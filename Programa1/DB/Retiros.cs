namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Retiros
    {
        public Retiros()
        {

        }

        public Retiros(int id, DateTime fecha, Empleados empleado, Sucursales sucursal, TipoRetiros tipo, float importe)
        {
            Id = id;
            Fecha = fecha;
            Empleado = empleado;
            Sucursal = sucursal;
            Tipo = tipo;
            Importe = importe;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; } = new DateTime(2000, 1, 1);
        public Empleados Empleado { get; set; } = new Empleados();
        public Sucursales Sucursal { get; set; } = new Sucursales();
        public TipoRetiros Tipo { get; set; } = new TipoRetiros();
        public Single Importe { get; set; }


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
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Retiros {filtro} ORDER BY Id", conexionSql);
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

        public DataTable Datos_Mes(DateTime mes, int suc)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"EXEC sp_SueldosMes '{mes.ToString("MM/dd/yyy")}', {suc}", conexionSql);
                comandoSql.CommandType = CommandType.Text;
                conexionSql.Open();
                comandoSql.ExecuteNonQuery();

                if (suc > 0)
                {
                    comandoSql.CommandText = $"SELECT * FROM vw_MesTemp WHERE Mes='{mes.ToString("MM/dd/yyy")}' AND Id_Sucursales={suc} ORDER BY  Id_Empleados";
                }
                else
                {
                    comandoSql.CommandText = $"SELECT * FROM vw_MesTemp WHERE Mes='{mes.ToString("MM/dd/yyy")}' ORDER BY Id_Sucursales, Id_Empleados";
                }

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
        public DataTable Detalle_Adelantos()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
                        
            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Retiros WHERE Fecha BETWEEN '{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND '{Fecha.AddDays(6).ToString("MM/dd/yyy")}' " +
                    $" AND Id_Empleados={Empleado.Id}" +
                    $" AND Id_Tipo=100" +
                    $" ORDER BY Fecha", conexionSql);
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
        public DataTable Detalle_Resto()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Retiros WHERE Fecha BETWEEN '{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND '{Fecha.AddMonths(1).AddDays(-1).ToString("MM/dd/yyy")}' " +
                    $" AND Id_Empleados={Empleado.Id}" +
                    $" AND Id_Tipo=1" +
                    $" ORDER BY Fecha", conexionSql);
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
        public void Actualizar_Adelantos()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sql;

                if (Id != 0)
                {
                    command.CommandText =
                    $"UPDATE Retiros SET " +
                    $"  Fecha='{Fecha.ToString("MM/dd/yyy")}'" +
                    $", Id_Tipo=100" +
                    $", Id_Sucursales={Sucursal.Id}" +
                    $", Id_Empleados={Empleado.Id}" +
                    $", Importe={Importe.ToString().Replace(",", ".")} " +
                    $"  WHERE Id={Id}";

                    var d = command.ExecuteNonQuery();
                }
                else
                {
                    string s = $"DELETE FROM Retiros WHERE ";

                    switch (Fecha.Day)
                    {
                        case 7:
                            s = $"{s}  Fecha BETWEEN '{Fecha.ToString("MM/dd/yyy")}' AND '{Fecha.AddDays(6).ToString("MM/dd/yyy")}'";
                            break;
                        case 14:
                            s = $"{s}  Fecha BETWEEN '{Fecha.ToString("MM/dd/yyy")}' AND '{Fecha.AddDays(6).ToString("MM/dd/yyy")}'";
                            break;
                        case 21:
                            //Hasta fin de mes
                            s = $"{s}  Fecha BETWEEN '{Fecha.ToString("MM/dd/yyy")}' AND " +
                                $"'{Fecha.AddMonths(1).AddDays(-1).ToString("MM/dd/yyy")}'";
                            break;
                    }

                    s = $"{s} AND Id_Tipo=100" +
                    $" AND Id_Sucursales={Sucursal.Id}" +
                    $" AND Id_Empleados={Empleado.Id}";

                    sql.Open();

                    command.CommandText = s;
                    var d = command.ExecuteNonQuery();

                    command.CommandText =
                    $"INSERT INTO Retiros (Fecha, Id_Empleados, Id_Sucursales, Id_Tipo, Importe) VALUES (" +
                    $"'{Fecha.ToString("MM/dd/yyy")}'" +
                    $", {Empleado.Id}" +
                    $", {Sucursal.Id}" +
                    $", 100" +
                    $", {Importe.ToString().Replace(",", ".")})";

                    d = command.ExecuteNonQuery();
                }


                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public void Actualizar_Resto()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sql;

                if (Id != 0)
                {
                    command.CommandText =
                    $"UPDATE Retiros SET " +
                    $"  Fecha='{Fecha.ToString("MM/dd/yyy")}'" +
                    $", Id_Tipo=1" +
                    $", Id_Sucursales={Sucursal.Id}" +
                    $", Id_Empleados={Empleado.Id}" +
                    $", Importe={Importe.ToString().Replace(",", ".")} " +
                    $"  WHERE Id={Id}";

                    var d = command.ExecuteNonQuery();
                }
                else
                {
                    string s = $"DELETE FROM Retiros WHERE " +
                    $"  Fecha BETWEEN '{Fecha.ToString("MM/dd/yyy")}' AND '{Fecha.AddDays(5).ToString("MM/dd/yyy")}'" +
                    $" AND Id_Tipo=1" +
                    $" AND Id_Sucursales={Sucursal.Id}" +
                    $" AND Id_Empleados={Empleado.Id}";

                    sql.Open();

                    command.CommandText = s;
                    var d = command.ExecuteNonQuery();

                    command.CommandText =
                    $"INSERT INTO Retiros (Fecha, Id_Empleados, Id_Sucursales, Id_Tipo, Importe) VALUES (" +
                    $"'{Fecha.ToString("MM/dd/yyy")}'" +
                    $", {Empleado.Id}" +
                    $", {Sucursal.Id}" +
                    $", 1" +
                    $", {Importe.ToString().Replace(",", ".")})";

                    d = command.ExecuteNonQuery();
                }


                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public void Actualizar_Saldo(Single importe)
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sql;


                string s = $"UPDATE Mes_Temp SET Saldo={importe.ToString().Replace(",", ".")} " +
                $" WHERE Mes='{Fecha.ToString("MM/dd/yyy")}'" +
                $" AND Id_Sucursales={Sucursal.Id}" +
                $" AND Id_Empleados={Empleado.Id}";

                sql.Open();

                command.CommandText = s;
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
