Imports Entity._3Modules
Imports Entity._4Classes.Events

Namespace _0App.SettingsViews
    Public Class Svw0Projection
        Private WithEvents WScreenChangedEvent As ScreenChangedEvent = ScreenChangedEvent.Instance
        Private _identifyForms As New List(Of Form)
        Private _idFormsShown As Boolean = False
        Private Sub svw0Projection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If My.Settings.secondaryScr = "MANUAL" Then
                pnlMan.Visible = True
                lv.Visible = False
                btnID.Hide()
                btnProjection.Hide()
                btnMan.Text = "&Auto Setup"
                numRezHoriz.Value = My.Settings.secondaryScrRez.Width
                numRezVert.Value = Math.Abs(My.Settings.secondaryScrRez.Height)
                My.Settings.secondaryScr = "MANUAL"
                My.Settings.Save()
            End If
            LoadLv()
        End Sub
        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
                For Each f As Form In _identifyForms
                    f.Close()
                Next
                _identifyForms.Clear()
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub
        Private Sub LoadLv()
            lv.Items.Clear()
            For Each f As Form In _identifyForms
                f.Close()
            Next
            _identifyForms.Clear()
            Dim toAdd As New List(Of ListViewItem)
            For Each scr As Screen In Screen.AllScreens
                Using bmp As New Bitmap(scr.Bounds.Width, scr.Bounds.Height)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        g.CopyFromScreen(scr.Bounds.Location, New Point(0, 0), scr.Bounds.Size)
                        imgLst.Images.Add(scr.DeviceName, New Bitmap(GetThumbnail(bmp)))
                    End Using
                End Using
                Dim li As New ListViewItem(scr.DeviceName.Replace("\\.\", "").Trim)
                li.Tag = scr.Bounds.Size
                If scr.Primary Then li.SubItems.Add("Show Control")
                If scr.DeviceName = My.Settings.secondaryScr Then li.SubItems.Add("Default Projector")
                li.ImageKey = scr.DeviceName
                toAdd.Add(li)
                Dim frm As New Form
                frm.FormBorderStyle = FormBorderStyle.None
                frm.StartPosition = FormStartPosition.Manual
                frm.Tag = scr.DeviceName
                frm.Left = CInt(scr.Bounds.X + scr.Bounds.Width / 2)
                frm.Top = CInt(scr.Bounds.Y + scr.Bounds.Height / 2)
                frm.BackColor = Color.SlateBlue
                frm.ShowIcon = False
                frm.ShowInTaskbar = False
                frm.TopMost = True
                Dim lb As New Label
                lb.Text = li.Text
                lb.Font = New Font("Segoe UI SemiLight", 60)
                lb.ForeColor = Color.White 'Color.FromArgb(64, 64, 64)
                lb.Left = 0
                lb.Top = 0
                lb.AutoSize = True
                frm.Controls.Add(lb)
                frm.Width = lb.Width
                frm.Height = lb.Height
                frm.Left -= frm.Width \ 2
                frm.Top = CInt(frm.Top - (frm.Height / 2))
                _identifyForms.Add(frm)
            Next
            lv.Items.AddRange(toAdd.ToArray)
        End Sub

        Sub scrChanged() Handles WScreenChangedEvent.SecondaryScreenChanged
            LoadLv()
            If _idFormsShown Then
                btnID.PerformClick()
            End If
        End Sub
        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            If lv.SelectedItems.Count <> 1 Then
                btnProjection.Enabled = False
            Else
                If lv.SelectedItems(0).SubItems.Count > 1 Then
                    If lv.SelectedItems(0).SubItems(1).Text = "Show Control" Then
                        btnProjection.Enabled = False
                    Else
                        btnProjection.Enabled = True
                    End If
                Else
                    btnProjection.Enabled = True
                End If
            End If
        End Sub

        Private Sub btnProjection_EnabledChanged(sender As Object, e As EventArgs) Handles btnProjection.EnabledChanged
            If btnProjection.Enabled = False Then
                btnProjection.BackColor = Color.fromArgb(100, 100, 100)
            Else
                btnProjection.BackColor = Color.Gainsboro
            End If
        End Sub

        Private Sub btnProjection_Click(sender As Object, e As EventArgs) Handles btnProjection.Click
            lv.Focus()
            If lv.SelectedItems.Count > 0 Then
                My.Settings.secondaryScr = lv.SelectedItems(0).ImageKey
                My.Settings.secondaryScrWH = DirectCast(lv.SelectedItems(0).Tag, Size).Width / DirectCast(lv.SelectedItems(0).Tag, Size).Height
                My.Settings.secondaryScrRez = DirectCast(lv.SelectedItems(0).Tag, Size)
                My.Settings.Save()
                If DirectCast(lv.SelectedItems(0).Tag, Size) <> My.Settings.secondaryScrRez Then
                    clearProjectorSettings()
                    MsgBox("Your projector resolution has changed. You may need to re-crop your image resources to fit the new resolution.", _
                           MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground, "Projector Changed")
                End If
                LoadLv()
                CheckSecondaryScreen()
            End If
        End Sub

        Private Sub btnID_Click(sender As Object, e As EventArgs) Handles btnID.Click
            If _idFormsShown Then
                btnID.BackColor = Color.Gainsboro
                btnID.ForeColor = Color.Black
                For Each f As Form In _identifyForms
                    f.Hide()
                Next
                lv.Focus()
                _idFormsShown = False
            Else
                btnID.BackColor = Color.MediumSlateBlue
                btnID.ForeColor = Color.White
                For Each f As Form In _identifyForms
                    f.Show()
                Next
                lv.Focus()
                _idFormsShown = True
            End If
        End Sub

        Private Sub btnMan_Click(sender As Object, e As EventArgs) Handles btnMan.Click
            pnlMan.Visible = Not pnlMan.Visible
            lv.Visible = Not lv.Visible
            btnID.Visible = Not btnID.Visible
            btnProjection.Visible = Not btnProjection.Visible
            If btnMan.Text = "&Manual Setup" Then
                btnMan.Text = "&Auto Setup"
                numRezHoriz.Value = My.Settings.secondaryScrRez.Width
                numRezVert.Value = Math.Abs(My.Settings.secondaryScrRez.Height)
                My.Settings.secondaryScr = "MANUAL"
                My.Settings.Save()
            Else
                btnMan.Text = "&Manual Setup"
                LoadLv()
            End If
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If numRezHoriz.Value > 0 And numRezVert.Value > 0 Then
                If My.Settings.secondaryScr = "MANUAL" Then
                    If numRezHoriz.Value <> My.Settings.secondaryScrRez.Width Or numRezVert.Value <> My.Settings.secondaryScrRez.Height Then
                        My.Settings.secondaryScrRez = New Size(CInt(numRezHoriz.Value), CInt(numRezVert.Value))
                        My.Settings.secondaryScrWH = numRezHoriz.Value / numRezVert.Value
                        clearProjectorSettings()
                        MsgBox("Your projector resolution has changed. You may need to re-crop your image resources to fit the new resolution.", _
                               MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground, "Projector Changed")
                    End If
                End If
            End If
        End Sub
    End Class
End Namespace