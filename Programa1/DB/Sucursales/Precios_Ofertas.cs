namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Lista_Ofertas
    {
        public Lista_Ofertas()
        {
        }

        public Lista_Ofertas(int orden, Productos prod, string desc, Single pr)
        {
            Orden = orden;
            Producto = prod;
            Descripcion = desc;
            Costo = pr;
        }

        public int Orden { get; set; }
        public Productos Producto { get; set; } = new Productos();
        public string Descripcion { get; set; }

        public Single Costo { get; set; }

        public Single Buscar_Costo()
        {
            try
            {
                var dt = new DataTable("Datos");
                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

                string sel = $"SELECT TOP 1 * FROM vw_PreciosOfertas WHERE Id_Productos={Producto.Id} ORDER BY Orden";
                
                SqlCommand comandoSql = new SqlCommand(sel, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Orden = Convert.ToInt32(dr["Orden"]);
                Producto.Id = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Costo = Convert.ToSingle(dr["Costo"]);


            }
            catch (Exception)
            {
                Orden = 0;
                Costo = 0;
            }
            return Costo;
        }
        public Single Buscar_SiguienteCosto()
        {
            try
            {
                var dt = new DataTable("Datos");
                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

                string sel = $"SELECT TOP 1 * FROM vw_PreciosOfertas WHERE Orden>{Orden} ORDER BY Orden";

                SqlCommand comandoSql = new SqlCommand(sel, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Orden = Convert.ToInt32(dr["Orden"]);
                Producto.Id = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Costo = Convert.ToSingle(dr["Costo"]);


            }
            catch (Exception)
            {
                Orden = 0;
                Costo = 0;
            }
            return Costo;
        }

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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_PreciosOfertas" + filtro, conexionSql);
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
                    new SqlCommand($"UPDATE Precios_Ofertas " +
                    $"SET Orden={Orden}, Id_Productos={Producto.Id}, Descripcion='{Descripcion}', Costo={Costo.ToString().Replace(",", ".")} " +
                    $"WHERE Orden={Orden}", sql);
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

            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Precios_Ofertas (Orden, Id_Productos, Descripcion, Costo) " +
                    $"VALUES({Orden}, {Producto.Id}, '{Descripcion}', {Costo.ToString().Replace(",", ".")} )", sql);
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

        public void Borrar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Precios_Ofertas WHERE Orden=" + Orden, sql);
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
    }
}
