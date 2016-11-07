Imports System.IO
Imports Entity._1Dialogs.Popups
Imports NAudio.Wave
Imports Entity._3Modules

Namespace _1Dialogs.General.Selectors

    Public Class DiagGlobalRes
        Public ViewImageRes As Boolean = False
        Public Result As String
        Dim _audioReader As AudioFileReader
        Dim _waveOut As IWavePlayer
        Dim _moving As Boolean = False
        Dim _ppt As New Point
        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub diagImageView_MouseDown(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseDown, lbTitle.MouseDown, breadcrumbs.MouseDown
            _moving = True
            _ppt = e.Location
        End Sub

        Private Sub diagImageView_MouseMove(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseMove, lbTitle.MouseMove, breadcrumbs.MouseMove
            If _moving Then
                Me.Location = New Point(Me.Left + e.X - _ppt.X, Me.Top + e.Y - _ppt.Y)
            End If
        End Sub

        Private Sub diagImageView_MouseUp(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseUp, lbTitle.MouseUp, breadcrumbs.MouseUp
            _moving = False
        End Sub

        Private Sub diagEntityResAud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            il.Images.Add(My.Resources.Folder)
            il.Images.Add(My.Resources.Headphones)
            il.Images.Add(My.Resources.photo)
            'make the width of the main column of the lv almost equal to the entire screen
            lv.Columns(0).Width = CInt(lv.Width * 0.9)
            If viewImageRes Then
                btnPlay.Text = "&Preview"
                lbTitle.Text = "Global Image Resources"
            End If
            'load the lv to the globals directory
            loadLV(GlobalPath)
        End Sub


        ''' <summary>
        '''     occurs when the waveout stops playing
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub playStopped(sender As Object, e As StoppedEventArgs)
            On Error Resume Next
            If viewImageRes Then
                btnPlay.Text = "&Preview"
            Else
                btnPlay.Text = "&Play"
            End If
            _audioReader.Close()
        End Sub


        ''' <summary>
        '''     make the listview load a directory
        ''' </summary>
        ''' <param name="path">the path of the directory</param>
        ''' <remarks></remarks>
        Private Sub loadLV(ByVal path As String)
            'make sure the listview is cleared, so items don't repeat
            lv.Items.Clear()
            breadcrumbs.Text = path.Replace(GlobalPath, "Global Resources").Replace("\", " > ")
            'create a list for items
            Dim toAdd As New List(Of ListViewItem)
            If Not path = GlobalPath Then
                'if not the current path is the root path, add an item to navigate 'up'
                Dim pdi As New ListViewItem("(Up One Directory)")
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
                    'set the item's tag to the full path of the dir
                    i.Tag = d.FullName
                    toAdd.Add(i)
                Next
                'get and add files
                For Each f As FileInfo In di.GetFiles
                    '...only if the file is a supported file
                    Dim formats As New List(Of String)
                    If viewImageRes Then
                        formats.Add(".jpg")
                        formats.Add(".jpeg")
                        formats.Add(".png")
                        formats.Add(".gif")
                        formats.Add(".tif")
                        formats.Add(".tiff")
                        formats.Add(".ico")
                        formats.Add(".bmp")
                    Else
                        formats.Add(".mp3")
                        formats.Add(".wav")
                    End If
                    Dim matchFormat As Boolean = False
                    For Each format As String In formats
                        If f.Name.ToLower.EndsWith(format) Then
                            matchFormat = True
                            Exit For
                        End If
                    Next
                    If matchFormat Then
                        'set the name of the item to the file name without extension
                        Dim i As New ListViewItem(IO.Path.GetFileNameWithoutExtension(f.FullName))
                        'set the image of the item to the headphone icon if audio, image icon if image
                        If viewImageRes Then
                            i.ImageIndex = 2
                        Else
                            i.ImageIndex = 1
                        End If
                        'set the item's tag to the full path of the file
                        i.Tag = f.FullName
                        toAdd.Add(i)
                    End If
                Next
            End If
            'items are collected then added because otherwise the listview can get really slow
            lv.Items.AddRange(toAdd.ToArray)
        End Sub


        ''' <summary>
        '''     search the directory
        ''' </summary>
        ''' <param name="keywords">what to search for</param>
        ''' <remarks></remarks>
        Private Sub searchLV(ByVal keywords As String)
            breadcrumbs.Text = "Search Results"
            keywords = keywords.ToLower
            If keywords.Trim = "" Then
                loadLV(GlobalPath)
                Exit Sub
            End If
            Dim di As New DirectoryInfo(GlobalPath)
            lv.Items.Clear()
            Dim toAdd As New List(Of ListViewItem)
            'loop through all files
            For Each f As FileInfo In di.GetFiles("*", SearchOption.AllDirectories)
                'only add if the file is a supported file
                Dim formats As New List(Of String)
                If viewImageRes Then
                    formats.Add(".jpg")
                    formats.Add(".jpeg")
                    formats.Add(".png")
                    formats.Add(".gif")
                    formats.Add(".tif")
                    formats.Add(".tiff")
                    formats.Add(".ico")
                    formats.Add(".bmp")
                Else
                    formats.Add(".mp3")
                    formats.Add(".wav")
                End If
                Dim matchFormat As Boolean = False
                For Each format As String In formats
                    If f.FullName.EndsWith(format) Then
                        matchFormat = True
                        Exit For
                    End If
                Next
                If matchFormat Then
                    Dim isMatch As Boolean = True
                    For Each s As String In keywords.Split(" "c)
                        If Not Path.GetFileNameWithoutExtension(f.Name).ToLower.Contains(s) Then
                            isMatch = False
                            Exit For
                        End If
                    Next
                    If isMatch Then
                        Dim i As New ListViewItem(Path.GetFileNameWithoutExtension(f.Name))
                        i.Tag = f.FullName
                        i.ImageIndex = 1
                        toAdd.Add(i)
                    End If
                End If
            Next
            lv.Items.AddRange(toAdd.ToArray)
        End Sub

        Private Sub lv_ItemActivate(sender As Object, e As EventArgs) Handles lv.ItemActivate
            If lv.SelectedItems.Count > 0 Then
                Dim formats As New List(Of String)
                If viewImageRes Then
                    formats.Add(".jpg")
                    formats.Add(".jpeg")
                    formats.Add(".png")
                    formats.Add(".gif")
                    formats.Add(".tif")
                    formats.Add(".tiff")
                    formats.Add(".ico")
                    formats.Add(".bmp")
                Else
                    formats.Add(".mp3")
                    formats.Add(".wav")
                End If
                Dim matchFormat As Boolean = False
                For Each format As String In formats
                    If lv.SelectedItems(0).Tag.ToString.EndsWith(format) Then
                        matchFormat = True
                        Exit For
                    End If
                Next

                'supported file
                If matchFormat Then
                    btnUse.PerformClick()
                Else 'directory
                    'naviget to the chosen directory
                    loadLV(lv.SelectedItems(0).Tag.ToString)
                End If
            End If
        End Sub

        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            If lv.SelectedItems.Count > 0 Then
                Dim formats As New List(Of String)
                If viewImageRes Then
                    formats.Add(".jpg")
                    formats.Add(".jpeg")
                    formats.Add(".png")
                    formats.Add(".gif")
                    formats.Add(".tif")
                    formats.Add(".tiff")
                    formats.Add(".ico")
                    formats.Add(".bmp")
                Else
                    formats.Add(".mp3")
                    formats.Add(".wav")
                End If
                Dim matchFormat As Boolean = False
                For Each format As String In formats
                    If lv.SelectedItems(0).Tag.ToString.EndsWith(format) Then
                        matchFormat = True
                        Exit For
                    End If
                Next
                'supported file
                If matchFormat Then
                    btnUse.Enabled = True
                    btnPlay.Show()
                    If viewImageRes Then
                        btnPlay.Text = "&Preview"
                    Else
                        btnPlay.Text = "&Play"
                    End If
                    Try
                        _audioReader.Close()
                    Catch ex As Exception
                    End Try
                Else
                    btnUse.Enabled = False
                    btnPlay.Hide()
                End If
            Else
                btnUse.Enabled = False
                btnPlay.Hide()
            End If
        End Sub


        Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
            lv.Focus()
            If btnPlay.Text = "&Play" Then
                Try
                    btnPlay.Text = "&Stop"
                    _audioReader = New AudioFileReader(lv.SelectedItems(0).Tag.ToString)
                    _waveOut = New WaveOut
                    _waveOut.Init(_audioReader)
                    AddHandler _waveOut.PlaybackStopped, AddressOf playStopped
                    _waveOut.Play()
                Catch ex As Exception
                    MsgBox("Oops, Entity can't play this file. It's probably corrupted.")
                    Try
                        _waveOut.Stop()
                        _audioReader.Close()
                    Catch
                    End Try
                    btnPlay.Text = "&Play"
                    btnUse.Enabled = False
                End Try
            ElseIf btnPlay.Text = "&Stop" Then
                btnPlay.Text = "&Play"
                _waveOut.Stop()
                _audioReader.Close()
            Else
                Using diag As New DiagImageView
                    With diag
                        Dim tbmp As Bitmap
                        Using fs As New FileStream(lv.SelectedItems(0).Tag.ToString, FileMode.Open, FileAccess.Read)
                            Using procbmp As New Bitmap(fs)
                                .TopMost = True
                                .Text = lv.SelectedItems(0).Text & " - Entity Image Viewer"
                                .Width = (My.Computer.Screen.WorkingArea.Width \ 3) * 2
                                .Height = (My.Computer.Screen.WorkingArea.Height \ 3) * 2
                                If procbmp.Width / procbmp.Height > .pb.Width / .pb.Height Then
                                    tbmp = New Bitmap(procbmp, .pb.Width, CInt(.pb.Width * (procbmp.Height / procbmp.Width)))
                                Else
                                    tbmp = New Bitmap(procbmp, CInt(.pb.Height * (procbmp.Width / procbmp.Height)), .pb.Height)
                                End If
                                'procbmp.Dispose()
                                .StartPosition = FormStartPosition.CenterScreen
                                'try to display the preview image
                                .pb.Image = tbmp
                            End Using
                        End Using
                        .ShowDialog()
                        tbmp.Dispose()
                    End With
                End Using
            End If
        End Sub

        Private Sub tbSearch_TextChanged(sender As Object, e As EventArgs) Handles tbSearch.TextChanged
            searchLV(tbSearch.Text)
        End Sub

        Private Sub btnUse_Click(sender As Object, e As EventArgs) Handles btnUse.Click
            result = lv.SelectedItems(0).Tag.ToString
            Try
                If viewImageRes Then
                    Using fs As New FileStream(lv.SelectedItems(0).Tag.ToString, FileMode.Open)
                        Using b As New Bitmap(fs)
                            'do nothing, testing
                            'if there is an error then we know the file is corrupted/bad
                            'such files are ignored
                        End Using
                    End Using
                Else
                    _audioReader = New AudioFileReader(lv.SelectedItems(0).Tag.ToString)
                    _waveOut = New WaveOut
                    _waveOut.Init(_audioReader)
                    _waveOut.Play()
                    _waveOut.Stop()
                    _audioReader.Close()
                End If
            Catch ex As Exception
                MsgBox("This file can't be used.", MsgBoxStyle.Exclamation, "File Invalid")
                Exit Sub
            End Try
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

        Private Sub diagGlobalRes_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub
    End Class
End Namespace