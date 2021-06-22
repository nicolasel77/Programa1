namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Cantidad_Clientes : c_Base
    {
        public Cantidad_Clientes()
        {
            Tabla = "Cantidad_Clientes";
            Vista = "vw_CantidadClientes";
            ID_Automatico = true;
        }
               
        public DateTime Fecha { get; set; }
        
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();
        
        public int Cantidad { get; set; }

        
        public new void Actualizar()
        {
            Actualizar("Fecha", Fecha);
            Actualizar("ID_Sucursales", Sucursal.ID);
            Actualizar("Cantidad", Cantidad);                        
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Cantidad_Clientes (Fecha, Id_Sucursales, Cantidad) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.ID}, {Cantidad.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_CantidadClientes WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
                Cantidad = Convert.ToInt32(dr["Cantidad"]);

            }
            catch (Exception)
            {
                ID = 0;
                Fecha = Convert.ToDateTime("1/1/1");
                Sucursal.ID = 0;
                Cantidad = 0;
            }


        }
    }
}
