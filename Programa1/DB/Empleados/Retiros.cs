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

        public Retiros(int id, DateTime fecha, Empleados empleado, Sucursales.Sucursales sucursal, TipoRetiros tipo, float importe, int dias_Vacas, int dias_Pagados)
        {
            Id = id;
            Fecha = fecha;
            Empleado = empleado;
            Sucursal = sucursal;
            Tipo = tipo;
            Importe = importe;
            Dias_Vacas = dias_Vacas;
            Dias_Pagados = dias_Pagados;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; } = new DateTime(2000, 1, 1);
        public Empleados Empleado { get; set; } = new Empleados();
        public Sucursales.Sucursales Sucursal { get; set; } = new Sucursales.Sucursales();
        public TipoRetiros Tipo { get; set; } = new TipoRetiros();
        public Single Importe { get; set; }
        public int Dias_Vacas { get; set; }
        public int Dias_Pagados { get; set; }


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
        public DataTable Retiro_Aguinaldo()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                DateTime fIni, fFin;
                if (Fecha.Month == 12)
                {
                    fIni = Fecha;
                }
                else
                {
                    fIni = Fecha.AddMonths(Fecha.Month * -1);
                }
                fIni = fIni.AddDays((fIni.Day - 1) * -1);
                fFin = fIni.AddDays(-1).AddMonths(12);

                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Retiros WHERE Fecha BETWEEN '{fIni.ToString("MM/dd/yyy")}'" +
                    $" AND '{fFin.ToString("MM/dd/yyy")}' " +
                    $" AND Id_Empleados={Empleado.Id}" +
                    $" AND Id_Tipo IN(4, 40)" +
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

        public Single Aguinaldo_Empleado()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"SELECT dbo.f_Aguinaldo('{Fecha.ToString("MM/dd/yy")}', {Empleado.Id})", sql);
                command.CommandType = CommandType.Text;
                sql.Open();
                command.Connection = sql;


                var d = command.ExecuteScalar();
                return Convert.ToSingle(d);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public Single Aguinaldo_Saldo()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"SELECT dbo.f_SaldoAguinaldo('{Fecha.ToString("MM/dd/yy")}', {Empleado.Id})", sql);
                command.CommandType = CommandType.Text;
                sql.Open();
                command.Connection = sql;


                var d = command.ExecuteScalar();
                return Convert.ToSingle(d);
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public Single Total_Adelantos()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT SUM(Importe) FROM vw_Retiros WHERE Fecha BETWEEN '{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND '{Fecha.AddDays(6).ToString("MM/dd/yyy")}' " +
                    $" AND Id_Empleados={Empleado.Id}" +
                    $" AND Id_Tipo=100", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }

            return Convert.ToSingle(d);
        }
        public Single Total_Resto()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT SUM(Importe) FROM vw_Retiros WHERE Fecha BETWEEN '{Fecha.ToString("MM/dd/yyy")}'" +
                    $" AND '{Fecha.AddMonths(1).AddDays(-1).ToString("MM/dd/yyy")}' " +
                    $" AND Id_Empleados={Empleado.Id}" +
                    $" AND Id_Tipo=1", conexionSql);

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

        public DataTable Retiro_Vacaciones()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                DateTime fIni, fFin;
                if (Fecha.Month == 12)
                {
                    fIni = Fecha;
                }
                else
                {
                    fIni = Fecha.AddMonths(Fecha.Month * -1);
                }
                fIni = fIni.AddDays((fIni.Day - 1) * -1);
                fFin = fIni.AddDays(-1).AddMonths(12);

                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Vacaciones WHERE Fecha BETWEEN '{fIni.ToString("MM/dd/yyy")}'" +
                    $" AND '{fFin.ToString("MM/dd/yyy")}' " +
                    $" AND Id_Empleados={Empleado.Id}" +
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
        public int Vacaciones_Dias()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"SELECT dbo.f_VacacionesDias('{Fecha.ToString("MM/dd/yy")}', {Empleado.Id})", sql);
                command.CommandType = CommandType.Text;
                sql.Open();
                command.Connection = sql;


                var d = command.ExecuteScalar();
                return Convert.ToInt32(d);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int Sueldo_Dia()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"SELECT dbo.f_SueldoDia('{Fecha.ToString("MM/dd/yy")}', {Empleado.Id})", sql);
                command.CommandType = CommandType.Text;
                sql.Open();
                command.Connection = sql;


                var d = command.ExecuteScalar();
                return Convert.ToInt32(d);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int Saldo_DiaVacas()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"SELECT dbo.f_SaldoDiaVacas('{Fecha.ToString("MM/dd/yy")}', {Empleado.Id})", sql);
                command.CommandType = CommandType.Text;
                sql.Open();
                command.Connection = sql;


                var d = command.ExecuteScalar();
                return Convert.ToInt32(d);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int Saldo_ImporteVacas()
        {
            SqlConnection sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand($"SELECT dbo.f_SaldoImporteVacas('{Fecha.ToString("MM/dd/yy")}', {Empleado.Id})", sql);
                command.CommandType = CommandType.Text;
                sql.Open();
                command.Connection = sql;


                var d = command.ExecuteScalar();
                return Convert.ToInt32(d);
            }
            catch (Exception)
            {
                return 0;
            }
        }


        public void Actualizar_Vacas()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                command.CommandText =
                $"DELETE FROM Detalle_Vacaciones WHERE " +
                $"Fecha='{Fecha.ToString("MM/dd/yyy")}' AND Id_Empleados={Empleado.Id}";

                var d = command.ExecuteNonQuery();

                command.CommandText =
                $"INSERT INTO Detalle_Vacaciones (Fecha, Id_Empleados, Dias, Importe, Id_Sucursales, Dias_Pagados) VALUES (" +
                $"'{Fecha.ToString("MM/dd/yyy")}'" +
                $", {Empleado.Id}" +
                $", {Dias_Vacas}" +
                $", {Importe.ToString().Replace(",", ".")}" +
                $", {Sucursal.Id}" +
                $", {Dias_Pagados})";

                d = command.ExecuteNonQuery();

                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
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

                    //Id = MaxId();
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

                    if (Fecha.Day >= 1 & Fecha.Day < 5)
                    {
                        f = $" BETWEEN '{f}' AND '{Fecha.AddDays(4 - Fecha.Day).ToString("MM/dd/yyy")}'";
                    }
                    else
                    {
                        if (Fecha.Day >= 7 & Fecha.Day < 14)
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
                    }
                    command.CommandText =
                    $"DELETE FROM Retiros WHERE " +
                    $"  Fecha {f} " +
                    $" AND Id_Tipo={Tipo.Id}" +
                    $" AND Id_Empleados={Empleado.Id}";

                    var d = command.ExecuteNonQuery();
                    Id = 0;
                }


                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }

        /// <summary>
        /// Borra los datos dentro del rango del mes (del 5 al 4 del siguiente)
        /// </summary>
        public void Borrar_Mes()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                string f = $"'{Fecha.Month.ToString()}/5/{Fecha.Year.ToString()}'";
                f = $"BETWEEN {f} AND '{Fecha.AddMonths(1).Month.ToString()}/4/{Fecha.AddMonths(1).Year.ToString()}'";
                command.CommandText =
                $"DELETE FROM Retiros WHERE " +
                $"  Fecha {f} " +
                $" AND Id_Tipo={Tipo.Id}" +
                $" AND Id_Empleados={Empleado.Id}";

                var d = command.ExecuteNonQuery();


                sql.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error");
            }
        }
        public void Borrar_Vacaciones()
        {
            var sql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.Connection = sql;
                sql.Open();

                command.CommandText =
                $"DELETE FROM Detalle_Vacaciones WHERE " +
                $"Fecha='{Fecha.ToString("MM/dd/yyy")}' AND Id_Empleados={Empleado.Id}";

                var d = command.ExecuteNonQuery();

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
                if (Fecha.Year > 2000)
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
                SqlCommand comandoSql = new SqlCommand("SELECT ISNULL(MAX(Id), 0) FROM Retiros", conexionSql);

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
