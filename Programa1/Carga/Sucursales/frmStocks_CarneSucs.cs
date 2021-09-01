using Programa1.DB;
using System;
using System.Windows.Forms;

namespace Programa1.Carga.Sucursales
{
    public partial class frmStocks_CarneSucs : Form
    {
        readonly Stock stock = new Stock();
        public frmStocks_CarneSucs()
        {
            InitializeComponent();
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }
        private void cSucursales1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }
        private void Cargar()
        {

            string filtro = cFechas1.Cadena();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            filtro = h.Unir(filtro, cSucursales1.Cadena("ID_Sucursales"));

            if (cSucursales1.Cantidad_Seleccionada() == 1)
            {
                grd.MostrarDatos(stock.Datos_Vista(filtro + " AND Id_Tipo=1", "ID_Productos Prod, Descripcion, Kilos"), true, true);
            }
            else
            {
                grd.MostrarDatos(stock.Stock_CarneSucs(filtro), true, true);
            }
            grd.Columnas[2].Format = "N1";
            grd.SumarCol(2, true);
            grd.AutosizeAll();
        }
    }

}
