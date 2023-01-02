namespace Programa1.Carga.Varios
{
    using Programa1.Clases;
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class frmAnalisis_Venta : Form
    {
        public frmAnalisis_Venta()
        {
            InitializeComponent();
        }

        private void Analisis_Venta_Load(object sender, EventArgs e)
        {
            Semanas sem = new Semanas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstSemanas, sem.Fechas(), "dd/MM/yyy");
        }

        private void lstSemanas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void cSucs_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Datos();
        }

        private void cProds_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar_Datos();
        }


        void Cargar_Datos()
        {
            c_Base _Base = new c_Base();

            if (rdProductos.Checked == true)
            {
                if (cSucs.Valor_Actual > 0)
                {
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "SUC";
                    p1.Value = cSucs.Valor_Actual;

                    if (lstSemanas.SelectedIndex != -1)
                    {
                        SqlParameter p2 = new SqlParameter();
                        p2.ParameterName = "SEM";
                        p2.Value = DateTime.Parse(lstSemanas.Text);

                        DataTable dt = _Base.sp_Datos("dbo.sp_Analisis_VentasSuc", new SqlParameter[] { p1, p2 });
                        
                        dt.Columns.Add("Venta", typeof(double), "Stock_Ant+TR_Ent+Entrada-TR_Sal-Stock");
                        dt.Columns.Add("Diferencia", typeof(double), "Oferta-Venta");

                        grd.MostrarDatos(dt, true, false);
                        grd.Columnas[grd.get_ColIndex("Venta")].Move(grd.Cols - 3);

                        grd.FixCols = 3;
                        for (int i = 3; i < grd.Cols; i++)
                        {
                            grd.Columnas[i].Format = "N1";                            
                        }
                        grd.AutosizeAll();
                    }

                }
            }
            else
            {
                if (cProds.Valor_Actual > 0)
                {
                    SqlParameter p1 = new SqlParameter();
                    p1.ParameterName = "PROD";
                    p1.Value = cProds.Valor_Actual;

                    if (lstSemanas.SelectedIndex != -1)
                    {
                        SqlParameter p2 = new SqlParameter();
                        p2.ParameterName = "SEM";
                        p2.Value = DateTime.Parse(lstSemanas.Text);

                        DataTable dt = _Base.sp_Datos("dbo.sp_Analisis_VentasProd", new SqlParameter[] { p1, p2 });

                        dt.Columns.Add("Venta", typeof(double), "Stock_Ant+TR_Ent+Entrada-TR_Sal-Stock");
                        dt.Columns.Add("Diferencia", typeof(double), "Oferta-Venta");

                        grd.MostrarDatos(dt, true, false);
                        grd.Columnas[grd.get_ColIndex("Venta")].Move(grd.Cols - 3);

                        grd.FixCols = 2;
                        for (int i = 3; i < grd.Cols; i++)
                        {
                            grd.Columnas[i].Format = "N1";                            
                        }
                        grd.AutosizeAll();
                    }

                }
            }
        }


    }
}
