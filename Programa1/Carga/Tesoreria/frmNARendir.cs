namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System.Windows.Forms;

    public partial class frmNARendir : Form
    {
        public Nombres_ARendir nombres_ARendir { get; set; } = new Nombres_ARendir();
        private Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmNARendir()
        {
            InitializeComponent();

            h.Llenar_List(lst, nombres_ARendir.Datos());
        }

        private void cmdAceptar_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        private void cmdCancelar_Click(object sender, System.EventArgs e)
        {
            nombres_ARendir.ID = 0;
            this.Hide();
        }

        private void lst_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            nombres_ARendir.ID = h.Codigo_Seleccionado(lst.Text);
        }
    }
}
