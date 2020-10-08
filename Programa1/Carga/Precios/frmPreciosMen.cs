
namespace Programa1.Carga.Precios
{
    using Programa1.DB;
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmPreciosMen : Form
    {
        Precios_Sucursales precios;
        Herramientas h = new Herramientas();
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

            h.Llenar_List(lstFechas, precios.Fechas(2), "dd/MM/yyyy");            
        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Precios();
        }

        private void Cargar_Precios()
        {
            if (lstFechas.SelectedIndex > -1)
            {
                precios.Fecha = Convert.ToDateTime(lstFechas.Text);
            }
            else
            {
                //precios.Fecha = null;
            }
            DataTable dt = precios.Precios_Men();


            grd.MostrarDatos(dt, true, false);
            grd.set_ColW(0, 60);
            grd.set_ColW(1, 300);
        }

    }
}
