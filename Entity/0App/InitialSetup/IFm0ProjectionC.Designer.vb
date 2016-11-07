Namespace _0App.InitialSetup
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IFm0ProjectionC
        Inherits IFmBase



        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IFm0ProjectionC))
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.btnClose = New System.Windows.Forms.Button()
            Me.pnlContent = New System.Windows.Forms.Panel()
            Me.pb = New System.Windows.Forms.PictureBox()
            Me.btnMan = New System.Windows.Forms.Button()
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.lbDesc = New System.Windows.Forms.Label()
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlContent.SuspendLayout()
            CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'imgLst
            '
            Me.imgLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
            Me.imgLst.ImageSize = New System.Drawing.Size(158, 100)
            Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
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
            Me.btnClose.TabIndex = 50
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'pnlContent
            '
            Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.pnlContent.Controls.Add(Me.pb)
            Me.pnlContent.Controls.Add(Me.btnMan)
            Me.pnlContent.Controls.Add(Me.lbTitle)
            Me.pnlContent.Controls.Add(Me.lbDesc)
            Me.pnlContent.Location = New System.Drawing.Point(215, 23)
            Me.pnlContent.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pnlContent.Name = "pnlContent"
            Me.pnlContent.Size = New System.Drawing.Size(625, 411)
            Me.pnlContent.TabIndex = 49
            '
            'pb
            '
            Me.pb.Image = CType(resources.GetObject("pb.Image"), System.Drawing.Image)
            Me.pb.Location = New System.Drawing.Point(272, 46)
            Me.pb.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pb.Name = "pb"
            Me.pb.Size = New System.Drawing.Size(80, 85)
            Me.pb.TabIndex = 48
            Me.pb.TabStop = False
            '
            'btnMan
            '
            Me.btnMan.BackColor = System.Drawing.Color.Gainsboro
            Me.btnMan.FlatAppearance.BorderSize = 0
            Me.btnMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMan.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMan.ForeColor = System.Drawing.Color.Black
            Me.btnMan.Location = New System.Drawing.Point(247, 320)
            Me.btnMan.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnMan.Name = "btnMan"
            Me.btnMan.Size = New System.Drawing.Size(131, 40)
            Me.btnMan.TabIndex = 41
            Me.btnMan.TabStop = False
            Me.btnMan.Tag = "0"
            Me.btnMan.Text = "&Manual Setup"
            Me.btnMan.UseVisualStyleBackColor = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.ForeColor = System.Drawing.Color.White
            Me.lbTitle.Location = New System.Drawing.Point(115, 151)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(395, 30)
            Me.lbTitle.TabIndex = 47
            Me.lbTitle.Text = "You don't have any projectors connected!"
            '
            'lbDesc
            '
            Me.lbDesc.AutoSize = True
            Me.lbDesc.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbDesc.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbDesc.Location = New System.Drawing.Point(103, 195)
            Me.lbDesc.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbDesc.Name = "lbDesc"
            Me.lbDesc.Size = New System.Drawing.Size(419, 100)
            Me.lbDesc.TabIndex = 46
            Me.lbDesc.Text = resources.GetString("lbDesc.Text")
            Me.lbDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'IFm0ProjectionC
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1000, 470)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.pnlContent)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "IFm0ProjectionC"
            Me.Opacity = 0.1R
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlContent.ResumeLayout(False)
            Me.pnlContent.PerformLayout()
            CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents imgLst As System.Windows.Forms.ImageList
        Friend WithEvents btnMan As System.Windows.Forms.Button
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents lbDesc As System.Windows.Forms.Label
        Friend WithEvents pb As System.Windows.Forms.PictureBox
        Friend WithEvents pnlContent As System.Windows.Forms.Panel
        Friend WithEvents btnClose As System.Windows.Forms.Button

    End Class
End Namespace