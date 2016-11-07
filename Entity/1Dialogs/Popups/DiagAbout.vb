Imports Entity._3Modules
Namespace _1Dialogs.Popups
    Public Class DiagAbout

        Private Enum ReleaseType
            Alpha = 0
            Beta
            Stable
        End Enum
        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
        Dim _moving As Boolean = False
        Dim _ppt As New Point
        Dim _drawIdx As Integer = 0
        Private Const RelType As ReleaseType = ReleaseType.Beta
        Private Sub DiagAbout_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            lbName.Text = My.Application.Info.ProductName
            lbVer.Text = "Version " & My.Application.Info.Version.ToString & " " & RelType.ToString()
            lbCopyright.Text = My.Application.Info.Copyright
            tbCredits.Text = My.Resources.credits
            cbCheckUpd.Checked = My.Settings.autoUpdateCheck
        End Sub
        Private Sub diagImageView_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, title.MouseDown, pnlBody.MouseDown, _
                                                                                           pnlInfo.MouseDown, lbName.MouseDown, lbCopyright.MouseDown, lbVer.MouseDown, lbCredits.MouseDown, lbDotNet.MouseDown
            If e.Button <> Windows.Forms.MouseButtons.XButton1 And e.Button <> Windows.Forms.MouseButtons.XButton2 Then
                _moving = True
                _ppt = e.Location
            End If
        End Sub

        Private Sub diagImageView_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, title.MouseMove, pnlBody.MouseMove, _
                                                                                           pnlInfo.MouseMove, lbName.MouseMove, lbCopyright.MouseMove, lbVer.MouseMove, lbCredits.MouseMove, lbDotNet.MouseMove
            If _moving Then
                Me.Location = New Point(Me.Left + e.X - _ppt.X, Me.Top + e.Y - _ppt.Y)
            End If
        End Sub

        Private Sub diagImageView_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, title.MouseUp, _
                                                                                         pnlInfo.MouseUp, lbName.MouseUp, lbCopyright.MouseUp, lbVer.MouseUp, lbCredits.MouseUp, lbDotNet.MouseUp
            _moving = False
        End Sub
        Private Sub pnlBody_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlBody.MouseUp
            _moving = False
            If e.Button = Windows.Forms.MouseButtons.XButton1 Then
                _drawIdx += 1
                If _drawIdx > 2 Then _drawIdx = 0
                pnlBody.Invalidate()
            ElseIf e.Button = Windows.Forms.MouseButtons.XButton2 Then
                _drawIdx -= 1
                If _drawIdx < 0 Then _drawIdx = 2
                pnlBody.Invalidate()
            End If
        End Sub

        Private Sub pnlBody_Paint(sender As Object, e As PaintEventArgs) Handles pnlBody.Paint
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            Using whiteBr As New SolidBrush(Color.White)
                Using sUI_s As New Font("Segoe UI SemiLight", 18)
                    Select Case _drawIdx
                        Case 0
                            'draw logo
                            Using clrBr As New SolidBrush(Color.FromArgb(129, 137, 153))
                                Using sUI As New Font("Segoe UI SemiLight", 21)
                                    e.Graphics.FillRectangle(clrBr, 10, 10, 42, 42)
                                    e.Graphics.DrawString("En", sUI, whiteBr, 12, 12)
                                End Using
                            End Using
                            e.Graphics.DrawString(My.Application.Info.ProductName, sUI_s, whiteBr, 60, 14)
                        Case 1
                            'draw hawk
                            e.Graphics.FillRectangle(whiteBr, 10, 10, 42, 42)
                            e.Graphics.DrawImage(My.Resources.U_Hill_Logo, 10, 10, 42, 42)
                            e.Graphics.DrawString("The University Hill Theatre Department", sUI_s, whiteBr, 60, 14)
                        Case 2
                            'draw Al
                            Using clrBr As New SolidBrush(Color.FromArgb(218, 122, 40))
                                Using sUI As New Font("Segoe UI SemiLight", 21)
                                    e.Graphics.FillRectangle(clrBr, 10, 10, 42, 42)
                                    e.Graphics.DrawString("Al", sUI, whiteBr, 14, 12)
                                End Using
                            End Using
                            e.Graphics.DrawString("Lead Programmer: Alex Yu", sUI_s, whiteBr, 60, 14)
                    End Select
                End Using
            End Using
        End Sub


        Private Sub tbCredits_TextChanged(sender As Object, e As EventArgs) Handles tbCredits.TextChanged
            tbCredits.Text = My.Resources.credits
        End Sub

        Private Sub tbCredits_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbCredits.KeyPress
            e.Handled = True 'suppress all keypress events
        End Sub
        Private Sub tbCredits_KeyUp(sender As Object, e As KeyEventArgs) Handles tbCredits.KeyUp
            If e.Control And e.KeyCode = Keys.C Then 'handle the copy action separately
                tbCredits.Copy()
            End If
        End Sub

        Private Sub btnCPOL_Click(sender As Object, e As EventArgs) Handles btnCPOL.Click
            Using diag As New DiagWebViewer("The Code Project Open License (CPOL) 1.02", My.Resources.CPOL)
                pnlInfo.Focus()
                diag.ShowDialog()
            End Using
        End Sub

        Private Sub btnMSPL_Click(sender As Object, e As EventArgs) Handles btnMSPL.Click
            Using diag As New DiagWebViewer("The Microsoft Public License (MS-PL)", My.Resources.MSPL)
                pnlInfo.Focus()
                diag.ShowDialog()
            End Using
        End Sub

        Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
            If My.Computer.Network.IsAvailable Then
                If Not updateBW.IsBusy Then
                    updateBW.RunWorkerAsync()
                End If
            Else
                MsgBox("You are not connected to the internet." & vbCrLf & "Connect to a network to check for update.", MsgBoxStyle.Information Or _
                                                                                                                        MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.SystemModal, "Network Unavailable")
            End If
        End Sub

        Private Sub updateBW_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles updateBW.DoWork
            Dim result As Integer = checkUpdate()
            If result = 0 Then
                MsgBox("You are already running the latest version of the Entity System.", MsgBoxStyle.Information Or _
                                                                                           MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.SystemModal, "No Update Required")
            ElseIf result < 0 Then
                MsgBox("We cannot check for updates at the moment. Please try again later.", MsgBoxStyle.Exclamation Or _
                                                                                             MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.SystemModal, "Update Checking Failed")
            End If
        End Sub

        Private Sub cbCheckUpd_CheckedChanged(sender As Object, e As EventArgs) Handles cbCheckUpd.CheckedChanged
            My.Settings.autoUpdateCheck = cbCheckUpd.Checked
            My.Settings.Save()
        End Sub

        Private Sub btnContacts_Click(sender As Object, e As EventArgs) Handles btnContacts.Click
            Using diag As New DiagWebViewer("Contact Us", My.Resources.contacts)
                pnlInfo.Focus()
                diag.ShowDialog()
            End Using
        End Sub

        Private Sub DiagAbout_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub


    End Class
End Namespace