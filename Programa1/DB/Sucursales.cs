
namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Sucursales
    {
        public Sucursales()
        {
            Tipo = new TipoSucursales();
            Localidad = new Localidades();
        }

        public Sucursales(int id, string nombre, int tipo, bool ver, bool propio, string titular, string cuit, string direccion, string alias, int localidad, string balanza)
        {
            Id = id;
            Nombre = nombre;
            Tipo.Id = tipo;
            Ver = ver;
            Propio = propio;
            Titular = titular;
            CUIT = cuit;
            Direccion = direccion;
            Alias = alias;
            Localidad.Id = localidad;
            Balanza = balanza;
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        public TipoSucursales Tipo { get; set; }

        public bool Ver { get; set; }

        public bool Propio { get; set; }

        public string Titular { get; set; }

        public string CUIT { get; set; }

        public string Direccion { get; set; }

        public string Alias { get; set; }

        public Localidades Localidad { get; set; }

        public string Balanza { get; set; }



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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Sucursales" + filtro, conexionSql);
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
                string vpropio = Propio ? "1" : "0";
                
                SqlCommand command =
                    new SqlCommand($"UPDATE Sucursales SET Nombre='{Nombre}', Tipo={Tipo.Id}, Ver={vver}, Propio={vpropio}, Titular='{Titular}', CUIT='{CUIT}', Direccion='{Direccion}'" +
                    $",Alias='{Alias}',Id_Localidad={Localidad.Id}, Balanza='{Balanza}' WHERE Id={Id}", sql);
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
                string vpropio = Propio ? "1" : "0";                

                SqlCommand command =
                    new SqlCommand($"INSERT INTO Sucursales (Id, Nombre, Tipo, Ver, Propio, Titular, CUIT, Direccion, Id_Localidad, Alias, Balanza) VALUES({Id}, '{Nombre}', {Tipo.Id}, {vver}, " +
                    $"{vpropio}, '{Titular}', '{CUIT}', '{Direccion}', {Localidad.Id}, '{Alias}', '{Balanza}')", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM Sucursales WHERE Id=" + Id, sql);
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
                SqlCommand command = new SqlCommand("SELECT Nombre FROM Sucursales WHERE Id=" + Id, sql);
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
