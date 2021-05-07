namespace Programa1.DB.Varios
{
    using Programa1.Clases;
    using System;
    using System.Data;

    public class Listas_Carga : c_Base
    {
        public Listas_Carga()
        {
            Tabla = "Listas_Carga";
            Vista = "vw_Listas_Carga";            "
        }
        public Productos Producto { get; set; } = new Productos();
        public int Orden { get; set; }
        public Nombre_Listas Lista { get; set; } = new Nombre_Listas();

        public DataTable Datos()
        {
            return Datos_Vista("ID_Lista=" + Lista.ID, "*", "Orden");
        }
        public DataTable Productos()
        {
            return Datos_Vista("ID_Lista=" + Lista.ID, "Producto, Nombre_Producto, ", " Orden");
        }
        public int Producto_Siguiente()
        {
            int p = Producto.ID;
            p = Convert.ToInt32(Dato($"ID_Lista={Lista.ID} AND Orden>{Orden}", "Producto, ", "Orden"));
            if (p == 0)
            {
                Producto.ID = p;
                Producto.Existe();
            }
            return Producto.ID;
        }

    }
}
