Imports ISA.Utility.Data
Module IniSettings

    Private ReadOnly ConfigSectionD8 As String = "D8 SETTINGS"


    Public Function GetConfigInfoD8() As D8Reader.ConfigInfo
        Dim Ini As New IniFileIO
        Dim Result As New D8Reader.ConfigInfo

        Result.PortName = Ini.GetString(ConfigSectionD8, "PORT", "USB")
        Result.BaudRate = Ini.GetInteger(ConfigSectionD8, "BAUDRATE", 115200)
        Result.Enabled = True

        Return Result
    End Function

    Public Sub SaveConfigInfoD8(ByVal newconfig As D8Reader.ConfigInfo)
        Dim Ini As New IniFileIO

        Ini.WriteString(ConfigSectionD8, "PORT", "USB")
        Ini.WriteInteger(ConfigSectionD8, "BAUDRATE", 115200)
        Ini.WriteBoolean(ConfigSectionD8, "D8 DEVICE", True)
    End Sub
End Module
