
namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Empleados
    {
        public Empleados()
        {
        }

        public enum Orden_X {Nombre = 0, Suc, Id, Fecha_Nac, Alta, Baja, DNI, Tipo};

        public Empleados(int id,
                         string nombre,
                         TipoEmpleados tipo,
                         string domicilio,
                         Localidades localidad,
                         int dni,
                         DateTime fecha,
                         string telefono,
                         DateTime alta,
                         DateTime baja,
                         Sucursales sucursal)
        {
            Id = id;
            Nombre = nombre;
            DNI = dni;
            Fecha_Nacimiento = fecha;
            Domicilio = domicilio;
            Telefono = telefono;
            Alta = alta;
            Baja = baja;
            Sucursal = sucursal;
            Tipo = tipo;
            Localidad = localidad;

        }

        [Required]
        [Key]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
        public string Nombre { get; set; }
        public int DNI { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        [MaxLength(100, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public DateTime Alta { get; set; }
        public DateTime Baja { get; set; }

        public TipoEmpleados Tipo { get; set; } = new TipoEmpleados();
        public Localidades Localidad { get; set; }
        public Sucursales Sucursal { get; set; }

        public Orden_X Ordernar_por { get; set; }
        public bool Mostrar_Bajas { get; set; } = false;

        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            Herramientas.Herramientas h = new Herramientas.Herramientas();


            if (Mostrar_Bajas == false)
            {
                filtro = h.Unir(filtro, " (BAJA IS NULL) ");
            }
            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }
            switch (Ordernar_por)
            {
                case Orden_X.Nombre:
                    filtro += " ORDER BY Nombre ";
                    break;
                case Orden_X.Id:
                    filtro += " ORDER BY Id ";
                    break;
                case Orden_X.Suc:
                    filtro += " ORDER BY Id_Sucursales ";
                    break;
                case Orden_X.Tipo:
                    filtro += " ORDER BY Id_Tipo ";
                    break;
                case Orden_X.Fecha_Nac:
                    filtro += " ORDER BY Fecha_Nacimiento ";
                    break;
                case Orden_X.DNI:
                    filtro += " ORDER BY DNI ";
                    break;
                case Orden_X.Alta:
                    filtro += " ORDER BY Alta ";
                    break;
                case Orden_X.Baja:
                    filtro += " ORDER BY Baja ";
                    break;
            }
            
            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Empleados" + filtro, conexionSql);
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

        private void Asignar(DataRow dr)
        {
            Id = Convert.ToInt32(dr["Id"]);
            Nombre = dr["Nombre"].ToString();
            DNI = Convert.ToInt32(dr["DNI"]);
            Fecha_Nacimiento = Convert.ToDateTime(dr["Fecha_Nacimiento"]);
            Domicilio = dr["Domicilio"].ToString();
            Telefono = dr["Telefono"].ToString();
            Alta = Convert.ToDateTime(dr["Alta"]);
            Baja = Convert.ToDateTime(dr["Baja"]);

            Sucursal.Id = Convert.ToInt32(dr["Id_Sucursales"]);
            Localidad.Id = Convert.ToInt32(dr["Id_Localidades"]);
            Tipo.Id = Convert.ToInt32(dr["Id_Tipo"]);
        }

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command =
                    new SqlCommand($"UPDATE Empleados SET Nombre='{Nombre}', Id_Tipo={Tipo.Id}, Domicilio='{Domicilio}'" +
                    $",Id_Localidades={Localidad.Id} WHERE Id={Id}", sql);
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
                    new SqlCommand($"INSERT INTO Empleados (Id, Nombre, Id_Tipo, Domicilio, Id_Localidades,) VALUES({Id}, '{Nombre}', {Tipo.Id}, " +
                    $"'{Domicilio}', {Localidad.Id})", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM Empleados WHERE Id=" + Id, sql);
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
                SqlCommand command = new SqlCommand("SELECT Nombre FROM Empleados WHERE Id=" + Id, sql);
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
