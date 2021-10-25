using Programa1.Clases;
using Programa1.DB;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Tesoreria
{
    public partial class frmAyuda_Gastos : Form
    {
        private c_Base cb;

        
        public frmAyuda_Gastos()
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
                sf = $"Nombre LIKE '%{txtBuscar.Text.Replace(" ", "%")}%'";
                if (int.TryParse(txtBuscar.Text, out n) == true)
                {
                    sf = $"{sf} OR CONVERT(varchar, ID) LIKE '%{n}%'";
                }
            }

            dt = cb.Datos(sf);

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
                e.Handled = true;
                if (lst.Items.Count == 1)
                {
                    Valor = lst.Items[0].ToString();
                }
                else
                {
                    Valor = lst.Text;
                }
                this.Hide();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Valor = lst.Text;
            this.Hide();
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            cmdAceptar.PerformClick();
        }
    }
}
