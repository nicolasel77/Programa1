
namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;

    public partial class frmCaja_Diaria : Form
    {

        private Entradas cd_E = new Entradas();

        public frmCaja_Diaria()
        {
            InitializeComponent();
        }
        private void frmCaja_Diaria_Load(object sender, EventArgs e)
        {
            Cargar_Datos();
        }


        private void frmCaja_Diaria_Resize(object sender, EventArgs e)
        {
            if (splPrincipal.Width != 0) { splPrincipal.SplitterDistance = (splPrincipal.Width - 212); }
        }


        private void Cargar_Datos()
        {
            grdEntradas.MostrarDatos(cd_E.Datos($"Fecha='{mntFecha.SelectionRange.Start:MM/dd/yy}'"), true);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("ID"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Fecha"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("ID_TipoEntrada"), 50);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Nombre"), 90);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("ID_SubTipoEntrada"), 50);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Descripcion"), 120);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Importe"), 90);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Grupo"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Es_Entrega"), 0);
            grdEntradas.set_ColW(grdEntradas.get_ColIndex("Tabla"), 0);
            
            grdEntradas.set_Texto(0, grdEntradas.get_ColIndex("ID_TipoEntrada"), "Tipo");
            grdEntradas.set_Texto(0, grdEntradas.get_ColIndex("ID_SubTipoEntrada"), "SubTipo");

            grdEntradas.Columnas[grdEntradas.get_ColIndex("Importe")].Style.Format = "N1";

            Totales();
        }

        private void Totales()
        {
            Double t = grdEntradas.SumarCol(grdEntradas.get_ColIndex("Importe"), false);
            lblTEntrada.Text = "Total Entradas: " + t.ToString("C1");
            lblSEntradas.Text = t.ToString("C1");

            double Sa = cd_E.Total_AFecha(mntFecha.SelectionStart.AddDays(-1));

            lblSSantEntradas.Text = Sa.ToString("C1");

        }

        private void mntFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            Cargar_Datos();
        }
    }
}
