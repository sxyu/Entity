Namespace _5Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PercentSetter
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
            Me.tbEdit = New System.Windows.Forms.TextBox()
            Me.emptyMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.pb = New FlatProgressBar()
            Me.timerKeyDown = New System.Windows.Forms.Timer(Me.components)
            Me.SuspendLayout()
            '
            'tbEdit
            '
            Me.tbEdit.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tbEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tbEdit.ContextMenuStrip = Me.emptyMenu
            Me.tbEdit.Cursor = System.Windows.Forms.Cursors.Arrow
            Me.tbEdit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.tbEdit.Location = New System.Drawing.Point(3, 2)
            Me.tbEdit.MaxLength = 3
            Me.tbEdit.Multiline = True
            Me.tbEdit.Name = "tbEdit"
            Me.tbEdit.Size = New System.Drawing.Size(114, 29)
            Me.tbEdit.TabIndex = 2
            Me.tbEdit.Visible = False
            '
            'emptyMenu
            '
            Me.emptyMenu.Name = "emptyMenu"
            Me.emptyMenu.Size = New System.Drawing.Size(61, 4)
            '
            'pb
            '
            Me.pb.BackColor = System.Drawing.Color.WhiteSmoke
            Me.pb.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pb.DrawBorder = False
            Me.pb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.pb.Location = New System.Drawing.Point(0, 0)
            Me.pb.Name = "pb"
            Me.pb.ProgressColor = System.Drawing.Color.fromArgb(100, 100, 100)
            Me.pb.ProgressText = "0%"
            Me.pb.Size = New System.Drawing.Size(303, 32)
            Me.pb.TabIndex = 1
            Me.pb.Vertical = False
            '
            'timerKeyDown
            '
            '
            'percentSetter
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.DPI
            Me.Controls.Add(Me.tbEdit)
            Me.Controls.Add(Me.pb)
            Me.Font = New System.Drawing.Font("Segoe UI SemiLight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.Name = "percentSetter"
            Me.Size = New System.Drawing.Size(303, 32)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents pb As FlatProgressBar
        Friend WithEvents tbEdit As System.Windows.Forms.TextBox
        Friend WithEvents emptyMenu As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents timerKeyDown As System.Windows.Forms.Timer

    End Class
End NameSpace