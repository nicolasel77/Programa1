namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Stock : c_Base
    {
        public Stock()
        {
            Tabla = "Stock";
            Vista = "vw_Stock";
            ID_Automatico = true;
        }


        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();
        [MaxLength(50, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();
        public Single Costo { get; set; }
        public Single Kilos { get; set; }

        public Precios_Sucursales precios = new Precios_Sucursales();

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro);
        }

        public Double Stock_Kilos(string filtro)
        {
            object d = Dato_Sumado(filtro, "Kilos");
            if (d == DBNull.Value) { d = 0; }
            return Convert.ToDouble(d);
        }
        public Double Stock_Carne(string filtro)
        {
            object d = Dato_Sumado(filtro + " AND ID_Tipo=1", "Kilos");
            if (d == DBNull.Value) { d = 0; }
            return Convert.ToDouble(d);
        }
        public DataTable Stock_CarneSucs(string filtro)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_Sucursales, Nombre, SUM(Kilos) Kilos FROM vw_Stock WHERE {filtro}  AND ID_Tipo=1 GROUP BY ID_Sucursales, Nombre ORDER BY ID_Sucursales", conexionSql);
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
            Actualizar("ID_Productos", Producto.ID);
            Actualizar("Descripcion", Descripcion);
            Actualizar("Costo", Costo);
            Actualizar("Kilos", Kilos);
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Stock (Fecha, Id_Sucursales, Id_Productos, Descripcion, Costo, Kilos) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.ID}, {Producto.ID}, '{Descripcion}', {Costo.ToString().Replace(",", ".")}, {Kilos.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Stock WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
                Costo = Convert.ToSingle(dr["Costo"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);

            }
            catch (Exception)
            {
                ID = 0;
                Fecha = Convert.ToDateTime("1/1/1");
                Producto.ID = 0;
                Descripcion = "";
                Sucursal.ID = 0;
                Costo = 0;
                Kilos = 0;
            }
        }
    }
}
