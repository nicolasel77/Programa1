
namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Traslados
    {


        public Traslados()
        {
        }

        public Traslados(int id, DateTime fecha, Productos prod, string desc, Sucursales suc_Salida, float costo_Salida, Sucursales suc_Entrada, float costo_Entrada, float kilos)
        {
            Id = id;
            Fecha = fecha;
            Producto = prod;
            Descripcion = desc;
            sucS = suc_Salida;
            CostoS = costo_Salida;
            sucE = suc_Entrada;
            CostoE = costo_Entrada;
            Kilos = kilos;

        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();

        [MaxLength(100, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Sucursales sucS { get; set; } = new Sucursales();
        public float CostoS { get; set; }
        public Sucursales sucE { get; set; } = new Sucursales();
        public float CostoE { get; set; }
        public Single Kilos { get; set; }

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
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Traslados {filtro} ORDER BY Id", conexionSql);
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
                    new SqlCommand($"UPDATE Traslados SET Fecha='{Fecha.ToString("MM/dd/yyy")}', " +
                        $"Suc_Salida={sucS.Id}, Suc_Entrada={sucE.Id}, Id_Productos={Producto.Id}, Descripcion='{Descripcion}', " +
                        $"Costo_Salida={CostoS.ToString().Replace(",", ".")}, Costo_Entrada={CostoE.ToString().Replace(",", ".")}, Kilos={Kilos.ToString().Replace(",", ".")} " +
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
                    new SqlCommand($"INSERT INTO Traslados (Fecha, Suc_Salida, Suc_Entrada, Id_Productos, Descripcion, Costo_Salida, Costo_Entrada, Kilos) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {sucS.Id}, {sucE.Id}, {Producto.Id}, '{Descripcion}', {CostoS.ToString().Replace(",", ".")}, {CostoE.ToString().Replace(",", ".")}, {Kilos.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(Id) FROM Traslados", conexionSql);

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
                SqlCommand command = new SqlCommand("DELETE FROM Traslados WHERE Id=" + Id, sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Traslados WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Id = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Producto.Id = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                sucS.Id = Convert.ToInt32(dr["Suc_Salida"]);
                sucE.Id = Convert.ToInt32(dr["Suc_Entrada"]);
                CostoS = Convert.ToSingle(dr["Costo_Salida"]);
                CostoS = Convert.ToSingle(dr["Costo_Entrada"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);

            }
            catch (Exception)
            {
                Id = 0;
            }


        }
    }
}
