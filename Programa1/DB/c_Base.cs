namespace Programa1.Clases
{
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class c_Base
    {
        public string Tabla { get; set; }
        public string Vista { get; set; }

        public int ID { get; set; }
        public string Nombre { get; set; }


        #region " Editar Datos "
        public void Actualizar()
        {
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("UPDATE {2} SET Nombre='{0}' WHERE Id={1}", Nombre, ID, Tabla), cnn);
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
        public void Actualizar(string Campo, object valor)
        {
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Herramientas h = new Herramientas();
            valor = h.Formato_SQL(valor);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("UPDATE {0} SET {1}={2} WHERE Id={3}", Tabla, Campo, valor, ID), cnn);
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
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO {Tabla} (Id, Nombre) VALUES({ID}, '{Nombre}')", cnn);
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
        /// <summary>
        /// Agrega el registro sumando un campo. Ej: SubTipo 
        /// </summary>
        /// <param name="Campo">El nombre del Campo que se agrega a Id y Nombre.</param>
        /// <param name="valor">Valor tipo objet. Se formatea en el mismo procedimiento.</param>
        public void Agregar(string Campo, object valor)
        {
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Herramientas h = new Herramientas();
            valor = h.Formato_SQL(valor);

            try
            {
                SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO {0} (Id, Nombre, {3}) VALUES({1}, '{2}', {4})", Tabla, ID, Nombre, Campo, valor), cnn);
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
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand(string.Format("DELETE FROM {1} WHERE Id={0}", ID, Tabla), cnn);
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
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                string Cadena = $"SELECT Id, Nombre FROM {Tabla} {filtro} ORDER BY Id";

                SqlCommand cmd = new SqlCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
                daAdapt.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        /// <summary>
        /// A Diferencia de Datos, devuelve los datos de la Vista.
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="Campos">Filtro de campos a devolver</param>
        /// <param name="Orden">Por defecto es por Id</param>
        /// <returns>Datatable</returns>
        public DataTable Datos_Vista(string filtro = "", string Campos = "*", string Orden = "ORDER BY Id")
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }
            if (Orden != "") { if (Orden != "ORDER BY Id") { Orden = " ORDER BY " + Orden; } }

            try
            {
                string Cadena = $"SELECT {Campos} FROM {Vista} {filtro} {Orden}";

                SqlCommand cmd = new SqlCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
                daAdapt.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable sp_Datos()
        {
            var dt = new DataTable("Datos");
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand(Tabla, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
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

            SqlConnection cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            var dt = new DataTable("Datos");

            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM {Tabla} WHERE Id={ID}", cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
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
        public bool Existe(int value)
        {
            SqlConnection cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            var dt = new DataTable("Datos");

            try
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM {Tabla} WHERE Id={value}", cnn);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter daAdapt = new SqlDataAdapter(cmd);
                daAdapt.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    ID = 0;
                    Nombre = "";
                    return false;
                }
                else
                {
                    ID = value;
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

        #region " Subs "
        public void Ejecutar_sp(string sp)
        {
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
            }

        }
        public void Ejecutar_sp(string sp, string nombreParametro, int n)
        {
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                SqlParameter sqlP = new SqlParameter(nombreParametro, SqlDbType.Int);
                sqlP.SqlValue = n;

                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(sqlP);
                cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
            }

        }
        public void Ejecutar_sp(string sp, string nombreParametro, string n)
        {
            var cnn = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            try
            {
                SqlParameter sqlP = new SqlParameter(nombreParametro, SqlDbType.Text);
                sqlP.SqlValue = n;

                cnn.Open();
                SqlCommand cmd = new SqlCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(sqlP);
                cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
            }

        }
        #endregion
    }
}
