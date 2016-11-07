Namespace _1Dialogs.Popups
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagImageView
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
            Me.btnClose = New System.Windows.Forms.Button()
            Me.pb = New System.Windows.Forms.PictureBox()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.btnClose.Location = New System.Drawing.Point(783, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 1
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'pb
            '
            Me.pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pb.BackColor = System.Drawing.Color.Gainsboro
            Me.pb.Location = New System.Drawing.Point(-1, 55)
            Me.pb.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pb.Name = "pb"
            Me.pb.Size = New System.Drawing.Size(821, 345)
            Me.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pb.TabIndex = 2
            Me.pb.TabStop = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(19, 17)
            Me.Label1.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(144, 21)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Entity Image Viewer"
            '
            'DiagImageView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(820, 400)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.pb)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagImageView"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Entity System"
            Me.TopMost = True
            CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents pb As System.Windows.Forms.PictureBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
    End Class
End NameSpace