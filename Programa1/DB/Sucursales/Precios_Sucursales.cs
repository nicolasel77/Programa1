namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Precios_Sucursales
    {
        public Precios_Sucursales()
        {
        }

        public Precios_Sucursales(int id, DateTime fecha, Productos prod, Sucursales sucursal, float pr)
        {
            Id = id;
            Fecha = fecha;
            Producto = prod;
            Sucursal = sucursal;
            Precio = pr;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();
        public Sucursales Sucursal { get; set; } = new Sucursales();
        public Single Precio { get; set; }

        public Single Buscar()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 Precio FROM Precios_Sucursales  WHERE Fecha<='{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND Id_Productos={Producto.Id} AND ID_Sucursales={Sucursal.Id} ORDER BY Fecha DESC", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = null;
            }
            Precio = Convert.ToSingle(d);
            return Precio;
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_PreciosSucursales" + filtro, conexionSql);
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

        public DataTable Tabla_Men()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
                      
            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT Id, Nombre, 0.0 Precio FROM Productos WHERE Id_Tipo=2 AND Ver=1 ORDER BY Id" , conexionSql);
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

        public DataTable Fechas_Men()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT Fecha FROM vw_PreciosSucursales WHERE Id_Tipo=2 GROUP BY Fecha ORDER BY Fecha DESC", conexionSql);
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
                    new SqlCommand($"UPDATE Precios_Sucursales " +
                    $"SET Fecha='{Fecha.ToString("MM/dd/yyy")}', Id_Sucursales={Sucursal.Id}, Id_Productos={Producto.Id}, Precio={Precio.ToString().Replace(",", ".")} " +
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

            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Precio_Sucursales (Fecha, Id_Sucursales, Id_Productos, Precio) " +
                    $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.Id}, {Producto.Id}, {Precio.ToString().Replace(",", ".")} )", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM Precios_Sucursales WHERE Id=" + Id, sql);
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
