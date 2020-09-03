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

        public Double Saldo_Proveedor(int prov, DateTime fecha)
        {
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);
            object d = null;


            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT dbo.f_SaldoProveedor({prov}, '{fecha:MM/dd/yy}')", conexionSql);

                conexionSql.Open();

                comandoSql.CommandType = CommandType.Text;
                d = comandoSql.ExecuteScalar();

                conexionSql.Close();
            }
            catch (Exception)
            {
                d = null;
            }
            Double t = Convert.ToDouble(d);
            return t;
        }
        public DataTable Pagos(int prov, DateTime fecha1, DateTime fecha2)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT ID, Fecha, Descripcion, Importe FROM CD_Gastos WHERE Fecha BETWEEN '{fecha1:MM/dd/yy}' AND '{fecha2:MM/dd/yy}' ORDER BY Fecha", conexionSql);
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
    }
}
