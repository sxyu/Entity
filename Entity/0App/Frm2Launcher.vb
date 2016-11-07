Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports Entity._1Dialogs.Input
Imports Entity._2Namespaces.Light
Imports Microsoft.VisualBasic.FileIO
Imports Entity._3Modules
Imports Entity._1Dialogs.Loading
Imports Entity._1Dialogs.Popups
Imports Entity._2Namespaces
Imports Entity._2Namespaces.Sound
Imports Entity._2Namespaces.Projection
Imports Entity._4Classes.Types
Imports Entity._4Classes.Project
Imports Entity._2Namespaces.CueSys

Namespace _0App

    Public Class Frm2Launcher
        Public Const BSF_IGNORECURRENTTASK As Byte = 2 '&H2 'this ignores the current app
        Public Const BSF_POSTMESSAGE As Byte = 16 '&H10  'This posts the message
        Public Const BSM_APPLICATIONS As Byte = 8 '&H8  'This tells the windows message to just go to applications
#Region "API imports"
        <DllImport("USER32.DLL", EntryPoint:="BroadcastSystemMessageA", _
                   SetLastError:=True, CharSet:=CharSet.Unicode, _
                   ExactSpelling:=True, _
                   CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function BroadcastSystemMessage(ByVal dwFlags As Int32, ByRef pdwRecipients As Int32, ByVal uiMessage As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
            ' Leave function empty - DLLImport attribute forwards calls to BroadcastSystemMessage to
            ' BroadcastSystemMessage in USER32.DLL.
        End Function
        Public MessageId As Integer
        Private m_Mutex As System.Threading.Mutex 'Used to determine if the application is already open
        Private m_uniqueIdentifier As String = String.Empty 'user to determine if the app is already open
        <DllImport("USER32.DLL", EntryPoint:="RegisterWindowMessageA", _
                   SetLastError:=True, CharSet:=CharSet.Unicode, _
                   ExactSpelling:=True, _
                   CallingConvention:=CallingConvention.StdCall)> _
        Public Shared Function RegisterWindowMessage(ByVal pString As String) As Integer
            ' Leave function empty - DLLImport attribute forwards calls to RegisterWindowMessage to
            ' RegisterWindowMessage in USER32.DLL.
        End Function
#End Region
        Private Sub Checkprevious()
            On Error Resume Next
            'Check for previous instance of this app
            m_uniqueIdentifier = Application.ExecutablePath.Replace("\", "_")
            m_Mutex = New System.Threading.Mutex(False, m_uniqueIdentifier)
            MessageId = RegisterWindowMessage(m_uniqueIdentifier)
            If m_Mutex.WaitOne(1, True) Then
                'we are the first instance don't need to do anything

            Else
                'Cause the current form to show
                'Now brodcast a message to cause the first instance to show up
                Dim bsmRecipients As Int32 = BSM_APPLICATIONS 'Only go to applications

                Dim tmpuint32 As Int32 = 0
                tmpuint32 = tmpuint32 Or BSF_IGNORECURRENTTASK 'Ignore current app
                tmpuint32 = tmpuint32 Or BSF_POSTMESSAGE 'Post the windows message
                Dim ret As Integer
                ret = BroadcastSystemMessage(tmpuint32, bsmRecipients, MessageId, 0, 0)
                'A differnt instance already exists exit now.
                Application.Exit()
            End If
        End Sub

        Private Sub Frm2Launcher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            _6Misc.SecondMonitor.CheckExit()
            For i As Integer = 0 To 511
                DmxEngine.SetDmxValue(i, 0)
            Next
            DiagCOM.Close()
        End Sub
        Private Sub frmLauncher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If Not FileSystem.DirectoryExists(CurWorkDir.Path) Then
                FileSystem.CreateDirectory(CurWorkDir.Path)
            End If
            lbWorkingDir.Text = "Working Directory: " & CurWorkDir.Path
            btnWorkingDir.Left = lbWorkingDir.Right
            Me.Icon = My.Resources.en
            If Not FileSystem.FileExists(LightFile) Then FileSystem.WriteAllText(LightFile, "[Lights]" & vbCrLf, False)
            If Not FileSystem.DirectoryExists(Application.StartupPath & "\global") Then FileSystem.CreateDirectory(Application.StartupPath & "\global")
            ImageCache.Images.Clear()
            WFormCache.Clear()
            LoadLv()
            If lv.Items.Count > 0 Then lv.Items(0).Selected = True
            Checkprevious()
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            ImageCache.ImageSize = New Size(158, 100)
            ImageCache.ColorDepth = ColorDepth.Depth32Bit
            Me.BringToFront()
            lv.Focus()
            lv.Select()
            If FirstLaunch Then
                If My.Computer.Network.IsAvailable Then
                    If My.Settings.autoUpdateCheck Then
                        updateChecker.RunWorkerAsync()
                    End If
                End If
                'flag off firstLaunch so update checking won't be done every time this form is shown.
                FirstLaunch = False
            End If
            For i As Integer = 0 To 511
                DmxEngine.SetDmxValue(i, 0)
            Next

            If Frm0Loading.InvokeRequired Then
                Frm0Loading.Invoke(Sub() Frm0Loading.Fade(True))
            Else
                Frm0Loading.Fade(True)
            End If
        End Sub

        Private Sub LoadLv()
            Dim toAdd As New List(Of ListViewItem)
            For i As Integer = 1 To imglst.Images.Count - 1
                imglst.Images.RemoveAt(imglst.Images.Count - 1)
            Next
            'find each project and do...
            For Each p As EntityProject In CurWorkDir.GetProjects
                'create item for listview
                Dim it As New ListViewItem(p.Name)
                it.Tag = p.Path
                it.ImageKey = p.Name
                'generate preview image
                '>first check if there is a cached image called "cover"
                If FileSystem.FileExists(p.Path & "\resources\0cache\cover") Then
                    'if exists then uses the image
                    imglst.Images.Add(p.Name, GetThumbnail(p.Path & "\resources\0cache\cover"))
                Else
                    '>otherwise take the first cached image
                    Dim goodFileFound As Boolean = False
                    Dim goodFile As FileInfo
                    If FileSystem.DirectoryExists(p.Path & "\resources\0cache") Then
                        Dim Crdi As New DirectoryInfo(p.Path & "\resources\0cache")
                        Dim Carfo() As FileInfo = Crdi.GetFiles
                        If Carfo.Length > 0 Then
                            For Each f As FileInfo In Carfo
                                Try
                                    Using b As New Bitmap(f.FullName)
                                        'do nothing, testing
                                        'if there is an error then we know the file is corrupted/bad
                                        'such files are ignored
                                    End Using
                                    goodFile = f
                                    goodFileFound = True
                                    Exit For
                                Catch ex As Exception
                                End Try
                            Next
                        End If
                    End If
                    If goodFileFound Then
                        Try
                            imglst.Images.Add(p.Name, GetThumbnail(goodFile.FullName))
                        Catch ex As Exception
                            it.ImageIndex = 0
                        End Try
                    Else
                        '>if this still doesn't work then we generate a thumbnail out of the first image resource
                        Dim rdi As New DirectoryInfo(p.Path & "\resources")
                        Dim arfo() As FileInfo = rdi.GetFiles
                        Dim arf As New List(Of FileInfo)
                        For Each f As FileInfo In arfo
                            If f.Name.EndsWith(".jpg") Or f.Name.EndsWith(".png") Or f.Name.EndsWith(".gif") Then
                                Try
                                    Using fs As New FileStream(f.FullName, FileMode.Open)
                                        Using b As New Bitmap(fs)
                                            'do nothing, testing again
                                        End Using
                                    End Using
                                    arf.Add(f)
                                Catch ex As Exception
                                End Try
                                Exit For
                            End If
                        Next
                        If arf.Count = 0 Then
                            it.ImageKey = "default"
                        Else
                            Try
                                imglst.Images.Add(p.Name, GetThumbnail(arf(0).FullName))
                            Catch ex As Exception
                                it.ImageIndex = 0
                            End Try
                        End If
                    End If
                End If
                'finally, add the item to the list
                toAdd.Add(it)
            Next
            'add the list of items to the listview
            lv.BeginUpdate()
            lv.Items.Clear()
            lv.Items.AddRange(toAdd.ToArray)
            lv.EndUpdate()

            System.GC.Collect()
        End Sub
        Private Sub lv_ItemActivate(sender As Object, e As EventArgs) Handles lv.ItemActivate
            btnOpen.PerformClick()
        End Sub

        Private Sub lv_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp, lv.KeyUp
            If lv.Focused = True Then
                If e.KeyCode = Keys.Delete Then
                    btnDel.PerformClick()
                ElseIf e.KeyCode = Keys.F2 Then
                    btnRename.PerformClick()
                ElseIf e.KeyCode = Keys.F5 Then
                    LoadLv()
                End If
            End If
            If e.Control Then
                If e.KeyCode = Keys.N Then
                    btnNew.PerformClick()
                ElseIf e.KeyCode = Keys.O Then
                    btnOpen.PerformClick()
                ElseIf e.KeyCode = Keys.R Then
                    btnRename.PerformClick()
                ElseIf e.KeyCode = Keys.A Then
                    For Each i As ListViewItem In lv.Items
                        i.Selected = True
                    Next
                End If
            End If
        End Sub


        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            If lv.SelectedIndices.Count < 1 Then
                btnDel.Enabled = False
                btnOpen.Enabled = False
                btnRename.Enabled = False
                btnDel.Text = "&Delete Show"
            ElseIf lv.SelectedIndices.Count > 1 Then
                btnDel.Enabled = True
                btnOpen.Enabled = False
                btnRename.Enabled = False
                btnDel.Text = "&Delete Shows"
            Else
                btnDel.Enabled = True
                btnOpen.Enabled = True
                btnRename.Enabled = True
                btnDel.Text = "&Delete Show"
            End If
        End Sub
        'make sure the lv gets focus 
        Private Sub btn_Focus(sender As Object, e As EventArgs) Handles btnOpen.GotFocus, btnNew.GotFocus, btnDel.GotFocus
            lv.Focus()
        End Sub

        Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
            Dim s As String = "s"
            If lv.SelectedItems.Count = 1 Then s = ""
            Dim names As String = ""
            For i As Integer = 0 To lv.SelectedItems.Count - 1
                names &= lv.SelectedItems(i).Text
                If i <> lv.SelectedItems.Count - 1 Then names &= ", "
            Next
            If MsgBox("Sure you want to delete the show" & s & " ''" & names & "''?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation _
                                                                                      Or MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.DefaultButton2, "Delete Show" & s) = MsgBoxResult.Yes Then
                For Each i As ListViewItem In lv.SelectedItems
                    FileSystem.DeleteDirectory(i.Tag.ToString, UIOption.OnlyErrorDialogs, _
                                    RecycleOption.SendToRecycleBin, UICancelOption.DoNothing)
                    lv.Items.Remove(i)
                Next
            End If
        End Sub

        Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
            CurView = EntityView.Null
            Cursor.Hide()
            FrmPrepShow.Show()
            FrmPrepShow.Title = "Preparing Your Show..."
            FrmPrepShow.Description = "Locating Resources"
            FrmPrepShow.Refresh()
            FrmPrepShow.Focus()

            'entity will now load the project files and open the main GUI
            'move cursor to prevent misclicks
            Cursor.Position = New Point(Me.Width \ 2, Me.Height \ 2)
            'sets current project variables
            Dim projFileName As String = lv.SelectedItems(0).Tag.ToString() & "\" & lv.SelectedItems(0).Text & ".enproj"
            If (Not File.Exists(projFileName)) OrElse String.IsNullOrEmpty(File.ReadAllText(projFileName)) Then
                Dim x As New Xml.XmlDocument
                x.AppendChild(x.CreateElement("EntityProject"))
                x.Save(projFileName)
            End If
            CurProject = New EntityProject(projFileName)

            'loads the cached image list
            Dim di As New DirectoryInfo(CurProject.ResPath)
            'list of resources that need caching
            Dim dia As New List(Of FileInfo)
            'list of resources that are already cached
            Dim dica As New List(Of FileInfo)
            'count images
            For Each f As FileInfo In di.GetFiles()
                If CheckExtension(f.Extension, ImgFormats) Then
                    If FileSystem.FileExists(CurProject.ResCachePath & "\" & IO.Path.GetFileNameWithoutExtension(f.Name)) Then
                        dica.Add(f)
                    Else
                        dia.Add(f)
                    End If
                ElseIf CheckExtension(f.Extension, AudFormats) Then
                    If FileSystem.FileExists(CurProject.ResCachePath & "\wgraph\" & IO.Path.GetFileNameWithoutExtension(f.Name)) Then
                        dica.Add(f)
                    Else
                        dia.Add(f)
                    End If
                End If
            Next
            Dim curres As Integer = 0
            FrmPrepShow.Description = "Loading Cached Resources"
            FrmPrepShow.Refresh()
            For Each f As FileInfo In dica
                If CheckExtension(f.Extension, ImgFormats) Then
                    Using fs As New FileStream(CurProject.ResCachePath & "\" & IO.Path.GetFileNameWithoutExtension(f.Name), FileMode.Open)
                        Using previewImg As New Bitmap(fs)
                            Try
                                ImageCache.Images.Add(f.Name, New Bitmap(previewImg))
                            Catch ex As Exception
                                'skip image
                                Continue For
                            End Try
                        End Using
                    End Using
                ElseIf CheckExtension(f.Extension, AudFormats) Then
                    Using fs As New FileStream(CurProject.ResCachePath & "\wgraph\" & IO.Path.GetFileNameWithoutExtension(f.Name), FileMode.Open)
                        Using previewImg As New Bitmap(fs)
                            WFormCache.Add(f.Name, New Bitmap(previewImg))
                        End Using
                    End Using
                End If
            Next
            For Each f As FileInfo In dia
                If CheckExtension(f.Extension, ImgFormats) Then
                    'cache images
                    If FileSystem.FileExists(CurProject.ResBackPath & "\" & f.Name) Then
                        FrmPrepShow.Description = "Caching Resource " & curres & " of " & dia.Count
                        FrmPrepShow.Refresh()
                        curres += 1
                        Using previewImg As New Bitmap(158, 100)
                            Try
                                'read to a temporary bitmap file
                                Using newImg As Bitmap = New Bitmap(f.FullName)
                                    Using g As Graphics = Graphics.FromImage(previewImg)
                                        g.Clear(Color.WhiteSmoke)
                                        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
                                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                                        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                                        If newImg.Width / newImg.Height > 1.58 Then
                                            Dim h As Double = newImg.Height * (158 / newImg.Width)
                                            Dim hdist As Double = (100 - h) / 2
                                            g.DrawImage(newImg, 0, CInt(hdist), 158, CInt(h))
                                        Else
                                            Dim w As Double = newImg.Width * (100 / newImg.Height)
                                            Dim wdist As Double = (158 - w) / 2
                                            g.DrawImage(newImg, CInt(wdist), 0, CInt(w), 100)
                                        End If
                                    End Using
                                End Using
                            Catch ex As Exception
                                'if can't create preview then skip the image
                                Continue For
                            End Try
                            ImageCache.Images.Add(f.Name, New Bitmap(previewImg))
                            SaveJpeg(CurProject.ResCachePath & "\" & IO.Path.GetFileNameWithoutExtension(f.Name), previewImg, 85)
                        End Using
                        FrmPrepShow.Refresh()
                    End If
                ElseIf CheckExtension(f.Extension, AudFormats) Then
                    'cache audio graphs
                    Try
                        FrmPrepShow.Description = "Caching Resource " & curres & " of " & dia.Count
                        curres += 1
                        FrmPrepShow.Refresh()
                        Using previewImg As New Bitmap(GenerateWaveForm(f.FullName))
                            WFormCache.Add(f.Name, New Bitmap(previewImg))
                            SavePng(CurProject.ResCachePath & "\wgraph\" & IO.Path.GetFileNameWithoutExtension(f.Name), previewImg)
                        End Using
                    Catch ex As Exception
                    End Try
                End If
            Next

            'load lights
            UpdateVisual()

            'clear resource lists
            Cues.Clear()
            Subs.Clear()
            SfxCues.Clear()
            PjxCues.Clear()
            Dim allFields As List(Of String) = CurProject.Settings.GetSettingsInSection("Cues")

            For Each f As String In allFields
                Dim it As New ListViewItem(f)
                it.Name = f
                it.ImageIndex = 0
                it.Selected = False
                Cues.Add(New Cue(f, CurProject.Settings.GetSetting("Cues", f)))
            Next

            allFields = CurProject.Settings.GetSettingsInSection("Submasters")

            For Each f As String In allFields
                Dim it As New ListViewItem(f)
                it.Name = f
                it.ImageIndex = 0
                it.Selected = False
                Dim s As Submaster = New Submaster(f, CurProject.Settings.GetSetting("Submasters", f))
                Subs.Add(s)

            Next
            allFields = CurProject.Settings.GetSettingsInSection("Sfx")

            For Each f As String In allFields
                Dim it As New ListViewItem(f)
                it.Name = f
                it.ImageIndex = 0
                it.Selected = False
                SfxCues.Add(New SfxCue(f, CurProject.Settings.GetSetting("Sfx", f)))
            Next
            allFields = CurProject.Settings.GetSettingsInSection("Projection")

            For Each f As String In allFields
                Dim it As New ListViewItem(f)
                it.Name = f
                it.ImageIndex = 0
                it.Selected = False
                PjxCues.Add(New PjxCue(f, CurProject.Settings.GetSetting("Projection", f)))
            Next
            'take a lot of care to prevent misclicking - it seems to be really common at this stage according to my experiences
            Cursor.Position = New Point(Me.Width \ 2, Me.Height \ 2)
            Frm3Viewer.Show()
            'caches views
            FrmPrepShow.Description = "Initializing GUI"
            FrmPrepShow.Refresh()
            InitViews()
            'switches to the home tab
            ChangeView(EntityView.Home)
            'Cursor.Show()
            FrmPrepShow.Fade(True)
            Cursor.Position = New Point(Me.Width \ 2, Me.Height \ 2)
            System.GC.Collect()
            Me.Close()
        End Sub
        'new proj button
        Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
            Using frm As New DiagTextInput
                With frm
                    .Text = "New Show"
                    .CheckProj = True
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        'add item to listview
                        Dim it As New ListViewItem(.Result)
                        it.Tag = CurWorkDir.Path & "\" & .Result
                        it.ImageIndex = 0
                        lv.Items.Add(it)
                        it.Selected = True
                        CreateProjFolders(CurWorkDir.Path & "\" & .Result)
                        lv.Sort()
                    End If
                End With
            End Using
        End Sub

        Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
            Dim frm As New DiagTextInput
            With frm
                .Text = "Rename Show"
                .DescText = "New Name"
                .DefaultResult = lv.SelectedItems(0).Text
                .OkText = "Rename"
                .CheckProj = True
                .CheckProjIgnore = lv.SelectedItems(0).Text
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    'add item to listview
                    Dim it As ListViewItem = lv.SelectedItems(0)
                    If Not it.Text = .Result Then
                        FileSystem.RenameFile(it.Tag.ToString & "\" & it.Text & ".enproj", .Result & ".enproj")
                        FileSystem.RenameDirectory(it.Tag.ToString, .Result)
                        it.Text = .Result
                        it.Tag = CurWorkDir.Path & "\" & .Result
                    End If
                    lv.Sort()
                End If
            End With
            frm.Dispose()
        End Sub

        Private Sub frmProjs_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
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
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            e.Graphics.DrawString("En", New Font("Segoe UI SemiLight", 15), Brushes.White, 12, 11)
        End Sub

        Private Function GetEncoderInfo(ByVal mimeType As String) _
            As ImageCodecInfo
            Dim j As Integer
            Dim encoders As ImageCodecInfo()
            encoders = ImageCodecInfo.GetImageEncoders()
            For j = 0 To encoders.Length
                If encoders(j).MimeType = mimeType Then
                    Return encoders(j)
                End If
            Next j
            Return Nothing
        End Function

        Private Sub updateChecker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles updateChecker.DoWork
            If CheckUpdate(True) = 1 Then
                ShowUpdator(, True)
            End If
        End Sub

        Private Sub Frm2Launcher_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
            CheckSecondaryScreen()
        End Sub

        Private Sub BtnWorkingDir_Click(sender As Object, e As EventArgs) Handles btnWorkingDir.Click
            Using diag As New FolderBrowserDialog
                With diag
                    .ShowNewFolderButton = True
                    .Description = "Choose a working directory"
                    If .ShowDialog = Windows.Forms.DialogResult.OK AndAlso .SelectedPath <> CurWorkDir.Path Then
                        CurWorkDir = New WorkingDirectory(.SelectedPath)
                        My.Settings.workDir = .SelectedPath
                        My.Settings.Save()
                        lbWorkingDir.Text = "Working Directory: " & CurWorkDir.Path
                        btnWorkingDir.Left = lbWorkingDir.Right
                        LoadLv()
                    End If
                End With
            End Using
        End Sub
    End Class
End Namespace