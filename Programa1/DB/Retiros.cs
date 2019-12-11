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
        public DataTable Detalle_Varios()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Retiros WHERE Fecha BETWEEN '{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND '{Fecha.AddMonths(1).AddDays(-1).ToString("MM/dd/yyy")}' " +
                    $" AND Id_Empleados={Empleado.Id}" +
                    $" AND Id_Tipo={Tipo.Id}" +
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
        public void Actualizar()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                if (Id != 0)
                {
                    command.CommandText =
                    $"UPDATE Retiros SET " +
                    $"  Fecha='{Fecha.ToString("MM/dd/yyy")}'" +
                    $", Id_Tipo={Tipo.Id}" +
                    $", Id_Sucursales={Sucursal.Id}" +
                    $", Id_Empleados={Empleado.Id}" +
                    $", Importe={Importe.ToString().Replace(",", ".")} " +
                    $"  WHERE Id={Id}";

                    var d = command.ExecuteNonQuery();
                }
                else
                {
                    command.CommandText =
                    $"INSERT INTO Retiros (Fecha, Id_Empleados, Id_Sucursales, Id_Tipo, Importe) VALUES (" +
                    $"'{Fecha.ToString("MM/dd/yyy")}'" +
                    $", {Empleado.Id}" +
                    $", {Sucursal.Id}" +
                    $", {Tipo.Id}" +
                    $", {Importe.ToString().Replace(",", ".")})";

                    var d = command.ExecuteNonQuery();
                }


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
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                if (Id != 0)
                {
                    command.CommandText = $"DELETE FROM Retiros WHERE Id={Id}";

                    var d = command.ExecuteNonQuery();
                }
                else
                {
                    string f = Fecha.ToString("MM/dd/yyy");

                    if (Fecha.Day >=1 & Fecha.Day < 14)
                    {
                        f = $" BETWEEN '{f}' AND '{Fecha.AddDays(13 - Fecha.Day).ToString("MM/dd/yyy")}'";
                    }
                    else
                    {
                        if (Fecha.Day >= 14 & Fecha.Day < 20)
                        {
                            f = $" BETWEEN '{f}' AND '{Fecha.AddDays(20 - Fecha.Day).ToString("MM/dd/yyy")}'";
                        }
                        else
                        {
                            if (Fecha.Day >= 21 & Fecha.Day < 31)
                            {
                                f = $" BETWEEN '{f}' AND '{Fecha.AddDays(30 - Fecha.Day).ToString("MM/dd/yyy")}'";
                            }
                        }
                    }

                    command.CommandText =
                    $"DELETE FROM Retiros WHERE " +
                    $"  Fecha {f} " +
                    $" AND Id_Tipo={Tipo.Id}" +
                    $" AND Id_Empleados={Empleado.Id}";
                                        
                    var d = command.ExecuteNonQuery();
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

        public int MaxId()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d;


            try
            {
                SqlCommand comandoSql = new SqlCommand("SELECT MAX(Id) FROM Retiros", conexionSql);

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
