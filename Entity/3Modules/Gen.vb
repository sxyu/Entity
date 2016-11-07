Imports System.IO
Imports System.Net
Imports Microsoft.VisualBasic.FileIO
Imports NAudio.Wave
Imports Entity._2Namespaces
Imports Entity._2Namespaces.Light
Imports Entity._2Namespaces.Sound
Imports Entity._2Namespaces.Projection
Imports Entity._4Classes.Types
Imports Entity._4Classes.Events
Imports Entity._6Misc
Imports Cue = Entity._2Namespaces.CueSys.Cue
Imports Entity._4Classes.Project
Imports Entity._2Namespaces.ImageIndexer
Imports Entity._2Namespaces.CueSys

Namespace _3Modules

    Module General

#Region "Global Variables"

        Public ReadOnly Property OpenFormsCount As Integer
            Get
                Dim ct As Integer
                For Each f As Form In My.Application.OpenForms
                    If f.Visible Then ct += 1
                Next
                Return ct
            End Get
        End Property

        Public ReadOnly Property OpenFormsCountNo2M As Integer
            Get
                Dim ct As Integer
                'Dim a As String = ""
                For Each f As Form In My.Application.OpenForms
                    'a &= f.Name & vbCrLf
                    'If f.Visible Then
                    If f.Tag IsNot Nothing Then
                        If f.Tag.ToString <> "_sm" Then
                            ct += 1
                        End If
                    Else
                        ct += 1
                    End If
                    'End If
                Next
                'MsgBox(a.Trim)
                Return ct
            End Get
        End Property

        ''' <summary>
        '''     default light visual editor size
        ''' </summary>
        ''' <remarks></remarks>
        Public DEFAULT_SIZE As Size
        ''' <summary>
        '''     decides whether the app is currently in presentation mode
        ''' </summary>
        ''' <remarks></remarks>
        Public IsPresMode As Boolean = False

        ''' <summary>
        '''     current project
        ''' </summary>
        ''' <remarks></remarks>
        Public CurProject As EntityProject

        ''' <summary>
        '''     current working directory
        ''' </summary>
        ''' <remarks></remarks>
        Public CurWorkDir As WorkingDirectory

        ''' <summary>
        '''     where to store global resources
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly GlobalPath As String = Application.StartupPath & "\global"


        ''' <summary>
        '''     settings file for lights
        ''' </summary>
        ''' <remarks></remarks>
        Public ReadOnly LightFile As String = Application.StartupPath & "\lights.ini"


        ''' <summary>
        '''     default dialog filter for images
        ''' </summary>
        ''' <remarks></remarks>
        Public ImageFilter As String = "All Supported Image Formats|*.png;*.jpg;*.jpeg;*.gif;*.bmp;*.tif;*.tiff;*.ico"

        Public ImgFormats() As String = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".ico"}


        ''' <summary>
        '''     default dialog filter for audio
        ''' </summary>
        ''' <remarks></remarks>
        Public AudioFilter As String = "All Supported Audio Formats|*.mp3;*.wav"

        Public AudFormats() As String = {".mp3", ".wav"}
        ' caches for image resources
        Public ImageCache As New ImageList
        ' cache for waveform data
        Public WFormCache As New indexedImageList

        ''' <summary>
        '''     Instance of slideEngine used for general animating purposes
        ''' </summary>
        ''' <remarks></remarks>
        Public SEngine As PjxEngine
        ' is it the first time the viewer is shown
        Public FirstShow As Boolean = True
        ' is it the first time the launcher is shown (this ensures that autoupdate is only ran once)
        Public FirstLaunch As Boolean = True
        ' is there a second monitor
        Public HasSecondMonitor As Boolean


        ''' <summary>
        '''     list of rectangles to draw light visuals(ellipses)
        ''' </summary>
        ''' <remarks></remarks>
        Public LightRects As New List(Of RectangleX)


        ''' <summary>
        '''     list of lights
        ''' </summary>
        ''' <remarks></remarks>
        Public Lights As New List(Of Light)


        ''' <summary>
        '''     list of submasters
        ''' </summary>
        ''' <remarks></remarks>
        Public Subs As New List(Of Submaster)


        ''' <summary>
        '''     list of cues
        ''' </summary>
        ''' <remarks></remarks>
        Public Cues As New List(Of CueSys.Cue)


        ''' <summary>
        '''     list of SFX cues
        ''' </summary>
        ''' <remarks></remarks>
        Public SfxCues As New List(Of SfxCue)


        ''' <summary>
        '''     list of PJX cues
        ''' </summary>
        ''' <remarks></remarks>
        Public PjxCues As New List(Of PjxCue)


        ''' <summary>
        '''     records past conversations on EnCOM
        ''' </summary>
        ''' <remarks></remarks>
        Public EnComMsg As String = ""

#End Region

#Region "Enums"

        Public Enum ImageColorMode
            Normal = 0
            Blackwhite = 1
            Greyscale = 2
            Sepia = 3
            Inverse = 4
            Bright = 5
            Dark = 6
            Highcontrast = 7
        End Enum

        Public Enum Alignment
            None = 0
            Center = 1
            CenterLeft = 2
            CenterRight = 3
            TopLeft = 4
            TopCenter = 5
            TopRight = 6
            BottomLeft = 7
            BottomCenter = 8
            BottomRight = 9
        End Enum

#End Region

#Region "Methods"
        ''' <summary>
        '''     Checks if each required project folder for a show exists, and if not, creates them.
        ''' </summary>
        ''' <param name="show">full show path to check</param>
        ''' <remarks></remarks>
        Public Sub CreateProjFolders(show As String)
            Try
                If Not FileSystem.DirectoryExists(show) Then FileSystem.CreateDirectory(show)
                If Not FileSystem.FileExists(show & "\" & Path.GetFileName(show) & ".enproj") Then
                    Dim x As New Xml.XmlDocument
                    x.AppendChild(x.CreateElement("EntityProject"))
                    x.Save(show & "\" & Path.GetFileName(show) & ".enproj")
                End If
                If Not FileSystem.DirectoryExists(show & "\resources") Then FileSystem.CreateDirectory(show & "\resources")
                If Not FileSystem.DirectoryExists(show & "\resources\0backup") Then _
                    FileSystem.CreateDirectory(show & "\resources\0backup")
                If Not FileSystem.DirectoryExists(show & "\resources\0cache") Then _
                    FileSystem.CreateDirectory(show & "\resources\0cache")
                If Not FileSystem.DirectoryExists(show & "\resources\0cache\wgraph") Then _
                    FileSystem.CreateDirectory(show & "\resources\0cache\wgraph")
                If Not FileSystem.DirectoryExists(Application.StartupPath & "\global") Then _
                    FileSystem.CreateDirectory(Application.StartupPath & "\global")
                If Not FileSystem.FileExists(LightFile) Then _
                    FileSystem.WriteAllText(LightFile, "[Lights]" & vbCrLf, False)
            Catch ex As Exception
                MsgBox(
                    "Project Error 1: Failed to create project folders. Detailed info displayed below:" & vbCrLf &
                    ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub

        ''' <summary>
        '''     Detects the extension of an image resource file
        ''' </summary>
        ''' <param name="res">Resource to Process</param>
        ''' <returns>Extension</returns>
        ''' <remarks></remarks>
        Function ImgResToFileExt(res As String) As String
            For Each s As String In ImgFormats
                If FileSystem.FileExists(CurProject.ResBackPath & "\" & res & s) Then
                    Return s
                End If
            Next
            Return Nothing
        End Function


        ''' <summary>
        '''     Gets the full path of an image resource file
        ''' </summary>
        ''' <param name="res">Resource to Process</param>
        ''' <returns>Full Path</returns>
        ''' <remarks></remarks>
        Function ImgResToPath(res As String) As String
            If res = "_blackout" Then Return "_blackout"
            For Each s As String In ImgFormats
                If FileSystem.FileExists(CurProject.ResBackPath & "\" & res & s) Then
                    Return CurProject.ResPath & "\" & res & s
                End If
            Next
            Return Nothing
        End Function


        ''' <summary>
        '''     Detects the extension of an audio resource file
        ''' </summary>
        ''' <param name="res">Resource to Process</param>
        ''' <returns>Extension</returns>
        ''' <remarks></remarks>
        Function AudResToFileExt(res As String) As String
            For Each s As String In AudFormats
                If FileSystem.FileExists(CurProject.ResPath & "\" & res & s) Then
                    Return s
                End If
            Next
            Return Nothing
        End Function


        ''' <summary>
        '''     Gets the full path of an audio resource file
        ''' </summary>
        ''' <param name="res">Resource to Process</param>
        ''' <returns>Full Path</returns>
        ''' <remarks></remarks>
        Function AudResToPath(res As String) As String
            For Each s As String In AudFormats
                If FileSystem.FileExists(CurProject.ResPath & "\" & res & s) Then
                    Return CurProject.ResPath & "\" & res & s
                End If
            Next
            MsgBox(
                "SFX Error 1: No such resource found. If this persists, please report the issue to the Entity Team." &
                vbCrLf &
                "extra info: " & res, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Function


        ''' <summary>
        '''     Gets the full path of an audio resource file
        ''' </summary>
        ''' <param name="res">Resource to Process</param>
        ''' <returns>Full Path</returns>
        ''' <remarks></remarks>
        Function ResWithExtExists(res As String, ByVal extList As String()) As Boolean
            For Each s As String In extList
                If FileSystem.FileExists(CurProject.ResPath & "\" & res & s) Then
                    Return True
                End If
            Next
            Return False
        End Function


        ''' <summary>
        '''     converts a keyframeslist to plain text
        ''' </summary>
        ''' <param name="list">keyframeslist to convert</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function KfListToStr(ByVal list As KeyFrameList) As String
            Try
                Dim str As String = ""
                list.Sort()
                For i As Integer = 0 To list.Length - 1
                    Dim kf As KeyFrame = list.Items(i)
                    If i < list.Length - 1 Then
                        str &= kf.Time & "," & kf.Volume & ";"
                    Else
                        str &= kf.Time & "," & kf.Volume
                    End If
                Next
                Return str
            Catch ex As Exception
                MsgBox(
                    "KFS Error 1: Failed to convert KF to string. Detailed info displayed below:" & vbCrLf & ex.ToString &
                    vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function


        ''' <summary>
        '''     converts text to a keyframeslist
        ''' </summary>
        ''' <param name="str">string to convert</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function StrToKfList(ByVal str As String) As KeyFrameList
            Try
                Dim kfList As New KeyFrameList
                Dim strSplit() As String = str.Split(";"c)
                For i As Integer = 0 To strSplit.Length - 1
                    If strSplit(i) <> "" And strSplit(i).Contains(",") Then
                        kfList.Add(CDec(strSplit(i).Split(","c)(0).Trim), CDbl(strSplit(i).Split(","c)(1).Trim))
                    End If
                Next
                If kfList.Length < 2 Then
                    kfList.Add(0, 100)
                    kfList.Add(100, 100)
                End If
                Return kfList
            Catch ex As Exception
                MsgBox(
                    "KFS Error 2: Failed to convert string to KF. Detailed info displayed below:" & vbCrLf & ex.ToString &
                    vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function



        ''' <summary>
        '''     makes sure a time value is 2 digits long (eg. 3 minutes becomes 03 minutes)
        ''' </summary>
        ''' <param name="input"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function R2Dgts(ByVal input As String) As String
            Try
                Dim output As String = input
                Select Case output.Length
                    Case 2
                    Case Is < 2
                        While output.ToString.Length < 2
                            output = "0" & output
                        End While
                    Case Is > 2
                        output = output.Remove(2)
                End Select
                Return output
            Catch ex As Exception
                Return "00"
            End Try
        End Function


        ''' <summary>
        '''     If a string is convertable to integer and is two digits when converted to integer, adds a zero before the string.
        '''     Otherwise does nothing.
        ''' </summary>
        ''' <param name="mstext"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CorrectMS(ByVal mstext As String) As String
            Try
                If CInt(mstext) < 100 Then
                    Return "0" & mstext
                Else
                    Return mstext
                End If
            Catch
                Return mstext
            End Try
        End Function


        ''' <summary>
        '''     generates a waveform graph from an audio file
        ''' </summary>
        ''' <param name="filePath">the audio file to use</param>
        ''' <param name="imageWidth">the width of the image (optional)</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GenerateWaveForm(ByVal filePath As String, Optional ByVal imageWidth As Integer = -1) As Bitmap
            Try
                If imageWidth = -1 Then imageWidth = Screen.PrimaryScreen.WorkingArea.Width - 50
                Dim waveStream As WaveStream
                Dim penColor As Color = Color.WhiteSmoke
                Dim penWidth As Integer = 1
                Dim lineColor As Color = Color.FromArgb(100, 100, 100)
                Dim lineWidth As Integer = 2
                Using outBmp As New Bitmap(imageWidth, 125)
                    Using g As Graphics = Graphics.FromImage(outBmp)
                        g.Clear(Color.CornflowerBlue)
                        Select Case Path.GetExtension(filePath).ToLower
                            Case ".mp3"
                                waveStream = New Mp3FileReader(filePath)
                            Case ".wav"
                                waveStream = New WaveFileReader(filePath)
                            Case Else
                                waveStream = New AudioFileReader(filePath)
                        End Select
                        Dim bytesPerSample As Integer =
                                CInt((waveStream.WaveFormat.BitsPerSample / 8) * waveStream.WaveFormat.Channels)
                        Dim samplesPerPixel As Integer = CInt((waveStream.Length / bytesPerSample) / imageWidth)
                        If waveStream IsNot Nothing Then
                            waveStream.Position = 0
                            Dim bytesRead As Integer
                            Dim waveData As Byte() = New Byte(samplesPerPixel * bytesPerSample - 1) {}
                            Using graphPen As Pen = New Pen(penColor, penWidth)
                                Using linePen As Pen = New Pen(lineColor, lineWidth)
                                    Try
                                        For x As Single = 0 To imageWidth - 1
                                            Dim low As Short = 0
                                            Dim high As Short = 0
                                            bytesRead = waveStream.Read(waveData, 0, samplesPerPixel * bytesPerSample)
                                            If bytesRead = 0 Then
                                                Exit For
                                            End If
                                            For n As Integer = 0 To bytesRead - 1 Step 2
                                                Dim sample As Short = BitConverter.ToInt16(waveData, n)
                                                If sample < low Then
                                                    low = sample
                                                End If
                                                If sample > high Then
                                                    high = sample
                                                End If
                                            Next
                                            Dim lowPercent As Single = ((CSng(low) - Short.MinValue) / UShort.MaxValue)
                                            Dim highPercent As Single = ((CSng(high) - Short.MinValue) / UShort.MaxValue)
                                            g.DrawLine(graphPen, x, 125 * lowPercent, x, 125 * highPercent)
                                        Next
                                        waveStream.Close()
                                    Catch ex As Exception
                                        waveStream.Close()
                                        MsgBox(ex.ToString)
                                    End Try
                                End Using
                            End Using
                        End If
                    End Using
                    Return New Bitmap(outBmp)
                End Using
            Catch ex As Exception
                FileSystem.DeleteFile(filePath)
                MsgBox("WaveForm Error 1: Failed to generate WaveForm graph of audio:''" & filePath _
                       & "''. Detailed info displayed below:" & vbCrLf & ex.ToString & vbCrLf &
                       "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                       "Error")
                Application.Exit()
            End Try
        End Function
        Public Sub SaveSubmasters()
            For Each s As Submaster In Subs
                'don't save at first to speed it up
                CurProject.Settings.SetSetting("Submasters", s.Name, s.ToString, False)
            Next
            CurProject.Settings.Save()
        End Sub
        Public Sub SaveSfxCues()
            For Each s As SfxCue In SfxCues
                'don't save at first to speed it up
                CurProject.Settings.SetSetting("Sfx", s.CueName, s.ToString, False)
            Next
            CurProject.Settings.Save()
        End Sub
        Public Sub SavePjxCues()
            For Each p As PjxCue In PjxCues
                'don't save at first to speed it up
                CurProject.Settings.SetSetting("Projection", p.Cue, p.ToString, False)
            Next
            CurProject.Settings.Save()
        End Sub
        Public Sub SaveCues()
            CurProject.Settings.ClearSection("Submasters", False)
            CurProject.Settings.ClearSection("Cues", False)
            CurProject.Settings.ClearSection("Sfx", False)
            CurProject.Settings.ClearSection("Projection", False)
            For i As Integer = 0 To Cues.Count - 1
                Dim c As Cue = Cues(i)
                'don't save at first to speed it up
                CurProject.Settings.SetSetting("Submasters", c.Name, c.GetAssociatedSubmaster.ToString, False)
                CurProject.Settings.SetSetting("Cues", c.Name, c.ToString, False)
                CurProject.Settings.SetSetting("Sfx", c.Name, c.GetAssociatedSfxCue.ToString, False)
                CurProject.Settings.SetSetting("Projection", c.Name, c.GetAssociatedPjxCue.ToString, False)
            Next
            CurProject.Settings.Save()
        End Sub
        ''' <summary>
        '''     attempts to convert the given string to a valid file path. 
        ''' </summary>
        ''' <param name="str">string to convert</param>
        ''' <remarks></remarks>
        Public Function CPath(ByVal str As String) As String
            Try
                Return _
                    str.Replace("_", " ").Replace("/", ",").Replace("\", ",").Replace("|", ",").Replace("*", "!").Replace(
                        "?", "!").
                        Replace(ControlChars.Quote, "").Replace("<", "(").Replace(":", "-").Trim.ToLower
            Catch ex As Exception
                MsgBox(
                    "Misc Error 3: Failed to convert a string to a path. Detailed info displayed below:" & vbCrLf &
                    ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function

        Public Sub CheckSecondaryScreen()
            Try
                If Screen.AllScreens.Length > 1 And My.Settings.secondaryScr <> "MANUAL" Then
                    Dim secScrDefSet As Boolean = False
                    Dim prev As Boolean = HasSecondMonitor
                    Dim secondScr As Screen
                    Dim firstNonPrimaryScr As Screen
                    For Each s As Screen In Screen.AllScreens
                        If s.DeviceName = My.Settings.secondaryScr And s.Bounds.Size = My.Settings.secondaryScrRez Then
                            secScrDefSet = True
                            HasSecondMonitor = True
                            secondScr = s
                            Exit For
                        End If
                        If s.Primary = False Then
                            firstNonPrimaryScr = s
                        End If
                    Next
                    If secScrDefSet = False And firstNonPrimaryScr IsNot Nothing Then
                        secondScr = firstNonPrimaryScr
                        HasSecondMonitor = True
                        If ClearProjectorSettings() Then
                            MsgBox("Your projector resolution has changed. You may need to re-crop your image resources.",
                                   MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground, "Projector Changed")
                        End If
                        My.Settings.secondaryScr = secondScr.DeviceName
                        My.Settings.secondaryScrWH = secondScr.Bounds.Width / secondScr.Bounds.Height
                        My.Settings.secondaryScrRez = secondScr.Bounds.Size
                        My.Settings.Save()
                    End If
                    If Not HasSecondMonitor = prev Then
                        If HasSecondMonitor Then
                            If SecondMonitor.Visible = False Then
                                SecondMonitor.Location = secondScr.Bounds.Location
                                SecondMonitor.WindowState = FormWindowState.Maximized
                                'SecondMonitor.Width = secondScr.Bounds.Width
                                'SecondMonitor.Height = secondScr.Bounds.Height
                                SecondMonitor.BringToFront()
                                SecondMonitor.Show()
                            End If
                        Else
                            SecondMonitor.Hide()
                        End If
                        ScreenChangedEvent.Instance.RaiseScreenChangedEvent()
                    End If
                Else
                    If Not HasSecondMonitor = False Then
                        HasSecondMonitor = False
                        SecondMonitor.Hide()
                        ScreenChangedEvent.Instance.RaiseScreenChangedEvent()
                    End If
                End If
            Catch ex As Exception
                MsgBox("Projector Error 1: Error occurred when checking for screens. Detailed info displayed below:" _
                       & vbCrLf & ex.ToString & vbCrLf &
                       "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                       "Error")
                Application.Restart()
            End Try
        End Sub


        ''' <summary>
        '''     Clears all projector resolution / image resource crop settings
        ''' </summary>
        ''' <remarks></remarks>
        Public Function ClearProjectorSettings() As Boolean
            Try
                Dim ret As Boolean
                Dim di As New DirectoryInfo(CurProject.ResPath)
                For Each f As FileInfo In di.GetFiles
                    If f.Extension = ".jpg" Or f.Extension = ".png" Or f.Extension = ".gif" Then
                        If CurProject.Settings.DeleteSetting("Images", Path.GetFileNameWithoutExtension(f.FullName) & " Crop") _
                            = True Then ret = True
                    End If
                Next
                Return ret
            Catch ex As Exception
                Console.WriteLine(
                    "Projector Error 2: Failed to clear projector settings. Detailed info displayed below:" _
                    & vbCrLf & ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists." & vbCrLf)
                Application.Restart()
                Return False
            End Try
        End Function

        ''' <summary>
        '''     updates all light visual data (ellipses) displayed in the light view of the cue tab.
        '''     Used when a light is changed in the lights tab while the submaster setup is open.
        ''' </summary>
        ''' <param name="refCtrl"></param>
        ''' <remarks></remarks>
        Public Sub UpdateVisual(Optional ByVal refCtrl As Control = Nothing)
            Try
                Dim oldActive As New Dictionary(Of String, Boolean)
                For i As Integer = 0 To LightRects.Count - 1
                    oldActive.Add(LightRects(i).Tag.ToString, LightRects(i).IsActive)
                Next
                LightRects.Clear()
                Lights.Clear()
                If File.Exists(LightFile) Then
                    Dim read As String() = GetAllSettingFields(LightFile)
                    Dim allFields As New List(Of String)(read)
                    For Each f As String In allFields
                        If allFields.Contains(f & " Visual") Then
                            Dim lt As New Light(f)
                            Dim l As String = GetSettingDataCaseI(LightFile, f)
                            Dim params() As String = l.Split(","c)
                            For Each chnl As String In params
                                If chnl.Contains(":") Then
                                    Dim id As String = chnl.Remove(chnl.IndexOf(":"c)).Trim
                                    Dim desc As String = chnl.Remove(0, chnl.IndexOf(":"c) + 1).Trim
                                    lt.Channels.Add(New Channel(desc, CInt(id), f))
                                End If
                            Next
                            Lights.Add(lt)
                            Dim recX As New RectangleX(GetSettingDataCaseI(LightFile, f & " Visual"), DEFAULT_SIZE)
                            recX.Tag = f
                            For Each i As KeyValuePair(Of String, Boolean) In oldActive
                                If i.Key = f Then
                                    recX.IsActive = i.Value
                                    Exit For
                                End If
                            Next
                            LightRects.Add(recX)
                            If refCtrl Is Nothing Then
                                If ViewCache(1) IsNot Nothing Then
                                    ViewCache(1).Refresh()
                                End If
                            Else
                                refCtrl.Refresh()
                            End If
                        End If
                    Next
                Else
                    FileSystem.WriteAllText(LightFile, "[Lights]" & vbCrLf, False)
                End If
            Catch
                'do nothing, no great harm
            End Try
        End Sub


        ''' <summary>
        '''     renames a light visual (ellipse) displayed in the light view of the cue tab.
        '''     Used when a light is renamed in the global setup while the lights is open.
        ''' </summary>
        ''' <param name="oldName"></param>
        ''' <param name="newName"></param>
        ''' <remarks></remarks>
        Public Sub UpdateVisualName(ByVal oldName As String, ByVal newName As String)
            Try
                For Each r As RectangleX In LightRects
                    If r.Tag.ToString = oldName Then r.Tag = newName
                Next
                For Each l As Light In Lights
                    If l.Name = oldName Then l.Name = newName
                Next
                If ViewCache(1) IsNot Nothing Then ViewCache(1).Refresh()
            Catch
            End Try
        End Sub


        ''' <summary>
        '''     converts a channel name to a channel.
        ''' </summary>
        ''' <param name="lightName">the light in which the channel is located</param>
        ''' <param name="chnlName">the channel in the light</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IndChnlToChnl(ByVal lightName As String, ByVal chnlName As String) As Integer
            For Each l As Light In Lights
                If l.Name = lightName Then
                    For Each c As Channel In l.Channels
                        If c.Name = chnlName Then
                            Return c.BufferInd
                        End If
                    Next
                    Exit For
                End If
            Next
            MsgBox("Misc Error 7: Failed to retrieve the DMX channel number from an instance of Channel." _
                   & vbCrLf & "Contact the Entity Team if this persists.",
                   MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Error")
            Application.Restart()
            Return Nothing
        End Function
        ''' <summary>
        '''    lists the channels of a particular light
        ''' </summary>
        ''' <param name="lightName">the light to process</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLightChnls(ByVal lightName As String) As Integer()
            Dim ret As New List(Of Integer)
            For Each lt As Light In Lights
                If lt.Name = lightName Then
                    For Each ch As Channel In lt.Channels
                        ret.Add(ch.BufferInd)
                    Next
                End If
            Next
            Return ret.ToArray()
        End Function
        ''' <summary>
        '''    
        ''' </summary>
        ''' <param name="lightName">the light to process</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetLightByName(ByVal lightName As String) As Light
            For Each lt As Light In Lights
                If lt.Name = lightName Then
                    Return lt
                    Exit For
                End If
            Next
        End Function
        ''' <summary>
        '''     Iterates through all submasters and finds the one with the specified name.
        ''' </summary>
        ''' <param name="s">name of submaster to search for</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSubmasterByName(ByVal s As String, Optional ByVal showError As Boolean = False) As Submaster
            For Each sm As Submaster In Subs
                If sm.Name = s Then
                    Return sm
                    Exit For
                End If
            Next
            If showError Then
                MsgBox("Misc Error 8: No such submaster (Method GetSubmasterByName)",
                       MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Error")
            Else
                Return Nothing
            End If
        End Function


        ''' <summary>
        '''     Iterates through all cues and finds the one with the specified name.
        ''' </summary>
        ''' <param name="s">name of cue to search for</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetCueByName(ByVal s As String, Optional ByVal showError As Boolean = False) As CueSys.Cue
            For Each c As CueSys.Cue In Cues
                If c.Name = s Then
                    Return c
                    Exit For
                End If
            Next
            If showError Then
                MsgBox("Misc Error 9: No such cue (Method GetCueByName)",
                       MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Error")
            Else
                Return Nothing
            End If
        End Function


        ''' <summary>
        '''     Iterates through all SFX cues and finds the one with the specified name.
        ''' </summary>
        ''' <param name="s">name of SFX cue to search for</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSfxCueByName(ByVal s As String, Optional ByVal showError As Boolean = False) As SfxCue
            For Each c As SfxCue In SfxCues
                If c.CueName = s Then
                    Return c
                    Exit For
                End If
            Next
            If showError Then
                MsgBox("Misc Error 10: No such SFX cue (Method GetSfxCueByName)",
                       MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Error")
            Else
                Return Nothing
            End If
        End Function


        ''' <summary>
        '''     Iterates through all PJX cues and finds the one with the specified name.
        ''' </summary>
        ''' <param name="s">name of PJX cue to search for</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetPjxCueByName(ByVal s As String, Optional ByVal showError As Boolean = False) As PjxCue
            For Each c As PjxCue In PjxCues
                If c.Cue = s Then
                    Return c
                    Exit For
                End If
            Next
            If showError Then
                MsgBox("Misc Error 11: No such PJX cue (Method GetPjxCueByName)",
                       MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Error")
            Else
                Return Nothing
            End If
        End Function


        ''' <summary>
        '''     Simple function to add a forward slash to the end of a path name (if it is not already present).
        ''' </summary>
        ''' <param name="input">path to process</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AFs(ByVal input As String) As String
            On Error Resume Next
            Dim output As String = input.Replace("/", "\").Trim
            If output.EndsWith("\") = False Then output &= "\"
            Return output
        End Function


        ''' <summary>
        '''     Checks if the provided path matches one of the provided extensions
        ''' </summary>
        ''' <param name="path"></param>
        ''' <param name="extList"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckExtension(ByVal path As String, ByVal extList As String()) As Boolean
            For Each s As String In extList
                If path.ToLower.EndsWith(s.ToLower) Then
                    Return True
                    Exit For
                End If
            Next
            Return False
        End Function
        Public Sub invokeCtrl(control As Control, a As Action)
            If control.InvokeRequired Then
                control.BeginInvoke(a)
            Else
                a()
            End If
        End Sub
        Public Sub UpdateCueOrder(lv As ListView, Optional offset As Integer = 0)
            For i As Integer = 0 To lv.Items.Count - 1
                Dim v As String = lv.Items(i).Text
                For j As Integer = 0 To Cues.Count - 1
                    Dim c As Cue = Cues(j)
                    If c.Name = v Then
                        If i + offset <> j Then
                            Swap(Cues, i, j)
                        End If
                        Exit For
                    End If
                Next
            Next
        End Sub
        Private Sub Swap(ByRef l As IList, i1 As Integer, i2 As Integer)
            Dim tmp As Object = l(i2)
            l(i2) = l(i1)
            l(i1) = tmp
        End Sub
#End Region
    End Module
End Namespace