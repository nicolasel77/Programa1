namespace Programa1.DB.Sucursales
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    class Estadisticas_Sucursales
    {
        public Sucursales Suc = new Sucursales();
        public Semanas Sem = new Semanas();

        public Estadisticas_Sucursales()
        {
        }

        public void Guardar()
        {

        }
        
        
        public Double Balance()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT f_Balance {Suc.Id}, '{Sem.Semana:MM/dd/yy}', '{Sem.Semana.AddDays(6):MM/dd/yy}'", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }
            
            return Convert.ToDouble(d);
        }
        
        public Double Carne_Kilos()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT dbo.f_CarneKilos ({Suc.Id}, '{Sem.Semana:MM/dd/yy}', '{Sem.Semana.AddDays(6):MM/dd/yy}')", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = 0;
            }

            return Convert.ToDouble(d);
        }
        public Double Carne_Importe()
        {
            Double t = 0;
            return t;
        }
        
        public Double Pollo_Kilos()
        {
            Double t = 0;
            return t;
        }
        public Double Pollo_Importe()
        {
            Double t = 0;
            return t;
        }

        public Double Granja_Kilos()
        {
            Double t = 0;
            return t;
        }
        public Double Granja_Importe()
        {
            Double t = 0;
            return t;
        }

        public Double Menudencias_Importe()
        {
            Double t = 0;
            return t;
        }
        public Double Embutidos_Importe()
        {
            Double t = 0;
            return t;
        }
        
        public Double Integracion_Venta()
        {
            Double t = 0;
            return t;
        }
        public Double Integracion_Compra()
        {
            Double t = 0;
            return t;
        }

        public Double Empleados()
        {
            Double t = 0;
            return t;
        }

        public Double Gastos()
        {
            Double t = 0;
            return t;
        }

        public Double Ganancia()
        {
            Double t = 0;
            return t;
        }

        public Double Kilos_Compra()
        {
            Double t = 0;
            return t;
        }

        public Double Clientes()
        {
            Double t = 0;
            return t;
        }

        public Double Reintegros()
        {
            Double t = 0;
            return t;
        }


        public DataTable Completa(int Top = 50)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP {Top} * FROM Estadisticas_Sucursal WHERE " +
                    $" ID_Sucursales={Suc.Id}" +
                    $" AND Semana BETWEEN  '{Sem.Semana.AddYears(-1):MM/dd/yy}' AND '{Sem.Semana.AddMonths(1):MM/dd/yy}' ORDER BY Semana DESC", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);
                dt.Columns.Remove("ID_Sucursales");
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
    }
}
