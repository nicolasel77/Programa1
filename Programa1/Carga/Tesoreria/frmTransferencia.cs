namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    public partial class frmTransferencia : Form
    {
        public frmTransferencia()
        {
            InitializeComponent();
        }
        private Cajas cajas = new Cajas();
        private Herramientas.Herramientas h = new Herramientas.Herramientas();

        private void frmTransferencia_Load(object sender, EventArgs e)
        {
            DataTable dt = cajas.Datos();
            h.Llenar_List(lstDesde, dt);
            h.Llenar_List(lstHacia, dt);
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtImporte_Enter(object sender, EventArgs e)
        {
            txtImporte.Text = "";
        }

        private void cmdAcpetar_Click(object sender, EventArgs e)
        {
            if (lstDesde.SelectedIndex > -1)
            {
                if (lstHacia.SelectedIndex > -1)
                {
                    double importe;
                    if (double.TryParse(txtImporte.Text, out importe)==true)
                    {
                        MessageBox.Show(importe.ToString());
                    }
                }
            }
        }
        
    }
}
