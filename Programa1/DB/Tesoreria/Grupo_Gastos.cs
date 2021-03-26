namespace Programa1.DB.Tesoreria
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Grupo_Gastos
    {
        public Grupo_Gastos() { }

        private int vId;

        [Required]
        [Key]
        public int Id
        {
            get { return vId; }
            set
            {
                vId = value;
                Cargar();
            }
        }

        [MaxLength(20, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(20, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Tabla { get; set; }
        /// <summary>
        /// Campo a buscar.
        /// </summary>
        public string Campo_Id { get; set; }
        public string Campo_Nombre { get; set; }
        public string Campo_Filtro { get; set; }

        public void Cargar()
        {
            DataTable dt = Datos("Id=" + Id);
            if (dt.Rows.Count != 0)
            {
                Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                Tabla = Convert.ToString(dt.Rows[0]["Tabla"]);
                Campo_Id = Convert.ToString(dt.Rows[0]["Campo_Id"]);
                Campo_Nombre = Convert.ToString(dt.Rows[0]["Campo_Nombre"]);
                Campo_Filtro = Convert.ToString(dt.Rows[0]["Campo_Filtro"]);
            }
            else
            {
                Nombre = "";
                Tabla = "";
                Campo_Id = "";
                Campo_Nombre = "";
                Campo_Filtro = "";
            }
        }

        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Grupos_Salidas" + filtro, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable Tablas(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Tablas" + filtro, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public int MaxId()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT ISNULL(MAX(Id), 0) FROM Grupos_Salidas", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }

            return Convert.ToInt32(d);
        }

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"UPDATE Grupos_Salidas SET Nombre='{Nombre}', " +
                    $"Tabla='{Tabla}', Campo_ID='{Campo_Id}', Campo_Nombre='{Campo_Nombre}', Campo_Filtro='{Campo_Filtro}'" +
                    $" WHERE Id={Id}", sql);
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

        public void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"INSERT INTO Grupos_Salidas (Nombre, Tabla, Campo_ID, Campo_Nombre, Campo_Filtro)" +
                    $" VALUES('{Nombre}', '{Tabla}', '{Campo_Id}', '{Campo_Nombre}', '{Campo_Filtro}')", sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                Id = MaxId();

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void Borrar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("DELETE FROM Grupos_Salidas WHERE Id={0}", Id), sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                Id = 0;

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        public void Buscar_Tabla()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Campo_Id = "";
            Campo_Nombre = "";

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM Tablas WHERE Tabla LIKE '{Tabla}'", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    Campo_Id = Convert.ToString(dt.Rows[0]["Campo_Id"]);
                    Campo_Nombre = Convert.ToString(dt.Rows[0]["Campo_Nombre"]);
                    Campo_Filtro = Convert.ToString(dt.Rows[0]["Campo_Filtro"]);
                }
            }
            catch (Exception)
            {
                dt = null;
            }

        }

        public bool Existe()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand("SELECT Nombre FROM Grupos_Salidas WHERE Id=" + Id, sql);
                command.CommandType = CommandType.Text;
                sql.Open();
                command.Connection = sql;


                var d = command.ExecuteScalar();

                if (string.IsNullOrEmpty(Convert.ToString(d)))
                {
                    return false;
                }
                else
                {
                    if (d.ToString().Length == 0)
                    {
                        Nombre = "";
                        return false;
                    }
                    else
                    {
                        Nombre = d.ToString();
                        return true;
                    }

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }
        }
    }
}
