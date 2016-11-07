Imports Entity._5Controls

Namespace _0App.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Vw4Cues
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Vw4Cues))
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.btnDel = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.sideBar = New System.Windows.Forms.Panel()
            Me.btnMvUp = New System.Windows.Forms.Button()
            Me.btnMvDn = New System.Windows.Forms.Button()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.editor = New System.Windows.Forms.Panel()
            Me.tabPJX = New System.Windows.Forms.Button()
            Me.tabSFX = New System.Windows.Forms.Button()
            Me.tabLFX = New System.Windows.Forms.Button()
            Me.cbPJX = New System.Windows.Forms.CheckBox()
            Me.cbSFX = New System.Windows.Forms.CheckBox()
            Me.cbLFX = New System.Windows.Forms.CheckBox()
            Me.btnEdit = New System.Windows.Forms.Button()
            Me.lbName = New System.Windows.Forms.Label()
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.bottomDummy = New System.Windows.Forms.Panel()
            Me.pnlPJX = New System.Windows.Forms.Panel()
            Me.lbPjx = New System.Windows.Forms.Label()
            Me.tbPJXDur = New System.Windows.Forms.TextBox()
            Me.tbPJXDelay = New System.Windows.Forms.TextBox()
            Me.cbPjxEffect = New System.Windows.Forms.ComboBox()
            Me.btnPjxPlay = New System.Windows.Forms.Button()
            Me.btnPjxChoose = New System.Windows.Forms.Button()
            Me.pbPjx = New System.Windows.Forms.PictureBox()
            Me.lbPJXDelay = New System.Windows.Forms.Label()
            Me.lbPJXDur = New System.Windows.Forms.Label()
            Me.pnlLFX = New System.Windows.Forms.Panel()
            Me.visual = New System.Windows.Forms.PictureBox()
            Me.channelsEditor = New System.Windows.Forms.Panel()
            Me.FaderBar = New Entity._5Controls.CoolTrackBar()
            Me.cbType = New System.Windows.Forms.ComboBox()
            Me.asngLV = New Entity._5Controls.listViewX()
            Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colChnlName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.btnFader = New System.Windows.Forms.Button()
            Me.btnRemCh = New System.Windows.Forms.Button()
            Me.lbCh = New System.Windows.Forms.Label()
            Me.btnAddCh = New System.Windows.Forms.Button()
            Me.pnlLightSelector = New System.Windows.Forms.Panel()
            Me.cbLLight = New System.Windows.Forms.ComboBox()
            Me.cbLChTag = New System.Windows.Forms.ComboBox()
            Me.pnlCh = New System.Windows.Forms.Panel()
            Me.numChID = New System.Windows.Forms.NumericUpDown()
            Me.pnlFadeTime = New System.Windows.Forms.Panel()
            Me.lbFadeDelayUnit = New System.Windows.Forms.Label()
            Me.lbFadeDelay = New System.Windows.Forms.Label()
            Me.tbFadeDelay = New System.Windows.Forms.TextBox()
            Me.lbFadeTimeUnit = New System.Windows.Forms.Label()
            Me.lbFadeTime = New System.Windows.Forms.Label()
            Me.tbFadeTime = New System.Windows.Forms.TextBox()
            Me.pnlSFX = New System.Windows.Forms.Panel()
            Me.tbAllFade = New System.Windows.Forms.TextBox()
            Me.lbAllFade = New System.Windows.Forms.Label()
            Me.tbAllDelay = New System.Windows.Forms.TextBox()
            Me.lbP = New System.Windows.Forms.Label()
            Me.tbSFade = New System.Windows.Forms.TextBox()
            Me.lbSFade = New System.Windows.Forms.Label()
            Me.btnSChange = New System.Windows.Forms.Button()
            Me.btnPChange = New System.Windows.Forms.Button()
            Me.tbSDelay = New System.Windows.Forms.TextBox()
            Me.lbPDelay = New System.Windows.Forms.Label()
            Me.tbPDelay = New System.Windows.Forms.TextBox()
            Me.btnSRem = New System.Windows.Forms.Button()
            Me.btnSAdd = New System.Windows.Forms.Button()
            Me.btnPRem = New System.Windows.Forms.Button()
            Me.cbStopAll = New System.Windows.Forms.CheckBox()
            Me.btnPAdd = New System.Windows.Forms.Button()
            Me.lvToPlay = New Entity._5Controls.listViewX()
            Me.PcolName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.PcolDelay = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.lbToStop = New System.Windows.Forms.Label()
            Me.lbToPlay = New System.Windows.Forms.Label()
            Me.lvToStop = New Entity._5Controls.listViewX()
            Me.ScolName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ScolDur = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.ScolDelay = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.lbSDelay = New System.Windows.Forms.Label()
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
            Me.sideBar.SuspendLayout()
            Me.editor.SuspendLayout()
            Me.pnlPJX.SuspendLayout()
            CType(Me.pbPjx, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlLFX.SuspendLayout()
            CType(Me.visual, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.channelsEditor.SuspendLayout()
            CType(Me.FaderBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlLightSelector.SuspendLayout()
            Me.pnlCh.SuspendLayout()
            CType(Me.numChID, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFadeTime.SuspendLayout()
            Me.pnlSFX.SuspendLayout()
            Me.SuspendLayout()
            '
            'imgLst
            '
            Me.imgLst.ImageStream = CType(resources.GetObject("imgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
            Me.imgLst.Images.SetKeyName(0, "Folder-Star.ico")
            Me.imgLst.Images.SetKeyName(1, "Stock.ico")
            Me.imgLst.Images.SetKeyName(2, "Package.ico")
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
            Me.tt.SetToolTip(Me.btnDel, "Deletes all selected cues.")
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
            Me.tt.SetToolTip(Me.btnAdd, resources.GetString("btnAdd.ToolTip"))
            Me.btnAdd.UseVisualStyleBackColor = False
            '
            'sideBar
            '
            Me.sideBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.sideBar.AutoScroll = True
            Me.sideBar.BackColor = System.Drawing.Color.Gainsboro
            Me.sideBar.Controls.Add(Me.btnMvUp)
            Me.sideBar.Controls.Add(Me.btnMvDn)
            Me.sideBar.Controls.Add(Me.lv)
            Me.sideBar.Controls.Add(Me.btnDel)
            Me.sideBar.Controls.Add(Me.btnAdd)
            Me.sideBar.Location = New System.Drawing.Point(27, 39)
            Me.sideBar.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.sideBar.Name = "sideBar"
            Me.sideBar.Size = New System.Drawing.Size(311, 637)
            Me.sideBar.TabIndex = 0
            '
            'btnMvUp
            '
            Me.btnMvUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnMvUp.Enabled = False
            Me.btnMvUp.FlatAppearance.BorderSize = 0
            Me.btnMvUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMvUp.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMvUp.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnMvUp.Location = New System.Drawing.Point(22, 13)
            Me.btnMvUp.Margin = New System.Windows.Forms.Padding(0, 24, 60, 24)
            Me.btnMvUp.Name = "btnMvUp"
            Me.btnMvUp.Size = New System.Drawing.Size(130, 40)
            Me.btnMvUp.TabIndex = 1
            Me.btnMvUp.Text = "Move Up"
            Me.tt.SetToolTip(Me.btnMvUp, resources.GetString("btnMvUp.ToolTip"))
            Me.btnMvUp.UseVisualStyleBackColor = False
            '
            'btnMvDn
            '
            Me.btnMvDn.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnMvDn.Enabled = False
            Me.btnMvDn.FlatAppearance.BorderSize = 0
            Me.btnMvDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMvDn.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMvDn.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnMvDn.Location = New System.Drawing.Point(166, 13)
            Me.btnMvDn.Margin = New System.Windows.Forms.Padding(0, 24, 60, 24)
            Me.btnMvDn.Name = "btnMvDn"
            Me.btnMvDn.Size = New System.Drawing.Size(130, 40)
            Me.btnMvDn.TabIndex = 2
            Me.btnMvDn.Text = "Move Down"
            Me.tt.SetToolTip(Me.btnMvDn, resources.GetString("btnMvDn.ToolTip"))
            Me.btnMvDn.UseVisualStyleBackColor = False
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
            Me.lv.TabIndex = 0
            Me.tt.SetToolTip(Me.lv, "A list of the show's cues. Click any cue to edit it." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Note that the order of cu" & _
            "es in this list" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "is the order they will be activated during the show.")
            Me.lv.UseCompatibleStateImageBehavior = False
            Me.lv.View = System.Windows.Forms.View.Details
            '
            'colName
            '
            Me.colName.Text = "Name"
            '
            'editor
            '
            Me.editor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.editor.AutoScroll = True
            Me.editor.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.editor.Controls.Add(Me.tabPJX)
            Me.editor.Controls.Add(Me.tabSFX)
            Me.editor.Controls.Add(Me.tabLFX)
            Me.editor.Controls.Add(Me.cbPJX)
            Me.editor.Controls.Add(Me.cbSFX)
            Me.editor.Controls.Add(Me.cbLFX)
            Me.editor.Controls.Add(Me.btnEdit)
            Me.editor.Controls.Add(Me.lbName)
            Me.editor.Controls.Add(Me.tbName)
            Me.editor.Controls.Add(Me.lbWarning)
            Me.editor.Controls.Add(Me.bottomDummy)
            Me.editor.Controls.Add(Me.pnlPJX)
            Me.editor.Controls.Add(Me.pnlLFX)
            Me.editor.Controls.Add(Me.pnlSFX)
            Me.editor.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.editor.Location = New System.Drawing.Point(353, 39)
            Me.editor.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.editor.Name = "editor"
            Me.editor.Size = New System.Drawing.Size(727, 637)
            Me.editor.TabIndex = 1
            Me.editor.Visible = False
            '
            'tabPJX
            '
            Me.tabPJX.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.tabPJX.FlatAppearance.BorderSize = 0
            Me.tabPJX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabPJX.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabPJX.ForeColor = System.Drawing.Color.White
            Me.tabPJX.Location = New System.Drawing.Point(274, 88)
            Me.tabPJX.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.tabPJX.Name = "tabPJX"
            Me.tabPJX.Size = New System.Drawing.Size(120, 40)
            Me.tabPJX.TabIndex = 33
            Me.tabPJX.Tag = ""
            Me.tabPJX.Text = "PJX"
            Me.tt.SetToolTip(Me.tabPJX, "Click to go to the projection tab" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If a tab is greyed out, you need to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "check t" & _
            "he checkbox above it to enable it.")
            Me.tabPJX.UseVisualStyleBackColor = False
            '
            'tabSFX
            '
            Me.tabSFX.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.tabSFX.FlatAppearance.BorderSize = 0
            Me.tabSFX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabSFX.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabSFX.ForeColor = System.Drawing.Color.White
            Me.tabSFX.Location = New System.Drawing.Point(154, 88)
            Me.tabSFX.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.tabSFX.Name = "tabSFX"
            Me.tabSFX.Size = New System.Drawing.Size(120, 40)
            Me.tabSFX.TabIndex = 32
            Me.tabSFX.Tag = ""
            Me.tabSFX.Text = "SFX"
            Me.tt.SetToolTip(Me.tabSFX, "Click to go to the sound effects tab." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If a tab is greyed out, you need to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "che" & _
            "ck the checkbox above it to enable it." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
            Me.tabSFX.UseVisualStyleBackColor = False
            '
            'tabLFX
            '
            Me.tabLFX.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.tabLFX.FlatAppearance.BorderSize = 0
            Me.tabLFX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabLFX.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabLFX.ForeColor = System.Drawing.Color.White
            Me.tabLFX.Location = New System.Drawing.Point(34, 88)
            Me.tabLFX.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.tabLFX.Name = "tabLFX"
            Me.tabLFX.Size = New System.Drawing.Size(120, 40)
            Me.tabLFX.TabIndex = 31
            Me.tabLFX.Text = "LFX"
            Me.tt.SetToolTip(Me.tabLFX, "Click to go to the lights tab." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If a tab is greyed out, you need to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "check the " & _
            "checkbox above it to enable it.")
            Me.tabLFX.UseVisualStyleBackColor = False
            '
            'cbPJX
            '
            Me.cbPJX.AutoSize = True
            Me.cbPJX.Location = New System.Drawing.Point(274, 64)
            Me.cbPJX.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.cbPJX.Name = "cbPJX"
            Me.cbPJX.Size = New System.Drawing.Size(49, 24)
            Me.cbPJX.TabIndex = 30
            Me.cbPJX.Text = "PJX"
            Me.tt.SetToolTip(Me.cbPJX, "Check this box if there are projection changes in this cue.")
            Me.cbPJX.UseVisualStyleBackColor = True
            '
            'cbSFX
            '
            Me.cbSFX.AutoSize = True
            Me.cbSFX.Location = New System.Drawing.Point(156, 64)
            Me.cbSFX.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.cbSFX.Name = "cbSFX"
            Me.cbSFX.Size = New System.Drawing.Size(52, 24)
            Me.cbSFX.TabIndex = 29
            Me.cbSFX.Text = "SFX"
            Me.tt.SetToolTip(Me.cbSFX, "Check this box if there are sound effects to be played or stopped in this cue.")
            Me.cbSFX.UseVisualStyleBackColor = True
            '
            'cbLFX
            '
            Me.cbLFX.AutoSize = True
            Me.cbLFX.Location = New System.Drawing.Point(34, 64)
            Me.cbLFX.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.cbLFX.Name = "cbLFX"
            Me.cbLFX.Size = New System.Drawing.Size(51, 24)
            Me.cbLFX.TabIndex = 28
            Me.cbLFX.Text = "LFX"
            Me.tt.SetToolTip(Me.cbLFX, "Check this box if there are light changes in this cue.")
            Me.cbLFX.UseVisualStyleBackColor = True
            '
            'btnEdit
            '
            Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.btnEdit.FlatAppearance.BorderSize = 0
            Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnEdit.Image = Global.Entity.My.Resources.Resources.EditBtn
            Me.btnEdit.Location = New System.Drawing.Point(580, 26)
            Me.btnEdit.Margin = New System.Windows.Forms.Padding(0, 38, 60, 38)
            Me.btnEdit.Name = "btnEdit"
            Me.btnEdit.Size = New System.Drawing.Size(29, 26)
            Me.btnEdit.TabIndex = 6
            Me.tt.SetToolTip(Me.btnEdit, "Click to edit the name of this cue.")
            Me.btnEdit.UseVisualStyleBackColor = False
            '
            'lbName
            '
            Me.lbName.AutoSize = True
            Me.lbName.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.lbName.ForeColor = System.Drawing.Color.White
            Me.lbName.Location = New System.Drawing.Point(29, 29)
            Me.lbName.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbName.Name = "lbName"
            Me.lbName.Size = New System.Drawing.Size(50, 20)
            Me.lbName.TabIndex = 17
            Me.lbName.Text = "Label1"
            '
            'tbName
            '
            Me.tbName.Location = New System.Drawing.Point(33, 26)
            Me.tbName.Margin = New System.Windows.Forms.Padding(48, 24, 0, 24)
            Me.tbName.MaxLength = 30
            Me.tbName.Name = "tbName"
            Me.tbName.Size = New System.Drawing.Size(547, 27)
            Me.tbName.TabIndex = 5
            Me.tt.SetToolTip(Me.tbName, "Click the red button on the right to save, or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "right click it to cancel.")
            Me.tbName.Visible = False
            '
            'lbWarning
            '
            Me.lbWarning.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.lbWarning.ForeColor = System.Drawing.Color.White
            Me.lbWarning.Location = New System.Drawing.Point(29, 4)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(547, 28)
            Me.lbWarning.TabIndex = 20
            Me.lbWarning.Text = "Warning"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWarning.Visible = False
            '
            'bottomDummy
            '
            Me.bottomDummy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.bottomDummy.Location = New System.Drawing.Point(204, 28778)
            Me.bottomDummy.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.bottomDummy.Name = "bottomDummy"
            Me.bottomDummy.Size = New System.Drawing.Size(130, 40)
            Me.bottomDummy.TabIndex = 26
            '
            'pnlPJX
            '
            Me.pnlPJX.Controls.Add(Me.lbPjx)
            Me.pnlPJX.Controls.Add(Me.tbPJXDur)
            Me.pnlPJX.Controls.Add(Me.tbPJXDelay)
            Me.pnlPJX.Controls.Add(Me.cbPjxEffect)
            Me.pnlPJX.Controls.Add(Me.btnPjxPlay)
            Me.pnlPJX.Controls.Add(Me.btnPjxChoose)
            Me.pnlPJX.Controls.Add(Me.pbPjx)
            Me.pnlPJX.Controls.Add(Me.lbPJXDelay)
            Me.pnlPJX.Controls.Add(Me.lbPJXDur)
            Me.pnlPJX.Location = New System.Drawing.Point(33, 129)
            Me.pnlPJX.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.pnlPJX.Name = "pnlPJX"
            Me.pnlPJX.Size = New System.Drawing.Size(523, 297)
            Me.pnlPJX.TabIndex = 36
            Me.pnlPJX.Visible = False
            '
            'lbPjx
            '
            Me.lbPjx.Location = New System.Drawing.Point(284, 64)
            Me.lbPjx.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbPjx.Name = "lbPjx"
            Me.lbPjx.Size = New System.Drawing.Size(100, 22)
            Me.lbPjx.TabIndex = 44
            Me.lbPjx.Text = "_blackout"
            '
            'tbPJXDur
            '
            Me.tbPJXDur.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbPJXDur.Location = New System.Drawing.Point(7, 252)
            Me.tbPJXDur.Margin = New System.Windows.Forms.Padding(36, 14, 36, 24)
            Me.tbPJXDur.MaxLength = 5
            Me.tbPJXDur.Name = "tbPJXDur"
            Me.tbPJXDur.Size = New System.Drawing.Size(100, 29)
            Me.tbPJXDur.TabIndex = 35
            Me.tbPJXDur.Text = "1.0"
            Me.tt.SetToolTip(Me.tbPJXDur, "Sets the number of seconds the image transition should take.")
            '
            'tbPJXDelay
            '
            Me.tbPJXDelay.Location = New System.Drawing.Point(200, 253)
            Me.tbPJXDelay.Margin = New System.Windows.Forms.Padding(36, 24, 36, 14)
            Me.tbPJXDelay.MaxLength = 5
            Me.tbPJXDelay.Name = "tbPJXDelay"
            Me.tbPJXDelay.Size = New System.Drawing.Size(100, 27)
            Me.tbPJXDelay.TabIndex = 36
            Me.tbPJXDelay.Text = "0.0"
            Me.tt.SetToolTip(Me.tbPJXDelay, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the image transition" & _
            " should occur.")
            '
            'cbPjxEffect
            '
            Me.cbPjxEffect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cbPjxEffect.BackColor = System.Drawing.SystemColors.Window
            Me.cbPjxEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbPjxEffect.DropDownWidth = 220
            Me.cbPjxEffect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbPjxEffect.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbPjxEffect.FormattingEnabled = True
            Me.cbPjxEffect.Location = New System.Drawing.Point(288, 144)
            Me.cbPjxEffect.Margin = New System.Windows.Forms.Padding(36, 24, 36, 24)
            Me.cbPjxEffect.Name = "cbPjxEffect"
            Me.cbPjxEffect.Size = New System.Drawing.Size(130, 28)
            Me.cbPjxEffect.TabIndex = 33
            Me.tt.SetToolTip(Me.cbPjxEffect, "Sets the effect to use for transitioning to the new image.")
            '
            'btnPjxPlay
            '
            Me.btnPjxPlay.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnPjxPlay.FlatAppearance.BorderSize = 0
            Me.btnPjxPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPjxPlay.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPjxPlay.ForeColor = System.Drawing.Color.White
            Me.btnPjxPlay.Location = New System.Drawing.Point(288, 181)
            Me.btnPjxPlay.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnPjxPlay.Name = "btnPjxPlay"
            Me.btnPjxPlay.Size = New System.Drawing.Size(130, 40)
            Me.btnPjxPlay.TabIndex = 34
            Me.btnPjxPlay.Text = "Preview"
            Me.tt.SetToolTip(Me.btnPjxPlay, "Click to preview this image transition." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Note: The preview will be played immed" & _
            "iately." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "In other words, changing the 'delay' field below " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "will have no effect " & _
            "on the preview.")
            Me.btnPjxPlay.UseVisualStyleBackColor = False
            '
            'btnPjxChoose
            '
            Me.btnPjxChoose.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnPjxChoose.FlatAppearance.BorderSize = 0
            Me.btnPjxChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPjxChoose.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPjxChoose.ForeColor = System.Drawing.Color.White
            Me.btnPjxChoose.Location = New System.Drawing.Point(288, 94)
            Me.btnPjxChoose.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnPjxChoose.Name = "btnPjxChoose"
            Me.btnPjxChoose.Size = New System.Drawing.Size(130, 40)
            Me.btnPjxChoose.TabIndex = 32
            Me.btnPjxChoose.Text = "Change Image"
            Me.tt.SetToolTip(Me.btnPjxChoose, "Click to choose another image to display." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tip: You can choose the ""_blackout"" " & _
            "item here" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "if you wish to black out the projection for the cue.")
            Me.btnPjxChoose.UseVisualStyleBackColor = False
            '
            'pbPjx
            '
            Me.pbPjx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.pbPjx.Location = New System.Drawing.Point(7, 48)
            Me.pbPjx.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.pbPjx.Name = "pbPjx"
            Me.pbPjx.Size = New System.Drawing.Size(257, 176)
            Me.pbPjx.TabIndex = 0
            Me.pbPjx.TabStop = False
            '
            'lbPJXDelay
            '
            Me.lbPJXDelay.AutoSize = True
            Me.lbPJXDelay.Location = New System.Drawing.Point(302, 256)
            Me.lbPJXDelay.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbPJXDelay.Name = "lbPJXDelay"
            Me.lbPJXDelay.Size = New System.Drawing.Size(55, 20)
            Me.lbPJXDelay.TabIndex = 41
            Me.lbPJXDelay.Text = "s Delay"
            Me.tt.SetToolTip(Me.lbPJXDelay, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the image transition" & _
            " should occur.")
            '
            'lbPJXDur
            '
            Me.lbPJXDur.AutoSize = True
            Me.lbPJXDur.Location = New System.Drawing.Point(109, 256)
            Me.lbPJXDur.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbPJXDur.Name = "lbPJXDur"
            Me.lbPJXDur.Size = New System.Drawing.Size(75, 20)
            Me.lbPJXDur.TabIndex = 43
            Me.lbPJXDur.Text = "s Duration"
            Me.tt.SetToolTip(Me.lbPJXDur, "Sets the number of seconds the image transition should take.")
            '
            'pnlLFX
            '
            Me.pnlLFX.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
            Me.pnlLFX.Controls.Add(Me.visual)
            Me.pnlLFX.Controls.Add(Me.channelsEditor)
            Me.pnlLFX.Controls.Add(Me.pnlFadeTime)
            Me.pnlLFX.Location = New System.Drawing.Point(33, 129)
            Me.pnlLFX.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.pnlLFX.Name = "pnlLFX"
            Me.pnlLFX.Size = New System.Drawing.Size(523, 496)
            Me.pnlLFX.TabIndex = 25
            '
            'visual
            '
            Me.visual.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.visual.Location = New System.Drawing.Point(0, 14)
            Me.visual.Margin = New System.Windows.Forms.Padding(36, 14, 36, 0)
            Me.visual.Name = "visual"
            Me.visual.Size = New System.Drawing.Size(523, 170)
            Me.visual.TabIndex = 22
            Me.visual.TabStop = False
            Me.tt.SetToolTip(Me.visual, "A visualisation of your lights." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click any light to assign/unassign it." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can " & _
            "edit this visualisation in the ""Lights"" tab.")
            '
            'channelsEditor
            '
            Me.channelsEditor.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
            Me.channelsEditor.Controls.Add(Me.FaderBar)
            Me.channelsEditor.Controls.Add(Me.cbType)
            Me.channelsEditor.Controls.Add(Me.asngLV)
            Me.channelsEditor.Controls.Add(Me.btnFader)
            Me.channelsEditor.Controls.Add(Me.btnRemCh)
            Me.channelsEditor.Controls.Add(Me.lbCh)
            Me.channelsEditor.Controls.Add(Me.btnAddCh)
            Me.channelsEditor.Controls.Add(Me.pnlLightSelector)
            Me.channelsEditor.Controls.Add(Me.pnlCh)
            Me.channelsEditor.Location = New System.Drawing.Point(0, 183)
            Me.channelsEditor.Margin = New System.Windows.Forms.Padding(36, 0, 36, 14)
            Me.channelsEditor.Name = "channelsEditor"
            Me.channelsEditor.Size = New System.Drawing.Size(523, 196)
            Me.channelsEditor.TabIndex = 24
            '
            'FaderBar
            '
            Me.FaderBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.FaderBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.FaderBar.GrooveBorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.FaderBar.GrooveColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.FaderBar.GrooveSize = 6
            Me.FaderBar.Location = New System.Drawing.Point(384, 14)
            Me.FaderBar.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.FaderBar.Maximum = 255
            Me.FaderBar.Name = "FaderBar"
            Me.FaderBar.Orientation = System.Windows.Forms.Orientation.Vertical
            Me.FaderBar.Size = New System.Drawing.Size(45, 151)
            Me.FaderBar.TabIndex = 30
            Me.FaderBar.TickStyle = System.Windows.Forms.TickStyle.Both
            Me.tt.SetToolTip(Me.FaderBar, "When done adjusting," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "click the red button below to hide this trackbar." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Saving" & _
            " is automatic.")
            Me.FaderBar.Visible = False
            '
            'cbType
            '
            Me.cbType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbType.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbType.FormattingEnabled = True
            Me.cbType.Items.AddRange(New Object() {"Light", "Channel"})
            Me.cbType.Location = New System.Drawing.Point(21, 164)
            Me.cbType.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.cbType.Name = "cbType"
            Me.cbType.Size = New System.Drawing.Size(102, 29)
            Me.cbType.TabIndex = 27
            Me.tt.SetToolTip(Me.cbType, "Sets whether to assign a light or a channel")
            Me.cbType.Visible = False
            '
            'asngLV
            '
            Me.asngLV.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.asngLV.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
            Me.asngLV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.asngLV.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
            Me.asngLV.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.asngLV.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colChnlName})
            Me.asngLV.Font = New System.Drawing.Font("Segoe UI Semilight", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.asngLV.ForeColor = System.Drawing.Color.White
            Me.asngLV.FullRowSelect = True
            Me.asngLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.asngLV.HideSelection = False
            Me.asngLV.LargeImageList = Me.imgLst
            Me.asngLV.Location = New System.Drawing.Point(20, 34)
            Me.asngLV.Margin = New System.Windows.Forms.Padding(36, 14, 36, 0)
            Me.asngLV.Name = "asngLV"
            Me.asngLV.Size = New System.Drawing.Size(476, 117)
            Me.asngLV.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.asngLV.TabIndex = 21
            Me.asngLV.TileSize = New System.Drawing.Size(180, 56)
            Me.tt.SetToolTip(Me.asngLV, resources.GetString("asngLV.ToolTip"))
            Me.asngLV.UseCompatibleStateImageBehavior = False
            Me.asngLV.View = System.Windows.Forms.View.Tile
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
            'btnFader
            '
            Me.btnFader.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnFader.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnFader.FlatAppearance.BorderSize = 0
            Me.btnFader.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnFader.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFader.ForeColor = System.Drawing.Color.White
            Me.btnFader.Location = New System.Drawing.Point(384, 165)
            Me.btnFader.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnFader.Name = "btnFader"
            Me.btnFader.Size = New System.Drawing.Size(45, 29)
            Me.btnFader.TabIndex = 30
            Me.btnFader.Text = "10"
            Me.tt.SetToolTip(Me.btnFader, "The fader level (brightness) to set the light/channel to." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "10 = Fully On, 0 = Off" & _
            "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click to adjust, then click again to save.")
            Me.btnFader.UseVisualStyleBackColor = False
            Me.btnFader.Visible = False
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
            Me.btnRemCh.Location = New System.Drawing.Point(482, 160)
            Me.btnRemCh.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnRemCh.Name = "btnRemCh"
            Me.btnRemCh.Size = New System.Drawing.Size(40, 35)
            Me.btnRemCh.TabIndex = 11
            Me.btnRemCh.Text = "-"
            Me.tt.SetToolTip(Me.btnRemCh, "Removes items from the ""Assigned Channels and Lights"" box." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can select multip" & _
            "le items to remove at the same time." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can also add/remove items with the v" & _
            "isualiser above.")
            Me.btnRemCh.UseVisualStyleBackColor = False
            '
            'lbCh
            '
            Me.lbCh.AutoSize = True
            Me.lbCh.Location = New System.Drawing.Point(16, 10)
            Me.lbCh.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbCh.Name = "lbCh"
            Me.lbCh.Size = New System.Drawing.Size(385, 20)
            Me.lbCh.TabIndex = 25
            Me.lbCh.Text = "Assigned Channels and Lights (Scroll Screen Down To Edit)"
            '
            'btnAddCh
            '
            Me.btnAddCh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAddCh.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnAddCh.FlatAppearance.BorderSize = 0
            Me.btnAddCh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddCh.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddCh.ForeColor = System.Drawing.Color.White
            Me.btnAddCh.Location = New System.Drawing.Point(437, 160)
            Me.btnAddCh.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnAddCh.Name = "btnAddCh"
            Me.btnAddCh.Size = New System.Drawing.Size(40, 35)
            Me.btnAddCh.TabIndex = 10
            Me.btnAddCh.Text = "+"
            Me.tt.SetToolTip(Me.btnAddCh, resources.GetString("btnAddCh.ToolTip"))
            Me.btnAddCh.UseVisualStyleBackColor = False
            '
            'pnlLightSelector
            '
            Me.pnlLightSelector.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.pnlLightSelector.Controls.Add(Me.cbLLight)
            Me.pnlLightSelector.Controls.Add(Me.cbLChTag)
            Me.pnlLightSelector.Location = New System.Drawing.Point(123, 162)
            Me.pnlLightSelector.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.pnlLightSelector.Name = "pnlLightSelector"
            Me.pnlLightSelector.Size = New System.Drawing.Size(261, 36)
            Me.pnlLightSelector.TabIndex = 29
            Me.pnlLightSelector.Visible = False
            '
            'cbLLight
            '
            Me.cbLLight.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.cbLLight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbLLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbLLight.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbLLight.FormattingEnabled = True
            Me.cbLLight.Location = New System.Drawing.Point(12, 3)
            Me.cbLLight.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.cbLLight.Name = "cbLLight"
            Me.cbLLight.Size = New System.Drawing.Size(118, 29)
            Me.cbLLight.TabIndex = 9
            Me.tt.SetToolTip(Me.cbLLight, "Sets the light to assign." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lights are defined in the ""Lights"" tab.")
            '
            'cbLChTag
            '
            Me.cbLChTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.cbLChTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbLChTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbLChTag.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbLChTag.FormattingEnabled = True
            Me.cbLChTag.Location = New System.Drawing.Point(135, 3)
            Me.cbLChTag.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.cbLChTag.Name = "cbLChTag"
            Me.cbLChTag.Size = New System.Drawing.Size(115, 29)
            Me.cbLChTag.TabIndex = 8
            Me.tt.SetToolTip(Me.cbLChTag, "Sets the channel of the of the light to assign." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Lights and their channels are de" & _
            "fined in the ""Lights"" tab.")
            '
            'pnlCh
            '
            Me.pnlCh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.pnlCh.Controls.Add(Me.numChID)
            Me.pnlCh.Location = New System.Drawing.Point(133, 154)
            Me.pnlCh.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.pnlCh.Name = "pnlCh"
            Me.pnlCh.Size = New System.Drawing.Size(118, 43)
            Me.pnlCh.TabIndex = 28
            Me.pnlCh.Visible = False
            '
            'numChID
            '
            Me.numChID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.numChID.Location = New System.Drawing.Point(12, 10)
            Me.numChID.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.numChID.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
            Me.numChID.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numChID.Name = "numChID"
            Me.numChID.Size = New System.Drawing.Size(95, 27)
            Me.numChID.TabIndex = 7
            Me.tt.SetToolTip(Me.numChID, "The number of the channel to assign." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The valid range of values on a DMX 512 cabl" & _
            "e is 1 to 512.")
            Me.numChID.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'pnlFadeTime
            '
            Me.pnlFadeTime.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
            Me.pnlFadeTime.Controls.Add(Me.lbFadeDelayUnit)
            Me.pnlFadeTime.Controls.Add(Me.lbFadeDelay)
            Me.pnlFadeTime.Controls.Add(Me.tbFadeDelay)
            Me.pnlFadeTime.Controls.Add(Me.lbFadeTimeUnit)
            Me.pnlFadeTime.Controls.Add(Me.lbFadeTime)
            Me.pnlFadeTime.Controls.Add(Me.tbFadeTime)
            Me.pnlFadeTime.Location = New System.Drawing.Point(0, 379)
            Me.pnlFadeTime.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.pnlFadeTime.Name = "pnlFadeTime"
            Me.pnlFadeTime.Size = New System.Drawing.Size(523, 50)
            Me.pnlFadeTime.TabIndex = 34
            '
            'lbFadeDelayUnit
            '
            Me.lbFadeDelayUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbFadeDelayUnit.AutoSize = True
            Me.lbFadeDelayUnit.ForeColor = System.Drawing.Color.White
            Me.lbFadeDelayUnit.Location = New System.Drawing.Point(-485, -99)
            Me.lbFadeDelayUnit.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbFadeDelayUnit.Name = "lbFadeDelayUnit"
            Me.lbFadeDelayUnit.Size = New System.Drawing.Size(72, 20)
            Me.lbFadeDelayUnit.TabIndex = 36
            Me.lbFadeDelayUnit.Text = "Second(s)"
            Me.tt.SetToolTip(Me.lbFadeDelayUnit, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the fading of lights" & _
            " should begin.")
            '
            'lbFadeDelay
            '
            Me.lbFadeDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbFadeDelay.AutoSize = True
            Me.lbFadeDelay.ForeColor = System.Drawing.Color.White
            Me.lbFadeDelay.Location = New System.Drawing.Point(397, 15)
            Me.lbFadeDelay.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbFadeDelay.Name = "lbFadeDelay"
            Me.lbFadeDelay.Size = New System.Drawing.Size(48, 20)
            Me.lbFadeDelay.TabIndex = 35
            Me.lbFadeDelay.Text = "Delay:"
            Me.tt.SetToolTip(Me.lbFadeDelay, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the fading of lights" & _
            " should begin.")
            '
            'tbFadeDelay
            '
            Me.tbFadeDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbFadeDelay.Location = New System.Drawing.Point(452, 12)
            Me.tbFadeDelay.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbFadeDelay.MaxLength = 5
            Me.tbFadeDelay.Name = "tbFadeDelay"
            Me.tbFadeDelay.Size = New System.Drawing.Size(54, 27)
            Me.tbFadeDelay.TabIndex = 34
            Me.tbFadeDelay.Text = "1.0"
            Me.tt.SetToolTip(Me.tbFadeDelay, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the fading of lights" & _
            " should begin.")
            '
            'lbFadeTimeUnit
            '
            Me.lbFadeTimeUnit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbFadeTimeUnit.AutoSize = True
            Me.lbFadeTimeUnit.ForeColor = System.Drawing.Color.White
            Me.lbFadeTimeUnit.Location = New System.Drawing.Point(-4433, -99)
            Me.lbFadeTimeUnit.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbFadeTimeUnit.Name = "lbFadeTimeUnit"
            Me.lbFadeTimeUnit.Size = New System.Drawing.Size(72, 20)
            Me.lbFadeTimeUnit.TabIndex = 33
            Me.lbFadeTimeUnit.Text = "Second(s)"
            Me.tt.SetToolTip(Me.lbFadeTimeUnit, "Sets how long it takes to fade from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the previously activated lights" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the ligh" & _
            "ts assigned to this cue")
            '
            'lbFadeTime
            '
            Me.lbFadeTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbFadeTime.AutoSize = True
            Me.lbFadeTime.ForeColor = System.Drawing.Color.White
            Me.lbFadeTime.Location = New System.Drawing.Point(222, 15)
            Me.lbFadeTime.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbFadeTime.Name = "lbFadeTime"
            Me.lbFadeTime.Size = New System.Drawing.Size(103, 20)
            Me.lbFadeTime.TabIndex = 32
            Me.lbFadeTime.Text = "Fade Duration:"
            Me.tt.SetToolTip(Me.lbFadeTime, "Sets how long it takes to fade from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the previously activated lights" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the ligh" & _
            "ts assigned to this cue")
            '
            'tbFadeTime
            '
            Me.tbFadeTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbFadeTime.Location = New System.Drawing.Point(330, 12)
            Me.tbFadeTime.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbFadeTime.MaxLength = 5
            Me.tbFadeTime.Name = "tbFadeTime"
            Me.tbFadeTime.Size = New System.Drawing.Size(54, 27)
            Me.tbFadeTime.TabIndex = 31
            Me.tbFadeTime.Text = "1.0"
            Me.tt.SetToolTip(Me.tbFadeTime, "Sets how long it takes to fade from" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the previously activated lights" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the ligh" & _
            "ts assigned to this cue")
            '
            'pnlSFX
            '
            Me.pnlSFX.Controls.Add(Me.tbAllFade)
            Me.pnlSFX.Controls.Add(Me.lbAllFade)
            Me.pnlSFX.Controls.Add(Me.tbAllDelay)
            Me.pnlSFX.Controls.Add(Me.lbP)
            Me.pnlSFX.Controls.Add(Me.tbSFade)
            Me.pnlSFX.Controls.Add(Me.lbSFade)
            Me.pnlSFX.Controls.Add(Me.btnSChange)
            Me.pnlSFX.Controls.Add(Me.btnPChange)
            Me.pnlSFX.Controls.Add(Me.tbSDelay)
            Me.pnlSFX.Controls.Add(Me.lbPDelay)
            Me.pnlSFX.Controls.Add(Me.tbPDelay)
            Me.pnlSFX.Controls.Add(Me.btnSRem)
            Me.pnlSFX.Controls.Add(Me.btnSAdd)
            Me.pnlSFX.Controls.Add(Me.btnPRem)
            Me.pnlSFX.Controls.Add(Me.cbStopAll)
            Me.pnlSFX.Controls.Add(Me.btnPAdd)
            Me.pnlSFX.Controls.Add(Me.lvToPlay)
            Me.pnlSFX.Controls.Add(Me.lbToStop)
            Me.pnlSFX.Controls.Add(Me.lbToPlay)
            Me.pnlSFX.Controls.Add(Me.lvToStop)
            Me.pnlSFX.Controls.Add(Me.lbSDelay)
            Me.pnlSFX.Location = New System.Drawing.Point(33, 129)
            Me.pnlSFX.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.pnlSFX.Name = "pnlSFX"
            Me.pnlSFX.Size = New System.Drawing.Size(523, 508)
            Me.pnlSFX.TabIndex = 35
            Me.pnlSFX.Visible = False
            '
            'tbAllFade
            '
            Me.tbAllFade.Location = New System.Drawing.Point(5, 509)
            Me.tbAllFade.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbAllFade.MaxLength = 5
            Me.tbAllFade.Name = "tbAllFade"
            Me.tbAllFade.Size = New System.Drawing.Size(82, 27)
            Me.tbAllFade.TabIndex = 21
            Me.tbAllFade.Text = "0.0"
            Me.tt.SetToolTip(Me.tbAllFade, resources.GetString("tbAllFade.ToolTip"))
            '
            'lbAllFade
            '
            Me.lbAllFade.AutoSize = True
            Me.lbAllFade.Location = New System.Drawing.Point(88, 512)
            Me.lbAllFade.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbAllFade.Name = "lbAllFade"
            Me.lbAllFade.Size = New System.Drawing.Size(50, 20)
            Me.lbAllFade.TabIndex = 46
            Me.lbAllFade.Text = "s Fade"
            Me.tt.SetToolTip(Me.lbAllFade, resources.GetString("lbAllFade.ToolTip"))
            '
            'tbAllDelay
            '
            Me.tbAllDelay.Location = New System.Drawing.Point(171, 509)
            Me.tbAllDelay.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbAllDelay.MaxLength = 5
            Me.tbAllDelay.Name = "tbAllDelay"
            Me.tbAllDelay.Size = New System.Drawing.Size(82, 27)
            Me.tbAllDelay.TabIndex = 22
            Me.tbAllDelay.Text = "0.0"
            Me.tt.SetToolTip(Me.tbAllDelay, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "all sound effects sh" & _
            "ould be stopped." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This is only valid if the ""stop all"" box above is checked.")
            '
            'lbP
            '
            Me.lbP.AutoSize = True
            Me.lbP.Location = New System.Drawing.Point(254, 512)
            Me.lbP.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbP.Name = "lbP"
            Me.lbP.Size = New System.Drawing.Size(55, 20)
            Me.lbP.TabIndex = 44
            Me.lbP.Text = "s Delay"
            Me.tt.SetToolTip(Me.lbP, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "all sound effects sh" & _
            "ould be stopped." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This is only valid if the ""stop all"" box above is checked.")
            '
            'tbSFade
            '
            Me.tbSFade.Location = New System.Drawing.Point(4, 423)
            Me.tbSFade.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbSFade.MaxLength = 5
            Me.tbSFade.Name = "tbSFade"
            Me.tbSFade.ShortcutsEnabled = False
            Me.tbSFade.Size = New System.Drawing.Size(34, 27)
            Me.tbSFade.TabIndex = 15
            Me.tbSFade.Text = "0.0"
            Me.tt.SetToolTip(Me.tbSFade, "Sets the number of seconds it should take to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "fade out the selected sound effect." & _
            "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Set this field to 0 to have the sound effect stop immediately.")
            Me.tbSFade.Visible = False
            '
            'lbSFade
            '
            Me.lbSFade.AutoSize = True
            Me.lbSFade.Location = New System.Drawing.Point(37, 426)
            Me.lbSFade.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbSFade.Name = "lbSFade"
            Me.lbSFade.Size = New System.Drawing.Size(50, 20)
            Me.lbSFade.TabIndex = 42
            Me.lbSFade.Text = "s Fade"
            Me.tt.SetToolTip(Me.lbSFade, "Sets the number of seconds it should take to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "fade out the selected sound effect." & _
            "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Set this field to 0 to have the sound effect stop immediately." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
            Me.lbSFade.Visible = False
            '
            'btnSChange
            '
            Me.btnSChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.btnSChange.Enabled = False
            Me.btnSChange.FlatAppearance.BorderSize = 0
            Me.btnSChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSChange.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSChange.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnSChange.Location = New System.Drawing.Point(319, 416)
            Me.btnSChange.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnSChange.Name = "btnSChange"
            Me.btnSChange.Size = New System.Drawing.Size(100, 40)
            Me.btnSChange.TabIndex = 18
            Me.btnSChange.Text = "Change"
            Me.tt.SetToolTip(Me.btnSChange, "Choose a new audio resource for the selected item in the list.")
            Me.btnSChange.UseVisualStyleBackColor = False
            '
            'btnPChange
            '
            Me.btnPChange.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.btnPChange.Enabled = False
            Me.btnPChange.FlatAppearance.BorderSize = 0
            Me.btnPChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPChange.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPChange.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnPChange.Location = New System.Drawing.Point(317, 190)
            Me.btnPChange.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnPChange.Name = "btnPChange"
            Me.btnPChange.Size = New System.Drawing.Size(100, 40)
            Me.btnPChange.TabIndex = 12
            Me.btnPChange.Text = "Change"
            Me.tt.SetToolTip(Me.btnPChange, "Choose a new audio resource for the selected item in the list.")
            Me.btnPChange.UseVisualStyleBackColor = False
            '
            'tbSDelay
            '
            Me.tbSDelay.Location = New System.Drawing.Point(97, 422)
            Me.tbSDelay.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbSDelay.MaxLength = 5
            Me.tbSDelay.Name = "tbSDelay"
            Me.tbSDelay.ShortcutsEnabled = False
            Me.tbSDelay.Size = New System.Drawing.Size(33, 27)
            Me.tbSDelay.TabIndex = 16
            Me.tbSDelay.Text = "0.0"
            Me.tt.SetToolTip(Me.tbSDelay, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the sound effect sho" & _
            "uld be stopped.")
            Me.tbSDelay.Visible = False
            '
            'lbPDelay
            '
            Me.lbPDelay.AutoSize = True
            Me.lbPDelay.Location = New System.Drawing.Point(58, 200)
            Me.lbPDelay.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbPDelay.Name = "lbPDelay"
            Me.lbPDelay.Size = New System.Drawing.Size(129, 20)
            Me.lbPDelay.TabIndex = 37
            Me.lbPDelay.Text = "Second(s) of Delay"
            Me.tt.SetToolTip(Me.lbPDelay, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the sound effect sho" & _
            "uld be played.")
            Me.lbPDelay.Visible = False
            '
            'tbPDelay
            '
            Me.tbPDelay.Location = New System.Drawing.Point(4, 197)
            Me.tbPDelay.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbPDelay.MaxLength = 5
            Me.tbPDelay.Name = "tbPDelay"
            Me.tbPDelay.ShortcutsEnabled = False
            Me.tbPDelay.Size = New System.Drawing.Size(53, 27)
            Me.tbPDelay.TabIndex = 10
            Me.tbPDelay.Text = "0.0"
            Me.tt.SetToolTip(Me.tbPDelay, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the sound effect sho" & _
            "uld be played.")
            Me.tbPDelay.Visible = False
            '
            'btnSRem
            '
            Me.btnSRem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSRem.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.btnSRem.Enabled = False
            Me.btnSRem.FlatAppearance.BorderSize = 0
            Me.btnSRem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSRem.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSRem.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnSRem.Location = New System.Drawing.Point(423, 415)
            Me.btnSRem.Margin = New System.Windows.Forms.Padding(0, 24, 60, 24)
            Me.btnSRem.Name = "btnSRem"
            Me.btnSRem.Size = New System.Drawing.Size(100, 40)
            Me.btnSRem.TabIndex = 19
            Me.btnSRem.Text = "Remove"
            Me.tt.SetToolTip(Me.btnSRem, "Deletes all selected items in the list.")
            Me.btnSRem.UseVisualStyleBackColor = False
            '
            'btnSAdd
            '
            Me.btnSAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.btnSAdd.FlatAppearance.BorderSize = 0
            Me.btnSAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSAdd.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnSAdd.Location = New System.Drawing.Point(214, 416)
            Me.btnSAdd.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnSAdd.Name = "btnSAdd"
            Me.btnSAdd.Size = New System.Drawing.Size(100, 40)
            Me.btnSAdd.TabIndex = 17
            Me.btnSAdd.Text = "Add"
            Me.tt.SetToolTip(Me.btnSAdd, "Choose a new audio resource to add to the list of sfx to stop.")
            Me.btnSAdd.UseVisualStyleBackColor = False
            '
            'btnPRem
            '
            Me.btnPRem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPRem.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.btnPRem.Enabled = False
            Me.btnPRem.FlatAppearance.BorderSize = 0
            Me.btnPRem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPRem.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPRem.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnPRem.Location = New System.Drawing.Point(421, 190)
            Me.btnPRem.Margin = New System.Windows.Forms.Padding(0, 24, 60, 24)
            Me.btnPRem.Name = "btnPRem"
            Me.btnPRem.Size = New System.Drawing.Size(100, 40)
            Me.btnPRem.TabIndex = 13
            Me.btnPRem.Text = "Remove"
            Me.tt.SetToolTip(Me.btnPRem, "Deletes all selected items in the list.")
            Me.btnPRem.UseVisualStyleBackColor = False
            '
            'cbStopAll
            '
            Me.cbStopAll.AutoSize = True
            Me.cbStopAll.Location = New System.Drawing.Point(3, 478)
            Me.cbStopAll.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.cbStopAll.Name = "cbStopAll"
            Me.cbStopAll.Size = New System.Drawing.Size(292, 24)
            Me.cbStopAll.TabIndex = 20
            Me.cbStopAll.Text = "Stop All Sound Effects On Cue Activation"
            Me.tt.SetToolTip(Me.cbStopAll, "Check this box if you want to stop all currently playing sound effects when this " & _
            "cue is activated.")
            Me.cbStopAll.UseVisualStyleBackColor = True
            '
            'btnPAdd
            '
            Me.btnPAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.btnPAdd.FlatAppearance.BorderSize = 0
            Me.btnPAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPAdd.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnPAdd.Location = New System.Drawing.Point(212, 190)
            Me.btnPAdd.Margin = New System.Windows.Forms.Padding(120, 24, 60, 24)
            Me.btnPAdd.Name = "btnPAdd"
            Me.btnPAdd.Size = New System.Drawing.Size(100, 40)
            Me.btnPAdd.TabIndex = 11
            Me.btnPAdd.Text = "Add"
            Me.tt.SetToolTip(Me.btnPAdd, "Choose a new audio resource to add to the list of sfx to stop.")
            Me.btnPAdd.UseVisualStyleBackColor = False
            '
            'lvToPlay
            '
            Me.lvToPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lvToPlay.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lvToPlay.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.PcolName, Me.PcolDelay})
            Me.lvToPlay.FullRowSelect = True
            Me.lvToPlay.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me.lvToPlay.HideSelection = False
            Me.lvToPlay.Location = New System.Drawing.Point(4, 48)
            Me.lvToPlay.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.lvToPlay.Name = "lvToPlay"
            Me.lvToPlay.Size = New System.Drawing.Size(519, 136)
            Me.lvToPlay.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lvToPlay.TabIndex = 9
            Me.tt.SetToolTip(Me.lvToPlay, "Double click any item to preview.")
            Me.lvToPlay.UseCompatibleStateImageBehavior = False
            Me.lvToPlay.View = System.Windows.Forms.View.Details
            '
            'PcolName
            '
            Me.PcolName.Text = "Name"
            Me.PcolName.Width = 120
            '
            'PcolDelay
            '
            Me.PcolDelay.Text = "Delay"
            '
            'lbToStop
            '
            Me.lbToStop.AutoSize = True
            Me.lbToStop.Location = New System.Drawing.Point(3, 249)
            Me.lbToStop.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbToStop.Name = "lbToStop"
            Me.lbToStop.Size = New System.Drawing.Size(220, 20)
            Me.lbToStop.TabIndex = 1
            Me.lbToStop.Text = "Sound Effects to Stop (If Playing)"
            '
            'lbToPlay
            '
            Me.lbToPlay.AutoSize = True
            Me.lbToPlay.Location = New System.Drawing.Point(3, 23)
            Me.lbToPlay.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbToPlay.Name = "lbToPlay"
            Me.lbToPlay.Size = New System.Drawing.Size(145, 20)
            Me.lbToPlay.TabIndex = 0
            Me.lbToPlay.Text = "Sound Effects to Play"
            '
            'lvToStop
            '
            Me.lvToStop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lvToStop.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lvToStop.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ScolName, Me.ScolDur, Me.ScolDelay})
            Me.lvToStop.FullRowSelect = True
            Me.lvToStop.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
            Me.lvToStop.HideSelection = False
            Me.lvToStop.Location = New System.Drawing.Point(4, 274)
            Me.lvToStop.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.lvToStop.Name = "lvToStop"
            Me.lvToStop.Size = New System.Drawing.Size(519, 136)
            Me.lvToStop.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lvToStop.TabIndex = 14
            Me.tt.SetToolTip(Me.lvToStop, "Double click any item to preview.")
            Me.lvToStop.UseCompatibleStateImageBehavior = False
            Me.lvToStop.View = System.Windows.Forms.View.Details
            '
            'ScolName
            '
            Me.ScolName.Text = "Name"
            Me.ScolName.Width = 120
            '
            'ScolDur
            '
            Me.ScolDur.Text = "Fade Duration"
            Me.ScolDur.Width = 94
            '
            'ScolDelay
            '
            Me.ScolDelay.Text = "Delay"
            '
            'lbSDelay
            '
            Me.lbSDelay.AutoSize = True
            Me.lbSDelay.Location = New System.Drawing.Point(130, 425)
            Me.lbSDelay.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbSDelay.Name = "lbSDelay"
            Me.lbSDelay.Size = New System.Drawing.Size(55, 20)
            Me.lbSDelay.TabIndex = 39
            Me.lbSDelay.Text = "s Delay"
            Me.tt.SetToolTip(Me.lbSDelay, "Sets the number of seconds after the activation of this cue" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
            Me.lbSDelay.Visible = False
            '
            'tt
            '
            Me.tt.AutoPopDelay = 10000
            Me.tt.InitialDelay = 1000
            Me.tt.ReshowDelay = 500
            '
            'Vw4Cues
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Controls.Add(Me.sideBar)
            Me.Controls.Add(Me.editor)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.Name = "Vw4Cues"
            Me.Size = New System.Drawing.Size(1100, 700)
            Me.sideBar.ResumeLayout(False)
            Me.editor.ResumeLayout(False)
            Me.editor.PerformLayout()
            Me.pnlPJX.ResumeLayout(False)
            Me.pnlPJX.PerformLayout()
            CType(Me.pbPjx, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlLFX.ResumeLayout(False)
            CType(Me.visual, System.ComponentModel.ISupportInitialize).EndInit()
            Me.channelsEditor.ResumeLayout(False)
            Me.channelsEditor.PerformLayout()
            CType(Me.FaderBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlLightSelector.ResumeLayout(False)
            Me.pnlCh.ResumeLayout(False)
            CType(Me.numChID, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFadeTime.ResumeLayout(False)
            Me.pnlFadeTime.PerformLayout()
            Me.pnlSFX.ResumeLayout(False)
            Me.pnlSFX.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents btnDel As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents imgLst As System.Windows.Forms.ImageList
        Friend WithEvents sideBar As System.Windows.Forms.Panel
        Friend WithEvents editor As System.Windows.Forms.Panel
        Friend WithEvents lv As listViewX
        Friend WithEvents colName As System.Windows.Forms.ColumnHeader
        Friend WithEvents btnMvUp As System.Windows.Forms.Button
        Friend WithEvents btnMvDn As System.Windows.Forms.Button
        Friend WithEvents tt As System.Windows.Forms.ToolTip
        Friend WithEvents tabPJX As System.Windows.Forms.Button
        Friend WithEvents tabSFX As System.Windows.Forms.Button
        Friend WithEvents tabLFX As System.Windows.Forms.Button
        Friend WithEvents cbPJX As System.Windows.Forms.CheckBox
        Friend WithEvents cbSFX As System.Windows.Forms.CheckBox
        Friend WithEvents cbLFX As System.Windows.Forms.CheckBox
        Friend WithEvents btnEdit As System.Windows.Forms.Button
        Friend WithEvents lbName As System.Windows.Forms.Label
        Friend WithEvents tbName As System.Windows.Forms.TextBox
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents pnlSFX As System.Windows.Forms.Panel
        Friend WithEvents lvToStop As listViewX
        Friend WithEvents ScolName As System.Windows.Forms.ColumnHeader
        Friend WithEvents ScolDelay As System.Windows.Forms.ColumnHeader
        Friend WithEvents lvToPlay As listViewX
        Friend WithEvents PcolName As System.Windows.Forms.ColumnHeader
        Friend WithEvents PcolDelay As System.Windows.Forms.ColumnHeader
        Friend WithEvents cbStopAll As System.Windows.Forms.CheckBox
        Friend WithEvents lbToStop As System.Windows.Forms.Label
        Friend WithEvents lbToPlay As System.Windows.Forms.Label
        Friend WithEvents pnlPJX As System.Windows.Forms.Panel
        Friend WithEvents pnlLFX As System.Windows.Forms.Panel
        Friend WithEvents FaderBar As CoolTrackBar
        Friend WithEvents visual As System.Windows.Forms.PictureBox
        Friend WithEvents channelsEditor As System.Windows.Forms.Panel
        Friend WithEvents btnFader As System.Windows.Forms.Button
        Friend WithEvents cbType As System.Windows.Forms.ComboBox
        Friend WithEvents lbCh As System.Windows.Forms.Label
        Friend WithEvents btnRemCh As System.Windows.Forms.Button
        Friend WithEvents btnAddCh As System.Windows.Forms.Button
        Friend WithEvents asngLV As listViewX
        Friend WithEvents colID As System.Windows.Forms.ColumnHeader
        Friend WithEvents colChnlName As System.Windows.Forms.ColumnHeader
        Friend WithEvents pnlLightSelector As System.Windows.Forms.Panel
        Friend WithEvents cbLLight As System.Windows.Forms.ComboBox
        Friend WithEvents cbLChTag As System.Windows.Forms.ComboBox
        Friend WithEvents pnlCh As System.Windows.Forms.Panel
        Friend WithEvents numChID As System.Windows.Forms.NumericUpDown
        Friend WithEvents pnlFadeTime As System.Windows.Forms.Panel
        Friend WithEvents lbFadeTimeUnit As System.Windows.Forms.Label
        Friend WithEvents lbFadeTime As System.Windows.Forms.Label
        Friend WithEvents tbFadeTime As System.Windows.Forms.TextBox
        Friend WithEvents btnPRem As System.Windows.Forms.Button
        Friend WithEvents btnPAdd As System.Windows.Forms.Button
        Friend WithEvents btnSRem As System.Windows.Forms.Button
        Friend WithEvents btnSAdd As System.Windows.Forms.Button
        Friend WithEvents tbPDelay As System.Windows.Forms.TextBox
        Friend WithEvents lbPDelay As System.Windows.Forms.Label
        Friend WithEvents lbSDelay As System.Windows.Forms.Label
        Friend WithEvents tbSDelay As System.Windows.Forms.TextBox
        Friend WithEvents btnSChange As System.Windows.Forms.Button
        Friend WithEvents btnPChange As System.Windows.Forms.Button
        Friend WithEvents pbPjx As System.Windows.Forms.PictureBox
        Friend WithEvents btnPjxChoose As System.Windows.Forms.Button
        Friend WithEvents btnPjxPlay As System.Windows.Forms.Button
        Friend WithEvents cbPjxEffect As System.Windows.Forms.ComboBox
        Friend WithEvents tbPJXDur As System.Windows.Forms.TextBox
        Friend WithEvents tbPJXDelay As System.Windows.Forms.TextBox
        Friend WithEvents lbPJXDelay As System.Windows.Forms.Label
        Friend WithEvents lbPJXDur As System.Windows.Forms.Label
        Friend WithEvents lbPjx As System.Windows.Forms.Label
        Friend WithEvents lbFadeDelayUnit As System.Windows.Forms.Label
        Friend WithEvents lbFadeDelay As System.Windows.Forms.Label
        Friend WithEvents tbFadeDelay As System.Windows.Forms.TextBox
        Friend WithEvents tbSFade As System.Windows.Forms.TextBox
        Friend WithEvents lbSFade As System.Windows.Forms.Label
        Friend WithEvents ScolDur As System.Windows.Forms.ColumnHeader
        Friend WithEvents tbAllFade As System.Windows.Forms.TextBox
        Friend WithEvents lbAllFade As System.Windows.Forms.Label
        Friend WithEvents tbAllDelay As System.Windows.Forms.TextBox
        Friend WithEvents lbP As System.Windows.Forms.Label
        Friend WithEvents bottomDummy As System.Windows.Forms.Panel

    End Class
End NameSpace