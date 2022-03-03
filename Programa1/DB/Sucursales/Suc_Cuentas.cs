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
            Tabla = "dbGastos.dbo.Suc_Cuentas";
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

        //public int N_Cuentas_Compartidas(int suc)
        //{
        //    return Convert.ToInt32(Dato_Generico($"SELECT COUNT(Suc) FROM {Vista} WHERE Tipo = 1 AND N_Cuenta = (SELECT TOP 1 N_Cuenta FROM Suc_Cuentas WHERE Suc = {suc})"));
        //}

        //public DataTable nccc(int suc)
        //{ 
        //return Datos_Genericos($"SELECT Suc FROM {Vista} WHERE Tipo = 1 AND N_Cuenta = (SELECT TOP 1 N_Cuenta FROM Suc_Cuentas WHERE Suc = {suc})");
        //}

        public int buscar_suc(int establecimiento)
        {
            int suc = 0;
            try
            {
                suc = Convert.ToInt32(Dato_Generico(Tabla, $" N_Cuenta = {establecimiento} ORDER BY Suc", "Suc"));
            }
            catch
            { 
            }
            return suc;
        }

    }
}
