namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Suc_Cuentas : c_Base
    {
        public Suc_Cuentas()
        {
            Vista = "dbGastos.dbo.vw_SucCuentas";
        }

        public DataTable Datos_Vista()
        {
            return Datos_Vista("", "Carga, Suc, Nombre, RIGHT(N_Cuenta, 4) NCuenta, Tipo, RTRIM(Descripcion) Descripcion, Alias, Titular ", " Titular, Suc, Tipo");
        }

    }
}
