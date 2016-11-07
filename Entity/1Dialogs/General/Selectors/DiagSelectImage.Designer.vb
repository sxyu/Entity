Imports Entity._5Controls

Namespace _1Dialogs.General.Selectors
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagSelectImage
        Inherits System.Windows.Forms.Form

        'UserControl overrides dispose to clean up the component list.
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiagSelectImage))
            Me.cbEffect = New System.Windows.Forms.ComboBox()
            Me.lbEffect = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.title = New System.Windows.Forms.Label()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
            Me.pnlBG = New System.Windows.Forms.Panel()
            Me.lv = New Entity._5Controls.listViewX()
            Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.lbDur = New System.Windows.Forms.Label()
            Me.tbDur = New System.Windows.Forms.TextBox()
            Me.lbDelay = New System.Windows.Forms.Label()
            Me.tbDelay = New System.Windows.Forms.TextBox()
            Me.pnlBG.SuspendLayout()
            Me.SuspendLayout()
            '
            'cbEffect
            '
            Me.cbEffect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cbEffect.BackColor = System.Drawing.SystemColors.Window
            Me.cbEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbEffect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbEffect.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbEffect.FormattingEnabled = True
            Me.cbEffect.Location = New System.Drawing.Point(853, 29)
            Me.cbEffect.Margin = New System.Windows.Forms.Padding(36, 24, 36, 24)
            Me.cbEffect.Name = "cbEffect"
            Me.cbEffect.Size = New System.Drawing.Size(200, 28)
            Me.cbEffect.TabIndex = 4
            Me.tt.SetToolTip(Me.cbEffect, resources.GetString("cbEffect.ToolTip"))
            Me.cbEffect.Visible = False
            '
            'lbEffect
            '
            Me.lbEffect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbEffect.AutoSize = True
            Me.lbEffect.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbEffect.ForeColor = System.Drawing.Color.White
            Me.lbEffect.Location = New System.Drawing.Point(776, 32)
            Me.lbEffect.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbEffect.Name = "lbEffect"
            Me.lbEffect.Size = New System.Drawing.Size(74, 20)
            Me.lbEffect.TabIndex = 12
            Me.lbEffect.Text = "Transition:"
            Me.tt.SetToolTip(Me.lbEffect, resources.GetString("lbEffect.ToolTip"))
            Me.lbEffect.Visible = False
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.BackColor = System.Drawing.Color.Gainsboro
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.btnOK.Location = New System.Drawing.Point(922, 473)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(72, 29, 72, 29)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(130, 40)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "&OK"
            Me.tt.SetToolTip(Me.btnOK, "Assign the selected image in the box above" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to the current cue.")
            Me.btnOK.UseVisualStyleBackColor = False
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
            Me.btnCancel.Location = New System.Drawing.Point(787, 473)
            Me.btnCancel.Margin = New System.Windows.Forms.Padding(72, 29, 72, 29)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(130, 40)
            Me.btnCancel.TabIndex = 1
            Me.btnCancel.Text = "&Cancel"
            Me.tt.SetToolTip(Me.btnCancel, "Closes the window without choosing a new image.")
            Me.btnCancel.UseVisualStyleBackColor = False
            '
            'title
            '
            Me.title.AutoSize = True
            Me.title.ForeColor = System.Drawing.Color.White
            Me.title.Location = New System.Drawing.Point(45, 32)
            Me.title.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.title.Name = "title"
            Me.title.Size = New System.Drawing.Size(108, 20)
            Me.title.TabIndex = 15
            Me.title.Text = "Image Selector"
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnClose.FlatAppearance.BorderSize = 0
            Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
            Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.ForeColor = System.Drawing.Color.White
            Me.btnClose.Location = New System.Drawing.Point(1061, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 16
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'tt
            '
            Me.tt.AutoPopDelay = 5000
            Me.tt.InitialDelay = 1000
            Me.tt.ReshowDelay = 200
            '
            'pnlBG
            '
            Me.pnlBG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnlBG.BackColor = System.Drawing.Color.WhiteSmoke
            Me.pnlBG.Controls.Add(Me.lv)
            Me.pnlBG.Location = New System.Drawing.Point(45, 76)
            Me.pnlBG.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.pnlBG.Name = "pnlBG"
            Me.pnlBG.Size = New System.Drawing.Size(1008, 376)
            Me.pnlBG.TabIndex = 17
            Me.tt.SetToolTip(Me.pnlBG, "Double click any image to preview.")
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID})
            Me.lv.Font = New System.Drawing.Font("Segoe UI Semilight", 11.0!)
            Me.lv.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            Me.lv.Location = New System.Drawing.Point(26, 24)
            Me.lv.Margin = New System.Windows.Forms.Padding(36, 24, 36, 24)
            Me.lv.MultiSelect = False
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(946, 331)
            Me.lv.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lv.TabIndex = 0
            Me.tt.SetToolTip(Me.lv, "Double click any image to preview.")
            Me.lv.UseCompatibleStateImageBehavior = False
            '
            'colID
            '
            Me.colID.Text = "ID"
            '
            'lbDur
            '
            Me.lbDur.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lbDur.AutoSize = True
            Me.lbDur.ForeColor = System.Drawing.Color.White
            Me.lbDur.Location = New System.Drawing.Point(147, 483)
            Me.lbDur.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbDur.Name = "lbDur"
            Me.lbDur.Size = New System.Drawing.Size(110, 20)
            Me.lbDur.TabIndex = 47
            Me.lbDur.Text = "s Fade Duration"
            '
            'tbDur
            '
            Me.tbDur.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tbDur.Location = New System.Drawing.Point(280, 480)
            Me.tbDur.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbDur.MaxLength = 5
            Me.tbDur.Name = "tbDur"
            Me.tbDur.Size = New System.Drawing.Size(100, 27)
            Me.tbDur.TabIndex = 44
            Me.tbDur.Text = "0.0"
            '
            'lbDelay
            '
            Me.lbDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lbDelay.AutoSize = True
            Me.lbDelay.ForeColor = System.Drawing.Color.White
            Me.lbDelay.Location = New System.Drawing.Point(382, 483)
            Me.lbDelay.Margin = New System.Windows.Forms.Padding(36, 0, 36, 0)
            Me.lbDelay.Name = "lbDelay"
            Me.lbDelay.Size = New System.Drawing.Size(55, 20)
            Me.lbDelay.TabIndex = 46
            Me.lbDelay.Text = "s Delay"
            '
            'tbDelay
            '
            Me.tbDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.tbDelay.Location = New System.Drawing.Point(45, 480)
            Me.tbDelay.Margin = New System.Windows.Forms.Padding(36, 14, 36, 14)
            Me.tbDelay.MaxLength = 5
            Me.tbDelay.Name = "tbDelay"
            Me.tbDelay.Size = New System.Drawing.Size(100, 27)
            Me.tbDelay.TabIndex = 45
            Me.tbDelay.Text = "0.0"
            '
            'DiagSelectImage
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(1098, 537)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.title)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.lbEffect)
            Me.Controls.Add(Me.cbEffect)
            Me.Controls.Add(Me.pnlBG)
            Me.Controls.Add(Me.lbDur)
            Me.Controls.Add(Me.tbDur)
            Me.Controls.Add(Me.lbDelay)
            Me.Controls.Add(Me.tbDelay)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(36, 24, 36, 24)
            Me.Name = "DiagSelectImage"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Tag = "imgsel"
            Me.Text = "Image Selector - Entity System"
            Me.pnlBG.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents cbEffect As System.Windows.Forms.ComboBox
        Friend WithEvents lbEffect As System.Windows.Forms.Label
        Friend WithEvents lv As listViewX
        Friend WithEvents colID As System.Windows.Forms.ColumnHeader
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents title As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents tt As System.Windows.Forms.ToolTip
        Friend WithEvents pnlBG As System.Windows.Forms.Panel
        Friend WithEvents lbDur As System.Windows.Forms.Label
        Friend WithEvents tbDur As System.Windows.Forms.TextBox
        Friend WithEvents lbDelay As System.Windows.Forms.Label
        Friend WithEvents tbDelay As System.Windows.Forms.TextBox

    End Class
End NameSpace