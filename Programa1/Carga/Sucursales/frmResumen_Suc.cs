namespace Programa1.Carga
{
    using Programa1.DB.Sucursales;
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
            this.Cursor = Cursors.WaitCursor;
            Entradas();
            Salidas();
            Cuentas();
            if (paEst.Visible == true) { Estadisticas(); }
            this.Cursor = Cursors.Default;
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
        }

        private void Estadisticas()
        {
            grdEstadistica.MostrarDatos(Est.Completa(), true, false);
            grdEstadistica.AutosizeAll();
            
        }

        private void paEstadistica_Click(object sender, EventArgs e)
        {
            if( paEst.Visible == false)
            {
                Estadisticas();
            }
            paEst.Visible = !paEst.Visible;
        }
    }
}
