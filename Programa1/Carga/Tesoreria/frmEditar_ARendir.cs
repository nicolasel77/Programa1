namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;

    public partial class frmEditar_ARendir : Form
    {
        public frmEditar_ARendir()
        {
            InitializeComponent();
        }

        readonly Herramientas.Herramientas h = new Herramientas.Herramientas();
        readonly Nombres_ARendir a_Rendir = new Nombres_ARendir();

        private void frmEditar_ARendir_Load(object sender, EventArgs e)
        {
            h.Llenar_List(lstNombres, a_Rendir.Datos());
        }

        private void lstNombres_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEdicion.Text = h.Nombre_Seleccionado(lstNombres.Text);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if(lstNombres.SelectedIndex != -1)
            {
                if(txtEdicion.TextLength != 0)
                {
                    a_Rendir.ID = h.Codigo_Seleccionado(lstNombres.Text);
                    a_Rendir.Nombre = txtEdicion.Text;

                    a_Rendir.Actualizar();

                    h.Llenar_List(lstNombres, a_Rendir.Datos());
                    txtEdicion.Text = "";
                }
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            if(txtEdicion.TextLength != 0)
            {
                a_Rendir.Nombre = txtEdicion.Text;
                a_Rendir.ID = a_Rendir.Max_ID() + 1;

                a_Rendir.Agregar();

                h.Llenar_List(lstNombres, a_Rendir.Datos());
                txtEdicion.Text = "";
            }
        }
    }
}
