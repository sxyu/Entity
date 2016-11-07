Imports Entity._3Modules
Imports Entity._4Classes.Events
Imports Entity._4Classes.Types

Namespace _0App.InitialSetup
    Public Class IFm0ProjectionA
        Inherits IFmBase
        Private WScreenChangedEvent As ScreenChangedEvent = ScreenChangedEvent.Instance
        Private _identifyForms As New List(Of Form)
        Private _idFormsShown As Boolean = False
        Private _selTitle As String = "Which of these is your (backdrop) projector?"
        Private _selDesc As String = "Please select the one and click the bottom right button to continue." & vbCrLf & _
                                     "If you cannot connect to a projector right now," & vbCrLf & _
                                     "click the manual setup button to input required values by hand."

        Private _connTitle As String = "You don't have any projectors connected!"
        Private _connDesc As String = "Please connect to one, even if it's just for a minute." & vbCrLf & _
                                      "We just need to read some settings from the it." & vbCrLf & _
                                      "If you cannot connect to a projector right now," & vbCrLf & _
                                      "click the manual setup button to input required values by hand."

        Private Sub svw0Projection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            LoadLv()
            content.Left = CInt(Me.Width / 2 - content.Width / 2)
            content.Top = CInt(Me.Height / 2 - content.Height / 2)
            lv.Left = CInt(content.Width / 2 - lv.Width / 2)
            lbDesc.Left = CInt(content.Width / 2 - lbDesc.Width / 2)
            lbTitle.Left = CInt(content.Width / 2 - lbTitle.Width / 2)
            AddHandler WScreenChangedEvent.SecondaryScreenChanged, AddressOf ScrChanged
            Me.Icon = My.Resources.en 'set icon
            Me.ForceClose = False
            Me.Fade()
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
                If scr.Primary Then Continue For
                Using bmp As New Bitmap(scr.Bounds.Width, scr.Bounds.Height)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        g.CopyFromScreen(scr.Bounds.Location, New Point(0, 0), scr.Bounds.Size)
                        imgLst.Images.Add(scr.DeviceName, New Bitmap(GetThumbnail(bmp, , , Color.fromArgb(100, 100, 100))))
                    End Using
                End Using
                Dim li As New ListViewItem(scr.DeviceName.Replace("\\.\", "").Trim)
                li.Tag = scr.Bounds.Size
                'If scr.DeviceName = My.Settings.secondaryScr Then li.SubItems.Add("Default Projector")
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

        Sub ScrChanged()
            If Me.Visible Then
                LoadLv()
                If Screen.AllScreens.Length <= 1 Then
                    FrmCinematic.BackColor = Color.fromArgb(100, 100, 100)
                    IFm0ProjectionC.Show()
                    Me.Close()
                End If
                If _idFormsShown Then
                    btnID.PerformClick()
                End If
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
                btnProjection.BackColor = Color.fromArgb(120, 120, 120)
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
                    ClearProjectorSettings()
                End If
                FrmCinematic.BlankOut = False
                FrmCinematic.StartScene = 8
                FrmCinematic.ReInit()
                Me.Close()
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
        Protected Friend Overrides Sub Base_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If ForceClose Then
                _6Misc.SecondMonitor.CheckExit()
                _1Dialogs.Popups.DiagCOM.Close()
                If OpenFormsCount <= 1 Then
                    dmxEngine.abortThread()
                End If
                RemoveHandler WScreenChangedEvent.SecondaryScreenChanged, AddressOf ScrChanged
            Else
                e.Cancel = True
                Me.Fade(True)
                If FrmCinematic.BlankOut And OpenFormsCountNo2M < 3 Then
                    FrmCinematic.Close()
                End If
            End If
        End Sub
        Private Sub btnMan_Click(sender As Object, e As EventArgs) Handles btnMan.Click
            FrmCinematic.BackColor = Color.fromArgb(100, 100, 100)
            IFm0ProjectionM.Show()
            Me.Close()
        End Sub

        Private Sub IFm0ProjectionA_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
            CheckSecondaryScreen()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            If Me.Opacity = 1 Then Me.Close()
        End Sub
    End Class
End Namespace