using System.Windows.Forms;
using Programa1.DB;
using Programa1.DB.Sucursales;

namespace Programa1.Carga.Precios
{
    public partial class frmGuardar_Varios : Form
    {
        public frmGuardar_Varios()
        {
            InitializeComponent();
        }

        Herramientas.Herramientas h = new Herramientas.Herramientas();
        public bool Guardar = false;


        public void Cargar()
        {
            DB.Sucursales.Sucursales sucs = new DB.Sucursales.Sucursales();
            h.Llenar_List(lstSucursales, sucs.Datos("Propio=1 AND Ver=1"));
        }

        private void cmdGuardar_Click(object sender, System.EventArgs e)
        {
            Guardar = true;
            if (lstSucursales.SelectedIndex == -1)
            {
                for (int i = 0; i <= lstSucursales.Items.Count - 1; i++)
                {
                    lstSucursales.SetSelected(i, true);
                }
            }
            this.Hide();
        }
    }
}
