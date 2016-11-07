Imports Entity._5Controls

Namespace _0App
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Frm5ShowUi
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm5ShowUi))
        Me.imglst = New System.Windows.Forms.ImageList(Me.components)
        Me.projBar = New System.Windows.Forms.Panel()
        Me.lbShow = New System.Windows.Forms.Label()
        Me.viewer = New System.Windows.Forms.Panel()
        Me.pnlCue = New System.Windows.Forms.Panel()
        Me.btnViewEdit = New System.Windows.Forms.Button()
            Me.pnlSf = New System.Windows.Forms.Panel()
            Me.pnlSOpts = New System.Windows.Forms.Panel()
            Me.btnSPlay = New System.Windows.Forms.Button()
            Me.btnSStop = New System.Windows.Forms.Button()
            Me.btnSStopAll = New System.Windows.Forms.Button()
            Me.pbLts = New System.Windows.Forms.PictureBox()
            Me.pnlPj = New System.Windows.Forms.Panel()
            Me.btnPCh = New System.Windows.Forms.Button()
            Me.btnPBO = New System.Windows.Forms.Button()
            Me.pbPj = New System.Windows.Forms.PictureBox()
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
            Me.CueSlider = New Entity._5Controls.Slider()
            Me.lvSf = New Entity._5Controls.listViewX()
            Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colStatus = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.TopBar1 = New Entity._5Controls.ShowHeaderBar()
            Me.projBar.SuspendLayout()
            Me.viewer.SuspendLayout()
            Me.pnlCue.SuspendLayout()
            Me.pnlSf.SuspendLayout()
            Me.pnlSOpts.SuspendLayout()
            CType(Me.pbLts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlPj.SuspendLayout()
            CType(Me.pbPj, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'imglst
            '
            Me.imglst.ImageStream = CType(resources.GetObject("imglst.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imglst.TransparentColor = System.Drawing.Color.Transparent
            Me.imglst.Images.SetKeyName(0, "Headphones.ico")
            '
            'projBar
            '
            Me.projBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.projBar.Controls.Add(Me.lbShow)
            Me.projBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.projBar.Location = New System.Drawing.Point(0, 50)
            Me.projBar.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.projBar.Name = "projBar"
            Me.projBar.Size = New System.Drawing.Size(1344, 84)
            Me.projBar.TabIndex = 2
            '
            'lbShow
            '
            Me.lbShow.AutoSize = True
            Me.lbShow.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbShow.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.lbShow.Location = New System.Drawing.Point(38, 28)
            Me.lbShow.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbShow.Name = "lbShow"
            Me.lbShow.Size = New System.Drawing.Size(86, 25)
            Me.lbShow.TabIndex = 11
            Me.lbShow.Text = "My Show"
            '
            'viewer
            '
            Me.viewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.viewer.AutoScroll = True
            Me.viewer.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.viewer.Controls.Add(Me.pnlCue)
            Me.viewer.Controls.Add(Me.pnlSf)
            Me.viewer.Controls.Add(Me.pbLts)
            Me.viewer.Controls.Add(Me.pnlPj)
            Me.viewer.Location = New System.Drawing.Point(0, 134)
            Me.viewer.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.viewer.Name = "viewer"
            Me.viewer.Size = New System.Drawing.Size(1344, 524)
            Me.viewer.TabIndex = 0
            '
            'pnlCue
            '
            Me.pnlCue.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.pnlCue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
            Me.pnlCue.Controls.Add(Me.btnViewEdit)
            Me.pnlCue.Controls.Add(Me.CueSlider)
            Me.pnlCue.Location = New System.Drawing.Point(550, 200)
            Me.pnlCue.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.pnlCue.Name = "pnlCue"
            Me.pnlCue.Size = New System.Drawing.Size(550, 200)
            Me.pnlCue.TabIndex = 2
            '
            'btnViewEdit
            '
            Me.btnViewEdit.BackColor = System.Drawing.Color.Gainsboro
            Me.btnViewEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnViewEdit.FlatAppearance.BorderSize = 0
            Me.btnViewEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnViewEdit.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnViewEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnViewEdit.Location = New System.Drawing.Point(30, 92)
            Me.btnViewEdit.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.btnViewEdit.Name = "btnViewEdit"
            Me.btnViewEdit.Size = New System.Drawing.Size(120, 35)
            Me.btnViewEdit.TabIndex = 0
            Me.btnViewEdit.Text = "View + Edit"
            Me.tt.SetToolTip(Me.btnViewEdit, "Click to view and edit your cues.")
            Me.btnViewEdit.UseVisualStyleBackColor = False
            '
            'pnlSf
            '
            Me.pnlSf.AutoScroll = True
            Me.pnlSf.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.pnlSf.Controls.Add(Me.lvSf)
            Me.pnlSf.Controls.Add(Me.pnlSOpts)
            Me.pnlSf.ForeColor = System.Drawing.Color.White
            Me.pnlSf.Location = New System.Drawing.Point(0, 200)
            Me.pnlSf.Margin = New System.Windows.Forms.Padding(48, 27, 48, 27)
            Me.pnlSf.Name = "pnlSf"
            Me.pnlSf.Size = New System.Drawing.Size(550, 200)
            Me.pnlSf.TabIndex = 1
            Me.tt.SetToolTip(Me.pnlSf, "A list of sound effects being played." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Right click to show/hide options.")
            '
            'pnlSOpts
            '
            Me.pnlSOpts.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlSOpts.Controls.Add(Me.btnSPlay)
            Me.pnlSOpts.Controls.Add(Me.btnSStop)
            Me.pnlSOpts.Controls.Add(Me.btnSStopAll)
            Me.pnlSOpts.Location = New System.Drawing.Point(78, 145)
            Me.pnlSOpts.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.pnlSOpts.Name = "pnlSOpts"
            Me.pnlSOpts.Size = New System.Drawing.Size(472, 55)
            Me.pnlSOpts.TabIndex = 1
            Me.tt.SetToolTip(Me.pnlSOpts, "A list of sound effects being played." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Right click to show/hide options.")
            Me.pnlSOpts.Visible = False
            '
            'btnSPlay
            '
            Me.btnSPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSPlay.BackColor = System.Drawing.Color.Gainsboro
            Me.btnSPlay.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnSPlay.FlatAppearance.BorderSize = 0
            Me.btnSPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSPlay.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSPlay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnSPlay.Location = New System.Drawing.Point(87, 10)
            Me.btnSPlay.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.btnSPlay.Name = "btnSPlay"
            Me.btnSPlay.Size = New System.Drawing.Size(120, 35)
            Me.btnSPlay.TabIndex = 2
            Me.btnSPlay.Text = "Play"
            Me.tt.SetToolTip(Me.btnSPlay, "Select a sound effect to play.")
            Me.btnSPlay.UseVisualStyleBackColor = False
            '
            'btnSStop
            '
            Me.btnSStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSStop.BackColor = System.Drawing.Color.Gainsboro
            Me.btnSStop.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnSStop.Enabled = False
            Me.btnSStop.FlatAppearance.BorderSize = 0
            Me.btnSStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSStop.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSStop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnSStop.Location = New System.Drawing.Point(213, 10)
            Me.btnSStop.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.btnSStop.Name = "btnSStop"
            Me.btnSStop.Size = New System.Drawing.Size(120, 35)
            Me.btnSStop.TabIndex = 1
            Me.btnSStop.Text = "Stop"
            Me.tt.SetToolTip(Me.btnSStop, "Stop the selected sound effect.")
            Me.btnSStop.UseVisualStyleBackColor = False
            '
            'btnSStopAll
            '
            Me.btnSStopAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSStopAll.BackColor = System.Drawing.Color.Gainsboro
            Me.btnSStopAll.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnSStopAll.FlatAppearance.BorderSize = 0
            Me.btnSStopAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSStopAll.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSStopAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnSStopAll.Location = New System.Drawing.Point(338, 10)
            Me.btnSStopAll.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.btnSStopAll.Name = "btnSStopAll"
            Me.btnSStopAll.Size = New System.Drawing.Size(120, 35)
            Me.btnSStopAll.TabIndex = 0
            Me.btnSStopAll.Text = "Stop All"
            Me.tt.SetToolTip(Me.btnSStopAll, "Stop all sound effects immediately.")
            Me.btnSStopAll.UseVisualStyleBackColor = False
            '
            'pbLts
            '
            Me.pbLts.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.pbLts.Location = New System.Drawing.Point(550, 0)
            Me.pbLts.Margin = New System.Windows.Forms.Padding(36, 16, 36, 0)
            Me.pbLts.Name = "pbLts"
            Me.pbLts.Size = New System.Drawing.Size(550, 200)
            Me.pbLts.TabIndex = 23
            Me.pbLts.TabStop = False
            Me.tt.SetToolTip(Me.pbLts, "A visualisation of your lights." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You are currently in viewing (grey) mode." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Rig" & _
            "ht click to enter editing (blue) mode." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(You can turn lights on or off in editin" & _
            "g mode)")
            '
            'pnlPj
            '
            Me.pnlPj.Controls.Add(Me.btnPCh)
            Me.pnlPj.Controls.Add(Me.btnPBO)
            Me.pnlPj.Controls.Add(Me.pbPj)
            Me.pnlPj.Location = New System.Drawing.Point(0, 0)
            Me.pnlPj.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.pnlPj.Name = "pnlPj"
            Me.pnlPj.Size = New System.Drawing.Size(550, 200)
            Me.pnlPj.TabIndex = 0
            '
            'btnPCh
            '
            Me.btnPCh.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnPCh.BackColor = System.Drawing.Color.Gainsboro
            Me.btnPCh.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnPCh.FlatAppearance.BorderSize = 0
            Me.btnPCh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPCh.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPCh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnPCh.Location = New System.Drawing.Point(281, 16)
            Me.btnPCh.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.btnPCh.Name = "btnPCh"
            Me.btnPCh.Size = New System.Drawing.Size(120, 35)
            Me.btnPCh.TabIndex = 1
            Me.btnPCh.Text = "Change"
            Me.tt.SetToolTip(Me.btnPCh, "Select another image to display.")
            Me.btnPCh.UseVisualStyleBackColor = False
            Me.btnPCh.Visible = False
            '
            'btnPBO
            '
            Me.btnPBO.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnPBO.BackColor = System.Drawing.Color.Gainsboro
            Me.btnPBO.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnPBO.FlatAppearance.BorderSize = 0
            Me.btnPBO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPBO.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPBO.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnPBO.Location = New System.Drawing.Point(411, 16)
            Me.btnPBO.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.btnPBO.Name = "btnPBO"
            Me.btnPBO.Size = New System.Drawing.Size(120, 35)
            Me.btnPBO.TabIndex = 0
            Me.btnPBO.Text = "Black Out"
            Me.tt.SetToolTip(Me.btnPBO, "Blacks out the projector immediately")
            Me.btnPBO.UseVisualStyleBackColor = False
            Me.btnPBO.Visible = False
            '
            'pbPj
            '
            Me.pbPj.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.pbPj.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pbPj.Location = New System.Drawing.Point(0, 0)
            Me.pbPj.Margin = New System.Windows.Forms.Padding(36, 16, 36, 16)
            Me.pbPj.Name = "pbPj"
            Me.pbPj.Size = New System.Drawing.Size(550, 200)
            Me.pbPj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pbPj.TabIndex = 0
            Me.pbPj.TabStop = False
            Me.pbPj.Tag = "_pv"
            '
            'tt
            '
            Me.tt.AutoPopDelay = 4000
            Me.tt.InitialDelay = 1000
            Me.tt.ReshowDelay = 1000
            '
            'CueSlider
            '
            Me.CueSlider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.CueSlider.ArrowColor = System.Drawing.Color.DarkGray
            Me.CueSlider.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.CueSlider.BarColor1 = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CueSlider.DraggingSliderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
            Me.CueSlider.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.CueSlider.InitialSliderLocation = -100.0!
            Me.CueSlider.LeftText = ""
            Me.CueSlider.Location = New System.Drawing.Point(30, 136)
            Me.CueSlider.Margin = New System.Windows.Forms.Padding(48, 21, 48, 21)
            Me.CueSlider.Name = "CueSlider"
            Me.CueSlider.RightText = "Next Cue"
            Me.CueSlider.Size = New System.Drawing.Size(250, 43)
            Me.CueSlider.SliderColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
            Me.CueSlider.SliderLocation = -100.0!
            Me.CueSlider.TabIndex = 1
            Me.CueSlider.TextColor = System.Drawing.Color.White
            Me.tt.SetToolTip(Me.CueSlider, "Slide the slider to the right end of the bar to proceed to the next cue")
            '
            'lvSf
            '
            Me.lvSf.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lvSf.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lvSf.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.lvSf.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lvSf.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colStatus})
            Me.lvSf.Font = New System.Drawing.Font("Segoe UI Semilight", 11.0!)
            Me.lvSf.ForeColor = System.Drawing.Color.White
            Me.lvSf.FullRowSelect = True
            Me.lvSf.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lvSf.HideSelection = False
            Me.lvSf.Location = New System.Drawing.Point(23, 15)
            Me.lvSf.Margin = New System.Windows.Forms.Padding(48, 27, 48, 27)
            Me.lvSf.Name = "lvSf"
            Me.lvSf.Size = New System.Drawing.Size(499, 130)
            Me.lvSf.SmallImageList = Me.imglst
            Me.lvSf.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lvSf.TabIndex = 0
            Me.tt.SetToolTip(Me.lvSf, "A list of sound effects being played." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Right click to show/hide options.")
            Me.lvSf.UseCompatibleStateImageBehavior = False
            Me.lvSf.View = System.Windows.Forms.View.Details
            '
            'colName
            '
            Me.colName.Text = "Name"
            '
            'colStatus
            '
            Me.colStatus.Text = "Status"
            '
            'TopBar1
            '
            Me.TopBar1.Dock = System.Windows.Forms.DockStyle.Top
            Me.TopBar1.Location = New System.Drawing.Point(0, 0)
            Me.TopBar1.Margin = New System.Windows.Forms.Padding(48, 21, 48, 21)
            Me.TopBar1.Name = "TopBar1"
            Me.TopBar1.Size = New System.Drawing.Size(1344, 50)
            Me.TopBar1.TabIndex = 1
            '
            'Frm5ShowUi
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1344, 658)
            Me.Controls.Add(Me.projBar)
            Me.Controls.Add(Me.viewer)
            Me.Controls.Add(Me.TopBar1)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Margin = New System.Windows.Forms.Padding(48, 21, 48, 21)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Frm5ShowUi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entity System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.projBar.ResumeLayout(false)
        Me.projBar.PerformLayout
        Me.viewer.ResumeLayout(false)
        Me.pnlCue.ResumeLayout(false)
        Me.pnlSf.ResumeLayout(false)
        Me.pnlSOpts.ResumeLayout(false)
        CType(Me.pbLts,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlPj.ResumeLayout(false)
        CType(Me.pbPj,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
        Friend WithEvents imglst As System.Windows.Forms.ImageList
        Friend WithEvents projBar As System.Windows.Forms.Panel
        Friend WithEvents lbShow As System.Windows.Forms.Label
        Friend WithEvents viewer As System.Windows.Forms.Panel
        Friend WithEvents tt As System.Windows.Forms.ToolTip
        Friend WithEvents pbPj As System.Windows.Forms.PictureBox
        Friend WithEvents pbLts As System.Windows.Forms.PictureBox
        Friend WithEvents pnlSf As System.Windows.Forms.Panel
        Friend WithEvents lvSf As listViewX
        Friend WithEvents colName As System.Windows.Forms.ColumnHeader
        Friend WithEvents pnlCue As System.Windows.Forms.Panel
        Friend WithEvents btnViewEdit As System.Windows.Forms.Button
        Friend WithEvents CueSlider As Slider
        Friend WithEvents colStatus As System.Windows.Forms.ColumnHeader
        Friend WithEvents TopBar1 As ShowHeaderBar
        Friend WithEvents btnPBO As System.Windows.Forms.Button
        Friend WithEvents btnPCh As System.Windows.Forms.Button
        Friend WithEvents btnSStop As System.Windows.Forms.Button
        Friend WithEvents btnSStopAll As System.Windows.Forms.Button
        Friend WithEvents btnSPlay As System.Windows.Forms.Button
        Friend WithEvents pnlPj As System.Windows.Forms.Panel
        Friend WithEvents pnlSOpts As System.Windows.Forms.Panel

    End Class
End Namespace