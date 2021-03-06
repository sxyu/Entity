﻿Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class DuoSlider

    Public Event Activate(ByVal isNegative As Boolean)
    Public Property BarColor1 As Color = Color.SeaGreen
    Public Property BarColor2 As Color = Color.SlateBlue
    Public Property TextColor As Color = Color.White
    Public Property LeftText As String = "Prev Cue"
    Public Property RightText As String = "Next Cue"
    Public Property CircleColor As Color = Color.LightGray
    Public Property DraggingCircleColor As Color = Color.White
    Public Property InitialSliderLocation As Single = 0
    Public Property SliderLocation As Single  'slider location. valid range: -100 to 100
        Get
            Return _sliderLocation
        End Get
        Set(value As Single)
            _sliderLocation = value
            RaiseEvent SliderLocationChanged(value)
        End Set
    End Property
    Private _sliderLocation As Single
    Private justActivated As Integer = 0
    ''' <summary>
    ''' Raised when the location of the slider is changed
    ''' </summary>
    ''' <remarks></remarks>
    Private Event SliderLocationChanged(ByVal value As Single)

    Private dragging As Boolean = False
    Private ellipseRect As Rectangle
    Public Sub DrawRoundRect(ByVal g As Graphics, ByVal p As Pen, ByVal x As Single, ByVal y As Single, _
                             ByVal width As Single, ByVal height As Single, ByVal radius As Single)
        Using gp As New GraphicsPath()
            gp.StartFigure()
            gp.AddArc(x + width - radius, y, radius * 2, radius * 2, 270, 90)
            gp.AddArc(x + width - radius, y + height - radius, radius * 2, radius * 2, 0, 90)
            gp.AddArc(x, y + height - radius, radius * 2, radius * 2, 90, 90)
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
            gp.CloseFigure()
            g.DrawPath(p, gp)
        End Using
    End Sub
    Public Sub FillRoundRect(ByVal g As Graphics, ByVal b As Brush, ByVal x As Single, ByVal y As Single, _
                             ByVal width As Single, ByVal height As Single, ByVal radius As Single)
        Using gp As New GraphicsPath()
            gp.StartFigure()
            gp.AddArc(x + width - radius, y, radius * 2, radius * 2, 270, 90)
            gp.AddArc(x + width - radius, y + height - radius, radius * 2, radius * 2, 0, 90)
            gp.AddArc(x, y + height - radius, radius * 2, radius * 2, 90, 90)
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90)
            gp.CloseFigure()
            g.FillPath(b, gp)
        End Using
    End Sub

    Private Sub DuoSlider_Load(sender As Object, e As EventArgs) Handles Me.Load
        MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        _sliderLocation = InitialSliderLocation
    End Sub

    Private Sub DuoSlider_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Using buffer As New Bitmap(e.ClipRectangle.Width, e.ClipRectangle.Height)
            Using g As Graphics = Graphics.FromImage(buffer)
                g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

                Dim corn As Integer = CInt(Me.Height / 3)

                If justActivated = 1 Then
                    Using b As New SolidBrush(BarColor2)
                        FillRoundRect(g, b, 1, 1, Me.Width - 4 - corn, Me.Height - 4 - corn, corn)
                    End Using
                ElseIf justActivated = -1 Then
                    Using b As New SolidBrush(BarColor1)
                        FillRoundRect(g, b, 1, 1, Me.Width - 4 - corn, Me.Height - 4 - corn, corn)
                    End Using
                Else
                    Using b As New LinearGradientBrush(New Point(0, CInt(Me.Height / 2)), _
                                                   New Point(Me.Width, CInt(Me.Height / 2)), _
                                                   BarColor1, BarColor2)
                        FillRoundRect(g, b, 1, 1, Me.Width - 4 - corn, Me.Height - 4 - corn, corn)
                    End Using
                End If
                'Using pLine As New Pen(Color.LightGray, 1.5)
                '    g.DrawLine(pLine, 2, Me.Height \ 2, Me.Width - 4, Me.Height \ 2)
                'End Using
                Using sUI As New Font("Segoe UI", CInt(Me.Height / 5 * 2))
                    Using bText As New SolidBrush(TextColor)
                        Dim mes As SizeF = g.MeasureString(RightText, sUI)
                        g.DrawString(LeftText, sUI, bText, 10, CInt(Me.Height / 2 - mes.Height / 2))
                        g.DrawString(RightText, sUI, bText, Me.Width - mes.Width - 10, CInt(Me.Height / 2 - mes.Height / 2))
                    End Using
                End Using
                Using p As New Pen(Me.ForeColor, 2)
                    DrawRoundRect(g, p, 0, 1, Me.Width - 3 - corn, Me.Height - 3 - corn, corn)
                End Using

                Dim r As Double = Me.Height / 3
                Dim d As Double = r * 2
                Dim cent As Double = Me.Width / 2
                Dim offset As Double = _sliderLocation / 100 * (Me.Width / 2 - 8)

                ellipseRect = New Rectangle(CInt(cent - r + offset), CInt(r / 2), _
                              CInt(d), CInt(d))
                If dragging Then
                    Using bElp As New SolidBrush(Color.FromArgb(100, DraggingCircleColor))
                        g.FillEllipse(bElp, ellipseRect)
                    End Using
                Else
                    Using bElp As New SolidBrush(Color.FromArgb(70, CircleColor))
                        g.FillEllipse(bElp, ellipseRect)
                    End Using
                End If
                    Using pElp As New Pen(Me.ForeColor, 1.5)
                        g.DrawEllipse(pElp, ellipseRect)
                    End Using
            End Using
            e.Graphics.DrawImageUnscaled(buffer, 0, 0)
        End Using
    End Sub

    Private Sub SliderMove() Handles Me.SliderLocationChanged
        If _sliderLocation >= 95 Then
            dragging = False
            _sliderLocation = InitialSliderLocation
            justActivated = 1
            resetter.Start()
            Me.Invalidate()
            RaiseEvent Activate(False)
        ElseIf _sliderLocation <= -95 Then
            dragging = False
            _sliderLocation = InitialSliderLocation
            justActivated = -1
            resetter.Start()
            Me.Invalidate()
            RaiseEvent Activate(True)
        End If
    End Sub

    Private Sub DuoSlider_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If isInEllipse(e.Location, ellipseRect) Then
            dragging = True
            Me.Invalidate()
        End If
    End Sub
    Private Sub DuoSlider_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If dragging Then
            SliderLocation = CSng((e.Location.X - Me.Width / 2) / Me.Width) * 200
            Me.Invalidate()
        End If
    End Sub
    Private Sub DuoSlider_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        dragging = False
        SliderLocation = InitialSliderLocation
        Me.Invalidate()
    End Sub

    Private Sub resetter_Tick(sender As Object, e As EventArgs) Handles resetter.Tick
        resetter.Stop()
        justActivated = 0
        Me.Invalidate()
    End Sub
End Class
