namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    class Semanas
    {
        public Semanas()
        {

        }
        public Semanas(DateTime sem, bool guardada, bool cerrada)
        {
            Semana = sem;
            Guardada = guardada;
            Cerrada = cerrada;
        }
        public DateTime Semana { get; set; }
        public bool Guardada { get; set; }
        public bool Cerrada { get; set; }


        public DataTable Datos()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Semanas ORDER BY Semana DESC", conexionSql);
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
        public DataTable Años()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT DISTINCT DATEPART(YEAR, Semana) Años FROM Semanas ORDER BY Años DESC", conexionSql);
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

    }
}
