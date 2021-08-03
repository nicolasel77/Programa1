using Programa1.DB.Tesoreria;
using System;
using System.Data;
using System.Windows.Forms;
namespace Programa1.Carga.Tesoreria
{
    public partial class frmAyudaGrupos_E : Form
    {
        private Tablas Tablas = new Tablas();
        private Cajas eCajas;
        private Herramientas.Herramientas h = new Herramientas.Herramientas();

        public string Valor = "";
        public string tabla = "";
        public string campo_ID = "";
        public string campo_Nombre = "";
        public DataTable names;
        private string Filtro_Tipo = "";

        public frmAyudaGrupos_E()
        {
            InitializeComponent();
        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {
            Cargar();
            txtBuscar.Focus();
        }

        public void Cargar_Cajas()
        {
            eCajas = new Cajas();
            Cargar();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Cargar_TiposEntradas(int Tipo)
        {
            Tablas = new Tablas();
            Tablas.Id = Tipo;
            Cargar();
        }
        public void Cargar_SubTiposEntradas(int Tipo)
        {
            Tablas = new Tablas();
            Tablas.Id = Tipo;
            Tablas.Cargar();

            Cargar();
        }

        private void Cargar()
        {
            DataTable dt = new DataTable();
            string sf = "";
            dt = Tablas.Datos_Tablas();
            h.Llenar_List(lst, dt);
            lst.Items.Clear();

            if (txtBuscar.Text.Length != 0) { sf = $"Nombre LIKE '%{txtBuscar.Text}%'"; }



            foreach (DataRow dr in dt.Rows)
            {
                lst.Items.Add($"{dr[0]}. {dr[1]}");
            }

            txtBuscar.Focus();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Anterior(lst);
                    break;
                case Keys.Down:
                    Siguiente(lst);
                    break;
            }
        }

        private void Siguiente(ListBox ls)
        {
            if (ls.Items.Count != 0)
            {
                int i = ls.SelectedIndex;
                if (i == -1)
                {
                    lst.SelectedIndex = 0;
                }
                else
                {
                    if (i == ls.Items.Count - 1)
                    {
                        ls.SelectedIndex = 0;
                    }
                    else
                    {
                        ls.SelectedIndex = i + 1;
                    }
                }
            }
        }

        private void Anterior(ListBox ls)
        {
            int i = ls.SelectedIndex;
            if (i == -1)
            {
                ls.SelectedIndex = ls.Items.Count - 1;
            }
            else
            {
                if (i == 0)
                {
                    ls.SelectedIndex = ls.Items.Count - 1;
                }
                else
                {
                    ls.SelectedIndex = i - 1;
                }
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                cmdAceptar.PerformClick();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (lst.Items.Count > 0)
            {
                Herramientas.Herramientas h = new Herramientas.Herramientas();
                Tablas tab = new Tablas();
                tab.Id = h.Codigo_Seleccionado(lst.Text);
                tabla = tab.Tabla;
                campo_Nombre = tab.Campo_Nombre;
                campo_ID = tab.Campo_Id;

                this.Hide();
            }
            else
            {
                cmdCancelar.PerformClick();
            }

        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            cmdAceptar.PerformClick();
        }
    }
}
