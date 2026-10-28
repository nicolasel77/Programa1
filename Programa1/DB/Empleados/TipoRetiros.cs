namespace Programa1.DB
{
    using Programa1.Clases;

    public class TipoRetiros : c_Base
    {
        public TipoRetiros()
        {
            Tabla = "dbEmpleados.dbo.Tipos_Retiro";
            Campo_Nombre = "Descripcion";
        }

    }
}
