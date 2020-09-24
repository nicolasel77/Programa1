using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Programa1.DB.Tesoreria
{
    class SubTipo_Gastos
    {
        public SubTipo_Gastos()
        {
        }

        private int vId;

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

        [MaxLength(100, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }
               
        public int ID_SubTipo { get; set; }


        public void Cargar()
        {
            DataTable dt = Datos("Id_Tipo=" + Id_Tipo);
            if (dt.Rows.Count != 0)
            {
                Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
                ID_SubTipo = Convert.ToInt32(dt.Rows[0]["ID_SubTipo"]);
            }
            else
            {
                Nombre = "";
                ID_SubTipo = 0;
            }

        }

        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM SubTipos_Gastos" + filtro, conexionSql);
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

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"UPDATE SubTipos_Gastos SET Nombre='{Nombre}', " +
                    $"ID_SubTipo={ID_SubTipo} WHERE Id_Tipo={Id_Tipo} AND ID_SubTipo={ID_SubTipo}", sql);
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
                SqlCommand command = new SqlCommand($"INSERT INTO SubTipos_Gastos (Id_Tipo, Nombre, ID_SubTipo)" +
                    $" VALUES({Id_Tipo}, '{Nombre}', {ID_SubTipo})", sql);
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
                SqlCommand command = new SqlCommand($"DELETE FROM SubTipos_Gastos WHERE Id_Tipo={Id_Tipo} AND ID_SubTipo={ID_SubTipo}", sql);
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
                SqlCommand command = new SqlCommand($"SELECT Nombre FROM SubTipos_Gastos WHERE Id_Tipo={Id_Tipo} AND ID_SubTipo={ID_SubTipo}", sql);
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
