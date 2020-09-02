namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    class Semanas
    {
        public Semanas()
        {
            DateTime d = DateTime.Today;
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(Semana) FROM Semanas", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DateTime d2 = Convert.ToDateTime(dt.Rows[0][0]);
                if ((d - d2).TotalDays>6)
                {
                    d2 = d2.AddDays(7);
                    comandoSql.CommandText = $"INSERT INTO Semanas (Semana) VALUES('{d2.ToString("MM/dd/yy")}')";
                    conexionSql.Open();
                    comandoSql.Connection = conexionSql;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                dt = null;
            }            
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


        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                if (filtro.Length > 0)
                {
                    filtro = " WHERE " + filtro;
                }
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM Semanas {filtro} ORDER BY Semana DESC", conexionSql);
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
