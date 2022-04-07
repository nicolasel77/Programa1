namespace Proveedores
{
    using Programa1.Carga.Proveedores;
    using Programa1.DB;
    using Programa1.DB.Tesoreria;
    using Programa1.DB.Varios;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class CCtes_Proveedores
    {
        public Compras Compras = new Compras();
        public Gastos gastos { get; set; } = new Gastos();
        public bool Aceptado;

        public CCtes_Proveedores()
        {
        }

        public void Cargar_Pago()
        {
            frmPagar fr = new frmPagar();
            fr.saldos = this;
            fr.gastos = gastos;
            fr.Cargar();
            fr.ShowDialog();
            Aceptado = fr.Aceptado;
        }

        public DateTime Ultima_Fecha() { return Compras.Ultima_Fecha(); }

        public DataTable Pagos_Autorizados()
        {
            Pagos_Autorizados p = new Pagos_Autorizados();
            return p.Autorizados_Proveedor(gastos.Id_SubTipoGastos);

        }

        public DataTable Detalle_Compras(string filtro = "", bool Agrupado = false)
        {
            DataTable dt;
            if (Agrupado == true)
            {
                dt = Compras.ResumenFecha_Datos(filtro);
            }
            else
            {
                dt = Compras.Datos(filtro);
            }
            return dt;
        }

        public DataTable Saldos_Proveedores(DateTime fecha)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT Id, Nombre, dbo.f_SaldoProveedor(Id, '{fecha:MM/dd/yy}') AS Saldo FROM Proveedores WHERE Ver=1 ORDER BY Id", conexionSql);
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
                SqlCommand comandoSql = new SqlCommand($"SELECT dbo.f_GananciaProveedor({prov}, '{fecha1:MM/dd/yy}', '{fecha2:MM/dd/yy}')", conexionSql);

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
