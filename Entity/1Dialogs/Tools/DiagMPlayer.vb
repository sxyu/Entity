
Imports Entity._3Modules
Imports Entity._2Namespaces.SfxSys

Namespace _1Dialogs.Tools
    Public Class DiagMPlayer
        Private _audPath As String
        Private _player As SoundEffect 'make use of my custom SoundEffect class to simplify the audio playing process
        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
        Dim moving As Boolean = False
        Dim ppt As New Point

        Private Sub diagMPlayer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            Try
                _audPath = ""
                _player.Dispose()
            Catch
            End Try
        End Sub

        Private Sub diagMPlayer_Load(sender As Object, e As EventArgs) Handles Me.Load
            Try
                'Cursor.Position = New Point(btnPlay.Left + Me.Left + btnPlay.Width \ 2, btnPlay.Top + Me.Top + btnPlay.Height \ 2)
                Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
                Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
                Me.Icon = My.Resources.en
                _player.Play()
                AddHandler _player.ProgressChanged, AddressOf PlayProgressChange
                AddHandler _player.Player.PlaybackStopped, AddressOf PlayStopped
            Catch
            End Try
        End Sub
        Private Sub diagImageView_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Label1.MouseDown
            moving = True
            ppt = e.Location
        End Sub

        Private Sub diagImageView_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Label1.MouseMove
            If moving Then
                Me.Location = New Point(Me.Left + e.X - ppt.X, Me.Top + e.Y - ppt.Y)
            End If
        End Sub

        Private Sub diagImageView_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, Label1.MouseUp
            moving = False
        End Sub

        Public Sub New(ByVal audPath As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Try
                _audPath = audPath
                If CurProject Is Nothing Then ' if no project is loaded
                    _player = New SoundEffect(_audPath, False)
                Else
                    If _audPath.Trim.StartsWith(CurProject.ResPath) Then
                        _player = New SoundEffect(IO.Path.GetFileNameWithoutExtension(_audPath).Trim, True)
                    Else
                        _player = New SoundEffect(_audPath, False)
                    End If
                End If
                pb.Value = 0
            Catch ex As Exception
                MsgBox("An error occurred while trying to create the audio player window. If this persists, please contact the Entity Team.", _
                       MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Error")
                MsgBox(ex.ToString)
            End Try
        End Sub
        Private dragging As Boolean = False
        Private Sub pb_MouseDown(sender As Object, e As MouseEventArgs) Handles pb.MouseDown
            calculateTimeByMousePos(e.X)
            dragging = True
        End Sub

        Private Sub pb_MouseMove(sender As Object, e As MouseEventArgs) Handles pb.MouseMove
            Try
                If dragging Then
                    calculateTimeByMousePos(e.X)
                End If
            Catch ex As Exception
            End Try
        End Sub
        Private Sub pb_MouseUp(sender As Object, e As MouseEventArgs) Handles pb.MouseUp
            calculateTimeByMousePos(e.X)
            dragging = False
        End Sub
        Private Sub CalculateTimeByMousePos(mouseX As Integer)
            Try
                Dim ratio As Double = mouseX / pb.Width
                If ratio > 1 Then ratio = 1
                If ratio < 0 Then ratio = 0
                pb.Value = CInt(ratio * 100)
                _player.Ratio = ratio
            Catch ex As Exception
                Me.Close()
            End Try
        End Sub
        Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
            Try
                If btnPlay.Text = "&Play" Then
                    btnPlay.Text = "&Pause"
                    _player.Play()
                Else
                    btnPlay.Text = "&Play"
                    _player.Pause()
                End If
            Catch ex As Exception
                Me.Close()
            End Try
        End Sub

        Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
            _player.Reset()
            pb.Value = 0
            btnPlay.Text = "&Play"
            AddHandler _player.Player.PlaybackStopped, AddressOf PlayStopped
        End Sub

        Private Sub PlayStopped(sender As Object, e As NAudio.Wave.StoppedEventArgs)
            _player.Reset()
            pb.Value = 0
            btnPlay.Text = "&Play"
            AddHandler _player.Player.PlaybackStopped, AddressOf PlayStopped
        End Sub
        Private Sub PlayProgressChange(percent As Double)
            If pb.InvokeRequired Then
                pb.BeginInvoke(New MethodInvoker(Sub() pb.Value = CInt(percent)))
            Else
                pb.Value = CInt(percent)
            End If
        End Sub

        Private Sub diagMPlayer_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub

        'Private Sub diagMPlayer_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        '    Me.Close()
        'End Sub

        'Private Sub btnPreCalc_Click(sender As Object, e As EventArgs) Handles btnPreCalc.Click
        '    _player.PreCalculateFades()
        'End Sub
        'Private Sub ProgCh(percent As Double)
        '    If btnPreCalc.InvokeRequired Then
        '        btnPreCalc.Invoke(New MethodInvoker(Sub()
        '                                                btnPreCalc.Text = CStr(percent)
        '                                            End Sub))
        '    Else
        '        btnPreCalc.Text = CStr(percent)
        '    End If
        'End Sub
    End Class
End Namespace