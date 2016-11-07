Imports Entity._3Modules
Namespace _6Misc
    Public Class SecondMonitor 'displays on second monitor
        Private _forceClose As Boolean = False

        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not Me.DesignMode Then cp.ExStyle = cp.ExStyle Or &H80
                Return cp
            End Get
        End Property

        Public Sub CheckExit()
            If OpenFormsCount < 3 Then
                _forceClose = True
                Me.Close()
            End If
        End Sub

        Private Sub SecondMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            If Not _forceClose Then
                e.Cancel = True
            End If
        End Sub

        Private Sub pb_mouseEnter(sender As Object, e As EventArgs) Handles pb.MouseEnter, MyBase.MouseEnter
            Cursor.Hide()
        End Sub

        Private Sub pb_MouseLeave(sender As Object, e As EventArgs) Handles pb.MouseLeave, MyBase.MouseEnter
            Cursor.Show()
        End Sub

    End Class
End Namespace