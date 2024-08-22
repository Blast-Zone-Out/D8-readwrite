Imports ISA.Utility.Data
Public Class ReadWriteSettings

    Private Sub ReadWriteSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As DatabaseManager.Configuration = GetLocalDatabaseConfig()
        txtIpAddress.Text = x.ipAddress
        txtDataBaseName.Text = x.databaseName
        txtPort.Text = x.port
        txtUserName.Text = x.username
        txtPassword.Text = x.password
        txtDriver.Text = x.driver

        Dim c As ReadWriteSettings.CheckBoxSettings = GetCheckboxSettings()
        CheckBox2.Checked = c.CheckBoxState

    End Sub



    Private Function ReadWriteSettingsEnabled(ByVal Enabled As Boolean) As Boolean

        txtIpAddress.Enabled = Enabled
        txtPort.Enabled = Enabled
        txtUserName.Enabled = Enabled
        txtPassword.Enabled = Enabled
        txtDataBaseName.Enabled = Enabled
        txtDriver.Enabled = Enabled
        'BtnSave.Enabled = Enabled
        'BtnTesting.Enabled = Enabled

    End Function

    Private Function ReadWriteEnabled(ByVal Enable As Boolean) As Boolean

        Translate.txtCardCode.Enabled = Enable
        Translate.txtSiteID.Enabled = Enable
        Translate.txtEntryID.Enabled = Enable
        Translate.CBxVehicleID.Enabled = Enable
        Translate.txtTimeIN.Enabled = Enable
        Translate.txtPlateno.Enabled = Enable
        Translate.BtnWrite.Enabled = Enable

        Translate.BtnReadAll.Enabled = Enable
        Translate.txtTranslate.Enabled = Enable
        Translate.BtnTranslate.Enabled = Enable
        Translate.BtnSync.Enabled = Enable
        Button1.Enabled = Enable
        'SECTOR 4
        Translate.txtSiteIDSector4.Enabled = Enable
        Translate.txtPosID.Enabled = Enable
        Translate.txtXGrace.Enabled = Enable
        Translate.txtTransTime.Enabled = Enable
        Translate.txtCrID.Enabled = Enable
        Translate.Button3.Enabled = Enable
        Translate.txtReadCardSector4.Enabled = Enable
        Translate.BtnReadAllSector4.Enabled = Enable
        Translate.txtTranslateSector4.Enabled = Enable
        Translate.BtnTranslateSector4.Enabled = Enable
        Translate.BtnSyncSector4.Enabled = Enable
        Return True
    End Function

    Public Structure CheckBoxSettings
        Public CheckBoxState As Boolean
        Public CheckBoxState1 As Boolean
    End Structure

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        ReadWriteSettingsEnabled(CheckBox2.Checked)

        ReadWriteEnabled(CheckBox2.Checked)

    End Sub


    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim c As ReadWriteSettings.CheckBoxSettings
        Dim x As DatabaseManager.Configuration

        x.ipAddress = txtIpAddress.Text
        x.databaseName = txtDataBaseName.Text
        x.port = txtPort.Text
        x.username = txtUserName.Text
        x.password = txtPassword.Text
        x.databaseName = txtDataBaseName.Text
        x.driver = txtDriver.Text
        x.isOk = True

        'checkbox stateinp
        c.CheckBoxState = CheckBox2.CheckState
        c.CheckBoxState1 = CheckBox2.CheckState
        Try

            SaveLocalDatabaseConfig(x)
            SaveIniCheckBoxSettings(c)

            MsgBox("SAVED", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Fail" & vbCrLf & ex.Message)
        End Try




        'Dim t As TextBoxt
        't.textbo1 = txtIpAddress.Text
        't.textbox2 = txtPort.Text
        't.textbox3 = txtDataBaseName.Text
        't.textbox4 = txtUserName.Text
        't.textbox5 = txtPassword.Text
        't.textbox6 = txtDriver.Text
        't.textbox7 = CheckBox1.Checked
        'SaveTextBoxt(t)


    End Sub

    Private Sub BtnTesting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTesting.Click
        Dim x As DatabaseManager.Configuration
        x.ipAddress = txtIpAddress.Text
        x.databaseName = txtDataBaseName.Text
        x.port = txtPort.Text
        x.username = txtUserName.Text
        x.password = txtPassword.Text
        x.databaseName = txtDataBaseName.Text
        x.driver = txtDriver.Text
        x.isOk = True

        Using dbConn As New DatabaseManager(x)
            If dbConn.Status = True Then
                MsgBox("Successfully Connected", MsgBoxStyle.Information, "CONNECTED")
            Else
                MsgBox("Not Connected", MsgBoxStyle.Exclamation, "NOT CONNECTED")
            End If
        End Using

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Me.Close()
    End Sub
End Class