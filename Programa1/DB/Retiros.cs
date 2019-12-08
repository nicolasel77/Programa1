namespace Programa1.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    class Retiros
    {
        public Retiros()
        {
            //Cargar_Mes();
        }
        public Retiros(DateTime fecha, Empleados empl, Sucursales suc, TipoRetiros tipo, Single saldoant)
        {
            Mes = fecha;
            Empleado = empl;
            Sucursal = suc;
            Tipo = tipo;
            Saldo_Anterior = saldoant;
        }

        public DateTime Mes { get; set; }
        public Empleados Empleado { get; set; } = new Empleados();
        public Sucursales Sucursal { get; set; } = new Sucursales();
        public TipoRetiros Tipo { get; set; } = new TipoRetiros();
        public Single Saldo_Anterior { get; set; }
        public Single Sueldo_Mes { get; set; }
        public Single Adelanto { get; set; }
        public Single D7 { get; set; }
        public Single D14 { get; set; }
        public Single D21 { get; set; }
        public Single Resto { get; set; }
        public Single Descuento { get; set; }
        public Single Franco { get; set; }
        public Single Bono { get; set; }
        public Single Ajustes { get; set; }
        public Single Vacas { get; set; }

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

        public DataTable Datos_Mes(DateTime mes, string suc = "")
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (suc.Length > 0)
            {
                suc = $" AND ({suc})";
            }
            try
            {
                SqlCommand comandoSql = new SqlCommand($"EXEC sp_SueldosMes '{mes.ToString("MM/dd/yyy")}'", conexionSql);
                comandoSql.CommandType = CommandType.Text;
                conexionSql.Open();
                comandoSql.ExecuteNonQuery();

                comandoSql.CommandText = $"SELECT * FROM vw_MesTemp WHERE Mes='{mes.ToString("MM/dd/yyy")}' {suc} ORDER BY Id_Sucursales, Id_Empleados";
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


        //private void Cargar_Mes()
        //{
        //    DateTime f = DateTime.Today.AddDays((DateTime.Today.Day - 1) * - 1);
        //    var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
        //    SqlCommand comandoSql = new SqlCommand($"SELECT COUNT(Mes) FROM Mes_Temp WHERE Mes='{f.ToString("MM/dd/yyy")}'", conexionSql);
        //    object d = null;


        //    try
        //    {
        //        conexionSql.Open();
        //        comandoSql.CommandType = CommandType.Text;
        //        d = comandoSql.ExecuteScalar();

        //        conexionSql.Close();
        //    }
        //    catch (Exception)
        //    {
        //        d = 0;
        //    }
        //    if (Convert.ToInt32(d) == 0)
        //    {
        //        comandoSql.CommandText = $"EXEC sp_SueldosMes '{f.ToString("MM/dd/yyy")}'";
        //        comandoSql.CommandType = CommandType.Text;

        //        conexionSql.Open();
        //        comandoSql.ExecuteNonQuery();

        //    }
        //}
    }
}
