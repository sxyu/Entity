Imports Entity._5Controls

Namespace _0App
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Frm2Launcher
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm2Launcher))
            Me.btnOpen = New System.Windows.Forms.Button()
            Me.lbDesc = New System.Windows.Forms.Label()
            Me.imglst = New System.Windows.Forms.ImageList(Me.components)
            Me.btnNew = New System.Windows.Forms.Button()
            Me.btnDel = New System.Windows.Forms.Button()
            Me.btnRename = New System.Windows.Forms.Button()
            Me.updateChecker = New System.ComponentModel.BackgroundWorker()
            Me.btnWorkingDir = New System.Windows.Forms.Button()
            Me.lbWorkingDir = New System.Windows.Forms.Label()
            Me.TopBar = New Entity._5Controls.HeaderBar()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.SuspendLayout()
            '
            'btnOpen
            '
            Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnOpen.Enabled = False
            Me.btnOpen.FlatAppearance.BorderSize = 0
            Me.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOpen.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnOpen.Location = New System.Drawing.Point(739, 401)
            Me.btnOpen.Margin = New System.Windows.Forms.Padding(60, 24, 60, 24)
            Me.btnOpen.Name = "btnOpen"
            Me.btnOpen.Size = New System.Drawing.Size(160, 40)
            Me.btnOpen.TabIndex = 1
            Me.btnOpen.Text = "&Open"
            Me.btnOpen.UseVisualStyleBackColor = False
            '
            'lbDesc
            '
            Me.lbDesc.AutoSize = True
            Me.lbDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.lbDesc.Location = New System.Drawing.Point(45, 97)
            Me.lbDesc.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbDesc.Name = "lbDesc"
            Me.lbDesc.Size = New System.Drawing.Size(500, 60)
            Me.lbDesc.TabIndex = 6
            Me.lbDesc.Text = "Welcome to the Entity System," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a simple and intuitive theatrical effect controlle" & _
        "r system" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "created and managed by the University Hill Secondary Theatre Departmen" & _
        "t"
            '
            'imglst
            '
            Me.imglst.ImageStream = CType(resources.GetObject("imglst.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imglst.TransparentColor = System.Drawing.Color.Transparent
            Me.imglst.Images.SetKeyName(0, "default")
            '
            'btnNew
            '
            Me.btnNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnNew.FlatAppearance.BorderSize = 0
            Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNew.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnNew.Location = New System.Drawing.Point(49, 401)
            Me.btnNew.Margin = New System.Windows.Forms.Padding(60, 24, 60, 24)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(130, 40)
            Me.btnNew.TabIndex = 2
            Me.btnNew.Text = "&New Show"
            Me.btnNew.UseVisualStyleBackColor = False
            '
            'btnDel
            '
            Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnDel.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnDel.Enabled = False
            Me.btnDel.FlatAppearance.BorderSize = 0
            Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDel.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnDel.Location = New System.Drawing.Point(319, 401)
            Me.btnDel.Margin = New System.Windows.Forms.Padding(60, 24, 60, 24)
            Me.btnDel.Name = "btnDel"
            Me.btnDel.Size = New System.Drawing.Size(130, 40)
            Me.btnDel.TabIndex = 4
            Me.btnDel.Text = "&Delete Show"
            Me.btnDel.UseVisualStyleBackColor = False
            '
            'btnRename
            '
            Me.btnRename.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnRename.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnRename.Enabled = False
            Me.btnRename.FlatAppearance.BorderSize = 0
            Me.btnRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRename.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnRename.Location = New System.Drawing.Point(184, 401)
            Me.btnRename.Margin = New System.Windows.Forms.Padding(60, 24, 60, 24)
            Me.btnRename.Name = "btnRename"
            Me.btnRename.Size = New System.Drawing.Size(130, 40)
            Me.btnRename.TabIndex = 3
            Me.btnRename.Text = "&Rename Show"
            Me.btnRename.UseVisualStyleBackColor = False
            '
            'updateChecker
            '
            '
            'btnWorkingDir
            '
            Me.btnWorkingDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnWorkingDir.BackColor = System.Drawing.Color.WhiteSmoke
            Me.btnWorkingDir.FlatAppearance.BorderSize = 0
            Me.btnWorkingDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(235, Byte), Integer))
            Me.btnWorkingDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnWorkingDir.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!)
            Me.btnWorkingDir.ForeColor = System.Drawing.Color.DarkGray
            Me.btnWorkingDir.Image = Global.Entity.My.Resources.Resources.ModifyBtn
            Me.btnWorkingDir.Location = New System.Drawing.Point(221, 168)
            Me.btnWorkingDir.Margin = New System.Windows.Forms.Padding(60, 24, 60, 24)
            Me.btnWorkingDir.Name = "btnWorkingDir"
            Me.btnWorkingDir.Size = New System.Drawing.Size(32, 28)
            Me.btnWorkingDir.TabIndex = 5
            Me.btnWorkingDir.Text = "                &W"
            Me.btnWorkingDir.UseVisualStyleBackColor = False
            '
            'lbWorkingDir
            '
            Me.lbWorkingDir.AutoSize = True
            Me.lbWorkingDir.Font = New System.Drawing.Font("Segoe UI Semilight", 10.0!)
            Me.lbWorkingDir.ForeColor = System.Drawing.Color.Gray
            Me.lbWorkingDir.Location = New System.Drawing.Point(45, 172)
            Me.lbWorkingDir.Name = "lbWorkingDir"
            Me.lbWorkingDir.Size = New System.Drawing.Size(174, 19)
            Me.lbWorkingDir.TabIndex = 9
            Me.lbWorkingDir.Text = "Current Working Directory:"
            '
            'TopBar
            '
            Me.TopBar.Dock = System.Windows.Forms.DockStyle.Top
            Me.TopBar.Location = New System.Drawing.Point(0, 0)
            Me.TopBar.Margin = New System.Windows.Forms.Padding(48, 24, 48, 24)
            Me.TopBar.Name = "TopBar"
            Me.TopBar.Size = New System.Drawing.Size(944, 50)
            Me.TopBar.TabIndex = 7
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lv.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName})
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            Me.lv.LargeImageList = Me.imglst
            Me.lv.Location = New System.Drawing.Point(15, 210)
            Me.lv.Margin = New System.Windows.Forms.Padding(36, 19, 36, 19)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(884, 148)
            Me.lv.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lv.TabIndex = 0
            Me.lv.UseCompatibleStateImageBehavior = False
            '
            'colName
            '
            Me.colName.Text = "Name"
            '
            'Frm2Launcher
            '
            Me.AcceptButton = Me.btnOpen
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.ClientSize = New System.Drawing.Size(944, 458)
            Me.Controls.Add(Me.lbWorkingDir)
            Me.Controls.Add(Me.btnWorkingDir)
            Me.Controls.Add(Me.TopBar)
            Me.Controls.Add(Me.lv)
            Me.Controls.Add(Me.btnRename)
            Me.Controls.Add(Me.btnDel)
            Me.Controls.Add(Me.btnNew)
            Me.Controls.Add(Me.lbDesc)
            Me.Controls.Add(Me.btnOpen)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(60, 24, 60, 24)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "Frm2Launcher"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Entity System"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnOpen As System.Windows.Forms.Button
        Friend WithEvents lbDesc As System.Windows.Forms.Label
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents btnDel As System.Windows.Forms.Button
        Friend WithEvents imglst As System.Windows.Forms.ImageList
        Friend WithEvents colName As System.Windows.Forms.ColumnHeader
        Friend WithEvents btnRename As System.Windows.Forms.Button
        Friend WithEvents TopBar As HeaderBar
        Friend WithEvents lv As listViewX
        Friend WithEvents updateChecker As System.ComponentModel.BackgroundWorker
        Friend WithEvents btnWorkingDir As System.Windows.Forms.Button
        Friend WithEvents lbWorkingDir As System.Windows.Forms.Label

    End Class
End Namespace