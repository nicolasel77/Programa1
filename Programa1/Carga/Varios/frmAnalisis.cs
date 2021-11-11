﻿namespace Programa1.Carga.Varios
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
            //Herramientas.Herramientas h = new Herramientas.Herramientas();
            int colww = 0;
            if (cSuc.Valor_Actual > 0) colww = 40;

            //string filtro = $"Semana<='{cFecha.fecha_Actual:MM/dd/yy}'";
            //string fSuc = cSuc.Cadena("Suc");

            //if (string.IsNullOrEmpty(fSuc))
            //{
            //    filtro = $"SELECT * FROM vw_Analisis WHERE Semana='{cFecha.fecha_Actual:MM/dd/yy}' ORDER BY Suc";
            //    colww = 40;
            //}
            //else
            //{
            //    filtro = h.Unir(filtro, fSuc);

            //    filtro = $"SELECT TOP {nuCant.Value} * FROM vw_Analisis WHERE {filtro} ORDER BY Semana DESC, Suc";
            //}
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

            grd.MostrarDatos(c.sp_Datos("dbo.sp_Analisis", new SqlParameter[] { p1, p2, p3 }), true);

            for (int i = grd.get_ColIndex("Balance"); i <= grd.Cols - 2; i++)
            {
                grd.SumarCol(i, true);
                grd.Columnas[i].Format = "N1";
            }
            grd.AutosizeAll();

            this.Cursor = Cursors.Default;

        }
    }
}
