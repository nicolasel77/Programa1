namespace Programa1.Carga
{
    using Programa1.DB;
    using Programa1.DB.Varios;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    public partial class frmStock_Galpon : Form
    {
        private Stock_Galpon Stock;
        Listas_Carga Listas = new Listas_Carga();

        #region " Columnas "
        private Byte c_IdProv;
        private Byte c_Nombre;
        private Byte c_IdProd;
        private Byte c_Descripcion;
        private Byte c_Cantidad;
        private Byte c_Kilos;
        private Byte c_Precio;
        #endregion

        public frmStock_Galpon()
        {
            InitializeComponent();

            Stock = new Stock_Galpon();

            grdStock.MostrarDatos(Stock.stock_Sis("id_productos = 0"), true);

            formato_Grilla();
        }

        private void frmStock_Galpon_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cProvs.Siguiente();
                    }
                    else
                    {
                        if (e.Shift)
                        {
                            e.Handled = true;
                            cProds.Siguiente();
                        }
                    }
                    break;
                case Keys.Subtract:
                    if (e.Control)
                    {
                        e.Handled = true;
                        cProvs.Anterior();
                    }
                    else
                    {
                        if (e.Shift)
                        {
                            e.Handled = true;
                            cProds.Anterior();
                        }
                    }
                    break;
            }
        }

        #region "Mensaje"
        private void Mensaje(string Mensaje)
        {
            System.Media.SystemSounds.Beep.Play();
            lblMensaje.Text = Mensaje;
            tiMensaje.Start();
        }
        private void TiMensaje_Tick(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            tiMensaje.Stop();
        }

        #endregion

        private void CmdMostrar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string s = Armar_Cadena();
            grdStock.MostrarDatos(Stock.stock_Sis(s), true);

            s = Armar_Cadena_cerdo();
            grdCerdo.MostrarDatos(Stock.stock_Sis_Cerdo(s), true);

            formato_Grilla();
            grdStock.ActivarCelda(grdStock.Rows - 1, c_IdProd);
            grdStock.Focus();

            this.Cursor = Cursors.Default;
        }

        private string Armar_Cadena()
        {
            string p = cProds.Cadena("id_Productos");
            string f = cFecha.Cadena();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            p = h.Unir(f, p);

            return p;
        }

        private string Armar_Cadena_cerdo()
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            
            string p = "id_productos IN (204, 205, 2204, 2205)";
            string f = $"fecha <= {h.Formato_SQL(cFecha.fecha_Fin)}";

            p = h.Unir(f, p);

            return p;
        }

        private void formato_Grilla()
        {
            c_IdProd = Convert.ToByte(grdStock.get_ColIndex("Id_Productos"));
            c_Descripcion = Convert.ToByte(grdStock.get_ColIndex("Descripcion"));
            c_Cantidad = Convert.ToByte(grdStock.get_ColIndex("Cantidad"));
            c_Kilos = Convert.ToByte(grdStock.get_ColIndex("Kilos"));
            c_Precio = Convert.ToByte(grdStock.get_ColIndex("Precio"));
            grdStock.Reset_Teclas();
            int[] n = { 13, 32, 42, 43, 45, 46, 47, 112, 123 };
            grdStock.TeclasManejadas = n;
            grdStock.AgregarTeclas(Convert.ToInt32(Keys.Subtract), c_IdProd, c_Kilos);

            grdStock.set_ColW(c_IdProd, 40);
            grdStock.set_ColW(c_Descripcion, 250);
            grdStock.set_ColW(c_Cantidad, 60);
            grdStock.set_ColW(c_Kilos, 60);
            grdStock.set_ColW(c_Precio, 60);

            grdStock.Columnas[c_Kilos].Format = "N1";
            grdStock.Columnas[c_Precio].Format = "N1";
            if (chProv.Checked == true)
            {
                c_IdProv = Convert.ToByte(grdStock.get_ColIndex("Id_Prov"));
                c_Nombre = Convert.ToByte(grdStock.get_ColIndex("Nombre"));

                grdStock.AgregarTeclas(Convert.ToInt32(Keys.Add), c_IdProv, c_Kilos);

                grdStock.set_ColW(c_IdProv, 40);
                grdStock.set_ColW(c_Nombre, 250);

                grdStock.Columnas[c_IdProv + 1].Style.ForeColor = Color.DimGray;
                grdStock.set_Texto(0, c_IdProv, "Prov");
            }

            grdStock.Columnas[c_Kilos].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);
            grdStock.set_Texto(0, c_IdProd, "Prod");
            grdStock.BorrarFila(grdStock.Rows - 1);

            for (int j = grdStock.Rows - 1; j > 0; j--)
            {
                if (Convert.ToInt32(grdStock.get_Texto(j, c_Kilos)) == 0)
                {
                    grdStock.BorrarFila(j);
                }
            }

            Totales();
        }

        private void Totales()
        {
            double k = grdStock.SumarCol(c_Kilos, false);
            int c = grdStock.Rows - 1;
            lblCant.Text = $"Registros: {c:N0}";
            lblKilos.Text = $"Kilos: {k:N1}";
        }


        private void CmdLimpiar_Click(object sender, EventArgs e)
        {
            grdStock.Rows = 1;
            Totales();
        }


        private void CProds_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void CSucs_Cambio_Seleccion(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }


        private void GrdStock_CambioFila(short Fila)
        {
        }

        private void GrdStock_KeyPress(object sender, short e)
        {
            if (e == 13)
            {
                if (Stock.ID == 0)
                {

                    if (grdStock.Col == c_Kilos)
                    {
                        Stock.Producto.ID = Listas.Producto_Siguiente();


                        Stock.Descripcion = Stock.Producto.Nombre;

                        grdStock.set_Texto(grdStock.Row, c_IdProd, Stock.Producto.ID);
                        grdStock.set_Texto(grdStock.Row, c_Descripcion, Stock.Descripcion);
                    }
                }
            }
        }


        private void LblCant_Click(object sender, EventArgs e)
        {
            ToolStripLabel lbl = sender as ToolStripLabel;
            string s = lbl.Text.Substring(lbl.Text.IndexOf(":") + 1);

            Clipboard.SetText(s);

            Mensaje($"Copiado: {s}");
        }

        private void cFecha_Cambio_Seleccion_1(object sender, EventArgs e)
        {
            cProds.Filtro_In = $" (SELECT DISTINCT id_Productos FROM vw_Stock_Sis WHERE {cFecha.Cadena()})";
            cmdMostrar.PerformClick();
        }

        private void chProv_CheckedChanged_1(object sender, EventArgs e)
        {
            cmdMostrar.PerformClick();
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            //Imprimir imprimir = new Imprimir();
            //this.Cursor = Cursors.WaitCursor;
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(AppContext.BaseDirectory + "\\Imprimir.xlsm");
            //// Ejecutar la macro
            //// Imprimir_Carne(ByVal Suc As Integer, ByVal Fecha As Date, ByVal Imp_Integracion As Boolean)
            //String s = "";
            //s = Armar_Cadena();
            //s = imprimir.Consulta(s, chProv.Checked);
            //xlApp.Run("Cargar", s);
            //xlApp.Visible = true;
            ////xlApp.showd
            ////xlWorkbook.Close(false);
            ////xlApp = null;
            ////this.Close();
            //this.Cursor = Cursors.Default;
        }

        //private void cmdCerrarSemana_Click(object sender, EventArgs e)
        //{
        //    //Cerrar_Semanas cerrar_semanas = new Cerrar_Semanas();
        //    //cerrar_semanas.ShowDialog();
        //}
    }
}
