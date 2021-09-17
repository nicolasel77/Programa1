namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Windows.Forms;

    public partial class frmEditar_Cajas : Form
    {
        public frmEditar_Cajas()
        {
            InitializeComponent();
        }

        readonly Herramientas.Herramientas h = new Herramientas.Herramientas();
        readonly Cajas cajas = new Cajas();

        private void frmEditar_ARendir_Load(object sender, EventArgs e)
        {
            h.Llenar_List(lstNombres, cajas.Datos());
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
                    cajas.ID = h.Codigo_Seleccionado(lstNombres.Text);
                    cajas.Nombre = txtEdicion.Text;

                    cajas.Actualizar();

                    h.Llenar_List(lstNombres, cajas.Datos());
                    txtEdicion.Text = "";
                }
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            if(txtEdicion.TextLength != 0)
            {
                cajas.Nombre = txtEdicion.Text;
                cajas.ID = cajas.Max_ID() + 1;

                cajas.Agregar();

                h.Llenar_List(lstNombres, cajas.Datos());
                txtEdicion.Text = "";
            }
        }
    }
}
