namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    /// <summary>
    /// Panel para indicar, por tipo de tarjeta, en qué columna del archivo está cada dato.
    /// Se abre un archivo de ejemplo, se elige cada columna de la lista de títulos y se prueba antes de guardar.
    /// El formulario se arma por código (no tiene diseñador).
    /// </summary>
    public class frmFormatos_Tarjeta : Form
    {
        private readonly Formatos_Tarjeta formatos = new Formatos_Tarjeta();
        private readonly Func<string, int> buscarSuc;
        private readonly string carpeta;
        private Archivo_Tarjetas archivo;
        private bool cargando;

        private static readonly string[] Datos =
        {
            "Fecha", "Fecha para filtrar", "Fecha de pago", "Sucursal / cuenta", "Importe", "Lote", "Comprobante", "Tarjeta", "Estado"
        };
        private static readonly string[] Ayudas =
        {
            "obligatoria", "opcional, si no es la misma fecha", "opcional", "obligatoria", "obligatorio", "opcional", "opcional", "opcional", "opcional"
        };

        private ComboBox cmbTipo;
        private Label lblOrigen;
        private Label lblArchivo;
        private readonly ComboBox[] cmbCol = new ComboBox[Datos.Length];
        private readonly Label[] lblCol = new Label[Datos.Length];
        private NumericUpDown nuFila;
        private TextBox txtEstados;
        private TextBox txtDiaSiguiente;
        private TextBox txtSucDespues;
        private NumericUpDown nuComprobante;
        private NumericUpDown nuLote;
        private NumericUpDown nuTarjeta;
        private TextBox txtResultado;
        private DataGridView grdVista;

        public frmFormatos_Tarjeta(DataTable tipos, Func<string, int> buscarSuc, string carpeta)
        {
            this.buscarSuc = buscarSuc;
            this.carpeta = carpeta;
            Armar();

            cmbTipo.Items.Add("0. Predeterminado (tipos sin formato propio)");
            if (tipos != null)
            {
                foreach (DataRow dr in tipos.Rows)
                {
                    cmbTipo.Items.Add(tipos.Columns.Count > 1 ? $"{dr[0]}. {dr[1]}" : $"{dr[0]}. ");
                }
            }
            cmbTipo.SelectedIndex = 0;
        }

        #region " Armado de la pantalla "

        private void Armar()
        {
            Text = "Formatos de archivos de tarjetas";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(1040, 680);
            MinimumSize = new Size(900, 600);
            Font = new Font("Microsoft Sans Serif", 8.25F);

            Controls.Add(Etiqueta("Tipo de tarjeta", 12, 15, 90));
            cmbTipo = new ComboBox { Location = new Point(105, 12), Size = new Size(300, 21), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbTipo.SelectedIndexChanged += (s, e) => Cargar_Formato();
            Controls.Add(cmbTipo);

            lblOrigen = Etiqueta("", 415, 15, 300);
            Controls.Add(lblOrigen);

            var cmdAbrir = new Button { Text = "Abrir archivo de ejemplo...", Location = new Point(12, 42), Size = new Size(170, 24) };
            cmdAbrir.Click += (s, e) => Abrir_Archivo();
            Controls.Add(cmdAbrir);

            lblArchivo = Etiqueta("Abra un archivo del tipo elegido para ver sus columnas.", 190, 47, 800);
            Controls.Add(lblArchivo);

            // Columnas
            Controls.Add(Etiqueta("Dato", 12, 80, 120, true));
            Controls.Add(Etiqueta("Columna del archivo (título, o #número de columna)", 135, 80, 300, true));
            int y = 100;
            for (int i = 0; i < Datos.Length; i++)
            {
                Controls.Add(Etiqueta(Datos[i], 12, y + 3, 120));
                cmbCol[i] = new ComboBox { Location = new Point(135, y), Size = new Size(230, 21), DropDownStyle = ComboBoxStyle.DropDown };
                cmbCol[i].TextChanged += (s, e) => Actualizar_Ayudas();
                Controls.Add(cmbCol[i]);
                lblCol[i] = Etiqueta(Ayudas[i], 372, y + 3, 250);
                Controls.Add(lblCol[i]);
                y += 26;
            }

            var cmdNombres = new Button { Text = "Pasar posiciones (#) a títulos", Location = new Point(135, y + 2), Size = new Size(230, 24) };
            cmdNombres.Click += (s, e) => Pasar_A_Nombres();
            Controls.Add(cmdNombres);

            // Otras opciones
            int x = 640;
            Controls.Add(Etiqueta("Otras opciones", x, 80, 200, true));
            Controls.Add(Etiqueta("Fila de los títulos (0 = buscarla sola)", x, 103, 230));
            nuFila = Numero(x + 235, 100, 0, 1000);
            Controls.Add(nuFila);

            Controls.Add(Etiqueta("Estados que se importan (separados por ;)", x, 129, 230));
            txtEstados = new TextBox { Location = new Point(x + 235, 126), Size = new Size(150, 20) };
            Controls.Add(txtEstados);

            Controls.Add(Etiqueta("Estados que se pagan al día siguiente", x, 155, 230));
            txtDiaSiguiente = new TextBox { Location = new Point(x + 235, 152), Size = new Size(150, 20) };
            Controls.Add(txtDiaSiguiente);

            Controls.Add(Etiqueta("Sucursal: número después del texto", x, 181, 230));
            txtSucDespues = new TextBox { Location = new Point(x + 235, 178), Size = new Size(150, 20) };
            Controls.Add(txtSucDespues);
            Controls.Add(Etiqueta("(vacío = buscar la cuenta en Cuentas)", x + 235, 201, 200));

            Controls.Add(Etiqueta("Comprobante: cifras (+ primeras, - últimas)", x, 225, 230));
            nuComprobante = Numero(x + 235, 222, -30, 30);
            Controls.Add(nuComprobante);

            Controls.Add(Etiqueta("Lote si el archivo no lo trae", x, 251, 230));
            nuLote = Numero(x + 235, 248, 0, 999999);
            Controls.Add(nuLote);

            Controls.Add(Etiqueta("Tarjeta si el archivo no la trae", x, 277, 230));
            nuTarjeta = Numero(x + 235, 274, 0, 999999);
            Controls.Add(nuTarjeta);

            // Botones
            var cmdProbar = new Button { Text = "Probar", Location = new Point(x, 310), Size = new Size(90, 26) };
            cmdProbar.Click += (s, e) => Probar();
            Controls.Add(cmdProbar);

            var cmdGuardar = new Button { Text = "Guardar", Location = new Point(x + 98, 310), Size = new Size(90, 26) };
            cmdGuardar.Click += (s, e) => Guardar();
            Controls.Add(cmdGuardar);

            var cmdQuitar = new Button { Text = "Volver al predeterminado", Location = new Point(x + 196, 310), Size = new Size(160, 26) };
            cmdQuitar.Click += (s, e) => Quitar();
            Controls.Add(cmdQuitar);

            txtResultado = new TextBox
            {
                Location = new Point(12, 372),
                Size = new Size(1016, 70),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            Controls.Add(txtResultado);

            grdVista = new DataGridView
            {
                Location = new Point(12, 450),
                Size = new Size(1016, 218),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersWidth = 55,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None,
                SelectionMode = DataGridViewSelectionMode.CellSelect
            };
            Controls.Add(grdVista);
        }

        private static Label Etiqueta(string texto, int x, int y, int ancho, bool negrita = false)
        {
            var l = new Label { Text = texto, Location = new Point(x, y), Size = new Size(ancho, 16), AutoEllipsis = true };
            if (negrita) { l.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold); }
            return l;
        }

        private static NumericUpDown Numero(int x, int y, int minimo, int maximo)
        {
            return new NumericUpDown { Location = new Point(x, y), Size = new Size(70, 20), Minimum = minimo, Maximum = maximo };
        }

        #endregion

        private int Tipo_Elegido()
        {
            string s = cmbTipo.Text;
            int n;
            int p = s.IndexOf(".");
            return (p > 0 && int.TryParse(s.Substring(0, p), out n)) ? n : 0;
        }

        /// <summary>Muestra el formato vigente del tipo elegido.</summary>
        private void Cargar_Formato()
        {
            int tipo = Tipo_Elegido();
            List<Formato_Tarjeta> guardados = formatos.Guardados();
            Formato_Tarjeta f = Formato_Tarjeta.Elegir(guardados, tipo);

            bool propio = false;
            foreach (Formato_Tarjeta g in guardados)
            {
                if (g.Id_Tipo == tipo) { propio = true; }
            }
            lblOrigen.Text = propio ? "Formato guardado para este tipo." : "Usa el formato predeterminado (sin guardar).";

            cargando = true;
            string[] cols = Columnas(f);
            for (int i = 0; i < cmbCol.Length; i++) { cmbCol[i].Text = cols[i]; }
            nuFila.Value = Acotar(f.Fila_Encabezado, nuFila);
            txtEstados.Text = f.Estados_Validos;
            txtDiaSiguiente.Text = f.Estados_Dia_Siguiente;
            txtSucDespues.Text = f.Suc_Despues_De;
            nuComprobante.Value = Acotar(f.Comprobante_Largo, nuComprobante);
            nuLote.Value = Acotar(f.Lote_Fijo, nuLote);
            nuTarjeta.Value = Acotar(f.Tarjeta_Fijo, nuTarjeta);
            cargando = false;

            txtResultado.Text = "";
            Actualizar_Ayudas();
        }

        private static decimal Acotar(int valor, NumericUpDown nu)
        {
            return Math.Max(nu.Minimum, Math.Min(nu.Maximum, valor));
        }

        private static string[] Columnas(Formato_Tarjeta f)
        {
            return new[] { f.Col_Fecha, f.Col_Fecha_Filtro, f.Col_Fecha_Pago, f.Col_Sucursal, f.Col_Importe, f.Col_Lote,
                f.Col_Comprobante, f.Col_Tarjeta, f.Col_Estado };
        }

        /// <summary>Arma el formato con lo que hay en pantalla.</summary>
        private Formato_Tarjeta De_Pantalla()
        {
            var f = new Formato_Tarjeta();
            f.Id_Tipo = Tipo_Elegido();
            f.Fila_Encabezado = (int)nuFila.Value;
            f.Col_Fecha = cmbCol[0].Text.Trim();
            f.Col_Fecha_Filtro = cmbCol[1].Text.Trim();
            f.Col_Fecha_Pago = cmbCol[2].Text.Trim();
            f.Col_Sucursal = cmbCol[3].Text.Trim();
            f.Col_Importe = cmbCol[4].Text.Trim();
            f.Col_Lote = cmbCol[5].Text.Trim();
            f.Col_Comprobante = cmbCol[6].Text.Trim();
            f.Col_Tarjeta = cmbCol[7].Text.Trim();
            f.Col_Estado = cmbCol[8].Text.Trim();
            f.Estados_Validos = txtEstados.Text.Trim();
            f.Estados_Dia_Siguiente = txtDiaSiguiente.Text.Trim();
            f.Suc_Despues_De = txtSucDespues.Text.Trim();
            f.Comprobante_Largo = (int)nuComprobante.Value;
            f.Lote_Fijo = (int)nuLote.Value;
            f.Tarjeta_Fijo = (int)nuTarjeta.Value;
            return f;
        }

        /// <summary>Fila de títulos del archivo abierto según lo que hay en pantalla (0 si no se encuentra).</summary>
        private int Fila_Titulos(Formato_Tarjeta f)
        {
            if (archivo == null) { return 0; }
            List<string> faltantes;
            int fila = Lector_Tarjetas.Buscar_Encabezado(archivo, f, out faltantes);
            if (fila == 0 && faltantes.Count > 0)
            {
                // Con títulos que no coinciden se muestra igual la fila que más se parece a una de títulos
                fila = f.Fila_Encabezado > 0 ? f.Fila_Encabezado : Fila_Con_Mas_Textos();
            }
            if (fila == 0) { fila = Fila_Con_Mas_Textos(); }
            return fila;
        }

        /// <summary>Entre las primeras filas, la primera con la mayor cantidad de celdas de texto.</summary>
        private int Fila_Con_Mas_Textos()
        {
            int mejor = 0, mejorCant = 0;
            for (int fila = 1; fila <= archivo.Filas.Count && fila <= 100; fila++)
            {
                int cant = 0;
                foreach (object o in archivo.Filas[fila - 1])
                {
                    if (o is string && ((string)o).Trim().Length > 0) { cant++; }
                }
                if (cant > mejorCant) { mejorCant = cant; mejor = fila; }
            }
            return mejor;
        }

        private void Abrir_Archivo()
        {
            using (var od = new OpenFileDialog())
            {
                od.Filter = "Excel o CSV|*.xlsx;*.csv|Todos los archivos|*.*";
                if (!string.IsNullOrEmpty(carpeta) && Directory.Exists(carpeta)) { od.InitialDirectory = carpeta; }
                if (od.ShowDialog(this) != DialogResult.OK) { return; }

                Cursor = Cursors.WaitCursor;
                try
                {
                    archivo = Archivo_Tarjetas.Abrir(od.FileName);
                    lblArchivo.Text = od.FileName + $"  ({archivo.Filas.Count} filas, {archivo.Columnas} columnas)";

                    // Si el nombre trae el tipo (dos primeras cifras) se elige solo
                    int tipo = Lector_Tarjetas.Tipo_Del_Nombre(od.FileName);
                    for (int i = 0; tipo > 0 && i < cmbTipo.Items.Count; i++)
                    {
                        if (cmbTipo.Items[i].ToString().StartsWith(tipo + ".")) { cmbTipo.SelectedIndex = i; break; }
                    }
                }
                catch (Exception er)
                {
                    archivo = null;
                    MessageBox.Show("No se pudo abrir el archivo:\n" + er.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            Mostrar_Archivo();
            Actualizar_Ayudas();
        }

        /// <summary>Muestra las primeras filas del archivo y carga los títulos en las listas.</summary>
        private void Mostrar_Archivo()
        {
            grdVista.Rows.Clear();
            grdVista.Columns.Clear();
            if (archivo == null) { return; }

            for (int c = 0; c < archivo.Columnas; c++)
            {
                int n = grdVista.Columns.Add("c" + c, $"{Lector_Tarjetas.Letra(c)} (#{c + 1})");
                grdVista.Columns[n].Width = 110;
                grdVista.Columns[n].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            int fila = Fila_Titulos(De_Pantalla());
            int ultima = Math.Min(archivo.Filas.Count, Math.Max(fila, 1) + 30);
            for (int f = 1; f <= ultima; f++)
            {
                var valores = new object[archivo.Columnas];
                for (int c = 0; c < archivo.Columnas; c++) { valores[c] = Lector_Tarjetas.Texto(archivo.Celda(f, c)); }
                int n = grdVista.Rows.Add(valores);
                grdVista.Rows[n].HeaderCell.Value = f.ToString();
                if (f == fila) { grdVista.Rows[n].DefaultCellStyle.BackColor = Color.LightYellow; }
            }
            try
            {
                if (fila > 1 && fila <= grdVista.Rows.Count) { grdVista.FirstDisplayedScrollingRowIndex = fila - 1; }
            }
            catch (Exception) { }

            // Títulos disponibles para elegir en cada lista
            var titulos = new List<string>();
            if (fila > 0)
            {
                for (int c = 0; c < archivo.Columnas; c++)
                {
                    string t = Lector_Tarjetas.Texto(archivo.Celda(fila, c));
                    if (t.Length > 0 && !titulos.Contains(t)) { titulos.Add(t); }
                }
            }
            cargando = true;
            foreach (ComboBox cmb in cmbCol)
            {
                string actual = cmb.Text;
                cmb.Items.Clear();
                cmb.Items.Add("");
                foreach (string t in titulos) { cmb.Items.Add(t); }
                cmb.Text = actual;
            }
            cargando = false;
        }

        /// <summary>Al lado de cada columna muestra dónde la encontró en el archivo abierto.</summary>
        private void Actualizar_Ayudas()
        {
            if (cargando) { return; }
            Formato_Tarjeta f = De_Pantalla();
            int fila = Fila_Titulos(f);
            string[] cols = Columnas(f);

            for (int i = 0; i < cols.Length; i++)
            {
                lblCol[i].ForeColor = SystemColors.ControlText;
                if (cols[i].Length == 0 || archivo == null)
                {
                    lblCol[i].Text = Ayudas[i];
                    continue;
                }

                int c = Lector_Tarjetas.Columna(archivo, fila, cols[i]);
                if (c < 0 || c >= archivo.Columnas)
                {
                    lblCol[i].Text = "NO está en el archivo";
                    lblCol[i].ForeColor = Color.Red;
                }
                else if (Lector_Tarjetas.Posicion(cols[i]) >= 0)
                {
                    lblCol[i].Text = $"columna {Lector_Tarjetas.Letra(c)}: {Lector_Tarjetas.Texto(archivo.Celda(fila, c))}";
                }
                else
                {
                    lblCol[i].Text = $"columna {Lector_Tarjetas.Letra(c)} (#{c + 1})";
                }
            }
        }

        /// <summary>Reemplaza las columnas indicadas por posición (#12) por el título que tienen en el archivo abierto.</summary>
        private void Pasar_A_Nombres()
        {
            if (archivo == null)
            {
                MessageBox.Show("Primero abra un archivo de ejemplo de este tipo.", Text);
                return;
            }

            Formato_Tarjeta f = De_Pantalla();
            int fila = f.Fila_Encabezado > 0 ? f.Fila_Encabezado : Fila_Titulos(f);
            if (fila == 0) { return; }

            // Títulos repetidos no sirven para identificar la columna
            var veces = new Dictionary<string, int>();
            for (int c = 0; c < archivo.Columnas; c++)
            {
                string n = Lector_Tarjetas.Normalizar(Lector_Tarjetas.Texto(archivo.Celda(fila, c)));
                if (n.Length == 0) { continue; }
                veces[n] = veces.ContainsKey(n) ? veces[n] + 1 : 1;
            }

            int cambiadas = 0;
            cargando = true;
            foreach (ComboBox cmb in cmbCol)
            {
                int p = Lector_Tarjetas.Posicion(cmb.Text);
                if (p < 0) { continue; }
                string titulo = Lector_Tarjetas.Texto(archivo.Celda(fila, p));
                string n = Lector_Tarjetas.Normalizar(titulo);
                if (n.Length > 0 && veces[n] == 1 && !titulo.Contains("|"))
                {
                    cmb.Text = titulo;
                    cambiadas++;
                }
            }
            if (cambiadas > 0) { nuFila.Value = 0; }
            cargando = false;

            Actualizar_Ayudas();
            txtResultado.Text = $"Títulos tomados de la fila {fila}: {cambiadas} columnas cambiadas. Revise que sean las correctas, pruebe y guarde.";
        }

        private void Probar()
        {
            if (archivo == null)
            {
                MessageBox.Show("Primero abra un archivo de ejemplo de este tipo.", Text);
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                // Sin filtro de fechas ni de sucursal: se prueba el archivo entero
                Resultado_Lectura r = Lector_Tarjetas.Leer(archivo, De_Pantalla(), null, null, 0, buscarSuc);
                string s = r.Ok ? "CORRECTO. " : "CON PROBLEMAS. ";
                s += r.Resumen() + ". Total: " + r.Total.ToString("C2") + Environment.NewLine;
                if (r.Movimientos.Count > 0)
                {
                    Movimiento_Tarjeta m = r.Movimientos[0];
                    s += $"Primer movimiento (fila {m.Fila}): fecha {m.Fecha:dd/MM/yyyy}, pago {m.Fecha_Pago:dd/MM/yyyy}, sucursal {m.Suc}, " +
                        $"importe {m.Importe:N2}, lote {m.Lote}, comprobante {m.Comprobante}, tarjeta {m.Tarjeta}" + Environment.NewLine;
                }
                s += r.Texto_Errores();
                txtResultado.Text = s;
            }
            catch (Exception er)
            {
                txtResultado.Text = "Error al probar: " + er.Message;
            }
            Cursor = Cursors.Default;
        }

        private void Guardar()
        {
            Formato_Tarjeta f = De_Pantalla();
            if (f.Col_Fecha.Length == 0 || f.Col_Importe.Length == 0 || f.Col_Sucursal.Length == 0)
            {
                MessageBox.Show("Fecha, sucursal e importe son obligatorios.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (formatos.Guardar(f))
            {
                Cargar_Formato();
                txtResultado.Text = "Formato guardado.";
            }
            else
            {
                MessageBox.Show("No se pudo guardar el formato:\n" + formatos.Ultimo_Error +
                    "\n\nSi la tabla dbGastos.dbo.Formatos_Tarjeta no existe, hay que crearla con el script Formatos_Tarjeta.sql.",
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Quitar()
        {
            if (MessageBox.Show("¿Borrar el formato guardado de este tipo y volver al predeterminado?", Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) { return; }

            if (!formatos.Quitar(Tipo_Elegido()))
            {
                MessageBox.Show("No se pudo borrar:\n" + formatos.Ultimo_Error, Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cargar_Formato();
        }
    }
}
