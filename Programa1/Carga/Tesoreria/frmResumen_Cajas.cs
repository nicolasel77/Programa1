namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Tesoreria;
    using System;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmResumen_Cajas : Form
    {
        Entradas entradas = new Entradas();

        public frmResumen_Cajas()
        {
            InitializeComponent();

            DataTable dt = entradas.caja.Datos();

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            h.Llenar_List(lstCajas, dt);
        }

        private void cFechas1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void Cargar_Datos()
        {
            if (lstCajas.SelectedIndex != -1)
            {
                this.Cursor = Cursors.WaitCursor;
                

                Herramientas.Herramientas h = new Herramientas.Herramientas();

                string c = $"IDC= {h.Codigo_Seleccionado(lstCajas.Text)}";

                //Entradas
                grdEntradas.MostrarDatos(entradas.TotalPorSubTipo(h.Unir(cFechas1.Cadena(), c)), true, true);

                grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), true);
                grdEntradas.Columnas[grdEntradas.get_ColIndex("Total")].Style.Format = "N2";

                double e = grdEntradas.SumarCol(grdEntradas.get_ColIndex("Total"), true);

                grdEntradas.AutosizeAll();
                
                lblTotal.Text = $"Entradas: {e:C1}";

                //Salidas
                Gastos gastos = new Gastos();
                grdSalidas.MostrarDatos(gastos.TotalPorSubTipo(h.Unir(cFechas1.Cadena(), c)), true, true);

                grdSalidas.SumarCol(grdSalidas.get_ColIndex("Total"), true);
                grdSalidas.Columnas[grdSalidas.get_ColIndex("Total")].Style.Format = "N2";

                double g = grdSalidas.SumarCol(grdSalidas.get_ColIndex("Total"), true);

                grdSalidas.AutosizeAll();

                lblTotal.Text = $"{lblTotal.Text} Salidas: {g:C1}  Diferencia: {e-g:C1}";

                this.Cursor = Cursors.Default;
            }
        }

        private void lstCajas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Datos();
        }
    }
}
