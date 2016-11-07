Namespace _1Dialogs.General.Settings
    Public Class DiagLQuickSetup
        Public NamePattern As String = ""
        Public NumberOfLights As Integer
        Public Channels As New List(Of String)
        Public IsLvEmpty As Boolean
        Private OK(2) As Boolean

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click, btnClose.Click
            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnOK.Click
            If tbName.Text = "" Then Exit Sub
            If Not isLvEmpty Then
                If _
                    MsgBox(
                        "All of your current lighting configuration will be overwritten. Are you sure you want to continue?",
                        MsgBoxStyle.Exclamation Or MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.YesNo) <> MsgBoxResult.Yes _
                    Then
                    lv.Focus()
                    Exit Sub
                End If
            End If
            namePattern = tbName.Text
            numberOfLights = CInt(numNum.Value)
            For i As Integer = 0 To lv.Items.Count - 1
                channels.Add(lv.Items(i).SubItems(1).Text)
            Next
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

        Dim firstck As Boolean = False

        Private Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
            If String.IsNullOrEmpty(tbName.Text) Then
                If firstck Then
                    firstck = False
                    Exit Sub
                End If
                lbWarning.Text = "Name Format Cannot be Empty!"
                lbWarning.Show()
                btnOK.Enabled = False
                OK(0) = False
            Else
                If tbName.Text.Contains("%N%") Then
                    lbWarning.Hide()
                    btnOK.Enabled = True
                    OK(0) = True
                Else
                    lbWarning.Text = "The Format Must Contain %N%"
                    lbWarning.Show()
                    btnOK.Enabled = False
                    OK(0) = False
                End If
            End If
            checkIfOk()
        End Sub


        Dim moving As Boolean = False
        Dim ppt As New Point

        Private Sub me_MouseDown(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseDown, lbName.MouseDown, lbTitle.MouseDown _
                    , lbTag.MouseDown, lbNumbers.MouseDown
            moving = True
            ppt = e.Location
        End Sub

        Private Sub me_MouseMove(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseMove, lbName.MouseMove, lbTitle.MouseMove _
                    , lbTag.MouseMove, lbNumbers.MouseMove
            If moving Then
                Me.Location = New Point(Me.Left + e.X - ppt.X, Me.Top + e.Y - ppt.Y)
            End If
        End Sub

        Private Sub me_MouseUp(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseUp, lbName.MouseUp, lbTitle.MouseUp, lbTag.MouseUp,
                    lbNumbers.MouseUp
            moving = False
        End Sub

        Private Sub btnCreate_EnableChanged(sender As Object, e As EventArgs) _
            Handles btnOK.EnabledChanged, btnCancel.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(130, 130, 130)
            End If
        End Sub


        Private Sub btnRemCh_Click(sender As Object, e As EventArgs) Handles btnRemCh.Click
            If lv.SelectedItems.Count > 0 Then
                For Each i As ListViewItem In lv.SelectedItems
                    lv.Items.Remove(i)
                Next
                lvItemChanged()
            End If
        End Sub

        Private Sub btnAddCh_Click(sender As Object, e As EventArgs) Handles btnAddCh.Click
            Dim it As New ListViewItem()
            If lv.Items.Count > 0 Then
                it.Text = padZeros(CInt(lv.Items(lv.Items.Count - 1).Text) + 1)
            Else
                it.Text = "001"
            End If
            If lv.Items.Count < cmbChTag.Items.Count Then
                it.SubItems.Add(cmbChTag.Items(lv.Items.Count).ToString)
            Else
                it.SubItems.Add("Other")
            End If
            it.ImageIndex = 0
            For Each i As ListViewItem In lv.SelectedItems
                i.Selected = False
            Next
            lv.Items.Add(it)
            it.Selected = True
            lvItemChanged()
        End Sub

        Private Sub cmbChTag_TextChanged(sender As Object, e As EventArgs) Handles cmbChTag.TextChanged
            If cmbChTag.Text <> "" And lv.SelectedIndices.Count = 1 Then
                lv.SelectedItems(0).SubItems(1).Text = cmbChTag.Text
            End If
        End Sub

        Private Function padZeros(ByVal intToPad As Integer) As String
            Dim s As String = intToPad.ToString
            Select Case s.Length
                Case 0
                    Return "000"
                Case 1
                    Return "00" & s
                Case 2
                    Return "0" & s
                Case Else
                    Return s
            End Select
        End Function

        Private Sub LvItemChanged()
            If lv.Items.Count > 0 And lv.Items.Count <= 512 Then
                OK(2) = True
                numNum.Maximum = CDec(Math.Floor(512 / lv.Items.Count))
                CheckIfOk()
            Else
                OK(2) = False
                CheckIfOk()
            End If
        End Sub

        Private Sub CheckIfOk()
            If OK(0) And OK(1) And OK(2) Then
                btnOK.Enabled = True
            Else
                btnOK.Enabled = False
            End If
        End Sub


        Private Sub diagLQuickSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            OK(0) = True
            OK(1) = True
            OK(2) = True
            checkIfOk()
            lv.Columns(0).Width = 100
            lv.Columns(1).Width = CInt(lv.Width * 0.9 - 100)
        End Sub

        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            If lv.SelectedItems.Count <> 1 Then
                lbTag.Hide()
                cmbChTag.Hide()
                If lv.SelectedItems.Count < 1 Then btnRemCh.Enabled = False Else btnRemCh.Enabled = True
            Else
                lbTag.Show()
                cmbChTag.Text = lv.SelectedItems(0).SubItems(1).Text
                cmbChTag.Show()
                btnRemCh.Enabled = True
            End If
        End Sub

        Private Sub lv_KeyUp(sender As Object, e As KeyEventArgs) Handles lv.KeyUp
            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.A
                        For Each i As ListViewItem In lv.Items
                            i.Selected = True
                        Next
                    Case Keys.D
                        btnAddCh.PerformClick()
                End Select
            End If
            Select Case e.KeyCode
                Case Keys.Delete
                    btnRemCh.PerformClick()
                Case Keys.F2
                    cmbChTag.Focus()
            End Select
        End Sub

        Private Sub diagLQuickSetup_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub
    End Class
End Namespace