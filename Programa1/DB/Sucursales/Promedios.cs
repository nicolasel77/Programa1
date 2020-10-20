using C1.Win.C1FlexGrid;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Programa1.DB.Sucursales
{
    class Promedios
    {
        public Promedios()
        {
        }

        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Prod { get; set; }
        public int Cant { get; set; }
        public double Kilos { get; set; }
        public double KProm { get; set; }

        #region " Devolver Datos" 
        public DataTable Listado(int id = 0)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            string filtro = "";
            if (id != 0 ) { filtro = " WHERE ID=" + id; }
            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_Promedios {filtro} ORDER BY Id", conexionSql);
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

        public DataTable Detalle_Promedio(int id = 0)
        {
            var dt = new DataTable("Datos");
            var conexionSql = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString);

            if (id == 0) { id = ID; }
            try
            {
                SqlCommand comandoSql = new SqlCommand($"SELECT * FROM vw_DetallePromedios WHERE ID={id} ORDER BY Id, Prod", conexionSql);
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

        #endregion

        #region " Editar Datos" 

        #endregion
    }
}
