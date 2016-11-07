Namespace _0App.InitialSetup
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IFm0ProjectionM
        Inherits IFmBase



        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.content = New System.Windows.Forms.Panel()
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.btnMan = New System.Windows.Forms.Button()
            Me.numRezVert = New System.Windows.Forms.NumericUpDown()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.lbDesc = New System.Windows.Forms.Label()
            Me.lbRes = New System.Windows.Forms.Label()
            Me.lbX = New System.Windows.Forms.Label()
            Me.numRezHoriz = New System.Windows.Forms.NumericUpDown()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.content.SuspendLayout()
            CType(Me.numRezVert, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numRezHoriz, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'imgLst
            '
            Me.imgLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
            Me.imgLst.ImageSize = New System.Drawing.Size(158, 100)
            Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
            '
            'content
            '
            Me.content.Controls.Add(Me.lbTitle)
            Me.content.Controls.Add(Me.btnMan)
            Me.content.Controls.Add(Me.numRezVert)
            Me.content.Controls.Add(Me.btnSave)
            Me.content.Controls.Add(Me.lbDesc)
            Me.content.Controls.Add(Me.lbRes)
            Me.content.Controls.Add(Me.lbX)
            Me.content.Controls.Add(Me.numRezHoriz)
            Me.content.Location = New System.Drawing.Point(215, 23)
            Me.content.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.content.Name = "content"
            Me.content.Size = New System.Drawing.Size(625, 411)
            Me.content.TabIndex = 44
            Me.content.Visible = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.ForeColor = System.Drawing.Color.White
            Me.lbTitle.Location = New System.Drawing.Point(197, 25)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(230, 30)
            Me.lbTitle.TabIndex = 61
            Me.lbTitle.Text = "Manual Projector Setup"
            '
            'btnMan
            '
            Me.btnMan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnMan.BackColor = System.Drawing.Color.Gainsboro
            Me.btnMan.FlatAppearance.BorderSize = 0
            Me.btnMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMan.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMan.ForeColor = System.Drawing.Color.Black
            Me.btnMan.Location = New System.Drawing.Point(16, 363)
            Me.btnMan.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnMan.Name = "btnMan"
            Me.btnMan.Size = New System.Drawing.Size(130, 40)
            Me.btnMan.TabIndex = 58
            Me.btnMan.TabStop = False
            Me.btnMan.Tag = "0"
            Me.btnMan.Text = "&Auto Setup"
            Me.btnMan.UseVisualStyleBackColor = False
            '
            'numRezVert
            '
            Me.numRezVert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.numRezVert.Location = New System.Drawing.Point(321, 236)
            Me.numRezVert.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.numRezVert.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
            Me.numRezVert.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
            Me.numRezVert.Name = "numRezVert"
            Me.numRezVert.Size = New System.Drawing.Size(100, 29)
            Me.numRezVert.TabIndex = 57
            Me.numRezVert.Value = New Decimal(New Integer() {100, 0, 0, 0})
            '
            'btnSave
            '
            Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSave.BackColor = System.Drawing.Color.Gainsboro
            Me.btnSave.FlatAppearance.BorderSize = 0
            Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.Black
            Me.btnSave.Location = New System.Drawing.Point(478, 363)
            Me.btnSave.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(130, 40)
            Me.btnSave.TabIndex = 59
            Me.btnSave.TabStop = False
            Me.btnSave.Tag = "0"
            Me.btnSave.Text = "&OK"
            Me.btnSave.UseVisualStyleBackColor = False
            '
            'lbDesc
            '
            Me.lbDesc.AutoSize = True
            Me.lbDesc.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbDesc.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbDesc.Location = New System.Drawing.Point(85, 68)
            Me.lbDesc.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbDesc.Name = "lbDesc"
            Me.lbDesc.Size = New System.Drawing.Size(454, 60)
            Me.lbDesc.TabIndex = 60
            Me.lbDesc.Text = "Enter your projector's resolution and click the OK button to continue." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you ca" & _
        "n connect to a projector now, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "click the auto setup button to use an simpler se" & _
        "tup interface."
            Me.lbDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lbRes
            '
            Me.lbRes.AutoSize = True
            Me.lbRes.ForeColor = System.Drawing.Color.White
            Me.lbRes.Location = New System.Drawing.Point(235, 201)
            Me.lbRes.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbRes.Name = "lbRes"
            Me.lbRes.Size = New System.Drawing.Size(156, 21)
            Me.lbRes.TabIndex = 54
            Me.lbRes.Text = "Projector Resolution: "
            '
            'lbX
            '
            Me.lbX.AutoSize = True
            Me.lbX.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbX.Location = New System.Drawing.Point(303, 238)
            Me.lbX.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbX.Name = "lbX"
            Me.lbX.Size = New System.Drawing.Size(17, 21)
            Me.lbX.TabIndex = 55
            Me.lbX.Text = "x"
            '
            'numRezHoriz
            '
            Me.numRezHoriz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.numRezHoriz.Location = New System.Drawing.Point(200, 236)
            Me.numRezHoriz.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.numRezHoriz.Maximum = New Decimal(New Integer() {3200, 0, 0, 0})
            Me.numRezHoriz.Minimum = New Decimal(New Integer() {120, 0, 0, 0})
            Me.numRezHoriz.Name = "numRezHoriz"
            Me.numRezHoriz.Size = New System.Drawing.Size(100, 29)
            Me.numRezHoriz.TabIndex = 56
            Me.numRezHoriz.Value = New Decimal(New Integer() {120, 0, 0, 0})
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
            Me.btnClose.ForeColor = System.Drawing.Color.White
            Me.btnClose.Location = New System.Drawing.Point(963, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(64, 27, 64, 27)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 51
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'IFm0ProjectionM
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1000, 470)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.content)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "IFm0ProjectionM"
            Me.Opacity = 0.1R
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.content.ResumeLayout(False)
            Me.content.PerformLayout()
            CType(Me.numRezVert, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numRezHoriz, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents imgLst As System.Windows.Forms.ImageList
        Friend WithEvents content As System.Windows.Forms.Panel
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents btnMan As System.Windows.Forms.Button
        Friend WithEvents numRezVert As System.Windows.Forms.NumericUpDown
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents lbDesc As System.Windows.Forms.Label
        Friend WithEvents lbRes As System.Windows.Forms.Label
        Friend WithEvents lbX As System.Windows.Forms.Label
        Friend WithEvents numRezHoriz As System.Windows.Forms.NumericUpDown

    End Class
End Namespace