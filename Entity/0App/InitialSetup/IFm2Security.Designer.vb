Namespace _0App.InitialSetup
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IFm2Security
        Inherits IFmBase



        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.content = New System.Windows.Forms.Panel()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.lbDesc = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lbWarningRe = New System.Windows.Forms.Label()
            Me.tbNewPass = New System.Windows.Forms.TextBox()
            Me.lbNewPass = New System.Windows.Forms.Label()
            Me.lbNewPassRe = New System.Windows.Forms.Label()
            Me.btnSavePass = New System.Windows.Forms.Button()
            Me.tbNewPassRe = New System.Windows.Forms.TextBox()
            Me.btnClose = New System.Windows.Forms.Button()
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.content.SuspendLayout()
            Me.SuspendLayout()
            '
            'tmrAnim
            '
            Me.tmrAnim.Enabled = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.ForeColor = System.Drawing.Color.White
            Me.lbTitle.Location = New System.Drawing.Point(248, 17)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(204, 30)
            Me.lbTitle.TabIndex = 45
            Me.lbTitle.Text = "Protect Your Projects"
            '
            'content
            '
            Me.content.Controls.Add(Me.lbWarning)
            Me.content.Controls.Add(Me.lbDesc)
            Me.content.Controls.Add(Me.lbTitle)
            Me.content.Controls.Add(Me.btnCancel)
            Me.content.Controls.Add(Me.lbWarningRe)
            Me.content.Controls.Add(Me.tbNewPass)
            Me.content.Controls.Add(Me.lbNewPass)
            Me.content.Controls.Add(Me.lbNewPassRe)
            Me.content.Controls.Add(Me.btnSavePass)
            Me.content.Controls.Add(Me.tbNewPassRe)
            Me.content.Location = New System.Drawing.Point(189, 23)
            Me.content.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.content.Name = "content"
            Me.content.Size = New System.Drawing.Size(696, 411)
            Me.content.TabIndex = 53
            '
            'lbWarning
            '
            Me.lbWarning.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbWarning.Location = New System.Drawing.Point(196, 219)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(300, 26)
            Me.lbWarning.TabIndex = 55
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lbWarning.Visible = False
            '
            'lbDesc
            '
            Me.lbDesc.AutoSize = True
            Me.lbDesc.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbDesc.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbDesc.Location = New System.Drawing.Point(181, 52)
            Me.lbDesc.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbDesc.Name = "lbDesc"
            Me.lbDesc.Size = New System.Drawing.Size(338, 80)
            Me.lbDesc.TabIndex = 54
            Me.lbDesc.Text = "Add a password to Entity for better security." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You will be asked for the password" & _
        " at every launch." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you do no not wish to use a password," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "click No Thanks to " & _
        "go right to work."
            Me.lbDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCancel.FlatAppearance.BorderSize = 0
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(199, 345)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(124, 40)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.TabStop = False
            Me.btnCancel.Tag = "0"
            Me.btnCancel.Text = "&No Thanks"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'lbWarningRe
            '
            Me.lbWarningRe.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbWarningRe.Location = New System.Drawing.Point(196, 308)
            Me.lbWarningRe.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbWarningRe.Name = "lbWarningRe"
            Me.lbWarningRe.Size = New System.Drawing.Size(300, 26)
            Me.lbWarningRe.TabIndex = 53
            Me.lbWarningRe.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.lbWarningRe.Visible = False
            '
            'tbNewPass
            '
            Me.tbNewPass.Location = New System.Drawing.Point(199, 191)
            Me.tbNewPass.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbNewPass.Name = "tbNewPass"
            Me.tbNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.tbNewPass.Size = New System.Drawing.Size(300, 29)
            Me.tbNewPass.TabIndex = 3
            '
            'lbNewPass
            '
            Me.lbNewPass.AutoSize = True
            Me.lbNewPass.ForeColor = System.Drawing.Color.White
            Me.lbNewPass.Location = New System.Drawing.Point(298, 157)
            Me.lbNewPass.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbNewPass.Name = "lbNewPass"
            Me.lbNewPass.Size = New System.Drawing.Size(109, 21)
            Me.lbNewPass.TabIndex = 52
            Me.lbNewPass.Text = "New Password"
            '
            'lbNewPassRe
            '
            Me.lbNewPassRe.AutoSize = True
            Me.lbNewPassRe.ForeColor = System.Drawing.Color.White
            Me.lbNewPassRe.Location = New System.Drawing.Point(283, 246)
            Me.lbNewPassRe.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbNewPassRe.Name = "lbNewPassRe"
            Me.lbNewPassRe.Size = New System.Drawing.Size(133, 21)
            Me.lbNewPassRe.TabIndex = 50
            Me.lbNewPassRe.Text = "Confirm Password"
            '
            'btnSavePass
            '
            Me.btnSavePass.BackColor = System.Drawing.Color.Gainsboro
            Me.btnSavePass.Enabled = False
            Me.btnSavePass.FlatAppearance.BorderSize = 0
            Me.btnSavePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSavePass.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSavePass.ForeColor = System.Drawing.Color.Black
            Me.btnSavePass.Location = New System.Drawing.Point(333, 345)
            Me.btnSavePass.Margin = New System.Windows.Forms.Padding(53, 46, 0, 14)
            Me.btnSavePass.Name = "btnSavePass"
            Me.btnSavePass.Size = New System.Drawing.Size(166, 40)
            Me.btnSavePass.TabIndex = 6
            Me.btnSavePass.TabStop = False
            Me.btnSavePass.Tag = "0"
            Me.btnSavePass.Text = "&Set Password"
            Me.btnSavePass.UseVisualStyleBackColor = False
            '
            'tbNewPassRe
            '
            Me.tbNewPassRe.Location = New System.Drawing.Point(199, 280)
            Me.tbNewPassRe.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbNewPassRe.Name = "tbNewPassRe"
            Me.tbNewPassRe.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.tbNewPassRe.Size = New System.Drawing.Size(300, 29)
            Me.tbNewPassRe.TabIndex = 4
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BackColor = System.Drawing.Color.Transparent
            Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnClose.FlatAppearance.BorderSize = 0
            Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.ForeColor = System.Drawing.Color.White
            Me.btnClose.Location = New System.Drawing.Point(963, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(64, 27, 64, 27)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 54
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'IFm2Security
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1000, 470)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.content)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "IFm2Security"
            Me.Opacity = 0.1R
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).EndInit()
            Me.content.ResumeLayout(False)
            Me.content.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents content As System.Windows.Forms.Panel
        Friend WithEvents lbWarningRe As System.Windows.Forms.Label
        Friend WithEvents tbNewPass As System.Windows.Forms.TextBox
        Friend WithEvents lbNewPass As System.Windows.Forms.Label
        Friend WithEvents lbNewPassRe As System.Windows.Forms.Label
        Friend WithEvents btnSavePass As System.Windows.Forms.Button
        Friend WithEvents tbNewPassRe As System.Windows.Forms.TextBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lbDesc As System.Windows.Forms.Label
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button

    End Class
End Namespace