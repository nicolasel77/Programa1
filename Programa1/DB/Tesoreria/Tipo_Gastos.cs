namespace Programa1.DB.Tesoreria
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Tipo_Gastos
    {
        private int vId;
        /// <summary>
        /// Grupo_Gastos
        /// </summary>
        public Grupo_Gastos grupoS = new Grupo_Gastos();

        public Tipo_Gastos()
        {
        }        

        [Required]
        [Key]
        public int Id_Tipo
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

        /// <summary>
        /// Por ahora es fijo (solo evalúa que Id=12). Mas que nada se hizo para que quede dentro de la clase.
        /// </summary>
        public bool EsHacienda { get { return Id_Tipo == 12; } }

        public void Cargar()
        {
            DataTable dt = Datos("Id_Tipo=" + Id_Tipo);
            if (dt.Rows.Count != 0)
            {
                Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                grupoS.Id = Convert.ToInt32(dt.Rows[0]["Grupo"]);
            }
            else
            {
                Nombre = "";
                grupoS.Id = 0;
            }
        }


        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Tipos_Salidas " + filtro, conexionSql);
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

        /// <summary>
        /// Devuelve los SubTipos o datos segun corresponda:
        /// SubTipos, Sucursales, Frigorificos, etc
        /// </summary>
        /// <returns></returns>
        public DataTable SubTipos(string filtro = "")
        {
            DataTable dt = new DataTable();
            if (Id_Tipo != 0)
            {
                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

                Herramientas.Herramientas h = new Herramientas.Herramientas();

                if (grupoS.Campo_Filtro.Length != 0) { filtro = h.Unir(filtro, $"{grupoS.Campo_Filtro}={Id_Tipo}"); }
                if (filtro.Length != 0) { filtro = "WHERE " + filtro; }

                string s = $"SELECT  {grupoS.Campo_Id}, {grupoS.Campo_Nombre} FROM {grupoS.Tabla} {filtro}";
                try
                {
                    SqlCommand comandoSql = new SqlCommand(s, conexionSql);

                    conexionSql.Open();

                    SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                    SqlDat.Fill(dt);

                }
                catch (Exception)
                {
                    dt = null;
                }
            }
            return dt;
        }

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {

                SqlCommand command = new SqlCommand($"UPDATE Tipos_Salidas SET Nombre='{Nombre}', " +
                    $"Grupo={grupoS.Id} WHERE Id_Tipo={Id_Tipo}", sql);
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
                SqlCommand command = new SqlCommand($"INSERT INTO Tipos_Salidas (Id_Tipo, Nombre, Grupo) VALUES({Id_Tipo}, '{Nombre}', {grupoS.Id})", sql);
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

        public void Borrar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(string.Format("DELETE FROM Tipos_Salidas WHERE Id_Tipo={0}", Id_Tipo), sql);
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                var d = command.ExecuteNonQuery();

                Id_Tipo = 0;

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }


        public bool Existe()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand("SELECT Nombre FROM Tipos_Salidas WHERE Id_Tipo=" + Id_Tipo, sql);
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
