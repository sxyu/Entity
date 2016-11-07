Imports Entity._5Controls

Namespace _1Dialogs.Popups
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagVolume
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
            Me.volumeSet = New percentSetter()
            Me.SuspendLayout()
            '
            'volumeSet
            '
            Me.volumeSet.AccuracyDigits = 0
            Me.volumeSet.BackColor = System.Drawing.Color.LightSteelBlue
            Me.volumeSet.Dock = System.Windows.Forms.DockStyle.Fill
            Me.volumeSet.Font = New System.Drawing.Font("Segoe UI SemiLight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.volumeSet.ForeColor = System.Drawing.Color.White
            Me.volumeSet.Location = New System.Drawing.Point(0, 0)
            Me.volumeSet.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
            Me.volumeSet.Name = "volumeSet"
            Me.volumeSet.ProgressColor = System.Drawing.Color.SteelBlue
            Me.volumeSet.ProgressText = Nothing
            Me.volumeSet.RightClickEnabled = False
            Me.volumeSet.Size = New System.Drawing.Size(124, 240)
            Me.volumeSet.TabIndex = 0
            Me.volumeSet.Value = 0.0R
            Me.volumeSet.Vertical = True
            '
            'DiagVolume
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.DPI
            Me.BackColor = System.Drawing.Color.fromArgb(120, 120, 120)
            Me.ClientSize = New System.Drawing.Size(124, 240)
            Me.Controls.Add(Me.volumeSet)
            Me.Font = New System.Drawing.Font("Segoe UI SemiLight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "DiagVolume"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "Entity System"
            Me.TopMost = True
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents volumeSet As percentSetter
    End Class
End Namespace