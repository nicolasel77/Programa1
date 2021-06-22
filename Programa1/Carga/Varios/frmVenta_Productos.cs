using Programa1.DB;
using Programa1.DB.Sucursales;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Varios
{
    public partial class frmVenta_Productos : Form
    {
        public frmVenta_Productos()
        {
            InitializeComponent();
            Semanas sem = new Semanas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstSemanas, sem.Fechas(), "dd/MM/yyy");
        }

        private void lstSemanas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Estadisticas_Sucursales es = new Estadisticas_Sucursales();
            es.Sem.Semana = Convert.ToDateTime(lstSemanas.Text);


            DataTable dt = es.Ventas_KilosProdSuc((byte)nuSemanas.Value, cProductos1.Cadena("Prod"));
            
            grd.MostrarDatos(dt, true, false); ;
            
            for (int c= 2; c <= grd.Cols-1; c++)
            {
                grd.Columnas[c].Format = "N";
            }
            grd.AutosizeAll();
            grd.set_ColW(0, 40);
            grd.set_ColW(1, 200);

            this.Cursor = Cursors.Default;

        }

        private void cProductos1_Cambio_Seleccion(object sender, EventArgs e)
        {

        }

        private void cSucursales1_Cambio_Seleccion(object sender, EventArgs e)
        {

        }
    }
}
