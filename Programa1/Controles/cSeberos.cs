﻿namespace Programa1.Controles
{
    using Programa1.DB;
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class cSeberos : UserControl
    {
        private Seberos Sebero;
        private Herramientas herramientas = new Herramientas();

        private bool cCancel = false;
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

        public string Titulo { get => lblTitulo.Text; set { lblTitulo.Text = value; } }

        public event EventHandler Cambio_Seleccion;

        public cSeberos()
        {
            InitializeComponent();
            Sebero = new Seberos();
            
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
            
            lst.Items.Clear();
            DataTable dt = new DataTable();

            dt = Sebero.Datos();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Items.Add($"{dr["Id"]}. {dr["Nombre"]}");
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


        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            Cargar();
        }


        private void CmdNinguno_Click(object sender, EventArgs e)
        {
            lst.SelectedIndex = -1;
        }
    }
}
