﻿Namespace _5Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class HeaderBar
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HeaderBar))
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnCOM = New System.Windows.Forms.Button()
            Me.btnAud = New System.Windows.Forms.Button()
            Me.btnAbout = New System.Windows.Forms.Button()
            Me.btnSetup = New System.Windows.Forms.Button()
            Me.btnMin = New System.Windows.Forms.Button()
            Me.title = New System.Windows.Forms.Label()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.lbTime = New System.Windows.Forms.Label()
            Me.mainTT = New System.Windows.Forms.ToolTip(Me.components)
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.Panel1.Controls.Add(Me.btnCOM)
            Me.Panel1.Controls.Add(Me.btnAud)
            Me.Panel1.Controls.Add(Me.btnAbout)
            Me.Panel1.Controls.Add(Me.btnSetup)
            Me.Panel1.Controls.Add(Me.btnMin)
            Me.Panel1.Controls.Add(Me.title)
            Me.Panel1.Controls.Add(Me.btnClose)
            Me.Panel1.Controls.Add(Me.lbTime)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Font = New System.Drawing.Font("Segoe UI Semilight", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Margin = New System.Windows.Forms.Padding(48, 37, 48, 37)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(1000, 50)
            Me.Panel1.TabIndex = 32
            '
            'btnCOM
            '
            Me.btnCOM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnCOM.BackColor = System.Drawing.Color.Transparent
            Me.btnCOM.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCOM.FlatAppearance.BorderSize = 0
            Me.btnCOM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnCOM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnCOM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCOM.Image = CType(resources.GetObject("btnCOM.Image"), System.Drawing.Image)
            Me.btnCOM.Location = New System.Drawing.Point(-3848, 66)
            Me.btnCOM.Margin = New System.Windows.Forms.Padding(96, 44, 96, 44)
            Me.btnCOM.Name = "btnCOM"
            Me.btnCOM.Size = New System.Drawing.Size(38, 35)
            Me.btnCOM.TabIndex = 14
            Me.btnCOM.TabStop = False
            Me.btnCOM.Tag = ""
            Me.mainTT.SetToolTip(Me.btnCOM, "Open the EnCOM Chat Box")
            Me.btnCOM.UseVisualStyleBackColor = False
            '
            'btnAud
            '
            Me.btnAud.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAud.BackColor = System.Drawing.Color.Transparent
            Me.btnAud.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnAud.FlatAppearance.BorderSize = 0
            Me.btnAud.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnAud.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnAud.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAud.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAud.Image = CType(resources.GetObject("btnAud.Image"), System.Drawing.Image)
            Me.btnAud.Location = New System.Drawing.Point(-3048, 66)
            Me.btnAud.Margin = New System.Windows.Forms.Padding(96, 44, 96, 44)
            Me.btnAud.Name = "btnAud"
            Me.btnAud.Size = New System.Drawing.Size(38, 35)
            Me.btnAud.TabIndex = 13
            Me.btnAud.TabStop = False
            Me.btnAud.Text = " "
            Me.mainTT.SetToolTip(Me.btnAud, "Adjust System Audio Levels")
            Me.btnAud.UseVisualStyleBackColor = False
            '
            'btnAbout
            '
            Me.btnAbout.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnAbout.BackColor = System.Drawing.Color.Transparent
            Me.btnAbout.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnAbout.FlatAppearance.BorderSize = 0
            Me.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAbout.Location = New System.Drawing.Point(-1368, 66)
            Me.btnAbout.Margin = New System.Windows.Forms.Padding(96, 44, 96, 44)
            Me.btnAbout.Name = "btnAbout"
            Me.btnAbout.Size = New System.Drawing.Size(38, 35)
            Me.btnAbout.TabIndex = 12
            Me.btnAbout.TabStop = False
            Me.btnAbout.Text = "A"
            Me.mainTT.SetToolTip(Me.btnAbout, "About the Entity System" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tip: You can manually check for updates here.")
            Me.btnAbout.UseVisualStyleBackColor = False
            '
            'btnSetup
            '
            Me.btnSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSetup.BackColor = System.Drawing.Color.Transparent
            Me.btnSetup.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnSetup.FlatAppearance.BorderSize = 0
            Me.btnSetup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnSetup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSetup.Image = CType(resources.GetObject("btnSetup.Image"), System.Drawing.Image)
            Me.btnSetup.Location = New System.Drawing.Point(-2008, 66)
            Me.btnSetup.Margin = New System.Windows.Forms.Padding(96, 44, 96, 44)
            Me.btnSetup.Name = "btnSetup"
            Me.btnSetup.Size = New System.Drawing.Size(38, 35)
            Me.btnSetup.TabIndex = 10
            Me.btnSetup.TabStop = False
            Me.mainTT.SetToolTip(Me.btnSetup, "Settings and Global Resources")
            Me.btnSetup.UseVisualStyleBackColor = False
            '
            'btnMin
            '
            Me.btnMin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnMin.BackColor = System.Drawing.Color.Transparent
            Me.btnMin.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnMin.FlatAppearance.BorderSize = 0
            Me.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
            Me.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
            Me.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnMin.Location = New System.Drawing.Point(-392, 66)
            Me.btnMin.Margin = New System.Windows.Forms.Padding(96, 44, 96, 44)
            Me.btnMin.Name = "btnMin"
            Me.btnMin.Size = New System.Drawing.Size(38, 35)
            Me.btnMin.TabIndex = 9
            Me.btnMin.TabStop = False
            Me.btnMin.Text = "-"
            Me.mainTT.SetToolTip(Me.btnMin, "Minimize Window")
            Me.btnMin.UseVisualStyleBackColor = False
            '
            'title
            '
            Me.title.AutoSize = True
            Me.title.Font = New System.Drawing.Font("Segoe UI Semilight", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.title.Location = New System.Drawing.Point(48, 13)
            Me.title.Margin = New System.Windows.Forms.Padding(48, 0, 48, 0)
            Me.title.Name = "title"
            Me.title.Size = New System.Drawing.Size(121, 25)
            Me.title.TabIndex = 2
            Me.title.Text = "Entity System"
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
            Me.btnClose.Location = New System.Drawing.Point(248, 66)
            Me.btnClose.Margin = New System.Windows.Forms.Padding(96, 44, 96, 44)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(38, 35)
            Me.btnClose.TabIndex = 6
            Me.btnClose.TabStop = False
            Me.btnClose.Text = "x"
            Me.mainTT.SetToolTip(Me.btnClose, "Close App")
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'lbTime
            '
            Me.lbTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lbTime.BackColor = System.Drawing.Color.Transparent
            Me.lbTime.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbTime.Location = New System.Drawing.Point(309, 7)
            Me.lbTime.Margin = New System.Windows.Forms.Padding(48, 0, 48, 0)
            Me.lbTime.Name = "lbTime"
            Me.lbTime.Size = New System.Drawing.Size(393, 35)
            Me.lbTime.TabIndex = 11
            Me.lbTime.Text = "99:99"
            Me.lbTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.mainTT.SetToolTip(Me.lbTime, "Current Time")
            '
            'HeaderBar
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
            Me.Controls.Add(Me.Panel1)
            Me.Margin = New System.Windows.Forms.Padding(48, 22, 48, 22)
            Me.Name = "HeaderBar"
            Me.Size = New System.Drawing.Size(1000, 50)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnSetup As System.Windows.Forms.Button
        Friend WithEvents btnMin As System.Windows.Forms.Button
        Friend WithEvents title As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents btnAbout As System.Windows.Forms.Button
        Friend WithEvents lbTime As System.Windows.Forms.Label
        Friend WithEvents mainTT As System.Windows.Forms.ToolTip
        Friend WithEvents btnAud As System.Windows.Forms.Button
        Friend WithEvents btnCOM As System.Windows.Forms.Button

    End Class
End NameSpace