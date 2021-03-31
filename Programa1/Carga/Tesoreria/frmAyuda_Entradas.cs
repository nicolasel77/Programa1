using Programa1.DB.Tesoreria;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Tesoreria
{
    public partial class frmAyuda_Entradas : Form
    {
        private Tipos_Entradas TEntradas;
        private Cajas eCajas;

        private enum TOpcion : byte
        {
            eCaja = 0,
            eTipo = 1,
            eSubTipo = 2
        }
        private TOpcion Opcion;
        public string Valor = "";
        private string Filtro_Tipo = "";

        public frmAyuda_Entradas()
        {
            InitializeComponent();
        }

        private void frmAyuda_Load(object sender, EventArgs e)
        {
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
            TEntradas = new Tipos_Entradas();
            TEntradas.Id_Tipo = Tipo;
            Opcion = TOpcion.eTipo;
            Cargar();
        }
        public void Cargar_SubTiposEntradas(int Tipo)
        {
            TEntradas = new Tipos_Entradas();
            TEntradas.Id_Tipo = Tipo;
            TEntradas.Cargar();
            Opcion = TOpcion.eSubTipo;

            Cargar();
        }

        private void Cargar()
        {
            DataTable dt = new DataTable();
            string sf = "";

            lst.Items.Clear();

            switch (Opcion)
            {
                case TOpcion.eCaja:
                    if (txtBuscar.Text.Length != 0) { sf = $"Nombre LIKE '%{txtBuscar.Text}%'"; }

                    dt = eCajas.Datos(sf);

                    foreach (DataRow dr in dt.Rows)
                    {
                        lst.Items.Add($"{dr[0]}. {dr[1]}");
                    }
                    break;
                case TOpcion.eTipo:
                    if (txtBuscar.Text.Length != 0) { sf = $"Nombre LIKE '%{txtBuscar.Text}%'"; }

                    dt = TEntradas.Datos(sf);
                    foreach (DataRow dr in dt.Rows)
                    {
                        lst.Items.Add($"{dr[0]}. {dr[1]}");
                    }
                    break;
                case TOpcion.eSubTipo:
                    if (txtBuscar.Text.Length != 0)
                    {
                        if (Filtro_Tipo.Length > 0)
                        {
                            sf = $"{Filtro_Tipo} AND {TEntradas.grupoE.Campo_Nombre} LIKE '%{txtBuscar.Text}%'";
                        }
                        else
                        {
                            sf = $"{TEntradas.grupoE.Campo_Nombre} LIKE '%{txtBuscar.Text}%'";
                        }
                    }
                    else
                    {
                        sf = Filtro_Tipo;
                    }

                    dt = TEntradas.SubTipos(sf);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lst.Items.Add($"{dr[0]}. {dr[1]}");
                        }
                    }
                    break;
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
                Valor = lst.Text;
                this.Hide();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Valor = lst.Text;
            this.Hide();
        }
    }
}
