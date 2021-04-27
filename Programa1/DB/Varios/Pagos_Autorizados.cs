namespace Programa1.DB.Varios
{
    using Kiosko.Clases;
    using System.Data;

    class Pagos_Autorizados : c_Base
    {
        public Pagos_Autorizados() { Tabla = "Productos"; }

        public DataTable Datos()
        {
            return Datos("Ver=1");
        }
    }
}
