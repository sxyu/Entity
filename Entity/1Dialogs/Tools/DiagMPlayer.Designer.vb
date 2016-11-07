Imports Entity._5Controls

Namespace _1Dialogs.Tools
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagMPlayer
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnPlay = New System.Windows.Forms.Button()
            Me.btnStop = New System.Windows.Forms.Button()
            Me.pb = New Entity._5Controls.FlatProgressBar()
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
            Me.btnClose.Location = New System.Drawing.Point(450, 2)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(35, 35)
            Me.btnClose.TabIndex = 1
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(5, 10)
            Me.Label1.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(138, 21)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Entity Audio Player"
            '
            'btnPlay
            '
            Me.btnPlay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnPlay.BackColor = System.Drawing.Color.Gainsboro
            Me.btnPlay.FlatAppearance.BorderSize = 0
            Me.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPlay.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPlay.ForeColor = System.Drawing.Color.Black
            Me.btnPlay.Location = New System.Drawing.Point(348, 94)
            Me.btnPlay.Margin = New System.Windows.Forms.Padding(53, 23, 0, 14)
            Me.btnPlay.Name = "btnPlay"
            Me.btnPlay.Size = New System.Drawing.Size(130, 40)
            Me.btnPlay.TabIndex = 0
            Me.btnPlay.TabStop = False
            Me.btnPlay.Tag = "0"
            Me.btnPlay.Text = "&Pause"
            Me.btnPlay.UseVisualStyleBackColor = False
            '
            'btnStop
            '
            Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnStop.BackColor = System.Drawing.Color.Gainsboro
            Me.btnStop.FlatAppearance.BorderSize = 0
            Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnStop.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnStop.ForeColor = System.Drawing.Color.Black
            Me.btnStop.Location = New System.Drawing.Point(213, 94)
            Me.btnStop.Margin = New System.Windows.Forms.Padding(53, 23, 0, 14)
            Me.btnStop.Name = "btnStop"
            Me.btnStop.Size = New System.Drawing.Size(130, 40)
            Me.btnStop.TabIndex = 1
            Me.btnStop.TabStop = False
            Me.btnStop.Tag = "0"
            Me.btnStop.Text = "&Stop"
            Me.btnStop.UseVisualStyleBackColor = False
            '
            'pb
            '
            Me.pb.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pb.BackColor = System.Drawing.Color.WhiteSmoke
            Me.pb.DrawBorder = False
            Me.pb.Location = New System.Drawing.Point(9, 45)
            Me.pb.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pb.Name = "pb"
            Me.pb.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.pb.ProgressText = ""
            Me.pb.Size = New System.Drawing.Size(469, 40)
            Me.pb.TabIndex = 2
            Me.pb.Vertical = False
            '
            'DiagMPlayer
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.CancelButton = Me.btnClose
            Me.ClientSize = New System.Drawing.Size(487, 145)
            Me.Controls.Add(Me.btnStop)
            Me.Controls.Add(Me.btnPlay)
            Me.Controls.Add(Me.pb)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.btnClose)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagMPlayer"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Entity System"
            Me.TopMost = True
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents pb As flatProgressBar
        Friend WithEvents btnPlay As System.Windows.Forms.Button
        Friend WithEvents btnStop As System.Windows.Forms.Button
    End Class
End NameSpace