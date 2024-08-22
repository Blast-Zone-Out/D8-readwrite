Public Class ReadWrite
    Private ErrMsg As String

    Private Sub ReadWrite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim reader As New D8Reader(GetConfigInfoD8)
        reader.Connect()
        'D8_Connect()
    End Sub

    Private Sub Read_card(ByVal Sector As String)
        Dim reader As New D8Reader(GetConfigInfoD8)

        Dim CC As String = vbNullString
        '        Dim DD As Date = Now

        'If D8_Connect() = False Then Exit Sub
        If reader.Connect = False Then Exit Sub

        'CC = D8_GetCard()
        CC = reader.GetCardCode
        If CC = String.Empty Then Exit Sub

        Try

            'If D8_LoadKey(Sector) = False Then
            If reader.Read(Sector) = False Then

                Exit Sub
            End If

            'If D8_Authenticate(Sector) = False Then
            If reader.Read(Sector) = False Then
                ErrMSG = "Error Card Authentication"
                Exit Sub
            End If

            'TextBox4.Text = D8_Function.read_card(Sector)
            TextBox4.Text = reader.Read(Sector)
            MsgBox("done")
            '=================================================================

        Catch ex As Exception
            ErrMSG = ex.Message
        End Try
    End Sub

    Private Sub ReadWrite_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim reader As New D8Reader(GetConfigInfoD8)
        ' Check if "Ctrl + Insert" keys are pressed
        If e.Control AndAlso e.KeyCode = Keys.Insert Then
            ' Show ReadWriteSettings FORM
            Dim settingsForm As New ReadWriteSettings()
            settingsForm.Show()
        End If


        If e.KeyCode = Keys.Enter Then


           
            Me.txtCardCode.Text = reader.GetCardCode
        End If
        
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        writing(Button4.Text)
    End Sub

    Sub writing(ByVal sector As String)
        'Write Card
        Dim reader As New D8Reader(GetConfigInfoD8)
        'If writecard.WriteCard(sector, TextBox3.Text, txtCardCode.Text) = False Then
        If reader.Write(sector, TextBox3.Text) = False Then

            MsgBox("Write card failed", MsgBoxStyle.Exclamation, "Prompt")
            Exit Sub
        End If

        Me.Cursor = Cursors.Default
        MsgBox("done")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        writing(Button5.Text)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        writing(Button6.Text)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        writing(Button7.Text)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        writing(Button8.Text)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        writing(Button9.Text)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        writing(Button10.Text)
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        writing(Button11.Text)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        writing(Button12.Text)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        writing(Button13.Text)
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        writing(Button14.Text)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        writing(Button15.Text)
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        writing(Button16.Text)
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        writing(Button17.Text)
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        writing(Button18.Text)
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        writing(Button19.Text)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim reader As New D8Reader(GetConfigInfoD8)
        'Me.TextBox4.Text = D8_Function.read_card(CShort(Me.TextBox2.Text))
        Me.TextBox4.Text = reader.Read(CShort(Me.TextBox2.Text))
        Me.TextBox4.Text = XORCipher(Me.TextBox4.Text, False)
    End Sub




    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Me.Close()
    End Sub



    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim reader As New D8Reader(GetConfigInfoD8)


        Me.txtCardCode.Text = reader.GetCardCode

    End Sub
End Class
