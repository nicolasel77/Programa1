namespace Programa1.Carga.Tesoreria
{
    using ClosedXML.Excel;
    using Programa1.DB.Tesoreria;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Text;

    /// <summary>Un movimiento leído del archivo, listo para guardar en Entradas_Tarjeta.</summary>
    public class Movimiento_Tarjeta
    {
        public int Fila;
        public int Id_Tipo;
        public DateTime Fecha;
        public DateTime Fecha_Pago;
        public int Suc;
        public decimal Importe;
        public int Lote;
        public long Comprobante;
        public long Tarjeta;
    }

    public class Resultado_Lectura
    {
        public List<Movimiento_Tarjeta> Movimientos = new List<Movimiento_Tarjeta>();
        /// <summary>Problemas que impiden importar. Si hay alguno no se debe guardar.</summary>
        public List<string> Errores = new List<string>();
        /// <summary>Fila donde se encontraron los títulos (0 si no se usan).</summary>
        public int Fila_Encabezado;
        /// <summary>Filas con contenido pero sin una fecha válida (títulos, totales, etc.).</summary>
        public int Filas_Sin_Fecha;
        public string Ejemplo_Sin_Fecha = "";
        /// <summary>Filas descartadas por fecha, sucursal o estado.</summary>
        public int Filas_Filtradas;
        /// <summary>Movimientos cuya cuenta no corresponde a ninguna sucursal (quedan con sucursal 0).</summary>
        public int Sin_Sucursal;

        public bool Ok { get { return Errores.Count == 0; } }

        public decimal Total
        {
            get
            {
                decimal t = 0;
                foreach (Movimiento_Tarjeta m in Movimientos) { t += m.Importe; }
                return t;
            }
        }

        /// <summary>Texto corto con el resultado, para mostrar en pantalla.</summary>
        public string Resumen()
        {
            string s = $"{Movimientos.Count} movimientos";
            if (Fila_Encabezado > 0) { s += $", títulos en la fila {Fila_Encabezado}"; }
            if (Filas_Filtradas > 0) { s += $", {Filas_Filtradas} filas fuera del filtro"; }
            if (Filas_Sin_Fecha > 0) { s += $", {Filas_Sin_Fecha} filas sin fecha (ej. {Ejemplo_Sin_Fecha})"; }
            if (Sin_Sucursal > 0) { s += $", {Sin_Sucursal} SIN SUCURSAL"; }
            return s;
        }

        /// <summary>Los primeros errores, uno por línea.</summary>
        public string Texto_Errores(int maximo = 12)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Errores.Count && i < maximo; i++) { sb.AppendLine(Errores[i]); }
            if (Errores.Count > maximo) { sb.AppendLine($"... y {Errores.Count - maximo} más."); }
            return sb.ToString();
        }
    }

    /// <summary>
    /// Contenido de la primera hoja de un Excel (.xlsx) o de un CSV, en memoria.
    /// Cada celda es null, string, double o DateTime.
    /// </summary>
    public class Archivo_Tarjetas
    {
        public List<object[]> Filas = new List<object[]>();
        public int Columnas;
        public bool Es_Csv;

        public static Archivo_Tarjetas Abrir(string ruta)
        {
            string ext = Path.GetExtension(ruta).ToLowerInvariant();
            if (ext == ".csv" || ext == ".txt") { return Abrir_Csv(ruta); }
            return Abrir_Excel(ruta);
        }

        private static Archivo_Tarjetas Abrir_Excel(string ruta)
        {
            var a = new Archivo_Tarjetas();
            // FileShare.ReadWrite: se puede leer aunque el archivo esté abierto en Excel
            using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var libro = new XLWorkbook(fs))
            {
                IXLWorksheet hoja = libro.Worksheet(1);
                IXLRow ultimaFila = hoja.LastRowUsed();
                IXLColumn ultimaCol = hoja.LastColumnUsed();
                if (ultimaFila == null || ultimaCol == null) { return a; }

                int filas = ultimaFila.RowNumber();
                a.Columnas = ultimaCol.ColumnNumber();
                for (int i = 0; i < filas; i++) { a.Filas.Add(new object[a.Columnas]); }

                foreach (IXLCell celda in hoja.CellsUsed())
                {
                    int f = celda.Address.RowNumber - 1;
                    int c = celda.Address.ColumnNumber - 1;
                    if (f < filas && c < a.Columnas) { a.Filas[f][c] = Valor(celda); }
                }
            }
            return a;
        }

        private static object Valor(IXLCell celda)
        {
            try
            {
                XLCellValue v = celda.HasFormula ? celda.CachedValue : celda.Value;
                if (v.IsBlank) { return null; }
                if (v.IsDateTime) { return v.GetDateTime(); }
                if (v.IsNumber) { return v.GetNumber(); }
                if (v.IsText) { return v.GetText(); }
                return v.ToString();
            }
            catch (Exception)
            {
                return celda.GetString();
            }
        }

        private static Archivo_Tarjetas Abrir_Csv(string ruta)
        {
            var a = new Archivo_Tarjetas { Es_Csv = true };
            byte[] bytes;
            using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                bytes = ms.ToArray();
            }

            string texto;
            try
            {
                // UTF-8 estricto; si el archivo no es UTF-8 válido se lee como ANSI (Windows-1252)
                texto = new UTF8Encoding(false, true).GetString(bytes);
            }
            catch (Exception)
            {
                texto = Encoding.GetEncoding(1252).GetString(bytes);
            }
            if (texto.Length > 0 && texto[0] == '﻿') { texto = texto.Substring(1); }

            char sep = Separador(texto);
            var fila = new List<object>();
            var campo = new StringBuilder();
            bool comillas = false;

            for (int i = 0; i < texto.Length; i++)
            {
                char ch = texto[i];
                if (comillas)
                {
                    if (ch == '"')
                    {
                        if (i + 1 < texto.Length && texto[i + 1] == '"') { campo.Append('"'); i++; }
                        else { comillas = false; }
                    }
                    else { campo.Append(ch); }
                }
                else if (ch == '"' && campo.Length == 0) { comillas = true; }
                else if (ch == sep) { fila.Add(campo.ToString()); campo.Clear(); }
                else if (ch == '\r') { }
                else if (ch == '\n')
                {
                    fila.Add(campo.ToString()); campo.Clear();
                    a.Filas.Add(fila.ToArray());
                    fila.Clear();
                }
                else { campo.Append(ch); }
            }
            if (campo.Length > 0 || fila.Count > 0)
            {
                fila.Add(campo.ToString());
                a.Filas.Add(fila.ToArray());
            }

            foreach (object[] f in a.Filas)
            {
                if (f.Length > a.Columnas) { a.Columnas = f.Length; }
            }
            return a;
        }

        /// <summary>Elige el separador que más aparece en las primeras líneas: punto y coma, coma o tabulación.</summary>
        private static char Separador(string texto)
        {
            int pc = 0, co = 0, tab = 0, lineas = 0;
            foreach (char ch in texto)
            {
                if (ch == ';') { pc++; }
                else if (ch == ',') { co++; }
                else if (ch == '\t') { tab++; }
                else if (ch == '\n') { lineas++; if (lineas >= 10) { break; } }
            }
            if (pc >= co && pc >= tab) { return ';'; }
            if (tab >= co) { return '\t'; }
            return ',';
        }

        /// <summary>Valor de la celda (fila desde 1, columna desde 0) o null si no existe.</summary>
        public object Celda(int fila, int col)
        {
            if (fila < 1 || fila > Filas.Count || col < 0) { return null; }
            object[] f = Filas[fila - 1];
            return col < f.Length ? f[col] : null;
        }
    }

    /// <summary>
    /// Lee los movimientos de un archivo de tarjetas según un Formato_Tarjeta.
    /// No depende de la posición de las columnas cuando el formato las indica por nombre de encabezado.
    /// </summary>
    public static class Lector_Tarjetas
    {
        private static readonly CultureInfo esAR = new CultureInfo("es-AR");
        private static readonly string[] fechasIso =
        {
            "yyyy-MM-dd", "yyyy-MM-dd HH:mm", "yyyy-MM-dd HH:mm:ss", "yyyy-MM-ddTHH:mm:ss", "yyyy-MM-ddTHH:mm:ssK",
            "yyyy-MM-ddTHH:mm:ss.FFFFFFFK", "yyyy/MM/dd", "yyyy/MM/dd HH:mm:ss"
        };

        /// <summary>Cuántas filas se revisan como máximo para encontrar los títulos.</summary>
        private const int Filas_Busqueda = 100;

        /// <summary>
        /// Tipo de tarjeta según el nombre del archivo: las dos primeras cifras ("13 nave.xlsx" = 13).
        /// Si el nombre empieza con una sola cifra se toma esa ("9.xlsx" = 9). 0 si no empieza con un número.
        /// </summary>
        public static int Tipo_Del_Nombre(string ruta)
        {
            string n = Path.GetFileNameWithoutExtension(ruta).TrimStart();
            int largo = 0;
            while (largo < n.Length && largo < 2 && n[largo] >= '0' && n[largo] <= '9') { largo++; }
            return largo == 0 ? 0 : int.Parse(n.Substring(0, largo));
        }

        #region " Columnas y encabezado "

        /// <summary>Minúsculas, sin acentos ni signos, para comparar títulos y estados.</summary>
        public static string Normalizar(string s)
        {
            if (string.IsNullOrEmpty(s)) { return ""; }
            var sb = new StringBuilder();
            bool espacio = false;
            foreach (char ch in s.Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) == UnicodeCategory.NonSpacingMark) { continue; }
                if (char.IsLetterOrDigit(ch))
                {
                    if (espacio && sb.Length > 0) { sb.Append(' '); }
                    sb.Append(char.ToLowerInvariant(ch));
                    espacio = false;
                }
                else { espacio = true; }
            }
            return sb.ToString();
        }

        /// <summary>Si la columna está indicada por posición ("#12") devuelve el índice desde 0; si no, -1.</summary>
        public static int Posicion(string col)
        {
            col = (col ?? "").Trim();
            int n;
            if (col.StartsWith("#") && int.TryParse(col.Substring(1).Trim(), out n) && n > 0) { return n - 1; }
            return -1;
        }

        /// <summary>Letra de Excel de una columna (0 = A).</summary>
        public static string Letra(int col)
        {
            string s = "";
            col++;
            while (col > 0)
            {
                int r = (col - 1) % 26;
                s = (char)('A' + r) + s;
                col = (col - 1) / 26;
            }
            return s;
        }

        /// <summary>
        /// Índice (desde 0) de la columna indicada, buscándola en la fila de títulos si es por nombre.
        /// -1 si está vacía o no se encuentra.
        /// </summary>
        public static int Columna(Archivo_Tarjetas a, int filaEncabezado, string col)
        {
            col = (col ?? "").Trim();
            if (col.Length == 0) { return -1; }
            int p = Posicion(col);
            if (p >= 0) { return p; }
            if (filaEncabezado < 1 || filaEncabezado > a.Filas.Count) { return -1; }

            object[] titulos = a.Filas[filaEncabezado - 1];
            foreach (string alternativa in col.Split('|'))
            {
                string buscado = Normalizar(alternativa);
                if (buscado.Length == 0) { continue; }
                for (int c = 0; c < titulos.Length; c++)
                {
                    if (titulos[c] != null && Normalizar(Texto(titulos[c])) == buscado) { return c; }
                }
            }
            return -1;
        }

        private static string[] Columnas_Del_Formato(Formato_Tarjeta f)
        {
            return new[] { f.Col_Fecha, f.Col_Fecha_Filtro, f.Col_Fecha_Pago, f.Col_Sucursal, f.Col_Importe, f.Col_Lote,
                f.Col_Comprobante, f.Col_Tarjeta, f.Col_Estado };
        }

        /// <summary>
        /// Busca la fila de títulos: la primera donde están todas las columnas que el formato indica por nombre.
        /// Devuelve el número de fila (desde 1) o 0 si no la encuentra; en ese caso <paramref name="faltantes"/>
        /// trae los títulos que no aparecieron en la fila más parecida.
        /// Si el formato no usa nombres devuelve la fila configurada (o 0).
        /// </summary>
        public static int Buscar_Encabezado(Archivo_Tarjetas a, Formato_Tarjeta f, out List<string> faltantes)
        {
            faltantes = new List<string>();
            var porNombre = new List<string>();
            foreach (string col in Columnas_Del_Formato(f))
            {
                if (!string.IsNullOrWhiteSpace(col) && Posicion(col) < 0) { porNombre.Add(col.Trim()); }
            }
            if (porNombre.Count == 0) { return f.Fila_Encabezado; }

            List<string> mejorFaltantes = null;
            int ultima = Math.Min(a.Filas.Count, Filas_Busqueda);

            // Primero la fila configurada, después las demás
            for (int paso = 0; paso <= ultima; paso++)
            {
                int fila = paso == 0 ? f.Fila_Encabezado : paso;
                if (fila < 1 || fila > a.Filas.Count) { continue; }
                if (paso > 0 && fila == f.Fila_Encabezado) { continue; }

                var faltan = new List<string>();
                foreach (string col in porNombre)
                {
                    if (Columna(a, fila, col) < 0) { faltan.Add(col); }
                }
                if (faltan.Count == 0) { return fila; }
                if (mejorFaltantes == null || faltan.Count < mejorFaltantes.Count) { mejorFaltantes = faltan; }
            }

            // No hay fila con todos los títulos: se informan los que faltan en la más parecida
            faltantes = (mejorFaltantes != null && mejorFaltantes.Count < porNombre.Count) ? mejorFaltantes : porNombre;
            return 0;
        }

        #endregion

        #region " Conversión de valores "

        /// <summary>Texto de una celda, sin espacios alrededor. Los números enteros van sin decimales.</summary>
        public static string Texto(object v)
        {
            if (v == null) { return ""; }
            if (v is string) { return ((string)v).Trim(); }
            if (v is DateTime)
            {
                DateTime d = (DateTime)v;
                return d.TimeOfDay.Ticks == 0 ? d.ToString("dd/MM/yyyy") : d.ToString("dd/MM/yyyy HH:mm:ss");
            }
            if (v is double)
            {
                double n = (double)v;
                if (Math.Abs(n) < 9e18 && Math.Floor(n) == n) { return ((long)n).ToString(CultureInfo.InvariantCulture); }
                return n.ToString(esAR);
            }
            return v.ToString().Trim();
        }

        public static bool A_Fecha(object v, out DateTime fecha)
        {
            fecha = DateTime.MinValue;
            if (v == null) { return false; }
            if (v is DateTime) { fecha = (DateTime)v; return true; }
            if (v is double)
            {
                // Fecha guardada como número de serie de Excel (años 1955 a 2119)
                double n = (double)v;
                if (n > 20000 && n < 80000) { fecha = DateTime.FromOADate(n); return true; }
                return false;
            }

            string s = v.ToString().Trim();
            if (s.Length < 6) { return false; }
            if (DateTime.TryParseExact(s, fechasIso, CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha)) { return true; }
            // día/mes/año, con o sin hora
            return DateTime.TryParse(s, esAR, DateTimeStyles.None, out fecha);
        }

        /// <summary>
        /// Convierte un importe. Acepta "1.234,56", "1,234.56", "1234,56", "1234.56", "$ 1.234" y negativos.
        /// Con un solo punto y tres cifras detrás ("1.234") se toma como separador de miles, salvo en CSV
        /// donde el punto es decimal (así lo trataba el programa).
        /// </summary>
        public static bool A_Importe(object v, bool csv, out decimal importe)
        {
            importe = 0;
            if (v == null) { return false; }
            if (v is double)
            {
                double n = (double)v;
                if (double.IsNaN(n) || Math.Abs(n) > 1e15) { return false; }
                importe = Math.Round((decimal)n, 2);
                return true;
            }
            if (v is DateTime) { return false; }

            string s = v.ToString().Trim();
            bool negativo = s.Contains("-") || (s.StartsWith("(") && s.EndsWith(")"));
            var sb = new StringBuilder();
            int puntos = 0, comas = 0;
            foreach (char ch in s)
            {
                if (ch >= '0' && ch <= '9') { sb.Append(ch); }
                else if (ch == '.') { sb.Append(ch); puntos++; }
                else if (ch == ',') { sb.Append(ch); comas++; }
                else if (char.IsLetter(ch)) { return false; }
            }
            s = sb.ToString();
            if (s.Length == 0 || puntos + comas == s.Length) { return false; }

            int ultPunto = s.LastIndexOf('.');
            int ultComa = s.LastIndexOf(',');
            char dec = '\0';
            if (puntos > 0 && comas > 0) { dec = ultPunto > ultComa ? '.' : ','; }
            else if (comas == 1) { dec = ','; }
            else if (puntos == 1)
            {
                bool tresCifras = s.Length - ultPunto - 1 == 3;
                dec = (csv || !tresCifras) ? '.' : '\0';
            }

            var limpio = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch >= '0' && ch <= '9') { limpio.Append(ch); }
                else if (ch == dec && i == (dec == '.' ? ultPunto : ultComa)) { limpio.Append('.'); }
            }

            if (!decimal.TryParse(limpio.ToString(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out importe)) { return false; }
            importe = Math.Round(importe, 2);
            if (negativo) { importe = -importe; }
            return true;
        }

        /// <summary>Convierte a entero. Acepta "025", "123,00" y números de Excel sin decimales.</summary>
        public static bool A_Entero(object v, out long entero)
        {
            entero = 0;
            if (v == null) { return false; }
            if (v is double)
            {
                double n = (double)v;
                if (Math.Abs(n) > 9e18 || Math.Floor(n) != n) { return false; }
                entero = (long)n;
                return true;
            }
            string s = Texto(v).Replace(" ", "");
            if (long.TryParse(s, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out entero)) { return true; }

            decimal d;
            if (A_Importe(s, false, out d) && decimal.Truncate(d) == d && Math.Abs(d) < 9e18m)
            {
                entero = (long)d;
                return true;
            }
            return false;
        }

        private static List<string> Lista(string valores)
        {
            var l = new List<string>();
            foreach (string v in (valores ?? "").Split(';'))
            {
                string n = Normalizar(v);
                if (n.Length > 0) { l.Add(n); }
            }
            return l;
        }

        /// <summary>Primer número que aparece después de <paramref name="marca"/> ("VACA NEGRA SUC 31" con "SUC" = 31).</summary>
        private static bool Numero_Despues_De(string texto, string marca, out int numero)
        {
            numero = 0;
            int i = texto.IndexOf(marca, StringComparison.OrdinalIgnoreCase);
            if (i < 0) { return false; }
            i += marca.Length;
            while (i < texto.Length && !(texto[i] >= '0' && texto[i] <= '9')) { i++; }
            int ini = i;
            while (i < texto.Length && texto[i] >= '0' && texto[i] <= '9') { i++; }
            return i > ini && int.TryParse(texto.Substring(ini, i - ini), out numero);
        }

        #endregion

        /// <summary>
        /// Lee los movimientos del archivo.
        /// </summary>
        /// <param name="desde">Fecha mínima (se compara solo el día). null = sin límite.</param>
        /// <param name="hasta">Fecha máxima inclusive (se compara solo el día). null = sin límite.</param>
        /// <param name="filtroSuc">Sucursal a importar, 0 = todas.</param>
        /// <param name="buscarSuc">Devuelve la sucursal de un número de cuenta/establecimiento/terminal (0 si no existe).</param>
        public static Resultado_Lectura Leer(Archivo_Tarjetas a, Formato_Tarjeta f, DateTime? desde, DateTime? hasta,
            int filtroSuc, Func<string, int> buscarSuc)
        {
            var r = new Resultado_Lectura();

            if (string.IsNullOrWhiteSpace(f.Col_Fecha)) { r.Errores.Add("El formato no indica la columna de la fecha."); }
            if (string.IsNullOrWhiteSpace(f.Col_Importe)) { r.Errores.Add("El formato no indica la columna del importe."); }
            if (string.IsNullOrWhiteSpace(f.Col_Sucursal)) { r.Errores.Add("El formato no indica la columna de la sucursal."); }
            if (!r.Ok) { return r; }
            if (a.Filas.Count == 0) { r.Errores.Add("El archivo está vacío."); return r; }

            List<string> faltantes;
            int filaTitulos = Buscar_Encabezado(a, f, out faltantes);
            if (faltantes.Count > 0)
            {
                r.Errores.Add("No se encontraron en el archivo estas columnas: " + string.Join(", ", faltantes) +
                    ". Seguramente cambiaron los títulos: abra Formatos y elija las columnas nuevas.");
                return r;
            }
            r.Fila_Encabezado = filaTitulos;

            int cFecha = Columna(a, filaTitulos, f.Col_Fecha);
            int cFiltro = Columna(a, filaTitulos, f.Col_Fecha_Filtro);
            int cPago = Columna(a, filaTitulos, f.Col_Fecha_Pago);
            int cSuc = Columna(a, filaTitulos, f.Col_Sucursal);
            int cImporte = Columna(a, filaTitulos, f.Col_Importe);
            int cLote = Columna(a, filaTitulos, f.Col_Lote);
            int cComp = Columna(a, filaTitulos, f.Col_Comprobante);
            int cTarjeta = Columna(a, filaTitulos, f.Col_Tarjeta);
            int cEstado = Columna(a, filaTitulos, f.Col_Estado);

            List<string> validos = Lista(f.Estados_Validos);
            List<string> diaSiguiente = Lista(f.Estados_Dia_Siguiente);
            if ((validos.Count > 0 || diaSiguiente.Count > 0) && cEstado < 0)
            {
                r.Errores.Add("El formato filtra por estado pero no indica la columna del estado.");
                return r;
            }

            string marcaSuc = (f.Suc_Despues_De ?? "").Trim();
            var sucursales = new Dictionary<string, int>();
            DateTime? dDesde = desde.HasValue ? desde.Value.Date : (DateTime?)null;
            DateTime? dHasta = hasta.HasValue ? hasta.Value.Date : (DateTime?)null;

            for (int fila = filaTitulos + 1; fila <= a.Filas.Count; fila++)
            {
                object[] celdas = a.Filas[fila - 1];
                bool vacia = true;
                foreach (object o in celdas)
                {
                    if (o != null && Texto(o).Length > 0) { vacia = false; break; }
                }
                if (vacia) { continue; }

                // La fecha que decide si la fila entra en el rango
                object vFiltro = a.Celda(fila, cFiltro >= 0 ? cFiltro : cFecha);
                DateTime fFiltro;
                if (!A_Fecha(vFiltro, out fFiltro))
                {
                    r.Filas_Sin_Fecha++;
                    if (r.Ejemplo_Sin_Fecha.Length == 0) { r.Ejemplo_Sin_Fecha = $"fila {fila}: \"{Texto(vFiltro)}\""; }
                    continue;
                }
                if ((dDesde.HasValue && fFiltro.Date < dDesde.Value) || (dHasta.HasValue && fFiltro.Date > dHasta.Value))
                {
                    r.Filas_Filtradas++;
                    continue;
                }

                string estado = cEstado >= 0 ? Normalizar(Texto(a.Celda(fila, cEstado))) : "";
                if (validos.Count > 0 && !validos.Contains(estado))
                {
                    r.Filas_Filtradas++;
                    continue;
                }

                // Sucursal
                string textoSuc = Texto(a.Celda(fila, cSuc));
                int suc = 0;
                if (marcaSuc.Length > 0)
                {
                    if (!Numero_Despues_De(textoSuc, marcaSuc, out suc))
                    {
                        r.Errores.Add($"Fila {fila}: no se pudo obtener la sucursal de \"{textoSuc}\" (se busca el número después de \"{marcaSuc}\").");
                        continue;
                    }
                }
                else if (textoSuc.Length > 0)
                {
                    if (!sucursales.TryGetValue(textoSuc, out suc))
                    {
                        suc = buscarSuc != null ? buscarSuc(textoSuc) : 0;
                        sucursales[textoSuc] = suc;
                    }
                }
                if (filtroSuc != 0 && suc != filtroSuc)
                {
                    r.Filas_Filtradas++;
                    continue;
                }

                // A partir de acá la fila se importa: cualquier dato inválido es un error
                var m = new Movimiento_Tarjeta { Fila = fila, Id_Tipo = f.Id_Tipo, Suc = suc };

                if (cFiltro >= 0)
                {
                    if (!A_Fecha(a.Celda(fila, cFecha), out m.Fecha))
                    {
                        r.Errores.Add($"Fila {fila}: la fecha no es válida: \"{Texto(a.Celda(fila, cFecha))}\".");
                        continue;
                    }
                }
                else { m.Fecha = fFiltro; }
                m.Fecha = m.Fecha.Date;

                DateTime fPago;
                m.Fecha_Pago = (cPago >= 0 && A_Fecha(a.Celda(fila, cPago), out fPago)) ? fPago.Date : m.Fecha;
                if (diaSiguiente.Contains(estado)) { m.Fecha_Pago = m.Fecha.AddDays(1); }

                if (!A_Importe(a.Celda(fila, cImporte), a.Es_Csv, out m.Importe))
                {
                    r.Errores.Add($"Fila {fila}: el importe no es válido: \"{Texto(a.Celda(fila, cImporte))}\".");
                    continue;
                }

                long n;
                m.Lote = f.Lote_Fijo;
                string textoLote = Texto(a.Celda(fila, cLote));
                if (cLote >= 0 && textoLote.Length > 0)
                {
                    if (!A_Entero(a.Celda(fila, cLote), out n) || Math.Abs(n) > int.MaxValue)
                    {
                        r.Errores.Add($"Fila {fila}: el lote no es un número: \"{textoLote}\".");
                        continue;
                    }
                    m.Lote = (int)n;
                }

                m.Tarjeta = f.Tarjeta_Fijo;
                string textoTarjeta = Texto(a.Celda(fila, cTarjeta));
                if (cTarjeta >= 0 && textoTarjeta.Length > 0)
                {
                    if (!A_Entero(a.Celda(fila, cTarjeta), out n))
                    {
                        r.Errores.Add($"Fila {fila}: la tarjeta no es un número: \"{textoTarjeta}\".");
                        continue;
                    }
                    m.Tarjeta = n;
                }

                m.Comprobante = 0;
                string textoComp = Texto(a.Celda(fila, cComp));
                if (cComp >= 0 && textoComp.Length > 0)
                {
                    int largo = Math.Abs(f.Comprobante_Largo);
                    if (largo > 0 && textoComp.Length > largo)
                    {
                        textoComp = f.Comprobante_Largo > 0 ? textoComp.Substring(0, largo) : textoComp.Substring(textoComp.Length - largo);
                    }
                    if (!A_Entero(textoComp, out n))
                    {
                        r.Errores.Add($"Fila {fila}: el comprobante no es un número: \"{textoComp}\".");
                        continue;
                    }
                    m.Comprobante = n;
                }

                if (suc == 0) { r.Sin_Sucursal++; }
                r.Movimientos.Add(m);
            }

            if (r.Ok && r.Movimientos.Count == 0 && r.Filas_Filtradas == 0 && r.Filas_Sin_Fecha > 0)
            {
                r.Errores.Add($"Ninguna fila tiene una fecha válida en la columna indicada ({r.Ejemplo_Sin_Fecha}). Revise el formato.");
            }
            return r;
        }
    }
}
