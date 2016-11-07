Imports Entity._3Modules
Namespace _0App.InitialSetup
    Public Class IFm3Tips
        Inherits IFmBase
        Private Sub svw3Tips_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            content.Left = CInt(Me.Width / 2 - content.Width / 2)
            content.Top = CInt(Me.Height / 2 - content.Height / 2)
            'For Each c As Control In content.Controls
            '    If c.Tag Is Nothing Then
            '        c.Left = CInt(content.Width / 2 - c.Width / 2)
            '    End If
            'Next
            Me.Icon = My.Resources.en 'set icon
            content.Show()
            ForceClose = False
            Me.Fade()
            Cursor.Show()
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnOK.Click
            FrmCinematic.BlankOut = False
            FrmCinematic.StartScene = 16
            FrmCinematic.ReInit()
            Me.Close()
        End Sub


        Private Sub IFm3Tips_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                btnOK.PerformClick()
                e.Handled = True
            End If
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
    End Class
End Namespace