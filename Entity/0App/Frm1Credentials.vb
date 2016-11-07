Imports System.Drawing.Text
Imports Entity._3Modules

Namespace _0App

    Public Class Frm1Credentials
        Private _tryTimes As Integer = 0
        Private _prevAttempt As String = ""

        Private Sub frmCredentials_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            pnlInput.Left = CInt(Me.Width / 2 - pnlInput.Width / 2)
            pnlInput.Top = CInt(Me.Height / 2 - pnlInput.Height / 2)
            Me.Icon = My.Resources.en 'set icon
        End Sub


        Private Sub pbIcon_Paint(sender As Object, e As PaintEventArgs) Handles pbIcon.Paint
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(129, 137, 153)), e.ClipRectangle)
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias
            Dim strloc As New StringFormat()
            strloc.Alignment = StringAlignment.Center
            strloc.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString("En", New Font("Segoe UI SemiLight", CSng((e.ClipRectangle.Height) / 7 * 3)), Brushes.White,
                                  e.ClipRectangle, strloc)
        End Sub

        Private Sub btnUnlock_Click(sender As Object, e As EventArgs) Handles btnUnlock.Click
            'get hashes
            Dim hash As String = GenerateHashUnsalted(My.Settings.userSalt1 & tbPass.Text.Trim & My.Settings.userSalt2)
            Dim correctHash As String = My.Settings.userPassword
            'compare hashes
            If hash = correctHash Then
                lbWrong.Hide()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                lbWrong.Show()
                If _prevAttempt <> tbPass.Text Then
                    _tryTimes += 1
                    _prevAttempt = tbPass.Text
                    If _tryTimes < 4 Then
                        lbWrong.Text = String.Format("Password Incorrect. {0} Attempts Left", CStr(5 - _tryTimes))
                    ElseIf _tryTimes < 5 Then
                        lbWrong.Text = "Password Incorrect. 1 Attempt Left"
                    Else
                        My.Settings.crecWait = True
                        My.Settings.waitTime = Now.AddMinutes(1)
                        My.Settings.Save()
                        End
                    End If
                End If
            End If
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub tbPass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbPass.KeyPress
            If btnUnlock.Enabled Then
                If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                    btnUnlock.PerformClick()
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub tbPass_Leave(sender As Object, e As EventArgs) Handles tbPass.Leave
            tbPass.Focus()
        End Sub

        Private Sub btnKeyboard_Click(sender As Object, e As EventArgs) Handles btnKeyboard.Click
            Dim progFiles As String = "C:\Program Files\Common Files\Microsoft Shared\ink"
            Dim keyboardPath As String = IO.Path.Combine(progFiles, "TabTip.exe")
            Process.Start(keyboardPath)
        End Sub
    End Class
End Namespace