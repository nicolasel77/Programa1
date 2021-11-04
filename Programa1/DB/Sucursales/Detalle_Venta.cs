namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Detalle_Venta : c_Base
    {
        public int Id_Venta { get; set; }
        public string Descripcion { get; set; }
        public Detalle_Venta()
        {
            Tabla = "Detalle_Ventas";
            Vista = "Detalle_Ventas";
            ID_Automatico = true;
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Detalle_Ventas (Id_Venta, Descripcion) " +
                        $"VALUES({Id_Venta}, '{Descripcion}')", sql);
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

        public new void Actualizar()
        {
            Actualizar("Descripcion", Descripcion);
        }

    }
}
