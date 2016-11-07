Namespace _1Dialogs.Input
    Public Class DiagTextInput
        Public Result As String = ""
        Public OkText As String = "Create"
        Public CancelText As String = "Cancel"
        Public DescText As String = "Name"
        Public DefaultResult As String = ""
        Public CheckProjIgnore As String = ""
        Public CheckProj As Boolean = False
        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
            If tbName.Text = "" Then Exit Sub
            result = tbName.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub
        Dim firstck As Boolean = False
        Private Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
            If String.IsNullOrEmpty(tbName.Text.Trim) Then
                If firstck Then
                    firstck = False
                    Exit Sub
                End If
                lbWarning.Text = "Name Cannot be Empty!"
                lbWarning.Show()
                btnCreate.Enabled = False
            ElseIf tbName.Text.Contains("/") Or tbName.Text.Contains("\") Or tbName.Text.Contains(".") Or tbName.Text.Contains(":") _
                   Or tbName.Text.Contains("?") Or tbName.Text.Contains("*") Or tbName.Text.Contains("''") Or tbName.Text.Contains("|") _
                   Or tbName.Text.Contains("<") Or tbName.Text.Contains(">") Or tbName.Text.Contains(ControlChars.NewLine) Then
                btnCreate.Enabled = False
                lbWarning.Text = "Name Must Not Contain: / \ . : ? * < >"
                lbWarning.Show()
            Else
                lbWarning.Hide()
                btnCreate.Enabled = True
                If checkproj Then
                    If FileIO.FileSystem.DirectoryExists(_3Modules.General.CurWorkDir.Path & "\" & tbName.Text) Then
                        If Not tbName.Text = CheckProjIgnore Then
                            lbWarning.Text = "This Name is Already Taken!"
                            lbWarning.Show()
                            btnCreate.Enabled = False
                        End If
                    Else
                        lbWarning.Hide()
                        btnCreate.Enabled = True
                    End If
                End If
            End If
        End Sub


        Private Sub frmTextInput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Label1.Text = Me.Text
            btnCreate.Text = oktext
            Label2.Text = desctext
            tbName.Text = defaultresult
        End Sub

        Dim moving As Boolean = False
        Dim ppt As New Point
        Private Sub me_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, lbWarning.MouseDown, Label2.MouseDown, Label1.MouseDown
            moving = True
            ppt = e.Location
        End Sub

        Private Sub me_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, lbWarning.MouseMove, Label2.MouseMove, Label1.MouseMove
            If moving Then
                Me.Location = New Point(Me.Left + e.X - ppt.X, Me.Top + e.Y - ppt.Y)
            End If
        End Sub

        Private Sub me_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, lbWarning.MouseUp, Label2.MouseUp, Label1.MouseUp
            moving = False
        End Sub

        Private Sub btnCreate_EnableChanged(sender As Object, e As EventArgs) Handles btnCreate.EnabledChanged, btnCancel.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(100, 100, 100)
            End If
        End Sub

        Private Sub diagTextInput_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub
    End Class
End Namespace