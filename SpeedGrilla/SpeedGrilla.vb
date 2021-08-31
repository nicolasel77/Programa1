Imports System.ComponentModel
Public Class SpeedGrilla
    Inherits UserControl
    Public lc As New DataTable
    Private vtotal As Single
    Private ObTemp As Object
    Private txt As clstxt
    Private clsfor As New Grilla2.ClsFormulas
    Dim TeclasCol As New Collection
    Private HayMenu As Boolean = False
    Public Event Cambio_texto(ByVal Texto As String)
    Structure Expresion
        Public Col As Int32
        Public Expresion As String
    End Structure
    Dim ColExp As Expresion()
    Private Nomcols As String()
    Private HayExpresiones As Boolean = False
    Private Archivo As String = "Grilla.xls"
    Public TeclasManejadas() As Int32 = {555}
    Private FilaSeleccionada As Integer = 1
    Friend WithEvents ttGenenral As ToolTip
    Private PintarFilas As Boolean = True


#Region " C�digo generado por el Dise�ador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Dise�ador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicializaci�n despu�s de la llamada a InitializeComponent()
        txt = New clstxt(Grd)
    End Sub

    'UserControl1 reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Dise�ador de Windows Forms
    Private components As System.ComponentModel.IContainer
    Friend WithEvents OpenExcel As OpenFileDialog
    Friend WithEvents SaveExcel As SaveFileDialog
    Public WithEvents Grd As C1.Win.C1FlexGrid.C1FlexGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SpeedGrilla))
        Me.OpenExcel = New System.Windows.Forms.OpenFileDialog()
        Me.SaveExcel = New System.Windows.Forms.SaveFileDialog()
        Me.Grd = New C1.Win.C1FlexGrid.C1FlexGrid()
        Me.ttGenenral = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenExcel
        '
        Me.OpenExcel.Filter = "Archivos de Excel (*.xls)|*.xls"
        Me.OpenExcel.Title = "Abrir Archivo de excel"
        '
        'SaveExcel
        '
        Me.SaveExcel.DefaultExt = "xls"
        Me.SaveExcel.FileName = "Datos"
        Me.SaveExcel.Filter = "Archivos de Excel (*.xls)|*.xls"
        Me.SaveExcel.Title = "Guardar Datos de la grilla..."
        '
        'Grd
        '
        Me.Grd.ColumnInfo = "10,0,0,0,0,100,Columns:"
        Me.Grd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grd.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.Grd.Language = C1.Util.Localization.Language.Spanish
        Me.Grd.Location = New System.Drawing.Point(0, 0)
        Me.Grd.Name = "Grd"
        Me.Grd.Rows.DefaultSize = 20
        Me.Grd.Rows.Fixed = 0
        Me.Grd.ShowCellLabels = True
        Me.Grd.Size = New System.Drawing.Size(714, 456)
        Me.Grd.StyleInfo = resources.GetString("Grd.StyleInfo")
        Me.Grd.TabIndex = 0
        Me.Grd.UseCompatibleTextRendering = False
        '
        'SpeedGrilla
        '
        Me.Controls.Add(Me.Grd)
        Me.Name = "SpeedGrilla"
        Me.Size = New System.Drawing.Size(714, 456)
        CType(Me.Grd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Delegado"
    Private Delegate Sub DelTotal(ByVal col As Int32)
    Private Delegate Sub DelTotales(ByVal col1 As Int32, ByVal col2 As Integer)
#End Region
#Region "Procedimientos Publicos"
    Private Sub Grilla2_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Grd.Height = Me.Height
        Grd.Width = Me.Width
    End Sub
    Public Sub ErrorEnTxt()
        Dim s As String
        Beep()
        s = String.Format("El valor que ingres� para el campo ""{0}"" no es v�lido.", Grd.Item(0, Grd.Col))
        RaiseEvent DatoNoValido(s)
        Grd.StartEditing()
    End Sub
    Public Property TipoCampo() As DataTable
        Get
            Return lc
        End Get
        Set(ByVal Value As DataTable)
            lc = Value
        End Set
    End Property
    Public Sub MostrarDatos(ByVal ls As DataTable, Optional ByVal AplicarFormato As Boolean = False, Optional ByVal CalTotal As Int32 = -1)
        Dim i As Int32
        Grd.Redraw = False
        Grd.Col = -1
        If ls Is Nothing Then
            For i = 0 To Grd.Rows.Count - 2
                Grd.RemoveItem()
            Next
            Grd.AddItem("")
            Grd.Redraw = True
            Exit Sub
        End If

        If AplicarFormato = True Then
            If ls.Rows.Count = 0 Then ' si no hay nada, reaplico el formato anterior
                Encabezados(ls)
            Else 'aplico el nuevo formato
                lc = ls.Copy
                Encabezados(lc)
                CargarDatosGrilla(ls)
                If CalTotal <> -1 Then
                    vtotal = SumarCol(CalTotal, True)
                End If
            End If
            For i = 0 To ls.Columns.Count - 1
                Select Case ls.Columns(i).DataType.ToString
                    Case "System.String"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
                    Case "System.Boolean"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    Case "System.DateTime"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    Case "System.Single", "System.Double", "System.Decimal"
                        Grd.Cols(i).Format = "#.00#"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                    Case "System.Integer", "System.Int16", "System.Int32", "System.Int64"
                        Grd.Cols(i).Format = "#"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                    Case Else
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                End Select
            Next
        Else
            Grd.Rows.RemoveRange(0, Grd.Rows.Count - 1)
            Grd.Rows.Fixed = 1
            CargarDatosGrilla(ls)
            Grd.Cols.Count = ls.Columns.Count
            For i = 0 To ls.Columns.Count - 1
                Grd.Cols(i).Caption = ls.Columns(i).Caption
            Next
            Grd.AddItem("")
        End If
        Grd.Redraw = True
    End Sub
    Public Sub MostrarDatos(ByVal ls As DataTable, ByVal AplicarFormato As Boolean, ByVal AgregarUltimaFila As Boolean)
        Dim i As Int32
        Grd.Redraw = False
        Grd.Col = -1
        If ls Is Nothing Then
            For i = 0 To Grd.Rows.Count - 2
                Grd.RemoveItem()
            Next
            Grd.AddItem("")
            Grd.Redraw = True
            Exit Sub
        End If

        If AplicarFormato = True Then
            If ls.Rows.Count = 0 Then ' si no hay nada, reaplico el formato anterior
                Encabezados(ls)
            Else 'aplico el nuevo formato
                lc = ls.Copy
                Encabezados(lc)
                CargarDatosGrilla(ls)
            End If
            For i = 0 To ls.Columns.Count - 1
                Select Case ls.Columns(i).DataType.ToString
                    Case "System.String"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
                    Case "System.Boolean"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    Case "System.DateTime"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    Case "System.Single", "System.Double", "System.Decimal"
                        Grd.Cols(i).Format = "#.00#"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                    Case "System.Integer", "System.Int16", "System.Int32", "System.Int64"
                        Grd.Cols(i).Format = "#"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                    Case Else
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                End Select
            Next
        Else
            Grd.Rows.RemoveRange(0, Grd.Rows.Count - 1)
            Grd.Rows.Fixed = 1
            CargarDatosGrilla(ls)
            Grd.Cols.Count = ls.Columns.Count
            For i = 0 To ls.Columns.Count - 1
                Grd.Cols(i).Caption = ls.Columns(i).Caption
            Next
            Grd.AddItem("")
        End If
        If Not AgregarUltimaFila Then
            Grd.Rows.Remove(Grd.Rows.Count - 1)
        End If
        Grd.Redraw = True
    End Sub

    Private Sub PrepararDataTable(ByRef lc As DataTable)
        Dim i As Int32
        lc.Constraints.Clear()
        ReDim ColExp(0) 'para inicializarlos
        ReDim Nomcols(lc.Columns.Count)
        For i = 0 To lc.Columns.Count - 1
            If lc.Columns(i).AutoIncrement = True Then lc.Columns(i).AutoIncrement = False
            If lc.Columns(i).Expression <> "" Then
                HayExpresiones = True
                ReDim Preserve ColExp(ColExp.GetUpperBound(0) + 1)
                ColExp(ColExp.GetUpperBound(0) - 1).Col = i
                ColExp(ColExp.GetUpperBound(0) - 1).Expresion = lc.Columns(i).Expression
            End If
            Try
                Nomcols(i) = lc.Columns(i).Caption
                lc.Columns(i).AllowDBNull = True
                lc.Columns(i).ReadOnly = False
            Catch e As Exception
            End Try
        Next
    End Sub
    Private Sub PrepararGrilla()
        Dim i As Integer
        Try
            Grd.Language = C1.Util.Localization.Language.Spanish
            For i = 0 To Grd.Cols.Count - 1
                Select Case Grd.Cols(i).DataType.ToString
                    Case "System.String"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter
                    Case "System.Boolean"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    Case "System.DateTime"
                        Grd.Cols(i).Editor = txt
                        Grd.Cols(i).Format = "dd/MM/yy"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter
                    Case "System.Single", "System.Double", "System.Decimal"
                        Grd.Cols(i).Format = "#.00#"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                    Case "System.Integer", "System.Int16", "System.Int32", "System.Int64"
                        Grd.Cols(i).Format = "#"
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                    Case Else
                        Grd.Cols(i).TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.RightCenter
                End Select
            Next
        Catch er As Exception
            MsgBox(er.Message)
        End Try
    End Sub

    Public Sub Encabezados(ByVal Titulos As DataTable)
        Grd.Redraw = False
        If Titulos.Columns.Count Then
            Dim i As Int32
            Dim inicio As Char
            Dim Cad As String
            Grd.Cols.Count = Titulos.Columns.Count
            Titulos.Rows.Clear()
            PrepararDataTable(Titulos)
            Grd.Cols.Count = Titulos.Columns.Count
            Grd.Rows.Fixed = 1
            Grd.DataSource = Titulos 'para adaptar la cantidad de columnas, tipos de datos y editores
            Grd.DataSource = Nothing
            For i = 0 To Titulos.Columns.Count - 1
                Cad = Titulos.Columns(i).Caption
                inicio = Cad.Chars(0)
                Cad = Titulos.Columns(i).Caption.Remove(0, 1)
                Cad = Cad.Insert(0, Char.ToUpper(inicio))
                Grd.Cols(i).Caption = Cad
            Next
            PrepararGrilla()
            Grd.AddItem("")
        End If
        Alinear(2)
        AlinearFix(4)
        If lc Is Nothing Then lc = Titulos.Clone
        Grd.Redraw = True
    End Sub

    Private Sub CargarDatosGrilla(ByVal ls As DataTable)
        Dim i, j As Int32
        Grd.Redraw = False
        Try
            For i = 0 To ls.Rows.Count - 1
                Grd.Rows.Add()
                For j = 0 To ls.Columns.Count - 1
                    Grd(i + 1, j) = ls.Rows(i).Item(j)

                Next
            Next

        Catch ex As Exception
            Beep()
        End Try
    End Sub

    Public Sub TotalCol(ByVal Columna As Int32)
        Dim i As Int32
        vtotal = 0
        For i = 0 To Grd.Rows.Count - 1
            If IsNumeric(Grd.Item(i, Columna)) Then
                vtotal += Grd.Item(i, Columna)
            End If
        Next
        Grd.Item(Grd.Rows.Count - 1, Columna) = vtotal
        RaiseEvent CalculoFinalizado(Columna, vtotal)
    End Sub
    Public Sub ThrTotalCol(ByVal columna As Int32)
        Dim handler As New DelTotal(AddressOf TotalCol)
        handler.BeginInvoke(columna, Nothing, Nothing)
    End Sub
    Public Sub thrTotales(ByVal col1 As Integer, ByVal col2 As Integer)
        Dim handler As New DelTotales(AddressOf Totales)
        handler.BeginInvoke(col1, col2, Nothing, Nothing)
    End Sub

    Public Sub SumTotal(ByVal Columna As Int32, Optional ByVal Etiqueta As String = "")
        If Etiqueta = "" Then Etiqueta = "Total"
        Grd.Subtotal(C1.Win.C1FlexGrid.AggregateEnum.Sum, Columna, Columna, Columna, Columna, Etiqueta)
    End Sub
    Public Sub ActivarCelda(Optional ByVal Fila As Int32 = -1, Optional ByVal Columna As Int32 = -1)
        If Fila = -1 Then Fila = Grd.Row
        If Fila >= Grd.Rows.Count Then Fila = Grd.Rows.Count - 1
        If Columna = -1 Then Columna = Grd.Col
        If Columna >= Grd.Cols.Count Then Columna = Grd.Cols.Count - 1
        Grd.Select(Fila, Columna)
    End Sub
    Public Sub AgregarFila(Optional ByVal Valor As String = "", Optional ByVal Fila As Int32 = -1)
        Grd.Rows.Add()
        'Try
        '    If Fila = -1 Then
        '        Grd.Rows.Add()
        '    Else
        '        Grd.Rows.Add(Fila)
        '    End If
        '    'With Grd
        '    If .Rows.Count > 2 Then
        '        Dim b As Boolean
        '        For i As Integer = 0 To .Cols.Count - 1
        '            .Rows(Fila).Item(i)
        '            .Rows(Fila).Item(i). (.Rows.Count - 1, i, .GetData(.Rows.Count - 2, i))
        '        Next
        '    End If
        'End With
        'Catch er As Exception
        'End Try
    End Sub

    Public Sub AutosizeCol(ByVal Columna As Int32)
        If Columna <> -1 Then Grd.AutoSizeCol(Columna)
    End Sub
    Public Sub AutosizeCol(ByVal Columna As Int32())
        For i As Int32 = 0 To Columna.Length - 1
            If Not Columna(i) >= Grd.Cols.Count - 1 Then Grd.AutoSizeCol(Columna(i))
        Next
    End Sub
    Public Sub AutosizeAll()
        For i As Integer = 0 To Grd.Cols.Count - 1
            Grd.AutoSizeCol(i)
        Next
    End Sub


    Public Sub GuardarEnExcel(ByVal NombreArch As String)
        Grd.SaveExcel(NombreArch, "", C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells Or C1.Win.C1FlexGrid.FileFlags.VisibleOnly)
    End Sub
    Public Sub CargarDesdeExcel(ByVal NombreArch As String, Optional ByVal Hoja As String = "")
        Grd.LoadExcel(NombreArch, Hoja, C1.Win.C1FlexGrid.FileFlags.AsDisplayed)
    End Sub
    Public Sub CargarDesdeExcel()
        Grd.LoadExcel(Archivo)
    End Sub
    Public Sub Imprimir()
        Grd.PrintGrid("Grilla", C1.Win.C1FlexGrid.PrintGridFlags.ShowPreviewDialog Or C1.Win.C1FlexGrid.PrintGridFlags.ShowPrintDialog Or C1.Win.C1FlexGrid.PrintGridFlags.ShowPageSetupDialog)
    End Sub
    Public Sub Limpiar()
        Dim est As Boolean = Grd.Redraw
        If est Then Grd.Redraw = False
        If Grd.Rows.Count > 1 Then Grd.Rows.RemoveRange(1, Grd.Rows.Count - 1)
        Grd.Redraw = est
    End Sub

    Public Sub CrearCombo(ByVal Columna As Int32, ByVal dt As DataTable)
        Dim Hash As New Hashtable
        Dim i As Int32
        For i = 0 To dt.Rows.Count - 1
            Hash.Add(dt.Rows(i).Item(0), dt.Rows(i).Item(1))
        Next
        Grd.Cols(Columna).DataMap = Hash
    End Sub
    Public Sub CrearArbol(ByVal funcion As C1.Win.C1FlexGrid.AggregateEnum, ByVal AgruparPor As Int32, ByVal TotalEn As Int32, Optional ByVal Etiqueta As String = "", Optional ByVal Nivel As Int32 = 0)
        Grd.Subtotal(funcion, Nivel, AgruparPor, AgruparPor, TotalEn, Etiqueta)
    End Sub
    Public Sub PrimerLetraMayuscula()
        Dim inicio As Char
        Dim Cad As String
        Dim columna As C1.Win.C1FlexGrid.Column
        For Each columna In Grd.Cols
            inicio = columna.Caption.Chars(0)
            Cad = columna.Caption.Remove(0, 1)
            Cad = Cad.Insert(0, Char.ToUpper(inicio))
            columna.Caption = Cad
        Next
    End Sub
    Public Sub Totales(ByVal col1 As Integer, ByVal col2 As Integer)
        Dim i As Integer
        Dim ac As Single
        For i = 0 To Grd.Rows.Count - 1
            If IsNumeric(Grd.Item(i, col1)) And IsNumeric(Grd.Item(i, col2)) Then
                ac += Grd.Item(i, col1) * Grd.Item(i, col2)
            End If
        Next
        RaiseEvent CalculoFinalizado(col1, ac)
    End Sub

    Public Sub RepetirUltimaFila(ByVal CampoExepcion() As String)
        With Grd
            If .Rows.Count > 2 Then
                Dim b As Boolean
                For i As Integer = 0 To .Cols.Count - 1
                    b = False
                    For n As Integer = 0 To CampoExepcion.Length - 1
                        If .Cols(i).Name.ToLower = CampoExepcion(n).ToLower Then
                            b = True
                        End If
                    Next
                    If Not b Then
                        .SetData(.Rows.Count - 1, i, .GetData(.Rows.Count - 2, i))
                    End If
                Next
            End If
        End With
    End Sub

    Public Sub Siguiente_Fila()
        With Grd
            If .Rows.Count > 2 Then
                If .Row = .Rows.Count - 1 Then
                    ActivarCelda(1, .Col)
                Else
                    ActivarCelda(.Row + 1, .Col)
                End If
            End If
        End With
    End Sub

    Public Sub Anterior_Fila()
        With Grd
            If .Rows.Count > 2 Then
                If .Row < 2 Then
                    ActivarCelda(.Rows.Count - 1, .Col)
                Else
                    ActivarCelda(.Row - 1, .Col)
                End If
            End If
        End With
    End Sub
#End Region

#Region "Propiedades de las Celdas"
    Public Property ColorCelda(Optional ByVal Fila As Int32 = -1, Optional ByVal Columna As Int32 = -1) As Color
        Get
            If Grd.Rows.Count And Grd.Cols.Count Then
                Dim rg As C1.Win.C1FlexGrid.CellRange = Grd.GetCellRange(Grd.Row, Grd.Col)
                Return Color.FromArgb(rg.StyleDisplay.BackColor.A, rg.StyleDisplay.BackColor.R, rg.StyleDisplay.BackColor.G, rg.StyleDisplay.BackColor.B)
            End If
        End Get
        Set(ByVal Value As Color)
            If Grd.Rows.Count And Grd.Cols.Count Then
                If Fila = -1 Then Fila = Grd.Row
                If Columna = -1 Then Columna = Grd.Col
                If Value.Name <> "0" And Grd.Row > -1 And Grd.Col > -1 Then
                    Dim rg As C1.Win.C1FlexGrid.CellRange = Grd.GetCellRange(Fila, Columna)
                    rg.StyleNew.BackColor = Value
                End If
            End If
        End Set
    End Property
    Public Property ColorLetraCelda(Optional ByVal Fila As Int32 = -1, Optional ByVal Columna As Int32 = -1) As Color
        Get
            If Fila = -1 Then Fila = Grd.Row
            If Columna = -1 Then Columna = Grd.Col
            Dim rg As C1.Win.C1FlexGrid.CellRange = Grd.GetCellRange(Fila, Columna)
            Return rg.StyleDisplay.ForeColor
        End Get
        Set(ByVal Value As Color)
            If Fila = -1 Then Fila = Grd.Row
            If Columna = -1 Then Columna = Grd.Col
            Dim rg As C1.Win.C1FlexGrid.CellRange = Grd.GetCellRange(Fila, Columna)
            rg.StyleNew.ForeColor = Value
        End Set
    End Property
    Public Property AlineamientoCelda(Optional ByVal Fila As Int32 = -1, Optional ByVal Columna As Int32 = -1) As C1.Win.C1FlexGrid.CellStyle
        Get
            Return Grd.GetCellStyle(Fila, Columna)
        End Get
        Set(ByVal Value As C1.Win.C1FlexGrid.CellStyle)
            Grd.SetCellStyle(Fila, Col, Value)
        End Set
    End Property
    Public Sub BorrarFila(Optional ByVal Fila As Int32 = -1)
        If Fila = -1 Then Fila = Grd.Row
        If Fila = -1 Then Exit Sub 'si da la casualidad de que el row=-1 
        Grd.RemoveItem(Fila)
    End Sub
    Public Function GetCellRect() As Rectangle
        Return Grd.GetCellRect(Grd.Row, Grd.Col, False)
    End Function
#End Region
#Region "Propiedades de las Columnas"
    Public Property FixCols() As Int32
        Get
            Return Grd.Cols.Fixed
        End Get
        Set(ByVal Value As Int32)
            Grd.Cols.Fixed = Value
        End Set
    End Property
    Public Property Cols() As Int32
        Get
            Return Grd.Cols.Count
        End Get
        Set(ByVal Value As Int32)
            Grd.Cols.Count = Value
        End Set
    End Property
    <Description("Posicion del cursor")>
    Public Property Col() As Int32
        Get
            Return Grd.Col
        End Get
        Set(ByVal Value As Int32)
            Grd.Col = Value
        End Set
    End Property
    Public Property ColW(ByVal Columna As Int32) As Int32
        Get
            Return Grd.Cols.Item(Columna).Width
        End Get
        Set(ByVal Value As Int32)
            Try
                Grd.Cols.Item(Columna).Width = Value
            Catch ex As Exception

            End Try
        End Set
    End Property
    Public ReadOnly Property TipoCol(ByVal Columna As Int32) As System.Type
        Get
            Return Grd.Cols.Item(Columna).DataType
        End Get
    End Property
    Public ReadOnly Property ColIndex(ByVal NombreColumna As String) As Int32
        Get
            Return Grd.Cols.IndexOf(NombreColumna)
        End Get
    End Property
    Public Property MergeCol(ByVal Columna As Int32) As Boolean
        Get
            Return Grd.Cols(Columna).AllowMerging
        End Get
        Set(ByVal Value As Boolean)
            Grd.Cols(Columna).AllowMerging = Value
        End Set
    End Property
    Public Property Columnas() As C1.Win.C1FlexGrid.ColumnCollection
        Get
            Return Grd.Cols
        End Get
        Set(ByVal Value As C1.Win.C1FlexGrid.ColumnCollection)
            Grd.Cols = Value
        End Set
    End Property
#End Region
#Region "Propiedades de las Filas"
    Public Property FixRows() As Int32
        Get
            Return Grd.Rows.Fixed
        End Get
        Set(ByVal Value As Int32)
            Grd.Rows.Fixed = Value
        End Set
    End Property
    Public Property Rows() As Int32
        Get
            Return Grd.Rows.Count
        End Get
        Set(ByVal Value As Int32)
            Grd.Rows.Count = Value
        End Set
    End Property
    Public Property Row() As Int32
        Get
            Return Grd.Row
        End Get
        Set(ByVal Value As Int32)
            If Grd.Row > -1 Then Grd.Row = Value
        End Set
    End Property
    Public ReadOnly Property Filas() As C1.Win.C1FlexGrid.RowCollection
        Get
            Return Grd.Rows
        End Get
    End Property
    Public ReadOnly Property IsNew(ByVal Fila As Int32) As Boolean
        Get
            Return Grd.Rows(Fila).IsNew
        End Get
    End Property
#End Region

#Region "Propiedades de la Grilla"
    Public Property AutoResize() As Boolean
        Get
            Return Grd.AutoResize
        End Get
        Set(ByVal Value As Boolean)
            Grd.AutoResize = Value
        End Set
    End Property
    Public Property bColor() As Drawing.Color
        Get
            Return Grd.BackColor
        End Get
        Set(ByVal Value As Drawing.Color)
            Grd.BackColor = Value
        End Set
    End Property
    Public Property fColor() As Color
        Get
            Return Grd.Styles.Fixed.BackColor
        End Get
        Set(ByVal Value As Color)
            Grd.Styles.Fixed.BackColor = Value
        End Set
    End Property
    Public Property bColorSel() As Color
        Get
            Return Grd.Styles.Highlight.BackColor
        End Get
        Set(ByVal Value As Color)
            Grd.Styles.Highlight.BackColor = Value
        End Set
    End Property
    Public Property bFColor() As Color
        Get
            Return Grd.ForeColor
        End Get
        Set(ByVal Value As Color)
            Grd.ForeColor = Value
        End Set
    End Property
    Public Property bFColorSel() As Color
        Get
            Return Grd.Styles.Highlight.ForeColor
        End Get
        Set(ByVal Value As Color)
            Grd.Styles.Highlight.ForeColor = Value
        End Set
    End Property
    Public ReadOnly Property Estilo(ByVal Est As C1.Win.C1FlexGrid.CellStyleEnum) As C1.Win.C1FlexGrid.CellStyle
        Get
            Return Grd.Styles(Est)
        End Get
    End Property
    Public ReadOnly Property Styles() As C1.Win.C1FlexGrid.CellStyleCollection
        Get
            Return Grd.Styles
        End Get
    End Property
    Public Property EnableEdicion() As Boolean
        Get
            Return Grd.AllowEditing
        End Get
        Set(ByVal Value As Boolean)
            If Value = True Then
                Grd.AllowEditing = True
            Else
                Grd.AllowEditing = False
            End If
        End Set
    End Property
    Public Property Texto(Optional ByVal f As Int32 = -1, Optional ByVal c As Object = -1) As Object
        Get
            If Not IsNumeric(c) Then c = Grd.Cols.IndexOf(c)
            If f = -1 Then f = Grd.Row
            If c = -1 Then c = Grd.Col
            'MsgBox(Grd.GetDataDisplay(f, c))
            Try
                If IsDBNull(Grd.Item(f, c)) Or Grd.Item(f, c) Is Nothing Then
                    If Not IsNothing(Grd.Cols(c).datatype) Then
                        Select Case Grd.Cols(c).DataType.ToString
                            Case "System.String"
                                Return ""
                            Case "System.Byte", "System.Int16", "System.Int32", "System.Int64", "System.Single", "System.Double", "System.Decimal"
                                Return 0
                            Case "System.DateTime"
                                Return Date.MinValue
                            Case "System.Boolean"
                                Return False
                        End Select
                    End If
                Else
                    Return Grd.Item(f, c)
                End If
            Catch er As Exception
                RaiseEvent grdError(er.Message)
            End Try
        End Get
        Set(ByVal Value As Object)
            If Not IsNumeric(c) Then c = Grd.Cols.IndexOf(c)
            If f = -1 Then f = Grd.Row
            If c = -1 Then c = Grd.Col
            Try
                Grd(f, c) = Value
            Catch er As Exception
                RaiseEvent grdError(er.Message)
            End Try
        End Set
    End Property
    Public Property AllowMerging() As C1.Win.C1FlexGrid.AllowMergingEnum
        Get
            Return Grd.AllowMerging
        End Get
        Set(ByVal Value As C1.Win.C1FlexGrid.AllowMergingEnum)
            Grd.AllowMerging = Value
        End Set
    End Property
    Public Property AllowSorting() As C1.Win.C1FlexGrid.AllowSortingEnum
        Get
            Return Grd.AllowSorting
        End Get
        Set(ByVal Value As C1.Win.C1FlexGrid.AllowSortingEnum)
            Grd.AllowSorting = Value
        End Set
    End Property
    Public Property DataSource() As Object
        Get
            Return Grd.DataSource
        End Get
        Set(ByVal Value As Object)
            Grd.DataSource = Value
        End Set
    End Property
    Public Property DataMember() As String
        Get
            Return Grd.DataMember
        End Get
        Set(ByVal Value As String)
            Grd.DataMember = Value
        End Set
    End Property
    Public Property KeyActionEnter() As C1.Win.C1FlexGrid.KeyActionEnum
        Get
            Return Grd.KeyActionEnter
        End Get
        Set(ByVal Value As C1.Win.C1FlexGrid.KeyActionEnum)
            Grd.KeyActionEnter = Value
        End Set
    End Property
    Public ReadOnly Property Selection() As C1.Win.C1FlexGrid.CellRange
        Get
            Return Grd.Selection
        End Get
    End Property
    Public ReadOnly Property Arbol() As C1.Win.C1FlexGrid.GridTree
        Get
            Return Grd.Tree
        End Get
    End Property
    Public Property Redraw() As Boolean
        Get
            Return Grd.Redraw
        End Get
        Set(ByVal Value As Boolean)
            Grd.Redraw = Value
        End Set
    End Property

    Public Property PintarFilaSel() As Boolean
        Get
            Return PintarFilas
        End Get
        Set(ByVal value As Boolean)
            PintarFilas = value
        End Set
    End Property
#End Region

#Region "Propiedades de la impresion"
    Public Property Encabezado() As String
        Get
            Return Grd.PrintParameters.Header
        End Get
        Set(ByVal Value As String)
            Grd.PrintParameters.Header = Value
        End Set
    End Property
    Public Property PieDePagina() As String
        Get
            Return Grd.PrintParameters.Footer
        End Get
        Set(ByVal Value As String)
            Grd.PrintParameters.Footer = Value
        End Set
    End Property
    Public Property FuenteEncabezado() As Font
        Get
            Return Grd.PrintParameters.HeaderFont
        End Get
        Set(ByVal Value As Font)
            Grd.PrintParameters.HeaderFont = Value
        End Set
    End Property
    Public Property FuentePieDePagina() As Font
        Get
            Return Grd.PrintParameters.FooterFont
        End Get
        Set(ByVal Value As Font)
            Grd.PrintParameters.FooterFont = Value
        End Set
    End Property
#End Region

#Region "Eventos Publicos"
    Public Event Editado(ByVal f As Int16, ByVal c As Int16, ByVal a As Object)
    Public Event DatoNoValido(ByVal Texto As String)
    Public Event grdError(ByVal Texto As String)
    Public Event CambioFila(ByVal Fila As Int16)
    Public Shadows Event KeyUp(ByVal sender As Object, ByVal e As Int16)
    Public Shadows Event KeyPress(ByVal sender As Object, ByVal e As Int16)
    Public Shadows Event DobleClick(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Event AntesDeOrdenar()
    Public Event Ordenado()
    Public Event ColumnaMovida()
    Public Event SeleccionCambio(ByVal FilaInicio As Int32, ByVal FilaFin As Int32, ByVal ColInicio As Int32, ByVal ColFin As Int32)
    Public Shadows Event Click()
    Public Event CalculoFinalizado(ByVal col As Int32, ByVal Total As Single)
    Public Event CambioColumna(ByVal col As Integer)
    Public Shadows Event MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs)
    Public Shadows Event MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

#Region "Compatibilidad con Grilla"
    Public Sub Alinear(ByVal Align As Int16, Optional ByVal Col As Int16 = -1)
        Dim i As Int16
        With Grd
            Dim sasd As String = sasd = .Cols.Item(0).Caption.ToString()
            If Col > -1 Then
                .Cols.Item(Col).TextAlign = Align
            Else
                Try
                    For i = 0 To .Cols.Count - 1
                        .Cols.Item(0).TextAlign = Align
                    Next
                Catch er As Exception
                    RaiseEvent grdError(er.Message)
                End Try
            End If
        End With
    End Sub
    Public Sub AlinearFix(ByVal Align As Int16, Optional ByVal Col As Int16 = 0)
        If Col = 0 Then Col = -1
        Alinear(Align, Col)
    End Sub
    Public Sub AnchoEncabezados(ByVal dt As DataTable)
        Dim i As Int16
        With dt
            For i = 0 To .Columns.Count - 1
                Select Case .Columns(i).DataType.ToString
                    Case "System.Int16"
                        Grd.Cols(i).Width = 600
                    Case "System.Int32"
                        Grd.Cols(i).Width = 900
                    Case "System.Int64"
                        Grd.Cols(i).Width = 1200
                    Case "System.String"
                        Grd.Cols(i).Width = 1400
                    Case "System.Boolean"
                        Grd.Cols(i).Width = 500
                    Case "System.Single"
                        Grd.Cols(i).Width = 800
                    Case "System.Double"
                        Grd.Cols(i).Width = 1000
                End Select
            Next
        End With
    End Sub
    Public Sub Ordenar(ByVal o As Int16)
        Grd.Sort(C1.Win.C1FlexGrid.SortFlags.Ascending, o)
    End Sub
    Public Function EsUltimaFila() As Boolean

        With Grd
            If .Row = .Rows.Count - 1 Then
                Return True
            End If
        End With
    End Function
    Public Function EsUltimaC() As Boolean
        Dim n As Int32
        With Grd
            n = .Col
            If .Col = .Cols.Count - 1 Then
                Return True
            End If
        End With
    End Function
    Public Function SumarCol(ByVal Col As Integer) As Double
        Dim i As Integer
        Dim a As String
        Try
            With Grd
                Dim t As Double
                For i = 1 To .Rows.Count - 1
                    If Not .Rows(i).IsNode AndAlso IsNumeric(.GetDataDisplay(i, Col)) Then
                        a = .Item(i, Col)
                        t += CDbl(a)
                    End If
                Next
                If t Then
                    .Item(.Rows.Count - 1, Col) = t
                End If
                Return t
            End With
        Catch er As System.Exception
        End Try
    End Function
    Public Function SumarCol(ByVal NombreCol As String) As Double
        Dim i As Int16
        Dim ColSum As Integer
        Dim a As String
        ColSum = Grd.Cols.IndexOf(NombreCol)
        If ColSum = -1 Then Return 0
        Try
            With Grd
                Dim t As Double
                For i = 1 To .Rows.Count - 1
                    If Not .Rows(i).IsNode AndAlso IsNumeric(.GetDataDisplay(i, ColSum)) Then
                        a = .Item(i, ColSum)
                        t += CDbl(a)
                    End If
                Next
                If t Then
                    .Item(.Rows.Count - 1, ColSum) = t
                End If
                Return t
            End With
        Catch er As System.Exception
        End Try
    End Function
    Public Function SumarCol(ByVal Col As Integer, ByVal Escribir As Boolean) As Double
        Dim i As Integer
        Dim a As Double
        Try
            With Grd
                Dim t As Double
                Dim fin As Integer

                If Escribir = True Then
                    fin = .Rows.Count - 2
                Else
                    fin = .Rows.Count - 1
                End If

                For i = 1 To fin
                    If Not .Rows(i).IsNode AndAlso IsNumeric(.GetDataDisplay(i, Col)) Then
                        a = CDbl(.Item(i, Col))
                        t += a
                    End If
                Next
                If Escribir Then
                    If t Then
                        .Item(.Rows.Count - 1, Col) = t
                    End If
                End If
                Return t
            End With
        Catch er As System.Exception
        End Try
    End Function
    Public Function SumarCol(ByVal NombreCol As String, ByVal Escribir As Boolean) As Double
        Dim i As Int16
        Dim a As String
        Dim ColSumar As Integer
        ColSumar = Grd.Cols.IndexOf(NombreCol)
        If ColSumar = -1 Then Return 0
        Try
            With Grd
                Dim t As Double
                For i = 1 To .Rows.Count - 1
                    If Not .Rows(i).IsNode AndAlso IsNumeric(.GetDataDisplay(i, ColSumar)) Then
                        a = .Item(i, ColSumar)
                        t += CDbl(a)
                    End If
                Next
                If Escribir Then
                    If t Then
                        .Item(.Rows.Count - 1, ColSumar) = t
                    End If
                End If
                Return t
            End With
        Catch er As System.Exception
        End Try
    End Function
    Public Function SumarCol(ByVal Col As Integer, ByVal Escribir As Boolean, ByVal Inicio As Int16) As Double
        Dim i As Int16
        Dim a As String

        Try
            With Grd
                Dim t As Double
                For i = Inicio To .Rows.Count - 1
                    If Not .Rows(i).IsNode AndAlso IsNumeric(.GetDataDisplay(i, Col)) Then
                        a = .Item(i, Col)
                        t += CDbl(a)
                    End If
                Next
                If Escribir Then
                    If t Then
                        .Item(.Rows.Count - 1, Col) = t
                    End If
                End If
                Return t
            End With
        Catch er As System.Exception
        End Try
    End Function
    Public Function SumarCol(ByVal NombreCol As String, ByVal Escribir As Boolean, ByVal Inicio As Integer) As Double
        Dim i As Int16
        Dim a As String
        Dim colsum As Integer
        colsum = Grd.Cols.IndexOf(NombreCol)
        If colsum = -1 Then Return 0
        Try
            With Grd
                Dim t As Double
                For i = Inicio To .Rows.Count - 1
                    If Not .Rows(i).IsNode AndAlso IsNumeric(.GetDataDisplay(i, colsum)) Then
                        a = .Item(i, colsum)
                        t += CDbl(a)
                    End If
                Next
                If Escribir Then
                    If t Then
                        .Item(.Rows.Count - 1, colsum) = t
                    End If
                End If
                Return t
            End With
        Catch er As System.Exception
        End Try
    End Function
    Public ReadOnly Property TotalC() As Double
        Get
            Return vtotal
        End Get
    End Property
#End Region

#Region "Events handlers"

    Private Sub Grd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grd.Click
        RaiseEvent Click()
    End Sub
    Private Sub Grd_KeyPress(ByVal sender As System.Object, ByVal e As KeyPressEventArgs) Handles Grd.KeyPress
        Dim Tecla As Int32 = Microsoft.VisualBasic.AscW(e.KeyChar)
        If Tecla = 13 Then
            Try
                If Grd.Rows(Grd.Row).IsNode Then
                    Grd.Rows(Grd.Row).Node.Collapsed = Not (Grd.Rows(Grd.Row).Node.Collapsed)
                    e.Handled = True
                End If
            Catch
            End Try
        End If
        If Array.BinarySearch(TeclasManejadas, Tecla) >= 0 Then
            e.Handled = True
        End If
        RaiseEvent KeyPress(sender, Tecla)
    End Sub

    Private Sub Grd_ValidateEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.ValidateEditEventArgs) Handles Grd.ValidateEdit
        Try
            With Grd.Editor
                'MsgBox(Grd.Cols(1).DataType)

                If Not IsNothing(Grd.Editor) Then
                    If .Text.StartsWith("�") Then
                        Dim c As String = clsfor.CalcularF(Grd.Editor.Text.Substring(1))
                        If IsNumeric(c) Then
                            Grd.Editor.Text = CSng(c)
                        End If
                    End If
                End If
                If Not IsNothing(Grd.Cols(e.Col).DataType) Then
                    Select Case Grd.Cols(e.Col).DataType.ToString
                        Case "System.Int16", "System.Int32", "System.Byte", "System.Int64"
                            If Not IsNumeric(Grd.Editor.Text) Then e.Cancel = True
                        Case "System.Single", "System.Double", "System.Decimal"
                            If Grd.Editor.Text.StartsWith(",") Or Grd.Editor.Text.StartsWith(".") Then Grd.Editor.Text = "0" & Grd.Editor.Text
                            If Not IsNumeric(Grd.Editor.Text) Then e.Cancel = True
                        Case "System.DateTime"
                            If IsNumeric(.Text) Then
                                Dim f As Date
                                If IsDate(Grd.GetData(Grd.Row, Grd.Col)) Then
                                    f = Grd.GetData(Grd.Row, Grd.Col)
                                    If f.Year < 2000 Then
                                        f = Date.Today
                                    End If
                                Else
                                    f = Date.Today
                                End If
                                Dim s As String = String.Format("{0}/{1}/{2}", .Text, f.Month, f.Year)
                                If IsDate(s) Then .Text = s
                            End If
                            If Not IsDate(Grd.Editor.Text) Then
                                e.Cancel = True
                            Else
                                e.Cancel = False
                            End If
                        Case "System.Boolean"
                        Case "System.String"
                        Case Else
                            MsgBox(Grd.Cols(e.Col).DataType.ToString)
                    End Select

                    If e.Cancel = False Then
                        Select Case Grd.Cols(e.Col).DataType.ToString
                            Case "System.DateTime"
                                ObTemp = CDate(Grd.Editor.Text)
                            Case "System.Boolean"
                                If e.Checkbox = C1.Win.C1FlexGrid.CheckEnum.Checked Then
                                    ObTemp = True
                                Else
                                    ObTemp = False
                                End If
                                Exit Sub
                            Case "System.Int16", "System.Int32", "System.Byte"
                                Try
                                    ObTemp = CInt(Grd.Editor.Text)
                                Catch es As Exception
                                    ObTemp = 0
                                End Try
                            Case "System.Int64"
                                Try
                                    ObTemp = CLng(Grd.Editor.Text)
                                Catch es As Exception
                                    ObTemp = 0
                                End Try
                            Case "System.Single", "System.Double", "System.Decimal"
                                Try
                                    ObTemp = CDbl(Grd.Editor.Text)
                                    'ObTemp = CSng(Grd.Editor.Text.Replace(".", ","))
                                Catch ex As Exception
                                    ObTemp = 0
                                End Try
                            Case "System.String"
                                ObTemp = Grd.Editor.Text
                            Case Else
                                ObTemp = Grd.Editor.Text
                        End Select
                        Grd.Editor.Text = Grd.GetDataDisplay(e.Row, e.Col)
                    Else
                        Dim tx As Object = Grd.Editor
                        tx.SelectAll()

                    End If
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            Beep()
        End Try
    End Sub
    Private Sub Grd_AfterEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RowColEventArgs) Handles Grd.AfterEdit
        RaiseEvent Editado(e.Row, e.Col, ObTemp)
        Try
            If HayExpresiones Then
                Dim i, j As Int16
                Dim Cad(ColExp.GetUpperBound(0) - 1) As String
                For i = 0 To ColExp.GetUpperBound(0) - 1
                    Cad(i) = ColExp(i).Expresion
                Next
                For j = 0 To ColExp.GetUpperBound(0) - 1
                    For i = 0 To Nomcols.GetUpperBound(0) - 2
                        Cad(j) = Cad(j).Replace(Nomcols(i), Grd(e.Row, Grd.Cols(Nomcols(i)).Index))
                    Next
                Next 'ya reemplazamos todas;)
                For i = 0 To ColExp.GetUpperBound(0) - 1
                    Grd(e.Row, ColExp(i).Col) = clsfor.CalcularF(Cad(i))
                Next
            End If
        Catch ex As Exception
            Beep()
        End Try
    End Sub
    Private Sub Grd_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles Grd.KeyDown
        If Array.BinarySearch(TeclasManejadas, CInt(e.KeyCode)) >= 0 Then
            e.Handled = True
            RaiseEvent KeyUp(sender, e.KeyCode)
            MoverCursor(e.KeyCode)
        End If
    End Sub
    Private Sub Grd_KeyUpEdit(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.KeyEditEventArgs) Handles Grd.KeyUpEdit
        'ac� capturo las teclas que no son alfanumericas
        RaiseEvent Cambio_texto(Grd.Editor.Text)
    End Sub

    Private Sub Grd_AfterDragColumn(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.DragRowColEventArgs) Handles Grd.AfterDragColumn
        RaiseEvent ColumnaMovida()
    End Sub
    Private Sub Grd_RowColChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Grd.RowColChange
        Static r As Int32
        Static c As Int32
        With Grd
            Try
                If .Rows.Count > 0 Then
                    If .Row <> r And .Row <> -1 And .Redraw = True Then
                        r = .Row
                        If r < 0 Then Exit Sub
                        RaiseEvent CambioFila(r)
                        If PintarFilas And FilaSeleccionada <> r And r > 0 Then
                            'despintar EX Fila Seleccionada
                            If Grd.Rows.Count > FilaSeleccionada Then
                                Dim rg As C1.Win.C1FlexGrid.Row = Grd.Rows(FilaSeleccionada)
                                If Not rg.IsNode Then rg.StyleNew.BackColor = Color.White
                            End If
                            'pintar la Fila Seleccionada
                            Dim rg2 As C1.Win.C1FlexGrid.Row = Grd.Rows(r)
                            If Not rg2.IsNode Then rg2.StyleNew.BackColor = Color.LightBlue
                            FilaSeleccionada = r
                        End If
                    End If
                End If
            Catch ex As OverflowException
                Beep()
            Catch er As Exception

            End Try
            If .Col <> c And .Col <> -1 And .Redraw = True Then
                c = .Col
                RaiseEvent CambioColumna(c)
            End If
        End With
    End Sub
    Private Sub Grd_AfterSelChange(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.RangeEventArgs) Handles Grd.AfterSelChange
        RaiseEvent SeleccionCambio(e.NewRange.r1, e.NewRange.r2, e.NewRange.c1, e.NewRange.c2)
        With Grd
            If e.NewRange.c1 = e.NewRange.c2 Then
                If e.NewRange.r1 <> e.NewRange.r2 Then
                    Dim t As Double
                    For i As Integer = e.NewRange.r1 To e.NewRange.r2
                        If IsNumeric(Texto(i, e.NewRange.c1)) Then
                            t += Texto(i, e.NewRange.c1)
                        End If
                    Next
                    ttGenenral.SetToolTip(Grd, FormatNumber(t, 2))
                End If
            End If
        End With
    End Sub
    Private Sub Grd_BeforeSort(ByVal sender As System.Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles Grd.BeforeSort
        RaiseEvent AntesDeOrdenar()
        e.Handled = True
        Grd.Sort(New Comparador(e))
        RaiseEvent Ordenado()
    End Sub
    Private Sub Grd_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grd.DoubleClick
        RaiseEvent DobleClick(sender, e)
    End Sub
    Private Sub Grd_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grd.MouseEnter
        RaiseEvent MouseEnter(sender, e)
    End Sub
    Private Sub Grd_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grd.MouseLeave
        RaiseEvent MouseLeave(sender, e)
    End Sub


#End Region
#Region "Menu Contextual"
    Private Sub Editar_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Grd.Select()
        SendKeys.Send("{F2}")
    End Sub
    Private Sub Imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ts As New Threading.ThreadStart(AddressOf Imprimir)
        Dim th As New Threading.Thread(ts)
        th.Start()
    End Sub
    Private Sub Excel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If SaveExcel.ShowDialog() = DialogResult.OK Then
            Archivo = SaveExcel.FileName
            GuardarEnExcel(Archivo)
        End If
    End Sub
    Private Sub AutosizeCol_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        AutosizeCol(Grd.Col)
    End Sub
    Private Sub CargarDesdeExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim ts As New Threading.ThreadStart(AddressOf CargarDesdeExcel)
        Dim th As New Threading.Thread(ts)
        If MsgBox("Cuidado! Se perder� toda la informacion no guardada! Desea continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If OpenExcel.ShowDialog() = DialogResult.OK Then
                Grd.DataSource = Nothing
                Archivo = OpenExcel.FileName
                th.Start()
            End If
        End If
    End Sub
    Private Sub MnuOcultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Grd.Col <> -1 Then Grd.Cols(Grd.Col).Visible = False
    End Sub
#End Region

#Region "Custom Comparer"
    Public Class Comparador
        Implements IComparer
        Dim columna As Int32
        Dim orden As Int16
        Dim cmp As Int32

        Public Function Compare(ByVal X As Object, ByVal Y As Object) As Int32 Implements IComparer.Compare
            Dim r1 As C1.Win.C1FlexGrid.Row = X
            Dim r2 As C1.Win.C1FlexGrid.Row = Y
            Dim s1 As Object = r1(columna)
            Dim s2 As Object = r2(columna)
            Try
                If s1 Is DBNull.Value Or s1 Is Nothing Then Return +1
                If s2 Is DBNull.Value Or s2 Is Nothing Then Return -1
                If s1 = s2 Then Return 0
                Select Case s1.GetType.ToString
                    Case "System.String"
                        Return orden * String.Compare(s1, s2)
                End Select
                If s1 < s2 Then
                    cmp = -1
                Else
                    cmp = +1
                End If
                Return orden * cmp
            Catch e As Exception

            End Try

        End Function
        Public Sub New(ByVal e As C1.Win.C1FlexGrid.SortColEventArgs)
            columna = e.Col
            If e.Order = C1.Win.C1FlexGrid.SortFlags.Ascending Then
                orden = 1
            Else
                orden = -1
            End If
        End Sub
    End Class
#End Region

#Region "Custom Editor"
    Public Class clstxt
        Inherits TextBox
        Implements C1.Win.C1FlexGrid.IC1EmbeddedEditor
        Dim valor As Object
        Dim f As Boolean
        Dim WithEvents grid As C1.Win.C1FlexGrid.C1FlexGrid
        Sub New(ByVal Owner As C1.Win.C1FlexGrid.C1FlexGrid)
            MyBase.Visible = False
            MyBase.BorderStyle = BorderStyle.None
            grid = Owner
            Owner.Controls.Add(Me)
        End Sub
        Sub C1EditorInitialize(ByVal value As Object, ByVal editorAttributes As IDictionary) Implements C1.Win.C1FlexGrid.IC1EmbeddedEditor.C1EditorInitialize
            Try
                MyBase.BackColor = editorAttributes(BackColor)
                MyBase.Font = editorAttributes(Font)
                MyBase.ForeColor = editorAttributes(ForeColor)
                value = Convert.ChangeType(value, GetType(Date))
                MyBase.SelectAll()
            Catch er As Exception
            End Try
        End Sub
        Function C1EditorKeyDownFinishEdit(ByVal e As KeyEventArgs) As Boolean Implements C1.Win.C1FlexGrid.IC1EmbeddedEditor.C1EditorKeyDownFinishEdit
            Select Case e.KeyCode
                Case Keys.Escape, Keys.Enter, Keys.Tab, Keys.Up, Keys.Down, Keys.PageUp, Keys.PageDown
                    Return True
                Case Else
                    Return False
            End Select
        End Function
        Function C1EditorFormat(ByVal value As Object, ByVal mask As String) As String Implements C1.Win.C1FlexGrid.IC1EmbeddedEditor.C1EditorFormat
            Return Format(CDate(value), "dd/MM/yy")
        End Function
        Function C1EditorGetValue() As Object Implements C1.Win.C1FlexGrid.IC1EmbeddedEditor.C1EditorGetValue
            Try
                If (IsDate(valor.date)) Then
                    Return valor.date
                Else
                    Return #1/1/1900#
                End If
            Catch er As Exception
                'MsgBox(er.Message)
            End Try
        End Function
        'Sub C1EditorSetValue(ByVal value As Object) Implements C1.Win.C1FlexGrid.IC1EmbeddedEditor.C1EditorSetValue
        '    valor = value
        '    MyBase.Text = value
        'End Sub
        Function C1EditorValueIsValid() As Boolean Implements C1.Win.C1FlexGrid.IC1EmbeddedEditor.C1EditorValueIsValid
            If IsDate(grid.Editor.Text) Then
                Return True
            Else
                MyBase.Focus()
                MyBase.SelectAll()
                Return False
            End If
        End Function
        Sub C1EditorUpdateBounds(ByVal rc As Rectangle) Implements C1.Win.C1FlexGrid.IC1EmbeddedEditor.C1EditorUpdateBounds
            MyBase.Bounds = rc
        End Sub
        Function C1EditorGetStyle() As Drawing.Design.UITypeEditorEditStyle Implements C1.Win.C1FlexGrid.IC1EmbeddedEditor.C1EditorGetStyle
        End Function
        Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean

            If (keyData = Keys.Enter) Then

                Parent.Focus()

                'If (Parent.Focused) Then SendKeys.Send("{RIGHT}")



                Return True

            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function

        
    End Class
#End Region

#Region "KeyRelations"
    Public Sub AgregarTeclas(ByVal Tecla As Integer, ByVal ParamArray Columnas() As Integer)
        ReDim Preserve TeclasManejadas(TeclasManejadas.GetUpperBound(0) + 1) 'redimensiono
        TeclasManejadas(TeclasManejadas.GetUpperBound(0)) = Tecla 'la atacheo
        Array.Sort(TeclasManejadas) 'lo ordeno para el binary search
        TeclasCol.Add(Columnas, Tecla.ToString & "a")
    End Sub
    Public Sub Reset_Teclas()
        TeclasCol.Clear()
    End Sub
    Private Sub MoverCursor(ByVal tecla As Integer)
        Dim Columnas() As Integer
        Try
            Columnas = TeclasCol.Item(tecla.ToString & "a")
        Catch ex As Exception
            Exit Sub
        End Try
        Dim i As Integer
        For i = 0 To Columnas.GetUpperBound(0)
            If Columnas(i) = Grd.Col Then
                If i = Columnas.GetUpperBound(0) Then
                    Grd.Col = Columnas(0)
                    Exit For
                Else
                    Grd.Col = Columnas(i + 1)
                    Exit For
                End If
            End If
        Next
        If i >= Columnas.GetUpperBound(0) Then 'el cursor no esta en ningun lado, lo tiramos en la primer columna
            Grd.Select(Grd.Row, Columnas(0))
        End If
    End Sub
    Public Sub BorrarTeclas(ByVal Tecla As Integer)
        Dim i As Integer
        ReDim Preserve TeclasManejadas(TeclasManejadas.GetUpperBound(0) - 1)
        For i = 0 To TeclasManejadas.GetUpperBound(0)
            If Tecla = TeclasManejadas(i) Then
                TeclasManejadas(i) = 999 'Pwned! n00bcakes :p
            End If
        Next
        Array.Sort(TeclasManejadas) ' lo sorteo para que quede al final
        TeclasCol.Remove(Tecla & "a") 'y lo quito del collection        
    End Sub

#End Region

End Class

Public Class ClsFormulas
    Public mVar() As String

    Public Function AsignarVar(ByVal Texto As String) As String
        Dim i As Integer, varIter As String, vTexto As String
        Dim varFin As Integer, varF As Integer, varC As Integer

        'Funci�n suma
        i = InStr(Texto, "@")
        If i Then
            Texto = Mid$(Texto, 1, i - 1) & SumarRango(Mid$(Texto, i + 1))
        End If
        'Esto reemplaza todas las celdas ( [Fila;Columna] ) por sus valores
        i = InStr(Texto, "[")
        Do While i
            vTexto = Right$(Texto, Len(Texto) - i)
            varFin = InStr(vTexto, "]")
            vTexto = Left$(vTexto, varFin - 1)
            varF = CInt(Left$(vTexto, InStr(vTexto, ";") - 1))
            varC = CInt(Mid$(vTexto, InStr(vTexto, ";") + 1))
            varIter = BuscarValor(varF, varC)

            varFin = InStr(Texto, "]")
            Texto = Left$(Texto, i - 1) & varIter & Right$(Texto, Len(Texto) - varFin)
            i = InStr(Texto, "[")
        Loop
        'Analizar Texto
        'por ejemplo: 3+(2*5)
        vTexto = BuscarOp(Texto)
        AsignarVar = vTexto
    End Function
    Public Function AnalizarTexto(ByVal Texto As String) As String
        Dim i As Integer, vTexto As String, Loop1 As Integer
        Dim a As Integer, t As String, Loop2 As Integer

        Const cLetras As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Const cOperad As String = "=+-*/%@() "
        Texto = Trim(Texto)
        Texto = UCase(Texto)
        i = InStr(Texto, "SUMA")
        If i Then
            vTexto = Mid$(Texto, i + 5, (InStr(i, Texto, ")") - i - 5))
            a = InStr(vTexto, ":")
            t = CrearRango(Mid$(vTexto, 1, a - 1), True)
            t = "@" & t & ":" & CrearRango(Mid$(vTexto, a + 1), True) & " "
            Texto = Mid$(Texto, 1, i - 1) & t & Mid$(Texto, InStr(Texto, ")") + 1)
        End If
        Texto = Texto & " "
        For Loop1 = 1 To Len(cLetras)
            i = InStr(Texto, Mid$(cLetras, Loop1, 1))
            If i Then
                'si hay una letra es un rango
                'buscar el par ej: B3
                'a = InStr(Texto, ")")
                'vTexto = Texto
                'Do While a
                '   f = InStrRev(vTexto, "(", a)
                '  t = Mid$(vTexto, f + 1, a - f - 1)
                ' t = AnalizarTexto(t)
                'vTexto = Left$(vTexto, f) & t & Mid$(vTexto, a)
                'a = InStr(vTexto, ")")
                'Loop
                For Loop2 = i To Len(Texto)
                    For a = 1 To Len(cOperad)
                        If Mid$(cOperad, a, 1) = Mid$(Texto, Loop2, 1) Then
                            Texto = Mid$(Texto, 1, i - 1) & CrearRango(Mid$(Texto, i, Loop2 - i)) & Mid$(Texto, Loop2)
                            Loop1 = Loop1 - 1
                            Loop2 = Len(Texto)
                            Exit For
                        End If
                    Next
                Next
            End If
        Next
        Texto = Trim$(Texto)
        AnalizarTexto = Texto
    End Function
    Public Function CalcularF(ByVal Texto As String) As Double
        Dim i As Integer, varIter As Integer, vTexto As String = "", n As Double
        Dim Loop1 As Integer, varCalc() As Double = Nothing, varOp() As String = Nothing

        Const vNum As String = "0123456789,"

        Texto = Texto & ")"
        For i = 1 To Len(Texto)
            If InStr(vNum, Mid$(Texto, i, 1)) Then
                vTexto = vTexto & Mid$(Texto, i, 1)
            Else
                varIter = varIter + 1
                ReDim Preserve varOp(varIter)
                ReDim Preserve varCalc(varIter)
                If Len(vTexto) Then
                    varCalc(varIter) = CDbl(vTexto)
                Else
                    varCalc(varIter) = 0
                End If
                If Mid$(Texto, i, 1) <> ")" Then
                    varOp(varIter) = Mid$(Texto, i, 1)
                End If
                vTexto = ""
            End If
        Next i
        If varIter Then
            n = varCalc(1)
        End If
        For Loop1 = 1 To varIter - 1
            Select Case varOp(Loop1)
                Case "+"
                    n = n + varCalc(Loop1 + 1)
                Case "-"
                    n = n - varCalc(Loop1 + 1)
                Case "*"
                    n = n * varCalc(Loop1 + 1)
                Case "/"
                    If varCalc(Loop1 + 1) <> 0 Then
                        n = n / varCalc(Loop1 + 1)
                    Else
                        'MsgBox "Divisi�n por cero.", vbCritical, "Error"
                        n = 0
                    End If
                Case "%"
                    n = n * (varCalc(Loop1 + 1) / 100)

            End Select
        Next
        CalcularF = n
    End Function
    Private Function BuscarOp(ByVal Texto As String) As String
        Dim i As Integer, vTexto As String
        Dim varFin As Integer, s As Integer, vTextFinal As String

        If Mid$(Texto, 1, 1) = "=" Then
            Texto = Mid$(Texto, 2)
        End If
        s = InStr(Texto, "(")
        Do While s
            vTexto = Texto
            varFin = InStr(s, vTexto, ")")
            i = InStrRev(Texto, "(", varFin)
            vTexto = Mid$(Texto, i + 1, varFin - i - 1)

            If Not IsNumeric(Left$(vTexto, 1)) Then
                vTexto = Mid$(vTexto, 2)
            End If
            vTextFinal = CalcularF(vTexto)
            Texto = Left(Texto, i - 1) & vTextFinal & Right(Texto, Len(Texto) - varFin)
            s = InStr(Texto, "(")
        Loop
        vTextFinal = CalcularF(Texto)
        BuscarOp = vTextFinal
    End Function
    Private Function BuscarValor(ByVal f As Integer, ByVal c As Integer) As Object

        If Mid$(mVar(f).Chars(c), 1, 1) = "=" Then
            'mVar(f).Chars(c) = AsignarVar(Mid$(mVar(f).Chars(c), 2))
            Mid(mVar(f), c, 1) = AsignarVar(Mid$(mVar(f).Chars(c), 2))
        End If
        If IsNumeric(mVar(f).Chars(c)) Then
            BuscarValor = mVar(f).Chars(c)
        Else
            BuscarValor = 0
        End If
        Exit Function
        BuscarValor = 0
    End Function
    Private Function SumarRango(ByVal Texto As String) As String
        Dim i As Integer, varIter As Integer, vTexto As String, n As Double
        Dim varF(1) As Integer, varC(1) As Integer, c As Integer, f As Integer

        i = InStr(Texto, ";")
        vTexto = Left$(Texto, i - 1)
        varF(0) = CInt(vTexto)
        Texto = Mid$(Texto, i + 1)
        i = InStr(Texto, ":")
        vTexto = Left$(Texto, i - 1)
        varC(0) = CInt(vTexto)
        Texto = Mid$(Texto, i + 1)

        i = InStr(Texto, ";")
        vTexto = Left$(Texto, i - 1)
        varF(1) = CInt(vTexto)
        Texto = Mid$(Texto, i + 1)
        varIter = InStr(Texto, " ")
        If varIter Then
            varC(1) = CInt(Mid$(Texto, 1, Len(Texto) - varIter - 1))
            Texto = Mid$(Texto, varIter + 1)
        Else
            varC(1) = CInt(Texto)
            Texto = ""
        End If
        For f = varF(0) To varF(1)
            For c = varC(0) To varC(1)
                If IsNumeric(mVar(f).Chars(c)) Then
                    n = n + Char.GetNumericValue(mVar(f).Chars(c))
                Else
                    If Mid$(mVar(f).Chars(c), 1, 1) = "=" Then
                        vTexto = AsignarVar(mVar(f).Chars(c))
                        n = n + CDbl(vTexto)
                    End If
                End If
            Next
        Next
        SumarRango = n & Texto
    End Function
    Private Function CrearRango(ByVal Texto As String, Optional ByVal esSuma As Boolean = False) As String
        Dim c As Integer, f As Integer, a As Integer

        For a = 1 To Len(Texto)
            If IsNumeric(Mid$(Texto, a, 1)) Then
                If InStr(Texto, ")") Then
                    f = CLng(Mid$(Texto, a, InStr(Texto, ")") - a))
                Else
                    f = CLng(Mid$(Texto, a))
                End If
                Exit For
            Else
                c = Asc(Mid$(Texto, a, 1)) - 64
            End If
        Next
        If esSuma Then
            CrearRango = f & ";" & c
        Else
            CrearRango = "[" & f & ";" & c & "]"
        End If
    End Function
End Class
