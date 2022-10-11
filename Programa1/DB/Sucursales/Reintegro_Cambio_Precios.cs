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

        public DataTable Datos(DateTime fecha, int producto, int cantidad)
        {
            SqlParameter f = new SqlParameter("F", fecha);
            SqlParameter prod = new SqlParameter("prod", producto);
            SqlParameter cant= new SqlParameter("cantPromedio", cantidad);

            DataTable dt = sp_Datos("sp_CambioPrecios", new SqlParameter[] { f, prod, cant });

            dt.Columns.Add("Reintegro", typeof(double), "((Venta+Traslados_E-Traslados_S+Stock)-(Venta_Promedio / 8 * Dias)) * (Precio_Nuevo-Precio_Ant)");

            return dt;
        }

    }
}
