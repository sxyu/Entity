Imports System.Drawing.Imaging
Imports System.IO
Imports Entity._1Dialogs.Popups
Imports Microsoft.VisualBasic.FileIO
Imports Entity._0App
Imports Entity._3Modules
Imports Entity._2Namespaces
Imports Entity._4Classes.Types
Imports Entity._2Namespaces.Projection

Namespace _1Dialogs.General.Selectors

    Public Class DiagSelectImage
        Inherits Form
        Public Selected As String = ""
        Public SelectedPath As String = ""
        Public Duration As Double = 1
        Public Delay As Double = 0
        Public Transition As Integer = 0
        Private _isMoving As Boolean = False
        Private _ppt As New Point

        Public Sub UpdateControls()
            'add code here. ran when screen changes
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
            cbEffect.Show()
            If IsPresMode Then
                cbEffect.SelectedIndex = CType(My.Settings.favouriteTransition, PjxEngine.Effect)
                tbDur.Text = CStr(My.Settings.favPjDur)
                tbDelay.Text = CStr(My.Settings.favPjDelay)
            End If
            cbEffect.SelectedIndex = CType(Transition, PjxEngine.Effect)
            tbDur.Text = CStr(Duration)
            tbDelay.Text = CStr(Delay)
            lbEffect.Left = cbEffect.Left - lbEffect.Width - 3
            If Not FileSystem.DirectoryExists(CurWorkDir.Path) Then
                FileSystem.CreateDirectory(CurWorkDir.Path)
            End If
            CreateProjFolders(CurProject.Path)
            LoadLv()
        End Sub
        Private Sub LoadLv()
            lv.Items.Clear()
            Dim di As New DirectoryInfo(CurProject.ResPath)
            Dim dia As FileInfo() = di.GetFiles
            Dim toAdd As New List(Of ListViewItem)
            'add blackout
            If ImageCache.Images.ContainsKey("_blackout") Then ImageCache.Images.RemoveByKey("_blackout")
            Dim bO As New ListViewItem("_blackout")
            bO.Tag = "_blackout"
            bO.ImageKey = "_blackout"

            bO.Name = "_blackout"
            toAdd.Add(bO)
            Using blackout As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                Using g As Graphics = Graphics.FromImage(blackout)
                    g.Clear(Color.Black)
                End Using
                ImageCache.Images.Add("_blackout", GetThumbnail(blackout))
            End Using
            'add resources
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
                If e.KeyCode = Keys.F5 Then
                    LoadLv()
                End If
            End If
            If e.Control Then
                If e.KeyCode = Keys.A Then
                    For Each i As ListViewItem In lv.Items
                        i.Selected = True
                    Next
                End If
            End If
        End Sub


        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            Dim selct As Integer = lv.SelectedItems.Count
            If selct = 1 Then
                Selected = lv.SelectedItems(0).Text
                SelectedPath = lv.SelectedItems(0).Tag.ToString
                btnOK.Enabled = True
            Else
                Selected = ""
                btnOK.Enabled = False
            End If
        End Sub
        Private Sub btn_EnableChanged(sender As Object, e As EventArgs) Handles btnOK.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(80, 80, 80)
            End If
        End Sub
        Private Sub btn_Focus(sender As Object, e As EventArgs) Handles btnOK.Enter, btnCancel.Enter, btnClose.Enter
            lv.Focus()
        End Sub

        Private isTrans As Boolean = False
        Private prevSel As Integer = -1
        'when the image transition effect ends
        Private Sub EffectEnd(sender As Object, e As EventArgs)
            RemoveHandler SEngine.EffectEnded, AddressOf EffectEnd
            If HasSecondMonitor Then
                _6Misc.SecondMonitor.pb.BackgroundImage = Nothing
                isTrans = False
            End If
        End Sub

        Private Sub lv_ItemActivate(sender As Object, e As EventArgs) Handles lv.ItemActivate
            If IsPresMode Then
                btnOK.PerformClick()
            Else
                Dim name As String = lv.SelectedItems(0).Tag.ToString
                Dim procBmp As Bitmap
                If name = "_blackout" Then
                    Dim blackout As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                    Using g As Graphics = Graphics.FromImage(blackout)
                        g.Clear(Color.Black)
                    End Using
                    procBmp = blackout
                Else
                    Using fs As New FileStream(name, FileMode.OpenOrCreate, FileAccess.Read)
                        procBmp = New Bitmap(fs)
                    End Using
                End If
                If HasSecondMonitor Then
                    If Not lv.SelectedIndices(0) = prevSel Then
                        If Not isTrans Then
                            With _6Misc.SecondMonitor
                                Dim tbmp As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                                If .pb.Image IsNot Nothing Then
                                    Try
                                        .pb.BackgroundImage = New Bitmap(.pb.Image)
                                    Catch
                                    End Try
                                End If
                                Using g As Graphics = Graphics.FromImage(tbmp)
                                    g.Clear(Color.Black)
                                    g.DrawImage(procBmp, 0, 0, My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                                    .pb.SizeMode = PictureBoxSizeMode.CenterImage
                                    .pb.BackgroundImageLayout = ImageLayout.None
                                    'procbmp.Dispose()
                                    SEngine = New PjxEngine(tbmp, .pb, "Image", CInt(CDbl(tbDur.Text) * 1000))
                                    SEngine.ColorTrans = Color.Transparent
                                    SEngine.EffectName = CType(cbEffect.SelectedIndex, PjxEngine.Effect)
                                    'SEngine.Start()
                                    AddHandler SEngine.EffectEnded, AddressOf EffectEnd
                                    If name <> "_blackout" Or .pb.BackgroundImage IsNot Nothing Then
                                        isTrans = True
                                    End If
                                    prevSel = lv.SelectedIndices(0)
                                End Using
                            End With
                        End If
                    End If
                Else
                    Using diag As New DiagImageView
                        With diag
                            .TopMost = True
                            .Text = lv.SelectedItems(0).Text & " - Entity Image Viewer"
                            .Width = (My.Computer.Screen.WorkingArea.Width \ 3) * 2
                            .Height = (My.Computer.Screen.WorkingArea.Height \ 3) * 2
                            'procbmp.Dispose()
                            .StartPosition = FormStartPosition.CenterScreen
                            'try to display the preview image
                            .pb.Image = GetThumbnail(procBmp, .pb.Width, .pb.Height)
                            .ShowDialog()
                        End With
                    End Using
                End If
                procBmp.Dispose()
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
            Transition = CType(cbEffect.SelectedIndex, PjxEngine.Effect)
            If IsPresMode Then
                My.Settings.favouriteTransition = cbEffect.SelectedIndex
                My.Settings.Save()
            End If
        End Sub

        Private Sub DiagSelectImage_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub

        Private Sub btnCancClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click, btnCancel.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
            If Not String.IsNullOrEmpty(Selected) Then
                If IsPresMode Then
                    Dim pCue As New PjxCue("e_change", Me.Selected, CType(cbEffect.SelectedIndex, PjxEngine.Effect), _
                                                             Me.Duration, Me.Delay)
                    pCue.ExecuteCue()
                    If pCue.NameOfRes = "_blackout" Then
                        Frm5ShowUi.pbPj.Image = Frm5ShowUi.BlackOutSm
                    Else
                        Frm5ShowUi.pbPj.Image = GetThumbnail(ImgResToPath(pCue.NameOfRes), _
                                                             Frm5ShowUi.pbPj.Width, Frm5ShowUi.pbPj.Height, Frm5ShowUi.pbPj.BackColor)
                    End If
                End If
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End Sub

        Private Sub DiagSelectImage_MouseDown(sender As Object, e As MouseEventArgs) Handles title.MouseDown, MyBase.MouseDown, lbEffect.MouseDown
            _isMoving = True
            _ppt = e.Location
        End Sub

        Private Sub DiagSelectImage_MouseMove(sender As Object, e As MouseEventArgs) Handles title.MouseMove, MyBase.MouseMove, lbEffect.MouseMove
            If _isMoving Then
                Me.Location = New Point(Me.Left + e.X - _ppt.X, Me.Top + e.Y - _ppt.Y)
            End If
        End Sub

        Private Sub DiagSelectImage_MouseUp(sender As Object, e As MouseEventArgs) Handles title.MouseUp, MyBase.MouseUp, lbEffect.MouseUp
            _isMoving = False
        End Sub
        Private Sub tb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbDelay.KeyPress, tbDur.KeyPress
            Select Case e.KeyChar
                Case "0"c To "9"c
                    'allow the char
                Case "."c
                    If DirectCast(sender, TextBox).Text.Contains(".") Then e.Handled = True 'suppress the keypress if there is already a decimal point
                Case Convert.ToChar(Keys.Back)
                    'allow
                Case Else
                    e.Handled = True
            End Select
        End Sub
        Private Sub tbDur_TextChanged(sender As Object, e As EventArgs) Handles tbDur.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbDur.Text.Trim) Then
                    tbDur.Text = tbDur.Text.Trim
                    Dim fadeTime As Double = CDbl(tbDur.Text) 'see if converting works
                    If fadeTime > 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        Me.Duration = CDbl(tbDur.Text)
                        If IsPresMode Then
                            My.Settings.favPjDur = Me.Duration
                            My.Settings.Save()
                        End If
                    End If
                End If
            Catch ex As Exception
                tbDur.Text = "1.0"
                'if something fails resets text
            End Try
        End Sub
        Private Sub tbDelay_TextChanged(sender As Object, e As EventArgs) Handles tbDelay.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbDelay.Text.Trim) Then
                    tbDelay.Text = tbDelay.Text.Trim
                    Dim fadeTime As Double = CDbl(tbDelay.Text) 'see if converting works
                    If fadeTime >= 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        Me.Delay = CDbl(tbDelay.Text)
                        If IsPresMode Then
                            My.Settings.favPjDelay = Me.Delay
                            My.Settings.Save()
                        End If
                    End If
                End If
            Catch ex As Exception
                tbDelay.Text = "0.0"
                'if something fails resets text
            End Try
        End Sub
        Private Sub tb_Leave(sender As Object, e As EventArgs) Handles tbDelay.Leave, tbDur.Leave
            Dim tb As TextBox = DirectCast(sender, TextBox)
            If tb.Text.EndsWith(".") Then tb.Text = tb.Text.Remove(tb.Text.Length - 1)
            Dim fadeTime As Double = CDbl(tb.Text) 'see if converting works
            If fadeTime > 15 Then 'unreasonably long fade time
                tb.Text = "15.0"
                Exit Sub 'set the fadetime back to 15
            End If
            If String.IsNullOrEmpty(tb.Text.Trim) OrElse CDbl(tb.Text.Trim) < 0 Then
                tb.Text = "0.0"
                tb.SelectionLength = 0
                tb.SelectionStart = tb.Text.Length
            End If
        End Sub

        Private Sub DiagSelectImage_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            If IsPresMode Then
                e.Cancel = True
                Me.Hide()
            End If
        End Sub

    End Class
End Namespace