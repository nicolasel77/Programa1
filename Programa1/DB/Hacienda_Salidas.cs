
namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Hacienda_Salidas
    {        
        public Hacienda_Salidas()
        {
            
        }

        public Hacienda_Salidas(int id, DateTime fecha, Faena faena, Sucursales sucursal, float costo_Salida, float media)
        {
            Id = id;
            Fecha = fecha;
            Faena = faena;
            Sucursal = sucursal;
            Costo_Salida = costo_Salida;
            Media = media;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Faena Faena { get; set; } = new Faena();
        public Sucursales Sucursal { get; set; } = new Sucursales();
        public Single Costo_Salida { get; set; }
        public Single Media { get; set; }


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
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Hacienda_Salidas {filtro} ORDER BY Id", conexionSql);
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
        public DataTable Datos_Salidas(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Id, Fecha, Id_Sucursales, Nombre, Tropa, Nombre_Categoria, Nombre_Producto, " +
                    $"Costo_Carne, Costo_Salida, Media, Kilos AS Original, Total_Compra, Total_Venta FROM vw_Hacienda_Salidas {filtro} ORDER BY Id", conexionSql);
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
                    new SqlCommand($"UPDATE Hacienda_Salidas SET " +
                        $"Fecha='{Fecha.ToString("MM/dd/yyy")}', " +
                        $"Id_Sucursales={Sucursal.Id}, " +
                        $"Id_Faena={Faena.Id}, " +
                        $"Costo_Salida={Costo_Salida.ToString().Replace(",", ".")}, " +
                        $"Media={Media.ToString().Replace(",", ".")} " +
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
                    new SqlCommand($"INSERT INTO Hacienda_Salidas (Id, Fecha, Id_Sucursales, Id_Faena, Costo_Salida, Media) " +
                        $"VALUES({Id}, '{Fecha.ToString("MM/dd/yyy")}', {Sucursal.Id}, {Faena.Id}, {Costo_Salida.ToString().Replace(",", ".")}, {Media.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(Id) FROM Hacienda_Salidas", conexionSql);

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
                SqlCommand command = new SqlCommand("DELETE FROM Hacienda_Salidas WHERE Id=" + Id, sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Hacienda_Salidas WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Id = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Faena.Id = Convert.ToInt32(dr["Id_Faena"]);
                Sucursal.Id = Convert.ToInt32(dr["Id_Sucursales"]);
                Costo_Salida = Convert.ToSingle(dr["Costo_Salida"]);
                Media = Convert.ToSingle(dr["Media"]);

            }
            catch (Exception)
            {
                Id = 0;
            }


        }
    }
}
