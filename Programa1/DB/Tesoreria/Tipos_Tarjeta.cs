namespace Programa1.DB.Tesoreria
{
    using Programa1.Clases;
    using System;
    using System.Data;
    public class Tipos_Tarjeta : c_Base
    {

        public Tipos_Tarjeta()
        {
            ID_Automatico = true;
            Tabla = "dbGastos.dbo.Tipo_Cuentas";
            Vista = "dbGastos.dbo.Tipo_Cuentas";
        }

        public new DataTable Datos(string filtro = "")
        {
            return Datos_Vista(filtro);
        }
    }
}