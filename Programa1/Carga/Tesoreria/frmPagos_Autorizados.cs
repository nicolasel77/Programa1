namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Varios;
    using System;
    using System.Windows.Forms;

    public partial class frmPagos_Autorizados : Form
    {
        public frmPagos_Autorizados()
        {
            InitializeComponent();
        }

        Pagos_Autorizados Pagos = new Pagos_Autorizados();

        private void frmPagos_Autorizados_Load(object sender, EventArgs e)
        {
            grdAutorizados.MostrarDatos(Pagos.Datos(), true);
        }
    }
}
