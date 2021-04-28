namespace Programa1.DB.Varios
{
    using Kiosko.Clases;
    using System.Data;

    class Pagos_Autorizados : c_Base
    {
        public Pagos_Autorizados() { Tabla = "sp_PagosAutorizados"; }

        public DataTable Datos()
        {
            return sp_Datos();
        }
    }
}
