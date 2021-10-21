namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;

    class Lugares_imp : c_Base
    {
        public Lugares_imp()
        {
            Tabla = "Lugares_Imprimir_Ofertas";
            Vista = "Lugares_Imprimir_Ofertas";
            ID_Automatico = true;
        }
        public void agregar()
        {
            Agregar();
            ID = Min_ID();
        }
    }
}
