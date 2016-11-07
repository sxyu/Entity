Imports Entity._3Modules
Namespace _0App.InitialSetup
    Public Class IFm2Security
        Inherits IFmBase
        Private Sub svw2Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            content.Left = CInt(Me.Width / 2 - content.Width / 2)
            content.Top = CInt(Me.Height / 2 - content.Height / 2)
            For Each c As Control In content.Controls
                If c.Tag Is Nothing Then
                    c.Left = CInt(content.Width / 2 - c.Width / 2)
                End If
            Next
            Me.Icon = My.Resources.en 'set icon
            btnCancel.Left = tbNewPassRe.Left
            btnSavePass.Left = tbNewPassRe.Right - btnSavePass.Width
            content.Show()
            tbNewPass.Focus()
            ForceClose = False
            Me.Fade()
        End Sub
        Dim ok1 As Boolean = False
        Dim ok2 As Boolean = False
        Private Sub tbNewPassRe_TextChanged(sender As Object, e As EventArgs) Handles tbNewPassRe.TextChanged
            btnSavePass.Enabled = False
            If tbNewPass.Text.Trim = tbNewPassRe.Text.Trim Then
                ok2 = True
            Else
                ok2 = False
                lbWarningRe.Text = "The passwords do not match"
            End If
            checkIfOk()
        End Sub
        Private Sub tbNewPass_TextChanged(sender As Object, e As EventArgs) Handles tbNewPass.TextChanged
            If String.IsNullOrEmpty(tbNewPass.Text.Trim) = False Then
                If tbNewPass.Text.Length >= 6 Then
                    If tbNewPassRe.Text <> "" Then
                        If tbNewPass.Text.Trim = tbNewPassRe.Text.Trim Then
                            ok1 = True
                        Else
                            ok1 = False
                            lbWarningRe.Text = "The passwords do not match"
                        End If
                    Else
                        lbWarning.Text = ""
                        ok1 = True
                    End If
                Else
                    ok1 = False
                    lbWarning.Text = "Password must be 6 characters min"
                End If
            Else
                ok1 = False
                lbWarning.Text = "The password cannot be blank"
            End If
            checkIfOk()
        End Sub
        Private Sub checkIfOk()
            If ok1 And ok2 Then
                btnSavePass.Enabled = True
                lbWarningRe.Hide()
                lbWarning.Hide()
            Else
                btnSavePass.Enabled = False
                lbWarningRe.Show()
                lbWarning.Show()
            End If
        End Sub
        Private Sub btnSavePass_EnabledChanged(sender As Object, e As EventArgs) Handles btnSavePass.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(160, 160, 160)
            End If
        End Sub


        Private Sub btnSavePass_Click(sender As Object, e As EventArgs) Handles btnSavePass.Click
            Dim hash() As String = GenerateHash(tbNewPass.Text.Trim)
            My.Settings.userPassword = hash(0)
            My.Settings.userSalt1 = hash(1)
            My.Settings.userSalt2 = hash(2)
            My.Settings.Save()
            FrmCinematic.BlankOut = False
            FrmCinematic.StartScene = 13
            FrmCinematic.ReInit()
            Me.Close()
        End Sub

        Private Sub tbNewPassRe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNewPassRe.KeyPress, tbNewPass.KeyPress
            If btnSavePass.Enabled Then
                If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                    btnSavePass.PerformClick()
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub svw3Admin_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
            tbNewPass.Focus()
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            My.Settings.userPassword = ""
            My.Settings.userSalt1 = ""
            My.Settings.userSalt2 = ""
            My.Settings.Save()
            FrmCinematic.BlankOut = False
            FrmCinematic.StartScene = 14
            FrmCinematic.ReInit()
            Me.Close()
        End Sub


        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

    End Class
End Namespace