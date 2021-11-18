using System;
using System.Windows.Forms;

namespace Programa1.Controles
{
    public partial class cBoton : UserControl
    {

        public new event EventHandler Click;
        public cBoton()
        {
            InitializeComponent();
        }

        private void cmd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Click != null) { this.Click(sender, e); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string Texto
        {
            get { return cmd.Text; }
            set { cmd.Text = value; } 
        }
    }
}
