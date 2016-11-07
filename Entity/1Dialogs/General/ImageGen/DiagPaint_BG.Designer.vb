Namespace _1Dialogs.General.ImageGen
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagPaintBg
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
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnGradSw = New System.Windows.Forms.Button()
            Me.btnCustomBack = New System.Windows.Forms.Button()
            Me.rbImage = New System.Windows.Forms.RadioButton()
            Me.btnGradEnd = New System.Windows.Forms.Button()
            Me.cbGradType = New System.Windows.Forms.ComboBox()
            Me.btnGradStart = New System.Windows.Forms.Button()
            Me.rbGrad = New System.Windows.Forms.RadioButton()
            Me.btnSolidColor = New System.Windows.Forms.Button()
            Me.rbSolid = New System.Windows.Forms.RadioButton()
            Me.pnlGrad = New System.Windows.Forms.Panel()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.pnlGrad.SuspendLayout()
            Me.SuspendLayout()
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.Location = New System.Drawing.Point(29, 23)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(202, 30)
            Me.lbTitle.TabIndex = 0
            Me.lbTitle.Text = "Background Options"
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.Gainsboro
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnOK.Location = New System.Drawing.Point(303, 368)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(130, 40)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "&OK"
            Me.btnOK.UseVisualStyleBackColor = False
            '
            'btnGradSw
            '
            Me.btnGradSw.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnGradSw.FlatAppearance.BorderSize = 0
            Me.btnGradSw.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
            Me.btnGradSw.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGradSw.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGradSw.Location = New System.Drawing.Point(270, 0)
            Me.btnGradSw.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnGradSw.Name = "btnGradSw"
            Me.btnGradSw.Size = New System.Drawing.Size(100, 40)
            Me.btnGradSw.TabIndex = 2367
            Me.btnGradSw.Tag = "a"
            Me.btnGradSw.Text = "Reverse"
            Me.btnGradSw.UseVisualStyleBackColor = False
            '
            'btnCustomBack
            '
            Me.btnCustomBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnCustomBack.FlatAppearance.BorderSize = 0
            Me.btnCustomBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
            Me.btnCustomBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCustomBack.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCustomBack.ForeColor = System.Drawing.Color.White
            Me.btnCustomBack.Location = New System.Drawing.Point(34, 302)
            Me.btnCustomBack.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnCustomBack.Name = "btnCustomBack"
            Me.btnCustomBack.Size = New System.Drawing.Size(130, 40)
            Me.btnCustomBack.TabIndex = 2366
            Me.btnCustomBack.Tag = "c"
            Me.btnCustomBack.Text = "Select File"
            Me.btnCustomBack.UseVisualStyleBackColor = False
            '
            'rbImage
            '
            Me.rbImage.AutoSize = True
            Me.rbImage.Location = New System.Drawing.Point(34, 273)
            Me.rbImage.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.rbImage.Name = "rbImage"
            Me.rbImage.Size = New System.Drawing.Size(70, 25)
            Me.rbImage.TabIndex = 2365
            Me.rbImage.Tag = "c"
            Me.rbImage.Text = "Image"
            Me.rbImage.UseVisualStyleBackColor = True
            '
            'btnGradEnd
            '
            Me.btnGradEnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnGradEnd.FlatAppearance.BorderSize = 0
            Me.btnGradEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGradEnd.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGradEnd.ForeColor = System.Drawing.Color.White
            Me.btnGradEnd.Location = New System.Drawing.Point(135, 0)
            Me.btnGradEnd.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnGradEnd.Name = "btnGradEnd"
            Me.btnGradEnd.Size = New System.Drawing.Size(130, 40)
            Me.btnGradEnd.TabIndex = 2364
            Me.btnGradEnd.Tag = "a"
            Me.btnGradEnd.Text = "Color 2"
            Me.btnGradEnd.UseVisualStyleBackColor = False
            '
            'cbGradType
            '
            Me.cbGradType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbGradType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbGradType.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbGradType.FormattingEnabled = True
            Me.cbGradType.Items.AddRange(New Object() {"Horizontal", "Vertical", "Diagonal Foreward", "Diagonal Backward", "Central"})
            Me.cbGradType.Location = New System.Drawing.Point(0, 49)
            Me.cbGradType.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.cbGradType.Name = "cbGradType"
            Me.cbGradType.Size = New System.Drawing.Size(370, 29)
            Me.cbGradType.TabIndex = 2362
            Me.cbGradType.Tag = "a"
            '
            'btnGradStart
            '
            Me.btnGradStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnGradStart.FlatAppearance.BorderSize = 0
            Me.btnGradStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGradStart.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGradStart.ForeColor = System.Drawing.Color.White
            Me.btnGradStart.Location = New System.Drawing.Point(0, 0)
            Me.btnGradStart.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnGradStart.Name = "btnGradStart"
            Me.btnGradStart.Size = New System.Drawing.Size(130, 40)
            Me.btnGradStart.TabIndex = 2363
            Me.btnGradStart.Tag = "a"
            Me.btnGradStart.Text = "Color 1"
            Me.btnGradStart.UseVisualStyleBackColor = False
            '
            'rbGrad
            '
            Me.rbGrad.AutoSize = True
            Me.rbGrad.Location = New System.Drawing.Point(34, 151)
            Me.rbGrad.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.rbGrad.Name = "rbGrad"
            Me.rbGrad.Size = New System.Drawing.Size(87, 25)
            Me.rbGrad.TabIndex = 2361
            Me.rbGrad.Tag = "a"
            Me.rbGrad.Text = "Gradient"
            Me.rbGrad.UseVisualStyleBackColor = True
            '
            'btnSolidColor
            '
            Me.btnSolidColor.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnSolidColor.FlatAppearance.BorderSize = 0
            Me.btnSolidColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSolidColor.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSolidColor.ForeColor = System.Drawing.Color.White
            Me.btnSolidColor.Location = New System.Drawing.Point(34, 96)
            Me.btnSolidColor.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnSolidColor.Name = "btnSolidColor"
            Me.btnSolidColor.Size = New System.Drawing.Size(130, 40)
            Me.btnSolidColor.TabIndex = 2360
            Me.btnSolidColor.Tag = "a"
            Me.btnSolidColor.Text = "Color"
            Me.btnSolidColor.UseVisualStyleBackColor = False
            '
            'rbSolid
            '
            Me.rbSolid.AutoSize = True
            Me.rbSolid.Checked = True
            Me.rbSolid.Location = New System.Drawing.Point(34, 67)
            Me.rbSolid.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.rbSolid.Name = "rbSolid"
            Me.rbSolid.Size = New System.Drawing.Size(103, 25)
            Me.rbSolid.TabIndex = 2359
            Me.rbSolid.TabStop = True
            Me.rbSolid.Tag = "a"
            Me.rbSolid.Text = "Solid Color"
            Me.rbSolid.UseVisualStyleBackColor = True
            '
            'pnlGrad
            '
            Me.pnlGrad.Controls.Add(Me.btnGradSw)
            Me.pnlGrad.Controls.Add(Me.btnGradEnd)
            Me.pnlGrad.Controls.Add(Me.btnGradStart)
            Me.pnlGrad.Controls.Add(Me.cbGradType)
            Me.pnlGrad.Location = New System.Drawing.Point(34, 180)
            Me.pnlGrad.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pnlGrad.Name = "pnlGrad"
            Me.pnlGrad.Size = New System.Drawing.Size(399, 80)
            Me.pnlGrad.TabIndex = 2368
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
            Me.btnClose.Location = New System.Drawing.Point(413, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 2369
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'DiagPaintBg
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.CancelButton = Me.btnOK
            Me.ClientSize = New System.Drawing.Size(450, 422)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnCustomBack)
            Me.Controls.Add(Me.rbImage)
            Me.Controls.Add(Me.rbGrad)
            Me.Controls.Add(Me.btnSolidColor)
            Me.Controls.Add(Me.rbSolid)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.lbTitle)
            Me.Controls.Add(Me.pnlGrad)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagPaintBg"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "2"
            Me.TopMost = True
            Me.pnlGrad.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnGradSw As System.Windows.Forms.Button
        Friend WithEvents btnCustomBack As System.Windows.Forms.Button
        Friend WithEvents rbImage As System.Windows.Forms.RadioButton
        Friend WithEvents btnGradEnd As System.Windows.Forms.Button
        Friend WithEvents cbGradType As System.Windows.Forms.ComboBox
        Friend WithEvents btnGradStart As System.Windows.Forms.Button
        Friend WithEvents rbGrad As System.Windows.Forms.RadioButton
        Friend WithEvents btnSolidColor As System.Windows.Forms.Button
        Friend WithEvents rbSolid As System.Windows.Forms.RadioButton
        Friend WithEvents pnlGrad As System.Windows.Forms.Panel
        Friend WithEvents btnClose As System.Windows.Forms.Button
    End Class
End Namespace