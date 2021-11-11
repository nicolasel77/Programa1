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
            nuAño.Value = DateTime.Today.Year;
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

        private void nuAño_ValueChanged(object sender, EventArgs e)
        {
            mntFecha.SetDate(new DateTime((int)nuAño.Value, mntFecha.SelectionStart.Month, mntFecha.SelectionStart.Day));
        }
    }
}
