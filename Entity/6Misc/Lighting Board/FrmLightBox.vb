Namespace _6Misc
    Public Class FrmLightBox

        Private Sub frmLightBox_MouseDown(sender As Object, e As EventArgs) Handles Me.MouseDown
            'If frmSettings.Visible Then
            'frmSettings.Close()
            'End If
            If frmLightingBd.Visible Then
                frmLightingBd.Close()
            End If
            Me.Close()
        End Sub
        'don't show form on alt tab
        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not Me.DesignMode Then cp.ExStyle = cp.ExStyle Or &H80
                Return cp
            End Get
        End Property

    End Class
End Namespace