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

        public Precios_Sucursales(int id, DateTime fecha, Productos prod, Sucursales.Sucursales sucursal, float pr)
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
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();
        public Single Precio { get; set; }


        #region " Devolver Datos "
        public Single Buscar()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;

            //Si no hay una sucursal seleccionada se devuelve el primer precio encontrado
            string suc = $"(SELECT TOP 1 Id_Sucursales FROM Precios_Sucursales WHERE Fecha<='{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND Id_Productos={Producto.Id} ORDER BY Fecha DESC)";
            if (Sucursal.Id > 0) { suc = Sucursal.Id.ToString(); }
            try
            {

                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 Precio FROM Precios_Sucursales  WHERE Fecha<='{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND Id_Productos={Producto.Id} AND ID_Sucursales={suc} ORDER BY Fecha DESC", conexionSql);

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

        public DataTable Tabla_Precios(int tipo)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Id, Nombre, 0.0 Precio FROM Productos WHERE Id_Tipo={tipo} AND Ver=1 ORDER BY Id", conexionSql);
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
        public DataTable Precios(byte tipo)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string fecha = $"(SELECT MAX(Fecha) FROM vw_PreciosSucursales WHERE Id_Tipo={tipo})";
                string suc = "";

                if (Fecha != null) { fecha = $"'{Fecha:MM/dd/yy}'"; }
                if (Sucursal.Id != 0) { suc = " AND Id_Sucursales=" + Sucursal.Id; }

                SqlCommand comandoSql = new SqlCommand($"SELECT Id_Productos Id, Descripcion Nombre, Precio FROM vw_PreciosSucursales " +
                    $"WHERE Fecha={fecha} {suc} AND Id_Tipo={tipo} AND Ver=1 ORDER BY Id", conexionSql);
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

        public DataTable Fechas(int tipo, int prod = 0, string filtroSuc = "", int top = 50)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            string filtroProd = "";
            if (prod != 0) { filtroProd = " AND ID_Productos=" + prod; }

            if (filtroSuc != "") { filtroSuc = $" ID_Sucursales IN({filtroSuc}) AND ";  }

            try
            {
                string mostrarPrecio = "";
                if (prod == 1 | prod == 300) { mostrarPrecio = ", Precio"; }

                SqlCommand comandoSql = new SqlCommand($"SELECT TOP {top} Fecha{mostrarPrecio} FROM vw_PreciosSucursales WHERE {filtroSuc}Id_Tipo={tipo} {filtroProd} GROUP BY Fecha{mostrarPrecio} ORDER BY Fecha DESC", conexionSql);
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
        public DataTable Fechas_Granja(int top = 50)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP {top} Fecha, Precio FROM Precios_Sucursales " +
                    $"WHERE ID_Productos=300 " +
                    $"GROUP BY Fecha, Precio ORDER BY Fecha DESC", conexionSql);
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

        public DataTable Precios_CarneListaKilos()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Precios_CarneListaKilos ORDER BY ID_Productos", conexionSql);
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

        public DataTable Precios_Formulas()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Precios_Formulas ORDER BY ID_Productos", conexionSql);
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

        public DataTable Integraciones_Sucursales(DateTime fecha)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"dbo.sp_IntegracionesSucursales '{fecha:MM/dd/yy}'", conexionSql);
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

        public DataTable Integraciones_Sucursales(bool Agrupado)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 50 Fecha, Precio AS Integracion FROM Precios_Sucursales WHERE Id_Productos=1 GROUP BY Fecha, Precio ORDER BY Fecha DESC, Precio ", conexionSql);
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
        #endregion

        #region " Editar Datos "
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
                    new SqlCommand($"DELETE FROM Precios_Sucursales WHERE Fecha='{Fecha:MM/dd/yyy}' AND Id_Sucursales={Sucursal.Id} AND Id_Productos={Producto.Id}", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                command.CommandText = $"INSERT INTO Precios_Sucursales (Fecha, Id_Sucursales, Id_Productos, Precio) " +
                    $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.Id}, {Producto.Id}, {Precio.ToString().Replace(",", ".")} )";

                d = command.ExecuteNonQuery();

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

                Id = 0;

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void Borrar_Lista(int Tipo)
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                //Se pide el tipo para no borrar listas de distinto tipo. Ej: carne/men/emb
                SqlCommand command = new SqlCommand($"DELETE FROM Precios_Sucursales " +
                    $"WHERE ID IN(SELECT ID FROM vw_PreciosSucursales " +
                    $"WHERE ID_Sucursales={Sucursal.Id} AND Fecha='{Fecha:MM/dd/yyyy}' AND Id_Tipo={Tipo})", sql);
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
        #endregion


    }
}
