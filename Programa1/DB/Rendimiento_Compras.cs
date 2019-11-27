﻿namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Rendimiento_Compras
    {
        public Rendimiento_Compras()
        {
        }

        public Rendimiento_Compras(int id, DateTime fecha, Productos prod, string desc, Proveedores proveedor, float costo, float kilos)
        {
            Id = id;
            Fecha = fecha;
            Producto = prod;
            Descripcion = desc;
            Proveedor = proveedor;
            Costo = costo;
            Kilos = kilos;

        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();

        [MaxLength(50, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Proveedores Proveedor { get; set; } = new Proveedores();
        public Single Costo { get; set; }
        public Single Kilos { get; set; }

        public Precios_Proveedores precios = new Precios_Proveedores();

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
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_RendimientoCompras {filtro} ORDER BY Id", conexionSql);
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
                    new SqlCommand($"UPDATE Rendimiento_Compras SET Fecha='{Fecha.ToString("MM/dd/yyy")}', " +
                        $"Id_Proveedores={Proveedor.Id}, Id_Productos={Producto.Id}, Descripcion='{Descripcion}', " +
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
                    new SqlCommand($"INSERT INTO Rendimiento_Compras (Fecha, Id_Proveedores, Id_Productos, Descripcion, Costo, Kilos) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Proveedor.Id}, {Producto.Id}, '{Descripcion}', {Costo.ToString().Replace(",", ".")}, {Kilos.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(Id) FROM Rendimiento_Compras", conexionSql);

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
                SqlCommand command = new SqlCommand("DELETE FROM Rendimiento_Compras WHERE Id=" + Id, sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Rendimiento_Compras WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Id = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Producto.Id = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Proveedor.Id = Convert.ToInt32(dr["Id_Proveedores"]);
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
