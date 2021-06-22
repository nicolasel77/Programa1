namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class GastosSucursales_Tipos : c_Base
    {
        public GastosSucursales_Tipos()
        {
            Tabla = "GastosSucursales_Tipos";
            Vista = "GastosSucursales_Tipos";
        }


        public GastosSucursales_Rubros Rubro { get; set; } = new GastosSucursales_Rubros();

        public bool Ordern_XId { get; set; } = true;

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro, "*", Ordern_XId ? "ID" : "Nombre");
        }

        public new void Actualizar()
        {
            Actualizar("Nombre", Nombre);
            Actualizar("ID_Rubro", Rubro.ID);
        }

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO GastosSucursales_Tipos (Id, Id_Rubro, Nombre) VALUES({ID}, {Rubro.ID}, '{Nombre}')", sql);
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
