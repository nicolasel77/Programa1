namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    /// <summary>
    /// Stock Carne/Pollo por producto: kilos de cada producto con Productos.PedirStock = 1
    /// que carga la sucursal en Sistema-Web (tabla Stock_Diario_Productos, un registro por
    /// fecha + sucursal + producto). Al modificar se recalculan los totales de Stock_Diario
    /// (Pollo = productos 300 a 399, Carne = el resto), igual que hace la API.
    /// </summary>
    public class Stock_Diario_Productos : c_Base
    {
        public Stock_Diario_Productos()
        {
            Tabla = "Stock_Diario_Productos";
            // Vista armada en línea para no depender de una vista en la base
            Vista = "(SELECT S.Id, S.Fecha, S.Id_Sucursales, Su.Nombre, S.Id_Productos, P.Nombre Producto, S.Kilos, S.Modificado " +
                    "FROM Stock_Diario_Productos S LEFT JOIN Sucursales Su ON Su.Id = S.Id_Sucursales " +
                    "LEFT JOIN Productos P ON P.Id = S.Id_Productos) AS vw_StockDiarioProductos";
            ID_Automatico = true;
        }

        private const string RecalcularTotales = @"
            DECLARE @c DECIMAL(10,2), @po DECIMAL(10,2);
            SELECT @c  = ISNULL(SUM(CASE WHEN Id_Productos BETWEEN 300 AND 399 THEN 0 ELSE Kilos END), 0),
                   @po = ISNULL(SUM(CASE WHEN Id_Productos BETWEEN 300 AND 399 THEN Kilos ELSE 0 END), 0)
            FROM Stock_Diario_Productos WHERE Fecha=@f AND Id_Sucursales=@s;
            UPDATE Stock_Diario SET Carne=@c, Pollo=@po, Modificado=GETDATE() WHERE Fecha=@f AND Id_Sucursales=@s;
            IF @@ROWCOUNT = 0
                INSERT INTO Stock_Diario (Fecha, Id_Sucursales, Carne, Pollo) VALUES (@f, @s, @c, @po);";

        /// <summary>
        /// Cambia los kilos de un registro y recalcula los totales del día de esa sucursal.
        /// Devuelve false si no se pudo grabar.
        /// </summary>
        public bool Actualizar_Kilos(int id, decimal kilos)
        {
            var cnn = new SqlConnection(cadCN);
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "DECLARE @f DATE, @s INT; " +
                    "UPDATE Stock_Diario_Productos SET Kilos=@k, Modificado=GETDATE(), @f=Fecha, @s=Id_Sucursales WHERE Id=@id; " +
                    "IF @f IS NOT NULL BEGIN " + RecalcularTotales + " END", cnn);
                cmd.Parameters.Add("@k", SqlDbType.Decimal).Value = kilos;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }
        }

        /// <summary>
        /// Borra un registro y recalcula los totales del día de esa sucursal.
        /// </summary>
        public bool Borrar_Registro(int id)
        {
            var cnn = new SqlConnection(cadCN);
            try
            {
                SqlCommand cmd = new SqlCommand(
                    "DECLARE @f DATE, @s INT; " +
                    "SELECT @f=Fecha, @s=Id_Sucursales FROM Stock_Diario_Productos WHERE Id=@id; " +
                    "DELETE FROM Stock_Diario_Productos WHERE Id=@id; " +
                    "IF @f IS NOT NULL BEGIN " + RecalcularTotales + " END", cnn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }
        }

        /// <summary>
        /// Fecha guardada de un registro (para controlar fechas cerradas).
        /// </summary>
        public DateTime Fecha_Registro(int id)
        {
            var cnn = new SqlConnection(cadCN);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Fecha FROM Stock_Diario_Productos WHERE Id=@id", cnn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cnn.Open();
                object o = cmd.ExecuteScalar();
                cnn.Close();
                return o == null ? DateTime.MinValue : Convert.ToDateTime(o);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }
    }
}
