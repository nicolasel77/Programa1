using System;
using System.Data;
using System.Data.SqlClient;

namespace Programa1.DB.Varios
{
    class Datos_Genericos
    {
        public Datos_Genericos()
        {
        }

        public DataTable Datos(String cadena)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand(cadena, conexionSql);
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

        public void Ejecutalee(string cadena)
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand(cadena, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                conexionSql.Open();
                comandoSql.ExecuteNonQuery();
            }
            catch (Exception)
            {
                
            }
        }
    }
}
