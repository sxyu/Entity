Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Imports NAudio
Imports NAudio.Wave
Imports Entity._3Modules
Imports Entity._1Dialogs.General.Settings
Imports Entity._4Classes.Types

Namespace _0App.InitialSetup


    Public Class IFm1LightN
        Inherits IFmBase
        Private rects As New List(Of RectangleX)
        Private _dragReg As DragArea = DragArea.none
        Private _dragPpt As Point
        Private _flashAll As Boolean = False
        Private Enum DragArea
            None = 0
            TopLeft = 1
            TopRight = 2
            BottomLeft = 3
            BottomRight = 4
            Top = 5
            Right = 6
            Bottom = 7
            Left = 8
            All = 9
        End Enum
        Private Sub svw1Light_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.Icon = My.Resources.en 'set icon
            channelsView.Sort()
            LoadLv()
            Me.ForceClose = False
            Me.Fade()
        End Sub
        Private Sub SetControlPos()
            visual.Size = DEFAULT_SIZE
            btnEdit.Left = visual.Right - btnEdit.Width
            lbName.Left = visual.Left
            tbName.Left = lbName.Left
            lbName.Width = visual.Width - btnEdit.Width
            tbName.Width = visual.Width - btnEdit.Width
            visual.Top = lbName.Bottom + 10
            channelsEditor.Top = visual.Bottom
            channelsEditor.Width = DEFAULT_SIZE.Width
            channelsView.Columns(0).Width = 100
            channelsView.Columns(1).Width = CInt(channelsView.Width * 0.95 - 100)
            If visual.BackgroundImage Is Nothing Then
                visual.BackgroundImage = New Bitmap(visual.Width, visual.Height)
            End If
            If visual.Image Is Nothing Then
                visual.Image = New Bitmap(visual.Width, visual.Height)
            End If
        End Sub
        Public Sub LoadLv()
            editor.Show()
            visual.Height = visual.Width \ 2
            editor.Hide()
            lv.Items.Clear()
            rects.Clear()
            lv.Columns(0).Width = CInt(lv.Width * 0.9)
            Dim toAdd As New List(Of ListViewItem)
            If File.Exists(LightFile) Then
                Dim read As String() = GetAllSettingFields(LightFile)
                Dim allFields As New List(Of String)(read)
                For Each f As String In allFields
                    If allFields.Contains(f & " Visual") Then
                        Dim it As New ListViewItem(f)
                        it.Name = f
                        it.ImageIndex = 0
                        it.Selected = False
                        toAdd.Add(it)
                        Dim recX As New RectangleX(GetSettingDataCaseI(LightFile, f & " Visual"), visual.Size)
                        recX.Tag = f
                        rects.Add(recX)
                    End If
                Next
            Else
                FileSystem.WriteAllText(LightFile, "[Lights]" & vbCrLf, False)
            End If
            lv.Items.AddRange(toAdd.ToArray)
            If lv.Items.Count > 0 Then lv.Items(0).Selected = True
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

        Private Sub lv_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp, lv.KeyUp
            If lv.Focused = True Then
                If e.KeyCode = Keys.Delete Then
                    btnDel.PerformClick()
                ElseIf e.KeyCode = Keys.F2 Then
                    btnEdit_MClick(btnEdit, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                ElseIf e.KeyCode = Keys.F5 Then
                    loadLv()
                End If
            End If
            If e.Control Then
                If e.KeyCode = Keys.D Then
                    btnAdd.PerformClick()
                ElseIf e.KeyCode = Keys.A Then
                    For Each i As ListViewItem In lv.Items
                        i.Selected = True
                    Next
                ElseIf e.KeyCode = Keys.C Then
                    If lv.SelectedItems.Count = 1 Then
                        Dim newItemText As String = lv.SelectedItems(0).Text & " - Copy"
                        SetSettingData(LightFile, newItemText, GetSettingDataCaseI(LightFile, lv.SelectedItems(0).Text))
                        SetSettingData(LightFile, newItemText & " Visual", _
                                       GetSettingDataCaseI(LightFile, lv.SelectedItems(0).Text & " Visual"))
                        loadLv()
                        For Each li As ListViewItem In lv.Items
                            If li.Text = newItemText Then
                                li.Selected = True
                            Else
                                li.Selected = False
                            End If
                        Next
                    End If
                End If
            End If
        End Sub

        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function
        'add light button
        Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
            Dim it As New ListViewItem()
            Dim recX As RectangleX
            If lv.Items.ContainsKey("New Light") Then
                Dim i As Integer = 0
                Do
                    i += 1
                Loop While lv.Items.ContainsKey("New Light " & i.ToString)
                it.Text = "New Light " & i.ToString
                it.Name = "New Light " & i.ToString
                SetSettingData(LightFile, "New Light " & i.ToString, "1:Main")
                SetSettingData(LightFile, "New Light " & i.ToString & " Visual", _
                               RectToStr(New Rectangle(4200, 4000, 1600, 2000)))
                recX = New RectangleX("4200,4000,1600,2000", visual.Size)
                recX.Tag = "New Light " & i.ToString
            Else
                it.Name = "New Light"
                it.Text = "New Light"
                SetSettingData(LightFile, "New Light", "1:Main")
                SetSettingData(LightFile, "New Light Visual", _
                               RectToStr(New Rectangle(4200, 4000, 1600, 2000)))
                recX = New RectangleX("4200,4000,1600,2000", visual.Size)
                recX.Tag = "New Light"
            End If
            it.ImageIndex = 0
            For Each i As ListViewItem In lv.SelectedItems
                i.Selected = False
            Next
            lv.Items.Add(it)
            'UpdateVisual()
            'addVisualRect(recX)
            rects.Add(recX)
            visual.Refresh()
            lv.Sort()
            lv.EnsureVisible(it.Index)
            btnRemCh.Enabled = False
            it.Selected = True
        End Sub
        Private Sub btn_EnableChanged(sender As Object, e As EventArgs) Handles btnAdd.EnabledChanged, btnRemCh.EnabledChanged
            If DirectCast(sender, Button).Enabled Then
                DirectCast(sender, Button).BackColor = Color.FromArgb(100, 100, 100)
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(80, 80, 80)
            End If
        End Sub

        Private Sub vw3Images_Layout(sender As Object, e As LayoutEventArgs) Handles MyBase.Layout
            lv.LargeImageList = ImageCache
        End Sub
        'rename button
        Private Sub btnEdit_MClick(sender As Object, e As MouseEventArgs) Handles btnEdit.MouseUp
            If lv.SelectedItems.Count > 0 Then
                If tbName.Visible Then
                    tbName.Text = tbName.Text.Trim
                    If e.Button = Windows.Forms.MouseButtons.Left And tbName.Text <> lbName.Text Then
                        lbName.Text = tbName.Text
                        For Each r As RectangleX In rects
                            If r.Tag.ToString = lv.SelectedItems(0).Text Then
                                r.Tag = tbName.Text
                                Exit For
                            End If
                        Next
                        RenameSettingData(LightFile, lv.SelectedItems(0).Text, tbName.Text)
                        RenameSettingData(LightFile, lv.SelectedItems(0).Text & " Visual", tbName.Text & " Visual")
                        UpdateVisualName(lv.SelectedItems(0).Text, tbName.Text)
                        lv.SelectedItems(0).Text = tbName.Text
                        lv.SelectedItems(0).Name = tbName.Text
                        btnEdit.BackColor = Color.FromArgb(160, 160, 160)
                    End If
                    lv.Sort()
                    lv.EnsureVisible(lv.SelectedIndices(0))
                    visual.Focus()
                    tbName.Visible = False
                    lbName.Visible = True
                    btnEdit.BackColor = Color.FromArgb(160, 160, 160)
                    visual.Refresh()
                Else
                    visual.Focus()
                    tbName.Text = lbName.Text
                    tbName.Visible = True
                    lbName.Visible = False
                    tbName.Focus()
                    tbName.SelectionLength = 0
                    tbName.SelectionStart = tbName.Text.Length
                    btnEdit.BackColor = Color.IndianRed
                End If
            End If
        End Sub



        Private Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
            If String.IsNullOrEmpty(tbName.Text.Trim) Then
                lbWarning.Text = "Name Cannot be Empty!"
                lbWarning.Show()
                btnEdit.Enabled = False
            ElseIf lv.Items.ContainsKey(tbName.Text) Then
                If tbName.Text = lbName.Text Then
                    lbWarning.Hide()
                    btnEdit.Enabled = True
                Else
                    lbWarning.Text = "This Name is Already Taken!"
                    lbWarning.Show()
                    btnEdit.Enabled = False
                End If
            ElseIf tbName.Text.EndsWith(" Visual") Then
                lbWarning.Text = "Light Names Must Not End With '' Visual''!"
                lbWarning.Show()
                btnEdit.Enabled = False
            ElseIf tbName.Text.Contains(":") Then
                lbWarning.Text = "Light Names Must Not Contain '':''!"
                lbWarning.Show()
                btnEdit.Enabled = False
            Else
                lbWarning.Hide()
                btnEdit.Enabled = True
            End If
        End Sub
        Private Sub tbName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbName.KeyPress
            If btnEdit.Enabled Then
                If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                    btnEdit_MClick(btnEdit, New MouseEventArgs(Windows.Forms.MouseButtons.Left, 1, 0, 0, 0))
                    e.Handled = True
                End If
            End If
        End Sub


        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            If lbChID.Visible Then
                lbChID.Hide()
                lbChTag.Hide()
                numChID.Hide()
                cmbChTag.Hide()
            End If
            If tbName.Visible Then
                visual.Focus()
                tbName.Visible = False
                lbName.Visible = True
                btnEdit.BackColor = Color.FromArgb(160, 160, 160)
            End If
            If lv.SelectedItems.Count <> 1 Then
                editor.Hide()
                If lv.SelectedItems.Count < 1 Then btnDel.Enabled = False Else btnDel.Enabled = True
                'visual_Paint
            Else
                lbName.Text = lv.SelectedItems(0).Text
                editor.Show()
                btnDel.Enabled = True
                setControlPos()
                For Each i As ListViewItem In channelsView.CheckedItems
                    DmxEngine.SetDmxValue(CInt(unpadZeros(i.Text)), 0)
                    i.Checked = False
                Next
                channelsView.Items.Clear()
                Dim chnlsToAdd As New List(Of ListViewItem)
                Dim params() As String = GetSettingData(LightFile, lv.SelectedItems(0).Text).Split(","c)
                For Each chnl As String In params
                    If chnl.Contains(":") Then
                        Dim id As String = chnl.Remove(chnl.IndexOf(":"c)).Trim
                        Dim desc As String = chnl.Remove(0, chnl.IndexOf(":"c) + 1).Trim
                        Dim it As New ListViewItem(padZeros(CInt(id)))
                        it.ImageIndex = 1
                        it.SubItems.Add(desc)
                        chnlsToAdd.Add(it)
                    End If
                Next
                For Each r As RectangleX In rects
                    If r.Tag.ToString = lv.SelectedItems(0).Name Then
                        r.IsActive = True
                    Else
                        'set everything else to inactive
                        r.IsActive = False
                    End If
                Next
                channelsView.Items.AddRange(chnlsToAdd.ToArray)

                btnFlashAll.BackColor = Color.fromArgb(100, 100, 100)
                btnFlashAll.ForeColor = Color.FromArgb(64, 64, 64)
                For Each i As ListViewItem In channelsView.Items
                    i.Checked = False
                Next
                _flashAll = False

                visual.Refresh()
            End If
            If channelsView.Items.Count <= 1 Then
                btnRemCh.Enabled = False
            Else
                btnRemCh.Enabled = True
            End If
            If lv.SelectedItems.Count > 0 Then lv.EnsureVisible(lv.SelectedIndices(0))
            lv.Refresh()
        End Sub



        Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
            Dim s As String = "s "
            If lv.SelectedItems.Count = 1 Then s = " "
            Dim resNames As String = ""
            For i As Integer = 0 To lv.SelectedItems.Count - 1
                If i < lv.SelectedItems.Count - 1 Then
                    resNames &= lv.SelectedItems(i).Text & ", "
                Else
                    resNames &= lv.SelectedItems(i).Text
                End If
            Next
            If MsgBox("Delete the light" & s & "''" & resNames & "''?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation _
                                                                        Or MsgBoxStyle.MsgBoxSetForeground, "Delete Light" & s) = MsgBoxResult.Yes Then
                For Each i As ListViewItem In lv.SelectedItems
                    i.Selected = False
                    DeleteSettingData(LightFile, i.Text)
                    DeleteSettingData(LightFile, i.Text & " Visual")
                    For Each r As RectangleX In rects
                        If r.Tag.ToString = i.Name Then
                            rects.Remove(r)
                            'remVisualRect(r.tag.ToString)
                            Exit For
                        End If
                    Next
                    'UpdateVisual()
                Next
                loadLv()
                For Each i As ListViewItem In lv.SelectedItems
                    i.Selected = False
                Next
                editor.Hide()
                If lv.Items.Count > 0 Then lv.Items(0).Selected = True
                visual.Refresh()
            End If
        End Sub

        Private Sub channelsView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles channelsView.SelectedIndexChanged
            If channelsView.SelectedItems.Count <> 1 Then
                lbChID.Hide()
                lbChTag.Hide()
                numChID.Hide()
                cmbChTag.Hide()
                If channelsView.SelectedItems.Count < 1 Then btnRemCh.Enabled = False Else btnRemCh.Enabled = True
            Else
                lbChID.Show()
                lbChTag.Show()
                numChID.Show()
                cmbChTag.Show()
                If channelsView.Items.Count <= 1 Then
                    btnRemCh.Enabled = False
                Else
                    btnRemCh.Enabled = True
                End If
                numChID.Value = CInt(channelsView.SelectedItems(0).Text)
                cmbChTag.Text = channelsView.SelectedItems(0).SubItems(1).Text
            End If
        End Sub

        Private Sub numChID_ValueChanged(sender As Object, e As EventArgs) Handles numChID.ValueChanged
            If channelsView.SelectedIndices.Count = 1 Then
                channelsView.SelectedItems(0).Text = padZeros(CInt(numChID.Value))
                saveChannels()
                channelsView.Sort()
                'UpdateVisual(numChID)
            End If
        End Sub

        Private Sub cmbChTag_TextChanged(sender As Object, e As EventArgs) Handles cmbChTag.TextChanged
            If cmbChTag.Text <> "" And channelsView.SelectedIndices.Count = 1 Then
                If cmbChTag.Text.Trim = "All" Then
                    cmbChTag.Text = "all"
                End If
                channelsView.SelectedItems(0).SubItems(1).Text = cmbChTag.Text
                saveChannels()
                'UpdateVisual(cmbChTag)
            End If
        End Sub

        Private Sub saveChannels()
            If lv.SelectedItems.Count = 1 Then
                Dim strToSave As String = ""
                For ct As Integer = 0 To channelsView.Items.Count - 1
                    Dim i As ListViewItem = channelsView.Items(ct)
                    strToSave &= unpadZeros(i.Text) & ":" & i.SubItems(1).Text
                    If Not ct = channelsView.Items.Count - 1 Then strToSave &= ","
                Next
                SetSettingData(LightFile, lv.SelectedItems(0).Text, strToSave)
            End If
        End Sub

        Private Sub btnRemCh_Click(sender As Object, e As EventArgs) Handles btnRemCh.Click
            If channelsView.SelectedItems.Count > 0 Then
                If channelsView.Items.Count > 1 Then
                    For Each i As ListViewItem In channelsView.SelectedItems
                        DmxEngine.SetDmxValue(CInt(unpadZeros(i.Text)), 0)
                        i.Checked = False
                        channelsView.Items.Remove(i)
                    Next
                    saveChannels()
                    'UpdateVisual()
                End If
            End If
            If channelsView.Items.Count <= 1 Then
                btnRemCh.Enabled = False
            Else
                btnRemCh.Enabled = True
            End If
        End Sub
        Private Sub btnAddCh_Click(sender As Object, e As EventArgs) Handles btnAddCh.Click
            Dim it As New ListViewItem()
            If channelsView.Items.Count > 0 Then
                it.Text = padZeros(CInt(channelsView.Items(channelsView.Items.Count - 1).Text) + 1)
            Else
                it.Text = "001"
            End If
            If channelsView.Items.Count < cmbChTag.Items.Count Then
                it.SubItems.Add(cmbChTag.Items(channelsView.Items.Count).ToString)
            Else
                it.SubItems.Add("Other")
            End If
            it.ImageIndex = 1
            For Each i As ListViewItem In channelsView.SelectedItems
                i.Selected = False
            Next
            channelsView.Items.Add(it)
            it.Selected = True
            saveChannels()
            'UpdateVisual()
            If channelsView.Items.Count <= 1 Then
                btnRemCh.Enabled = False
            Else
                btnRemCh.Enabled = True
            End If
        End Sub
        Private Sub btnLightingBD_Click(sender As Object, e As EventArgs)
            For Each i As ListViewItem In channelsView.CheckedItems
                i.Checked = False
            Next
            With _6Misc.FrmLightingBd
                '.Width = Screen.PrimaryScreen.WorkingArea.Width
                '.Height = Screen.PrimaryScreen.WorkingArea.Height / 7 * 5
                .MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
                .Left = CInt(Screen.PrimaryScreen.WorkingArea.Width / 2 - .Width / 2)
                .Top = CInt(Screen.PrimaryScreen.WorkingArea.Height / 2 - .Height / 2)
                .Opacity = 1
                _6Misc.FrmLightBox.Show()
                _6Misc.FrmLightBox.BringToFront()
                .Show()
                .BringToFront()
            End With
        End Sub

        Private Sub channelsView_ItemActivate(sender As Object, e As EventArgs) Handles channelsView.ItemActivate
            If channelsView.SelectedItems.Count > 0 Then
                For Each i As ListViewItem In channelsView.SelectedItems
                    i.Checked = Not i.Checked
                Next
            End If
        End Sub

        Private Sub channelsView_ItemChecked(sender As Object, e As ItemCheckedEventArgs) Handles channelsView.ItemChecked
            Dim ch As Integer = CInt(unpadZeros(e.Item.Text)) - 1
            If e.Item.Checked Then
                e.Item.BackColor = Color.fromArgb(100, 100, 100)
                DmxEngine.SetDmxValue(ch, 255)
            Else
                e.Item.BackColor = Color.FromArgb(180, 180, 180)
                DmxEngine.SetDmxValue(ch, 0)
            End If
            'If channelsView.Items.Count > 0 Then
            '    For Each i As ListViewItem In channelsView.Items
            '        If i IsNot Nothing Then
            '            If Not String.IsNullOrEmpty(i.Text) Then
            '                Dim ch As Integer = CInt(unpadZeros(i.Text)) - 1
            '                If i.Checked = False Then
            '                    i.BackColor = Color.FromArgb(180, 180, 180)
            '                    DmxEngine.SetDmxValue( ch, 0)
            '                Else
            '                    i.BackColor = Color.fromArgb(100, 100, 100)
            '                    DmxEngine.SetDmxValue( ch, 255)
            '                End If
            '            End If
            '        End If
            '    Next
            'End If
        End Sub

        Private Sub channelsView_KeyUp(sender As Object, e As KeyEventArgs) Handles channelsView.KeyUp
            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.A
                        For Each i As ListViewItem In channelsView.Items
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
        Private Sub paintLight(ByVal g As Graphics, ByVal clipRec As Rectangle, ByVal cRec As RectangleX, ByVal name As String)
            Using blackPen As New Pen(Color.fromArgb(100, 100, 100))
                Using blackBr As New SolidBrush(Color.fromArgb(100, 100, 100))
                    Using lightBr As New SolidBrush(Color.FromArgb(70, Color.GhostWhite))
                        Using segoeUI As New Font("Segoe UI SemiLight", 10)
                            g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                            g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                            g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                            g.DrawEllipse(blackPen, cRec.ToRectangle)
                            g.FillEllipse(lightBr, cRec.ToRectangle)

                            Dim sz As SizeF = g.MeasureString(name, segoeUI)
                            g.DrawString(name, segoeUI, blackBr, CInt(cRec.Left + cRec.Width / 2 - sz.Width / 2), _
                                         CInt(cRec.Top + cRec.Height / 2 - sz.Height / 2))
                        End Using
                    End Using
                End Using
            End Using
        End Sub
        Private Sub PaintSelectedLight(ByVal g As Graphics, ByVal clipRec As Rectangle, ByVal cRec As RectangleX, ByVal name As String)
            If cRec IsNot Nothing Then
                Using whitePen As New Pen(Color.White, 2)
                    Using blackPen As New Pen(Color.fromArgb(80, 80, 80))
                        Using transBr As New SolidBrush(Color.FromArgb(100, Color.White))
                            Using lightBr As New SolidBrush(Color.FromArgb(100, Color.FromArgb(255, 191, 0))) 'amber
                                Using opaqueBr As New SolidBrush(Color.FromArgb(170, Color.fromArgb(100, 100, 100)))
                                    Using veryTransBr As New SolidBrush(Color.FromArgb(50, Color.AliceBlue))
                                        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                                        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                                        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                                        g.DrawEllipse(blackPen, cRec.ToRectangle)
                                        g.FillEllipse(lightBr, cRec.ToRectangle)
                                        Dim cornerSize As Integer = 10
                                        g.DrawRectangle(whitePen, cRec.GetCornerRectangle(RectangleX.Corner.topLeft, cornerSize))
                                        g.DrawRectangle(whitePen, cRec.GetCornerRectangle(RectangleX.Corner.topRight, cornerSize))
                                        g.DrawRectangle(whitePen, cRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, cornerSize))
                                        g.DrawRectangle(whitePen, cRec.GetCornerRectangle(RectangleX.Corner.bottomRight, cornerSize))
                                        g.DrawRectangle(whitePen, cRec.GetSideRectangle(RectangleX.Side.top, cornerSize))
                                        g.DrawRectangle(whitePen, cRec.GetSideRectangle(RectangleX.Side.right, cornerSize))
                                        g.DrawRectangle(whitePen, cRec.GetSideRectangle(RectangleX.Side.bottom, cornerSize))
                                        g.DrawRectangle(whitePen, cRec.GetSideRectangle(RectangleX.Side.left, cornerSize))

                                        g.DrawRectangle(blackPen, cRec.GetCornerRectangle(RectangleX.Corner.topLeft, cornerSize, 1))
                                        g.DrawRectangle(blackPen, cRec.GetCornerRectangle(RectangleX.Corner.topRight, cornerSize, 1))
                                        g.DrawRectangle(blackPen, cRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, cornerSize, 1))
                                        g.DrawRectangle(blackPen, cRec.GetCornerRectangle(RectangleX.Corner.bottomRight, cornerSize, 1))
                                        g.DrawRectangle(blackPen, cRec.GetSideRectangle(RectangleX.Side.top, cornerSize, 1))
                                        g.DrawRectangle(blackPen, cRec.GetSideRectangle(RectangleX.Side.right, cornerSize, 1))
                                        g.DrawRectangle(blackPen, cRec.GetSideRectangle(RectangleX.Side.bottom, cornerSize, 1))
                                        g.DrawRectangle(blackPen, cRec.GetSideRectangle(RectangleX.Side.left, cornerSize, 1))

                                        g.DrawRectangle(blackPen, cRec.GetCornerRectangle(RectangleX.Corner.topLeft, cornerSize, -1))
                                        g.DrawRectangle(blackPen, cRec.GetCornerRectangle(RectangleX.Corner.topRight, cornerSize, -1))
                                        g.DrawRectangle(blackPen, cRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, cornerSize, -1))
                                        g.DrawRectangle(blackPen, cRec.GetCornerRectangle(RectangleX.Corner.bottomRight, cornerSize, -1))
                                        g.DrawRectangle(blackPen, cRec.GetSideRectangle(RectangleX.Side.top, cornerSize, -1))
                                        g.DrawRectangle(blackPen, cRec.GetSideRectangle(RectangleX.Side.right, cornerSize, -1))
                                        g.DrawRectangle(blackPen, cRec.GetSideRectangle(RectangleX.Side.bottom, cornerSize, -1))
                                        g.DrawRectangle(blackPen, cRec.GetSideRectangle(RectangleX.Side.left, cornerSize, -1))
                                        Select Case _dragReg
                                            Case DragArea.TopLeft
                                                g.FillRectangle(transBr, cRec.GetCornerRectangle(RectangleX.Corner.topLeft, cornerSize))
                                            Case DragArea.TopRight
                                                g.FillRectangle(transBr, cRec.GetCornerRectangle(RectangleX.Corner.topRight, cornerSize))
                                            Case DragArea.BottomLeft
                                                g.FillRectangle(transBr, cRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, cornerSize))
                                            Case DragArea.BottomRight
                                                g.FillRectangle(transBr, cRec.GetCornerRectangle(RectangleX.Corner.bottomRight, cornerSize))
                                            Case DragArea.Top
                                                g.FillRectangle(transBr, cRec.GetSideRectangle(RectangleX.Side.top, cornerSize))
                                            Case DragArea.Right
                                                g.FillRectangle(transBr, cRec.GetSideRectangle(RectangleX.Side.right, cornerSize))
                                            Case DragArea.Bottom
                                                g.FillRectangle(transBr, cRec.GetSideRectangle(RectangleX.Side.bottom, cornerSize))
                                            Case DragArea.Left
                                                g.FillRectangle(transBr, cRec.GetSideRectangle(RectangleX.Side.left, cornerSize))
                                            Case DragArea.All
                                                'g.FillEllipse(veryTransBr, cRec.ToRectangle)
                                        End Select

                                        Using blackBr As New SolidBrush(Color.fromArgb(80, 80, 80))
                                            Using segoeUI As New Font("Segoe UI SemiLight", 10)
                                                Dim sz As SizeF = g.MeasureString(name, segoeUI)
                                                g.DrawString(name, segoeUI, blackBr, CInt(cRec.Left + cRec.Width / 2 - sz.Width / 2), _
                                                             CInt(cRec.Top + cRec.Height / 2 - sz.Height / 2))
                                            End Using
                                        End Using
                                    End Using
                                End Using
                            End Using
                        End Using
                    End Using
                End Using
            End If
        End Sub

        Private Sub visual_Paint(sender As Object, e As PaintEventArgs) Handles visual.Paint
            Using bgBr As New SolidBrush(Color.fromArgb(100, 100, 100))
                Using br As New SolidBrush(Color.White)
                    Using segoeUi As New Font("Segoe UI SemiLight", 8)
                        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
                        Dim sz As SizeF = e.Graphics.MeasureString("Audience (Click To Flip)", segoeUi)
                        If My.Settings.lightVisualReverse Then
                            e.Graphics.FillRectangle(bgBr, 0, visual.Height - CInt(visual.Height / 10), visual.Width, CInt(visual.Height / 10))
                            e.Graphics.DrawString("Audience (Click To Flip)", segoeUi, br, CInt(visual.Width / 2 - sz.Width / 2), _
                                                  CInt(visual.Height / 20 * 19 - sz.Height / 2))
                        Else
                            e.Graphics.FillRectangle(bgBr, 0, 0, visual.Width, CInt(visual.Height / 10))
                            e.Graphics.DrawString("Audience (Click To Flip)", segoeUi, br, CInt(visual.Width / 2 - sz.Width / 2), _
                                                  CInt(visual.Height / 20 - sz.Height / 2))
                        End If
                    End Using
                End Using
            End Using
            Dim selRect As RectangleX
            For i As Integer = rects.Count - 1 To 0 Step -1
                Dim r As RectangleX = rects(i)
                If My.Settings.lightVisualReverse Then
                    Dim inverseR As New RectangleX(r.Left, visual.Height - r.Bottom, r.Width, r.Height)
                    inverseR.Tag = r.Tag
                    If r.IsActive Then
                        selRect = inverseR
                    Else
                        paintLight(e.Graphics, e.ClipRectangle, inverseR, r.Tag.ToString)
                    End If
                Else
                    If r.IsActive Then
                        selRect = r
                    Else
                        paintLight(e.Graphics, e.ClipRectangle, r, r.Tag.ToString)
                    End If
                End If
            Next
            If selRect IsNot Nothing Then
                paintSelectedLight(e.Graphics, e.ClipRectangle, selRect, selRect.Tag.ToString)
            End If
        End Sub
        Private Sub visual_MouseDown(sender As Object, e As MouseEventArgs) Handles visual.MouseDown
            Dim cRec As RectangleX
            For Each r As RectangleX In rects
                If r.IsActive Then
                    If My.Settings.lightVisualReverse Then
                        cRec = New RectangleX(r.Left, visual.Height - r.Bottom, r.Width, r.Height)
                    Else
                        cRec = r
                    End If
                    Exit For
                End If
            Next
            If Not cRec Is Nothing Then
                If IsInRect(e.Location, cRec.GetCornerRectangle(RectangleX.Corner.topLeft, 10)) Then
                    _dragReg = DragArea.topLeft
                ElseIf IsInRect(e.Location, cRec.GetCornerRectangle(RectangleX.Corner.topRight, 10)) Then
                    _dragReg = DragArea.topRight
                ElseIf IsInRect(e.Location, cRec.GetCornerRectangle(RectangleX.Corner.bottomLeft, 10)) Then
                    _dragReg = DragArea.bottomLeft
                ElseIf IsInRect(e.Location, cRec.GetCornerRectangle(RectangleX.Corner.bottomRight, 10)) Then
                    _dragReg = DragArea.bottomRight

                ElseIf IsInRect(e.Location, cRec.GetSideRectangle(RectangleX.Side.top, 10)) Then
                    _dragReg = DragArea.top
                ElseIf IsInRect(e.Location, cRec.GetSideRectangle(RectangleX.Side.right, 10)) Then
                    _dragReg = DragArea.right
                ElseIf IsInRect(e.Location, cRec.GetSideRectangle(RectangleX.Side.bottom, 10)) Then
                    _dragReg = DragArea.bottom
                ElseIf IsInRect(e.Location, cRec.GetSideRectangle(RectangleX.Side.left, 10)) Then
                    _dragReg = DragArea.left

                ElseIf IsInEllipse(e.Location, cRec.ToRectangle) Then
                    _dragReg = DragArea.all
                Else
                    Dim foundNewRect As Boolean = False
                    Dim mousePos As Point = e.Location
                    If My.Settings.lightVisualReverse Then
                        mousePos = New Point(mousePos.X, visual.Height - mousePos.Y)
                    End If
                    For Each r As RectangleX In rects
                        If Not r.IsActive Then
                            If IsInEllipse(mousePos, r.ToRectangle) Then
                                foundNewRect = True
                                For Each it As ListViewItem In lv.SelectedItems
                                    If it.Name = r.Tag.ToString Then
                                        Exit For
                                    Else
                                        it.Selected = False
                                    End If
                                Next

                                For Each it As ListViewItem In lv.Items
                                    If it.Name = r.Tag.ToString Then
                                        it.Selected = True
                                        Exit For
                                    End If
                                Next
                                Call visual_MouseDown(visual, New MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta))
                                Exit For
                            End If
                        End If
                    Next
                    If Not foundNewRect Then
                        If My.Settings.lightVisualReverse Then
                            If e.Y > visual.Height / 10 * 9 Then
                                My.Settings.lightVisualReverse = False
                            End If
                        Else
                            If e.Y < visual.Height / 10 Then
                                My.Settings.lightVisualReverse = True
                            End If
                        End If
                        My.Settings.Save()
                        visual.Refresh()
                    End If
                End If
                _dragPpt = e.Location
                visual.Refresh()
            End If
        End Sub


        Private Sub visual_MouseUp(sender As Object, e As MouseEventArgs) Handles visual.MouseUp
            _dragReg = 0
            saveVisual()
            visual.Refresh()
            'UpdateVisual()
            lv.Focus()
        End Sub

        Private Sub visual_MouseMove(sender As Object, e As MouseEventArgs) Handles visual.MouseMove
            Dim cRec As RectangleX
            For Each r As RectangleX In rects
                If r.IsActive Then
                    cRec = r
                    Exit For
                End If
            Next
            If _dragReg <> DragArea.none Then
                If My.Settings.lightVisualReverse Then
                    Select Case _dragReg
                        Case DragArea.topLeft
                            cRec.MoveCorner(RectangleX.Corner.bottomLeft, e.X - _dragPpt.X, e.Y - _dragPpt.Y)
                        Case DragArea.topRight
                            cRec.MoveCorner(RectangleX.Corner.bottomRight, e.X - _dragPpt.X, _dragPpt.Y - e.Y)
                        Case DragArea.bottomLeft
                            cRec.MoveCorner(RectangleX.Corner.topLeft, e.X - _dragPpt.X, _dragPpt.Y - e.Y)
                        Case DragArea.bottomRight
                            cRec.MoveCorner(RectangleX.Corner.topRight, e.X - _dragPpt.X, e.Y - _dragPpt.Y)
                        Case DragArea.top
                            cRec.MoveSide(RectangleX.Side.bottom, 0, _dragPpt.Y - e.Y)
                        Case DragArea.right
                            cRec.MoveSide(RectangleX.Side.right, e.X - _dragPpt.X, 0)
                        Case DragArea.bottom
                            cRec.MoveSide(RectangleX.Side.top, 0, _dragPpt.Y - e.Y)
                        Case DragArea.left
                            cRec.MoveSide(RectangleX.Side.left, e.X - _dragPpt.X, 0)
                        Case DragArea.all
                            cRec.Move(e.X - _dragPpt.X, _dragPpt.Y - e.Y)
                    End Select
                Else
                    Select Case _dragReg
                        Case DragArea.topLeft
                            cRec.MoveCorner(RectangleX.Corner.topLeft, e.X - _dragPpt.X, e.Y - _dragPpt.Y)
                        Case DragArea.topRight
                            cRec.MoveCorner(RectangleX.Corner.topRight, e.X - _dragPpt.X, _dragPpt.Y - e.Y)
                        Case DragArea.bottomLeft
                            cRec.MoveCorner(RectangleX.Corner.bottomLeft, e.X - _dragPpt.X, _dragPpt.Y - e.Y)
                        Case DragArea.bottomRight
                            cRec.MoveCorner(RectangleX.Corner.bottomRight, e.X - _dragPpt.X, e.Y - _dragPpt.Y)
                        Case DragArea.top
                            cRec.MoveSide(RectangleX.Side.top, 0, e.Y - _dragPpt.Y)
                        Case DragArea.right
                            cRec.MoveSide(RectangleX.Side.right, e.X - _dragPpt.X, 0)
                        Case DragArea.bottom
                            cRec.MoveSide(RectangleX.Side.bottom, 0, e.Y - _dragPpt.Y)
                        Case DragArea.left
                            cRec.MoveSide(RectangleX.Side.left, e.X - _dragPpt.X, 0)
                        Case DragArea.all
                            cRec.Move(e.X - _dragPpt.X, e.Y - _dragPpt.Y)
                    End Select
                End If
                _dragPpt = e.Location
                cRec.EnsureWithin(New Rectangle(New Point(0, 0), visual.Size))
                cRec.EnsureLarger(40, 40)
                visual.Refresh()
            End If
        End Sub
        Private Sub SaveVisual()
            For Each r As RectangleX In rects
                If My.Settings.lightVisualReverse Then
                    Dim ir As New RectangleX(r.Left, visual.Height - r.Bottom, r.Width, r.Height)
                    SetSettingData(LightFile, r.Tag.ToString & " Visual", r.ToRatioString(visual.Size))
                Else
                    SetSettingData(LightFile, r.Tag.ToString & " Visual", r.ToRatioString(visual.Size))
                End If
            Next
        End Sub


        Private Sub btnQuickSetup_Click(sender As Object, e As EventArgs)
            Using diag As New diagLQuickSetup
                With diag
                    If lv.Items.Count = 0 Then .isLvEmpty = True Else .isLvEmpty = False
                    If .ShowDialog = DialogResult.OK Then
                        lv.Items.Clear()
                        FileSystem.WriteAllText(LightFile, "[Lights]" & vbCrLf, False)
                        For i As Integer = 1 To .numberOfLights
                            Dim str As String
                            For j As Integer = 1 To .channels.Count
                                str &= CStr((i - 1) * .channels.Count + j) & ":" & .channels(j - 1)
                                If Not j = .channels.Count Then str &= ","
                            Next
                            Dim paddedIdx As String = padZeros(i, .numberOfLights.ToString.Length)
                            SetSettingData(LightFile, .NamePattern.Replace("%N%", paddedIdx).Replace("%n%", paddedIdx), str)
                            SetSettingData(LightFile, .NamePattern.Replace("%N%", paddedIdx).Replace("%n%", paddedIdx) & " Visual", _
                                           "4200,4000,1600,2000")
                            str = ""
                        Next
                        loadLv()
                    End If
                End With
            End Using
            lv.Focus()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
            FrmCinematic.BackColor = Color.fromArgb(100, 100, 100)
            IFm1LightQ.Show()
            Me.Close()
        End Sub

        Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
            FrmCinematic.BlankOut = False
            FrmCinematic.StartScene = 10
            FrmCinematic.ReInit()
            Me.Close()
        End Sub

        Private Sub btnFlashAll_Click(sender As Object, e As EventArgs) Handles btnFlashAll.Click
            If _flashAll Then
                btnFlashAll.BackColor = Color.fromArgb(100, 100, 100)
                btnFlashAll.ForeColor = Color.FromArgb(64, 64, 64)
                If channelsView.Items.Count > 0 Then
                    For Each i As ListViewItem In channelsView.Items
                        If i IsNot Nothing Then
                            If Not String.IsNullOrEmpty(i.Text) Then
                                Dim ch As Integer = CInt(unpadZeros(i.Text)) - 1
                                i.BackColor = Color.FromArgb(180, 180, 180)
                                DmxEngine.SetDmxValue(ch, 0)
                            End If
                        End If
                    Next
                End If
                For Each i As ListViewItem In channelsView.Items
                    i.Checked = False
                Next
            Else
                btnFlashAll.BackColor = Color.SteelBlue
                btnFlashAll.ForeColor = Color.White
                If channelsView.Items.Count > 0 Then
                    For Each i As ListViewItem In channelsView.Items
                        If i IsNot Nothing Then
                            If Not String.IsNullOrEmpty(i.Text) Then
                                Dim ch As Integer = CInt(unpadZeros(i.Text)) - 1
                                i.BackColor = Color.fromArgb(100, 100, 100)
                                DmxEngine.SetDmxValue(ch, 255)
                            End If
                        End If
                    Next
                End If
                For Each i As ListViewItem In channelsView.Items
                    i.Checked = True
                Next
            End If
            _flashAll = Not _flashAll
        End Sub
    End Class
End Namespace