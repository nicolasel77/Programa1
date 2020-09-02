using Programa1.DB;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Programa1.Carga
{
    public partial class frmResumen_Proveedores : Form
    {
        private Compras Compras;

        public frmResumen_Proveedores()
        {
            InitializeComponent();
        }
        
        private void frmResumen_Proveedores_Load(object sender, EventArgs e)
        {
            Compras = new Compras();
            Cargar_Proveedores(DateTime.Today);
        }

        
        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Proveedores(cFechas1.fecha_Fin);
        }

        private void Cargar_Proveedores(DateTime fecha)
        {
            this.Cursor = Cursors.WaitCursor;
            grdProv.MostrarDatos(Compras.Saldos_Proveedores(fecha), true, false);
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
            }
            this.Cursor = Cursors.Default;
        }

    }
}
