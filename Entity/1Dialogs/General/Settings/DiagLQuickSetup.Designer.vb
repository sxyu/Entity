Namespace _1Dialogs.General.Settings
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagLQuickSetup
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
            Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"001", "Main"}, 0)
            Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"002", "Other"}, 0)
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiagLQuickSetup))
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.lbName = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.lbNumbers = New System.Windows.Forms.Label()
            Me.numNum = New System.Windows.Forms.NumericUpDown()
            Me.lbChnls = New System.Windows.Forms.Label()
            Me.lv = New System.Windows.Forms.ListView()
            Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colChnlName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.btnRemCh = New System.Windows.Forms.Button()
            Me.btnAddCh = New System.Windows.Forms.Button()
            Me.cmbChTag = New System.Windows.Forms.ComboBox()
            Me.lbTag = New System.Windows.Forms.Label()
            Me.btnClose = New System.Windows.Forms.Button()
            CType(Me.numNum, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.Location = New System.Drawing.Point(31, 26)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(195, 25)
            Me.lbTitle.TabIndex = 0
            Me.lbTitle.Text = "Express Lighting Setup"
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.BackColor = System.Drawing.Color.Gainsboro
            Me.btnOK.Enabled = False
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnOK.Location = New System.Drawing.Point(347, 438)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(130, 40)
            Me.btnOK.TabIndex = 33
            Me.btnOK.Text = "&OK"
            Me.btnOK.UseVisualStyleBackColor = False
            '
            'tbName
            '
            Me.tbName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbName.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tbName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.tbName.Location = New System.Drawing.Point(36, 131)
            Me.tbName.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbName.MaxLength = 50
            Me.tbName.MinimumSize = New System.Drawing.Size(300, 29)
            Me.tbName.Name = "tbName"
            Me.tbName.Size = New System.Drawing.Size(398, 29)
            Me.tbName.TabIndex = 0
            Me.tbName.Text = "Light %N%"
            Me.tbName.WordWrap = False
            '
            'lbName
            '
            Me.lbName.AutoSize = True
            Me.lbName.Location = New System.Drawing.Point(32, 96)
            Me.lbName.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbName.Name = "lbName"
            Me.lbName.Size = New System.Drawing.Size(312, 21)
            Me.lbName.TabIndex = 3
            Me.lbName.Text = "Light Naming Pattern (%N%=Light Number)"
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatAppearance.BorderSize = 0
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnCancel.Location = New System.Drawing.Point(212, 438)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(130, 40)
            Me.btnCancel.TabIndex = 32
            Me.btnCancel.Text = "&Cancel"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'lbWarning
            '
            Me.lbWarning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbWarning.Location = New System.Drawing.Point(35, 159)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(399, 29)
            Me.lbWarning.TabIndex = 4
            Me.lbWarning.Text = "Label1"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWarning.Visible = False
            '
            'lbNumbers
            '
            Me.lbNumbers.AutoSize = True
            Me.lbNumbers.Location = New System.Drawing.Point(32, 199)
            Me.lbNumbers.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbNumbers.Name = "lbNumbers"
            Me.lbNumbers.Size = New System.Drawing.Size(133, 21)
            Me.lbNumbers.TabIndex = 5
            Me.lbNumbers.Text = "Number of Lights:"
            '
            'numNum
            '
            Me.numNum.Location = New System.Drawing.Point(171, 197)
            Me.numNum.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.numNum.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
            Me.numNum.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numNum.Name = "numNum"
            Me.numNum.Size = New System.Drawing.Size(100, 29)
            Me.numNum.TabIndex = 6
            Me.numNum.Value = New Decimal(New Integer() {24, 0, 0, 0})
            '
            'lbChnls
            '
            Me.lbChnls.AutoSize = True
            Me.lbChnls.Location = New System.Drawing.Point(30, 247)
            Me.lbChnls.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbChnls.Name = "lbChnls"
            Me.lbChnls.Size = New System.Drawing.Size(178, 21)
            Me.lbChnls.TabIndex = 7
            Me.lbChnls.Text = "Channels For Each Light:"
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.Alignment = System.Windows.Forms.ListViewAlignment.[Default]
            Me.lv.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lv.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colChnlName})
            Me.lv.ForeColor = System.Drawing.Color.White
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            ListViewItem1.StateImageIndex = 0
            ListViewItem2.StateImageIndex = 0
            Me.lv.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
            Me.lv.Location = New System.Drawing.Point(34, 282)
            Me.lv.Margin = New System.Windows.Forms.Padding(0)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(443, 92)
            Me.lv.SmallImageList = Me.imgLst
            Me.lv.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lv.TabIndex = 22
            Me.lv.UseCompatibleStateImageBehavior = False
            Me.lv.View = System.Windows.Forms.View.Details
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
            'imgLst
            '
            Me.imgLst.ImageStream = CType(resources.GetObject("imgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
            Me.imgLst.Images.SetKeyName(0, "Stock.ico")
            '
            'btnRemCh
            '
            Me.btnRemCh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnRemCh.BackColor = System.Drawing.Color.Gainsboro
            Me.btnRemCh.Enabled = False
            Me.btnRemCh.FlatAppearance.BorderSize = 0
            Me.btnRemCh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRemCh.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemCh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.btnRemCh.Location = New System.Drawing.Point(348, 378)
            Me.btnRemCh.Margin = New System.Windows.Forms.Padding(107, 23, 53, 23)
            Me.btnRemCh.Name = "btnRemCh"
            Me.btnRemCh.Size = New System.Drawing.Size(40, 29)
            Me.btnRemCh.TabIndex = 31
            Me.btnRemCh.Text = "-"
            Me.btnRemCh.UseVisualStyleBackColor = False
            '
            'btnAddCh
            '
            Me.btnAddCh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAddCh.BackColor = System.Drawing.Color.Gainsboro
            Me.btnAddCh.FlatAppearance.BorderSize = 0
            Me.btnAddCh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddCh.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddCh.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.btnAddCh.Location = New System.Drawing.Point(394, 378)
            Me.btnAddCh.Margin = New System.Windows.Forms.Padding(107, 23, 53, 23)
            Me.btnAddCh.Name = "btnAddCh"
            Me.btnAddCh.Size = New System.Drawing.Size(40, 29)
            Me.btnAddCh.TabIndex = 30
            Me.btnAddCh.Text = "+"
            Me.btnAddCh.UseVisualStyleBackColor = False
            '
            'cmbChTag
            '
            Me.cmbChTag.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbChTag.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbChTag.FormattingEnabled = True
            Me.cmbChTag.Items.AddRange(New Object() {"Main", "Fader", "Cyan", "Magenta", "Yellow", "Color", "Pan", "Tilt", "Fine Pan", "Fine Tilt", "Shutter", "Patching", "Other"})
            Me.cmbChTag.Location = New System.Drawing.Point(68, 378)
            Me.cmbChTag.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.cmbChTag.Name = "cmbChTag"
            Me.cmbChTag.Size = New System.Drawing.Size(274, 29)
            Me.cmbChTag.TabIndex = 29
            Me.cmbChTag.Visible = False
            '
            'lbTag
            '
            Me.lbTag.AutoSize = True
            Me.lbTag.Location = New System.Drawing.Point(30, 381)
            Me.lbTag.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTag.Name = "lbTag"
            Me.lbTag.Size = New System.Drawing.Size(33, 21)
            Me.lbTag.TabIndex = 34
            Me.lbTag.Text = "Tag"
            Me.lbTag.Visible = False
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
            Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnClose.Location = New System.Drawing.Point(463, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 35
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'DiagLQuickSetup
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(500, 495)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.lbTag)
            Me.Controls.Add(Me.btnRemCh)
            Me.Controls.Add(Me.btnAddCh)
            Me.Controls.Add(Me.cmbChTag)
            Me.Controls.Add(Me.lv)
            Me.Controls.Add(Me.lbChnls)
            Me.Controls.Add(Me.numNum)
            Me.Controls.Add(Me.lbNumbers)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.lbName)
            Me.Controls.Add(Me.tbName)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.lbTitle)
            Me.Controls.Add(Me.lbWarning)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagLQuickSetup"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Entity System"
            Me.TopMost = True
            CType(Me.numNum, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents tbName As System.Windows.Forms.TextBox
        Friend WithEvents lbName As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents lbNumbers As System.Windows.Forms.Label
        Friend WithEvents numNum As System.Windows.Forms.NumericUpDown
        Friend WithEvents lbChnls As System.Windows.Forms.Label
        Friend WithEvents lv As System.Windows.Forms.ListView
        Friend WithEvents colID As System.Windows.Forms.ColumnHeader
        Friend WithEvents colChnlName As System.Windows.Forms.ColumnHeader
        Friend WithEvents imgLst As System.Windows.Forms.ImageList
        Friend WithEvents btnRemCh As System.Windows.Forms.Button
        Friend WithEvents btnAddCh As System.Windows.Forms.Button
        Friend WithEvents cmbChTag As System.Windows.Forms.ComboBox
        Friend WithEvents lbTag As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
    End Class
End NameSpace