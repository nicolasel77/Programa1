
namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Traslados : c_Base
    {
        public Traslados()
        {
            Tabla = "Traslados";
            Vista = "vw_Traslados";
            ID_Automatico = true;
        }

        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();

        [MaxLength(100, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Sucursales.Sucursales sucS { get; set; } = new Sucursales.Sucursales();
        public float CostoS { get; set; }
        public Sucursales.Sucursales sucE { get; set; } = new Sucursales.Sucursales();
        public float CostoE { get; set; }
        public int Cantidad { get; set; }
        public Single Kilos { get; set; }

        public Precios_Sucursales precios = new Precios_Sucursales();

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro);
        }

        public new void Actualizar()
        {
            Actualizar("Fecha", Fecha);
            Actualizar("Suc_Salida", sucS.ID);
            Actualizar("Suc_Entrada", sucE.ID);
            Actualizar("ID_Productos", Producto.ID);
            Actualizar("Descripcion", Descripcion);
            Actualizar("Costo_Salida", CostoS);
            Actualizar("Costo_Entrada", CostoE);
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
                    new SqlCommand($"INSERT INTO Traslados (Fecha, Suc_Salida, Suc_Entrada, Id_Productos, Descripcion, Costo_Salida, Costo_Entrada, Cantidad, Kilos) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {sucS.ID}, {sucE.ID}, {Producto.ID}, '{Descripcion}', {CostoS.ToString().Replace(",", ".")}, {CostoE.ToString().Replace(",", ".")}, {Cantidad}, {Kilos.ToString().Replace(",", ".")})", sql);
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

        public int Producto_Siguiente()
        {
            Producto.Siguiente(" ver = 1 ");
            return Producto.ID;
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

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Producto.ID = Convert.ToInt32(dr["Id_Productos"]);
                Descripcion = dr["Descripcion"].ToString();
                sucS.ID = Convert.ToInt32(dr["Suc_Salida"]);
                sucE.ID = Convert.ToInt32(dr["Suc_Entrada"]);
                CostoS = Convert.ToSingle(dr["Costo_Salida"]);
                CostoE = Convert.ToSingle(dr["Costo_Entrada"]);
                Cantidad = Convert.ToInt32(dr["Cantidad"]);
                Kilos = Convert.ToSingle(dr["Kilos"]);

            }
            catch (Exception)
            {
                ID = 0;
                Fecha = Convert.ToDateTime("1/1/1");
                Producto.ID = 0;
                Descripcion = "";
                sucS.ID = 0;
                sucE.ID = 0;
                CostoS = 0;
                CostoE = 0;
                Cantidad = 0;
                Kilos = 0;
            }
        }
    }
}
