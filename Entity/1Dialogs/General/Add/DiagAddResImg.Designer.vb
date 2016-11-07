Namespace _1Dialogs.General.Add
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagAddResImg
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
            Me.title = New System.Windows.Forms.Label()
            Me.pbPrev = New System.Windows.Forms.PictureBox()
            Me.lbSource = New System.Windows.Forms.Label()
            Me.tbPath = New System.Windows.Forms.TextBox()
            Me.btnBrowse = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.lbResName = New System.Windows.Forms.Label()
            Me.tbResName = New System.Windows.Forms.TextBox()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.lbResMode = New System.Windows.Forms.Label()
            Me.cbEffect = New System.Windows.Forms.ComboBox()
            Me.btnImgLib = New System.Windows.Forms.Button()
            Me.btnPaint = New System.Windows.Forms.Button()
            CType(Me.pbPrev, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'title
            '
            Me.title.AutoSize = True
            Me.title.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.title.Location = New System.Drawing.Point(36, 22)
            Me.title.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.title.Name = "title"
            Me.title.Size = New System.Drawing.Size(206, 30)
            Me.title.TabIndex = 1
            Me.title.Text = "New Image Resource"
            '
            'pbPrev
            '
            Me.pbPrev.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.pbPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.pbPrev.Location = New System.Drawing.Point(473, 63)
            Me.pbPrev.Margin = New System.Windows.Forms.Padding(36, 20, 36, 20)
            Me.pbPrev.Name = "pbPrev"
            Me.pbPrev.Size = New System.Drawing.Size(454, 251)
            Me.pbPrev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.pbPrev.TabIndex = 2
            Me.pbPrev.TabStop = False
            '
            'lbSource
            '
            Me.lbSource.AutoSize = True
            Me.lbSource.Location = New System.Drawing.Point(37, 158)
            Me.lbSource.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbSource.Name = "lbSource"
            Me.lbSource.Size = New System.Drawing.Size(56, 21)
            Me.lbSource.TabIndex = 3
            Me.lbSource.Text = "Source"
            '
            'tbPath
            '
            Me.tbPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tbPath.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.tbPath.Font = New System.Drawing.Font("Segoe UI Semilight", 13.0!)
            Me.tbPath.Location = New System.Drawing.Point(41, 184)
            Me.tbPath.Margin = New System.Windows.Forms.Padding(36, 20, 36, 20)
            Me.tbPath.Name = "tbPath"
            Me.tbPath.Size = New System.Drawing.Size(284, 31)
            Me.tbPath.TabIndex = 15
            Me.tbPath.TabStop = False
            '
            'btnBrowse
            '
            Me.btnBrowse.BackColor = System.Drawing.Color.Gainsboro
            Me.btnBrowse.FlatAppearance.BorderSize = 0
            Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnBrowse.Location = New System.Drawing.Point(323, 185)
            Me.btnBrowse.Margin = New System.Windows.Forms.Padding(36, 20, 36, 20)
            Me.btnBrowse.Name = "btnBrowse"
            Me.btnBrowse.Size = New System.Drawing.Size(78, 29)
            Me.btnBrowse.TabIndex = 1
            Me.btnBrowse.Text = "&Browse"
            Me.btnBrowse.UseVisualStyleBackColor = False
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.BackColor = System.Drawing.Color.Gainsboro
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.FlatAppearance.BorderSize = 0
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnCancel.Location = New System.Drawing.Point(662, 326)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(36, 15, 36, 15)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(130, 40)
            Me.btnCancel.TabIndex = 6
            Me.btnCancel.Text = "&Cancel"
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'btnAdd
            '
            Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAdd.BackColor = System.Drawing.Color.Gainsboro
            Me.btnAdd.Enabled = False
            Me.btnAdd.FlatAppearance.BorderSize = 0
            Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnAdd.Location = New System.Drawing.Point(797, 326)
            Me.btnAdd.Margin = New System.Windows.Forms.Padding(36, 15, 36, 15)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(130, 40)
            Me.btnAdd.TabIndex = 7
            Me.btnAdd.Text = "&Add"
            Me.btnAdd.UseVisualStyleBackColor = False
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnClose.FlatAppearance.BorderSize = 0
            Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.ForeColor = System.Drawing.Color.White
            Me.btnClose.Location = New System.Drawing.Point(930, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(36, 15, 36, 15)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(40, 40)
            Me.btnClose.TabIndex = 8
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'lbResName
            '
            Me.lbResName.AutoSize = True
            Me.lbResName.Location = New System.Drawing.Point(37, 79)
            Me.lbResName.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbResName.Name = "lbResName"
            Me.lbResName.Size = New System.Drawing.Size(117, 21)
            Me.lbResName.TabIndex = 9
            Me.lbResName.Text = "Resource Name"
            '
            'tbResName
            '
            Me.tbResName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tbResName.Font = New System.Drawing.Font("Segoe UI Semilight", 13.0!)
            Me.tbResName.Location = New System.Drawing.Point(41, 105)
            Me.tbResName.Margin = New System.Windows.Forms.Padding(36, 20, 36, 20)
            Me.tbResName.MaxLength = 30
            Me.tbResName.Name = "tbResName"
            Me.tbResName.Size = New System.Drawing.Size(360, 31)
            Me.tbResName.TabIndex = 0
            '
            'lbWarning
            '
            Me.lbWarning.ForeColor = System.Drawing.Color.White
            Me.lbWarning.Location = New System.Drawing.Point(41, 135)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(360, 26)
            Me.lbWarning.TabIndex = 10
            Me.lbWarning.Text = "Name Cannot be Empty!"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWarning.Visible = False
            '
            'lbResMode
            '
            Me.lbResMode.AutoSize = True
            Me.lbResMode.Location = New System.Drawing.Point(37, 239)
            Me.lbResMode.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbResMode.Name = "lbResMode"
            Me.lbResMode.Size = New System.Drawing.Size(48, 21)
            Me.lbResMode.TabIndex = 11
            Me.lbResMode.Text = "Effect"
            '
            'cbEffect
            '
            Me.cbEffect.BackColor = System.Drawing.SystemColors.Window
            Me.cbEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbEffect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbEffect.Font = New System.Drawing.Font("Segoe UI Semilight", 13.0!)
            Me.cbEffect.FormattingEnabled = True
            Me.cbEffect.Items.AddRange(New Object() {"Normal", "Black and White", "Greyscale", "Old Photo", "Inverted", "Bright", "Dark", "High Contrast"})
            Me.cbEffect.Location = New System.Drawing.Point(41, 265)
            Me.cbEffect.Margin = New System.Windows.Forms.Padding(36, 5, 36, 15)
            Me.cbEffect.Name = "cbEffect"
            Me.cbEffect.Size = New System.Drawing.Size(360, 31)
            Me.cbEffect.TabIndex = 2
            '
            'btnImgLib
            '
            Me.btnImgLib.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnImgLib.BackColor = System.Drawing.Color.Gainsboro
            Me.btnImgLib.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.btnImgLib.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnImgLib.FlatAppearance.BorderSize = 0
            Me.btnImgLib.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnImgLib.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnImgLib.Location = New System.Drawing.Point(41, 326)
            Me.btnImgLib.Margin = New System.Windows.Forms.Padding(36, 20, 36, 20)
            Me.btnImgLib.Name = "btnImgLib"
            Me.btnImgLib.Size = New System.Drawing.Size(150, 40)
            Me.btnImgLib.TabIndex = 4
            Me.btnImgLib.Text = "Global &Resources"
            Me.btnImgLib.UseVisualStyleBackColor = False
            Me.btnImgLib.Visible = False
            '
            'btnPaint
            '
            Me.btnPaint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnPaint.BackColor = System.Drawing.Color.Gainsboro
            Me.btnPaint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.btnPaint.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnPaint.FlatAppearance.BorderSize = 0
            Me.btnPaint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPaint.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnPaint.Location = New System.Drawing.Point(197, 326)
            Me.btnPaint.Margin = New System.Windows.Forms.Padding(60, 20, 36, 20)
            Me.btnPaint.Name = "btnPaint"
            Me.btnPaint.Size = New System.Drawing.Size(204, 40)
            Me.btnPaint.TabIndex = 5
            Me.btnPaint.Text = "Quick Image &Generator"
            Me.btnPaint.UseVisualStyleBackColor = False
            Me.btnPaint.Visible = False
            '
            'DiagAddResImg
            '
            Me.AcceptButton = Me.btnAdd
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(972, 390)
            Me.Controls.Add(Me.btnPaint)
            Me.Controls.Add(Me.btnImgLib)
            Me.Controls.Add(Me.cbEffect)
            Me.Controls.Add(Me.lbResMode)
            Me.Controls.Add(Me.lbWarning)
            Me.Controls.Add(Me.tbResName)
            Me.Controls.Add(Me.lbResName)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnAdd)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnBrowse)
            Me.Controls.Add(Me.tbPath)
            Me.Controls.Add(Me.lbSource)
            Me.Controls.Add(Me.pbPrev)
            Me.Controls.Add(Me.title)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(36, 20, 36, 20)
            Me.Name = "DiagAddResImg"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Add Image Resource"
            CType(Me.pbPrev, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents title As System.Windows.Forms.Label
        Friend WithEvents pbPrev As System.Windows.Forms.PictureBox
        Friend WithEvents lbSource As System.Windows.Forms.Label
        Friend WithEvents tbPath As System.Windows.Forms.TextBox
        Friend WithEvents btnBrowse As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents lbResName As System.Windows.Forms.Label
        Friend WithEvents tbResName As System.Windows.Forms.TextBox
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents lbResMode As System.Windows.Forms.Label
        Friend WithEvents cbEffect As System.Windows.Forms.ComboBox
        Friend WithEvents btnImgLib As System.Windows.Forms.Button
        Friend WithEvents btnPaint As System.Windows.Forms.Button
    End Class
End Namespace