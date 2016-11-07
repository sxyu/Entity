Namespace _0App
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class Frm0Loading
        Inherits Entity._0App.InitialSetup.IFmBase

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
            Me.tmrLoad = New System.Windows.Forms.Timer(Me.components)
            Me.updateChecker = New System.ComponentModel.BackgroundWorker()
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tmrAnim
            '
            Me.tmrAnim.Enabled = False
            '
            'tmrLoad
            '
            Me.tmrLoad.Enabled = True
            '
            'updateChecker
            '
            '
            'Frm0Loading
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(1378, 780)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(48, 22, 48, 22)
            Me.Name = "Frm0Loading"
            Me.ShowInTaskbar = False
            Me.Text = "Entity System"
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.tmrAnim, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents tmrLoad As System.Windows.Forms.Timer
        Friend WithEvents updateChecker As System.ComponentModel.BackgroundWorker
    End Class
End Namespace