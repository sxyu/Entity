Imports System.Threading
Imports Entity._4Classes.Types.DmxEngine
Imports Entity._2Namespaces.Light
Imports Entity._3Modules
Imports NAudio.Wave

Namespace _2Namespaces

    Namespace LightChangeSys
        Public Module Methods
            Private _execTmr As Timer
            Private _execList As List(Of LightChange)
            Private _execDur As Double
            Private _execTime As Double = 0
            Private _prevTime As Integer = 0

            Public Function GetLightDifferences(ByVal Cue1 As Submaster, ByVal Cue2 As Submaster, ByVal FadeTime As Double) _
                As List(Of LightChange)
                Dim ret As New List(Of LightChange)
                Dim dict1 As New Dictionary(Of Integer, Integer) 'list of channels in the first cue
                Dim dict2 As New Dictionary(Of Integer, Integer) 'list of channels in the second cue

                For Each l As KeyValuePair(Of Channel, Integer) In Cue1.LightList
                    If Not dict1.ContainsKey(l.Key.Channel) Then
                        If l.Key.Name = "All" Then
                            Dim pLight As Light.Light = GetLightByName(l.Key.ParentLight)
                            If pLight IsNot Nothing Then
                                For Each ic As Channel In pLight.Channels
                                    dict1.Add(ic.BufferInd, l.Value)
                                Next
                            End If
                        Else
                            If l.Key.BufferInd > 0 And l.Key.BufferInd <= 512 And l.Value > 0 Then
                                dict1.Add(l.Key.BufferInd, l.Value)
                            End If
                        End If
                    End If
                Next
                For Each l As KeyValuePair(Of Integer, Integer) In Cue1.ChannelList
                    If Not dict1.ContainsKey(l.Key) Then
                        If l.Key > 0 And l.Key <= 512 And l.Value > 0 Then
                            dict1.Add(l.Key - 1, l.Value)
                        End If
                    End If
                Next

                For Each l As KeyValuePair(Of Channel, Integer) In Cue2.LightList
                        If Not dict2.ContainsKey(l.Key.Channel) Then
                            If l.Key.Name = "All" Then
                            Dim pLight As Light.Light = GetLightByName(l.Key.ParentLight)
                            If pLight IsNot Nothing Then
                                For Each ic As Channel In pLight.Channels
                                    dict2.Add(ic.BufferInd, l.Value)
                                Next
                            End If
                        Else
                            If l.Key.Channel > 0 And l.Key.Channel <= 512 And l.Value > 0 Then
                                dict2.Add(l.Key.BufferInd, l.Value)
                            End If
                            End If
                        End If
                Next
                For Each l As KeyValuePair(Of Integer, Integer) In Cue2.ChannelList
                    If Not dict2.ContainsKey(l.Key) Then
                        If l.Key > 0 And l.Key <= 512 And l.Value > 0 Then
                            dict2.Add(l.Key - 1, l.Value)
                        End If
                    End If
                Next

                For Each l As KeyValuePair(Of Integer, Integer) In dict1
                    If l.Key < 512 And l.Key >= 0 And l.Value <= 255 And l.Value >= 0 Then
                        If dict2.ContainsKey(l.Key) Then
                            Dim newVal As Integer = dict2(l.Key)
                            If newVal <> l.Value AndAlso newVal < 255 Then
                                ret.Add(New LightChange(l.Key, l.Value, newVal))
                            End If
                        Else
                            ret.Add(New LightChange(l.Key, l.Value, 0))
                        End If
                    End If
                Next
                For Each l As KeyValuePair(Of Integer, Integer) In dict2
                    If Not dict1.ContainsKey(l.Key) AndAlso (l.Key < 512 And l.Key >= 0 And l.Value <= 255 And l.Value >= 0) Then
                        ret.Add(New LightChange(l.Key, 0, l.Value))
                    End If
                Next
                CalcLightChanges(ret, FadeTime)
                Return ret
            End Function
            Public Sub CalcLightChanges(ByVal changes As List(Of LightChange), ByVal duration As Double)
                For Each c As LightChange In changes
                    If c.IsChangeRateCalculated = False Then c.CalcChangeRate(duration)
                    c.CurrentLevel = c.ValueBefore
                Next
            End Sub
            Public Sub SetLightsToChange(ByVal changes As List(Of LightChange), ByVal duration As Double)
                _execList = changes
                _execDur = duration
            End Sub
            Public Sub SetTime(ByVal time As Double)
                If time > _execDur Then
                    time = 0
                    For Each c As LightChange In _execList
                        c.CurrentLevel = c.ValueAfter
                        _4Classes.Types.DmxEngine.SetDmxValue(c.Channel, CByte(CInt(c.CurrentLevel)))
                    Next
                Else
                    For Each c As LightChange In _execList
                        c.CurrentLevel += c.ChangeRate * (time - _prevTime) / 50
                        _4Classes.Types.DmxEngine.SetDmxValue(c.Channel, CByte(CInt(c.CurrentLevel)))
                    Next
                    _prevTime = time
                End If
            End Sub
            Public Sub ExecuteLightChanges(ByVal changes As List(Of LightChange), ByVal duration As Double)
                CalcLightChanges(changes, duration)
                _execList = changes
                _execDur = duration
                _execTime = 0
                _execTmr = New Timer(AddressOf ExecTmrTick, Nothing, 0, 50)
            End Sub

            Private Sub ExecTmrTick(state As Object)
                If _execTime > _execDur Then
                    _execTime = 0
                    _execTmr.Dispose()
                Else
                    For Each c As LightChange In _execList
                        c.CurrentLevel += c.ChangeRate
                        If c.CurrentLevel < 0 Then c.CurrentLevel = 0
                        If c.CurrentLevel > 255 Then c.CurrentLevel = 255
                        If c.Channel >= 0 And c.Channel < 512 Then
                            _4Classes.Types.DmxEngine.SetDmxValue(c.Channel, CByte(CInt(c.CurrentLevel)))
                        End If
                    Next
                End If
                _execTime += 100
            End Sub
        End Module

        Public Class LightChange
            Public Property Channel As Integer
            Public Property ValueBefore As Integer
            Public Property ValueAfter As Integer
            Public Property ChangeRate As Double
            Public Property IsChangeRateCalculated As Boolean = False
            Public Property CurrentLevel As Double

            Public Sub CalcChangeRate(ByVal duration As Double)
                Me.ChangeRate = (Me.ValueAfter - Me.ValueBefore) / (duration / 50)
                Me.IsChangeRateCalculated = True
            End Sub

            Public Sub New(ByVal chnl As Integer, ByVal before As Integer, ByVal after As Integer)
                Me.Channel = chnl
                Me.ValueBefore = before
                Me.ValueAfter = after
            End Sub
        End Class
    End Namespace

    Namespace DelaySys
        Public Module DelayBase
            Public Enum ExecType
                Light = 0
                SfxPlay
                SfxStop
                SfxStopAll
                Pjx
            End Enum
        End Module

        Public Class DelayEvent
            Public Enum DelayState
                Delayed = 0
                Active
                Finished
            End Enum
            Public Property State As DelayState = DelayState.Delayed
            Public Property Delay As Double 'delay in seconds
            Public Property Type As ExecType

            'possible arguments
            Public Property StrArgs As String
            Public Property DblArgs As Double
            Public Property ObjArgs As Object

            Public Sub New(ByVal _delay As Double, ByVal _type As ExecType, Optional ByVal _strArgs As String = "",
                           Optional ByVal _dblArgs As Double = 0, Optional ByVal _objArgs As Object = Nothing)
                Me.Delay = _delay
                Me.Type = _type
                Me.StrArgs = _strArgs
                Me.DblArgs = _dblArgs
                Me.ObjArgs = _objArgs
            End Sub
        End Class
    End Namespace

    Namespace SfxSys
        Public Class SoundEffect
            Implements IDisposable

#Region "Events"
            Public Event ProgressChanged(percent As Double)
            Public Event CalcPercentageChanged(percent As Double)
            Public Event SfxPlay(name As String)
            Public Event SfxStop(name As String)
            Public Event SfxPause(name As String)
#End Region

#Region "Public Properties"

            Public Property Name As String
            Public Property FullPath As String
            Public Property KeyFrames As New KeyFrameList
            Public Property Reader As AudioFileReader
            Public Property Player As IWavePlayer
            Public Property Volume As Double = 1
            Public Property LinkedLvI As ListViewItem 'listviewitem to update
            Public Property LinkedListView As ListView 'listview to place lvI
            Public ReadOnly Property CalcProgressPercent As Double
                Get
                    Return _calcProgressPercent
                End Get
            End Property

            Public Property Time As TimeSpan
                Get
                    If Reader Is Nothing Then
                        Return actualZeroTime
                    Else
                        Try
                            Return Reader.CurrentTime - actualZeroTime
                        Catch ex As Exception
                            Return actualEndTime
                        End Try
                    End If
                End Get
                Set(value As TimeSpan)
                    isFading = False
                    Reader.CurrentTime = value + actualZeroTime
                End Set
            End Property

            Public ReadOnly Property TotalTime As TimeSpan
                Get
                    Return Reader.TotalTime - actualZeroTime - (Reader.TotalTime - actualEndTime)
                End Get
            End Property

            Public Property Percent As Double
                Get
                    Dim db As Double = Me.Time.Ticks / Me.TotalTime.Ticks * 100
                    If db > 100 Then
                        db = 100
                        Me.Reset()
                    End If
                    If db < 0 Then db = 0
                    Return db
                End Get
                Set(value As Double)
                    If value >= 0 And value <= 100 Then
                        isFading = False
                        Reader.CurrentTime = TimeSpan.FromTicks(CLng(Me.TotalTime.Ticks * (value / 100))) + actualZeroTime
                    End If
                End Set
            End Property

            Public Property Ratio As Double
                Get
                    Return Me.Time.Ticks / Me.TotalTime.Ticks
                End Get
                Set(value As Double)
                    Reader.CurrentTime = TimeSpan.FromTicks(CLng(Me.TotalTime.Ticks * value)) + actualZeroTime
                End Set
            End Property

#End Region

#Region "Private Variables"

            Private actualZeroTime As TimeSpan
            Private actualEndTime As TimeSpan
            Private checkEndTimer As New Timers.Timer(100)
            Private isFading As Boolean = False
            Private fadeSpeed As Double
            Private properVolume As Double
            Private isPreCalced As Boolean = False
            Private _calcProgressPercent As Double = 0
            Private tempKFList As New KeyFrameList

#End Region

#Region "Common Methods (Inc. Constructor)"

            Public Sub New(ByVal path As String, Optional ByVal isResource As Boolean = True)
                Dim realFileName As String
                If isResource Then
                    realFileName = AudResToPath(path)
                    Me.Name = path.Trim
                Else
                    realFileName = path
                    Me.Name = "_external"
                End If
                FullPath = realFileName

                If CheckExtension(realFileName, AudFormats) Then
                    Reader = New AudioFileReader(realFileName)
                    Player = New WaveOut
                    Player.Init(Reader)
                Else
                    MsgBox("Due to a critical error in the SFX system, the application must restart." _
                           , MsgBoxStyle.MsgBoxSetForeground, "Restart Required")
                    Application.Restart()
                    Exit Sub
                End If
                If isResource Then
                    KeyFrames = StrToKfList(CurProject.Settings.GetSetting("Audio", path))
                Else
                    KeyFrames = StrToKfList("100,100;0,100")
                End If

                If isResource Then
                    LinkedLvI = New ListViewItem(path)
                Else
                    LinkedLvI = New ListViewItem(IO.Path.GetFileNameWithoutExtension(path))
                End If
                LinkedLvI.SubItems.Add("Stopped")
                LinkedLvI.ImageIndex = 0

                UpdateStartEnd()
                AddHandler checkEndTimer.Elapsed, AddressOf TimerTick
            End Sub

            Public Function Clone() As SoundEffect
                If Me.Name = "_external" Then
                    Return New SoundEffect(Me.FullPath, False)
                Else
                    Return New SoundEffect(Me.Name, True)
                End If
            End Function

            Public Sub Dispose() Implements IDisposable.Dispose
                Try
                    checkEndTimer.Stop()
                    checkEndTimer.Dispose()
                    Player.Stop()
                    Reader.Close()
                    Player.Dispose()
                    If LinkedListView.InvokeRequired Then
                        LinkedListView.BeginInvoke(New MethodInvoker(Sub() _
                                                                        If LinkedListView IsNot Nothing Then _
                                                                        LinkedListView.Items.Remove(LinkedLvI)))
                    Else
                        If LinkedListView IsNot Nothing Then LinkedListView.Items.Remove(LinkedLvI)
                    End If
                Catch
                End Try
            End Sub

#End Region

#Region "Public Methods"

            Public Sub Play()
                Try
                    If Player IsNot Nothing Then
                        If Player.PlaybackState = PlaybackState.Paused Or Player.PlaybackState = PlaybackState.Stopped _
                            Then
                            If Reader.CurrentTime < actualZeroTime Then
                                Reader.CurrentTime = actualZeroTime
                            End If
                            Player.Play()
                            checkEndTimer.Start()
                            If LinkedListView.InvokeRequired Then
                                LinkedListView.BeginInvoke(New MethodInvoker(Sub()
                                                                                 If LinkedLvI IsNot Nothing Then LinkedLvI.SubItems(1).Text = "Playing"
                                                                                 LinkedListView.Items.Add(LinkedLvI)
                                                                             End Sub))
                            Else
                                If LinkedLvI IsNot Nothing Then LinkedLvI.SubItems(1).Text = "Playing"
                                LinkedListView.Items.Add(LinkedLvI)
                            End If
                            RaiseEvent SfxPlay(Me.Name)
                        End If
                    End If
                Catch
                End Try
            End Sub

            Public Sub Pause()
                Try
                    Player.Pause()
                    checkEndTimer.Stop()
                    If LinkedListView IsNot Nothing Then
                        If LinkedListView.InvokeRequired Then
                            LinkedListView.BeginInvoke(New MethodInvoker(Sub() _
                                                                            If LinkedLvI IsNot Nothing Then _
                                                                            LinkedLvI.SubItems(1).Text = "Paused"))
                        Else
                            If LinkedLvI IsNot Nothing Then LinkedLvI.SubItems(1).Text = "Paused"
                        End If
                    End If
                    RaiseEvent SfxPause(Me.Name)
                Catch ex As Exception
                End Try
            End Sub

            Public Sub StopPlay()
                isFading = False
                properVolume = 1
                Player.Stop()
                checkEndTimer.Stop()
                If LinkedListView IsNot Nothing Then
                    If LinkedListView.InvokeRequired Then
                        LinkedListView.BeginInvoke(New MethodInvoker(Sub()
                                                                         If LinkedLvI IsNot Nothing Then
                                                                             LinkedLvI.SubItems(1).Text = "Stopped"
                                                                         End If
                                                                         If LinkedListView IsNot Nothing Then
                                                                             LinkedListView.Items.Remove(LinkedLvI)
                                                                         End If
                                                                     End Sub))
                    Else
                        If LinkedLvI IsNot Nothing Then
                            LinkedLvI.SubItems(1).Text = "Stopped"
                        End If
                        If LinkedListView IsNot Nothing Then LinkedListView.Items.Remove(LinkedLvI)
                    End If
                End If
                RaiseEvent SfxStop(Me.Name)
            End Sub

            ''' <summary>
            '''     Fades in the sound effect over a specified time.
            ''' </summary>
            ''' <param name="FadeSeconds">The time period in seconds to fade in the sfx</param>
            ''' <remarks></remarks>
            Public Sub FadeIn(ByVal FadeSeconds As Double)
                If Player IsNot Nothing And Player.PlaybackState <> PlaybackState.Playing _
                    AndAlso FadeSeconds < Me.Reader.TotalTime.Seconds Then
                    If FadeSeconds < 0.1 Then 'too short
                        Me.Reset()
                    Else
                        If isFading Then
                            properVolume = KeyFrames.CalcVolumeByTime(
                                    CDec(New TimeSpan(FadeSeconds).Ticks / Me.Reader.TotalTime.Ticks * 100)) / 100
                            fadeSpeed = CSng(1 / FadeSeconds / 10)
                        Else
                            Reader.Volume = 0
                            Me.Play()
                            Reader.Volume = 0
                            Volume = 0
                            properVolume = KeyFrames.CalcVolumeByTime(
                                    CDec(New TimeSpan(FadeSeconds).Ticks / Me.Reader.TotalTime.Ticks * 100)) / 100
                            fadeSpeed = CSng(1 / FadeSeconds / 10)
                            isFading = True
                            If LinkedListView IsNot Nothing Then
                                If LinkedListView.InvokeRequired Then
                                    LinkedListView.BeginInvoke(New MethodInvoker(Sub() _
                                                                                    If LinkedLvI IsNot Nothing Then _
                                                                                    LinkedLvI.SubItems(1).Text =
                                                                                    "Fading In"))
                                Else
                                    If LinkedLvI IsNot Nothing Then LinkedLvI.SubItems(1).Text = "Fading In"
                                End If
                            End If
                        End If
                    End If
                End If
            End Sub
            ''' <summary>
            '''     Fades out the sound effect over a specified time.
            ''' </summary>
            ''' <param name="FadeSeconds">The time period in seconds to fade out the sfx</param>
            ''' <remarks></remarks>
            Public Sub FadeOut(ByVal FadeSeconds As Double)
                If FadeSeconds < 0.1 Then 'too short
                    Me.Reset()
                Else
                    If isFading Then
                        properVolume = Reader.Volume
                        fadeSpeed = -CSng(Volume / FadeSeconds / 10)
                    Else
                        Reader.Volume =
                            CSng(
                                KeyFrames.CalcVolumeByTime(
                                    CDec(Me.Reader.CurrentTime.Ticks / Me.Reader.TotalTime.Ticks * 100)) / 100)
                        properVolume = Reader.Volume
                        fadeSpeed = -CSng(Volume / FadeSeconds / 10)
                        isFading = True
                        If LinkedListView IsNot Nothing Then
                            If LinkedListView.InvokeRequired Then
                                LinkedListView.BeginInvoke(New MethodInvoker(Sub() _
                                                                                If LinkedLvI IsNot Nothing Then _
                                                                                LinkedLvI.SubItems(1).Text =
                                                                                "Fading Out"))
                            Else
                                If LinkedLvI IsNot Nothing Then LinkedLvI.SubItems(1).Text = "Fading Out"
                            End If
                        End If
                    End If
                End If
            End Sub

            Public Sub Reset()
                Try
                    Player.Stop()
                    checkEndTimer.Stop()
                    Reader.CurrentTime = actualZeroTime
                    isFading = False
                    properVolume = 1
                    Me.Volume = 1
                    Player = New WaveOut
                    Player.Init(Reader)
                    RaiseEvent ProgressChanged(0)
                    If LinkedListView.InvokeRequired Then
                        LinkedListView.BeginInvoke(New MethodInvoker(Sub()
                                                                         If LinkedLvI IsNot Nothing Then
                                                                             LinkedLvI.SubItems(1).Text = "Stopped"
                                                                         End If
                                                                         If LinkedListView IsNot Nothing Then LinkedListView.Items.Remove(LinkedLvI)
                                                                     End Sub))

                    Else
                        If LinkedLvI IsNot Nothing Then
                            LinkedLvI.SubItems(1).Text = "Stopped"
                        End If
                        If LinkedListView IsNot Nothing Then LinkedListView.Items.Remove(LinkedLvI)
                    End If
                Catch
                End Try
            End Sub

            Public Sub UpdateKeyFrames()
                If Me.Name = "_external" Then
                    KeyFrames = StrToKfList("100,100;0,100")
                Else
                    KeyFrames = StrToKfList(CurProject.Settings.GetSetting("Audio", Me.Name))
                End If
                UpdateStartEnd()
            End Sub

            Public Sub PreCalculateFades()
                _calcProgressPercent = 0
                RaiseEvent CalcPercentageChanged(0)
                If Me.Name = "_external" Then
                    KeyFrames = StrToKfList("100,100;0,100")
                    UpdateStartEnd()
                    _calcProgressPercent = 100
                    RaiseEvent CalcPercentageChanged(100)
                Else
                    Dim th As New Thread(AddressOf CalcThread)
                    th.Start()
                End If
            End Sub

            Public Sub UnsetPreCalculatedFades()
                isPreCalced = False
                UpdateKeyFrames()
            End Sub

#End Region

#Region "Private Methods"

            Private Sub UpdateStartEnd()
                Dim lastKf As KeyFrame = KeyFrames.Items(0)
                Dim firstKf As KeyFrame = KeyFrames.Items(KeyFrames.Length - 1)
                actualZeroTime = TimeSpan.FromTicks(CLng(firstKf.Time / 100 * Reader.TotalTime.Ticks))
                actualEndTime = TimeSpan.FromTicks(CLng(lastKf.Time / 100 * Reader.TotalTime.Ticks))
                Reader.Volume = CSng(firstKf.Volume / 100)
            End Sub

            Private Sub TimerTick(sender As Object, e As EventArgs)
                If Me.Time >= (actualEndTime - actualZeroTime) Then Me.Reset() : Exit Sub 'sound effect ended, reset
                If Volume < 0 Then
                    Me.Reset()
                End If
                If isFading Then 'fading
                    Volume += fadeSpeed
                    If Volume < 0 Then
                        Me.Reset()
                    ElseIf Volume > 1 Then
                        Volume = 1
                        properVolume = 1
                        isFading = False
                    Else
                        Reader.Volume = CSng(properVolume * Volume)
                    End If
                Else
                    If isPreCalced Then
                        Dim vol As Single = CSng(KeyFrames.GetClosestKF(
                            CDec(Me.Reader.CurrentTime.Ticks / Me.Reader.TotalTime.Ticks * 100)).Volume / 100) * Me.Volume
                        If vol > 1 Then vol = 1
                        If vol >= 0 Then
                            If Reader.Volume <> vol Then Reader.Volume = vol
                        End If
                    Else
                        Dim vol As Single = CSng(KeyFrames.CalcVolumeByTime(
                            CDec(Me.Reader.CurrentTime.Ticks / Me.Reader.TotalTime.Ticks * 100)) / 100) * Me.Volume
                        If vol < 0 Then vol = 0
                        If vol > 100 Then vol = 100
                        If Reader.Volume <> vol Then Reader.Volume = vol
                    End If
                End If
                RaiseEvent ProgressChanged(Me.Percent)
            End Sub

            Private Sub CalcThread()
                Dim prevCalc As Double
                For Time As Decimal = CDec(actualZeroTime.Ticks / Reader.TotalTime.Ticks) * 100 To _
                    CDec(actualEndTime.Ticks / Reader.TotalTime.Ticks) * 100 _
                    Step CDec(0.1)
                    Dim calc As Double = KeyFrames.CalcVolumeByTime(Time)
                    If prevCalc <> calc Then
                        prevCalc = calc
                        tempKFList.Add(Time, calc)
                        _calcProgressPercent = Time /
                                           ((actualEndTime.Ticks - actualZeroTime.Ticks) / Reader.TotalTime.Ticks * 100)
                    End If
                    RaiseEvent CalcPercentageChanged(Time)
                Next
                KeyFrames.Clear()
                KeyFrames.AddRange(tempKFList.Items.ToArray)
                UpdateStartEnd()
                _calcProgressPercent = 100
                Me.isPreCalced = True
                RaiseEvent CalcPercentageChanged(100)
            End Sub

#End Region
        End Class
    End Namespace

End Namespace
