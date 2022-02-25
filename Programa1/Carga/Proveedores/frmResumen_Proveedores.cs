using Programa1.Carga.Proveedores;
using Programa1.DB.Proveedores;
using Proveedores;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Programa1.Carga
{
    public partial class frmResumen_Proveedores : Form
    {
        private CCtes_Proveedores cCtes = new CCtes_Proveedores();
        private int Prov = 0;

        private byte c_IDEstado = 7;
        private byte c_Estado = 8;
        private byte c_Observacion = 9;

        public frmResumen_Proveedores()
        {
            InitializeComponent();
        }

        private void frmResumen_Proveedores_Load(object sender, EventArgs e)
        {
            grdEntradas.TeclasManejadas = new int[] { 32, 46 };
            Cargar_Proveedores(DateTime.Today);
            cFechas1.Ultima_Fecha = cCtes.Ultima_Fecha();
        }


        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Proveedores(cFechas1.fecha_Fin);
        }

        private void Cargar_Proveedores(DateTime fecha)
        {
            this.Cursor = Cursors.WaitCursor;
            Prov = Convert.ToInt32(grdProv.get_Texto(grdProv.Row, 0));

            grdProv.MostrarDatos(cCtes.Saldos_Proveedores(fecha), true, false);
            grdProv.Columnas[grdProv.get_ColIndex("Saldo")].Style.Format = "#,###.#";
            grdProv.set_Texto(0, 1, "Proveedor");
            grdProv.AutosizeAll();
            for (int i = grdProv.Rows - 1; i >= 1; i--)
            {
                double v = Convert.ToDouble(grdProv.get_Texto(i, grdProv.get_ColIndex("Saldo")));
                //Para redondear a 0
                if (v > -1 & v < 1)
                {
                    v = 0;
                }

                if (v != 0 | chSoloSaldos.Checked == false)
                {
                    if (Convert.ToSingle(grdProv.get_Texto(i, grdProv.get_ColIndex("Saldo"))) > 0)
                    {
                        grdProv.set_ColorLetraCelda(i, grdProv.get_ColIndex("Saldo"), Color.Blue);
                    }
                    else
                    {
                        grdProv.set_ColorLetraCelda(i, grdProv.get_ColIndex("Saldo"), Color.DarkRed);
                    }
                }
                else
                {
                    grdProv.Filas[i].Visible = false;
                }

                if (Convert.ToInt32(grdProv.get_Texto(i, 0)) == Prov) { grdProv.ActivarCelda(i, 0); }
            }
            if (Prov != 0) { Cargar_Datos(Prov); }

            Double sp = Convert.ToDouble(grdProv.SumarCol(grdProv.get_ColIndex("Saldo"), false));
            lblSaldoProveedores.Text = sp.ToString("$ #,##0.0");
            this.Cursor = Cursors.Default;
        }

        private void grdProv_CambioFila(short Fila)
        {
            Prov = Convert.ToInt32(grdProv.get_Texto(grdProv.Row, 0));
            if (Prov != 0)
            {
                Cargar_Datos(Prov);
            }
        }

        private void Cargar_Datos(int prov)
        {
            Compras();
            Pagos();
            DateTime f1 = cFechas1.fecha_Actual;
            DateTime f2 = cFechas1.fecha_Fin;

            double t = cCtes.Saldo_Proveedor(prov, f1.AddDays(-1));

            lblSaldoAnt.Text = t.ToString("$ #,##0.0");
            t = Convert.ToDouble(grdProv.get_Texto(grdProv.Row, 2));
            lblSaldo.Text = t.ToString("$ #,##0.0");


            t = cCtes.Total_Ajustes(prov, f1, f2);
            lblAjustes.Text = t.ToString("$ #,##0.0");

            t = cCtes.Total_Devoluciones(prov, f1, f2);
            lblDevoluciones.Text = t.ToString("$ #,##0.0");

            t = cCtes.Ganancia_Proveedor(prov, f1, f2);
            lblGanancia.Text = t.ToString("$ #,##0.0");
        }

        private void Compras()
        {
            //COMPRAS
            String s = $"{cFechas1.Cadena()} AND Id_Proveedores={Prov}";
            cCtes.Compras.Proveedor.Id = Prov;
            DataTable dt = cCtes.Detalle_Compras(s, rdAgrupado.Checked);
            grdEntradas.MostrarDatos(dt, true, false);

            grdEntradas.set_Texto(0, grdEntradas.get_ColIndex("Id_Productos"), "Prod");
            grdEntradas.Columnas[grdEntradas.get_ColIndex("Costo")].Style.Format = "#,###.#";

            grdEntradas.AutosizeAll();
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Id"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Id_Proveedores"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Nombre"), 0);

            double t = Convert.ToDouble(grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), false));
            lblTotalEntradas.Text = t.ToString("Total: $ #,##0.0");
            lblCompras.Text = t.ToString("$ #,##0.0");

            C1.Win.C1FlexGrid.CellStyle cKilos;
            cKilos = grdEntradas.Styles.Add("Kilos");
            cKilos.Font = new Font("Arial", 8, FontStyle.Bold);
            cKilos.Format = "#,###.#";

            grdEntradas.Columnas[grdEntradas.get_ColIndex("Kilos")].Style = cKilos;

            C1.Win.C1FlexGrid.CellStyle cTotal;
            cTotal = grdEntradas.Styles.Add("Total");
            cTotal.ForeColor = Color.DarkBlue;
            cTotal.Format = "#,###.#";

            grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style = cTotal;

            grdEntradas.set_ColW(c_IDEstado, 0);
            grdEntradas.set_ColW(c_Estado, 0);
            grdEntradas.set_ColW(c_Observacion, 200);

            C1.Win.C1FlexGrid.CellStyle ch = grdEntradas.Styles.Add("ch");
            C1.Win.C1FlexGrid.CellStyle er = grdEntradas.Styles.Add("er");
            ch.BackColor = Color.LightBlue;
            er.BackColor = Color.MistyRose;

            for (int i = 1; i <= grdEntradas.Rows - 1; i++)
            {
                int ne = Convert.ToInt32(grdEntradas.get_Texto(i, c_Estado));
                if (ne == 1) { grdEntradas.Filas[i].Style = ch; }
                if (ne == 2) { grdEntradas.Filas[i].Style = er; }
            }
        }

        private void Pagos()
        {
            //PAGOS
            DataTable dt = cCtes.Salidas(Prov, cFechas1.fecha_Actual, cFechas1.fecha_Fin);
            grdSalidas.MostrarDatos(dt, true, false);

            grdSalidas.Columnas[grdSalidas.get_ColIndex("Importe")].Style.Format = "#,###.#";
            grdSalidas.AutosizeAll();
            grdSalidas.set_ColW(grdSalidas.get_ColIndex("ID"), 0);
            C1.Win.C1FlexGrid.CellStyle Devolucion;
            C1.Win.C1FlexGrid.CellStyle Ajuste;

            Devolucion = grdSalidas.Styles.Add("Devolucion");
            Ajuste = grdSalidas.Styles.Add("Ajuste");

            Devolucion.BackColor = Color.MistyRose;
            Ajuste.BackColor = Color.LightSkyBlue;

            for (int i = 1; i <= grdSalidas.Rows - 1; i++)
            {
                string s = Convert.ToString(grdSalidas.get_Texto(i, grdSalidas.get_ColIndex("Descripcion")));
                s = s.Substring(0, 2);

                switch (s)
                {
                    case "Dv":
                        grdSalidas.Filas[i].Style = Devolucion;
                        break;
                    case "Aj":
                        grdSalidas.Filas[i].Style = Ajuste;
                        break;
                    default:
                        grdSalidas.Filas[i].Style = null;
                        break;
                }

            }

            double t = Convert.ToDouble(grdSalidas.SumarCol(grdSalidas.get_ColIndex("Importe"), false));
            lblTotalSalidas.Text = t.ToString("Total: $ #,##0.0");
            lblPagos.Text = t.ToString("$ #,##0.0");
        }

        private void frmResumen_Proveedores_Resize(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer2.Height - 137;
        }

        private void chSoloSaldos_CheckedChanged(object sender, EventArgs e)
        {
            Cargar_Proveedores(cFechas1.fecha_Fin);
        }

        private void rdAgrupado_CheckedChanged(object sender, EventArgs e)
        {
            Cargar_Datos(Prov);
        }

        private void grdEntradas_DobleClick(object sender, EventArgs e)
        {
            String s = $"Fecha='{Convert.ToDateTime(grdEntradas.get_Texto(grdEntradas.Row, 1)):MM/dd/yy}' AND Id_Proveedores={Prov}";
            cCtes.Compras.Proveedor.Id = Prov;
            DataTable dt = cCtes.Detalle_Compras(s, false);

            frmDetalle fr = new frmDetalle();
            fr.grd.MostrarDatos(dt, true, false);
            fr.grd.AutosizeAll();
            fr.ShowDialog();
            grdEntradas.Focus();
            SendKeys.Send("{ESCAPE}");
        }

        private void grdEntradas_KeyPress(object sender, short e)
        {
            if (e == 32)
            {
                if (rdAgrupado.Checked == true)
                {
                    int i = grdEntradas.Row;
                    Estados_Compra es = new Estados_Compra();
                    es.Fecha = Convert.ToDateTime(grdEntradas.get_Texto(i, grdEntradas.get_ColIndex("Fecha")));
                    es.Proveedor.Id = Prov;
                    es.ID = Convert.ToInt32(grdEntradas.get_Texto(i, c_IDEstado));
                    int n = Convert.ToInt32(grdEntradas.get_Texto(i, c_Estado));
                    if (n == 0) { es.Estado = Estados_Compra.e_Estado.Sin_Chequear; }
                    if (n == 1) { es.Estado = Estados_Compra.e_Estado.Chequeado; }
                    if (n == 2) { es.Estado = Estados_Compra.e_Estado.Error; }

                    es.Siguiente();

                    C1.Win.C1FlexGrid.CellStyle ch = grdEntradas.Styles.Add("ch");
                    C1.Win.C1FlexGrid.CellStyle er = grdEntradas.Styles.Add("er");
                    ch.BackColor = Color.LightBlue;
                    er.BackColor = Color.MistyRose;

                    grdEntradas.set_Texto(i, c_Estado, es.Estado);
                    grdEntradas.set_Texto(i, c_IDEstado, es.ID);

                    if (es.Estado == Estados_Compra.e_Estado.Chequeado) { grdEntradas.Filas[i].Style = ch; }
                    if (es.Estado == Estados_Compra.e_Estado.Error) { grdEntradas.Filas[i].Style = er; }
                    if (es.Estado == Estados_Compra.e_Estado.Sin_Chequear) { grdEntradas.Filas[i].Style = null; grdEntradas.set_Texto(i, c_Observacion, ""); } 
                }

            }
        }

        private void grdEntradas_Editado(short f, short c, object a)
        {
            if (c == c_Observacion)
            {
                Estados_Compra es = new Estados_Compra();
                es.ID = Convert.ToInt32(grdEntradas.get_Texto(f, c_IDEstado));
                es.Observacion = a.ToString();
                if (es.ID == 0)
                {
                    es.Fecha = Convert.ToDateTime(grdEntradas.get_Texto(f, grdEntradas.get_ColIndex("Fecha")));
                    es.Proveedor.Id = Prov;
                    es.Estado = Estados_Compra.e_Estado.Chequeado;
                    grdEntradas.set_Texto(f, c_Estado, 1);

                    es.Agregar();
                    grdEntradas.set_Texto(f, c_IDEstado, es.ID);
                }
                else
                {
                    es.Actualizar("Observacion", a.ToString());
                }
                C1.Win.C1FlexGrid.CellStyle ch = grdEntradas.Styles.Add("ch");
                ch.BackColor = Color.LightBlue;

                grdEntradas.set_Texto(f, c_IDEstado, es.ID);
                grdEntradas.set_Texto(f, c_Observacion, a);
                if (es.Estado == Estados_Compra.e_Estado.Chequeado) { grdEntradas.Filas[f].Style = ch; }

            }
        }

        private void grdEntradas_KeyUp(object sender, short e)
        {
            if (e == Convert.ToInt32(Keys.Delete))
            {
                if (grdEntradas.Col == c_Observacion)
                {
                    int i = grdEntradas.Row;
                    Estados_Compra es = new Estados_Compra();
                    es.ID = Convert.ToInt32(grdEntradas.get_Texto(i, c_IDEstado));
                    es.Observacion = "";
                    es.Actualizar("Observacion", es.Observacion);
                    grdEntradas.set_Texto(i, c_Observacion, "");
                }
            }
        }
    }
}
