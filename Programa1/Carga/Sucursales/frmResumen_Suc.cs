namespace Programa1.Carga
{
    using Programa1.Carga.Sucursales;
    using Programa1.DB;
    using Programa1.DB.Sucursales;
    using Programa1.DB.Varios;
    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    public partial class frmResumen_Suc : Form
    {

        private readonly Resumen_Sucursales RS = new Resumen_Sucursales();
        private readonly Estadisticas_Sucursales Est = new Estadisticas_Sucursales();
        private int Suc = 0;
        private byte Filtro_Salidas = 0;
        private byte Filtro_Entradas = 0;
        private bool Filtro_SucUnica = true;
        private Estadisticas_Sucursales.Tipo_Propio Filtro_EsSucursal = Estadisticas_Sucursales.Tipo_Propio.Sucursales;

        private bool NoCargar = false;

        public frmResumen_Suc()
        {
            InitializeComponent();
        }

        private void frmResumen_Suc_Load(object sender, EventArgs e)
        {
            // 13: Enter
            // 46: Delete            
            grdEntradas.TeclasManejadas = new int[] { 13, 46 };
            grdSalidas.TeclasManejadas = new int[] { 13, 46 };
        }
        private void frmResumen_Suc_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    if (grdSucursales.EsUltimaFila() == true)
                    {
                        grdSucursales.ActivarCelda(1, 0);
                    }
                    else
                    {
                        grdSucursales.ActivarCelda(grdSucursales.Row + 1, 0);
                    }
                    break;
                case Keys.Subtract:
                    if (grdSucursales.Row == 1)
                    {
                        grdSucursales.ActivarCelda(grdSucursales.Rows - 1, 0);
                    }
                    else
                    {
                        grdSucursales.ActivarCelda(grdSucursales.Row - 1, 0);
                    }
                    break;
                case Keys.Divide:
                    cFechas1.Anterior();
                    break;
                case Keys.Multiply:
                    cFechas1.Siguiente();
                    break;
            }
        }

        private void Menu_SalidasClick(object sender, EventArgs e)
        {
            ToolStripMenuItem n = sender as ToolStripMenuItem;
            if (n.Checked == false)
            {
                foreach (ToolStripMenuItem t in mnuFiltroSalidas.Items)
                {
                    t.Checked = false;
                }
                n.Checked = true;
                Filtro_Salidas = Convert.ToByte(n.Tag);
            }
            else
            {
                n.Checked = false;
                Filtro_Salidas = 0;
            }
            Salidas();
            this.Cursor = Cursors.Default;
        }
        private void Menu_EntradasClick(object sender, EventArgs e)
        {
            ToolStripMenuItem n = sender as ToolStripMenuItem;
            if (n.Checked == false)
            {
                foreach (ToolStripMenuItem t in mnuFiltroEntradas.Items)
                {
                    t.Checked = false;
                }
                n.Checked = true;
                Filtro_Entradas = Convert.ToByte(n.Tag);
            }
            else
            {
                n.Checked = false;
                Filtro_Entradas = 0;
            }
            Entradas();
            this.Cursor = Cursors.Default;
        }

        private void Cargar_Listado(DateTime Semana)
        {
            grdSucursales.MostrarDatos(RS.Listado_Balances(Semana, sucursalesListado.Checked), true, false);
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
                if (Convert.ToInt32(grdSucursales.get_Texto(i, 0)) == Suc) { grdSucursales.ActivarCelda(i, 0); }
            }
            grdSucursales.Columnas[2].Style.Format = "#,###.#";
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Est.Sem.Semana = cFechas1.fecha_Actual;
            Cargar_Listado(cFechas1.fecha_Actual);
            Cargar_Datos();
            this.Cursor = Cursors.Default;
        }

        private void grdSucursales_CambioFila(short Fila)
        {
            if (Convert.ToInt32(grdSucursales.get_Texto(Fila, 0)) != 0)
            {
                Suc = Convert.ToInt32(grdSucursales.get_Texto(Fila, 0));
                Est.Suc.ID = Suc;
                lblSuc.Text = $"{grdSucursales.get_Texto(Fila, 1)}";
                Cargar_Datos();
                this.Cursor = Cursors.Default;
            }
        }

        private void Cargar_Datos()
        {
            if (grdSucursales.Row > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                Entradas();
                Salidas();
                Cuentas();
                this.Text = $"{lblSuc.Text}  -  Semana: {cFechas1.fecha_Actual:dd/MM/yy}";
                if (paEst.Visible == true) { Estadisticas(); }
                this.Cursor = Cursors.Default;
            }
        }

        private void Entradas()
        {
            DataTable dt = new DataTable();
            dt = RS.Entradas(Suc, cFechas1.fecha_Actual, cFechas1.fecha_Fin, Filtro_Entradas);
            grdEntradas.MostrarDatos(dt, true, false);
            grdEntradas.AutosizeAll();
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("ID_Proveedor"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("ID"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("SQL"), 0);

            grdEntradas.Columnas[grdEntradas.get_ColIndex("Kilos")].Style.Format = "#,###.#";
            grdEntradas.Columnas[grdEntradas.get_ColIndex("Costo")].Style.Format = "#,###.#";
            grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "#,###.#";

            double T = grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), false);
            lblTotalEntradas.Text = "Total: " + T.ToString("C1");
        }
        private void Salidas()
        {
            DataTable dt = new DataTable();
            dt = RS.Salidas(Suc, cFechas1.fecha_Actual, cFechas1.fecha_Fin, Filtro_Salidas);
            grdSalidas.MostrarDatos(dt, true, false);
            grdSalidas.AutosizeAll();
            grdSalidas.set_ColW(grdSalidas.get_ColIndex("ID_Proveedor"), 0);
            grdSalidas.set_ColW(grdSalidas.get_ColIndex("ID"), 0);
            grdSalidas.set_ColW(grdSalidas.get_ColIndex("SQL"), 0);

            grdSalidas.Columnas[grdSalidas.get_ColIndex("Kilos")].Style.Format = "#,###.#";
            grdSalidas.Columnas[grdSalidas.get_ColIndex("Costo")].Style.Format = "#,###.#";
            grdSalidas.Columnas[grdSalidas.get_ColIndex("Total")].Style.Format = "#,###.#";

            double T = grdSalidas.SumarCol(grdSalidas.get_ColIndex("Total"), false);
            lblTotalSalidas.Text = "Total: " + T.ToString("C1");
        }
        private void Cuentas()
        {
            grdVentas.MostrarDatos(Est.Ventas_KilosPorTipo(), true, false);
            for (int i = 1; i < grdVentas.Cols; i++)
            {
                grdVentas.Columnas[i].Format = "N1";
            }
            grdVentas.AutosizeAll();

            Stock st = new Stock();
            string cadena = $"Id_Sucursales={Suc} AND {cFechas1.Cadena()}";
            double k = st.Stock_Carne(cadena);
            cmdCarne.Text = $"STOCK CARNE:  {k:N1} kg";
            k = Est.Balance();
            lblBalance.Text = $"Balance: {k:N1}";
            if (k > 0) { lblBalance.ForeColor = Color.SteelBlue; } else { lblBalance.ForeColor = Color.Red; }

            k = Est.Balances();
            lblTBalancesSuc.Text = $"Sucs: {k:N1}";
            if (k > 0) { lblTBalancesSuc.ForeColor = Color.SteelBlue; } else { lblTBalancesSuc.ForeColor = Color.Red; }

            k = Est.Balances(false);
            lblTBalancesClientes.Text = $"Cln: {k:N1}";
            if (k > 0) { lblTBalancesClientes.ForeColor = Color.SteelBlue; } else { lblTBalancesClientes.ForeColor = Color.Red; }
        }

        private void Estadisticas()
        {
            this.Cursor = Cursors.WaitCursor;
            if (NoCargar == false)
            {
                if (Suc != 0)
                {
                    if (Filtro_SucUnica == true) { grdEstadistica.MostrarDatos(Est.Unica(Convert.ToInt32(nuTop.Value)), true, true); } else { grdEstadistica.MostrarDatos(Est.Todas(), true, true); }

                    for (int i = 2; i < grdEstadistica.Cols; i++)
                    {
                        grdEstadistica.Columnas[i].Format = "N1";
                        grdEstadistica.SumarCol(i, true);
                    }

                    if (Est.Filtro_Propio == Estadisticas_Sucursales.Tipo_Propio.Sucursales)
                    {
                        int c = grdEstadistica.get_ColIndex("Balance");
                        int f = grdEstadistica.Rows - 1;
                        double balance = Convert.ToDouble(grdEstadistica.get_Texto(f, c));
                        double kilos = Convert.ToDouble(grdEstadistica.get_Texto(f, grdEstadistica.get_ColIndex("Carne")));
                        double tIntV = 0;
                        double tIntC = 0;
                        double b = 0;
                        for (int i = 1; i < f; i++)
                        {

                            b = Convert.ToDouble(grdEstadistica.get_Texto(i, c));

                            if (b > 0)
                            {
                                grdEstadistica.set_ColorLetraCelda(i, c - 1, Color.SteelBlue);
                                grdEstadistica.set_ColorLetraCelda(i, c, Color.SteelBlue);
                            }
                            else
                            {
                                grdEstadistica.set_ColorLetraCelda(i, c - 1, Color.Red);
                                grdEstadistica.set_ColorLetraCelda(i, c, Color.Red);
                            }
                            tIntV += (Convert.ToDouble(grdEstadistica.get_Texto(i, grdEstadistica.get_ColIndex("Carne"))) * Convert.ToDouble(grdEstadistica.get_Texto(i, grdEstadistica.get_ColIndex("IntVenta"))));
                            tIntC += (Convert.ToDouble(grdEstadistica.get_Texto(i, grdEstadistica.get_ColIndex("Carne"))) * Convert.ToDouble(grdEstadistica.get_Texto(i, grdEstadistica.get_ColIndex("IntCompra"))));
                        }


                        if (kilos != 0)
                        {
                            grdEstadistica.set_Texto(f, grdEstadistica.get_ColIndex("Rend"), balance / kilos);
                            grdEstadistica.set_Texto(f, grdEstadistica.get_ColIndex("IntVenta"), tIntV / kilos);
                            grdEstadistica.set_Texto(f, grdEstadistica.get_ColIndex("IntCompra"), tIntC / kilos);
                            grdEstadistica.set_Texto(f, grdEstadistica.get_ColIndex("DifInt"), (tIntV / kilos) - (tIntC / kilos));
                        }
                        else
                        {
                            grdEstadistica.set_Texto(f, grdEstadistica.get_ColIndex("Rend"), 0);
                            grdEstadistica.set_Texto(f, grdEstadistica.get_ColIndex("IntVenta"), 0);
                            grdEstadistica.set_Texto(f, grdEstadistica.get_ColIndex("IntCompra"), 0);
                            grdEstadistica.set_Texto(f, grdEstadistica.get_ColIndex("DifInt"), 0);
                        }
                        b = Convert.ToDouble(grdEstadistica.get_Texto(f, c));

                        if (b > 0)
                        {
                            grdEstadistica.set_ColorLetraCelda(f, c - 1, Color.SteelBlue);
                            grdEstadistica.set_ColorLetraCelda(f, c, Color.SteelBlue);
                        }
                        else
                        {
                            grdEstadistica.set_ColorLetraCelda(f, c - 1, Color.Red);
                            grdEstadistica.set_ColorLetraCelda(f, c, Color.Red);
                        } 
                    }
                    grdEstadistica.AutosizeAll();
                }
            }
            this.Cursor = Cursors.Default;

        }

        private void paEstadistica_Click(object sender, EventArgs e)
        {
            if (paEst.Visible == false)
            {
                Estadisticas();
            }
            paEst.Visible = !paEst.Visible;
        }

        private void grdEntradas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Enter))
            {
                Cargar_DetalleEntrada();
            }
            else
            {
                if (e == Convert.ToInt32(Keys.Delete))
                {
                    if (grdEntradas.Row > 0)
                    {
                        grdEntradas.BorrarFila();
                    }
                }
            }
        }

        private void grdEntradas_DobleClick(object sender, EventArgs e)
        {
            Cargar_DetalleEntrada();
        }

        private void Cargar_DetalleEntrada()
        {
            string s = grdEntradas.get_Texto(grdEntradas.Row, grdEntradas.get_ColIndex("SQL")).ToString();
            if (s.Length > 0)
            {
                frmDetalle_Resumen fr = new frmDetalle_Resumen();
                Datos_Genericos dg = new Datos_Genericos();
                fr.grd.MostrarDatos(dg.Datos(s), true, false);
                fr.grd.AutosizeAll();
                fr.ShowDialog();
                this.Focus();
                grdEntradas.Focus();
            }
        }

        private void grdSalidas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Enter))
            {
                Cargar_DetalleSalida();
            }
            else
            {
                if (e == Convert.ToInt32(Keys.Delete))
                {
                    if (grdSalidas.Row > 0)
                    {
                        grdSalidas.BorrarFila();
                    }
                }
            }
        }
        private void grdSalidas_DobleClick(object sender, EventArgs e)
        {
            Cargar_DetalleSalida();
        }

        private void Cargar_DetalleSalida()
        {
            string s = grdSalidas.get_Texto(grdSalidas.Row, grdSalidas.get_ColIndex("SQL")).ToString();
            if (s.Length > 0)
            {
                frmDetalle_Resumen fr = new frmDetalle_Resumen();
                Datos_Genericos dg = new Datos_Genericos();
                fr.grd.MostrarDatos(dg.Datos(s), true, false);
                fr.grd.AutosizeAll();
                fr.ShowDialog();
                this.Focus();
                grdSalidas.Focus();
            }
        }

        private void cmdStock_Carne_Click(object sender, EventArgs e)
        {
            frmStock_Carne fr = new frmStock_Carne();
            Stock st = new Stock();

            string cadena = $"Id_Sucursales={Suc} AND {cFechas1.Cadena()} AND ID_Tipo=1";

            fr.grd.MostrarDatos(st.Datos(cadena), true, true);
            fr.grd.SumarCol(fr.grd.get_ColIndex("Kilos"), true);
            fr.grd.AutosizeAll();
            fr.ShowDialog();
        }

        private void todasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NoCargar == false)
            {
                NoCargar = true;
                unaToolStripMenuItem.Checked = !unaToolStripMenuItem.Checked;
                todasToolStripMenuItem.Checked = !todasToolStripMenuItem.Checked;
                Filtro_SucUnica = unaToolStripMenuItem.Checked;
                Estadisticas();
                NoCargar = false;
            }
        }

        private void cmdRecargar_Click(object sender, EventArgs e)
        {
            Estadisticas();
        }

        private void nuTop_ValueChanged(object sender, EventArgs e)
        {
            Estadisticas();
        }

        private void sucursalesListado_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            sucursalesListado.Checked = true;
            clientesToolStripMenuItem1.Checked = false;
            Cargar_Listado(cFechas1.fecha_Actual);
            this.Cursor = Cursors.Default;
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            sucursalesListado.Checked = false;
            clientesToolStripMenuItem1.Checked = true;
            Cargar_Listado(cFechas1.fecha_Actual);
            this.Cursor = Cursors.Default;

        }

        #region Resise panel est
        bool allowResize = false;

        private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            allowResize = false;
        }

        private void pictureBox1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (allowResize)
            {
                int v = this.Width - paEst.Left - e.X;
                this.paEst.Width = (v > anchoEst) ? v : anchoEst;
                anchoEst = v;
                Application.DoEvents();
            }
        }

        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            allowResize = true;
        }
        #endregion

        private void lbl4_Click(object sender, EventArgs e)
        {
            nuTop.Value = 4;
        }

        private void lbl5_Click(object sender, EventArgs e)
        {
            nuTop.Value = 5;
        }

        private void lbl6_Click(object sender, EventArgs e)
        {
            nuTop.Value = 6;
        }

        private void lbl10_Click(object sender, EventArgs e)
        {
            nuTop.Value = 10;
        }

        int anchoEst = 600;
        private void tiOcultar_Tick(object sender, EventArgs e)
        {
            if (Cursor.Current != null) { this.Cursor = new Cursor(Cursor.Current.Handle); }
            int posX = Cursor.Position.X;
            //this.Text = $"X: {posX}  paEst.Left: {paEst.Left:N1}";
            paEst.Width = (posX <= paEst.Left) ? 10 : anchoEst;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoCargar = true;
            clientesToolStripMenuItem.Checked = true;
            NoCargar = false;
            sucursalesToolStripMenuItem.Checked = false;
            Filtro_EsSucursal = Estadisticas_Sucursales.Tipo_Propio.Clientes;
            Est.Filtro_Propio = Filtro_EsSucursal;
            Estadisticas();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoCargar = true;
            sucursalesToolStripMenuItem.Checked = true;
            NoCargar = false;
            clientesToolStripMenuItem.Checked = false;
            Filtro_EsSucursal = Estadisticas_Sucursales.Tipo_Propio.Sucursales;
            Est.Filtro_Propio = Filtro_EsSucursal;
            Estadisticas();
        }


    }
}
