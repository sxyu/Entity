Imports Entity._5Controls

Namespace _0App.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Vw1Light
        Inherits System.Windows.Forms.UserControl

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Vw1Light))
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.btnDel = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.sideBar = New System.Windows.Forms.Panel()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.btnLightingBD = New System.Windows.Forms.Button()
            Me.btnQuickSetup = New System.Windows.Forms.Button()
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.editor = New System.Windows.Forms.Panel()
            Me.btnEdit = New System.Windows.Forms.Button()
            Me.lbName = New System.Windows.Forms.Label()
            Me.visual = New System.Windows.Forms.PictureBox()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.channelsEditor = New System.Windows.Forms.Panel()
            Me.btnFlashAll = New System.Windows.Forms.Button()
            Me.lbCh = New System.Windows.Forms.Label()
            Me.channelsView = New Entity._5Controls.listViewX()
            Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colChnlName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.pnlOpts = New System.Windows.Forms.Panel()
            Me.lbChTag = New System.Windows.Forms.Label()
            Me.lbChID = New System.Windows.Forms.Label()
            Me.btnAddCh = New System.Windows.Forms.Button()
            Me.btnRemCh = New System.Windows.Forms.Button()
            Me.cmbChTag = New System.Windows.Forms.ComboBox()
            Me.numChID = New System.Windows.Forms.NumericUpDown()
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
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
            'btnDel
            '
            Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnDel.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnDel.Enabled = False
            Me.btnDel.FlatAppearance.BorderSize = 0
            Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDel.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDel.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnDel.Location = New System.Drawing.Point(166, 585)
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
            Me.btnAdd.Location = New System.Drawing.Point(22, 585)
            Me.btnAdd.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(130, 40)
            Me.btnAdd.TabIndex = 3
            Me.btnAdd.Text = "Add"
            Me.btnAdd.UseVisualStyleBackColor = False
            '
            'sideBar
            '
            Me.sideBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.sideBar.AutoScroll = True
            Me.sideBar.BackColor = System.Drawing.Color.Gainsboro
            Me.sideBar.Controls.Add(Me.lv)
            Me.sideBar.Controls.Add(Me.btnLightingBD)
            Me.sideBar.Controls.Add(Me.btnQuickSetup)
            Me.sideBar.Controls.Add(Me.btnDel)
            Me.sideBar.Controls.Add(Me.btnAdd)
            Me.sideBar.Location = New System.Drawing.Point(27, 39)
            Me.sideBar.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.sideBar.Name = "sideBar"
            Me.sideBar.Size = New System.Drawing.Size(311, 637)
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
            Me.lv.Location = New System.Drawing.Point(22, 61)
            Me.lv.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(274, 511)
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
            'btnLightingBD
            '
            Me.btnLightingBD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnLightingBD.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnLightingBD.FlatAppearance.BorderSize = 0
            Me.btnLightingBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLightingBD.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLightingBD.ForeColor = System.Drawing.Color.White
            Me.btnLightingBD.Location = New System.Drawing.Point(166, 13)
            Me.btnLightingBD.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnLightingBD.Name = "btnLightingBD"
            Me.btnLightingBD.Size = New System.Drawing.Size(130, 40)
            Me.btnLightingBD.TabIndex = 2
            Me.btnLightingBD.Text = "Lighting Brd"
            Me.btnLightingBD.UseVisualStyleBackColor = False
            '
            'btnQuickSetup
            '
            Me.btnQuickSetup.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnQuickSetup.FlatAppearance.BorderSize = 0
            Me.btnQuickSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnQuickSetup.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnQuickSetup.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnQuickSetup.Location = New System.Drawing.Point(22, 13)
            Me.btnQuickSetup.Margin = New System.Windows.Forms.Padding(0, 24, 60, 24)
            Me.btnQuickSetup.Name = "btnQuickSetup"
            Me.btnQuickSetup.Size = New System.Drawing.Size(130, 40)
            Me.btnQuickSetup.TabIndex = 1
            Me.btnQuickSetup.Text = "Express Setup"
            Me.btnQuickSetup.UseVisualStyleBackColor = False
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
            Me.editor.Location = New System.Drawing.Point(353, 39)
            Me.editor.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.editor.Name = "editor"
            Me.editor.Size = New System.Drawing.Size(727, 637)
            Me.editor.TabIndex = 1
            Me.editor.Visible = False
            '
            'btnEdit
            '
            Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
            Me.btnEdit.FlatAppearance.BorderSize = 0
            Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEdit.Font = New System.Drawing.Font("Segoe UI Light", 11.25!)
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
            'lbName
            '
            Me.lbName.AutoSize = True
            Me.lbName.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
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
            'lbWarning
            '
            Me.lbWarning.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
            Me.lbWarning.ForeColor = System.Drawing.Color.White
            Me.lbWarning.Location = New System.Drawing.Point(29, 38)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(527, 28)
            Me.lbWarning.TabIndex = 4
            Me.lbWarning.Text = "Warning"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWarning.Visible = False
            '
            'channelsEditor
            '
            Me.channelsEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.channelsEditor.Controls.Add(Me.btnFlashAll)
            Me.channelsEditor.Controls.Add(Me.lbCh)
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
            Me.btnFlashAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
            Me.btnFlashAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnFlashAll.Font = New System.Drawing.Font("Segoe UI Semilight", 10.0!)
            Me.btnFlashAll.ForeColor = System.Drawing.Color.White
            Me.btnFlashAll.Location = New System.Drawing.Point(455, 9)
            Me.btnFlashAll.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnFlashAll.Name = "btnFlashAll"
            Me.btnFlashAll.Size = New System.Drawing.Size(89, 36)
            Me.btnFlashAll.TabIndex = 24
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
            Me.pnlOpts.Controls.Add(Me.btnAddCh)
            Me.pnlOpts.Controls.Add(Me.btnRemCh)
            Me.pnlOpts.Controls.Add(Me.cmbChTag)
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
            'btnAddCh
            '
            Me.btnAddCh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAddCh.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnAddCh.FlatAppearance.BorderSize = 0
            Me.btnAddCh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
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
            Me.btnRemCh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
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
            'Vw1Light
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Controls.Add(Me.sideBar)
            Me.Controls.Add(Me.editor)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.Name = "Vw1Light"
            Me.Size = New System.Drawing.Size(1100, 700)
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
        Friend WithEvents channelsEditor As System.Windows.Forms.Panel
        Friend WithEvents colID As System.Windows.Forms.ColumnHeader
        Friend WithEvents colChnlName As System.Windows.Forms.ColumnHeader
        Friend WithEvents btnQuickSetup As System.Windows.Forms.Button
        Friend WithEvents cmbChTag As System.Windows.Forms.ComboBox
        Friend WithEvents btnRemCh As System.Windows.Forms.Button
        Friend WithEvents btnAddCh As System.Windows.Forms.Button
        Friend WithEvents lbCh As System.Windows.Forms.Label
        Friend WithEvents numChID As System.Windows.Forms.NumericUpDown
        Friend WithEvents lbChTag As System.Windows.Forms.Label
        Friend WithEvents lbChID As System.Windows.Forms.Label
        Friend WithEvents btnLightingBD As System.Windows.Forms.Button
        Friend WithEvents lv As listViewX
        Friend WithEvents colName As System.Windows.Forms.ColumnHeader
        Friend WithEvents channelsView As listViewX
        Friend WithEvents pnlOpts As System.Windows.Forms.Panel
        Friend WithEvents tt As System.Windows.Forms.ToolTip
        Friend WithEvents btnFlashAll As System.Windows.Forms.Button

    End Class
End Namespace