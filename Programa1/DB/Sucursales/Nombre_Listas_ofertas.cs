namespace Programa1.DB.Sucursales
{
    using Programa1.Clases;
    class Nombre_Listas_ofertas : c_Base
    {
        public Nombre_Listas_ofertas()
        {
            Tabla = "Listas_Imp_Ofertas";
            Campo_ID = "Id_Lista";
            ID_Automatico = true;
        }

        public void Borrar_Hijos()
        {
            //Borrar sus hijitos
            Lista_Ofertas ls = new Lista_Ofertas();
            ls.Borrar("Id_Lista=" + ID);
        }
    }
}
