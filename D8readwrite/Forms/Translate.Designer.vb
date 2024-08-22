<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Translate
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtCardCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnWrite = New System.Windows.Forms.Button
        Me.txtPlateno = New System.Windows.Forms.TextBox
        Me.txtTimeIN = New System.Windows.Forms.TextBox
        Me.CBxVehicleID = New System.Windows.Forms.ComboBox
        Me.txtEntryID = New System.Windows.Forms.TextBox
        Me.txtSiteID = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtCrID = New System.Windows.Forms.TextBox
        Me.txtTransTime = New System.Windows.Forms.TextBox
        Me.txtXGrace = New System.Windows.Forms.TextBox
        Me.txtPosID = New System.Windows.Forms.TextBox
        Me.txtSiteIDSector4 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BtnSync = New System.Windows.Forms.Button
        Me.BtnTranslate = New System.Windows.Forms.Button
        Me.txtTranslate = New System.Windows.Forms.TextBox
        Me.BtnReadAll = New System.Windows.Forms.Button
        Me.txtReadCard = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.BtnSyncSector4 = New System.Windows.Forms.Button
        Me.BtnTranslateSector4 = New System.Windows.Forms.Button
        Me.txtTranslateSector4 = New System.Windows.Forms.TextBox
        Me.BtnReadAllSector4 = New System.Windows.Forms.Button
        Me.txtReadCardSector4 = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtCardCode
        '
        Me.txtCardCode.Enabled = False
        Me.txtCardCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCardCode.Location = New System.Drawing.Point(80, 15)
        Me.txtCardCode.Name = "txtCardCode"
        Me.txtCardCode.Size = New System.Drawing.Size(173, 26)
        Me.txtCardCode.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CARD CODE"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(377, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(196, 30)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "READ & WRITE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BtnWrite)
        Me.GroupBox1.Controls.Add(Me.txtPlateno)
        Me.GroupBox1.Controls.Add(Me.txtTimeIN)
        Me.GroupBox1.Controls.Add(Me.CBxVehicleID)
        Me.GroupBox1.Controls.Add(Me.txtEntryID)
        Me.GroupBox1.Controls.Add(Me.txtSiteID)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 196)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'BtnWrite
        '
        Me.BtnWrite.Enabled = False
        Me.BtnWrite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnWrite.Location = New System.Drawing.Point(130, 156)
        Me.BtnWrite.Name = "BtnWrite"
        Me.BtnWrite.Size = New System.Drawing.Size(75, 33)
        Me.BtnWrite.TabIndex = 12
        Me.BtnWrite.Text = "WRITE"
        Me.BtnWrite.UseVisualStyleBackColor = True
        '
        'txtPlateno
        '
        Me.txtPlateno.Enabled = False
        Me.txtPlateno.Location = New System.Drawing.Point(86, 131)
        Me.txtPlateno.Name = "txtPlateno"
        Me.txtPlateno.Size = New System.Drawing.Size(173, 20)
        Me.txtPlateno.TabIndex = 11
        '
        'txtTimeIN
        '
        Me.txtTimeIN.Enabled = False
        Me.txtTimeIN.Location = New System.Drawing.Point(86, 104)
        Me.txtTimeIN.Name = "txtTimeIN"
        Me.txtTimeIN.Size = New System.Drawing.Size(173, 20)
        Me.txtTimeIN.TabIndex = 10
        '
        'CBxVehicleID
        '
        Me.CBxVehicleID.Enabled = False
        Me.CBxVehicleID.FormattingEnabled = True
        Me.CBxVehicleID.Items.AddRange(New Object() {"CAR", "MOTOR"})
        Me.CBxVehicleID.Location = New System.Drawing.Point(86, 73)
        Me.CBxVehicleID.Name = "CBxVehicleID"
        Me.CBxVehicleID.Size = New System.Drawing.Size(173, 21)
        Me.CBxVehicleID.TabIndex = 9
        '
        'txtEntryID
        '
        Me.txtEntryID.Enabled = False
        Me.txtEntryID.Location = New System.Drawing.Point(86, 44)
        Me.txtEntryID.Name = "txtEntryID"
        Me.txtEntryID.Size = New System.Drawing.Size(173, 20)
        Me.txtEntryID.TabIndex = 8
        '
        'txtSiteID
        '
        Me.txtSiteID.Enabled = False
        Me.txtSiteID.Location = New System.Drawing.Point(86, 13)
        Me.txtSiteID.Name = "txtSiteID"
        Me.txtSiteID.Size = New System.Drawing.Size(173, 20)
        Me.txtSiteID.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 131)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "PLATE NO."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "TIME IN"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "VEHICLE ID"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(4, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "ENTRY ID"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "SITE ID "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtCrID)
        Me.GroupBox2.Controls.Add(Me.txtTransTime)
        Me.GroupBox2.Controls.Add(Me.txtXGrace)
        Me.GroupBox2.Controls.Add(Me.txtPosID)
        Me.GroupBox2.Controls.Add(Me.txtSiteIDSector4)
        Me.GroupBox2.Location = New System.Drawing.Point(293, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 196)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(135, 156)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 33)
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "WRITE"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 138)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(36, 13)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "CR ID"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "TRANSTIME"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 79)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "XGRACE"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "POS ID"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "SITE ID"
        '
        'txtCrID
        '
        Me.txtCrID.Enabled = False
        Me.txtCrID.Location = New System.Drawing.Point(93, 131)
        Me.txtCrID.Name = "txtCrID"
        Me.txtCrID.Size = New System.Drawing.Size(173, 20)
        Me.txtCrID.TabIndex = 17
        '
        'txtTransTime
        '
        Me.txtTransTime.Enabled = False
        Me.txtTransTime.Location = New System.Drawing.Point(93, 104)
        Me.txtTransTime.Name = "txtTransTime"
        Me.txtTransTime.Size = New System.Drawing.Size(173, 20)
        Me.txtTransTime.TabIndex = 16
        '
        'txtXGrace
        '
        Me.txtXGrace.Enabled = False
        Me.txtXGrace.Location = New System.Drawing.Point(93, 76)
        Me.txtXGrace.Name = "txtXGrace"
        Me.txtXGrace.Size = New System.Drawing.Size(173, 20)
        Me.txtXGrace.TabIndex = 15
        '
        'txtPosID
        '
        Me.txtPosID.Enabled = False
        Me.txtPosID.Location = New System.Drawing.Point(93, 47)
        Me.txtPosID.Name = "txtPosID"
        Me.txtPosID.Size = New System.Drawing.Size(173, 20)
        Me.txtPosID.TabIndex = 14
        '
        'txtSiteIDSector4
        '
        Me.txtSiteIDSector4.Enabled = False
        Me.txtSiteIDSector4.Location = New System.Drawing.Point(93, 19)
        Me.txtSiteIDSector4.Name = "txtSiteIDSector4"
        Me.txtSiteIDSector4.Size = New System.Drawing.Size(173, 20)
        Me.txtSiteIDSector4.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(133, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "SECTOR 3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(405, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "SECTOR 4"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BtnSync)
        Me.GroupBox3.Controls.Add(Me.BtnTranslate)
        Me.GroupBox3.Controls.Add(Me.txtTranslate)
        Me.GroupBox3.Controls.Add(Me.BtnReadAll)
        Me.GroupBox3.Controls.Add(Me.txtReadCard)
        Me.GroupBox3.Location = New System.Drawing.Point(7, 286)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(280, 194)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        '
        'BtnSync
        '
        Me.BtnSync.Enabled = False
        Me.BtnSync.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSync.Location = New System.Drawing.Point(88, 147)
        Me.BtnSync.Name = "BtnSync"
        Me.BtnSync.Size = New System.Drawing.Size(117, 33)
        Me.BtnSync.TabIndex = 16
        Me.BtnSync.Text = "SYNC"
        Me.BtnSync.UseVisualStyleBackColor = True
        '
        'BtnTranslate
        '
        Me.BtnTranslate.Enabled = False
        Me.BtnTranslate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTranslate.Location = New System.Drawing.Point(88, 108)
        Me.BtnTranslate.Name = "BtnTranslate"
        Me.BtnTranslate.Size = New System.Drawing.Size(117, 33)
        Me.BtnTranslate.TabIndex = 15
        Me.BtnTranslate.Text = "TRANSLATE"
        Me.BtnTranslate.UseVisualStyleBackColor = True
        '
        'txtTranslate
        '
        Me.txtTranslate.Enabled = False
        Me.txtTranslate.Location = New System.Drawing.Point(29, 82)
        Me.txtTranslate.Name = "txtTranslate"
        Me.txtTranslate.Size = New System.Drawing.Size(230, 20)
        Me.txtTranslate.TabIndex = 14
        '
        'BtnReadAll
        '
        Me.BtnReadAll.Enabled = False
        Me.BtnReadAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReadAll.Location = New System.Drawing.Point(105, 43)
        Me.BtnReadAll.Name = "BtnReadAll"
        Me.BtnReadAll.Size = New System.Drawing.Size(75, 33)
        Me.BtnReadAll.TabIndex = 13
        Me.BtnReadAll.Text = "READ"
        Me.BtnReadAll.UseVisualStyleBackColor = True
        '
        'txtReadCard
        '
        Me.txtReadCard.Enabled = False
        Me.txtReadCard.Location = New System.Drawing.Point(29, 17)
        Me.txtReadCard.Name = "txtReadCard"
        Me.txtReadCard.Size = New System.Drawing.Size(230, 20)
        Me.txtReadCard.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.BtnSyncSector4)
        Me.GroupBox4.Controls.Add(Me.BtnTranslateSector4)
        Me.GroupBox4.Controls.Add(Me.txtTranslateSector4)
        Me.GroupBox4.Controls.Add(Me.BtnReadAllSector4)
        Me.GroupBox4.Controls.Add(Me.txtReadCardSector4)
        Me.GroupBox4.Location = New System.Drawing.Point(293, 286)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(280, 194)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        '
        'BtnSyncSector4
        '
        Me.BtnSyncSector4.Enabled = False
        Me.BtnSyncSector4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSyncSector4.Location = New System.Drawing.Point(93, 147)
        Me.BtnSyncSector4.Name = "BtnSyncSector4"
        Me.BtnSyncSector4.Size = New System.Drawing.Size(117, 33)
        Me.BtnSyncSector4.TabIndex = 17
        Me.BtnSyncSector4.Text = "SYNC"
        Me.BtnSyncSector4.UseVisualStyleBackColor = True
        '
        'BtnTranslateSector4
        '
        Me.BtnTranslateSector4.Enabled = False
        Me.BtnTranslateSector4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTranslateSector4.Location = New System.Drawing.Point(93, 108)
        Me.BtnTranslateSector4.Name = "BtnTranslateSector4"
        Me.BtnTranslateSector4.Size = New System.Drawing.Size(117, 33)
        Me.BtnTranslateSector4.TabIndex = 16
        Me.BtnTranslateSector4.Text = "TRANSLATE"
        Me.BtnTranslateSector4.UseVisualStyleBackColor = True
        '
        'txtTranslateSector4
        '
        Me.txtTranslateSector4.Enabled = False
        Me.txtTranslateSector4.Location = New System.Drawing.Point(36, 82)
        Me.txtTranslateSector4.Name = "txtTranslateSector4"
        Me.txtTranslateSector4.Size = New System.Drawing.Size(230, 20)
        Me.txtTranslateSector4.TabIndex = 16
        '
        'BtnReadAllSector4
        '
        Me.BtnReadAllSector4.Enabled = False
        Me.BtnReadAllSector4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReadAllSector4.Location = New System.Drawing.Point(116, 43)
        Me.BtnReadAllSector4.Name = "BtnReadAllSector4"
        Me.BtnReadAllSector4.Size = New System.Drawing.Size(75, 33)
        Me.BtnReadAllSector4.TabIndex = 16
        Me.BtnReadAllSector4.Text = "READ"
        Me.BtnReadAllSector4.UseVisualStyleBackColor = True
        '
        'txtReadCardSector4
        '
        Me.txtReadCardSector4.Enabled = False
        Me.txtReadCardSector4.Location = New System.Drawing.Point(36, 17)
        Me.txtReadCardSector4.Name = "txtReadCardSector4"
        Me.txtReadCardSector4.Size = New System.Drawing.Size(230, 20)
        Me.txtReadCardSector4.TabIndex = 16
        '
        'Translate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(585, 495)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCardCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "Translate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "READ & TRANSLATE"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPlateno As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeIN As System.Windows.Forms.TextBox
    Friend WithEvents CBxVehicleID As System.Windows.Forms.ComboBox
    Friend WithEvents txtEntryID As System.Windows.Forms.TextBox
    Friend WithEvents txtSiteID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnWrite As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCrID As System.Windows.Forms.TextBox
    Friend WithEvents txtTransTime As System.Windows.Forms.TextBox
    Friend WithEvents txtXGrace As System.Windows.Forms.TextBox
    Friend WithEvents txtPosID As System.Windows.Forms.TextBox
    Friend WithEvents txtSiteIDSector4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnTranslate As System.Windows.Forms.Button
    Friend WithEvents txtTranslate As System.Windows.Forms.TextBox
    Friend WithEvents BtnReadAll As System.Windows.Forms.Button
    Friend WithEvents txtReadCard As System.Windows.Forms.TextBox
    Friend WithEvents BtnTranslateSector4 As System.Windows.Forms.Button
    Friend WithEvents txtTranslateSector4 As System.Windows.Forms.TextBox
    Friend WithEvents BtnReadAllSector4 As System.Windows.Forms.Button
    Friend WithEvents txtReadCardSector4 As System.Windows.Forms.TextBox
    Friend WithEvents BtnSync As System.Windows.Forms.Button
    Friend WithEvents BtnSyncSector4 As System.Windows.Forms.Button
    Friend WithEvents txtCardCode As System.Windows.Forms.TextBox
End Class
