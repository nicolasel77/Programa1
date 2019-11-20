namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Precios_Ofertas
    {
        public Precios_Ofertas()
        {
            Producto = new Productos();
            Sucursal = new Sucursales();
        }

        public Precios_Ofertas(int id, DateTime fecha, Productos prod, Sucursales sucursal, float pr)
        {
            Id = id;
            Fecha = fecha;
            Producto = prod;
            Sucursal = sucursal;
            Costo_Original = pr;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; }
        public Sucursales Sucursal { get; set; }
        public Single Costo_Original { get; set; }
        public Single Costo_Oferta { get; set; }

        public Single Buscar()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 Costo_Oferta FROM Precios_Ofertas  WHERE Fecha<='{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND Id_Productos={Producto.Id} AND ID_Sucursal={Sucursal.Id} ORDER BY Fecha DESC", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = null;
            }
            Costo_Oferta = Convert.ToSingle(d);
            return Costo_Oferta;
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
                    $"SET Fecha='{Fecha.ToString("MM/dd/yyy")}', Id_Sucursales={Sucursal.Id}, Id_Productos={Producto.Id}, " +
                    $"Costo_Original={Costo_Original.ToString().Replace(",", ".")}, Costo_Oferta={Costo_Oferta.ToString().Replace(",", ".")} " +
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
                    new SqlCommand($"INSERT INTO Precios_Ofertas (Fecha, Id_Sucursales, Id_Productos, Costo_Original, Costo_Oferta) " +
                    $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.Id}, {Producto.Id}, {Costo_Original.ToString().Replace(",", ".")} )", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM Precios_Ofertas WHERE Id=" + Id, sql);
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
