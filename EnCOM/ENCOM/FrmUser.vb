Public Class frmUser
    Private _r As Random = New Random
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        frmMain.userName = tbName.Text.Trim
        frmMain.userColor = RandomRGBColor()
        frmMain.Show()
        frmMain.BringToFront()
        System.GC.Collect()
        Me.Close()
    End Sub
    Public Function RandomRGBColor() As Color
        Dim n As Integer = 70
        Return Color.FromArgb(255, _
            185 + _r.Next(0, n), _
            185 + CInt(Math.Ceiling(Rnd() * n)), _
            185 + CInt(Math.Ceiling(Rnd() * n)))
    End Function

    Private Sub tbName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbName.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnOK.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
        If String.IsNullOrEmpty(tbName.Text.Trim) Then
            btnOK.Enabled = False
        ElseIf tbName.Text.Trim.ToLower = "show control" Or tbName.Text.Trim.ToLower = "admin" Or tbName.Text.Trim.ToLower = "administrator" Then
            btnOK.Enabled = False
        Else
            btnOK.Enabled = True
        End If
    End Sub

    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.People2
    End Sub

    Private Sub frmUser_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Alert.CheckExit()
    End Sub
End Class