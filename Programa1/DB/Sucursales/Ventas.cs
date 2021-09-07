
namespace Programa1.DB
{
    using Programa1.Clases;
    using Programa1.DB.Varios;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class  Ventas : c_Base
    {
        public Ventas()
        {
            Tabla = "Ventas";
            Vista = "vw_Ventas";
            ID_Automatico = true;
        }


        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();
        [MaxLength(100, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();
        public int Cantidad { get; set; }
        public Single CostoVenta { get; set; }
        public Proveedores.Proveedores Proveedor { get; set; } = new Proveedores.Proveedores();
        public Single CostoCompra { get; set; }
        public Single Kilos { get; set; }
        public Camiones Camion { get; set; } = new Camiones();

        public Precios_Sucursales precios = new Precios_Sucursales();
        public Precios_Proveedores precios_Proveedores = new Precios_Proveedores();

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro, "ID, Fecha, ID_Camion, ID_Proveedores, Nombre_Proveedor, ID_Sucursales, Nombre, ID_Productos, Descripcion, Costo_Compra, Costo_Venta, Cantidad, Kilos, Total_Compra, Total_Venta, Promedio");
        }

        /// <summary>
        /// Resumen de datos de Proveedor. Sirve para análisis y para copiar a compras.
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public DataTable Resumen_Compra(string filtro = "", Boolean Agrupar = true)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            string GroupBy = "";
            string Camposuma = ", Kilos, Total_compra Total";
            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }
            if (Agrupar == true)
            {
                Camposuma = ", SUM(Kilos) Kilos, SUM(Total_Compra) Total ";
                GroupBy = " GROUP BY Fecha, ID_Camion, Id_Proveedores, Nombre_Proveedor, Id_Productos, Descripcion, Costo_Compra ";
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Fecha, ID_Camion, Id_Proveedores, Nombre_Proveedor, Id_Productos, Descripcion, Costo_Compra Costo{Camposuma}  " +
                    $"FROM vw_Ventas {filtro} " +
                    GroupBy +
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
        public DataTable Resumen_ATraslados(string filtro = "", Boolean Agrupar = true)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            string GroupBy = "";
            string Camposuma = ", Kilos, Total_Compra Total_Salida, Total_Venta Total_Entrada ";

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }
            if (Agrupar == true)
            {
                Camposuma = ", SUM(Kilos) Kilos , SUM(Total_Compra) Total_Salida, SUM(Total_Venta) Total_Entrada ";
                GroupBy = " GROUP BY Fecha, Id_Sucursales, Nombre, Id_Productos, Descripcion, Costo_Compra, Costo_Venta ";
            }
            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Fecha, 50 Suc_Salida, 'CAMARA' Nombre_Salida, Id_Sucursales Suc_Entrada, Nombre Nombre_Entrada, Id_Productos, Descripcion, Costo_Compra Costo_Salida, Costo_Venta Costo_Entrada" +
                    Camposuma +
                    $"FROM vw_Ventas {filtro} " +
                    GroupBy +
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

        public new void Actualizar()
        {
            Actualizar("Fecha", Fecha);
            Actualizar("ID_Sucursales", Sucursal.ID);
            Actualizar("ID_Camion", Camion.ID);
            Actualizar("Id_Proveedores", Proveedor.Id);
            Actualizar("ID_Productos", Producto.ID);
            Actualizar("Descripcion", Descripcion);
            Actualizar("Cantidad", Cantidad);
            Actualizar("Costo_Compra", CostoCompra);
            Actualizar("Costo_Venta", CostoVenta);
            Actualizar("Kilos", Kilos);
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO  Ventas (Fecha, Id_Sucursales, ID_Camion, Id_Proveedores, Id_Productos, Descripcion, Cantidad, Costo_Venta, Costo_Compra, Kilos) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.ID}, {Camion.ID}, {Proveedor.Id}, {Producto.ID}, '{Descripcion}', {Cantidad}, {CostoVenta.ToString().Replace(",", ".")}, {CostoCompra.ToString().Replace(",", ".")}, {Kilos.ToString().Replace(",", ".")})", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();

                int n2 = Max_ID();
                if (n == n2)
                {
                    ID = 0;
                    MessageBox.Show("No se pudo guardar el registro.", "Error");
                }
                else
                {
                    ID = n2;
                }
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Ventas WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Camion.ID = Convert.ToInt32(dr["Id_Camion"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
                Proveedor.Id = Convert.ToInt32(dr["Id_Proveedores"]);
                Cantidad = Convert.ToInt32(dr["Cantidad"]);
                CostoVenta = Convert.ToSingle(dr["Costo_Venta"]);
                CostoCompra = Convert.ToSingle(dr["Costo_Compra"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);

            }
            catch (Exception)
            {
                ID = 0;
                Fecha = Convert.ToDateTime("1/1/1");
                Camion.ID = 0;
                Proveedor.Id = 0;
                Producto.ID = 0;
                Descripcion = "";
                Sucursal.ID = 0;
                Cantidad = 0;
                CostoCompra = 0;
                CostoVenta = 0;
                Kilos = 0;
            }
        }

    }
}
