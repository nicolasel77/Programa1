using Programa1.Clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Varios
{
    public partial class frmAyuda_Generico : Form
    {
        private c_Base cb = new c_Base();

        public int ID_Seleccionado = 0;
        public string Nombre_Seleccionado = "";

        public string Campo_Nombre = "Nombre";
        public string Campo_ID = "ID";

        public string Tabla
        {
            set
            {
                cb.Tabla = value;
                cb.Campo_ID = Campo_ID;
                cb.Campo_Nombre = Campo_Nombre;
                txtBuscar.Text = "";
                Cargar();
            }
        }
        public string Vista 
        {
            set
            {
                txtBuscar.Text = "";
                cb.Vista = value;
                cb.Campo_ID = Campo_ID;
                cb.Campo_Nombre = Campo_Nombre;
                Cargar_Vista();
            }
        }

        public frmAyuda_Generico()
        {
            InitializeComponent();
        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {
            txtBuscar.Focus();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Cargar()
        {
            DataTable dt = new DataTable();
            string sf = "";
            int n = 0;

            lst.Items.Clear();            

            if (txtBuscar.Text.Length != 0)
            {
                sf = $"{Campo_Nombre} LIKE '%{txtBuscar.Text.Replace(" ", "%")}%'";
                if (int.TryParse(txtBuscar.Text, out n) == true)
                {
                    sf = $"{sf} OR CONVERT(varchar, {Campo_ID}) LIKE '%{n}%'";
                }
            }

            dt = cb.Datos(sf);

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Items.Add($"{dr[0]}. {dr[1]}");
                } 
            }


            txtBuscar.Focus();
        }
        private void Cargar_Vista()
        {
            DataTable dt = new DataTable();
            string sf = "";
            int n = 0;

            lst.Items.Clear();            
            
            if (txtBuscar.Text.Length != 0)
            {
                sf = $"{Campo_Nombre} LIKE '%{txtBuscar.Text.Replace(" ", "%")}%'";
                if (int.TryParse(txtBuscar.Text, out n) == true)
                {
                    sf = $"{sf} OR CONVERT(varchar, {Campo_ID}) LIKE '%{n}%'";
                }
            }

            dt = cb.Datos_Vista(sf);

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
                Herramientas.Herramientas h = new Herramientas.Herramientas();

                e.Handled = true;
                if (lst.Items.Count == 1)
                {
                    ID_Seleccionado = h.Codigo_Seleccionado(lst.Items[0].ToString());
                    Nombre_Seleccionado = h.Nombre_Seleccionado(lst.Items[0].ToString());
                }
                else
                {
                    ID_Seleccionado = h.Codigo_Seleccionado(lst.Text);
                    Nombre_Seleccionado = h.Nombre_Seleccionado(lst.Text);
                }
                this.Hide();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if(lst.SelectedIndex != -1)
            {
                Herramientas.Herramientas h = new Herramientas.Herramientas();

                ID_Seleccionado = h.Codigo_Seleccionado(lst.Text);
                Nombre_Seleccionado = h.Nombre_Seleccionado(lst.Text);
            }
            this.Hide();
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            cmdAceptar.PerformClick();
        }
    }
}
