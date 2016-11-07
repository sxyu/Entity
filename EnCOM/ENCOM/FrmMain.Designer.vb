<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Me.rtb = New System.Windows.Forms.RichTextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.timerCodeExpire = New System.Windows.Forms.Timer(Me.components)
        Me.btnOK = New System.Windows.Forms.Button()
        Me.toSend = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'rtb
        '
        Me.rtb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtb.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtb.ForeColor = System.Drawing.Color.White
        Me.rtb.Location = New System.Drawing.Point(21, 15)
        Me.rtb.Margin = New System.Windows.Forms.Padding(41, 23, 41, 23)
        Me.rtb.Name = "rtb"
        Me.rtb.ReadOnly = True
        Me.rtb.Size = New System.Drawing.Size(646, 354)
        Me.rtb.TabIndex = 3
        Me.rtb.TabStop = False
        Me.rtb.Text = ""
        '
        'btnSend
        '
        Me.btnSend.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSend.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.btnSend.Enabled = False
        Me.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnSend.FlatAppearance.BorderSize = 0
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.ForeColor = System.Drawing.Color.White
        Me.btnSend.Location = New System.Drawing.Point(574, 375)
        Me.btnSend.Margin = New System.Windows.Forms.Padding(41, 17, 41, 17)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(110, 61)
        Me.btnSend.TabIndex = 2
        Me.btnSend.Text = "&Send" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Enter)"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'timerCodeExpire
        '
        Me.timerCodeExpire.Enabled = True
        Me.timerCodeExpire.Interval = 2000
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOK.Location = New System.Drawing.Point(574, 436)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(41, 17, 41, 17)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(110, 36)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "Log Out"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'toSend
        '
        Me.toSend.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.toSend.Location = New System.Drawing.Point(0, 375)
        Me.toSend.Margin = New System.Windows.Forms.Padding(41, 17, 41, 17)
        Me.toSend.Multiline = True
        Me.toSend.Name = "toSend"
        Me.toSend.Size = New System.Drawing.Size(577, 97)
        Me.toSend.TabIndex = 0
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(684, 471)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.rtb)
        Me.Controls.Add(Me.toSend)
        Me.Font = New System.Drawing.Font("Segoe UI Semilight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(41, 23, 41, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entity EnCOM Standalone Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtb As System.Windows.Forms.RichTextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents timerCodeExpire As System.Windows.Forms.Timer
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents toSend As System.Windows.Forms.TextBox

End Class
