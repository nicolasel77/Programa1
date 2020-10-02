using C1.Win.C1FlexGrid;
using Programa1.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Programa1.Carga.Precios
{
    public partial class frmPrecios_Carne : Form
    {
        Precios_Sucursales pr = new Precios_Sucursales();

        private List<CellStyle> Colores = new List<CellStyle>();


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

            Colores.Add(grdSucursales.Styles.Add("1"));
            Colores.Add(grdSucursales.Styles.Add("2"));
            Colores.Add(grdSucursales.Styles.Add("3"));
            Colores.Add(grdSucursales.Styles.Add("4"));
            Colores.Add(grdSucursales.Styles.Add("5"));
            Colores.Add(grdSucursales.Styles.Add("6"));
            Colores.Add(grdSucursales.Styles.Add("7"));
            Colores.Add(grdSucursales.Styles.Add("8"));
            Colores.Add(grdSucursales.Styles.Add("9"));
            Colores[0].BackColor = Color.LightBlue;
            Colores[1].BackColor = Color.LightGreen;
            Colores[2].BackColor = Color.LightPink;
            Colores[3].BackColor = Color.White;
            Colores[4].BackColor = Color.PaleTurquoise;
            Colores[5].BackColor = Color.Beige;
            Colores[6].BackColor = Color.MistyRose;
            Colores[7].BackColor = Color.Gainsboro;
            Colores[8].BackColor = Color.Thistle;
            

        }


        private void cmdFormulas_Click(object sender, EventArgs e)
        {
            splFormulas.Panel2Collapsed = !splFormulas.Panel2Collapsed;
        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {

            grdSucursales.MostrarDatos(pr.Integraciones_Sucursales(Convert.ToDateTime(lstFechas.Text)), true, false);
            grdSucursales.AutosizeAll();
            
            int c = grdSucursales.get_ColIndex("Integracion");

            grdSucursales.Ordenar(Convert.ToInt16(c));
            int n = 0;
            Single vintegr = Convert.ToSingle(grdSucursales.get_Texto(1, c));

            for (int i = 1; i <= grdSucursales.Rows - 1; i++)
            {
                if (vintegr != Convert.ToSingle(grdSucursales.get_Texto(i, c)))
                {                    
                    vintegr = Convert.ToSingle(grdSucursales.get_Texto(i, c));
                    if (n == Colores.Count - 1) { n = -1; }
                    n++;
                }
                grdSucursales.Filas[i].Style = Colores[n];
            }
            grdSucursales.Ordenar(Convert.ToInt16(grdSucursales.get_ColIndex("ID")));
        }
    }
}
