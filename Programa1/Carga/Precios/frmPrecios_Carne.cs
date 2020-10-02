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
            grdProductos.Columnas[grdProductos.get_ColIndex("Precio")].Style.Format = "N1";
            grdProductos.Columnas[grdProductos.get_ColIndex("Total")].Style.Format = "N1";
            grdProductos.Columnas[grdProductos.get_ColIndex("%")].Style.Format = "N2";

            //13: Enter
            //43: +
            //46: Delete
            grdProductos.TeclasManejadas = new int[] { 13, 43, 46, 107 };

            dt = pr.Precios_Formulas();
            grdFormulas.MostrarDatos(dt, true, true);
            grdFormulas.set_Texto(0, 0, "ID");
            grdFormulas.AutosizeAll();

            dt = pr.Fechas(1);
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstFechas, dt, "dd/MM/yyy");

            Colores.Add(grdSucursales.Styles.Add("0"));
            Colores.Add(grdSucursales.Styles.Add("1"));
            Colores.Add(grdSucursales.Styles.Add("2"));
            Colores.Add(grdSucursales.Styles.Add("3"));
            Colores.Add(grdSucursales.Styles.Add("4"));
            Colores.Add(grdSucursales.Styles.Add("5"));
            Colores.Add(grdSucursales.Styles.Add("6"));
            Colores.Add(grdSucursales.Styles.Add("7"));
            Colores.Add(grdSucursales.Styles.Add("8"));
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
            this.Cursor = Cursors.WaitCursor;
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

            pr.Fecha = Convert.ToDateTime(lstFechas.Text);

            grdSucursales.Ordenar(Convert.ToInt16(grdSucursales.get_ColIndex("ID")));
            this.Cursor = Cursors.Default;
            if (pr.Sucursal.Id != 0) { Cargar_Precios(); }
        }

        private void grdSucursales_CambioFila(short Fila)
        {
            pr.Sucursal.Id = 0;
            if (Convert.ToInt32(grdSucursales.get_Texto(Fila, 0)) != 0)
            {
                pr.Sucursal.Id = Convert.ToInt32(grdSucursales.get_Texto(Fila, 0));
                lblSuc.Text = Convert.ToString(grdSucursales.get_Texto(Fila, 1));
                Cargar_Precios();
            }
        }


        private void Cargar_Precios()
        {
            if (pr.Sucursal.Id != 0)
            {
                if (lstFechas.SelectedIndex != -1)
                {
                    this.Cursor = Cursors.WaitCursor;

                    for (int i = 1; i <= grdProductos.Rows - 1; i++)
                    {
                        int vProd = Convert.ToInt32(grdProductos.get_Texto(i, grdProductos.get_ColIndex("ID_Productos")));
                        if (vProd != 0)
                        {
                            pr.Producto.Id = vProd;

                            Single precio = pr.Buscar();

                            Double kilos = Convert.ToDouble(grdProductos.get_Texto(i, grdProductos.get_ColIndex("Kilos")));

                            grdProductos.set_Texto(i, grdProductos.get_ColIndex("Precio"), precio);
                            grdProductos.set_Texto(i, grdProductos.get_ColIndex("Total"), precio * kilos);

                        }
                    }

                    Calcular_Precios();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void Calcular_Precios()
        {
            double iTotal = Convert.ToDouble(grdProductos.get_Texto(1, grdProductos.get_ColIndex("Total")));
            double iKilos = Convert.ToDouble(grdProductos.get_Texto(1, grdProductos.get_ColIndex("Kilos")));
            double iInt = Convert.ToDouble(grdProductos.get_Texto(1, grdProductos.get_ColIndex("Precio")));

            double tTotal = 0, tKilos = 0;

            for (int i = 1; i <= grdProductos.Rows - 1; i++)
            {
                int vProd = Convert.ToInt32(grdProductos.get_Texto(i, grdProductos.get_ColIndex("ID_Productos")));
                if (vProd != 0)
                {
                    Single precio = Convert.ToSingle(grdProductos.get_Texto(i, grdProductos.get_ColIndex("Precio")));
                    Double kilos = Convert.ToDouble(grdProductos.get_Texto(i, grdProductos.get_ColIndex("Kilos")));


                    grdProductos.set_Texto(i, grdProductos.get_ColIndex("Total"), precio * kilos);
                    grdProductos.set_Texto(i, grdProductos.get_ColIndex("%"), ((kilos / iKilos) * 100));

                    tKilos += kilos;
                    tTotal += (precio * kilos);
                }
            }

            tKilos -= iKilos;
            tTotal -= iTotal;
            lblPromedio.Text = "Promedio: " + ((tTotal / iKilos) - iInt).ToString("N3");
            lblIntegracion.Text = "Int: " + (tTotal / iKilos).ToString("N3");

            Calcular_Formulas();
            //lblProm.Text = FormatNumber(PrecioBifes * 0.70215, 2) '[(b/ancho+b/angosto)/2]*40.43/100+[(b/ancho+b/angosto)/2]
        }

        private void Calcular_Formulas()
        {
            for (int i = 1; i <= grdProductos.Rows - 1; i++)
            {
                int vProd = Convert.ToInt32(grdFormulas.get_Texto(i, grdFormulas.get_ColIndex("ID_Productos")));
                string cadena = Convert.ToString(grdFormulas.get_Texto(i, grdFormulas.get_ColIndex("Formula")));
                Single precio = 0;
                
                if (vProd != 0 & cadena.Length > 0)
                {
                    // Buscar expersiones regulares para cambiar los [n] x precio
                }

                grdFormulas.set_Texto(i, grdFormulas.get_ColIndex("Precio"), precio);
            }
        }
        private void grdProductos_Editado(short f, short c, object a)
        {
            int cPr = grdProductos.get_ColIndex("Precio");
            if (c == cPr)
            {
                grdProductos.set_Texto(f, c, Convert.ToSingle(a));
                Calcular_Precios();
                grdProductos.ActivarCelda(f + 1, c);
            }
        }

        private void grdProductos_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Add))
            {
                grdProductos.set_Texto(grdProductos.Row, grdProductos.Col, Convert.ToSingle(grdProductos.get_Texto(grdProductos.Row - 1, grdProductos.Col)));
                grdProductos.ActivarCelda(grdProductos.Row + 1);
                Calcular_Precios();
            }
            else
            {
                if (e == Convert.ToInt32(Keys.Enter))
                {
                    grdProductos.ActivarCelda(grdProductos.Row + 1);
                }
            }
        }
    }
}
