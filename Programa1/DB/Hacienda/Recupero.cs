using Programa1.Clases;
using System;

namespace Programa1.DB
{
    public class Recupero : c_Base
    {
        public Recupero()
        {
            Tabla = "Recuperos";
            Vista = "vw_Recuperos";
        }

        public DateTime Fecha{ get; set; }

        public Productos Producto { get; set; }
        public Frigorificos Frigorifico { get; set; }
        public bool Mercado { get; set; }
        public Single Valor{ get; set; }

        

        public Single Buscar(DateTime fecha, int prod, int frigo, bool mercado)
        {
            string m = mercado ? "1" : "0";
            object d = Dato($"Fecha<='{fecha:MM/dd/yy}' AND ID_Productos={prod} AND ID_Frigorificos={frigo} AND Mercado={m}", "Recupero", "Fecha DESC");

            if (d == DBNull.Value) { d = 0; }

            return Convert.ToSingle(d);
        }
    }
}
