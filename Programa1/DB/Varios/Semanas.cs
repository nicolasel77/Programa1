namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Semanas : c_Base
    {
        public Semanas()
        {
            Tabla = "Semanas";
            Vista = "Semanas";

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
                    comandoSql.CommandText = $"INSERT INTO Semanas (Semana) VALUES('{d2:MM/dd/yy}')";
                    conexionSql.Open();
                    comandoSql.Connection = conexionSql;
                    comandoSql.ExecuteNonQuery();
                }
            }
            catch (Exception er)
            {
                System.Windows.Forms.MessageBox.Show(er.Message);
            }            
        }
       
        public DateTime Semana { get; set; }
        public bool Guardada { get; set; }
        public bool Cerrada { get; set; }
                
        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro, "*", "Semana DESC");            
        }
        public DataTable Fechas()
        {
            return Datos_Vista("", "TOP 100 Semana", "Semana DESC");            
        }
        public DataTable Años()
        {
            return Datos_Vista("", "DISTINCT DATEPART(YEAR, Semana) Años", "Años DESC");            
        }


    }
}
