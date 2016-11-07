Namespace _1Dialogs.Popups
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DiagCOM
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiagCOM))
            Me.rtb = New System.Windows.Forms.RichTextBox()
            Me.btnSend = New System.Windows.Forms.Button()
            Me.ToSend = New System.Windows.Forms.TextBox()
            Me.btnExpand = New System.Windows.Forms.Button()
            Me.pnlBG = New System.Windows.Forms.Panel()
            Me.pnlBG.SuspendLayout()
            Me.SuspendLayout()
            '
            'rtb
            '
            Me.rtb.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.rtb.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.rtb.Font = New System.Drawing.Font("Segoe UI Semilight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rtb.ForeColor = System.Drawing.Color.White
            Me.rtb.Location = New System.Drawing.Point(20, 61)
            Me.rtb.Margin = New System.Windows.Forms.Padding(32, 18, 32, 18)
            Me.rtb.Name = "rtb"
            Me.rtb.ReadOnly = True
            Me.rtb.Size = New System.Drawing.Size(390, 274)
            Me.rtb.TabIndex = 4
            Me.rtb.TabStop = False
            Me.rtb.Text = ""
            '
            'btnSend
            '
            Me.btnSend.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnSend.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnSend.FlatAppearance.BorderSize = 0
            Me.btnSend.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSend.Font = New System.Drawing.Font("Segoe UI Semilight", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSend.ForeColor = System.Drawing.Color.White
            Me.btnSend.Image = CType(resources.GetObject("btnSend.Image"), System.Drawing.Image)
            Me.btnSend.Location = New System.Drawing.Point(340, 2)
            Me.btnSend.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnSend.Name = "btnSend"
            Me.btnSend.Size = New System.Drawing.Size(43, 47)
            Me.btnSend.TabIndex = 5
            Me.btnSend.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.btnSend.UseVisualStyleBackColor = False
            '
            'ToSend
            '
            Me.ToSend.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.ToSend.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ToSend.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
            Me.ToSend.Location = New System.Drawing.Point(8, 9)
            Me.ToSend.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.ToSend.Multiline = True
            Me.ToSend.Name = "ToSend"
            Me.ToSend.Size = New System.Drawing.Size(331, 30)
            Me.ToSend.TabIndex = 6
            '
            'btnExpand
            '
            Me.btnExpand.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.btnExpand.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnExpand.FlatAppearance.BorderSize = 0
            Me.btnExpand.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnExpand.Font = New System.Drawing.Font("Segoe UI Semilight", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExpand.ForeColor = System.Drawing.Color.White
            Me.btnExpand.Location = New System.Drawing.Point(383, 2)
            Me.btnExpand.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.btnExpand.Name = "btnExpand"
            Me.btnExpand.Size = New System.Drawing.Size(45, 47)
            Me.btnExpand.TabIndex = 7
            Me.btnExpand.Text = "+"
            Me.btnExpand.TextAlign = System.Drawing.ContentAlignment.TopCenter
            Me.btnExpand.UseVisualStyleBackColor = False
            '
            'pnlBG
            '
            Me.pnlBG.BackColor = System.Drawing.SystemColors.Window
            Me.pnlBG.Controls.Add(Me.ToSend)
            Me.pnlBG.Location = New System.Drawing.Point(2, 2)
            Me.pnlBG.Margin = New System.Windows.Forms.Padding(32, 14, 32, 14)
            Me.pnlBG.Name = "pnlBG"
            Me.pnlBG.Size = New System.Drawing.Size(341, 47)
            Me.pnlBG.TabIndex = 8
            '
            'DiagCOM
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(430, 390)
            Me.Controls.Add(Me.btnExpand)
            Me.Controls.Add(Me.btnSend)
            Me.Controls.Add(Me.rtb)
            Me.Controls.Add(Me.pnlBG)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.KeyPreview = True
            Me.Margin = New System.Windows.Forms.Padding(43, 18, 43, 18)
            Me.Name = "DiagCOM"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
            Me.Text = "Entity System"
            Me.TopMost = True
            Me.pnlBG.ResumeLayout(False)
            Me.pnlBG.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents rtb As System.Windows.Forms.RichTextBox
        Friend WithEvents btnSend As System.Windows.Forms.Button
        Friend WithEvents ToSend As System.Windows.Forms.TextBox
        Friend WithEvents btnExpand As System.Windows.Forms.Button
        Friend WithEvents pnlBG As System.Windows.Forms.Panel
    End Class
End Namespace