namespace Programa1.Carga
{
    using Programa1.DB.Sucursales;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmResumenSuc : Form
    {

        private Resumen_Sucursales RS = new Resumen_Sucursales();
        private int Suc = 0;

        public frmResumenSuc()
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
            }
            grdSucursales.Columnas[2].Style.Format = "#,###.#";
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Listado(cFechas1.fecha_Actual);
        }

        private void grdSucursales_CambioFila(short Fila)
        {
            if (Convert.ToInt32(grdSucursales.get_Texto(Fila, 2)) != 0)
            {
                Suc = Convert.ToInt32(grdSucursales.get_Texto(Fila, 2));
                Cargar_Datos();
            }
        }

        private void Cargar_Datos()
        {
            
        }
    }
}
