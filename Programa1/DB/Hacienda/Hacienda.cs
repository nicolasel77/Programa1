using System;
using System.Data;
using System.Data.SqlClient;

namespace Programa1.DB.Hacienda
{
    public class Hacienda
    {
        public Hacienda()
        {
        }

        public NBoletas nBoletas = new NBoletas();
        public Compra_Hacienda compra = new Compra_Hacienda();
        public Agregados_Hacienda Agregados = new Agregados_Hacienda();
        public Faena Faena = new Faena();

        public void Cargar(int nb = 0)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (nb == 0)
            {
                nb = nBoletas.ID;
            }

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM NBoletas WHERE NBoleta={nb}", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                if (dt != null)
                {
                    nBoletas.ID = nb;
                    nBoletas.Fecha = dt.Rows[0]["Fecha"] == DBNull.Value ? Convert.ToDateTime("1/1/0") : Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                    nBoletas.Reparto = dt.Rows[0]["Reparto"] == DBNull.Value ? 0 : Convert.ToInt16(dt.Rows[0]["Reparto"]);
                    nBoletas.Costo = dt.Rows[0]["Costo"] == DBNull.Value ? 0 : Convert.ToSingle(dt.Rows[0]["Costo"]);
                    nBoletas.Costo_Faena = dt.Rows[0]["Costo_Faena"] == DBNull.Value ? 0 : Convert.ToSingle(dt.Rows[0]["Costo_Faena"]);
                    nBoletas.Costo_Final = dt.Rows[0]["Costo_Final"] == DBNull.Value ? 0 : Convert.ToSingle(dt.Rows[0]["Costo_Final"]);
                    if (dt.Rows[0]["Directo"] == DBNull.Value) { nBoletas.Actualizar("Directo", false); }
                    nBoletas.Directo = dt.Rows[0]["Directo"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["Directo"]);
                    nBoletas.Kilos_Compra = dt.Rows[0]["Kilos_Compra"] == DBNull.Value ? 0 : Convert.ToDouble(dt.Rows[0]["Kilos_Compra"]);
                    nBoletas.Kilos_Faena = dt.Rows[0]["Kilos_Faena"] == DBNull.Value ? 0 : Convert.ToDouble(dt.Rows[0]["Kilos_Faena"]);
                    compra.NBoleta = nBoletas;
                }

            }
            catch (Exception)
            {
                nBoletas.ID = 0;
            }
        }

        /// <summary>
        /// Calcula el Costo para NBoleta
        /// </summary>
        public void Calcular_Costo()
        {
            compra.NBoleta = nBoletas;
            compra.NBoleta.Cargar();
            object tCompra = compra.Dato_Sumado("NBoleta=" + compra.NBoleta.ID, "Total");
            object tAgregados = Agregados.Dato_Sumado("NBoleta=" + compra.NBoleta.ID, "Importe");
            object tKilos = compra.Dato_Sumado("NBoleta=" + compra.NBoleta.ID, "Kilos");

            double t = 0;
            if (Convert.ToDouble(tKilos) != 0) { t = (Convert.ToDouble(tCompra) + Convert.ToDouble(tAgregados)) / Convert.ToDouble(tKilos); }

            nBoletas.Costo = Convert.ToSingle(t);
        }

        public DataTable Deuda_Hacienda(DateTime fecha)
        {
            SqlParameter p = new SqlParameter("Fecha", fecha);
            DataTable dt = nBoletas.sp_Datos("dbo.sp_DeudaHacienda", p);

            if (dt != null)
            {
                DataColumn dc1 = new DataColumn("Diferencia", typeof(double), "Compra+Agregados-Pagos_Compra-Pagos_Agregados");
                DataColumn dc2 = new DataColumn("Saldo", typeof(double));
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);
                double t = 0;
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    t += Convert.ToDouble(dt.Rows[i]["Compra"]);
                    t += Convert.ToDouble(dt.Rows[i]["Agregados"]);
                    t -= Convert.ToDouble(dt.Rows[i]["Pagos_Compra"]);
                    t -= Convert.ToDouble(dt.Rows[i]["Pagos_Agregados"]);
                    dt.Rows[i]["Saldo"] = t;
                }
            }
            return dt;
        }
    }
}
