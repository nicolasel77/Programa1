namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Productos
    {
        public Productos()
        {
            Tipo = new TipoProductos();
        }

        public Productos(int id, string nombre, int tipo, bool ver, bool imp, bool pesable, int multi)
        {
            Id = id;
            Nombre = nombre;
            Tipo.Id = tipo;
            Ver = ver;
            Imprimir = imp;
            Pesable = pesable;
            Multiplicador = multi;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        public TipoProductos Tipo { get; set; }

        public bool Ver { get; set; }

        public bool Imprimir { get; set; }

        public bool Pesable { get; set; }

        public int Multiplicador { get; set; }



        public DataTable Datos(string filtro = "")
        {
            //Cadena de conexion y DataTable (tabla)
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Productos" + filtro, conexionSql);
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
                string vimp = Imprimir ? "1" : "0";
                string vpesa = Pesable ? "1" : "0";

                SqlCommand command = 
                    new SqlCommand($"UPDATE Productos SET Nombre='{Nombre}', Id_Tipo={Tipo.Id}, Ver={vver}, Imprimir={vimp}, Pesable={vpesa}, Multiplicador={Multiplicador} WHERE Id={Id}", sql);
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
                string vimp = Imprimir ? "1" : "0";
                string vpesa = Pesable ? "1" : "0";

                SqlCommand command = 
                    new SqlCommand($"INSERT INTO Productos (Id, Nombre, Id_Tipo, Ver, Imprimir, Pesable, Multiplicador) VALUES({Id}, '{Nombre}', {Tipo.Id}, {vver}, " +
                    $"{vimp}, {vpesa}, {Multiplicador})", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM Productos WHERE Id=" + Id, sql);
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
                SqlCommand command = new SqlCommand("SELECT Nombre FROM Productos WHERE Id=" + Id, sql);
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
