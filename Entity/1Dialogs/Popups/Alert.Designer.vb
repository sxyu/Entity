Namespace _1Dialogs.Popups
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Alert
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
            Me.timerDisappear = New System.Windows.Forms.Timer(Me.components)
            Me.btnOK = New System.Windows.Forms.Button()
            Me.dummy = New System.Windows.Forms.Panel()
            Me.SuspendLayout()
            '
            'timerDisappear
            '
            Me.timerDisappear.Enabled = True
            Me.timerDisappear.Interval = 500
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOK.BackColor = System.Drawing.Color.PaleVioletRed
            Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnOK.FlatAppearance.BorderSize = 0
            Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnOK.ForeColor = System.Drawing.Color.White
            Me.btnOK.Location = New System.Drawing.Point(206, -1)
            Me.btnOK.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(35, 35)
            Me.btnOK.TabIndex = 4
            Me.btnOK.TabStop = False
            Me.btnOK.Text = "x"
            Me.btnOK.UseVisualStyleBackColor = False
            '
            'dummy
            '
            Me.dummy.Location = New System.Drawing.Point(128, -53)
            Me.dummy.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.dummy.Name = "dummy"
            Me.dummy.Size = New System.Drawing.Size(117, 46)
            Me.dummy.TabIndex = 5
            '
            'Alert
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.PaleVioletRed
            Me.ClientSize = New System.Drawing.Size(240, 115)
            Me.Controls.Add(Me.dummy)
            Me.Controls.Add(Me.btnOK)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.Name = "Alert"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "EnCOM Message Alert"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents timerDisappear As System.Windows.Forms.Timer
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents dummy As System.Windows.Forms.Panel
    End Class
End Namespace