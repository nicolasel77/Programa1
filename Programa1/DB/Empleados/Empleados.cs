
namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Empleados
    {
        public Empleados()
        {
        }

        public enum Orden_X { Nombre = 0, Suc, Id, Fecha_Nac, Alta, Baja, DNI, Tipo };

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
                         Sucursales.Sucursales sucursal)
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
        public DateTime Fecha_Nacimiento { get; set; } = DateTime.Parse("1-1-1900");

        [MaxLength(100, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public DateTime Alta { get; set; } = DateTime.Parse("1-1-1900");
        public DateTime Baja { get; set; } = DateTime.Parse("1-1-1900");

        public TipoEmpleados Tipo { get; set; } = new TipoEmpleados();
        public Localidades Localidad { get; set; } = new Localidades();
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();

        public Orden_X Ordernar_por { get; set; }
        public bool Mostrar_Bajas { get; set; } = false;

        public DataTable Datos(string filtro = "")
        {
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            var dt = new DataTable("Datos");

            if (Mostrar_Bajas == false)
            {
                filtro = h.Unir(filtro, " (Baja IS NULL OR Baja<'01-01-2000') ");
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

                var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

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
            if (dr["Fecha_Nacimiento"] != DBNull.Value)
            {
                Fecha_Nacimiento = Convert.ToDateTime(dr["Fecha_Nacimiento"]);
            }

            Domicilio = dr["Domicilio"].ToString();
            Telefono = dr["Telefono"].ToString();
            if (dr["Alta"] != DBNull.Value)
            {
                Alta = Convert.ToDateTime(dr["Alta"]);
            }

            if (dr["Baja"] != DBNull.Value)
            {
                Baja = Convert.ToDateTime(dr["Baja"]);
            }

            Sucursal.ID = Convert.ToInt32(dr["Id_Sucursales"]);
            Localidad.Id = Convert.ToInt32(dr["Id_Localidades"]);
            Tipo.ID = Convert.ToInt32(dr["Id_Tipo"]);
        }

        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string vBaja = "NULL";
                if (Baja > Convert.ToDateTime("1/1/2000"))
                {
                    vBaja = Baja.ToString("'MM/dd/yyy'");
                }

                SqlCommand command =
                    new SqlCommand($"UPDATE Empleados SET Nombre='{Nombre}', Id_Tipo={Tipo.ID}, Telefono='{Telefono}', Domicilio='{Domicilio}'" +
                    $", Fecha_Nacimiento='{Fecha_Nacimiento.ToString("MM/dd/yyy")}', Alta='{Alta.ToString("MM/dd/yyy")}', Baja={vBaja}" +
                    $", DNI={DNI}, Id_Localidades={Localidad.Id}, Id_Sucursales={Sucursal.ID} WHERE Id={Id}", sql);
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
                    new SqlCommand($"INSERT INTO Empleados (Id, Nombre, DNI, Fecha_Nacimiento, Domicilio, Telefono, Alta, Baja, Id_Tipo, Id_Localidades, Id_Sucursales)" +
                    $" VALUES({Id}, '{Nombre}', {DNI}, '{Fecha_Nacimiento.ToString("MM/dd/yyy")}'" +
                    $", '{Domicilio}', '{Telefono}', '{Alta.ToString("MM/dd/yyy")}', '{Baja.ToString("MM/dd/yyy")}'" +
                    $", {Tipo.ID}, {Localidad.Id}, {Sucursal.ID})", sql);
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

                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Empleados WHERE Id=" + Id, sql);
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

        public int MaxId()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT ISNULL(MAX(Id), 0) FROM Empleados", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }

            return Convert.ToInt32(d);
        }
    }
}
