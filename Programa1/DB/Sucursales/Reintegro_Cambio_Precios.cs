namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class Reintegro_Cambio_Precios : c_Base
    {

        public Reintegro_Cambio_Precios()
        {

        }

        public DataTable Datos(DateTime fecha, int producto, float np = 0)
        {
            SqlParameter f = new SqlParameter("F", fecha);
            SqlParameter prod = new SqlParameter("prod", producto);
            SqlParameter precio = new SqlParameter("precio", np);

            DataTable dt = sp_Datos("sp_CambioPrecios", new SqlParameter[] { f, prod, precio });

            dt.Columns.Add("Reintegro", typeof(double), "(((Entrada+Traslados_E-Traslados_S+Stock)-(Venta / 8 * Dias)) * (Precio_Ant-Precio_Nuevo))");

            return dt;
        }

    }
}
