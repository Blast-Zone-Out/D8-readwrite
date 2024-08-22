Imports ISA.Utility.Data

Public Class Translate

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim a As New ReadWrite
        a.ShowDialog()

    End Sub

    Private Sub Form2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim reader As New D8Reader(GetConfigInfoD8)
        If e.KeyCode = Keys.Enter Then
            'Me.txtCardCode.Text = D8_GetCard(False)
            Me.txtCardCode.Text = reader.GetCardCode(False)
            reader.Beep()
        End If

        ' Check if "Ctrl + Insert" keys are pressed
        If e.Control AndAlso e.KeyCode = Keys.Insert Then
            ' Show ReadWriteSettings FORM
            Dim settingsForm As New ReadWriteSettings()
            settingsForm.Show()
        End If

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As New D8Reader.ConfigInfo
        Dim c As ReadWriteSettings.CheckBoxSettings = GetCheckboxSettings()

        ReadWriteSettings.CheckBox2.Checked = c.CheckBoxState1


        Dim reader As New D8Reader(GetConfigInfoD8)
        'D8_Connect()
        reader.Connect()
        'Me.txtCardCode.Text = D8_GetCard(False)
        Me.txtCardCode.Text = reader.GetCardCode
        Me.txtTimeIN.Text = Date.Now
        Me.txtTransTime.Text = Date.Now
        CBxVehicleID.SelectedIndex = 0

        SaveConfigInfoD8(x)

    End Sub




#Region "Sector 3"

    Private Sub BtnWrite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWrite.Click
        Try
            Dim siteid As String = txtSiteID.Text
            Dim entryid As String = txtEntryID.Text
            Dim TimeIn As String = TimeConversion.LocalToUnixTimestamp(CDate(txtTimeIN.Text)).ToString
            Dim PlateNo As String = txtPlateno.Text.Replace(" ", "").ToUpper.Trim


            If Write(siteid, entryid, TimeIn, PlateNo) = True Then
                MsgBox("SUCCESS")
            Else
                MsgBox("FAIL")
            End If
        Catch ex As Exception
            MsgBox("Fail" & vbCrLf & ex.Message)
        End Try
        
    End Sub

    'Function for Write
    Public Function Write(ByVal siteid As String, ByVal entryid As String, ByVal TimeIn As String, ByVal PlateNo As String) As Boolean
        Dim reader As New D8Reader(GetConfigInfoD8)
        'If D8_Connect() = False Then
        If reader.Connect() = False Then
            'MsgBox("Failed Card Reader Connection")
            Return False
        End If

        Try
            'Clear Card
            'Clear_as_New()
            reader.ClearSector(3)

            Me.Cursor = Cursors.WaitCursor

            'Show new data

            Me.txtTimeIN.Text = Date.Now
            Me.Refresh()

            If txtCardCode.Text = Nothing OrElse txtCardCode.Text.Trim() = "" Then
                'MsgBox("No Card Detected!", MsgBoxStyle.Exclamation, "NO CARD")
                Return False
            End If

            'Get/create Card data-------
            'Dim siteid As String = txtSiteID.Text
            'Dim entryid As String = txtEntryID.Text

            'Dim TimeIn As String = TimeConversion.LocalToUnixTimestamp(CDate(txtTimeIN.Text)).ToString
            'Dim PlateNo As String = txtPlateno.Text.Replace(" ", "").ToUpper.Trim
            Dim VehType As String

            Select Case CBxVehicleID.Text.ToUpper
                Case "CAR"
                    VehType = "2"
                Case "Motor"
                    VehType = "1"
                Case Else
                    VehType = "2"
                    CBxVehicleID.SelectedIndex = 0
            End Select


            'Write Card
            Dim CardMsg_S3 As String = siteid & " " & entryid & " " & VehType & " " & TimeIn & " " & PlateNo
            'If writecard.WriteCard(3, CardMsg_S3, Me.txtCardCode.Text) = False Then
            If reader.Write(3, CardMsg_S3) = False Then
                'MsgBox("Write Card Failed", MsgBoxStyle.Exclamation, "Prompt")
                Return False
            End If

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'MsgBox("Failed writing card")
            Return False
        End Try

        txtSiteID.Text = vbNullString
        txtEntryID.Text = vbNullString
        CBxVehicleID.Text = vbNullString
        txtTimeIN.Text = Date.Now
        txtPlateno.Text = vbNullString
        Return True

    End Function

    Private Sub BtnReadAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReadAll.Click
        Dim reader As New D8Reader(GetConfigInfoD8)
        Me.txtReadCard.Text = reader.Read(3)

        Me.txtTranslate.Text = XORCipher(Me.txtReadCard.Text, False) 'o
        translateInputs()

        reader.Beep()
    End Sub

    Private Sub BtnTranslate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTranslate.Click
        Dim reader As New D8Reader(GetConfigInfoD8)
        Me.txtTranslate.Text = XORCipher(Me.txtReadCard.Text, False)
        reader.Beep()


        translateInputs()
    End Sub

    Private Sub BtnSync_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSync.Click
        If Sync() = True Then
            MsgBox("SUCCESS")
        Else
            MsgBox("FAIL")
        End If
    End Sub
    'FUNCTION SYNC
    Public Function Sync() As Boolean
        ' Define the required input controls for validation
        Dim RequiredInfo() As Control = {txtSiteID, txtEntryID, CBxVehicleID, txtTimeIN, txtPlateno}


        ' Loop through each control and check if any are empty
        For i = 0 To RequiredInfo.Length - 1
            If RequiredInfo(i).Text = "" Then
                'MsgBox("Fill all boxes", MsgBoxStyle.Exclamation, "Fill")
                Return False
            End If
        Next i

        Try
            ' Get the local database configuration
            Dim databaseConfig As DatabaseManager.Configuration = GetLocalDatabaseConfig()
            ' Use the database connection within a Using block to ensure proper disposal
            Using dbConn As New DatabaseManager(databaseConfig)

                If dbConn.Status = False Then
                    'MsgBox("Error Connection Database", MsgBoxStyle.Critical, "DATABASE CONNECTION ERROR")
                    Return False
                End If

                ' Construct the SQL INSERT statement with sanitized inputs
                Dim NewSectorInfo As String = "'" & txtSiteID.Text.Replace("'", "''") & "','" & _
                                              txtEntryID.Text.Replace("'", "''") & "','" & _
                                              CBxVehicleID.Text.Replace("'", "''") & "','" & _
                                              txtTimeIN.Text.Replace("'", "''") & "','" & _
                                              txtPlateno.Text.Replace("'", "''") & "'"

                Dim query As String = "INSERT INTO dbase.sector3 (siteid, entryid, vehicleid, timein, plateno) VALUES (" & NewSectorInfo & ")"

                Try
                    ' Execute the query
                    dbConn.ExecuteQuery(query)
                    'MsgBox("Successfully synced", MsgBoxStyle.Information, "Success")
                    Return True
                Catch ex As Exception
                    MsgBox("Failed to sync: " & ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End Using

        Catch ex As Exception
            MsgBox("Failed to connect to the database: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        End Try
        Return False

    End Function




#End Region

#Region "Sector 4"

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim siteid As String = txtSiteIDSector4.Text
        Dim posid As String = txtPosID.Text
        Dim xgrace As String = txtXGrace.Text
        Dim crid As String = txtCrID.Text
        Dim transtime As String = TimeConversion.LocalToUnixTimestamp(CDate(txtTransTime.Text)).ToString

        If WriteSector4(siteid, posid, xgrace, crid, transtime) = True Then
            MsgBox("SUCCESS")
        Else
            MsgBox("FAIL")
        End If
    End Sub

    Public Function WriteSector4(ByVal siteid As String, ByVal posid As String, ByVal xgrace As String, ByVal crid As String, ByVal transtime As String) As Boolean
        Dim reader As New D8Reader(GetConfigInfoD8)

        'If D8_Connect() = False Then
        If reader.Connect() = False Then
            'MsgBox("Failed Card Reader connection")
            Return False
        End If

        Try
            'Clear Card
            'Clear_as_New()
            reader.ClearSector(4)

            Me.Cursor = Cursors.WaitCursor

            'Show new data
            'Me.txtCardCode.Text = D8_GetCard(False)
            Me.txtCardCode.Text = reader.GetCardCode
            Me.txtTimeIN.Text = Date.Now
            Me.Refresh()

            If txtCardCode.Text Is Nothing OrElse txtCardCode.Text.Trim() = "" Then
                'MsgBox("No card detected!", MsgBoxStyle.Exclamation, "NO CARD")
                Return False
            End If

            'Get/create Card data

            'Dim siteid As String = txtSiteIDSector4.Text
            'Dim posid As String = txtPosID.Text
            'Dim xgrace As String = txtXGrace.Text
            'Dim crid As String = txtCrID.Text

            'Dim transtime As String = TimeConversion.LocalToUnixTimestamp(CDate(txtTransTime.Text)).ToString

            'Write Card
            Dim CardMsg_S4 As String = siteid & " " & posid & " " & xgrace & " " & transtime & " " & crid

            'If writecard.WriteCard(4, CardMsg_S4, Me.txtCardCode.Text) = False Then

            If reader.Write(4, CardMsg_S4) = False Then
                'MsgBox("Write card failed", MsgBoxStyle.Exclamation, "Prompt")
                Return False
            End If

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            'MsgBox("Failed writing card")
        End Try
        Return False

        txtSiteIDSector4.Text = vbNullString
        txtPosID.Text = vbNullString
        txtXGrace.Text = vbNullString
        txtTransTime.Text = Date.Now
        txtCrID.Text = vbNullString

    End Function

    Private Sub BtnReadAllSector4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReadAllSector4.Click
        Dim reader As New D8Reader(GetConfigInfoD8)
        Me.txtReadCardSector4.Text = reader.Read(4)
        reader.Beep()
    End Sub

    Private Sub BtnTranslateSector4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTranslateSector4.Click
        Dim reader As New D8Reader(GetConfigInfoD8)
        Me.txtTranslateSector4.Text = XORCipher(Me.txtReadCardSector4.Text, False)
        reader.Beep()

        Dim sector4 As Boolean = True
        translateInputs(sector4)
    End Sub

    Private Sub BtnSyncSector4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSyncSector4.Click
        If SyncSector4() = True Then
            MsgBox("SUCCESS")
        Else
            MsgBox("FAIL")
        End If

    End Sub

    'FUNCTION SYNC FOR SECTOR 4
    Public Function SyncSector4() As Boolean

        ' Define the required input controls for validation
        Dim RequiredInfo() As Control = {txtSiteIDSector4, txtPosID, txtXGrace, txtTransTime, txtCrID}

        ' Loop through each control and check if any are empty
        For i = 0 To RequiredInfo.Length - 1
            If RequiredInfo(i).Text = "" Then
                MsgBox("Fill all boxes", MsgBoxStyle.Exclamation, "Fill")
                Return False
            End If
        Next i

        Try

            ' Get the local database configuration
            Dim databaseConfig As DatabaseManager.Configuration = GetLocalDatabaseConfig()

            ' Use the database connection within a Using block to ensure proper disposal
            Using dbConn As New DatabaseManager(databaseConfig)

                If dbConn.Status = False Then
                    MsgBox("Error Connection Database", MsgBoxStyle.Critical, "DATABASE CONNECTION")
                    Return False
                End If

                ' Construct the SQL INSERT statement with sanitized inputs
                Dim NewSectorInfo As String = "'" & txtSiteIDSector4.Text.Replace("'", "''") & "','" & _
                                                    txtPosID.Text.Replace("'", "''") & "','" & _
                                                    txtXGrace.Text.Replace("'", "''") & "','" & _
                                                    txtTransTime.Text.Replace("'", "''") & "','" & _
                                                    txtCrID.Text.Replace("'", "''") & "'"

                Dim query As String = "INSERT INTO dbase.sector4 (siteid, posid, xgrace, transtime, crid) VALUES (" & NewSectorInfo & ")"

                Try
                    ' Execute the query
                    dbConn.ExecuteQuery(query)
                    Return True

                Catch ex As Exception
                    MsgBox("Failed to sync: " & ex.Message, MsgBoxStyle.Critical, "Error")
                End Try
            End Using

        Catch ex As Exception
            MsgBox("Failed to connect to the database: " & ex.Message, MsgBoxStyle.Critical, "Database Error")
        End Try
        Return False

    End Function


#End Region

    Sub translateInputs(Optional ByVal buttonTrigger As Boolean = False)
        Dim inputString As String = txtTranslate.Text
        Dim inputString4 As String = txtTranslateSector4.Text

        Dim splitWords() As String = inputString.Split(" "c)
        Dim splitWords4() As String = inputString4.Split(" "c)


        Try
            If buttonTrigger = False Then
                txtSiteID.Text = splitWords(0)
                txtEntryID.Text = splitWords(1)
                CBxVehicleID.Text = splitWords(2)
                txtTimeIN.Text = splitWords(3)
                txtPlateno.Text = splitWords(4)
            End If

        Catch ex As Exception
            clearInputs(buttonTrigger)
            MessageBox.Show("Nothing to translate in Sector 3")
        End Try

        Try
            If buttonTrigger = True Then
                txtSiteIDSector4.Text = splitWords4(0)
                txtPosID.Text = splitWords4(1)
                txtXGrace.Text = splitWords4(2)
                txtTransTime.Text = splitWords4(3)
                txtCrID.Text = splitWords4(4)
            End If
        Catch ex As Exception
            clearInputs(buttonTrigger)
            MessageBox.Show("Nothing to translate in Sector 4")
        End Try
    End Sub

    Sub clearInputs(Optional ByVal buttonTrigger As Boolean = False)

        If buttonTrigger = False Then
            txtSiteID.Text = vbNullString
            txtEntryID.Text = vbNullString
            CBxVehicleID.Text = vbNullString
            txtTimeIN.Text = Date.Now
            txtPlateno.Text = vbNullString
        Else
            txtSiteIDSector4.Text = vbNullString
            txtPosID.Text = vbNullString
            txtXGrace.Text = vbNullString
            txtTransTime.Text = Date.Now
            txtCrID.Text = vbNullString
        End If

    End Sub



    

End Class