Imports Entity._0App.Views
Imports Entity._1Dialogs.General.Selectors
Imports Entity._3Modules
Imports Entity._1Dialogs.General.ImageGen
Imports Entity._4Classes.Types

Namespace _1Dialogs.General.Add

    Public Class DiagAddResImg
        Public CRec As RectangleX
        Public CropRec As Rectangle
        Public ImageBounds As Rectangle
        Public Result As String
        Public Resname As String
        Public Colormode As Integer
        Private _dragReg As DragArea
        Private _dragPpt As New Point
        Private _realPathHidden As Boolean
        Private _hiddenFilePath As String

        Public Property Editmode As Boolean
        Public OrigFileName As String = ""
        Dim _changed As Boolean = False
        Dim _curImage As Bitmap
        Dim _curNormimage As Bitmap
        Private Enum DragArea
            None = 0
            TopLeft = 1
            TopRight = 2
            BottomLeft = 3
            BottomRight = 4
            All = 5
        End Enum
        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, btnClose.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub tbPath_KeyDown(sender As Object, e As KeyEventArgs) Handles tbPath.KeyDown
            e.SuppressKeyPress = True
        End Sub

        Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
            Using diag As New OpenFileDialog
                With diag
                    .RestoreDirectory = True
                    .Title = "Select Image"
                    .Filter = ImageFilter
                    .Multiselect = False
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        _changed = True
                        tbPath.Text = .FileName
                        tbResName.Text = IO.Path.GetFileNameWithoutExtension(.FileName)
                    End If
                End With
            End Using
        End Sub

        Private Sub tbResName_TextChanged(sender As Object, e As EventArgs) Handles tbResName.TextChanged
            If String.IsNullOrEmpty(tbResName.Text.Trim) Then
                btnAdd.Enabled = False
                lbWarning.Text = "Name Cannot be Empty!"
                lbWarning.Show()
            ElseIf tbResName.Text.Contains("/") Or tbResName.Text.Contains("\") Or tbResName.Text.Contains(".") Or tbResName.Text.Contains(":") _
                   Or tbResName.Text.Contains("?") Or tbResName.Text.Contains("*") Or tbResName.Text.Contains("''") Or tbResName.Text.Contains("|") _
                   Or tbResName.Text.Contains("<") Or tbResName.Text.Contains(">") Or tbResName.Text.Contains(",") Or tbResName.Text.Contains(";") _
                   Or tbResName.Text.Contains(ControlChars.NewLine) Then
                btnAdd.Enabled = False
                lbWarning.Text = "Name Must Not Contain: / \ , . : ; ? * < >"
                lbWarning.Show()
            ElseIf tbResName.Text.EndsWith(" Crop") Then
                btnAdd.Enabled = False
                lbWarning.Text = "Name Must End With ' Crop'"
                lbWarning.Show()
            ElseIf tbResName.Text = ("_blackout") Then
                btnAdd.Enabled = False
                lbWarning.Text = "Name Cannot Be ''_blackout''"
                lbWarning.Show()
            Else
                If tbPath.Text <> "" Then
                    If FileIO.FileSystem.FileExists(CurProject.ResPath & "\" & tbResName.Text & ".jpg") Or _
                       FileIO.FileSystem.FileExists(CurProject.ResPath & "\" & tbResName.Text & ".png") Or FileIO.FileSystem.FileExists(CurProject.ResPath & "\" & tbResName.Text & ".gif") Then
                        If tbResName.Text = OrigFileName And OrigFileName <> "" Then
                            btnAdd.Enabled = True
                            lbWarning.Hide()
                        Else
                            btnAdd.Enabled = False
                            lbWarning.Text = "Resource With Same Name Exists!"
                            lbWarning.Show()
                        End If
                    Else
                        btnAdd.Enabled = True
                        _changed = True
                        lbWarning.Hide()
                    End If
                End If
            End If
        End Sub

        Private Sub tbPath_TextChanged(sender As Object, e As EventArgs) Handles tbPath.TextChanged
            If Editmode Then Exit Sub
            Dim path As String
            If _realPathHidden Then
                path = _hiddenFilePath
            Else
                path = tbPath.Text
            End If
            If FileIO.FileSystem.FileExists(path) And path <> "" Then
                If lbWarning.Visible = False And tbResName.Text <> "" Then
                    btnAdd.Enabled = True
                End If
                Using tmp As Bitmap = New Bitmap(path)
                    Dim ratioW As Double = pbPrev.Width / tmp.Width
                    Dim ratioH As Double = pbPrev.Height / tmp.Height
                    Dim min As Double = Math.Min(ratioW, ratioH)
                    _curNormimage = New Bitmap(tmp, CInt(tmp.Width * min), CInt(tmp.Height * min))
                    If cbEffect.SelectedIndex = 0 Then
                        _curImage = New Bitmap(_curNormimage)
                    ElseIf cbEffect.SelectedIndex = 8 Then
                        _curImage = New Bitmap(path)
                    Else
                        _curImage = New Bitmap(RecolorImage(_curNormimage, CType(cbEffect.SelectedIndex, ImageColorMode)))
                    End If
                    pbPrev.Image = _curImage
                    ImageBounds = New Rectangle(CInt((pbPrev.Width - _curImage.Width) / 2), CInt((pbPrev.Height - _curImage.Height) / 2), _
                                                pbPrev.Image.Width, pbPrev.Image.Height)
                    If ImageBounds.Left < 0 Then ImageBounds.X = 0
                    If ImageBounds.Top < 1 Then ImageBounds.Y = 1
                    If ImageBounds.Width > pbPrev.Width - 1 Then ImageBounds.Width = pbPrev.Width - 1
                    If ImageBounds.Height > pbPrev.Height - 2 Then ImageBounds.Height = pbPrev.Height - 2
                    setDefaultCRec()
                End Using
            Else
                btnAdd.Enabled = False
            End If
        End Sub

        Dim moving As Boolean = False
        Dim ppt As New Point
        Private Sub frmAddResImg_MouseDown(sender As Object, e As MouseEventArgs) Handles _
                                                                                      MyBase.MouseDown, lbWarning.MouseDown, lbResName.MouseDown, lbSource.MouseDown, title.MouseDown, tbPath.MouseDown, lbResMode.MouseDown
            moving = True
            ppt = e.Location
        End Sub
        Private Sub frmAddResImg_MouseMove(sender As Object, e As MouseEventArgs) Handles _
                                                                                      MyBase.MouseMove, lbWarning.MouseMove, lbResName.MouseMove, lbSource.MouseMove, title.MouseMove, tbPath.MouseMove, lbResMode.MouseMove
            If moving Then
                Me.Location = New Point(Me.Left + e.X - ppt.X, Me.Top + e.Y - ppt.Y)
            End If
        End Sub
        Private Sub frmAddResImg_MouseUp(sender As Object, e As MouseEventArgs) Handles _
                                                                                    MyBase.MouseUp, lbWarning.MouseUp, lbResName.MouseUp, lbSource.MouseUp, title.MouseUp, tbPath.MouseUp, lbResMode.MouseUp
            moving = False
            _dragReg = 0
            pbPrev.Refresh()
        End Sub
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            If Editmode Then
                Result = CurProject.ResBackPath & "\" & OrigFileName & ImgResToFileExt(OrigFileName)
            Else
                If _realPathHidden Then
                    Result = _hiddenFilePath
                Else
                    Result = tbPath.Text
                End If
            End If
            If _changed Then
                _1Dialogs.Loading.FrmProcessing.Show()
                _1Dialogs.Loading.FrmProcessing.Refresh()
            End If
            CropRec = CRec.GetSubtractedRect(ImageBounds) _
                .GetMultipliedRect(New Size(CInt(ImageBounds.Width / ImageBounds.Height * My.Settings.secondaryScrRez.Height * 2), _
                                            My.Settings.secondaryScrRez.Height * 2), ImageBounds).ToRectangle
            Resname = tbResName.Text
            Colormode = cbEffect.SelectedIndex
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub tbPath_Enter(sender As Object, e As EventArgs) Handles tbPath.Enter
            btnBrowse.Focus()
        End Sub


        Private Sub frmAddResImg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If Editmode Then
                btnImgLib.Hide()
                title.Text = "Edit Image Resource"
                tbPath.Text = "(Local Resource File)"
                btnBrowse.Enabled = False
                btnAdd.Text = "&Save"
                OrigFileName = TryCast(ViewCache(3), vw3Images).lv.SelectedItems(0).Text
                tbResName.Text = OrigFileName
                Try
                    Using bmp As Bitmap = New Bitmap(CurProject.ResBackPath & "\" & OrigFileName & ImgResToFileExt(OrigFileName))
                        Dim ratioW As Double = pbPrev.Width / bmp.Width
                        Dim ratioH As Double = pbPrev.Height / bmp.Height
                        Dim min As Double = Math.Min(ratioW, ratioH)
                        pbPrev.Image = New Bitmap(bmp, CInt(bmp.Width * min), CInt(bmp.Height * min))
                        ImageBounds = New Rectangle(CInt((pbPrev.Width - pbPrev.Image.Width) / 2), CInt((pbPrev.Height - pbPrev.Image.Height) / 2), _
                                                    pbPrev.Image.Width, pbPrev.Image.Height)
                        If ImageBounds.Left < 0 Then ImageBounds.X = 0
                        If ImageBounds.Top < 0 Then ImageBounds.Y = 0
                        If ImageBounds.Width > pbPrev.Width Then ImageBounds.Width = pbPrev.Width
                        If ImageBounds.Height > pbPrev.Height Then ImageBounds.Height = pbPrev.Height
                        Colormode = 9
                    End Using
                Catch ex As Exception
                    Colormode = 9
                End Try
                Try
                    cbEffect.SelectedIndex = CInt(CurProject.Settings.GetSetting("Images", OrigFileName))
                Catch ex As Exception
                End Try
                Try
                    Dim gs As String = CurProject.Settings.GetSetting("Images", OrigFileName & " Crop")
                    If CDbl(gs) = 0 Then
                        setDefaultCRec()
                    Else
                        CRec = New RectangleX(StrToRect(gs))
                    End If
                Catch ex As Exception
                    setDefaultCRec()
                End Try
            Else
                btnImgLib.Show()
                btnPaint.Show()
                cbEffect.SelectedIndex = 0
                'setDefaultCRec()
            End If
        End Sub
        Private Sub SetDefaultCRec()
            If ImageBounds.Width / ImageBounds.Height > My.Settings.secondaryScrWH Then
                CRec = New RectangleX(ImageBounds.X + 2, ImageBounds.Y + 2, CInt(My.Settings.secondaryScrWH * (ImageBounds.Height - 4)), ImageBounds.Height - 4)
            Else
                CRec = New RectangleX(ImageBounds.X + 2, ImageBounds.Y + 2, ImageBounds.Width - 4, CInt((ImageBounds.Width - 4) / My.Settings.secondaryScrWH))
            End If
        End Sub
        Private Sub btnCreate_EnableChanged(sender As Object, e As EventArgs) Handles btnAdd.EnabledChanged, btnCancel.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(100, 100, 100)
            End If
        End Sub

        Private Sub cbEffect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbEffect.SelectedIndexChanged

            Dim path As String
            If _realPathHidden Then
                path = _hiddenFilePath
            Else
                path = tbPath.Text
            End If
            If String.IsNullOrEmpty(path) = False And FileIO.FileSystem.FileExists(path) And Colormode <> cbEffect.SelectedIndex Then
                _changed = True
                Colormode = cbEffect.SelectedIndex
                Using fs As New IO.FileStream(path, IO.FileMode.Open)
                    Using tmp As Bitmap = New Bitmap(fs)
                        _changed = True
                        Dim ratioW As Double = pbPrev.Width / tmp.Width
                        Dim ratioH As Double = pbPrev.Height / tmp.Height
                        Dim min As Double = Math.Min(ratioW, ratioH)
                        _curNormimage = New Bitmap(tmp, CInt(tmp.Width * min), CInt(tmp.Height * min))
                        If cbEffect.SelectedIndex = 0 Then
                            _curImage = New Bitmap(_curNormimage)
                        ElseIf cbEffect.SelectedIndex = 8 Then
                            _curImage = New Bitmap(CurProject.ResBackPath & "\" & OrigFileName & ImgResToFileExt(OrigFileName))
                        Else
                            _curImage = New Bitmap(RecolorImage(_curNormimage, CType(cbEffect.SelectedIndex, ImageColorMode)))
                        End If
                        pbPrev.Image = _curImage
                    End Using
                End Using
            ElseIf Editmode And Colormode <> cbEffect.SelectedIndex Then
                _changed = True
                Colormode = cbEffect.SelectedIndex
                Using fs As New IO.FileStream(CurProject.ResBackPath & "\" & OrigFileName & ImgResToFileExt(OrigFileName), _
                                              IO.FileMode.OpenOrCreate, IO.FileAccess.ReadWrite)
                    Using tmp As Bitmap = New Bitmap(fs)
                        Dim ratioW As Double = pbPrev.Width / tmp.Width
                        Dim ratioH As Double = pbPrev.Height / tmp.Height
                        Dim max As Double = Math.Max(ratioW, ratioH)
                        _curNormimage = New Bitmap(tmp, CInt(tmp.Width * max), CInt(tmp.Height * max))
                        If cbEffect.SelectedIndex = 0 Then
                            _curImage = New Bitmap(fs)
                        ElseIf cbEffect.SelectedIndex = 8 Then
                            _curImage = New Bitmap(CurProject.ResBackPath & "\" & OrigFileName & ImgResToFileExt(OrigFileName))
                        Else
                            _curImage = New Bitmap(RecolorImage(_curNormimage, CType(cbEffect.SelectedIndex, ImageColorMode)))
                        End If
                        pbPrev.Image = _curImage
                        fs.Flush()
                    End Using
                End Using
            End If
        End Sub

        Private Sub pbPrev_MouseMove(sender As Object, e As MouseEventArgs) Handles pbPrev.MouseMove
            If _dragReg <> DragArea.none Then
                Select Case _dragReg
                    Case DragArea.topLeft
                        CRec.MoveCorner(RectangleX.Corner.topLeft, e.X - _dragPpt.X, WtoH(e.X - _dragPpt.X))
                    Case DragArea.topRight
                        CRec.MoveCorner(RectangleX.Corner.topRight, e.X - _dragPpt.X, WtoH(e.X - _dragPpt.X))
                    Case DragArea.bottomLeft
                        CRec.MoveCorner(RectangleX.Corner.bottomLeft, e.X - _dragPpt.X, WtoH(e.X - _dragPpt.X))
                    Case DragArea.bottomRight
                        CRec.MoveCorner(RectangleX.Corner.bottomRight, e.X - _dragPpt.X, WtoH(e.X - _dragPpt.X))
                    Case DragArea.all
                        CRec.Move(e.X - _dragPpt.X, e.Y - _dragPpt.Y)
                End Select
                _dragPpt = e.Location
                CRec.EnsureWHRatio(My.Settings.secondaryScrWH, _
                                   New Rectangle(ImageBounds.X + 2, ImageBounds.Y + 2, ImageBounds.Width - 4, ImageBounds.Height - 4))
                CRec.EnsureLarger(40, 40)
                pbPrev.Refresh()
            Else
                frmAddResImg_MouseMove(pbPrev, New MouseEventArgs(Windows.Forms.MouseButtons.Left, e.Clicks, e.X, e.Y, e.Delta))
            End If
        End Sub

        Private Sub pbPrev_Paint(sender As Object, e As PaintEventArgs) Handles pbPrev.Paint
            If Not CRec Is Nothing Then
                Using whitePen As New Pen(Color.White)
                    Using blackPen As New Pen(Color.Black)
                        Using transBr As New SolidBrush(Color.FromArgb(100, Color.White))
                            Using opaqueBr As New SolidBrush(Color.FromArgb(170, pbPrev.BackColor))
                                Using veryTransBr As New SolidBrush(Color.FromArgb(50, Color.AliceBlue))
                                    e.Graphics.DrawRectangle(whitePen, CRec.ToRectangle)
                                    e.Graphics.DrawRectangle(blackPen, CRec.ToRectangle(1))
                                    e.Graphics.DrawRectangle(blackPen, CRec.ToRectangle(-1))
                                    Dim cornerSize As New Size(20, 20)
                                    e.Graphics.DrawRectangle(whitePen, CRec.GetCornerRectangle(RectangleX.Corner.topLeft, 20))
                                    e.Graphics.DrawRectangle(whitePen, CRec.GetCornerRectangle(RectangleX.Corner.topRight, 20))
                                    e.Graphics.DrawRectangle(whitePen, CRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, 20))
                                    e.Graphics.DrawRectangle(whitePen, CRec.GetCornerRectangle(RectangleX.Corner.bottomRight, 20))

                                    e.Graphics.DrawRectangle(blackPen, CRec.GetCornerRectangle(RectangleX.Corner.topLeft, 20, 1))
                                    e.Graphics.DrawRectangle(blackPen, CRec.GetCornerRectangle(RectangleX.Corner.topRight, 20, 1))
                                    e.Graphics.DrawRectangle(blackPen, CRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, 20, 1))
                                    e.Graphics.DrawRectangle(blackPen, CRec.GetCornerRectangle(RectangleX.Corner.bottomRight, 20, 1))

                                    e.Graphics.DrawRectangle(blackPen, CRec.GetCornerRectangle(RectangleX.Corner.topLeft, 20, -1))
                                    e.Graphics.DrawRectangle(blackPen, CRec.GetCornerRectangle(RectangleX.Corner.topRight, 20, -1))
                                    e.Graphics.DrawRectangle(blackPen, CRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, 20, -1))
                                    e.Graphics.DrawRectangle(blackPen, CRec.GetCornerRectangle(RectangleX.Corner.bottomRight, 20, -1))
                                    'If dragReg = DragArea.none Then
                                    e.Graphics.FillRectangle(opaqueBr, 0, 0, CRec.Left, e.ClipRectangle.Height)
                                    e.Graphics.FillRectangle(opaqueBr, CRec.Left, 0, CRec.Width + 1, CRec.Top)
                                    e.Graphics.FillRectangle(opaqueBr, CRec.Left, CRec.Bottom + 1, CRec.Width + 1, e.ClipRectangle.Height - CRec.Bottom - 1)
                                    e.Graphics.FillRectangle(opaqueBr, CRec.Right + 1, 0, e.ClipRectangle.Width - CRec.Right - 1, e.ClipRectangle.Height)
                                    'End If
                                    Select Case _dragReg
                                        Case DragArea.topLeft
                                            e.Graphics.FillRectangle(transBr, CRec.GetCornerRectangle(RectangleX.Corner.topLeft, 20))
                                        Case DragArea.topRight
                                            e.Graphics.FillRectangle(transBr, CRec.GetCornerRectangle(RectangleX.Corner.topRight, 20))
                                        Case DragArea.bottomLeft
                                            e.Graphics.FillRectangle(transBr, CRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, 20))
                                        Case DragArea.bottomRight
                                            e.Graphics.FillRectangle(transBr, CRec.GetCornerRectangle(RectangleX.Corner.bottomRight, 20))
                                        Case DragArea.all
                                            e.Graphics.FillRectangle(veryTransBr, CRec.ToRectangle)
                                    End Select
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End If
        End Sub

        Private Sub pbPrev_MouseUp(sender As Object, e As MouseEventArgs) Handles pbPrev.MouseUp
            _dragReg = 0
            pbPrev.Refresh()
            frmAddResImg_MouseUp(pbPrev, New MouseEventArgs(Windows.Forms.MouseButtons.Left, e.Clicks, e.X, e.Y, e.Delta))
        End Sub

        Private Sub pbPrev_MouseDown(sender As Object, e As MouseEventArgs) Handles pbPrev.MouseDown
            If CRec Is Nothing Then
                frmAddResImg_MouseDown(pbPrev, New MouseEventArgs(Windows.Forms.MouseButtons.Left, e.Clicks, e.X, e.Y, e.Delta))
            Else
                If isInRect(e.Location, CRec.GetCornerRectangle(RectangleX.Corner.topLeft, 20)) Then
                    _dragReg = DragArea.topLeft
                ElseIf isInRect(e.Location, CRec.GetCornerRectangle(RectangleX.Corner.topRight, 20)) Then
                    _dragReg = DragArea.topRight
                ElseIf isInRect(e.Location, CRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, 20)) Then
                    _dragReg = DragArea.bottomLeft
                ElseIf isInRect(e.Location, CRec.GetCornerRectangle(RectangleX.Corner.bottomRight, 20)) Then
                    _dragReg = DragArea.bottomRight
                ElseIf isInRect(e.Location, CRec.ToRectangle) Then
                    _dragReg = DragArea.all
                Else
                    frmAddResImg_MouseDown(pbPrev, New MouseEventArgs(Windows.Forms.MouseButtons.Left, e.Clicks, e.X, e.Y, e.Delta))
                End If
                _dragPpt = e.Location
                pbPrev.Refresh()
            End If
        End Sub
        Private Function isInRect(pt As Point, rect As Rectangle) As Boolean
            If pt.X > rect.X And pt.Y > rect.Y And pt.X < rect.Right And pt.Y < rect.Bottom Then Return True Else Return False
        End Function

        Private Sub AnyCtrl_MUp(sender As Object, e As MouseEventArgs) Handles tbResName.MouseUp, tbPath.MouseUp, cbEffect.MouseUp, btnClose.MouseUp, btnCancel.MouseUp, btnBrowse.MouseUp, btnAdd.MouseUp
            _dragReg = 0
            pbPrev.Refresh()
        End Sub

        Public Function HtoW(height As Integer) As Integer
            Return CInt(height * My.Settings.secondaryScrWH)
        End Function
        Public Function WtoH(width As Integer) As Integer
            Return CInt(width / My.Settings.secondaryScrWH)
        End Function

        Private Sub btnImgLib_Click(sender As Object, e As EventArgs) Handles btnImgLib.Click
            Using diag As New diagGlobalRes
                With diag
                    .viewImageRes = True
                    If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                        _realPathHidden = True
                        tbPath.Text = "(Global Resource)"
                        tbPath.Enabled = False
                        btnBrowse.Enabled = False
                        _hiddenFilePath = .result
                        tbResName.Text = IO.Path.GetFileNameWithoutExtension(.result).Replace("_", " ").Replace(",", " ").Replace(".", " ")
                        btnImgLib.Hide()
                        btnPaint.Hide()
                        _changed = True

                        If FileIO.FileSystem.FileExists(_hiddenFilePath) And _hiddenFilePath <> "" Then
                            If lbWarning.Visible = False And tbResName.Text <> "" Then
                                btnAdd.Enabled = True
                            End If
                            Using tmp As Bitmap = New Bitmap(_hiddenFilePath)
                                Dim ratioW As Double = pbPrev.Width / tmp.Width
                                Dim ratioH As Double = pbPrev.Height / tmp.Height
                                Dim min As Double = Math.Min(ratioW, ratioH)
                                _curNormimage = New Bitmap(tmp, CInt(tmp.Width * min), CInt(tmp.Height * min))
                                If cbEffect.SelectedIndex = 0 Then
                                    _curImage = New Bitmap(_curNormimage)
                                ElseIf cbEffect.SelectedIndex = 8 Then
                                    _curImage = New Bitmap(_hiddenFilePath)
                                Else
                                    _curImage = New Bitmap(RecolorImage(_curNormimage, CType(cbEffect.SelectedIndex, ImageColorMode)))
                                End If
                                pbPrev.Image = _curImage
                                ImageBounds = New Rectangle(CInt((pbPrev.Width - _curImage.Width) / 2), CInt((pbPrev.Height - _curImage.Height) / 2), _
                                                            pbPrev.Image.Width, pbPrev.Image.Height)
                                If ImageBounds.Left < 0 Then ImageBounds.X = 0
                                If ImageBounds.Top < 0 Then ImageBounds.Y = 0
                                If ImageBounds.Width > pbPrev.Width - 1 Then ImageBounds.Width = pbPrev.Width - 1
                                If ImageBounds.Height > pbPrev.Height - 2 Then ImageBounds.Height = pbPrev.Height - 2
                                setDefaultCRec()
                            End Using
                        Else
                            btnAdd.Enabled = False
                        End If
                    End If
                End With
            End Using
        End Sub

        Private Sub btnImgLib_MouseEnter(sender As Object, e As EventArgs) Handles btnImgLib.MouseEnter, btnPaint.MouseEnter
            DirectCast(sender, Button).FlatAppearance.BorderSize = 1
        End Sub
        Private Sub btnImgLib_MouseLeave(sender As Object, e As EventArgs) Handles btnImgLib.MouseLeave, btnPaint.MouseLeave
            DirectCast(sender, Button).FlatAppearance.BorderSize = 0
        End Sub


        Private Sub btnPaint_Click(sender As Object, e As EventArgs) Handles btnPaint.Click
            Using diag As New diagPaint
                If diag.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    _realPathHidden = True
                    _hiddenFilePath = FileIO.SpecialDirectories.Temp & "\imgGen.jpg"
                    tbPath.Text = "(Generated Image)"
                    tbPath.Enabled = False
                    btnBrowse.Enabled = False
                    btnImgLib.Hide()
                    btnPaint.Hide()
                End If
            End Using
        End Sub

        Private Sub diagAddResImg_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub
    End Class
End Namespace