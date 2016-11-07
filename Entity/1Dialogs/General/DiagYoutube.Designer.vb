Imports Entity._5Controls

Namespace _1Dialogs.General
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagYoutube
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
            Me.btnClose = New System.Windows.Forms.Button()
            Me.tbURL = New System.Windows.Forms.TextBox()
            Me.wb = New System.Windows.Forms.WebBrowser()
            Me.btnDownload = New System.Windows.Forms.Button()
            Me.bw = New System.ComponentModel.BackgroundWorker()
            Me.lbWarning = New System.Windows.Forms.Label()
            Me.msgCheck = New System.Windows.Forms.Timer(Me.components)
            Me.btnMin = New System.Windows.Forms.Button()
            Me.backPnl = New System.Windows.Forms.Panel()
            Me.bottomPnl = New System.Windows.Forms.Panel()
            Me.btnAd = New System.Windows.Forms.Button()
            Me.pnl = New System.Windows.Forms.Panel()
            Me.lbTitle = New System.Windows.Forms.Label()
            Me.progress = New Entity._5Controls.FlatProgressBar()
            Me.backPnl.SuspendLayout()
            Me.bottomPnl.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnClose
            '
            Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClose.BackColor = System.Drawing.Color.Transparent
            Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnClose.FlatAppearance.BorderSize = 0
            Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
            Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnClose.Location = New System.Drawing.Point(869, 6)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(34, 29)
            Me.btnClose.TabIndex = 5
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'tbURL
            '
            Me.tbURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tbURL.BackColor = System.Drawing.Color.LightGray
            Me.tbURL.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tbURL.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbURL.ForeColor = System.Drawing.SystemColors.WindowFrame
            Me.tbURL.Location = New System.Drawing.Point(22, 6)
            Me.tbURL.Name = "tbURL"
            Me.tbURL.Size = New System.Drawing.Size(532, 26)
            Me.tbURL.TabIndex = 0
            '
            'wb
            '
            Me.wb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.wb.Location = New System.Drawing.Point(-1, 58)
            Me.wb.MinimumSize = New System.Drawing.Size(20, 20)
            Me.wb.Name = "wb"
            Me.wb.Size = New System.Drawing.Size(909, 256)
            Me.wb.TabIndex = 0
            Me.wb.Url = New System.Uri("http://www.youtube.com", System.UriKind.Absolute)
            '
            'btnDownload
            '
            Me.btnDownload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnDownload.BackColor = System.Drawing.Color.CornflowerBlue
            Me.btnDownload.Enabled = False
            Me.btnDownload.FlatAppearance.BorderSize = 0
            Me.btnDownload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue
            Me.btnDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
            Me.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDownload.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDownload.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnDownload.Location = New System.Drawing.Point(809, 0)
            Me.btnDownload.Margin = New System.Windows.Forms.Padding(0, 10, 0, 3)
            Me.btnDownload.Name = "btnDownload"
            Me.btnDownload.Size = New System.Drawing.Size(100, 38)
            Me.btnDownload.TabIndex = 1
            Me.btnDownload.TabStop = False
            Me.btnDownload.Tag = "0"
            Me.btnDownload.Text = "Download"
            Me.btnDownload.UseVisualStyleBackColor = False
            '
            'bw
            '
            Me.bw.WorkerReportsProgress = True
            Me.bw.WorkerSupportsCancellation = True
            '
            'lbWarning
            '
            Me.lbWarning.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbWarning.AutoSize = True
            Me.lbWarning.Font = New System.Drawing.Font("Segoe UI Semilight", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbWarning.Location = New System.Drawing.Point(628, 9)
            Me.lbWarning.Name = "lbWarning"
            Me.lbWarning.Size = New System.Drawing.Size(181, 20)
            Me.lbWarning.TabIndex = 3
            Me.lbWarning.Text = "Not a valid Youtube video."
            Me.lbWarning.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbWarning.Visible = False
            '
            'msgCheck
            '
            Me.msgCheck.Interval = 500
            '
            'btnMin
            '
            Me.btnMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnMin.BackColor = System.Drawing.Color.Transparent
            Me.btnMin.FlatAppearance.BorderSize = 0
            Me.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
            Me.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
            Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMin.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnMin.Location = New System.Drawing.Point(831, 6)
            Me.btnMin.Name = "btnMin"
            Me.btnMin.Size = New System.Drawing.Size(34, 29)
            Me.btnMin.TabIndex = 4
            Me.btnMin.TabStop = False
            Me.btnMin.Text = "-"
            Me.btnMin.UseVisualStyleBackColor = False
            '
            'backPnl
            '
            Me.backPnl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.backPnl.BackColor = System.Drawing.Color.LightGray
            Me.backPnl.Controls.Add(Me.btnDownload)
            Me.backPnl.Controls.Add(Me.progress)
            Me.backPnl.Controls.Add(Me.tbURL)
            Me.backPnl.Location = New System.Drawing.Point(0, 314)
            Me.backPnl.Name = "backPnl"
            Me.backPnl.Size = New System.Drawing.Size(908, 38)
            Me.backPnl.TabIndex = 1
            '
            'bottomPnl
            '
            Me.bottomPnl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.bottomPnl.Controls.Add(Me.lbWarning)
            Me.bottomPnl.Location = New System.Drawing.Point(0, 354)
            Me.bottomPnl.Name = "bottomPnl"
            Me.bottomPnl.Size = New System.Drawing.Size(908, 37)
            Me.bottomPnl.TabIndex = 2
            '
            'btnAd
            '
            Me.btnAd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAd.BackColor = System.Drawing.Color.DimGray
            Me.btnAd.FlatAppearance.BorderSize = 0
            Me.btnAd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray
            Me.btnAd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
            Me.btnAd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAd.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.btnAd.Location = New System.Drawing.Point(785, 6)
            Me.btnAd.Name = "btnAd"
            Me.btnAd.Size = New System.Drawing.Size(40, 29)
            Me.btnAd.TabIndex = 3
            Me.btnAd.Text = "Ad"
            Me.btnAd.UseVisualStyleBackColor = False
            '
            'pnl
            '
            Me.pnl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pnl.BackColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(49, Byte), Integer), CType(CType(43, Byte), Integer))
            Me.pnl.BackgroundImage = Global.Entity.My.Resources.Resources.YouTube
            Me.pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
            Me.pnl.Location = New System.Drawing.Point(0, 58)
            Me.pnl.Name = "pnl"
            Me.pnl.Size = New System.Drawing.Size(908, 256)
            Me.pnl.TabIndex = 8
            Me.pnl.Visible = False
            '
            'lbTitle
            '
            Me.lbTitle.AutoSize = True
            Me.lbTitle.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTitle.Location = New System.Drawing.Point(18, 17)
            Me.lbTitle.Name = "lbTitle"
            Me.lbTitle.Size = New System.Drawing.Size(214, 25)
            Me.lbTitle.TabIndex = 6
            Me.lbTitle.Text = "Entity Youtube Converter"
            '
            'progress
            '
            Me.progress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.progress.BackColor = System.Drawing.Color.LightGray
            Me.progress.DrawBorder = False
            Me.progress.ForeColor = System.Drawing.Color.White
            Me.progress.Location = New System.Drawing.Point(545, 1)
            Me.progress.Name = "progress"
            Me.progress.ProgressColor = System.Drawing.Color.MediumSeaGreen
            Me.progress.ProgressText = ""
            Me.progress.Size = New System.Drawing.Size(264, 38)
            Me.progress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
            Me.progress.TabIndex = 2
            Me.progress.Vertical = False
            '
            'DiagYoutube
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.DimGray
            Me.ClientSize = New System.Drawing.Size(909, 392)
            Me.Controls.Add(Me.pnl)
            Me.Controls.Add(Me.btnAd)
            Me.Controls.Add(Me.btnMin)
            Me.Controls.Add(Me.wb)
            Me.Controls.Add(Me.lbTitle)
            Me.Controls.Add(Me.btnClose)
            Me.Controls.Add(Me.backPnl)
            Me.Controls.Add(Me.bottomPnl)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "DiagYoutube"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Youtube Converter"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.backPnl.ResumeLayout(False)
            Me.backPnl.PerformLayout()
            Me.bottomPnl.ResumeLayout(False)
            Me.bottomPnl.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents tbURL As System.Windows.Forms.TextBox
        Friend WithEvents btnDownload As System.Windows.Forms.Button
        Friend WithEvents bw As System.ComponentModel.BackgroundWorker
        Friend WithEvents progress As FlatProgressBar
        Friend WithEvents lbWarning As System.Windows.Forms.Label
        Friend WithEvents msgCheck As System.Windows.Forms.Timer
        Friend WithEvents wb As System.Windows.Forms.WebBrowser
        Friend WithEvents btnMin As System.Windows.Forms.Button
        Friend WithEvents backPnl As System.Windows.Forms.Panel
        Friend WithEvents bottomPnl As System.Windows.Forms.Panel
        Friend WithEvents btnAd As System.Windows.Forms.Button
        Friend WithEvents pnl As System.Windows.Forms.Panel
        Friend WithEvents lbTitle As System.Windows.Forms.Label
    End Class
End Namespace