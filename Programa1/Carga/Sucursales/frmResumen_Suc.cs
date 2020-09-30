namespace Programa1.Carga
{
    using Programa1.Carga.Sucursales;
    using Programa1.DB;
    using Programa1.DB.Sucursales;
    using Programa1.DB.Varios;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmResumen_Suc : Form
    {

        private Resumen_Sucursales RS = new Resumen_Sucursales();
        private Estadisticas_Sucursales Est = new Estadisticas_Sucursales();
        private int Suc = 0;

        public frmResumen_Suc()
        {
            InitializeComponent();
        }

        private void frmResumen_Suc_Load(object sender, EventArgs e)
        {
            // 13: Enter
            // 46: Delete            
            grdEntradas.TeclasManejadas = new int[] { 13, 46 };
            grdSalidas.TeclasManejadas = new int[] { 13, 46 };
        }


        private void Cargar_Listado(DateTime Semana)
        {
            grdSucursales.MostrarDatos(RS.Listado_Balances(Semana), true, false);
            grdSucursales.set_ColW(0, 30);
            grdSucursales.set_ColW(1, 120);
            grdSucursales.set_ColW(2, 90);
            for (int i = 1; i <= grdSucursales.Rows - 1; i++)
            {
                if (Convert.ToDouble(grdSucursales.get_Texto(i, 2)) >= 0)
                {
                    grdSucursales.set_ColorLetraCelda(i, 2, Color.Blue);
                }
                else
                {
                    grdSucursales.set_ColorLetraCelda(i, 2, Color.Red);
                }
                if (Convert.ToInt32(grdSucursales.get_Texto(i, 0)) == Suc) { grdSucursales.ActivarCelda(i, 0); }
            }
            grdSucursales.Columnas[2].Style.Format = "#,###.#";
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Est.Sem.Semana = cFechas1.fecha_Actual;
            Cargar_Listado(cFechas1.fecha_Actual);
            Cargar_Datos();
            this.Cursor = Cursors.Default;
        }

        private void grdSucursales_CambioFila(short Fila)
        {
            if (Convert.ToInt32(grdSucursales.get_Texto(Fila, 0)) != 0)
            {
                Suc = Convert.ToInt32(grdSucursales.get_Texto(Fila, 0));
                Est.Suc.Id = Suc;

                lblSuc.Text = $"{grdSucursales.get_Texto(Fila, 1)}";
                this.Text = $"{lblSuc.Text}  -  Semana: {cFechas1.fecha_Actual:dd/MM/yy}";
                Cargar_Datos();
            }
        }

        private void Cargar_Datos()
        {
            if (grdSucursales.Row > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                Entradas();
                Salidas();
                Cuentas();
                if (paEst.Visible == true) { Estadisticas(); }
                this.Cursor = Cursors.Default; 
            }
        }



        private void Entradas()
        {
            DataTable dt = new DataTable();
            dt = RS.Entradas(Suc, cFechas1.fecha_Actual, cFechas1.fecha_Fin);
            grdEntradas.MostrarDatos(dt, true, false);
            grdEntradas.AutosizeAll();
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("ID_Proveedor"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("ID"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("SQL"), 0);

            grdEntradas.Columnas[grdEntradas.get_ColIndex("Kilos")].Style.Format = "#,###.#";
            grdEntradas.Columnas[grdEntradas.get_ColIndex("Costo")].Style.Format = "#,###.#";
            grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "#,###.#";

            double T = grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), false);
            lblTotalEntradas.Text = "Total: " + T.ToString("C1");
        }
        private void Salidas()
        {
            DataTable dt = new DataTable();
            dt = RS.Salidas(Suc, cFechas1.fecha_Actual, cFechas1.fecha_Fin);
            grdSalidas.MostrarDatos(dt, true, false);
            grdSalidas.AutosizeAll();
            grdSalidas.set_ColW(grdSalidas.get_ColIndex("ID_Proveedor"), 0);
            grdSalidas.set_ColW(grdSalidas.get_ColIndex("ID"), 0);
            grdSalidas.set_ColW(grdSalidas.get_ColIndex("SQL"), 0);

            grdSalidas.Columnas[grdSalidas.get_ColIndex("Kilos")].Style.Format = "#,###.#";
            grdSalidas.Columnas[grdSalidas.get_ColIndex("Costo")].Style.Format = "#,###.#";
            grdSalidas.Columnas[grdSalidas.get_ColIndex("Total")].Style.Format = "#,###.#";

            double T = grdSalidas.SumarCol(grdSalidas.get_ColIndex("Total"), false);
            lblTotalSalidas.Text = "Total: " + T.ToString("C1");
        }
        private void Cuentas()
        {
            Double k = Est.Carne_Kilos();
            lblCarneK.Text = $"Venta Carne: {k.ToString("N0")} kg";
            Stock st = new Stock();
            string cadena = $"Id_Sucursales={Suc} AND {cFechas1.Cadena()}";
            k = st.Stock_Carne(cadena);
            cmdStock_Carne.Text = $"STOCK CARNE:  {k:N1} kg";

        }


        private void Estadisticas()
        {
            grdEstadistica.MostrarDatos(Est.Completa(), true, false);
            grdEstadistica.AutosizeAll();

        }

        private void paEstadistica_Click(object sender, EventArgs e)
        {
            if (paEst.Visible == false)
            {
                Estadisticas();
            }
            paEst.Visible = !paEst.Visible;
        }


        private void grdEntradas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Enter))
            {
                Cargar_DetalleEntrada();
            }
            else
            {
                if (e == Convert.ToInt32(Keys.Delete))
                {
                    if (grdEntradas.Row > 0)
                    {
                        grdEntradas.BorrarFila();
                    }
                }
            }
        }

        private void grdEntradas_DobleClick(object sender, EventArgs e)
        {
            Cargar_DetalleEntrada();
        }

        private void Cargar_DetalleEntrada()
        {
            string s = grdEntradas.get_Texto(grdEntradas.Row, grdEntradas.get_ColIndex("SQL")).ToString();
            if (s.Length > 0)
            {
                frmDetalle_Resumen fr = new frmDetalle_Resumen();
                Datos_Genericos dg = new Datos_Genericos();
                fr.grd.MostrarDatos(dg.Datos(s), true, false);
                fr.grd.AutosizeAll();
                fr.ShowDialog();
                this.Focus();
                grdEntradas.Focus();
            }
        }


        private void grdSalidas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Enter))
            {
                Cargar_DetalleSalida();
            }
            else
            {
                if (e == Convert.ToInt32(Keys.Delete))
                {
                    if (grdSalidas.Row > 0)
                    {
                        grdSalidas.BorrarFila();
                    }
                }
            }
        }
        private void grdSalidas_DobleClick(object sender, EventArgs e)
        {
            Cargar_DetalleSalida();
        }

        private void Cargar_DetalleSalida()
        {
            string s = grdSalidas.get_Texto(grdSalidas.Row, grdSalidas.get_ColIndex("SQL")).ToString();
            if (s.Length > 0)
            {
                frmDetalle_Resumen fr = new frmDetalle_Resumen();
                Datos_Genericos dg = new Datos_Genericos();
                fr.grd.MostrarDatos(dg.Datos(s), true, false);
                fr.grd.AutosizeAll();
                fr.ShowDialog();
                this.Focus();
                grdSalidas.Focus();
            }
        }

        private void cmdStock_Carne_Click(object sender, EventArgs e)
        {
            frmStock_Carne fr = new frmStock_Carne();
            Stock st = new Stock();

            string cadena = $"Id_Sucursales={Suc} AND {cFechas1.Cadena()} AND ID_Tipo=1";

            fr.grd.MostrarDatos(st.Datos(cadena), true, true);
            fr.grd.SumarCol(fr.grd.get_ColIndex("Kilos"), true);
            fr.grd.AutosizeAll();
            fr.ShowDialog();
        }

        private void frmResumen_Suc_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (grdSucursales.EsUltimaFila() == true)
                    {
                        grdSucursales.ActivarCelda(1, 0);
                    }
                    else
                    {
                        grdSucursales.ActivarCelda(grdSucursales.Row + 1, 0);
                    }
                    break;
                case Keys.Subtract:
                    if (grdSucursales.Row == 1)
                    {
                        grdSucursales.ActivarCelda(grdSucursales.Rows - 1, 0);
                    }
                    else
                    {
                        grdSucursales.ActivarCelda(grdSucursales.Row - 1, 0);
                    }
                    break;
            }
        }
    }
}
