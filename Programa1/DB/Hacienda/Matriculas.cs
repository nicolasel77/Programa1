namespace Programa1.DB
{
    using Programa1.Clases;
    using System;

    public class Matriculas : c_Base
    {
        public Matriculas()
        {
            Tabla = "Matriculas";
            Vista = Tabla;
        }

        public void Cargar_Por_Nombre(string nombre)
        {
            object mat = Dato($"Nombre LIKE '%{nombre}%'");
            if (mat == DBNull.Value) { mat = 0; }

            ID = Convert.ToInt32(mat);
        }
    }
}
