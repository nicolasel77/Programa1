﻿namespace Programa1.Controles
{
    using Programa1.DB;
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class cSucursales : UserControl
    {
        private Sucursales Sucs;
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
                vFiltroIn = value;
                Cargar();
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


        public event EventHandler Cambio_Seleccion;

        public cSucursales()
        {
            InitializeComponent();

            Sucs = new Sucursales();

            DataTable dt = Sucs.Tipo.Datos();
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
            DataTable dt = new DataTable();
            string s = "";
            string z = "";

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
            if (txtBuscar.TextLength > 0)
            {
                int i;
                bool n = int.TryParse(txtBuscar.Text, out i);
                if (n)
                {
                    z = $"Nombre like '%{i}%' OR Id={i}";
                }
                else
                {
                    z = $"Nombre like '%{txtBuscar.Text}%'";
                }
            }
            if (s.Length > 0)
            {
                if (z.Length > 0)
                {
                    s = $"{s} AND {z}";
                }
            }
            else
            {
                if (z.Length > 0)
                {
                    s = z;
                }
            }
            lst.Items.Clear();

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

            dt = Sucs.Datos(s);
            foreach (DataRow dr in dt.Rows)
            {
                lst.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
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
                    lst.SetSelected(i, false);
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
                    lst.SetSelected(i, false);
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

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void CmdTodosTipos_Click(object sender, EventArgs e)
        {
            lstTipos.SelectedIndex = -1;
        }
    }

}
