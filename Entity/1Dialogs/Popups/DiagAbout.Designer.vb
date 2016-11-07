Namespace _1Dialogs.Popups
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagAbout
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
            Me.btnClose = New System.Windows.Forms.Button()
            Me.title = New System.Windows.Forms.Label()
            Me.pnlBody = New System.Windows.Forms.Panel()
            Me.pnlInfo = New System.Windows.Forms.Panel()
            Me.lbDotNet = New System.Windows.Forms.Label()
            Me.lbCredits = New System.Windows.Forms.Label()
            Me.tbCredits = New System.Windows.Forms.TextBox()
            Me.lbCopyright = New System.Windows.Forms.Label()
            Me.lbVer = New System.Windows.Forms.Label()
            Me.lbName = New System.Windows.Forms.Label()
            Me.cbCheckUpd = New System.Windows.Forms.CheckBox()
            Me.btnContacts = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnMSPL = New System.Windows.Forms.Button()
            Me.btnCPOL = New System.Windows.Forms.Button()
            Me.logo = New System.Windows.Forms.Label()
            Me.updateBW = New System.ComponentModel.BackgroundWorker()
            Me.tmrDraw = New System.Windows.Forms.Timer(Me.components)
            Me.pnlBody.SuspendLayout()
            Me.pnlInfo.SuspendLayout()
            Me.SuspendLayout()
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
            Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnClose.Location = New System.Drawing.Point(697, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(30, 30)
            Me.btnClose.TabIndex = 1
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'title
            '
            Me.title.AutoSize = True
            Me.title.Location = New System.Drawing.Point(52, 26)
            Me.title.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.title.Name = "title"
            Me.title.Size = New System.Drawing.Size(172, 21)
            Me.title.TabIndex = 3
            Me.title.Text = "About the Entity System"
            '
            'pnlBody
            '
            Me.pnlBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlBody.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
            Me.pnlBody.Controls.Add(Me.pnlInfo)
            Me.pnlBody.Location = New System.Drawing.Point(18, 67)
            Me.pnlBody.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pnlBody.Name = "pnlBody"
            Me.pnlBody.Size = New System.Drawing.Size(692, 302)
            Me.pnlBody.TabIndex = 5
            '
            'pnlInfo
            '
            Me.pnlInfo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlInfo.BackColor = System.Drawing.Color.WhiteSmoke
            Me.pnlInfo.Controls.Add(Me.lbDotNet)
            Me.pnlInfo.Controls.Add(Me.lbCredits)
            Me.pnlInfo.Controls.Add(Me.tbCredits)
            Me.pnlInfo.Controls.Add(Me.lbCopyright)
            Me.pnlInfo.Controls.Add(Me.lbVer)
            Me.pnlInfo.Controls.Add(Me.lbName)
            Me.pnlInfo.ForeColor = System.Drawing.Color.White
            Me.pnlInfo.Location = New System.Drawing.Point(0, 65)
            Me.pnlInfo.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pnlInfo.Name = "pnlInfo"
            Me.pnlInfo.Size = New System.Drawing.Size(692, 237)
            Me.pnlInfo.TabIndex = 6
            '
            'lbDotNet
            '
            Me.lbDotNet.AutoSize = True
            Me.lbDotNet.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lbDotNet.Location = New System.Drawing.Point(20, 83)
            Me.lbDotNet.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbDotNet.Name = "lbDotNet"
            Me.lbDotNet.Size = New System.Drawing.Size(272, 21)
            Me.lbDotNet.TabIndex = 12
            Me.lbDotNet.Text = "Built On Microsoft .Net Framework 4.0"
            '
            'lbCredits
            '
            Me.lbCredits.AutoSize = True
            Me.lbCredits.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lbCredits.Location = New System.Drawing.Point(20, 83)
            Me.lbCredits.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbCredits.Name = "lbCredits"
            Me.lbCredits.Size = New System.Drawing.Size(62, 21)
            Me.lbCredits.TabIndex = 8
            Me.lbCredits.Text = "Credits:"
            '
            'tbCredits
            '
            Me.tbCredits.Cursor = System.Windows.Forms.Cursors.Default
            Me.tbCredits.Font = New System.Drawing.Font("Segoe UI Semilight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbCredits.Location = New System.Drawing.Point(24, 118)
            Me.tbCredits.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbCredits.Multiline = True
            Me.tbCredits.Name = "tbCredits"
            Me.tbCredits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.tbCredits.Size = New System.Drawing.Size(646, 97)
            Me.tbCredits.TabIndex = 7
            Me.tbCredits.TabStop = False
            '
            'lbCopyright
            '
            Me.lbCopyright.AutoSize = True
            Me.lbCopyright.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lbCopyright.Location = New System.Drawing.Point(20, 54)
            Me.lbCopyright.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbCopyright.Name = "lbCopyright"
            Me.lbCopyright.Size = New System.Drawing.Size(77, 21)
            Me.lbCopyright.TabIndex = 6
            Me.lbCopyright.Text = "Copyright"
            '
            'lbVer
            '
            Me.lbVer.AutoSize = True
            Me.lbVer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lbVer.Location = New System.Drawing.Point(20, 33)
            Me.lbVer.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbVer.Name = "lbVer"
            Me.lbVer.Size = New System.Drawing.Size(61, 21)
            Me.lbVer.TabIndex = 5
            Me.lbVer.Text = "Version"
            '
            'lbName
            '
            Me.lbName.AutoSize = True
            Me.lbName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lbName.Location = New System.Drawing.Point(20, 12)
            Me.lbName.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbName.Name = "lbName"
            Me.lbName.Size = New System.Drawing.Size(100, 21)
            Me.lbName.TabIndex = 4
            Me.lbName.Text = "Entity System"
            '
            'cbCheckUpd
            '
            Me.cbCheckUpd.AutoSize = True
            Me.cbCheckUpd.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbCheckUpd.ForeColor = System.Drawing.Color.White
            Me.cbCheckUpd.Location = New System.Drawing.Point(475, 423)
            Me.cbCheckUpd.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.cbCheckUpd.Name = "cbCheckUpd"
            Me.cbCheckUpd.Size = New System.Drawing.Size(235, 25)
            Me.cbCheckUpd.TabIndex = 7
            Me.cbCheckUpd.TabStop = False
            Me.cbCheckUpd.Text = "Check For Updates On &Startup"
            Me.cbCheckUpd.UseVisualStyleBackColor = True
            '
            'btnContacts
            '
            Me.btnContacts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnContacts.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnContacts.FlatAppearance.BorderSize = 0
            Me.btnContacts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnContacts.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnContacts.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnContacts.Location = New System.Drawing.Point(276, 380)
            Me.btnContacts.Margin = New System.Windows.Forms.Padding(0, 23, 53, 23)
            Me.btnContacts.Name = "btnContacts"
            Me.btnContacts.Size = New System.Drawing.Size(120, 40)
            Me.btnContacts.TabIndex = 13
            Me.btnContacts.TabStop = False
            Me.btnContacts.Text = "Contacts"
            Me.btnContacts.UseVisualStyleBackColor = False
            '
            'btnUpdate
            '
            Me.btnUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnUpdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnUpdate.FlatAppearance.BorderSize = 0
            Me.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUpdate.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnUpdate.Location = New System.Drawing.Point(475, 380)
            Me.btnUpdate.Margin = New System.Windows.Forms.Padding(0, 23, 53, 23)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(235, 40)
            Me.btnUpdate.TabIndex = 11
            Me.btnUpdate.TabStop = False
            Me.btnUpdate.Text = "Check For &Update"
            Me.btnUpdate.UseVisualStyleBackColor = False
            '
            'btnMSPL
            '
            Me.btnMSPL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnMSPL.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnMSPL.FlatAppearance.BorderSize = 0
            Me.btnMSPL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMSPL.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMSPL.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnMSPL.Location = New System.Drawing.Point(147, 380)
            Me.btnMSPL.Margin = New System.Windows.Forms.Padding(0, 23, 53, 23)
            Me.btnMSPL.Name = "btnMSPL"
            Me.btnMSPL.Size = New System.Drawing.Size(120, 40)
            Me.btnMSPL.TabIndex = 10
            Me.btnMSPL.TabStop = False
            Me.btnMSPL.Text = "MS-PL"
            Me.btnMSPL.UseVisualStyleBackColor = False
            '
            'btnCPOL
            '
            Me.btnCPOL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnCPOL.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnCPOL.FlatAppearance.BorderSize = 0
            Me.btnCPOL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCPOL.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCPOL.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnCPOL.Location = New System.Drawing.Point(18, 380)
            Me.btnCPOL.Margin = New System.Windows.Forms.Padding(0, 23, 53, 23)
            Me.btnCPOL.Name = "btnCPOL"
            Me.btnCPOL.Size = New System.Drawing.Size(120, 40)
            Me.btnCPOL.TabIndex = 9
            Me.btnCPOL.TabStop = False
            Me.btnCPOL.Text = "CPOL"
            Me.btnCPOL.UseVisualStyleBackColor = False
            '
            'logo
            '
            Me.logo.AutoSize = True
            Me.logo.Font = New System.Drawing.Font("Segoe UI Semilight", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.logo.Location = New System.Drawing.Point(14, 21)
            Me.logo.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.logo.Name = "logo"
            Me.logo.Size = New System.Drawing.Size(31, 32)
            Me.logo.TabIndex = 6
            Me.logo.Text = "A"
            '
            'updateBW
            '
            '
            'tmrDraw
            '
            Me.tmrDraw.Enabled = True
            Me.tmrDraw.Interval = 5000
            '
            'DiagAbout
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(729, 463)
            Me.Controls.Add(Me.cbCheckUpd)
            Me.Controls.Add(Me.logo)
            Me.Controls.Add(Me.title)
            Me.Controls.Add(Me.btnContacts)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnCPOL)
            Me.Controls.Add(Me.btnMSPL)
            Me.Controls.Add(Me.pnlBody)
            Me.Controls.Add(Me.btnUpdate)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagAbout"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Entity System"
            Me.pnlBody.ResumeLayout(False)
            Me.pnlInfo.ResumeLayout(False)
            Me.pnlInfo.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents title As System.Windows.Forms.Label
        Friend WithEvents pnlBody As System.Windows.Forms.Panel
        Friend WithEvents pnlInfo As System.Windows.Forms.Panel
        Friend WithEvents lbName As System.Windows.Forms.Label
        Friend WithEvents lbVer As System.Windows.Forms.Label
        Friend WithEvents lbCopyright As System.Windows.Forms.Label
        Friend WithEvents logo As System.Windows.Forms.Label
        Friend WithEvents tbCredits As System.Windows.Forms.TextBox
        Friend WithEvents lbCredits As System.Windows.Forms.Label
        Friend WithEvents btnCPOL As System.Windows.Forms.Button
        Friend WithEvents btnMSPL As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents lbDotNet As System.Windows.Forms.Label
        Friend WithEvents updateBW As System.ComponentModel.BackgroundWorker
        Friend WithEvents cbCheckUpd As System.Windows.Forms.CheckBox
        Friend WithEvents btnContacts As System.Windows.Forms.Button
        Friend WithEvents tmrDraw As System.Windows.Forms.Timer
    End Class
End NameSpace