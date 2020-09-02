﻿
namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using Programa1.DB.Proveedores;

    class Devoluciones
    {        
        public Devoluciones()
        {
            
        }

        public Devoluciones(int id, DateTime fecha, Productos prod, string desc, Sucursales sucu, Single Costo_Venta, Proveedores.Proveedores proveedor, Single Costo_Compra, Single kilos)
        {
            Id = id;
            Fecha = fecha;
            Producto = prod;
            Descripcion = desc;
            Sucursal = sucu;
            CostoVenta = Costo_Venta;
            Proveedor = proveedor;
            CostoCompra = Costo_Compra;
            Kilos = kilos;

        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();
        [MaxLength(100, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Sucursales Sucursal { get; set; } = new Sucursales();
        public Single CostoVenta { get; set; }
        public Proveedores.Proveedores Proveedor { get; set; } = new Proveedores.Proveedores();
        public Single CostoCompra { get; set; }
        public Single Kilos { get; set; }


        public Precios_Sucursales precios = new Precios_Sucursales();
        public Precios_Proveedores precios_Proveedores = new Precios_Proveedores();

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
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Devoluciones {filtro} ORDER BY Id", conexionSql);
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

        /// <summary>
        /// Resumen de datos de Proveedor. Sirve para análisis y para copiar a compras.
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
                SqlCommand comandoSql = new SqlCommand($"SELECT Fecha, Id_Proveedores, Nombre_Proveedor, Id_Productos, Descripcion, Costo_Compra Costo, SUM(Kilos) Kilos, SUM(Total_Compra) Total  " +
                    $"FROM vw_Devoluciones {filtro} " +
                    $"GROUP BY Fecha, Id_Proveedores, Nombre_Proveedor, Id_Productos, Descripcion, Costo_Compra " +
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
        /// <summary>
        /// Resumen de datos para copiar a Traslados (Sucucrsal 50).
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public DataTable Resumen_ATraslados(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Fecha, 50 Suc_Salida, 'CAMARA' Nombre_Salida, Id_Sucursales Suc_Entrada, Nombre Nombre_Entrada, Id_Productos, Descripcion, Costo_Compra Costo_Salida, Costo_Venta Costo_Entrada, SUM(Kilos) Kilos" +
                    $", SUM(Total_Compra) Total_Salida, SUM(Total_Venta) Total_Entrada   " +
                    $"FROM vw_Devoluciones {filtro} " +
                    $"GROUP BY Fecha, Id_Sucursales, Nombre, Id_Productos, Descripcion, Costo_Compra, Costo_Venta " +
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
                    new SqlCommand($"UPDATE Devoluciones SET Fecha='{Fecha.ToString("MM/dd/yyy")}', " +
                        $"Id_Sucursales={Sucursal.Id}, Id_Proveedores={Proveedor.Id}, Id_Productos={Producto.Id}, Descripcion='{Descripcion}', " +
                        $"Costo_Venta={CostoVenta.ToString().Replace(",", ".")}, Costo_Compra={CostoCompra.ToString().Replace(",", ".")}, Kilos={Kilos.ToString().Replace(",", ".")} " +
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
                    new SqlCommand($"INSERT INTO Devoluciones (Fecha, Id_Sucursales, Id_Proveedores, Id_Productos, Descripcion, Costo_Venta, Costo_Compra, Kilos) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.Id}, {Proveedor.Id}, {Producto.Id}, '{Descripcion}', {CostoVenta.ToString().Replace(",", ".")}, {CostoCompra.ToString().Replace(",", ".")}, {Kilos.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(Id) FROM Devoluciones", conexionSql);

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
                SqlCommand command = new SqlCommand("DELETE FROM Devoluciones WHERE Id=" + Id, sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Devoluciones WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                Id = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Producto.Id = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Sucursal.Id = Convert.ToInt32(dr["Id_Sucursales"]);
                Proveedor.Id = Convert.ToInt32(dr["Id_Proveedores"]);
                CostoVenta = Convert.ToSingle(dr["Costo_Venta"]);
                CostoCompra = Convert.ToSingle(dr["Costo_Compra"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);

            }
            catch (Exception)
            {
                Id = 0;
            }


        }
    }
}
