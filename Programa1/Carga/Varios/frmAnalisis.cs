namespace Programa1.Carga.Varios
{
    using Programa1.Clases;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public partial class frmAnalisis : Form
    {
        public frmAnalisis()
        {
            InitializeComponent();

        }

        private void cFechas1_Cambio_Seleccion(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            c_Base c = new c_Base();            

            SqlParameter p1 = new SqlParameter();
            p1.ParameterName = "Suc";
            if (cSuc.Valor_Actual <= 0)
            { 
                p1.Value = 0; 
            }
            else
            {
                p1.Value = cSuc.Valor_Actual;
            }

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "F1";
            p2.Value = cFecha.fecha_Actual;

            SqlParameter p3 = new SqlParameter();
            p3.ParameterName = "Cant";
            p3.Value = nuCant.Value;

            SqlParameter p4 = new SqlParameter();
            p4.ParameterName = "Agrupar";
            p4.Value = chAgrupar.Checked;

            grd.MostrarDatos(c.sp_Datos("dbo.sp_Analisis", new SqlParameter[] { p1, p2, p3, p4 }), true);

            for (int i = grd.get_ColIndex("Balance"); i <= grd.Cols - 1; i++)
            {
                grd.SumarCol(i, true);
                grd.Columnas[i].Format = "N1";
            }
            grd.AutosizeAll();

            double total = c.Dato_Sumado("vw_Gastos", $"Fecha between '{cFecha.fecha_Actual:MM/dd/yy}'  and '{cFecha.fecha_Fin:MM/dd/yy}' and ID_TipoGastos IN (2, 3, 4, 8, 14, 15, 28, 32, 35)", "Importe");
            lblGastoEmpresa.Text = $"Gastos Empresa: {total.ToString("C2")}";
            this.Cursor = Cursors.Default;

        }

        private void lblGastoEmpresa_Click(object sender, System.EventArgs e)
        {

        }
    }
}
