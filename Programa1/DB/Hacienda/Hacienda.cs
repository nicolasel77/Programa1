using System;
using System.Data;
using System.Data.SqlClient;

namespace Programa1.DB
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
                    if (dt.Rows[0]["Directo"] == DBNull.Value) { nBoletas.Actualizar("Directo", false); }
                    nBoletas.Directo = dt.Rows[0]["Directo"] == DBNull.Value ? false : Convert.ToBoolean(dt.Rows[0]["Directo"]);

                    compra.NBoleta = nBoletas; 
                }

            }
            catch (Exception)
            {
                nBoletas.ID = 0;
            }
        }

        public void Calcular_Costo()
        {
            object tCompra = compra.Dato_Sumado("NBoleta=" + compra.NBoleta.ID, "Total");
            object tAgregados = Agregados.Dato_Sumado("NBoleta=" + compra.NBoleta.ID, "Importe"); ;
            object tKilos = compra.Dato_Sumado("NBoleta=" + compra.NBoleta.ID, "Kilos"); ;

            double t = (Convert.ToDouble(tCompra) + Convert.ToDouble(tAgregados)) / Convert.ToDouble(tKilos);

            nBoletas.Costo = Convert.ToSingle(t);
        }
    }
}
