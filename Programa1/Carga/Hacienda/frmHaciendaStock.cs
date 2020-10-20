namespace Programa1.Carga.Hacienda
{
    using Programa1.DB;
    using System;
    using System.Windows.Forms;

    public partial class frmHaciendaStock : Form
    {
        Faena faena = new Faena();
        public frmHaciendaStock()
        {
            InitializeComponent();
        }

        private void FrmHaciendaStock_Load(object sender, EventArgs e)
        {
            calFecha.MaxDate = DateTime.Today;
        }

        private void Cargar(DateTime f)
        {
            this.Cursor = Cursors.WaitCursor;
            grdStock.MostrarDatos(faena.Stock_Faena(f), true, false);
            grdStock.Grd.SubtotalPosition = C1.Win.C1FlexGrid.SubtotalPositionEnum.BelowData;
            grdStock.CrearArbol(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 4);
            grdStock.CrearArbol(C1.Win.C1FlexGrid.AggregateEnum.Sum, 0, 5);
            
            grdStock.AutosizeAll();

            grdTipo.MostrarDatos(faena.Stock_Tipo(f), true, true);
            grdTipo.Columnas[grdTipo.get_ColIndex("Kilos")].Format = "N0";
            if (grdTipo.Rows > 3)
            {
                grdTipo.SumarCol(1, true);
                grdTipo.SumarCol(2, true);
            }
            else
            {
                grdTipo.Rows = 2;
            }
            
            grdTipo.AutosizeAll();

            grdCategorias.MostrarDatos(faena.Stock_Categorias(f), true, true);
            grdCategorias.Columnas[grdCategorias.get_ColIndex("Kilos")].Format = "N0";
            if (grdCategorias.Rows > 3)
            {
                grdCategorias.SumarCol(1, true);
                grdCategorias.SumarCol(2, true);
            }
            else
            {
                grdCategorias.Rows = 2;
            }

            grdCategorias.AutosizeAll();

            this.Cursor = Cursors.Default;
        }

        private void CalFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            Cargar(calFecha.SelectionEnd.Date);
        }

        

        private void GrdStock_CambioFila(short Fila)
        {
            if (Fila > 0)
            {
                if (!grdStock.Grd.Rows[Fila].IsNode)
                {
                    this.Cursor = Cursors.WaitCursor;
                    faena.nBoleta.NBoleta = Convert.ToInt32(grdStock.get_Texto(Fila, grdStock.get_ColIndex("NBoleta")));
                    string f = $"Nombre_Categoria='{grdStock.get_Texto(Fila, grdStock.get_ColIndex("Cat"))}'" +
                               $" AND Tropa={grdStock.get_Texto(Fila, grdStock.get_ColIndex("Tropa"))}";
                    grdDetalle.MostrarDatos(faena.Stock_DetalleFaena(calFecha.SelectionEnd.Date, f), true, false);
                    grdDetalle.AutosizeAll();
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void cmdMostrar_Click(object sender, EventArgs e)
        {
            Cargar(DateTime.Today.AddMonths(1));
        }
    }
}
