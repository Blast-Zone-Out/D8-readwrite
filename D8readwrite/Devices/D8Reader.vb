Imports COMRD800Lib
Imports System.Text

''' <summary>
''' Represents a D8 reader for handling card operations.
''' </summary>
Public Class D8Reader
    Implements IDisposable

#Region "Definitions"
    ''' <summary>
    ''' The port name for the D8 reader.
    ''' </summary>
    Private _port As String

    ''' <summary>
    ''' The baud rate for the D8 reader.
    ''' </summary>
    Private _baudRate As Integer

    ''' <summary>
    ''' The D8 reader class.
    ''' </summary>
    ''' <remarks></remarks>
    Private _d8Reader As RD800Class

    ''' <summary>D8 settings</summary>
    Public Structure ConfigInfo
        ''' <summary>D8 port</summary>
        Public PortName As String
        ''' <summary>D8 BaudRate</summary>
        Public BaudRate As Integer
        ''' <summary>Check if D8 is enabled</summary>
        Public Enabled As Boolean
    End Structure

#End Region

#Region "Constructor"
    ''' <summary>
    ''' Initializes a new instance of the <see cref="D8Reader"/> class.
    ''' </summary>
    ''' <param name="newConfig">Configuration of D8.</param>
    Public Sub New(ByVal newConfig As ConfigInfo)
        _port = newConfig.PortName
        _baudRate = newConfig.BaudRate
        _d8Reader = New RD800Class
    End Sub
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Connects to the D8 reader.
    ''' </summary>
    ''' <returns><c>true</c> if the connection is successful; otherwise, <c>false</c>.</returns>
    Public Function Connect() As Boolean
        Dim PortNumber As Integer
        If _port = "USB" Then
            PortNumber = 100
        ElseIf _port.Substring(0, 3) = "COM" Then
            PortNumber = CInt(_port.Substring(3, 1)) - 1
        Else
            PortNumber = -1
        End If

        Try
            Dim response As Integer = _d8Reader.dc_init(PortNumber, _baudRate)

            If response < 0 Then
                Save_Logs("D8 is not Connected", LogType.System)
                Return False
            End If

            Return True

        Catch ex As Exception
            Save_Logs("D8Reader.Connect error: " & ex.Message & vbCrLf & ex.ToString, LogType.System)
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Disconnects to the D8 reader.
    ''' </summary>
    ''' <returns><c>true</c> if the disconnect is successful; otherwise, <c>false</c>.</returns>
    Public Function Disconnect() As Boolean
        Try
            Dim response As Integer = _d8Reader.dc_exit

            If response < 0 Then
                Save_Logs("D8 is not Disconnect", LogType.System)
                Return False
            End If

            Return True

        Catch ex As Exception
            Save_Logs("D8Reader.Disconnect error: " & ex.Message & vbCrLf & ex.ToString, LogType.System)
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Gets the card code.
    ''' </summary>
    ''' <returns>The card code.</returns>
    Public Function GetCardCode(Optional ByVal convetToHex As Boolean = True) As String
        Dim result As String = String.Empty

        If Me.Connect() = False Then
            Save_Logs("D8Reader.GetCardCode failed: D8 is not Connected", LogType.System)
            Return result
        End If

        Try
            Dim tempResult As String = String.Empty
            Dim response As Integer = _d8Reader.dc_card(0, tempResult)

            If response < 0 Then
                Save_Logs("D8Reader.GetCardCode failed: response = " & response.ToString, LogType.System)
                Return result
            End If

            If response = 1 Then
                Save_Logs("D8Reader.GetCardCode failed: no card", LogType.System, True)
                Return result
            End If

            If (String.IsNullOrEmpty(tempResult) = False) Then
                If convetToHex Then
                    Dim hexCode As String = Hex(tempResult).PadLeft(8, "0")
                    result = Mid(hexCode, 7, 2) & Mid(hexCode, 5, 2) & Mid(hexCode, 3, 2) & Mid(hexCode, 1, 2)
                Else
                    result = tempResult
                End If
            End If

            Return result

        Catch ex As Exception
            Save_Logs("D8Reader.GetCardCode error: " & ex.Message & vbCrLf & ex.ToString, LogType.System)
            Return result
        End Try

        Me.Disconnect()

    End Function

    ''' <summary>
    ''' Reads data from the specified sector.
    ''' </summary>
    ''' <param name="sector">The sector number.</param>
    ''' <returns>The read sector data.</returns>
    Public Function Read(ByVal sector As Integer) As String
        Dim result As String = String.Empty

        If Me.Connect() = False Then
            Save_Logs("D8Reader.Read failed: D8 is not Connected", LogType.System)
            Return result
        End If

        Dim response As Integer = _d8Reader.dc_card(0, Nothing)

        If response = 1 Then
            Save_Logs("D8Reader.GetCardCode failed: no card", LogType.System, True)
            Return result
        End If

        If Me.LoadKey(sector) = False Then
            Save_Logs("D8Reader.Read failed: LoadKey failed", LogType.System)
            Return result
        End If

        If Me.Authenticate(sector) = False Then
            Save_Logs("D8Reader.Read failed: Authenticate failed", LogType.System)
            Return result
        End If

        Dim sectorStartAddress As Integer = (sector * 4)
        Dim tempResult As New StringBuilder
        For block = 0 To 2
            Dim blockData As String = Me.ReadBlock(sectorStartAddress + block)
            tempResult.Append(blockData)
        Next

        result = tempResult.ToString.Trim

        Me.Disconnect()

        Return result
    End Function

    ''' <summary>
    ''' Writes data to the specified sector.
    ''' </summary>
    ''' <param name="sector">The sector number.</param>
    ''' <param name="data">The sector data.</param>
    ''' <returns><c>true</c> if the write operation is successful; otherwise, <c>false</c>.</returns>
    Public Function Write(ByVal sector As Integer, ByVal data As String) As Boolean

        If data.Length > 48 Then
            Dim excessData As Integer = data.Length - 48
            Save_Logs("D8Reader.Write failed: data exceed by " & excessData.ToString & " characters" & vbCrLf & "Data: " & data, LogType.System)
            Return False
        End If

        If Me.Connect() = False Then
            Save_Logs("D8Reader.Write failed: D8 is not Connected", LogType.System)
            Return False
        End If

        If Me.LoadKey(sector) = False Then
            Save_Logs("D8Reader.Write failed: LoadKey failed", LogType.System)
            Return False
        End If

        If Me.Authenticate(sector) = False Then
            Save_Logs("D8Reader.Write failed: Authenticate failed", LogType.System)
            Return False
        End If

        'Data Preparation
        Dim formattedData As String = data.PadRight(48, " ")


        Dim sectorStartAddress As Integer = (sector * 4)
        For block = 0 To 2
            Dim substringStartIndex As Integer = block * 16
            Dim currentAddress As Short = sectorStartAddress + block
            Dim sendData As String = formattedData.Substring(substringStartIndex, 16)
            Try
                _d8Reader.dc_restore(currentAddress)
                _d8Reader.put_bstrSBuffer_asc = StringToHexString(sendData)
                Dim response As Integer = _d8Reader.dc_write(currentAddress)

                If response < 0 Then
                    Save_Logs("D8Reader.Write failed: response = " & response.ToString & " @ sector " & sector & ", block " & block & ", address " & currentAddress, LogType.System)
                    Return False
                End If

            Catch ex As Exception
                Save_Logs("D8Reader.Write error @ sector " & sector & ", block " & block & ", address " & currentAddress & ": " & ex.Message & vbCrLf & ex.ToString, LogType.System)
                Return False
            End Try

        Next

        Me.Disconnect()

        Return True
    End Function

    ''' <summary>
    ''' Clears the card data for the specified sectors.
    ''' </summary>
    ''' <param name="sector">The sectors to clear.</param>
    Public Function ClearSector(ByVal sector As Integer) As Boolean
        Dim blankData As String = New String(" "c, 48)
        Dim result As Boolean = Me.Write(sector, blankData)
        Return result
    End Function

    ''' <summary>
    ''' Triggers a beep sound.
    ''' </summary>
    ''' <param name="ms">Lenght of sound in MS</param>
    ''' <remarks></remarks>
    Public Sub Beep(Optional ByVal ms As Integer = 10)

        If Me.Connect() = False Then
            Save_Logs("D8Reader.beep failed: D8 is not Connected", LogType.System)
            Exit Sub
        End If

        _d8Reader.dc_beep(ms)

        Me.Disconnect()
    End Sub
#End Region

#Region "Private Methods"
    ''' <summary>
    '''  Load card password into the D8 reader.
    ''' </summary>
    ''' <returns><c>true</c> if the authentication is successful; otherwise, <c>false</c>.</returns>
    Private Function LoadKey(ByVal sector As Short) As Boolean

        _d8Reader.put_bstrSBuffer_asc = "FFFFFFFFFFFF"
        Dim response As Integer = _d8Reader.dc_load_key(0, sector)

        Try
            If response < 0 Then
                Save_Logs("D8Reader.LoadKey failed: response = " & response.ToString, LogType.System)
                Return False
            End If
            Return True

        Catch ex As Exception
            Save_Logs("D8Reader.LoadKey error: " & ex.Message & vbCrLf & ex.ToString, LogType.System)
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Authenticates the D8 reader.
    ''' </summary>
    ''' <returns><c>true</c> if the authentication is successful; otherwise, <c>false</c>.</returns>
    Private Function Authenticate(ByVal sector As Short) As Boolean

        Dim response As Integer = _d8Reader.dc_authentication(0, sector)

        Try
            If response < 0 Then
                Save_Logs("D8Reader.Authenticate failed: response = " & response.ToString, LogType.System)
                Return False
            End If

            Return True
        Catch ex As Exception
            Save_Logs("D8Reader.Authenticate error: " & ex.Message & vbCrLf & ex.ToString, LogType.System)
            Return False
        End Try

    End Function

    ''' <summary>
    ''' Read a block of Mifare card.
    ''' </summary>
    ''' <returns><c>true</c> if the authentication is successful; otherwise, <c>false</c>.</returns>
    Private Function ReadBlock(ByVal address As Short) As String
        'No connect needed assuming this is only used within this class
        Dim result As String

        'Read card
        Try
            Dim response As Integer = _d8Reader.dc_read(address)
            If response < 0 Then
                Return String.Empty
            End If
        Catch ex As Exception
            Save_Logs("D8Reader.ReadBlock dc_read error: " & ex.Message & vbCrLf & ex.ToString, LogType.System)
            result = String.Empty
        End Try

        'Read cardReader buffer
        Try
            result = CStr(_d8Reader.get_bstrRBuffer)
        Catch ex As Exception
            Save_Logs("D8Reader.ReadBlock get_bstrRBuffer error: " & ex.Message & vbCrLf & ex.ToString, LogType.System)
            result = String.Empty
        End Try

        'Return result
        Return result
    End Function

    ''' <summary>
    ''' Converts a string into its hexadecimal representation based on ASCII values.
    ''' </summary>
    ''' <param name="data">The input string to convert.</param>
    ''' <returns>A string representing the hexadecimal representation of the input string.</returns>
    Private Function StringToHexString(ByVal data As String) As String

        Dim result As String = String.Empty
        Dim hexDataStringBuilder As New System.Text.StringBuilder

        For Each c As Char In data
            Dim hexString As String = Convert.ToInt32(c).ToString("X2")
            hexDataStringBuilder.Append(hexString)
        Next

        result = hexDataStringBuilder.ToString()

        Return result
    End Function
#End Region

#Region " IDisposable Support "
    Private disposedValue As Boolean = False        ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: free other state (managed objects).
            End If

            Me.Disconnect()
            _port = Nothing
            _baudRate = Nothing
        End If
        Me.disposedValue = True
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
