namespace Programa1.Controles
{
    using Programa1.DB;
    using Programa1.Herramientas;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class cProveedores : UserControl
    {
        private Proveedores Provs;
        private Herramientas herramientas = new Herramientas();

        private bool cCancel = false;
        private bool MostrarTipo = true;
        private string vFiltroIn = "";

        public string Filtro_In
        {
            get
            {
                return vFiltroIn;
            }
            set
            {
                if (value != vFiltroIn)
                {
                    vFiltroIn = value;
                    Cargar();
                }
            }
        }
        public bool Mostrar_Tipo
        {
            get { return splitContainer1.Panel2Collapsed; }
            set
            {
                MostrarTipo = value;
                splitContainer1.Panel2Collapsed = !MostrarTipo;
            }
        }


        public string Titulo { get => lblTitulo.Text; set { lblTitulo.Text = value; } }

        public event EventHandler Cambio_Seleccion;

        public cProveedores()
        {
            InitializeComponent();

            Provs = new Proveedores();
            DataTable dt = Provs.Tipo.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                lstTipos.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }

            Cargar();
        }

        public int Valor_Actual
        {
            get
            {
                int n = -1;
                if (lst.SelectedIndex > -1)
                {
                    n = herramientas.Codigo_Seleccionado(lst.Text);
                }
                return n;
            }
            set
            {
                for (int i = 0; i < lst.Items.Count; i++)
                {
                    if (herramientas.Codigo_Seleccionado(lst.Items[i].ToString()) == value)
                    {
                        lst.SelectedIndices.Add(i);
                    }
                }
            }
        }

        public string Cadena(string campo)
        {
            string s = "";
            if (lst.SelectedItems.Count > 0)
            {
                if (lst.SelectedItems.Count == 1)
                {
                    s = $"{campo}={Valor_Actual.ToString()}";
                }
                else
                {
                    foreach (string sn in lst.SelectedItems)
                    {
                        s = $"{s}, {herramientas.Codigo_Seleccionado(sn)}";
                    }
                    s = $"{campo} IN({s.Substring(2)})";
                }
            }
            return s;
        }


        private void Cargar()
        {
            List<String> items = new List<String>();

            foreach (String item in lst.SelectedItems)
            {
                items.Add(item);
            }

            DataTable dt = new DataTable();
            string s = "";

            if (txtBuscar.TextLength > 0)
            {
                int i;
                bool n = int.TryParse(txtBuscar.Text, out i);
                if (n)
                {
                    s = $"Nombre like '%{i}%' OR Id={i}";
                }
                else
                {
                    s = $"Nombre like '%{txtBuscar.Text}%'";
                }
            }
            else
            {
                if (lstTipos.SelectedItems.Count == 1)
                {
                    s = $"(Tipo={herramientas.Codigo_Seleccionado(lstTipos.Text)})";
                }
                else
                {
                    if (lstTipos.SelectedItems.Count > 1)
                    {
                        foreach (string sn in lstTipos.SelectedItems)
                        {
                            s = $"{s}, {herramientas.Codigo_Seleccionado(sn)}";
                        }
                        s = $"(Tipo IN ({s.Substring(2)}))";
                    }
                }

                if (vFiltroIn.Length > 0)
                {
                    if (s.Length > 0)
                    {
                        s = $"{s} AND Id IN ({vFiltroIn})";
                    }
                    else
                    {
                        s = $"Id IN ({vFiltroIn})";
                    }

                }
            }

            lst.Items.Clear();
            dt = Provs.Datos(s);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            if (items.Count > 0)
            {
                for (int n = 0; n < items.Count; n++)
                {
                    for (int i = 0; i < lst.Items.Count; i++)
                    {
                        if (items[n].ToString() == lst.Items[i].ToString())
                        {
                            lst.SetSelected(i, true);
                            break;
                        }
                    }
                }
            }
        }

        public void Siguiente()
        {
            if (lst.Items.Count > 0)
            {
                int i = lst.SelectedIndex;

                if (i == -1)
                {
                    lst.SetSelected(0, true);
                }
                else
                {
                    cCancel = true;
                    lst.SetSelected(i, false);
                    cCancel = false;
                    if (i == lst.Items.Count - 1)
                    {
                        lst.SetSelected(0, true);
                    }
                    else
                    {
                        lst.SetSelected(i + 1, true);
                    }
                }
            }
        }
        public void Anterior()
        {
            if (lst.Items.Count > 0)
            {
                int i = lst.SelectedIndex;

                if (i == -1)
                {
                    lst.SetSelected(lst.Items.Count - 1, true);
                }
                else
                {
                    cCancel = true;
                    lst.SetSelected(i, false);
                    cCancel = false;
                    if (i == 0)
                    {
                        lst.SetSelected(lst.Items.Count - 1, true);
                    }
                    else
                    {
                        lst.SetSelected(i - 1, true);
                    }
                }
            }
        }

        private void Lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cCancel == false)
            {
                Cambio_Seleccion(this, e);
            }
        }

        private void LstTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Lst_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    cmdNinguno.PerformClick();
                    break;
                case MouseButtons.Right:
                    cmdInvertir.PerformClick();
                    break;
            }
        }


        private void CmdTodos_Click(object sender, EventArgs e)
        {
            cCancel = true;
            SelectionMode previousMode = lst.SelectionMode;
            lst.SelectionMode = SelectionMode.MultiSimple;

            lst.BeginUpdate();

            for (int i = 0; i < lst.Items.Count; i++)
            {
                lst.SelectedIndices.Add(i);
            }

            lst.EndUpdate();
            lst.SelectionMode = previousMode;
            cCancel = false;
            Cambio_Seleccion(this, e);
        }
        private void CmdInvertir_Click(object sender, EventArgs e)
        {
            cCancel = true;
            SelectionMode previousMode = lst.SelectionMode;
            lst.SelectionMode = SelectionMode.MultiSimple;

            lst.BeginUpdate();

            for (int i = 0; i < lst.Items.Count; i++)
            {
                lst.SetSelected(i, !lst.GetSelected(i));
            }

            lst.EndUpdate();
            lst.SelectionMode = previousMode;
            cCancel = false;
            Cambio_Seleccion(this, e);
        }

        private void RdId_CheckedChanged(object sender, EventArgs e)
        {
            Provs.Ordern_XId = rdId.Checked;
            Cargar();
        }
        private void ChVer_CheckedChanged(object sender, EventArgs e)
        {
            Provs.Mostrar_Ocultos = chVer.Checked;
            Cargar();
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void CmdTodosTipos_Click(object sender, EventArgs e)
        {
            lstTipos.SelectedIndex = -1;
        }      

        private void CmdNinguno_Click(object sender, EventArgs e)
        {
            lst.SelectedIndex = -1;
        }

        private void SplitContainer1_Panel1_DoubleClick(object sender, EventArgs e)
        {
            Mostrar_Tipo = !MostrarTipo;
        }
    }
}
