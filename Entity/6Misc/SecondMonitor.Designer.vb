Namespace _6Misc
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SecondMonitor
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
            Me.pb = New System.Windows.Forms.PictureBox()
            CType(Me.pb, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pb
            '
            Me.pb.BackColor = System.Drawing.Color.Black
            Me.pb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.pb.Cursor = System.Windows.Forms.Cursors.Cross
            Me.pb.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pb.Location = New System.Drawing.Point(0, 0)
            Me.pb.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pb.Name = "pb"
            Me.pb.Size = New System.Drawing.Size(2485, 1015)
            Me.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
            Me.pb.TabIndex = 0
            Me.pb.TabStop = False
            Me.pb.Tag = "_sm"
            '
            'SecondMonitor
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.Black
            Me.ClientSize = New System.Drawing.Size(2485, 1015)
            Me.Controls.Add(Me.pb)
            Me.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.Color.Black
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SecondMonitor"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Tag = "_sm"
            Me.Text = "Entity Systemor Interface"
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.pb, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pb As System.Windows.Forms.PictureBox
    End Class
End Namespace