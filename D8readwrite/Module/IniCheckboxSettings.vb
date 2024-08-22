Imports ISA.Utility.Data

Module IniCheckboxSettings

    Private ReadOnly IniCheckboxSettings As String = "CHECKBOX STATE"

    Public Function GetCheckboxSettings() As ReadWriteSettings.CheckBoxSettings
        Dim Ini As New IniFileIO
        Dim result As New ReadWriteSettings.CheckBoxSettings

        result.CheckBoxState = Ini.GetBoolean(IniCheckboxSettings, "Checkbox", False)
        result.CheckBoxState1 = Ini.GetBoolean(IniCheckboxSettings, "CheckBox1", False)
        Return result

    End Function

    Public Sub SaveIniCheckBoxSettings(ByVal checkState As ReadWriteSettings.CheckBoxSettings)

        Dim Ini As New IniFileIO

        Ini.WriteBoolean(IniCheckboxSettings, "Checkbox", checkState.CheckBoxState)
        Ini.WriteBoolean(IniCheckboxSettings, "Checkbox1", checkState.CheckBoxState1)

    End Sub
End Module
