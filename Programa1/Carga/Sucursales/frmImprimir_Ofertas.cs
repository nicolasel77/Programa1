namespace Programa1.Carga.Sucursales
{
    using Programa1.DB.Sucursales;
    using System;
    using System.Data;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;

    public partial class frmImprimir_Ofertas : Form
    {
        Listas_Ofertas listas = new Listas_Ofertas();
        Herramientas.Herramientas h = new Herramientas.Herramientas();

        #region " Columnas "
        private readonly Byte c_Id;
        private readonly Byte c_Orden;
        private readonly Byte c_IdProd;
        private readonly Byte c_Nombre;
        private readonly Byte c_Id_Tipo;
        private readonly Byte c_Tipo;
        private readonly Byte c_Descripcion;
        private readonly Byte c_Costo;
        private readonly Byte c_Detalle;
        private readonly Byte c_Pintar;
        private readonly Byte c_Id_lista;
        #endregion

        CultureInfo ci = new CultureInfo("Es-Es");

        bool cargando_lista = false;
        bool avisado = false;

        public frmImprimir_Ofertas()
        {
            InitializeComponent();
            h.Llenar_List(lstSucs, listas.sucdatos());
            h.Llenar_List(lstListas, listas.lista.Datos());
            h.Llenar_List(cmbTitulos, listas.titulos.Datos());
            grdLista.MostrarDatos(listas.Datos_Vista("ID=0"), true);

            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdLista.TeclasManejadas = n;

            c_Id = Convert.ToByte(grdLista.get_ColIndex("Id"));
            c_Orden = Convert.ToByte(grdLista.get_ColIndex("Orden"));
            c_IdProd = Convert.ToByte(grdLista.get_ColIndex("Id_Prod"));
            c_Nombre = Convert.ToByte(grdLista.get_ColIndex("Nombre"));
            c_Id_Tipo = Convert.ToByte(grdLista.get_ColIndex("Id_Tipo"));
            c_Tipo = Convert.ToByte(grdLista.get_ColIndex("Tipo"));
            c_Descripcion = Convert.ToByte(grdLista.get_ColIndex("Descripcion"));
            c_Detalle = Convert.ToByte(grdLista.get_ColIndex("Detalle"));
            c_Pintar = Convert.ToByte(grdLista.get_ColIndex("Pintar"));
            c_Costo = Convert.ToByte(grdLista.get_ColIndex("Costo"));
            c_Id_lista = Convert.ToByte(grdLista.get_ColIndex("Id_Lista"));
            Formato_Grilla();
        }

        private void Formato_Grilla()
        {
            grdLista.AutosizeAll();
            grdLista.set_ColW(c_Nombre, 200);
            grdLista.set_ColW(c_Tipo, 100);
            grdLista.set_ColW(c_Descripcion, 150);
            grdLista.set_ColW(c_Costo, 80);
            grdLista.set_ColW(c_Id, 0);
            grdLista.set_ColW(c_Id_lista, 0);
        }

        private void lstListas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargando_lista = true;
            listas.lista.ID = h.Codigo_Seleccionado(lstListas.Text);
            grdLista.MostrarDatos(listas.Datos_Vista("Id_Lista = " + h.Codigo_Seleccionado(lstListas.Text)), true);
            Formato_Grilla();
            cargar_sucs();
            cargando_lista = false;

            if (listas.FilasdeImpresion() > 121)
            {
                avisado = true;
                lblVariasHojas.Visible = true;
            }
            else
            {
                avisado = false;
                lblVariasHojas.Visible = false;
            }
        }

        private void cargar_sucs()
        {
            lstSucs.SelectedIndex = -1;
            cargando_lista = true;
            for (int i = 0; i <= lstSucs.Items.Count - 1; i++)
            {
                if (listas.Existe(h.Codigo_Seleccionado(lstSucs.GetItemText(lstSucs.Items[i]))) == true)
                {
                    lstSucs.SelectedIndex = i;
                }
            }
            cargando_lista = false;
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            string nuevoNombre = txtAgregar.Text;
            if (nuevoNombre.Length != 0 & nuevoNombre != "Agregar")
            {
                listas.lista.Nombre = nuevoNombre;
                listas.lista.Agregar();

                lstListas.Items.Add($"{listas.lista.ID}. {nuevoNombre}");
                txtAgregar.Text = "";
            }
        }

        private void grdLista_Editado(short f, short c, object a)
        {
            switch (c)
            {
                case 1://Orden
                    grdLista.set_Texto(f, c, a);
                    listas.Orden = Convert.ToInt32(a);
                    if (listas.ID > 0)
                    {
                        listas.Actualizar();
                        grdLista.ActivarCelda(f + 1, c);
                    }
                    else
                    { grdLista.ActivarCelda(f, c + 1); }
                    break;
                case 2://Id_Prod
                    if (listas.productos.Existe(Convert.ToInt32(a)))
                    {
                        listas.productos.Buscar();
                        grdLista.set_Texto(f, c, a);
                        listas.productos.ID = Convert.ToInt32(a);
                        grdLista.set_Texto(f, c_Nombre, listas.productos.Nombre);
                        grdLista.set_Texto(f, c_Id_Tipo, listas.productos.Tipo.ID);
                        grdLista.set_Texto(f, c_Tipo, listas.productos.Tipo.Nombre);
                        if (listas.ID > 0)
                        {
                            listas.Actualizar();
                            grdLista.ActivarCelda(f + 1, c);
                        }
                        else
                        { grdLista.ActivarCelda(f, c_Descripcion); }
                    }
                    break;
                case 6://Descripcion
                    grdLista.set_Texto(f, c, a);
                    listas.descripcion = a.ToString();
                    if (listas.ID > 0)
                    {
                        listas.Actualizar();
                        grdLista.ActivarCelda(f + 1, c);
                    }
                    else
                    { grdLista.ActivarCelda(f, c_Costo); }
                    break;
                case 7://Costo

                    if (listas.ID > 0)
                    {
                        grdLista.set_Texto(f, c, a);
                        listas.costo = Convert.ToDouble(a);
                        listas.Actualizar();
                        grdLista.ActivarCelda(f + 1, c);
                    }
                    else
                    {
                        if (listas.productos.ID > 0)
                        {
                            grdLista.set_Texto(f, c, a);
                            listas.costo = Convert.ToDouble(a);
                            listas.Agregar();
                            grdLista.set_Texto(f, c_Id, listas.ID);
                            grdLista.AgregarFila();
                            grdLista.set_Texto(f + 1, c_Orden, listas.Max_Orden() + 1);
                            grdLista.ActivarCelda(f + 1, c_IdProd);
                        }
                        else
                        {
                            grdLista.ActivarCelda(f, c_IdProd);
                            grdLista.ErrorEnTxt();
                        }
                    }
                    break;

                case 8://Detalle
                    if (a.ToString().Length < 6)
                    {
                        grdLista.set_Texto(f, c, a);
                        listas.Detalle = a.ToString();
                        if (listas.ID > 0)
                        {
                            listas.Actualizar();
                            grdLista.ActivarCelda(f + 1, c);
                        }
                        else
                        { grdLista.ActivarCelda(f, c_Costo); }
                    }
                    else
                    { MessageBox.Show($"El limite de caracteres del detalle es de 5", "Demasiados caracteres", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    break;

                case 9://Pintar
                    grdLista_CambioFila(f);
                    if (listas.ID > 0)
                    {
                        grdLista.set_Texto(f, c, a);
                        listas.Pintar = Convert.ToBoolean(a);
                        listas.Actualizar();
                        grdLista.ActivarCelda(f + 1, c);
                    }
                    break;
            }
            if (listas.FilasdeImpresion() > 121 & avisado == false)
            {
                MessageBox.Show($"La cantidad de filas para imprimir esta Lista es mayor a la recomendada, la Lista deberá imprimirse en varias hojas.", "Aviso de impresión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lblVariasHojas.Visible = true;
                avisado = true;
            }
            else if (listas.FilasdeImpresion() < 121 & avisado == true)
            {
                lblVariasHojas.Visible = false;
                avisado = false;
            }
        }

        private void grdLista_CambioFila(short Fila)
        {
            int i = Convert.ToInt32(grdLista.get_Texto(Fila, c_Id).ToString());
            if (i > 0)
            {
                listas.ID = i;
                listas.Cargar_Fila();
            }
            else
            {
                listas.ID = 0;
                listas.Orden = Convert.ToInt32(grdLista.get_Texto(Fila, c_Orden));
                listas.productos.ID = Convert.ToInt32(grdLista.get_Texto(Fila, c_IdProd));
                listas.descripcion = grdLista.get_Texto(Fila, c_Descripcion).ToString();
                listas.costo = Convert.ToSingle(grdLista.get_Texto(Fila, c_Costo));
                listas.Detalle = grdLista.get_Texto(Fila, c_Detalle).ToString();
                listas.Pintar = Convert.ToBoolean(grdLista.get_Texto(Fila, c_Pintar));
            }
        }

        private void cmdEditar_Click(object sender, EventArgs e)
        {
            frmEditar_Suc_Ofertas frm = new frmEditar_Suc_Ofertas();
            frm.ShowDialog();
            frm.Close();
            h.Llenar_List(lstSucs, listas.sucdatos());
            cargar_sucs();
        }

        private void grdLista_KeyUp(object sender, short e)
        {
            switch (Convert.ToInt32(e))
            {
                case 46: //Delete
                    if (Convert.ToInt32(grdLista.get_Texto(grdLista.Row, c_Id)) != 0)
                    {
                        listas.ID = Convert.ToInt32(grdLista.get_Texto(grdLista.Row, c_Id));
                        listas.Borrar();
                        grdLista.BorrarFila(grdLista.Row);
                        grdLista_CambioFila(Convert.ToByte(grdLista.Row));
                        if (listas.FilasdeImpresion() < 121 & avisado == true)
                        {
                            lblVariasHojas.Visible = false;
                            avisado = false;
                        }
                    }
                    break;
            }
        }
        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (lstListas.SelectedIndex > -1)
            {
                if (listas.Fecha_Cerrada(listas.Fecha) == false)
                {
                    if (MessageBox.Show($"¿Esta segura/o de borrar el registro?", "Borrar", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        listas.lista.ID = Convert.ToInt32(h.Codigo_Seleccionado(lstListas.Text));
                        listas.lista.Borrar_Hijos();
                        listas.lista.Borrar();
                        h.Llenar_List(lstListas, listas.lista.Datos());
                    }
                }
                else
                {
                    MessageBox.Show("La fecha se encuentra cerrada", "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (listas.lista.ID > 0 & cargando_lista == false)
            {
                listas.Borrar_Suc_Listas();
                string nom_suc;
                foreach (string item in lstSucs.SelectedItems)
                {
                    nom_suc = item.ToString();
                    if (nom_suc.IndexOf(".") > -1)
                    {
                        nom_suc = nom_suc.Substring(nom_suc.IndexOf(".") + 2);
                        if (nom_suc.Length > 0)
                        {
                            listas.Agregar_sucs_a_Lista(nom_suc, h.Codigo_Seleccionado(item));
                        }
                    }
                }
            }
        }

        private void txtTitulos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtTitulos.Text.Length > 0)
                {
                    listas.titulos.Nombre = txtTitulos.Text;
                    listas.titulos.Agregar();
                    txtTitulos.Text = "";
                    h.Llenar_List(cmbTitulos, listas.titulos.Datos());
                    cmbTitulos.SelectedIndex = cmbTitulos.Items.Count - 1;
                }
            }
        }

        private void txtAgregar_Click(object sender, EventArgs e)
        {
            if (txtAgregar.Text == "Agregar")
            { txtAgregar.Text = ""; }
        }

        private void txtTitulos_Enter(object sender, EventArgs e)
        {
            if (txtTitulos.Text == "Agregar titulos")
            { txtTitulos.Text = ""; }
        }

        private void txtTitulos_Leave(object sender, EventArgs e)
        {
            if (txtTitulos.Text == "")
            { txtTitulos.Text = "Agregar titulos"; }
        }

        private void txtAgregar_Enter(object sender, EventArgs e)
        {
            if (txtAgregar.Text == "Agregar")
            { txtAgregar.Text = ""; }
        }

        private void txtAgregar_Leave(object sender, EventArgs e)
        {
            if (txtAgregar.Text == "")
            { txtAgregar.Text = "Agregar"; }
        }

        private void Prueba_hilos(int la_listapaa, int copias, string tipofecha, DateTime fecha, string Titulo, bool vista_previa = false)
        {
            Listas_Ofertas cofimp = new Listas_Ofertas();
            string fileTest = @"D:\Sistema\P1\Listas_Ofertas.xlsm";

            int c_producto = 1;
            int c_descripcion = 2;
            int c_costo = 3;
            int c_detalle = 4;
            cofimp.lista.ID = la_listapaa;
            DataTable dt = cofimp.Datos_Vista($"Id_Lista = {cofimp.lista.ID}", "*", "Id_Tipo, Orden, Id_Prod, Costo");

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(fileTest);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int id_tipo = 0;
            int filae = 1;
            xlWorksheet.Cells.Clear();
            xlApp.Run("Blanquear_Bordes");

            xlWorksheet.Cells[filae, 1] = "OFERTAS";

            if (tipofecha == "(Día)")
            { tipofecha = ci.DateTimeFormat.GetDayName(fecha.DayOfWeek); }
            xlWorksheet.Cells[filae, 2] = tipofecha;
            xlWorksheet.Cells[filae, 3] = fecha.Day + "-" + ci.DateTimeFormat.GetMonthName(fecha.Month).Substring(0, 3);
            xlWorksheet.Cells[filae, 5] = Titulo;

            int hojas = 1;

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                if (filae > 61 * hojas & c_producto == 5)
                {
                    filae = 61 * hojas + 2;
                    hojas = hojas + 1;
                    c_producto = 1;
                    c_descripcion = 2;
                    c_costo = 3;
                    c_detalle = 4;
                    id_tipo = 0;
                }
                else if (filae > 61 * hojas & c_producto == 1)
                {
                    filae = 61 * hojas - 61 + 2;
                    c_producto = 5;
                    c_descripcion = 6;
                    c_costo = 7;
                    c_detalle = 8;
                }

                if (id_tipo == Convert.ToInt32(dt.Rows[i][4]))
                {
                    xlWorksheet.Cells[filae, c_producto] = dt.Rows[i][3];
                    xlWorksheet.Cells[filae, c_descripcion] = dt.Rows[i][6];
                    xlWorksheet.Cells[filae, c_costo] = dt.Rows[i][7];
                    xlWorksheet.Cells[filae, c_detalle] = dt.Rows[i][8];
                    if (Convert.ToBoolean(dt.Rows[i][9]) == true)
                    {
                        xlWorksheet.Cells[filae, c_producto].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        xlWorksheet.Cells[filae, c_descripcion].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        xlWorksheet.Cells[filae, c_costo].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        xlWorksheet.Cells[filae, c_detalle].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    }
                    filae = filae + 1;
                }
                else
                {
                    if (filae < 61 * hojas)
                    {
                        xlWorksheet.Cells[filae + 1, c_descripcion] = dt.Rows[i][5];
                        id_tipo = Convert.ToInt32(dt.Rows[i][4]);
                        filae = filae + 2;
                        i = i - 1;
                    }
                    else
                    { filae = filae + 1; i = i - 1; }
                }
            }
            //ejecutar macro
            xlApp.Run("Dar_Formato");
            if (vista_previa == false)
            {
                dt = cofimp.sucs_imp();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    xlWorksheet.Cells[1, 6] = dt.Rows[i][1];
                    xlWorksheet.PrintOutEx(Copies: copias, Preview: false, To: hojas);
                    //imprimir
                }
            }
            else
            {
                xlWorksheet.Cells[1, 6] = "OFICINA";
                xlWorksheet.PrintOutEx(Copies: 1, Preview: false, To: hojas);
            }
            xlWorkbook.Close(false);
            xlApp.Quit();
        }

        private void cmdVistaPrevia_Click(object sender, EventArgs e)
        {
            int copias;
            string tipofecha = cmbTipofecha.Text;
            DateTime fecha = mtcFecha.SelectionStart;
            string titulos = cmbTitulos.Text;
            if (int.TryParse(txtCopias.Text, out copias) == true)
            { copias = Convert.ToInt32(txtCopias.Text); }
            else
            { copias = 1; }
            Thread Hilo_prueba = new Thread(() => Prueba_hilos(listas.lista.ID, copias, tipofecha, fecha, titulos, true));
            Hilo_prueba.Start();
        }

        private void cmbCopias_Enter(object sender, EventArgs e)
        {
            if (txtCopias.Text == "Copias")
            { txtCopias.Text = ""; }
        }

        private void cmbCopias_Leave(object sender, EventArgs e)
        {
            if (txtCopias.Text == "")
            { txtCopias.Text = "Copias"; }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            int copias;
            string tipofecha = cmbTipofecha.Text;
            DateTime fecha = mtcFecha.SelectionStart;
            string titulos = cmbTitulos.Text;
            if (int.TryParse(txtCopias.Text, out copias) == true)
            { copias = Convert.ToInt32(txtCopias.Text); }
            else
            { copias = 1; }
            Thread Hilo_prueba = new Thread(() => Prueba_hilos(listas.lista.ID, copias, tipofecha, fecha, titulos));
            Hilo_prueba.Start();
        }
    }
}
