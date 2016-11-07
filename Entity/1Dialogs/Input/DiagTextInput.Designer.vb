Namespace _1Dialogs.Input
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagTextInput
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnCreate = New System.Windows.Forms.Button()
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(41, 20)
            Me.Label1.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(110, 30)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "New Show"
            '
            'btnCreate
            '
            Me.btnCreate.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCreate.Enabled = False
            Me.btnCreate.FlatAppearance.BorderSize = 0
            Me.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCreate.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnCreate.Location = New System.Drawing.Point(315, 168)
            Me.btnCreate.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnCreate.Name = "btnCreate"
            Me.btnCreate.Size = New System.Drawing.Size(130, 40)
            Me.btnCreate.TabIndex = 1
            Me.btnCreate.Text = "Cre&ate"
            Me.btnCreate.UseVisualStyleBackColor = False
            '
            'tbName
            '
            Me.tbName.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tbName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.tbName.Location = New System.Drawing.Point(46, 105)
            Me.tbName.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbName.MaxLength = 50
            Me.tbName.MinimumSize = New System.Drawing.Size(300, 29)
            Me.tbName.Name = "tbName"
            Me.tbName.Size = New System.Drawing.Size(400, 29)
            Me.tbName.TabIndex = 0
            Me.tbName.WordWrap = False
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(42, 70)
            Me.Label2.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(51, 21)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Name"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatAppearance.BorderSize = 0
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnCancel.Location = New System.Drawing.Point(180, 168)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(130, 40)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "&Cancel"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'lbWarning
            '
            Me.lbWarning.ForeColor = System.Drawing.Color.White
            Me.lbWarning.Location = New System.Drawing.Point(267, 526)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(3915, 96)
            Me.lbWarning.TabIndex = 5
            Me.lbWarning.Text = "Name Cannot be Empty!"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWarning.Visible = False
            '
            'DiagTextInput
            '
            Me.AcceptButton = Me.btnCreate
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(496, 240)
            Me.Controls.Add(Me.lbWarning)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.Label2)
            Me.Controls.Add(Me.tbName)
            Me.Controls.Add(Me.btnCreate)
            Me.Controls.Add(Me.Label1)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagTextInput"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Entity System"
            Me.TopMost = True
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnCreate As System.Windows.Forms.Button
        Friend WithEvents tbName As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lbWarning As System.Windows.Forms.Label
    End Class
End NameSpace