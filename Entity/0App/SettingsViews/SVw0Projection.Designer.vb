Imports Entity._5Controls

Namespace _0App.SettingsViews
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Svw0Projection
        Inherits System.Windows.Forms.UserControl



        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.btnProjection = New System.Windows.Forms.Button()
            Me.btnID = New System.Windows.Forms.Button()
            Me.btnMan = New System.Windows.Forms.Button()
            Me.pnlMan = New System.Windows.Forms.Panel()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.numRezVert = New System.Windows.Forms.NumericUpDown()
            Me.numRezHoriz = New System.Windows.Forms.NumericUpDown()
            Me.lbX = New System.Windows.Forms.Label()
            Me.lbRes = New System.Windows.Forms.Label()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colNM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ColDes = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.pnlMan.SuspendLayout()
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
            'btnProjection
            '
            Me.btnProjection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnProjection.BackColor = System.Drawing.Color.Gainsboro
            Me.btnProjection.Enabled = False
            Me.btnProjection.FlatAppearance.BorderSize = 0
            Me.btnProjection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnProjection.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnProjection.ForeColor = System.Drawing.Color.Black
            Me.btnProjection.Location = New System.Drawing.Point(1137, 12)
            Me.btnProjection.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnProjection.Name = "btnProjection"
            Me.btnProjection.Size = New System.Drawing.Size(170, 40)
            Me.btnProjection.TabIndex = 43
            Me.btnProjection.TabStop = False
            Me.btnProjection.Tag = "0"
            Me.btnProjection.Text = "Set &Default Projector"
            Me.btnProjection.UseVisualStyleBackColor = False
            '
            'btnID
            '
            Me.btnID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnID.BackColor = System.Drawing.Color.Gainsboro
            Me.btnID.FlatAppearance.BorderSize = 0
            Me.btnID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnID.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnID.ForeColor = System.Drawing.Color.Black
            Me.btnID.Location = New System.Drawing.Point(1002, 12)
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
            Me.btnMan.BackColor = System.Drawing.Color.Gainsboro
            Me.btnMan.FlatAppearance.BorderSize = 0
            Me.btnMan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMan.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMan.ForeColor = System.Drawing.Color.Black
            Me.btnMan.Location = New System.Drawing.Point(16, 12)
            Me.btnMan.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnMan.Name = "btnMan"
            Me.btnMan.Size = New System.Drawing.Size(130, 40)
            Me.btnMan.TabIndex = 41
            Me.btnMan.TabStop = False
            Me.btnMan.Tag = "0"
            Me.btnMan.Text = "&Manual Setup"
            Me.btnMan.UseVisualStyleBackColor = False
            '
            'pnlMan
            '
            Me.pnlMan.Controls.Add(Me.btnSave)
            Me.pnlMan.Controls.Add(Me.numRezVert)
            Me.pnlMan.Controls.Add(Me.numRezHoriz)
            Me.pnlMan.Controls.Add(Me.lbX)
            Me.pnlMan.Controls.Add(Me.lbRes)
            Me.pnlMan.Location = New System.Drawing.Point(16, 80)
            Me.pnlMan.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pnlMan.Name = "pnlMan"
            Me.pnlMan.Size = New System.Drawing.Size(257, 185)
            Me.pnlMan.TabIndex = 44
            Me.pnlMan.Visible = False
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.Gainsboro
            Me.btnSave.FlatAppearance.BorderSize = 0
            Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.Black
            Me.btnSave.Location = New System.Drawing.Point(111, 124)
            Me.btnSave.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(130, 40)
            Me.btnSave.TabIndex = 45
            Me.btnSave.TabStop = False
            Me.btnSave.Tag = "0"
            Me.btnSave.Text = "&Save"
            Me.btnSave.UseVisualStyleBackColor = False
            '
            'numRezVert
            '
            Me.numRezVert.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.numRezVert.Location = New System.Drawing.Point(141, 62)
            Me.numRezVert.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.numRezVert.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
            Me.numRezVert.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
            Me.numRezVert.Name = "numRezVert"
            Me.numRezVert.Size = New System.Drawing.Size(100, 29)
            Me.numRezVert.TabIndex = 5
            Me.numRezVert.Value = New Decimal(New Integer() {100, 0, 0, 0})
            '
            'numRezHoriz
            '
            Me.numRezHoriz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.numRezHoriz.Location = New System.Drawing.Point(16, 62)
            Me.numRezHoriz.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.numRezHoriz.Maximum = New Decimal(New Integer() {3200, 0, 0, 0})
            Me.numRezHoriz.Minimum = New Decimal(New Integer() {120, 0, 0, 0})
            Me.numRezHoriz.Name = "numRezHoriz"
            Me.numRezHoriz.Size = New System.Drawing.Size(100, 29)
            Me.numRezHoriz.TabIndex = 4
            Me.numRezHoriz.Value = New Decimal(New Integer() {120, 0, 0, 0})
            '
            'lbX
            '
            Me.lbX.AutoSize = True
            Me.lbX.ForeColor = System.Drawing.Color.Black
            Me.lbX.Location = New System.Drawing.Point(120, 64)
            Me.lbX.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbX.Name = "lbX"
            Me.lbX.Size = New System.Drawing.Size(17, 21)
            Me.lbX.TabIndex = 3
            Me.lbX.Text = "x"
            '
            'lbRes
            '
            Me.lbRes.AutoSize = True
            Me.lbRes.ForeColor = System.Drawing.Color.Black
            Me.lbRes.Location = New System.Drawing.Point(12, 11)
            Me.lbRes.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbRes.Name = "lbRes"
            Me.lbRes.Size = New System.Drawing.Size(156, 21)
            Me.lbRes.TabIndex = 1
            Me.lbRes.Text = "Projector Resolution: "
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lv.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNM, Me.ColDes})
            Me.lv.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lv.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            Me.lv.LargeImageList = Me.imgLst
            Me.lv.Location = New System.Drawing.Point(16, 79)
            Me.lv.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(1291, 558)
            Me.lv.TabIndex = 0
            Me.lv.TileSize = New System.Drawing.Size(446, 104)
            Me.lv.UseCompatibleStateImageBehavior = False
            Me.lv.View = System.Windows.Forms.View.Tile
            '
            'colNM
            '
            Me.colNM.Text = "Name"
            '
            'ColDes
            '
            Me.ColDes.Text = "Description"
            '
            'Svw0Projection
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Controls.Add(Me.pnlMan)
            Me.Controls.Add(Me.lv)
            Me.Controls.Add(Me.btnMan)
            Me.Controls.Add(Me.btnProjection)
            Me.Controls.Add(Me.btnID)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "Svw0Projection"
            Me.Size = New System.Drawing.Size(1327, 652)
            Me.pnlMan.ResumeLayout(False)
            Me.pnlMan.PerformLayout()
            CType(Me.numRezVert, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numRezHoriz, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents imgLst As System.Windows.Forms.ImageList
        Friend WithEvents btnProjection As System.Windows.Forms.Button
        Friend WithEvents btnID As System.Windows.Forms.Button
        Friend WithEvents btnMan As System.Windows.Forms.Button
        Friend WithEvents pnlMan As System.Windows.Forms.Panel
        Friend WithEvents lbX As System.Windows.Forms.Label
        Friend WithEvents lbRes As System.Windows.Forms.Label
        Friend WithEvents numRezVert As System.Windows.Forms.NumericUpDown
        Friend WithEvents numRezHoriz As System.Windows.Forms.NumericUpDown
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents lv As listViewX
        Friend WithEvents colNM As System.Windows.Forms.ColumnHeader
        Friend WithEvents ColDes As System.Windows.Forms.ColumnHeader

    End Class
End NameSpace