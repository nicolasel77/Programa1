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
            return Datos_Vista("Tipo = 1", "Carga, Suc, Nombre, RIGHT(N_Cuenta, 4) NCuenta, Tipo, RTRIM(Descripcion) Descripcion, Alias, Titular ", " Titular, Suc, Tipo");
        }

        public bool Cuentas_Compartidas(int suc)
        {
            if (Datos_Vista($"RIGHT(N_Cuenta, 4) IN (SELECT RIGHT(N_Cuenta, 4) FROM dbGastos.dbo.vw_SucCuentas WHERE suc = {suc} AND Tipo = 1)", "Suc", "Suc").Rows.Count > 1)
            { return true; }
            else
            { return false; }
        }
    }
}
