using System;
using System.Windows.Forms;

namespace Programa1.Carga
{
    public partial class frmStock : Form
    {
        public frmStock()
        {
            InitializeComponent();
            
        }

        private void CProds_Cambio_Seleccion(object sender, EventArgs e)
        {
            Armar_Cadena();
        }

        #region "Mensaje"
        private void Mensaje(string Mensaje)
        {
            System.Media.SystemSounds.Beep.Play();
            lblMensaje.Text = Mensaje;
            tiMensaje.Start();
        }
        private void TiMensaje_Tick(object sender, EventArgs e)
        {
            lblMensaje.Text = "";
            tiMensaje.Stop();
        }

        #endregion

        private void CmdMostrar_Click(object sender, EventArgs e)
        {
            Armar_Cadena();
        }
       

        private void CSucs_Cambio_Seleccion(object sender, EventArgs e)
        {
            Armar_Cadena();
        }

        private void Armar_Cadena()
        {
            string p = cProds.Cadena("Id_Productos");
            string s = cSucs.Cadena("Id_Sucursales");
            string f = cFecha.Cadena();
            Herramientas.Herramientas h = new Herramientas.Herramientas();

            s = h.Unir(f, s);
            s = h.Unir(s, p);

            Mensaje(s);
        }
    }
}
