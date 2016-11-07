Namespace _1Dialogs.Popups
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagWebViewer
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
            Me.btnClose = New System.Windows.Forms.Button()
            Me.title = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.wbContent = New System.Windows.Forms.WebBrowser()
            Me.SuspendLayout()
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
            Me.btnClose.Location = New System.Drawing.Point(692, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 1
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'title
            '
            Me.title.AutoSize = True
            Me.title.Location = New System.Drawing.Point(41, 31)
            Me.title.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.title.Name = "title"
            Me.title.Size = New System.Drawing.Size(75, 21)
            Me.title.TabIndex = 3
            Me.title.Text = "Title Here"
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
            Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.ForeColor = System.Drawing.Color.White
            Me.btnOK.Location = New System.Drawing.Point(581, 415)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(130, 40)
            Me.btnOK.TabIndex = 5
            Me.btnOK.Text = "OK"
            Me.btnOK.UseVisualStyleBackColor = False
            '
            'wbContent
            '
            Me.wbContent.IsWebBrowserContextMenuEnabled = False
            Me.wbContent.Location = New System.Drawing.Point(2, 67)
            Me.wbContent.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.wbContent.MinimumSize = New System.Drawing.Size(213, 91)
            Me.wbContent.Name = "wbContent"
            Me.wbContent.ScriptErrorsSuppressed = True
            Me.wbContent.Size = New System.Drawing.Size(725, 340)
            Me.wbContent.TabIndex = 6
            '
            'DiagWebViewer
            '
            Me.AcceptButton = Me.btnOK
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(729, 463)
            Me.Controls.Add(Me.wbContent)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.title)
            Me.Controls.Add(Me.btnClose)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagWebViewer"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Entity System"
            Me.TopMost = True
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents title As System.Windows.Forms.Label
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents wbContent As System.Windows.Forms.WebBrowser
    End Class
End Namespace