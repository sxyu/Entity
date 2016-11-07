Namespace _0App.InitialSetup
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IFm3Tips
        Inherits IFmBase



        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IFm3Tips))
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.content = New System.Windows.Forms.Panel()
            Me.lbTip2 = New System.Windows.Forms.Label()
            Me.pbTip2 = New System.Windows.Forms.PictureBox()
            Me.pbTip1 = New System.Windows.Forms.PictureBox()
            Me.lbTip1 = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.content.SuspendLayout()
            CType(Me.pbTip2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.pbTip1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tmrAnim
            '
            Me.tmrAnim.Enabled = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.ForeColor = System.Drawing.Color.White
            Me.lbTitle.Location = New System.Drawing.Point(120, 29)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(373, 30)
            Me.lbTitle.TabIndex = 45
            Me.lbTitle.Text = "Accessing Settings in the Entity System"
            '
            'content
            '
            Me.content.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.content.Controls.Add(Me.lbTip2)
            Me.content.Controls.Add(Me.pbTip2)
            Me.content.Controls.Add(Me.pbTip1)
            Me.content.Controls.Add(Me.lbTip1)
            Me.content.Controls.Add(Me.lbTitle)
            Me.content.Controls.Add(Me.btnOK)
            Me.content.Location = New System.Drawing.Point(195, 24)
            Me.content.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.content.Name = "content"
            Me.content.Size = New System.Drawing.Size(614, 620)
            Me.content.TabIndex = 53
            '
            'lbTip2
            '
            Me.lbTip2.AutoSize = True
            Me.lbTip2.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTip2.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbTip2.Location = New System.Drawing.Point(143, 496)
            Me.lbTip2.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTip2.Name = "lbTip2"
            Me.lbTip2.Size = New System.Drawing.Size(328, 60)
            Me.lbTip2.TabIndex = 57
            Me.lbTip2.Text = "To modify lighting settings, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "open any existing project or create a new project" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and click the Lights tab."
            Me.lbTip2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'pbTip2
            '
            Me.pbTip2.Image = CType(resources.GetObject("pbTip2.Image"), System.Drawing.Image)
            Me.pbTip2.Location = New System.Drawing.Point(32, 336)
            Me.pbTip2.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pbTip2.Name = "pbTip2"
            Me.pbTip2.Size = New System.Drawing.Size(550, 150)
            Me.pbTip2.TabIndex = 56
            Me.pbTip2.TabStop = False
            '
            'pbTip1
            '
            Me.pbTip1.Image = CType(resources.GetObject("pbTip1.Image"), System.Drawing.Image)
            Me.pbTip1.Location = New System.Drawing.Point(32, 80)
            Me.pbTip1.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pbTip1.Name = "pbTip1"
            Me.pbTip1.Size = New System.Drawing.Size(550, 150)
            Me.pbTip1.TabIndex = 55
            Me.pbTip1.TabStop = False
            '
            'lbTip1
            '
            Me.lbTip1.AutoSize = True
            Me.lbTip1.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTip1.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbTip1.Location = New System.Drawing.Point(135, 241)
            Me.lbTip1.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTip1.Name = "lbTip1"
            Me.lbTip1.Size = New System.Drawing.Size(344, 60)
            Me.lbTip1.TabIndex = 54
            Me.lbTip1.Text = "To edit projector settings or set passwords." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click the Settings and Global Resou" & _
        "rces button" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "on the top right of any major Entity System window."
            Me.lbTip1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.Gainsboro
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOK.ForeColor = System.Drawing.Color.Black
            Me.btnOK.Location = New System.Drawing.Point(452, 569)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(130, 40)
            Me.btnOK.TabIndex = 5
            Me.btnOK.TabStop = False
            Me.btnOK.Tag = ""
            Me.btnOK.Text = "Got It"
            Me.btnOK.UseVisualStyleBackColor = False
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
            Me.btnClose.TabIndex = 58
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'IFm3Tips
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1000, 663)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.content)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "IFm3Tips"
            Me.Opacity = 0.1R
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).EndInit()
            Me.content.ResumeLayout(False)
            Me.content.PerformLayout()
            CType(Me.pbTip2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.pbTip1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents content As System.Windows.Forms.Panel
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents lbTip1 As System.Windows.Forms.Label
        Friend WithEvents pbTip1 As System.Windows.Forms.PictureBox
        Friend WithEvents pbTip2 As System.Windows.Forms.PictureBox
        Friend WithEvents lbTip2 As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button

    End Class
End Namespace