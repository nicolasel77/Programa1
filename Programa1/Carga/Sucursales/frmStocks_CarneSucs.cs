using Programa1.DB;
using System;
using System.Windows.Forms;

namespace Programa1.Carga.Sucursales
{
    public partial class frmStocks_CarneSucs : Form
    {
        Stock stock = new Stock();
        public frmStocks_CarneSucs()
        {
            InitializeComponent();
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {

            string filtro = cFechas1.Cadena();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            filtro = h.Unir(filtro, cSucursales1.Cadena("ID_Sucursales"));
            grd.MostrarDatos(stock.Stock_CarneSucs(filtro), true, 2);
            grd.Columnas[2].Format = "N1";
            grd.AutosizeAll();
        }
    }
}
