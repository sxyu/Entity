Imports Entity._3Modules
Namespace _4Classes.Types
    Public Class RectangleX
        Public Enum Corner
            None = 0
            TopLeft = 1
            TopRight = 2
            BottomLeft = 3
            BottomRight = 4
        End Enum

        Public Enum Side
            None = 0
            Top = 1
            Right = 2
            Bottom = 3
            Left = 4
        End Enum

        Public Property IsActive As Boolean = False
        Public Property ActivePercent As Decimal = 0
        Public Property Tag As Object
        Public Property Size As New Size
        Public Property TopLeft As New Point

        Public Property TopRight As Point
            Get
                Return New Point(Me.TopLeft.X + Me.Size.Width, Me.TopLeft.Y)
            End Get
            Set(value As Point)
                Me.Size = New Size(Me.Size.Width + (value.X - Me.BottomRight.X), Me.Size.Height + (value.Y - Me.TopLeft.Y))
                Me.TopLeft = New Point(Me.TopLeft.X, Me.TopLeft.Y - (value.Y - Me.TopLeft.Y))
            End Set
        End Property

        Public Property BottomRight As Point
            Get
                Return New Point(Me.TopLeft.X + Me.Size.Width, Me.TopLeft.Y + Me.Size.Height)
            End Get
            Set(value As Point)
                Me.Size = New Size(Me.Size.Width + (value.X - Me.BottomRight.X),
                                   Me.Size.Height + (value.Y - Me.BottomRight.Y))
            End Set
        End Property

        Public Property BottomLeft As Point
            Get
                Return New Point(Me.TopLeft.X, Me.TopLeft.Y + Me.Size.Height)
            End Get
            Set(value As Point)
                Me.Size = New Size(Me.Size.Width - (value.X - Me.TopLeft.X), Me.Size.Height - (value.Y - Me.BottomRight.Y))
                Me.TopLeft = New Point(Me.TopLeft.X + (value.X - Me.TopLeft.X), Me.TopLeft.Y)
            End Set
        End Property

        Public Property Top As Integer
            Get
                Return Me.TopLeft.Y
            End Get
            Set(value As Integer)
                Me.TopLeft = New Point(Me.TopLeft.X, value)
            End Set
        End Property

        Public Property Left As Integer
            Get
                Return Me.TopLeft.X
            End Get
            Set(value As Integer)
                Me.TopLeft = New Point(value, Me.TopLeft.Y)
            End Set
        End Property

        Public Property Bottom As Integer
            Get
                Return Me.TopLeft.Y + Me.Size.Height
            End Get
            Set(value As Integer)
                Me.Size = New Size(Me.Size.Width, Me.Size.Height + (value - Me.Bottom))
            End Set
        End Property

        Public Property Right As Integer
            Get
                Return Me.TopLeft.X + Me.Size.Width
            End Get
            Set(value As Integer)
                Me.Size = New Size(Me.Size.Width + (value - Me.Right), Me.Size.Height)
            End Set
        End Property

        Public Property Width As Integer
            Get
                Return Me.Size.Width
            End Get
            Set(value As Integer)
                Me.Size = New Size(value, Me.Size.Height)
            End Set
        End Property

        Public Property Height As Integer
            Get
                Return Me.Size.Height
            End Get
            Set(value As Integer)
                Me.Size = New Size(Me.Size.Width, value)
            End Set
        End Property

        Public Sub Move(ByVal right As Integer, ByVal down As Integer)
            Me.TopLeft = New Point(Me.TopLeft.X + right, Me.TopLeft.Y + down)
        End Sub

        Public Sub EnsureLarger(ByVal width As Integer, ByVal height As Integer)
            If Me.Size.Width < width Then
                Me.Width = width
            End If
            If Me.Size.Height < height Then
                Me.Height = height
            End If
        End Sub

        Public Sub EnsureTopLeft(ByVal x As Integer, ByVal y As Integer)
            If Me.TopLeft.X < x Then
                Me.TopLeft = New Point(x, Me.TopLeft.Y)
            End If
            If Me.TopLeft.Y < y Then
                Me.TopLeft = New Point(Me.TopLeft.X, y)
            End If
        End Sub

        Public Sub EnsureBottomRight(ByVal x As Integer, ByVal y As Integer)
            If Me.TopLeft.X + Me.Size.Width > x Then
                Me.TopLeft = New Point(x - Me.Size.Width, Me.TopLeft.Y)
            End If
            If Me.TopLeft.Y + Me.Size.Height > y Then
                Me.TopLeft = New Point(Me.TopLeft.X, y - Me.Size.Height)
            End If
        End Sub

        Public Sub EnsureWithin(ByVal outerRect As Rectangle)
            Me.EnsureTopLeft(outerRect.X, outerRect.Y)
            Me.EnsureBottomRight(outerRect.Right - 1, outerRect.Bottom - 1)
            If Me.Width > outerRect.Width Then
                Me.Width = outerRect.Width - 1
            End If
            If Me.Height > outerRect.Height Then
                Me.Height = outerRect.Height - 1
            End If
            Me.EnsureTopLeft(outerRect.X, outerRect.Y)
            Me.EnsureBottomRight(outerRect.Right - 1, outerRect.Bottom - 1)
        End Sub

        Public Sub EnsureWHRatio(ByVal ratio As Double, Optional ByVal outerRect As Rectangle = Nothing)
            If outerRect = Nothing Then
                Me.Width = CInt(Me.Height * ratio)
            Else
                EnsureWithin(outerRect)
                If Me.Height * ratio > outerRect.Width Then
                    Me.Height = CInt(Me.Width / ratio)
                Else
                    Me.Width = CInt(Me.Height * ratio)
                End If
                EnsureWithin(outerRect)
            End If
        End Sub

        Public Function GetCornerRectangle(ByVal corner As Corner, ByVal sideLength As Integer,
                                           Optional ByVal offset As Integer = 0) As Rectangle
            Dim sizeR As New Size(sideLength + offset * 2, sideLength + offset * 2)
            Select Case corner
                Case corner.TopLeft
                    Return New Rectangle(New Point(Me.TopLeft.X - offset, Me.TopLeft.Y - offset), sizeR)
                Case corner.TopRight
                    Return New Rectangle(New Point(Me.Right - sideLength - offset, Me.Top - offset), sizeR)
                Case corner.BottomLeft
                    Return New Rectangle(New Point(Me.Left - offset, Me.Bottom - sideLength - offset), sizeR)
                Case corner.BottomRight
                    Return New Rectangle(New Point(Me.Right - sideLength - offset, Me.Bottom - sideLength - offset), sizeR)
            End Select
        End Function

        Public Function GetSideRectangle(ByVal side As Side, ByVal sideLength As Integer,
                                         Optional ByVal offset As Integer = 0) As Rectangle
            Dim sizeR As New Size(sideLength + offset * 2, sideLength + offset * 2)
            Select Case side
                Case side.Top
                    Return New Rectangle(New Point(CInt(Me.TopLeft.X + Me.Width / 2 - sideLength / 2 - offset),
                                                   Me.TopLeft.Y - offset), sizeR)
                Case side.Right
                    Return New Rectangle(New Point(Me.Right - sideLength - offset,
                                                   CInt(Me.TopLeft.Y + Me.Height / 2 - sideLength / 2 - offset)), sizeR)
                Case side.Bottom
                    Return New Rectangle(New Point(CInt(Me.TopLeft.X + Me.Width / 2 - sideLength / 2 - offset),
                                                   Me.Bottom - sideLength - offset), sizeR)
                Case side.Left
                    Return New Rectangle(New Point(Me.Left - offset,
                                                   CInt(Me.TopLeft.Y + Me.Height / 2 - sideLength / 2 - offset)), sizeR)
            End Select
        End Function

        Public Function GetSubtractedRect(ByVal rect As Rectangle) As RectangleX
            Dim top_left As Point = New Point(Me.Left - rect.Left, Me.Top - rect.Top)
            Return New RectangleX(top_left, Me.Size)
        End Function

        Public Function GetMultipliedRect(ByVal msize As Size, ByVal prect As Rectangle) As RectangleX
            Dim w As Integer = CInt((Me.Width / prect.Width) * msize.Width)
            Dim h As Integer = CInt((Me.Height / prect.Height) * msize.Height)
            Dim x As Integer = CInt((Me.Left / prect.Width) * msize.Width)
            Dim y As Integer = CInt((Me.Top / prect.Height) * msize.Height)
            Return New RectangleX(x, y, w, h)
        End Function

        Public Sub MoveCorner(ByVal corner As Corner, ByVal x As Integer, ByVal y As Integer)
            Select Case corner
                Case corner.TopLeft
                    Me.TopLeft = New Point(Me.TopLeft.X + x, Me.TopLeft.Y + y)
                    Me.Width -= x
                    Me.Height -= y
                Case corner.TopRight
                    Me.TopRight = New Point(Me.TopRight.X + x, Me.TopRight.Y + y)
                Case corner.BottomLeft
                    Me.BottomLeft = New Point(Me.BottomLeft.X + x, Me.BottomLeft.Y + y)
                Case corner.BottomRight
                    Me.BottomRight = New Point(Me.BottomRight.X + x, Me.BottomRight.Y + y)
            End Select
        End Sub

        Public Sub MoveSide(ByVal side As Side, ByVal x As Integer, ByVal y As Integer)
            Select Case side
                Case side.Top
                    Me.TopLeft = New Point(Me.TopLeft.X + x, Me.TopLeft.Y + y)
                    Me.Height -= y
                Case side.Right
                    Me.TopRight = New Point(Me.TopRight.X + x, Me.TopRight.Y + y)
                    Me.Height += y
                Case side.Bottom
                    Me.BottomLeft = New Point(Me.BottomLeft.X + x, Me.BottomLeft.Y - y)
                    Me.Width += x
                Case side.Left
                    Me.TopLeft = New Point(Me.TopLeft.X + x, Me.TopLeft.Y + y)
                    Me.Width -= x
            End Select
        End Sub

        Public Function ToRectangle(Optional ByVal offset As Integer = 0) As Rectangle
            Return New Rectangle(Me.TopLeft.X - offset, Me.TopLeft.Y - offset, Me.Width + offset * 2, Me.Height + offset * 2)
        End Function

        Public Function ToPolygon() As Point()
            Return {Me.TopLeft, Me.TopRight, Me.BottomRight, Me.BottomLeft}
        End Function

        Public Overrides Function ToString() As String
            Return Me.Left & "," & Me.Top & "," & Me.Width & "," & Me.Height
        End Function

        Public Function ToRatioString(ByVal outerSize As Size) As String
            Return CInt(Me.Left / outerSize.Width * 10000) & "," & CInt(Me.Top / outerSize.Height * 10000) & "," &
                   CInt(Me.Width / outerSize.Width * 10000) & "," & CInt(Me.Height / outerSize.Height * 10000)
        End Function

        Public Sub New(ByVal ratioStr As String, ByVal outerSize As Size)
            Dim rect As New Rectangle
            Dim strSplit() As String = ratioStr.Split(","c)
            If strSplit.Length >= 4 Then
                rect.X = CInt(CDbl(strSplit(0)) / 10000 * outerSize.Width)
                rect.Y = CInt(CDbl(strSplit(1)) / 10000 * outerSize.Height)
                rect.Width = CInt(CDbl(strSplit(2)) / 10000 * outerSize.Width)
                rect.Height = CInt(CDbl(strSplit(3)) / 10000 * outerSize.Height)
                Me.TopLeft = rect.Location
                Me.Size = rect.Size
            End If
            'Return CInt(Me.Left / outerSize.Width * 10000) & "," & CInt(Me.Top / outerSize.Height * 10000) & "," & _
            '    CInt(Me.Width / outerSize.Width * 10000) & "," & CInt(Me.Height / outerSize.Height * 10000)
        End Sub

        Public Sub New(ByVal top_Left As Point, ByVal rect_Size As Size)
            Me.TopLeft = top_Left
            Me.Size = rect_Size
        End Sub

        Public Sub New(ByVal top_Left As Point, ByVal w As Integer, ByVal h As Integer)
            Me.TopLeft = top_Left
            Me.Size = New Size(w, h)
        End Sub

        Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal w As Integer, ByVal h As Integer)
            Me.TopLeft = New Point(x, y)
            Me.Size = New Size(w, h)
        End Sub

        Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal rect_Size As Size)
            Me.TopLeft = New Point(x, y)
            Me.Size = rect_Size
        End Sub

        Public Sub New(ByVal top_Left As Point, ByVal bottom_Right As Point)
            Me.TopLeft = top_Left
            Me.Size = New Size(bottom_Right.X - top_Left.X, bottom_Right.Y - top_Left.Y)
        End Sub

        Public Sub New(ByVal rectangle As Rectangle)
            Me.TopLeft = rectangle.Location
            Me.Size = rectangle.Size
        End Sub

        Public Sub New(ByVal str As String)
            Dim rect As New Rectangle
            Dim strSplit() As String = str.Split(","c)
            If strSplit.Length >= 4 Then
                rect.X = CInt(strSplit(0))
                rect.Y = CInt(strSplit(1))
                rect.Width = CInt(strSplit(2))
                rect.Height = CInt(strSplit(3))
                Me.TopLeft = rect.Location
                Me.Size = rect.Size
            End If
        End Sub

        Public Function Clone() As RectangleX
            Dim rec As New RectangleX(Me.TopLeft, Me.Size)
            rec.Tag = Me.Tag
            rec.IsActive = Me.IsActive
            rec.ActivePercent = Me.ActivePercent
            Return rec
        End Function
    End Class
End Namespace