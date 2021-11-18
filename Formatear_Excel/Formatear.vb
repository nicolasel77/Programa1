
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class Formatear

    Private _hoja As New Excel.Worksheet

    Public Sub New()
    End Sub

    Public Property Hoja As Worksheet
        Get
            Return _hoja
        End Get
        Set(value As Worksheet)
            _hoja = value
        End Set
    End Property

    Public Sub Formatear_E_Imprimir()
        Dim ffinal As Integer
        ffinal = Hoja.Range("A1000").End(Excel.XlDirection.xlUp).Row

        Hoja.ListObjects.Add(Excel.XlListObjectSourceType.xlSrcRange, Hoja.Range("$B$1:$R$" & ffinal - 2), , Excel.XlYesNoGuess.xlYes).Name = "Tabla1"
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

        Hoja.Range("A" & ffinal - 1 & ":K" & ffinal).ClearContents()
        Hoja.Range("G" & ffinal).Value = "Totales"
    End Sub
End Class
