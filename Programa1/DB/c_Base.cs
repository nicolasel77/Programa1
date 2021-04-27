namespace Kiosko.Clases
{
    using System;
    using System.Data;
    using System.Data.Odbc;
    using System.Windows.Forms;

    public class c_Base
    {
        public string Tabla { get; set; }
        public int ID { get; set; }
        public string Nombre { get; set; }


        #region " Editar Datos "
        public void Actualizar()
        {
            var cnn = new OdbcConnection(Kiosko.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                OdbcCommand command = new OdbcCommand(string.Format("UPDATE {2} SET Nombre='{0}' WHERE Id={1}", Nombre, ID, Tabla), cnn);
                command.CommandType = CommandType.Text;
                command.Connection = cnn;
                cnn.Open();

                var d = command.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void Agregar()
        {
            var cnn = new OdbcConnection(Kiosko.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                OdbcCommand cmd = new OdbcCommand($"INSERT INTO {Tabla} (Id, Nombre) VALUES({ID}, '{Nombre}')", cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();

                var d = cmd.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void Borrar()
        {
            var cnn = new OdbcConnection(Kiosko.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                OdbcCommand cmd = new OdbcCommand(string.Format("DELETE FROM {1} WHERE Id={0}", ID, Tabla), cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();

                var d = cmd.ExecuteNonQuery();

                ID = 0;

                cnn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        #endregion


        #region " Devolver Datos "
        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var cnn = new OdbcConnection(Kiosko.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                string Cadena = $"SELECT Id, Nombre FROM {Tabla} {filtro} ORDER BY Id";

                OdbcCommand cmd = new OdbcCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                OdbcDataAdapter daAdapt = new OdbcDataAdapter(cmd);
                daAdapt.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public bool Existe()
        {

            OdbcConnection cnn = new OdbcConnection(Kiosko.Properties.Settings.Default.dbDatosConnectionString);
            var dt = new DataTable("Datos");

            try
            {
                OdbcCommand cmd = new OdbcCommand($"SELECT * FROM {Tabla} WHERE Id={ID}", cnn);
                cmd.CommandType = CommandType.Text;

                OdbcDataAdapter daAdapt = new OdbcDataAdapter(cmd);
                daAdapt.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    Nombre = "";
                    return false;
                }
                else
                {
                    Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }

        } 
        #endregion
    }
}
