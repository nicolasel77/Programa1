using System;

namespace ExtractorExtractoBancario
{
    /// <summary>Representa un movimiento individual del extracto.</summary>
    public class Movimiento
    {
        public DateTime Fecha      { get; set; }
        public string   Concepto   { get; set; }
        /// <summary>Null para la línea de Saldo Anterior.</summary>
        public double? Importe    { get; set; }
        public string   FechaValor { get; set; }
        public double  Saldo      { get; set; }

        public Movimiento()
        {
            Concepto   = string.Empty;
            FechaValor = string.Empty;
        }
    }
}
