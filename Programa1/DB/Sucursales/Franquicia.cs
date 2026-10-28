namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Franquicia : c_Base
    {
        
        public Franquicia()
        {
            Tabla = "valor_Franquicia";
            Vista = "vw_valor_Franquicia";
        }

        public DataTable valores()
        {
            var dt = new DataTable("Franquicia");
            try
            {
                dt = Datos_Vista("", "*" , "fecha, id_sucursal");
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }
        public DataTable impuestos(DateTime fecha)
        {
            var dt = new DataTable("Franquicia");
            try
            {
                //dt = Datos_Genericos($"SELECT * FROM vw_valor_impuestos WHERE fecha BETWEEN '{fecha:yyyy-MM-dd}' AND '{fecha.AddDays(6):yyyy-MM-dd}' ORDER BY fecha, id_sucursal");
                dt = Datos_Genericos($"SELECT * FROM vw_valor_impuestos ORDER BY fecha, id_sucursal");
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }
        public DataTable gastos(DateTime fecha)
        {
            var dt = new DataTable("Franquicia");
            try
            {
                //dt = Datos_Genericos($"SELECT * FROM vw_valor_gasto WHERE fecha BETWEEN '{fecha:yyyy-MM-dd}' AND '{fecha.AddDays(6):yyyy-MM-dd}' ORDER BY fecha, id_sucursal");
                dt = Datos_Genericos($"SELECT * FROM vw_valor_gasto ORDER BY fecha, id_sucursal");
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }

        internal DataTable cargasSociales(DateTime fecha)
        {
            var dt = new DataTable("Franquicia");
            try
            {
                //dt = Datos_Genericos($"SELECT * FROM vw_valor_gasto WHERE fecha BETWEEN '{fecha:yyyy-MM-dd}' AND '{fecha.AddDays(6):yyyy-MM-dd}' ORDER BY fecha, id_sucursal");
                dt = Datos_Genericos($"SELECT * FROM vw_valor_cargassociales ORDER BY fecha, id_sucursal");
            }
            catch (Exception)
            {
                dt = null;
            }
            return dt;
        }
    }
}
