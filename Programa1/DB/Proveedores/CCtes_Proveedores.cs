using Programa1.DB;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Proveedores
{
    class CCtes_Proveedores
    {
        private Programa1.DB.Proveedores.Proveedores prov;
        public Compras Compras = new Compras();

        public CCtes_Proveedores()
        {
        }
        public CCtes_Proveedores(int prov)
        {
            this.prov.Id = prov;
        }

        public DataTable Saldos_Proveedores(DateTime fecha)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Id, Nombre, dbo.f_SaldoProveedor(Id, '{fecha.ToString("MM/dd/yy")}') AS Saldo FROM Proveedores ORDER BY Id", conexionSql);
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

        public DataTable Salidas(int prov, DateTime fecha1, DateTime fecha2)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                conexionSql.Open();
                SqlCommand comandoSql = new SqlCommand($"EXEC dbo.sp_ResumenSalidasProv {prov}, '{fecha1:MM/dd/yy}', '{fecha2:MM/dd/yy}'", conexionSql);
                comandoSql.ExecuteNonQuery();

                comandoSql = new SqlCommand($"SELECT * FROM t_ProvSalidas ORDER BY Fecha", conexionSql);
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

        public Double Saldo_Proveedor(int prov, DateTime fecha)
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;
            Double t = 0;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT dbo.f_SaldoProveedor({prov}, '{fecha:MM/dd/yy}')", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();
                t = Convert.ToDouble(d);
            }
            catch (Exception)
            {
                d = 0;
            }
            finally
            {
                conexionSql.Close();
            }

            return t;
        }

        public Double Total_Ajustes(int prov, DateTime fecha1, DateTime fecha2)
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;
            Double t = 0;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ISNULL(SUM(Importe), 0) FROM Ajustes_Proveedor WHERE ID_Proveedor={prov} AND Fecha BETWEEN '{fecha1:MM/dd/yy}' AND '{fecha2:MM/dd/yy}'", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();
                t = Convert.ToDouble(d);                
            }
            catch (Exception)
            {
                d = 0;
            }
            finally
            {
                conexionSql.Close();
            }
            
            return t;
        }

        public Double Total_Devoluciones(int prov, DateTime fecha1, DateTime fecha2)
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;
            Double t = 0;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ISNULL(SUM(Costo_Compra*Kilos), 0) FROM Devoluciones WHERE ID_Proveedores={prov} AND Fecha BETWEEN '{fecha1:MM/dd/yy}' AND '{fecha2:MM/dd/yy}'", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();
                t = Convert.ToDouble(d);
            }
            catch (Exception)
            {
                d = 0;
            }
            finally
            {
                conexionSql.Close();
            }

            return t;
        }

        public Double Ganancia_Proveedor(int prov, DateTime fecha1, DateTime fecha2)
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;
            Double t = 0;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT  dbo.f_GananciaProveedor({prov}, '{fecha1:MM/dd/yy}', '{fecha2:MM/dd/yy}')", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();
                t = Convert.ToDouble(d);
            }
            catch (Exception)
            {
                d = 0;
            }
            finally
            {
                conexionSql.Close();
            }

            return t;
        }

    }
}
