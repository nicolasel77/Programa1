namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Ofertas : c_Base
    {
        public Ofertas()
        {
            Tabla = "Ofertas";
            Vista = "vw_Ofertas";
            ID_Automatico = true;
        }

        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();

        [MaxLength(50, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();
        public Single Costo_Original { get; set; }
        public Single Costo_Oferta { get; set; }
        public Single Kilos { get; set; }

        public Precios_Sucursales precios = new Precios_Sucursales();
        public Lista_Ofertas precios_ofertas = new Lista_Ofertas();

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro, "*,(Kilos_Vendidos-Kilos) AS Diferencia");            
        }

        public new void Actualizar()
        {
                Actualizar("Fecha", Fecha);
                Actualizar("Id_Sucursales", Sucursal.ID);
                Actualizar("ID_Productos", Producto.ID);
                Actualizar("Descripcion", Descripcion);
                Actualizar("Costo_Original", Costo_Original);
                Actualizar("Costo_Oferta", Costo_Oferta);
                Actualizar("Kilos", Kilos);
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Ofertas (Fecha, Id_Sucursales, Id_Productos, Descripcion, Costo_Original, Costo_Oferta, Kilos) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.ID}, {Producto.ID}, '{Descripcion}', {Costo_Original.ToString().Replace(",", ".")}, {Costo_Oferta.ToString().Replace(",", ".")}, {Kilos.ToString().Replace(",", ".")})", sql);
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


        public void Cargar_Fila()
        {
            Cargar_Fila(ID);
        }
        public void Cargar_Fila(int id)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Ofertas WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
                Costo_Original = Convert.ToSingle(dr["Costo_Original"]);
                Costo_Oferta = Convert.ToSingle(dr["Costo_Oferta"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);
            }
            catch (Exception)
            {
                ID = 0;
                Fecha = Convert.ToDateTime("1/1/1");
                Producto.ID = 0;
                Descripcion = "";
                Sucursal.ID = 0;
                Costo_Original = 0;
                Costo_Oferta = 0;
                Kilos = 0;
            }
        }

        public double Buscarkg_Venta()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            double kv;

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT TOP 1 Kilos_Vendidos FROM vw_Ofertas WHERE Id=" + ID, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];
                kv = Convert.ToDouble(dr["Kilos_Vendidos"]);
                

            }
            catch (Exception)
            {
                kv = 0;
            }
            return kv;
        }

    }
}
