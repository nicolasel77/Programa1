using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace ExtractorExtractoBancario
{
    // =========================================================================
    //  INTERFAZ BASE PARA PARSERS DE BANCOS
    // =========================================================================

    /// <summary>
    /// Cada banco implementa esta interfaz para detectar su formato y
    /// extraer cabecera + movimientos a partir de las líneas de texto del PDF.
    /// </summary>
    internal interface IBancoPdfParser
    {
        /// <summary>Nombre legible del banco (usado en consola y en Excel).</summary>
        string NombreBanco { get; }

        /// <summary>
        /// Indica si este parser puede procesar el PDF dado el texto de
        /// sus primeras páginas.
        /// </summary>
        bool Detectar(string textoPrimeraPagina);

        /// <summary>
        /// Extrae cabecera y movimientos del texto completo del PDF.
        /// </summary>
        void Extraer(List<string> lineas,
                     out CabeceraCuenta cabecera,
                     out List<Movimiento> movimientos);
    }

    // =========================================================================
    //  PARSER: BANCO PROVINCIA
    // =========================================================================

    internal class BancoProvincia : IBancoPdfParser
    {
        public string NombreBanco => "Banco Provincia";

        // Línea de movimiento Provincia:
        //   02/03/2026   CONCEPTO          1.234,56   02-03   9.876.543,21
        // Sin importe (SALDO ANTERIOR):
        //   27/02/2026   SALDO ANTERIOR                       5.171.082,91
        private static readonly Regex RegMov = new Regex(
            @"^(?<fecha>\d{2}/\d{2}/\d{4})\s{2,}(?<concepto>.+?)\s{2,}" +
            @"(?:(?<importe>-?[\d.,]+)\s{2,}(?<fvalor>\d{2}-\d{2})\s{2,})?" +
            @"(?<saldo>-?[\d.,]+)\s*$",
            RegexOptions.Compiled);

        private static readonly Regex RegCuit = new Regex(@"CUIT\s+(?<v>\d{11})", RegexOptions.Compiled);
        private static readonly Regex RegCbu = new Regex(@"CBU:\s*(?<v>\d+)", RegexOptions.Compiled);
        private static readonly Regex RegNroCuenta = new Regex(@"(?<v>\d{6}/\d)", RegexOptions.Compiled);
        private static readonly Regex RegEmitido = new Regex(@"Emitido el\s+(?<v>\d{2}/\d{2}/\d{4})", RegexOptions.Compiled);
        private static readonly Regex RegFrecuencia = new Regex(@"Frecuencia\s+(?<v>\w+)", RegexOptions.Compiled);
        private static readonly Regex RegSucursal = new Regex(@"^(?<cod>\d{4})\s*-\s*(?<nom>.+)$", RegexOptions.Compiled);
        private static readonly Regex RegTitular = new Regex(@"\b(SRL|S\.R\.L\.|SA|S\.A\.|SOCIEDAD|LTDA)\b", RegexOptions.Compiled);

        private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("es-AR");

        public bool Detectar(string texto)
        {
            return texto.Contains("Banco de la Provincia") ||
                   texto.Contains("BANCO PROVINCIA") ||
                   texto.Contains("bancoprovincia") ||
                   (texto.Contains("SALDO ANTERIOR") && Regex.IsMatch(texto, @"\d{2}/\d{2}/\d{4}"));
        }

        public void Extraer(List<string> lineas,
                            out CabeceraCuenta cabecera,
                            out List<Movimiento> movimientos)
        {
            cabecera = new CabeceraCuenta { Banco = NombreBanco };
            movimientos = new List<Movimiento>();
            bool cabOk = false;

            foreach (var linea in lineas)
            {
                // ── Cabecera ─────────────────────────────────────────────────
                if (!cabOk)
                {
                    string cuit = cabecera.Cuit;
                    TrySet(RegCuit, linea, "v", ref cuit);
                    cabecera.Cuit = cuit;

                    string cbu = cabecera.Cbu;
                    TrySet(RegCbu, linea, "v", ref cbu);
                    cabecera.Cbu = cbu;

                    string nroCuenta = cabecera.NumeroCuenta;
                    TrySet(RegNroCuenta, linea, "v", ref nroCuenta);
                    cabecera.NumeroCuenta = nroCuenta;

                    string frecuencia = cabecera.Frecuencia;
                    TrySet(RegFrecuencia, linea, "v", ref frecuencia);
                    cabecera.Frecuencia = frecuencia;

                    var mSuc = RegSucursal.Match(linea);
                    if (mSuc.Success && string.IsNullOrEmpty(cabecera.Sucursal))
                        cabecera.Sucursal = mSuc.Groups["cod"].Value + " - " +
                                            mSuc.Groups["nom"].Value.Trim();

                    var mEm = RegEmitido.Match(linea);
                    if (mEm.Success && cabecera.FechaEmision == default(DateTime))
                    {
                        DateTime d;
                        if (DateTime.TryParseExact(mEm.Groups["v"].Value, "dd/MM/yyyy",
                                Cultura, DateTimeStyles.None, out d))
                            cabecera.FechaEmision = d;
                    }

                    if ((linea.Contains("CUENTA CORRIENTE") || linea.Contains("CAJA DE AHORRO"))
                        && string.IsNullOrEmpty(cabecera.TipoCuenta))
                        cabecera.TipoCuenta = linea.Trim();

                    if (RegTitular.IsMatch(linea) && string.IsNullOrEmpty(cabecera.Titular))
                        cabecera.Titular = linea.Trim();

                    if (!string.IsNullOrEmpty(cabecera.Cuit) &&
                        cabecera.FechaEmision != default(DateTime))
                        cabOk = true;
                }

                // ── Movimientos ───────────────────────────────────────────────
                var m = RegMov.Match(linea.Trim());
                if (!m.Success) continue;

                DateTime fecha;
                if (!DateTime.TryParseExact(m.Groups["fecha"].Value, "dd/MM/yyyy",
                        Cultura, DateTimeStyles.None, out fecha)) continue;

                double saldo;
                if (!TryParseDouble(m.Groups["saldo"].Value, out saldo)) continue;

                double? importe = null;
                if (m.Groups["importe"].Success)
                {
                    double imp;
                    if (TryParseDouble(m.Groups["importe"].Value, out imp))
                        importe = imp;
                }

                movimientos.Add(new Movimiento
                {
                    Fecha = fecha,
                    Concepto = m.Groups["concepto"].Value.Trim(),
                    Importe = importe,
                    FechaValor = m.Groups["fvalor"].Value.Trim(),
                    Saldo = saldo
                });
            }

            movimientos = EliminarDuplicados(movimientos);
        }


        private static void TrySet(Regex r, string linea, string grupo, ref string campo)
        {
            if (!string.IsNullOrEmpty(campo)) return;
            var m = r.Match(linea);
            if (m.Success) campo = m.Groups[grupo].Value;
        }

        private bool TryParseDouble(string value, out double r)
        {
            string n = value.Replace(".", ",");
            try
            {
                r = Convert.ToDouble(n);
                return true;
            }
            catch (Exception)
            {
                r = 0;
            }
            return false;
        }

        private static List<Movimiento> EliminarDuplicados(List<Movimiento> lista)
        {
            var vistos = new HashSet<string>();
            var resultado = new List<Movimiento>();
            foreach (var mov in lista)
            {
                string clave = string.Format("{0:yyyyMMdd}|{1}|{2}|{3}",
                    mov.Fecha, mov.Concepto,
                    mov.Importe.HasValue ? mov.Importe.Value.ToString() : "null",
                    mov.Saldo);
                if (vistos.Add(clave)) resultado.Add(mov);
            }
            return resultado;
        }
    }

    // =========================================================================
    //  PARSER: BANCO GALICIA
    // =========================================================================

    internal class BancoGalicia : IBancoPdfParser
    {
        public string NombreBanco => "Banco Galicia";

        // Línea principal Galicia: fecha en dd/MM/yy, crédito y débito en
        // columnas separadas (una de las dos puede estar vacía), luego saldo.
        // Ejemplo:
        //   01/10/24    NAVE - VENTA CON TARJETA          7.670,28               6.375.814,36
        //   01/10/24    ING. BRUTOS S/ CRED                          -153,41      6.375.660,95
        // El saldo siempre es el último número de la línea.
        // Crédito: número positivo en su columna; Débito: número negativo.
        private static readonly Regex RegFecha = new Regex(@"^\s*(?<fecha>\d{2}/\d{2}/\d{2})\s+(?<resto>.+)$", RegexOptions.Compiled);

        // Extrae todos los números de la parte derecha de la línea
        private static readonly Regex RegNumero = new Regex(
            @"(?<n>-?[\d.]+,\d{2})",
            RegexOptions.Compiled);

        private static readonly Regex RegCuit = new Regex(@"CUIT\s+(?:del\s+\w+\s+\w+\s*:\s*)?(?<v>[\d-]+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex RegCbu = new Regex(@"CBU\s*[:\s]+(?<v>\d{22})", RegexOptions.Compiled);
        private static readonly Regex RegNroCta = new Regex(@"N[°º]\s*(?<v>[\d-]+\s*[\d-]+)", RegexOptions.Compiled);
        private static readonly Regex RegPeriodo = new Regex(@"(?<desde>\d{2}/\d{2}/\d{4})\s+(?<hasta>\d{2}/\d{2}/\d{4})", RegexOptions.Compiled);

        private static readonly CultureInfo Cultura = CultureInfo.GetCultureInfo("es-AR");

        public bool Detectar(string texto)
        {
            return texto.Contains("Galicia") ||
                   texto.Contains("GALICIA") ||
                   (texto.Contains("Resumen de Cuenta") &&
                    Regex.IsMatch(texto, @"\d{2}/\d{2}/\d{2}\s{2,}"));
        }

        public void Extraer(List<string> lineas,
                            out CabeceraCuenta cabecera,
                            out List<Movimiento> movimientos)
        {
            cabecera = new CabeceraCuenta { Banco = NombreBanco };
            movimientos = new List<Movimiento>();

            // ── Cabecera: leer primeras líneas ────────────────────────────────
            ExtraerCabecera(lineas, cabecera);

            // ── Movimientos: procesamos línea a línea con acumulación
            //    de líneas de continuación (sin fecha) ─────────────────────────
            Movimiento movPendiente = null;

            foreach (var linea in lineas)
            {
                // Saltar encabezados y pies de página
                if (EsLineaEncabezado(linea)) continue;

                var mFecha = RegFecha.Match(linea);

                if (mFecha.Success)
                {
                    // Guardar movimiento anterior si existía
                    if (movPendiente != null)
                        movimientos.Add(movPendiente);

                    DateTime fecha;
                    if (!DateTime.TryParse(mFecha.Groups["fecha"].Value,
                             Cultura, DateTimeStyles.None, out fecha))
                    {
                        movPendiente = null;
                        continue;
                    }

                    string resto = mFecha.Groups["resto"].Value;
                    movPendiente = ParsearLineaGalicia(fecha, resto);
                }
                else if (movPendiente != null)
                {
                    // Línea de continuación: agregar al concepto si es texto,
                    // ignorar si solo tiene números (ya fueron procesados)
                    string trim = linea.Trim();
                    if (!string.IsNullOrEmpty(trim) && !EsSoloNumeros(trim))
                        movPendiente.Concepto = movPendiente.Concepto + " " + trim;
                }
            }

            // Agregar el último movimiento pendiente
            if (movPendiente != null)
                movimientos.Add(movPendiente);

            movimientos = EliminarDuplicados(movimientos);
        }

        // ── Helpers privados ──────────────────────────────────────────────────

        private static Movimiento ParsearLineaGalicia(DateTime fecha, string resto)
        {
            // Extraer todos los números del final de la línea
            var matches = new List<Match>();
            var m = RegNumero.Match(resto);
            while (m.Success) { matches.Add(m); m = m.NextMatch(); }

            double saldo = 0;
            double? importe = null;

            if (matches.Count >= 2)
            {
                // Último = saldo, penúltimo = importe (crédito o débito)
                TryParseDouble(matches[matches.Count - 1].Groups["n"].Value, out saldo);
                double imp;
                if (TryParseDouble(matches[matches.Count - 2].Groups["n"].Value, out imp))
                    importe = imp;
            }
            else if (matches.Count == 1)
            {
                TryParseDouble(matches[0].Groups["n"].Value, out saldo);
            }

            // El concepto es todo el texto antes del primer número
            string concepto = resto;
            if (matches.Count > 0)
            {
                int posNumero = matches[0].Index;
                concepto = posNumero > 0
                    ? resto.Substring(0, posNumero).Trim()
                    : resto.Trim();
            }

            return new Movimiento
            {
                Fecha = fecha,
                Concepto = concepto,
                Importe = importe,
                Saldo = saldo
            };
        }

        private static void ExtraerCabecera(List<string> lineas, CabeceraCuenta cab)
        {
            bool titularSiguiente = false;

            foreach (var linea in lineas)
            {
                // El titular suele ser la primera línea de texto con SRL/SA, o
                // la línea inmediatamente tras el encabezado del documento.
                if (titularSiguiente && string.IsNullOrEmpty(cab.Titular)
                    && !string.IsNullOrWhiteSpace(linea)
                    && !EsLineaEncabezado(linea))
                {
                    cab.Titular = linea.Trim();
                    titularSiguiente = false;
                }

                if (linea.Contains("esumen de Cuenta")) { titularSiguiente = true; }

                var mCuit = RegCuit.Match(linea);
                if (mCuit.Success && string.IsNullOrEmpty(cab.Cuit))
                    cab.Cuit = mCuit.Groups["v"].Value.Replace("-", "").Replace(" ", "");

                var mCbu = RegCbu.Match(linea);
                if (mCbu.Success && string.IsNullOrEmpty(cab.Cbu))
                    cab.Cbu = mCbu.Groups["v"].Value;

                var mNro = RegNroCta.Match(linea);
                if (mNro.Success && string.IsNullOrEmpty(cab.NumeroCuenta))
                    cab.NumeroCuenta = mNro.Groups["v"].Value.Trim();

                var mPer = RegPeriodo.Match(linea);
                if (mPer.Success && cab.FechaEmision == default(DateTime))
                {
                    DateTime d;
                    if (DateTime.TryParseExact(mPer.Groups["hasta"].Value,
                            "dd/MM/yyyy", Cultura, DateTimeStyles.None, out d))
                        cab.FechaEmision = d;
                }

                if ((linea.Contains("Cuenta Corriente") || linea.Contains("Caja de Ahorro"))
                    && string.IsNullOrEmpty(cab.TipoCuenta))
                    cab.TipoCuenta = linea.Trim();

                // Titular: línea con SRL / SA / etc.
                if (Regex.IsMatch(linea, @"\b(SRL|S\.R\.L\.|SA|S\.A\.|SOCIEDAD|LTDA)\b")
                    && string.IsNullOrEmpty(cab.Titular))
                    cab.Titular = linea.Trim();

                // Dejar de buscar cabecera cuando encontramos la primera fecha
                if (Regex.IsMatch(linea, @"^\d{2}/\d{2}/\d{2}\s")) break;
            }
        }

        private static bool EsLineaEncabezado(string linea)
        {
            return linea.Contains("Resumen de Cuenta") ||
                   linea.Contains("Página") ||
                   linea.TrimStart().StartsWith("Fecha") ||
                   linea.Contains("20241031") ||  // código interno del resumen
                   linea.Trim().Length == 0;
        }

        private static bool EsSoloNumeros(string s)
        {
            return Regex.IsMatch(s, @"^[\d.,\s\-/$]+$");
        }

        private static bool TryParseDouble(string value, out double r)
        {
            if (double.TryParse(value, NumberStyles.Any, Cultura, out r)) return true;
            var n = value.Replace(".", "").Replace(",", ".");
            return double.TryParse(n, NumberStyles.Any, CultureInfo.InvariantCulture, out r);
        }

        private static List<Movimiento> EliminarDuplicados(List<Movimiento> lista)
        {
            var vistos = new HashSet<string>();
            var resultado = new List<Movimiento>();
            foreach (var mov in lista)
            {
                string clave = string.Format("{0:yyyyMMdd}|{1}|{2}|{3}",
                    mov.Fecha, mov.Concepto,
                    mov.Importe.HasValue ? mov.Importe.Value.ToString() : "null",
                    mov.Saldo);
                if (vistos.Add(clave)) resultado.Add(mov);
            }
            return resultado;
        }
    }

    // =========================================================================
    //  FACHADA PRINCIPAL: PdfExtractor
    // =========================================================================

    public static class PdfExtractor
    {
        // Lista de parsers disponibles — agregar nuevos bancos aquí
        private static readonly List<IBancoPdfParser> Parsers = new List<IBancoPdfParser>
        {
            new BancoProvincia(),
            new BancoGalicia(),
        };

        public static void Extraer(string rutaPdf,
                                   out CabeceraCuenta cabecera,
                                   out List<Movimiento> movimientos)
        {
            // 1. Leer todo el texto del PDF reconstruyendo líneas espaciales
            string textoPrimeraPagina;
            List<string> todasLasLineas = LeerLineasPdf(rutaPdf, out textoPrimeraPagina);

            // 2. Detectar qué banco es
            IBancoPdfParser parser = null;
            foreach (var p in Parsers)
            {
                if (p.Detectar(textoPrimeraPagina))
                {
                    parser = p;
                    break;
                }
            }

            // Fallback: usar Provincia como genérico
            if (parser == null)
            {
                Console.WriteLine("⚠️  Banco no reconocido, usando parser genérico.");
                parser = new BancoProvincia();
            }
            else
            {
                Console.WriteLine("   Banco detectado: " + parser.NombreBanco);
            }

            // 3. Extraer con el parser correspondiente
            parser.Extraer(todasLasLineas, out cabecera, out movimientos);
        }

        // ── Reconstrucción de líneas desde PdfPig ────────────────────────────

        private static List<string> LeerLineasPdf(string rutaPdf,
                                                   out string textoPrimeraPagina)
        {
            var todas = new List<string>();
            var primera = new StringBuilder();
            bool esPrimera = true;

            using (var pdf = PdfDocument.Open(rutaPdf))
            {
                foreach (var pagina in pdf.GetPages())
                {
                    var lineas = ReconstruirLineas(pagina);
                    todas.AddRange(lineas);

                    if (esPrimera)
                    {
                        foreach (var l in lineas) primera.AppendLine(l);
                        esPrimera = false;
                    }
                }
            }

            textoPrimeraPagina = primera.ToString();
            return todas;
        }

        private static List<string> ReconstruirLineas(Page pagina)
        {
            const double toleranciaY = 3.0;

            var grupos = new SortedDictionary<double, List<Word>>(
                             Comparer<double>.Create((a, b) => b.CompareTo(a)));

            foreach (var palabra in pagina.GetWords())
            {
                double clave = Math.Round(palabra.BoundingBox.Bottom / toleranciaY) * toleranciaY;
                if (!grupos.ContainsKey(clave))
                    grupos[clave] = new List<Word>();
                grupos[clave].Add(palabra);
            }

            var lineas = new List<string>();
            foreach (var par in grupos)
            {
                var palabras = par.Value;
                palabras.Sort((a, b) => a.BoundingBox.Left.CompareTo(b.BoundingBox.Left));

                var sb = new StringBuilder();
                double xAnterior = double.MinValue;

                foreach (var palabra in palabras)
                {
                    if (xAnterior != double.MinValue)
                    {
                        double hueco = palabra.BoundingBox.Left - xAnterior;
                        int espacios = Math.Max(1, (int)(hueco / 4.5));
                        sb.Append(new string(' ', espacios));
                    }
                    sb.Append(palabra.Text);
                    xAnterior = palabra.BoundingBox.Right;
                }

                string linea = sb.ToString();
                if (!string.IsNullOrWhiteSpace(linea))
                    lineas.Add(linea);
            }

            return lineas;
        }
    }
}