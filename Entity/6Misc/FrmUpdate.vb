Namespace _6Misc
    Public Class FrmUpdate
        Public IsAutoCheck As Boolean = False
        Public IsOk As Boolean = False
        Private Sub frmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Icon = My.Resources.en
            If isAutoCheck Then
                cbCheckUpd.Checked = My.Settings.autoUpdateCheck
                cbCheckUpd.Show()
            Else
                cbCheckUpd.Hide()
            End If
            Me.BringToFront()
        End Sub
        Private Sub ButtonCanc_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, btnClose.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Dim moving As Boolean
        Dim ppt As New Point
        Private Sub Panel1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles _
                                                                                                            MyBase.MouseDown, lbVer.MouseDown, lbDesc.MouseDown, lbTitle.MouseDown, tbNotes.MouseDown
            On Error Resume Next
            moving = True
            ppt = New Point(e.Location.X, e.Location.Y)
        End Sub
        Private Sub Panel1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles _
                                                                                                            MyBase.MouseMove, lbVer.MouseMove, lbDesc.MouseMove, lbTitle.MouseMove
            On Error Resume Next
            If moving Then
                Me.Location = New Point(Me.Location.X + e.Location.X - ppt.X, Me.Location.Y + e.Location.Y - ppt.Y)
            End If
        End Sub
        Private Sub Panel1_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles _
                                                                                                          MyBase.MouseUp, lbVer.MouseUp, lbDesc.MouseUp, lbTitle.MouseUp, tbNotes.MouseUp, tbNotes.MouseMove
            On Error Resume Next
            moving = False
        End Sub

        Private Sub tbNotes_KeyDown(sender As Object, e As KeyEventArgs) Handles tbNotes.KeyDown
            e.SuppressKeyPress = True
        End Sub

        Private Sub tbNotes_Enter(sender As Object, e As EventArgs) Handles tbNotes.Enter
            btnOK.Focus()
        End Sub

        Private Sub cbCheckUpd_CheckedChanged(sender As Object, e As EventArgs) Handles cbCheckUpd.CheckedChanged
            My.Settings.autoUpdateCheck = cbCheckUpd.Checked
            My.Settings.Save()
        End Sub

        Private Sub frmUpdate_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub btnOK_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOK.MouseUp
            Me.DialogResult = Windows.Forms.DialogResult.OK
            isOK = True
            Me.Close()
        End Sub

        Private Sub frmUpdate_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub
    End Class
End Namespace