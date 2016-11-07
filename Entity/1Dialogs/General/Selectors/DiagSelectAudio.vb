Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports NAudio.Wave
Imports Entity._3Modules
Imports Entity._2Namespaces

Namespace _1Dialogs.General.Selectors

    Public Class DiagSelectAudio
        Dim _audioFileReader As AudioFileReader
        Dim _waveOutDevice As IWavePlayer
        'Dim ws As WaveStream
        Dim _curPlayTime As TimeSpan
        Dim _totTimeText As String = ""
        Dim _zeroTimeText As String = ""
        Dim _actualZeroTime As TimeSpan
        Dim _actualEndTime As TimeSpan
        Dim _lineLocation As Double = 0
        Dim _keyFrames As New KeyFrameList
        Private _draggingKeyFrame As Boolean = False
        Private _draggedKeyFrame As KeyFrame
        Public Property Selected As String = ""
        Public Property Delay As Double
        Public Property Duration As Double
        Public Property ShowDur As Boolean = False

        Private Sub CloseWaveOut()
            If _waveOutDevice IsNot Nothing Then
                _waveOutDevice.[Stop]()
            End If
            If _audioFileReader IsNot Nothing Then
                _audioFileReader = Nothing
            End If
            If _waveOutDevice IsNot Nothing Then
                _waveOutDevice.Dispose()
                _waveOutDevice = Nothing
            End If
        End Sub

        Private Sub audio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            tbDelay.Text = My.Settings.favDelayTime.ToString
            tbDur.Text = My.Settings.favFadeDur.ToString
            Me.Delay = My.Settings.favDelayTime
            Me.Duration = My.Settings.favFadeDur
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            If imgLst.Images.Count < 1 Then
                imgLst.Images.Add(My.Resources.Headphones)
            End If
            If Not FileSystem.DirectoryExists(CurWorkDir.Path) Then
                FileSystem.CreateDirectory(CurWorkDir.Path)
            End If
            CreateProjFolders(CurProject.Path)
            If IsPresMode Then
                ShowDur = False
                lbDelay.Hide()
                tbDelay.Hide()
            Else
                lbDelay.Show()
                tbDelay.Show()
            End If
            lbDur.Visible = ShowDur
            tbDur.Visible = ShowDur
            If Not ShowDur Then
                tbDelay.Left = tbDur.Left
                lbDelay.Left = lbDur.Left
            End If
            LoadLv()
        End Sub

        Private Sub MouseUpX() Handles fader.MouseUpX
            If _draggingKeyFrame Then
                If _curPlayTime >= _actualEndTime Then
                    _curPlayTime = _actualZeroTime
                ElseIf _curPlayTime < _actualZeroTime Then
                    _curPlayTime = _actualZeroTime
                End If
            End If
            saveKeyFrames()
            updateKeyFrames()
            dragging = False
            _draggingKeyFrame = False
            _draggedKeyFrame = Nothing
        End Sub

        Sub LoadLv()
            lv.Items.Clear()
            lv.Columns(0).Width = CInt(lv.Width * 0.9)
            Dim di As New DirectoryInfo(CurProject.ResPath)
            Dim dia As FileInfo() = di.GetFiles
            Dim toAdd As New List(Of ListViewItem)
            For Each f As FileInfo In dia
                If f.Extension.ToLower = ".wav" Or f.Extension.ToLower = ".mp3" Then
                    Dim it As New ListViewItem(Path.GetFileNameWithoutExtension(f.FullName))
                    it.Tag = f.FullName
                    'preview image
                    it.ImageIndex = 0
                    toAdd.Add(it)
                End If
            Next
            lv.Items.AddRange(toAdd.ToArray)
            If String.IsNullOrEmpty(Me.Selected) Then
                If lv.Items.Count > 0 Then lv.Items(0).Selected = True
            Else
                For Each it As ListViewItem In lv.Items
                    If it.Text = Me.Selected Then
                        it.Selected = True
                        Exit Sub
                    End If
                Next
                If lv.Items.Count > 0 Then lv.Items(0).Selected = True
            End If
        End Sub

        'code for dragging form
        Dim _moving As Boolean = False
        Dim _ppt As New Point

        Private Sub frmAddResImg_MouseDown(sender As Object, e As MouseEventArgs) Handles _
                                                                                      MyBase.MouseDown, title.MouseDown,
                                                                                      lbDelay.MouseDown, lbDur.MouseDown
            _moving = True
            _ppt = e.Location
        End Sub

        Private Sub frmAddResImg_MouseMove(sender As Object, e As MouseEventArgs) Handles _
                                                                                      MyBase.MouseMove, title.MouseMove,
                                                                                      lbDelay.MouseMove, lbDur.MouseMove
            If _moving Then
                Me.Location = New Point(Me.Left + e.X - _ppt.X, Me.Top + e.Y - _ppt.Y)
            End If
        End Sub

        Private Sub frmAddResImg_MouseUp(sender As Object, e As MouseEventArgs) Handles _
                                                                                    MyBase.MouseUp, title.MouseUp,
                                                                                    lbDelay.MouseUp, lbDur.MouseUp
            _moving = False
        End Sub

        Private Sub lv_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp, lv.KeyUp
            If lv.Focused Then
                If e.KeyCode = Keys.F5 Then
                    loadLv()
                ElseIf e.KeyCode = Keys.F2 Then
                    btnEdit_MClick(btnEdit, New MouseEventArgs(MouseButtons.Left, 1, 2, 2, 0))
                End If
            End If
            Me.btnEarlier_MouseUp(Me.btnEarlier, New MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0))
            Select Case e.KeyCode
                Case Keys.Space
                    Me.btnPlay.PerformClick()
                Case Keys.R
                    If Not e.Alt Then
                        Me.btnStop.PerformClick()
                    End If
            End Select
        End Sub

        Private Sub DiagSelectAudio_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            Select Case e.KeyCode
                Case Keys.Left
                    Me.btnEarlier_MDown(Me.btnEarlier, New EventArgs())
                Case Keys.Right
                    Me.btnLater_MDown(Me.btnLater, New EventArgs)
            End Select
        End Sub

        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            Dim selct As Integer = lv.SelectedItems.Count
            saveKeyFrames()
            If selct < 1 Then
                lbName.Show()
                tbName.Hide()
                btnEdit.BackColor = Color.fromArgb(120, 120, 120)
                editor.Hide()
                Try
                    If _audioFileReader IsNot Nothing Then
                        _audioFileReader.Dispose()
                    End If
                Catch ex As Exception
                End Try
                _keyFrames.Clear()
                _waveOutDevice = New WaveOut
                _curPlayTime = _actualZeroTime
                btnSelect.Enabled = False
            Else
                btnSelect.Enabled = True
                Me.Selected = lv.SelectedItems(0).Text
                Dim fileName As String = lv.SelectedItems(0).Tag.ToString
                If FileSystem.FileExists(fileName) Then
                    timerLineMove.Stop()
                    tbName.Text = lv.SelectedItems(0).Text
                    tbName.Hide()
                    lbName.Text = lv.SelectedItems(0).Text
                    _lineLocation = 0
                    waveForm.Refresh()
                    Try
                        _audioFileReader.Dispose()
                    Catch ex As Exception
                    End Try
                    _waveOutDevice = New WaveOut
                    AddHandler _waveOutDevice.PlaybackStopped, AddressOf playStopped
                    btnPlay.Text = "Play"
                    'load the waveform image
                    Dim temp As Bitmap = WFormCache.GetImageByName(Path.GetFileName(fileName))
                    waveForm.BackgroundImage = New Bitmap(temp)
                    _waveOutDevice.Stop()
                    _waveOutDevice = New WaveOut
                    _audioFileReader = New AudioFileReader(lv.SelectedItems(0).Tag.ToString)
                    '
                    _keyFrames.Clear()
                    loadKeyFrames(lv.SelectedItems(0).Text)
                    updateStartEnd()
                    _curPlayTime = _actualZeroTime
                    '
                    _waveOutDevice.Init(_audioFileReader)
                    Using read As New AudioFileReader(fileName)
                        With read
                            If .TotalTime.TotalHours >= 1 Then
                                _totTimeText = R2Dgts(CStr(.TotalTime.Hours)) & ":" & R2Dgts(CStr(.TotalTime.Minutes)) & ":" &
                                               R2Dgts(CStr(.TotalTime.Seconds))
                            Else
                                _totTimeText = R2Dgts(CStr(.TotalTime.Minutes)) & ":" & R2Dgts(CStr(.TotalTime.Seconds)) &
                                               ":" & R2Dgts(CStr(.TotalTime.Milliseconds))
                            End If
                        End With
                    End Using
                    lbTime.Text = _zeroTimeText & " / " & _totTimeText
                    editor.Show()
                Else
                    MsgBox("This resource no longer exists!")
                    loadLv()
                End If
            End If
        End Sub

        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function
        'make sure the lv gets focus 
        Private Sub btn_Focus(sender As Object, e As EventArgs)
            lv.Focus()
        End Sub

        Private Sub UpdateStartEnd()
            Dim lastKf As KeyFrame = _keyFrames.Items(0)
            Dim firstKf As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
            _actualZeroTime = TimeSpan.FromTicks(CLng(firstKf.Time / 100 * _audioFileReader.TotalTime.Ticks))
            _actualEndTime = TimeSpan.FromTicks(CLng(lastKf.Time / 100 * _audioFileReader.TotalTime.Ticks))
            _audioFileReader.Volume = CSng(firstKf.Volume / 100)

            If _audioFileReader.TotalTime.TotalHours >= 1 Then
                _zeroTimeText = R2Dgts(CStr(_actualZeroTime.Hours)) & ":" & R2Dgts(CStr(_actualZeroTime.Minutes)) & ":" &
                                R2Dgts(CStr(_actualZeroTime.Seconds))
            Else
                _zeroTimeText = R2Dgts(CStr(_actualZeroTime.Minutes)) & ":" & R2Dgts(CStr(_actualZeroTime.Seconds)) & ":" &
                                R2Dgts(CorrectMS(CStr(_actualZeroTime.Milliseconds)))
            End If
        End Sub

        Private Sub PlayStopped(sender As Object, e As StoppedEventArgs)
            btnPlay.Text = "&Play"
            fader.Enabled = True
            lbKF.Text = "Volume Keyframe Editor"
            btnKeyFrame.Show()
            fader.Width = btnKeyFrame.Left - fader.Left - 5
            _audioFileReader.CurrentTime = _curPlayTime
            lbTime.Text = _zeroTimeText & " / " & _totTimeText
            _lineLocation = 0
            fader.Enabled = True
            _curPlayTime = _actualZeroTime
            waveForm.Refresh()
            _waveOutDevice.Stop()
        End Sub
        Private Sub vw3Images_Layout(sender As Object, e As LayoutEventArgs) Handles MyBase.Layout
            lv.LargeImageList = ImageCache
        End Sub

        Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
            waveForm.Focus()
            If lv.SelectedItems.Count < 1 Then Exit Sub
            If _waveOutDevice.PlaybackState = PlaybackState.Playing Then
                _waveOutDevice.Pause()
                fader.Enabled = True
                btnKeyFrame.Show()
                fader.Width = btnKeyFrame.Left - fader.Left - 5
                lbKF.Text = "Volume Keyframe Editor"
                btnPlay.Text = "&Play"
                _curPlayTime = _audioFileReader.CurrentTime
                waveForm.Refresh()
                timerLineMove.Stop()
            ElseIf _waveOutDevice.PlaybackState = PlaybackState.Stopped Then
                btnPlay.Text = "&Pause"
                fader.Enabled = False
                btnKeyFrame.Hide()
                fader.Width = waveForm.Width
                lbKF.Text = "Current Volume"
                _audioFileReader.Volume = CSng(fader.Value / 100)
                _audioFileReader.CurrentTime = _curPlayTime
                _waveOutDevice.Play()
                timerLineMove.Start()
            Else
                btnPlay.Text = "&Pause"
                fader.Enabled = False
                btnKeyFrame.Hide()
                fader.Width = waveForm.Width
                lbKF.Text = "Current Volume"
                _audioFileReader.CurrentTime = _curPlayTime
                _audioFileReader.Volume = CSng(fader.Value / 100)
                _waveOutDevice.Play()
                timerLineMove.Start()
            End If
        End Sub

        Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
            If lv.SelectedItems.Count < 1 Then Exit Sub
            waveForm.Focus()
            Try
                lbKF.Text = "Volume Keyframe Editor"
                fader.Enabled = True
                timerLineMove.Stop()
                _waveOutDevice.Stop()
                _lineLocation = _keyFrames.Items(_keyFrames.Length - 1).Time
                waveForm.Refresh()
                _curPlayTime = _actualZeroTime
                _audioFileReader.CurrentTime = _curPlayTime
                Dim firstKf As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
                _audioFileReader.Volume = CSng(firstKf.Volume / 100)
                lbTime.Text = _zeroTimeText & " / " & _totTimeText
                btnPlay.Text = "&Play"
                btnKeyFrame.Show()
                fader.Width = btnKeyFrame.Left - fader.Left - 5
            Catch ex As Exception
            End Try
        End Sub


        Private Sub timerLineMove_Tick(sender As Object, e As EventArgs) Handles timerLineMove.Tick
            Try
                _curPlayTime = _audioFileReader.CurrentTime
                _lineLocation = _curPlayTime.Ticks / _audioFileReader.TotalTime.Ticks * 100
                updateTimeText()
                waveForm.Refresh()
                _audioFileReader.Volume = CSng(fader.Value / 100)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub vw2Audio_VisiChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
            Try
                If _waveOutDevice.PlaybackState = PlaybackState.Playing Then
                    If _waveOutDevice IsNot Nothing Then
                        btnPlay.Text = "&Play"
                        timerLineMove.Stop()
                        _waveOutDevice.Pause()
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub btnEdit_MClick(sender As Object, e As MouseEventArgs) Handles btnEdit.MouseUp
            If lv.SelectedItems.Count < 1 Then Exit Sub
            If e.Button = MouseButtons.Left Then
                waveForm.Focus()
                If tbName.Visible Then
                    If Not lbName.Text = tbName.Text Then
                        timerLineMove.Stop()
                        _waveOutDevice.Stop()
                        btnPlay.Text = "&Play"
                        lbName.Text = tbName.Text
                        Dim ext As String = Path.GetExtension(CStr(lv.SelectedItems(0).Tag))
                        Try
                            _audioFileReader.Close()
                            _waveOutDevice.Stop()
                        Catch ex As Exception
                        End Try
                        If lbName.Text.ToLower <> tbName.Text.ToLower Then
                            FileSystem.RenameFile(CStr(lv.SelectedItems(0).Tag), tbName.Text & ext)
                            If FileSystem.FileExists(CurProject.ResCachePath & "\wgraph\" & lv.SelectedItems(0).Text) Then
                                FileSystem.RenameFile(CurProject.ResCachePath & "\wgraph\" & lv.SelectedItems(0).Text, tbName.Text)
                            End If
                        Else
                            FileSystem.RenameFile(CStr(lv.SelectedItems(0).Tag), tbName.Text & ext & "2")
                            FileSystem.RenameFile(CurProject.ResPath & "\" & tbName.Text & ext & "2", tbName.Text & ext)
                            If FileSystem.FileExists(CurProject.ResCachePath & "\wgraph\" & lv.SelectedItems(0).Text) Then
                                FileSystem.RenameFile(CurProject.ResCachePath & "\wgraph\" & lv.SelectedItems(0).Text,
                                                      "$" & tbName.Text & ".temp")
                                FileSystem.RenameFile(CurProject.ResCachePath & "\wgraph\" & "$" & tbName.Text & ".temp",
                                                      tbName.Text)
                            End If
                        End If
                        WFormCache.ChangeKey(lv.SelectedItems(0).Text & ext, tbName.Text & ext)
                        lv.SelectedItems(0).Tag = CurProject.ResPath & "\" & tbName.Text & ext
                        _audioFileReader = New AudioFileReader(lv.SelectedItems(0).Tag.ToString)
                        _waveOutDevice.Init(_audioFileReader)
                        lv.SelectedItems(0).Text = tbName.Text
                    End If
                    lbName.Show()
                    tbName.Hide()
                    btnEdit.BackColor = Color.fromArgb(120, 120, 120)
                    lv.Sort()
                Else
                    tbName.Text = lbName.Text
                    lbName.Hide()
                    tbName.Show()
                    tbName.Focus()
                    tbName.SelectionStart = tbName.Text.Length
                    tbName.SelectionLength = 0
                    btnEdit.BackColor = Color.IndianRed
                End If
            ElseIf e.Button = MouseButtons.Right Then
                lbName.Show()
                tbName.Hide()
                btnEdit.BackColor = Color.fromArgb(120, 120, 120)
                lv.Sort()
                _0App.Frm3Viewer.AcceptButton = Nothing
            End If
        End Sub

        Private Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
            If String.IsNullOrEmpty(tbName.Text) Then
                lbWarning.Text = "Name Cannot be Empty!"
                lbWarning.Show()
                btnEdit.Enabled = False
            ElseIf _
                tbName.Text.Contains("/") Or tbName.Text.Contains("\") Or tbName.Text.Contains(".") Or
                tbName.Text.Contains(":") _
                Or tbName.Text.Contains("?") Or tbName.Text.Contains("*") Or tbName.Text.Contains("''") Or
                tbName.Text.Contains("|") _
                Or tbName.Text.Contains("<") Or tbName.Text.Contains(">") Or tbName.Text.Contains(ControlChars.NewLine) Then
                btnEdit.Enabled = False
                lbWarning.Text = "Name Must Not Contain: / \ . : ? * < >"
                lbWarning.Show()
            ElseIf lv.Items.ContainsKey(tbName.Text) Then
                lbWarning.Text = "This Name is Already Taken!"
                lbWarning.Show()
                btnEdit.Enabled = False
            Else
                lbWarning.Hide()
                btnEdit.Enabled = True
            End If
        End Sub

        Private Sub waveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles waveForm.MouseDown
            If lv.SelectedItems.Count < 1 Then Exit Sub
            'execute at least once
            If _audioFileReader IsNot Nothing Then
                If Not _waveOutDevice.PlaybackState = PlaybackState.Playing Then
                    For Each k As KeyFrame In _keyFrames.Items
                        Dim kRect As Rectangle = keyFrameToRect(k)
                        'check if in rect
                        If e.X < kRect.Right And e.X > kRect.Left And e.Y < kRect.Bottom And e.Y > kRect.Top Then
                            _lineLocation = k.Time
                            _curPlayTime = TimeSpan.FromTicks(CLng(_audioFileReader.TotalTime.Ticks * (k.Time / 100)))
                            waveForm.Refresh()
                            _draggingKeyFrame = True
                            _draggedKeyFrame = k
                            waveForm.Refresh()
                            Exit Sub
                        End If
                    Next
                End If
                dragging = True
                _lineLocation = e.Location.X / waveForm.Width * 100
                Dim lastKf As KeyFrame = _keyFrames.Items(0)
                Dim firstKf As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
                If _lineLocation < firstKf.Time Then _lineLocation = firstKf.Time
                If _lineLocation > lastKf.Time Then _lineLocation = lastKf.Time
                Try
                    _audioFileReader.CurrentTime = TimeSpan.FromTicks(CLng(_audioFileReader.TotalTime.Ticks * (_lineLocation / 100)))
                Catch ex As Exception
                End Try
                Try
                    If _audioFileReader.CurrentTime < _actualZeroTime Then
                        _audioFileReader.CurrentTime = _actualZeroTime
                    End If
                Catch ex As Exception
                End Try
                Try
                    _curPlayTime = _audioFileReader.CurrentTime
                Catch ex As Exception

                End Try
                updateTimeText()
                waveForm.Refresh()
                Dim curTimeText As String = ""
            End If
        End Sub

        Private Sub UpdateTimeText()
            Try
                Dim curTimeText As String = ""
                If _audioFileReader.TotalTime.TotalHours >= 1 Then
                    curTimeText = R2Dgts(CStr(_curPlayTime.Hours)) & ":" & R2Dgts(CStr(_curPlayTime.Minutes)) & ":" &
                                  R2Dgts(CStr(_curPlayTime.Seconds))
                Else
                    curTimeText = R2Dgts(CStr(_curPlayTime.Minutes)) & ":" & R2Dgts(CStr(_curPlayTime.Seconds)) & ":" &
                                  R2Dgts(CorrectMS(CStr(_curPlayTime.Milliseconds)))
                End If
                If curTimeText = "" Then curTimeText = _zeroTimeText
                lbTime.Text = curTimeText & " / " & _totTimeText
            Catch ex As Exception
                Debug.WriteLine(ex.ToString)
            End Try
        End Sub

        Private Sub UpdateKeyFrames()
            Try
                Dim proxStatus As Integer = _keyFrames.GetProximityStatus(CDec(_lineLocation))
                If proxStatus = 1 Then
                    If _keyFrames.Length <= 2 Then
                        btnKeyFrame.Enabled = False
                        btnKeyFrame.Text = "2 Keyframes Minimum"
                    Else
                        btnKeyFrame.Enabled = True
                        btnKeyFrame.Text = "&Remove Volume Keyframe"
                    End If
                ElseIf proxStatus = 0 Then
                    btnKeyFrame.Text = "Keyframe Proximity"
                    btnKeyFrame.Enabled = False
                Else
                    If _keyFrames.Length >= 10 Then
                        btnKeyFrame.Enabled = False
                        btnKeyFrame.Text = "10 Keyframes Maximum"
                    Else
                        btnKeyFrame.Enabled = True
                        btnKeyFrame.Text = "&Add Volume Keyframe"
                        fader.Value = 100
                    End If
                End If
                UpdateStartEnd()
                fader.Value = _keyFrames.CalcVolumeByTime(CDec(_lineLocation))
            Catch ex As Exception
            End Try
        End Sub

        Private Sub waveForm_Paint(sender As Object, e As PaintEventArgs) Handles waveForm.Paint
            If _lineLocation < _keyFrames.Items(_keyFrames.Items.Count - 1).Time Then _lineLocation =
                _keyFrames.Items(_keyFrames.Length - 1).Time
            If _lineLocation >= _keyFrames.Items(0).Time + 0.1 OrElse _audioFileReader.CurrentTime >= _audioFileReader.TotalTime _
                Then
                waveForm.Focus()
                If btnPlay.Text <> "&Play" Then
                    Try
                        fader.Enabled = True
                        lbKF.Text = "Volume Keyframe Editor"
                        btnKeyFrame.Show()
                        fader.Width = btnKeyFrame.Left - fader.Left - 5
                        timerLineMove.Stop()
                        _waveOutDevice.Stop()
                        _lineLocation = _keyFrames.Items(_keyFrames.Length - 1).Time
                        waveForm.Refresh()
                        _curPlayTime = _actualZeroTime
                        _audioFileReader.CurrentTime = _curPlayTime
                        updateTimeText()
                        btnPlay.Text = "&Play"
                    Catch ex As Exception
                    End Try
                End If
                _lineLocation = _keyFrames.Items(_keyFrames.Length - 1).Time
            End If
            Using Pen As New Pen(Color.fromArgb(100, 100, 100), 2)
                Dim actualLineLoc As Integer = CInt(e.ClipRectangle.Width * (_lineLocation / 100))
                e.Graphics.DrawLine(Pen, actualLineLoc, 0, actualLineLoc, e.ClipRectangle.Height)
            End Using
            'If waveOutDevice.PlaybackState = PlaybackState.Playing Then
            updateKeyFrames()
            '        End If
            Dim c As Color = Color.Gainsboro
            Dim tc As Color = Color.FromArgb(90, Color.OrangeRed)
            If _waveOutDevice.PlaybackState = PlaybackState.Playing Then
                c = Color.fromArgb(100, 100, 100)
                tc = Color.FromArgb(200, Color.fromArgb(80, 80, 80))
            End If
            Using sqPen As New Pen(Color.fromArgb(100, 100, 100))
                Using b As New SolidBrush(c)
                    Using bDragging As New SolidBrush(Color.White)
                        Using transBlueBr As New SolidBrush(Color.FromArgb(50, Color.Gainsboro))
                            Using bordPen As New Pen(Color.fromArgb(120, 120, 120))
                                Using transRedBr As New SolidBrush(tc)
                                    Dim lastPt As Point = keyFrameToPoint(_keyFrames.Items(0))
                                    Dim firstPt As Point = keyFrameToPoint(_keyFrames.Items(_keyFrames.Length - 1))
                                    If _waveOutDevice.PlaybackState = PlaybackState.Playing Then
                                        Dim pts As New List(Of PointF)
                                        pts.Add(New PointF(firstPt.X, e.ClipRectangle.Height))
                                        pts.Add(New PointF(lastPt.X, e.ClipRectangle.Height))
                                        For i As Integer = 0 To _keyFrames.Length - 1
                                            pts.Add(keyFrameToPoint(_keyFrames.Items(i)))
                                        Next
                                        e.Graphics.FillPolygon(transBlueBr, pts.ToArray)
                                    End If
                                    e.Graphics.FillRectangle(transRedBr, lastPt.X, 0, e.ClipRectangle.Width - lastPt.X,
                                                             e.ClipRectangle.Height)
                                    e.Graphics.FillRectangle(transRedBr, 0, 0, firstPt.X, e.ClipRectangle.Height)
                                    e.Graphics.DrawLine(bordPen, firstPt.X, 0, firstPt.X, e.ClipRectangle.Height)
                                    e.Graphics.DrawLine(bordPen, lastPt.X, 0, lastPt.X, e.ClipRectangle.Height)
                                    For i As Integer = 0 To _keyFrames.Length - 1
                                        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
                                        Dim k As KeyFrame = _keyFrames.Items(i)
                                        Dim rect As Rectangle = keyFrameToRect(k)
                                        If Not i = _keyFrames.Length - 1 Then
                                            e.Graphics.DrawLine(sqPen, keyFrameToPoint(k),
                                                                keyFrameToPoint(_keyFrames.Items(i + 1)))
                                        End If
                                        e.Graphics.FillRectangle(b, rect)
                                        If _
                                            _draggingKeyFrame And _waveOutDevice.PlaybackState <> PlaybackState.Playing And
                                            _draggedKeyFrame IsNot Nothing Then
                                            If _keyFrames.Items(i).Time = _draggedKeyFrame.Time Then
                                                e.Graphics.FillRectangle(bDragging, rect)
                                            End If
                                        End If
                                        e.Graphics.DrawRectangle(sqPen, rect)
                                    Next
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Dim dragging As Boolean = False

        Private Function keyFrameToRect(ByVal keyFrame As KeyFrame) As Rectangle
            Dim center As New Point(CInt(waveForm.Width * (keyFrame.Time / 100)),
                                    CInt(waveForm.Height * ((100 - keyFrame.Volume) / 100)))
            Return New Rectangle(center.X - 4, center.Y - 4, 8, 8)
        End Function

        Private Function keyFrameToPoint(ByVal keyFrame As KeyFrame) As Point
            Return New Point(CInt(waveForm.Width * (keyFrame.Time / 100)),
                             CInt(waveForm.Height * ((100 - keyFrame.Volume) / 100)))
        End Function

        Private Sub waveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles waveForm.MouseMove
            If dragging Then
                If _audioFileReader IsNot Nothing Then
                    _lineLocation = e.Location.X / waveForm.Width * 100
                    Dim lastKf As KeyFrame = _keyFrames.Items(0)
                    Dim firstKf As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
                    If _lineLocation < firstKf.Time Then _lineLocation = firstKf.Time
                    If _lineLocation > lastKf.Time Then _lineLocation = lastKf.Time
                    _curPlayTime = TimeSpan.FromTicks(CLng(_audioFileReader.TotalTime.Ticks * (_lineLocation / 100)))
                    Try
                        If _curPlayTime < _actualZeroTime Then
                            _curPlayTime = _actualZeroTime
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        _audioFileReader.CurrentTime = _curPlayTime
                    Catch ex As Exception
                    End Try
                    updateTimeText()
                    waveForm.Refresh()
                End If
            End If
            If _draggingKeyFrame Then
                Dim pc As Double = 100 - e.Y / waveForm.Height * 100
                If pc > 100 Then pc = 100
                If pc < 0 Then pc = 0
                fader.Value = pc
                _draggedKeyFrame.Volume = fader.Value
                _draggedKeyFrame.Time = CDec(e.X / waveForm.Width * 100)
                If _draggedKeyFrame.Time > 100 Then _draggedKeyFrame.Time = 100
                If _draggedKeyFrame.Time < 0 Then _draggedKeyFrame.Time = 0
                _lineLocation = _draggedKeyFrame.Time
                _keyFrames.Sort()
                _curPlayTime = TimeSpan.FromTicks(CLng(_audioFileReader.TotalTime.Ticks * (_draggedKeyFrame.Time / 100)))
                If _curPlayTime > _actualEndTime Then
                    _curPlayTime = _actualEndTime
                ElseIf _curPlayTime < _actualZeroTime Then
                    _curPlayTime = _actualZeroTime
                End If
                updateTimeText()
                Try
                    _audioFileReader.CurrentTime = _curPlayTime
                Catch ex As Exception
                End Try
                waveForm.Refresh()
            End If
        End Sub


        Private Sub microChange(ms As Integer)
            Try
                If ms < 0 Then
                    If _audioFileReader.CurrentTime.Add(TimeSpan.FromMilliseconds(ms)) < _actualZeroTime Then
                        _audioFileReader.CurrentTime = _actualZeroTime
                    Else
                        _audioFileReader.CurrentTime = _audioFileReader.CurrentTime.Add(TimeSpan.FromMilliseconds(ms))
                    End If
                Else
                    If _audioFileReader.CurrentTime.Add(TimeSpan.FromMilliseconds(ms)) > _actualEndTime Then
                        _audioFileReader.CurrentTime = _actualEndTime
                    Else
                        _audioFileReader.CurrentTime = _audioFileReader.CurrentTime.Add(TimeSpan.FromMilliseconds(ms))
                    End If
                End If


                _lineLocation = _audioFileReader.CurrentTime.Ticks / _audioFileReader.TotalTime.Ticks * 100
                _curPlayTime = _audioFileReader.CurrentTime
                updateTimeText()
                waveForm.Refresh()

            Catch ex As Exception
            End Try
        End Sub

        Dim _ticks As Integer = 0
        Dim _cancelTicks As Integer = 5

        Private Sub btnEarlier_MDown(sender As Object, e As EventArgs) Handles btnEarlier.MouseDown
            If lv.SelectedItems.Count < 1 Then Exit Sub
            _ticks = -30
            timerMicroMove.Start()
        End Sub

        Private Sub btnLater_MDown(sender As Object, e As EventArgs) Handles btnLater.MouseDown
            If lv.SelectedItems.Count < 1 Then Exit Sub
            _ticks = 30
            timerMicroMove.Start()
        End Sub

        Private Sub btnEarlier_MouseUp(sender As Object, e As MouseEventArgs) Handles btnEarlier.MouseUp, btnLater.MouseUp
            If lv.SelectedItems.Count < 1 Then Exit Sub
            _ticks = 0
            timerMicroMove.Stop()
            _cancelTicks = 5
            waveForm.Focus()
            dragging = False
            _draggingKeyFrame = False
        End Sub

        Private Sub timerMicroMove_Tick(sender As Object, e As EventArgs) Handles timerMicroMove.Tick
            If lv.SelectedItems.Count < 1 Then Exit Sub
            If _cancelTicks = 5 Then
                _cancelTicks -= 1
                microChange(_ticks)
            ElseIf _cancelTicks > 0 Then
                _cancelTicks -= 1
            Else
                microChange(_ticks)
            End If
        End Sub

        Private Sub SaveKeyFrames()
            If _keyFrames.Length > 0 Then
                CurProject.Settings.SetSetting("Audio", lbName.Text, KfListToStr(_keyFrames))
                Dim lastKf As KeyFrame = _keyFrames.Items(0)
                Dim firstKf As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
                _actualZeroTime =
                    TimeSpan.FromTicks(CLng(firstKf.Time / 100 * _audioFileReader.TotalTime.Ticks)).Add(
                        TimeSpan.FromMilliseconds(250))
                _actualEndTime =
                    TimeSpan.FromTicks(CLng(lastKf.Time / 100 * _audioFileReader.TotalTime.Ticks)).Add(
                        TimeSpan.FromMilliseconds(250))
            End If
        End Sub

        Private Sub LoadKeyFrames(ByVal showName As String)
            _keyFrames = StrToKfList(CurProject.Settings.GetSetting("Audio", showName))
        End Sub

        Private Sub btnKeyFrame_Click(sender As Object, e As EventArgs) Handles btnKeyFrame.Click
            If lv.SelectedItems.Count < 1 Then Exit Sub
            If btnKeyFrame.Text = "&Add Volume Keyframe" Then
                _keyFrames.Add(CDec(_lineLocation), fader.Value)
                waveForm.Refresh()
            Else
                btnKeyFrame.Text = "&Add Volume Keyframe"
                _keyFrames.RemoveByTime(CDec(_lineLocation))
                waveForm.Refresh()
            End If
            saveKeyFrames()
            updateKeyFrames()
            Try
                Dim proxStatus As Integer = _keyFrames.GetProximityStatus(CDec(_lineLocation))
                If proxStatus = 1 Then
                    If _lineLocation < _keyFrames.Items(0).Time And _lineLocation > _keyFrames.Items(_keyFrames.Length - 1).Time _
                        Then
                        btnKeyFrame.Enabled = True
                        btnKeyFrame.Text = "&Remove Volume Keyframe"
                    Else
                        btnKeyFrame.Enabled = False
                        btnKeyFrame.Text = "Static Keyframe"
                    End If
                ElseIf proxStatus = 0 Then
                    btnKeyFrame.Text = "Keyframe Proximity"
                    btnKeyFrame.Enabled = False
                Else
                    btnKeyFrame.Enabled = True
                    btnKeyFrame.Text = "&Add Volume Keyframe"
                    fader.Value = 100
                End If
                fader.Value = _keyFrames.CalcVolumeByTime(CDec(_lineLocation))
                _audioFileReader.Volume = CSng(fader.Value)
            Catch ex As Exception
            End Try
        End Sub


        Private Sub fader_ValueChanged(sender As Object, e As PropertyChangedEventArgs) Handles fader.ValueChanged
            If lv.SelectedItems.Count < 1 Then Exit Sub
            If _
                btnKeyFrame.Text = "&Remove Volume Keyframe" Or btnKeyFrame.Text = "2 Keyframes Minimum" Or
                btnKeyFrame.Text = "10 Keyframes Maximum" Then
                _keyFrames.ChangeVolumeByTime(CDec(_lineLocation), fader.Value)
                waveForm.Refresh()
            End If
        End Sub

        Private Sub btnKeyFrame_EnabledChanged(sender As Object, e As EventArgs) Handles btnKeyFrame.EnabledChanged
            If btnKeyFrame.Enabled = False Then
                btnKeyFrame.BackColor = Color.fromArgb(100, 100, 100)
            Else
                btnKeyFrame.BackColor = Color.fromArgb(100, 100, 100)
            End If
        End Sub

        Private Sub anyControl_MouseUp(sender As Object, e As MouseEventArgs) Handles tbName.MouseUp,
                                                                                      sideBar.MouseUp, MyBase.MouseUp,
                                                                                      lv.MouseUp, lbWarning.MouseUp,
                                                                                      lbTime.MouseUp, lbName.MouseUp,
                                                                                      lbKF.MouseUp, editor.MouseUp,
                                                                                      btnStop.MouseUp, btnPlay.MouseUp,
                                                                                      btnKeyFrame.MouseUp, btnEdit.MouseUp,
                                                                                      fader.MouseUp, waveForm.MouseUp
            If _draggingKeyFrame Then
                If _curPlayTime >= _actualEndTime Then
                    _curPlayTime = _actualZeroTime
                ElseIf _curPlayTime < _actualZeroTime Then
                    _curPlayTime = _actualZeroTime
                End If
            End If
            saveKeyFrames()
            updateKeyFrames()
            dragging = False
            _draggingKeyFrame = False
            _draggedKeyFrame = Nothing
            waveForm.Refresh()
        End Sub


        Private Sub tbName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbName.KeyPress
            If btnEdit.Enabled Then
                If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                    btnEdit_MClick(btnEdit, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0))
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub DiagSelectAudio_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub


        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub


        Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
            If IsPresMode Then
                _0App.Frm5ShowUI.PlaySfx(Me.Selected)
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub btn_EnableChanged(sender As Object, e As EventArgs) Handles btnSelect.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(80, 80, 80)
            End If
        End Sub

        Private Sub tb_Leave(sender As Object, e As EventArgs) Handles tbDelay.Leave, tbDur.Leave
            Dim tb As TextBox = DirectCast(sender, TextBox)
            If tb.Text.EndsWith(".") Then tb.Text = tb.Text.Remove(tb.Text.Length - 1)
            Dim fadeTime As Double = CDbl(tb.Text) 'see if converting works
            If fadeTime > 15 Then 'unreasonably long fade time
                tb.Text = "15.0"
                Exit Sub 'set the fadetime back to 15
            End If
            If String.IsNullOrEmpty(tb.Text.Trim) OrElse CDbl(tb.Text.Trim) < 0 Then
                tb.Text = "0.0"
                tb.SelectionLength = 0
                tb.SelectionStart = tb.Text.Length
            End If
        End Sub

        Private Sub tb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDelay.KeyPress, tbDur.KeyPress
            Select Case e.KeyChar
                Case "0"c To "9"c
                    'allow the char
                Case "."c
                    If DirectCast(sender, TextBox).Text.Contains(".") Then e.Handled = True _
                    'suppress the keypress if there is already a decimal point
                Case Convert.ToChar(Keys.Back)
                    'allow
                Case Else
                    e.Handled = True
            End Select
        End Sub

        Private Sub tbDelay_TextChanged(sender As Object, e As EventArgs) Handles tbDelay.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbDelay.Text.Trim) Then
                    tbDelay.Text = tbDelay.Text.Trim
                    Dim fadeTime As Double = CDbl(tbDelay.Text) 'see if converting works
                    If fadeTime >= 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        Me.Delay = CDbl(tbDelay.Text)
                        My.Settings.favDelayTime = Me.Delay
                        My.Settings.Save()
                    End If
                End If
            Catch ex As Exception
                tbDelay.Text = "0.0"
                'if something fails resets text
            End Try
        End Sub

        Private Sub tbDur_TextChanged(sender As Object, e As EventArgs) Handles tbDur.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbDur.Text.Trim) Then
                    tbDur.Text = tbDur.Text.Trim
                    Dim fadeTime As Double = CDbl(tbDur.Text) 'see if converting works
                    If fadeTime >= 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        Me.Duration = CDbl(tbDur.Text)
                        My.Settings.favFadeDur = Me.Duration
                        My.Settings.Save()
                    End If
                End If
            Catch ex As Exception
                tbDur.Text = "0.0"
                'if something fails resets text
            End Try
        End Sub

        Private Sub lv_ItemActivate(sender As Object, e As EventArgs) Handles lv.ItemActivate
            If btnSelect.Enabled Then btnSelect.PerformClick()
        End Sub

        Private Sub DiagSelectAudio_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            If IsPresMode Then
                e.Cancel = True
                Me.Hide()
            Else
                CloseWaveOut()
            End If
        End Sub
    End Class
End Namespace