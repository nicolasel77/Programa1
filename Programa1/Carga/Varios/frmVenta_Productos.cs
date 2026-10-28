using ClosedXML.Excel;
using ExtractorExtractoBancario;
using Programa1.DB;
using Programa1.DB.Sucursales;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Programa1.Carga.Varios
{
    public partial class frmVenta_Productos : Form
    {
        Estadisticas_Sucursales es = new Estadisticas_Sucursales();
        public frmVenta_Productos()
        {
            InitializeComponent();
            Semanas sem = new Semanas();
            Herramientas.Herramientas h = new Herramientas.Herramientas();
            h.Llenar_List(lstSemanas, sem.Fechas(), "dd/MM/yyy");
        }

        private void lstSemanas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            this.Cursor = Cursors.WaitCursor;

            if (lstSemanas.SelectedIndex > -1)
            {
                es.Sem.Semana = Convert.ToDateTime(lstSemanas.Text);


                DataTable dt;
                if (cProductos1.Cantidad_Seleccionada() == 1)
                {
                    dt = es.Ventas_KilosProdSuc((byte)nuSemanas.Value, cProductos1.Valor_Actual.ToString(), true);
                }
                else
                {
                    dt = es.Ventas_KilosProdSuc((byte)nuSemanas.Value, cProductos1.Cadena("Prod"));
                }

                grd.MostrarDatos(dt, true, false); ;

                for (int c = 2; c <= grd.Cols - 1; c++)
                {
                    grd.Columnas[c].Format = "N1";
                }
                grd.AutosizeAll();
                grd.set_ColW(0, 40);
                grd.set_ColW(1, 200);
                grd.Columnas[0].Style.BackColor = Color.WhiteSmoke;
                grd.Columnas[1].Style.BackColor = Color.WhiteSmoke;
                grd.Columnas["Promedio"].Style.BackColor = Color.Gainsboro;
            }

            this.Cursor = Cursors.Default;
        }

        private void cProductos1_Cambio_Seleccion(object sender, EventArgs e)
        {
            Cargar();
        }

        private void cSucursales1_Cambio_Seleccion(object sender, EventArgs e)
        {
            es.Suc.ID = cSuc.Valor_Actual == -1 ? 0 : cSuc.Valor_Actual;
            Cargar();
        }

        private void cmdExcel_Click(object sender, EventArgs e)
        {
            // Crear un excel con los datos de la grilla grd
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Movimientos");

            // Encabezados de columna
            for (int c = 0; c < grd.Cols; c++)
            {
                ws.Cell(1, c + 1).Value = (string)grd.get_Texto(0, c);
                ws.Cell(1, c + 1).Style
                   .Font.SetBold(true)
                   .Font.SetFontColor(XLColor.White)
                   .Fill.SetBackgroundColor(XLColor.SkyBlue)
                   .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                   .Border.SetBottomBorder(XLBorderStyleValues.Medium);
            }


            for (int i = 0; i <= grd.Rows; i++)
            {
                for (int c = 0; c < grd.Cols; c++)
                {
                    //ws.Cell(i + 1, c + 1).Value = (string)grd.get_Texto(i, c);
                    // Obtener el tipo de dato de la columna
                    Type colType = grd.Columnas[c].DataType;
                    string rawValue = Convert.ToString(grd.get_Texto(i, c));

                    if (string.IsNullOrEmpty(rawValue))
                    {
                        ws.Cell(i + 1, c + 1).Value = string.Empty;
                    }
                    else if (colType == typeof(int) || colType == typeof(long) || colType == typeof(short))
                    {
                        if (long.TryParse(rawValue, out long intVal))
                            ws.Cell(i + 1, c + 1).Value = intVal;
                        else
                            ws.Cell(i + 1, c + 1).Value = rawValue;
                        
                    }
                    else if (colType == typeof(decimal) || colType == typeof(double) || colType == typeof(float))
                    {
                        // Soporte para separador decimal local (, o .)
                        string normalized = rawValue.Replace(",", System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        if (decimal.TryParse(normalized, System.Globalization.NumberStyles.Any,
                                             System.Globalization.CultureInfo.CurrentCulture, out decimal decVal))
                            ws.Cell(i + 1, c + 1).Value = decVal;
                        else
                            ws.Cell(i + 1, c + 1).Value = rawValue;
                    }
                    else if (colType == typeof(DateTime))
                    {
                        if (DateTime.TryParse(rawValue, out DateTime dtVal))
                            ws.Cell(i + 1, c + 1).Value = dtVal;
                        else
                            ws.Cell(i + 1, c + 1).Value = rawValue;
                    }
                    else if (colType == typeof(bool))
                    {
                        if (bool.TryParse(rawValue, out bool boolVal))
                            ws.Cell(i + 1, c + 1).Value = boolVal;
                        else
                            ws.Cell(i + 1, c + 1).Value = rawValue;
                    }
                    else
                    {
                        // string u otro tipo no contemplado
                        ws.Cell(i + 1, c + 1).Value = rawValue;
                    }
                }
            }


            // Congelar hasta la fila de encabezados de columna
            ws.SheetView.FreezeRows(1);

            // Guardar en el escritorio
            SaveFileDialog fd = new SaveFileDialog();
            fd.DefaultExt = "xlsx";
            fd.Filter = "Excel Files|*.xlsx|All Files|*.*";
            fd.FileName = "Movimientos.xlsx";
            fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (fd.ShowDialog() == DialogResult.OK)
            {
                wb.SaveAs(fd.FileName);
            }
        }
    }
}
