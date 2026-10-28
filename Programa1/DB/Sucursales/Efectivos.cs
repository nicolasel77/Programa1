namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Efectivos : c_Base
    {
        public Efectivos()
        {
            ID_Automatico = true;
            Tabla = "dbGastos.dbo.Efectivos";
            Vista = "dbDatos.dbo.vw_Efectivos";
        }

        internal DataTable Agrupados()
        {
            return Datos_Vista("Cargado = 0", "ID_Sucursal, Nombre, SUM(Importe) AS Importe", "ID_Sucursal", "ID_Sucursal, Nombre");
        }

        internal DataTable SinCargar()
        {
            return Datos_Vista("Cargado = 0", "*", "ID_Sucursal, Fecha, ID");
        }
    }
}
