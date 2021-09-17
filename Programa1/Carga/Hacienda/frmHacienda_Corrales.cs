namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmHacienda_Corrales : Form
    {
        public frmHacienda_Corrales()
        {
            InitializeComponent();
        }

        private void cFecha_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            NBoletas nb = new NBoletas();
            grd.MostrarDatos(nb.Stock_Corrales(cFecha.fecha_Actual, cFecha.fecha_Fin), true, 3);
            grd.Columnas["Total_Compra"].Format = "N1";
            grd.AutosizeAll();
        }
    }
}
