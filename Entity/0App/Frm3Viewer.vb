Imports System.IO
Imports Entity._0App
Imports Microsoft.VisualBasic.FileIO
Imports Entity._0App.Views
Imports Entity._1Dialogs.Loading
Imports Entity._1Dialogs.General.Selectors
Imports Entity._3Modules
Imports Entity._4Classes.Types

Namespace _0App
    Public Class Frm3Viewer

        Private Sub Frm3Viewer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            FrmProcessing.fc = True
            FrmProcessing.Close()
            _6Misc.SecondMonitor.CheckExit()
            _1Dialogs.Popups.DiagCOM.Close()
            If OpenFormsCount <= 1 Then
                DmxEngine.abortThread()
            End If
        End Sub

        Private Sub Frm3Viewer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
            Dim vw As vw2Audio = DirectCast(ViewCache(2), vw2Audio)
            If CurView = EntityView.Audio Then
                Select Case e.KeyCode
                    Case Keys.Left
                        If Not vw.tbName.Focused Then
                            vw.btnEarlier_MDown(vw.btnEarlier, New System.EventArgs())
                        End If
                    Case Keys.Right
                        If Not vw.tbName.Focused Then
                            vw.btnLater_MDown(vw.btnLater, New System.EventArgs)
                        End If
                End Select
            End If
        End Sub

        Private Sub frm3Viewer_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.D1
                        tabHome.PerformClick()
                    Case Keys.D2
                        tabSubs.PerformClick()
                    Case Keys.D3
                        tabAud.PerformClick()
                    Case Keys.D4
                        tabImg.PerformClick()
                    Case Keys.D5
                        tabCues.PerformClick()
                    Case Keys.D6, Keys.F5
                        tabStart.PerformClick()
                    Case Keys.Delete
                        If e.Shift Then
                            btnAppChProj.PerformClick()
                        End If
                End Select
            Else
                Dim vw As vw2Audio = DirectCast(ViewCache(2), vw2Audio)
                If CurView = EntityView.Audio Then
                    If Not vw.tbName.Focused Then
                        Select Case e.KeyCode
                        Case Keys.Space
                            vw.btnPlay.PerformClick()
                        Case Keys.Left
                            vw.btnEarlier_MouseUp(vw.btnEarlier, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 1, 1, 0))
                        Case Keys.Right
                            vw.btnEarlier_MouseUp(vw.btnLater, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 1, 1, 0))
                        Case Keys.R
                            If Not e.Alt Then
                                vw.btnStop.PerformClick()
                            End If
                        End Select
                    End If
                End If
            End If
        End Sub

        Private Sub FrmViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Icon = My.Resources.en
            Dim projstr As String = CurProject.Name.Replace("&", "&&").Trim
            If projstr.Length > 35 Then
                projstr = projstr.Remove(35)
                projstr &= "..."
            End If
            lbShow.Text = projstr
            tbEdit.Left = lbShow.Left
            tbEdit.Width = lbShow.Width + 10
            btnEdit.Left = tbEdit.Right - 1
            If Not FileSystem.DirectoryExists(CurWorkDir.Path) Then
                FileSystem.CreateDirectory(CurWorkDir.Path)
            End If
            If Cues.Count > 0 Then tabStart.Enabled = True Else tabStart.Enabled = False
            System.GC.Collect()
        End Sub

        Private Sub frmProjs_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
            If Me.WindowState = FormWindowState.Normal Then
                Me.WindowState = FormWindowState.Maximized
            End If
        End Sub

        Private Sub btnMin_Click(sender As Object, e As EventArgs)
            Me.WindowState = FormWindowState.Minimized
        End Sub


        Private Sub btnAppChProj_Click(sender As Object, e As EventArgs) Handles btnAppChProj.Click
            _6Misc.SecondMonitor.pb.Image = Nothing
            System.GC.Collect()
            Frm0Loading.DontInit = True
            Frm0Loading.Show()
            Me.Close()
        End Sub

        Private Sub topBar_Paint(sender As Object, e As PaintEventArgs)
            'paint logo
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(129, 137, 153)), 10, 9, 32, 32)
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            e.Graphics.DrawString("En", New Font("Segoe UI SemiLight", 15), Brushes.White, 12, 11)
        End Sub
        'view changers
        Private Sub tabImg_Click(sender As Object, e As EventArgs) Handles tabImg.Click
            ChangeView(EntityView.Images)
        End Sub
        Private Sub tabHome_Click(sender As Object, e As EventArgs) Handles tabHome.Click
            ChangeView(EntityView.Home)
        End Sub

        Private Sub tabAud_Click(sender As Object, e As EventArgs) Handles tabAud.Click
            ChangeView(EntityView.Audio)
        End Sub

        Private Sub tabSubs_Click(sender As Object, e As EventArgs) Handles tabSubs.Click
            ChangeView(EntityView.Lights)
        End Sub

        Private Sub tabCues_Click(sender As Object, e As EventArgs) Handles tabCues.Click
            ChangeView(EntityView.Cues)
        End Sub

        Private Sub tabSubs_Enter(sender As Object, e As EventArgs) Handles tabSubs.Enter, tabImg.Enter, tabHome.Enter, tabCues.Enter, tabAud.Enter
            viewer.Focus()
        End Sub
        Private Sub lbShow_SizeChanged(sender As Object, e As EventArgs) Handles lbShow.SizeChanged
            tbEdit.Left = lbShow.Left
            tbEdit.Width = lbShow.Width + 10
            btnEdit.Left = tbEdit.Right
        End Sub

        Private Sub btnEdit_MClick(sender As Object, e As MouseEventArgs) Handles btnEdit.MouseUp
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If lbShow.Visible Then
                    btnEdit.BackColor = Color.SteelBlue
                    tbEdit.Text = lbShow.Text
                    lbShow.Hide()
                    btnEdit.Left = tbEdit.Right
                    tbEdit.Show()
                    tbEdit.SelectionStart = 0
                    tbEdit.SelectionLength = 0
                    tbEdit.SelectionStart = tbEdit.Text.Length
                    tbEdit.Focus()
                Else
                    tbEdit.Text = tbEdit.Text.Trim
                    btnEdit.BackColor = Color.FromArgb(140, 140, 140)
                    tbEdit.Hide()
                    lbShow.Show()
                    If Not tbEdit.Text = lbShow.Text Then
                        Dim view As Integer = CurView
                        'dispose all views to make sure the dir is not being used
                        For i As Integer = 0 To ViewCache.Length - 1
                            Try
                                ViewCache(i).Dispose()
                            Catch ex As Exception
                            End Try
                        Next
                        'do the renaming

                        CurProject.Name = tbEdit.Text
                    End If
                    lbShow.Text = tbEdit.Text
                    btnEdit.Left = tbEdit.Right
                End If
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                tbEdit.Text = tbEdit.Text.Trim
                btnEdit.BackColor = Color.fromArgb(120, 120, 120)
                tbEdit.Hide()
                lbShow.Show()
                btnEdit.Left = lbShow.Right + 10
            End If
        End Sub

        Private Sub tbEdit_TextChanged(sender As Object, e As EventArgs) Handles tbEdit.TextChanged
            Using tmp As New Bitmap(1, 1)
                Using g As Graphics = Graphics.FromImage(tmp)
                    Dim ms As SizeF = g.MeasureString(tbEdit.Text, tbEdit.Font)
                    tbEdit.Width = CInt(ms.Width + 10)
                    btnEdit.Left = tbEdit.Right
                End Using
            End Using
            If tbEdit.SelectionStart >= 0 Then
                Dim curSel As Integer = tbEdit.SelectionStart
                tbEdit.SelectionStart = 0
                tbEdit.SelectionStart = curSel
            End If
            If String.IsNullOrEmpty(tbEdit.Text) Then
                lbWarning.Text = "Name Cannot be Empty!"
                lbWarning.Show()
                btnEdit.Enabled = False
            ElseIf tbEdit.Text.Contains("/") Or tbEdit.Text.Contains("\") Or tbEdit.Text.Contains(".") Or tbEdit.Text.Contains(":") _
                   Or tbEdit.Text.Contains("?") Or tbEdit.Text.Contains("*") Or tbEdit.Text.Contains("''") Or tbEdit.Text.Contains("|") _
                   Or tbEdit.Text.Contains("<") Or tbEdit.Text.Contains(">") Or tbEdit.Text.Contains(ControlChars.NewLine) Then
                btnEdit.Enabled = False
                lbWarning.Text = "Name Must Not Contain: / \ . : ? * < >"
                lbWarning.Show()
            ElseIf FileIO.FileSystem.DirectoryExists(CurWorkDir.Path & "\" & tbEdit.Text) Then
                If tbEdit.Text = lbShow.Text Then
                    lbWarning.Hide()
                    btnEdit.Enabled = True
                Else
                    lbWarning.Text = "This Name is Already Taken!"
                    lbWarning.Show()
                    btnEdit.Enabled = False
                End If
            Else
                lbWarning.Hide()
                btnEdit.Enabled = True
            End If
        End Sub

        Private Sub tbEdit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbEdit.KeyPress
            If btnEdit.Enabled Then
                If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                    btnEdit_MClick(btnEdit, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub Frm3Viewer_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            Dim prevFlag As Boolean = HasSecondMonitor
            CheckSecondaryScreen()
            If prevFlag <> HasSecondMonitor Then
                If ViewCache IsNot Nothing AndAlso ViewCache(3) IsNot Nothing Then
                    DirectCast(ViewCache(3), vw3Images).UpdateControls()
                End If
                For Each frm As Form In My.Application.OpenForms
                    If frm.Tag IsNot Nothing Then
                        If CStr(frm.Tag) = "imgsel" Then
                            DirectCast(frm, DiagSelectImage).UpdateControls()
                        End If
                    End If
                Next
            End If
        End Sub

        Private Sub tabStart_Click(sender As Object, e As EventArgs) Handles tabStart.Click
            If Cues.Count > 0 Then
                Frm5ShowUI.Show()
                Me.Close()
            Else
                MsgBox("Please add at least one cue before presenting.", _
                       MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground, "Can't Start Show")
            End If
        End Sub

        Private Sub tabStart_EnabledChanged(sender As Object, e As EventArgs) Handles tabStart.EnabledChanged
            If tabStart.Enabled Then
                tabStart.BackColor = Color.MediumSeaGreen
            Else
                tabStart.BackColor = Color.FromArgb(100, 100, 100)
            End If
        End Sub
    End Class
End Namespace