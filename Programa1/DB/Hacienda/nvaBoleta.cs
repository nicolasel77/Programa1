namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    public class nvaBoleta : c_Base
    {
        public nvaBoleta()
        {
            Tabla = "NBoletas";
            Vista = "vw_NBoletas";
            Campo_ID = "NBoleta";
        }
        public int Boleta { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public int Cab { get; set; }
        public string Descr { get; set; }
        public double Importe { get; set; }

        public void Limpiar_Tabla()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                SqlCommand command =
                    new SqlCommand($"DELETE FROM nvaBoleta_Temp", sql);

                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();
            }
            catch (Exception e)
            {
            }
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO nvaBoleta_Temp (Boleta, Fecha, Nombre, Importe, Cab, Descr) VALUES ({Boleta}, '{Fecha.ToString("MM/dd/yyy")}', '{Nombre}', {Importe.ToString().Replace(",", ".")}, {Cab}, '{Descr}')", sql);

                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();

                //int n2 = Max_Boleta();
                //if (n == n2)
                //{
                //    ID = 0;
                //    MessageBox.Show("No se pudo guardar el registro.", "Error");
                //}
                //else
                //{
                //    ID = n2;
                //}
            }
            catch (Exception e)
            {
            }
        }

    }
}
