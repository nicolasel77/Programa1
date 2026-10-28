using C1.Win.C1FlexGrid;
using Grilla2;
using Programa1.DB;
using Programa1.DB.Sucursales;
using Programa1.DB.Varios;
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
        Precios_Franquicia prf = new Precios_Franquicia();

        private List<CellStyle> Colores = new List<CellStyle>();


        public frmPrecios_Carne()
        {
            InitializeComponent();
        }

        private void frmPrecios_Carne_Load(object sender, EventArgs e)
        {
            int[] t = { 43 };
            grdFranquicia.TeclasManejadas = t;

            prf.Tabla = "Precios_Franquicia";

            Configuraciones cn = new Configuraciones();
            string n = cn.Leer("Decimales en Precios Granja");
            if (n.Length != 0)
            {
                nuDecimales.Value = Convert.ToInt32(n);
            }

            DataTable dt = pr.Precios_CarneListaKilos();
            dt.Columns.Add("Precio", Type.GetType("System.Single"));
            dt.Columns.Add("Total", Type.GetType("System.Single"));
            dt.Columns.Add("%", Type.GetType("System.Single"));

            grdProductos.MostrarDatos(dt, true, false);
            grdProductos.set_Texto(0, 0, "Prod");

            grdProductos.set_ColW(grdProductos.get_ColIndex("ID_Productos"), 30);
            grdProductos.set_ColW(grdProductos.get_ColIndex("Nombre"), 150);
            grdProductos.set_ColW(grdProductos.get_ColIndex("Kilos"), 60);
            grdProductos.set_ColW(grdProductos.get_ColIndex("Precio"), 70);
            grdProductos.set_ColW(grdProductos.get_ColIndex("Total"), 90);
            grdProductos.set_ColW(grdProductos.get_ColIndex("%"), 50);

            grdProductos.Columnas[grdProductos.get_ColIndex("Kilos")].Style.Format = "N1";
            grdProductos.Columnas[grdProductos.get_ColIndex("Precio")].Style.Format = $"N{nuDecimales.Value}";
            grdProductos.Columnas[grdProductos.get_ColIndex("Total")].Style.Format = $"N{nuDecimales.Value}";
            grdProductos.Columnas[grdProductos.get_ColIndex("%")].Style.Format = "N2";


            dt.Columns.Remove("Kilos");
            dt.Columns.Remove("Total");

            dt.Columns.Add("% Au", Type.GetType("System.Single"));

            grdFranquicia.MostrarDatos(dt, true, false);
            grdFranquicia.set_Texto(0, 0, "Prod");

            grdFranquicia.set_ColW(grdFranquicia.get_ColIndex("ID_Productos"), 30);
            grdFranquicia.set_ColW(grdFranquicia.get_ColIndex("Nombre"), 150);
            grdFranquicia.set_ColW(grdFranquicia.get_ColIndex("%"), 50);
            grdFranquicia.set_ColW(grdFranquicia.get_ColIndex("% Au"), 50);

            grdFranquicia.Columnas[grdFranquicia.get_ColIndex("Precio")].Style.Format = $"N{nuDecimales.Value}";
            grdFranquicia.Columnas[grdFranquicia.get_ColIndex("% Au")].Style.Format = "N2";

            // Buscar los Porcentajes_Precios para los productos de franquicia
            for (int i = 1; i <= grdFranquicia.Rows - 1; i++)
            {
                int vProd = Convert.ToInt32(grdFranquicia.get_Texto(i, grdFranquicia.get_ColIndex("ID_Productos")));
                if (vProd != 0)
                {
                    prf.Producto = vProd;
                    Single por = prf.Buscar_Porcentaje();
                    grdFranquicia.set_Texto(i, grdFranquicia.get_ColIndex("% Au"), por);
                }
            }


            //13: Enter
            //43: +
            //46: Delete
            grdProductos.TeclasManejadas = new int[] { 13, 43, 46, 107 };

            dt = pr.Precios_Formulas();
            grdFormulas.MostrarDatos(dt, true, false);
            grdFormulas.set_Texto(0, 0, "ID");
            grdFormulas.AutosizeAll();
            grdFormulas.set_ColW(grdFormulas.get_ColIndex("Precio"), 80);
            grdFormulas.set_ColW(grdFormulas.get_ColIndex("PrecioFr"), 80);

            Cargar_Fechas();

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

            Cargar_Sucursales();

            this.Cursor = Cursors.Default;
        }

        private void Cargar_Sucursales()
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

            pr.Fecha = Convert.ToDateTime(lstFechas.Text);

            grdSucursales.Ordenar(Convert.ToInt16(grdSucursales.get_ColIndex("ID")));

            if (pr.Sucursal.ID != 0) { Cargar_Precios(); }
        }
        private void Cargar_Fechas()
        {
            lstFechas.Items.Clear();
            DataTable dt = pr.Fechas(1);

            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstFechas, dt, "dd/MM/yyy");
        }

        private void grdSucursales_CambioFila(short Fila)
        {
            pr.Sucursal.ID = 0;
            if (Convert.ToInt32(grdSucursales.get_Texto(Fila, 0)) != 0)
            {
                pr.Sucursal.ID = Convert.ToInt32(grdSucursales.get_Texto(Fila, 0));
                lblSuc.Text = Convert.ToString(grdSucursales.get_Texto(Fila, 1));
                Cargar_Precios();
            }
        }


        private void Cargar_Precios()
        {
            this.Cursor = Cursors.WaitCursor;
            if (pr.Sucursal.ID != 0)
            {
                if (lstFechas.SelectedIndex != -1)
                {
                    for (int i = 1; i <= grdProductos.Rows - 1; i++)
                    {
                        int vProd = Convert.ToInt32(grdProductos.get_Texto(i, grdProductos.get_ColIndex("ID_Productos")));
                        if (vProd != 0)
                        {
                            pr.Producto.ID = vProd;

                            Single precio = pr.Buscar();

                            Double kilos = Convert.ToDouble(grdProductos.get_Texto(i, grdProductos.get_ColIndex("Kilos")));

                            grdProductos.set_Texto(i, grdProductos.get_ColIndex("Precio"), precio);
                            grdProductos.set_Texto(i, grdProductos.get_ColIndex("Total"), precio * kilos);

                            precio = pr.Buscar(true);
                            grdFranquicia.set_Texto(i, grdFranquicia.get_ColIndex("Precio"), precio);
                        }
                    }

                    Calcular_Precios();

                    cmdGuardar.Enabled = true;
                    cmdBorrar.Enabled = true;
                }
            }
            this.Cursor = Cursors.Default;
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
            lblIntegracion.Text = (tTotal / iKilos).ToString("N3");

            Calcular_Formulas();
        }

        private void Calcular_Formulas()
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();

            //lblProm.Text = FormatNumber(PrecioBifes * 0.70215, 2) '[(b/ancho+b/angosto)/2]*40.43/100+[(b/ancho+b/angosto)/2]
            lblBifes.Text = "Bifes Desh: " + h.Calcular_Texto(Reemplazar_Precio("(([28]+[29])*0,70215)")).ToString("N3");

            for (int i = 1; i <= grdFormulas.Rows - 1; i++)
            {
                int vProd = Convert.ToInt32(grdFormulas.get_Texto(i, grdFormulas.get_ColIndex("ID_Productos")));
                string cadena = Convert.ToString(grdFormulas.get_Texto(i, grdFormulas.get_ColIndex("Formula")));
                string cadenafr = cadena;
                Single precio = 0;
                Single preciofr = 0;

                if (vProd != 0 & cadena.Length > 0)
                {
                    //Reemplazo la integracion por la calculada.
                    cadena = Reemplazar_Precio(cadena);
                    cadenafr = Reemplazar_Precio(cadenafr, true);
                    try
                    {
                        precio = Convert.ToSingle(h.Calcular_Texto(cadena));
                        preciofr = Convert.ToSingle(h.Calcular_Texto(cadenafr));
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    //Console.WriteLine();
                }

                grdFormulas.set_Texto(i, grdFormulas.get_ColIndex("Precio"), precio);
                grdFormulas.set_Texto(i, grdFormulas.get_ColIndex("PrecioFR"), preciofr);
            }

        }

        private string Reemplazar_Precio(string cadena, bool fr = false)
        {
            float integracion = Convert.ToSingle(lblIntegracion.Text);

            if (fr) integracion = Convert.ToSingle(grdFranquicia.get_Texto(1, grdFranquicia.get_ColIndex("Precio")));

            cadena = cadena.Replace("[1]", integracion.ToString());

            int n = cadena.IndexOf("[");

            while (n > -1)
            {
                int f = cadena.IndexOf("]");

                string testoAReemp = cadena.Substring(n + 1, (f - n) - 1);

                Single nPrecio = Buscar_PrecioEnGrilla(Convert.ToInt32(testoAReemp), fr);


                cadena = cadena.Replace(cadena.Substring(n, f - n + 1), nPrecio.ToString());

                n = cadena.IndexOf("[", n + 1);
            }

            return cadena;
        }

        private Single Buscar_PrecioEnGrilla(int prod, bool fr = false)
        {
            Single precio = 0;
            SpeedGrilla gr = fr ? grdFranquicia : grdProductos;

            for (int i = 1; i <= gr.Rows - 1; i++)
            {
                if (Convert.ToInt32(gr.get_Texto(i, gr.get_ColIndex("Id_Productos"))) == prod)
                {
                    precio = Convert.ToSingle(gr.get_Texto(i, gr.get_ColIndex("Precio")));
                    break;
                }
            }
            return precio;
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

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            frmGuardarPreciosCarne fr = new frmGuardarPreciosCarne();
            fr.Cargar();

            float integracion = Convert.ToSingle(grdSucursales.get_Texto(grdSucursales.Row, grdSucursales.get_ColIndex("Integracion")));
            DateTime fecha = Convert.ToDateTime(lstFechas.Text);

            fr.Seleccionar(integracion, fecha);
            fr.ShowDialog();

            if (fr.Guardar == true)
            {
                this.Cursor = Cursors.WaitCursor;

                pr.Fecha = fr.mntFecha.SelectionStart.Date;

                integracion = Convert.ToSingle(lblIntegracion.Text);

                foreach (string suc in fr.lstSucursales.SelectedItems)
                {
                    //Guardar todo por cada Sucursal
                    Herramientas.Herramientas h = new Herramientas.Herramientas();

                    pr.Sucursal.ID = h.Codigo_Seleccionado(suc);

                    //Guardar primero la integracion
                    pr.Producto.ID = 1;
                    pr.Precio = integracion;
                    pr.Precio_Fr = Convert.ToSingle(grdFranquicia.get_Texto(1, grdFranquicia.get_ColIndex("Precio")));
                    pr.Agregar();

                    //Guardar la Lista
                    //Arranca en el 2 porque el costo de integracion es el calculado
                    for (int i = 2; i <= grdProductos.Rows - 1; i++)
                    {
                        int prod = Convert.ToInt32((grdProductos.get_Texto(i, grdProductos.get_ColIndex("Id_Productos"))));

                        if (prod != 0)
                        {
                            pr.Producto.ID = prod;
                            pr.Precio = Convert.ToSingle((grdProductos.get_Texto(i, grdProductos.get_ColIndex("Precio"))));
                            pr.Precio_Fr = Convert.ToSingle((grdFranquicia.get_Texto(i, grdFranquicia.get_ColIndex("Precio"))));
                            pr.Agregar();
                        }
                    }
                    //Guardar Formulas
                    for (int i = 1; i <= grdFormulas.Rows - 1; i++)
                    {
                        int prod = Convert.ToInt32((grdFormulas.get_Texto(i, grdFormulas.get_ColIndex("Id_Productos"))));

                        if (prod != 0)
                        {
                            pr.Producto.ID = prod;
                            pr.Precio = Convert.ToSingle((grdFormulas.get_Texto(i, grdFormulas.get_ColIndex("Precio"))));
                            pr.Agregar();
                        }
                    }
                }

                Cargar_Fechas();
                lstFechas.SelectedIndex = 0;
                this.Cursor = Cursors.Default;
            }
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            frmImprimir_Carne fr = new frmImprimir_Carne();
            fr.ShowDialog();
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            frmBorrar_Carne fr = new frmBorrar_Carne();
            fr.ShowDialog();
            Cargar_Fechas();
        }

        private void nuDecimales_ValueChanged(object sender, EventArgs e)
        {
            Configuraciones cn = new Configuraciones();
            cn.Escribir("Decimales en Precios Carne", nuDecimales.Value.ToString());

            grdProductos.Columnas[grdProductos.get_ColIndex("Precio")].Style.Format = $"N{nuDecimales.Value}";
            grdProductos.Columnas[grdProductos.get_ColIndex("Total")].Style.Format = $"N{nuDecimales.Value}";

            Cargar_Precios();
        }

        private void grdFranquicia_Editado(short f, short c, object a)
        {
            grdFranquicia.set_Texto(f, c, Convert.ToSingle(a));
            if (f == 1 && c == 2)
            {
                double p = Convert.ToDouble(grdProductos.get_Texto(1, grdProductos.get_ColIndex("Precio")));
                double pf = Convert.ToDouble(grdFranquicia.get_Texto(1, grdFranquicia.get_ColIndex("Precio")));
                grdFranquicia.set_Texto(1, grdFranquicia.get_ColIndex("%"), ((p - pf) / pf) * 100);
                //Si se edita el precio de la franquicia, recalculo los precios.
                Calcular_Franquicia();
            }
            if (c == grdFranquicia.get_ColIndex("% Au"))
            {
                double p = Convert.ToDouble(a);
                grdFranquicia.set_Texto(f, c, p);

                // Guardar el porcentaje en la base de datos
                prf.Guardar_Porcentaje(Convert.ToInt32(grdFranquicia.get_Texto(f, 0)), p);
                // Si hay precio en la grilla de productos, recalculo el precio de franquicia
                double pr = Convert.ToDouble(grdProductos.get_Texto(f, grdProductos.get_ColIndex("Precio")));
                if (pr > 0)
                {
                    pr = pr + (pr * p / 100);
                    grdFranquicia.set_Texto(f, grdFranquicia.get_ColIndex("Precio"), pr);
                }
                grdFranquicia.ActivarCelda((c <= grdFranquicia.Rows - 1) ? f + 1 : 1, c);
                
            }
        }

        private void Calcular_Franquicia()
        {
            double p = Convert.ToDouble(grdProductos.get_Texto(1, grdProductos.get_ColIndex("Precio")));
            double pf = Convert.ToDouble(grdFranquicia.get_Texto(1, grdFranquicia.get_ColIndex("Precio")));

            if (pf == 0) return;
            
            p = p / pf;
            

            for (int i = 2; i <= grdFranquicia.Rows - 1; i++)
            {
                pf = grdProductos.get_Texto(i, grdProductos.get_ColIndex("Precio")) == "" ? 0 : Convert.ToDouble(grdProductos.get_Texto(i, grdProductos.get_ColIndex("Precio")));
                if (pf != 0)
                {
                    pf = pf / p;
                }
                grdFranquicia.set_Texto(i, grdFranquicia.get_ColIndex("Precio"), pf);
            }
        }

        private void cmdGuardarFR_Click(object sender, EventArgs e)
        {
            frmGuardar_Varios fr = new frmGuardar_Varios();
            fr.Cargar();
            fr.ShowDialog();
            if (fr.Guardar == true)
            {
                Cursor = Cursors.WaitCursor;
                Herramientas.Herramientas h = new Herramientas.Herramientas();

                prf.Fecha = fr.mntFecha.SelectionStart.Date;

                try
                {
                    foreach (string suc in fr.lstSucursales.SelectedItems)
                    {
                        //Guardar todo por cada Sucursal                    
                        prf.Sucursal = h.Codigo_Seleccionado(suc);
                        for (int i = 1; i < grdFranquicia.Rows; i++)
                        {
                            prf.Producto = (int)grdFranquicia.get_Texto(i, 0);
                            prf.Precio = Convert.ToSingle(grdFranquicia.get_Texto(i, "Precio"));

                            if (prf.Producto > 0) prf.Agregar();
                        }
                        for (int i = 1; i < grdFormulas.Rows; i++)
                        {
                            prf.Producto = Convert.ToInt16(grdFormulas.get_Texto(i, 0));
                            prf.Precio = Convert.ToSingle(grdFormulas.get_Texto(i, "PrecioFr"));

                            if (prf.Producto > 0) prf.Agregar();
                        }
                    }
                }
                catch (Exception er)
                {
                    Console.WriteLine(er);
                }
                Cargar_Precios();

                Cursor = Cursors.Default;
            }
        }
               

        private void cmdPorcentaje_Click(object sender, EventArgs e)
        {
            // Recorrer la grilla de franquicia y aplicar el porcentaje ingresado al precio de cada producto.
            try
            {
                for (int i = 1; i < grdFranquicia.Rows; i++)
                {
                    Single p = Convert.ToSingle(grdFranquicia.get_Texto(i, "% Au"));
                    Single precio = Convert.ToSingle(grdProductos.get_Texto(i, "Precio"));
                    
                    if (p != 0) { precio = precio + (precio * p / 100); }
                    
                    grdFranquicia.set_Texto(i, "Precio", precio);
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
            

        private void grdFranquicia_KeyPress(object sender, short e)
        {
            if(e == 43)
            {
                if(grdFranquicia.Row < grdFranquicia.Rows && grdFranquicia.Col == grdFranquicia.Cols - 1)
                {
                    double p = Convert.ToDouble(grdFranquicia.get_Texto(grdFranquicia.Row - 1, grdFranquicia.Col));

                    grdFranquicia.set_Texto(grdFranquicia.Row, grdFranquicia.Col, p);                    

                    // Guardar el porcentaje en la base de datos
                    prf.Guardar_Porcentaje(Convert.ToInt32(grdFranquicia.get_Texto(grdFranquicia.Row, 0)), p);

                    // Si hay precio en la grilla de productos, recalculo el precio de franquicia
                    double pr = Convert.ToDouble(grdProductos.get_Texto(grdFranquicia.Row, grdProductos.get_ColIndex("Precio")));
                    if (pr > 0)
                    {
                        pr = pr + (pr * p / 100);
                        grdFranquicia.set_Texto(grdFranquicia.Row, grdFranquicia.get_ColIndex("Precio"), pr);
                    }
                    grdFranquicia.ActivarCelda((grdFranquicia.Col <= grdFranquicia.Rows - 1) ? grdFranquicia.Row + 1 : 1, grdFranquicia.Col);
                }
            }
        }
    }
}
