Namespace _0App
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Frm4Settings
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
            Me.title = New System.Windows.Forms.Label()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.tabProj = New System.Windows.Forms.Button()
            Me.tabRes = New System.Windows.Forms.Button()
            Me.viewer = New System.Windows.Forms.Panel()
            Me.tabAdmin = New System.Windows.Forms.Button()
            Me.formIcon = New System.Windows.Forms.PictureBox()
            CType(Me.formIcon, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'title
            '
            Me.title.AutoSize = True
            Me.title.Location = New System.Drawing.Point(55, 25)
            Me.title.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.title.Name = "title"
            Me.title.Size = New System.Drawing.Size(217, 21)
            Me.title.TabIndex = 0
            Me.title.Text = "Settings and Global Resources"
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
            Me.btnClose.Location = New System.Drawing.Point(1336, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(40, 40)
            Me.btnClose.TabIndex = 4
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'tabProj
            '
            Me.tabProj.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tabProj.FlatAppearance.BorderSize = 0
            Me.tabProj.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
            Me.tabProj.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
            Me.tabProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabProj.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabProj.ForeColor = System.Drawing.Color.Black
            Me.tabProj.Location = New System.Drawing.Point(23, 70)
            Me.tabProj.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.tabProj.Name = "tabProj"
            Me.tabProj.Size = New System.Drawing.Size(120, 35)
            Me.tabProj.TabIndex = 1
            Me.tabProj.TabStop = False
            Me.tabProj.Tag = "0"
            Me.tabProj.Text = "Projection"
            Me.tabProj.UseVisualStyleBackColor = False
            '
            'tabRes
            '
            Me.tabRes.BackColor = System.Drawing.Color.Gainsboro
            Me.tabRes.FlatAppearance.BorderSize = 0
            Me.tabRes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.tabRes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.tabRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabRes.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabRes.ForeColor = System.Drawing.Color.Black
            Me.tabRes.Location = New System.Drawing.Point(143, 70)
            Me.tabRes.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.tabRes.Name = "tabRes"
            Me.tabRes.Size = New System.Drawing.Size(120, 35)
            Me.tabRes.TabIndex = 2
            Me.tabRes.TabStop = False
            Me.tabRes.Tag = "0"
            Me.tabRes.Text = "Resources"
            Me.tabRes.UseVisualStyleBackColor = False
            '
            'viewer
            '
            Me.viewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.viewer.BackColor = System.Drawing.Color.WhiteSmoke
            Me.viewer.Location = New System.Drawing.Point(23, 105)
            Me.viewer.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.viewer.Name = "viewer"
            Me.viewer.Size = New System.Drawing.Size(1333, 475)
            Me.viewer.TabIndex = 0
            '
            'tabAdmin
            '
            Me.tabAdmin.BackColor = System.Drawing.Color.Gainsboro
            Me.tabAdmin.FlatAppearance.BorderSize = 0
            Me.tabAdmin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.tabAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.tabAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabAdmin.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabAdmin.ForeColor = System.Drawing.Color.Black
            Me.tabAdmin.Location = New System.Drawing.Point(263, 70)
            Me.tabAdmin.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.tabAdmin.Name = "tabAdmin"
            Me.tabAdmin.Size = New System.Drawing.Size(120, 35)
            Me.tabAdmin.TabIndex = 3
            Me.tabAdmin.TabStop = False
            Me.tabAdmin.Tag = "0"
            Me.tabAdmin.Text = "Password"
            Me.tabAdmin.UseVisualStyleBackColor = False
            '
            'formIcon
            '
            Me.formIcon.Image = Global.Entity.My.Resources.Resources.SettingsIcon
            Me.formIcon.Location = New System.Drawing.Point(23, 24)
            Me.formIcon.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.formIcon.Name = "formIcon"
            Me.formIcon.Size = New System.Drawing.Size(25, 25)
            Me.formIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.formIcon.TabIndex = 5
            Me.formIcon.TabStop = False
            '
            'Frm4Settings
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(1378, 603)
            Me.Controls.Add(Me.tabAdmin)
            Me.Controls.Add(Me.viewer)
            Me.Controls.Add(Me.tabRes)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.title)
            Me.Controls.Add(Me.formIcon)
            Me.Controls.Add(Me.tabProj)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.Color.White
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "Frm4Settings"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Entity Settings"
            CType(Me.formIcon, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents title As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents tabProj As System.Windows.Forms.Button
        Friend WithEvents tabRes As System.Windows.Forms.Button
        Friend WithEvents viewer As System.Windows.Forms.Panel
        Friend WithEvents tabAdmin As System.Windows.Forms.Button
        Friend WithEvents formIcon As System.Windows.Forms.PictureBox
    End Class
End NameSpace