Imports CoreAudioApi
Imports Entity._3Modules
Imports Entity._0App

Namespace _1Dialogs.Popups
    Public Class DiagVolume
        Private _device As MMDevice
        Private Sub btnClose_Click(sender As Object, e As EventArgs)
            Me.Close()
        End Sub
        Dim _moving As Boolean = False
        Dim _ppt As New Point

        Private Sub DiagVolume_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If IsPresMode Then
                e.Cancel = True
                Me.Hide()
            End If
        End Sub
        Private Sub diagVolume_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Dim devEnum As New MMDeviceEnumerator()
            _device = devEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia)
            volumeSet.Value = _device.AudioEndpointVolume.MasterVolumeLevelScalar * 100
            AddHandler _device.AudioEndpointVolume.OnVolumeNotification, AddressOf VolumeChanged
            Me.Width = 50
            Me.Height = 240
            _device.AudioEndpointVolume.Mute = False
            Me.Icon = My.Resources.en 'set icon
        End Sub
        Private Sub VolumeChanged(data As CoreAudioApi.AudioVolumeNotificationData)
            VolumeChangedBg()
        End Sub
        Private Sub VolumeChangedBg()
            On Error Resume Next
            If Me.InvokeRequired Then
                Me.Invoke(New MethodInvoker(AddressOf VolumeChangedBg))
            Else
                If _device.AudioEndpointVolume.Mute Then
                    volumeSet.Value = 0
                Else
                    volumeSet.Value = _device.AudioEndpointVolume.MasterVolumeLevelScalar * 100
                End If
            End If
        End Sub
        Private Sub volumeSet_ValueChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Handles volumeSet.ValueChanged
            If e.PropertyName = "value" Then
                If volumeSet.Value > 100 Then volumeSet.Value = 100
                If volumeSet.Value < 0 Then volumeSet.Value = 0
                _device.AudioEndpointVolume.MasterVolumeLevelScalar = CType(volumeSet.Value / 100, Single)
                _device.AudioEndpointVolume.Mute = False
            End If
        End Sub

        Private Sub diagVolume_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
            _device.AudioEndpointVolume.Mute = False
            If Frm2Launcher.Visible Then
                Frm2Launcher.TopBar.Panel1.Focus()
            ElseIf Frm5ShowUi.Visible Then
                Frm5ShowUi.TopBar1.Panel1.Focus()
            Else
                Frm3Viewer.TopBar1.Panel1.Focus()
            End If
            Me.Close()
        End Sub

        Private Sub DiagVolume_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
            If e.KeyCode = Keys.Escape Then
                If Frm2Launcher.Visible Then
                    Frm2Launcher.TopBar.Panel1.Focus()
                ElseIf Frm5ShowUI.Visible Then
                    Frm5ShowUI.TopBar1.Panel1.Focus()
                Else
                    Frm3Viewer.TopBar1.Panel1.Focus()
                End If
                Me.Close()
            End If
        End Sub
    End Class
End Namespace