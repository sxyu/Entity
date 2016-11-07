Namespace _6Misc
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FrmUpdate
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
            Me.tbNotes = New System.Windows.Forms.TextBox()
            Me.lbVer = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.lbDesc = New System.Windows.Forms.Label()
            Me.cbCheckUpd = New System.Windows.Forms.CheckBox()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'tbNotes
            '
            Me.tbNotes.BackColor = System.Drawing.Color.Gainsboro
            Me.tbNotes.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tbNotes.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.tbNotes.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbNotes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.tbNotes.Location = New System.Drawing.Point(19, 126)
            Me.tbNotes.Margin = New System.Windows.Forms.Padding(29, 13, 29, 13)
            Me.tbNotes.Multiline = True
            Me.tbNotes.Name = "tbNotes"
            Me.tbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.tbNotes.Size = New System.Drawing.Size(473, 190)
            Me.tbNotes.TabIndex = 1
            Me.tbNotes.TabStop = False
            '
            'lbVer
            '
            Me.lbVer.AutoSize = True
            Me.lbVer.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbVer.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbVer.Location = New System.Drawing.Point(15, 92)
            Me.lbVer.Margin = New System.Windows.Forms.Padding(48, 0, 48, 0)
            Me.lbVer.Name = "lbVer"
            Me.lbVer.Size = New System.Drawing.Size(85, 21)
            Me.lbVer.TabIndex = 3
            Me.lbVer.Text = "Version 2.0"
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.Gainsboro
            Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.ForeColor = System.Drawing.SystemColors.WindowFrame
            Me.btnOK.Location = New System.Drawing.Point(372, 326)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(29, 13, 29, 13)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(120, 40)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "&Install"
            Me.btnOK.UseVisualStyleBackColor = False
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatAppearance.BorderSize = 0
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.ForeColor = System.Drawing.SystemColors.WindowFrame
            Me.btnCancel.Location = New System.Drawing.Point(247, 326)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(29, 13, 29, 13)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(120, 40)
            Me.btnCancel.TabIndex = 3
            Me.btnCancel.Text = "&Later"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbTitle.Location = New System.Drawing.Point(14, 9)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(48, 0, 48, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(152, 25)
            Me.lbTitle.TabIndex = 1
            Me.lbTitle.Text = "Update Available"
            '
            'lbDesc
            '
            Me.lbDesc.AutoSize = True
            Me.lbDesc.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbDesc.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbDesc.Location = New System.Drawing.Point(15, 57)
            Me.lbDesc.Margin = New System.Windows.Forms.Padding(48, 0, 48, 0)
            Me.lbDesc.Name = "lbDesc"
            Me.lbDesc.Size = New System.Drawing.Size(339, 21)
            Me.lbDesc.TabIndex = 4
            Me.lbDesc.Text = "A newer version of the Entity System is available."
            '
            'cbCheckUpd
            '
            Me.cbCheckUpd.AutoSize = True
            Me.cbCheckUpd.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbCheckUpd.ForeColor = System.Drawing.Color.White
            Me.cbCheckUpd.Location = New System.Drawing.Point(19, 331)
            Me.cbCheckUpd.Margin = New System.Windows.Forms.Padding(29, 13, 29, 13)
            Me.cbCheckUpd.Name = "cbCheckUpd"
            Me.cbCheckUpd.Size = New System.Drawing.Size(227, 25)
            Me.cbCheckUpd.TabIndex = 5
            Me.cbCheckUpd.Text = "Check for updates on startup"
            Me.cbCheckUpd.UseVisualStyleBackColor = True
            '
            'btnClose
            '
            Me.btnClose.FlatAppearance.BorderSize = 0
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.ForeColor = System.Drawing.Color.White
            Me.btnClose.Location = New System.Drawing.Point(470, 2)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 45
            Me.btnClose.Text = "x"
            '
            'FrmUpdate
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(150, Byte), Integer))
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(507, 380)
            Me.ControlBox = False
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.cbCheckUpd)
            Me.Controls.Add(Me.lbDesc)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.lbVer)
            Me.Controls.Add(Me.tbNotes)
            Me.Controls.Add(Me.lbTitle)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(48, 21, 48, 21)
            Me.Name = "FrmUpdate"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Tag = "update"
            Me.Text = "Update"
            Me.TopMost = True
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents tbNotes As System.Windows.Forms.TextBox
        Friend WithEvents lbVer As System.Windows.Forms.Label
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents lbDesc As System.Windows.Forms.Label
        Friend WithEvents cbCheckUpd As System.Windows.Forms.CheckBox
        Friend WithEvents btnClose As System.Windows.Forms.Button
    End Class
End Namespace