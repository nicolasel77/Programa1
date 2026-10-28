# Extractor de Extracto Bancario - Banco Provincia

Aplicación de consola en **C# / .NET 8** que extrae los movimientos de un PDF
de extracto de cuenta corriente del Banco Provincia y los escribe en un
archivo Excel con formato profesional.

---

## Dependencias NuGet

| Paquete | Uso |
|---------|-----|
| `PdfPig` | Lectura y extracción de texto del PDF |
| `ClosedXML` | Creación y formato del archivo Excel |

---

## Compilar y ejecutar

```bash
# 1. Restaurar paquetes y compilar
dotnet build

# 2. Ejecutar (el Excel se genera junto al PDF con el mismo nombre)
dotnet run -- "C:\ruta\al\Provincia1.pdf"

# 3. O especificando la ruta de salida del Excel
dotnet run -- "C:\ruta\al\Provincia1.pdf" "C:\ruta\salida\extracto.xlsx"
```

También podés ejecutar el binario directamente tras publicar:

```bash
dotnet publish -c Release -o ./publish
./publish/ExtractorExtractoBancario "Provincia1.pdf" "extracto.xlsx"
```

---

## Estructura del Excel generado

### Hoja "Movimientos"
- Datos de cabecera de la cuenta (titular, CUIT, CBU, etc.)
- Tabla completa de movimientos con columnas:
  - **Fecha** — fecha de la operación
  - **Concepto** — descripción del movimiento
  - **Importe** — monto (verde = crédito, rojo = débito)
  - **Fecha Valor** — fecha valor bancaria
  - **Saldo** — saldo acumulado luego del movimiento

### Hoja "Resumen"
- Totales del período (créditos, débitos, saldo neto)
- Agrupación de movimientos por tipo de concepto

---

## Notas

- El extractor usa expresiones regulares sobre el texto con layout del PDF,
  por lo que funciona correctamente siempre que el PDF no sea una imagen
  escaneada (si lo fuera, se necesitaría OCR adicional).
- Los duplicados que aparecen en el encabezado de cada página del PDF
  se eliminan automáticamente.
