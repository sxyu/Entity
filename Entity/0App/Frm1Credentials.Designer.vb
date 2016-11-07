Namespace _0App
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Frm1Credentials
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
            Me.pnlInput = New System.Windows.Forms.Panel()
            Me.lbWrong = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.pbIcon = New System.Windows.Forms.PictureBox()
            Me.lbPass = New System.Windows.Forms.Label()
            Me.btnUnlock = New System.Windows.Forms.Button()
            Me.tbPass = New System.Windows.Forms.TextBox()
            Me.btnKeyboard = New System.Windows.Forms.Button()
            Me.pnlInput.SuspendLayout()
            CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlInput
            '
            Me.pnlInput.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.pnlInput.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.pnlInput.Controls.Add(Me.lbWrong)
            Me.pnlInput.Controls.Add(Me.btnCancel)
            Me.pnlInput.Controls.Add(Me.lbTitle)
            Me.pnlInput.Controls.Add(Me.pbIcon)
            Me.pnlInput.Controls.Add(Me.lbPass)
            Me.pnlInput.Controls.Add(Me.btnUnlock)
            Me.pnlInput.Controls.Add(Me.tbPass)
            Me.pnlInput.Location = New System.Drawing.Point(158, 69)
            Me.pnlInput.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.pnlInput.Name = "pnlInput"
            Me.pnlInput.Size = New System.Drawing.Size(575, 307)
            Me.pnlInput.TabIndex = 0
            '
            'lbWrong
            '
            Me.lbWrong.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lbWrong.ForeColor = System.Drawing.Color.White
            Me.lbWrong.Location = New System.Drawing.Point(277, 184)
            Me.lbWrong.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbWrong.Name = "lbWrong"
            Me.lbWrong.Size = New System.Drawing.Size(242, 31)
            Me.lbWrong.TabIndex = 3
            Me.lbWrong.Text = "Password Incorrect"
            Me.lbWrong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWrong.Visible = False
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCancel.FlatAppearance.BorderSize = 0
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(253, 237)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(53, 46, 0, 14)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(130, 40)
            Me.btnCancel.TabIndex = 1
            Me.btnCancel.TabStop = False
            Me.btnCancel.Tag = "1"
            Me.btnCancel.Text = "&Cancel"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.ForeColor = System.Drawing.Color.White
            Me.lbTitle.Location = New System.Drawing.Point(121, 40)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(151, 32)
            Me.lbTitle.TabIndex = 5
            Me.lbTitle.Text = "Entity System"
            '
            'pbIcon
            '
            Me.pbIcon.Location = New System.Drawing.Point(59, 32)
            Me.pbIcon.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pbIcon.Name = "pbIcon"
            Me.pbIcon.Size = New System.Drawing.Size(48, 47)
            Me.pbIcon.TabIndex = 50
            Me.pbIcon.TabStop = False
            '
            'lbPass
            '
            Me.lbPass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lbPass.AutoSize = True
            Me.lbPass.ForeColor = System.Drawing.Color.White
            Me.lbPass.Location = New System.Drawing.Point(51, 111)
            Me.lbPass.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbPass.Name = "lbPass"
            Me.lbPass.Size = New System.Drawing.Size(74, 21)
            Me.lbPass.TabIndex = 4
            Me.lbPass.Text = "Password"
            '
            'btnUnlock
            '
            Me.btnUnlock.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnUnlock.BackColor = System.Drawing.Color.Gainsboro
            Me.btnUnlock.FlatAppearance.BorderSize = 0
            Me.btnUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUnlock.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUnlock.ForeColor = System.Drawing.Color.Black
            Me.btnUnlock.Location = New System.Drawing.Point(389, 237)
            Me.btnUnlock.Margin = New System.Windows.Forms.Padding(53, 46, 0, 14)
            Me.btnUnlock.Name = "btnUnlock"
            Me.btnUnlock.Size = New System.Drawing.Size(130, 40)
            Me.btnUnlock.TabIndex = 2
            Me.btnUnlock.TabStop = False
            Me.btnUnlock.Tag = "0"
            Me.btnUnlock.Text = "&Unlock"
            Me.btnUnlock.UseVisualStyleBackColor = False
            '
            'tbPass
            '
            Me.tbPass.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tbPass.Location = New System.Drawing.Point(55, 155)
            Me.tbPass.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.tbPass.Name = "tbPass"
            Me.tbPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.tbPass.Size = New System.Drawing.Size(464, 29)
            Me.tbPass.TabIndex = 0
            '
            'btnKeyboard
            '
            Me.btnKeyboard.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnKeyboard.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnKeyboard.FlatAppearance.BorderSize = 0
            Me.btnKeyboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnKeyboard.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnKeyboard.ForeColor = System.Drawing.Color.White
            Me.btnKeyboard.Location = New System.Drawing.Point(751, 401)
            Me.btnKeyboard.Margin = New System.Windows.Forms.Padding(53, 46, 0, 14)
            Me.btnKeyboard.Name = "btnKeyboard"
            Me.btnKeyboard.Size = New System.Drawing.Size(141, 40)
            Me.btnKeyboard.TabIndex = 51
            Me.btnKeyboard.TabStop = False
            Me.btnKeyboard.Tag = "1"
            Me.btnKeyboard.Text = "Touch Keyboard"
            Me.btnKeyboard.UseVisualStyleBackColor = False
            '
            'Frm1Credentials
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(891, 441)
            Me.Controls.Add(Me.btnKeyboard)
            Me.Controls.Add(Me.pnlInput)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "Frm1Credentials"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Entity System"
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.pnlInput.ResumeLayout(False)
            Me.pnlInput.PerformLayout()
            CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pnlInput As System.Windows.Forms.Panel
        Friend WithEvents tbPass As System.Windows.Forms.TextBox
        Friend WithEvents btnUnlock As System.Windows.Forms.Button
        Friend WithEvents lbPass As System.Windows.Forms.Label
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents pbIcon As System.Windows.Forms.PictureBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lbWrong As System.Windows.Forms.Label
        Friend WithEvents btnKeyboard As System.Windows.Forms.Button
    End Class
End Namespace