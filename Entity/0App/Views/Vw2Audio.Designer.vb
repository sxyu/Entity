Imports Entity._5Controls

Namespace _0App.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Vw2Audio
        Inherits System.Windows.Forms.UserControl

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
            Me.btnDel = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
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
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
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
            'btnDel
            '
            Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnDel.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnDel.Enabled = False
            Me.btnDel.FlatAppearance.BorderSize = 0
            Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDel.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDel.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnDel.Location = New System.Drawing.Point(162, 587)
            Me.btnDel.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnDel.Name = "btnDel"
            Me.btnDel.Size = New System.Drawing.Size(130, 40)
            Me.btnDel.TabIndex = 2
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
            Me.btnAdd.Location = New System.Drawing.Point(21, 587)
            Me.btnAdd.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(130, 40)
            Me.btnAdd.TabIndex = 1
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
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(271, 548)
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
            'tbName
            '
            Me.tbName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbName.Font = New System.Drawing.Font("Segoe UI Semilight", 12.25!)
            Me.tbName.Location = New System.Drawing.Point(29, 28)
            Me.tbName.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.tbName.MaxLength = 30
            Me.tbName.Name = "tbName"
            Me.tbName.Size = New System.Drawing.Size(577, 29)
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
            Me.editor.Location = New System.Drawing.Point(353, 39)
            Me.editor.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.editor.Name = "editor"
            Me.editor.Size = New System.Drawing.Size(727, 637)
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
            Me.fader.Size = New System.Drawing.Size(386, 40)
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
            Me.btnKeyFrame.Location = New System.Drawing.Point(426, 309)
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
            Me.btnLater.Location = New System.Drawing.Point(321, 223)
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
            Me.btnEarlier.Location = New System.Drawing.Point(276, 223)
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
            Me.waveForm.Size = New System.Drawing.Size(607, 125)
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
            Me.lbWarning.Size = New System.Drawing.Size(567, 28)
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
            Me.btnEdit.Location = New System.Drawing.Point(607, 28)
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
            Me.btnStop.Location = New System.Drawing.Point(506, 223)
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
            Me.btnPlay.Location = New System.Drawing.Point(371, 223)
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
            'Vw2Audio
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Controls.Add(Me.sideBar)
            Me.Controls.Add(Me.editor)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.Name = "Vw2Audio"
            Me.Size = New System.Drawing.Size(1100, 700)
            Me.sideBar.ResumeLayout(False)
            Me.editor.ResumeLayout(False)
            Me.editor.PerformLayout()
            CType(Me.waveForm, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents tt As System.Windows.Forms.ToolTip

    End Class
End Namespace