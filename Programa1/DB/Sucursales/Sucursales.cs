
namespace Programa1.DB.Sucursales
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Sucursales
    {
        public Sucursales()
        {
        }

        public enum Filtrar_SucsClientes { Todas = 0, Sucursales, Clientes };

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

        [MaxLength(50, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }

        public TipoSucursales Tipo { get; set; } = new TipoSucursales();

        public bool Ver { get; set; }

        public bool Propio { get; set; }

        public string Titular { get; set; }

        public string CUIT { get; set; }

        public string Direccion { get; set; }

        public string Alias { get; set; }

        public Localidades Localidad { get; set; } = new Localidades();

        public string Balanza { get; set; }


        public Filtrar_SucsClientes Filtro_SucCliente { get; set; }

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
            switch (Filtro_SucCliente)
            {
                case Filtrar_SucsClientes.Clientes:
                    filtro = h.Unir(filtro, " (Propio=0) ");
                    break;
                case Filtrar_SucsClientes.Sucursales:
                    filtro = h.Unir(filtro, " (Propio=1) ");
                    break;
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
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Sucursales" + filtro, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                dt = null;
            }

            return dt;
        }

        public void Siguiente()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 * FROM Sucursales WHERE Id>{Id} ORDER BY Id", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);
                DataRow dr;

                if (dt.Rows.Count > 0)
                {
                    dr = dt.Rows[0];
                    Asignar(dr);
                }
                else
                {
                    comandoSql.CommandText = ($"SELECT TOP 1 * FROM Sucursales ORDER BY Id");
                    comandoSql.CommandType = CommandType.Text;

                    SqlDat.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        Id = 0;
                    }
                    else
                    {
                        dr = dt.Rows[0];
                        Asignar(dr);
                    }
                }                
            }
            catch (Exception)
            {
                Id = 0;
            }
        }

        private void Asignar(DataRow dr)
        {
            Id = Convert.ToInt32(dr["Id"]);
            Nombre = dr["Nombre"].ToString();
            Tipo.Id = Convert.ToInt32(dr["Tipo"]);
            Ver = Convert.ToBoolean(dr["Ver"]);
            Titular = dr["Titular"].ToString();
            Direccion = dr["Direccion"].ToString();
            Alias = dr["Alias"].ToString();
            CUIT = dr["CUIT"].ToString();
            Balanza = dr["Balanza"].ToString();
            Localidad.Id = Convert.ToInt32(dr["Id_Localidad"]);
        }

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command =
                    new SqlCommand($"UPDATE Sucursales SET Nombre='{Nombre}', Tipo={Tipo.Id}, Ver={(Ver ? "1" : "0")}, Propio={(Propio ? "1" : "0")}, Titular='{Titular}', CUIT='{CUIT}', Direccion='{Direccion}'" +
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
            var dt = new DataTable("Datos");

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM Sucursales WHERE Id=" + Id, sql);
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
    }
}
