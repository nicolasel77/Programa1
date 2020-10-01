using Programa1.DB;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Precios
{
    public partial class frmPrecios_Carne : Form
    {
        Precios_Sucursales pr = new Precios_Sucursales();

        public frmPrecios_Carne()
        {
            InitializeComponent();
        }

        private void frmPrecios_Carne_Load(object sender, EventArgs e)
        {
            DataTable dt = pr.Precios_CarneListaKilos();
            dt.Columns.Add("Precio", Type.GetType("System.Single"));
            dt.Columns.Add("Total", Type.GetType("System.Single"));
            dt.Columns.Add("%", Type.GetType("System.Single"));

            grdProductos.MostrarDatos(dt, true, true);
            grdProductos.set_Texto(0, 0, "Prod");

            grdProductos.set_ColW(grdProductos.get_ColIndex("ID_Productos"), 30);
            grdProductos.set_ColW(grdProductos.get_ColIndex("Nombre"), 150);
            grdProductos.set_ColW(grdProductos.get_ColIndex("Kilos"), 60);
            grdProductos.set_ColW(grdProductos.get_ColIndex("Precio"), 60);
            grdProductos.set_ColW(grdProductos.get_ColIndex("Total"), 70);
            grdProductos.set_ColW(grdProductos.get_ColIndex("%"), 50);

            grdProductos.Columnas[grdProductos.get_ColIndex("Kilos")].Style.Format = "N1";
            grdProductos.Columnas[grdProductos.get_ColIndex("Precio")].Style.Format = "N3";
            grdProductos.Columnas[grdProductos.get_ColIndex("Total")].Style.Format = "N1";
            grdProductos.Columnas[grdProductos.get_ColIndex("%")].Style.Format = "N2";

            dt = pr.Precios_Formulas();
            grdFormulas.MostrarDatos(dt, true, true);
            grdFormulas.set_Texto(0, 0, "ID");
            grdFormulas.AutosizeAll();

            dt = pr.Fechas(1);
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstFechas, dt, "dd/MM/yyy");
        }


        private void cmdFormulas_Click(object sender, EventArgs e)
        {
            splFormulas.Panel2Collapsed = !splFormulas.Panel2Collapsed;
        }


    }
}
