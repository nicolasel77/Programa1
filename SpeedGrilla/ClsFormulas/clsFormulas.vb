Public Class ClsFormulas
    Public mVar() As String

    Public Function AsignarVar(ByVal Texto As String) As String
        Dim i As Integer, varIter As String, vTexto As String
        Dim varFin As Integer, varF As Integer, varC As Integer

        'Función suma
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
        Dim i As Integer, vTexto As String, Loop1 As Integer, vFor As String
        Dim c As Integer, f As Integer, a As Integer, t As String, Loop2 As Integer

        Const cLetras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        Const cOperad = "=+-*/%@() "
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
        Dim i As Integer, varIter As Integer, vTexto As String, n As Double
        Dim Loop1 As Integer, varCalc() As Double, varOp() As String

        Const vNum = "0123456789,"

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
                        'MsgBox "División por cero.", vbCritical, "Error"
                        n = 0
                    End If
                Case "%"
                    n = n * (varCalc(Loop1 + 1) / 100)

            End Select
        Next
        CalcularF = n
    End Function
    Private Function BuscarOp(ByVal Texto As String) As String
        Dim i As Integer, varIter As Integer, vTexto As String
        Dim Loop1 As Integer, varFin As Integer, s As Integer, vTextFinal As String

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
