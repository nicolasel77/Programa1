using Programa1.DB.Tesoreria;
using System;
using System.Data;
using System.Windows.Forms;


namespace Programa1.Carga.Tesoreria
{
    public partial class frmResumen_Entradas : Form
    {
        enum e_Orden
        {
            Tipo = 0,
            SubTipo = 1,
        }
        private e_Orden Orden;

        int Tipo = 0;
        int SubTipo = 0;


        Entradas Entradas = new Entradas();

        Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmResumen_Entradas()
        {
            InitializeComponent();
        }
        private void frmResumen_Entradas_Load(object sender, EventArgs e)
        {
            DataTable dt = Entradas.TE.grupoE.Datos();
            h.Llenar_List(lstGrupos, dt);
            dt = Entradas.caja.Datos();
            h.Llenar_List(lstCajas, dt);
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Lst();
            Cargar_Grilla();
        }

        private void Cargar_Lst()
        {
            this.Cursor = Cursors.WaitCursor;

            lst.Items.Clear();
            DataTable dt = new DataTable();

            string grupo = h.Codigos_Seleccionados(lstGrupos, "Grupo IN ({0})");
            string cajas = h.Codigos_Seleccionados(lstCajas, "IDC IN ({0}) ");

            grupo = h.Unir(grupo, cajas);
                                   

            switch (Orden)
            {
                case e_Orden.Tipo:
                    dt = Entradas.Tipos_Rango(h.Unir(cFechas1.Cadena(), grupo));
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lst.Items.Add($"{dr[0]}. {dr[1]}");
                        }
                    }
                    lblSubTipo.Text = "";
                    break;
                case e_Orden.SubTipo:
                    if (Tipo > 0)
                    {
                        dt = Entradas.SubTipos_Rango($"{(grupo.Length != 0 ? grupo + " AND " : "")} Id_TipoEntrada={Tipo} AND {cFechas1.Cadena()}");
                    }
                    else
                    {
                        dt = Entradas.SubTipos_Rango(h.Unir(cFechas1.Cadena(), grupo));
                    }
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lst.Items.Add($"{dr[0]}. {dr[1]}");
                        }
                    }
                    break;
            }
            if (lst.Items.Count > 0) { lst.Items.Insert(0, "Todos"); }
            this.Cursor = Cursors.Default;
        }

        private void Cargar_Grilla()
        {
            this.Cursor = Cursors.WaitCursor;

            string grupo = h.Codigos_Seleccionados(lstGrupos, "Grupo IN ({0})");
            string cajas = h.Codigos_Seleccionados(lstCajas, "IDC IN ({0}) ");

            grupo = h.Unir(grupo, cajas);

            switch (Orden)
            {
                case e_Orden.Tipo:
                    string s = h.Unir(cFechas1.Cadena(), grupo);
                    grdEntradas.MostrarDatos(Entradas.TotalPorTipo(s), true, true);
                    grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), true);
                    grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "N2";
                    grdEntradas.AutosizeAll();
                    grdEntradas.set_ColW(grdEntradas.get_ColIndex("Descripcion"), 400);
                    break;
                case e_Orden.SubTipo:
                    if (Tipo > 0)
                    {
                        grdEntradas.MostrarDatos(Entradas.TotalPorSubTipo($"{(grupo.Length != 0 ? grupo + " AND " : "")} Id_TipoEntrada={Tipo} AND {cFechas1.Cadena()}"), true, true);
                    }
                    else
                    {
                        grdEntradas.MostrarDatos(Entradas.TotalPorSubTipo(h.Unir(cFechas1.Cadena(), grupo)), true, true);
                    }
                    grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), true);
                    grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "N2";
                    grdEntradas.AutosizeAll();
                    grdEntradas.set_ColW(grdEntradas.get_ColIndex("Descripcion"), 400);
                    break;
            }
            double g = grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), true);
            lblTotal.Text = $"Total: {g:C1}";
            this.Cursor = Cursors.Default;
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            switch (Orden)
            {
                case e_Orden.Tipo:
                    lblTipo.Text = lst.Text;
                    if (lst.SelectedIndex > 0)
                    {
                        Tipo = h.Codigo_Seleccionado(lblTipo.Text);
                        grdEntradas.MostrarDatos(Entradas.TotalPorSubTipo($"Id_TipoEntrada={Tipo} AND {cFechas1.Cadena()}"), true, true);
                        grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), true);
                        grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "N2";
                        grdEntradas.AutosizeAll();
                        grdEntradas.set_ColW(grdEntradas.get_ColIndex("Descripcion"), 400);
                    }
                    else
                    {
                        Tipo = 0;
                        SubTipo = 0;
                        grdEntradas.MostrarDatos(Entradas.TotalPorTipo(cFechas1.Cadena()), true, true);
                        grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), true);
                        grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "N2";
                        grdEntradas.AutosizeAll();
                        grdEntradas.set_ColW(grdEntradas.get_ColIndex("Descripcion"), 400);
                    }
                    break;
                case e_Orden.SubTipo:
                    lblSubTipo.Text = lst.Text;
                    if (lst.SelectedIndex > 0)
                    {
                        SubTipo = h.Codigo_Seleccionado(lblSubTipo.Text);
                        string s = cFechas1.Cadena();
                        s = h.Unir(s, Tipo > 0 ? $"Id_TipoEntrada={Tipo}" : "");
                        s = h.Unir(s, $"ID_SubTipoEntrada ={SubTipo}");
                        grdEntradas.MostrarDatos(Entradas.TotalPorDetalle(s), true, true);
                        grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), true);
                        grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "N2";
                        grdEntradas.AutosizeAll();
                        grdEntradas.set_ColW(grdEntradas.get_ColIndex("Descripcion"), 400);
                    }
                    else
                    {
                        SubTipo = 0;
                        string s = cFechas1.Cadena();
                        s = h.Unir(s, Tipo > 0 ? $"Id_TipoEntrada={Tipo}" : "");
                        grdEntradas.MostrarDatos(Entradas.TotalPorSubTipo(s), true, true);
                        grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), true);
                        grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "N2";
                        grdEntradas.AutosizeAll();
                        grdEntradas.set_ColW(grdEntradas.get_ColIndex("Descripcion"), 400);
                    }
                    break;
            }
            this.Cursor = Cursors.Default;
        }

        private void cmdgrupoE_Click(object sender, EventArgs e)
        {
            lstGrupos.Visible = !lstGrupos.Visible;
        }

        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cFechas1_Cambio_Seleccion(null, null);
        }

        private void frmResumen_Entradas_KeyDown(object sender, KeyEventArgs e)
        {
            if (lst.Items.Count > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        e.Handled = true;
                        switch (Orden)
                        {
                            case e_Orden.Tipo:
                                if (lst.SelectedIndex > -1)
                                {
                                    Orden = e_Orden.SubTipo;
                                    Cargar_Lst();
                                    Cargar_Grilla();
                                }
                                break;
                        }
                        break;
                    case Keys.Left:
                        e.Handled = true;

                        switch (Orden)
                        {
                            case e_Orden.SubTipo:
                                Orden = e_Orden.Tipo;
                                Cargar_Lst();
                                Cargar_Grilla();
                                // Activar el último seleccionado

                                for (int i = 0; i <= lst.Items.Count - 1; i++)
                                {
                                    if (Orden == e_Orden.SubTipo)
                                    {
                                        if (SubTipo == h.Codigo_Seleccionado(lst.Items[i].ToString()))
                                        {
                                            lst.SelectedIndex = i;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        if (Tipo == h.Codigo_Seleccionado(lst.Items[i].ToString()))
                                        {
                                            lst.SelectedIndex = i;
                                            break;
                                        }
                                    }
                                }
                                break;
                        }
                        break;
                }

            }

        }

    }

}
