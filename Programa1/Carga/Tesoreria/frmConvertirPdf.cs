namespace Programa1.Carga.Tesoreria
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.parser;
    using OfficeOpenXml;
    using OfficeOpenXml.Table;
    using UglyToad.PdfPig;
    using UglyToad.PdfPig.Content;
    using System.Text.RegularExpressions;
    using System.Data;
    using System.Windows.Forms;

    public partial class frmConvertirPdf : Form
    {
        public enum ConversionMethod
        {
            ITextSharp,
            PdfPig,
            Auto
        }

        public frmConvertirPdf()
        {
            InitializeComponent();
        }

        private void cmdConvertir_Click(object sender, EventArgs e)
        {
            BatchConvertPdfs("D:\\Laburo\\pdfs\\Galicia", "D:\\Laburo\\pdfs\\Galicia");
        }

        /// <summary>
        /// Convierte PDF a Excel usando iTextSharp
        /// </summary>
        public static bool ConvertPdfToExcelITextSharp(string pdfPath, string excelPath)
        {
            try
            {
                Console.WriteLine($"🔄 Convirtiendo con iTextSharp: {"D:\\Laburo\\pdfs\\Galicia.pdf"}");

                // Configurar EPPlus para uso no comercial
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Datos PDF");

                    using (var reader = new PdfReader(pdfPath))
                    {
                        var allText = new List<string>();

                        // Extraer texto de todas las páginas
                        for (int page = 1; page <= reader.NumberOfPages; page++)
                        {
                            var pageText = PdfTextExtractor.GetTextFromPage(reader, page);
                            if (!string.IsNullOrWhiteSpace(pageText))
                            {
                                var lines = pageText.Split('\n')
                                    .Where(line => !string.IsNullOrWhiteSpace(line))
                                    .Select(line => line.Trim())
                                    .ToList();

                                allText.AddRange(lines);
                            }
                        }

                        // Intentar detectar estructura tabular
                        var tableData = DetectTableStructure(allText);

                        if (tableData.Rows.Count > 0)
                        {
                            // Escribir como tabla
                            WriteDataTableToWorksheet(worksheet, tableData);
                        }
                        else
                        {
                            // Escribir como texto simple
                            WriteTextToWorksheet(worksheet, allText);
                        }
                    }

                    // Guardar archivo Excel
                    var file = new FileInfo(excelPath);
                    package.SaveAs(file);
                }

                Console.WriteLine($"✅ Conversión exitosa: {excelPath}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error con iTextSharp: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Convierte PDF a Excel usando PdfPig
        /// </summary>
        public static bool ConvertPdfToExcelPdfPig(string pdfPath, string excelPath)
        {
            try
            {
                Console.WriteLine($"🔄 Convirtiendo con PdfPig: {System.IO.Path.GetFileName(pdfPath)}");

                //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    //using (var document = PdfDocument.Open(pdfPath))
                    using (var document = UglyToad.PdfPig.PdfDocument.Open(pdfPath))
                    {
                        var allWords = new List<Word>();
                        var pageTexts = new List<string>();

                        // Procesar cada página
                        for (int pageNum = 1; pageNum <= document.NumberOfPages; pageNum++)
                        {
                            var page = document.GetPage(pageNum);
                            var words = page.GetWords().ToList();
                            allWords.AddRange(words);

                            // Extraer texto de la página
                            var pageText = string.Join(" ", words.Select(w => w.Text));
                            pageTexts.Add(pageText);

                            // Crear hoja por página si hay mucho contenido
                            if (document.NumberOfPages > 1)
                            {
                                var worksheet = package.Workbook.Worksheets.Add($"Página {pageNum}");
                                ProcessPageWords(worksheet, words);
                            }
                        }

                        // Si es un documento de una página o queremos todo junto
                        if (document.NumberOfPages == 1)
                        {
                            var worksheet = package.Workbook.Worksheets.Add("Datos PDF");
                            ProcessPageWords(worksheet, allWords);
                        }
                        else
                        {
                            // Crear hoja resumen
                            var summaryWorksheet = package.Workbook.Worksheets.Add("Resumen");
                            var allLines = pageTexts.SelectMany(text =>
                                text.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries))
                                .ToList();
                            WriteTextToWorksheet(summaryWorksheet, allLines);
                        }
                    }

                    var file = new FileInfo(excelPath);
                    package.SaveAs(file);
                }

                Console.WriteLine($"✅ Conversión exitosa: {excelPath}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error con PdfPig: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Procesa palabras de una página y las organiza en Excel
        /// </summary>
        private static void ProcessPageWords(ExcelWorksheet worksheet, List<Word> words)
        {
            if (!words.Any()) return;

            // Agrupar palabras por líneas aproximadas (usando coordenada Y)
            var lineGroups = words
                .GroupBy(w => Math.Round(w.BoundingBox.Bottom, 1))
                .OrderByDescending(g => g.Key) // De arriba hacia abajo
                .ToList();

            int row = 1;
            foreach (var lineGroup in lineGroups)
            {
                var lineWords = lineGroup.OrderBy(w => w.BoundingBox.Left).ToList();

                // Intentar detectar columnas
                var columns = DetectColumns(lineWords);

                for (int col = 0; col < columns.Count; col++)
                {
                    if (!string.IsNullOrWhiteSpace(columns[col]))
                    {
                        worksheet.Cells[row, col + 1].Value = columns[col];
                    }
                }
                row++;
            }

            // Autoajustar columnas
            worksheet.Cells.AutoFitColumns();
        }

        /// <summary>
        /// Detecta columnas en una línea de palabras
        /// </summary>
        private static List<string> DetectColumns(List<Word> words)
        {
            if (!words.Any()) return new List<string>();

            var columns = new List<string>();
            var currentColumn = new StringBuilder();
            double lastX = words.First().BoundingBox.Left;

            foreach (var word in words)
            {
                double currentX = word.BoundingBox.Left;

                // Si hay un salto significativo en X, es probablemente una nueva columna
                if (currentX - lastX > 50) // Umbral ajustable
                {
                    columns.Add(currentColumn.ToString().Trim());
                    currentColumn.Clear();
                }

                if (currentColumn.Length > 0)
                    currentColumn.Append(" ");

                currentColumn.Append(word.Text);
                lastX = word.BoundingBox.Right;
            }

            // Agregar la última columna
            if (currentColumn.Length > 0)
            {
                columns.Add(currentColumn.ToString().Trim());
            }

            return columns;
        }

        /// <summary>
        /// Intenta detectar estructura tabular en el texto
        /// </summary>
        private static DataTable DetectTableStructure(List<string> lines)
        {
            var dataTable = new DataTable();

            if (!lines.Any()) return dataTable;

            // Buscar patrones que indiquen tablas
            var potentialHeaders = lines.Take(10)
                .Where(line => Regex.IsMatch(line, @"^[A-Za-z\s]+(\s{2,}[A-Za-z\s]+)+$"))
                .FirstOrDefault();

            if (potentialHeaders != null)
            {
                // Detectar separadores (espacios múltiples o tabs)
                var headers = Regex.Split(potentialHeaders, @"\s{2,}|\t")
                    .Where(h => !string.IsNullOrWhiteSpace(h))
                    .Select(h => h.Trim())
                    .ToList();

                // Crear columnas
                foreach (var header in headers)
                {
                    dataTable.Columns.Add(header);
                }

                // Procesar filas de datos
                var headerIndex = lines.IndexOf(potentialHeaders);
                var dataLines = lines.Skip(headerIndex + 1).Take(50); // Limitar para prueba

                foreach (var line in dataLines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var values = Regex.Split(line, @"\s{2,}|\t")
                        .Where(v => !string.IsNullOrWhiteSpace(v))
                        .Select(v => v.Trim())
                        .ToList();

                    if (values.Count == headers.Count)
                    {
                        var row = dataTable.NewRow();
                        for (int i = 0; i < values.Count; i++)
                        {
                            row[i] = values[i];
                        }
                        dataTable.Rows.Add(row);
                    }
                }
            }

            return dataTable;
        }

        /// <summary>
        /// Escribe DataTable a la hoja de Excel
        /// </summary>
        private static void WriteDataTableToWorksheet(ExcelWorksheet worksheet, DataTable dataTable)
        {
            // Escribir encabezados
            for (int col = 0; col < dataTable.Columns.Count; col++)
            {
                worksheet.Cells[1, col + 1].Value = dataTable.Columns[col].ColumnName;
                worksheet.Cells[1, col + 1].Style.Font.Bold = true;
            }

            // Escribir datos
            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = dataTable.Rows[row][col]?.ToString();
                }
            }

            // Crear tabla Excel
            if (dataTable.Rows.Count > 0)
            {
                var tableRange = worksheet.Cells[1, 1, dataTable.Rows.Count + 1, dataTable.Columns.Count];
                var table = worksheet.Tables.Add(tableRange, "TablaData");
                table.TableStyle = TableStyles.Medium2;
            }

            worksheet.Cells.AutoFitColumns();
        }

        /// <summary>
        /// Escribe texto simple a la hoja de Excel
        /// </summary>
        private static void WriteTextToWorksheet(ExcelWorksheet worksheet, List<string> lines)
        {
            worksheet.Cells[1, 1].Value = "Línea";
            worksheet.Cells[1, 2].Value = "Contenido";
            worksheet.Cells[1, 1, 1, 2].Style.Font.Bold = true;

            for (int i = 0; i < lines.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = i + 1;
                worksheet.Cells[i + 2, 2].Value = lines[i];
            }

            worksheet.Cells.AutoFitColumns();
        }

        /// <summary>
        /// Método principal de conversión
        /// </summary>
        public static bool ConvertPdfToExcel(string pdfPath, string excelPath = null, ConversionMethod method = ConversionMethod.Auto)
        {
            if (!File.Exists(pdfPath))
            {
                Console.WriteLine($"❌ El archivo PDF no existe: {pdfPath}");
                return false;
            }

            // Generar ruta de salida si no se proporciona
            if (string.IsNullOrEmpty(excelPath))
            {
                excelPath = System.IO.Path.ChangeExtension(pdfPath, ".xlsx");
            }

            Console.WriteLine($"📄 Archivo origen: {pdfPath}");
            Console.WriteLine($"📊 Archivo destino: {excelPath}");

            switch (method)
            {
                case ConversionMethod.ITextSharp:
                    return ConvertPdfToExcelITextSharp(pdfPath, excelPath);

                case ConversionMethod.PdfPig:
                    return ConvertPdfToExcelPdfPig(pdfPath, excelPath);

                case ConversionMethod.Auto:
                default:
                    Console.WriteLine("🤖 Modo automático: probando diferentes métodos...\n");

                    // Intentar PdfPig primero (más moderno)
                    if (ConvertPdfToExcelPdfPig(pdfPath, excelPath))
                        return true;

                    Console.WriteLine("🔄 Intentando con iTextSharp...");
                    return ConvertPdfToExcelITextSharp(pdfPath, excelPath);
            }
        }

        /// <summary>
        /// Convierte múltiples PDFs en un directorio
        /// </summary>
        public static void BatchConvertPdfs(string inputDirectory, string outputDirectory = null)
        {
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine($"❌ El directorio no existe: {inputDirectory}");
                return;
            }

            var pdfFiles = Directory.GetFiles(inputDirectory, "*.pdf");

            if (pdfFiles.Length == 0)
            {
                Console.WriteLine($"❌ No se encontraron archivos PDF en: {inputDirectory}");
                return;
            }

            // Configurar directorio de salida
            if (string.IsNullOrEmpty(outputDirectory))
            {
                outputDirectory = System.IO.Path.Combine(inputDirectory, "ConvertedExcel");
            }

            Directory.CreateDirectory(outputDirectory);

            Console.WriteLine($"📂 Procesando {pdfFiles.Length} archivos PDF...");
            Console.WriteLine($"📁 Directorio de salida: {outputDirectory}\n");

            int successful = 0;
            int failed = 0;

            foreach (var pdfFile in pdfFiles)
            {
                var fileName = System.IO.Path.GetFileNameWithoutExtension(pdfFile);
                var excelPath = System.IO.Path.Combine(outputDirectory, $"{fileName}.xlsx");

                Console.WriteLine(new string('=', 50));

                if (ConvertPdfToExcel(pdfFile, excelPath))
                {
                    successful++;
                }
                else
                {
                    failed++;
                }

                Console.WriteLine();
            }

            Console.WriteLine($"📊 Resumen de conversión:");
            Console.WriteLine($"   ✅ Exitosos: {successful}");
            Console.WriteLine($"   ❌ Fallidos: {failed}");
            Console.WriteLine($"   📁 Archivos guardados en: {outputDirectory}");
        }
    }

    /// <summary>
    /// Programa principal para ejemplos de uso
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🔄 Convertidor PDF a Excel en C#");
            Console.WriteLine(new string('=', 40));

            if (args.Length == 0)
            {
                Console.WriteLine("Uso:");
                Console.WriteLine("  PdfToExcelConverter.exe archivo.pdf [salida.xlsx] [método]");
                Console.WriteLine("  PdfToExcelConverter.exe directorio\\ [directorio_salida\\] batch");
                Console.WriteLine();
                Console.WriteLine("Métodos disponibles:");
                Console.WriteLine("  - iTextSharp: Usando librería iTextSharp");
                Console.WriteLine("  - PdfPig: Usando librería PdfPig (recomendado)");
                Console.WriteLine("  - Auto: Prueba automáticamente (por defecto)");
                Console.WriteLine();
                Console.WriteLine("Ejemplos:");
                Console.WriteLine("  PdfToExcelConverter.exe documento.pdf");
                Console.WriteLine("  PdfToExcelConverter.exe documento.pdf resultado.xlsx PdfPig");
                Console.WriteLine("  PdfToExcelConverter.exe C:\\PDFs\\ C:\\Excel\\ batch");
                return;
            }

            var inputPath = args[0];

            // Verificar si es procesamiento por lotes
            if (args.Length > 1 && args[args.Length - 1].ToLower() == "batch")
            {
                var outputDir = args.Length > 2 ? args[1] : null;
                //PdfToExcelConverter.BatchConvertPdfs(inputPath, outputDir);
            }
            else
            {
                // Procesamiento de archivo único
                var outputPath = args.Length > 1 ? args[1] : null;
                var methodStr = args.Length > 2 ? args[2] : "Auto";

                //if (Enum.TryParse<PdfToExcelConverter.ConversionMethod>(methodStr, true, out var method))
                //{
                //    PdfToExcelConverter.ConvertPdfToExcel(inputPath, outputPath, method);
                //}
                //else
                //{
                //    Console.WriteLine($"❌ Método no válido: {methodStr}");
                //    Console.WriteLine("Métodos disponibles: iTextSharp, PdfPig, Auto");
                //}
            }

            Console.WriteLine("\n✨ Proceso completado. Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
