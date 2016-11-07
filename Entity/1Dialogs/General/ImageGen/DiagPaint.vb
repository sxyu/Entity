Imports Entity._3Modules
Namespace _1Dialogs.General.ImageGen
    Public Class DiagPaint
        Private _font As Font
        Private _fgColor As Color
        Private _bgColor As Color
        Private _align As TextAlign

        Public BgpMode As BackMode
        Public BgpGradMode As GradientType
        Public BgpColor1 As Color = Color.Black
        Public BgpColor2 As Color = Color.fromArgb(120, 120, 120)
        Public BgpImage As String

        Dim _moving As Boolean = False
        Dim _ppt As New Point

        Public Enum TextAlign
            TopLeft = 0
            TopCenter
            TopRight
            CenterLeft
            Center
            CenterRight
            BottomLeft
            BottomCenter
            BottomRight
        End Enum
        Public Enum BackMode
            Color = 0
            Gradient
            Image
        End Enum
        Public Enum GradientType
            Horizontal
            Vertical
            DiagonalForward
            DiagonalBackward
            Central
        End Enum
        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
        Private Sub diagPaint_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Dim scrRatio As Double = My.Settings.secondaryScrWH
            Dim pbRatio As Double = pb.Width / pb.Height
            If pbRatio > scrRatio Then 'vert
                pb.Width = CInt(pb.Height * My.Settings.secondaryScrWH) 'resize
                pb.Left = CInt(Me.Width / 2 - pb.Width / 2) 'center
            Else 'horiz
                pb.Height = CInt(pb.Width / My.Settings.secondaryScrWH) 'resize
                pb.Top = 40 + CInt(Me.Height / 2 - pb.Height / 2) 'center
            End If
            tb.Text = CurProject.Name
            If My.Settings.favFont Is Nothing Then
                _font = New Font("Segoe UI SemiLight", 72)
                My.Settings.favFont = _font
            Else
                _font = My.Settings.favFont
            End If
            btnFont.Text = GetFontName(_font)
            btnFont.Font = New Font(_font.FontFamily.Name, 12, _font.Style)
            If My.Settings.favColor = Nothing Then
                _fgColor = Color.White
                My.Settings.favColor = Color.White
            Else
                _fgColor = My.Settings.favColor
            End If
            btnColor.BackColor = _fgColor
            btnColor.FlatAppearance.MouseDownBackColor = _fgColor
            btnColor.FlatAppearance.MouseOverBackColor = _fgColor
            btnColor.ForeColor = GetInverseColor(_fgColor)
            cbAlign.SelectedIndex = My.Settings.favAlign
            _align = CType(My.Settings.favAlign, Global.Entity._1Dialogs.General.ImageGen.DiagPaint.TextAlign)
            BgpMode = CType(My.Settings.favBGMode, BackMode)
            BgpColor1 = My.Settings.favBGColor1
            BgpColor2 = My.Settings.favBGColor2
            BgpGradMode = CType(My.Settings.favBGGradMode, GradientType)
            My.Settings.Save()
        End Sub
        Private Sub diag_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Label1.MouseDown, pb.MouseDown
            _moving = True
            _ppt = e.Location
        End Sub

        Private Sub diag_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Label1.MouseMove, pb.MouseMove
            If _moving Then
                Me.Location = New Point(Me.Left + e.X - _ppt.X, Me.Top + e.Y - _ppt.Y)
            End If
        End Sub

        Private Sub diag_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, Label1.MouseUp, pb.MouseUp
            _moving = False
        End Sub

        Private Sub btnFont_Click(sender As Object, e As EventArgs) Handles btnFont.Click
            Using diag As New FontDialog
                diag.Font = _font
                If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                    _font = diag.Font
                    btnFont.Text = GetFontName(_font)
                    btnFont.Font = New Font(_font.FontFamily.Name, 12, _font.Style)
                    pb.Refresh()
                    My.Settings.favFont = _font
                    My.Settings.Save()
                End If
            End Using
        End Sub
        Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
            Using diag As New ColorDialog
                diag.Color = _fgColor
                If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                    _fgColor = diag.Color
                    btnColor.BackColor = _fgColor
                    btnColor.FlatAppearance.MouseDownBackColor = _fgColor
                    btnColor.FlatAppearance.MouseOverBackColor = _fgColor
                    btnColor.ForeColor = GetInverseColor(_fgColor)
                    pb.Refresh()
                    My.Settings.favColor = _fgColor
                    My.Settings.Save()
                End If
            End Using
        End Sub

        Private Function GetFontName(ByVal font As Font) As String
            Return font.FontFamily.Name & " " & font.Size & "pt " & font.Style.ToString
        End Function
        Private Function GetInverseColor(ByVal color As Color) As Color
            Return color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B)
        End Function
        Public Function AlignToStrFormat(ByVal align As TextAlign) As StringFormat
            Dim ret As New StringFormat
            Select Case align
                Case TextAlign.TopLeft
                    ret.Alignment = StringAlignment.Near
                    ret.LineAlignment = StringAlignment.Near
                Case TextAlign.TopCenter
                    ret.Alignment = StringAlignment.Center
                    ret.LineAlignment = StringAlignment.Near
                Case TextAlign.TopRight
                    ret.Alignment = StringAlignment.Far
                    ret.LineAlignment = StringAlignment.Near

                Case TextAlign.CenterLeft
                    ret.Alignment = StringAlignment.Near
                    ret.LineAlignment = StringAlignment.Center
                Case TextAlign.Center
                    ret.Alignment = StringAlignment.Center
                    ret.LineAlignment = StringAlignment.Center
                Case TextAlign.CenterRight
                    ret.Alignment = StringAlignment.Far
                    ret.LineAlignment = StringAlignment.Center

                Case TextAlign.BottomLeft
                    ret.Alignment = StringAlignment.Near
                    ret.LineAlignment = StringAlignment.Far
                Case TextAlign.BottomCenter
                    ret.Alignment = StringAlignment.Center
                    ret.LineAlignment = StringAlignment.Far
                Case TextAlign.BottomRight
                    ret.Alignment = StringAlignment.Far
                    ret.LineAlignment = StringAlignment.Far
            End Select
            Return ret
        End Function
        Private Sub cbAlign_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbAlign.SelectedIndexChanged
            _align = CType(cbAlign.SelectedIndex, Global.Entity._1Dialogs.General.ImageGen.DiagPaint.TextAlign)
            My.Settings.favAlign = cbAlign.SelectedIndex
            My.Settings.Save()
            pb.Refresh()
        End Sub
        Private Sub paintImage(ByVal g As Graphics, ByVal clipRect As Rectangle)
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

            Select Case BgpMode
                Case BackMode.Color
                    g.Clear(BgpColor1)
                Case BackMode.Gradient
                    Dim h As Integer = clipRect.Height
                    Dim w As Integer = clipRect.Width
                    Dim br As Drawing2D.LinearGradientBrush
                    Dim path As New Drawing2D.GraphicsPath()
                    path.AddRectangle(New Rectangle(0, 0, w, h))
                    Dim fcb As Drawing2D.PathGradientBrush = New Drawing2D.PathGradientBrush(path)
                    fcb.CenterColor = BgpColor1
                    fcb.CenterPoint = New Point(CInt(w / 2), CInt(h / 2))
                    fcb.SurroundColors = {BgpColor2}
                    Dim cent As Boolean = False
                    Select Case BgpGradMode
                        Case GradientType.Horizontal
                            br = New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(w, 0), BgpColor1, BgpColor2)
                        Case GradientType.Vertical
                            br = New Drawing2D.LinearGradientBrush(New Point(CInt(w / 2), 0), New Point(CInt(w / 2), h), BgpColor1, BgpColor2)
                        Case GradientType.DiagonalForward
                            br = New Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(w, h), BgpColor1, BgpColor2)
                        Case GradientType.DiagonalBackward
                            br = New Drawing2D.LinearGradientBrush(New Point(w, 0), New Point(0, h), BgpColor1, BgpColor2)
                        Case GradientType.Central
                            cent = True
                    End Select
                    If cent Then
                        g.FillRectangle(fcb, 0, 0, w, h)
                        fcb.Dispose()
                    Else
                        g.FillRectangle(br, 0, 0, w, h)
                        br.Dispose()
                    End If
                Case BackMode.Image
                    Using bmp As Bitmap = GetBestFitImage(BgpImage, clipRect.Width, clipRect.Height)
                        If bmp.Width > clipRect.Width Then
                            g.DrawImageUnscaled(bmp, CInt((-(bmp.Width - clipRect.Width) / 2)), 0, bmp.Width, bmp.Height)
                        Else
                            g.DrawImageUnscaled(bmp, 0, CInt((-(bmp.Height - clipRect.Height) / 2)), bmp.Width, bmp.Height)
                        End If
                    End Using
            End Select
            Using br As New SolidBrush(_fgColor)
                g.DrawString(tb.Text, _font, br, clipRect, AlignToStrFormat(_align))
            End Using
        End Sub
        Private Sub pb_Paint(sender As Object, e As PaintEventArgs) Handles pb.Paint
            Using bmp As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                Using g As Graphics = Graphics.FromImage(bmp)
                    paintImage(g, New Rectangle(0, 0, bmp.Width, bmp.Height))
                    e.Graphics.DrawImage(bmp, -2, -2, e.ClipRectangle.Width + 2, e.ClipRectangle.Height + 2)
                End Using
            End Using
        End Sub

        Private Sub tb_TextChanged(sender As Object, e As EventArgs) Handles tb.TextChanged
            pb.Refresh()
        End Sub

        Private Sub btnBGOpts_Click(sender As Object, e As EventArgs) Handles btnBGOpts.Click
            Using diag As New DiagPaintBg(Me)
                With diag
                    .ShowDialog()
                End With

            End Using
        End Sub

        Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
            Using bmp As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                Using g As Graphics = Graphics.FromImage(bmp)
                    paintImage(g, New Rectangle(0, 0, bmp.Width, bmp.Height))
                    saveJpeg(FileIO.SpecialDirectories.Temp & "\imgGen.jpg", bmp, 85)
                End Using
            End Using
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub diagPaint_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub
    End Class
End Namespace