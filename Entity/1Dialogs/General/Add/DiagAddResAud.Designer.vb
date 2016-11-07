Namespace _1Dialogs.General.Add
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagAddResAud
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
            Me.title = New System.Windows.Forms.Label()
            Me.lbSource = New System.Windows.Forms.Label()
            Me.tbPath = New System.Windows.Forms.TextBox()
            Me.btnBrowse = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.lbResName = New System.Windows.Forms.Label()
            Me.tbResName = New System.Windows.Forms.TextBox()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.btnYoutube = New System.Windows.Forms.Button()
            Me.btnAudLib = New System.Windows.Forms.Button()
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
            Me.WaitTmr = New System.Windows.Forms.Timer(Me.components)
            Me.SuspendLayout()
            '
            'title
            '
            Me.title.AutoSize = True
            Me.title.Font = New System.Drawing.Font("Segoe UI Semilight", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.title.Location = New System.Drawing.Point(36, 22)
            Me.title.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.title.Name = "title"
            Me.title.Size = New System.Drawing.Size(203, 30)
            Me.title.TabIndex = 1
            Me.title.Text = "New Audio Resource"
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
            Me.tbPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tbPath.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.tbPath.Font = New System.Drawing.Font("Segoe UI Semilight", 13.0!)
            Me.tbPath.Location = New System.Drawing.Point(41, 184)
            Me.tbPath.Margin = New System.Windows.Forms.Padding(36, 5, 36, 20)
            Me.tbPath.Name = "tbPath"
            Me.tbPath.Size = New System.Drawing.Size(353, 31)
            Me.tbPath.TabIndex = 15
            Me.tbPath.TabStop = False
            '
            'btnBrowse
            '
            Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnBrowse.BackColor = System.Drawing.Color.Gainsboro
            Me.btnBrowse.FlatAppearance.BorderSize = 0
            Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnBrowse.Location = New System.Drawing.Point(393, 185)
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
            Me.btnCancel.Location = New System.Drawing.Point(206, 273)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(36, 15, 36, 15)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(130, 40)
            Me.btnCancel.TabIndex = 4
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
            Me.btnAdd.Location = New System.Drawing.Point(341, 273)
            Me.btnAdd.Margin = New System.Windows.Forms.Padding(36, 15, 36, 15)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(130, 40)
            Me.btnAdd.TabIndex = 5
            Me.btnAdd.Text = "&Add"
            Me.btnAdd.UseVisualStyleBackColor = False
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnClose.FlatAppearance.BorderSize = 0
            Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.ForeColor = System.Drawing.Color.White
            Me.btnClose.Location = New System.Drawing.Point(474, 2)
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
            Me.tbResName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbResName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tbResName.Font = New System.Drawing.Font("Segoe UI Semilight", 13.0!)
            Me.tbResName.Location = New System.Drawing.Point(41, 105)
            Me.tbResName.Margin = New System.Windows.Forms.Padding(36, 5, 36, 20)
            Me.tbResName.MaxLength = 30
            Me.tbResName.Name = "tbResName"
            Me.tbResName.Size = New System.Drawing.Size(430, 31)
            Me.tbResName.TabIndex = 0
            '
            'lbWarning
            '
            Me.lbWarning.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbWarning.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbWarning.ForeColor = System.Drawing.Color.White
            Me.lbWarning.Location = New System.Drawing.Point(41, 135)
            Me.lbWarning.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(430, 26)
            Me.lbWarning.TabIndex = 10
            Me.lbWarning.Text = "Name Cannot be Empty!"
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWarning.Visible = False
            '
            'btnYoutube
            '
            Me.btnYoutube.BackColor = System.Drawing.Color.Gainsboro
            Me.btnYoutube.BackgroundImage = Global.Entity.My.Resources.Resources.YouTube
            Me.btnYoutube.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.btnYoutube.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnYoutube.FlatAppearance.BorderSize = 0
            Me.btnYoutube.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnYoutube.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnYoutube.Location = New System.Drawing.Point(41, 253)
            Me.btnYoutube.Margin = New System.Windows.Forms.Padding(36, 20, 36, 20)
            Me.btnYoutube.Name = "btnYoutube"
            Me.btnYoutube.Size = New System.Drawing.Size(60, 60)
            Me.btnYoutube.TabIndex = 3
            Me.tt.SetToolTip(Me.btnYoutube, "Youtube Converter")
            Me.btnYoutube.UseVisualStyleBackColor = False
            '
            'btnAudLib
            '
            Me.btnAudLib.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnAudLib.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.btnAudLib.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnAudLib.FlatAppearance.BorderSize = 0
            Me.btnAudLib.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAudLib.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.btnAudLib.Location = New System.Drawing.Point(106, 253)
            Me.btnAudLib.Margin = New System.Windows.Forms.Padding(36, 20, 36, 20)
            Me.btnAudLib.Name = "btnAudLib"
            Me.btnAudLib.Size = New System.Drawing.Size(60, 60)
            Me.btnAudLib.TabIndex = 2
            Me.tt.SetToolTip(Me.btnAudLib, "Global Audio Resources")
            Me.btnAudLib.UseVisualStyleBackColor = False
            Me.btnAudLib.Visible = False
            '
            'WaitTmr
            '
            Me.WaitTmr.Interval = 20
            '
            'DiagAddResAud
            '
            Me.AcceptButton = Me.btnAdd
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(516, 335)
            Me.Controls.Add(Me.btnBrowse)
            Me.Controls.Add(Me.btnAudLib)
            Me.Controls.Add(Me.btnYoutube)
            Me.Controls.Add(Me.tbResName)
            Me.Controls.Add(Me.lbResName)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.btnAdd)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.tbPath)
            Me.Controls.Add(Me.lbSource)
            Me.Controls.Add(Me.title)
            Me.Controls.Add(Me.lbWarning)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(36, 20, 36, 20)
            Me.Name = "DiagAddResAud"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Add Image Resource"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents title As System.Windows.Forms.Label
        Friend WithEvents lbSource As System.Windows.Forms.Label
        Friend WithEvents tbPath As System.Windows.Forms.TextBox
        Friend WithEvents btnBrowse As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents lbResName As System.Windows.Forms.Label
        Friend WithEvents tbResName As System.Windows.Forms.TextBox
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents btnYoutube As System.Windows.Forms.Button
        Friend WithEvents btnAudLib As System.Windows.Forms.Button
        Friend WithEvents tt As System.Windows.Forms.ToolTip
        Friend WithEvents WaitTmr As System.Windows.Forms.Timer
    End Class
End NameSpace