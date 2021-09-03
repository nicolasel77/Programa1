using Programa1.DB;
using Programa1.DB.Sucursales;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Programa1.Carga.Varios
{
    public partial class frmVenta_Productos : Form
    {
        Estadisticas_Sucursales es = new Estadisticas_Sucursales();
        public frmVenta_Productos()
        {
            InitializeComponent();
            Semanas sem = new Semanas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstSemanas, sem.Fechas(), "dd/MM/yyy");
        }

        private void lstSemanas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;

            if (lstSemanas.SelectedIndex > -1)
            {
                es.Sem.Semana = Convert.ToDateTime(lstSemanas.Text);


                DataTable dt = es.Ventas_KilosProdSuc((byte)nuSemanas.Value, cProductos1.Cadena("Prod"));

                grd.MostrarDatos(dt, true, false); ;

                for (int c = 2; c <= grd.Cols - 1; c++)
                {
                    grd.Columnas[c].Format = "N1";
                }
                grd.AutosizeAll();
                grd.set_ColW(0, 40);
                grd.set_ColW(1, 200);
                grd.Columnas[0].Style.BackColor = Color.WhiteSmoke;
                grd.Columnas[1].Style.BackColor = Color.WhiteSmoke;
                grd.Columnas["Promedio"].Style.BackColor = Color.Gainsboro;
            }

            this.Cursor = Cursors.Default;
        }

        private void cProductos1_Cambio_Seleccion(object sender, EventArgs e)
        {

        }

        private void cSucursales1_Cambio_Seleccion(object sender, EventArgs e)
        {
            es.Suc.ID = cSuc.Valor_Actual == -1 ? 0 : cSuc.Valor_Actual ;
            Cargar();
        }
    }
}
