Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports Entity._0App.InitialSetup
Imports Entity._3Modules
Imports Entity._4Classes.Types.DmxEngine

Namespace _0App

    Public Class Frm0Loading : Inherits IFmBase
        Public DontInit As Boolean = False
        Private Shared _first As Boolean = True

        Private Sub frmLoading_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            Dim strSize As SizeF = e.Graphics.MeasureString("Loading...", New Font("Segoe UI SemiLight", 30))
            e.Graphics.DrawString("Loading...", New Font("Segoe UI SemiLight", 30), Brushes.White _
                                  , CSng(e.ClipRectangle.Width / 2 - strSize.Width / 2),
                                  CSng(e.ClipRectangle.Height / 2 - strSize.Height / 2))
            Using br As New SolidBrush(Color.FromArgb(129, 137, 153))
                e.Graphics.FillRectangle(br,
                                         e.ClipRectangle.Width \ 2 - CLng(strSize.Width) \ 2 - 70,
                                         e.ClipRectangle.Height \ 2 - 32, 64, 64)
            End Using
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias
            e.Graphics.DrawString("En", New Font("Segoe UI SemiLight", 30), Brushes.White,
                                  e.ClipRectangle.Width \ 2 - CLng(strSize.Width) \ 2 - 67,
                                  e.ClipRectangle.Height \ 2 - 28)
        End Sub

        Private Sub tmrLoad_Tick(sender As Object, e As EventArgs) Handles tmrLoad.Tick
            'make sure this only runs once.
            'we have to wait a bit instead of calling all these methods on load so the loading form can show properly and not flicker.
            tmrLoad.Stop()
            'check if log on attempts limit reached
            If My.Settings.crecWait Then
                If My.Settings.waitTime < Now Then
                    My.Settings.crecWait = False
                    My.Settings.Save()
                Else
                    Me.Hide()
                    MsgBox(
                        "You have reached the maximum number of authentication attempts. Please wait until " &
                        My.Settings.waitTime _
                        & " before trying again.", MsgBoxStyle.Exclamation _
                                                   Or MsgBoxStyle.SystemModal Or MsgBoxStyle.MsgBoxSetForeground,
                        "User Authentication Subsystem")
                    End
                End If
            End If
            'show password form if a password is set
            If String.IsNullOrEmpty(My.Settings.userPassword) = False And _first And My.Settings.userPassword <> "0" Then
                Using diag As New Frm1Credentials
                    If FirstLaunch Then
                        If My.Computer.Network.IsAvailable Then
                            If My.Settings.autoUpdateCheck Then
                                updateChecker.RunWorkerAsync()
                            End If
                            FirstLaunch = False
                        End If
                    End If
                    diag.Focus()
                    If diag.ShowDialog() = DialogResult.OK Then
                        _first = False
                    Else
                        End
                    End If
                End Using
            End If
            Try
                _1Dialogs.Popups.DiagCOM.Show()
                _1Dialogs.Popups.DiagCOM.Hide()
            Catch
            End Try
            'make sure the launcher is not visible on start
            Frm2Launcher.Visible = False
            'if first run, initialize DMX channels.
            If Not DontInit Then
                Initialize()
            End If
            'start loading launcher, but keep hiding it for now
            Frm2Launcher.Show()
            'check if the user has a projector/secondary display
            'if there is then this method launches the projector cover form on that display.
            CheckSecondaryScreen()
            'when everything is done loading, show the launcher
            Frm2Launcher.Visible = True
        End Sub

        Private Sub frmLoading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If CurWorkDir Is Nothing Then
                If String.IsNullOrEmpty(My.Settings.workDir) Then
                    My.Settings.workDir = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Entity Shows"
                    My.Settings.Save()
                End If
                If Not Directory.Exists(My.Settings.workDir) Then
                    Directory.CreateDirectory(My.Settings.workDir)
                End If
                CurWorkDir = New _4Classes.Project.WorkingDirectory(My.Settings.workDir)
            End If

            Me.Icon = My.Resources.en
            'check if dlls are missing
            If Not File.Exists(Application.StartupPath & "\NAudio.dll") Then
                Me.Hide()
                MsgBox("Oops, an important dll ''NAudio.dll'' is missing. You may need to reinstall this application.",
                       MsgBoxStyle.Critical _
                       Or MsgBoxStyle.SystemModal Or MsgBoxStyle.MsgBoxSetForeground, "DLL Missing :(")
                End 'exit immediately
            End If
            If Not File.Exists(Application.StartupPath & "\CoreAudioApi.dll") Then
                Me.Hide()
                MsgBox("Oops, an important dll ''CoreAudioApi.dll'' is missing. You may need to reinstall this application.",
                       MsgBoxStyle.Critical _
                       Or MsgBoxStyle.SystemModal Or MsgBoxStyle.MsgBoxSetForeground, "DLL Missing :(")
                End 'exit immediately
            End If
            If Not File.Exists(Application.StartupPath & "\ftd2xx.dll") Then
                Me.Hide()
                MsgBox("Oops, an important dll ''ftd2xx.dll'' is missing. You may need to reinstall this application.",
                       MsgBoxStyle.Critical _
                       Or MsgBoxStyle.SystemModal Or MsgBoxStyle.MsgBoxSetForeground, "DLL Missing :(")
                End 'exit immediately
            End If

            'set up default light editor size
            Dim h As Integer = (Screen.PrimaryScreen.Bounds.Height - 134) / 2 - 20
            Dim ratio As Integer = h / 306
            Dim w As Integer = 613 * ratio
            DEFAULT_SIZE = New Size(w, h)

            If My.Settings.initialSetup Then
                FrmCinematic.Show()
                Me.Close()
                Exit Sub
            End If
        End Sub
        Friend Overrides Sub tmrAnim_Tick(sender As Object, e As EventArgs)
            If fadeReverse Then
                If Me.Opacity > 0.25 Then
                    invokeAction(Sub() Me.Opacity -= 0.2)
                Else
                    DirectCast(sender, Timers.Timer).Stop()
                    Me.ForceClose = True
                    invokeAction(Sub() Me.Close())
                End If
            Else
                If Me.Opacity < 0.9 Then
                    invokeAction(Sub() Me.Opacity += 0.1)
                Else
                    DirectCast(sender, Timers.Timer).Stop()
                    invokeAction(Sub() Me.Opacity = 1)
                End If
            End If
        End Sub
        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
        End Sub

        Private Sub frmLoading_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            _6Misc.SecondMonitor.CheckExit()
            _1Dialogs.Popups.DiagCOM.Close()
        End Sub

        Private Sub updateChecker_DoWork(sender As Object, e As DoWorkEventArgs) Handles updateChecker.DoWork
            CheckUpdate(True)
        End Sub
    End Class
End Namespace