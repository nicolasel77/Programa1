using Programa1.DB.Tesoreria;
using System;
using System.Data;
using System.Windows.Forms;


namespace Programa1.Carga.Tesoreria
{
    public partial class frmResumen_Gastos : Form
    {
        enum e_Orden
        {
            Caja = 0,
            Tipo = 1,
            SubTipo = 2,
            Detalle = 3
        }
        private e_Orden Orden;

        int Tipo = 0;
        int SubTipo = 0;
        int Detalle = 0;
        readonly Gastos Gastos = new Gastos();
        readonly Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmResumen_Gastos()
        {
            InitializeComponent();
        }
        private void frmResumen_Gastos_Load(object sender, EventArgs e)
        {
            DataTable dt = Gastos.TG.grupoS.Datos();
            h.Llenar_List(lstGrupos, dt);
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_List();
            Cargar_Grilla();
            if (lst.Items.Count > 0) { lst.SelectedIndex = 0; }
        }

        private void Cargar_List()
        {
            this.Cursor = Cursors.WaitCursor;

            lst.Items.Clear();
            DataTable dt = new DataTable();

            string grupo = h.Codigos_Seleccionados(lstGrupos, "Grupo IN ({0})");            

            switch (Orden)
            {
                case e_Orden.Caja:

                    break;
                case e_Orden.Tipo:
                    dt = Gastos.Tipos_Rango(h.Unir(cFechas1.Cadena(), grupo));
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
                        grupo = h.Unir(grupo, cFechas1.Cadena());
                        grupo = h.Unir(grupo, $"Id_TipoGastos={Tipo}");
                        dt = Gastos.SubTipos_Rango(grupo);
                    }
                    else
                    {
                        dt = Gastos.SubTipos_Rango(h.Unir(cFechas1.Cadena(), grupo));
                    }
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            lst.Items.Add($"{dr[0]}. {dr[1]}");
                        }
                    }
                    break;
                case e_Orden.Detalle:
                    if (Tipo > 0)
                    {
                        if (SubTipo > 0)
                        {
                            grupo = h.Unir(grupo, cFechas1.Cadena());
                            grupo = h.Unir(grupo, $"Id_TipoGastos={Tipo}");
                            grupo = h.Unir(grupo, $"ID_SubTipoGastos={SubTipo}");                            
                            dt = Gastos.Detalles_Rango(grupo);
                        }
                        else
                        {
                            grupo = h.Unir(grupo, cFechas1.Cadena());
                            grupo = h.Unir(grupo, $"Id_TipoGastos={Tipo}");
                            dt = Gastos.Detalles_Rango(grupo);
                        }
                    }
                    else
                    {
                        if (SubTipo > 0)
                        {
                            grupo = h.Unir(grupo, cFechas1.Cadena());
                            grupo = h.Unir(grupo, $"ID_SubTipoGastos={SubTipo}");
                            dt = Gastos.Detalles_Rango(grupo);
                        }
                        else
                        {
                            dt = Gastos.Detalles_Rango(h.Unir(cFechas1.Cadena(), grupo));
                        }
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

            switch (Orden)
            {
                case e_Orden.Tipo:
                    string s = h.Unir(cFechas1.Cadena(), grupo);
                    grdGastos.MostrarDatos(Gastos.TotalPorTipo(s), true, true);
                    grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                    grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N1";
                    grdGastos.AutosizeAll();
                    grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    break;
                case e_Orden.SubTipo:
                    grupo = h.Unir(grupo, cFechas1.Cadena());
                    if (Tipo > 0)
                    {
                        grupo = h.Unir(grupo, $"Id_TipoGastos={Tipo}");
                        grdGastos.MostrarDatos(Gastos.TotalPorSubTipo(grupo), true, true);
                    }
                    else
                    {
                        grdGastos.MostrarDatos(Gastos.TotalPorSubTipo(grupo), true, true);
                    }
                    grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                    grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N1";
                    grdGastos.AutosizeAll();
                    grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    break;
                case e_Orden.Detalle:
                    if (Tipo > 0)
                    {
                        if (SubTipo > 0)
                        {
                            if (Detalle > 0)
                            {
                                grupo = h.Unir(grupo, cFechas1.Cadena());
                                grupo = h.Unir(grupo, $"Id_TipoGastos={Tipo}");
                                grupo = h.Unir(grupo, $"ID_SubTipoGastos={SubTipo}");
                                grupo = h.Unir(grupo, $"ID_DetalleGastos={Detalle}");
                            }
                            else
                            {
                                grupo = h.Unir(grupo, cFechas1.Cadena());
                                grupo = h.Unir(grupo, $"Id_TipoGastos={Tipo}");
                                grupo = h.Unir(grupo, $"ID_SubTipoGastos={SubTipo}");
                            }

                        }
                        else
                        {
                            if (Detalle > 0)
                            {
                                grupo = h.Unir(grupo, cFechas1.Cadena());
                                grupo = h.Unir(grupo, $"Id_TipoGastos={Tipo}");
                                grupo = h.Unir(grupo, $"ID_DetalleGastos={Detalle}");                                
                            }
                            else
                            {
                                grupo = h.Unir(grupo, cFechas1.Cadena());
                                grupo = h.Unir(grupo, $"Id_TipoGastos={Tipo}");                                
                            }
                        }
                    }
                    else
                    {
                        if (SubTipo > 0)
                        {
                            if (Detalle > 0)
                            {
                                grupo = h.Unir(grupo, cFechas1.Cadena());
                                grupo = h.Unir(grupo, $"ID_SubTipoGastos={SubTipo}");
                                grupo = h.Unir(grupo, $"ID_DetalleGastos={Detalle}");                                
                            }
                            else
                            {
                                grupo = h.Unir(grupo, cFechas1.Cadena());
                                grupo = h.Unir(grupo, $"ID_SubTipoGastos={SubTipo}");                                
                            }

                        }
                        else
                        {
                            if (Detalle > 0)
                            {
                                grupo = h.Unir(grupo, cFechas1.Cadena());
                                grupo = h.Unir(grupo, $"ID_DetalleGastos={Detalle}");                                
                            }                            
                        }
                    }
                    grdGastos.MostrarDatos(Gastos.TotalPorDetalle(grupo), true, true);
                    grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N1";
                    grdGastos.AutosizeAll();
                    grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    break;
            }
            Totales();
            Cursor = Cursors.Default;
        }

        private void Totales()
        {
            double g = grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
            lblTotal.Text = $"Total: {g:C1}";
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string grupo = h.Codigos_Seleccionados(lstGrupos, "Grupo IN ({0})");
            grupo  = h.Unir(grupo, cFechas1.Cadena());

            switch (Orden)
            {
                case e_Orden.Tipo:
                    lblTipo.Text = lst.Text;
                    if (lst.SelectedIndex > 0)
                    {
                        Tipo = h.Codigo_Seleccionado(lblTipo.Text);
                        grupo = h.Unir($"Id_TipoGastos={Tipo}", grupo);
                        grdGastos.MostrarDatos(Gastos.TotalPorSubTipo(grupo), true, true);
                        grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                        grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                        grdGastos.AutosizeAll();
                        grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    }
                    else
                    {
                        Tipo = 0;
                        SubTipo = 0;
                        Detalle = 0;
                        grdGastos.MostrarDatos(Gastos.TotalPorTipo(grupo), true, true);

                        grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                        grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                        grdGastos.AutosizeAll();
                        grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    }
                    break;
                case e_Orden.SubTipo:
                    lblSubTipo.Text = lst.Text;
                    if (lst.SelectedIndex > 0)
                    {
                        SubTipo = h.Codigo_Seleccionado(lblSubTipo.Text);
                        if (Tipo != 0) { grupo = h.Unir($"Id_TipoGastos={Tipo}", grupo); }
                        grupo = h.Unir($"Id_SubTipoGastos={SubTipo}", grupo);

                        grdGastos.MostrarDatos(Gastos.TotalPorDetalle(grupo), true, true);
                        grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                        grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                        grdGastos.AutosizeAll();
                        grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    }
                    else
                    {
                        SubTipo = 0;
                        if (Tipo != 0) { grupo = h.Unir($"Id_TipoGastos={Tipo}", grupo); }

                        grdGastos.MostrarDatos(Gastos.TotalPorSubTipo(grupo), true, true);
                        grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                        grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                        grdGastos.AutosizeAll();
                        grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    }
                    break;
                case e_Orden.Detalle:
                    if (lst.SelectedIndex > 0)
                    {
                        Detalle = h.Codigo_Seleccionado(lst.Text);
                        grupo = h.Unir($"Id_TipoGastos={Tipo}", grupo);
                        grupo = h.Unir($"ID_DetalleGastos={ Detalle }", grupo);
                        
                        if (SubTipo > 0) { grupo = h.Unir($"Id_SubTipoGastos={SubTipo}", grupo); }


                        grdGastos.MostrarDatos(Gastos.TotalPorDetalle(grupo, true), true, true);

                        grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                        grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                        grdGastos.AutosizeAll();
                        grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    }
                    else
                    {
                        Detalle = 0;
                        if (Tipo != 0) { grupo = h.Unir($"Id_TipoGastos={Tipo}", grupo); }
                        
                        if (SubTipo > 0) { grupo = h.Unir($"Id_SubTipoGastos={SubTipo}", grupo); }

                        grdGastos.MostrarDatos(Gastos.TotalPorDetalle(grupo, true), true, true);

                        grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                        grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                        grdGastos.AutosizeAll();
                        grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    }
                    break;
            }
            Totales();
            this.Cursor = Cursors.Default;
        }

        private void cmdGrupos_Click(object sender, EventArgs e)
        {
            lstGrupos.Visible = !lstGrupos.Visible;
        }

        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cFechas1.Cadena() != "")
            {
                Cargar_List();
                Cargar_Grilla(); 
            }
        }

        private void frmResumen_Gastos_KeyDown(object sender, KeyEventArgs e)
        {
            if (lst.Items.Count > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        e.Handled = true;
                        if (lst.SelectedIndex > -1)
                        {
                            switch (Orden)
                            {
                                case e_Orden.Tipo:
                                    Orden = e_Orden.SubTipo;
                                    Cargar_List();
                                    Cargar_Grilla();
                                    break;
                                case e_Orden.SubTipo:
                                    Orden = e_Orden.Detalle;
                                    Cargar_List();
                                    Cargar_Grilla();
                                    break;

                            }
                        }
                        break;

                    case Keys.Left:
                        e.Handled = true;
                        switch (Orden)
                        {
                            case e_Orden.Detalle:
                                Orden = e_Orden.SubTipo;
                                Cargar_List();
                                Cargar_Grilla();
                                break;
                            case e_Orden.SubTipo:
                                Orden = e_Orden.Tipo;
                                Cargar_List();
                                Cargar_Grilla();
                                break;

                        }
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
            }
        }

    }
}
