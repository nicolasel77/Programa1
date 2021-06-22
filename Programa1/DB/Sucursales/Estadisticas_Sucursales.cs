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

        public enum Tipo_Propio : byte
        {
            Sucursales = 0,
            Clientes = 1,
            Todos = 2
        }
        public Tipo_Propio Filtro_Propio = Tipo_Propio.Sucursales;
        public bool Filtro_Ver = true;

        public Double Balance()
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT dbo.f_Balance ({Suc.Id}, '{Sem.Semana:MM/dd/yy}', '{Sem.Semana.AddDays(6):MM/dd/yy}')", conexionSql);

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
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT dbo.f_TEmpleados ({Suc.Id}, '{Sem.Semana:MM/dd/yy}', '{Sem.Semana.AddDays(6):MM/dd/yy}')", conexionSql);

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

        /// <summary>
        /// Devuelve la suma de Balances de vw_Estadisticas_Sucursales.
        /// </summary>
        /// <param name="fsucs">Filtro de Propio.</param>
        /// <returns></returns>
        public Double Balances(bool fsucs = true)
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT dbo.f_SumBalances ({(fsucs ? "1" : "0")}, '{Sem.Semana:MM/dd/yy}', '{Sem.Semana.AddDays(6):MM/dd/yy}')", conexionSql);

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

        public DataTable Unica(int Top = 50)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT TOP {Top} Semana, Rend, Balance, Carne, Pollo, Granja, Men, Emb, Rec, IntVenta, IntCompra, DifInt" +
                    $", Empleados, Gastos, Ganancia, Clientes, Reintegros" +
                    $" FROM vw_Estadisticas_Sucursal WHERE " +
                    $" ID_Sucursales={Suc.Id}" +
                    $" AND Semana BETWEEN  '{Sem.Semana.AddYears(-1):MM/dd/yy}' AND '{Sem.Semana:MM/dd/yy}' ORDER BY Semana DESC", conexionSql);
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
        public DataTable Todas()
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string f = "";
                switch (Filtro_Propio)
                {
                    case Tipo_Propio.Sucursales:
                        f = "Propio=1 AND";
                        break;
                    case Tipo_Propio.Clientes:
                        f = "Propio=0 AND";
                        break;
                }
                SqlCommand comandoSql = new SqlCommand($"SELECT ID_Sucursales Suc, Nombre, Rend, Balance, Carne, Pollo, Granja, Men, Emb, Rec, IntVenta, IntCompra, DifInt" +
                    $", Empleados, Gastos, Ganancia, Clientes, Reintegros" +
                    $" FROM vw_Estadisticas_Sucursal WHERE " +
                    $" {f} {(Filtro_Ver ? "Ver=1 AND " : "")} Semana='{Sem.Semana:MM/dd/yy}' ORDER BY ID_Sucursales", conexionSql);
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

        /// <summary>
        /// Devuelve la venta por Tipo de producto de la semana/suc.
        /// </summary>
        /// <returns></returns>
        public DataTable Ventas_KilosPorTipo()
        {
            var dt = new DataTable("Ventas");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand("sp_VentasKilos", conexionSql);
                comandoSql.CommandType = CommandType.StoredProcedure;
                comandoSql.Parameters.AddWithValue("Suc", Suc.Id);
                comandoSql.Parameters.AddWithValue("F", Sem.Semana);

                conexionSql.Open();

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);
                dt.Columns.Add("Venta", typeof(Double), "St_Ant+Compra+Carne+Medias_U+TR_Ent-TR_Sal-Stock");
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }

        public DataTable Ventas_KilosProdSuc(byte semanas = 5, string filtro_Prods = "")
        {
            DataTable dt = new DataTable("Datos");

            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                string cadena = "";
                string Columnas_Semanas = "";
                Herramientas.Herramientas h = new Herramientas.Herramientas();

                if (filtro_Prods != "") { filtro_Prods = $" WHERE {filtro_Prods}"; }

                Columnas_Semanas = "";
                string suma_Semanas = "";

                DateTime fecha = Sem.Semana.AddDays(7 * (semanas - 1) * -1);

                for (int n = 1; n <= semanas; n++)
                {
                    Columnas_Semanas = h.Unir(Columnas_Semanas, $"[{fecha:dd/MM/yyyy}]", ", ");
                    suma_Semanas = h.Unir(suma_Semanas, $"[{fecha:dd/MM/yyyy}]", "+");
                    fecha = fecha.AddDays(7);
                }

                if (Suc.Id != 0)
                {
                    //cadena = $"SELECT * FROM (SELECT Prod, Nombre, CONVERT(varchar(10), FECHA, 103) AS Semana, ISNULL( Kilos, 0) AS tKilos FROM vw_VentaProductos) AS Venta " +
                    //            $" PIVOT (SUM (tKilos)" +
                    //            $" Suc={Suc.Id}" +
                    //            $" AND Semana='{Sem.Semana:MM/dd/yy}' ORDER BY Prod "; 
                }
                else
                {
                    cadena = $"SELECT * FROM (SELECT Prod, Nombre, CONVERT(varchar(10), FECHA, 103) AS Semana, ISNULL( Kilos, 0) AS tKilos FROM vw_VentaProductos) AS Venta " +
                                $" PIVOT (SUM (tKilos)" +
                                $"FOR Semana IN({Columnas_Semanas}))" +
                                $" AS VENTAS {filtro_Prods}  ORDER BY Prod";
                }

                conexionSql.Open();
                SqlCommand comandoSql = new SqlCommand(cadena, conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                dt.Columns.Add("Total", typeof(double), suma_Semanas);

                ////Limpiar el dt
                for (int i = dt.Rows.Count - 1; i > -1; i--)
                {
                    DataRow dr = dt.Rows[i];

                    if (dr["Total"] == DBNull.Value)
                    {
                        dt.Rows.RemoveAt(i);
                    }
                    else
                    {
                        if (Convert.ToDouble(dr["Total"]) == 0) { dt.Rows.RemoveAt(i); }
                    }
                }
            }
            catch (Exception)
            {
                dt = null;
            }

            return dt;
        }
    }
}
