Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.IO
Imports Entity._1Dialogs.General.Add
Imports Microsoft.VisualBasic.FileIO
Imports NAudio.Wave
Imports Entity._1Dialogs.Loading
Imports Entity._2Namespaces
Imports Entity._3Modules

Namespace _0App.Views

    Public Class Vw2Audio
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

        Private Sub CloseWaveOut()
            If _waveOutDevice IsNot Nothing Then
                _waveOutDevice.[Stop]()
            End If
            If _audioFileReader IsNot Nothing Then
                Try
                    _audioFileReader.Dispose()
                Catch ex As Exception
                End Try
            End If
            If _waveOutDevice IsNot Nothing Then
                _waveOutDevice.Dispose()
                _waveOutDevice = Nothing
            End If
        End Sub

        Private Sub audio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'docks in viewer
            Me.Dock = DockStyle.Fill
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            If imgLst.Images.Count < 1 Then
                imgLst.Images.Add(My.Resources.Headphones)
            End If
            If Not FileSystem.DirectoryExists(CurWorkDir.Path) Then
                FileSystem.CreateDirectory(CurWorkDir.Path)
            End If
            CreateProjFolders(CurProject.Path)
            loadLv()
        End Sub

        Private Sub mouseUpX() Handles fader.MouseUpX
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

        Sub loadLv()
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
            If lv.Items.Count > 0 Then lv.Items(0).Selected = True
        End Sub


        Private Sub lv_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp, lv.KeyUp
            If lv.Focused = True Then
                If e.KeyCode = Keys.Delete Then
                    btnDel.PerformClick()
                ElseIf e.KeyCode = Keys.F2 Then
                    btnEdit_MClick(btnEdit, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0))
                ElseIf e.KeyCode = Keys.F5 Then
                    loadLv()
                End If
            End If
            If e.Control Then
                If e.KeyCode = Keys.D Then
                    btnAdd.PerformClick()
                ElseIf e.KeyCode = Keys.A Then
                    For Each i As ListViewItem In lv.Items
                        i.Selected = True
                    Next
                End If
            End If
        End Sub


        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            Dim selct As Integer = lv.SelectedItems.Count
            saveKeyFrames()
            If selct <> 1 Then
                lbName.Show()
                tbName.Hide()
                btnEdit.BackColor = Color.fromArgb(120, 120, 120)
                Frm3Viewer.AcceptButton = Nothing
                If selct < 1 Then
                    btnDel.Enabled = False
                Else
                    btnDel.Enabled = True
                End If
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
            Else
                Dim fileName As String = lv.SelectedItems(0).Tag.ToString
                If FileSystem.FileExists(fileName) Then
                    timerLineMove.Stop()
                    btnDel.Enabled = True
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
                    btnPlay.Text = "&Play"
                    'load the waveform image
                    Dim temp As Bitmap = WFormCache.GetImageByName(Path.GetFileName(fileName))
                    waveForm.BackgroundImage = New Bitmap(temp)
                    _waveOutDevice.Stop()
                    _waveOutDevice = New WaveOut
                    Try
                        _audioFileReader = New AudioFileReader(lv.SelectedItems(0).Tag.ToString)
                    Catch ex As Exception
                        Try
                            FileSystem.DeleteFile(lv.SelectedItems(0).Tag.ToString)
                        Catch
                        End Try
                        lv.SelectedItems(0).Selected = False
                        Exit Sub
                    End Try

                    _keyFrames.Clear()
                    loadKeyFrames(lv.SelectedItems(0).Text)
                    If (_keyFrames.Items.Count > 0) Then

                    End If

                    _curPlayTime = _actualZeroTime
                    '
                    Try
                        _waveOutDevice.Init(_audioFileReader)
                    Catch ex As Exception
                    End Try
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
                    loadLv()
                End If
            End If
            updateTimeText()
        End Sub

        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function

        Private Sub updateStartEnd()
            Dim lastKF As KeyFrame = _keyFrames.Items(0)
            Dim firstKF As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
            If _audioFileReader IsNot Nothing Then
                _actualZeroTime = TimeSpan.FromTicks(CLng(firstKF.Time / 100 * _audioFileReader.TotalTime.Ticks))
                _actualEndTime = TimeSpan.FromTicks(CLng(lastKF.Time / 100 * _audioFileReader.TotalTime.Ticks))
                _audioFileReader.Volume = CSng(firstKF.Volume / 100)

                If _audioFileReader.TotalTime.TotalHours >= 1 Then
                    _zeroTimeText = R2Dgts(CStr(_actualZeroTime.Hours)) & ":" & R2Dgts(CStr(_actualZeroTime.Minutes)) & ":" &
                                    R2Dgts(CStr(_actualZeroTime.Seconds))
                Else
                    _zeroTimeText = R2Dgts(CStr(_actualZeroTime.Minutes)) & ":" & R2Dgts(CStr(_actualZeroTime.Seconds)) & ":" &
                                    R2Dgts(CorrectMS(CStr(_actualZeroTime.Milliseconds)))
                End If
            End If
        End Sub

        Private Sub playStopped(sender As Object, e As StoppedEventArgs)
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

        Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
            Dim s As String = "s "
            If lv.SelectedItems.Count = 1 Then s = " "
            Dim resNames As String = ""
            For i As Integer = 0 To lv.SelectedItems.Count - 1
                If i < lv.SelectedItems.Count - 1 Then
                    resNames &= lv.SelectedItems(i).Text & ", "
                Else
                    resNames &= lv.SelectedItems(i).Text
                End If
            Next
            If MsgBox("Delete the audio resource" & s & resNames & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation _
                                                                        Or MsgBoxStyle.MsgBoxSetForeground,
                      "Delete Resource" & s) = MsgBoxResult.Yes Then
                CloseWaveOut()
                _curPlayTime = TimeSpan.Zero
                btnPlay.Text = "Play"
                Dim toRem As New List(Of ListViewItem)
                Dim toRemNames As New List(Of String)
                For Each i As ListViewItem In lv.SelectedItems
                    If _audioFileReader IsNot Nothing Then
                        _audioFileReader = Nothing
                    End If
                    WFormCache.RemoveByName(i.Text)
                    If FileSystem.FileExists(CurProject.ResCachePath & "\wgraph\" & i.Text) Then
                        FileSystem.DeleteFile(CurProject.ResCachePath & "\wgraph\" & i.Text)
                    End If
                    If FileSystem.FileExists(i.Tag.ToString) Then
                        FileSystem.DeleteFile(i.Tag.ToString)
                    End If
                    CurProject.Settings.DeleteSetting("Audio", i.Text)
                    If ImageCache.Images.ContainsKey(i.Tag.ToString) Then
                        ImageCache.Images.RemoveByKey(i.Tag.ToString)
                    End If
                    toRem.Add(i)
                    toRemNames.Add(i.Text)
                Next
                For Each i As ListViewItem In toRem
                    lv.Items.Remove(i)
                Next
                Dim sToRem As New List(Of Sound.SfxEvent)
                For Each c As Sound.SfxCue In SfxCues
                    For Each ev As Sound.SfxEvent In c.PlayEvents
                        If toRemNames.Contains(ev.NameOfRes) Then
                            sToRem.Add(ev)
                        End If
                    Next
                    For Each v As Sound.SfxEvent In sToRem
                        c.PlayEvents.Remove(v)
                    Next
                    sToRem.Clear()
                    For Each ev As Sound.SfxEvent In c.StopEvents
                        If toRemNames.Contains(ev.NameOfRes) Then
                            sToRem.Add(ev)
                        End If
                    Next
                    For Each v As Sound.SfxEvent In sToRem
                        c.StopEvents.Remove(v)
                    Next
                    sToRem.Clear()
                Next
                SaveSfxCues()
            End If
        End Sub

        'add audio button
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Try
                If _waveOutDevice IsNot Nothing Then
                    _waveOutDevice.Stop()
                End If
                If _audioFileReader IsNot Nothing Then
                    _audioFileReader.Dispose()
                End If
            Catch ex As Exception
            End Try
            For Each i As ListViewItem In lv.Items
                i.Selected = False
            Next
            Using frm As New DiagAddResAud
                With frm
                    .Text = "Add Audio"
                    If .ShowDialog = DialogResult.OK Then
                        If FileSystem.FileExists(.Result) Then
                            'get extension of file
                            Dim ext As String = Path.GetExtension(.Result).ToLower
                            'create variable for modified file extension
                            FileSystem.CopyFile(.Result, CurProject.ResPath & "\" & .Resname & ext, True)
                            Using previewImg As New Bitmap(GenerateWaveForm(CurProject.ResPath & "\" & .Resname & ext))
                                WFormCache.Add(.Resname & ext, New Bitmap(previewImg))
                                SavePng(CurProject.ResCachePath & "\wgraph\" & .Resname, previewImg)
                            End Using
                            CurProject.Settings.SetSetting("Audio", .Resname, "100,100;0,100")
                            lv.BeginUpdate()
                            Dim it As New ListViewItem(.Resname)
                            it.ImageIndex = 0
                            it.Tag = CurProject.ResPath & "\" & .Resname & ext
                            lv.Items.Add(it)
                            lv.Sort()
                            lv.EndUpdate()
                            it.Selected = True
                            lv.Refresh()
                            If .RealPathHidden Then
                                Try
                                    If Not .Result.Contains(GlobalPath) Then
                                        FileSystem.DeleteFile(.Result)
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                            FrmProcessing.audio = False
                            FrmProcessing.fc = True
                            FrmProcessing.Close()
                        End If
                    End If
                End With
            End Using
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
                Dim firstKF As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
                _audioFileReader.Volume = CSng(firstKF.Volume / 100)
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

                        For Each c As Sound.SfxCue In SfxCues
                            For Each ev As Sound.SfxEvent In c.PlayEvents
                                If ev.NameOfRes = lv.SelectedItems(0).Text Then
                                    ev.NameOfRes = tbName.Text
                                End If
                            Next
                            For Each ev As Sound.SfxEvent In c.StopEvents
                                If ev.NameOfRes = lv.SelectedItems(0).Text Then
                                    ev.NameOfRes = tbName.Text
                                End If
                            Next
                        Next
                        SaveSfxCues()

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
                Frm3Viewer.AcceptButton = Nothing
            End If
        End Sub

        Private Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
            If String.IsNullOrEmpty(tbName.Text.Trim) Then
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
                Dim lastKF As KeyFrame = _keyFrames.Items(0)
                Dim firstKF As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
                If _lineLocation < firstKF.Time Then _lineLocation = firstKF.Time
                If _lineLocation > lastKF.Time Then _lineLocation = lastKF.Time
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

        Private Sub updateTimeText()
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

        Private Sub updateKeyFrames()
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
                updateStartEnd()
                fader.Value = _keyFrames.CalcVolumeByTime(CDec(_lineLocation))
            Catch ex As Exception
            End Try
        End Sub

        Private Sub waveForm_Paint(sender As Object, e As PaintEventArgs) Handles waveForm.Paint
            If _keyFrames.Length > 0 Then
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
                Using Pen As New Pen(Color.FromArgb(100, 100, 100), 2)
                    Dim actualLineLoc As Integer = CInt(e.ClipRectangle.Width * (_lineLocation / 100))
                    e.Graphics.DrawLine(Pen, actualLineLoc, 0, actualLineLoc, e.ClipRectangle.Height)
                End Using
                'If waveOutDevice.PlaybackState = PlaybackState.Playing Then
                updateKeyFrames()
                '        End If
                Dim c As Color = Color.Gainsboro
                Dim tc As Color = Color.FromArgb(90, Color.OrangeRed)
                If _waveOutDevice.PlaybackState = PlaybackState.Playing Then
                    c = Color.FromArgb(100, 100, 100)
                    tc = Color.FromArgb(200, Color.FromArgb(80, 80, 80))
                End If
                Using sqPen As New Pen(Color.FromArgb(100, 100, 100))
                    Using b As New SolidBrush(c)
                        Using bDragging As New SolidBrush(Color.White)
                            Using transBlueBr As New SolidBrush(Color.FromArgb(50, Color.Gainsboro))
                                Using bordPen As New Pen(Color.FromArgb(120, 120, 120))
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
            End If
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
                    Dim lastKF As KeyFrame = _keyFrames.Items(0)
                    Dim firstKF As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
                    If _lineLocation < firstKF.Time Then _lineLocation = firstKF.Time
                    If _lineLocation > lastKF.Time Then _lineLocation = lastKF.Time
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
                _draggedKeyFrame.Volume = pc
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

        Dim ticks As Integer = 0
        Dim cancelTicks As Integer = 5

        Public Sub btnEarlier_MDown(sender As Object, e As EventArgs) Handles btnEarlier.MouseDown
            If lv.SelectedItems.Count < 1 Then Exit Sub
            ticks = -30
            timerMicroMove.Start()
        End Sub

        Public Sub btnLater_MDown(sender As Object, e As EventArgs) Handles btnLater.MouseDown
            If lv.SelectedItems.Count < 1 Then Exit Sub
            ticks = 30
            timerMicroMove.Start()
        End Sub

        Public Sub btnEarlier_MouseUp(sender As Object, e As MouseEventArgs) Handles btnEarlier.MouseUp, btnLater.MouseUp
            If lv.SelectedItems.Count < 1 Then Exit Sub
            ticks = 0
            timerMicroMove.Stop()
            cancelTicks = 5
            waveForm.Focus()
            dragging = False
            _draggingKeyFrame = False
        End Sub

        Private Sub timerMicroMove_Tick(sender As Object, e As EventArgs) Handles timerMicroMove.Tick
            If lv.SelectedItems.Count < 1 Then Exit Sub
            If cancelTicks = 5 Then
                cancelTicks -= 1
                microChange(ticks)
            ElseIf cancelTicks > 0 Then
                cancelTicks -= 1
            Else
                microChange(ticks)
            End If
        End Sub

        Private Sub saveKeyFrames()
            If _keyFrames.Length > 0 Then
                CurProject.Settings.SetSetting("Audio", lbName.Text, KfListToStr(_keyFrames))
                Dim lastKF As KeyFrame = _keyFrames.Items(0)
                Dim firstKF As KeyFrame = _keyFrames.Items(_keyFrames.Length - 1)
                Try
                    If _audioFileReader IsNot Nothing Then
                        _actualZeroTime =
                            TimeSpan.FromTicks(CLng(firstKF.Time / 100 * _audioFileReader.TotalTime.Ticks)).Add(
                                TimeSpan.FromMilliseconds(250))
                        _actualEndTime =
                            TimeSpan.FromTicks(CLng(lastKF.Time / 100 * _audioFileReader.TotalTime.Ticks)).Add(
                                TimeSpan.FromMilliseconds(250))
                    End If
                Catch
                End Try
            End If
        End Sub

        Private Sub loadKeyFrames(ByVal showName As String)
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
                                                                                      btnDel.MouseUp, btnAdd.MouseUp,
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
    End Class
End Namespace