namespace Programa1.Controles
{
    using Programa1.DB;
    using Programa1.Herramientas;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Windows.Forms;

    public partial class cTipoGastosSucursal : UserControl
    {
        private GastosSucursales_Tipos Tipos = new GastosSucursales_Tipos();
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

        public cTipoGastosSucursal()
        {
            InitializeComponent();
                        
            DataTable dt = Tipos.Rubro.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                lstRubros.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }
            dt = Tipos.Rubro.Grupo.Datos();
            foreach (DataRow dr in dt.Rows)
            {
                lstGrupos.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }

            Cargar();
        }

        public int Valor_Actual
        {
            get
            {
                int n = -1;
                if (lstTipo.SelectedIndex > -1)
                {
                    n = herramientas.Codigo_Seleccionado(lstTipo.Text);
                }
                return n;
            }
            set
            {
                for (int i = 0; i < lstTipo.Items.Count; i++)
                {
                    if (herramientas.Codigo_Seleccionado(lstTipo.Items[i].ToString()) == value)
                    {
                        lstTipo.SelectedIndices.Add(i);
                    }
                }
            }
        }

        public string Cadena(string campo)
        {
            string s = "";
            if (lstTipo.SelectedItems.Count > 0)
            {
                if (lstTipo.SelectedItems.Count == 1)
                {
                    s = $"{campo}={Valor_Actual.ToString()}";
                }
                else
                {
                    foreach (string sn in lstTipo.SelectedItems)
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

            foreach (String item in lstTipo.SelectedItems)
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
                if (lstRubros.SelectedItems.Count == 1)
                {
                    s = $"(Tipo={herramientas.Codigo_Seleccionado(lstRubros.Text)})";
                }
                else
                {
                    if (lstRubros.SelectedItems.Count > 1)
                    {
                        foreach (string sn in lstRubros.SelectedItems)
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

            lstTipo.Items.Clear();
            dt = Tipos.Datos(s);
            foreach (DataRow dr in dt.Rows)
            {
                lstTipo.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
            }

            if (items.Count > 0)
            {
                for (int n = 0; n < items.Count; n++)
                {
                    for (int i = 0; i < lstTipo.Items.Count; i++)
                    {
                        if (items[n].ToString() == lstTipo.Items[i].ToString())
                        {
                            lstTipo.SetSelected(i, true);
                            break;
                        }
                    }
                }
            }

        }

        public void Siguiente()
        {
            if (lstTipo.Items.Count > 0)
            {
                int i = lstTipo.SelectedIndex;

                if (i == -1)
                {
                    lstTipo.SetSelected(0, true);
                }
                else
                {
                    lstTipo.SetSelected(i, false);
                    if (i == lstTipo.Items.Count - 1)
                    {
                        lstTipo.SetSelected(0, true);
                    }
                    else
                    {
                        lstTipo.SetSelected(i + 1, true);
                    }
                }
            }
        }
        public void Anterior()
        {
            if (lstTipo.Items.Count > 0)
            {
                int i = lstTipo.SelectedIndex;

                if (i == -1)
                {
                    lstTipo.SetSelected(lstTipo.Items.Count - 1, true);
                }
                else
                {
                    lstTipo.SetSelected(i, false);
                    if (i == 0)
                    {
                        lstTipo.SetSelected(lstTipo.Items.Count - 1, true);
                    }
                    else
                    {
                        lstTipo.SetSelected(i - 1, true);
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
                    cmdTodos.PerformClick();
                    break;
                case MouseButtons.Right:
                    cmdInvertir.PerformClick();
                    break;
            }
        }

        private void CmdTodos_Click(object sender, EventArgs e)
        {
            cCancel = true;
            SelectionMode previousMode = lstTipo.SelectionMode;
            lstTipo.SelectionMode = SelectionMode.MultiSimple;

            lstTipo.BeginUpdate();

            for (int i = 0; i < lstTipo.Items.Count; i++)
            {
                lstTipo.SelectedIndices.Add(i);
            }

            lstTipo.EndUpdate();
            lstTipo.SelectionMode = previousMode;
            cCancel = false;
            Cambio_Seleccion(this, e);
        }
        private void CmdInvertir_Click(object sender, EventArgs e)
        {
            cCancel = true;
            SelectionMode previousMode = lstTipo.SelectionMode;
            lstTipo.SelectionMode = SelectionMode.MultiSimple;

            lstTipo.BeginUpdate();

            for (int i = 0; i < lstTipo.Items.Count; i++)
            {
                lstTipo.SetSelected(i, !lstTipo.GetSelected(i));
            }

            lstTipo.EndUpdate();
            lstTipo.SelectionMode = previousMode;
            cCancel = false;
            Cambio_Seleccion(this, e);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void CmdTodosTipos_Click(object sender, EventArgs e)
        {
            lstRubros.SelectedIndex = -1;
        }

     
        private void RdId_CheckedChanged(object sender, EventArgs e)
        {
            Tipos.Ordern_XId = rdId.Checked;
            Cargar();
        }

        private void CmdNinguno_Click(object sender, EventArgs e)
        {
            lstTipo.SelectedIndex = -1;
        }

        
    }
}
