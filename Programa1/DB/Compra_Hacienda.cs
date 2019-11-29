namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Compra_Hacienda
    {

        public Compra_Hacienda()
        {
        }

        public Compra_Hacienda(int id, NBoletas nBoleta, Consignatarios consignatario, Productos producto, int cabezas, float kilos, float costo, float iVA, byte plazo)
        {
            Id = id;
            NBoleta = nBoleta;
            Consignatario = consignatario;
            Producto = producto;
            Cabezas = cabezas;
            Kilos = kilos;
            Costo = costo;
            IVA = iVA;
            Plazo = plazo;
        }

        public int Id { get; set; }
        public NBoletas NBoleta { get; set; }
        public Consignatarios Consignatario { get; set; }
        public Productos Producto { get; set; }
        public int Cabezas { get; set; }
        public Single Kilos { get; set; }
        public Single Costo { get; set; }
        public Single IVA { get; set; }
        public Byte Plazo { get; set; }

        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_CompraHacienda {filtro} ORDER BY Id", conexionSql);
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
                    new SqlCommand($"UPDATE Hacienda_Compras SET NBoleta={NBoleta.NBoleta}, Id_Consignatarios={Consignatario.Id}, Id_Productos={Producto.Id}, " +
                        $"Cabezas={Cabezas}, Kilos={Kilos.ToString().Replace(",", ".")}, Costo={Costo.ToString().Replace(",", ".")}, IVA={IVA.ToString().Replace(",", ".")}, Plazo={Plazo} " +    
                        $"WHERE Id={Id}", sql);
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
                    new SqlCommand($"INSERT INTO Hacienda_Compras (NBoleta, Id_Consignatarios, Id_Productos, Cabezas, Kilos, Costo, IVA, Plazo) " +
                        $"VALUES({NBoleta.NBoleta},{Consignatario.Id},{Producto.Id},{Cabezas},{Kilos.ToString().Replace(",", ".")},{Costo.ToString().Replace(",", ".")},{IVA.ToString().Replace(",", ".")},{Plazo})", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();

                int n2 = MaxId();
                if (n == n2)
                {
                    Id = 0;
                    MessageBox.Show("No se pudo guardar el registro.", "Error");
                }
                else
                {
                    Id = n2;
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
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(Id) FROM Hacienda_Compras", conexionSql);

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
                SqlCommand command = new SqlCommand("DELETE FROM Hacienda_Compras WHERE Id=" + Id, sql);
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

        public void Cargar_Fila(int id)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_CompraHacienda WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Id = id;
                NBoleta.NBoleta = Convert.ToInt32(dr["NBoleta"]);
                Consignatario.Id = Convert.ToInt32(dr["Id_Consignatarios"]);
                Producto.Id = Convert.ToInt32(dr["Id_Productos"]);
                Cabezas = Convert.ToInt32(dr["Cabezas"]);
                Costo = Convert.ToSingle(dr["Costo"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);
                IVA = Convert.ToSingle(dr["IVA"]);
                Plazo = Convert.ToInt32(dr["Plazo"]);
            }
            catch (Exception)
            {
                Id = 0;
            }


        }
    }
}
