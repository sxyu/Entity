Imports Entity._5Controls

Namespace _0App.InitialSetup
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IFm0ProjectionA
        Inherits IFmBase



        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.content = New System.Windows.Forms.Panel()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colNM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColDes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.btnProjection = New System.Windows.Forms.Button()
            Me.lbDesc = New System.Windows.Forms.Label()
            Me.btnID = New System.Windows.Forms.Button()
            Me.btnMan = New System.Windows.Forms.Button()
            Me.content.SuspendLayout()
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
            'imgLst
            '
            Me.imgLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
            Me.imgLst.ImageSize = New System.Drawing.Size(158, 100)
            Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
            '
            'content
            '
            Me.content.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.content.Controls.Add(Me.lv)
            Me.content.Controls.Add(Me.lbTitle)
            Me.content.Controls.Add(Me.btnProjection)
            Me.content.Controls.Add(Me.lbDesc)
            Me.content.Controls.Add(Me.btnID)
            Me.content.Controls.Add(Me.btnMan)
            Me.content.Location = New System.Drawing.Point(215, 23)
            Me.content.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.content.Name = "content"
            Me.content.Size = New System.Drawing.Size(625, 411)
            Me.content.TabIndex = 52
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
            Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lv.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNM, Me.ColDes})
            Me.lv.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lv.ForeColor = System.Drawing.Color.White
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            Me.lv.LargeImageList = Me.imgLst
            Me.lv.Location = New System.Drawing.Point(16, 125)
            Me.lv.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(592, 229)
            Me.lv.TabIndex = 0
            Me.lv.TileSize = New System.Drawing.Size(446, 104)
            Me.lv.UseCompatibleStateImageBehavior = False
            '
            'colNM
            '
            Me.colNM.Text = "Name"
            '
            'ColDes
            '
            Me.ColDes.Text = "Description"
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.ForeColor = System.Drawing.Color.White
            Me.lbTitle.Location = New System.Drawing.Point(112, 17)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(401, 30)
            Me.lbTitle.TabIndex = 45
            Me.lbTitle.Text = "Which of these displays is your projector? "
            '
            'btnProjection
            '
            Me.btnProjection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnProjection.BackColor = System.Drawing.Color.Gainsboro
            Me.btnProjection.Enabled = False
            Me.btnProjection.FlatAppearance.BorderSize = 0
            Me.btnProjection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnProjection.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnProjection.ForeColor = System.Drawing.Color.Black
            Me.btnProjection.Location = New System.Drawing.Point(408, 363)
            Me.btnProjection.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnProjection.Name = "btnProjection"
            Me.btnProjection.Size = New System.Drawing.Size(200, 40)
            Me.btnProjection.TabIndex = 43
            Me.btnProjection.TabStop = False
            Me.btnProjection.Tag = "0"
            Me.btnProjection.Text = "This is My &Projector"
            Me.btnProjection.UseVisualStyleBackColor = False
            '
            'lbDesc
            '
            Me.lbDesc.AutoSize = True
            Me.lbDesc.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbDesc.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbDesc.Location = New System.Drawing.Point(89, 52)
            Me.lbDesc.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbDesc.Name = "lbDesc"
            Me.lbDesc.Size = New System.Drawing.Size(447, 60)
            Me.lbDesc.TabIndex = 44
            Me.lbDesc.Text = "Please select the one and click the bottom right button to continue." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you can'" & _
        "t connect to a projector right now, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "click the Manual Setup button to input req" & _
        "uired values by hand."
            Me.lbDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnID
            '
            Me.btnID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnID.BackColor = System.Drawing.Color.Gainsboro
            Me.btnID.FlatAppearance.BorderSize = 0
            Me.btnID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnID.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnID.ForeColor = System.Drawing.Color.Black
            Me.btnID.Location = New System.Drawing.Point(273, 363)
            Me.btnID.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnID.Name = "btnID"
            Me.btnID.Size = New System.Drawing.Size(130, 40)
            Me.btnID.TabIndex = 42
            Me.btnID.TabStop = False
            Me.btnID.Tag = "0"
            Me.btnID.Text = "&Identify"
            Me.btnID.UseVisualStyleBackColor = False
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
            Me.btnMan.TabIndex = 41
            Me.btnMan.TabStop = False
            Me.btnMan.Tag = "0"
            Me.btnMan.Text = "&Manual Setup"
            Me.btnMan.UseVisualStyleBackColor = False
            '
            'IFm0ProjectionA
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
            Me.Name = "IFm0ProjectionA"
            Me.Opacity = 0.1R
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.content.ResumeLayout(False)
            Me.content.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents imgLst As System.Windows.Forms.ImageList
        Friend WithEvents content As System.Windows.Forms.Panel
        Friend WithEvents lv As Entity._5Controls.listViewX
        Friend WithEvents colNM As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColDes As System.Windows.Forms.ColumnHeader
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents btnProjection As System.Windows.Forms.Button
        Friend WithEvents lbDesc As System.Windows.Forms.Label
        Friend WithEvents btnID As System.Windows.Forms.Button
        Friend WithEvents btnMan As System.Windows.Forms.Button

    End Class
End Namespace