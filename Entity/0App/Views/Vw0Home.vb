Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports Entity._3Modules

Namespace _0App.Views

    Public Class Vw0Home
        Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            'docks in viewer
            Me.Dock = DockStyle.Fill
            If Not FileSystem.DirectoryExists(CurWorkDir.Path) Then
                FileSystem.CreateDirectory(CurWorkDir.Path)
            End If
            createProjFolders(CurProject.Path)
            If My.Settings.p1show Then
                btn1PRes.Show()
                btn1SRes.Show()
                btn1Subs.Show()
                btn1Exp.Text = "-"
            Else
                btn1PRes.Hide()
                btn1SRes.Hide()
                btn1Subs.Hide()
                btn1Exp.Text = "+"
            End If
            If My.Settings.p2show Then
                btn2Cues.Show()
                btn2Exp.Text = "-"
            Else
                btn2Cues.Hide()
                btn2Exp.Text = "+"
            End If
            If My.Settings.advshow Then
                btnAdvCtrls.Show()
                btnAdvCache.Show()
                btnAdvProj.Show()
                btnAdvRes.Show()
                btnAdvAdmin.Show()
                btnAdvExp.Text = "-"
            Else
                btnAdvCtrls.Hide()
                btnAdvCache.Hide()
                btnAdvRes.Hide()
                btnAdvProj.Hide()
                btnAdvAdmin.Hide()
                btnAdvExp.Text = "+"
            End If
        End Sub
        Private Sub btn1PRes_Click(sender As Object, e As EventArgs) Handles btn1PRes.Click
            Me.Focus()
            changeView(EntityView.images)
        End Sub

        Private Sub btn1Exp_Click(sender As Object, e As EventArgs) Handles btn1Exp.Click
            Me.Focus()
            If btn1Exp.Text = "+" Then
                btn1Exp.Text = "-"
                btn1Subs.Show()
                btn1SRes.Show()
                btn1PRes.Show()
                My.Settings.p1show = True
            Else
                btn1Exp.Text = "+"
                btn1Subs.Hide()
                btn1SRes.Hide()
                btn1PRes.Hide()
                My.Settings.p1show = False
            End If
            My.Settings.Save()
        End Sub

        Private Sub btn2Exp_Click(sender As Object, e As EventArgs) Handles btn2Exp.Click
            Me.Focus()
            If btn2Exp.Text = "+" Then
                btn2Exp.Text = "-"
                btn2Cues.Show()
                btn3Begin.Show()
                My.Settings.p2show = True
            Else
                btn2Exp.Text = "+"
                btn2Cues.Hide()
                btn3Begin.Hide()
                My.Settings.p2show = True
            End If
        End Sub
        Private Sub btnAdvExp_Click(sender As Object, e As EventArgs) Handles btnAdvExp.Click
            Me.Focus()
            If btnAdvExp.Text = "+" Then
                btnAdvExp.Text = "-"
                btnAdvCtrls.Show()
                btnAdvCache.Show()
                btnAdvRes.Show()
                btnAdvProj.Show()
                btnAdvAdmin.Show()
                My.Settings.advshow = True
            Else
                btnAdvExp.Text = "+"
                btnAdvCtrls.Hide()
                btnAdvCache.Hide()
                btnAdvProj.Hide()
                btnAdvRes.Hide()
                btnAdvAdmin.Hide()
                My.Settings.advshow = False
            End If
        End Sub

        Private Sub btn1Subs_Click(sender As Object, e As EventArgs) Handles btn1Subs.Click
            changeView(EntityView.lights)
        End Sub

        Private Sub btn1SRes_Click(sender As Object, e As EventArgs) Handles btn1SRes.Click
            changeView(EntityView.audio)
        End Sub

        Private Sub btn2Cues_Click(sender As Object, e As EventArgs) Handles btn2Cues.Click
            changeView(EntityView.cues)
        End Sub

        Private Sub btnAdvCache_Click(sender As Object, e As EventArgs) Handles btnAdvCache.Click
            Me.Focus()
            If MsgBox("If Entity is behaving weirdly (ex. the preview images are not updating)" & vbCrLf _
                      & "try clearing the cache." & vbCrLf & vbCrLf & _
                      "Warning: after clearing, you will need to re-open your show AND" & vbCrLf & "your resources will need to be re-cached." _
                      & vbCrLf & vbCrLf & "Re-caching can be extremely slow." & vbCrLf & "Are you sure you want to continue?", MsgBoxStyle.YesNo Or MsgBoxStyle. _
                                                                                                                                   Exclamation Or MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.ApplicationModal, "Clear Cache") = MsgBoxResult.Yes Then
                Dim di As New DirectoryInfo(CurProject.ResCachePath)
                For Each file As FileInfo In di.GetFiles
                    Try
                        file.Delete()
                    Catch ex As Exception
                        MsgBox("An error occurred while attempting to clear the cache:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, _
                               "Cache Clear Error")
                    End Try
                Next
                Dim di2 As New DirectoryInfo(CurProject.ResCachePath & "\wgraph\")
                For Each file As FileInfo In di2.GetFiles
                    Try
                        file.Delete()
                    Catch ex As Exception
                        MsgBox("An error occurred while attempting to clear the cache:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, _
                               "Cache Clear Error")
                    End Try
                Next
                MsgBox("The cache has been cleared. You will now be redirected to the show selection screen.", MsgBoxStyle.Information, "Cache Successfully Cleared")
                Frm3Viewer.btnAppChProj.PerformClick()
            End If
        End Sub

        Private Sub btnAdvCtrls_Click(sender As Object, e As EventArgs) Handles btnAdvCtrls.Click
            Me.Focus()
            With _6Misc.FrmLightingBd
                '.Width = Screen.PrimaryScreen.WorkingArea.Width
                '.Height = Screen.PrimaryScreen.WorkingArea.Height / 7 * 5
                .MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                .Left = CInt(Screen.PrimaryScreen.WorkingArea.Width / 2 - .Width / 2)
                .Top = CInt(Screen.PrimaryScreen.WorkingArea.Height / 2 - .Height / 2)
                .Opacity = 1
                _6Misc.FrmLightBox.Show()
                _6Misc.FrmLightBox.BringToFront()
                .Show()
                .BringToFront()
            End With
        End Sub

        Private Sub btnAdvProj_Click(sender As Object, e As EventArgs) Handles btnAdvProj.Click
            showSettingsForm(Frm4Settings.SettingsView.projection)
        End Sub

        Private Sub btnAdvRes_Click(sender As Object, e As EventArgs) Handles btnAdvRes.Click
            showSettingsForm(Frm4Settings.SettingsView.resources)
        End Sub

        Private Sub btnAdvAdmin_Click(sender As Object, e As EventArgs) Handles btnAdvAdmin.Click
            showSettingsForm(Frm4Settings.SettingsView.admin)
        End Sub
        Private Sub ShowSettingsForm(ByVal view As Frm4Settings.SettingsView)
            Me.Focus()
            Using frm As New Frm4Settings
                With frm
                    .Width = CInt(Screen.PrimaryScreen.Bounds.Width / 7 * 6)
                    .Height = CInt(Screen.PrimaryScreen.Bounds.Height / 7 * 5)
                    .Left = CInt(Screen.PrimaryScreen.Bounds.Width / 2 - .Width / 2)
                    .Top = CInt(Screen.PrimaryScreen.Bounds.Height / 2 - .Height / 2)
                    .Opacity = 1
                    .View = view
                    .ShowDialog()
                    .BringToFront()
                End With
            End Using
        End Sub

        Private Sub btn3Begin_Click(sender As Object, e As EventArgs) Handles btn3Begin.Click
            Frm5ShowUI.Show()
            Me.ParentForm.Close()
        End Sub

        Private Sub vw0Home_ParentChanged(sender As Object, e As EventArgs) Handles MyBase.ParentChanged
            If Me.ParentForm IsNot Nothing Then
                If Cues.Count > 0 Then
                    btn3Begin.Enabled = True
                Else
                    btn3Begin.Enabled = False
                End If
            End If
        End Sub

        Private Sub lb3_Click(sender As Object, e As EventArgs)

        End Sub
    End Class
End Namespace