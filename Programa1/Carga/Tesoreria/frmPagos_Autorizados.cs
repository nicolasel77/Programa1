namespace Programa1.Carga.Tesoreria
{
    using Programa1.DB.Varios;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    public partial class frmPagos_Autorizados : Form
    {
        C1.Win.C1FlexGrid.CellStyle e_prov;
        C1.Win.C1FlexGrid.CellStyle e_Hacienda;
        C1.Win.C1FlexGrid.CellStyle e_HaciendaError;

        Herramientas.Herramientas h = new Herramientas.Herramientas();

        public frmPagos_Autorizados()
        {
            InitializeComponent();
        }

        Pagos_Autorizados Pagos = new Pagos_Autorizados();

        private void frmPagos_Autorizados_Load(object sender, EventArgs e)
        {
            e_prov = grdAutorizados.Styles.Add("Prov");
            e_Hacienda = grdAutorizados.Styles.Add("p1hac");
            e_HaciendaError = grdAutorizados.Styles.Add("p2hac");

            e_prov.BackColor = Color.LightBlue;
            e_Hacienda.BackColor = Color.LightCyan;
            e_HaciendaError.BackColor = Color.LightCoral;
                        
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            Cargar();
        }
        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                h.Ejecutar_Macro("Pagos_Autorizados", "Cargar", Pagos.filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.Cursor = Cursors.Default;
        }


        private void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;

            //Filtros**********
            Pagos.f_ID = -1;

            Pagos.filtro = h.Codigos_Seleccionados(lstFiltros, "ID IN({0})"); ;

            if (lstFiltros.SelectedItems.Count == 1) { Pagos.f_ID = h.Codigo_Seleccionado(lstFiltros.Text); }

            //Datos
            grdAutorizados.MostrarDatos(Pagos.Datos(), true);
            grdAutorizados.SumarCol(grdAutorizados.get_ColIndex("Saldo"), true);
            Formato_Grlla();


            //Pintar
            for (int i = 1; i < grdAutorizados.Rows - 1; i++)
            {
                short vId = Convert.ToInt16(grdAutorizados.get_Texto(i, 0));
                short vCorroborar = Convert.ToInt16(grdAutorizados.get_Texto(i, grdAutorizados.get_ColIndex("Corroborar")));

                if (vId == 0) { grdAutorizados.Filas[i].Style = e_prov; }

                if (vId == 1 | vId == 2)
                {
                    if (vCorroborar == 1) { grdAutorizados.Filas[i].Style = e_Hacienda; }
                }
                else 
                { 
                    if (vCorroborar == 2) { grdAutorizados.Filas[i].Style = e_HaciendaError; } 
                }
            }

            this.Cursor = Cursors.Default;

        }

        private void Formato_Grlla()
        {
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("ID"), 0);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Origen"), 80);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Fecha"), 55);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Plazo"), 30);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Venc"), 55);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Dias"), 30);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("ID_N"), 30);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Nombre"), 60);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Cant"), 40);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Descripcion"), 100);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Kilos"), 60);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Costo"), 40);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Total"), 80);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Pagos"), 80);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Saldo"), 90);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Observacion"), 200);
            grdAutorizados.set_ColW(grdAutorizados.get_ColIndex("Corroborar"), 0);

            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Kilos")].Style.Format = "N1";
            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Costo")].Style.Format = "N1";
            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Total")].Style.Format = "N1";
            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Pagos")].Style.Format = "N1";
            grdAutorizados.Columnas[grdAutorizados.get_ColIndex("Saldo")].Style.Format = "N1";
        }

        
    }
}
