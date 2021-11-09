
namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Precios_Sebo
    {
        public Precios_Sebo()
        {
        }
       
        public DateTime Fecha { get; set; }
        public Productos Producto { get; set; } = new Productos();
        public Proveedores.Proveedores Proveedor { get; set; } = new Proveedores.Proveedores();
        public float Precio { get; set; }
               
        public float Buscar()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 Precio FROM Precios_Seberos WHERE Fecha<='{Fecha:MM/dd/yyy}'" +
                    $" AND ID_Productos={Producto.ID} AND Id_Seberos={Proveedor.Id} ORDER BY Fecha DESC", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = null;
            }
            Precio = Convert.ToSingle(d);
            return Precio;
        }

        
    }
}
