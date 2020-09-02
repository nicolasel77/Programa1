namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class GastosSucursales_Tipos
    {
        public GastosSucursales_Tipos()
        {            
        }

        public GastosSucursales_Tipos(int id, GastosSucursales_Rubros rubro, string nombre)
        {
            Id = id;
            Rubro = rubro;
            Nombre = nombre;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        public GastosSucursales_Rubros Rubro { get; set; } = new GastosSucursales_Rubros();

        [MaxLength(50, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        public bool Ordern_XId { get; set; } = true;

        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0) filtro = " WHERE " + filtro;

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
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_GastosSucursalesTipos  {filtro} ", conexionSql);
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
                SqlCommand command = new SqlCommand($"UPDATE GastosSucursales_Tipos SET Nombre='{Nombre}', Id_Rubro={Rubro.Id} WHERE Id={Id}", sql);
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
                SqlCommand command = new SqlCommand($"INSERT INTO GastosSucursales_Tipos (Id, Id_Rubro, Nombre) VALUES({Id}, {Rubro.Id}, '{Nombre}')", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM GastosSucursales_Tipos WHERE Id=" + Id, sql);
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
                SqlCommand command = new SqlCommand($"SELECT Nombre FROM GastosSucursales_Tipos WHERE Id={Id}", sql);
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
