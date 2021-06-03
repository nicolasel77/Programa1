namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class NBoletas : c_Base
    {
        public NBoletas()
        {
            Tabla = "NBoletas";
            Vista = "vw_NBoletas";
            Campo_ID = "NBoleta";
        }


        public int NBoleta { get; set; }
        public DateTime Fecha { get; set; }
        public int Reparto { get; set; }
        public Single Costo { get; set; }
        public Single Costo_Faena { get; set; }
        public bool Directo { get; set; }
               
        public new void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command =
                    new SqlCommand($"UPDATE NBoletas SET NBoleta={NBoleta}, Fecha='{Fecha.ToString("MM/dd/yyy")}', Directo={(Directo ? "1" : "0")}, " +
                        $"Reparto={Reparto}, Costo={Costo.ToString().Replace(",", ".")}, Costo_Faena={Costo_Faena.ToString().Replace(",", ".")} " +
                        $"WHERE NBoleta={NBoleta}", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_Boleta();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO NBoletas (NBoleta, Fecha, Reparto, Costo, Costo_Faena, Directo) " +
                        $"VALUES({NBoleta}, '{Fecha.ToString("MM/dd/yyy")}', {Reparto}, {Costo.ToString().Replace(",", ".")}, " +
                        $"{Costo_Faena.ToString().Replace(",", ".")}, {(Directo ? "1" : "0")})", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();

                int n2 = Max_Boleta();
                if (n == n2)
                {
                    NBoleta = 0;
                    MessageBox.Show("No se pudo guardar el registro.", "Error");
                }
                else
                {
                    NBoleta = n2;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public int Max_Boleta()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(NBoleta) FROM NBoletas", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }

            return Convert.ToInt32(d);
        }

        

    }
}
