namespace Programa1.DB.Varios
{
    using Programa1.Clases;
    public class Nombre_Listas : c_Base
    {
        public Nombre_Listas()
        {
            Tabla = "Nombre_Listas";
        }

        public void Borrar_Hijos()
        {
            //Borrar sus hijitos
            Listas_Carga ls = new Listas_Carga();
            ls.Borrar("ID_Lista=" + ID);            
        }
    }
}
