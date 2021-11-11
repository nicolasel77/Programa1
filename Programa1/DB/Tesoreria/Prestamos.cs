using Programa1.Clases;
using System;
using System.Data;

namespace Programa1.DB.Tesoreria
{
    public class Prestamos : c_Base
    {
        public Prestamos()
        {

        }
        public DataTable Entradas(string fecha)
        {
            DataTable dt = new DataTable();
            dt = Datos_Genericos($"SELECT Fecha, IDC, Caja, ID_SubTipoEntrada, Descripcion, Importe FROM vw_Entradas WHERE ID_TipoEntrada=12 AND {fecha} ORDER BY Fecha");
            return dt;
        }

        public DataTable Pagos(string fecha)
        {
            DataTable dt = new DataTable();
            dt = Datos_Genericos($"SELECT Fecha, IDC, Caja, ID_SubTipoGastos, Desc_SubTipo, Descripcion, Importe FROM vw_Gastos WHERE ID_TipoGastos=27 AND {fecha} ORDER BY Fecha");
            return dt;
        }
    }

    
}
