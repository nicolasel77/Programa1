
namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class CargaSebo
    {        
        public CargaSebo()
        {
            
        }
               

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();
        public Seberos Sebero { get; set; } = new Seberos();
        public Single Costo { get; set; }
        public Single Kilos { get; set; }


        public Precios_Sebo precios_Seberos = new Precios_Sebo();

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
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_CargaSebo {filtro} ORDER BY Id", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                dt = null;
            }

            return dt;
        }

        /// <summary>
        /// Resumen de datos de Sebero. Sirve para análisis y para copiar a compras.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public DataTable Resumen_Compra(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Fecha, Id_Seberos, Nombre_Sebero, Id_Productos, Descripcion, Costo_Compra Costo, SUM(Kilos) Kilos, SUM(Total_Compra) Total  " +
                    $"FROM vw_CargaSebo {filtro} " +
                    $"GROUP BY Fecha, Id_Seberos, Nombre_Sebero, Id_Productos, Descripcion, Costo_Compra " +
                    $"ORDER BY  Fecha, Id_Productos", conexionSql);
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
                    new SqlCommand($"UPDATE CargaSebo SET Fecha='{Fecha.ToString("MM/dd/yyy")}', " +
                        $"Id_Sucursales={Sucursal.ID}, Id_Seberos={Sebero.ID}, Id_Productos={Producto.ID}, " +
                        $"Costo={Costo.ToString().Replace(",", ".")}, Kilos={Kilos.ToString().Replace(",", ".")} " +
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
                    new SqlCommand($"INSERT INTO CargaSebo (Fecha, Id_Sucursales, Id_Seberos, Id_Productos, Costo, Kilos) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.ID}, {Sebero.ID}, {Producto.ID}, {Costo.ToString().Replace(",", ".")}, {Kilos.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT ISNULL(MAX(Id), 0) FROM CargaSebo", conexionSql);

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
                SqlCommand command = new SqlCommand("DELETE FROM CargaSebo WHERE Id=" + Id, sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_CargaSebo WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Id = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
                Sebero.ID = Convert.ToInt32(dr["Id_Seberos"]);
                Costo = Convert.ToSingle(dr["Costo"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);

            }
            catch (Exception)
            {
                Id = 0;
            }


        }
    }
}
