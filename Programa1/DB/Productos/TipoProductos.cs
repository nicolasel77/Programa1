
namespace Programa1.DB
{
    using Programa1.Clases;

    public class TipoProductos : c_Base
    {
        public TipoProductos()
        {
            Tabla = "TipoProductos";
            Vista= "TipoProductos";
        }

        public TipoProductos(int id, string nombre)
        {
            ID = id;
            Nombre = nombre;
        }

        public bool ResumirPorVenta { get; set; }
        public bool Tiene_Estadistica { get; set; }


    }
}
