namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Proveedores
    {
        public Proveedores()
        {
            Tipo = new TipoProveedores();
        }

        public Proveedores(int id, string nombre, int tipo, bool ver)
        {
            Id = id;
            Nombre = nombre;
            Tipo.Id = tipo;
            Ver = ver;            
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        public TipoProveedores Tipo { get; set; }

        public bool Ver { get; set; }


        public bool Mostrar_Ocultos { get; set; } = false;
        public bool Ordern_XId { get; set; } = true;


        public DataTable Datos(string filtro = "")
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
                SqlCommand comandoSql = new SqlCommand("SELECT Id, Tipo, Nombre, Ver FROM Proveedores" + filtro, conexionSql);
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
                string vver = Ver ? "1" : "0";
                
                SqlCommand command =
                    new SqlCommand($"UPDATE Proveedores SET Nombre='{Nombre}', Tipo={Tipo.Id}, Ver={vver} WHERE Id={Id}", sql);
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
                string vver = Ver ? "1" : "0";
                
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Proveedores (Id, Nombre, Tipo, Ver) VALUES({Id}, '{Nombre}', {Tipo.Id}, {vver})", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM Proveedores WHERE Id=" + Id, sql);
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


        public bool Existe()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand("SELECT Nombre FROM Proveedores WHERE Id=" + Id, sql);
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
