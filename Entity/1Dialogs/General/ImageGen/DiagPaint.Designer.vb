Namespace _1Dialogs.General.ImageGen
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagPaint
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
            Me.btnColor = New System.Windows.Forms.Button()
            Me.tb = New System.Windows.Forms.TextBox()
            Me.btnFont = New System.Windows.Forms.Button()
            Me.cbAlign = New System.Windows.Forms.ComboBox()
            Me.btnBGOpts = New System.Windows.Forms.Button()
            Me.btnOK = New System.Windows.Forms.Button()
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
            Me.btnClose.Location = New System.Drawing.Point(928, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 1
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'pb
            '
            Me.pb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pb.BackColor = System.Drawing.Color.Black
            Me.pb.Location = New System.Drawing.Point(2, 65)
            Me.pb.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pb.Name = "pb"
            Me.pb.Size = New System.Drawing.Size(961, 419)
            Me.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pb.TabIndex = 2
            Me.pb.TabStop = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(17, 21)
            Me.Label1.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(174, 21)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Simple Image Generator"
            '
            'btnColor
            '
            Me.btnColor.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnColor.BackColor = System.Drawing.Color.White
            Me.btnColor.FlatAppearance.BorderSize = 0
            Me.btnColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
            Me.btnColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
            Me.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnColor.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnColor.ForeColor = System.Drawing.Color.Black
            Me.btnColor.Location = New System.Drawing.Point(252, 585)
            Me.btnColor.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnColor.Name = "btnColor"
            Me.btnColor.Size = New System.Drawing.Size(50, 40)
            Me.btnColor.TabIndex = 2
            Me.btnColor.Text = "Color"
            Me.btnColor.UseVisualStyleBackColor = False
            '
            'tb
            '
            Me.tb.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tb.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tb.Location = New System.Drawing.Point(1, 495)
            Me.tb.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tb.Multiline = True
            Me.tb.Name = "tb"
            Me.tb.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.tb.Size = New System.Drawing.Size(962, 91)
            Me.tb.TabIndex = 0
            Me.tb.Text = "Entity Show"
            '
            'btnFont
            '
            Me.btnFont.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnFont.BackColor = System.Drawing.Color.Gainsboro
            Me.btnFont.FlatAppearance.BorderSize = 0
            Me.btnFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnFont.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!)
            Me.btnFont.ForeColor = System.Drawing.Color.Black
            Me.btnFont.Location = New System.Drawing.Point(2, 585)
            Me.btnFont.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnFont.Name = "btnFont"
            Me.btnFont.Size = New System.Drawing.Size(250, 40)
            Me.btnFont.TabIndex = 1
            Me.btnFont.Text = "Segoe UI SemiLight 72 pt"
            Me.btnFont.UseVisualStyleBackColor = False
            '
            'cbAlign
            '
            Me.cbAlign.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.cbAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbAlign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbAlign.Font = New System.Drawing.Font("Segoe UI Semilight", 11.0!)
            Me.cbAlign.FormattingEnabled = True
            Me.cbAlign.ItemHeight = 20
            Me.cbAlign.Items.AddRange(New Object() {"Top Left", "Top Center", "Top Right", "Center Left", "Center", "Center Right", "Bottom Left", "Bottom Center", "Bottom Right"})
            Me.cbAlign.Location = New System.Drawing.Point(316, 591)
            Me.cbAlign.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.cbAlign.Name = "cbAlign"
            Me.cbAlign.Size = New System.Drawing.Size(200, 28)
            Me.cbAlign.TabIndex = 3
            '
            'btnBGOpts
            '
            Me.btnBGOpts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnBGOpts.BackColor = System.Drawing.Color.Gainsboro
            Me.btnBGOpts.FlatAppearance.BorderSize = 0
            Me.btnBGOpts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBGOpts.ForeColor = System.Drawing.Color.Black
            Me.btnBGOpts.Location = New System.Drawing.Point(663, 585)
            Me.btnBGOpts.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnBGOpts.Name = "btnBGOpts"
            Me.btnBGOpts.Size = New System.Drawing.Size(170, 40)
            Me.btnBGOpts.TabIndex = 9
            Me.btnBGOpts.Text = "Background &Options"
            Me.btnBGOpts.UseVisualStyleBackColor = False
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnOK.BackColor = System.Drawing.Color.IndianRed
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.ForeColor = System.Drawing.Color.White
            Me.btnOK.Location = New System.Drawing.Point(833, 585)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(130, 40)
            Me.btnOK.TabIndex = 10
            Me.btnOK.Text = "&OK"
            Me.btnOK.UseVisualStyleBackColor = False
            '
            'DiagPaint
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(965, 627)
            Me.Controls.Add(Me.cbAlign)
            Me.Controls.Add(Me.btnFont)
            Me.Controls.Add(Me.tb)
            Me.Controls.Add(Me.btnColor)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.pb)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.btnBGOpts)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagPaint"
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
        Friend WithEvents btnColor As System.Windows.Forms.Button
        Friend WithEvents tb As System.Windows.Forms.TextBox
        Friend WithEvents btnFont As System.Windows.Forms.Button
        Friend WithEvents cbAlign As System.Windows.Forms.ComboBox
        Friend WithEvents btnBGOpts As System.Windows.Forms.Button
        Friend WithEvents btnOK As System.Windows.Forms.Button
    End Class
End NameSpace