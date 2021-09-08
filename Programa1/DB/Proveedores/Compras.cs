namespace Programa1.DB
{
    using Programa1.Clases;
    using Programa1.DB.Varios;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Compras : c_Base
    {
        public Compras()
        {
            Tabla = "Compras";
            Vista = "vw_Compras";
            ID_Automatico = true;
        }


        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();

        [MaxLength(50, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Proveedores.Proveedores Proveedor { get; set; } = new Proveedores.Proveedores();
        public Single Costo { get; set; }
        public int Cantidad { get; set; }
        public Single Kilos { get; set; }

        public Camiones Camion { get; set; } = new Camiones();

        public Precios_Proveedores precios = new Precios_Proveedores();

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro, "Id, Fecha, ID_Camion, Id_Proveedores, Nombre, Id_Productos, Descripcion, Costo, Cantidad, Kilos, Total, Promedio");
        }

        /// <summary>
        /// Muestra los datos agrupados por fecha para CCtes (sin las columnas id, nombre proveedor).
        /// </summary>
        /// <param name="filtro">Nesesario: fecha y proveedor.</param>
        /// <returns></returns>
        public DataTable ResumenFecha_Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                string Cadena = $"SELECT 0 AS ID, Fecha, 0 Id_Productos, '' Descripcion, 0 Costo, SUM(Kilos) Kilos, SUM(Total) Total" +
                    $", ISNULL((SELECT e.ID FROM Estados_Compra e WHERE e.Fecha=vw_Compras.Fecha AND e.Id_Proveedor={Proveedor.Id}), 0) Id_Estado" +
                    $", ISNULL((SELECT e.Estado FROM Estados_Compra e WHERE e.Fecha=vw_Compras.Fecha AND e.Id_Proveedor={Proveedor.Id}), 0) Estado" +
                    $", ISNULL((SELECT e.Observacion FROM Estados_Compra e WHERE e.Fecha=vw_Compras.Fecha AND e.Id_Proveedor={Proveedor.Id}), '') Observacion" +
                    $" FROM vw_Compras {filtro}  GROUP BY Fecha ORDER BY Fecha";

                SqlCommand comandoSql = new SqlCommand(Cadena, conexionSql);
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

        public DateTime Ultima_Fecha()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ISNULL(MAX(Fecha), '1/1/2000') FROM Compras", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = null;
            }
            DateTime f = Convert.ToDateTime(d);
            return f;
        }
        public new void Actualizar()
        {
            Actualizar("Fecha", Fecha);
            Actualizar("ID_Camion", Camion.ID);
            Actualizar("Id_Proveedores", Proveedor.Id);
            Actualizar("ID_Productos", Producto.ID);
            Actualizar("Descripcion", Descripcion);
            Actualizar("Costo", Costo);
            Actualizar("Cantidad", Cantidad);
            Actualizar("Kilos", Kilos);
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Compras (Fecha, Id_Camion, Id_Proveedores, Id_Productos, Descripcion, Costo, Cantidad, Kilos) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Camion.ID}, {Proveedor.Id}, {Producto.ID}, '{Descripcion}', {Costo.ToString().Replace(",", ".")}, {Cantidad}, {Kilos.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Compras WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Camion.ID = Convert.ToInt32(dr["Id_Camion"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Proveedor.Id = Convert.ToInt32(dr["Id_Proveedores"]);
                Costo = Convert.ToSingle(dr["Costo"]);
                Cantidad = Convert.ToInt32(dr["Cantidad"]);
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
                Costo = 0;
                Cantidad = 0;
                Kilos = 0;
            }
        }
    }
}
