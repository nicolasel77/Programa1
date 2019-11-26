namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    class Sueldos
    {
        public Sueldos()
        {
        }

        public Sueldos(int id, DateTime fecha, Empleados prod, TipoSueldo tipo, Single sueldo)
        {
            Id = id;
            Fecha = fecha;
            Empleado = prod;
            Tipo = tipo;
            Sueldo = sueldo;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Empleados Empleado { get; set; } = new Empleados();
        public TipoSueldo Tipo { get; set; } = new TipoSueldo();
        public Single Sueldo { get; set; }

        public Single Buscar()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP 1 Sueldo FROM Sueldos  WHERE Fecha<='{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND Id_Empleados={Empleado.Id} AND ID_Tipo={Tipo.Id} ORDER BY Fecha DESC", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = null;
            }
            Sueldo = Convert.ToSingle(d);
            return Sueldo;
        }

        public DataTable Datos(string filtro = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (filtro.Length > 0)
            {
                filtro = " WHERE " + filtro;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT * FROM vw_Sueldos" + filtro, conexionSql);
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
                    new SqlCommand($"UPDATE Sueldos " +
                    $"SET Fecha='{Fecha.ToString("MM/dd/yyy")}', Id_Tipo={Tipo.Id}, Id_Empleados={Empleado.Id}, Sueldo={Sueldo.ToString().Replace(",", ".")} " +
                    $"WHERE Id={Id}", sql);
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
                    new SqlCommand($"INSERT INTO Sueldos (Fecha, Id_Tipo, Id_Empleados, Sueldo) " +
                    $"VALUES('{Fecha.ToString("MM/dd/yyy")}', {Tipo.Id}, {Empleado.Id}, {Sueldo.ToString().Replace(",", ".")} )", sql);
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
                SqlCommand command = new SqlCommand("DELETE FROM Sueldos WHERE Id=" + Id, sql);
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

}
