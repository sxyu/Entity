Imports Entity._0App.SettingsViews
Imports Entity._0App
Imports Entity._0App.Views
Imports Entity._4Classes.Types
Imports Entity._6Misc
Imports System.Drawing.Drawing2D

Namespace _3Modules
    Module Shapes
        ' cache for settings tabs

        ''' <summary>
        '''     converts a rectangle to plain text
        ''' </summary>
        ''' <param name="rect">rectangle to convert</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function RectToStr(ByVal rect As Rectangle) As String
            Try
                Dim str As String = rect.X & "," & rect.Y & "," & rect.Width & "," & rect.Height
                Return str
            Catch ex As Exception
                MsgBox(
                    "Misc Error 1: Failed to convert rectangle to string. Detailed info displayed below:" & vbCrLf &
                    ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function


        ''' <summary>
        '''     converts text to a rectangle
        ''' </summary>
        ''' <param name="str">string to convert</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function StrToRect(ByVal str As String) As Rectangle
            Try
                Dim rect As New Rectangle
                Dim strSplit() As String = str.Split(CChar(","))
                If strSplit.Length < 4 Then
                    Return Nothing
                End If
                rect.X = CInt(strSplit(0))
                rect.Y = CInt(strSplit(1))
                rect.Width = CInt(strSplit(2))
                rect.Height = CInt(strSplit(3))
                Return rect
            Catch ex As Exception
                MsgBox(
                    "Misc Error 2: Failed to convert string to rectangle. Detailed info displayed below:" & vbCrLf &
                    ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function
        ''' <summary>
        '''     Checks if a point is in the given ellipse
        ''' </summary>
        ''' <param name="pt">the point to check</param>
        ''' <param name="rect">the rectangle from which to form the ellipse</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsInEllipse(ByVal pt As Point, ByVal rect As Rectangle) As Boolean
            Dim gp As New GraphicsPath()
            gp.AddEllipse(rect)
            Return gp.IsVisible(pt)
        End Function


        ''' <summary>
        '''     Checks if a point is in the given rectangle
        ''' </summary>
        ''' <param name="pt">the point to check</param>
        ''' <param name="rect">the rectangle</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function IsInRect(pt As Point, rect As Rectangle) As Boolean
            If pt.X > rect.X And pt.Y > rect.Y And pt.X < rect.Right And pt.Y < rect.Bottom Then Return True Else _
                Return False
        End Function
    End Module
End Namespace