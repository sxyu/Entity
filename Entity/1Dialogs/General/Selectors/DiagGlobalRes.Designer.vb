Imports Entity._5Controls

Namespace _1Dialogs.General.Selectors
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagGlobalRes
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
            Me.btnClose = New System.Windows.Forms.Button()
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.il = New System.Windows.Forms.ImageList(Me.components)
            Me.btnUse = New System.Windows.Forms.Button()
            Me.tbSearch = New System.Windows.Forms.TextBox()
            Me.btnPlay = New System.Windows.Forms.Button()
            Me.breadcrumbs = New System.Windows.Forms.Label()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.SuspendLayout()
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BackColor = System.Drawing.Color.Transparent
            Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnClose.FlatAppearance.BorderSize = 0
            Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnClose.Location = New System.Drawing.Point(561, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 1
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Location = New System.Drawing.Point(31, 20)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(173, 21)
            Me.lbTitle.TabIndex = 3
            Me.lbTitle.Text = "Global Audio Resources"
            '
            'il
            '
            Me.il.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
            Me.il.ImageSize = New System.Drawing.Size(16, 16)
            Me.il.TransparentColor = System.Drawing.Color.Transparent
            '
            'btnUse
            '
            Me.btnUse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnUse.BackColor = System.Drawing.Color.SteelBlue
            Me.btnUse.Enabled = False
            Me.btnUse.FlatAppearance.BorderSize = 0
            Me.btnUse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnUse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnUse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnUse.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUse.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnUse.Location = New System.Drawing.Point(427, 498)
            Me.btnUse.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnUse.Name = "btnUse"
            Me.btnUse.Size = New System.Drawing.Size(130, 40)
            Me.btnUse.TabIndex = 3
            Me.btnUse.TabStop = False
            Me.btnUse.Tag = "0"
            Me.btnUse.Text = "&Use"
            Me.btnUse.UseVisualStyleBackColor = False
            '
            'tbSearch
            '
            Me.tbSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tbSearch.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.tbSearch.Location = New System.Drawing.Point(35, 66)
            Me.tbSearch.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbSearch.Name = "tbSearch"
            Me.tbSearch.Size = New System.Drawing.Size(522, 29)
            Me.tbSearch.TabIndex = 0
            '
            'btnPlay
            '
            Me.btnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnPlay.BackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnPlay.FlatAppearance.BorderSize = 0
            Me.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPlay.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPlay.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnPlay.Location = New System.Drawing.Point(35, 498)
            Me.btnPlay.Margin = New System.Windows.Forms.Padding(0, 46, 0, 14)
            Me.btnPlay.Name = "btnPlay"
            Me.btnPlay.Size = New System.Drawing.Size(130, 40)
            Me.btnPlay.TabIndex = 2
            Me.btnPlay.TabStop = False
            Me.btnPlay.Tag = "0"
            Me.btnPlay.Text = "&Play"
            Me.btnPlay.UseVisualStyleBackColor = False
            Me.btnPlay.Visible = False
            '
            'breadcrumbs
            '
            Me.breadcrumbs.AutoSize = True
            Me.breadcrumbs.Location = New System.Drawing.Point(31, 109)
            Me.breadcrumbs.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.breadcrumbs.Name = "breadcrumbs"
            Me.breadcrumbs.Size = New System.Drawing.Size(55, 21)
            Me.breadcrumbs.TabIndex = 4
            Me.breadcrumbs.Text = "Global"
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lv.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName})
            Me.lv.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lv.ForeColor = System.Drawing.Color.White
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            Me.lv.Location = New System.Drawing.Point(35, 144)
            Me.lv.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(522, 336)
            Me.lv.SmallImageList = Me.il
            Me.lv.TabIndex = 1
            Me.lv.UseCompatibleStateImageBehavior = False
            Me.lv.View = System.Windows.Forms.View.Details
            '
            'colName
            '
            Me.colName.Text = "Name"
            '
            'DiagGlobalRes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(598, 551)
            Me.Controls.Add(Me.breadcrumbs)
            Me.Controls.Add(Me.btnPlay)
            Me.Controls.Add(Me.tbSearch)
            Me.Controls.Add(Me.btnUse)
            Me.Controls.Add(Me.lbTitle)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.lv)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagGlobalRes"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.TopMost = True
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents btnUse As System.Windows.Forms.Button
        Friend WithEvents tbSearch As System.Windows.Forms.TextBox
        Friend WithEvents btnPlay As System.Windows.Forms.Button
        Friend WithEvents il As System.Windows.Forms.ImageList
        Friend WithEvents breadcrumbs As System.Windows.Forms.Label
        Friend WithEvents lv As listViewX
        Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    End Class
End NameSpace