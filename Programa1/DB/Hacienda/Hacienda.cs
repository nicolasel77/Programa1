using System;
using System.Data;
using System.Data.SqlClient;

namespace Programa1.DB
{
    class Hacienda
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

            if (nb == 0) nb = nBoletas.NBoleta;

            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM NBoletas WHERE NBoleta={nb} ORDER BY Id", conexionSql);
                comandoSql.CommandType = CommandType.Text;

                SqlDataAdapter SqlDat = new SqlDataAdapter(comandoSql);
                SqlDat.Fill(dt);

                nBoletas.NBoleta = nb;
                nBoletas.Fecha = Convert.ToDateTime(dt.Rows[0]["Fecha"]);
                nBoletas.Reparto = Convert.ToInt16(dt.Rows[0]["Reparto"]);
                nBoletas.Costo = Convert.ToSingle(dt.Rows[0]["Costo"]);
                nBoletas.Costo_Faena = Convert.ToSingle(dt.Rows[0]["Costo_Faena"]);
                nBoletas.Directo = Convert.ToBoolean(dt.Rows[0]["Directo"]);

                compra.NBoleta = nBoletas;
                
            }
            catch (Exception)
            {
                nBoletas.NBoleta = 0;
            }
        }
    }
}
