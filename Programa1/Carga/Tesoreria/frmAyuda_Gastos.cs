using Programa1.DB.Tesoreria;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa1.Carga.Tesoreria
{
    public partial class frmAyuda_Gastos : Form
    {
        private Tipo_Gastos TGastos;
        private Detalle_Gastos DTgastos;

        private enum TOpcion : byte
        {
            gTipo = 0,
            gSubTipo = 1,
            gDetalle = 2
        }
        private TOpcion Opcion;
        public string Valor = "";
        private string Filtro_Tipo = "";

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

        public void Cargar_TiposGastos(int Tipo)
        {
            TGastos = new Tipo_Gastos();
            TGastos.Id_Tipo = Tipo;
            Opcion = TOpcion.gTipo;
            Cargar();
        }
        public void Cargar_SubTiposGastos(int Tipo)
        {
            TGastos = new Tipo_Gastos();
            TGastos.Id_Tipo = Tipo;
            if (TGastos.grupoS.Campo_Filtro.Length > 0 ) { Filtro_Tipo = $"{TGastos.grupoS.Campo_Filtro}={Tipo}"; }
            Opcion = TOpcion.gSubTipo;
            
            Cargar();
        }
        public void Cargar_Detalles(int Tipo)
        {
            DTgastos = new Detalle_Gastos();
            DTgastos.Id_Tipo = Tipo;
            Opcion = TOpcion.gDetalle;
            Filtro_Tipo = $"ID_Tipo={Tipo}";

            Cargar();
        }

        private void Cargar()
        {
            DataTable dt = new DataTable();
            string sf = "";

            lst.Items.Clear();

            switch (Opcion)
            {
                case TOpcion.gTipo:
                    if (txtBuscar.Text.Length != 0) { sf = $"Nombre LIKE '%{txtBuscar.Text}%'"; }

                    dt = TGastos.Datos(sf);
                    foreach (DataRow dr in dt.Rows)
                    {
                        lst.Items.Add($"{dr[0]}. {dr[1]}");
                    }
                    break;
                case TOpcion.gSubTipo:
                    if (txtBuscar.Text.Length != 0) 
                    { 
                        if (Filtro_Tipo.Length > 0)
                        {
                            sf = $"{Filtro_Tipo} AND {TGastos.grupoS.Campo_Nombre} LIKE '%{txtBuscar.Text}%'";
                        }
                    }
                    else
                    {
                        sf = Filtro_Tipo;
                    }

                    dt = TGastos.SubTipos(sf);
                    foreach (DataRow dr in dt.Rows)
                    {
                        lst.Items.Add($"{dr[0]}. {dr[1]}");
                    }
                    break;
                case TOpcion.gDetalle:
                    if (txtBuscar.Text.Length != 0)
                    {
                        if (Filtro_Tipo.Length > 0)
                        {
                            sf = $"{Filtro_Tipo} AND Nombre LIKE '%{txtBuscar.Text}%'";
                        }
                    }
                    else
                    {
                        sf = Filtro_Tipo;
                    }

                    dt = DTgastos.Datos(sf);
                    foreach (DataRow dr in dt.Rows)
                    {
                        lst.Items.Add($"{dr["ID_Detalle"]}. {dr["Nombre"]}");
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
                    if(i == ls.Items.Count - 1)
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
            if (e.KeyChar== Convert.ToChar(13))
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
