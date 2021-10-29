using System;

namespace Programa1.DB.Hacienda
{
    public class Cortes
    {
        public Cortes()
        {
            Limpiar();
        }

        public void Limpiar()
        {
            Fecha = DateTime.Now;
            Cantidad = 0;
            Importe = 0;
            Id = 0;
        }

        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public double Importe { get; set; }
    }
}