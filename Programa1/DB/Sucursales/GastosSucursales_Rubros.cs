namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class GastosSucursales_Rubros : c_Base
    {
        public GastosSucursales_Rubros()
        {
            Tabla = "GastosSucursales_Rubros";
            Vista = "GastosSucursales_Rubros";
            Grupo = new GastosSucursales_Grupos();
        }

        public GastosSucursales_Grupos Grupo { get; set; }


        public  new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro);            
        }

        public new void Actualizar()
        {
            Actualizar("Nombre", Nombre);
            Actualizar("ID_Grupo", Grupo.ID);            
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO GastosSucursales_Rubros (Id, Id_Grupo, Nombre) VALUES({ID}, {Grupo.ID}, '{Nombre}')", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        
    }
}
