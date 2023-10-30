namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cuentas : c_Base
    {
        public Cuentas() 
        {
            Tabla = "dbGastos.dbo.Suc_Cuentas";
            Vista = "dbGastos.dbo.vw_SucCuentas";
        }

        public new DataTable Datos(string filtro = "")
        {
            if (filtro != "") { filtro = $"WHERE {filtro}"; }

            return Datos_Vista($"SELECT Tipo, Titular Nombre FROM {Vista} {filtro} ORDER BY Titular GROUP BY Titular");
        }
    }
}
