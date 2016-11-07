Imports Entity._5Controls

Namespace _0App
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Frm3Viewer
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm3Viewer))
            Me.imglst = New System.Windows.Forms.ImageList(Me.components)
            Me.projBar = New System.Windows.Forms.Panel()
            Me.tbEdit = New System.Windows.Forms.TextBox()
            Me.btnEdit = New System.Windows.Forms.Button()
            Me.btnAppChProj = New System.Windows.Forms.Button()
            Me.lbShow = New System.Windows.Forms.Label()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.viewer = New System.Windows.Forms.Panel()
            Me.tabsflow = New System.Windows.Forms.FlowLayoutPanel()
            Me.tabHome = New System.Windows.Forms.Button()
            Me.tabSubs = New System.Windows.Forms.Button()
            Me.tabAud = New System.Windows.Forms.Button()
            Me.tabImg = New System.Windows.Forms.Button()
            Me.tabCues = New System.Windows.Forms.Button()
            Me.tabStart = New System.Windows.Forms.Button()
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
            Me.TopBar1 = New Entity._5Controls.HeaderBar()
            Me.projBar.SuspendLayout()
            Me.tabsflow.SuspendLayout()
            Me.SuspendLayout()
            '
            'imglst
            '
            Me.imglst.ImageStream = CType(resources.GetObject("imglst.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imglst.TransparentColor = System.Drawing.Color.Transparent
            Me.imglst.Images.SetKeyName(0, "theatre.png")
            '
            'projBar
            '
            Me.projBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
            Me.projBar.Controls.Add(Me.tbEdit)
            Me.projBar.Controls.Add(Me.btnEdit)
            Me.projBar.Controls.Add(Me.btnAppChProj)
            Me.projBar.Controls.Add(Me.lbShow)
            Me.projBar.Controls.Add(Me.lbWarning)
            Me.projBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.projBar.Location = New System.Drawing.Point(0, 50)
            Me.projBar.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.projBar.Name = "projBar"
            Me.projBar.Size = New System.Drawing.Size(944, 84)
            Me.projBar.TabIndex = 2
            '
            'tbEdit
            '
            Me.tbEdit.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.tbEdit.Location = New System.Drawing.Point(36, 23)
            Me.tbEdit.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbEdit.MaxLength = 50
            Me.tbEdit.Name = "tbEdit"
            Me.tbEdit.Size = New System.Drawing.Size(234, 33)
            Me.tbEdit.TabIndex = 1
            Me.tbEdit.TabStop = False
            Me.tbEdit.Visible = False
            '
            'btnEdit
            '
            Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
            Me.btnEdit.FlatAppearance.BorderSize = 0
            Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnEdit.Image = Global.Entity.My.Resources.Resources.EditBtn
            Me.btnEdit.Location = New System.Drawing.Point(270, 23)
            Me.btnEdit.Margin = New System.Windows.Forms.Padding(60, 38, 60, 38)
            Me.btnEdit.Name = "btnEdit"
            Me.btnEdit.Size = New System.Drawing.Size(33, 33)
            Me.btnEdit.TabIndex = 0
            Me.btnEdit.TabStop = False
            Me.tt.SetToolTip(Me.btnEdit, "When not editing: (Color.fromArgb(100, 100, 100))" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click to edit the name of this" & _
            " show." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "When editing: (Blue)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Left click to confirm edit, or" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "right click to c" & _
            "ancel." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
            Me.btnEdit.UseVisualStyleBackColor = False
            '
            'btnAppChProj
            '
            Me.btnAppChProj.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAppChProj.BackColor = System.Drawing.Color.Gainsboro
            Me.btnAppChProj.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnAppChProj.FlatAppearance.BorderSize = 0
            Me.btnAppChProj.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAppChProj.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAppChProj.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnAppChProj.Location = New System.Drawing.Point(724, 20)
            Me.btnAppChProj.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.btnAppChProj.Name = "btnAppChProj"
            Me.btnAppChProj.Size = New System.Drawing.Size(202, 40)
            Me.btnAppChProj.TabIndex = 2
            Me.btnAppChProj.Text = "Choose Another Show"
            Me.tt.SetToolTip(Me.btnAppChProj, "Hotkey: Ctrl+Shift+Del")
            Me.btnAppChProj.UseVisualStyleBackColor = False
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
            'lbWarning
            '
            Me.lbWarning.AutoSize = True
            Me.lbWarning.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbWarning.ForeColor = System.Drawing.Color.White
            Me.lbWarning.Location = New System.Drawing.Point(41, 61)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(63, 20)
            Me.lbWarning.TabIndex = 37
            Me.lbWarning.Text = "Warning"
            Me.lbWarning.Visible = False
            '
            'viewer
            '
            Me.viewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.viewer.AutoScroll = True
            Me.viewer.BackColor = System.Drawing.Color.WhiteSmoke
            Me.viewer.Location = New System.Drawing.Point(0, 186)
            Me.viewer.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.viewer.Name = "viewer"
            Me.viewer.Size = New System.Drawing.Size(944, 271)
            Me.viewer.TabIndex = 0
            '
            'tabsflow
            '
            Me.tabsflow.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(140, Byte), Integer))
            Me.tabsflow.Controls.Add(Me.tabHome)
            Me.tabsflow.Controls.Add(Me.tabSubs)
            Me.tabsflow.Controls.Add(Me.tabAud)
            Me.tabsflow.Controls.Add(Me.tabImg)
            Me.tabsflow.Controls.Add(Me.tabCues)
            Me.tabsflow.Controls.Add(Me.tabStart)
            Me.tabsflow.Dock = System.Windows.Forms.DockStyle.Top
            Me.tabsflow.Location = New System.Drawing.Point(0, 134)
            Me.tabsflow.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tabsflow.Name = "tabsflow"
            Me.tabsflow.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
            Me.tabsflow.Size = New System.Drawing.Size(944, 50)
            Me.tabsflow.TabIndex = 1
            '
            'tabHome
            '
            Me.tabHome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tabHome.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tabHome.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.tabHome.FlatAppearance.BorderSize = 0
            Me.tabHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.WhiteSmoke
            Me.tabHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
            Me.tabHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabHome.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabHome.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.tabHome.Location = New System.Drawing.Point(0, 12)
            Me.tabHome.Margin = New System.Windows.Forms.Padding(0, 7, 0, 3)
            Me.tabHome.Name = "tabHome"
            Me.tabHome.Size = New System.Drawing.Size(120, 38)
            Me.tabHome.TabIndex = 0
            Me.tabHome.TabStop = False
            Me.tabHome.Tag = "0"
            Me.tabHome.Text = "Home"
            Me.tabHome.UseVisualStyleBackColor = False
            '
            'tabSubs
            '
            Me.tabSubs.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tabSubs.BackColor = System.Drawing.Color.Gainsboro
            Me.tabSubs.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.tabSubs.FlatAppearance.BorderSize = 0
            Me.tabSubs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.tabSubs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.tabSubs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabSubs.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabSubs.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.tabSubs.Location = New System.Drawing.Point(120, 15)
            Me.tabSubs.Margin = New System.Windows.Forms.Padding(0, 10, 0, 3)
            Me.tabSubs.Name = "tabSubs"
            Me.tabSubs.Size = New System.Drawing.Size(120, 35)
            Me.tabSubs.TabIndex = 1
            Me.tabSubs.TabStop = False
            Me.tabSubs.Tag = "0"
            Me.tabSubs.Text = "Lights"
            Me.tabSubs.UseVisualStyleBackColor = False
            '
            'tabAud
            '
            Me.tabAud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tabAud.BackColor = System.Drawing.Color.Gainsboro
            Me.tabAud.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.tabAud.FlatAppearance.BorderSize = 0
            Me.tabAud.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.tabAud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.tabAud.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabAud.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabAud.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.tabAud.Location = New System.Drawing.Point(240, 15)
            Me.tabAud.Margin = New System.Windows.Forms.Padding(0, 10, 0, 3)
            Me.tabAud.Name = "tabAud"
            Me.tabAud.Size = New System.Drawing.Size(120, 35)
            Me.tabAud.TabIndex = 2
            Me.tabAud.TabStop = False
            Me.tabAud.Tag = "0"
            Me.tabAud.Text = "Audio"
            Me.tabAud.UseVisualStyleBackColor = False
            '
            'tabImg
            '
            Me.tabImg.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tabImg.BackColor = System.Drawing.Color.Gainsboro
            Me.tabImg.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.tabImg.FlatAppearance.BorderSize = 0
            Me.tabImg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.tabImg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.tabImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabImg.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabImg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.tabImg.Location = New System.Drawing.Point(360, 15)
            Me.tabImg.Margin = New System.Windows.Forms.Padding(0, 10, 0, 3)
            Me.tabImg.Name = "tabImg"
            Me.tabImg.Size = New System.Drawing.Size(120, 35)
            Me.tabImg.TabIndex = 3
            Me.tabImg.TabStop = False
            Me.tabImg.Tag = "0"
            Me.tabImg.Text = "Images"
            Me.tabImg.UseVisualStyleBackColor = False
            '
            'tabCues
            '
            Me.tabCues.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tabCues.BackColor = System.Drawing.Color.Gainsboro
            Me.tabCues.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.tabCues.FlatAppearance.BorderSize = 0
            Me.tabCues.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.tabCues.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.tabCues.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabCues.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabCues.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.tabCues.Location = New System.Drawing.Point(480, 15)
            Me.tabCues.Margin = New System.Windows.Forms.Padding(0, 10, 0, 3)
            Me.tabCues.Name = "tabCues"
            Me.tabCues.Size = New System.Drawing.Size(120, 35)
            Me.tabCues.TabIndex = 4
            Me.tabCues.TabStop = False
            Me.tabCues.Tag = "0"
            Me.tabCues.Text = "Cues"
            Me.tabCues.UseVisualStyleBackColor = False
            '
            'tabStart
            '
            Me.tabStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tabStart.BackColor = System.Drawing.Color.MediumSeaGreen
            Me.tabStart.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.tabStart.FlatAppearance.BorderSize = 0
            Me.tabStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.tabStart.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tabStart.ForeColor = System.Drawing.Color.White
            Me.tabStart.Location = New System.Drawing.Point(612, 12)
            Me.tabStart.Margin = New System.Windows.Forms.Padding(12, 7, 0, 3)
            Me.tabStart.Name = "tabStart"
            Me.tabStart.Size = New System.Drawing.Size(140, 38)
            Me.tabStart.TabIndex = 5
            Me.tabStart.TabStop = False
            Me.tabStart.Tag = "2"
            Me.tabStart.Text = "Start Show"
            Me.tabStart.UseVisualStyleBackColor = False
            '
            'TopBar1
            '
            Me.TopBar1.Dock = System.Windows.Forms.DockStyle.Top
            Me.TopBar1.Location = New System.Drawing.Point(0, 0)
            Me.TopBar1.Margin = New System.Windows.Forms.Padding(48, 19, 48, 19)
            Me.TopBar1.Name = "TopBar1"
            Me.TopBar1.Size = New System.Drawing.Size(944, 50)
            Me.TopBar1.TabIndex = 3
            '
            'Frm3Viewer
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.ClientSize = New System.Drawing.Size(944, 458)
            Me.Controls.Add(Me.tabsflow)
            Me.Controls.Add(Me.projBar)
            Me.Controls.Add(Me.viewer)
            Me.Controls.Add(Me.TopBar1)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Margin = New System.Windows.Forms.Padding(48, 19, 48, 19)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Frm3Viewer"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Entity System"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.projBar.ResumeLayout(False)
            Me.projBar.PerformLayout()
            Me.tabsflow.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents imglst As System.Windows.Forms.ImageList
        Friend WithEvents projBar As System.Windows.Forms.Panel
        Friend WithEvents lbShow As System.Windows.Forms.Label
        Friend WithEvents btnAppChProj As System.Windows.Forms.Button
        Friend WithEvents viewer As System.Windows.Forms.Panel
        Friend WithEvents tabsflow As System.Windows.Forms.FlowLayoutPanel
        Friend WithEvents tabStart As System.Windows.Forms.Button
        Friend WithEvents tabCues As System.Windows.Forms.Button
        Friend WithEvents tabImg As System.Windows.Forms.Button
        Friend WithEvents tabAud As System.Windows.Forms.Button
        Friend WithEvents tabSubs As System.Windows.Forms.Button
        Friend WithEvents tabHome As System.Windows.Forms.Button
        Friend WithEvents TopBar1 As HeaderBar
        Friend WithEvents btnEdit As System.Windows.Forms.Button
        Friend WithEvents tbEdit As System.Windows.Forms.TextBox
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents tt As System.Windows.Forms.ToolTip

    End Class
End Namespace