namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Reintegros : c_Base
    {


        public Reintegros()
        {
            Tabla = "Reintegros";
            Vista = "vw_Reintegros";
            ID_Automatico = true;
        }

              
        public DateTime Fecha { get; set; }
        public TipoReintegros Tipo { get; set; } = new TipoReintegros();
        [MaxLength(80, ErrorMessage = "La {0} no puede ser mayor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();
        public double Importe { get; set; }

        public new DataTable Datos(string filtro = "")
        {
            
            return Datos_Vista(filtro);
        }

        public new void Actualizar()
        {
            Actualizar("Fecha", Fecha);
            Actualizar("ID_Sucursales", Sucursal.ID);
            Actualizar("ID_Tipo", Tipo.ID);
            Actualizar("Descripcion", Descripcion);
            Actualizar("Importe", Importe);                        
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            int n = Max_ID();
            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Reintegros (Fecha, Id_Sucursales, Id_Tipo, Descripcion, Importe) " +
                        $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Sucursal.ID}, {Tipo.ID}, '{Descripcion}', {Importe.ToString().Replace(",", ".")})", sql);
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Reintegros WHERE Id=" + id, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                DataRow dr = dt.Rows[0];

                ID = id;
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Tipo.ID = Convert.ToInt32(dr["Id_Tipo"]);
                Descripcion = dr["Descripcion"].ToString();
                Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
                Importe = Convert.ToDouble(dr["Importe"]);

            }
            catch (Exception)
            {
                ID = 0;
                Fecha = Convert.ToDateTime("1/1/1");
                Tipo.ID = 0;
                Descripcion = "";
                Sucursal.ID = 0;
                Importe = 0;
            }


        }
    }
}
