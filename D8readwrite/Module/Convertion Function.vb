Module Convertion_Function


    Public Structure DaTe_F
        Public DF As String
        Public DT As String
    End Structure

    Public Function Fdate(ByVal date1 As Date, ByVal date2 As Date) As DaTe_F
        Dim s As New DaTe_F
        s.DF = Format(CDate(date1), "yyyy-MM-dd HH:mm:ss")
        s.DT = Format(CDate(date2), "yyyy-MM-dd HH:mm:ss")
        Return s
    End Function

    Function HexToString(ByVal strHex As String) As String
        Dim strMakeText As String, lngCharCount As Long
        strMakeText = Space$(Len(strHex) \ 2)
        For lngCharCount = 1 To Len(strHex) \ 2
            Mid$(strMakeText, lngCharCount, 1) = Chr(Val("&H" & Mid$(strHex, (lngCharCount * 2) - 1, 2)))
        Next lngCharCount
        Return strMakeText
    End Function

    Function StringToHex(ByVal alpha As String) As String
        Dim str As String = vbNullString
        Dim Val As String = vbNullString
        Dim i As Long
        For i = 1 To alpha.Length
            str = Mid(alpha, i, 1)
            Dim xx As String
            xx = Hex(Asc(str))
            Val = Val + xx
        Next i

        If Val.Length > 32 Then
            Return vbNullString
        End If

        Val = Val + New String("0", 32 - Val.Length)

        Return Val
    End Function

    Public Function Set_Data32(ByVal data As String) As String

        Dim Hstr As String = String.Empty
        Dim Dstr As String = StringToHex(data)
        Dim Dlen As Integer = Dstr.Length
        Dim Glen As Integer = 0
        If Dlen < 32 Then
            Glen = 32 - Dlen
            Hstr = New String("0", Glen)
        End If

        Dim NStr As String = Dstr & Hstr
        Dim HoldData As String = String.Empty
        Dim Fstr As String = String.Empty
        Dim i As Integer = 0

        For i = 1 To 32 Step 2
            Dim X As String = Mid$(NStr, i, 2)
            HoldData = HoldData + X & " "
        Next
        Return HoldData

    End Function

    Public Function Set_Data(ByVal Data As String) As String
        Return Trim$(Data.Replace(Chr("0"), vbNullString))
    End Function

    Public Function Convert_Code(ByVal Code As String) As String
        Dim CC As String = Hex$(Code)
        Dim i As Integer = 8 - CC.Length
        Dim Ncc As String = New String("0", i)
        If CC.Length < 8 Then
            CC = Ncc & CC
        End If

        Dim S78 As String = Mid$(CC, 7, 2)
        Dim S65 As String = Mid$(CC, 5, 2)
        Dim S43 As String = Mid$(CC, 3, 2)
        Dim S12 As String = Mid$(CC, 1, 2)
        Return S78 & S65 & S43 & S12
    End Function

    Public Function check_input(ByVal user As String, ByVal pass As String) As Boolean
        'Number and Letters only
        Dim str As String = user & pass
        Dim sb As New System.Text.StringBuilder
        For Each ch As Char In str
            If Char.IsLetterOrDigit(ch) = False Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Function Set_TimeRange(ByVal D1 As DateTime, ByVal D2 As DateTime) As String
        Dim start_time As DateTime = D1
        Dim stop_time As DateTime = D2
        Dim diff As TimeSpan = stop_time.Subtract(start_time)
        Return FormatTimeSpan(diff)
    End Function

    Private Function FormatTimeSpan(ByVal time_span As TimeSpan, Optional ByVal whole_seconds As Boolean = True) As String
        Dim txt As String = ""

        If time_span.Days >= 0 Then
            txt &= ", " & time_span.Days.ToString() & "D"
            time_span = time_span.Subtract(New TimeSpan(time_span.Days, 0, 0, 0))
        End If
        If time_span.Hours >= 0 Then
            txt &= ", " & time_span.Hours.ToString() & "H"
            time_span = time_span.Subtract(New TimeSpan(0, time_span.Hours, 0, 0))
        End If

        If time_span.Minutes >= 0 Then
            txt &= ", " & time_span.Minutes.ToString() & "m"
            time_span = time_span.Subtract(New TimeSpan(0, 0, time_span.Minutes, 0))
        End If

        If whole_seconds Then
            ' Display only whole seconds.
            If time_span.Seconds > 0 Then
                txt &= ", " & time_span.Seconds.ToString() & "s"
            End If
        Else
            ' Display fractional seconds.
            txt &= ", " & time_span.TotalSeconds.ToString() & "s"
        End If

        ' Remove the leading ", ".
        If txt.Length > 0 Then txt = txt.Substring(2)

        ' Return the result.
        Return txt
    End Function

    Public Structure Time_Span
        Public Day As Integer
        Public Hour As Integer
        Public Min As Integer
    End Structure

    Public Function Get_TimeSpan(ByVal Tin As DateTime, ByVal Tout As DateTime) As Time_Span
        Dim diff As TimeSpan = Tout.Subtract(Tin)
        Dim x As New Time_Span

        If diff.Days > 0 Then
            x.Day = diff.Days
            diff = diff.Subtract(New TimeSpan(diff.Days, 0, 0, 0))
        End If

        If diff.Hours > 0 Then
            x.Hour = diff.Hours
            diff = diff.Subtract(New TimeSpan(0, diff.Hours, 0, 0))
        End If

        If diff.Minutes > 0 Then
            x.Min = diff.Minutes
            diff = diff.Subtract(New TimeSpan(0, 0, diff.Minutes, 0))
        End If
        Return x
    End Function

    Public Function Make_Neg(ByVal Amount As Double) As Double
        Return Amount * -1
    End Function



End Module
