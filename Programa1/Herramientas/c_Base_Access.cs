namespace Programa1.Clases
{
    using Programa1.Herramientas;
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using System.Media;
    using System.Windows.Forms;

    public class c_Base_Access
    {
        string conn_string = "Provider=Microsoft.ACE.OLEDB.12.0;" + Programa1.Properties.Settings.Default.dbDatosConnectionString;

        public c_Base_Access() { }

        public c_Base_Access(string tabla, string vista)
        {
            Tabla = tabla;
            Vista = vista;
        }
        public string Base_Access
        {
            get { return conn_string; }
            set
            {
                if (File.Exists(value) == true)
                {
                    conn_string = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={value};Jet OLEDB:Database Password=**Oficina02;";
                }

            }
        }

        public string Tabla { get; set; }
        public string Vista { get; set; }

        public int ID { get; set; }

        /// <summary>
        /// Por defecto false.
        /// </summary>
        public bool ID_Automatico = false;

        /// <summary>
        /// Es el nombre del campo ID, por defecto es ID.
        /// </summary>
        public string Campo_ID { get; set; } = "ID";
        public string Campo_Nombre { get; set; } = "Nombre";
        public string Nombre { get; set; }



        #region " Editar Datos "
        public void Actualizar()
        {
            var cnn = new OleDbConnection(conn_string);

            try
            {
                OleDbCommand command = new OleDbCommand(string.Format("UPDATE {2} SET Nombre='{0}' WHERE {3}={1}", Nombre, ID, Tabla, Campo_ID), cnn);
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
            var cnn = new OleDbConnection(conn_string);

            Herramientas h = new Herramientas();
            valor = h.Formato_SQL(valor);

            try
            {
                OleDbCommand command = new OleDbCommand(string.Format("UPDATE {0} SET {1}={2} WHERE {3}={4}", Tabla, Campo, valor, Campo_ID, ID), cnn);
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
            var cnn = new OleDbConnection(conn_string);

            try
            {
                string cadena = $"INSERT INTO {Tabla} ({Campo_ID}, Nombre) VALUES({ID}, '{Nombre}')";
                if (ID_Automatico == true) { cadena = $"INSERT INTO {Tabla} (Nombre) VALUES('{Nombre}')"; }
                OleDbCommand cmd = new OleDbCommand(cadena, cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();

                var d = cmd.ExecuteNonQuery();

                cnn.Close();
                ID = Max_ID();
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
            var cnn = new OleDbConnection(conn_string);

            Herramientas h = new Herramientas();
            valor = h.Formato_SQL(valor);

            try
            {
                string cadena = string.Format("INSERT INTO {0} ({5}, Nombre, {3}) VALUES({1}, '{2}', {4})", Tabla, ID, Nombre, Campo, valor, Campo_ID);
                if (ID_Automatico == true) { cadena = string.Format("INSERT INTO {0} (Nombre, {2}) VALUES('{1}', {3})", Tabla, Nombre, Campo, valor); }

                OleDbCommand cmd = new OleDbCommand(cadena, cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();

                var d = cmd.ExecuteNonQuery();

                cnn.Close();
                ID = Max_ID();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        /// <summary>
        /// Agrega el registro sin usar ID, Nombre.
        /// </summary>
        /// <param name="Campo">El nombre del Campo que se agrega.</param>
        /// <param name="valor">Valor tipo objet. Se formatea en el mismo procedimiento.</param>
        public void Agregar_NoID(string Campo, object valor)
        {
            var cnn = new OleDbConnection(conn_string);

            Herramientas h = new Herramientas();
            valor = h.Formato_SQL(valor);

            try
            {
                OleDbCommand cmd = new OleDbCommand(string.Format("INSERT INTO {0} ({1}) VALUES({2})", Tabla, Campo, valor), cnn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();

                var d = cmd.ExecuteNonQuery();

                cnn.Close();
                ID = Max_ID();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void Borrar()
        {
            var cnn = new OleDbConnection(conn_string);

            try
            {
                OleDbCommand cmd = new OleDbCommand(string.Format("DELETE FROM {1} WHERE {2}={0}", ID, Tabla, Campo_ID), cnn);
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
        /// <summary>
        /// Para borrar varios registros a la vez.
        /// </summary>
        /// <param name="where">sin la palabra where</param>
        public void Borrar(string where)
        {
            var cnn = new OleDbConnection(conn_string);

            try
            {
                OleDbCommand cmd = new OleDbCommand(string.Format("DELETE FROM {1} WHERE {0}", where, Tabla), cnn);
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
        public void Borrar(string tabla, string where)
        {
            var cnn = new OleDbConnection(conn_string);

            try
            {
                OleDbCommand cmd = new OleDbCommand(string.Format("DELETE FROM {1} WHERE {0}", where, tabla), cnn);
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
        #endregion


        #region " Devolver Datos "
        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var cnn = new OleDbConnection(conn_string);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                string Cadena = $"SELECT {Campo_ID}, {Campo_Nombre} FROM {Tabla} {filtro} ORDER BY {Campo_ID}";

                OleDbCommand cmd = new OleDbCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
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
        public DataTable Datos_Vista(string filtro = "", string Campos = "*", string Orden = "ORDER BY ")
        {
            var dt = new DataTable("Datos");
            var cnn = new OleDbConnection(conn_string);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }
            if (Campos == "") { Campos = "*"; }
            if (Orden != "") { Orden = (Orden != "ORDER BY ") ? " ORDER BY " + Orden : " ORDER BY " + Campo_ID; }

            try
            {
                string Cadena = $"SELECT {Campos} FROM {Vista} {filtro} {Orden}";

                OleDbCommand cmd = new OleDbCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                daAdapt.Fill(dt);
            }
            catch (Exception er)
            {
                dt = null;
                MessageBox.Show(er.Message);
            }

            return dt;
        }
        public DataTable Datos_Vista(string filtro, string Campos, string Orden, string GroupBy)
        {
            var dt = new DataTable("Datos");
            var cnn = new OleDbConnection(conn_string);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }
            if (Campos == "") { Campos = "*"; }
            if (GroupBy.Length > 0) { GroupBy = " GROUP BY " + GroupBy; }
            if (Orden != "") { Orden = (Orden != "ORDER BY ") ? " ORDER BY " + Orden : " ORDER BY " + Campo_ID; }

            try
            {
                string Cadena = $"SELECT {Campos} FROM {Vista} {filtro} {GroupBy} {Orden}";

                OleDbCommand cmd = new OleDbCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                daAdapt.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
        /// <summary>
        /// Devuelve un dato específico. Usa Top 1
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="Campos"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public object Dato(string filtro = "", string Campos = "*", string Orden = "ORDER BY ")
        {
            var cnn = new OleDbConnection(conn_string);
            object d = null;
            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }
            if (Orden != "") { Orden = (Orden != "ORDER BY ") ? " ORDER BY " + Orden : " ORDER BY " + Campo_ID; }

            try
            {
                string Cadena = $"SELECT TOP 1 {Campos} FROM {Vista} {filtro} {Orden}";

                OleDbCommand cmd = new OleDbCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                d = cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
            }

            return d;
        }
        /// <summary>
        /// Devuelve un dato específico buscando por tabla.
        /// </summary>
        /// <param name="tabla"></param>
        /// <param name="filtro"></param>
        /// <param name="Campo"></param>
        /// <returns></returns>
        public object Dato_Generico(string tabla, string filtro, string Campo)
        {
            var cnn = new OleDbConnection(conn_string);
            object d = null;
            
            try
            {
                string Cadena = $"SELECT TOP 1 {Campo} FROM {tabla} WHERE {filtro}";

                OleDbCommand cmd = new OleDbCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                d = cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
            }

            return d;
        }
        /// <summary>
        /// Devuelve un SUM(Campo)
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="Campo"></param>
        /// <param name="Orden"></param>
        /// <returns></returns>
        public double Dato_Sumado(string filtro, string Campo)
        {
            var cnn = new OleDbConnection(conn_string);
            object d;
            try
            {
                string Cadena = $"SELECT SUM({Campo}) FROM {Vista} WHERE {filtro}";

                OleDbCommand cmd = new OleDbCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                d = cmd.ExecuteScalar();                
                cnn.Close();
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
                d = 0;
            }
            if (d == DBNull.Value) { d = 0; }
            return Convert.ToDouble(d);
        }
        public double Dato_Sumado(string tabla, string filtro, string Campo)
        {
            var cnn = new OleDbConnection(conn_string);
            object d;
            try
            {
                string Cadena = $"SELECT SUM({Campo}) FROM {tabla} WHERE {filtro}";

                OleDbCommand cmd = new OleDbCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                d = cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
                d = 0;
            }
            if (d == DBNull.Value) { d = 0; }
            return Convert.ToDouble(d);
        }

        public DataTable sp_Datos()
        {
            var dt = new DataTable("Datos");
            var cnn = new OleDbConnection(conn_string);

            try
            {
                OleDbCommand cmd = new OleDbCommand(Tabla, cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                daAdapt.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public int Max_ID()
        {
            var cnn = new OleDbConnection(conn_string);
            int d = 0;

            try
            {
                string Cadena = $"SELECT MAX({Campo_ID}) FROM {Tabla}";

                OleDbCommand cmd = new OleDbCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();
                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                d = (int)cmd.ExecuteScalar();

                cnn.Close();
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
            }

            return d;
        }

        public bool Existe()
        {

            OleDbConnection cnn = new OleDbConnection(conn_string);
            var dt = new DataTable("Datos");

            try
            {
                OleDbCommand cmd = new OleDbCommand($"SELECT * FROM {Tabla} WHERE Id={ID}", cnn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
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
            OleDbConnection cnn = new OleDbConnection(conn_string);
            var dt = new DataTable("Datos");

            try
            {
                OleDbCommand cmd = new OleDbCommand($"SELECT * FROM {Tabla} WHERE {Campo_ID}={value}", cnn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
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
        public bool Existe(string campo, object value)
        {
            OleDbConnection cnn = new OleDbConnection(conn_string);
            var dt = new DataTable("Datos");
            Herramientas h = new Herramientas();
            value = h.Formato_SQL(value);

            try
            {
                OleDbCommand cmd = new OleDbCommand($"SELECT * FROM {Tabla} WHERE {campo}={value}", cnn);
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                daAdapt.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    ID = 0;
                    Nombre = "";
                    return false;
                }
                else
                {
                    ID = Convert.ToInt32(dt.Rows[0][0]);
                    Nombre = Convert.ToString(dt.Rows[0][Campo_Nombre]);
                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }

        }

        public bool Fecha_Cerrada(DateTime f)
        {
            var cnn = new OleDbConnection(conn_string);
            object n = null;

            try
            {
                string Cadena = $"SELECT TOP 1 Cerrada FROM Semanas WHERE Semana<='{f:MM/dd/yyyy}' ORDER BY Semana DESC";

                OleDbCommand cmd = new OleDbCommand(Cadena, cnn);
                cmd.CommandType = CommandType.Text;

                cnn.Open();

                OleDbDataAdapter daAdapt = new OleDbDataAdapter(cmd);
                n = cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
                SystemSounds.Beep.Play();
            }

            if (n == null) { n = false; }

            return Convert.ToBoolean(n);
        }
        #endregion

        #region " Subs "
        public void Ejecutar_sp(string sp)
        {
            var cnn = new OleDbConnection(conn_string);
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
            }

        }
        public void Ejecutar_sp(string sp, OleDbParameter[] parameter)
        {
            var cnn = new OleDbConnection(conn_string);
            try
            {
                cnn.Open();
                OleDbCommand cmd = new OleDbCommand(sp, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameter);
                cmd.ExecuteScalar();
                cnn.Close();
            }
            catch (Exception)
            {
            }

        }
        public void Ejecutar_sp(string sp, string nombreParametro, int n)
        {
            var cnn = new OleDbConnection(conn_string);
            try
            {
                OleDbParameter sqlP = new OleDbParameter(nombreParametro, SqlDbType.Int);
                sqlP.Value = n;

                cnn.Open();
                OleDbCommand cmd = new OleDbCommand(sp, cnn);
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
            var cnn = new OleDbConnection(conn_string);
            try
            {
                OleDbParameter sqlP = new OleDbParameter(nombreParametro, SqlDbType.Text);
                sqlP.Value = n;

                cnn.Open();
                OleDbCommand cmd = new OleDbCommand(sp, cnn);
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
