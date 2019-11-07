namespace Programa1.Carga
{
    using Programa1.DB;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class frmCMStock : Form
    {
        private List<int> Id;
        private Stock stock = new Stock();

        public frmCMStock()
        {
            InitializeComponent();
        }

        public List<int> Ids
        {
            set
            {
                Id = value;
                Cargar();
            }
                
        }

        private void Cargar()
        {
            string s = string.Join(",", Id);
            grdOriginal.MostrarDatos(stock.Datos($" Id IN ({s})"), true, false);
            grdResultado.Rows = 0;
            formato_Grilla();
            Totales();

        }
        private void formato_Grilla()
        {
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id"), 0);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Fecha"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Sucursales"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Nombre"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Id_Productos"), 30);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Descripcion"), 100);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Costo"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Kilos"), 60);
            grdOriginal.set_ColW(grdOriginal.get_ColIndex("Total"), 80);

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Costo")].Format = "C2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Format = "N2";
            grdOriginal.Columnas[grdOriginal.get_ColIndex("Total")].Format = "C2";

            grdOriginal.Columnas[grdOriginal.get_ColIndex("Kilos")].Style.Font = new System.Drawing.Font("Arial", 8, System.Drawing.FontStyle.Bold);

            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Sucursales"), "Suc");
            grdOriginal.set_Texto(0, grdOriginal.get_ColIndex("Id_Productos"), "Prod");
        }

        private void Totales()
        {
            double t = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Total"), false);
            double k = grdOriginal.SumarCol(grdOriginal.get_ColIndex("Kilos"), false);
            int c = grdOriginal.Rows - 1;
            
            lblTotalO.Text = $"Registros: {c} Kilos: {k:N2} Total: {t:C2}";

            t = grdResultado.SumarCol(grdResultado.get_ColIndex("Total"), false);
            k = grdResultado.SumarCol(grdResultado.get_ColIndex("Kilos"), false);
            c = grdResultado.Rows - 1;

            if (c > 0)
            {
                lblTotalR.Text = $"Registros: {c} Kilos: {k:N2} Total: {t:C2}";
            }
            else { lblTotalR.Text = ""; }
        }
    }    
}
