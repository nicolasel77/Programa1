namespace Programa1.DB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public class Agregados_Hacienda
    {
        public Agregados_Hacienda()
        {
        }

     
        public int Id { get; set; }
        public NBoletas nb { get; set; } = new NBoletas();

        public TipoAgregados tipoAgregados = new TipoAgregados();
        public Consignatarios Consignatario { get; set; } = new Consignatarios();
        public Single Importe { get; set; }
        public int Plazo { get; set; }


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
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Agregados_Hacienda {filtro} ORDER BY Id", conexionSql);
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
