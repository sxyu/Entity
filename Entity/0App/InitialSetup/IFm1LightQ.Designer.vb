Namespace _0App.InitialSetup
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IFm1LightQ
        Inherits IFmBase

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IFm1LightQ))
            Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"001", "Main"}, 0)
            Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"002", "Other"}, 0)
            Me.imgLst = New System.Windows.Forms.ImageList(Me.components)
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.lbTag = New System.Windows.Forms.Label()
            Me.btnRemCh = New System.Windows.Forms.Button()
            Me.btnAddCh = New System.Windows.Forms.Button()
            Me.cmbChTag = New System.Windows.Forms.ComboBox()
            Me.lv = New System.Windows.Forms.ListView()
            Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.colChnlName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.lbChnls = New System.Windows.Forms.Label()
            Me.numNum = New System.Windows.Forms.NumericUpDown()
            Me.lbNumbers = New System.Windows.Forms.Label()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.lbName = New System.Windows.Forms.Label()
            Me.tbName = New System.Windows.Forms.TextBox()
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.lbDesc = New System.Windows.Forms.Label()
            Me.content = New System.Windows.Forms.Panel()
            CType(Me.numNum, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.content.SuspendLayout()
            Me.SuspendLayout()
            '
            'imgLst
            '
            Me.imgLst.ImageStream = CType(resources.GetObject("imgLst.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imgLst.TransparentColor = System.Drawing.Color.Transparent
            Me.imgLst.Images.SetKeyName(0, "Stock.ico")
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.BackColor = System.Drawing.Color.Gainsboro
            Me.btnOK.Enabled = False
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.ForeColor = System.Drawing.Color.Black
            Me.btnOK.Location = New System.Drawing.Point(428, 529)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(130, 40)
            Me.btnOK.TabIndex = 33
            Me.btnOK.Text = "&Next"
            Me.btnOK.UseVisualStyleBackColor = False
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
            Me.btnClose.Location = New System.Drawing.Point(963, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(64, 27, 64, 27)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 52
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'lbTag
            '
            Me.lbTag.AutoSize = True
            Me.lbTag.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTag.ForeColor = System.Drawing.Color.White
            Me.lbTag.Location = New System.Drawing.Point(77, 476)
            Me.lbTag.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTag.Name = "lbTag"
            Me.lbTag.Size = New System.Drawing.Size(35, 20)
            Me.lbTag.TabIndex = 34
            Me.lbTag.Text = "Tag:"
            Me.lbTag.Visible = False
            '
            'btnRemCh
            '
            Me.btnRemCh.BackColor = System.Drawing.Color.Gainsboro
            Me.btnRemCh.Enabled = False
            Me.btnRemCh.FlatAppearance.BorderSize = 0
            Me.btnRemCh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRemCh.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemCh.ForeColor = System.Drawing.Color.Black
            Me.btnRemCh.Location = New System.Drawing.Point(518, 471)
            Me.btnRemCh.Margin = New System.Windows.Forms.Padding(53, 23, 53, 23)
            Me.btnRemCh.Name = "btnRemCh"
            Me.btnRemCh.Size = New System.Drawing.Size(40, 31)
            Me.btnRemCh.TabIndex = 31
            Me.btnRemCh.Text = "-"
            Me.btnRemCh.UseVisualStyleBackColor = False
            '
            'btnAddCh
            '
            Me.btnAddCh.BackColor = System.Drawing.Color.Gainsboro
            Me.btnAddCh.FlatAppearance.BorderSize = 0
            Me.btnAddCh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddCh.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddCh.ForeColor = System.Drawing.Color.Black
            Me.btnAddCh.Location = New System.Drawing.Point(473, 471)
            Me.btnAddCh.Margin = New System.Windows.Forms.Padding(53, 23, 53, 23)
            Me.btnAddCh.Name = "btnAddCh"
            Me.btnAddCh.Size = New System.Drawing.Size(40, 31)
            Me.btnAddCh.TabIndex = 30
            Me.btnAddCh.Text = "+"
            Me.btnAddCh.UseVisualStyleBackColor = False
            '
            'cmbChTag
            '
            Me.cmbChTag.Font = New System.Drawing.Font("Segoe UI Semilight", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbChTag.FormattingEnabled = True
            Me.cmbChTag.Items.AddRange(New Object() {"Main", "Fader", "Cyan", "Magenta", "Yellow", "Color", "Pan", "Tilt", "Fine Pan", "Fine Tilt", "Shutter", "Patching", "Other"})
            Me.cmbChTag.Location = New System.Drawing.Point(130, 471)
            Me.cmbChTag.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.cmbChTag.Name = "cmbChTag"
            Me.cmbChTag.Size = New System.Drawing.Size(328, 31)
            Me.cmbChTag.TabIndex = 29
            Me.cmbChTag.Visible = False
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid
            Me.lv.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colChnlName})
            Me.lv.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lv.ForeColor = System.Drawing.Color.White
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            ListViewItem1.StateImageIndex = 0
            ListViewItem2.StateImageIndex = 0
            Me.lv.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
            Me.lv.Location = New System.Drawing.Point(81, 370)
            Me.lv.Margin = New System.Windows.Forms.Padding(32, 14, 32, 0)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(476, 100)
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
            'lbChnls
            '
            Me.lbChnls.AutoSize = True
            Me.lbChnls.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbChnls.ForeColor = System.Drawing.Color.White
            Me.lbChnls.Location = New System.Drawing.Point(241, 342)
            Me.lbChnls.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbChnls.Name = "lbChnls"
            Me.lbChnls.Size = New System.Drawing.Size(166, 20)
            Me.lbChnls.TabIndex = 7
            Me.lbChnls.Text = "Channels For Each Light:"
            '
            'numNum
            '
            Me.numNum.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.numNum.Location = New System.Drawing.Point(276, 293)
            Me.numNum.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.numNum.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
            Me.numNum.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numNum.Name = "numNum"
            Me.numNum.Size = New System.Drawing.Size(100, 27)
            Me.numNum.TabIndex = 6
            Me.numNum.Value = New Decimal(New Integer() {24, 0, 0, 0})
            '
            'lbNumbers
            '
            Me.lbNumbers.AutoSize = True
            Me.lbNumbers.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbNumbers.ForeColor = System.Drawing.Color.White
            Me.lbNumbers.Location = New System.Drawing.Point(263, 261)
            Me.lbNumbers.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbNumbers.Name = "lbNumbers"
            Me.lbNumbers.Size = New System.Drawing.Size(125, 20)
            Me.lbNumbers.TabIndex = 5
            Me.lbNumbers.Text = "Number of Lights:"
            '
            'lbWarning
            '
            Me.lbWarning.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbWarning.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbWarning.Location = New System.Drawing.Point(1952, 974)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(3947, 110)
            Me.lbWarning.TabIndex = 4
            Me.lbWarning.Text = "The Light Name Must Contain %N%"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.TopRight
            Me.lbWarning.Visible = False
            '
            'lbName
            '
            Me.lbName.AutoSize = True
            Me.lbName.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbName.ForeColor = System.Drawing.Color.White
            Me.lbName.Location = New System.Drawing.Point(177, 177)
            Me.lbName.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbName.Name = "lbName"
            Me.lbName.Size = New System.Drawing.Size(295, 20)
            Me.lbName.TabIndex = 3
            Me.lbName.Text = "Light Naming Pattern (%N%=Light Number)"
            '
            'tbName
            '
            Me.tbName.BackColor = System.Drawing.Color.White
            Me.tbName.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbName.ForeColor = System.Drawing.Color.Black
            Me.tbName.Location = New System.Drawing.Point(224, 211)
            Me.tbName.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.tbName.MaxLength = 50
            Me.tbName.MinimumSize = New System.Drawing.Size(200, 29)
            Me.tbName.Name = "tbName"
            Me.tbName.Size = New System.Drawing.Size(200, 27)
            Me.tbName.TabIndex = 0
            Me.tbName.Text = "Light %N%"
            Me.tbName.WordWrap = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.ForeColor = System.Drawing.Color.White
            Me.lbTitle.Location = New System.Drawing.Point(179, 30)
            Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(280, 30)
            Me.lbTitle.TabIndex = 0
            Me.lbTitle.Text = "Tell Us How Your Lights Work"
            '
            'lbDesc
            '
            Me.lbDesc.AutoSize = True
            Me.lbDesc.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbDesc.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.lbDesc.Location = New System.Drawing.Point(110, 68)
            Me.lbDesc.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.lbDesc.Name = "lbDesc"
            Me.lbDesc.Size = New System.Drawing.Size(418, 80)
            Me.lbDesc.TabIndex = 47
            Me.lbDesc.Text = "Fill in all the fields and click Next to continue." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If you don't know what to do," & _
        " you may wish to contact support." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Note that you can also set up lights in the n" & _
        "ext step, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "though it will take longer."
            Me.lbDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'content
            '
            Me.content.Controls.Add(Me.lbTitle)
            Me.content.Controls.Add(Me.lbWarning)
            Me.content.Controls.Add(Me.lbTag)
            Me.content.Controls.Add(Me.btnOK)
            Me.content.Controls.Add(Me.lbDesc)
            Me.content.Controls.Add(Me.cmbChTag)
            Me.content.Controls.Add(Me.btnAddCh)
            Me.content.Controls.Add(Me.btnRemCh)
            Me.content.Controls.Add(Me.tbName)
            Me.content.Controls.Add(Me.lbName)
            Me.content.Controls.Add(Me.numNum)
            Me.content.Controls.Add(Me.lbChnls)
            Me.content.Controls.Add(Me.lbNumbers)
            Me.content.Controls.Add(Me.lv)
            Me.content.Location = New System.Drawing.Point(215, 23)
            Me.content.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.content.Name = "content"
            Me.content.Size = New System.Drawing.Size(625, 583)
            Me.content.TabIndex = 53
            '
            'IFm1LightQ
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1000, 613)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.content)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "IFm1LightQ"
            Me.Opacity = 0.1R
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.Text = "Entity System"
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.numNum, System.ComponentModel.ISupportInitialize).EndInit()
            Me.content.ResumeLayout(False)
            Me.content.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lbTitle As System.Windows.Forms.Label
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents tbName As System.Windows.Forms.TextBox
        Friend WithEvents lbName As System.Windows.Forms.Label
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
        Friend WithEvents lbDesc As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents content As System.Windows.Forms.Panel
    End Class
End Namespace