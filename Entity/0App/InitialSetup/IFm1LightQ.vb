Imports Microsoft.VisualBasic.FileIO
Imports Entity._3Modules
Namespace _0App.InitialSetup
    Public Class IFm1LightQ
        Inherits IFmBase
        Public NamePattern As String = ""
        Public NumberOfLights As Integer
        Public Channels As New List(Of String)
        Public IsLvEmpty As Boolean
        Private OK(2) As Boolean
        Private Sub btnCancel_Click(sender As Object, e As EventArgs)
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnOK.Click
            If tbName.Text = "" Then Exit Sub
            namePattern = tbName.Text
            numberOfLights = CInt(numNum.Value)
            For i As Integer = 0 To lv.Items.Count - 1
                channels.Add(lv.Items(i).SubItems(1).Text)
            Next
            lv.Items.Clear()

            FileSystem.WriteAllText(LightFile, "[Lights]" & vbCrLf, False)
            For i As Integer = 1 To numberOfLights
                Dim str As String
                For j As Integer = 1 To channels.Count
                    str &= CStr((i - 1) * channels.Count + j) & ":" & channels(j - 1)
                    If Not j = channels.Count Then str &= ","
                Next
                Dim paddedIdx As String = padZeros(i, numberOfLights.ToString.Length)
                SetSettingData(LightFile, NamePattern.Replace("%N%", paddedIdx).Replace("%n%", paddedIdx), str)
                SetSettingData(LightFile, NamePattern.Replace("%N%", paddedIdx).Replace("%n%", paddedIdx) & " Visual", _
                               "4200,4000,1600,2000")
                str = ""
            Next

            'set up default light editor size
            Dim h As Integer = (Screen.PrimaryScreen.Bounds.Height - 134) / 2 - 20
            Dim ratio As Integer = h / 306
            Dim w As Integer = 613 * ratio
            DEFAULT_SIZE = New Size(w, h)

            'show next form
            FrmCinematic.BackColor = Color.WhiteSmoke
            IFm1LightN.Show()
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
        Private Sub me_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, lbName.MouseDown, lbTitle.MouseDown _
                                                                                , lbTag.MouseDown, lbNumbers.MouseDown
            moving = True
            ppt = e.Location
        End Sub

        Private Sub me_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, lbName.MouseMove, lbTitle.MouseMove _
                                                                                , lbTag.MouseMove, lbNumbers.MouseMove
            If moving Then
                Me.Location = New Point(Me.Left + e.X - ppt.X, Me.Top + e.Y - ppt.Y)
            End If
        End Sub

        Private Sub me_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, lbName.MouseUp, lbTitle.MouseUp, lbTag.MouseUp, _
                                                                              lbNumbers.MouseUp
            moving = False
        End Sub

        Private Sub btnCreate_EnableChanged(sender As Object, e As EventArgs) Handles btnOK.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.Gainsboro
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(160, 160, 160)
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
        Private Function padZeros(ByVal intToPad As Integer, Optional ByVal length As Integer = 3) As String
            Dim s As String = intToPad.ToString
            While s.Length < length
                s = "0" & s
            End While
            Return s
        End Function
        Private Function unpadZeros(ByVal paddedStr As String) As String
            Dim unpaddedStr As String = paddedStr
            While unpaddedStr.StartsWith("0")
                unpaddedStr = unpaddedStr.Remove(0, 1)
            End While
            Return unpaddedStr
        End Function
        Private Sub lvItemChanged()
            If lv.Items.Count > 0 And lv.Items.Count <= 512 Then
                OK(2) = True
                numNum.Maximum = CDec(Math.Floor(512 / lv.Items.Count))
                checkIfOk()
            Else
                OK(2) = False
                checkIfOk()
            End If
        End Sub
        Private Sub checkIfOk()
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
            Me.Icon = My.Resources.en 'set icon
            checkIfOk()
            lv.Columns(0).Width = 120
            lv.Columns(1).Width = CInt(lv.Width * 0.9 - 120)
            content.Left = CInt(Me.Width / 2 - content.Width / 2)
            content.Top = CInt(Me.Height / 2 - content.Height / 2)
            Me.ForceClose = False
            Me.Fade()
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

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub btnRemCh_EnabledChanged(sender As Object, e As EventArgs) Handles btnRemCh.EnabledChanged
            If btnRemCh.Enabled = False Then
                btnRemCh.BackColor = Color.FromArgb(180, 180, 180)
            Else
                btnRemCh.BackColor = Color.Gainsboro
            End If
        End Sub
    End Class
End Namespace