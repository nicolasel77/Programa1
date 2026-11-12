namespace Programa1.Carga.Tesoreria
{
    using DB.Tesoreria;
    using Decidir;
    using Decidir.Constants;
    using Decidir.Model;
    using OfficeOpenXml;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Windows.Forms;

    public partial class frmLeer_Tarjetas : Form
    {
        private Leer_Tarjetas leer;
        private Formatos_Tarjeta formatos = new Formatos_Tarjeta();
        private Herramientas.Herramientas h = new Herramientas.Herramientas();
        string fcarpeta = @"E:\Tarjetas";
        DataTable dt = null;

        public frmLeer_Tarjetas()
        {
            InitializeComponent();
            leer = new Leer_Tarjetas();
            h.Llenar_List(lstTitulares, leer.titulares());
            h.Llenar_List(cmbSuc, leer.sucdatos());
            lstTitulares.SelectedIndex = 0;
        }

        private void frmLeer_Tarjetas_Load(object sender, EventArgs e)
        {
            string s = leer.Carpeta_guardada();
            if (s.Length == 0)
            { leer.Actualizar_carpeta(fcarpeta); }
            else
            { fcarpeta = s; }

            cmdCarpeta.Text = fcarpeta;

            Cargar_cuentas();

            h.Llenar_List(lstTipo, leer.tipos_tarjeta.Datos_Vista());

            dt = leer.Datos_Vista("Id = 0");
            grdDatos.MostrarDatos(dt, true, false);
            grdDatos.AutosizeAll();
            grdDatos.set_ColW(0, 0);

            grdCuentas.TeclasManejadas = new int[] { 13, 32, 42, 43, 45, 46, 47, 112, 123 };

            dtFecha.Value = DateTime.Today.AddDays((((int)DateTime.Today.DayOfWeek) + 6) * -1);
            dtMaxima.Value = dtFecha.Value.AddDays(6);
        }

        private void chAuto_CheckedChanged(object sender, EventArgs e)
        {
            tiAuto.Enabled = chAuto.Checked;
        }

        /// <summary>
        /// Mueve el archivo ya importado a la subcarpeta Back para que no se vuelva a leer.
        /// Devuelve false si no se pudo mover.
        /// </summary>
        private bool Mover_Archivo()
        {
            string s = lblArchivo.Text;
            lblArchivo.Text = "";
            if (s.Length == 0 || !File.Exists(s)) { return true; }

            try
            {
                string back = Path.Combine(fcarpeta, "Back");
                Directory.CreateDirectory(back);

                string nombre = Path.GetFileNameWithoutExtension(s);
                string ex = Path.GetExtension(s);
                string n = Path.Combine(back, nombre + ex);
                int i = 1;
                while (File.Exists(n))
                {
                    n = Path.Combine(back, nombre + " (" + i + ")" + ex);
                    i += 1;
                }

                File.Move(s, n);
                cmdRuta.Text = "Guardado: " + n;
                return true;
            }
            catch (Exception er)
            {
                MessageBox.Show("Los movimientos se guardaron, pero el archivo no se pudo mover a la carpeta Back:\n" + er.Message +
                    "\n\nMuévalo a mano para que no se importe dos veces.", "Leer tarjetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void cmdEscribir_Click(object sender, EventArgs e)
        {
            Escribir();
        }

        /// <summary>
        /// Lee el archivo seleccionado (Excel o CSV) con el formato configurado para el tipo de tarjeta,
        /// toma los movimientos dentro del rango de fechas y de la sucursal filtrada,
        /// y los carga en la grilla. No guarda nada.
        /// </summary>
        /// <param name="tipo">Tipo de tarjeta. 0 = el seleccionado en la lista.</param>
        /// <returns>true si el archivo se leyó sin problemas y se puede guardar.</returns>
        private bool Escribir(int tipo = 0)
        {
            lblTotal.Text = "";
            string archivo = lblArchivo.Text;
            if (archivo.Length == 0) { return false; }

            if (tipo == 0 && lstTipo.SelectedIndex > -1) { tipo = h.Codigo_Seleccionado(lstTipo.Text); }
            if (tipo == 0)
            {
                MessageBox.Show("No se pudo saber el tipo de tarjeta de " + Path.GetFileName(archivo) +
                    ".\nEl nombre del archivo debe empezar con el número de tipo (por ejemplo 13) o hay que seleccionar el tipo en la lista.",
                    "Leer tarjetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                leer.vtipo = tipo;
                int f_suc = h.Codigo_Seleccionado(cmbSuc.Text);

                Formato_Tarjeta formato = formatos.Buscar(tipo);
                Archivo_Tarjetas datos = Archivo_Tarjetas.Abrir(archivo);
                Resultado_Lectura r = Lector_Tarjetas.Leer(datos, formato, dtFecha.Value, dtMaxima.Value, f_suc, leer.suc_cuentas.buscar_suc);

                dt.Rows.Clear();
                foreach (Movimiento_Tarjeta m in r.Movimientos)
                {
                    DataRow nrow = dt.NewRow();

                    nrow["Fecha"] = m.Fecha;
                    nrow["Fecha_Pago"] = m.Fecha_Pago;
                    nrow["Comprobante"] = m.Comprobante;
                    nrow["Suc"] = m.Suc;
                    nrow["Tarjeta"] = m.Tarjeta;
                    nrow["Importe"] = m.Importe;
                    nrow["Lote"] = m.Lote;
                    nrow["Id_Tipo"] = tipo;
                    nrow["Acreditado"] = true;

                    dt.Rows.Add(nrow);
                }

                // Mostrar datos en la grilla y calcular totales
                grdDatos.MostrarDatos(dt, true, false);
                grdDatos.AutosizeAll();
                grdDatos.set_ColW(0, 0);

                if (!r.Ok)
                {
                    lblTotal.Text = "No se importó: " + Path.GetFileName(archivo);
                    MessageBox.Show("No se puede importar " + Path.GetFileName(archivo) + " (tipo " + tipo + "):\n\n" + r.Texto_Errores(),
                        "Leer tarjetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                lblTotal.Text = "Total: " + r.Total.ToString("C1") + "  (" + r.Resumen() + ")";
                return true;
            }
            catch (Exception er)
            {
                lblTotal.Text = er.Message;
                MessageBox.Show("No se pudo leer " + Path.GetFileName(archivo) + ":\n" + er.Message,
                    "Leer tarjetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Guarda los movimientos cargados (todos o ninguno) y mueve el archivo a Back.
        /// </summary>
        /// <returns>true si se guardó todo y el archivo quedó movido.</returns>
        private bool Guardar()
        {
            if (leer.Fecha_Cerrada(dtFecha.Value) || leer.Fecha_Cerrada(dtMaxima.Value))
            {
                MessageBox.Show("La fecha se encuentra cerrada", "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var movimientos = new List<Movimiento_Tarjeta>();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var m = new Movimiento_Tarjeta();
                    m.Fecha = Convert.ToDateTime(dr["Fecha"]);
                    m.Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]);
                    m.Importe = Math.Round(Convert.ToDecimal(dr["Importe"]), 2);
                    m.Suc = Convert.ToInt32(Valor_O_Cero(dr["Suc"]));
                    m.Fecha_Pago = dr["Fecha_Pago"] == DBNull.Value ? m.Fecha : Convert.ToDateTime(dr["Fecha_Pago"]);
                    m.Lote = Convert.ToInt32(Valor_O_Cero(dr["Lote"]));
                    m.Comprobante = Convert.ToInt64(Valor_O_Cero(dr["Comprobante"]));
                    m.Tarjeta = Convert.ToInt64(Valor_O_Cero(dr["Tarjeta"]));
                    movimientos.Add(m);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("No se guardó nada: hay un movimiento con datos inválidos.\n" + er.Message,
                    "Leer tarjetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            Cursor = Cursors.WaitCursor;
            lblpb.Text = "Guardando";
            lblpb.Visible = true;
            Application.DoEvents();

            string error = leer.Guardar_Movimientos(movimientos);

            lblpb.Visible = false;
            Cursor = Cursors.Default;

            if (error.Length > 0)
            {
                MessageBox.Show("No se guardó ningún movimiento:\n" + error, "Leer tarjetas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            dt.Rows.Clear();
            grdDatos.Rows = 1;
            lblTotal.Text = "";
            return Mover_Archivo();
        }

        private static object Valor_O_Cero(object valor)
        {
            if (valor == null || valor == DBNull.Value || valor.ToString().Length == 0) { return 0; }
            return valor;
        }

        /// <summary>
        /// Importa todos los Excel y CSV de la carpeta. El tipo de tarjeta sale de las dos primeras
        /// cifras del nombre del archivo; si el nombre no empieza con un número se usa el tipo seleccionado.
        /// </summary>
        private void tiAuto_Tick(object sender, EventArgs e)
        {
            tiAuto.Stop();
            bool todoBien = true;

            if (Directory.Exists(fcarpeta))
            {
                var archivos = new List<string>();
                archivos.AddRange(Directory.GetFiles(fcarpeta, "*.xlsx", SearchOption.TopDirectoryOnly));
                archivos.AddRange(Directory.GetFiles(fcarpeta, "*.csv", SearchOption.TopDirectoryOnly));

                foreach (string s in archivos)
                {
                    // Archivos temporales que crea Excel mientras el libro está abierto
                    if (Path.GetFileName(s).StartsWith("~$")) { continue; }

                    lblArchivo.Text = s;
                    Application.DoEvents();

                    if (!(Escribir(Lector_Tarjetas.Tipo_Del_Nombre(s)) && Guardar()))
                    {
                        todoBien = false;
                        lblArchivo.Text = "";
                    }
                }
            }

            if (todoBien)
            {
                if (chAuto.Checked) { tiAuto.Start(); }
            }
            else
            {
                // Se apaga el modo automático para no reintentar cada 5 segundos el archivo con problemas
                chAuto.Checked = false;
            }
        }

        private void cmdFormatos_Click(object sender, EventArgs e)
        {
            bool auto = tiAuto.Enabled;
            tiAuto.Stop();
            using (var fr = new frmFormatos_Tarjeta(leer.tipos_tarjeta.Datos_Vista(), leer.suc_cuentas.buscar_suc, fcarpeta))
            {
                fr.ShowDialog(this);
            }
            if (auto && chAuto.Checked) { tiAuto.Start(); }
        }

        private void cmdCarpeta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fc = new FolderBrowserDialog();
            if (fc.ShowDialog() == DialogResult.OK)
            {
                fcarpeta = fc.SelectedPath;
                cmdCarpeta.Text = "Carpeta: " + fcarpeta;
                leer.Actualizar_carpeta(fcarpeta);
            }
        }

        private void grdCuentas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Delete))
            { grdCuentas.BorrarFila(grdCuentas.Row); }
        }

        private void grdCuentas_Editado(short f, short c, object a)
        {
            string col = grdCuentas.get_Texto(0, c).ToString();
            if (rdCuentas.Checked)
            {
                if (grdCuentas.EsUltimaFila())
                {
                    if (c == grdCuentas.get_ColIndex("Suc"))
                    {
                        leer.Sucursal.ID = Convert.ToInt32(a);
                        leer.Sucursal.Existe();
                        leer.suc_cuentas.suc = Convert.ToInt32(a);
                        grdCuentas.set_Texto(f, c, a);
                        grdCuentas.set_Texto(f, grdCuentas.get_ColIndex("Nombre"), leer.Sucursal.Nombre);
                        grdCuentas.ActivarCelda(f, grdCuentas.get_ColIndex("N_Cuenta"));
                    }
                    else if (c == grdCuentas.get_ColIndex("N_Cuenta"))
                    {
                        if (grdCuentas.get_Texto(f, 0).ToString() != "0")
                        {
                            grdCuentas.set_Texto(f, c, a);
                            leer.suc_cuentas.Agregar();
                        }
                    }
                }
                else
                {
                    switch (col)
                    {
                        case "Suc":
                            leer.suc_cuentas.Actualizar("Suc", a);

                            leer.Sucursal.ID = Convert.ToInt32(a);
                            leer.Sucursal.Existe();
                            leer.suc_cuentas.suc = Convert.ToInt32(a);
                            grdCuentas.set_Texto(f, c, a);
                            grdCuentas.set_Texto(f, grdCuentas.get_ColIndex("Nombre"), leer.Sucursal.Nombre);
                            break;

                        case "N_Cuenta":
                            grdCuentas.set_Texto(f, c, a);

                            leer.suc_cuentas.Actualizar("N_Cuenta", a);
                            leer.suc_cuentas.N_Cuenta = a.ToString();
                            break;

                        case "Tipo":
                            leer.suc_cuentas.Actualizar("Tipo", a);

                            leer.tipos_tarjeta.ID = Convert.ToInt32(a);
                            leer.suc_cuentas.Tipo = Convert.ToInt32(a);
                            leer.tipos_tarjeta.Existe();

                            grdCuentas.set_Texto(f, c, a);
                            grdCuentas.set_Texto(f, grdCuentas.get_ColIndex("Descripcion"), leer.tipos_tarjeta.Nombre);
                            break;

                        case "Titular":
                            grdCuentas.set_Texto(f, c, a);

                            leer.suc_cuentas.Actualizar("Titular", a);
                            leer.suc_cuentas.Titular = a.ToString();
                            break;
                    }
                }
            }
            else
            {
                if (col == "Suc")
                {
                    if (a.ToString() != "0")
                    {
                        leer.Sucursal.ID = Convert.ToInt32(a);
                        leer.Sucursal.Existe();
                        leer.suc_cuentas.suc = Convert.ToInt32(a);
                        leer.suc_cuentas.Titular = h.Nombre_Seleccionado(lstTitulares.Text);
                        leer.suc_cuentas.N_Cuenta = grdCuentas.get_Texto(f, grdCuentas.get_ColIndex("Terminal_Ticket")).ToString();

                        if (grdCuentas.get_Texto(f, c).ToString() == "0")
                        { leer.suc_cuentas.Agregar_terminalesMP(grdCuentas.get_Texto(f, grdCuentas.get_ColIndex("Id_Terminal"))); }
                        else { leer.suc_cuentas.Actualizar_terminalesMP(a, grdCuentas.get_Texto(f, grdCuentas.get_ColIndex("Id_Terminal"))); }


                        grdCuentas.set_Texto(f, c, a);
                        grdCuentas.set_Texto(f, grdCuentas.get_ColIndex("Nombre"), leer.Sucursal.Nombre);
                    }
                }
            }
            grdCuentas.ActivarCelda(f + 1, c);
        }

        private void grdCuentas_CambioFila(short Fila)
        {
            if (Fila < grdCuentas.Rows - 1)
            {
                leer.suc_cuentas.suc = Convert.ToInt32(grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("Suc")));
                leer.suc_cuentas.N_Cuenta = grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("N_Cuenta")).ToString();
                leer.suc_cuentas.Tipo = Convert.ToInt32(grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("Tipo")));
                leer.suc_cuentas.Titular = grdCuentas.get_Texto(Fila, grdCuentas.get_ColIndex("Titular")).ToString();
            }
        }

        private async void Cargar_cuentas()
        {
            if (rdCuentas.Checked)
            {
                lblCuentas.Text = "Cuentas";
                grdCuentas.MostrarDatos(leer.suc_cuentas.Datos_Vista(), true, true);
                grdCuentas.AutosizeAll();
                for (int i = 1; i <= grdCuentas.Rows - 1; i++)
                {
                    if (leer.suc_cuentas.Cuentas_Compartidas(grdCuentas.get_Texto(i, 2).ToString()) == true)
                    {
                        for (int c = 0; c <= grdCuentas.Cols - 1; c++)
                        { grdCuentas.set_ColorLetraCelda(i, c, Color.Red); }
                    }
                }
            }
            else
            {
                lblCuentas.Text = "Terminales MP de " + lstTitulares.Text.Substring(lstTitulares.Text.IndexOf(".") + 1);
                Cursor = Cursors.WaitCursor;
                using (HttpClient client = new HttpClient())
                {
                    string AccessToken = leer.Bearer(h.Codigo_Seleccionado(lstTitulares.Text));
                    dt = leer.suc_cuentas.Id_TerminalesMP();
                    dt.Rows.Clear();

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                    HttpResponseMessage response;


                    response = await client.GetAsync($"https://api.mercadopago.com/point/integration-api/devices?offset=0&limit=50");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        foreach (var venta in ventas.RootElement.GetProperty("devices").EnumerateArray())
                        {
                            if (venta.GetProperty("pos_id").ToString().Length > 2)
                            {
                                DataRow nrow = dt.NewRow();

                                //nrow["Posnet_id"] = Convert.ToInt32(venta["pos_id"]?.ToString());
                                nrow["Id_Terminal"] = venta.GetProperty("pos_id").ToString();

                                leer.Sucursal.ID = leer.suc_cuentas.buscar_terminalMP(Convert.ToInt32(venta.GetProperty("pos_id").ToString()));

                                nrow["Suc"] = leer.Sucursal.ID;
                                nrow["Nombre"] = leer.suc_cuentas.buscar_nombreterminalMP(leer.Sucursal.ID);

                                nrow["Terminal_Ticket"] = venta.GetProperty("id").ToString().Substring((int)venta.GetProperty("id").ToString().IndexOf("POS") + 3);

                                dt.Rows.Add(nrow);
                            }
                        }
                    }
                    else { MessageBox.Show("No se pudieron cargar las terminales.", default, MessageBoxButtons.OK); }

                    grdCuentas.MostrarDatos(dt, true, false);
                    grdCuentas.AutosizeAll();
                    grdCuentas.Ordenar(0);

                    dt = leer.Datos_Vista("Id = 0");

                    Application.DoEvents();

                    Cursor = Cursors.Default;
                }
            }
        }

        private void grdCuentas_CambioColumna(int col)
        {
            if (col == 1 | col == 4)
            { grdCuentas.EnableEdicion = false; }
            else { grdCuentas.EnableEdicion = true; }
        }

        private void lstTipo_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            { lstTipo.SelectedIndex = -1; }
        }

        private void cmdRecargar_Click(object sender, EventArgs e)
        {
            Cargar_cuentas();
        }
        private void cmbSuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSuc.SelectedIndex > -1) { lstTitulares.SelectedIndexChanged -= lstTitulares_SelectedIndexChanged; lstTitulares.SelectedIndex = leer.titular(h.Codigo_Seleccionado(cmbSuc.Text)) - 1; lstTitulares.SelectedIndexChanged += lstTitulares_SelectedIndexChanged; }
        }
        private void lstTitulares_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSuc.SelectedIndexChanged -= cmbSuc_SelectedIndexChanged;
            cmbSuc.SelectedIndex = -1;
            cmbSuc.SelectedIndexChanged += cmbSuc_SelectedIndexChanged;

            if (!rdCuentas.Checked) { Cargar_cuentas(); }
        }

        private async void cmdMP_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (HttpClient client = new HttpClient())
            {
                string AccessToken = leer.Bearer(h.Codigo_Seleccionado(lstTitulares.Text));

                dt.Rows.Clear();
                string beginDate = dtFecha.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                string endDate = dtMaxima.Value.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");
                int offset = 0;
                int total = 0;
                if (cmbSuc.SelectedIndex > -1) { endDate += $"&pos_id={leer.terminalMP(h.Codigo_Seleccionado(cmbSuc.Text))}"; }

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                HttpResponseMessage response;

                //Esto es porque se hace a veces MP solo envía una parte de las ventas

                for (int i = 0; i < 5; i++)
                {
                    response = await client.GetAsync($"https://api.mercadopago.com/v1/payments/search?begin_date={beginDate}&end_date={endDate}&status=approved,pending,in_process&limit=50&offset={offset}");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas.RootElement.GetProperty("paging");
                        if (total < Convert.ToInt32(paging.GetProperty("total").ToString())) { total = Convert.ToInt32(paging.GetProperty("total").ToString()); }
                    }
                }

                for (int i = 0; offset < total; i++)
                {
                    offset = i * 50;

                    try
                    {
                        response = await client.GetAsync($"https://api.mercadopago.com/v1/payments/search?begin_date={beginDate}&end_date={endDate}&status=approved,pending,in_process&limit=50&offset={offset}");
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas.RootElement.GetProperty("paging");
                        if (total > Convert.ToInt32(paging.GetProperty("total").ToString())) { i += -1; continue; }


                        foreach (var venta in ventas.RootElement.GetProperty("results").EnumerateArray())
                        {
                            DataRow nrow = dt.NewRow();

                            nrow["Comprobante"] = venta.GetProperty("id").ToString();

                            var poi = venta.GetProperty("point_of_interaction");
                            //var device;// = poi.GetProperty("device");
                            // ver si existe la propiedad device antes de intentar acceder a ella

                            // C#
                            JsonElement device = default;
                            bool hasDevice = poi.ValueKind == JsonValueKind.Object && poi.TryGetProperty("device", out device);
                            //bool hasDevice = poi.TryGetProperty("device", out var device);

                            nrow["Fecha"] = Convert.ToDateTime(venta.GetProperty("date_created").ToString());
                            nrow["Fecha_Pago"] = Convert.ToDateTime(venta.GetProperty("date_created").ToString());
                            nrow["Importe"] = Convert.ToSingle(venta.GetProperty("transaction_amount").ToString().Replace(".", ","));

                            if (!hasDevice || device.ValueKind == JsonValueKind.Null)
                            {
                                // Buscar la palabra SMARTPOS en responseData
                                if (responseData.Contains("SMARTPOS"))
                                {
                                    int indexStart = responseData.IndexOf("SMARTPOS");
                                    if (indexStart < 0)
                                    {
                                        nrow["Suc"] = 0;
                                    }
                                    else
                                    {
                                        string sucursal = responseData.Substring(indexStart + 8, 10);
                                        nrow["Suc"] = leer.suc_cuentas.buscar_suc(sucursal);
                                    }
                                }
                                else
                                {
                                    nrow["Suc"] = 0;
                                }
                            }
                            else
                            {
                                string termial = device.GetProperty("serial_number").ToString();
                                if (termial.StartsWith("SMART"))
                                {
                                    nrow["Suc"] = leer.suc_cuentas.buscar_suc(device.GetProperty("serial_number").ToString().Substring(8) ?? "N/A");
                                }
                                else
                                {
                                    nrow["Suc"] = leer.suc_cuentas.buscar_suc(device.GetProperty("serial_number").ToString().Substring(8) ?? "N/A");
                                }
                            }

                            nrow["id_Tipo"] = 14;
                            nrow["Tarjeta"] = 1;
                            nrow["Lote"] = 1;

                            dt.Rows.Add(nrow);
                        }
                    }
                    else { i += -1; continue; }
                }
                grdDatos.MostrarDatos(dt, true, false);
                grdDatos.AutosizeAll();
                grdDatos.set_ColW(0, 0);
                double t = grdDatos.SumarCol(grdDatos.get_ColIndex("Importe"), false);
                lblTotal.Text = "Total: " + t.ToString("C1");
                pbLeer.Visible = false;
                lblpb.Visible = false;
                Application.DoEvents();

                Cursor = Cursors.Default;

                if (grdDatos.Rows > 0)
                { Guardar(); }
            }
        }

        private void rdTerminalesMP_CheckedChanged(object sender, EventArgs e)
        {
            Cargar_cuentas();
        }

        private async void cmdExcel_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            using (HttpClient client = new HttpClient())
            {
                string AccessToken = leer.Bearer(h.Codigo_Seleccionado(lstTitulares.Text));

                dt.Rows.Clear();
                // Chequear que no este ya agregada al columna
                if (!dt.Columns.Contains("Datos_Adicionales"))
                {
                    // Agregar una columna tipo texto a dt para los datos restantes
                    DataColumn col = new DataColumn();
                    col.ColumnName = "Datos_Adicionales";
                    col.DataType = typeof(string);
                    col.DefaultValue = "";
                    dt.Columns.Add(col);
                }
                string beginDate = dtFecha.Value.ToString("yyyy-MM-ddTHH:mm:ssZ");
                string endDate = dtMaxima.Value.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-ddTHH:mm:ssZ");
                int offset = 0;
                int total = 0;
                if (cmbSuc.SelectedIndex > -1) { endDate += $"&pos_id={leer.terminalMP(h.Codigo_Seleccionado(cmbSuc.Text))}"; }

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", AccessToken);
                HttpResponseMessage response;

                //Esto es porque se hace a veces MP solo envía una parte de las ventas

                for (int i = 0; i < 5; i++)
                {
                    response = await client.GetAsync($"https://api.mercadopago.com/v1/payments/search?begin_date={beginDate}&end_date={endDate}&status=approved,pending,in_process&limit=50&offset={offset}");
                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas.RootElement.GetProperty("paging");
                        if (total < Convert.ToInt32(paging.GetProperty("total"))) { total = Convert.ToInt32(paging.GetProperty("total")); }
                    }
                }

                for (int i = 0; offset < total; i++)
                {
                    offset = i * 50;

                    response = await client.GetAsync($"https://api.mercadopago.com/v1/payments/search?begin_date={beginDate}&end_date={endDate}&status=approved,pending,in_process&limit=50&offset={offset}");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        JsonDocument ventas = JsonDocument.Parse(responseData);
                        StringBuilder sb = new StringBuilder();

                        var paging = ventas.RootElement.GetProperty("paging");
                        if (total > Convert.ToInt32(paging.GetProperty("total"))) { i += -1; continue; }


                        foreach (var venta in ventas.RootElement.GetProperty("results").EnumerateArray())
                        {
                            DataRow nrow = dt.NewRow();

                            nrow["Comprobante"] = venta.GetProperty("id").ToString();

                            var poi = venta.GetProperty("point_of_interaction");
                            var device = poi.GetProperty("device");

                            bool hasDevice = poi.TryGetProperty("device", out device);

                            nrow["Fecha"] = Convert.ToDateTime(venta.GetProperty("date_created").ToString());
                            nrow["Fecha_Pago"] = Convert.ToDateTime(venta.GetProperty("date_created").ToString());
                            nrow["Importe"] = Convert.ToSingle(venta.GetProperty("transaction_amount").ToString().Replace(".", ","));
                            nrow["Datos_Adicionales"] = $"";
                            //nrow["Datos_Adicionales"] = $"Collector Id: {venta["collector_id"]} - Tipo de pago: {venta["payment_type_id"]?.ToString()} - Detalles: {venta["description"]?.ToString()}";

                            if (!hasDevice || device.ValueKind == JsonValueKind.Null)
                            {
                                // Buscar la palabra SMARTPOS en responseData
                                if (responseData.Contains("SMARTPOS"))
                                {
                                    int indexStart = responseData.IndexOf("SMARTPOS");
                                    if (indexStart < 0)
                                    {
                                        nrow["Suc"] = 0;
                                    }
                                    else
                                    {
                                        string sucursal = responseData.Substring(indexStart + 8, 10);
                                        nrow["Suc"] = leer.suc_cuentas.buscar_suc(sucursal);
                                    }
                                }
                                else
                                {
                                    nrow["Suc"] = 0;
                                }
                            }
                            else
                            {
                                string termial = device.GetProperty("serial_number").ToString();
                                if (termial.StartsWith("SMART"))
                                {
                                    nrow["Suc"] = leer.suc_cuentas.buscar_suc(device.GetProperty("serial_number").ToString().Substring(8) ?? "N/A");
                                }
                                else
                                {
                                    nrow["Suc"] = leer.suc_cuentas.buscar_suc(device.GetProperty("serial_number").ToString().Substring(8) ?? "N/A");
                                }
                            }

                            nrow["id_Tipo"] = 14;
                            nrow["Tarjeta"] = 1;
                            nrow["Lote"] = 1;

                            dt.Rows.Add(nrow);
                        }
                    }
                    else { i += -1; continue; }
                }
                grdDatos.MostrarDatos(dt, true, false);
                grdDatos.AutosizeAll();
                grdDatos.set_ColW(0, 0);
                double t = grdDatos.SumarCol(grdDatos.get_ColIndex("Importe"), false);
                lblTotal.Text = "Total: " + t.ToString("C1");
                pbLeer.Visible = false;
                lblpb.Visible = false;
                Application.DoEvents();

                Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string privateApiKey = "019dab64-4dd8-7015-8b69-5bc9a96a8b4b";
            string publicApiKey = "019dab64-4df1-7347-97c5-678060742afd";

            privateApiKey = "92b71cf711ca41f78362a7134f87ff65";
            publicApiKey = "e9cdb99fff374b5f91da4480c8dca741";

            //Para el ambiente de desarrollo
            DecidirConnector decidir = new DecidirConnector(Ambiente.AMBIENTE_SANDBOX, privateApiKey, publicApiKey);

            GetAllPaymentsResponse pagos = decidir.GetAllPayments(null, null, dtFecha.Value, dtMaxima.Value);

            //Mostrar los pagos en la grilla
            foreach (PaymentResponse pago in pagos.results)
            {
                DataRow nrow = dt.NewRow();
                nrow["Comprobante"] = pago.id;
                nrow["Fecha"] = Convert.ToDateTime(pago.date);
                nrow["Importe"] = Convert.ToSingle(pago.amount);
                dt.Rows.Add(nrow);
            }
            grdDatos.MostrarDatos(dt, true, false);
        }
    }
}
