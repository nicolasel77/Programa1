namespace Programa1.DB
{
    using Programa1.Clases;

    public class Categorias : c_Base
    {
        public Categorias()
        {
            Tabla = "Categorias";
        }

        public TipoStock tipoStock { get; set; }

    }
}
