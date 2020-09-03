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
        public frmResumen_Proveedores()
        {
            InitializeComponent();
        }

        private void frmResumen_Proveedores_Load(object sender, EventArgs e)
        {
            Cargar_Proveedores(DateTime.Today);
            cFechas1.Ultima_Fecha = cCtes.Compras.Ultima_Fecha();            
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
            for (int i = 1; i <= grdProv.Rows - 1; i++)
            {
                if (Convert.ToSingle(grdProv.get_Texto(i, grdProv.get_ColIndex("Saldo"))) > 0)
                {
                    grdProv.set_ColorLetraCelda(i, grdProv.get_ColIndex("Saldo"), Color.Blue);
                }
                else
                {
                    grdProv.set_ColorLetraCelda(i, grdProv.get_ColIndex("Saldo"), Color.DarkRed);
                }
                if (Convert.ToInt32(grdProv.get_Texto(i, 0)) == Prov) { grdProv.ActivarCelda(i, 0); }
            }
            if (Prov != 0) { Cargar_Datos(Prov); }
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
            double t = cCtes.Saldo_Proveedor(prov, cFechas1.fecha_Actual.AddDays(-1));
            lblSaldoAnt.Text = t.ToString("$ #,###.0");
            t = Convert.ToDouble(grdProv.get_Texto(grdProv.Row, 2));
            lblSaldo.Text = t.ToString("$ #,###.0");
        }

        private void Compras()
        {
            //COMPRAS
            String s = $"{cFechas1.Cadena()} AND Id_Proveedores={Prov}";
            DataTable dt = cCtes.Compras.Datos(s);
            grdEntradas.MostrarDatos(dt, true, false);

            grdEntradas.set_Texto(0, grdEntradas.get_ColIndex("Id_Productos"), "Prod");
            grdEntradas.Columnas[grdEntradas.get_ColIndex("Costo")].Style.Format = "#,###.#";
            grdEntradas.Columnas[grdEntradas.get_ColIndex("Kilos")].Style.Format = "#,###.#";
            grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "#,###.#";

            grdEntradas.AutosizeAll();
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Id"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Id_Proveedores"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Id_Proveedores") + 1, 0);

            double t = Convert.ToDouble(grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), false));
            lblTotalEntradas.Text = t.ToString("Total: $ #,###.0");
            lblCompras.Text = t.ToString("$ #,###.0");
        }

        private void Pagos()
        {
            //PAGOS
            DataTable dt = cCtes.Pagos(Prov, cFechas1.fecha_Actual, cFechas1.fecha_Fin);
            grdSalidas.MostrarDatos(dt, true, false);

            grdSalidas.set_ColW(grdSalidas.get_ColIndex("Id"), 0);

            grdSalidas.Columnas[grdSalidas.get_ColIndex("Importe")].Style.Format = "#,###.#";

            grdSalidas.AutosizeAll();

            double t = Convert.ToDouble(grdSalidas.SumarCol(grdSalidas.get_ColIndex("Total"), false));
            lblTotalSalidas.Text = t.ToString("Total: $ #,###.0");
            lblPagos.Text = t.ToString("$ #,###.0");
        }

        private void frmResumen_Proveedores_Resize(object sender, EventArgs e)
        {
            splitContainer2.SplitterDistance = splitContainer2.Height - 137;
        }
    }
}
