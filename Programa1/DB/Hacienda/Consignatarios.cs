namespace Programa1.DB
{
    using Programa1.Clases;
    using System;

    public class Consignatarios : c_Base
    {
        public Consignatarios()
        {
            Tabla = "Consignatarios";
            Vista = Tabla;
        }

        /// <summary>
        /// Devuelve el ID del sistema donde ID_Frigorifico=id_frigo.
        /// </summary>
        /// <param name="id_frigo">El ID del frigorifico.</param>
        /// <returns></returns>
        public int Traducir_Consignatario(int id_frigo)
        {
            object id = Dato("ID_Frigorifico=" + id_frigo, "Id");
            
            if (id == DBNull.Value ) { id = 0; }

            return Convert.ToInt32(id);
        }
    }
}
