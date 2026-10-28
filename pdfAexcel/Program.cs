using System;
using System.Collections.Generic;
using System.IO;

namespace ExtractorExtractoBancario
{
    internal class Program
    {
        static int Main(string[] args)
        {
            string rutaPdf, rutaExcel;

            // ── Argumentos de línea de comandos ─────────────────────────────
            if (args.Length >= 1)
            {
                rutaPdf = args[0];
            }
            else
            {
                Console.Write("Ruta del PDF de entrada: ");
                rutaPdf = (Console.ReadLine() ?? string.Empty).Trim().Trim('"');
            }

            if (!File.Exists(rutaPdf))
            {
                Console.Error.WriteLine("❌  No se encontró el archivo: " + rutaPdf);
                return 1;
            }

            rutaExcel = args.Length >= 2
                ? args[1]
                : Path.ChangeExtension(rutaPdf, ".xlsx");

            // ── Extracción ───────────────────────────────────────────────────
            Console.WriteLine("📄  Leyendo PDF: " + rutaPdf);

            CabeceraCuenta cabecera;
            List<Movimiento> movimientos;
            PdfExtractor.Extraer(rutaPdf, out cabecera, out movimientos);

            Console.WriteLine("   Titular  : " + (string.IsNullOrEmpty(cabecera.Titular) ? "(no detectado)" : cabecera.Titular));
            Console.WriteLine("   CUIT     : " + (string.IsNullOrEmpty(cabecera.Cuit)    ? "-" : cabecera.Cuit));
            Console.WriteLine("   Cuenta   : " + (string.IsNullOrEmpty(cabecera.NumeroCuenta) ? "-" : cabecera.NumeroCuenta));

            if (movimientos.Count > 0)
                Console.WriteLine(string.Format("   Período  : {0:dd/MM/yyyy} → {1:dd/MM/yyyy}",
                    movimientos[0].Fecha, movimientos[movimientos.Count - 1].Fecha));

            Console.WriteLine("   Movimientos encontrados: " + movimientos.Count);

            // ── Generación del Excel ─────────────────────────────────────────
            Console.WriteLine("\n📊  Generando Excel...");
            ExcelWriter.Guardar(rutaExcel, cabecera, movimientos);

            return 0;
        }
    }
}
