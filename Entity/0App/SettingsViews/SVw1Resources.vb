Imports System.Drawing.Text
Imports System.IO
Imports Entity._1Dialogs.General
Imports Microsoft.VisualBasic.FileIO
Imports Entity._3Modules
Imports Entity._1Dialogs.Tools
Imports Entity._1Dialogs.Popups

Namespace _0App.SettingsViews

    Public Class Svw1Resources
        Private _path As String
        Private _infoText As String
        'Private _prevPath As String
        Private _prevType As String
        Private _firstMove As Boolean = True
        Private _prevLabel As String
        Private _updateTimer As New Timers.Timer(150)
        Private _refreshTimer As New Timers.Timer(150)
        Private _dR As Boolean = False
        Private _dD As Boolean = False
        Private _rf As Boolean = False
        'Private _suppressActivate As Boolean = False

        Private Sub svw1Resources_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
            imgLst.Images.Add(My.Resources.Folder)
            imgLst.Images.Add(My.Resources.Headphones)
            imgLst.Images.Add(My.Resources.photo)
            imgLst.Images.Add(My.Resources.Document)
            backSplit.SplitterDistance = CInt(backSplit.Height * My.Settings.globResViewSplitter)
            AddHandler _updateTimer.Elapsed, AddressOf UpdateTimerTick
            AddHandler _refreshTimer.Elapsed, AddressOf RefreshTimerTick
            LoadLv(GlobalPath)
        End Sub

        'UserControl overrides dispose to clean up the component list.
        <DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub
        Private Sub UpdateTimerTick()
            _updateTimer.Stop()
            If _dD Then
                _dD = False
                If btnDelete.Enabled Then btnDelete.Invoke(New MethodInvoker(Sub() btnDelete.Enabled = False))
            End If
            If _dR Then
                _dR = False
                If btnRename.Enabled Then btnRename.Invoke(New MethodInvoker(Sub() btnRename.Enabled = False))
            End If
        End Sub
        Private Sub RefreshTimerTick()
            _refreshTimer.Stop()
            If _rf Then
                _rf = False
                backSplit.Panel2.Invoke(New MethodInvoker(Sub() backSplit.Panel2.Invalidate()))
            End If
        End Sub
        Private Sub LoadLv(ByVal path As String)
            'make sure the listview is cleared, so items don't repeat
            lv.Items.Clear()
            _path = path
            breadcrumbs.Text = path.Replace(GlobalPath, "Global Resources").Replace("\", " > ")
            'create a list for items
            Dim toAdd As New List(Of ListViewItem)
            If Not path = GlobalPath Then
                'if not the current path is the root path, add an item to navigate 'up'
                Dim pdi As New ListViewItem("(Up One Directory)")
                pdi.ImageIndex = 5
                pdi.Tag = IO.Path.GetDirectoryName(path.Remove(path.Length - 1))
                toAdd.Add(pdi)
            End If
            If Directory.Exists(path) Then
                Dim di As New DirectoryInfo(path)
                'get and add dirs
                For Each d As DirectoryInfo In di.GetDirectories
                    Dim i As New ListViewItem(d.Name)
                    'set the image of the item to the folder icon (see the imglist il)
                    i.ImageIndex = 0
                    i.SubItems.Add("Folder")
                    'set the item's tag to the full path of the dir
                    i.Tag = d.FullName
                    toAdd.Add(i)
                Next
                'get and add files
                For Each f As FileInfo In di.GetFiles
                    Dim i As New ListViewItem(IO.Path.GetFileNameWithoutExtension(f.FullName))
                    'list of image formats to check
                    i.SubItems.Add("File")
                    i.ImageIndex = 3
                    If General.CheckExtension(f.Name, ImgFormats) Then
                        'image file
                        i.ImageIndex = 2
                        i.SubItems(1).Text = "Image"
                    ElseIf General.CheckExtension(f.Name, AudFormats) Then
                        'audio file
                        i.ImageIndex = 1
                        i.SubItems(1).Text = "Audio"
                    Else
                        Continue For
                    End If
                    'add size of file
                    '1024 B = 1 KB 
                    '1048576 B = 1 MB
                    '1073741824 B = 1 GB
                    If f.Length < 512 Then
                        i.SubItems.Add(CStr(f.Length) & " Bytes")
                    ElseIf f.Length < 512000 Then
                        i.SubItems.Add(CStr(Math.Round(f.Length / 1024, 1)) & " KB")
                    ElseIf f.Length < 524288000 Then
                        i.SubItems.Add(CStr(Math.Round(f.Length / 1048576, 1)) & " MB")
                    Else
                        i.SubItems.Add(CStr(Math.Round(f.Length / 1073741824, 1)) & " GB")
                    End If
                    'set the item's tag to the full path of the file
                    i.Tag = f.FullName
                    toAdd.Add(i)
                Next
            End If
            'items are collected then added because otherwise the listview can get really slow
            lv.Items.AddRange(toAdd.ToArray)
            'note: first activation is no longer suppressed in this version due to keyboard accessibility issues
            'If lv.Items.Count > 0 Then
            '    lv.Items(0).Selected = True
            '    'make sure the user still has to double click the selected item to activate it. This prevents accidental navigations.
            '    _suppressActivate = True
            'End If
            lv.Focus()
        End Sub

        Private Sub lv_DragDrop(sender As Object, e As DragEventArgs) Handles lv.DragDrop
            Dim localPt As Point = lv.PointToClient(New Point(e.X, e.Y))
            Dim dropItm As ListViewItem = lv.GetItemAt(localPt.X, localPt.Y)
            'MsgBox(dropItm.Text)
            If dropItm IsNot Nothing AndAlso Directory.Exists(dropItm.Tag.ToString) Then
                If (dropItm.ImageIndex = 0 Or dropItm.Text = "(Up One Directory)") And e.Data.GetDataPresent(DataFormats.FileDrop) Then
                    Dim origFile As String = e.Data.GetData(DataFormats.FileDrop)
                    Dim origFileName As String = Path.GetFileName(origFile.Trim({"\"c, "/"c}))
                    If origFile <> dropItm.Tag.ToString Then
                        If File.Exists(origFile) Then
                            FileIO.FileSystem.MoveFile(origFile, dropItm.Tag.ToString & "\" & origFileName)
                        ElseIf Directory.Exists(origFile) Then
                            FileIO.FileSystem.MoveDirectory(origFile, dropItm.Tag.ToString & "\" & origFileName)
                        End If
                        LoadLv(dropItm.Tag.ToString)
                        For Each i As ListViewItem In lv.Items
                            If i.Text = Path.GetFileNameWithoutExtension(origFileName) Then
                                i.EnsureVisible()
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If
        End Sub

        Private Sub lv_DragEnter(sender As Object, e As DragEventArgs) Handles lv.DragEnter
            e.Effect = DragDropEffects.Move
        End Sub


        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            If Me.Width < 900 Then
                btnYoutube.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                btnDelete.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                btnNewFolder.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                btnRename.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                btnAdd.Anchor = AnchorStyles.Top Or AnchorStyles.Left
                pnlButtons.Refresh()
            End If
            If lv.SelectedItems.Count <> 1 Then
                'backSplit.Panel2Collapsed = True
                If lv.SelectedItems.Count > 1 Then
                    If Not btnDelete.Enabled Then btnDelete.Enabled = True
                    If _updateTimer IsNot Nothing Then
                        _updateTimer.Stop()
                    End If
                Else
                    'If btnDelete.Enabled Then btnDelete.Enabled = False
                    _dD = True
                    _updateTimer.Start()
                End If
                'If btnRename.Enabled Then btnRename.Enabled = False
                _dR = True
                _updateTimer.Start()
            Else
                If backSplit.Panel2Collapsed Then
                    backSplit.Panel2Collapsed = False
                End If
                '_suppressActivate = False
                If lv.SelectedItems(0).Text = "(Up One Directory)" Then
                    'backSplit.Panel2Collapsed = True
                    btnDelete.Enabled = False
                    btnDelete.Enabled = False
                    btnRename.Enabled = False
                    Exit Sub
                End If
                btnDelete.Enabled = True
                btnRename.Enabled = True
                If lv.SelectedItems(0).SubItems(1).Text = "Folder" Then
                    Dim info As New DirectoryInfo(lv.SelectedItems(0).Tag.ToString)
                    _infoText = "Name: " & info.Name & vbCrLf & "Type: " & lv.SelectedItems(0).SubItems(1).Text
                    If lv.SelectedItems(0).SubItems.Count > 2 Then
                        _infoText &= vbCrLf & "Size: " & lv.SelectedItems(0).SubItems(2).Text
                    End If
                    _infoText &= vbCrLf & "Last Accessed: " & info.LastAccessTime
                Else
                    Dim info As New FileInfo(lv.SelectedItems(0).Tag.ToString)
                    _infoText = "Name: " & info.Name & vbCrLf & "Type: " & lv.SelectedItems(0).SubItems(1).Text
                    If lv.SelectedItems(0).SubItems.Count > 2 Then
                        _infoText &= vbCrLf & "Size: " & lv.SelectedItems(0).SubItems(2).Text
                    End If
                    _infoText &= vbCrLf & "Last Accessed: " & info.LastAccessTime
                End If
                '_prevPath = lv.SelectedItems(0).Tag.ToString
                _prevType = lv.SelectedItems(0).SubItems(1).Text
                _refreshTimer.Stop()
                _rf = True
                _refreshTimer.Start()
                'backSplit.Panel2.Refresh()
                If lv.SelectedItems(0).SubItems.Count > 1 Then
                    If lv.SelectedItems(0).SubItems(1).Text = "Show Control" Then
                        btnDelete.Enabled = False
                        _dD = True
                        _updateTimer.Start()
                    Else
                        btnDelete.Enabled = True
                    End If
                Else
                    btnDelete.Enabled = True
                End If
                If _updateTimer IsNot Nothing Then _updateTimer.Stop()
            End If
        End Sub


        Private Sub back_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles backSplit.Panel2.Paint
            Using backbuffer As New Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height)
                Using g As Graphics = Graphics.FromImage(backbuffer)
                    g.TextRenderingHint = TextRenderingHint.AntiAlias
                    Dim sideL As Integer = backSplit.Panel2.Height - 30
                    Using br As New SolidBrush(Color.White)
                        g.DrawString(_infoText, Me.Font, br, 30 + sideL, 15)
                    End Using
                    Using br As New SolidBrush(Color.FromArgb(170,170,170))
                        g.FillRectangle(br, 15, 15, sideL, sideL)
                    End Using
                    Dim _prevImg As Bitmap
                    Select Case _prevType
                        Case "Folder"
                            _prevImg = My.Resources.Folder.ToBitmap
                        Case "Audio"
                            _prevImg = My.Resources.Headphones.ToBitmap
                        Case "Image"
                            Using fs As New FileStream(lv.SelectedItems(0).Tag.ToString, FileMode.Open)
                                Using readBMP As New Bitmap(fs)
                                    _prevImg = GetThumbnail(readBMP, sideL, sideL)
                                End Using
                            End Using
                        Case Else
                            _prevImg = My.Resources.Document.ToBitmap
                    End Select
                    g.DrawImage(_prevImg, CInt(15 + sideL / 2 - _prevImg.Width / 2), CInt(15 + sideL / 2 - _prevImg.Height / 2))
                    _prevImg.Dispose()
                    e.Graphics.DrawImageUnscaled(backbuffer, 0, 0)
                End Using
            End Using
        End Sub

        Private Sub lv_ItemActivate(sender As Object, e As EventArgs) Handles lv.ItemActivate
            If lv.SelectedItems.Count = 1 Then
                'If _suppressActivate Then
                '    _suppressActivate = False
                'Else
                If lv.SelectedItems(0).ImageIndex = 0 Or lv.SelectedItems(0).Text = "(Up One Directory)" Then
                    LoadLv(lv.SelectedItems(0).Tag.ToString)
                Else
                    If lv.SelectedItems(0).SubItems(1).Text = "Image" Then
                        Using diag As New DiagImageView
                            With diag
                                Dim tbmp As Bitmap
                                Using _
                                    fs As New FileStream(lv.SelectedItems(0).Tag.ToString, FileMode.Open, FileAccess.Read)
                                    Using procbmp As New Bitmap(fs)
                                        .TopMost = True
                                        .Text = lv.SelectedItems(0).Text & " - Entity Image Viewer"
                                        .Width = (My.Computer.Screen.WorkingArea.Width \ 3) * 2
                                        .Height = (My.Computer.Screen.WorkingArea.Height \ 3) * 2
                                        If procbmp.Width / procbmp.Height > .pb.Width / .pb.Height Then
                                            tbmp = New Bitmap(procbmp, .pb.Width,
                                                              CInt(.pb.Width * (procbmp.Height / procbmp.Width)))
                                        Else
                                            tbmp = New Bitmap(procbmp, CInt(.pb.Height * (procbmp.Width / procbmp.Height)),
                                                              .pb.Height)
                                        End If
                                        'procbmp.Dispose()
                                        .StartPosition = FormStartPosition.Manual
                                        .Left = CInt(Screen.PrimaryScreen.Bounds.Width / 2 - .Width / 2)
                                        .Top =
                                            CInt(
                                                Screen.PrimaryScreen.Bounds.Height / 2 - .Height / 2 + btnNewFolder.Height / 2)
                                        'try to display the preview image
                                        .pb.Image = tbmp
                                    End Using
                                End Using
                                .ShowDialog()
                                tbmp.Dispose()
                            End With
                        End Using
                    ElseIf CheckExtension(lv.SelectedItems(0).Tag.ToString, AudFormats) Then
                        Using diag As New DiagMPlayer(lv.SelectedItems(0).Tag.ToString)
                            diag.ShowDialog()
                        End Using
                    Else
                        'do not start potentially harmful files
                        If Not (lv.SelectedItems(0).Tag.ToString.ToLower.EndsWith(".exe") Or
                            lv.SelectedItems(0).Tag.ToString.ToLower.EndsWith(".msi")) Then
                            Try
                                Process.Start(lv.SelectedItems(0).Tag.ToString)
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                End If
                'End If
            End If
        End Sub

        Private Sub lv_SizeChanged(sender As Object, e As EventArgs) Handles lv.SizeChanged
            lv.Columns(0).Width = lv.Width \ 3
            lv.Columns(1).Width = CInt(lv.Width / 9 * 2)
            lv.Columns(2).Width = CInt(lv.Width / 9 * 2)
        End Sub

        Private Sub backSplit_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles backSplit.SplitterMoved
            If _firstMove Then
                If Me.ParentForm IsNot Nothing Then
                    If Me.ParentForm.Visible Then
                        _firstMove = False
                    End If
                End If
            Else
                My.Settings.globResViewSplitter = backSplit.SplitterDistance / backSplit.Height
                My.Settings.Save()
            End If
        End Sub

        Private Sub btnNewFolder_Click(sender As Object, e As EventArgs) Handles btnNewFolder.Click
            Dim dirName As String = "New Folder"
            If Directory.Exists(_path & "\New Folder") Then
                Dim endInt As Integer = 1
                While Directory.Exists(_path & "\New Folder " & endInt)
                    endInt += 1
                End While
                Directory.CreateDirectory(_path & "\New Folder " & endInt)
                dirName = "New Folder " & endInt
            Else
                Directory.CreateDirectory(_path & "\New Folder")
            End If
            LoadLv(_path)
            lv.Focus()
            For Each li As ListViewItem In lv.Items
                If li.Text = dirName Then
                    li.Selected = True
                    lv.EnsureVisible(li.Index)
                    li.BeginEdit()
                    Exit For
                Else
                    li.Selected = False
                End If
            Next
        End Sub

        Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
            lv.Focus()
            If lv.SelectedItems.Count = 1 Then
                lv.SelectedItems(0).BeginEdit()
            End If
        End Sub

        Private Sub lv_BeforeLabelEdit(sender As Object, e As LabelEditEventArgs) Handles lv.BeforeLabelEdit
            If lv.SelectedItems.Count = 1 Then
                _prevLabel = lv.SelectedItems(0).Text
            End If
        End Sub

        Private Sub lv_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles lv.AfterLabelEdit
            Dim text As String = e.Label
            If e.Label Is Nothing Then
                text = _prevLabel
            ElseIf String.IsNullOrEmpty(e.Label.Trim) Then
                text = _prevLabel
            End If
            If lv.SelectedItems.Count = 1 Then
                If _prevLabel = text Then
                    e.CancelEdit = True
                Else
                    If lv.SelectedItems(0).SubItems(1).Text = "Folder" Then
                        If Directory.Exists(lv.SelectedItems(0).Tag.ToString.Replace(_prevLabel, text.Trim)) Then
                            MsgBox("This folder name is already taken. Your changes will be reverted.",
                                   MsgBoxStyle.Exclamation, "Name Taken")
                            e.CancelEdit = True
                        Else
                            Try
                                FileSystem.RenameDirectory(lv.SelectedItems(0).Tag.ToString, text.Trim)
                                lv.SelectedItems(0).Tag = lv.SelectedItems(0).Tag.ToString.Replace(_prevLabel, text.Trim)
                            Catch ex As Exception
                                MsgBox("This folder name is invalid! Your changes will be reverted.",
                                       MsgBoxStyle.Exclamation, "Name Invalid")
                                e.CancelEdit = True
                            End Try
                        End If
                    Else
                        If File.Exists(lv.SelectedItems(0).Tag.ToString.Replace(_prevLabel, text.Trim)) Then
                            MsgBox("This file name is already taken. Your changes will be reverted.",
                                   MsgBoxStyle.Exclamation, "Name Taken")
                            e.CancelEdit = True
                        Else
                            Try
                                FileSystem.RenameFile(lv.SelectedItems(0).Tag.ToString,
                                                      Path.GetFileName(lv.SelectedItems(0).Tag.ToString.Replace(_prevLabel,
                                                                                                                text.Trim)))
                                lv.SelectedItems(0).Tag = lv.SelectedItems(0).Tag.ToString.Replace(_prevLabel, text.Trim)
                            Catch ex As Exception
                                MsgBox("This file name is invalid! Your changes will be reverted.", MsgBoxStyle.Exclamation,
                                       "Name Invalid")
                                e.CancelEdit = True
                            End Try
                        End If
                    End If
                End If
            End If
        End Sub

        Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
            lv.Focus()
            'Dim s As String = "s "
            'If lv.SelectedItems.Count = 1 Then s = " "
            'Dim resNames As String = ""
            'For i As Integer = 0 To lv.SelectedItems.Count - 1
            '    If Not lv.SelectedItems(i).Text = "(Up One Directory)" Then
            '        resNames &= lv.SelectedItems(i).Text
            '        If i < lv.SelectedItems.Count - 1 Then
            '            resNames &= ", "
            '        End If
            '    End If
            'Next
            'If MsgBox("Delete the item" & s & "''" & resNames & "''?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation _
            '                                                           Or MsgBoxStyle.MsgBoxSetForeground, "Delete") =
            '   MsgBoxResult.Yes Then
            For Each i As ListViewItem In lv.SelectedItems
                If Not i.Text = "(Up One Directory)" Then
                    If i.SubItems(1).Text = "Folder" Then
                        Directory.Delete(i.Tag.ToString, True)
                    Else
                        File.Delete(i.Tag.ToString)
                    End If
                    i.Selected = False
                End If
            Next
            LoadLv(_path)
            'End If
        End Sub

        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            lv.Focus()
            Using diag As New OpenFileDialog
                With diag
                    .Multiselect = True
                    .Title = "Add Resources"
                    If .ShowDialog = DialogResult.OK AndAlso .FileNames.Length > 0 Then
                        For Each r As String In .FileNames
                            Try
                                File.Copy(r, _path & "\" & Path.GetFileName(r), True)
                            Catch ex As Exception

                            End Try
                        Next
                        LoadLv(_path)
                        For Each i As ListViewItem In lv.Items
                            For Each r As String In .FileNames
                                If i.Text = Path.GetFileNameWithoutExtension(r) Then
                                    i.EnsureVisible()
                                    i.Selected = True
                                    Exit For
                                End If
                            Next
                        Next
                    End If
                End With
            End Using
        End Sub

        Private Sub lv_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp, lv.KeyUp, backSplit.KeyUp
            If lv.Focused = True Then
                If e.KeyCode = Keys.Delete Then
                    btnDelete.PerformClick()
                ElseIf e.KeyCode = Keys.F2 Then
                    If lv.SelectedItems.Count = 1 Then
                        lv.SelectedItems(0).BeginEdit()
                    End If
                ElseIf e.KeyCode = Keys.F5 Then
                    LoadLv(_path)
                End If
            End If
            If e.Control Then
                If e.KeyCode = Keys.D Then
                    btnAdd.PerformClick()
                ElseIf e.KeyCode = Keys.A Then
                    For Each i As ListViewItem In lv.Items
                        i.Selected = True
                    Next
                    'ElseIf e.KeyCode = Keys.C Then
                    '    If lv.SelectedItems.Count = 1 Then

                    '    End If
                End If
            End If
            If e.Alt And e.KeyCode = Keys.Up Or e.KeyCode = Keys.Back Then
                If lv.Items(0).Text = "(Up One Directory)" Then
                    LoadLv(lv.Items(0).Tag.ToString)
                End If
            End If
        End Sub

        Private Sub btnNewFolder_EnabledChanged(sender As Object, e As EventArgs) _
            Handles btnRename.EnabledChanged, btnNewFolder.EnabledChanged, btnDelete.EnabledChanged, btnAdd.EnabledChanged
            Dim btn As Button = DirectCast(sender, Button)
            If btn.Enabled = False Then
                btn.BackColor = Color.fromArgb(100, 100, 100)
            Else
                btn.BackColor = Color.Gainsboro
            End If
        End Sub

        Private Sub btnYoutube_Click(sender As Object, e As EventArgs) Handles btnYoutube.Click
            If My.Computer.Network.IsAvailable Then
                Using diag As New DiagYoutube
                    With diag
                        If .ShowDialog() = DialogResult.OK Then
                            File.Copy(SpecialDirectories.Temp & "\" & .Result & ".mp3", _path & "\" & .Result & ".mp3")
                            File.Delete(SpecialDirectories.Temp & "\" & .Result & ".mp3")
                            LoadLv(_path)
                            For Each li As ListViewItem In lv.Items
                                If li.Text = .Result Then
                                    li.Selected = True
                                    lv.EnsureVisible(li.Index)
                                Else
                                    li.Selected = False
                                End If
                            Next
                        End If
                    End With
                End Using
            Else
                MsgBox("Please connect to internet to convert Youtube videos.",
                       MsgBoxStyle.Exclamation Or MsgBoxStyle.ApplicationModal _
                       Or MsgBoxStyle.MsgBoxSetForeground, "No Internet Connection")
            End If
        End Sub

        Private Sub svw2Resources_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
            lv.Focus()
        End Sub

        Private Sub lv_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles lv.ItemDrag
            If e.Item IsNot Nothing Then
                If Not e.Item.Text = "(Up One Directory)" Then
                    lv.DoDragDrop(New DataObject(DataFormats.FileDrop, DirectCast(e.Item, ListViewItem).Tag.ToString()), DragDropEffects.Move)
                End If
            End If
        End Sub

        Private Sub lv_DragOver(sender As Object, e As DragEventArgs) Handles lv.DragOver
            If e.Y < 270 Then
                Dim l As Point = lv.PointToClient(New Point(e.X, e.Y))
                Dim itm As ListViewItem = lv.GetItemAt(l.X, l.Y)
                If itm IsNot Nothing AndAlso itm.Index > 0 Then
                    lv.Items(itm.Index - 1).EnsureVisible()
                End If
            ElseIf e.Y > 435 Then
                Dim l As Point = lv.PointToClient(New Point(e.X, e.Y))
                Dim itm As ListViewItem = lv.GetItemAt(l.X, l.Y)
                If itm IsNot Nothing AndAlso itm.Index < lv.Items.Count - 1 Then
                    lv.Items(itm.Index + 1).EnsureVisible()
                End If
            End If

        End Sub
    End Class
End Namespace