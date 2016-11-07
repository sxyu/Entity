Imports Entity._3Modules
Imports Entity._4Classes.Types.DmxEngine
Imports Entity._6Misc
Namespace _0App
    Public Class Frm4Settings
        Public Enum SettingsView
            Projection = 0
            Resources
            Admin
            Null
        End Enum

        Public Property View As SettingsView
        Private _curView As SettingsView
        Private _moving As Boolean
        Private _ppt As New Point

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            View = SettingsView.Null
            _curView = View
        End Sub

        Private Sub diagImageView_MouseDown(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseDown, title.MouseDown, formIcon.MouseDown
            _moving = True
            _ppt = e.Location
        End Sub

        Private Sub diagImageView_MouseMove(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseMove, title.MouseMove, formIcon.MouseMove
            If _moving Then
                Me.Location = New Point(Me.Left + e.X - _ppt.X, Me.Top + e.Y - _ppt.Y)
            End If
        End Sub

        Private Sub diagImageView_MouseUp(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseUp, title.MouseUp, formIcon.MouseUp
            _moving = False
        End Sub

        Public Sub SetView(newView As SettingsView)
            viewer.Focus()
            If _curView <> newView Then
                Me.viewer.Controls.Clear()
                ReInitSettings()
                _curView = newView
                View = _curView
                tabProj.BackColor = Color.Gainsboro
                tabRes.BackColor = Color.Gainsboro
                tabAdmin.BackColor = Color.Gainsboro
                tabProj.FlatAppearance.MouseOverBackColor = Color.FromArgb(170,170,170)
                tabRes.FlatAppearance.MouseOverBackColor = Color.FromArgb(170,170,170)
                tabAdmin.FlatAppearance.MouseOverBackColor = Color.FromArgb(170,170,170)
                tabProj.FlatAppearance.MouseDownBackColor = Color.fromArgb(100, 100, 100)
                tabRes.FlatAppearance.MouseDownBackColor = Color.fromArgb(100, 100, 100)
                tabAdmin.FlatAppearance.MouseDownBackColor = Color.fromArgb(100, 100, 100)
                My.Settings.favSettingsView = newView
                My.Settings.Save()
                Select Case newView
                    Case SettingsView.Projection
                        tabProj.BackColor = Color.WhiteSmoke
                        tabProj.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                        tabProj.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                        SettingsCache(0).Dock = DockStyle.Fill
                        Me.viewer.Controls.Add(SettingsCache(0))
                    Case SettingsView.Resources
                        tabRes.BackColor = Color.WhiteSmoke
                        tabRes.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                        tabRes.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                        SettingsCache(1).Dock = DockStyle.Fill
                        Me.viewer.Controls.Add(SettingsCache(1))
                    Case SettingsView.Admin
                        tabAdmin.BackColor = Color.WhiteSmoke
                        tabAdmin.FlatAppearance.MouseDownBackColor = Color.WhiteSmoke
                        tabAdmin.FlatAppearance.MouseOverBackColor = Color.WhiteSmoke
                        SettingsCache(2).Dock = DockStyle.Fill
                        Me.viewer.Controls.Add(SettingsCache(2))
                End Select
                Me.viewer.Refresh()
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub frmSettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            If Frm3Viewer.Visible Then
                Frm3Viewer.TopBar1.Panel1.Focus()
            ElseIf Frm2Launcher.Visible Then
                Frm2Launcher.TopBar.Panel1.Focus()
            End If
            frmLightBox.Close()
            Dim emptyArr(511) As Byte
            setDmx(emptyArr)
        End Sub

        Private Sub tabProj_Click(sender As Object, e As EventArgs) Handles tabProj.Click
            SetView(SettingsView.Projection)
        End Sub


        Private Sub tabRes_Click(sender As Object, e As EventArgs) Handles tabRes.Click
            SetView(SettingsView.Resources)
        End Sub

        Private Sub tabAdmin_Click(sender As Object, e As EventArgs) Handles tabAdmin.Click
            SetView(SettingsView.Admin)
        End Sub

        Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Icon = My.Resources.en
            initSettings()
            SetView(View)
        End Sub


        Private Sub frmSettings_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.D1
                        SetView(SettingsView.Projection)
                    Case Keys.D2
                        SetView(SettingsView.Resources)
                    Case Keys.D3
                        SetView(SettingsView.Admin)
                End Select
            End If
        End Sub

        Private Sub Frm4Settings_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub
    End Class
End Namespace