namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;
    public partial class frmResumenARendir : Form
    {
        public frmResumenARendir()
        {
            InitializeComponent();
        }

        private A_Rendir ar = new A_Rendir();
        private Nombres_ARendir nar = new Nombres_ARendir();
        private Herramientas.Herramientas h = new Herramientas.Herramientas();

        private void frm_Load(object sender, EventArgs e)
        {
            //HORRIBLE.
            h.Llenar_List(lstARendir, nar.Datos());
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void lstARendir_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Datos();
        }


        private void Cargar_Datos()
        {
            this.Cursor = Cursors.WaitCursor;
            string f = cFecha.Cadena();

            if (lstARendir.SelectedIndex != -1) { ar.ID_NARendir = h.Codigo_Seleccionado(lstARendir.Text); }
            grdSalidas.MostrarDatos(ar.Salidas(f), true, false);
            grdSalidas.Columnas[1].Style.Format = "N1";
            grdSalidas.AutosizeAll();

            double s = grdSalidas.SumarCol(grdSalidas.get_ColIndex("Importe"));
            lblTEntradas.Text = "Total: " + s.ToString("N1");

            grdGastos.MostrarDatos(ar.Gastos(f), true, false);
            grdGastos.Columnas[grdGastos.get_ColIndex("Importe")].Style.Format = "N1";
            grdGastos.set_ColW(0, 50);
            grdGastos.set_ColW(1, 30);
            grdGastos.set_ColW(2, 80);
            grdGastos.set_ColW(3, 30);
            grdGastos.set_ColW(4, 80);
            grdGastos.set_ColW(5, 30);
            grdGastos.set_ColW(6, 200);
            grdGastos.set_ColW(7, 90);

            double g = grdGastos.SumarCol(grdGastos.get_ColIndex("Importe"));
            lblTGastos.Text = "Total: " + g.ToString("N1");

            s = s - g;
            lblSaldo.Text = "Saldo: " + s.ToString("N1");
            this.Cursor = Cursors.Default;

        }
        
    }
}
