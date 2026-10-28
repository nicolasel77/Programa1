
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Imports System.Data
Public Class Formatear

    Private _hoja As New Excel.Worksheet

    Public Sub New()
    End Sub

    Private Function EsColumnaNumerica(ByVal tipo As System.Type) As Boolean
        Select Case System.Type.GetTypeCode(tipo)
            Case TypeCode.Byte, TypeCode.SByte, TypeCode.Int16, TypeCode.UInt16, TypeCode.Int32, TypeCode.UInt32, TypeCode.Int64, TypeCode.UInt64, TypeCode.Decimal, TypeCode.Single, TypeCode.Double
                Return True
            Case Else
                Return False
        End Select
    End Function

    Public Property Hoja As Worksheet
        Get
            Return _hoja
        End Get
        Set(value As Worksheet)
            _hoja = value
        End Set
    End Property

    Public Sub Vencimientos_P1()
        Dim fila_final As Integer
        fila_final = Hoja.Range("A1000").End(Excel.XlDirection.xlUp).Row

        Hoja.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, Hoja.Range("$B$1:$R$" & fila_final - 2), , Excel.XlYesNoGuess.xlYes).Name = "Tabla1"
        Hoja.ListObjects("Tabla1").TableStyle = "TableStyleMedium4"
        Hoja.ListObjects("Tabla1").ShowAutoFilterDropDown = False

        Hoja.Columns("A:A").EntireColumn.Hidden = True
        Hoja.Columns("J:N").Style = "Comma"
        Hoja.Columns("B:R").EntireColumn.AutoFit
        Hoja.Range("O2:Q2").EntireColumn.Hidden = True

        With Hoja.PageSetup
            .PrintTitleRows = "$1:$1"
            .PrintTitleColumns = ""
            .LeftHeader = ""
            .CenterHeader = ""
            .RightHeader = ""
            .LeftFooter = ""
            .CenterFooter = ""
            .RightFooter = ""
            .LeftMargin = Hoja.Application.InchesToPoints(0)
            .RightMargin = Hoja.Application.InchesToPoints(0)
            .TopMargin = Hoja.Application.InchesToPoints(0)
            .BottomMargin = Hoja.Application.InchesToPoints(0)
            .HeaderMargin = Hoja.Application.InchesToPoints(0.31496062992126)
            .FooterMargin = Hoja.Application.InchesToPoints(0.31496062992126)
            .PrintHeadings = False
            .PrintGridlines = False
            .PrintComments = Excel.XlPrintLocation.xlPrintNoComments
            .PrintQuality = 600
            .CenterHorizontally = False
            .CenterVertically = False
            .Orientation = Excel.XlPageOrientation.xlLandscape
            .Draft = False
            .FirstPageNumber = Excel.Constants.xlAutomatic
            .Order = Excel.XlOrder.xlDownThenOver
            .BlackAndWhite = False
            .Zoom = 100
            .PaperSize = XlPaperSize.xlPaperA4
            .PrintErrors = Excel.XlPrintErrors.xlPrintErrorsDisplayed
            .OddAndEvenPagesHeaderFooter = False
            .DifferentFirstPageHeaderFooter = False
            .ScaleWithDocHeaderFooter = True
            .AlignMarginsHeaderFooter = True
            .EvenPage.LeftHeader.Text = ""
            .EvenPage.CenterHeader.Text = ""
            .EvenPage.RightHeader.Text = ""
            .EvenPage.LeftFooter.Text = ""
            .EvenPage.CenterFooter.Text = ""
            .EvenPage.RightFooter.Text = ""
            .FirstPage.LeftHeader.Text = ""
            .FirstPage.CenterHeader.Text = ""
            .FirstPage.RightHeader.Text = ""
            .FirstPage.LeftFooter.Text = ""
            .FirstPage.CenterFooter.Text = ""
            .FirstPage.RightFooter.Text = ""
        End With

        Hoja.Range("A" & fila_final - 1 & ":K" & fila_final).ClearContents()
        Hoja.Range("G" & fila_final).Value = "Totales"
    End Sub

    ''' <summary>
    ''' Crea un excel nuevo
    ''' </summary>
    ''' <param name="dt">Datos para leer</param>
    ''' <param name="CerraloNomas">Indica si se cierra solo. Por ejemplo: después de imprimir.</param>
    ''' <param name="Imprimile">Si imprime directamente o no.</param>
    ''' <param name="vistaPrevia">Si muestra una vista previa antes de imprimir.</param>
    ''' <param name="agregarColumnaTotal">Si agrega una columna con el total de los valores numéricos de cada fila.</param>
    Public Sub Formato_Automatico(ByVal dt As Data.DataTable, Optional CerraloNomas As Boolean = True, Optional ByVal Imprimile As Boolean = False, Optional ByVal vistaPrevia As Boolean = False, Optional ByVal agregarColumnaTotal As Boolean = False)
        'Crear un excel para imprimir
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim h As New Excel.Worksheet

        xlApp = New Excel.Application()
        xlWorkBook = xlApp.Workbooks.Add()
        h = xlWorkBook.Worksheets.Item(1)

        For i As Integer = 0 To dt.Rows.Count - 1
            For c As Integer = 0 To dt.Columns.Count - 1
                h.Cells(i + 2, c + 1).value = dt.Rows(i).Item(c)
            Next
        Next

        For c As Integer = 0 To dt.Columns.Count - 1
            h.Cells(1, c + 1).Value = dt.Columns(c).ColumnName
            Dim col As String = Chr(c + 65) & ":" & Chr(c + 65)

            Select Case dt.Columns(c).DataType.Name
                Case "DateTime"
                    h.Columns(col).NumberFormat = "dd/mm"

                Case "Decimal", "Single", "Double"
                    'h.Columns(col).Style = "#.#"

                Case "String"
                    h.Columns(col).ColumnWidth = 40

                Case "Int16", "Int32", "Int64"
                    h.Columns(col).NumberFormat = "#,###"
                Case Else

            End Select
        Next

        'Formato
        Dim fila_final As Integer = dt.Rows.Count + 1
        Dim col_final As Integer = dt.Columns.Count

        If agregarColumnaTotal Then
            col_final += 1
            h.Cells(1, col_final).Value = "Total"

            Dim colsNumericas As New List(Of Integer)
            'Se omite la columna A (id de producto)
            For c As Integer = 1 To dt.Columns.Count - 1
                If EsColumnaNumerica(dt.Columns(c).DataType) Then colsNumericas.Add(c + 1)
            Next

            If colsNumericas.Count > 0 AndAlso dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim celdas As New List(Of String)
                    For Each c As Integer In colsNumericas
                        celdas.Add(h.Cells(i + 2, c).Address(False, False))
                    Next
                    h.Cells(i + 2, col_final).Formula = "=SUM(" & String.Join(",", celdas) & ")"
                Next
                h.Range(h.Cells(2, col_final), h.Cells(fila_final, col_final)).NumberFormat = "#,##0.00"
            End If
        End If

        Dim rangoTabla As Excel.Range = h.Range(h.Cells(1, 1), h.Cells(fila_final, col_final))
        h.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, rangoTabla, , Excel.XlYesNoGuess.xlYes).Name = "Tabla1"
        h.ListObjects("Tabla1").TableStyle = "TableStyleMedium4"
        h.ListObjects("Tabla1").ShowAutoFilterDropDown = False

        h.Range(h.Cells(1, 1), h.Cells(1, col_final)).EntireColumn.AutoFit()

        With h.PageSetup
            .PrintTitleRows = "$1:$1"
            .PrintTitleColumns = ""
            .LeftHeader = ""
            .CenterHeader = ""
            .RightHeader = ""
            .LeftFooter = ""
            .CenterFooter = ""
            .RightFooter = ""
            .LeftMargin = h.Application.InchesToPoints(0)
            .RightMargin = h.Application.InchesToPoints(0)
            .TopMargin = h.Application.InchesToPoints(0)
            .BottomMargin = h.Application.InchesToPoints(0)
            .HeaderMargin = h.Application.InchesToPoints(0.31496062992126)
            .FooterMargin = h.Application.InchesToPoints(0.31496062992126)
            .PrintHeadings = False
            .PrintGridlines = False
            .PrintComments = Excel.XlPrintLocation.xlPrintNoComments
            '.PrintQuality = 600
            .CenterHorizontally = False
            .CenterVertically = False
            .Orientation = Excel.XlPageOrientation.xlLandscape
            .Draft = False
            .FirstPageNumber = Excel.Constants.xlAutomatic
            .Order = Excel.XlOrder.xlDownThenOver
            .BlackAndWhite = False
            .Zoom = 100
            .PaperSize = XlPaperSize.xlPaperA4
            .PrintErrors = Excel.XlPrintErrors.xlPrintErrorsDisplayed
            .OddAndEvenPagesHeaderFooter = False
            .DifferentFirstPageHeaderFooter = False
            .ScaleWithDocHeaderFooter = True
            .AlignMarginsHeaderFooter = True
            .EvenPage.LeftHeader.Text = ""
            .EvenPage.CenterHeader.Text = ""
            .EvenPage.RightHeader.Text = ""
            .EvenPage.LeftFooter.Text = ""
            .EvenPage.CenterFooter.Text = ""
            .EvenPage.RightFooter.Text = ""
            .FirstPage.LeftHeader.Text = ""
            .FirstPage.CenterHeader.Text = ""
            .FirstPage.RightHeader.Text = ""
            .FirstPage.LeftFooter.Text = ""
            .FirstPage.CenterFooter.Text = ""
            .FirstPage.RightFooter.Text = ""
        End With


        'Imprimir            
        If Imprimile = True Then
            xlWorkBook.PrintOutEx()
        Else
            If vistaPrevia Then
                xlWorkBook.PrintPreview()
            End If
        End If
        xlApp.Visible = True

        If CerraloNomas Then
            xlApp.DisplayAlerts = False
            'Liberar
            'xlWorkBook.Close(True, Nothing, Nothing)
            xlApp.Quit()

            xlWorkBook = Nothing
            xlApp = Nothing
            h = Nothing
        End If
    End Sub
End Class
