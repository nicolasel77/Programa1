namespace Programa1.DB.Varios
{
    using Programa1.Clases;
    using System.Data;

    public class Autor_Proveedor : c_Base
    {
        public Autor_Proveedor()
        {
            Vista = "t_PagosAutorizados";
        }
    }
    public class Pagos_Autorizados : c_Base
    {
        public Pagos_Autorizados() { Vista = "vw_PagosAutorizados"; }
        private Autor_Proveedor Autorizados_Prov { get; set; } = new Autor_Proveedor();

        public string filtro = "";
        /// <summary>
        /// Filtrar solo un Tipo
        /// </summary>
        public int f_ID = -1;

        public DataTable Datos()
        {
            if (f_ID > -1)
            {
                Ejecutar_sp("sp_PagosAutorizados", "filtro_Tipo", f_ID);
            }
            else
            {
                Ejecutar_sp("sp_PagosAutorizados");
            }
            return Datos_Vista(filtro, "*", "Venc");
        }

        public DataTable Autorizados_Proveedor(int p)
        {
            Ejecutar_sp("sp_PagosAutorizadosProveedor", "p", p);
            return Autorizados_Prov.Datos_Vista("", "CONVERT(bit, 0) Sel, Fecha, Total, Pagos, Saldo", "Fecha");
        }
    }
}
