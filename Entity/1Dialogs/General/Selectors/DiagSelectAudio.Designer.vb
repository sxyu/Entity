Imports Entity._5Controls

Namespace _1Dialogs.General.Selectors
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagSelectAudio
        Inherits System.Windows.Forms.Form

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
                Try
                    If disposing Then
                        _audioFileReader.Dispose()
                    End If
                Catch ex As Exception
                End Try
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
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.sideBar = New System.Windows.Forms.Panel()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.editor = New System.Windows.Forms.Panel()
            Me.lbKF = New System.Windows.Forms.Label()
            Me.fader = New Entity._5Controls.PercentSetter()
            Me.btnKeyFrame = New System.Windows.Forms.Button()
            Me.btnLater = New System.Windows.Forms.Button()
            Me.btnEarlier = New System.Windows.Forms.Button()
            Me.waveForm = New System.Windows.Forms.PictureBox()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.lbTime = New System.Windows.Forms.Label()
            Me.btnEdit = New System.Windows.Forms.Button()
            Me.lbName = New System.Windows.Forms.Label()
            Me.btnStop = New System.Windows.Forms.Button()
            Me.btnPlay = New System.Windows.Forms.Button()
            Me.timerLineMove = New System.Windows.Forms.Timer(Me.components)
            Me.timerMicroMove = New System.Windows.Forms.Timer(Me.components)
            Me.title = New System.Windows.Forms.Label()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.btnSelect = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lbDelay = New System.Windows.Forms.Label()
            Me.tbDelay = New System.Windows.Forms.TextBox()
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
            Me.lbDur = New System.Windows.Forms.Label()
            Me.tbDur = New System.Windows.Forms.TextBox()
            Me.sideBar.SuspendLayout()
            Me.editor.SuspendLayout()
            CType(Me.waveForm, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'imgLst
            '
            Me.imgLst.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
            Me.imgLst.ImageSize = New System.Drawing.Size(16, 16)
            Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
            '
            'sideBar
            '
            Me.sideBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.sideBar.AutoScroll = True
            Me.sideBar.BackColor = System.Drawing.Color.Gainsboro
            Me.sideBar.Controls.Add(Me.lv)
            Me.sideBar.Location = New System.Drawing.Point(27, 50)
            Me.sideBar.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.sideBar.Name = "sideBar"
            Me.sideBar.Size = New System.Drawing.Size(311, 404)
            Me.sideBar.TabIndex = 1
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lv.BackColor = System.Drawing.Color.Gainsboro
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName})
            Me.lv.Font = New System.Drawing.Font("Segoe UI Semilight", 11.0!)
            Me.lv.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            Me.lv.Location = New System.Drawing.Point(21, 24)
            Me.lv.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.lv.MultiSelect = False
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(271, 348)
            Me.lv.SmallImageList = Me.imgLst
            Me.lv.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lv.TabIndex = 0
            Me.tt.SetToolTip(Me.lv, "Select the sound effect you wish to play/stop from this box." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "While selected, y" & _
            "ou can also edit the sound effect with the editor box on the right.")
            Me.lv.UseCompatibleStateImageBehavior = False
            Me.lv.View = System.Windows.Forms.View.Details
            '
            'colName
            '
            Me.colName.Text = "Name"
            '
            'tbName
            '
            Me.tbName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbName.Font = New System.Drawing.Font("Segoe UI Semilight", 12.25!)
            Me.tbName.Location = New System.Drawing.Point(29, 28)
            Me.tbName.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.tbName.MaxLength = 30
            Me.tbName.Name = "tbName"
            Me.tbName.Size = New System.Drawing.Size(626, 29)
            Me.tbName.TabIndex = 1
            '
            'editor
            '
            Me.editor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.editor.AutoScroll = True
            Me.editor.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.editor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.editor.Controls.Add(Me.lbKF)
            Me.editor.Controls.Add(Me.fader)
            Me.editor.Controls.Add(Me.btnKeyFrame)
            Me.editor.Controls.Add(Me.btnLater)
            Me.editor.Controls.Add(Me.btnEarlier)
            Me.editor.Controls.Add(Me.waveForm)
            Me.editor.Controls.Add(Me.lbWarning)
            Me.editor.Controls.Add(Me.lbTime)
            Me.editor.Controls.Add(Me.btnEdit)
            Me.editor.Controls.Add(Me.lbName)
            Me.editor.Controls.Add(Me.btnStop)
            Me.editor.Controls.Add(Me.btnPlay)
            Me.editor.Controls.Add(Me.tbName)
            Me.editor.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.editor.Location = New System.Drawing.Point(353, 50)
            Me.editor.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.editor.Name = "editor"
            Me.editor.Size = New System.Drawing.Size(715, 402)
            Me.editor.TabIndex = 1
            Me.editor.Visible = False
            '
            'lbKF
            '
            Me.lbKF.AutoSize = True
            Me.lbKF.ForeColor = System.Drawing.Color.White
            Me.lbKF.Location = New System.Drawing.Point(25, 278)
            Me.lbKF.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbKF.Name = "lbKF"
            Me.lbKF.Size = New System.Drawing.Size(166, 20)
            Me.lbKF.TabIndex = 11
            Me.lbKF.Text = "Volume Keyframe Editor"
            '
            'fader
            '
            Me.fader.AccuracyDigits = 0
            Me.fader.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.fader.BackColor = System.Drawing.Color.WhiteSmoke
            Me.fader.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.fader.ForeColor = System.Drawing.Color.White
            Me.fader.Location = New System.Drawing.Point(29, 309)
            Me.fader.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.fader.Name = "fader"
            Me.fader.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.fader.ProgressText = Nothing
            Me.fader.RightClickEnabled = True
            Me.fader.Size = New System.Drawing.Size(435, 40)
            Me.fader.TabIndex = 6
            Me.tt.SetToolTip(Me.fader, "Displays the current volume level." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If a keyframe is selected, this can also be" & _
            " used to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "adjust the volume of the keyframe.")
            Me.fader.Value = 50.0R
            Me.fader.Vertical = False
            '
            'btnKeyFrame
            '
            Me.btnKeyFrame.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnKeyFrame.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnKeyFrame.FlatAppearance.BorderSize = 0
            Me.btnKeyFrame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnKeyFrame.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnKeyFrame.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnKeyFrame.ForeColor = System.Drawing.Color.White
            Me.btnKeyFrame.Location = New System.Drawing.Point(474, 309)
            Me.btnKeyFrame.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnKeyFrame.Name = "btnKeyFrame"
            Me.btnKeyFrame.Size = New System.Drawing.Size(210, 40)
            Me.btnKeyFrame.TabIndex = 7
            Me.btnKeyFrame.TabStop = False
            Me.btnKeyFrame.Text = "&Add Volume Keyframe"
            Me.btnKeyFrame.UseVisualStyleBackColor = False
            '
            'btnLater
            '
            Me.btnLater.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnLater.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnLater.FlatAppearance.BorderSize = 0
            Me.btnLater.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnLater.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnLater.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLater.ForeColor = System.Drawing.Color.White
            Me.btnLater.Location = New System.Drawing.Point(855, 223)
            Me.btnLater.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnLater.Name = "btnLater"
            Me.btnLater.Size = New System.Drawing.Size(40, 40)
            Me.btnLater.TabIndex = 3
            Me.btnLater.TabStop = False
            Me.btnLater.Text = "&>"
            Me.tt.SetToolTip(Me.btnLater, "Move later in time." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hotkey: Right Arrow")
            Me.btnLater.UseVisualStyleBackColor = False
            '
            'btnEarlier
            '
            Me.btnEarlier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnEarlier.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnEarlier.FlatAppearance.BorderSize = 0
            Me.btnEarlier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnEarlier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEarlier.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEarlier.ForeColor = System.Drawing.Color.White
            Me.btnEarlier.Location = New System.Drawing.Point(810, 223)
            Me.btnEarlier.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnEarlier.Name = "btnEarlier"
            Me.btnEarlier.Size = New System.Drawing.Size(40, 40)
            Me.btnEarlier.TabIndex = 2
            Me.btnEarlier.TabStop = False
            Me.btnEarlier.Text = "&<"
            Me.tt.SetToolTip(Me.btnEarlier, "Move earlier in time." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hotkey: Left Arrow")
            Me.btnEarlier.UseVisualStyleBackColor = False
            '
            'waveForm
            '
            Me.waveForm.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.waveForm.BackColor = System.Drawing.Color.CornflowerBlue
            Me.waveForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.waveForm.Location = New System.Drawing.Point(29, 86)
            Me.waveForm.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.waveForm.Name = "waveForm"
            Me.waveForm.Size = New System.Drawing.Size(655, 125)
            Me.waveForm.TabIndex = 21
            Me.waveForm.TabStop = False
            '
            'lbWarning
            '
            Me.lbWarning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbWarning.ForeColor = System.Drawing.Color.White
            Me.lbWarning.Location = New System.Drawing.Point(39, 56)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(1101, 28)
            Me.lbWarning.TabIndex = 9
            Me.lbWarning.Text = "Warning"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lbTime
            '
            Me.lbTime.AutoSize = True
            Me.lbTime.ForeColor = System.Drawing.Color.White
            Me.lbTime.Location = New System.Drawing.Point(25, 223)
            Me.lbTime.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbTime.Name = "lbTime"
            Me.lbTime.Size = New System.Drawing.Size(93, 20)
            Me.lbTime.TabIndex = 10
            Me.lbTime.Text = "0:000 / 0:000"
            '
            'btnEdit
            '
            Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnEdit.FlatAppearance.BorderSize = 0
            Me.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral
            Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnEdit.Image = Global.Entity.My.Resources.Resources.EditBtn
            Me.btnEdit.Location = New System.Drawing.Point(655, 28)
            Me.btnEdit.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnEdit.Name = "btnEdit"
            Me.btnEdit.Size = New System.Drawing.Size(29, 29)
            Me.btnEdit.TabIndex = 0
            Me.btnEdit.TabStop = False
            Me.tt.SetToolTip(Me.btnEdit, "When not editing: (Color.fromArgb(100, 100, 100))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click to edit the name of this" & _
            " audio resource." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "When editing: (Red)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Left click to confirm edit, or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "right c" & _
            "lick to cancel.")
            Me.btnEdit.UseVisualStyleBackColor = False
            '
            'lbName
            '
            Me.lbName.AutoSize = True
            Me.lbName.Font = New System.Drawing.Font("Segoe UI Semilight", 12.25!)
            Me.lbName.ForeColor = System.Drawing.Color.White
            Me.lbName.Location = New System.Drawing.Point(29, 31)
            Me.lbName.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbName.Name = "lbName"
            Me.lbName.Size = New System.Drawing.Size(56, 23)
            Me.lbName.TabIndex = 8
            Me.lbName.Text = "Label1"
            '
            'btnStop
            '
            Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnStop.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnStop.FlatAppearance.BorderSize = 0
            Me.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnStop.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnStop.ForeColor = System.Drawing.Color.White
            Me.btnStop.Location = New System.Drawing.Point(1040, 223)
            Me.btnStop.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnStop.Name = "btnStop"
            Me.btnStop.Size = New System.Drawing.Size(130, 40)
            Me.btnStop.TabIndex = 4
            Me.btnStop.TabStop = False
            Me.btnStop.Text = "Reset"
            Me.tt.SetToolTip(Me.btnStop, "Resets the effect to its initial position." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hotkey: R")
            Me.btnStop.UseVisualStyleBackColor = False
            '
            'btnPlay
            '
            Me.btnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPlay.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnPlay.FlatAppearance.BorderSize = 0
            Me.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPlay.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPlay.ForeColor = System.Drawing.Color.White
            Me.btnPlay.Location = New System.Drawing.Point(905, 223)
            Me.btnPlay.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnPlay.Name = "btnPlay"
            Me.btnPlay.Size = New System.Drawing.Size(130, 40)
            Me.btnPlay.TabIndex = 5
            Me.btnPlay.TabStop = False
            Me.btnPlay.Text = "&Play"
            Me.tt.SetToolTip(Me.btnPlay, "Hotkey: Space")
            Me.btnPlay.UseVisualStyleBackColor = False
            '
            'timerLineMove
            '
            Me.timerLineMove.Interval = 150
            '
            'timerMicroMove
            '
            Me.timerMicroMove.Interval = 20
            '
            'title
            '
            Me.title.AutoSize = True
            Me.title.Location = New System.Drawing.Point(23, 18)
            Me.title.Name = "title"
            Me.title.Size = New System.Drawing.Size(0, 20)
            Me.title.TabIndex = 45
            '
            'btnClose
            '
            Me.btnClose.FlatAppearance.BorderSize = 0
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.Location = New System.Drawing.Point(1061, 2)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 44
            Me.btnClose.Text = "x"
            '
            'btnSelect
            '
            Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSelect.BackColor = System.Drawing.Color.Gainsboro
            Me.btnSelect.FlatAppearance.BorderSize = 0
            Me.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSelect.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelect.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.btnSelect.Location = New System.Drawing.Point(938, 473)
            Me.btnSelect.Margin = New System.Windows.Forms.Padding(60, 24, 60, 48)
            Me.btnSelect.Name = "btnSelect"
            Me.btnSelect.Size = New System.Drawing.Size(130, 40)
            Me.btnSelect.TabIndex = 15
            Me.btnSelect.Text = "&OK"
            Me.btnSelect.UseVisualStyleBackColor = False
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatAppearance.BorderSize = 0
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.btnCancel.Location = New System.Drawing.Point(803, 473)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(60, 24, 60, 48)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(130, 40)
            Me.btnCancel.TabIndex = 14
            Me.btnCancel.Text = "&Cancel"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'lbDelay
            '
            Me.lbDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lbDelay.AutoSize = True
            Me.lbDelay.Location = New System.Drawing.Point(363, 483)
            Me.lbDelay.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbDelay.Name = "lbDelay"
            Me.lbDelay.Size = New System.Drawing.Size(55, 20)
            Me.lbDelay.TabIndex = 41
            Me.lbDelay.Text = "s Delay"
            '
            'tbDelay
            '
            Me.tbDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tbDelay.Location = New System.Drawing.Point(261, 480)
            Me.tbDelay.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbDelay.MaxLength = 5
            Me.tbDelay.Name = "tbDelay"
            Me.tbDelay.Size = New System.Drawing.Size(100, 27)
            Me.tbDelay.TabIndex = 13
            Me.tbDelay.Text = "0.0"
            '
            'lbDur
            '
            Me.lbDur.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lbDur.AutoSize = True
            Me.lbDur.Location = New System.Drawing.Point(129, 483)
            Me.lbDur.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbDur.Name = "lbDur"
            Me.lbDur.Size = New System.Drawing.Size(110, 20)
            Me.lbDur.TabIndex = 43
            Me.lbDur.Text = "s Fade Duration"
            Me.lbDur.Visible = False
            '
            'tbDur
            '
            Me.tbDur.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tbDur.Location = New System.Drawing.Point(27, 480)
            Me.tbDur.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbDur.MaxLength = 5
            Me.tbDur.Name = "tbDur"
            Me.tbDur.Size = New System.Drawing.Size(100, 27)
            Me.tbDur.TabIndex = 12
            Me.tbDur.Text = "0.0"
            Me.tbDur.Visible = False
            '
            'DiagSelectAudio
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(1098, 537)
            Me.Controls.Add(Me.lbDur)
            Me.Controls.Add(Me.tbDur)
            Me.Controls.Add(Me.lbDelay)
            Me.Controls.Add(Me.tbDelay)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSelect)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.title)
            Me.Controls.Add(Me.sideBar)
            Me.Controls.Add(Me.editor)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.Color.White
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.Name = "DiagSelectAudio"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.sideBar.ResumeLayout(False)
            Me.editor.ResumeLayout(False)
            Me.editor.PerformLayout()
            CType(Me.waveForm, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents imgLst As System.Windows.Forms.ImageList
        Friend WithEvents sideBar As System.Windows.Forms.Panel
        Friend WithEvents tbName As System.Windows.Forms.TextBox
        Friend WithEvents editor As System.Windows.Forms.Panel
        Friend WithEvents lbName As System.Windows.Forms.Label
        Friend WithEvents btnEdit As System.Windows.Forms.Button
        Friend WithEvents timerLineMove As System.Windows.Forms.Timer
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents timerMicroMove As System.Windows.Forms.Timer
        Friend WithEvents lbKF As System.Windows.Forms.Label
        Friend WithEvents fader As percentSetter
        Friend WithEvents btnKeyFrame As System.Windows.Forms.Button
        Friend WithEvents btnLater As System.Windows.Forms.Button
        Friend WithEvents btnEarlier As System.Windows.Forms.Button
        Friend WithEvents waveForm As System.Windows.Forms.PictureBox
        Friend WithEvents lbTime As System.Windows.Forms.Label
        Friend WithEvents btnStop As System.Windows.Forms.Button
        Friend WithEvents btnPlay As System.Windows.Forms.Button
        Friend WithEvents lv As listViewX
        Friend WithEvents colName As System.Windows.Forms.ColumnHeader
        Friend WithEvents title As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents btnSelect As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lbDelay As System.Windows.Forms.Label
        Friend WithEvents tbDelay As System.Windows.Forms.TextBox
        Friend WithEvents tt As System.Windows.Forms.ToolTip
        Friend WithEvents lbDur As System.Windows.Forms.Label
        Friend WithEvents tbDur As System.Windows.Forms.TextBox

    End Class
End NameSpace