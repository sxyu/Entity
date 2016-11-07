Imports Entity._5Controls

Namespace _0App.Views
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Vw3Images
        Inherits System.Windows.Forms.UserControl

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
            Me.btnEdit = New System.Windows.Forms.Button()
            Me.btnDel = New System.Windows.Forms.Button()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.cbEffect = New System.Windows.Forms.ComboBox()
            Me.lbEffect = New System.Windows.Forms.Label()
            Me.tt = New System.Windows.Forms.ToolTip(Me.components)
            Me.lv = New Entity._5Controls.listViewX()
            Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
            Me.SuspendLayout()
            '
            'btnEdit
            '
            Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnEdit.Enabled = False
            Me.btnEdit.FlatAppearance.BorderSize = 0
            Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEdit.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEdit.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnEdit.Location = New System.Drawing.Point(798, 643)
            Me.btnEdit.Margin = New System.Windows.Forms.Padding(64, 37, 64, 37)
            Me.btnEdit.Name = "btnEdit"
            Me.btnEdit.Size = New System.Drawing.Size(130, 40)
            Me.btnEdit.TabIndex = 2
            Me.btnEdit.Text = "&Edit Image"
            Me.btnEdit.UseVisualStyleBackColor = False
            '
            'btnDel
            '
            Me.btnDel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnDel.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnDel.Enabled = False
            Me.btnDel.FlatAppearance.BorderSize = 0
            Me.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDel.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDel.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnDel.Location = New System.Drawing.Point(933, 643)
            Me.btnDel.Margin = New System.Windows.Forms.Padding(64, 37, 64, 37)
            Me.btnDel.Name = "btnDel"
            Me.btnDel.Size = New System.Drawing.Size(130, 40)
            Me.btnDel.TabIndex = 3
            Me.btnDel.Text = "&Delete Image"
            Me.btnDel.UseVisualStyleBackColor = False
            '
            'btnAdd
            '
            Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnAdd.FlatAppearance.BorderSize = 0
            Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAdd.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAdd.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.btnAdd.Location = New System.Drawing.Point(663, 643)
            Me.btnAdd.Margin = New System.Windows.Forms.Padding(64, 37, 64, 37)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(130, 40)
            Me.btnAdd.TabIndex = 1
            Me.btnAdd.Text = "&Add Image"
            Me.btnAdd.UseVisualStyleBackColor = False
            '
            'cbEffect
            '
            Me.cbEffect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cbEffect.BackColor = System.Drawing.SystemColors.Window
            Me.cbEffect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbEffect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cbEffect.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cbEffect.FormattingEnabled = True
            Me.cbEffect.Location = New System.Drawing.Point(835, 22)
            Me.cbEffect.Margin = New System.Windows.Forms.Padding(48, 22, 48, 22)
            Me.cbEffect.Name = "cbEffect"
            Me.cbEffect.Size = New System.Drawing.Size(228, 28)
            Me.cbEffect.TabIndex = 4
            Me.tt.SetToolTip(Me.cbEffect, "The transition effect to use for the image preview.")
            Me.cbEffect.Visible = False
            '
            'lbEffect
            '
            Me.lbEffect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbEffect.AutoSize = True
            Me.lbEffect.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbEffect.Location = New System.Drawing.Point(701, 25)
            Me.lbEffect.Margin = New System.Windows.Forms.Padding(48, 0, 48, 0)
            Me.lbEffect.Name = "lbEffect"
            Me.lbEffect.Size = New System.Drawing.Size(127, 20)
            Me.lbEffect.TabIndex = 12
            Me.lbEffect.Text = "Preview Transition:"
            Me.tt.SetToolTip(Me.lbEffect, "The transition effect to use for the image preview.")
            Me.lbEffect.Visible = False
            '
            'tt
            '
            Me.tt.AutoPopDelay = 5000
            Me.tt.InitialDelay = 1000
            Me.tt.ReshowDelay = 200
            '
            'lv
            '
            Me.lv.Activation = System.Windows.Forms.ItemActivation.TwoClick
            Me.lv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lv.BackColor = System.Drawing.Color.WhiteSmoke
            Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID})
            Me.lv.Font = New System.Drawing.Font("Segoe UI Semilight", 11.0!)
            Me.lv.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lv.FullRowSelect = True
            Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
            Me.lv.HideSelection = False
            Me.lv.Location = New System.Drawing.Point(0, 67)
            Me.lv.Margin = New System.Windows.Forms.Padding(48, 22, 48, 22)
            Me.lv.Name = "lv"
            Me.lv.Size = New System.Drawing.Size(1100, 565)
            Me.lv.Sorting = System.Windows.Forms.SortOrder.Ascending
            Me.lv.TabIndex = 0
            Me.tt.SetToolTip(Me.lv, "Double click any image to preview.")
            Me.lv.UseCompatibleStateImageBehavior = False
            '
            'colID
            '
            Me.colID.Text = "ID"
            '
            'Vw3Images
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.AutoScroll = True
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Controls.Add(Me.lv)
            Me.Controls.Add(Me.lbEffect)
            Me.Controls.Add(Me.cbEffect)
            Me.Controls.Add(Me.btnEdit)
            Me.Controls.Add(Me.btnDel)
            Me.Controls.Add(Me.btnAdd)
            Me.Margin = New System.Windows.Forms.Padding(48, 22, 48, 22)
            Me.Name = "Vw3Images"
            Me.Size = New System.Drawing.Size(1100, 700)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnEdit As System.Windows.Forms.Button
        Friend WithEvents btnDel As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents cbEffect As System.Windows.Forms.ComboBox
        Friend WithEvents lbEffect As System.Windows.Forms.Label
        Friend WithEvents lv As listViewX
        Friend WithEvents colID As System.Windows.Forms.ColumnHeader
        Friend WithEvents tt As System.Windows.Forms.ToolTip

    End Class
End NameSpace