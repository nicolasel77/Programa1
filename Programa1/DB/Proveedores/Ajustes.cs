namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Ajustes : c_Base
    {
        public Ajustes()
        {
            Tabla = "Ajustes_Proveedor";
            Vista = "vw_Ajustes";
            ID_Automatico = true;
        }

        public DateTime Fecha { get; set; }

        [MaxLength(100, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Proveedores.Proveedores Proveedor { get; set; } = new Proveedores.Proveedores();
        public Double Importe { get; set; }


        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro);            
        }
       
        
        public new void Actualizar()
        {      
            Actualizar("Fecha", Fecha);
            Actualizar("Id_Proveedores", Proveedor.Id);
            Actualizar("Descripcion", Descripcion);
            Actualizar("Importe", Importe);
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(cadCN);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Ajustes_Proveedor (Fecha, Id_Proveedor, Descripcion, Importe) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Proveedor.Id}, '{Descripcion}', {Importe.ToString().Replace(",", ".")})", sql);
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
            var conexionSql = new SqlConnection(cadCN);


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Ajustes WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Descripcion = dr["Descripcion"].ToString();
                Proveedor.Id = Convert.ToInt32(dr["Id_Proveedor"]);
                Importe = Convert.ToSingle(dr["Importe"]);

            }
            catch (Exception)
            {
                ID = 0;
                Fecha = Convert.ToDateTime("1/1/1");
                Proveedor.Id = 0;                
                Descripcion = "";
                Importe = 0;
            }
        }
    }
}
