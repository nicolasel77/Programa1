using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;

namespace ExtractorExtractoBancario
{
    public static class ExcelWriter
    {
        private static readonly XLColor ColorEncabezado = XLColor.FromHtml("#1F4E79");
        private static readonly XLColor ColorSubEncabezado = XLColor.FromHtml("#2E75B6");
        private static readonly XLColor ColorFilaAlterna = XLColor.FromHtml("#D6E4F0");
        private static readonly XLColor ColorPositivo = XLColor.FromHtml("#C6EFCE");
        private static readonly XLColor ColorNegativo = XLColor.FromHtml("#FFC7CE");

        public static void Guardar(string rutaSalida,
                                   CabeceraCuenta cabecera,
                                   List<Movimiento> movimientos)
        {
            using (var wb = new XLWorkbook())
            {
                EscribirHojaMovimientos(wb, cabecera, movimientos);
                EscribirHojaResumen(wb, movimientos);
                wb.SaveAs(rutaSalida);
            }

            Console.WriteLine("\n✅  Excel generado: " + rutaSalida);
        }

        // ── Hoja Movimientos ─────────────────────────────────────────────────

        private static void EscribirHojaMovimientos(XLWorkbook wb,
                                                     CabeceraCuenta cab,
                                                     List<Movimiento> movimientos)
        {
            var ws = wb.Worksheets.Add("Movimientos");
            int fila = 1;

            // Título principal
            string tituloPagina = "EXTRACTO DE CUENTA CORRIENTE - " + (cab != null && !string.IsNullOrEmpty(cab.Banco) ? cab.Banco.ToUpper() : "BANCO");
            ws.Cell(fila, 1).Value = tituloPagina;
            ws.Range(fila, 1, fila, 5).Merge();
            ws.Cell(fila, 1).Style
               .Font.SetBold(true)
               .Font.SetFontSize(14)
               .Font.SetFontColor(XLColor.White)
               .Fill.SetBackgroundColor(ColorEncabezado)
               .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            fila++;

            // Datos de cabecera
            if (cab != null)
            {
                var datos = new[]
                {
                    new[] { "Banco",          cab.Banco },
                    new[] { "Sucursal",       cab.Sucursal },
                    new[] { "Titular",        cab.Titular },
                    new[] { "CUIT",           cab.Cuit },
                    new[] { "CBU",            cab.Cbu },
                    new[] { "N° de Cuenta",   cab.NumeroCuenta },
                    new[] { "Tipo de Cuenta", cab.TipoCuenta },
                    new[] { "Fecha Emisión",  cab.FechaEmision.ToString("dd/MM/yyyy") },
                    new[] { "Frecuencia",     cab.Frecuencia },
                };

                foreach (var par in datos)
                {
                    ws.Cell(fila, 1).Value = par[0];
                    ws.Cell(fila, 1).Style
                       .Font.SetBold(true)
                       .Fill.SetBackgroundColor(ColorSubEncabezado)
                       .Font.SetFontColor(XLColor.White);
                    ws.Cell(fila, 2).Value = par[1];
                    ws.Range(fila, 2, fila, 5).Merge();
                    fila++;
                }
            }

            fila++; // fila en blanco

            // Encabezados de columna
            string[] cols = { "Fecha", "Concepto", "Importe", "Fecha Valor", "Saldo" };
            for (int c = 0; c < cols.Length; c++)
            {
                ws.Cell(fila, c + 1).Value = cols[c];
                ws.Cell(fila, c + 1).Style
                   .Font.SetBold(true)
                   .Font.SetFontColor(XLColor.White)
                   .Fill.SetBackgroundColor(ColorEncabezado)
                   .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                   .Border.SetBottomBorder(XLBorderStyleValues.Medium);
            }
            fila++;

            int filaInicio = fila;
            bool alternar = false;

            foreach (var mov in movimientos)
            {
                var colorFila = alternar ? ColorFilaAlterna : XLColor.White;

                // Fecha
                ws.Cell(fila, 1).Value = mov.Fecha;
                ws.Cell(fila, 1).Style.DateFormat.Format = "dd/mm/yyyy";
                ws.Cell(fila, 1).Style.Fill.SetBackgroundColor(colorFila);

                // Concepto
                ws.Cell(fila, 2).Value = mov.Concepto;
                ws.Cell(fila, 2).Style.Fill.SetBackgroundColor(colorFila);

                // Importe
                if (mov.Importe.HasValue)
                {
                    ws.Cell(fila, 3).Value = (double)mov.Importe.Value;
                    ws.Cell(fila, 3).Style.NumberFormat.Format = "#,##0.00";
                    ws.Cell(fila, 3).Style.Fill.SetBackgroundColor(
                        mov.Importe.Value >= 0 ? ColorPositivo : ColorNegativo);
                }

                // Fecha Valor
                ws.Cell(fila, 4).Value = mov.FechaValor;
                ws.Cell(fila, 4).Style
                   .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                   .Fill.SetBackgroundColor(colorFila);

                // Saldo
                ws.Cell(fila, 5).Value = (double)mov.Saldo;
                ws.Cell(fila, 5).Style.NumberFormat.Format = "#,##0.00";
                ws.Cell(fila, 5).Style.Fill.SetBackgroundColor(colorFila);

                // Borde inferior suave
                ws.Range(fila, 1, fila, 5).Style
                   .Border.SetBottomBorder(XLBorderStyleValues.Hair)
                   .Border.SetBottomBorderColor(XLColor.LightGray);

                alternar = !alternar;
                fila++;
            }

            // Borde exterior de la tabla de datos
            if (movimientos.Count > 0)
                ws.Range(filaInicio - 1, 1, fila - 1, 5).Style
                   .Border.SetOutsideBorder(XLBorderStyleValues.Medium)
                   .Border.SetOutsideBorderColor(ColorEncabezado);

            // Anchos de columna
            ws.Column(1).Width = 14;
            ws.Column(2).Width = 55;
            ws.Column(3).Width = 18;
            ws.Column(4).Width = 14;
            ws.Column(5).Width = 18;

            // Congelar hasta la fila de encabezados de columna
            ws.SheetView.FreezeRows(filaInicio - 1);
        }

        // ── Hoja Resumen ─────────────────────────────────────────────────────

        private static void EscribirHojaResumen(XLWorkbook wb,
                                                 List<Movimiento> movimientos)
        {
            var ws = wb.Worksheets.Add("Resumen");

            var conImporte = movimientos.Where(m => m.Importe.HasValue).ToList();
            var creditos = conImporte.Where(m => m.Importe.Value > 0).ToList();
            var debitos = conImporte.Where(m => m.Importe.Value < 0).ToList();

            double saldoInicial = 0;
            double saldoFinal = 0;
            if (movimientos.Count > 0)
            {
                var primero = movimientos[0];
                saldoInicial = primero.Saldo - (primero.Importe ?? 0);
                saldoFinal = movimientos[movimientos.Count - 1].Saldo;
            }

            // Título
            ws.Cell(1, 1).Value = "RESUMEN DEL EXTRACTO";
            ws.Range(1, 1, 1, 2).Merge();
            ws.Cell(1, 1).Style
               .Font.SetBold(true).Font.SetFontSize(13)
               .Font.SetFontColor(XLColor.White)
               .Fill.SetBackgroundColor(ColorEncabezado)
               .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            // Estadísticas generales — se escribe cada fila con tipo explícito
            // para evitar la ambigüedad de XLCellValue en ClosedXML 0.100.x
            int fila = 2;
            bool alt = false;

            EscribirFilaResumenTexto(ws, fila++, ref alt, "Total movimientos", movimientos.Count);
            EscribirFilaResumenTexto(ws, fila++, ref alt, "Total créditos (ingresos)", creditos.Count);
            EscribirFilaResumenTexto(ws, fila++, ref alt, "Total débitos (egresos)", debitos.Count);
            EscribirFilaResumenNumero(ws, fila++, ref alt, "Suma de créditos", (double)creditos.Sum(m => m.Importe.Value));
            EscribirFilaResumenNumero(ws, fila++, ref alt, "Suma de débitos", (double)debitos.Sum(m => m.Importe.Value));
            EscribirFilaResumenNumero(ws, fila++, ref alt, "Saldo neto del período", (double)conImporte.Sum(m => m.Importe.Value));
            EscribirFilaResumenNumero(ws, fila++, ref alt, "Saldo inicial", (double)saldoInicial);
            EscribirFilaResumenNumero(ws, fila++, ref alt, "Saldo final", (double)saldoFinal);

            // Tabla de movimientos por tipo de concepto
            fila++;
            ws.Cell(fila, 1).Value = "MOVIMIENTOS POR TIPO DE CONCEPTO";
            ws.Range(fila, 1, fila, 3).Merge();
            ws.Cell(fila, 1).Style
               .Font.SetBold(true).Font.SetFontColor(XLColor.White)
               .Fill.SetBackgroundColor(ColorSubEncabezado)
               .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            fila++;

            ws.Cell(fila, 1).Value = "Concepto";
            ws.Cell(fila, 2).Value = "Cantidad";
            ws.Cell(fila, 3).Value = "Total";
            ws.Range(fila, 1, fila, 3).Style
               .Font.SetBold(true).Font.SetFontColor(XLColor.White)
               .Fill.SetBackgroundColor(ColorEncabezado);
            fila++;

            var porConcepto = conImporte
                .GroupBy(m => ClasificarConcepto(m.Concepto))
                .OrderBy(g => g.Key)
                .ToList();

            alt = false;
            foreach (var grupo in porConcepto)
            {
                var bg = alt ? ColorFilaAlterna : XLColor.White;
                ws.Cell(fila, 1).Value = grupo.Key;
                ws.Cell(fila, 2).Value = grupo.Count();
                ws.Cell(fila, 3).Value = (double)grupo.Sum(m => m.Importe.Value);
                ws.Cell(fila, 3).Style.NumberFormat.Format = "#,##0.00";
                ws.Range(fila, 1, fila, 3).Style.Fill.SetBackgroundColor(bg);
                alt = !alt;
                fila++;
            }

            ws.Column(1).Width = 35;
            ws.Column(2).Width = 20;
            ws.Column(3).Width = 20;
        }

        // ── Clasificación de conceptos ───────────────────────────────────────

        private static void EscribirFilaResumenTexto(IXLWorksheet ws, int fila, ref bool alt, string etiqueta, int valor)
        {
            var bg = alt ? ColorFilaAlterna : XLColor.White;
            ws.Cell(fila, 1).Value = etiqueta;
            ws.Cell(fila, 1).Style.Font.SetBold(true).Fill.SetBackgroundColor(bg);
            ws.Cell(fila, 2).Value = valor;
            ws.Cell(fila, 2).Style.Fill.SetBackgroundColor(bg);
            alt = !alt;
        }

        private static void EscribirFilaResumenNumero(IXLWorksheet ws, int fila, ref bool alt, string etiqueta, double valor)
        {
            var bg = alt ? ColorFilaAlterna : XLColor.White;
            ws.Cell(fila, 1).Value = etiqueta;
            ws.Cell(fila, 1).Style.Font.SetBold(true).Fill.SetBackgroundColor(bg);
            ws.Cell(fila, 2).Value = valor;
            ws.Cell(fila, 2).Style.NumberFormat.Format = "#,##0.00";
            ws.Cell(fila, 2).Style.Fill.SetBackgroundColor(bg);
            alt = !alt;
        }

        private static string ClasificarConcepto(string concepto)
        {
            if (concepto.Contains("IMPUESTO CREDITO")) return "Impuesto Crédito - Ley 25413";
            if (concepto.Contains("IMPUESTO DEBITO")) return "Impuesto Débito - Ley 25413";
            if (concepto.Contains("RETENCION ARBA")) return "Retención ARBA";
            if (concepto.Contains("CR.DEBIN")) return "Crédito DEBIN";
            if (concepto.Contains("DEBIN")) return "DEBIN";
            if (concepto.Contains("TRANSFERENCIA")) return "Transferencia";
            if (concepto.Contains("CHEQUE")) return "Cheque";
            if (concepto.Contains("COMISION")) return "Comisión";
            if (concepto.Contains("INTERES")) return "Interés";
            return "Otros";
        }
    }
}