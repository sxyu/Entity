Namespace _0App.SettingsViews
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Svw2Admin
        Inherits System.Windows.Forms.UserControl



        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.lbTitle = New System.Windows.Forms.Label()
        Me.tbPass = New System.Windows.Forms.TextBox()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.lbPass = New System.Windows.Forms.Label()
        Me.lbNewPassRe = New System.Windows.Forms.Label()
        Me.tbNewPassRe = New System.Windows.Forms.TextBox()
        Me.btnUnlock = New System.Windows.Forms.Button()
        Me.btnSavePass = New System.Windows.Forms.Button()
        Me.pnlNormal = New System.Windows.Forms.Panel()
        Me.lbWrong = New System.Windows.Forms.Label()
        Me.pnlNewPass = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lbWarning = New System.Windows.Forms.Label()
        Me.tbNewPass = New System.Windows.Forms.TextBox()
        Me.lbNewPass = New System.Windows.Forms.Label()
        Me.pnlNormal.SuspendLayout
        Me.pnlNewPass.SuspendLayout
        Me.SuspendLayout
        '
        'lbTitle
        '
        Me.lbTitle.AutoSize = true
        Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lbTitle.ForeColor = System.Drawing.Color.Black
            Me.lbTitle.Location = New System.Drawing.Point(32, 19)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(239, 25)
            Me.lbTitle.TabIndex = 45
            Me.lbTitle.Text = "Change / Remove Password"
            '
            'tbPass
            '
            Me.tbPass.Location = New System.Drawing.Point(18, 58)
            Me.tbPass.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbPass.Name = "tbPass"
            Me.tbPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.tbPass.Size = New System.Drawing.Size(360, 29)
            Me.tbPass.TabIndex = 0
            '
            'btnChange
            '
            Me.btnChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnChange.BackColor = System.Drawing.Color.Gainsboro
            Me.btnChange.FlatAppearance.BorderSize = 0
            Me.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnChange.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnChange.ForeColor = System.Drawing.Color.Black
            Me.btnChange.Location = New System.Drawing.Point(580, 466)
            Me.btnChange.Margin = New System.Windows.Forms.Padding(53, 46, 0, 14)
            Me.btnChange.Name = "btnChange"
            Me.btnChange.Size = New System.Drawing.Size(130, 40)
            Me.btnChange.TabIndex = 2
            Me.btnChange.TabStop = False
            Me.btnChange.Tag = "0"
            Me.btnChange.Text = "&Change"
            Me.btnChange.UseVisualStyleBackColor = False
            '
            'lbPass
            '
            Me.lbPass.AutoSize = True
            Me.lbPass.ForeColor = System.Drawing.Color.Black
            Me.lbPass.Location = New System.Drawing.Point(14, 23)
            Me.lbPass.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbPass.Name = "lbPass"
            Me.lbPass.Size = New System.Drawing.Size(74, 21)
            Me.lbPass.TabIndex = 48
            Me.lbPass.Text = "Password"
            '
            'lbNewPassRe
            '
            Me.lbNewPassRe.AutoSize = True
            Me.lbNewPassRe.ForeColor = System.Drawing.Color.Black
            Me.lbNewPassRe.Location = New System.Drawing.Point(14, 99)
            Me.lbNewPassRe.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbNewPassRe.Name = "lbNewPassRe"
            Me.lbNewPassRe.Size = New System.Drawing.Size(133, 21)
            Me.lbNewPassRe.TabIndex = 50
            Me.lbNewPassRe.Text = "Confirm Password"
            '
            'tbNewPassRe
            '
            Me.tbNewPassRe.Location = New System.Drawing.Point(18, 130)
            Me.tbNewPassRe.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbNewPassRe.Name = "tbNewPassRe"
            Me.tbNewPassRe.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.tbNewPassRe.Size = New System.Drawing.Size(360, 29)
            Me.tbNewPassRe.TabIndex = 4
            '
            'btnUnlock
            '
            Me.btnUnlock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnUnlock.BackColor = System.Drawing.Color.Gainsboro
            Me.btnUnlock.FlatAppearance.BorderSize = 0
            Me.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUnlock.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUnlock.ForeColor = System.Drawing.Color.Black
            Me.btnUnlock.Location = New System.Drawing.Point(445, 466)
            Me.btnUnlock.Margin = New System.Windows.Forms.Padding(53, 46, 0, 14)
            Me.btnUnlock.Name = "btnUnlock"
            Me.btnUnlock.Size = New System.Drawing.Size(130, 40)
            Me.btnUnlock.TabIndex = 1
            Me.btnUnlock.TabStop = False
            Me.btnUnlock.Tag = "0"
            Me.btnUnlock.Text = "&Remove"
            Me.btnUnlock.UseVisualStyleBackColor = False
            '
            'btnSavePass
            '
            Me.btnSavePass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSavePass.BackColor = System.Drawing.Color.Gainsboro
            Me.btnSavePass.Enabled = False
            Me.btnSavePass.FlatAppearance.BorderSize = 0
            Me.btnSavePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSavePass.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSavePass.ForeColor = System.Drawing.Color.Black
            Me.btnSavePass.Location = New System.Drawing.Point(580, 466)
            Me.btnSavePass.Margin = New System.Windows.Forms.Padding(53, 46, 0, 14)
            Me.btnSavePass.Name = "btnSavePass"
            Me.btnSavePass.Size = New System.Drawing.Size(130, 40)
            Me.btnSavePass.TabIndex = 6
            Me.btnSavePass.TabStop = False
            Me.btnSavePass.Tag = "0"
            Me.btnSavePass.Text = "&OK"
            Me.btnSavePass.UseVisualStyleBackColor = False
            '
            'pnlNormal
            '
            Me.pnlNormal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlNormal.Controls.Add(Me.btnUnlock)
            Me.pnlNormal.Controls.Add(Me.lbWrong)
            Me.pnlNormal.Controls.Add(Me.tbPass)
            Me.pnlNormal.Controls.Add(Me.lbPass)
            Me.pnlNormal.Controls.Add(Me.btnChange)
            Me.pnlNormal.Location = New System.Drawing.Point(19, 77)
            Me.pnlNormal.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pnlNormal.Name = "pnlNormal"
            Me.pnlNormal.Size = New System.Drawing.Size(718, 520)
            Me.pnlNormal.TabIndex = 52
            '
            'lbWrong
            '
            Me.lbWrong.ForeColor = System.Drawing.Color.Black
            Me.lbWrong.Location = New System.Drawing.Point(18, 88)
            Me.lbWrong.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbWrong.Name = "lbWrong"
            Me.lbWrong.Size = New System.Drawing.Size(360, 26)
            Me.lbWrong.TabIndex = 49
            Me.lbWrong.Text = "Password Incorrect"
            Me.lbWrong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWrong.Visible = False
            '
            'pnlNewPass
            '
            Me.pnlNewPass.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlNewPass.Controls.Add(Me.btnCancel)
            Me.pnlNewPass.Controls.Add(Me.lbWarning)
            Me.pnlNewPass.Controls.Add(Me.tbNewPass)
            Me.pnlNewPass.Controls.Add(Me.lbNewPass)
            Me.pnlNewPass.Controls.Add(Me.btnSavePass)
            Me.pnlNewPass.Controls.Add(Me.lbNewPassRe)
            Me.pnlNewPass.Controls.Add(Me.tbNewPassRe)
            Me.pnlNewPass.Location = New System.Drawing.Point(19, 77)
            Me.pnlNewPass.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pnlNewPass.Name = "pnlNewPass"
            Me.pnlNewPass.Size = New System.Drawing.Size(718, 520)
            Me.pnlNewPass.TabIndex = 53
            Me.pnlNewPass.Visible = False
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCancel.FlatAppearance.BorderSize = 0
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(445, 466)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(130, 40)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.TabStop = False
            Me.btnCancel.Tag = "0"
            Me.btnCancel.Text = "C&ancel"
            Me.btnCancel.UseVisualStyleBackColor = False
            Me.btnCancel.Visible = False
            '
            'lbWarning
            '
            Me.lbWarning.ForeColor = System.Drawing.Color.Black
            Me.lbWarning.Location = New System.Drawing.Point(18, 161)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(360, 26)
            Me.lbWarning.TabIndex = 53
            Me.lbWarning.Text = "Retype New Password"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWarning.Visible = False
            '
            'tbNewPass
            '
            Me.tbNewPass.Location = New System.Drawing.Point(18, 56)
            Me.tbNewPass.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbNewPass.Name = "tbNewPass"
            Me.tbNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.tbNewPass.Size = New System.Drawing.Size(360, 29)
            Me.tbNewPass.TabIndex = 3
            '
            'lbNewPass
            '
            Me.lbNewPass.AutoSize = True
            Me.lbNewPass.ForeColor = System.Drawing.Color.Black
            Me.lbNewPass.Location = New System.Drawing.Point(14, 23)
            Me.lbNewPass.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbNewPass.Name = "lbNewPass"
            Me.lbNewPass.Size = New System.Drawing.Size(109, 21)
            Me.lbNewPass.TabIndex = 52
            Me.lbNewPass.Text = "New Password"
            '
            'Svw2Admin
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Controls.Add(Me.lbTitle)
            Me.Controls.Add(Me.pnlNewPass)
            Me.Controls.Add(Me.pnlNormal)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "Svw2Admin"
            Me.Size = New System.Drawing.Size(788, 611)
        Me.pnlNormal.ResumeLayout(false)
        Me.pnlNormal.PerformLayout
        Me.pnlNewPass.ResumeLayout(false)
        Me.pnlNewPass.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents tbPass As System.Windows.Forms.TextBox
        Friend WithEvents btnChange As System.Windows.Forms.Button
        Friend WithEvents lbPass As System.Windows.Forms.Label
        Friend WithEvents lbNewPassRe As System.Windows.Forms.Label
        Friend WithEvents tbNewPassRe As System.Windows.Forms.TextBox
        Friend WithEvents btnUnlock As System.Windows.Forms.Button
        Friend WithEvents btnSavePass As System.Windows.Forms.Button
        Friend WithEvents pnlNormal As System.Windows.Forms.Panel
        Friend WithEvents pnlNewPass As System.Windows.Forms.Panel
        Friend WithEvents lbNewPass As System.Windows.Forms.Label
        Friend WithEvents tbNewPass As System.Windows.Forms.TextBox
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lbWrong As System.Windows.Forms.Label

    End Class
End Namespace