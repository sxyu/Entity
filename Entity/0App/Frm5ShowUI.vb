Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports Entity._2Namespaces.DelaySys
Imports Entity._2Namespaces.Light
Imports Microsoft.VisualBasic.FileIO
Imports NAudio.Wave
Imports Entity._0App.Views
Imports Entity._2Namespaces.Sound
Imports Entity._2Namespaces.Projection
Imports Entity._2Namespaces.SfxSys
Imports Entity._2Namespaces.LightChangeSys
Imports Entity._3Modules
Imports Entity._1Dialogs.Popups
Imports Entity._1Dialogs.Loading
Imports Entity._1Dialogs.General.Selectors
Imports Entity._4Classes.Types
Imports Entity._6Misc
Imports Cue = Entity._2Namespaces.CueSys.Cue

Namespace _0App

    Public Class Frm5ShowUi
        Public ForceClose As Boolean = False

        'Private Delegate Sub playDEvSafe(ByVal v As DelayEvent)
        Private _cueViewer As DiagViewCue

        Private _audioResources As New Dictionary(Of String, SoundEffect)

        Private _blackOut As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
        Public BlackOutSm As Bitmap 'public so selector can access this
        Private _blackOutSub As New Submaster("blackout")

        Private _nCue As Cue
        Private _nLfxSub As Submaster
        Private _nSfxCue As SfxCue
        Private _nPjxCue As PjxCue
        Private _curLfxSub As Submaster
        Private _cueNum As Integer = 0

        Private _isPjxEditing As Boolean = False
        Private _isSfxEditing As Boolean = False
        Private _isLfxEditing As Boolean = False

        Private _isCuePlaying As Boolean = False


#Region "DelayExec"

        Private delayTmr As New Timer
        Private _curTime As Double = 0
        Private _delayEvs As List(Of DelayEvent)

        Private Sub ExecuteDelayEvs(ByVal evs As List(Of DelayEvent))
            If _delayEvs IsNot Nothing Then _delayEvs.Clear()
            _delayEvs = evs
            _isCuePlaying = True
            _curTime = 0
            delayTmr.Start()
        End Sub

        Private Sub PlaySingleDelayEv(ByVal v As DelayEvent, ByVal time As Integer)
            If v.State = DelayEvent.DelayState.Delayed Then
                Select Case v.Type
                    Case ExecType.SfxPlay
                        _audioResources(v.StrArgs).Play()
                        v.State = DelayEvent.DelayState.Finished
                    Case ExecType.SfxStop
                        _audioResources(v.StrArgs).FadeOut(v.DblArgs)
                        v.State = DelayEvent.DelayState.Finished
                    Case ExecType.SfxStopAll
                        For Each sfx As SoundEffect In _audioResources.Values
                            If sfx.Player.PlaybackState = PlaybackState.Playing Then
                                sfx.FadeOut(v.DblArgs)
                            End If
                        Next
                        v.State = DelayEvent.DelayState.Finished
                End Select
            ElseIf v.State = DelayEvent.DelayState.Active Then
                Select Case v.Type
                    Case ExecType.Light
                        Dim sm As Submaster = DirectCast(v.ObjArgs, Submaster)
                        SetTime(time)
                        If (time / 1000) > sm.Duration Then v.State = DelayEvent.DelayState.Finished
                    Case ExecType.Pjx
                        Dim pCue As PjxCue = DirectCast(v.ObjArgs, PjxCue)
                        If HasSecondMonitor Then
                            pCue.StepAnimate(time)
                        End If
                        If (time / 1000) > pCue.Duration Then v.State = DelayEvent.DelayState.Finished
                End Select
            End If
        End Sub

        Private Sub DelayElapse(sender As Object, e As EventArgs)
            _curTime += 0.05
            Dim activeCt As Integer = 0
            For i As Integer = 0 To _delayEvs.Count - 1
                Dim v As DelayEvent = _delayEvs(i)
                If _curTime >= v.Delay Then
                    PlaySingleDelayEv(v, (_curTime - v.Delay) * 1000)
                    If v.State = DelayEvent.DelayState.Delayed Then
                        v.State = DelayEvent.DelayState.Active
                    End If
                End If
                If v.State <> DelayEvent.DelayState.Finished Then activeCt += 1
            Next
            If activeCt <= 0 Then
                _isCuePlaying = False
                delayTmr.Stop() 'stop when all events are done
                prepNextCue()
            End If
        End Sub
        Private Sub prepNextCue()
            If _cueNum < Cues.Count Then 'if this is not the last cue
                _nCue = Cues(_cueNum)
            End If
            If _nCue.IsLfxOn Then
                _nLfxSub = _nCue.GetAssociatedSubmaster
                SetLightsToChange(GetLightDifferences(_curLfxSub, _nLfxSub, _nLfxSub.Duration), _nLfxSub.Duration)
            End If
            If _nCue.IsSfxOn Then
                _nSfxCue = _nCue.GetAssociatedSfxCue
            End If
            If _nCue.IsPjxOn Then
                If HasSecondMonitor Then
                    If SecondMonitor.pb.Image Is Nothing Then
                        invokeCtrl(SecondMonitor.pb, Sub() SecondMonitor.pb.Image = _
                                                         New Bitmap(My.Settings.secondaryScrRez.Width, _
                                                            My.Settings.secondaryScrRez.Height))
                    Else
                        SecondMonitor.pb.BackgroundImage = New Bitmap(SecondMonitor.pb.Image)
                        SecondMonitor.pb.Image.Dispose()
                    End If
                    _nPjxCue = _nCue.GetAssociatedPjxCue
                    _nPjxCue.InitStepAnimator()
                End If
            End If
        End Sub
        Private Sub showNextCue()
            If _nCue.IsLfxOn Then
                _curLfxSub = _nLfxSub
                'set next cue variables and update display
                For Each r As RectangleX In LightRects
                    r.IsActive = False
                Next
                For Each l As Channel In _nLfxSub.LightList.Keys
                    Dim level As Double = _nLfxSub.LightList(l)
                    For Each r As RectangleX In LightRects
                        If r.Tag.ToString = l.ParentLight Then
                            If level > 0 Then
                                r.IsActive = True
                                r.ActivePercent = CDec(level / 2.55)
                                If r.ActivePercent > 100 Then r.ActivePercent = 100
                                If r.ActivePercent < 0 Then r.ActivePercent = 0
                            Else
                                r.IsActive = False
                            End If
                        End If
                    Next
                Next
            End If
            If _nCue.IsPjxOn Then
                If HasSecondMonitor Then
                    If _nPjxCue.NameOfRes = "_blackout" Then
                        invokeCtrl(pbPj, Sub()
                                             pbPj.Image = BlackOutSm
                                         End Sub)
                    Else
                        invokeCtrl(pbPj, Sub()
                                             pbPj.Image = GetThumbnail(ImgResToPath(_nPjxCue.NameOfRes), _
                                                                       pbPj.Width, pbPj.Height, pbPj.BackColor)
                                         End Sub)
                    End If
                End If
            End If
        End Sub
#End Region

        Public Sub PlaySfx(sfxname As String)
            _audioResources(sfxname).Play()
        End Sub

        Private Sub NextCue()
            _cueNum += 1

            DiagCOM.Show()
            DiagCOM.Hide()

            'if end of presentation
            If _cueNum > Cues.Count Then
                'fade out
                FadeOut()
                EndShow()
                Exit Sub
            End If

            'if there are more cues

            'create delay events
            Dim dEvs As New List(Of DelayEvent)
            If _nCue.IsLfxOn Then
                dEvs.Add(New DelayEvent(_nLfxSub.Delay, ExecType.Light, , _nLfxSub.Duration, _nLfxSub))
                _nLfxSub = _nCue.GetAssociatedSubmaster
            End If
            If _nCue.IsSfxOn Then
                If _nSfxCue.StopAll Then
                    dEvs.Add(New DelayEvent(_nSfxCue.StopAllDelay, ExecType.SfxStopAll))
                End If
                For Each p As SfxEvent In _nSfxCue.PlayEvents
                    dEvs.Add(New DelayEvent(p.Delay, ExecType.SfxPlay, p.NameOfRes))
                Next
                For Each s As SfxEvent In _nSfxCue.StopEvents
                    dEvs.Add(New DelayEvent(s.Delay, ExecType.SfxStop, s.NameOfRes, s.FadeDuration))
                Next
            End If
            If _nCue.IsPjxOn Then
                If HasSecondMonitor Then
                    dEvs.Add(New DelayEvent(_nPjxCue.Delay, ExecType.Pjx, , , _nPjxCue))
                End If
            End If
            showNextCue()

            'execute changes
            ExecuteDelayEvs(dEvs)

            pbLts.Invalidate()
            pnlCue.Invalidate()
        End Sub

        Private Sub FadeOut()
            If HasSecondMonitor Then
                'Dim SlideEn As New SlideEngine(blackOut, SecondMonitor.pb, "Image", 100)
                'SlideEn.ColorTrans = Color.Transparent
                'SlideEn.EffectName = PjxEngine.Effect.Fade_In
                'AddHandler SlideEn.EffectEnded, AddressOf slideEnd
                'SlideEn.Start()
                'If SecondMonitor.pb.Image IsNot Nothing Then SecondMonitor.pb.Image.Dispose()
                If SecondMonitor.pb.BackgroundImage IsNot Nothing Then
                    SecondMonitor.pb.BackgroundImage.Dispose()
                    SecondMonitor.pb.BackgroundImage = Nothing
                End If

                pbPj.SizeMode = PictureBoxSizeMode.Zoom
                Using g As Graphics = Graphics.FromImage(pbPj.Image)
                    g.DrawImage(GetThumbnail(BlackOutSm, pbPj.Width, pbPj.Height, pbPj.BackColor), New Point(0, 0))
                End Using
            End If

            For Each sfx As SoundEffect In _audioResources.Values
                sfx.Dispose()
            Next
            _audioResources.Clear()

            ExecuteLightChanges(GetLightDifferences(_curLfxSub, _blackOutSub, 1000), 1000)
        End Sub

        Public Sub EndShow()
            FrmPrepShow.Title = "Returning to the Editor..."
            FrmPrepShow.Description = "Please Wait..."
            FrmPrepShow.Show()
            FrmPrepShow.Refresh()
            Frm3Viewer.Show()
            If SEngine IsNot Nothing Then SEngine.Dispose()

            Dim prevView As EntityView = CurView
            CurView = EntityView.Null
            InitViews()
            ChangeView(prevView)
            Frm3Viewer.viewer.Refresh()

            IsPresMode = False 'turn off pres mode flag

            FrmPrepShow.Close()
            Me.ForceClose = True
            Me.Close()
        End Sub

        Private Sub Frm5ShowUI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                Me.TopBar1.btnCOM.PerformClick()
                e.Handled = True
            End If
        End Sub

        Private Sub frm5ShowUI_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
            If e.Control And e.Shift And e.KeyCode = Keys.Delete Then
                Me.TopBar1.btnClose.PerformClick()
            End If
        End Sub

        Private Sub frm5ShowUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.ForceClose = False
            FrmPrepShow.Show()
            FrmPrepShow.Title = "Entering Presentation Mode..."
            FrmPrepShow.Description = "The Show Will Begin Shortly"
            FrmPrepShow.Refresh()
            SecondMonitor.pb.Image = Nothing
            Me.Icon = My.Resources.en 'set icon
            'put controls in place

            pnlPj.Size = DEFAULT_SIZE
            pbLts.Size = DEFAULT_SIZE
            pnlSf.Size = DEFAULT_SIZE
            pnlCue.Size = DEFAULT_SIZE

            pnlPj.Left = CInt(viewer.Width / 2 - (pnlPj.Width + pbLts.Width) / 2 - 2.5)
            pnlPj.Top = CInt(viewer.Height / 2 - (pnlPj.Height + pnlSf.Height) / 2 - 2.5)
            pnlPj.Height = pbLts.Height
            pbLts.Left = pnlPj.Right + 5
            pbLts.Top = pnlPj.Top
            pnlSf.Left = pnlPj.Left
            pnlSf.Top = pnlPj.Bottom + 5
            pnlCue.Top = pnlSf.Top
            pnlCue.Left = pnlSf.Right + 5

            lvSf.Columns(0).Width = CInt(lvSf.Width * 0.618033989)
            lvSf.Columns(1).Width = CInt(lvSf.Width * 0.381966011) - 1

            Dim projstr As String = CurProject.Name.Replace("&", "&&").Trim
            If projstr.Length > 35 Then
                projstr = projstr.Remove(35)
                projstr &= "..."
            End If
            lbShow.Text = String.Format("{0} - Presenting", projstr)
            If Not FileSystem.DirectoryExists(CurWorkDir.Path) Then
                FileSystem.CreateDirectory(CurWorkDir.Path)
            End If

            'update lights
            UpdateVisual()

            delayTmr.Interval = 50
            AddHandler delayTmr.Tick, AddressOf DelayElapse

            'init values of cue variables
            _cueNum = 0
            _curLfxSub = _blackOutSub

            'unset lights
            For i As Integer = 0 To 511
                DmxEngine.SetDmxValue(i, 0)
            Next

            For Each rect As RectangleX In LightRects
                rect.IsActive = False
            Next
            pbLts.Invalidate()
            'init audio resources
            Dim dir As List(Of String) = CurProject.Settings.GetSettingsInSection("Audio")
            For Each res As String In dir
                If ResWithExtExists(res, AudFormats) Then
                    Dim sfx As New SoundEffect(res)
                    sfx.LinkedListView = Me.lvSf
                    _audioResources.Add(res, sfx)
                End If
            Next
            'init blackout image
            Using g As Graphics = Graphics.FromImage(_blackOut)
                g.Clear(Color.Black)
            End Using
            BlackOutSm = GetThumbnail(_blackOut, pbPj.Width, pbPj.Height, pbPj.BackColor)
            'fade screen to black if has secondary screen
            CheckSecondaryScreen()
            If HasSecondMonitor Then
                If SecondMonitor.pb.Image Is Nothing Then
                    SecondMonitor.pb.Image = New Bitmap(_blackOut)
                Else
                    Dim SlideEn As New PjxEngine(_blackOut, SecondMonitor.pb, "Image", 500)
                    SlideEn.ColorTrans = Color.Transparent
                    SlideEn.EffectName = PjxEngine.Effect.Fade_In
                    AddHandler SlideEn.EffectEnded, AddressOf SlideEnd
                    'SlideEn.Start()
                End If

                pbPj.SizeMode = PictureBoxSizeMode.Zoom
                pbPj.Image = New Bitmap(pbPj.Width, pbPj.Height)
                Using g As Graphics = Graphics.FromImage(pbPj.Image)
                    g.DrawImageUnscaled(BlackOutSm, New Point(0, 0))
                End Using
                tt.SetToolTip(pbPj,
                              "The image currently displayed on your projector." & vbCrLf &
                              "Right click to show/hide options.")
            Else
                tt.SetToolTip(pbPj,
                              "You don't have any projectors connected!" & vbCrLf & "Connect to one to project images.")
            End If
            IsPresMode = True 'turn on pres mode flag

            'prepare the first cue
            prepNextCue()

            'pre-cache popups
            DiagVolume.Show()
            DiagVolume.Hide()
            DiagSelectImage.Show()
            FrmPrepShow.BringToFront()
            DiagSelectImage.Hide()
            DiagSelectAudio.Show()
            FrmPrepShow.BringToFront()
            DiagSelectAudio.Hide()
            _cueViewer = New DiagViewCue(_nCue.Name, _nCue.Name)
            _cueViewer.TopMost = False
            _cueViewer.Show()
            FrmPrepShow.BringToFront()
            _cueViewer.Hide()
            _cueViewer.TopMost = True
            'minimize com dialog
            DiagCOM.btnExpand.Text = "+"
            DiagCOM.MinUI()
            'close loading screen
            FrmPrepShow.Fade(True)
        End Sub

        Private Sub SlideEnd(sender As Object, e As EventArgs)
            If pbPj.BackgroundImage IsNot Nothing Then pbPj.BackgroundImage.Dispose()
            DirectCast(sender, PjxEngine).Dispose()
        End Sub

        Private Sub frm5ShowUI_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
            If Me.WindowState = FormWindowState.Normal Then
                Me.WindowState = FormWindowState.Maximized
            End If
        End Sub

        Private Sub btnMin_Click(sender As Object, e As EventArgs)
            Me.WindowState = FormWindowState.Minimized
        End Sub


        Private Sub topBar_Paint(sender As Object, e As PaintEventArgs)
            'paint logo
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(129, 137, 153)), 10, 9, 32, 32)
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias
            e.Graphics.DrawString("En", New Font("Segoe UI SemiLight", 15), Brushes.White, 12, 11)
        End Sub

        Private Sub frm5ShowUI_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            If ForceClose Then
                If SEngine IsNot Nothing Then SEngine.Dispose()
                For Each sfx As SoundEffect In _audioResources.Values
                    sfx.Dispose()
                Next
                For Each r As RectangleX In LightRects
                    r.IsActive = False
                Next
                For i As Integer = 0 To 511
                    DmxEngine.SetDmxValue(i, 0)
                Next
                delayTmr.Dispose()
                _audioResources.Clear()
                FrmProcessing.fc = True
                FrmProcessing.Close()
                SecondMonitor.CheckExit()
                DiagCOM.Close()
                If OpenFormsCount <= 1 Then
                    DmxEngine.abortThread()
                End If
                IsPresMode = False
                DiagVolume.Close()
                DiagSelectAudio.Close()
                DiagSelectImage.Close()
                _cueViewer.Close()
            Else
                e.Cancel = True
            End If
        End Sub

        Private Sub tabSubs_Enter(sender As Object, e As EventArgs)
            viewer.Focus()
        End Sub

        Private Sub btn_EnableChanged(sender As Object, e As EventArgs) _
            Handles btnSStop.EnabledChanged, btnSStopAll.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(100, 100, 100)
            End If
        End Sub

        Private Sub lvSf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvSf.SelectedIndexChanged
            If lvSf.SelectedItems.Count > 0 Then
                btnSStop.Enabled = True
            Else
                btnSStop.Enabled = False
            End If
        End Sub

        Private Sub Frm3Viewer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            Dim prevFlag As Boolean = HasSecondMonitor
            CheckSecondaryScreen()
            If prevFlag <> HasSecondMonitor Then
                If ViewCache IsNot Nothing AndAlso ViewCache(3) IsNot Nothing Then
                    DirectCast(ViewCache(3), Vw3Images).UpdateControls()
                End If
                For Each frm As Form In My.Application.OpenForms
                    If frm.Tag IsNot Nothing Then
                        If CStr(frm.Tag) = "imgsel" Then
                            DirectCast(frm, DiagSelectImage).UpdateControls()
                        End If
                    End If
                Next

                If HasSecondMonitor Then
                    _blackOut.Dispose()
                    _blackOut = New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                    Using g As Graphics = Graphics.FromImage(_blackOut)
                        g.Clear(Color.Black)
                    End Using
                    BlackOutSm = GetThumbnail(_blackOut, pbPj.Width, pbPj.Height, pbPj.BackColor)

                    If _cueNum <= 0 Then
                        If pbPj.Image Is Nothing Then
                            pbPj.Image = New Bitmap(pbPj.Width, pbPj.Height)
                        End If
                        Using g As Graphics = Graphics.FromImage(pbPj.Image)
                            g.DrawImageUnscaled(BlackOutSm, New Point(0, 0))
                        End Using
                    Else
                        PjxCues(_cueNum - 1).ExecuteCue(pbPj)
                    End If
                    tt.SetToolTip(pbPj,
                                  "Shows the image currently displayed on your projector." & vbCrLf &
                                  "Right click to show/hide options.")
                Else
                    tt.SetToolTip(pbPj,
                                  "You don't have any projectors connected!" & vbCrLf & "Connect to one to project images.")
                End If
            End If
        End Sub

        Private Sub viewer_Paint(sender As Object, e As PaintEventArgs) Handles viewer.Paint
            Dim left As Integer = CInt(viewer.Width / 2 - (pbLts.Width + pbPj.Width) / 2 - 10)
            Dim top As Integer = CInt(viewer.Height / 2 - (pbLts.Height + pnlCue.Height) / 2 - 10)
            Dim width As Integer = pbLts.Width + pbPj.Width + 20
            Dim height As Integer = pbLts.Height + pnlCue.Height + 20
            Using br As New SolidBrush(Color.FromArgb(100, 100, 100))
                e.Graphics.FillRectangle(br, left, top, width, height)
            End Using
        End Sub


        Private Sub pnlCue_Paint(sender As Object, e As PaintEventArgs) Handles pnlCue.Paint
            Dim cueInt As String = CStr(_cueNum + 1) 'index of the next cue

            Dim cueName As String 'name of the next cue
            If _nCue Is Nothing Then
                cueName = "_blackout"
            Else
                cueName = _nCue.Name
            End If
            Using g As Graphics = e.Graphics
                g.SmoothingMode = SmoothingMode.HighQuality
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                Using sUIL As New Font("Segoe UI SemiLight", 16)
                    Using br As New SolidBrush(Color.WhiteSmoke)
                        Dim bordRect As New Rectangle(28, 28, e.ClipRectangle.Width - 31, e.ClipRectangle.Height - 70)
                        If _cueNum >= Cues.Count Then
                            g.DrawString("Next Cue: " & vbCrLf &
                                         "End Of Show", sUIL, br, bordRect)
                        Else
                            g.DrawString("Next Cue: " & vbCrLf &
                                         "Cue #" & cueInt & " - " & cueName, sUIL, br, bordRect)
                        End If
                    End Using
                End Using
            End Using
        End Sub

        Private Sub btnViewEdit_Click(sender As Object, e As EventArgs) Handles btnViewEdit.Click
            Me.TopBar1.Panel1.Focus()
            _cueViewer.StartingCue = _nCue.Name
            _cueViewer.SelectCue = _nCue.Name
            _cueViewer.Show()
            _cueViewer.BringToFront()
        End Sub


        'light visual display
        Private Sub paintLight(ByVal g As Graphics, ByVal clipRec As Rectangle, ByVal cRec As RectangleX,
                               ByVal name As String)
            Using blackPen As New Pen(Color.FromArgb(100, 100, 100))
                Using blackBr As New SolidBrush(Color.FromArgb(100, 100, 100))
                    Using lightBr As New SolidBrush(Color.FromArgb(70, Color.GhostWhite))
                        Using segoeUi As New Font("Segoe UI SemiLight", 10)
                            g.SmoothingMode = SmoothingMode.HighQuality
                            g.CompositingQuality = CompositingQuality.HighQuality
                            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                            g.DrawEllipse(blackPen, cRec.ToRectangle)
                            g.FillEllipse(lightBr, cRec.ToRectangle)

                            Dim sz As SizeF = g.MeasureString(name, segoeUi)
                            g.DrawString(name, segoeUi, blackBr, CInt(cRec.Left + cRec.Width / 2 - sz.Width / 2),
                                         CInt(cRec.Top + cRec.Height / 2 - sz.Height / 2))
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Private Sub paintSelectedLight(ByVal g As Graphics, ByVal clipRec As Rectangle, ByVal cRec As RectangleX,
                                       ByVal name As String, Optional ByVal opacity As Double = 100)
            If opacity > 100 Then opacity = 100
            If opacity < 0 Then opacity = 0
            If cRec IsNot Nothing Then
                Using whitePen As New Pen(Color.White, 2)
                    Using blackPen As New Pen(Color.FromArgb(80, 80, 80))
                        '248, 248, 255 Ghost White
                        '255, 191, 0   Amber
                        Using lightBr As New SolidBrush(Color.FromArgb(CInt(70 + 30 * (opacity / 100)),
                                                                       Color.FromArgb(CInt(248 + 6 * (opacity / 100)),
                                                                                      CInt(248 - 57 * (opacity / 100)),
                                                                                      CInt(255 - 255 * (opacity / 100))))) _
'calculate color
                            Using veryTransBr As New SolidBrush(Color.FromArgb(50, Color.AliceBlue))
                                g.SmoothingMode = SmoothingMode.HighQuality
                                g.CompositingQuality = CompositingQuality.HighQuality
                                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                                g.DrawEllipse(blackPen, cRec.ToRectangle)
                                g.FillEllipse(lightBr, cRec.ToRectangle)
                                Using blackBr As New SolidBrush(Color.FromArgb(80, 80, 80))
                                    Using segoeUI As New Font("Segoe UI SemiLight", 10)
                                        Dim sz As SizeF = g.MeasureString(name, segoeUI)
                                        g.DrawString(name, segoeUI, blackBr, CInt(cRec.Left + cRec.Width / 2 - sz.Width / 2),
                                                     CInt(cRec.Top + cRec.Height / 2 - sz.Height / 2))
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End If
        End Sub

        Private Sub pbLts_Paint(sender As Object, e As PaintEventArgs) Handles pbLts.Paint
            If _isLfxEditing Then
                e.Graphics.Clear(Color.FromArgb(157, 169, 191))
            Else
                e.Graphics.Clear(Color.FromArgb(120, 120, 120))
            End If
            Using bgBr As New SolidBrush(Color.FromArgb(100, Color.Black))
                Using br As New SolidBrush(Color.White)
                    Using segoeUI As New Font("Segoe UI SemiLight", 8)
                        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                        Dim sz As SizeF = e.Graphics.MeasureString("Audience (Click To Flip)", segoeUI)
                        If My.Settings.lightVisualReverse Then
                            e.Graphics.FillRectangle(bgBr, 0, pbLts.Height - CInt(pbLts.Height / 10), pbLts.Width,
                                                     CInt(pbLts.Height / 10))
                            e.Graphics.DrawString("Audience (Click To Flip)", segoeUI, br, CInt(pbLts.Width / 2 - sz.Width / 2),
                                                  CInt(pbLts.Height / 20 * 19 - sz.Height / 2))
                        Else
                            e.Graphics.FillRectangle(bgBr, 0, 0, pbLts.Width, CInt(pbLts.Height / 10))
                            e.Graphics.DrawString("Audience (Click To Flip)", segoeUI, br, CInt(pbLts.Width / 2 - sz.Width / 2),
                                                  CInt(pbLts.Height / 20 - sz.Height / 2))
                        End If
                    End Using
                End Using
            End Using
            Dim selRect As New List(Of RectangleX)

            For i As Integer = LightRects.Count - 1 To 0 Step -1
                Dim r As RectangleX = LightRects(i)
                If My.Settings.lightVisualReverse Then
                    Dim inverseR As New RectangleX(r.Left, pbLts.Height - r.Bottom, r.Width, r.Height)
                    inverseR.Tag = r.Tag
                    If r.IsActive Then
                        selRect.Add(inverseR)
                    Else
                        paintLight(e.Graphics, e.ClipRectangle, inverseR, r.Tag.ToString)
                    End If
                Else
                    If r.IsActive Then
                        selRect.Add(r)
                    Else
                        paintLight(e.Graphics, e.ClipRectangle, r, r.Tag.ToString)
                    End If
                End If
            Next
            If selRect.Count > 0 Then
                For i As Integer = 0 To selRect.Count - 1
                    Dim r As RectangleX = selRect(i)
                    paintSelectedLight(e.Graphics, e.ClipRectangle, r, r.Tag.ToString, r.ActivePercent)
                Next
            End If
        End Sub

        Private Sub pbLts_MouseDown(sender As Object, e As MouseEventArgs) Handles pbLts.MouseDown
            If e.Button = MouseButtons.Left Then
                Dim cRec As RectangleX
                For Each r As RectangleX In LightRects
                    If r.IsActive Then
                        If My.Settings.lightVisualReverse Then
                            cRec = New RectangleX(r.Left, pbLts.Height - r.Bottom, r.Width, r.Height)
                        Else
                            cRec = r
                        End If
                        Exit For
                    End If
                Next
                Dim foundNewRect As Boolean = False
                If _isLfxEditing Then
                    Dim mousePos As Point = e.Location
                    If My.Settings.lightVisualReverse Then
                        mousePos = New Point(mousePos.X, pbLts.Height - mousePos.Y)
                    End If

                    For Each r As RectangleX In LightRects
                        If IsInEllipse(mousePos, r.ToRectangle) Then
                            foundNewRect = True
                            If r.IsActive Then
                                r.IsActive = False
                                Dim sm As Submaster = _curLfxSub.Clone
                                For Each k As Channel In sm.LightList.Keys
                                    If k.Name = r.Tag.ToString Then
                                        sm.LightList.Remove(k)
                                        Exit For
                                    End If
                                Next
                                ExecuteLightChanges(GetLightDifferences(_curLfxSub, sm, 1000), 1000)
                            Else
                                r.IsActive = True
                                r.ActivePercent = 100
                                Dim curChnlName As String
                                Dim curChnlID As Integer
                                Dim sm As Submaster = New Submaster(_curLfxSub.ToString())
                                For Each l As Light In Lights
                                    If l.Name = r.Tag.ToString Then
                                        Dim curChnl As Channel = l.GetMainChannel
                                        curChnlName = curChnl.Name
                                        curChnlID = curChnl.Channel
                                        Exit For
                                    End If
                                Next
                                sm.LightList.Add(New Channel(curChnlName, curChnlID, CStr(r.Tag)), 255)
                                ExecuteLightChanges(GetLightDifferences(_curLfxSub, sm, 1000), 1000)
                            End If
                            Exit For
                        End If
                    Next
                Else
                    foundNewRect = False
                End If
                If Not foundNewRect Then
                    If My.Settings.lightVisualReverse Then
                        If e.Y > pbLts.Height / 10 * 9 Then
                            My.Settings.lightVisualReverse = False
                        End If
                    Else
                        If e.Y < pbLts.Height / 10 Then
                            My.Settings.lightVisualReverse = True
                        End If
                    End If
                End If
                My.Settings.Save()
                pbLts.Refresh()
            End If
        End Sub

        Private Sub pbPj_Paint(sender As Object, e As PaintEventArgs) Handles pbPj.Paint
            If Not HasSecondMonitor Then
                Dim g As Graphics = e.Graphics
                g.Clear(Color.FromArgb(120, 120, 120))
                Using br As New SolidBrush(Color.Gainsboro)
                    g.FillRectangle(br, CInt(pbPj.Width / 2 - 100), CInt(pbPj.Height / 2 - 25), 200, 50)
                End Using
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                Using br As New SolidBrush(Color.FromArgb(80, 80, 80))
                    Using f As New Font("Segoe UI SemiLight", 16)
                        Using sf As New StringFormat
                            sf.Alignment = StringAlignment.Center
                            sf.LineAlignment = StringAlignment.Center
                            g.DrawString("Not Connected", f, br, e.ClipRectangle, sf)
                        End Using
                    End Using
                End Using
            End If
        End Sub

        Private Sub CueSlider_Activate() Handles CueSlider.Activate
            NextCue()
        End Sub

        Private Sub pbPj_MouseUp(sender As Object, e As MouseEventArgs) Handles pbPj.MouseUp, btnPCh.MouseUp, btnPBO.MouseUp
            If e.Button = MouseButtons.Right Then
                If HasSecondMonitor Then
                    Me._isPjxEditing = Not Me._isPjxEditing
                    If Me._isPjxEditing Then
                        btnPBO.Show()
                        btnPCh.Show()
                    Else
                        btnPBO.Hide()
                        btnPCh.Hide()
                        pbPj.Invalidate()
                    End If
                End If
            End If
        End Sub

        Private Sub lvSf_MouseUp(sender As Object, e As MouseEventArgs) _
            Handles pnlSOpts.MouseUp, pnlSf.MouseUp, lvSf.MouseUp,
                    btnSPlay.MouseUp, btnSStop.MouseUp, btnSStopAll.MouseUp
            If e.Button = MouseButtons.Right Then
                Me._isSfxEditing = Not Me._isSfxEditing
                If Me._isSfxEditing Then
                    pnlSOpts.Show()
                Else
                    pnlSOpts.Hide()
                End If
            End If
        End Sub

        Private Sub pbLts_MouseUp(sender As Object, e As MouseEventArgs) Handles pbLts.MouseUp
            If e.Button = MouseButtons.Right Then
                Me._isLfxEditing = Not Me._isLfxEditing
                If _isLfxEditing Then
                    tt.SetToolTip(pbLts,
                                  "A visualisation of your lights." & vbCrLf & vbCrLf &
                                  "You are currently in editing (blue) mode." & vbCrLf _
                                  & "Click a light to turn it on or off." & vbCrLf &
                                  "Right click to return to viewing (grey) mode.")
                Else
                    tt.SetToolTip(pbLts,
                                  "A visualisation of your lights." & vbCrLf & vbCrLf &
                                  "You are currently in viewing (grey) mode." &
                                  vbCrLf & "Right click to enter editing (blue) mode." & vbCrLf _
                                  & "(You can only turn lights on or off in editing mode." & vbCrLf &
                                  "this is to prevent misclicks.)")
                End If
                pbLts.Invalidate()
            End If
        End Sub


        Private Sub btnPBO_Click(sender As Object, e As EventArgs) Handles btnPBO.Click
            Me.TopBar1.Panel1.Focus()
            Dim pCue As New PjxCue("e_blackout", "_blackout", PjxEngine.Effect.Fade_In, 1, 0)
            pCue.ExecuteCue()
            pbPj.Image = BlackOutSm
        End Sub

        Private Sub btnSStopAll_Click(sender As Object, e As EventArgs) Handles btnSStopAll.Click
            Me.TopBar1.Panel1.Focus()
            If lvSf.Items.Count > 0 Then
                For Each sfx As SoundEffect In _audioResources.Values
                    If sfx.Player.PlaybackState = PlaybackState.Playing Then
                        sfx.FadeOut(0.5)
                    End If
                Next
            End If
        End Sub

        Private Sub btnSStop_Click(sender As Object, e As EventArgs) Handles btnSStop.Click
            Me.TopBar1.Panel1.Focus()
            For Each i As ListViewItem In lvSf.SelectedItems
                _audioResources(i.Text).FadeOut(0.5)
            Next
        End Sub

        Private Sub btnPCh_Click(sender As Object, e As EventArgs) Handles btnPCh.Click
            Me.TopBar1.Panel1.Focus()
            DiagSelectImage.Show()
            DiagSelectImage.TopMost = True
        End Sub

        Private Sub btnSPlay_Click(sender As Object, e As EventArgs) Handles btnSPlay.Click
            Me.TopBar1.Panel1.Focus()
            DiagSelectAudio.Show()
            DiagSelectAudio.TopMost = True
        End Sub
    End Class
End Namespace