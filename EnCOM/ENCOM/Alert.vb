Public Class Alert
    Public Title As String
    Public Content As String
    Public UserColor As Color = Color.White
    Private _TimeDisappear As Integer = 10
    Protected Overrides ReadOnly Property CreateParams() As CreateParams
        Get
            ' Turn on WS_EX_TOOLWINDOW style bit
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H80
            Return cp
        End Get
    End Property

    Private Sub Alert_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        Using br As New SolidBrush(UserColor)
            Using largeF As New Font("Segoe UI SemiLight", 14)
                e.Graphics.DrawString(Title, largeF, br, 14, 25)
            End Using
        End Using
        Using br As New SolidBrush(Color.WhiteSmoke)
            Using smallF As New Font("Segoe UI SemiLight", 10)
                Dim temp As String = ""
                Dim rows As String = ""
                Using bmp As New Bitmap(1, 1)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        For Each c As Char In Content
                            temp &= c
                            If g.MeasureString(temp, smallF).Width > Me.Width - 25 Then
                                rows &= temp & vbCrLf
                                temp = ""
                            End If
                            If rows.Split(CChar(vbCrLf)).Length > 3 Then
                                rows &= vbCrLf & "..."
                                Exit For
                            End If
                        Next
                    End Using
                End Using
                rows = rows.Trim
                rows &= vbCrLf & temp
                rows = rows.Trim
                Dim needDots As Boolean = False
                While rows.Split(CChar(vbCrLf)).Length > 3
                    rows = rows.Remove(rows.LastIndexOf(vbCrLf))
                    needDots = True
                End While
                If needDots And rows.EndsWith("...") = False Then
                    rows &= vbCrLf & "..."
                End If
                e.Graphics.DrawString(rows, smallF, br, 15, 50)
            End Using
        End Using
    End Sub
    Private Sub Alert_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _TimeDisappear = 10
    End Sub

    Private Sub timerDisappear_Tick(sender As Object, e As EventArgs) Handles timerDisappear.Tick
        If _TimeDisappear = 0 Then
            timerDisappear.Stop()
            _TimeDisappear = 10
            Me.Close()
        End If
        _TimeDisappear -= 1
    End Sub
    Public Sub ResetDisappearTime()
        _TimeDisappear = 10
        timerDisappear.Enabled = True
    End Sub
    Public Sub CheckExit()
        If My.Application.OpenForms.Count < 3 Then
            Me.Close()
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        timerDisappear.Stop()
        _TimeDisappear = 10
        Me.Close()
    End Sub

    Private Sub btnOK_Enter(sender As Object, e As EventArgs) Handles btnOK.Enter
        dummy.Focus()
        frmMain.toSend.Focus()
    End Sub

    Private Sub Alert_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Me.BackColor = Color.FromArgb(229, 122, 157)
        btnOK.BackColor = Me.BackColor
    End Sub

    Private Sub Alert_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Me.BackColor = Color.PaleVioletRed
        btnOK.BackColor = Me.BackColor
    End Sub

    Private Sub Alert_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        frmMain.BringToFront()
        frmMain.toSend.Focus()
    End Sub
End Class