using System;

namespace ExtractorExtractoBancario
{
    /// <summary>Datos de cabecera del extracto bancario.</summary>
    public class CabeceraCuenta
    {
        public string Banco { get; set; }
        public string Sucursal { get; set; }
        public string Titular { get; set; }
        public string Cuit { get; set; }
        public string Cbu { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Frecuencia { get; set; }

        public CabeceraCuenta()
        {
            Banco = string.Empty;
            Sucursal = string.Empty;
            Titular = string.Empty;
            Cuit = string.Empty;
            Cbu = string.Empty;
            NumeroCuenta = string.Empty;
            TipoCuenta = string.Empty;
            Frecuencia = string.Empty;
        }
    }
}