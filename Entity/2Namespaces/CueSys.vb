Imports Entity._2Namespaces.Light
Imports Microsoft.VisualBasic.FileIO
Imports Entity._2Namespaces.Sound
Imports Entity._2Namespaces.Projection
Imports Entity._3Modules
Imports Entity._4Classes.Types
Imports Entity._2Namespaces.CueSys

Namespace _2Namespaces
    Namespace CueSys
        Public Class Cue
            Public Property Name As String
            Public Property IsLfxOn As Boolean
            Public Property IsSfxOn As Boolean
            Public Property IsPjxOn As Boolean

            Public Sub New(ByVal cueName As String, ByVal lightOn As Boolean, ByVal soundOn As Boolean,
                           ByVal pjOn As Boolean)
                Me.Name = cueName
                Me.IsLfxOn = lightOn
                Me.IsSfxOn = soundOn
                Me.IsPjxOn = pjOn
            End Sub

            Public Sub New(ByVal cueName As String, ByVal fromString As String)
                Me.Name = cueName
                If Len(fromString) = 3 Then
                    Me.IsLfxOn = CBool(fromString.Chars(0).ToString)
                    Me.IsSfxOn = CBool(fromString.Chars(1).ToString)
                    Me.IsPjxOn = CBool(fromString.Chars(2).ToString)
                Else
                    MsgBox("Cue Error 1: Cue storage file is corrupted. App will relaunch after deleting all cues.",
                           MsgBoxStyle.Critical, "Error")
                    FileSystem.WriteAllText("Cues", "[Cues]" & vbCrLf, False)
                    Application.Restart()
                End If
            End Sub

            Public Function Clone(ByVal newName As String) As Cue
                Try
                    Return New Cue(newName, Me.IsLfxOn, Me.IsSfxOn, Me.IsPjxOn)
                Catch
                    MsgBox("Cue Error 2: Failed to clone cue. App will relaunch immediately.", MsgBoxStyle.Critical, "Error")
                    FileSystem.WriteAllText("Cues", "[Cues]" & vbCrLf, False)
                    Application.Restart()
                End Try
            End Function

            Public Function GetAssociatedSubmaster() As Submaster
                Return GetSubmasterByName(Me.Name)
            End Function

            Public Function GetAssociatedSfxCue() As SfxCue
                Return GetSfxCueByName(Me.Name)
            End Function

            Public Function GetAssociatedPjxCue() As PjxCue
                Return GetPjxCueByName(Me.Name)
            End Function

            Public Function GetCueBefore() As Cue
                Dim cues As List(Of String) = CurProject.Settings.GetSettingsInSection("Cues")
                Dim ret As String = ""
                Dim found As Boolean = False
                For Each c As String In cues
                    If c = Me.Name Then
                        found = True
                        Exit For
                    Else
                        ret = c
                    End If
                Next
                If found Then
                    If String.IsNullOrEmpty(ret.Trim) Then
                        Return Nothing 'if this cue is the first cue returns nothing
                    Else
                        Return GetCueByName(ret)
                    End If
                Else
                    Return Nothing 'if the current cue is invalid returns a null object
                End If
            End Function

            Public Function GetCueAfter() As Cue
                Dim cues As List(Of String) = CurProject.Settings.GetSettingsInSection("Cues")
                Dim ret As String = ""
                Dim found As Boolean = False
                For Each c As String In cues
                    If found Then
                        ret = c
                        Exit For
                    End If
                    If c = Me.Name Then found = True
                Next
                If found Then
                    If String.IsNullOrEmpty(ret.Trim) Then
                        Return Nothing 'if this cue is the first cue returns nothing
                    Else
                        Return GetCueByName(ret)
                    End If
                Else
                    Return Nothing 'if the current cue is invalid returns a null object
                End If
            End Function

            Public Shadows Function ToString() As String
                Return CStr(CInt(Me.IsLfxOn) & CInt(Me.IsSfxOn) & CInt(Me.IsPjxOn)).Replace("-", "").Trim
            End Function
        End Class
    End Namespace

    Namespace Light
        Public Class Channel
            Public Property Name As String
            Public Property ParentLight As String

            'NOTE: this channel number is actually 1 more than the array index of this channel in the buffer
            'use BufferInd to get the actual index in the buffer
            Public Property Channel As Integer

            Public ReadOnly Property BufferInd As Integer
                Get
                    Return Me.Channel - 1
                End Get
            End Property

            Public Overrides Function ToString() As String
                Return Me.Name & ":" & Me.Channel.ToString & ":" & Me.ParentLight
            End Function

            Public Sub SetDmx(ByVal value As Integer)
                If value < 0 Then value = 0
                If value > 255 Then value = 255
                DmxEngine.SetDmxValue(Me.BufferInd, CByte(value))
            End Sub

            Public Sub SetDmxOff()
                Me.SetDmx(0)
            End Sub

            Public Sub SetDmxOn()
                Me.SetDmx(255)
            End Sub

            Public Sub New(ByVal fromString As String)
                If fromString.Contains(":") Then
                    Dim parts() As String = fromString.Split(":"c)
                    If parts.Length = 3 Then
                        Me.Name = parts(0)
                        Me.Channel = CInt(parts(1))
                        Me.ParentLight = parts(2)
                    Else
                        MsgBox(
                            "Cue Subsystem > Lighting Module > Error 2: Lighting data is corrupted. If this persists, please contact the Entity Team.",
                            MsgBoxStyle.Critical, "Error")
                        FileSystem.WriteAllText("Submasters", "[Submasters]" & vbCrLf, False)
                        Application.Restart()
                    End If
                End If
            End Sub

            Public Sub New(ByVal nm As String, ByVal chnl As Integer, Optional parent As String = "")
                If chnl > 0 And chnl <= 512 Then
                    Me.Name = nm
                    Me.Channel = chnl
                    Me.ParentLight = parent
                Else
                    Throw New Exception("Cue Subsystem > Lighting Module > Error 1: Dmx Channel number between 1 and 512 expected. Got channel: " & chnl)
                End If
            End Sub
        End Class

        Public Class Light
            Public Property Name As String
            Public Property Channels As List(Of Channel)

            Public Function GetMainChannel() As Channel
                If Channels.Count < 1 Then Return Nothing
                For Each ch As Channel In Channels
                    If ch.Name = "Main" Then
                        Return ch
                        Exit For
                    End If
                Next
                Return Channels(0)
            End Function

            Public Sub New(ByVal nm As String)
                Me.Channels = New List(Of Channel)
                Me.Name = nm
            End Sub
        End Class

        Public Class Submaster
            Public Property Name As String 'name of submaster
            Public Property ChannelList As Dictionary(Of Integer, Integer)
            Public Property LightList As Dictionary(Of Channel, Integer)
            Public Property Duration As Double
            Public Property Delay As Double

            Public Function Clone(Optional ByVal newName As String = "") As Submaster
                If newName = "" Then newName = Me.Name
                Return New Submaster(newName, Me.ToString)
            End Function

            Public Overrides Function ToString() As String
                Dim ret As String = ""
                Dim ct As Integer = 0
                For Each c As KeyValuePair(Of Integer, Integer) In Me.ChannelList
                    ret &= c.Key
                    ret &= "@" & c.Value
                    ct += 1
                    If ct < Me.ChannelList.Count Then ret &= ","
                Next
                ct = 0
                ret &= ";"
                For Each l As KeyValuePair(Of Channel, Integer) In Me.LightList
                    ret &= l.Key.ToString
                    ret &= "@" & l.Value
                    ct += 1
                    If ct < Me.LightList.Count Then ret &= ","
                Next
                ct = 0
                ret &= ";" & Duration.ToString & ";" & Delay.ToString
                Return ret
            End Function

            Public Sub New(ByVal nm As String, Optional ByVal str As String = "")
                Try
                    If str <> "" And str.Contains(";") Then
                        Me.ChannelList = New Dictionary(Of Integer, Integer)
                        Me.LightList = New Dictionary(Of Channel, Integer)
                        Me.Name = nm
                        Dim sects() As String = str.Split(";"c)
                        If sects.Length = 4 Then
                            Dim chnlSplit() As String = sects(0).Split(","c)
                            For Each s As String In chnlSplit
                                Try
                                    If s = "" Then Continue For
                                    Dim chnlSects() As String = s.Split("@"c)
                                    If chnlSects.Length = 2 Then
                                        Dim ch As Integer = CInt(chnlSects(0))
                                        Dim val As Integer = CInt(chnlSects(1))
                                        Me.ChannelList.Add(ch, val)
                                    End If
                                Catch ex As Exception
                                    Continue For
                                End Try
                            Next
                            Dim lightSplit() As String = sects(1).Split(","c)
                            For Each s As String In lightSplit
                                Try
                                    Dim lSects() As String = s.Split("@"c)
                                    If lSects.Length = 2 Then
                                        Me.LightList.Add(New Channel(lSects(0)), CInt(lSects(1)))
                                    End If
                                Catch ex As Exception
                                    Continue For
                                End Try
                            Next
                            Me.Duration = CDbl(sects(2))
                            Me.Delay = CDbl(sects(3))
                        Else
                            Throw New Exception("Invalid String")
                        End If
                    Else
                        Me.Name = nm
                        Me.ChannelList = New Dictionary(Of Integer, Integer)
                        Me.LightList = New Dictionary(Of Channel, Integer)
                    End If
                Catch
                    MsgBox(
                        "Light Sub Error 2: Data file is corrupted. If this persists, please contact the Entity Team.",
                        MsgBoxStyle.Critical, "Error")
                    FileSystem.WriteAllText("Submasters", "[Submasters]" & vbCrLf, False)
                    Application.Restart()
                End Try
            End Sub

            Public Sub New(ByVal nm As String, Optional ByVal channels As Dictionary(Of Integer, Integer) = Nothing,
                           Optional ByVal lights As Dictionary(Of Channel, Integer) = Nothing,
                           Optional ByVal subs As List(Of Submaster) = Nothing,
                           Optional ByVal fadeDur As Double = 1, Optional ByVal fadeDelay As Double = 0)
                Me.Name = nm
                Me.ChannelList = New Dictionary(Of Integer, Integer)
                Me.LightList = New Dictionary(Of Channel, Integer)
                If channels IsNot Nothing Then
                    For Each c As KeyValuePair(Of Integer, Integer) In channels
                        Me.ChannelList.Add(c.Key, c.Value)
                    Next
                End If
                If lights IsNot Nothing Then
                    For Each c As KeyValuePair(Of Channel, Integer) In lights
                        Me.LightList.Add(c.Key, c.Value)
                    Next
                End If
                Me.Duration = fadeDur
                Me.Delay = fadeDelay
            End Sub

            Public Sub New(ByVal nm As String) 'set all to defaults
                Me.Name = nm
                Me.ChannelList = New Dictionary(Of Integer, Integer)
                Me.LightList = New Dictionary(Of Channel, Integer)
                Me.Duration = 1
                Me.Delay = 0
            End Sub
        End Class
    End Namespace

    Namespace Sound
        Public Class SfxCue 'collection of SfxEvent
            Public Property CueName As String
            Public Property PlayEvents As New List(Of SfxEvent)
            Public Property StopEvents As New List(Of SfxEvent)
            Public Property StopAll As Boolean = False
            Public Property StopAllDuration As Double
            Public Property StopAllDelay As Double

            Public Shadows Function ToString() As String
                Try
                    Dim ret As String = ""
                    For Each ev As SfxEvent In Me.PlayEvents
                        ret &= ev.ToString & ";"
                    Next
                    ret &= "|"
                    For Each ev As SfxEvent In Me.StopEvents
                        ret &= ev.ToString & ";"
                    Next
                    ret &= "|" & Convert.ToInt32(Me.StopAll) & ";" & StopAllDelay & ";" & StopAllDuration
                    Return ret
                Catch
                    MsgBox(
                        "SFX Error 5A: Failed to convert a SFX cue to string. If this persists, please contact the Entity Team.",
                        MsgBoxStyle.Critical, "Error")
                    Return ""
                End Try
            End Function

            Public Function GetPlayEventByResName(ByVal name As String) As SfxEvent
                For Each ev As SfxEvent In PlayEvents
                    If ev.NameOfRes = name Then
                        Return ev
                        Exit For
                    End If
                Next
                Return Nothing
            End Function

            Public Function GetStopEventByResName(ByVal name As String) As SfxEvent
                For Each ev As SfxEvent In StopEvents
                    If ev.NameOfRes = name Then
                        Return ev
                        Exit For
                    End If
                Next
                Return Nothing
            End Function

            Public Sub New(ByVal _name As String, ByVal _stopAll As Boolean)
                Me.CueName = _name
                Me.StopAll = _stopAll
                Me.PlayEvents = New List(Of SfxEvent)
                Me.StopEvents = New List(Of SfxEvent)
            End Sub

            Public Sub New(ByVal _name As String, ByVal _playEv As List(Of SfxEvent),
                           ByVal _stopEv As List(Of SfxEvent), ByVal _stopAll As Boolean,
                           Optional ByVal _stopAllDelay As Double = 0,
                           Optional ByVal _stopAllDur As Double = 0.5)
                Me.CueName = _name
                Me.PlayEvents.Clear()
                Me.StopEvents.Clear()
                Me.PlayEvents.AddRange(_playEv.ToArray)
                Me.StopEvents.AddRange(_stopEv.ToArray)
                Me.StopAll = _stopAll
                Me.StopAllDelay = _stopAllDelay
                Me.StopAllDuration = _stopAllDur
            End Sub

            Public Sub New(ByVal name As String, ByVal fromStr As String)
                Try
                    Me.CueName = name
                    Me.PlayEvents.Clear()
                    Me.StopEvents.Clear()
                    Dim spl() As String = fromStr.Split("|"c)
                    If spl.Length = 3 Then
                        Dim pSpl() As String = spl(0).Split(";"c)
                        For Each ev As String In pSpl
                            If Not String.IsNullOrEmpty(ev.Trim) Then
                                Me.PlayEvents.Add(New SfxEvent(ev))
                            End If
                        Next
                        Dim sSpl() As String = spl(1).Split(";"c)
                        For Each ev As String In sSpl
                            If Not String.IsNullOrEmpty(ev.Trim) Then
                                Me.StopEvents.Add(New SfxEvent(ev))
                            End If
                        Next
                        Try
                            Dim saSpl() As String = spl(2).Split(";"c)
                            If saSpl.Length = 3 Then
                                Me.StopAll = CBool(saSpl(0))
                                Me.StopAllDelay = CDbl(saSpl(1))
                                Me.StopAllDuration = CDbl(saSpl(2))
                            Else
                                MsgBox(
                                    "SFX Error 1.2: Data file is corrupted. If this persists, please contact the Entity Team.",
                                    MsgBoxStyle.Critical,
                                    "Error")
                                FileSystem.WriteAllText("Sfx", "[Sfx]" & vbCrLf, False)
                                Application.Restart()
                            End If
                        Catch ex As Exception
                            Me.StopAll = False
                            Me.StopAllDelay = 0
                            Me.StopAllDuration = 0.5
                        End Try
                    Else
                        MsgBox(
                            "SFX Error 1.1: Data file is corrupted. If this persists, please contact the Entity Team.",
                            MsgBoxStyle.Critical,
                            "Error")
                        FileSystem.WriteAllText("Sfx", "[Sfx]" & vbCrLf, False)
                        Application.Restart()
                    End If
                Catch
                    MsgBox(
                        "SFX Error 2: Data file is corrupted or read failed. If this persists, please contact the Entity Team.",
                        MsgBoxStyle.Critical, "Error")
                    FileSystem.WriteAllText("Sfx", "[Sfx]" & vbCrLf, False)
                    Application.Restart()
                End Try
            End Sub

            Public Function Clone(ByVal newName As String) As SfxCue
                Return New SfxCue(newName, Me.PlayEvents, Me.StopEvents, Me.StopAll)
            End Function
        End Class

        Public Class SfxEvent
            Public Enum EventType
                PlaySfx = 0
                StopSfx
            End Enum

            Public Property Type As EventType
            Public Property NameOfRes As String
            Public Property Delay As Double
            Public Property FadeDuration As Double

            Public Sub New(ByVal resource As String, ByVal _type As EventType, Optional ByVal _delay As Double = 0)
                Me.NameOfRes = resource
                Me.Type = _type
                Me.FadeDuration = -1
                Me.Delay = _delay
            End Sub

            Public Sub New(ByVal resource As String, ByVal typeOfEv As EventType, Optional ByVal dur As Double = 0,
                           Optional ByVal startDelay As Double = 0)
                Me.NameOfRes = resource
                Me.Type = typeOfEv
                Me.FadeDuration = dur
                Me.Delay = startDelay
            End Sub

            Public Sub New(ByVal fromStr As String)
                Try
                    Dim spl() As String = fromStr.Trim.Split(","c)
                    If spl.Length = 3 Then
                        Me.NameOfRes = spl(0)
                        Me.Type = CType(spl(1), EventType)
                        Me.Delay = CDbl(spl(2))
                        Me.FadeDuration = -1
                    ElseIf spl.Length = 4 Then
                        Me.NameOfRes = spl(0)
                        Me.Type = CType(spl(1), EventType)
                        Me.Delay = CDbl(spl(2))
                        Me.FadeDuration = CDbl(spl(3))
                    Else
                        MsgBox("SFX Error 3: Error converting string to SFX event (too many arguments)" &
                               ". If this persists, please contact the Entity Team.", MsgBoxStyle.Critical,
                               "Error")
                        FileSystem.WriteAllText("Sfx", "[Sfx]" & vbCrLf, False)
                        Application.Restart()
                    End If
                Catch
                    MsgBox(
                        "SFX Error 4: Error converting string to SFX event. If this persists, please contact the Entity Team.",
                        MsgBoxStyle.Critical, "Error")
                    FileSystem.WriteAllText("Sfx", "[Sfx]" & vbCrLf, False)
                    Application.Restart()
                End Try
                'NameOfRes & "," & CInt(Type) & "," & Delay
            End Sub

            Public Shadows Function ToString() As String
                If Me.FadeDuration < 0 Then
                    Return Me.NameOfRes & "," & CInt(Me.Type) & "," & CStr(Me.Delay)
                Else
                    Return Me.NameOfRes & "," & CInt(Me.Type) & "," & CStr(Me.Delay) & "," & CStr(Me.FadeDuration)
                End If
            End Function

            Public Shared Widening Operator CType(ByVal ev As SfxEvent) As String
                If ev.FadeDuration < 0 Then
                    Return ev.NameOfRes & "," & CInt(ev.Type) & "," & CStr(ev.Delay)
                Else
                    Return ev.NameOfRes & "," & CInt(ev.Type) & "," & CStr(ev.Delay) & "," & CStr(ev.FadeDuration)
                End If
            End Operator

            Public Shared Widening Operator CType(ByVal s As String) As SfxEvent
                Return New SfxEvent(s)
            End Operator

            Public Function Clone() As SfxEvent
                Return New SfxEvent(Me.NameOfRes, Me.Type, Me.Delay)
            End Function
        End Class
    End Namespace

    Namespace Projection
        Public Class PjxCue
            Public Event TransitionEnd(sender As Object)
            Public Property Cue As String
            Public Property NameOfRes As String
            Public Property Effect As PjxEngine.Effect
            Public Property Duration As Double
            Public Property Delay As Double

            Private _lastEffectHost As PictureBox
            Private _lastSize As Size
            Private _lastLoc As Point
            Private _finishInit As Boolean = False
            Public Sub New(ByVal cuename As String, ByVal resname As String, ByVal effect As PjxEngine.Effect,
                           ByVal dur As Double, ByVal startDelay As Double)
                Me.Cue = cuename
                Me.NameOfRes = resname
                Me.Effect = effect
                Me.Duration = dur
                Me.Delay = startDelay
            End Sub

            Public Sub New(ByVal cuename As String, ByVal fromstr As String)
                Dim spl() As String = fromstr.Split(","c)
                If spl.Length = 4 Then
                    Try
                        Me.Cue = cuename
                        Me.NameOfRes = spl(0)
                        Me.Effect = CType(spl(1), PjxEngine.Effect)
                        Me.Duration = CDbl(spl(2))
                        Me.Delay = CDbl(spl(3))
                    Catch ex As Exception
                        MsgBox(
                            "Projection Error 2: Data file is corrupted or read failed. If this persists, please contact the Entity Team.",
                            MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Error")
                        FileSystem.WriteAllText("Projection", "[Projection]" & vbCrLf, False)
                        Application.Restart()
                    End Try
                Else
                    MsgBox(
                        "Projection Error 1: Data file is corrupted. If this persists, please contact the Entity Team.",
                        MsgBoxStyle.Critical _
                        Or MsgBoxStyle.MsgBoxSetForeground, "Error")
                    FileSystem.WriteAllText("Projection", "[Projection]" & vbCrLf, False)
                    Application.Restart()
                End If
            End Sub

            Public Shadows Function ToString() As String
                Return Join({Me.NameOfRes, CStr(CInt(Me.Effect)), CStr(Me.Duration), CStr(Me.Delay)}, ",")
            End Function

            Public Function Clone(ByVal newCueName As String) As PjxCue
                Return New PjxCue(newCueName, Me.NameOfRes, Me.Effect, Me.Duration, Me.Delay)
            End Function

            Public Sub ExecuteCue(Optional ByVal effectHost As PictureBox = Nothing)
                If effectHost Is Nothing Then
                    effectHost = _6Misc.SecondMonitor.pb
                End If
                Dim effW As Integer = effectHost.Width
                Dim effH As Integer = effectHost.Height
                _lastSize = effectHost.Size
                _lastLoc = effectHost.Location
                checkWh(effectHost, effW, effH)
                Dim blackout As Bitmap = getBlackout(effW, effH)

                DisplayPrevCue(effectHost, blackout)

                If Me.NameOfRes = "_blackout" Then
                    SEngine = New AutoPjxEngine(blackout, effectHost, "Image", CInt(Me.Duration * 1000))
                Else
                    SEngine = New AutoPjxEngine(GetThumbnail(ImgResToPath(Me.NameOfRes), effW, effH + 1,
                                                           Color.Transparent), effectHost, "Image",
                                              CInt(Me.Duration * 1000))
                End If
                Dim pEngine As AutoPjxEngine = DirectCast(SEngine, AutoPjxEngine)
                pEngine.ColorTrans = Color.Transparent
                pEngine.EffectName = Me.Effect
                pEngine.Start()
                _lastEffectHost = effectHost
                AddHandler pEngine.EffectEnded, AddressOf EffectEnd
                If effectHost.InvokeRequired Then
                    effectHost.BeginInvoke(
                        New MethodInvoker(
                            Sub()
                                effectHost.Invalidate()
                            End Sub))
                Else
                    effectHost.Invalidate()
                End If
            End Sub
            Public Sub StepAnimate(ByVal time As Integer)
                If SEngine IsNot Nothing AndAlso _finishInit Then
                    SEngine.SetTime(time)
                End If
            End Sub
            Public Sub InitStepAnimator(Optional ByVal effectHost As PictureBox = Nothing)
                If effectHost Is Nothing Then
                    effectHost = _6Misc.SecondMonitor.pb
                End If
                Dim effW As Integer = effectHost.Width
                Dim effH As Integer = effectHost.Height
                _lastSize = effectHost.Size
                _lastLoc = effectHost.Location
                checkWh(effectHost, effW, effH)

                Dim blackout As Bitmap = getBlackout(effW, effH)
                DisplayPrevCue(effectHost, blackout)
                If Me.NameOfRes = "_blackout" Then
                    SEngine = New PjxEngine(blackout, effectHost, "Image", CInt(Me.Duration * 1000))
                Else
                    SEngine = New PjxEngine(ImgResToPath(Me.NameOfRes), effectHost, "Image",
                                              CInt(Me.Duration * 1000))
                End If
                SEngine.ColorTrans = Color.Transparent
                SEngine.SetEffect(Me.Effect)
                'SEngine.SetTime(0)
                _lastEffectHost = effectHost
                AddHandler SEngine.EffectEnded, AddressOf EffectEnd
                If effectHost.InvokeRequired Then
                    effectHost.BeginInvoke(
                        New MethodInvoker(
                            Sub()
                                effectHost.Invalidate()
                            End Sub))
                Else
                    effectHost.Invalidate()
                End If
                _finishInit = True
            End Sub
            Private Sub checkWh(ByVal effecthost As PictureBox, ByRef effW As Integer, ByRef effH As Integer)
                If effW / effH <> My.Settings.secondaryScrWH Then
                    If effecthost.InvokeRequired Then
                        Dim h As Integer = effH
                        effecthost.BeginInvoke(
                            New MethodInvoker(
                                Sub() effecthost.Width = CInt(h * My.Settings.secondaryScrWH)))
                    Else
                        effecthost.Width = CInt(effH * My.Settings.secondaryScrWH)
                    End If
                    effW = effecthost.Width
                    effH = effecthost.Height
                    If effecthost.InvokeRequired Then
                        Dim w As Integer = effW
                        effecthost.BeginInvoke(
                            New MethodInvoker(
                                Sub() effecthost.Left = CInt(_lastLoc.X + (_lastSize.Width / 2 - w / 2))))
                    Else
                        effecthost.Left = CInt(_lastLoc.X + (_lastSize.Width / 2 - effW / 2))
                    End If
                End If
            End Sub
            Private Function getBlackout(ByVal w As Integer, ByVal h As Integer) As Bitmap
                Using resBmp As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                    Using g As Graphics = Graphics.FromImage(resBmp)
                        g.Clear(Color.Black)
                    End Using
                    Return GetThumbnail(resBmp, w, h, Color.Transparent)
                End Using
                GC.Collect()
            End Function
            Private Sub DisplayPrevCue(ByVal effectHost As PictureBox, ByVal blackOut As Bitmap)
                Dim effW = effectHost.Width
                Dim effH = effectHost.Height
                Dim prevCue As Cue
                Try
                    prevCue = GetCueByName(Me.Cue).GetCueBefore
                Catch ex As Exception
                End Try
                Dim prevName As String = ""
                If effectHost.InvokeRequired Then
                    effectHost.BeginInvoke(
                        New MethodInvoker(
                            Sub()
                                effectHost.SizeMode = PictureBoxSizeMode.Normal
                                effectHost.BackgroundImageLayout = ImageLayout.None
                            End Sub
                            ))
                Else
                    effectHost.SizeMode = PictureBoxSizeMode.Normal
                    effectHost.BackgroundImageLayout = ImageLayout.None
                End If
                If Not IsPresMode Then
                    If prevCue Is Nothing Then
                        If effectHost.InvokeRequired Then
                            effectHost.BeginInvoke(
                                New MethodInvoker(
                                    Sub()
                                        effectHost.BackgroundImage = blackOut
                                    End Sub
                                    ))
                        Else
                            effectHost.BackgroundImage = blackOut
                        End If
                    Else
                        'if this is not the first cue display previous cue image
                        prevName = prevCue.Name
                        Dim prevPjxCue As New PjxCue(prevName, CurProject.Settings.GetSetting("Projection", prevName))
                        If prevPjxCue.NameOfRes = "_blackout" Then
                            If effectHost.InvokeRequired Then
                                effectHost.BeginInvoke(
                                    New MethodInvoker(
                                        Sub()
                                        effectHost.BackgroundImage = blackOut
                                    End Sub
                                        ))
                            Else
                                effectHost.BackgroundImage = blackOut
                            End If
                        Else
                            Dim prevImgPath As String = ImgResToPath(prevPjxCue.NameOfRes)
                            If effectHost.InvokeRequired Then
                                effectHost.BeginInvoke(
                                    New MethodInvoker(
                                        Sub() _
                                                         effectHost.BackgroundImage =
                                                         GetThumbnail(prevImgPath, effW, effH, Color.Transparent)))
                            Else
                                effectHost.BackgroundImage = GetThumbnail(prevImgPath, effW, effH, Color.Transparent)
                            End If
                        End If
                    End If
                End If
            End Sub


            Private Sub EffectEnd(sender As Object, e As EventArgs)
                Try
                    RemoveHandler SEngine.EffectEnded, AddressOf EffectEnd
                    RaiseEvent TransitionEnd(Me)
                    SEngine.Reset()
                    If _lastEffectHost IsNot Nothing Then
                        If _lastEffectHost.InvokeRequired Then
                            _lastEffectHost.BeginInvoke(New MethodInvoker(Sub()
                                                                              If _lastEffectHost.BackgroundImage IsNot Nothing Then
                                                                                  _lastEffectHost.BackgroundImage.Dispose()
                                                                                  _lastEffectHost.BackgroundImage = Nothing
                                                                                  If _lastEffectHost.Image IsNot Nothing Then
                                                                                      _lastEffectHost.BackgroundImage = New Bitmap(_lastEffectHost.Image)                                                                                      
                                                                                  End If
                                                                              End If

                                                                              _lastEffectHost.Size = _lastSize
                                                                              _lastEffectHost.Location = _lastLoc
                                                                              _lastEffectHost.SizeMode = PictureBoxSizeMode.CenterImage
                                                                              _lastEffectHost.BackgroundImageLayout = ImageLayout.Center
                                                                              _lastEffectHost.Refresh()
                                                                          End Sub))
                        Else
                            If _lastEffectHost.BackgroundImage IsNot Nothing Then
                                _lastEffectHost.BackgroundImage.Dispose()
                                _lastEffectHost.BackgroundImage = Nothing
                                If _lastEffectHost.Image IsNot Nothing Then
                                    _lastEffectHost.BackgroundImage = New Bitmap(_lastEffectHost.Image)
                                End If
                            End If
                            _lastEffectHost.Size = _lastSize
                            _lastEffectHost.Location = _lastLoc
                            _lastEffectHost.SizeMode = PictureBoxSizeMode.Zoom
                            _lastEffectHost.BackgroundImageLayout = ImageLayout.Zoom
                            _lastEffectHost.Refresh()
                        End If
                        System.GC.Collect()
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
            End Sub
        End Class
    End Namespace

End Namespace


