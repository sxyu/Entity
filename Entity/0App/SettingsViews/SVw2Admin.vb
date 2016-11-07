Imports Entity._3Modules
Namespace _0App.SettingsViews
    Public Class Svw2Admin

        Private Sub svw2Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If String.IsNullOrEmpty(My.Settings.userPassword) Or My.Settings.userPassword = "0" Then
                lbTitle.Text = "Set New Password"
                btnCancel.Hide()
                pnlNormal.Hide()
                pnlNewPass.Show()
                tbNewPass.Focus()
            Else
                lbTitle.Text = "Change / Remove Password"
                btnCancel.Show()
                pnlNormal.Show()
                pnlNewPass.Hide()
                tbPass.Focus()
            End If
        End Sub
        Dim ok1 As Boolean = False
        Dim ok2 As Boolean = False
        Private Sub tbNewPassRe_TextChanged(sender As Object, e As EventArgs) Handles tbNewPassRe.TextChanged
            btnSavePass.Enabled = False
            If tbNewPass.Text.Trim = tbNewPassRe.Text.Trim Then
                ok2 = True
            Else
                ok2 = False
                lbWarning.Text = "The passwords do not match"
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
                            lbWarning.Text = "The passwords do not match"
                        End If
                    Else
                        lbWarning.Text = ""
                        ok1 = True
                    End If
                Else
                    ok1 = False
                    lbWarning.Text = "The password must be at least 6 characters long"
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
                lbWarning.Hide()
            Else
                btnSavePass.Enabled = False
                lbWarning.Show()
            End If
        End Sub
        Private Sub btnSavePass_EnabledChanged(sender As Object, e As EventArgs) Handles btnSavePass.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(100, 100, 100)
            End If
        End Sub


        Private Sub btnSavePass_Click(sender As Object, e As EventArgs) Handles btnSavePass.Click
            Dim msgtxt As String = "Password successfully changed."
            If My.Settings.userPassword = "" Or My.Settings.userPassword = "0" Then _
                msgtxt = "Password setup complete! You will now be asked to enter the password when you launch the Entity System."
            Dim hash() As String = GenerateHash(tbNewPass.Text.Trim)
            My.Settings.userPassword = hash(0)
            My.Settings.userSalt1 = hash(1)
            My.Settings.userSalt2 = hash(2)
            My.Settings.Save()
            MsgBox(msgtxt, MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxSetForeground, "User Authentication Subsystem")
            lbTitle.Text = "Change / Remove Password"
            pnlNormal.Show()
            pnlNewPass.Hide()
            tbPass.Text = ""
            btnCancel.Show()
            tbNewPass.Text = ""
            tbNewPassRe.Text = ""
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            tbNewPass.Text = ""
            tbNewPassRe.Text = ""
            tbPass.Text = ""
            lbTitle.Text = "Change / Remove Password"
            pnlNormal.Show()
            pnlNewPass.Hide()
        End Sub

        Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
            'get hashes
            Dim hash As String = GenerateHashUnsalted(My.Settings.userSalt1 & tbPass.Text.Trim & My.Settings.userSalt2)
            Dim correctHash As String = My.Settings.userPassword
            'compare hashes 
            If hash = correctHash Then
                tbNewPassRe.Text = ""
                tbNewPass.Text = ""
                lbTitle.Text = "Change Password"
                pnlNewPass.Show()
                pnlNormal.Hide()
                lbWrong.Hide()
                tbNewPass.Focus()
            Else
                lbWrong.Show()
            End If
        End Sub

        Private Sub btnLock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click
            'get hash
            Dim hash As String = GenerateHashUnsalted(My.Settings.userSalt1 & tbPass.Text.Trim & My.Settings.userSalt2)
            Dim correctHash As String = My.Settings.userPassword
            'compare hashes
            If hash = correctHash Then
                If MsgBox("Remove Password?", MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.YesNo, "Remove Password") _
                   = MsgBoxResult.Yes Then
                    My.Settings.userPassword = ""
                    My.Settings.Save()
                    MsgBox("Your password has been successfully removed. You will no longer be asked for the password when you launch the Entity System.", _
                           MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxSetForeground, "User Authentication Subsystem")
                    lbTitle.Text = "Set New Password"
                    pnlNewPass.Show()
                    pnlNormal.Hide()
                    btnCancel.Hide()
                    lbWrong.Hide()
                    tbNewPass.Focus()
                End If
            Else
                lbWrong.Show()
            End If
        End Sub

        Private Sub tbNewPassRe_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbNewPassRe.KeyPress, tbNewPass.KeyPress
            If btnSavePass.Enabled Then
                If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                    btnSavePass.PerformClick()
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub tbPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPass.KeyPress
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                btnChange.PerformClick()
                e.Handled = True
            End If
        End Sub

        Private Sub svw3Admin_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
            If pnlNewPass.Visible Then
                tbNewPass.Focus()
            Else
                tbPass.Focus()
            End If
        End Sub
    End Class
End Namespace