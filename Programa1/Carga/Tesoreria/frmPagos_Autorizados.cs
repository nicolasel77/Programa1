namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Varios;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmPagos_Autorizados : Form
    {
        C1.Win.C1FlexGrid.CellStyle e_prov;
        C1.Win.C1FlexGrid.CellStyle e_p1ha;

        public frmPagos_Autorizados()
        {
            InitializeComponent();
        }

        Pagos_Autorizados Pagos = new Pagos_Autorizados();

        private void frmPagos_Autorizados_Load(object sender, EventArgs e)
        {
            e_prov = grdAutorizados.Styles.Add("Prov");
            e_p1ha = grdAutorizados.Styles.Add("p1hac");

            e_prov.BackColor = Color.LightBlue;
            e_p1ha.BackColor = Color.MistyRose;

            Cargar();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;
            grdAutorizados.MostrarDatos(Pagos.Datos(), true, grdAutorizados.get_ColIndex("Saldo"));
            // 0  1       2      3     4       5     7       8       9          10       11    12      13    14       15
            //ID, Origen, Fecha, Plazo, Venc, Dias, ID_N, Nombre, Cant, Descripcion, Kilos, Costo, Total, Pagos, Saldo, Observacion 
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("ID"), 0);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Origen"), 80);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Fecha"), 55);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Plazo"), 30);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Venc"), 55);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Dias"), 30);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("ID_N"), 30);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Nombre"), 60);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Cant"), 40);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Descripcion"), 100);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Kilos"), 60);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Costo"), 40);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Total"), 80);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Pagos"), 80);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Saldo"), 90);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Observacion"), 200);

            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Kilos")].Style.Format = "N";
            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Costo")].Style.Format = "N1";
            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Total")].Style.Format = "N1";
            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Pagos")].Style.Format = "N1";
            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Saldo")].Style.Format = "N1";

            for (int i = 1; i < grdAutorizados.Rows - 1; i++)
            {
                if (Convert.ToInt16(grdAutorizados.get_Texto(i, 0)) == 0) { grdAutorizados.Filas[i].Style = e_prov; }
                if (Convert.ToInt16(grdAutorizados.get_Texto(i, 0)) == 1) { grdAutorizados.Filas[i].Style = e_p1ha; }
            }

            this.Cursor = Cursors.Default;

        }
    }
}
