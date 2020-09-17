namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class NBoletas
    {
        public NBoletas()
        {

        }

        public NBoletas(int nboleta, DateTime fecha, int reparto, float costo, float costo_f, bool direct)
        {
            NBoleta = nboleta;
            Fecha = fecha;
            Reparto = reparto;
            Costo = costo;
            Costo_Faena = costo_f;
            Directo = direct;

        }

        public int NBoleta { get; set; }
        public DateTime Fecha { get; set; }
        public int Reparto { get; set; }
        public Single Costo { get; set; }
        public Single Costo_Faena { get; set; }
        public bool Directo { get; set; }

        public DataTable Datos(string filtro = "", string top = " TOP 100", string orden = "DESC")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) filtro = " WHERE " + filtro;
            
            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT {top} * FROM vw_NBoletas {filtro} ORDER BY NBoleta {orden}", conexionSql);
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

        public void Actualizar()
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

        public void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = MaxId();
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

                int n2 = MaxId();
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

        public int MaxId()
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

        public void Borrar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM NBoletas WHERE NBoleta=" + NBoleta, sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                NBoleta = 0;

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        
    }
}
