namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class APicada
    {
        public APicada()
        {
        }

        public APicada(int id, DateTime fecha, Sucursales.Sucursales sucursal, Productos proda, Productos prods, float costoa, float costos, float kilosa, float kiloss)
        {
            Id = id;
            Fecha = fecha;
            Sucursal = sucursal;
            Producto_A = proda;
            Producto_S = prods;
            Kilos_A = kilosa;
            Kilos_S = kiloss;
            Costo_A = costoa;
            Costo_S = costos;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();

        public Productos Producto_A { get; set; } = new Productos();
        public Productos Producto_S { get; set; } = new Productos();

        public Single Kilos_A { get; set; }
        public Single Kilos_S { get; set; }

        public Single Costo_A { get; set; }
        public Single Costo_S { get; set; }

        public Precios_Sucursales precios = new Precios_Sucursales();

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
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_APicada {filtro} ORDER BY Id", conexionSql);
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
                    new SqlCommand($"UPDATE APicada SET Fecha='{Fecha.ToString("MM/dd/yyy")}', " +
                        $"Id_Sucursales={Sucursal.Id}, Id_Productos_A={Producto_A.Id}, Id_Productos_S={Producto_S.Id}, " +
                        $"Costo_A={Costo_A.ToString().Replace(",", ".")}, Costo_S={Costo_S.ToString().Replace(",", ".")}," +
                        $"Kilos_A={Kilos_A.ToString().Replace(",", ".")}, Kilos_S={Kilos_S.ToString().Replace(",", ".")} " +
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
                    new SqlCommand($"INSERT INTO APicada (Fecha, Id_Sucursales, Id_Productos_A, Id_Productos_S, Costo_A, Costo_S, Kilos_A, Kilos_S) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.Id}, {Producto_A.Id}, {Producto_S.Id}, {Costo_A.ToString().Replace(",", ".")}, {Costo_S.ToString().Replace(",", ".")}, " +
                        $"{Kilos_A.ToString().Replace(",", ".")}, {Kilos_S.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT ISNULL(MAX(Id), 0) FROM APicada", conexionSql);

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
                SqlCommand command = new SqlCommand("DELETE FROM APicada WHERE Id=" + Id, sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                Id = 0;

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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_APicada WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Id = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Sucursal.Id = Convert.ToInt32(dr["Id_Sucursales"]);
                Producto_A.Id = Convert.ToInt32(dr["Id_Productos_A"]);
                Costo_A = Convert.ToSingle(dr["Costo_A"]);
                Kilos_A = Convert.ToSingle(dr["Kilos_A"]);
                Producto_S.Id = Convert.ToInt32(dr["Id_Productos_S"]);
                Costo_S = Convert.ToSingle(dr["Costo_S"]);
                Kilos_S = Convert.ToSingle(dr["Kilos_S"]);
            }
            catch (Exception)
            {
                Id = 0;
            }


        }
    }
}
