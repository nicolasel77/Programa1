namespace Programa1.Carga.Tesoreria
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class frmNuevaFecha : Form
    {
        public bool Aceptado;

        public frmNuevaFecha()
        {
            InitializeComponent();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Aceptado = true;
            this.Hide();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
