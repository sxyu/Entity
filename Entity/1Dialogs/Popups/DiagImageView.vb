Imports Entity._3Modules
Namespace _1Dialogs.Popups
    Public Class DiagImageView
        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
        Dim _moving As Boolean = False
        Dim _ppt As New Point

        Private Sub diagImageView_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        End Sub
        Private Sub diagImageView_MouseDown(sender As Object, e As MouseEventArgs) Handles pb.MouseDown, MyBase.MouseDown, Label1.MouseDown
            _moving = True
            _ppt = e.Location
        End Sub

        Private Sub diagImageView_MouseMove(sender As Object, e As MouseEventArgs) Handles pb.MouseMove, MyBase.MouseMove, Label1.MouseMove
            If _moving Then
                Me.Location = New Point(Me.Left + e.X - _ppt.X, Me.Top + e.Y - _ppt.Y)
            End If
        End Sub

        Private Sub diagImageView_MouseUp(sender As Object, e As MouseEventArgs) Handles pb.MouseUp, MyBase.MouseUp, Label1.MouseUp
            _moving = False
        End Sub

        Private Sub diagImageView_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub

        Private Sub pb_Paint(sender As Object, e As PaintEventArgs) Handles pb.Paint
            Using pn As New Pen(Color.GhostWhite, 2)
                e.Graphics.DrawRectangle(pn, 2, -1, pb.Width - 3, pb.Height)
            End Using
        End Sub
    End Class
End Namespace