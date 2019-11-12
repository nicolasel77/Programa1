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
            producto = new Productos();
            suc = new Sucursales();
        }

        public Precios_Sucursales(int id, DateTime fecha, Productos prod, Sucursales sucursal, float pr)
        {
            Id = id;
            Fecha = fecha;
            producto = prod;
            suc = sucursal;
            Precio = pr;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Productos producto { get; set; }
        public Sucursales suc { get; set; }
        public Single Precio { get; set; }

        public Single Buscar()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 Precio FROM Precios_Sucursales  WHERE Fecha<='{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND Id_Productos={producto.Id} AND ID_Sucursales={suc.Id} ORDER BY Fecha DESC", conexionSql);

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
                //string vver = Ver ? "1" : "0";

                //SqlCommand command =
                //    new SqlCommand($"UPDATE Proveedores SET Nombre='{Nombre}', Tipo={Tipo.Id}, Ver={vver} WHERE Id={Id}", sql);
                //command.CommandType = CommandType.Text;
                //command.Connection = sql;
                //sql.Open();

                //var d = command.ExecuteNonQuery();

                //sql.Close();
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
                //string vver = Ver ? "1" : "0";

                //SqlCommand command =
                //    new SqlCommand($"INSERT INTO Proveedores (Id, Nombre, Tipo, Ver) VALUES({Id}, '{Nombre}', {Tipo.Id}, {vver})", sql);
                //command.CommandType = CommandType.Text;
                //command.Connection = sql;
                //sql.Open();

                //var d = command.ExecuteNonQuery();

                //sql.Close();
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
