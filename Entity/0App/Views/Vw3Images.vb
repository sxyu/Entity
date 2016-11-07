Imports System.Drawing.Imaging
Imports System.IO
Imports Entity._1Dialogs.General.Add
Imports Microsoft.VisualBasic.FileIO
Imports Entity._1Dialogs.Popups
Imports Entity._1Dialogs.Loading
Imports Entity._2Namespaces.Projection
Imports Entity._4Classes.Types
Imports Entity._3Modules
Imports Entity._6Misc

Namespace _0App.Views
    Public Class Vw3Images

        Public Sub UpdateControls()
            If HasSecondMonitor Then
                lbEffect.Show()
                cbEffect.Show()
            Else
                lbEffect.Hide()
                cbEffect.Hide()
            End If
        End Sub
        Private Sub images_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'docks in viewer
            Me.Dock = DockStyle.Fill
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Dim enumVals() As String = [Enum].GetNames(GetType(PjxEngine.Effect))
            For i As Integer = 0 To enumVals.Length - 2
                cbEffect.Items.Add(enumVals(i).Replace("_", " "))
            Next
            cbEffect.SelectedIndex = My.Settings.favouriteTransition
            lbEffect.Left = cbEffect.Left - lbEffect.Width - 3
            If Not FileSystem.DirectoryExists(CurWorkDir.Path) Then
                FileSystem.CreateDirectory(CurWorkDir.Path)
            End If
            CreateProjFolders(CurProject.Path)
            loadLv()
            UpdateControls()
        End Sub
        Sub loadLv()
            lv.Items.Clear()
            Dim di As New DirectoryInfo(CurProject.ResPath)
            Dim dia As FileInfo() = di.GetFiles
            Dim toAdd As New List(Of ListViewItem)
            For Each f As FileInfo In dia
                If f.Extension.ToLower = ".jpg" Or f.Extension.ToLower = ".png" Or f.Extension.ToLower = ".gif" Then
                    If FileSystem.FileExists(CurProject.ResBackPath & "\" & f.Name) Then
                        Dim it As New ListViewItem(Path.GetFileNameWithoutExtension(f.FullName))
                        it.Tag = f.FullName
                        'preview image
                        it.ImageKey = f.Name
                        toAdd.Add(it)
                    End If
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
                    btnEdit.PerformClick()
                ElseIf e.KeyCode = Keys.F5 Then
                    loadLv()
                End If
            End If
            If e.Control Then
                If e.KeyCode = Keys.D Then
                    btnAdd.PerformClick()
                ElseIf e.KeyCode = Keys.E Then
                    btnEdit.PerformClick()
                ElseIf e.KeyCode = Keys.A Then
                    For Each i As ListViewItem In lv.Items
                        i.Selected = True
                    Next
                End If
            End If
        End Sub


        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            Dim selct As Integer = lv.SelectedItems.Count
            If selct < 1 Then
                btnDel.Enabled = False
                btnEdit.Enabled = False
            ElseIf selct = 1 Then
                btnDel.Enabled = True
                btnDel.Text = "&Delete Image"
                btnEdit.Enabled = True
            Else
                btnDel.Text = "&Delete Images"
                btnDel.Enabled = True
                btnEdit.Enabled = False
            End If
        End Sub
        Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
            Dim s As String = "s"
            If lv.SelectedItems.Count = 1 Then
                s = ""
            End If
            Dim selectedList As String = ""
            For Each i As ListViewItem In lv.SelectedItems
                Dim comma As String = ", "
                If selectedList = "" Then comma = ""
                selectedList &= comma & "''" & i.Text & "''"
            Next
            If MsgBox("Delete the image resource" & s & " " & selectedList & "?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation _
                                                                                  Or MsgBoxStyle.MsgBoxSetForeground, "Delete Resource" & s) = MsgBoxResult.Yes Then
                Dim toRemNames As New List(Of String)
                For Each i As ListViewItem In lv.SelectedItems
                    FileSystem.DeleteFile(i.Tag.ToString, UIOption.OnlyErrorDialogs, _
                               RecycleOption.DeletePermanently, UICancelOption.DoNothing)
                    FileSystem.DeleteFile(i.Tag.ToString.Replace("\resources", "\resources\0backup"), UIOption.OnlyErrorDialogs, _
                               RecycleOption.DeletePermanently, UICancelOption.DoNothing)
                    If FileSystem.FileExists(CurProject.ResCachePath & "\" & i.Text) Then
                        FileSystem.DeleteFile(CurProject.ResCachePath & "\" & i.Text, UIOption.OnlyErrorDialogs, _
                                   RecycleOption.DeletePermanently, UICancelOption.DoNothing)
                    End If
                    CurProject.Settings.DeleteSetting("Images", i.Text)
                    CurProject.Settings.DeleteSetting("Images", i.Text & " Crop")
                    If ImageCache.Images.ContainsKey(i.ImageKey) Then
                        ImageCache.Images.RemoveByKey(i.ImageKey)
                    End If
                    toRemNames.Add(i.Text)
                    lv.Items.Remove(i)
                Next
                For Each c As PjxCue In PjxCues
                    If toRemNames.Contains(c.NameOfRes) Then
                        c.NameOfRes = "_blackout"
                    End If
                Next
            End If
        End Sub

        'add image button
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Using frm As New DiagAddResImg
                With frm
                    .Text = "Add Image"
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        'add item to listview
                        If FileSystem.FileExists(.Result) Then
                            CurProject.Settings.SetSetting("Images", .Resname & " Crop", .CRec.ToString)
                            Dim wRez As Integer = My.Settings.secondaryScrRez.Width * 2
                            Dim hRez As Integer = My.Settings.secondaryScrRez.Height * 2
                            'load file into memory
                            Dim orig As Bitmap
                            Using readBMP As Bitmap = New Bitmap(.Result)
                                orig = New Bitmap(CInt(Math.Round(hRez * (readBMP.Width / readBMP.Height), 0)), hRez)
                                Using g As Graphics = Graphics.FromImage(orig)
                                    g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                                    g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                                    g.DrawImage(readBMP, 0, 0, orig.Width, orig.Height)
                                End Using
                                'crop
                                Dim bmp As New Bitmap(wRez, hRez)
                                Using crop As New Bitmap(.CropRec.Width, .CropRec.Height)
                                    Using grp As Graphics = Graphics.FromImage(crop)
                                        grp.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                                        grp.DrawImage(orig, New Rectangle(0, 0, .CropRec.Width, .CropRec.Height), .CropRec, GraphicsUnit.Pixel)
                                        bmp = New Bitmap(crop, wRez, hRez)
                                    End Using
                                End Using
                                'get extension of file
                                Dim ext As String = Path.GetExtension(.Result).ToLower
                                'create variable for modified file extension
                                Dim modext As String = ".jpg" '""
                                'Select Case ext
                                '    Case ".jpg", ".jpeg"
                                '        modext = ".jpg"
                                '    Case ".png"
                                '            modext = ".jpg" REM".png"
                                '    Case ".gif"
                                '            modext = ".jpg" REM ".gif"
                                '    Case Else
                                '        modext = ".jpg"
                                'End Select
                                If .Colormode = ImageColorMode.Normal Then
                                    SaveJpeg(CurProject.ResPath & "\" & .Resname & modext, bmp, 85)
                                    SaveJpeg(CurProject.ResBackPath & "\" & .Resname & modext, orig, 100)
                                Else
                                    Using newimg As New Bitmap(RecolorImage(bmp, CType(.Colormode, ImageColorMode)))
                                        SaveJpeg(CurProject.ResPath & "\" & .Resname & modext, newimg, 85)
                                        SaveJpeg(CurProject.ResBackPath & "\" & .Resname & modext, orig, 100)
                                    End Using
                                End If
                                Dim it As New ListViewItem(.Resname)
                                it.Tag = CurProject.ResPath & "\" & .Resname & modext
                                'preview image
                                Dim previewImg As Bitmap = New Bitmap(158, 100)
                                Try
                                    previewImg = New Bitmap(GetThumbnail(CurProject.ResPath & "\" & .Resname & modext))

                                Catch ex As Exception
                                    'if can't create preview then skip the image
                                    Exit Sub
                                End Try
                                'try to display the preview image
                                CurProject.Settings.SetSetting("Images", .Resname, CStr(.Colormode))
                                ImageCache.Images.Add(.Resname & modext, New Bitmap(previewImg))
                                SaveJpeg(CurProject.ResCachePath & "\" & .Resname, previewImg, 85)
                                lv.BeginUpdate()
                                it.ImageKey = .Resname & modext
                                lv.Items.Add(it)
                                previewImg.Dispose()
                                lv.Sort()
                                lv.EndUpdate()
                                lv.Refresh()
                                it.Selected = True
                                orig.Dispose()
                                FrmProcessing.fc = True
                                FrmProcessing.Close()
                            End Using
                            If IO.File.Exists(FileIO.SpecialDirectories.Temp & "\imgGen.jpg") Then
                                IO.File.Delete(FileIO.SpecialDirectories.Temp & "\imgGen.jpg")
                            End If
                        End If
                    End If
                End With
            End Using
        End Sub

        Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
            Using frm As New DiagAddResImg
                With frm
                    .Text = "Edit Image"
                    .Editmode = True
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        'add item to listview
                        If FileSystem.FileExists(.Result) Then
                            CurProject.Settings.SetSetting("Images", .Resname & " Crop", .CRec.ToString)
                            'load file into memory
                            Dim ext As String = IO.Path.GetExtension(.Result)
                            Dim wRez As Integer = My.Settings.secondaryScrRez.Width * 2
                            Dim hRez As Integer = My.Settings.secondaryScrRez.Height * 2
                            Using fs As New FileStream(.Result, FileMode.OpenOrCreate, FileAccess.ReadWrite)
                                Dim orig As Bitmap
                                Dim bmp As New Bitmap(wRez, hRez)
                                Using readBMP As Bitmap = New Bitmap(fs)
                                    orig = New Bitmap(CInt(Math.Round(hRez * (readBMP.Width / readBMP.Height), 0)), hRez)
                                    Using g As Graphics = Graphics.FromImage(orig)
                                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                                        g.DrawImage(readBMP, 0, 0, orig.Width, orig.Height)
                                    End Using
                                End Using
                                'orig = New Bitmap(orig, CInt(Math.Round(hRez * (orig.Width / orig.Height), 0)), hRez)
                                Using crop As New Bitmap(.CropRec.Width, .CropRec.Height)
                                    Using grp As Graphics = Graphics.FromImage(crop)
                                        grp.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                                        grp.DrawImage(orig, New Rectangle(0, 0, .CropRec.Width, .CropRec.Height), .CropRec, GraphicsUnit.Pixel)
                                        orig.Dispose()
                                        Using g2 As Graphics = Graphics.FromImage(bmp)
                                            g2.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                                            g2.DrawImage(crop, 0, 0, wRez, hRez)
                                        End Using
                                    End Using
                                End Using
                                'get extension of file
                                FileSystem.DeleteFile(CurProject.ResPath & "\" & .OrigFileName & ext)
                                If .Colormode = ImageColorMode.Normal Then
                                    SaveJpeg(CurProject.ResPath & "\" & .Resname & ext, bmp, 85)
                                    'bmp.Save(cur_respath & "\" & .resname & ext)
                                Else
                                    Using newimg As New Bitmap(RecolorImage(bmp, CType(.Colormode, ImageColorMode)))
                                        'newimg.Save(cur_respath & "\" & .resname & ext)
                                        SaveJpeg(CurProject.ResPath & "\" & .Resname & ext, newimg, 85)
                                    End Using
                                End If
                                Dim dbl As Double = 8
                                Try
                                    dbl = CDbl(CurProject.Settings.GetSetting("Images", .OrigFileName))
                                Catch ex As Exception
                                End Try

                                If .Colormode <> dbl Then
                                    If .OrigFileName <> .Resname Then
                                        'rename file
                                        FileSystem.CopyFile(.Result, CurProject.ResBackPath & "\" & .Resname & ext, True)
                                    End If
                                    If FileSystem.FileExists(CurProject.ResCachePath & "\" & .OrigFileName) Then
                                        FileSystem.DeleteFile(CurProject.ResCachePath & "\" & .OrigFileName)
                                    End If
                                    CurProject.Settings.DeleteSetting("Images", .OrigFileName)
                                    CurProject.Settings.DeleteSetting("Images", .OrigFileName & " Crop")
                                    CurProject.Settings.SetSetting("Images", .Resname, CStr(.Colormode))
                                    CurProject.Settings.SetSetting("Images", .Resname & " Crop", .CRec.ToString)
                                    lv.Items.Remove(lv.SelectedItems(0))
                                    Dim it As New ListViewItem(.Resname)
                                    it.Tag = CurProject.ResPath & "\" & .Resname & ext
                                    'preview image
                                    Dim previewImg As New Bitmap(GetThumbnail(CurProject.ResPath & "\" & .Resname & ext))
                                    If ImageCache.Images.ContainsKey(.Resname & ext) Then
                                        ImageCache.Images.RemoveByKey(.Resname & ext)
                                    End If
                                    ImageCache.Images.Add(.Resname & ext, New Bitmap(previewImg))
                                    If FileSystem.FileExists(CurProject.ResCachePath & "\" & .Resname) Then FileSystem.DeleteFile(CurProject.ResCachePath & "\" & .Resname)
                                    SaveJpeg(CurProject.ResCachePath & "\" & .Resname, previewImg, 85)
                                    'previewImg.Save(cur_rescachepath & "\" & .resname, Imaging.ImageFormat.Png)
                                    it.ImageKey = .Resname & ext
                                    lv.BeginUpdate()
                                    lv.Items.Add(it)
                                    it.Selected = True
                                    previewImg.Dispose()
                                Else
                                    lv.BeginUpdate()
                                    lv.SelectedItems(0).Text = .Resname
                                    lv.SelectedItems(0).Tag = CurProject.ResPath & "\" & .Resname & ext
                                    If .OrigFileName <> .Resname Then
                                        'rename files
                                        If FileSystem.FileExists(CurProject.ResCachePath & "\" & .OrigFileName) Then
                                            FileSystem.RenameFile(CurProject.ResCachePath & "\" & .OrigFileName, .Resname)
                                        End If
                                        If FileSystem.FileExists(CurProject.ResPath & "\" & .OrigFileName & ext) Then
                                            FileSystem.RenameFile(CurProject.ResPath & "\" & .OrigFileName & ext, .Resname & ext)
                                        End If
                                        CurProject.Settings.DeleteSetting("Images", .OrigFileName)
                                        CurProject.Settings.SetSetting("Images", .Resname, CStr(.Colormode))
                                        For Each c As PjxCue In PjxCues
                                            If c.NameOfRes = .OrigFileName Then
                                                c.NameOfRes = .Resname
                                            End If
                                        Next
                                    End If
                                    Dim previewImg As New Bitmap(GetThumbnail(CurProject.ResPath & "\" & .Resname & ext))
                                    If ImageCache.Images.ContainsKey(.OrigFileName & ext) Then
                                        ImageCache.Images.RemoveByKey(.Resname & ext)
                                    End If
                                    If ImageCache.Images.ContainsKey(.Resname & ext) Then
                                        ImageCache.Images.RemoveByKey(.Resname & ext)
                                    End If
                                    ImageCache.Images.Add(.Resname & ext, New Bitmap(previewImg))
                                    If FileSystem.FileExists(CurProject.ResCachePath & "\" & .Resname) Then FileSystem.DeleteFile(CurProject.ResCachePath & "\" & .Resname)
                                    'previewImg.Save(cur_rescachepath & "\" & .resname, Imaging.ImageFormat.Png)
                                    SaveJpeg(CurProject.ResCachePath & "\" & .Resname, previewImg, 85)
                                End If
                                lv.Sort()
                                lv.EndUpdate()
                                'make sure file is unlocked before deleting!
                                fs.Flush()
                            End Using
                            prevSel = -1
                            'If .origFileName <> .resname Then
                            '    RenameFile(.result, .resname & ext)
                            'End If
                            'close wait form
                            FrmProcessing.fc = True
                            FrmProcessing.Close()
                        End If
                    End If
                End With
            End Using
        End Sub

        Private prevSel As Integer = -1
        'when the image transition effect ends
        Private Sub EffectEnd(sender As Object, e As EventArgs)
            RemoveHandler SEngine.EffectEnded, AddressOf EffectEnd
            If HasSecondMonitor Then
                SecondMonitor.pb.BackgroundImage = Nothing
            End If
        End Sub

        Private Sub lv_ItemActivate(sender As Object, e As EventArgs) Handles lv.ItemActivate
            If lv.SelectedItems.Count > 0 Then
                Dim name As String = lv.SelectedItems(0).Tag.ToString
                Using fs As New FileStream(name, FileMode.OpenOrCreate, FileAccess.Read)
                    Using procbmp As New Bitmap(fs)
                        If HasSecondMonitor Then
                            If lv.SelectedIndices(0) <> prevSel AndAlso (SEngine Is Nothing OrElse Not DirectCast(SEngine, AutoPjxEngine).IsBusy) Then
                                With SecondMonitor
                                    Dim tbmp As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                                    If .pb.Image IsNot Nothing Then
                                        .pb.BackgroundImage = New Bitmap(.pb.Image)
                                    End If
                                    Using g As Graphics = Graphics.FromImage(tbmp)
                                        g.Clear(Color.Black)
                                        g.DrawImage(procbmp, 0, 0, My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                                        .pb.SizeMode = PictureBoxSizeMode.CenterImage
                                        .pb.BackgroundImageLayout = ImageLayout.None
                                        'procbmp.Dispose()
                                        SEngine = New AutoPjxEngine(tbmp, .pb, "Image", 1000)
                                        Dim pEngine As AutoPjxEngine = DirectCast(SEngine, AutoPjxEngine)
                                        pEngine.ColorTrans = Color.Transparent
                                        pEngine.EffectName = CType(cbEffect.SelectedIndex, PjxEngine.Effect)
                                        pEngine.Start()
                                        AddHandler pEngine.EffectEnded, AddressOf EffectEnd
                                        prevSel = lv.SelectedIndices(0)
                                    End Using
                                End With
                            End If
                        Else

                            Using diag As New DiagImageView
                                With diag
                                    .TopMost = True
                                    .Text = lv.SelectedItems(0).Text & " - Entity Image Viewer"
                                    .Width = (My.Computer.Screen.WorkingArea.Width \ 3) * 2
                                    .Height = (My.Computer.Screen.WorkingArea.Height \ 3) * 2
                                    Dim tbmp As Bitmap
                                    If procbmp.Width / procbmp.Height > .pb.Width / .pb.Height Then
                                        tbmp = New Bitmap(procbmp, .pb.Width, CInt(.pb.Width * (procbmp.Height / procbmp.Width)))
                                    Else
                                        tbmp = New Bitmap(procbmp, CInt(.pb.Height * (procbmp.Width / procbmp.Height)), .pb.Height)
                                    End If
                                    'procbmp.Dispose()
                                    .StartPosition = FormStartPosition.CenterScreen
                                    'try to display the preview image
                                    .pb.Image = tbmp
                                    .ShowDialog()
                                    tbmp.Dispose()
                                End With
                            End Using
                        End If
                    End Using
                End Using
                System.GC.Collect()
            End If
        End Sub

        Private Sub topBar_Paint(sender As Object, e As PaintEventArgs)
            'paint logo
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(129, 137, 153)), 10, 9, 32, 32)
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            e.Graphics.DrawString("En", New Font("Segoe UI SemiLight", 15), Brushes.White, 12, 11)
        End Sub


        Private Sub vw3Images_Layout(sender As Object, e As LayoutEventArgs) Handles MyBase.Layout
            lv.LargeImageList = ImageCache
        End Sub

        Private Sub cbEffect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEffect.SelectedIndexChanged
            My.Settings.favouriteTransition = cbEffect.SelectedIndex
            My.Settings.Save()
        End Sub
    End Class
End Namespace