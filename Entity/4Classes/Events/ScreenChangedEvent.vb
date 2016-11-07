Namespace _4Classes.Events
    Public Class ScreenChangedEvent
        Private Sub New()
        End Sub

        Private Shared _instance As ScreenChangedEvent

        Public Event SecondaryScreenChanged()

        Public Shared ReadOnly Property Instance As ScreenChangedEvent
            Get
                If IsNothing(_instance) Then
                    _instance = New ScreenChangedEvent
                End If
                Return _instance
            End Get
        End Property

        Public Sub RaiseScreenChangedEvent()
            RaiseEvent SecondaryScreenChanged()
        End Sub
    End Class
End Namespace