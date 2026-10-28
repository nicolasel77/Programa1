namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using UglyToad.PdfPig.Graphics.Operations.SpecialGraphicsState;

    public class Precios_Franquicia : c_Base
    {
        public Precios_Franquicia()
        {
            Tabla = "Precios_Franquicia";
            Vista = "vw_PreciosFranquicia";
        }

        public DateTime Fecha { get; set; }
        public int Producto { get; set; } = 0;
        public int Sucursal { get; set; } = 0;
        public float Precio { get; set; } = 0;

        /// <summary>
        /// Devuelve un dt con un top 100 de las fechas
        /// </summary>
        /// <param name="suc">Ocional para filtrar</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        internal DataTable Fechas_DT(int suc = 0, int tipo = 0)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString))
            {
                string cadena = "SELECT TOP 100 Fecha FROM vw_PreciosFranquicia ";
                string filtro = "";
                if (suc > 0)
                {
                    filtro = $" Id_Sucursales={suc}";
                }
                if (tipo != 0)
                {
                    if (suc > 0)
                    {
                        filtro = $" Id_Sucursales={suc} AND Id_Tipo={tipo}";
                    }
                    else
                    {
                        filtro = $" Id_Tipo={tipo}";
                    }
                }
                if (filtro != "") filtro = " WHERE " + filtro;

                cadena += filtro + " Group by Fecha ORDER BY Fecha DESC";

                // Llenar el dt con los datos de la consulta
                SqlDataAdapter da = new SqlDataAdapter(cadena, conn);
                da.Fill(dt);
            }
            return dt;
        }

        public void Agregar()
        {
            using (SqlConnection conn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString))
            {
                // Primero borrar el precio para esa fecha, producto y sucursal
                string cadena = "DELETE FROM Precios_Franquicia WHERE Fecha=@fecha AND ID_Sucursales=@id_sucursales AND ID_Productos=@id_productos";
                SqlCommand sqlCommand = new SqlCommand(cadena, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@fecha", Fecha);
                sqlCommand.Parameters.AddWithValue("@id_sucursales", Sucursal);
                sqlCommand.Parameters.AddWithValue("@id_productos", Producto);
                sqlCommand.Parameters.AddWithValue("@precio", Precio);

                conn.Open();
                sqlCommand.ExecuteNonQuery();

                cadena = $"INSERT INTO Precios_Franquicia (Fecha, Id_Sucursales, Id_Productos, Precio) " +
                    "VALUES(@fecha, @id_sucursales, @id_productos, @precio)";
                sqlCommand = new SqlCommand(cadena, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@fecha", Fecha);
                sqlCommand.Parameters.AddWithValue("@id_sucursales", Sucursal);
                sqlCommand.Parameters.AddWithValue("@id_productos", Producto);
                sqlCommand.Parameters.AddWithValue("@precio", Precio);

                sqlCommand.ExecuteNonQuery();
                conn.Close();

            }
        }

        internal float Buscar_Precio(Precios_Franquicia precio)
        {
            float pr = 0;

            if (precio != null)
            {
                using (SqlConnection conn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString))
                {
                    string cadena = $"SELECT TOP 1 Precio FROM Precios_Franquicia WHERE Fecha<=@fecha AND Id_Productos=@prod AND Id_Sucursales=@suc ORDER BY Fecha DESC";
                    SqlCommand sqlCommand = new SqlCommand(cadena, conn);
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Parameters.AddWithValue("@fecha", precio.Fecha);
                    sqlCommand.Parameters.AddWithValue("@prod", precio.Producto);
                    sqlCommand.Parameters.AddWithValue("@suc", precio.Sucursal);

                    conn.Open();
                    // Buscar el precio

                    object resultado = sqlCommand.ExecuteScalar();
                    if (resultado != null && float.TryParse(resultado.ToString(), out float precioEncontrado))
                    {
                        pr = precioEncontrado;
                    }

                    conn.Close();

                }
            }
            return pr;
        }

        public DataTable Precios_GranjaListaKilos()
        {
            var dt = new DataTable("Datos");
            SqlConnection conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Precios_GranjaListaKilos ORDER BY ID_Productos", conexionSql);
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
            SqlConnection conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP {top} Fecha, Precio FROM Precios_Franquicia " +
                    $"WHERE ID_Productos=300 " +
                    $"GROUP BY Fecha,Precio ORDER BY Fecha DESC", conexionSql);
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

        public float Buscar()
        {

            SqlConnection conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;

            //Si no hay una sucursal seleccionada se devuelve el primer precio encontrado

            string suc = $"(SELECT TOP 1 Id_Sucursales FROM Precios_Franquicia " +
                         $"WHERE Fecha <= '{Fecha:MM/dd/yyyy}' " +
                         $"AND Id_Productos = {Producto} ORDER BY Fecha DESC)";

            if (Sucursal > 0) { suc = Sucursal.ToString(); }
            try
            {

                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 Precio FROM Precios_Franquicia  WHERE Fecha<='{Fecha:MM/dd/yyy}'" +
                    $" AND Id_Productos={Producto} AND ID_Sucursales={suc} ORDER BY Fecha DESC", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }
            Precio = Convert.ToSingle(d);

            return Precio;
        }

        public DataTable Integraciones_Sucursales(DateTime fecha, int tipo = 1)
        {
            var dt = new DataTable("Datos");
            SqlConnection conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (tipo == 4)
            {
                tipo = 300;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT S.Id, S.Nombre" +
                    $", (SELECT TOP 1 P.Precio FROM Precios_Franquicia P WHERE P.Id_Productos={tipo} AND P.Fecha<='{fecha:MM/dd/yyy}' AND P.Id_Sucursales=S.Id ORDER BY P.Fecha DESC) Integracion" +
                    $", (SELECT TOP 1 P.Fecha  FROM Precios_Franquicia P WHERE P.Id_Productos={tipo} AND P.Fecha<='{fecha:MM/dd/yyy}' AND P.Id_Sucursales=S.Id ORDER BY P.Fecha DESC) Fecha" +
                    $" FROM Sucursales S" +
                    $" WHERE     (Ver = 1) AND (Propio = 1)" +
                    $" ORDER BY Id", conexionSql);
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

        public bool Actualizar_Precios_Franquicia()
        {
            // Primero buscar todas las fechas de precios
            DataTable fechas = new DataTable("fechas");
            DateTime fecha = new DateTime(2026, 8, 22);

            using (SqlConnection conn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString))
            {
                try
                {
                    string cadena = $"SELECT DISTINCT Fecha, ID_Sucursales, ID_Productos, Precio FROM Precios_Franquicia WHERE Fecha>'{fecha:MM/dd/yyyy}' AND Precio<>0" +
                        $" ORDER BY Fecha, ID_Sucursales, ID_Productos";
                    SqlCommand sqlCommand = new SqlCommand(cadena, conn);
                    sqlCommand.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    da.Fill(fechas);

                    conn.Open();
                    sqlCommand.Parameters.Add("@fecha", SqlDbType.DateTime);
                    sqlCommand.Parameters.Add("@id_sucursales", SqlDbType.Int);
                    sqlCommand.Parameters.Add("@id_productos", SqlDbType.Int);
                    sqlCommand.Parameters.Add("@precio", SqlDbType.Float);

                    // Luego por cada fecha, sucursal y producto buscar el precio más reciente y actualizarlo
                    foreach (DataRow dr in fechas.Rows)
                    {
                        sqlCommand.Parameters["@fecha"].Value = Convert.ToDateTime(dr["Fecha"]);
                        sqlCommand.Parameters["@id_sucursales"].Value = Convert.ToInt32(dr["ID_Sucursales"]);
                        sqlCommand.Parameters["@id_productos"].Value = Convert.ToInt32(dr["ID_Productos"]);
                        sqlCommand.Parameters["@precio"].Value = Convert.ToSingle(dr["Precio"]);

                        cadena = "UPDATE VENTAS SET Costo_Franquicia=@precio WHERE Fecha>=@fecha AND ID_Sucursales=@id_sucursales AND ID_Productos=@id_productos";
                        sqlCommand.CommandText = cadena;

                        sqlCommand.ExecuteNonQuery();

                        cadena = "UPDATE Traslados SET Costo_SalidaFR=@precio WHERE Fecha>=@fecha AND Suc_Salida=@id_sucursales AND ID_Productos=@id_productos";
                        sqlCommand.CommandText = cadena;
                        sqlCommand.ExecuteNonQuery();

                        cadena = "UPDATE Traslados SET Costo_EntradaFR=@precio WHERE Fecha>=@fecha AND Suc_Entrada=@id_sucursales AND ID_Productos=@id_productos";
                        sqlCommand.CommandText = cadena;
                        sqlCommand.ExecuteNonQuery();


                        if (dr["ID_Productos"].ToString() == "1")
                        {
                            cadena = "UPDATE Hacienda_Salidas SET Costo_Franquicia=@precio WHERE Fecha>=@fecha AND ID_Sucursales=@id_sucursales";
                            sqlCommand.CommandText = cadena;
                            sqlCommand.ExecuteNonQuery();
                        }

                        cadena = "UPDATE Stock SET Costo_Franquicia=@precio WHERE Fecha>=@fecha AND ID_Sucursales=@id_sucursales AND ID_Productos=@id_productos";
                        sqlCommand.CommandText = cadena;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public float Buscar_Porcentaje()
        {
            using (SqlConnection conn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString))
            {
                string cadena = $"SELECT TOP 1 Porcentaje FROM Porcentajes_Precios WHERE Id_Producto={Producto}";
                SqlCommand sqlCommand = new SqlCommand(cadena, conn);
                sqlCommand.CommandType = CommandType.Text;
                conn.Open();

                // Buscar el porcenaje
                object resultado = sqlCommand.ExecuteScalar();
                if (resultado != null && float.TryParse(resultado.ToString(), out float porcentaje))
                {
                    return porcentaje;
                }
                conn.Close();
            }
            return 0;
        }

        internal void Guardar_Porcentaje(int prod, double porcentaje)
        {
            // Primero borrar el porcentaje para ese producto y luego agregarlo
            using (SqlConnection conn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString))
            {
                string cadena = "DELETE FROM Porcentajes_Precios WHERE Id_Producto=@id_producto";
                SqlCommand sqlCommand = new SqlCommand(cadena, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@id_producto", prod);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                cadena = $"INSERT INTO Porcentajes_Precios (Id_Producto, Porcentaje) VALUES(@id_producto, @porcentaje)";
                sqlCommand = new SqlCommand(cadena, conn);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@id_producto", prod);
                sqlCommand.Parameters.AddWithValue("@porcentaje", porcentaje);
                sqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
