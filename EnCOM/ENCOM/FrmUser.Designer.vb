<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUser
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
        Me.tbName = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lbName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'tbName
        '
        Me.tbName.Location = New System.Drawing.Point(24, 40)
        Me.tbName.Margin = New System.Windows.Forms.Padding(41, 17, 41, 17)
        Me.tbName.MaxLength = 25
        Me.tbName.Name = "tbName"
        Me.tbName.Size = New System.Drawing.Size(300, 25)
        Me.tbName.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.btnOK.Enabled = False
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(194, 75)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(41, 17, 41, 17)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(130, 40)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "&Enter EnCOM"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.Location = New System.Drawing.Point(21, 15)
        Me.lbName.Margin = New System.Windows.Forms.Padding(41, 0, 41, 0)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(45, 17)
        Me.lbName.TabIndex = 4
        Me.lbName.Text = "Name:"
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(346, 127)
        Me.Controls.Add(Me.lbName)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tbName)
        Me.Font = New System.Drawing.Font("Segoe UI Semilight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(41, 23, 41, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entity EnCOM Standalone Client"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbName As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lbName As System.Windows.Forms.Label
End Class
