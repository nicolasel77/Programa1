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

                int colTotalE;

                //Entradas
                if (chEDetalle.Checked == true)
                {
                    grdEntradas.MostrarDatos(entradas.Datos_Vista(h.Unir(cFechas1.Cadena(), c), "Fecha, ID_TipoEntrada IDT, Nombre Tipo, ID_SubTipoEntrada IDST, Descripcion, Importe"), true, true);
                    colTotalE = grdEntradas.get_ColIndex("Importe");
                }
                else
                {
                    grdEntradas.MostrarDatos(entradas.TotalPorSubTipo(h.Unir(cFechas1.Cadena(), c)), true, true);
                    colTotalE = grdEntradas.get_ColIndex("Total");
                }

                grdEntradas.SumarCol(colTotalE, true);
                grdEntradas.Columnas[colTotalE].Style.Format = "N2";

                double e = grdEntradas.SumarCol(colTotalE, true);

                grdEntradas.AutosizeAll();

                lblTotal.Text = $"Entradas: {e:C1}";

                //Salidas
                Gastos gastos = new Gastos();

                int colTotalS;

                if (chSDetalle.Checked == true)
                {
                    grdSalidas.MostrarDatos(gastos.Datos_Vista(h.Unir(cFechas1.Cadena(), c), "Fecha, ID_TipoGastos IDT, Desc_Tipo Tipo, ID_SubTipoGastos IDST, Desc_SubTipo SubTipo, ID_DetalleGastos IDD, Descripcion, Importe"), true, true);
                    colTotalS = grdSalidas.get_ColIndex("Importe");
                }
                else
                {
                    grdSalidas.MostrarDatos(gastos.TotalPorSubTipo(h.Unir(cFechas1.Cadena(), c)), true, true);
                    colTotalS = grdSalidas.get_ColIndex("Total");
                }

                grdSalidas.SumarCol(colTotalS, true);
                grdSalidas.Columnas[colTotalS].Style.Format = "N2";

                double g = grdSalidas.SumarCol(colTotalS, true);

                grdSalidas.AutosizeAll();

                lblTotal.Text = $"{lblTotal.Text} Salidas: {g:C1}  Diferencia: {e - g:C1}";

                this.Cursor = Cursors.Default;
            }
        }

        private void lstCajas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void chEDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if(lstCajas.SelectedIndex != -1)
            {
                Cargar_Datos();
            }
        }

        private void chSDetalle_CheckedChanged(object sender, EventArgs e)
        {
            if (lstCajas.SelectedIndex != -1)
            {
                Cargar_Datos();
            }
        }
    }
}
