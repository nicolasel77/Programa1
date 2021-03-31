namespace Programa1.DB.Tesoreria
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    class Detalle_Gastos
    {
        public Detalle_Gastos() { }
        private int vId;
        private int vDetalle;
        private Tipo_Gastos tg = new Tipo_Gastos();

        [Required]
        [Key]
        public int Id_Tipo
        {
            get { return vId; }
            set
            {
                vId = value;
                tg.Id_Tipo = vId;
                Cargar();
            }
        }


        [MaxLength(100, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        public int ID_Detalle
        {
            get { return vDetalle;  }
            set
            {
                vDetalle = value;
                Cargar();
            }
        }


        public void Cargar()
        {
            DataTable dt = Datos($"Id_Tipo={Id_Tipo} AND ID_Detalle={vDetalle}");
            if (dt.Rows.Count != 0)
            {
                Nombre = Convert.ToString(dt.Rows[0]["Nombre"]);
            }
            else
            {
                Nombre = "";
            }

        }

        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) { filtro = " WHERE " + filtro; }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Detalles_Gastos" + filtro + " ORDER BY ID_Detalle", conexionSql);
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
                SqlCommand command = new SqlCommand($"UPDATE Detalles_Gastos SET Nombre='{Nombre}', " +
                    $"ID_Detalle={ID_Detalle} WHERE Id_Tipo={Id_Tipo} AND ID_Detalle={ID_Detalle}", sql);
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
                SqlCommand command = new SqlCommand($"INSERT INTO Detalles_Gastos (Id_Tipo, Nombre, ID_Detalle)" +
                    $" VALUES({Id_Tipo}, '{Nombre}', {ID_Detalle})", sql);
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
                SqlCommand command = new SqlCommand($"DELETE FROM Detalles_Gastos WHERE Id_Tipo={Id_Tipo} AND ID_Detalle={ID_Detalle}", sql);
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
                SqlCommand command = new SqlCommand($"SELECT Nombre FROM Detalles_Gastos WHERE Id_Tipo={Id_Tipo} AND ID_Detalle={ID_Detalle}", sql);
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

