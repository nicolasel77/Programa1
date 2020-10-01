using System;
using System.Windows.Forms;

namespace Programa1.Controles
{
    public partial class cBoton : UserControl
    {

        public event EventHandler Click;
        public cBoton()
        {
            InitializeComponent();
        }

        private void cmd_Click(object sender, EventArgs e)
        {
            this.Click(sender, e);
        }

        public string Texto
        {
            get { return cmd.Text; }
            set { cmd.Text = value; } 
        }
    }
}
