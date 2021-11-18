namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using Programa1.Clases;
    public class Consignatarios: c_Base
    {
        public Consignatarios()
        {
            Tabla = "Consignatarios";
            Vista = Tabla;
        }

        public Consignatarios(int id, string nombre, int tipo, bool ver)
        {
            Id = id;
            Nombre = nombre;
            Id_Frigorifico = tipo;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]

        public int Id_Frigorifico { get; set; }

        public bool Mostrar_Ocultos { get; set; } = false;

        public bool Ordern_XId { get; set; } = true;


        public new DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            Herramientas.Herramientas h = new Herramientas.Herramientas();

            if (Mostrar_Ocultos == false)
            {
                filtro = h.Unir(filtro, " (Ver=1) ");
            }

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            if (Ordern_XId == false)
            {
                filtro += " ORDER BY Nombre ";
            }
            else
            {
                filtro += " ORDER BY Id";
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT Id, Nombre, Id_Frigorifico FROM Consignatarios" + filtro, conexionSql);
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
                SqlCommand command =
                    new SqlCommand($"UPDATE Consignatarios SET Nombre='{Nombre}', ID_Frigorifico={Id_Frigorifico} WHERE Id={Id}", sql);
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
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Consignatarios (Id, Nombre, Id_Frigorifico) VALUES({Id}, '{Nombre}', {Id_Frigorifico})", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM Consignatarios WHERE Id=" + Id, sql);
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


        public bool Existe()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            var dt = new DataTable("Datos");

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Consignatarios WHERE Id=" + Id, sql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);



                if (dt.Rows.Count == 0)
                {
                    Nombre = "";
                    return false;
                }
                else
                {
                    Asignar(dt.Rows[0]);
                    return true;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
                return false;
            }
        }

        private void Asignar(DataRow dr)
        {
            Id = Convert.ToInt32(dr["Id"]);
            Nombre = dr["Nombre"].ToString();
            Id_Frigorifico = Convert.ToInt32(dr["Tipo"]);
        }

            public int Traducir_Consignatario(int id_frigo)
            {
                object id = Dato("ID_Frigorifico=" + id_frigo, "Id");

                if (id == DBNull.Value) { id = 0; }

                return Convert.ToInt32(id);
        }
    }

}
