<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUpdate
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
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.pb = New Entity_Updator.flatProgressBar()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lbStep = New System.Windows.Forms.Label()
        Me.lbTitle = New System.Windows.Forms.Label()
        Me.lbFile = New System.Windows.Forms.Label()
        Me.logo = New System.Windows.Forms.PictureBox()
        Me.lbVer = New System.Windows.Forms.Label()
        Me.lbDlSize = New System.Windows.Forms.Label()
        Me.lbSpeed = New System.Windows.Forms.Label()
        Me.lbTSize = New System.Windows.Forms.Label()
        CType(Me.logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bw
        '
        Me.bw.WorkerReportsProgress = True
        Me.bw.WorkerSupportsCancellation = True
        '
        'pb
        '
        Me.pb.BackColor = System.Drawing.Color.Gainsboro
        Me.pb.DrawBorder = False
        Me.pb.Location = New System.Drawing.Point(0, 212)
        Me.pb.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
        Me.pb.Name = "pb"
        Me.pb.ProgressColor = System.Drawing.Color.MediumSeaGreen
        Me.pb.ProgressText = ""
        Me.pb.Size = New System.Drawing.Size(771, 35)
        Me.pb.TabIndex = 23
        Me.pb.Vertical = False
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(625, 257)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(130, 40)
        Me.btnCancel.TabIndex = 20
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lbStep
        '
        Me.lbStep.AutoSize = True
        Me.lbStep.ForeColor = System.Drawing.Color.White
        Me.lbStep.Location = New System.Drawing.Point(505, 142)
        Me.lbStep.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
        Me.lbStep.Name = "lbStep"
        Me.lbStep.Size = New System.Drawing.Size(44, 21)
        Me.lbStep.TabIndex = 22
        Me.lbStep.Text = "1 of 1"
        '
        'lbTitle
        '
        Me.lbTitle.AutoSize = True
        Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTitle.ForeColor = System.Drawing.Color.White
        Me.lbTitle.Location = New System.Drawing.Point(95, 31)
        Me.lbTitle.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
        Me.lbTitle.Name = "lbTitle"
        Me.lbTitle.Size = New System.Drawing.Size(193, 25)
        Me.lbTitle.TabIndex = 14
        Me.lbTitle.Text = "Entity System Updater"
        '
        'lbFile
        '
        Me.lbFile.AutoSize = True
        Me.lbFile.ForeColor = System.Drawing.Color.White
        Me.lbFile.Location = New System.Drawing.Point(505, 113)
        Me.lbFile.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
        Me.lbFile.Name = "lbFile"
        Me.lbFile.Size = New System.Drawing.Size(74, 21)
        Me.lbFile.TabIndex = 21
        Me.lbFile.Text = "Entity.exe"
        '
        'logo
        '
        Me.logo.Location = New System.Drawing.Point(41, 23)
        Me.logo.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
        Me.logo.Name = "logo"
        Me.logo.Size = New System.Drawing.Size(39, 39)
        Me.logo.TabIndex = 15
        Me.logo.TabStop = False
        '
        'lbVer
        '
        Me.lbVer.AutoSize = True
        Me.lbVer.ForeColor = System.Drawing.Color.White
        Me.lbVer.Location = New System.Drawing.Point(227, 91)
        Me.lbVer.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
        Me.lbVer.Name = "lbVer"
        Me.lbVer.Size = New System.Drawing.Size(61, 21)
        Me.lbVer.TabIndex = 16
        Me.lbVer.Text = "Version"
        '
        'lbDlSize
        '
        Me.lbDlSize.ForeColor = System.Drawing.Color.White
        Me.lbDlSize.Location = New System.Drawing.Point(138, 138)
        Me.lbDlSize.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
        Me.lbDlSize.Name = "lbDlSize"
        Me.lbDlSize.Size = New System.Drawing.Size(150, 29)
        Me.lbDlSize.TabIndex = 19
        Me.lbDlSize.Text = "Downloaded Size"
        Me.lbDlSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbSpeed
        '
        Me.lbSpeed.ForeColor = System.Drawing.Color.White
        Me.lbSpeed.Location = New System.Drawing.Point(138, 113)
        Me.lbSpeed.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
        Me.lbSpeed.Name = "lbSpeed"
        Me.lbSpeed.Size = New System.Drawing.Size(150, 29)
        Me.lbSpeed.TabIndex = 17
        Me.lbSpeed.Text = "Speed"
        Me.lbSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbTSize
        '
        Me.lbTSize.ForeColor = System.Drawing.Color.White
        Me.lbTSize.Location = New System.Drawing.Point(138, 163)
        Me.lbTSize.Margin = New System.Windows.Forms.Padding(32, 0, 32, 0)
        Me.lbTSize.Name = "lbTSize"
        Me.lbTSize.Size = New System.Drawing.Size(150, 29)
        Me.lbTSize.TabIndex = 18
        Me.lbTSize.Text = "Total Size"
        Me.lbTSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(770, 309)
        Me.Controls.Add(Me.pb)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.lbStep)
        Me.Controls.Add(Me.lbTitle)
        Me.Controls.Add(Me.lbFile)
        Me.Controls.Add(Me.logo)
        Me.Controls.Add(Me.lbVer)
        Me.Controls.Add(Me.lbDlSize)
        Me.Controls.Add(Me.lbSpeed)
        Me.Controls.Add(Me.lbTSize)
        Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(43, 23, 43, 23)
        Me.Name = "FrmUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Entity System Patcher"
        CType(Me.logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
    Friend WithEvents pb As Entity_Updator.flatProgressBar
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents lbStep As System.Windows.Forms.Label
    Friend WithEvents lbTitle As System.Windows.Forms.Label
    Friend WithEvents lbFile As System.Windows.Forms.Label
    Friend WithEvents logo As System.Windows.Forms.PictureBox
    Friend WithEvents lbVer As System.Windows.Forms.Label
    Friend WithEvents lbDlSize As System.Windows.Forms.Label
    Friend WithEvents lbSpeed As System.Windows.Forms.Label
    Friend WithEvents lbTSize As System.Windows.Forms.Label

End Class
