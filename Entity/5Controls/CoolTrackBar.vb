Imports System.Drawing.Drawing2D

Namespace _5Controls

    Public Class CoolTrackBar
        Inherits TrackBar

        Private _thumbRect As Rectangle = New Rectangle(0, 0, 19, 19)
        Private _isOverThumb As Boolean
        Private _cachedValue As Integer
        Private _rangeRect As Rectangle = Rectangle.Empty

        Private _mGrooveSize As Integer = 6
        Private _mGrooveBorderColor As Color = Color.fromArgb(100, 100, 100)
        Private _mGrooveColor As Color = Color.fromArgb(100, 100, 100)

        Private _mSelStartColor As Color = Color.Blue
        Private _mSelEndColor As Color = Color.Red

        Public Sub New()
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.SetStyle(ControlStyles.UserPaint, True)
            Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        End Sub

        Public Property GrooveSize As Integer
            Get
                Return _mGrooveSize
            End Get
            Set(value As Integer)
                _mGrooveSize = value
                Me.Invalidate()
            End Set
        End Property

        Public Property GrooveColor As Color
            Get
                Return _mGrooveColor
            End Get
            Set(value As Color)
                _mGrooveColor = value
                Me.Invalidate()
            End Set
        End Property

        Public Property GrooveBorderColor As Color
            Get
                Return _mGrooveBorderColor
            End Get
            Set(value As Color)
                _mGrooveBorderColor = value
                Me.Invalidate()
            End Set
        End Property

        Public Overloads Property TickStyle As TickStyle
            Get
                Return Windows.Forms.TickStyle.Both
            End Get
            Set(value As TickStyle)
                MyBase.TickStyle = Windows.Forms.TickStyle.Both
            End Set
        End Property

        Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
            Dim g As Graphics = pevent.Graphics
            Dim r As Rectangle = Me.DisplayRectangle

            Select Case MyBase.Orientation
                Case Orientation.Horizontal
                    _rangeRect = New Rectangle(r.X + 14, r.Top, r.Width - 30, r.Height)
                Case Orientation.Vertical
                    _rangeRect = New Rectangle(r.X + 5, r.Y + 14, r.Width, r.Height - 29)
            End Select

            MyBase.OnPaintBackground(pevent)

            DrawGroove(g)
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Dim g As Graphics = e.Graphics
            DrawThumb(g)
        End Sub

        Private Sub DrawGroove(g As Graphics)
            Dim r1 As Rectangle
            Dim r2 As Rectangle

            Select Case Orientation
                Case Windows.Forms.Orientation.Horizontal
                    r1 = New Rectangle(_rangeRect.X, _rangeRect.Y + (_rangeRect.Height - _mGrooveSize) \ 2, _rangeRect.Width, _mGrooveSize)
                    r2 = New Rectangle(r1.X, r1.Y, CInt(r1.Width * ValueToPercentage(_cachedValue)), r1.Height)
                Case Windows.Forms.Orientation.Vertical
                    r1 = New Rectangle(CInt(_rangeRect.X + (_rangeRect.Width - _mGrooveSize) / 2 - _mGrooveSize \ 2), _rangeRect.Y, _mGrooveSize, _rangeRect.Height)
                    r2 = New Rectangle(r1.X, r1.Y, r1.Width, CInt(r1.Height * ValueToPercentage(_cachedValue)))
                    g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                    Using sui As New Font("Segoe UI SemiLight", 6)
                        Using suiL As New Font("Segoe UI SemiLight", 8)
                            Using br As New SolidBrush(Color.FromArgb(200, 200, 200))
                                Dim w As Integer = CInt(_rangeRect.X + _rangeRect.Width / 2 + 4)
                                Dim wL As Integer = CInt(_rangeRect.X + _rangeRect.Width / 2 + 1)
                                Dim mTickH As Integer = CInt(g.MeasureString("-", sui).Height / 2)
                                Dim m10 As Integer = CInt(g.MeasureString("10", suiL).Height / 2)
                                Dim m5 As Integer = CInt(g.MeasureString("5", suiL).Height / 2)
                                Dim m0 As Integer = CInt(g.MeasureString(CStr(0), suiL).Height / 2)
                                g.DrawString("10", suiL, br, wL, _rangeRect.Y - m10)
                                g.DrawString("-", sui, br, w, CSng(_rangeRect.Y + _rangeRect.Height / 10 - mTickH))
                                g.DrawString("-", sui, br, w, CSng(_rangeRect.Y + _rangeRect.Height / 10 * 2 - mTickH))
                                g.DrawString("-", sui, br, w, CSng(_rangeRect.Y + _rangeRect.Height / 10 * 3 - mTickH))
                                g.DrawString("-", sui, br, w, CSng(_rangeRect.Y + _rangeRect.Height / 10 * 4 - mTickH))
                                g.DrawString("5", suiL, br, wL, CSng(_rangeRect.Y + _rangeRect.Height / 10 * 5 - m5))
                                g.DrawString("-", sui, br, w, CSng(_rangeRect.Y + _rangeRect.Height / 10 * 6 - mTickH))
                                g.DrawString("-", sui, br, w, CSng(_rangeRect.Y + _rangeRect.Height / 10 * 7 - mTickH))
                                g.DrawString("-", sui, br, w, CSng(_rangeRect.Y + _rangeRect.Height / 10 * 8 - mTickH))
                                g.DrawString("-", sui, br, w, CSng(_rangeRect.Y + _rangeRect.Height / 10 * 9 - mTickH))
                                g.DrawString("0", suiL, br, wL, CSng(_rangeRect.Y + _rangeRect.Height - m0))
                            End Using
                        End Using
                    End Using
            End Select

            Using b As New SolidBrush(_mGrooveColor)
                g.FillRectangle(b, r1)
            End Using

            Using p As New Pen(_mGrooveBorderColor)
                g.DrawRectangle(p, r1)
            End Using

            'Using lgb As New LinearGradientBrush(r1.Location, New Point(r1.Right, r1.Bottom), mSelStartColor, mSelEndColor)
            'g.FillRectangle(lgb, r2)
            'End Using
        End Sub

        Private Sub DrawThumb(g As Graphics)
            Dim thumb As VisualStyles.VisualStyleElement = Nothing

            Select Case MyBase.Orientation
                Case Orientation.Horizontal
                    If MyBase.Enabled Then
                        If _isOverThumb Then
                            thumb = VisualStyles.VisualStyleElement.TrackBar.ThumbTop.Hot
                        Else
                            If MyBase.Focused Then
                                thumb = VisualStyles.VisualStyleElement.TrackBar.ThumbTop.Focused
                            Else
                                thumb = VisualStyles.VisualStyleElement.TrackBar.ThumbTop.Normal
                            End If
                        End If
                    Else
                        thumb = VisualStyles.VisualStyleElement.TrackBar.ThumbTop.Disabled
                    End If
                Case Orientation.Vertical
                    If MyBase.Enabled Then
                        If _isOverThumb Then
                            thumb = VisualStyles.VisualStyleElement.TrackBar.ThumbRight.Hot
                        Else
                            If MyBase.Focused Then
                                thumb = VisualStyles.VisualStyleElement.TrackBar.ThumbRight.Focused
                            Else
                                thumb = VisualStyles.VisualStyleElement.TrackBar.ThumbRight.Normal
                            End If
                        End If
                    Else
                        thumb = VisualStyles.VisualStyleElement.TrackBar.ThumbRight.Disabled
                    End If
            End Select

            Dim valuePercentage As Single = ValueToPercentage(_cachedValue)
            Dim vsr As New VisualStyles.VisualStyleRenderer(thumb)
            _thumbRect.Size = vsr.GetPartSize(g, VisualStyles.ThemeSizeType.Draw)

            Dim pos As Integer
            Select Case MyBase.Orientation
                Case Orientation.Horizontal
                    pos = CInt(valuePercentage * _rangeRect.Width)
                    _thumbRect.Location = New Point(CInt(pos + _thumbRect.Width / 2 + 3), CInt(_rangeRect.Y + _thumbRect.Height / 2 + _mGrooveSize / 4))
                Case Orientation.Vertical
                    pos = CInt(valuePercentage * _rangeRect.Height)
                    _thumbRect.Location = New Point(CInt(_rangeRect.X + _thumbRect.Width / 2 + _mGrooveSize / 4), CInt(pos + _thumbRect.Height / 2 + 3))
            End Select

            vsr.DrawBackground(g, _thumbRect)
        End Sub

        Private Function ValueToPercentage(value As Integer) As Single
            Dim w As Integer = Me.Maximum - Me.Minimum
            Dim min As Single = Me.Minimum
            Dim max As Single = Me.Maximum
            If MyBase.Orientation = Orientation.Horizontal Then
                Return (value - min) / (max - min)
            Else
                Return 1 - (value - min) / (max - min)
            End If
        End Function

        Private Sub CoolTrackBar_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            If _thumbRect.IntersectsWith(New Rectangle(e.Location, New Size(1, 1))) Then
                _isOverThumb = True
                Me.Invalidate()
            ElseIf _isOverThumb Then
                _isOverThumb = False
                Me.Invalidate()
            End If
        End Sub

        Private Sub CoolTrackBar_ValueChanged(sender As Object, e As EventArgs) Handles Me.ValueChanged
            _cachedValue = MyBase.Value
            Me.Invalidate()
        End Sub
    End Class
End Namespace