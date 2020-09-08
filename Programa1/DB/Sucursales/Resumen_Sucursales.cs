namespace Programa1.DB.Sucursales
{
    using Programa1.DB;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    class Resumen_Sucursales
    {
        public Resumen_Sucursales()
        {
        }

        public DataTable Listado_Balances(DateTime Semana)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Id, Nombre, dbo.f_Balance (Id, '{Semana:MM/dd/yy}', '{Semana.AddDays(6):MM/dd/yy}') AS Balance FROM Sucursales WHERE Ver=1 AND Propio=1 ORDER BY Id", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable Entradas(int Suc, DateTime f1, DateTime f2)
        {
            DataTable dt = new DataTable("Entradas");
            DataSet ds = new DataSet("Datos");


            return dt;
        }
    }
}
