
namespace Programa1.DB
{
    using Programa1.Clases;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Empleados : c_Base
    {
        public Empleados()
        {
            Tabla = "dbEmpleados.dbo.Empleados";
            Vista = "dbEmpleados.dbo.vw_Empleados";
        }

        public enum Orden_X { Nombre = 0, Suc, Id, Fecha_Nac, Alta, Baja, DNI, Tipo };


        [MaxLength(100, ErrorMessage = "El {0} no puede ser mayor a {1} caracteres")]
        [Required]
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

        public new DataTable Datos(string filtro = "")
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

                SqlCommand comandoSql = new SqlCommand("SELECT * FROM dbEmpleados.dbo.vw_Empleados" + filtro, conexionSql);
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
                

        public new void Actualizar()
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
                    $", DNI={DNI}, Id_Localidades={Localidad.Id}, Id_Sucursales={Sucursal.ID} WHERE Id={ID}", sql);
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

        public new void Agregar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command =
                    new SqlCommand($"INSERT INTO Empleados (Id, Nombre, DNI, Fecha_Nacimiento, Domicilio, Telefono, Alta, Baja, Id_Tipo, Id_Localidades, Id_Sucursales)" +
                    $" VALUES({ID}, '{Nombre}', {DNI}, '{Fecha_Nacimiento.ToString("MM/dd/yyy")}'" +
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

    }
}
