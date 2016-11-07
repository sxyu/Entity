Imports System.Drawing.Drawing2D
Imports System.Drawing.Text

Namespace _5Controls

    Public Class Slider
        Public Event Activate()
        Public Property BarColor1 As Color = Color.SeaGreen
        Public Property TextColor As Color = Color.White
        Public Property LeftText As String = ""
        Public Property RightText As String = "Next Cue"
        Public Property SliderColor As Color = Color.FromArgb(160, 160, 160)
        Public Property ArrowColor As Color = Color.DarkGray
        Public Property DraggingSliderColor As Color = Color.White
        Public Property InitialSliderLocation As Single = -90

        Public Property SliderLocation As Single 'slider location. valid range: -100 to 100
            Get
                Return _sliderLocation
            End Get
            Set(value As Single)
                _sliderLocation = value
                RaiseEvent SliderLocationChanged(value)
            End Set
        End Property

        Private _sliderLocation As Single = -90
        'Private _justActivated As Integer = 0


        ''' <summary>
        '''     Raised when the location of the slider is changed
        ''' </summary>
        ''' <remarks></remarks>
        Private Event SliderLocationChanged(ByVal value As Single)

        Private _dragging As Boolean = False
        Private _ellipseRect As Rectangle

        'Public Sub DrawRoundRect(ByVal g As Graphics, ByVal p As Pen, ByVal x As Single, ByVal y As Single,
        '                         ByVal width As Single, ByVal height As Single, ByVal radius As Single)
        '    Using gp As New GraphicsPath()
        '        gp.StartFigure()
        '        gp.AddArc(x + width - radius, y, radius * 2, radius * 2, 270, 90)
        '        gp.AddArc(x + width - radius, y + height - radius, radius * 2, radius * 2, 0, 90)
        '        gp.AddArc(x, y + height - radius, radius * 2, radius * 2, 90, 90)
        '        gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
        '        gp.CloseFigure()
        '        g.DrawPath(p, gp)
        '    End Using
        'End Sub

        'Public Sub FillRoundRect(ByVal g As Graphics, ByVal b As Brush, ByVal x As Single, ByVal y As Single,
        '                         ByVal width As Single, ByVal height As Single, ByVal radius As Single)
        '    Using gp As New GraphicsPath()
        '        gp.StartFigure()
        '        gp.AddArc(x + width - radius, y, radius * 2, radius * 2, 270, 90)
        '        gp.AddArc(x + width - radius, y + height - radius, radius * 2, radius * 2, 0, 90)
        '        gp.AddArc(x, y + height - radius, radius * 2, radius * 2, 90, 90)
        '        gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
        '        gp.CloseFigure()
        '        g.FillPath(b, gp)
        '    End Using
        'End Sub

        Private Sub DuoSlider_Load(sender As Object, e As EventArgs) Handles Me.Load
            MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            _sliderLocation = InitialSliderLocation
        End Sub

        Private Sub DuoSlider_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using buffer As New Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height)
                Using g As Graphics = Graphics.FromImage(buffer)
                    g.SmoothingMode = SmoothingMode.HighQuality
                    g.TextRenderingHint = TextRenderingHint.AntiAlias

                    Dim corn As Integer = CInt(Me.Height / 3)

                    'If _justActivated = 1 Then
                    'Using b As New SolidBrush(BarColor2)
                    '    g.FillRectangle(b, 1, 1, Me.Width - 4, Me.Height - 4)
                    'End Using
                    'ElseIf _justActivated = -1 Then
                    Using b As New SolidBrush(BarColor1)
                        g.FillRectangle(b, 1, 1, Me.Width - 4, Me.Height - 4)
                    End Using
                    'Else
                    'Using b As New LinearGradientBrush(New Point(0, CInt(Me.Height / 2)),
                    '                                   New Point(Me.Width, CInt(Me.Height / 2)),
                    '                                   BarColor1, BarColor2)
                    '    g.FillRectangle(b, 1, 1, Me.Width - 4, Me.Height - 4)
                    'End Using
                    'End If
                    'Using pLine As New Pen(Color.fromArgb(100, 100, 100), 1.5)
                    '    g.DrawLine(pLine, 2, Me.Height \ 2, Me.Width - 4, Me.Height \ 2)
                    'End Using
                    Using sUI As New Font("Segoe UI SemiLight", CInt(Me.Height / 5 * 2))
                        Using bText As New SolidBrush(TextColor)
                            Dim mes As SizeF = g.MeasureString(RightText, sUI)
                            g.DrawString(LeftText, sUI, bText, 10, CInt(Me.Height / 2 - mes.Height / 2))
                            g.DrawString(RightText, sUI, bText, Me.Width - mes.Width - 10, CInt(Me.Height / 2 - mes.Height / 2))
                        End Using
                    End Using
                    'Using p As New Pen(Me.ForeColor, 2)
                    '    DrawRoundRect(g, p, 0, 1, Me.Width - 3 - corn, Me.Height - 3 - corn, corn)
                    'End Using
                    Dim d As Double = Me.Height - 6
                    Dim r As Double = r / 2
                    Dim cent As Double = Me.Width / 2 - 2
                    Dim offset As Double = _sliderLocation / 100 * (Me.Width / 2 - 2)
                    _ellipseRect = New Rectangle(CInt(cent + offset - r), 2,
                                                 CInt(d), CInt(d))
                    If _dragging Then
                        Using bElp As New SolidBrush(Color.FromArgb(150, DraggingSliderColor))
                            g.FillRectangle(bElp, _ellipseRect)
                        End Using
                    Else
                        Using bElp As New SolidBrush(Color.FromArgb(150, SliderColor))
                            g.FillRectangle(bElp, _ellipseRect)
                        End Using
                    End If
                    Using pArr As New Pen(ArrowColor, 5)
                        Dim arrowMargH As Integer = 10
                        Dim arrowMargV As Integer = 8
                        Dim arrowOffset As Integer = 1
                        g.DrawLine(pArr, _ellipseRect.Left + arrowMargH + arrowOffset, _ellipseRect.Top + arrowMargV,
                                   _ellipseRect.Right - arrowMargH + arrowOffset, CInt(Me.Height / 2))
                        g.DrawLine(pArr, _ellipseRect.Left + arrowMargH + arrowOffset, _ellipseRect.Bottom - arrowMargV,
                                   _ellipseRect.Right - arrowMargH + arrowOffset, CInt(Me.Height / 2) - 2)
                    End Using
                End Using
                e.Graphics.DrawImageUnscaled(buffer, 0, 0)
            End Using
        End Sub

        Private Sub SliderMove() Handles Me.SliderLocationChanged
            If _sliderLocation >= 95 Then
                _dragging = False
                _sliderLocation = InitialSliderLocation
                Me.Invalidate()
                RaiseEvent Activate()
            End If
        End Sub

        Private Sub DuoSlider_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            If _3Modules.Shapes.IsInRect(e.Location, _ellipseRect) Then
                _dragging = True
                Me.Invalidate()
            End If
        End Sub

        Private Sub Slider_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            If _dragging Then
                SliderLocation = CSng((e.Location.X - Me.Height / 2 - Me.Width / 2) / Me.Width) * 200
                Me.Invalidate()
            End If
        End Sub

        Private Sub Slider_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
            _dragging = False
            SliderLocation = InitialSliderLocation
            Me.Invalidate()
        End Sub

        'Private Sub resetter_Tick(sender As Object, e As EventArgs) Handles resetter.Tick
        '    resetter.Stop()
        '    _justActivated = 0
        '    Me.Invalidate()
        'End Sub
    End Class
End Namespace