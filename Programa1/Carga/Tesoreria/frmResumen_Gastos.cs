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
            Tipo = 0,
            SubTipo = 1,
            Detalle = 2
        }
        private e_Orden Orden;

        int Tipo = 0;
        int SubTipo = 0;
        int Detalle = 0;


        Gastos Gastos = new Gastos();

        Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmResumen_Gastos()
        {
            InitializeComponent();
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_List();

            Cargar_Grilla();
        }

        private void Cargar_List()
        {
            this.Cursor = Cursors.WaitCursor;
            lst.Items.Clear();
            DataTable dt = new DataTable();
            switch (Orden)
            {
                case e_Orden.Tipo:
                    dt = Gastos.Tipos_Rango(cFechas1.Cadena());
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
                        dt = Gastos.SubTipos_Rango($"Id_TipoGastos={Tipo} AND {cFechas1.Cadena()}");
                    }
                    else
                    {
                        dt = Gastos.SubTipos_Rango(cFechas1.Cadena());
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
                            dt = Gastos.Detalles_Rango($"Id_TipoGastos={Tipo} AND Id_SubTipoGastos={SubTipo} AND {cFechas1.Cadena()}");
                        }
                        else
                        {
                            dt = Gastos.Detalles_Rango($"Id_TipoGastos={Tipo} AND {cFechas1.Cadena()}");
                        }                        
                    }
                    else
                    {
                        if (SubTipo > 0)
                        {
                            dt = Gastos.Detalles_Rango($"Id_SubTipoGastos={SubTipo} AND {cFechas1.Cadena()}");
                        }
                        else
                        {
                            dt = Gastos.Detalles_Rango(cFechas1.Cadena());
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
            switch (Orden)
            {
                case e_Orden.Tipo:
                    grdGastos.MostrarDatos(Gastos.TotalPorTipo(cFechas1.Cadena()), true, true);
                    grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                    grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                    grdGastos.AutosizeAll();
                    grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    break;
                case e_Orden.SubTipo:
                    if (Tipo > 0)
                    {
                        grdGastos.MostrarDatos(Gastos.TotalPorSubTipo($"Id_TipoGastos={Tipo} AND {cFechas1.Cadena()}"), true, true);
                    }
                    else
                    {
                        grdGastos.MostrarDatos(Gastos.TotalPorSubTipo(cFechas1.Cadena()), true, true);
                    }
                    grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                    grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                    grdGastos.AutosizeAll();
                    grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    break;
                case e_Orden.Detalle:
                    string cadena = cFechas1.Cadena();

                    if (Tipo > 0)
                    {
                        if (SubTipo > 0)
                        {
                            if (Detalle > 0)
                            {
                                cadena = $"Id_TipoGastos={Tipo} AND ID_SubTipoGastos={SubTipo} AND ID_DetalleGastos={Detalle} AND {cFechas1.Cadena()}";
                            }
                            else
                            {
                                cadena = $"Id_TipoGastos={Tipo} AND ID_SubTipoGastos={SubTipo} AND {cFechas1.Cadena()}";
                            }
                            
                        }
                        else
                        {
                            if (Detalle > 0)
                            {
                                cadena = $"Id_TipoGastos={Tipo} AND ID_DetalleGastos={Detalle} AND {cFechas1.Cadena()}";
                            }
                            else
                            {
                                cadena = $"Id_TipoGastos={Tipo} AND {cFechas1.Cadena()}";
                            }
                        }
                    }
                    else
                    {
                        if (SubTipo > 0)
                        {
                            if (Detalle > 0)
                            {
                                cadena = $"ID_SubTipoGastos={SubTipo} AND ID_DetalleGastos={Detalle} AND {cFechas1.Cadena()}";
                            }
                            else
                            {
                                cadena = $"ID_SubTipoGastos={SubTipo} AND {cFechas1.Cadena()}";
                            }

                        }
                        else
                        {
                            if (Detalle > 0)
                            {
                                cadena = $"ID_DetalleGastos={Detalle} AND {cFechas1.Cadena()}";
                            }
                            else
                            {
                                cadena = cFechas1.Cadena();
                            }
                        }
                    }
                    grdGastos.MostrarDatos(Gastos.TotalPorDetalle(cadena), true, true);
                    grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                    grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                    grdGastos.AutosizeAll();
                    grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    break;
            }
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
                        grdGastos.MostrarDatos(Gastos.TotalPorSubTipo($"Id_TipoGastos={Tipo} AND {cFechas1.Cadena()}"), true, true);
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
                        grdGastos.MostrarDatos(Gastos.TotalPorTipo(cFechas1.Cadena()), true, true);
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
                        grdGastos.MostrarDatos(Gastos.TotalPorDetalle($"Id_TipoGastos={Tipo} AND ID_SubTipoGastos={SubTipo} AND {cFechas1.Cadena()}"), true, true);
                        grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                        grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                        grdGastos.AutosizeAll();
                        grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    }
                    else
                    {
                        SubTipo = 0;
                        grdGastos.MostrarDatos(Gastos.TotalPorSubTipo($"Id_TipoGastos={Tipo} AND {cFechas1.Cadena()}"), true, true);
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

                        string cadena = $"Id_TipoGastos={ Tipo} AND ID_DetalleGastos={ Detalle } AND {cFechas1.Cadena()} ";
                        
                        if (SubTipo > 0) { cadena = $"Id_TipoGastos={ Tipo} AND ID_SubTipoGastos={ SubTipo } AND ID_DetalleGastos={ Detalle } AND {cFechas1.Cadena()} "; }

                        
                        grdGastos.MostrarDatos(Gastos.TotalPorDetalle(cadena, true), true, true);
                        grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                        grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                        grdGastos.AutosizeAll();
                        grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    }
                    else
                    {
                        Detalle = 0;

                        string cadena = $"Id_TipoGastos={Tipo} AND {cFechas1.Cadena()}";

                        if (SubTipo > 0) { cadena = $"Id_TipoGastos={ Tipo} AND ID_SubTipoGastos={ SubTipo } AND {cFechas1.Cadena()} "; }
                                                
                        grdGastos.MostrarDatos(Gastos.TotalPorDetalle(cadena,true), true, true);
                        grdGastos.SumarCol(grdGastos.get_ColIndex("Total"), true);
                        grdGastos.Columnas[grdGastos.get_ColIndex("Total")].Style.Format = "N2";
                        grdGastos.AutosizeAll();
                        grdGastos.set_ColW(grdGastos.get_ColIndex("Descripcion"), 400);
                    }
                    break;
            }
            this.Cursor = Cursors.Default;
        }

        private void lst_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
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
                    break;
                case Keys.Left:
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
