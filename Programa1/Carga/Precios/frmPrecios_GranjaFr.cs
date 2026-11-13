namespace Programa1.Carga.Precios
{
    using C1.Win.C1FlexGrid;
    using Grilla2;
    using Programa1.DB;
    using Programa1.DB.Sucursales;
    using Programa1.DB.Varios;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class frmPrecios_GranjaFr : Form
    {
        Precios_Franquicia prf = new Precios_Franquicia();
        Precios_Sucursales pr = new Precios_Sucursales();

        private List<CellStyle> Colores = new List<CellStyle>();

        public frmPrecios_GranjaFr()
        {
            InitializeComponent();
        }

        private void frmPrecios_GranjaFr_Load(object sender, EventArgs e)
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

            DataTable dt = prf.Precios_GranjaListaKilos();
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

            grdFranquicia.Columnas[grdFranquicia.get_ColIndex("Precio")].Style.Format = $"N{nuDecimales.Value}";

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

        private void Cargar_Fechas()
        {
            lstFechas.Items.Clear();
            DataTable dt = prf.Fechas_Granja();

            foreach (DataRow dr in dt.Rows)
            {
                lstFechas.Items.Add($"{Convert.ToDateTime(dr[0]).ToString("dd/MM/yyyy")}   {dr[1]:N1}");
            }
        }

        private void lstFechas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            Cargar_Sucursales();

            this.Cursor = Cursors.Default;
        }

        private void Cargar_Sucursales()
        {
            grdSucursales.MostrarDatos(prf.Integraciones_Sucursales(Convert.ToDateTime(lstFechas.Text.Substring(0, 10)), 4), true, false);
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

            pr.Fecha = Convert.ToDateTime(lstFechas.Text.Substring(0, 10));
            prf.Fecha = pr.Fecha;

            grdSucursales.Ordenar(Convert.ToInt16(grdSucursales.get_ColIndex("ID")));

            if (prf.Sucursal != 0) { Cargar_Precios(); }
        }
       
        private void grdSucursales_CambioFila(short Fila)
        {
            pr.Sucursal.ID = 0;
            prf.Sucursal = 0;
            if (Convert.ToInt32(grdSucursales.get_Texto(Fila, 0)) != 0)
            {
                prf.Sucursal = Convert.ToInt32(grdSucursales.get_Texto(Fila, 0));
                pr.Sucursal.ID = prf.Sucursal;

                lblSuc.Text = Convert.ToString(grdSucursales.get_Texto(Fila, 1));
                Cargar_Precios();
            }
        }


        private void Cargar_Precios()
        {
            this.Cursor = Cursors.WaitCursor;
            if (prf.Sucursal != 0)
            {
                if (lstFechas.SelectedIndex != -1)
                {
                    for (int i = 1; i <= grdProductos.Rows - 1; i++)
                    {
                        int vProd = Convert.ToInt32(grdProductos.get_Texto(i, grdProductos.get_ColIndex("ID_Productos")));
                        if (vProd != 0)
                        {
                            prf.Producto = vProd;
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

                    cmdGuardarFR.Enabled = true;
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

        }

        private void grdFranquicia_Editado(short f, short c, object a)
        {
            if (f == 1 && c == 2)
            {
                grdFranquicia.set_Texto(f, c, Convert.ToSingle(a));
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
            double pf = Convert.ToDouble(grdFranquicia.get_Texto(1, grdFranquicia.get_ColIndex("Precio")));
            double total = Convert.ToDouble(grdProductos.get_Texto(1, grdProductos.get_ColIndex("Kilos")));
            total = total * pf;

            double t = 0;
            for (int i = 2; i <= grdFranquicia.Rows - 1; i++)
            {
                double t1 = Convert.ToDouble(grdProductos.get_Texto(i, grdProductos.get_ColIndex("Total")));
                t += t1;
            }

            for (int i = 2; i <= grdFranquicia.Rows - 1; i++)
            {
                double t1 = Convert.ToDouble(grdProductos.get_Texto(i, grdProductos.get_ColIndex("Total")));
                double kg = Convert.ToDouble(grdProductos.get_Texto(i, grdProductos.get_ColIndex("Kilos")));

                double t2 = t1 / t * 100;

                grdFranquicia.set_Texto(i, grdFranquicia.get_ColIndex("%"), t2);

                kg = kg == 0 ? 0 : (total * t2 / 100) / kg;

                grdFranquicia.set_Texto(i, grdFranquicia.get_ColIndex("Precio"), kg);
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

        private void grdFranquicia_KeyPress(object sender, short e)
        {
            if (e == 43)
            {
                if (grdFranquicia.Row < grdFranquicia.Rows && grdFranquicia.Col == grdFranquicia.Cols - 1)
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

        /// <summary>
        /// Recalcula los precios de franquicia del pollo de una semana (lunes a domingo) para todas
        /// las sucursales con dbo.sp_Actualizar_PreciosPollo: costo = promedio de compra del pollo,
        /// % = diferencia con el precio de lista del domingo, resto = precio de lista / (1 + %).
        /// Primero muestra el cálculo y solo graba si se confirma.
        /// </summary>
        private void cmdSemanaPollo_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;
            int desdeLunes = ((int)hoy.DayOfWeek + 6) % 7;
            DateTime lunesPasado = hoy.AddDays(-desdeLunes - 7);

            string txt = Microsoft.VisualBasic.Interaction.InputBox(
                "Lunes de la semana a actualizar (dd/MM/yyyy):", "Precios pollo", lunesPasado.ToString("dd/MM/yyyy"));
            if (txt.Trim().Length == 0) return;

            if (!DateTime.TryParseExact(txt.Trim(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out DateTime fecha))
            {
                MessageBox.Show("La fecha no es válida.", "Precios pollo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                DataTable resumen = Ejecutar_SemanaPollo(fecha, true);
                Cursor = Cursors.Default;
                if (resumen == null || resumen.Rows.Count == 0)
                {
                    MessageBox.Show("No hay sucursales para calcular.", "Precios pollo");
                    return;
                }

                DateTime lunes = Convert.ToDateTime(resumen.Rows[0]["Lunes"]);
                DateTime domingo = Convert.ToDateTime(resumen.Rows[0]["Domingo"]);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Semana del {lunes:dd/MM/yyyy} al {domingo:dd/MM/yyyy}");
                sb.AppendLine();
                int ok = 0;
                foreach (DataRow dr in resumen.Rows)
                {
                    if (dr["Estado"].ToString() == "OK")
                    {
                        ok++;
                        sb.AppendLine($"{dr["Id_Sucursales"]} {dr["Nombre"]}: costo {Convert.ToDouble(dr["Costo"]):N2}, " +
                            $"venta {Convert.ToDouble(dr["Venta"]):N2}, {Convert.ToDouble(dr["Porcentaje"]):N2}%");
                    }
                    else
                    {
                        sb.AppendLine($"{dr["Id_Sucursales"]} {dr["Nombre"]}: {dr["Estado"]} (no se toca)");
                    }
                }
                sb.AppendLine();
                sb.AppendLine($"¿Grabar los precios de {ok} sucursales y actualizar Stock y Traslados de esa semana?");

                if (ok == 0)
                {
                    MessageBox.Show(sb.ToString(), "Precios pollo");
                    return;
                }

                if (MessageBox.Show(sb.ToString(), "Precios pollo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Cursor = Cursors.WaitCursor;
                    Ejecutar_SemanaPollo(fecha, false);
                    Cargar_Fechas();
                    Cursor = Cursors.Default;
                    MessageBox.Show("Precios actualizados.", "Precios pollo");
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error al actualizar: " + ex.Message, "Precios pollo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable Ejecutar_SemanaPollo(DateTime fecha, bool simular)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString))
            using (SqlCommand cmd = new SqlCommand("dbo.sp_Actualizar_PreciosPollo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha.Date;
                cmd.Parameters.Add("@Simular", SqlDbType.Bit).Value = simular;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            return ds.Tables.Count > 0 ? ds.Tables[0] : null;
        }
    }
}
