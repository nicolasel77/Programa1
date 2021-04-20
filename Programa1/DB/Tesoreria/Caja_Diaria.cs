namespace Programa1.DB.Tesoreria
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Caja_Diaria
    {
        private Cajas Cajas = new Cajas();

        public Caja_Diaria()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            string s = "SELECT ISNULL(Fecha, '1/1/1900') FROM CD_Fecha";

            SqlCommand command = new SqlCommand(s, sql);
            command.CommandType = CommandType.Text;
            sql.Open();
            command.Connection = sql;

            var d = command.ExecuteScalar();
            DateTime f, f2;
            if (string.IsNullOrEmpty(Convert.ToString(d))) { d = "1/1/1900"; }

            if (DateTime.TryParse(d.ToString(), out f) == true)
            {
                if (f.Year > 2000)
                { Fecha = f; }
                else
                {
                    command.CommandText = "SELECT MAX(Fecha) FROM CD_Entradas"; 
                    d = command.ExecuteScalar();
                    if (DateTime.TryParse(d.ToString(), out f) == true) { Fecha = f; }

                    command.CommandText = "SELECT MAX(Fecha) FROM CD_Gastos";
                    d = command.ExecuteScalar();
                    if (DateTime.TryParse(d.ToString(), out f2) == true)
                    {
                        if (f2 > f) { Fecha = f2; }
                    }
                }
            }

        }

        public DateTime Fecha { get; set; }

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"DELETE FROM CD_Fecha", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                command.CommandText = $"INSERT INTO CD_Fecha (Fecha) VALUES('{Fecha:MM/dd/yy}')";
                d = command.ExecuteNonQuery();

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public DataTable Saldos(DateTime fecha)
        {
            return Cajas.Saldos(fecha);
        }
        public DataTable Saldos_ARendir(DateTime fecha)
        {
            return Cajas.nombre_ARendir.Saldos(fecha);
        }

        public DataTable Datos()
        {
            return Cajas.Datos();
        }
    }
}
