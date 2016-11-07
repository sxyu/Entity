Imports System.Threading
Imports Entity.Light
Imports NAudio
Imports NAudio.Wave
Namespace EntityScript
    Public Class ESShowManager
        Implements IDisposable
#Region "Variables"
        Public Event UpdateValues()

        Private isBusy As Boolean = False
        Private isWaiting As Boolean = False

        Private prevGMValue As Double = 1
        Private quickExec As Boolean = False

        'Private execThread As Thread

        Public LChnls As New Dictionary(Of Integer, Integer)
        Public LLights As New Dictionary(Of String, Integer)
        Public LSubs As New Dictionary(Of String, Integer)
        Public LGM As Double = 1

        Public SRepeats As New Dictionary(Of String, Integer)
        Public SPlayPct As New Dictionary(Of String, Single)
        Public SReader As New Dictionary(Of String, AudioFileReader)
        Public SWaveOut As New Dictionary(Of String, WaveOut)
        Public SVolumeMulti As New Dictionary(Of String, Single)
        Public SKeyFrames As New Dictionary(Of String, KeyFrameSystem.KeyFrameList)

        Public PPj As Bitmap

        Private Threads As New List(Of Thread)
        Private STimerThread As Thread

        Private _keepTimerOn As Boolean = True
#End Region

#Region "General"
        Public Sub New()
            LGM = 1
            LChnls = New Dictionary(Of Integer, Integer)
            LSubs = New Dictionary(Of String, Integer)
            LLights = New Dictionary(Of String, Integer)
            SRepeats = New Dictionary(Of String, Integer)
            SReader = New Dictionary(Of String, AudioFileReader)
            SWaveOut = New Dictionary(Of String, WaveOut)
            SPlayPct = New Dictionary(Of String, Single)
            SVolumeMulti = New Dictionary(Of String, Single)
            SKeyFrames = New Dictionary(Of String, KeyFrameSystem.KeyFrameList)
            Threads = New List(Of Thread)
            STimerThread = New Thread(AddressOf STimerTh)
            _keepTimerOn = True
            If My.Settings.secondaryScrRez.Height > 0 Then
                PPj = New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
            Else
                PPj = New Bitmap(1280, 1024)
            End If
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            LGM = 1
            UnsetAllLights()
            UnsetAllAudio()
            For Each th As Thread In Threads
                th.Abort()
            Next
            _keepTimerOn = False
            If STimerThread IsNot Nothing Then
                STimerThread.Abort()
            End If
            PPj.Dispose()
        End Sub
        ''' <summary>
        ''' Turns Off All Lights
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub UnsetAllLights()
            LChnls.Clear()
            LSubs.Clear()
            LLights.Clear()
            For i As Integer = 1 To 512
                Set_Memory_Channel(0, i, 0)
            Next
            Send_Memory_Channels(0)
        End Sub
        ''' <summary>
        ''' Turns Off All Audio
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub UnsetAllAudio()
            
            For Each i As KeyValuePair(Of String, WaveOut) In SWaveOut
                Try
                    i.Value.Stop()
                    i.Value.Dispose()
                Catch ex As Exception
                End Try
            Next
            For Each i As KeyValuePair(Of String, AudioFileReader) In SReader
                Try
                    i.Value.Close()
                Catch ex As Exception
                End Try
            Next
            SPlayPct.Clear()
            SRepeats.Clear()
            SWaveOut.Clear()
            SReader.Clear()
            SKeyFrames.Clear()
            SVolumeMulti.Clear()
        End Sub
        ''' <summary>
        ''' Executes EntityScript Code. 
        ''' </summary>
        ''' <param name="scr">the code to execute</param>
        ''' <remarks></remarks>
        Public Sub Parse(ByVal scr As String, Optional ByVal quickExecute As Boolean = False)
            Dim execThread As New Thread(AddressOf ParseC)
            Threads.Add(execThread)
            execThread.Start(New Object() {scr, quickExecute})
        End Sub

        ''' <summary>
        ''' Executes EntityScript Code. 
        ''' </summary>
        ''' <param name="obj">the code to execute as an object</param>
        ''' <remarks></remarks>
        Private Sub ParseC(ByVal obj As Object)
            Dim args() As Object = DirectCast(obj, Object())
            Dim scr As String = CStr(args(0))
            quickExec = CBool(args(1))
            'first, fix the script for parsing
            'comment removal
            While scr.Contains("/*") And scr.Contains("*/")
                scr = scr.Remove(scr.IndexOf("/*"), scr.IndexOf("*/") - scr.IndexOf("/*") + 2)
            End While
            If scr.Contains("/*") Then scr = scr.Remove(scr.IndexOf("/*"))
            'linebreak removal
            scr = scr.Replace(vbCr, "").Replace(vbLf, "")
            'multi white space removal
            While scr.Contains("  ")
                scr = scr.Replace("  ", " ")
            End While

            'split into lines
            Dim lines() As String = scr.Split(CChar(";"))
            For Each line As String In lines
                If line.Contains("<") And line.Contains(">") And line.Length > 5 Then
                    line = line.Trim
                    Dim type As String = line.Remove(3).ToUpper.Trim
                    Dim func As String = line.ToLower.Remove(line.IndexOf("<")).Remove(0, 4).Trim
                    Dim params() As String = line.ToLower.Remove(line.LastIndexOf(">")).Remove(0, line.IndexOf("<") + 1) _
                    .Replace("es:max", "10").Replace("es:min", "0").Replace("es:half", "5") _
                    .Replace("es:infinity", "-1").Replace("es:done", "0").Replace("es:all", "-1") _
                    .Split(CChar(","))

                    Select Case type
                        Case "LFX"
                            LFXExec(func, params)
                            isBusy = True
                        Case "SFX"
                            SFXExec(func, params)
                            isBusy = True
                        Case "PJX"
                            PJXExec(func, params)
                            isBusy = True
                        Case "MAC"

                            If func = "alert" Then
                                params = line.Remove(line.LastIndexOf(">")).Remove(0, line.IndexOf("<") + 1).Split(CChar(","))
                                'if alert keep caps
                            End If
                            MACExec(func, params)
                            isBusy = True
                    End Select
                End If
                If isWaiting Then
                    Do While isBusy
                        'do nothing until the busy flag is unflagged
                    Loop
                End If
            Next
            If quickExec Then
                dmxEngine.Send_Memory_Channels(0)
            End If
            Exit Sub
        End Sub
#End Region
#Region "Lights"
        ''' <summary>
        ''' executes light effects code
        ''' </summary>
        ''' <param name="func">the function</param>
        ''' <param name="params">parameters for the function</param>
        ''' <remarks></remarks>
        Private Sub LFXExec(ByVal func As String, ByVal params As String())
            Dim paramsList As New List(Of String)
            Dim levelsList As New List(Of Integer)
            Dim dur As Integer
            If func = "flash" Or func = "fade" Then
                For Each p As String In params
                    If p.Contains("to") Then
                        Try
                            Dim level As Integer = CInt(CDbl(p.Remove(0, p.IndexOf("to") + 2).Trim) * 25.5)
                            levelsList.Add(level)
                        Catch ex As Exception
                            Continue For
                        End Try
                        p = p.Remove(p.IndexOf("to")).Trim
                        paramsList.Add(p)
                    Else
                        Try
                            dur = CInt(p)
                        Catch ex As Exception
                        End Try
                        Continue For
                    End If
                Next
            End If
            Select Case func
                Case "flash"
                    If paramsList.Count = levelsList.Count Then
                        LFlash(paramsList.ToArray, levelsList.ToArray)
                    End If
                Case "flashon"
                    Dim fonLvLst As New List(Of Integer)
                    For i As Integer = 0 To params.Length - 1
                        fonLvLst.Add(255)
                    Next
                    LFlash(params, fonLvLst.ToArray)
                Case "flashoff"
                    Dim foffLvLst As New List(Of Integer)
                    For i As Integer = 0 To params.Length - 1
                        foffLvLst.Add(0)
                    Next
                    LFlash(params, foffLvLst.ToArray)
                Case "fade"
                    If paramsList.Count = levelsList.Count Then
                        LFade(paramsList.ToArray, levelsList.ToArray, dur)
                    End If
                Case "fadeon"
                    Dim fonLvLst As New List(Of Integer)
                    Dim fonParamLst As New List(Of String)
                    For i As Integer = 0 To paramsList.Count - 2
                        fonParamLst.Add(paramsList(i))
                        fonLvLst.Add(255)
                    Next
                    LFade(paramsList.ToArray, fonLvLst.ToArray, CInt(params(params.Length - 1)))
                Case "fadeoff"
                    Dim fonLvLst As New List(Of Integer)
                    Dim fonParamLst As New List(Of String)
                    For i As Integer = 0 To paramsList.Count - 2
                        fonParamLst.Add(paramsList(i))
                        fonLvLst.Add(0)
                    Next
                    LFade(paramsList.ToArray, fonLvLst.ToArray, CInt(params(params.Length - 1)))
                Case "blackout"
                    prevGMValue = LGM
                    LFlash({"gm"}, {0})
                Case "unblackout"
                    LFlash({"gm"}, {CInt(prevGMValue * 255)})
                Case "blink"
                    LBlink(params)
                Case "blinkgm"
                    LBlinkM(params)
            End Select
            isBusy = False
        End Sub
        Private Sub LFlash(ByVal params() As String, ByVal level() As Integer)
            For i As Integer = 0 To params.Length - 1
                Try
                    Dim paramsList As New List(Of Integer)
                    If params(i).StartsWith("sub:") Then
                        Dim subName As String = params(i).Replace("sub:", "").Trim
                        For Each s As Submaster In Subs
                            If s.Name.ToLower = subName Then
                                If level(i) = 0 Then
                                    If LSubs.ContainsKey(s.Name) Then
                                        LSubs.Remove(s.Name)
                                        RaiseEvent UpdateValues()
                                    End If
                                ElseIf level(i) < 0 Then
                                    Continue For
                                Else
                                    If LSubs.ContainsKey(s.Name) Then
                                        LSubs(s.Name) = level(i)
                                    Else
                                        LSubs.Add(s.Name, level(i))
                                        RaiseEvent UpdateValues()
                                    End If
                                End If

                                For Each c As KeyValuePair(Of IndexedChannel, Integer) In s.LightList
                                    If Not paramsList.Contains(c.Key.Channel) Then
                                        paramsList.Add(c.Key.Channel)
                                    End If
                                Next
                                For Each c As KeyValuePair(Of Integer, Integer) In s.ChannelList
                                    If Not paramsList.Contains(c.Key) Then
                                        paramsList.Add(c.Key)
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    ElseIf params(i).StartsWith("light:") Then
                        Dim lightInfo As String = params(i).Replace("light:", "").Trim
                        If lightInfo.Contains(":") Then
                            Dim lightName As String = lightInfo.Remove(lightInfo.IndexOf(":")).ToLower
                            Dim chName As String = lightInfo.Remove(0, lightInfo.IndexOf(":") + 1)
                            Dim channel As Integer = IndChnlToChnl(lightName, chName)
                            If level(i) = 0 Then
                                If LLights.ContainsKey(lightName & ":" & chName) Then
                                    LLights.Remove(lightName & ":" & chName)
                                    RaiseEvent UpdateValues()
                                End If
                            Else
                                If LLights.ContainsKey(lightName & ":" & chName) Then
                                    LLights(lightName & ":" & chName) = level(i)
                                Else
                                    LLights.Add(lightName & ":" & chName, level(i))
                                    RaiseEvent UpdateValues()
                                End If
                            End If
                            If paramsList.Contains(channel) = False And channel > -1 Then
                                paramsList.Add(channel)
                            End If
                        Else
                            Dim channel As Integer = -1
                            For Each l As Light.Light In lights
                                If l.Name = lightInfo Then
                                    channel = l.getMainChannel.Channel
                                    Dim chname As String = l.getMainChannel.Name
                                    If paramsList.Contains(channel) = False And channel > -1 Then
                                        paramsList.Add(channel)
                                    End If

                                    If level(i) = 0 Then
                                        If LLights.ContainsKey(l.Name & ":" & chname) Then
                                            LLights.Remove(l.Name & ":" & chname)
                                            RaiseEvent UpdateValues()
                                        End If
                                    Else
                                        If LLights.ContainsKey(l.Name & ":" & chname) Then
                                            LLights(l.Name & ":" & chname) = level(i)
                                        Else
                                            LLights.Add(l.Name & ":" & chname, level(i))
                                            RaiseEvent UpdateValues()
                                        End If
                                    End If

                                    Exit For
                                End If
                            Next
                        End If
                    ElseIf params(i).StartsWith("channel:") Then
                        Try
                            Dim channel As Integer = CInt(params(i).Replace("channel:", "").Trim)
                            If level(i) = 0 Then
                                If LChnls.ContainsKey(channel) Then
                                    LChnls.Remove(channel)
                                    RaiseEvent UpdateValues()
                                End If
                            Else
                                If LChnls.ContainsKey(channel) Then
                                    LChnls(channel) = level(i)
                                Else
                                    LChnls.Add(channel, level(i))
                                    RaiseEvent UpdateValues()
                                End If
                            End If
                            If paramsList.Contains(CInt(channel)) Then
                                paramsList.Add(CInt(channel))
                            End If
                        Catch
                        End Try
                    ElseIf params(i).Trim = "master" Or params(i).Trim = "gm" Or params(i).Trim = "grand master" Or params(i).Trim = "grandmaster" Then
                        LGM = level(i) / 255
                        If LGM < 0 Then
                            LGM = 0
                        ElseIf LGM > 1 Then
                            LGM = 1
                        End If
                        For Each k As KeyValuePair(Of Integer, Integer) In LChnls
                            dmxEngine.Set_Memory_Channel(0, k.Key, CByte(CInt(k.Value * LGM)))
                        Next
                        For Each l As Light.Light In lights
                            For Each c As IndexedChannel In l.Channels
                                If LLights.ContainsKey(l.Name & ":" & c.Name) Then
                                    dmxEngine.Set_Memory_Channel(0, c.Channel, CByte(CInt(LLights(l.Name & ":" & c.Name) * LGM)))
                                End If
                            Next
                        Next
                        For Each s As Submaster In Subs
                            If LSubs.ContainsKey(s.Name) Then
                                For Each c As KeyValuePair(Of IndexedChannel, Integer) In s.LightList
                                    dmxEngine.Set_Memory_Channel(0, c.Key.Channel, CByte(CInt(LSubs(s.Name) * LGM)))
                                Next
                                For Each c As KeyValuePair(Of Integer, Integer) In s.ChannelList
                                    dmxEngine.Set_Memory_Channel(0, c.Key, CByte(CInt(LSubs(s.Name) * LGM)))
                                Next
                            End If
                        Next
                        dmxEngine.Send_Memory_Channels(0)
                        Continue For
                    End If
                    If CInt(level(i)) > 0 And CInt(level(i)) < 256 Then
                        For Each prm As Integer In paramsList
                            If prm > 0 And prm < 513 And quickExec = False Then
                                dmxEngine.Set_Memory_Channel(0, prm, CByte(CInt(level(i) * LGM)))
                            End If
                        Next
                    End If
                Catch
                End Try
            Next
            If quickExec = False Then
                dmxEngine.Send_Memory_Channels(0)
            End If
            isBusy = False
        End Sub
        Private Sub LFade(ByVal params() As String, ByVal level() As Integer, ByVal dur As Integer)
            Dim channelDict As New Dictionary(Of Integer, Integer)
            For i As Integer = 0 To params.Length - 1
                Try
                    Dim paramsList As New List(Of Integer)
                    If params(i).StartsWith("sub:") Then
                        Dim subName As String = params(i).Replace("sub:", "").Trim
                        For Each s As Submaster In Subs
                            If s.Name.ToLower = subName Then
                                If level(i) = 0 Then
                                    If LSubs.ContainsKey(s.Name) Then
                                        LSubs.Remove(s.Name)
                                        RaiseEvent UpdateValues()
                                    End If
                                ElseIf level(i) < 0 Then
                                    Continue For
                                Else
                                    If LSubs.ContainsKey(s.Name) Then
                                        LSubs(s.Name) = level(i)
                                    Else
                                        LSubs.Add(s.Name, level(i))
                                        RaiseEvent UpdateValues()
                                    End If
                                End If
                                For Each c As IndexedChannel In s.LightList.Keys
                                    If Not paramsList.Contains(c.Channel) Then
                                        paramsList.Add(c.Channel)
                                    End If
                                Next
                                For Each c As KeyValuePair(Of Integer, Integer) In s.ChannelList
                                    If Not paramsList.Contains(c.Key) Then
                                        paramsList.Add(c.Key)
                                    End If
                                Next
                                Exit For
                            End If
                        Next
                    ElseIf params(i).StartsWith("light:") Then
                        Dim lightInfo As String = params(i).Replace("light:", "").Trim
                        If lightInfo.Contains(":") Then
                            Dim lightName As String = lightInfo.Remove(lightInfo.IndexOf(":")).ToLower
                            Dim chName As String = lightInfo.Remove(0, lightInfo.IndexOf(":") + 1)
                            Dim channel As Integer = IndChnlToChnl(lightName, chName)
                            If level(i) = 0 Then
                                If LLights.ContainsKey(lightName & ":" & chName) Then
                                    LLights.Remove(lightName & ":" & chName)
                                    RaiseEvent UpdateValues()
                                End If
                            Else
                                If LLights.ContainsKey(lightName & ":" & chName) Then
                                    LLights(lightName & ":" & chName) = level(i)
                                Else
                                    LLights.Add(lightName & ":" & chName, level(i))
                                    RaiseEvent UpdateValues()
                                End If
                            End If
                            If paramsList.Contains(channel) = False And channel > -1 Then
                                paramsList.Add(channel)
                            End If
                        Else
                            Dim channel As Integer = -1
                            For Each l As Light.Light In lights
                                If l.Name = lightInfo Then
                                    channel = l.getMainChannel.Channel
                                    Dim chName As String = l.getMainChannel.Name
                                    If level(i) = 0 Then
                                        If LLights.ContainsKey(l.Name & ":" & chName) Then
                                            LLights.Remove(l.Name & ":" & chName)
                                            RaiseEvent UpdateValues()
                                        End If
                                    Else
                                        If LLights.ContainsKey(l.Name & ":" & chName) Then
                                            LLights(l.Name & ":" & chName) = level(i)
                                        Else
                                            LLights.Add(l.Name & ":" & chName, level(i))
                                            RaiseEvent UpdateValues()
                                        End If
                                    End If
                                    Exit For
                                End If
                            Next
                            If paramsList.Contains(channel) = False And channel > -1 Then
                                paramsList.Add(channel)
                            End If
                        End If
                    ElseIf params(i).StartsWith("channel:") Then
                        Try
                            Dim channel As Integer = CInt(params(i).Replace("channel:", "").Trim)
                            If level(i) = 0 Then
                                If LChnls.ContainsKey(channel) Then
                                    LChnls.Remove(channel)
                                    RaiseEvent UpdateValues()
                                End If
                            Else
                                If LChnls.ContainsKey(channel) Then
                                    LChnls(channel) = level(i)
                                Else
                                    LChnls.Add(channel, level(i))
                                    RaiseEvent UpdateValues()
                                End If
                            End If
                            If paramsList.Contains(CInt(channel)) Then
                                paramsList.Add(CInt(channel))
                            End If
                        Catch
                        End Try
                    ElseIf params(i).Trim = "master" Or params(i).Trim = "gm" Or _
params(i).Trim = "grand master" Or params(i).Trim = "grandmaster" Then
                        LGM = level(i) / 255
                        If LGM < 0 Then
                            LGM = 0
                        ElseIf LGM > 1 Then
                            LGM = 1
                        End If
                        paramsList.Add(0)
                    End If
                    If CInt(level(i)) > -1 And CInt(level(i)) < 256 Then
                        For Each prm As Integer In paramsList
                            If prm > 0 And prm < 513 Then
                                Try
                                    If Not channelDict.ContainsKey(prm) Then
                                        channelDict.Add(prm, level(i))
                                    End If
                                Catch ex As Exception
                                End Try
                            End If
                        Next
                    End If
                Catch
                End Try
            Next
            isBusy = False
            Dim faderThread As New Thread(AddressOf LFadeTh)
            Dim args() As Object = {channelDict, dur}
            faderThread.Start(args)
        End Sub
        Private Sub LFadeTh(ByVal args As Object)
            'restore parameters
            Dim argArr() As Object = DirectCast(args, Object())
            Dim dict As Dictionary(Of Integer, Integer) = DirectCast(argArr(0), Dictionary(Of Integer, Integer))
            Dim dur As Integer = DirectCast(argArr(1), Integer)
            Dim speed As New Dictionary(Of Integer, Double)
            Dim value As New Dictionary(Of Integer, Double)
            For Each i As KeyValuePair(Of Integer, Integer) In dict
                If i.Key > 0 Then
                    speed.Add(i.Key, (i.Value - (dmxEngine.Get_Channel(0, i.Key)) / LGM) / (dur * 20))
                    value.Add(i.Key, dmxEngine.Get_Channel(0, i.Key) / LGM)
                Else
                    speed.Add(i.Key, (i.Value - LGM * 255 / (dur * 20)))
                    value.Add(i.Key, LGM * 255)
                End If
            Next
            While dict.Count > 0
                For Each i As KeyValuePair(Of Integer, Integer) In dict
                    If i.Key > 0 Then
                        value(i.Key) = value(i.Key) - speed(i.Key)
                        Dim curVal As Integer = CInt(value(i.Key))
                        If curVal < 0 Then
                            dmxEngine.Set_Memory_Channel(0, i.Key, 0)
                            dict.Remove(i.Key)
                        ElseIf curVal <= 255 Then
                            dmxEngine.Set_Memory_Channel(0, i.Key, CByte(CInt(curVal * LGM)))
                        End If
                    ElseIf i.Key = 0 Then

                        LGM -= speed(0)
                        For Each k As KeyValuePair(Of Integer, Integer) In LChnls
                            dmxEngine.Set_Memory_Channel(0, k.Key, CByte(CInt(k.Value * LGM)))
                        Next
                        For Each l As Light.Light In lights
                            For Each c As IndexedChannel In l.Channels
                                If LLights.ContainsKey(l.Name & ":" & c.Name) Then
                                    dmxEngine.Set_Memory_Channel(0, c.Channel, CByte(CInt(LLights(l.Name & ":" & c.Name) * LGM)))
                                End If
                            Next
                        Next
                        For Each s As Submaster In Subs
                            If LSubs.ContainsKey(s.Name) Then
                                For Each c As IndexedChannel In s.LightList.Keys
                                    dmxEngine.Set_Memory_Channel(0, c.Channel, CByte(CInt(LSubs(s.Name) * LGM)))
                                Next
                                For Each c As KeyValuePair(Of Integer, Integer) In s.ChannelList
                                    dmxEngine.Set_Memory_Channel(0, c.Key, CByte(CInt(LSubs(s.Name) * LGM)))
                                Next
                            End If
                        Next

                    End If
                Next
                If quickExec = False Then
                    dmxEngine.Send_Memory_Channels(0)
                    Thread.Sleep(50)
                End If
            End While
        End Sub
        Private Sub LBlink(ByVal params() As String)
            Dim paramsList As New List(Of Integer)
            Dim interval As Double = 0.25
            Dim duration As Double = 2
            Try
                interval = CDbl(params(1))
                duration = CDbl(params(2))
                If params(0).StartsWith("sub:") Then
                    Dim subName As String = params(0).Replace("sub:", "").Trim
                    For Each s As Submaster In Subs
                        If s.Name.ToLower = subName Then
                            For Each c As IndexedChannel In s.LightList.Keys
                                If Not paramsList.Contains(c.Channel) Then
                                    paramsList.Add(c.Channel)
                                End If
                            Next
                            Exit For
                        End If
                    Next
                ElseIf params(0).StartsWith("light:") Then
                    Dim lightInfo As String = params(0).Replace("light:", "").Trim
                    If lightInfo.Contains(":") Then
                        Dim lightName As String = lightInfo.Remove(lightInfo.IndexOf(":"))
                        Dim channel As Integer = IndChnlToChnl(lightName, lightInfo.Remove(0, lightInfo.IndexOf(":") + 1))
                        If paramsList.Contains(channel) = False And channel > -1 Then
                            paramsList.Add(channel)
                        End If
                    Else
                        Dim channel As Integer = -1
                        For Each l As Light.Light In lights
                            If l.Name = lightInfo Then
                                channel = l.getMainChannel.Channel
                                Exit For
                            End If
                        Next
                        If paramsList.Contains(channel) = False And channel > -1 Then
                            paramsList.Add(channel)
                        End If
                    End If
                ElseIf params(0).StartsWith("channel:") Then
                    Dim channel As String = params(0).Replace("channel:", "").Trim
                    Try
                        If paramsList.Contains(CInt(channel)) Xor String.IsNullOrEmpty(channel) Then
                            paramsList.Add(CInt(channel))
                        End If
                    Catch
                    End Try
                ElseIf params(0).Trim = "master" Or params(0).Trim = "gm" Or params(0).Trim = "grand master" Or params(0).Trim = "grandmaster" Then
                    'add every channel
                    paramsList.Add(0)
                Else
                    Dim subName As String = params(0)
                    Dim subFound As Boolean = False
                    For Each s As Submaster In Subs
                        If s.Name.ToLower = subName Then
                            For Each c As IndexedChannel In s.LightList.Keys
                                If Not paramsList.Contains(c.Channel) Then
                                    paramsList.Add(c.Channel)
                                End If
                            Next
                            subFound = True
                            Exit For
                        End If
                    Next
                    If Not subFound Then
                        Try
                            Dim channel As Integer = CInt(params(0).Replace("channel:", "").Trim) 'try converting to int
                            If paramsList.Contains(channel) Then
                                paramsList.Add(channel)
                            End If
                        Catch ex As Exception
                            'do nothing
                        End Try
                    End If
                End If
            Catch
            End Try

            Dim blinkThread As New Thread(AddressOf LBlinkTh)
            Dim args() As Object = {paramsList, interval, duration}
            blinkThread.Start(args)
        End Sub
        Private Sub LBlinkTh(ByVal args As Object)
            'restore params
            Dim argsArr() As Object = DirectCast(args, Object())
            Dim channels As List(Of Integer) = DirectCast(argsArr(0), List(Of Integer))
            Dim interval As Integer = DirectCast(argsArr(1), Integer)
            Dim duration As Integer = DirectCast(argsArr(2), Integer)
            Dim currentTime As Double = 0
            Dim lightsOn As Boolean = False
            While currentTime < duration
                currentTime += interval
                For Each c As Integer In channels
                    If c = 0 Then

                        If lightsOn Then
                            LGM = 0
                        Else
                            LGM = 1
                        End If
                        If LGM < 0 Then
                            LGM = 0
                        ElseIf LGM > 1 Then
                            LGM = 1
                        End If
                        For Each k As KeyValuePair(Of Integer, Integer) In LChnls
                            dmxEngine.Set_Memory_Channel(0, k.Key, CByte(CInt(k.Value * LGM)))
                        Next
                        For Each l As Light.Light In lights
                            For Each ch As IndexedChannel In l.Channels
                                If LLights.ContainsKey(l.Name & ":" & ch.Name) Then
                                    dmxEngine.Set_Memory_Channel(0, ch.Channel, CByte(CInt(LLights(l.Name & ":" & ch.Name) * LGM)))
                                End If
                            Next
                        Next
                        For Each s As Submaster In Subs
                            If LSubs.ContainsKey(s.Name) Then
                                For Each ch As IndexedChannel In s.LightList.Keys
                                    dmxEngine.Set_Memory_Channel(0, ch.Channel, CByte(CInt(LSubs(s.Name) * LGM)))
                                Next
                                For Each ch As KeyValuePair(Of Integer, Integer) In s.ChannelList
                                    dmxEngine.Set_Memory_Channel(0, ch.Key, CByte(CInt(LSubs(s.Name) * LGM)))
                                Next
                            End If
                        Next
                        dmxEngine.Send_Memory_Channels(0)

                    Else
                        If lightsOn Then
                            dmxEngine.Set_Memory_Channel(0, c, 0)
                        Else
                            dmxEngine.Set_Memory_Channel(0, c, 255)
                        End If
                    End If
                Next
                dmxEngine.Send_Memory_Channels(0)
                lightsOn = Not lightsOn
                If Not quickExec Then
                    Thread.Sleep(interval * 1000)
                End If
            End While
            For Each c As Integer In channels
                dmxEngine.Set_Memory_Channel(0, c, 0)
            Next
            LGM = 1
            If Not quickExec Then
                dmxEngine.Send_Memory_Channels(0)
            End If
        End Sub


        Private Sub LBlinkM(ByVal params() As String)
            Dim paramsList As New List(Of Integer)
            Dim interval As Double = 0.25
            Dim duration As Double = 2
            Try
                interval = CDbl(params(0))
                duration = CDbl(params(1))
            Catch
            End Try
            LBlink({"gm", CStr(interval), CStr(duration)})
        End Sub
#End Region
#Region "Sound Effects"
        ''' <summary>
        ''' executes sound effects code
        ''' </summary>
        ''' <param name="func">the function</param>
        ''' <param name="params">parameters for the function</param>
        ''' <remarks></remarks>
        Private Sub SFXExec(ByVal func As String, ByVal params As String())
            'Try
            Select Case func
                Case "play"
                    SPlay(params)
                Case "pause"
                    SPause(params)
                Case "resume"
                    SResume(params)
                Case "setvolume"

                Case "stop"
                    SStop(params)
            End Select
            isBusy = False
            'Catch ex As Exception
            'End Try
        End Sub
        Private Sub SPlay(ByVal params As String())
            Dim path As String = ESAudParamToPath(params(0))
            Dim vol As Double = 100
            Dim repeats As Integer = 1
            Try
                If params.Length > 1 Then
                    vol = CDbl(params(1))
                End If
                If params.Length > 2 Then
                    repeats = CInt(params(2))
                End If
            Catch
                Exit Sub
            End Try
            If String.IsNullOrEmpty(path) Then Exit Sub
            If IO.File.Exists(path) = False Then Exit Sub
            If SReader.ContainsKey(path) Then
                SWaveOut(path) = New WaveOut
                SReader(path).CurrentTime = TimeSpan.FromTicks(CLng(SReader(path).TotalTime.Ticks * SKeyFrames(path).Items(SKeyFrames(path).Length - 1).Time / 100))
                SReader(path).Volume = CSng((SKeyFrames(path).Items(SKeyFrames(path).Length - 1).Volume / 100) * (vol / 100))
                SRepeats(path) = repeats
                SPlayPct(path) = 0
                SWaveOut(path) = New WaveOut
                SWaveOut(path).Init(SReader(path))
                SWaveOut(path).Play()
            Else
                SReader.Add(path, New AudioFileReader(path))
                SWaveOut.Add(path, New WaveOut)
                Try
                    Dim rpts As Integer = repeats
                    SRepeats.Add(path, rpts)
                Catch ex As Exception
                    SRepeats.Add(path, 1)
                End Try
                SPlayPct.Add(path, 0)
                SVolumeMulti.Add(path, CSng(vol / 100))
                Dim kfl As New KeyFrameSystem.KeyFrameList
                If path.Replace("/", "\").ToLower.StartsWith(cur_respath.ToLower) Then
                    kfl = getKeyFrames(IO.Path.GetFileNameWithoutExtension(path))
                Else
                    kfl.Add(0, 100)
                    kfl.Add(100, 100)
                End If
                SKeyFrames.Add(path, kfl)
                SWaveOut(path) = New WaveOut()
                'SFX Play <Balloon Pop,100,1>;
                'SFX Play <Dun Dun Dun,100,1>;
                SReader(path).CurrentTime = TimeSpan.FromTicks(CLng(SReader(path).TotalTime.Ticks * (kfl.Items(kfl.Length - 1).Time / 100)))
                SReader(path).Volume = CSng((kfl.Items(kfl.Length - 1).Volume / 100) * (vol / 100))
                SWaveOut(path).Init(SReader(path))
                If STimerThread.ThreadState = ThreadState.Unstarted Then
                    STimerThread.Start()
                End If
                SWaveOut(path).Play()
            End If
        End Sub
        Private Sub SStop(ByVal params As String())
            If params(0) = "-1" Then
                UnsetAllAudio()
            Else
                Dim path As String = ESAudParamToPath(params(0))
                If String.IsNullOrEmpty(path) Then Exit Sub
                If IO.File.Exists(path) = False Then Exit Sub
                If SReader.ContainsKey(path) Then
                    SWaveOut(path).Stop()
                    SWaveOut(path).Dispose()
                    SWaveOut.Remove(path)
                    SReader(path).Dispose()
                    SReader.Remove(path)
                    SVolumeMulti.Remove(path)
                    SPlayPct.Remove(path)
                    SKeyFrames.Remove(path)
                    SRepeats.Remove(path)
                End If
            End If
        End Sub
        Private Sub SPause(ByVal params As String())
            If params(0) = "-1" Then
                For Each w As KeyValuePair(Of String, WaveOut) In SWaveOut
                    w.Value.Pause()
                Next
            Else
                Dim path As String = ESAudParamToPath(params(0))
                If String.IsNullOrEmpty(path) Then Exit Sub
                If IO.File.Exists(path) = False Then Exit Sub
                If SWaveOut.ContainsKey(path) Then
                    SWaveOut(path).Pause()
                End If
            End If
        End Sub
        Private Sub SResume(ByVal params As String())
            If params(0) = "-1" Then
                For Each w As KeyValuePair(Of String, WaveOut) In SWaveOut
                    If w.Value.PlaybackState = PlaybackState.Paused Then
                        w.Value.Play()
                    End If
                Next
            Else
                Dim path As String = ESAudParamToPath(params(0))
                If String.IsNullOrEmpty(path) Then Exit Sub
                If IO.File.Exists(path) = False Then Exit Sub
                If SWaveOut.ContainsKey(path) Then
                    SWaveOut(path).Play()
                End If
            End If
        End Sub
        Private Sub SSetVolume(ByVal params As String())
            Dim vol As Single
            Try
                vol = CSng(params(1))
            Catch ex As Exception
                Exit Sub
            End Try
            If vol > 100 Then vol = 100
            If vol < 0 Then vol = 0
            If params(0) = "master" Or params(0) = "gm" Or params(0) = "grandmaster" Or params(0) = "grand master" Then
                For Each s As String In SVolumeMulti.Keys
                    SVolumeMulti(s) = vol
                Next
            Else
                Dim path As String = ESAudParamToPath(params(0))
                If SVolumeMulti.ContainsKey(path) Then
                    SVolumeMulti(path) = vol
                End If
            End If
        End Sub
        Private Sub STimerTh()
            Dim sList As New List(Of String)
            While _keepTimerOn
                sList.Clear()
                For Each s As String In SReader.Keys
                    sList.Add(s)
                Next
                For Each s As String In sList
                    Dim r As AudioFileReader = SReader(s)
                    Dim startTime As Double = SKeyFrames(s).Items(SKeyFrames(s).Length - 1).Time
                    Dim endTime As Double = SKeyFrames(s).Items(0).Time
                    Dim curTime As Double = r.CurrentTime.Ticks / r.TotalTime.Ticks * 100
                    If curTime >= endTime Then
                        Thread.Sleep(200)
                        Dim repeats As Integer = SRepeats(s)
                        Dim name As String = "file:" & s
                        'SFX Play <Dun Dun Dun,100,es:Infinity>;
                        SReader(s).CurrentTime = TimeSpan.FromTicks(CLng(r.TotalTime.Ticks * (startTime / 100)))
                        If repeats > 1 Then
                            SRepeats(s) -= 1
                            SPlay({name})
                            Continue For
                        ElseIf repeats = 1 Then
                            SStop({name})
                            Continue For
                        Else
                            SPlay({name, SVolumeMulti(s).ToString, "-1"})
                            Continue For
                        End If
                    End If
                    Dim curRealTime As Double = curTime - startTime
                    SPlayPct(s) = CSng(curRealTime / (endTime - startTime))
                    If SKeyFrames.ContainsKey(s) Then
                        If SKeyFrames(s).Length > 1 Then
                            SReader(s).Volume = CSng(SKeyFrames(s).CalcVolumeByTime(CDec(curTime)) / 100 * SVolumeMulti(s))
                        End If
                    End If
                Next
                Thread.Sleep(200)
            End While
        End Sub
        Private Function getKeyFrames(ByVal audName As String) As KeyFrameSystem.KeyFrameList
            Dim setting As String = getSettingDataCaseI(cur_resaud, audName & "KF")
            If setting = "0" Then
                Dim kfl As New KeyFrameSystem.KeyFrameList
                kfl.Add(0, 100)
                kfl.Add(100, 100)
                Return kfl
            Else
                Return StrToKfList(setting)
            End If
        End Function
        Private Function ESAudParamToPath(ByVal ESParam As String) As String
            Dim temp As String = ""
            If ESParam.StartsWith("audio:") Then
                temp = cur_respath & "\" & ESParam.Remove(0, ESParam.IndexOf(":") + 1)
            ElseIf ESParam.StartsWith("global:") Then
                temp = GlobalPath & "\" & ESParam.Remove(0, ESParam.IndexOf(":") + 1)
            ElseIf ESParam.StartsWith("file:") Then
                temp = ESParam.Remove(0, ESParam.IndexOf(":") + 1)
            Else
                temp = cur_respath & "\" & ESParam.Remove(0, ESParam.IndexOf(":") + 1)
            End If
            If IO.File.Exists(temp) Then
                Return temp
            ElseIf IO.File.Exists(temp & ".mp3") Then
                Return temp & ".mp3"
            ElseIf IO.File.Exists(temp & ".wav") Then
                Return temp & ".wav"
            Else
                Return Nothing
            End If
        End Function
#End Region
#Region "Projection"
        ''' <summary>
        ''' executes projection code
        ''' </summary>
        ''' <param name="func">the function</param>
        ''' <param name="params">parameters for the function</param>
        ''' <remarks></remarks>
        Private Sub PJXExec(ByVal func As String, ByVal params As String())

        End Sub
#End Region
#Region "Macros"
        ''' <summary>
        ''' executes macros code
        ''' </summary>
        ''' <param name="func">the function</param>
        ''' <param name="params">parameters for the function</param>
        ''' <remarks></remarks>
        Private Sub MACExec(ByVal func As String, ByVal params As String())
            If func = "wait" Then
                If params(0) = "0" Then
                    MWaitDone(params)
                Else
                    Try
                        Dim a As Integer = CInt(params(0))
                    Catch ex As Exception
                        Exit Sub
                    End Try
                    MWait(params)
                End If
            ElseIf func = "alert" Then
                MAlert(params)
            End If
            isBusy = False
        End Sub
        Private Sub MWait(ByVal params() As String)
            If quickExec = False Then
                Thread.Sleep(CInt(CDbl(params(0)) * 1000))
            End If
        End Sub
        Private Sub MWaitDone(ByVal params() As String)
            If quickExec = False Then
                isWaiting = True
            End If
        End Sub
        Private Sub MAlert(ByVal params() As String)
            'temporary. please change later
            Dim toPrompt As String = ""
            For Each s As String In params
                toPrompt &= s & vbCrLf
            Next
            toPrompt = toPrompt.Trim
            MsgBox(toPrompt, MsgBoxStyle.MsgBoxSetForeground, "Alert")
        End Sub

        'include EnCOM automessage functions later
#End Region
    End Class
End Namespace