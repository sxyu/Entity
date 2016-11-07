Imports Entity._5Controls

Namespace _0App.InitialSetup
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IFm1LightN
        Inherits IFmBase

        'UserControl overrides dispose to clean up the component list.
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IFm1LightN))
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
            Me.btnEdit = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.lbTitile = New System.Windows.Forms.Label()
            Me.lbDesc = New System.Windows.Forms.Label()
            Me.btnPrev = New System.Windows.Forms.Button()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.sideBar = New System.Windows.Forms.Panel()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.btnDel = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.editor = New System.Windows.Forms.Panel()
            Me.lbName = New System.Windows.Forms.Label()
            Me.visual = New System.Windows.Forms.PictureBox()
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.channelsEditor = New System.Windows.Forms.Panel()
            Me.btnFlashAll = New System.Windows.Forms.Button()
            Me.lbCh = New System.Windows.Forms.Label()
            Me.footer = New System.Windows.Forms.Panel()
            Me.channelsView = New Entity._5Controls.listViewX()
            Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colChnlName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.pnlOpts = New System.Windows.Forms.Panel()
            Me.lbChTag = New System.Windows.Forms.Label()
            Me.lbChID = New System.Windows.Forms.Label()
            Me.cmbChTag = New System.Windows.Forms.ComboBox()
            Me.btnAddCh = New System.Windows.Forms.Button()
            Me.btnRemCh = New System.Windows.Forms.Button()
            Me.numChID = New System.Windows.Forms.NumericUpDown()
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.sideBar.SuspendLayout()
            Me.editor.SuspendLayout()
            CType(Me.visual, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.channelsEditor.SuspendLayout()
            Me.pnlOpts.SuspendLayout()
            CType(Me.numChID, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'imgLst
            '
            Me.imgLst.ImageStream = CType(resources.GetObject("imgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
            Me.imgLst.Images.SetKeyName(0, "Package.ico")
            Me.imgLst.Images.SetKeyName(1, "Stock.ico")
            '
            'btnEdit
            '
            Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
            Me.btnEdit.FlatAppearance.BorderSize = 0
            Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnEdit.Image = Global.Entity.My.Resources.Resources.EditBtn
            Me.btnEdit.Location = New System.Drawing.Point(556, 10)
            Me.btnEdit.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnEdit.Name = "btnEdit"
            Me.btnEdit.Size = New System.Drawing.Size(27, 26)
            Me.btnEdit.TabIndex = 0
            Me.tt.SetToolTip(Me.btnEdit, "When not editing: (Color.fromArgb(100, 100, 100))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click to edit the name of this" & _
            " light." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "When editing: (Red)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Left click to confirm edit, or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "right click to c" & _
            "ancel.")
            Me.btnEdit.UseVisualStyleBackColor = False
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
            Me.btnClose.Location = New System.Drawing.Point(1062, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(72, 29, 72, 29)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 6
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'lbTitile
            '
            Me.lbTitile.AutoSize = True
            Me.lbTitile.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitile.ForeColor = System.Drawing.Color.White
            Me.lbTitile.Location = New System.Drawing.Point(59, 20)
            Me.lbTitile.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbTitile.Name = "lbTitile"
            Me.lbTitile.Size = New System.Drawing.Size(244, 30)
            Me.lbTitile.TabIndex = 4
            Me.lbTitile.Text = "Advanced Lighting Setup"
            '
            'lbDesc
            '
            Me.lbDesc.AutoSize = True
            Me.lbDesc.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbDesc.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbDesc.Location = New System.Drawing.Point(60, 59)
            Me.lbDesc.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbDesc.Name = "lbDesc"
            Me.lbDesc.Size = New System.Drawing.Size(413, 100)
            Me.lbDesc.TabIndex = 5
            Me.lbDesc.Text = "You can rename, visually position, and test your lights here." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can even add/r" & _
        "emove lights if you need to." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "When you are done with editing and repositioning" & _
        " your lights, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "click Next to continue."
            '
            'btnPrev
            '
            Me.btnPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPrev.BackColor = System.Drawing.Color.Gainsboro
            Me.btnPrev.FlatAppearance.BorderSize = 0
            Me.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPrev.ForeColor = System.Drawing.Color.Black
            Me.btnPrev.Location = New System.Drawing.Point(773, 647)
            Me.btnPrev.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.btnPrev.Name = "btnPrev"
            Me.btnPrev.Size = New System.Drawing.Size(130, 40)
            Me.btnPrev.TabIndex = 2
            Me.btnPrev.Text = "&Previous"
            Me.btnPrev.UseVisualStyleBackColor = False
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.BackColor = System.Drawing.Color.Gainsboro
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.ForeColor = System.Drawing.Color.Black
            Me.btnOK.Location = New System.Drawing.Point(908, 647)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(130, 40)
            Me.btnOK.TabIndex = 3
            Me.btnOK.Text = "&Next"
            Me.btnOK.UseVisualStyleBackColor = False
            '
            'sideBar
            '
            Me.sideBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.sideBar.AutoScroll = True
            Me.sideBar.BackColor = System.Drawing.Color.Gainsboro
            Me.sideBar.Controls.Add(Me.lv)
            Me.sideBar.Controls.Add(Me.btnDel)
            Me.sideBar.Controls.Add(Me.btnAdd)
            Me.sideBar.Location = New System.Drawing.Point(64, 183)
            Me.sideBar.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.sideBar.Name = "sideBar"
            Me.sideBar.Size = New System.Drawing.Size(311, 455)
            Me.sideBar.TabIndex = 0
            '
            'lv
            '
            Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lv.BackColor = System.Drawing.Color.Gainsboro
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName})
            Me.lv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            Me.lv.Location = New System.Drawing.Point(22, 15)
            Me.lv.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(274, 371)
            Me.lv.SmallImageList = Me.imgLst
            Me.lv.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lv.TabIndex = 0
            Me.lv.UseCompatibleStateImageBehavior = False
            Me.lv.View = System.Windows.Forms.View.Details
            '
            'colName
            '
            Me.colName.Text = "Name"
            '
            'btnDel
            '
            Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnDel.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnDel.Enabled = False
            Me.btnDel.FlatAppearance.BorderSize = 0
            Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDel.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDel.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnDel.Location = New System.Drawing.Point(166, 402)
            Me.btnDel.Margin = New System.Windows.Forms.Padding(0, 24, 60, 24)
            Me.btnDel.Name = "btnDel"
            Me.btnDel.Size = New System.Drawing.Size(130, 40)
            Me.btnDel.TabIndex = 4
            Me.btnDel.Text = "Delete"
            Me.btnDel.UseVisualStyleBackColor = False
            '
            'btnAdd
            '
            Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnAdd.FlatAppearance.BorderSize = 0
            Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnAdd.Location = New System.Drawing.Point(22, 402)
            Me.btnAdd.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(130, 40)
            Me.btnAdd.TabIndex = 3
            Me.btnAdd.Text = "Add"
            Me.btnAdd.UseVisualStyleBackColor = False
            '
            'editor
            '
            Me.editor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.editor.AutoScroll = True
            Me.editor.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
            Me.editor.Controls.Add(Me.btnEdit)
            Me.editor.Controls.Add(Me.lbName)
            Me.editor.Controls.Add(Me.visual)
            Me.editor.Controls.Add(Me.tbName)
            Me.editor.Controls.Add(Me.lbWarning)
            Me.editor.Controls.Add(Me.channelsEditor)
            Me.editor.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.editor.Location = New System.Drawing.Point(386, 183)
            Me.editor.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.editor.Name = "editor"
            Me.editor.Size = New System.Drawing.Size(652, 455)
            Me.editor.TabIndex = 1
            Me.editor.Visible = False
            '
            'lbName
            '
            Me.lbName.AutoSize = True
            Me.lbName.BackColor = System.Drawing.Color.Transparent
            Me.lbName.ForeColor = System.Drawing.Color.White
            Me.lbName.Location = New System.Drawing.Point(29, 12)
            Me.lbName.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbName.Name = "lbName"
            Me.lbName.Size = New System.Drawing.Size(50, 20)
            Me.lbName.TabIndex = 3
            Me.lbName.Text = "Label1"
            '
            'visual
            '
            Me.visual.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.visual.Location = New System.Drawing.Point(29, 65)
            Me.visual.Margin = New System.Windows.Forms.Padding(36, 14, 36, 0)
            Me.visual.Name = "visual"
            Me.visual.Size = New System.Drawing.Size(554, 186)
            Me.visual.TabIndex = 22
            Me.visual.TabStop = False
            '
            'tbName
            '
            Me.tbName.Location = New System.Drawing.Point(29, 9)
            Me.tbName.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.tbName.MaxLength = 20
            Me.tbName.Name = "tbName"
            Me.tbName.Size = New System.Drawing.Size(527, 27)
            Me.tbName.TabIndex = 2
            Me.tbName.Visible = False
            '
            'lbWarning
            '
            Me.lbWarning.BackColor = System.Drawing.Color.Transparent
            Me.lbWarning.ForeColor = System.Drawing.Color.White
            Me.lbWarning.Location = New System.Drawing.Point(29, 35)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(527, 28)
            Me.lbWarning.TabIndex = 4
            Me.lbWarning.Text = "Label1"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWarning.Visible = False
            '
            'channelsEditor
            '
            Me.channelsEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.channelsEditor.Controls.Add(Me.btnFlashAll)
            Me.channelsEditor.Controls.Add(Me.lbCh)
            Me.channelsEditor.Controls.Add(Me.footer)
            Me.channelsEditor.Controls.Add(Me.channelsView)
            Me.channelsEditor.Controls.Add(Me.pnlOpts)
            Me.channelsEditor.Location = New System.Drawing.Point(29, 259)
            Me.channelsEditor.Margin = New System.Windows.Forms.Padding(36, 0, 36, 14)
            Me.channelsEditor.Name = "channelsEditor"
            Me.channelsEditor.Size = New System.Drawing.Size(554, 180)
            Me.channelsEditor.TabIndex = 0
            '
            'btnFlashAll
            '
            Me.btnFlashAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnFlashAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnFlashAll.FlatAppearance.BorderSize = 0
            Me.btnFlashAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnFlashAll.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFlashAll.ForeColor = System.Drawing.Color.White
            Me.btnFlashAll.Location = New System.Drawing.Point(455, 9)
            Me.btnFlashAll.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnFlashAll.Name = "btnFlashAll"
            Me.btnFlashAll.Size = New System.Drawing.Size(89, 36)
            Me.btnFlashAll.TabIndex = 25
            Me.btnFlashAll.Text = "Flash All"
            Me.btnFlashAll.UseVisualStyleBackColor = False
            '
            'lbCh
            '
            Me.lbCh.AutoSize = True
            Me.lbCh.Location = New System.Drawing.Point(25, 18)
            Me.lbCh.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbCh.Name = "lbCh"
            Me.lbCh.Size = New System.Drawing.Size(411, 20)
            Me.lbCh.TabIndex = 1
            Me.lbCh.Text = "Assigned Channels (Check the box beside a channel to flash it)"
            '
            'footer
            '
            Me.footer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.footer.Location = New System.Drawing.Point(36, 1075)
            Me.footer.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.footer.Name = "footer"
            Me.footer.Size = New System.Drawing.Size(554, 101)
            Me.footer.TabIndex = 23
            '
            'channelsView
            '
            Me.channelsView.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.channelsView.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
            Me.channelsView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.channelsView.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.channelsView.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.channelsView.CheckBoxes = True
            Me.channelsView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colChnlName})
            Me.channelsView.ForeColor = System.Drawing.Color.White
            Me.channelsView.FullRowSelect = True
            Me.channelsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.channelsView.HideSelection = False
            Me.channelsView.Location = New System.Drawing.Point(29, 52)
            Me.channelsView.Margin = New System.Windows.Forms.Padding(36, 14, 36, 0)
            Me.channelsView.Name = "channelsView"
            Me.channelsView.Size = New System.Drawing.Size(507, 79)
            Me.channelsView.SmallImageList = Me.imgLst
            Me.channelsView.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.channelsView.TabIndex = 0
            Me.channelsView.UseCompatibleStateImageBehavior = False
            Me.channelsView.View = System.Windows.Forms.View.Details
            '
            'colID
            '
            Me.colID.Text = "ID"
            Me.colID.Width = 89
            '
            'colChnlName
            '
            Me.colChnlName.Text = "Name"
            Me.colChnlName.Width = 120
            '
            'pnlOpts
            '
            Me.pnlOpts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlOpts.AutoScroll = True
            Me.pnlOpts.Controls.Add(Me.lbChTag)
            Me.pnlOpts.Controls.Add(Me.lbChID)
            Me.pnlOpts.Controls.Add(Me.cmbChTag)
            Me.pnlOpts.Controls.Add(Me.btnAddCh)
            Me.pnlOpts.Controls.Add(Me.btnRemCh)
            Me.pnlOpts.Controls.Add(Me.numChID)
            Me.pnlOpts.Location = New System.Drawing.Point(0, 135)
            Me.pnlOpts.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.pnlOpts.Name = "pnlOpts"
            Me.pnlOpts.Size = New System.Drawing.Size(554, 45)
            Me.pnlOpts.TabIndex = 1
            '
            'lbChTag
            '
            Me.lbChTag.AutoSize = True
            Me.lbChTag.Location = New System.Drawing.Point(181, 12)
            Me.lbChTag.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbChTag.Name = "lbChTag"
            Me.lbChTag.Size = New System.Drawing.Size(32, 20)
            Me.lbChTag.TabIndex = 1
            Me.lbChTag.Text = "Tag"
            Me.lbChTag.Visible = False
            '
            'lbChID
            '
            Me.lbChID.AutoSize = True
            Me.lbChID.Location = New System.Drawing.Point(25, 12)
            Me.lbChID.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbChID.Name = "lbChID"
            Me.lbChID.Size = New System.Drawing.Size(61, 20)
            Me.lbChID.TabIndex = 26
            Me.lbChID.Text = "Channel"
            Me.lbChID.Visible = False
            '
            'cmbChTag
            '
            Me.cmbChTag.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbChTag.FormattingEnabled = True
            Me.cmbChTag.Items.AddRange(New Object() {"Main", "Fader", "Cyan", "Magenta", "Yellow", "Color", "Pan", "Tilt", "Fine Pan", "Fine Tilt", "Shutter", "Patching", "Other"})
            Me.cmbChTag.Location = New System.Drawing.Point(220, 8)
            Me.cmbChTag.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.cmbChTag.Name = "cmbChTag"
            Me.cmbChTag.Size = New System.Drawing.Size(103, 29)
            Me.cmbChTag.TabIndex = 8
            Me.cmbChTag.Visible = False
            '
            'btnAddCh
            '
            Me.btnAddCh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAddCh.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnAddCh.FlatAppearance.BorderSize = 0
            Me.btnAddCh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddCh.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddCh.ForeColor = System.Drawing.Color.White
            Me.btnAddCh.Location = New System.Drawing.Point(339, 5)
            Me.btnAddCh.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnAddCh.Name = "btnAddCh"
            Me.btnAddCh.Size = New System.Drawing.Size(100, 35)
            Me.btnAddCh.TabIndex = 2
            Me.btnAddCh.Text = "Add"
            Me.btnAddCh.UseVisualStyleBackColor = False
            '
            'btnRemCh
            '
            Me.btnRemCh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRemCh.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnRemCh.Enabled = False
            Me.btnRemCh.FlatAppearance.BorderSize = 0
            Me.btnRemCh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRemCh.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemCh.ForeColor = System.Drawing.Color.White
            Me.btnRemCh.Location = New System.Drawing.Point(444, 5)
            Me.btnRemCh.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnRemCh.Name = "btnRemCh"
            Me.btnRemCh.Size = New System.Drawing.Size(100, 35)
            Me.btnRemCh.TabIndex = 3
            Me.btnRemCh.Text = "Remove"
            Me.btnRemCh.UseVisualStyleBackColor = False
            '
            'numChID
            '
            Me.numChID.Location = New System.Drawing.Point(93, 10)
            Me.numChID.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.numChID.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
            Me.numChID.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numChID.Name = "numChID"
            Me.numChID.Size = New System.Drawing.Size(81, 27)
            Me.numChID.TabIndex = 0
            Me.numChID.Value = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numChID.Visible = False
            '
            'IFm1LightN
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1099, 700)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.lbTitile)
            Me.Controls.Add(Me.lbDesc)
            Me.Controls.Add(Me.btnPrev)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.sideBar)
            Me.Controls.Add(Me.editor)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.Name = "IFm1LightN"
            Me.Opacity = 0.1R
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).EndInit()
            Me.sideBar.ResumeLayout(False)
            Me.editor.ResumeLayout(False)
            Me.editor.PerformLayout()
            CType(Me.visual, System.ComponentModel.ISupportInitialize).EndInit()
            Me.channelsEditor.ResumeLayout(False)
            Me.channelsEditor.PerformLayout()
            Me.pnlOpts.ResumeLayout(False)
            Me.pnlOpts.PerformLayout()
            CType(Me.numChID, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnDel As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents imgLst As System.Windows.Forms.ImageList
        Friend WithEvents sideBar As System.Windows.Forms.Panel
        Friend WithEvents tbName As System.Windows.Forms.TextBox
        Friend WithEvents editor As System.Windows.Forms.Panel
        Friend WithEvents lbName As System.Windows.Forms.Label
        Friend WithEvents btnEdit As System.Windows.Forms.Button
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents visual As System.Windows.Forms.PictureBox
        Friend WithEvents footer As System.Windows.Forms.Panel
        Friend WithEvents channelsEditor As System.Windows.Forms.Panel
        Friend WithEvents colID As System.Windows.Forms.ColumnHeader
        Friend WithEvents colChnlName As System.Windows.Forms.ColumnHeader
        Friend WithEvents cmbChTag As System.Windows.Forms.ComboBox
        Friend WithEvents btnRemCh As System.Windows.Forms.Button
        Friend WithEvents btnAddCh As System.Windows.Forms.Button
        Friend WithEvents lbCh As System.Windows.Forms.Label
        Friend WithEvents numChID As System.Windows.Forms.NumericUpDown
        Friend WithEvents lbChTag As System.Windows.Forms.Label
        Friend WithEvents lbChID As System.Windows.Forms.Label
        Friend WithEvents lv As listViewX
        Friend WithEvents colName As System.Windows.Forms.ColumnHeader
        Friend WithEvents channelsView As listViewX
        Friend WithEvents pnlOpts As System.Windows.Forms.Panel
        Friend WithEvents tt As System.Windows.Forms.ToolTip
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnPrev As System.Windows.Forms.Button
        Friend WithEvents lbTitile As System.Windows.Forms.Label
        Friend WithEvents lbDesc As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents btnFlashAll As System.Windows.Forms.Button

    End Class
End Namespace