
namespace Programa1.Carga.Precios
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmPreciosMen : Form
    {
        Precios_Sucursales precios;
        public frmPreciosMen()
        {
            InitializeComponent();
            precios = new Precios_Sucursales();
        }

        private void FrmPreciosMen_Load(object sender, EventArgs e)
        {
            DataTable dt = precios.Tabla_Men();

            
            grd.MostrarDatos(dt, true, false);
            grd.set_ColW(0, 60);
            grd.set_ColW(1, 300);

            lstFechas.DataSource = precios.Fechas_Men();
            lstFechas.DisplayMember = "Fecha";
            lstFechas.ValueMember = "Fecha";
        }
    }
}
