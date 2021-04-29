namespace Programa1.DB.Varios
{
    using Kiosko.Clases;
    using System.Data;

    class Pagos_Autorizados : c_Base
    {
        public Pagos_Autorizados() { Vista = "vw_PagosAutorizados"; }
        public string filtro = "";

        public DataTable Datos()
        {
            Ejecutar_sp("sp_PagosAutorizados");
            return Datos_Vista(filtro, "*", "Venc");
        }
    }
}
