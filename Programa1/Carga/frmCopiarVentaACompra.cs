namespace Programa1.Carga
{
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmCopiarVentaACompra : Form
    {
        public bool Aceptado = false;

        public frmCopiarVentaACompra()
        {
            InitializeComponent();
        }

        public void Cargar(DataTable dt)
        {
            grd.MostrarDatos(dt, true, false);
            grd.AutosizeAll();
        }
        private void CmdAceptar_Click(object sender, EventArgs e)
        {
            Aceptado = true;
        }
    }
}
