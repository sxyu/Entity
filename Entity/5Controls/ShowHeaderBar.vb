Imports System.Drawing.Text
Imports System.Timers
Imports CoreAudioApi
Imports Entity._0App
Imports Entity._1Dialogs.Popups
Imports Entity._3Modules

Namespace _5Controls

    Public Class ShowHeaderBar
        Dim _device As MMDevice
        Dim _timer As New Timer(200)

        Delegate Sub SafeTextDelegate(ByVal text As String)

        Delegate Sub SafeTooltipDelegate(ByVal text As String)

        Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
            Me.ParentForm.WindowState = FormWindowState.Minimized
            Panel1.Focus()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Panel1.Focus()
            If _
                MsgBox("Are you sure you want to stop presenting?", MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.YesNo,
                       "Stop Presenting") _
                = MsgBoxResult.Yes Then
                DirectCast(Me.ParentForm, Frm5ShowUI).EndShow()
            End If
        End Sub

        Private Sub top_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
            'paint logo
            Using whiteBr As New SolidBrush(Color.White)
                Using clrBr As New SolidBrush(Color.FromArgb(119, 127, 143))
                    Using sUI As New Font("Segoe UI SemiLight", 15)
                        e.Graphics.FillRectangle(clrBr, 10, 9, 32, 32)
                        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias
                        e.Graphics.DrawString("En", sUI, whiteBr, 12, 11)
                    End Using
                End Using
            End Using
        End Sub

        Private Sub topBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cur_time = DateTime.Now
            If My.Settings.timeFormat12 Then
                Dim hr As Integer = DateTime.Now.Hour
                Dim ampm As String = " AM"
                If hr = 24 Then hr = 0
                If hr > 12 Then
                    hr -= 12
                    ampm = " PM"
                End If
                lbTime.Text = R2Dgts(hr.ToString) & ":" & R2Dgts(CStr(DateTime.Now.Minute)) & ampm
            Else
                lbTime.Text = R2Dgts(CStr(DateTime.Now.Hour)) & ":" & R2Dgts(CStr(DateTime.Now.Minute))
            End If

            AddHandler _timer.Elapsed, AddressOf timer_Elapsed
            _timer.Start()

            title.Location = New Point(47, 12)

            btnClose.Location = New Point(Me.Width - 47, 9)
            btnMin.Location = New Point(btnClose.Left - 40, 9)
            btnAud.Location = New Point(btnMin.Left - 61, 9)
            btnCOM.Location = New Point(btnAud.Left - 40, 9)

            lbTime.Width = 82
            lbTime.Location = New Point(btnCOM.Left - 94, 10)
            Dim devEnum As New MMDeviceEnumerator()
            _device = devEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia)

            mainTT.SetToolTip(lbTime, "Click to toggle 24H / 12H formats.")
            mainTT.SetToolTip(btnAud,
                              "Master Volume: " & Math.Round(_device.AudioEndpointVolume.MasterVolumeLevelScalar * 100, 0) &
                              "%")
            AddHandler _device.AudioEndpointVolume.OnVolumeNotification, AddressOf VolumeChanged
        End Sub

        Dim cur_time As DateTime

        Private Sub VolumeChanged(data As AudioVolumeNotificationData)
            VolumeChangedBg()
        End Sub

        Private Sub VolumeChangedBg()
            Try
                If Me.InvokeRequired Then
                    Me.Invoke(New MethodInvoker(AddressOf VolumeChangedBg))
                Else
                    If _device.AudioEndpointVolume.Mute Then
                        mainTT.SetToolTip(btnAud, "Master Volume: 0%")
                    Else
                        mainTT.SetToolTip(btnAud,
                                          "Master Volume: " &
                                          Math.Round(_device.AudioEndpointVolume.MasterVolumeLevelScalar * 100, 0) & "%")
                    End If
                End If
            Catch
            End Try
        End Sub

        Private Sub UpdateTimeText(str As String)
            If str.Length > 0 Then lbTime.Text = str
        End Sub

        Private Sub timer_Elapsed(sender As Object, e As EventArgs)
            If DateTime.Now.Minute <> cur_time.Minute Then
                cur_time = DateTime.Now
                If My.Settings.timeFormat12 Then
                    Dim hr As Integer = DateTime.Now.Hour
                    Dim ampm As String = " AM"
                    If hr = 24 Then hr = 0
                    If hr > 12 Then
                        hr -= 12
                        ampm = " PM"
                    End If
                    Dim toRet As String = R2Dgts(hr.ToString) & ":" & R2Dgts(CStr(DateTime.Now.Minute)) & ampm
                    If lbTime.InvokeRequired Then
                        BeginInvoke(New SafeTextDelegate(AddressOf updateTimeText), toRet)
                    Else
                        lbTime.Text = toRet
                    End If
                Else
                    Dim toRet As String = R2Dgts(CStr(DateTime.Now.Hour)) & ":" & R2Dgts(CStr(DateTime.Now.Minute))
                    If lbTime.InvokeRequired Then
                        BeginInvoke(New SafeTextDelegate(AddressOf updateTimeText), toRet)
                    Else
                        lbTime.Text = toRet
                    End If
                End If
            End If
        End Sub


        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.Dock = DockStyle.Top
            Me.Height = 50
        End Sub

        Private Sub btnAud_Click(sender As Object, e As EventArgs) Handles btnAud.Click
            Panel1.Focus()
            If DiagVolume.Visible Then
                DiagVolume.Hide()
                Me.Panel1.Focus()
            Else
                DiagVolume.Location = New Point(btnAud.Left, Me.Height)
                DiagVolume.Show()
                DiagVolume.volumeSet.Focus()
            End If
        End Sub

        Private Sub btnSetup_Click(sender As Object, e As EventArgs)
            Panel1.Focus()
            Using frm As New Frm4Settings
                With frm
                    .Width = CInt(Screen.PrimaryScreen.WorkingArea.Width / 7 * 6)
                    .Height = CInt(Screen.PrimaryScreen.WorkingArea.Height / 7 * 6)
                    .Left = CInt(Screen.PrimaryScreen.WorkingArea.Width / 2 - .Width / 2)
                    .Top = CInt(Screen.PrimaryScreen.WorkingArea.Height / 2 - .Height / 2) + 2
                    .Opacity = 1
                    .View = CType(My.Settings.favSettingsView, Frm4Settings.SettingsView)
                    .ShowDialog()
                    .BringToFront()
                End With
            End Using
        End Sub

        Private Sub btnAbout_Click(sender As Object, e As EventArgs)
            Panel1.Focus()
            Using diag As New DiagAbout
                diag.ShowDialog()
            End Using
        End Sub

        Private Sub lbTime_MouseClick(sender As Object, e As MouseEventArgs) Handles lbTime.MouseClick
            Using tmp As New Bitmap(1, 1)
                Using g As Graphics = Graphics.FromImage(tmp)
                    Dim strSz As SizeF = g.MeasureString(lbTime.Text, lbTime.Font)
                    If e.X > lbTime.Width - strSz.Width - 1 Then
                        My.Settings.timeFormat12 = Not My.Settings.timeFormat12
                        cur_time = Nothing
                        My.Settings.Save()
                    End If
                End Using
            End Using
        End Sub

        Private Sub btnCOM_Click(sender As Object, e As EventArgs) Handles btnCOM.Click
            Me.Panel1.Focus()
            If DiagCOM.Visible Then
                DiagCOM.Hide()
            Else
                DiagCOM.Location = New Point(CInt(Me.ParentForm.Width / 2 - DiagCOM.Width / 2),
                             CInt(Me.ParentForm.Height / 2 - DiagCOM.Height / 2))
                DiagCOM.Show()
                DiagCOM.ToSend.Focus()
            End If
        End Sub
    End Class
End Namespace