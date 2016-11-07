Imports Entity._5Controls

Namespace _0App.SettingsViews
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Svw1Resources
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
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.btnNewFolder = New System.Windows.Forms.Button()
            Me.breadcrumbs = New System.Windows.Forms.Label()
            Me.backSplit = New System.Windows.Forms.SplitContainer()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.btnRename = New System.Windows.Forms.Button()
            Me.btnYoutube = New System.Windows.Forms.Button()
            Me.pnlButtons = New System.Windows.Forms.Panel()
            Me.btnDelete = New System.Windows.Forms.Button()
            CType(Me.backSplit, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.backSplit.Panel1.SuspendLayout()
            Me.backSplit.SuspendLayout()
            Me.pnlButtons.SuspendLayout()
            Me.SuspendLayout()
            '
            'imgLst
            '
            Me.imgLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
            Me.imgLst.ImageSize = New System.Drawing.Size(28, 28)
            Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
            '
            'btnAdd
            '
            Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAdd.BackColor = System.Drawing.Color.Gainsboro
            Me.btnAdd.FlatAppearance.BorderSize = 0
            Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAdd.ForeColor = System.Drawing.Color.Black
            Me.btnAdd.Location = New System.Drawing.Point(655, 5)
            Me.btnAdd.Margin = New System.Windows.Forms.Padding(0)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(130, 40)
            Me.btnAdd.TabIndex = 44
            Me.btnAdd.TabStop = False
            Me.btnAdd.Tag = "0"
            Me.btnAdd.Text = "&Add"
            Me.btnAdd.UseVisualStyleBackColor = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.ForeColor = System.Drawing.Color.Black
            Me.lbTitle.Location = New System.Drawing.Point(32, 19)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(152, 25)
            Me.lbTitle.TabIndex = 44
            Me.lbTitle.Text = "Global Resources"
            '
            'btnNewFolder
            '
            Me.btnNewFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnNewFolder.BackColor = System.Drawing.Color.Gainsboro
            Me.btnNewFolder.FlatAppearance.BorderSize = 0
            Me.btnNewFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNewFolder.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNewFolder.ForeColor = System.Drawing.Color.Black
            Me.btnNewFolder.Location = New System.Drawing.Point(520, 5)
            Me.btnNewFolder.Margin = New System.Windows.Forms.Padding(0)
            Me.btnNewFolder.Name = "btnNewFolder"
            Me.btnNewFolder.Size = New System.Drawing.Size(130, 40)
            Me.btnNewFolder.TabIndex = 43
            Me.btnNewFolder.TabStop = False
            Me.btnNewFolder.Tag = "0"
            Me.btnNewFolder.Text = "New &Folder"
            Me.btnNewFolder.UseVisualStyleBackColor = False
            '
            'breadcrumbs
            '
            Me.breadcrumbs.AutoSize = True
            Me.breadcrumbs.Font = New System.Drawing.Font("Segoe UI Semilight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.breadcrumbs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.breadcrumbs.Location = New System.Drawing.Point(34, 49)
            Me.breadcrumbs.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.breadcrumbs.Name = "breadcrumbs"
            Me.breadcrumbs.Size = New System.Drawing.Size(57, 17)
            Me.breadcrumbs.TabIndex = 45
            Me.breadcrumbs.Text = "Global >"
            '
            'backSplit
            '
            Me.backSplit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.backSplit.Location = New System.Drawing.Point(0, 80)
            Me.backSplit.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.backSplit.Name = "backSplit"
            Me.backSplit.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'backSplit.Panel1
            '
            Me.backSplit.Panel1.Controls.Add(Me.lv)
            Me.backSplit.Panel1.Padding = New System.Windows.Forms.Padding(35, 0, 0, 0)
            Me.backSplit.Panel1MinSize = 35
            '
            'backSplit.Panel2
            '
            Me.backSplit.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.backSplit.Panel2MinSize = 110
            Me.backSplit.Size = New System.Drawing.Size(1327, 572)
            Me.backSplit.SplitterDistance = 316
            Me.backSplit.SplitterWidth = 5
            Me.backSplit.TabIndex = 47
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.AllowDrop = True
            Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lv.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colType, Me.colSize})
            Me.lv.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lv.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            Me.lv.LabelEdit = True
            Me.lv.Location = New System.Drawing.Point(35, 0)
            Me.lv.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(1292, 316)
            Me.lv.SmallImageList = Me.imgLst
            Me.lv.TabIndex = 0
            Me.lv.TileSize = New System.Drawing.Size(446, 104)
            Me.lv.UseCompatibleStateImageBehavior = False
            Me.lv.View = System.Windows.Forms.View.Details
            '
            'colName
            '
            Me.colName.Text = "Name"
            '
            'colType
            '
            Me.colType.Text = "Type"
            '
            'colSize
            '
            Me.colSize.Text = "Size"
            '
            'btnRename
            '
            Me.btnRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRename.BackColor = System.Drawing.Color.Gainsboro
            Me.btnRename.FlatAppearance.BorderSize = 0
            Me.btnRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRename.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRename.ForeColor = System.Drawing.Color.Black
            Me.btnRename.Location = New System.Drawing.Point(790, 5)
            Me.btnRename.Margin = New System.Windows.Forms.Padding(0)
            Me.btnRename.Name = "btnRename"
            Me.btnRename.Size = New System.Drawing.Size(130, 40)
            Me.btnRename.TabIndex = 46
            Me.btnRename.TabStop = False
            Me.btnRename.Tag = "0"
            Me.btnRename.Text = "&Rename"
            Me.btnRename.UseVisualStyleBackColor = False
            '
            'btnYoutube
            '
            Me.btnYoutube.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnYoutube.BackColor = System.Drawing.Color.Gainsboro
            Me.btnYoutube.FlatAppearance.BorderSize = 0
            Me.btnYoutube.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnYoutube.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnYoutube.ForeColor = System.Drawing.Color.Black
            Me.btnYoutube.Location = New System.Drawing.Point(375, 5)
            Me.btnYoutube.Margin = New System.Windows.Forms.Padding(0)
            Me.btnYoutube.Name = "btnYoutube"
            Me.btnYoutube.Size = New System.Drawing.Size(130, 40)
            Me.btnYoutube.TabIndex = 42
            Me.btnYoutube.TabStop = False
            Me.btnYoutube.Tag = "0"
            Me.btnYoutube.Text = "&Youtube"
            Me.btnYoutube.UseVisualStyleBackColor = False
            '
            'pnlButtons
            '
            Me.pnlButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlButtons.AutoScroll = True
            Me.pnlButtons.Controls.Add(Me.btnYoutube)
            Me.pnlButtons.Controls.Add(Me.btnDelete)
            Me.pnlButtons.Controls.Add(Me.btnRename)
            Me.pnlButtons.Controls.Add(Me.btnAdd)
            Me.pnlButtons.Controls.Add(Me.btnNewFolder)
            Me.pnlButtons.Location = New System.Drawing.Point(262, 14)
            Me.pnlButtons.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pnlButtons.Name = "pnlButtons"
            Me.pnlButtons.Size = New System.Drawing.Size(1065, 52)
            Me.pnlButtons.TabIndex = 48
            '
            'btnDelete
            '
            Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnDelete.BackColor = System.Drawing.Color.Gainsboro
            Me.btnDelete.Enabled = False
            Me.btnDelete.FlatAppearance.BorderSize = 0
            Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDelete.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelete.ForeColor = System.Drawing.Color.Black
            Me.btnDelete.Location = New System.Drawing.Point(925, 5)
            Me.btnDelete.Margin = New System.Windows.Forms.Padding(0)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(130, 40)
            Me.btnDelete.TabIndex = 47
            Me.btnDelete.TabStop = False
            Me.btnDelete.Tag = "0"
            Me.btnDelete.Text = "&Delete"
            Me.btnDelete.UseVisualStyleBackColor = False
            '
            'Svw1Resources
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Controls.Add(Me.lbTitle)
            Me.Controls.Add(Me.breadcrumbs)
            Me.Controls.Add(Me.backSplit)
            Me.Controls.Add(Me.pnlButtons)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "Svw1Resources"
            Me.Size = New System.Drawing.Size(1327, 652)
            Me.backSplit.Panel1.ResumeLayout(False)
            CType(Me.backSplit, System.ComponentModel.ISupportInitialize).EndInit()
            Me.backSplit.ResumeLayout(False)
            Me.pnlButtons.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents imgLst As System.Windows.Forms.ImageList
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents btnNewFolder As System.Windows.Forms.Button
        Friend WithEvents breadcrumbs As System.Windows.Forms.Label
        Friend WithEvents backSplit As System.Windows.Forms.SplitContainer
        Friend WithEvents btnRename As System.Windows.Forms.Button
        Friend WithEvents btnYoutube As System.Windows.Forms.Button
        Friend WithEvents pnlButtons As System.Windows.Forms.Panel
        Friend WithEvents lv As Entity._5Controls.listViewX
        Friend WithEvents colName As System.Windows.Forms.ColumnHeader
        Friend WithEvents colType As System.Windows.Forms.ColumnHeader
        Friend WithEvents colSize As System.Windows.Forms.ColumnHeader
        Friend WithEvents btnDelete As System.Windows.Forms.Button

    End Class
End Namespace