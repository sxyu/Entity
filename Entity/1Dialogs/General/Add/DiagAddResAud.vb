Imports Entity._1Dialogs.General
Imports Entity._1Dialogs.General.Selectors
Imports Entity._1Dialogs.Loading
Imports Entity._3Modules

Namespace _1Dialogs.General.Add

    Public Class DiagAddResAud
        Public Result As String
        Public Resname As String
        Public OrigFileName As String = ""
        Dim _changed As Boolean = False
        Dim _curImage As Bitmap
        Dim _curNormimage As Bitmap
        Public RealPathHidden As Boolean = False
        Dim _hiddenFilePath As String = ""
        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, btnClose.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub tbPath_KeyDown(sender As Object, e As KeyEventArgs) Handles tbPath.KeyDown
            e.SuppressKeyPress = True
        End Sub

        Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
            Using diag As New OpenFileDialog
                With diag
                    .RestoreDirectory = True
                    .Title = "Select Audio File"
                    .Filter = AudioFilter
                    .Multiselect = False
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        _changed = True
                        tbPath.Text = .FileName
                        tbResName.Text = IO.Path.GetFileNameWithoutExtension(.FileName)
                    End If
                End With
            End Using
        End Sub

        Private Sub tbResName_TextChanged(sender As Object, e As EventArgs) Handles tbResName.TextChanged
            If String.IsNullOrEmpty(tbResName.Text.Trim) Then
                btnAdd.Enabled = False
                lbWarning.Text = "Name Cannot be Empty!"
                lbWarning.Show()
            ElseIf tbResName.Text.Contains("/") Or tbResName.Text.Contains("\") Or tbResName.Text.Contains(".") Or tbResName.Text.Contains(":") _
                   Or tbResName.Text.Contains("?") Or tbResName.Text.Contains("*") Or tbResName.Text.Contains("''") Or tbResName.Text.Contains("|") _
                   Or tbResName.Text.Contains("<") Or tbResName.Text.Contains(">") Or tbResName.Text.Contains(",") Or tbResName.Text.Contains(";") _
                   Or tbResName.Text.Contains(ControlChars.NewLine) Then
                btnAdd.Enabled = False
                lbWarning.Text = "Name Must Not Contain: / \ , . : ; ? * < >"
                lbWarning.Show()
            ElseIf tbResName.Text = "_external" Then
                lbWarning.Text = "Name Must Not Be ''_external''"
                lbWarning.Show()
            Else
                If tbPath.Text <> "" Then
                    If FileIO.FileSystem.FileExists(CurProject.ResPath & "\" & tbResName.Text & ".wav") Or _
                       FileIO.FileSystem.FileExists(CurProject.ResPath & "\" & tbResName.Text & ".mp3") Then
                        If tbResName.Text = OrigFileName And OrigFileName <> "" Then
                            btnAdd.Enabled = True
                            lbWarning.Hide()
                        Else
                            btnAdd.Enabled = False
                            lbWarning.Text = "Resource With Same Name Exists!"
                            lbWarning.Show()
                        End If
                    Else
                        btnAdd.Enabled = True
                        _changed = True
                        lbWarning.Hide()
                    End If
                End If
            End If
        End Sub

        Private Sub tbPath_TextChanged(sender As Object, e As EventArgs) Handles tbPath.TextChanged
            If FileIO.FileSystem.FileExists(tbPath.Text) And tbPath.Text <> "" Then
                If lbWarning.Visible = False And tbResName.Text <> "" Then
                    btnAdd.Enabled = True
                End If
            Else
                btnAdd.Enabled = False
            End If
        End Sub

        Dim moving As Boolean = False
        Dim ppt As New Point
        Private Sub frmAddResImg_MouseDown(sender As Object, e As MouseEventArgs) Handles _
                                                                                      MyBase.MouseDown, lbWarning.MouseDown, lbResName.MouseDown, lbSource.MouseDown, title.MouseDown, tbPath.MouseDown
            moving = True
            ppt = e.Location
        End Sub
        Private Sub frmAddResImg_MouseMove(sender As Object, e As MouseEventArgs) Handles _
                                                                                      MyBase.MouseMove, lbWarning.MouseMove, lbResName.MouseMove, lbSource.MouseMove, title.MouseMove, tbPath.MouseMove
            If moving Then
                Me.Location = New Point(Me.Left + e.X - ppt.X, Me.Top + e.Y - ppt.Y)
            End If
        End Sub
        Private Sub frmAddResImg_MouseUp(sender As Object, e As MouseEventArgs) Handles _
                                                                                    MyBase.MouseUp, lbWarning.MouseUp, lbResName.MouseUp, lbSource.MouseUp, title.MouseUp, tbPath.MouseUp
            moving = False
        End Sub
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            If _changed Then
                FrmProcessing.audio = True
                FrmProcessing.Show()
                FrmProcessing.Refresh()
            End If
            WaitTmr.Start()
        End Sub

        Private Sub tbPath_Enter(sender As Object, e As EventArgs) Handles tbPath.Enter
            btnBrowse.Focus()
        End Sub


        Private Sub btnCreate_EnableChanged(sender As Object, e As EventArgs) Handles btnAdd.EnabledChanged, btnCancel.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(100, 100, 100)
            End If
        End Sub

        Private Sub btnYoutube_MouseEnter(sender As Object, e As EventArgs) Handles btnYoutube.MouseEnter, btnAudLib.MouseEnter
            DirectCast(sender, Button).FlatAppearance.BorderSize = 1
        End Sub
        Private Sub btnYoutube_MouseLeave(sender As Object, e As EventArgs) Handles btnYoutube.MouseLeave, btnAudLib.MouseLeave
            DirectCast(sender, Button).FlatAppearance.BorderSize = 0
        End Sub

        Private Sub btnYoutube_Click(sender As Object, e As EventArgs) Handles btnYoutube.Click
            If My.Computer.Network.IsAvailable Then
                Using diag As New diagYoutube
                    With diag
                        If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                            RealPathHidden = True
                            tbPath.Enabled = False
                            tbPath.Text = .ytbUrl
                            tbResName.Text = .result
                            btnBrowse.Enabled = False
                            _hiddenFilePath = FileIO.SpecialDirectories.Temp & "\" & .result & ".mp3"
                            btnYoutube.Hide()
                            btnAudLib.Hide()
                        End If
                    End With
                End Using
            Else
                MsgBox("Please connect to internet to convert Youtube videos.", MsgBoxStyle.Exclamation Or MsgBoxStyle.ApplicationModal _
                                                                                Or MsgBoxStyle.MsgBoxSetForeground, "No Internet Connection")
            End If
        End Sub



        Private Sub diagAddResAud_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If IO.Directory.Exists(GlobalPath) Then
                btnAudLib.Show()
            End If
        End Sub

        Private Sub btnAudLib_Click(sender As Object, e As EventArgs) Handles btnAudLib.Click
            Using diag As New diagGlobalRes
                With diag
                    .viewImageRes = False
                    If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                        RealPathHidden = True
                        tbPath.Text = "(Global Resource)"
                        tbPath.Enabled = False
                        btnBrowse.Enabled = False
                        _hiddenFilePath = .result
                        tbResName.Text = IO.Path.GetFileNameWithoutExtension(.result).Replace(",", " ").Replace(".", " ")
                        btnYoutube.Hide()
                        btnAudLib.Hide()
                    End If
                End With
            End Using
        End Sub

        Private Sub btnAudLib_Paint(sender As Object, e As PaintEventArgs) Handles btnAudLib.Paint
            Dim bWid As Integer = btnAudLib.FlatAppearance.BorderSize
            Dim rect As New Rectangle(bWid, bWid, e.ClipRectangle.Width - 2 * bWid, _
                                      e.ClipRectangle.Height - 2 * bWid)
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(129, 137, 153)), rect)
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            Dim strloc As New StringFormat()
            strloc.Alignment = StringAlignment.Center
            strloc.LineAlignment = StringAlignment.Center
            e.Graphics.DrawString("Global" & vbCrLf & "Res", New Font("Segoe UI SemiLight", CSng((e.ClipRectangle.Height - bWid * 2) / 9 * 2)), Brushes.White, rect, strloc)
        End Sub

        Private Sub WaitTmr_Tick(sender As Object, e As EventArgs) Handles WaitTmr.Tick
            WaitTmr.Stop()
            Resname = tbResName.Text
            If RealPathHidden Then
                Me.Result = _hiddenFilePath
            Else
                Me.Result = tbPath.Text
            End If
            Me.Resname = tbResName.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub DiagAddResAud_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub
    End Class
End Namespace