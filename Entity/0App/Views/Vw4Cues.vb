Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports Entity._3Modules
Imports Entity._1Dialogs.Tools
Imports Entity._1Dialogs.General.Selectors
Imports Entity._6Misc
Imports Entity._2Namespaces.CueSys
Imports Entity._2Namespaces.Light
Imports Entity._2Namespaces.Sound
Imports Entity._2Namespaces.Projection
Imports Entity._4Classes.Types
Imports Entity._4Classes.Types.DmxEngine
Imports Entity._5Controls

Namespace _0App.Views

    Public Class Vw4Cues
        Dim _forceAddLast As Boolean = False
        Dim _curTab As CuesTab = CuesTab.Lfx
        Private _prevLightUpdTime As DateTime

        Enum CuesTab
            Lfx = 0
            Sfx
            Pjx
            None
        End Enum

        Private Sub vw4Cues_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            'docks in viewer
            Me.Dock = DockStyle.Fill
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            asngLV.Sort()
            LoadLv()
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            Const WM_CONTEXTMENU As Integer = &H7B

            If m.Msg <> WM_CONTEXTMENU Then
                MyBase.WndProc(m)
            End If
        End Sub

        Private Sub SetControlPos()
            'btnEdit.Left = visual.Right - btnEdit.Width
            'lbName.Left = visual.Left
            'tbName.Left = lbName.Left
            'lbName.Width = visual.Width - btnEdit.Width
            'tbName.Width = visual.Width - btnEdit.Width
            'visual.Top = lbName.Bottom + 5
            'visual.Height = visual.Width \ 2
            visual.Size = DEFAULT_SIZE
            pnlLFX.Width = DEFAULT_SIZE.Width + 20
            btnEdit.Left = pnlLFX.Left + visual.Width - btnEdit.Width
            tbName.Width = btnEdit.Left - tbName.Left + 1
            channelsEditor.Top = visual.Bottom
            channelsEditor.Width = DEFAULT_SIZE.Width
            asngLV.Columns(0).Width = 100
            asngLV.Columns(1).Width = CInt(asngLV.Width * 0.95 - 100)
            pnlFadeTime.Top = channelsEditor.Bottom
            pnlFadeTime.Width = DEFAULT_SIZE.Width
            If visual.BackgroundImage Is Nothing Then
                visual.BackgroundImage = New Bitmap(visual.Width, visual.Height)
            End If
            If visual.Image Is Nothing Then
                visual.Image = New Bitmap(visual.Width, visual.Height)
            End If
            pnlLFX.Height = pnlFadeTime.Bottom
            pnlSFX.Height = tbAllDelay.Bottom + 5
        End Sub

        Private Sub UpdateLights()
            If Now.Subtract(_prevLightUpdTime) > New TimeSpan(10000000) Then 'we don't want this method to be called too often
                _prevLightUpdTime = Now
                Dim chnls As New List(Of Integer)
                For Each l As ListViewItem In asngLV.Items
                    If l.Text.StartsWith("C") Then
                        chnls.Add(CInt(l.Text.Remove(0, l.Text.IndexOf(":") + 1).Trim))
                    Else
                        If l.SubItems(1).Text.Remove(l.SubItems(1).Text.IndexOf("@")).Trim = "All" Then
                            chnls.AddRange(GetLightChnls(l.Text.Remove(0, l.Text.IndexOf(":") + 1).Trim()))
                        Else
                            chnls.Add(IndChnlToChnl(l.Text.Remove(0, l.Text.IndexOf(":") + 1).Trim,
                                                    l.SubItems(1).Text.Remove(l.SubItems(1).Text.IndexOf("@")).Trim))
                        End If
                    End If
                Next
                For i As Integer = 1 To 511
                    If chnls.Contains(i) Then
                        SetDmxValue(i - 1, 255)
                    Else
                        SetDmxValue(i - 1, 0)
                    End If
                Next
            End If
        End Sub

        Private Sub LoadLv()
            editor.Show()
            visual.Height = visual.Width \ 2
            editor.Hide()
            lv.Items.Clear()
            lv.Columns(0).Width = CInt(lv.Width * 0.9)
            Dim toAdd As New List(Of ListViewItem)
            For Each c As Cue In Cues
                Dim f As String = c.Name
                Dim it As New ListViewItem(f)
                it.Name = f
                it.ImageIndex = 0
                it.Selected = False
                toAdd.Add(it)
            Next
            UpdateVisual()
            lv.Items.AddRange(toAdd.ToArray)
            If lv.Items.Count > 0 Then
                lv.Items(0).Selected = True
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


        ''' <summary>
        '''     Move selected items up or down in the specified listview
        ''' </summary>
        ''' <param name="lvwListView">The listview to manipulate</param>
        ''' <param name="blnMoveUp">True to move items up, False to move them down</param>
        Private Sub MoveItemsInListView(ByRef lvwListView As listViewX, ByVal blnMoveUp As Boolean)
            Try
                'Set the listview index to limit to depending on whether we are moving things up or down in the list
                Dim intLimittedIndex As Integer = (lvwListView.Items.Count - 1)
                If blnMoveUp Then intLimittedIndex = 0

                'Define a new collection of the listview indexes to move
                Dim colIndexesToMove As New List(Of Integer)()

                'Loop through each selected item in the listview (multiple select support)
                For Each lviSelectedItem As ListViewItem In lvwListView.SelectedItems
                    'Add the item's index to the collection
                    colIndexesToMove.Add(lviSelectedItem.Index)

                    'If this item is at the limit we defined
                    If lviSelectedItem.Index = intLimittedIndex Then
                        'Do not attempt to move item(s) as we are at the top or bottom of the list
                        Exit Try
                    End If
                Next

                'If we are moving items down
                If Not blnMoveUp Then
                    'Reverse the index list so that we move items from the bottom of the selection first
                    colIndexesToMove.Reverse()
                End If

                'Loop through each index we want to move
                For Each intIndex As Integer In colIndexesToMove
                    'Define a new listviewitem
                    Dim lviNewItem As ListViewItem = CType(lvwListView.Items(intIndex).Clone(), ListViewItem)

                    'Remove the currently selected item from the list
                    lvwListView.Items(intIndex).Remove()

                    'Insert the new item in it's new place
                    If blnMoveUp Then
                        lvwListView.Items.Insert(intIndex - 1, lviNewItem)
                    Else
                        lvwListView.Items.Insert(intIndex + 1, lviNewItem)
                    End If

                    'Set the new item to be selected
                    lviNewItem.Selected = True
                Next
                SaveCues()
            Catch ex As Exception
                Trace.WriteLine("MoveItemsInListView() has thrown an exception: " & ex.Message)
            Finally
                'Set the focus on the listview
                lvwListView.Focus()
            End Try
        End Sub


        Private Sub lv_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp, lv.KeyUp
            If e.KeyCode = Keys.Shift Then _forceAddLast = False
            If lv.Focused = True Then
                If e.KeyCode = Keys.Delete Then
                    btnDel.PerformClick()
                ElseIf e.KeyCode = Keys.F2 Then
                    btnEdit_MClick(btnEdit, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0))
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
                        CurProject.Settings.SetSetting("Submasters", newItemText, CurProject.Settings.GetSetting("Submasters", lv.SelectedItems(0).Text))
                        loadLv()
                        For Each li As ListViewItem In lv.Items
                            If li.Text = newItemText Then
                                li.Selected = True
                            Else
                                li.Selected = False
                            End If
                        Next
                    End If
                ElseIf e.KeyCode = Keys.Up Then
                    btnMvUp.PerformClick()
                ElseIf e.KeyCode = Keys.Down Then
                    btnMvDn.PerformClick()
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
            Dim i As Integer = 0
            Do
                i += 1
            Loop While lv.Items.ContainsKey("Cue " & i.ToString)
            it.Text = "Cue " & i.ToString
            it.Name = "Cue " & i.ToString
            If lv.Items.Count > 0 Then
                Dim selCue As Cue
                If lv.SelectedItems.Count > 0 Then
                    selCue = GetCueByName(lv.SelectedItems(0).Text)
                ElseIf lv.Items.Count > 0 Then
                    selCue = GetCueByName(lv.Items(lv.Items.Count - 1).Text)
                End If
                Cues.Add(selCue.Clone("Cue " & i.ToString))
                Subs.Add(selCue.GetAssociatedSubmaster.Clone("Cue " & i.ToString))
                SfxCues.Add(selCue.GetAssociatedSfxCue.Clone("Cue " & i.ToString))
                PjxCues.Add(selCue.GetAssociatedPjxCue.Clone("Cue " & i.ToString))
                it.ImageIndex = 0
                it.SubItems.Add("@ 10")
                If lv.SelectedItems.Count > 0 And _forceAddLast = False Then
                    lv.Items.Insert(lv.SelectedItems(0).Index + 1, it)
                Else
                    lv.Items.Add(it)
                End If
            Else
                Cues.Add(New Cue(it.Text, True, True, True))
                Subs.Add(New Submaster(it.Text))
                SfxCues.Add(New SfxCue(it.Text, New List(Of SfxEvent), New List(Of SfxEvent), False))
                PjxCues.Add(New PjxCue(it.Text, "_blackout", PjxEngine.Effect.Fade_In, 1, 0))
                it.ImageIndex = 0
                it.SubItems.Add("@ 10")
                lv.Items.Add(it)
            End If
            For Each li As ListViewItem In lv.SelectedItems
                li.Selected = False
            Next
            visual.Refresh()
            lv.EnsureVisible(it.Index)
            it.Selected = True
            UpdateActiveRects()
            UpdateCueOrder()
            SaveCues()
            CheckCueNum()
        End Sub

        Private Sub vw3Images_Layout(sender As Object, e As LayoutEventArgs) Handles MyBase.Layout
            lv.LargeImageList = ImageCache
        End Sub
        'rename button
        Private Sub btnEdit_MClick(sender As Object, e As MouseEventArgs) Handles btnEdit.MouseUp
            If lv.SelectedItems.Count = 1 Then
                If tbName.Visible Then
                    tbName.Text = tbName.Text.Trim
                    'change sub name
                    If e.Button = MouseButtons.Left And tbName.Text <> lbName.Text Then
                        lbName.Text = tbName.Text
                        For Each r As RectangleX In LightRects
                            If r.Tag.ToString = lv.SelectedItems(0).Text Then
                                r.Tag = tbName.Text
                                Exit For
                            End If
                        Next
                        Dim oldName As String = lv.SelectedItems(0).Text
                        Dim cCue As Cue = GetCueByName(oldName)
                        cCue.GetAssociatedSubmaster.Name = tbName.Text
                        cCue.GetAssociatedSfxCue.CueName = tbName.Text
                        cCue.GetAssociatedPjxCue.Cue = tbName.Text
                        cCue.Name = tbName.Text
                        CurProject.Settings.RenameSetting("Cues", oldName, tbName.Text)
                        CurProject.Settings.RenameSetting("Submasters", oldName, tbName.Text)
                        CurProject.Settings.RenameSetting("Submasters", oldName & " Visual", tbName.Text & " Visual")
                        CurProject.Settings.RenameSetting("Sfx", oldName, tbName.Text)
                        CurProject.Settings.RenameSetting("Projection", lv.SelectedItems(0).Text, tbName.Text)
                        lv.SelectedItems(0).Text = tbName.Text
                        lv.SelectedItems(0).Name = tbName.Text
                    End If
                    lv.EnsureVisible(lv.SelectedIndices(0))
                    visual.Focus()
                    tbName.Visible = False
                    lbName.Visible = True
                    btnEdit.BackColor = Color.FromArgb(160, 160, 160)
                    visual.Refresh()
                    tt.SetToolTip(btnEdit, "Click to edit the name of this cue.")
                Else
                    visual.Focus()
                    tbName.Text = lbName.Text
                    tbName.Visible = True
                    tbName.Top = btnEdit.Top
                    editor.ScrollControlIntoView(tbName)
                    lbName.Visible = False
                    tbName.Focus()
                    tbName.SelectionLength = 0
                    tbName.SelectionStart = tbName.Text.Length
                    btnEdit.BackColor = Color.IndianRed
                    tt.SetToolTip(btnEdit, "Left click to save the cue name, or" & vbCrLf & "right click to cancel.")
                End If
            End If
        End Sub


        Private Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbName.TextChanged
            editor.ScrollControlIntoView(tbName)
            If String.IsNullOrEmpty(tbName.Text) Then
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
            Else
                lbWarning.Hide()
                btnEdit.Enabled = True
            End If
        End Sub

        Private Sub tbName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbName.KeyPress
            If btnEdit.Enabled Then
                If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                    btnEdit_MClick(btnEdit, New MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0))
                    e.Handled = True
                End If
            End If
        End Sub


        Private Sub lv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lv.SelectedIndexChanged
            'hide hidden controls
            FaderBar.Hide()
            btnFader.BackColor = Color.WhiteSmoke
            btnFader.ForeColor = Color.FromArgb(64, 64, 64)
            btnFader.Hide()
            lbSDelay.Hide()
            tbSDelay.Hide()
            lbSFade.Hide()
            tbSFade.Hide()
            lbPDelay.Hide()
            tbPDelay.Hide()
            Try
                If HasSecondMonitor Then
                    If SecondMonitor IsNot Nothing Then
                        SecondMonitor.pb.Image = Nothing
                        If SecondMonitor.pb.BackgroundImage IsNot Nothing Then
                            SecondMonitor.pb.BackgroundImage = Nothing
                        End If
                    End If
                End If
            Catch
            End Try
            If cbType.Visible Then
                cbType.Hide()
                pnlCh.Hide()
                pnlLightSelector.Hide()
            End If
            If tbName.Visible Then
                visual.Focus()
                tbName.Visible = False
                lbName.Visible = True
                btnEdit.BackColor = Color.FromArgb(160, 160, 160)
            End If
            If lv.SelectedItems.Count <> 1 Then
                'multiselect/none selected: hide editor
                editor.Hide()
                If lv.SelectedItems.Count < 1 Then
                    If btnMvDn.Enabled Then
                        btnMvDn.Enabled = False
                        btnMvUp.Enabled = False
                        btnDel.Enabled = False
                    End If
                Else
                    If Not btnMvDn.Enabled Then
                        btnMvDn.Enabled = True
                        btnMvUp.Enabled = True
                        btnDel.Enabled = True
                    End If
                End If
            Else
                'load light tab
                lvToPlay.Items.Clear()
                lvToStop.Items.Clear()
                lbName.Text = lv.SelectedItems(0).Text
                If Not editor.Visible Then editor.Show()
                If Not btnMvDn.Enabled Then
                    btnDel.Enabled = True
                    btnMvDn.Enabled = True
                    btnMvUp.Enabled = True
                End If
                SetControlPos()
                asngLV.Items.Clear()
                For Each rx As RectangleX In LightRects
                    rx.IsActive = False
                Next
                Dim chnlsToAdd As New List(Of ListViewItem)
                For Each s As Submaster In Subs
                    If s.Name = lv.SelectedItems(0).Text Then
                        For Each chnl As KeyValuePair(Of Integer, Integer) In s.ChannelList
                            Dim it As New ListViewItem("C: " & padZeros(chnl.Key))
                            it.Name = "C: " & padZeros(chnl.Key)
                            it.ImageIndex = 1
                            it.SubItems.Add("@ " & CStr(Math.Round(chnl.Value / 25.5, 1)))
                            chnlsToAdd.Add(it)
                        Next
                        Dim toRem As New List(Of Channel)
                        For Each chnl As KeyValuePair(Of Channel, Integer) In s.LightList
                            If String.IsNullOrEmpty(chnl.Key.ParentLight) Then
                                toRem.Add(chnl.Key)
                            Else
                                Dim it As New ListViewItem("L: " & chnl.Key.ParentLight)
                                it.Name = "L: " & chnl.Key.ParentLight
                                it.ImageIndex = 2
                                it.SubItems.Add(chnl.Key.Name & " @ " & CStr(Math.Round(chnl.Value / 25.5, 1)))
                                For Each rx As RectangleX In LightRects
                                    If rx.Tag.ToString = chnl.Key.ParentLight Then
                                        rx.IsActive = True
                                    End If
                                Next
                                chnlsToAdd.Add(it)
                            End If
                        Next
                        While toRem.Count > 0
                            s.LightList.Remove(toRem(toRem.Count - 1))
                            toRem.RemoveAt(toRem.Count - 1)
                        End While
                        tbFadeTime.Text = s.Duration.ToString
                        tbFadeDelay.Text = s.Delay.ToString
                        Exit For
                    End If
                Next
                asngLV.Items.AddRange(chnlsToAdd.ToArray)
                'load sound tab
                lvToPlay.Items.Clear()
                lvToStop.Items.Clear()
                Dim cursfx As SfxCue = GetSfxCueByName(lv.SelectedItems(0).Text)
                Dim toAddP As New List(Of ListViewItem)
                For Each ev As SfxEvent In cursfx.PlayEvents
                    Dim i As New ListViewItem(ev.NameOfRes)
                    i.ImageIndex = 0
                    i.SubItems.Add(ev.Delay.ToString & "s")
                    toAddP.Add(i)
                Next
                lvToPlay.Items.AddRange(toAddP.ToArray)
                Dim toAddS As New List(Of ListViewItem)
                For Each ev As SfxEvent In cursfx.StopEvents
                    Dim i As New ListViewItem(ev.NameOfRes)
                    i.ImageIndex = 0
                    i.SubItems.Add(ev.FadeDuration.ToString & "s")
                    i.SubItems.Add(ev.Delay.ToString & "s")
                    toAddS.Add(i)
                Next
                lvToStop.Items.AddRange(toAddS.ToArray)
                cbStopAll.Checked = cursfx.StopAll
                lvToPlay.Columns(0).Width = CInt(lvToPlay.Width * 0.8)
                lvToPlay.Columns(1).Width = CInt(lvToPlay.Width * 0.2)
                lvToStop.Columns(0).Width = CInt(lvToStop.Width * 0.6 - 2)
                lvToStop.Columns(1).Width = CInt(lvToStop.Width * 0.2)
                lvToStop.Columns(2).Width = CInt(lvToStop.Width * 0.2)
                If lvToPlay.Items.Count > 0 Then lvToPlay.Items(0).Selected = True
                If lvToStop.Items.Count > 0 Then lvToStop.Items(0).Selected = True

                'load pjx tab
                cbPjxEffect.Items.Clear()
                Dim enumVals() As String = [Enum].GetNames(GetType(PjxEngine.Effect))
                For i As Integer = 0 To enumVals.Length - 2
                    cbPjxEffect.Items.Add(enumVals(i).Replace("_", " "))
                Next

                Dim curCue As Cue = GetCueByName(lv.SelectedItems(0).Text)
                Dim curPjxCue As PjxCue = curCue.GetAssociatedPjxCue
                cbPjxEffect.SelectedIndex = CInt(curPjxCue.Effect)
                tbPJXDur.Text = CStr(curPjxCue.Duration)
                tbPJXDelay.Text = CStr(curPjxCue.Delay)
                If curPjxCue.NameOfRes = "_blackout" Then
                    Dim blackout As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                    Using g As Graphics = Graphics.FromImage(blackout)
                        g.Clear(Color.Black)
                    End Using
                    pbPjx.Image = GetThumbnail(blackout, pbPjx.Width, pbPjx.Height, Color.FromArgb(160, 160, 160))
                    SecondMonitor.pb.BackgroundImage = Nothing
                Else
                    SecondMonitor.pb.BackgroundImage = GetThumbnail(ImgResToPath(curPjxCue.NameOfRes), SecondMonitor.pb.Width, SecondMonitor.pb.Height, Color.Black)
                    pbPjx.Image = GetThumbnail(ImgResToPath(curPjxCue.NameOfRes), pbPjx.Width, pbPjx.Height,
                                                           Color.FromArgb(160, 160, 160))
                End If

                lbPjx.Text = curPjxCue.NameOfRes
                'load cue base
                cbLFX.Checked = curCue.IsLfxOn
                cbSFX.Checked = curCue.IsSfxOn
                cbPJX.Checked = curCue.IsPjxOn
                tabLFX.Enabled = curCue.IsLfxOn
                tabSFX.Enabled = curCue.IsSfxOn
                tabPJX.Enabled = curCue.IsPjxOn
                Select Case My.Settings.favCueTab
                    Case 1
                        SetupTab(CuesTab.Lfx)
                    Case 2
                        SetupTab(CuesTab.Sfx)
                    Case 3
                        SetupTab(CuesTab.Pjx)
                    Case 0
                        SetupTab(CuesTab.None)
                    Case Else
                        If cbLFX.Checked Then
                            SetupTab(CuesTab.Lfx)
                        ElseIf cbSFX.Checked Then
                            SetupTab(CuesTab.Sfx)
                        ElseIf cbPJX.Checked Then
                            SetupTab(CuesTab.Pjx)
                        Else
                            SetupTab(CuesTab.None)
                        End If
                End Select
                If tabLFX.Enabled = False Then
                    tabLFX.BackColor = Color.FromArgb(100, 100, 100)
                Else
                    If tabLFX.Tag Is Nothing Then
                        tabLFX.BackColor = Color.FromArgb(170, 170, 170)
                    Else
                        tabLFX.BackColor = Color.Gainsboro
                    End If
                End If
                If tabSFX.Enabled = False Then
                    tabSFX.BackColor = Color.FromArgb(100, 100, 100)
                Else
                    If tabSFX.Tag Is Nothing Then
                        tabSFX.BackColor = Color.FromArgb(170, 170, 170)
                    Else
                        tabSFX.BackColor = Color.Gainsboro
                    End If
                End If
                If tabPJX.Enabled = False Then
                    tabPJX.BackColor = Color.FromArgb(100, 100, 100)
                Else
                    If tabPJX.Tag Is Nothing Then
                        tabPJX.BackColor = Color.FromArgb(170, 170, 170)
                    Else
                        tabPJX.BackColor = Color.Gainsboro
                    End If
                End If
            End If
            'UpdateVisual(visual)
            If lv.SelectedItems.Count > 0 Then lv.EnsureVisible(lv.SelectedIndices(0))
            lv.Refresh()
            UpdateLights()
        End Sub

        Private Function GetCurCue() As Cue
            Return GetCueByName(lv.SelectedItems(0).Text)
        End Function

        Private Function GetCurSfxCue() As SfxCue
            Return GetSfxCueByName(lv.SelectedItems(0).Text)
        End Function

        Private Function GetCurPjxCue() As PjxCue
            Return GetPjxCueByName(lv.SelectedItems(0).Text)
        End Function

        Private Sub SetupTab(tab As CuesTab)
            Select Case tab
                Case CuesTab.lfx
                    _curTab = CuesTab.lfx
                    tabLFX.Tag = 1
                    SelTab(tabLFX)
                    tabSFX.Tag = Nothing
                    SelTab(tabSFX, False)
                    tabPJX.Tag = Nothing
                    SelTab(tabPJX, False)
                    My.Settings.favCueTab = 1
                    pnlLFX.Show()
                    pnlSFX.Hide()
                    pnlPJX.Hide()
                Case CuesTab.sfx
                    _curTab = CuesTab.sfx
                    tabLFX.Tag = Nothing
                    SelTab(tabLFX, False)
                    tabSFX.Tag = 1
                    SelTab(tabSFX)
                    tabPJX.Tag = Nothing
                    SelTab(tabPJX, False)
                    My.Settings.favCueTab = 2
                    pnlLFX.Hide()
                    pnlSFX.Show()
                    pnlPJX.Hide()
                Case CuesTab.pjx
                    _curTab = CuesTab.pjx
                    tabLFX.Tag = Nothing
                    SelTab(tabLFX, False)
                    tabSFX.Tag = Nothing
                    SelTab(tabSFX, False)
                    tabPJX.Tag = 1
                    SelTab(tabPJX)
                    My.Settings.favCueTab = 3
                    pnlLFX.Hide()
                    pnlSFX.Hide()
                    pnlPJX.Show()
                Case CuesTab.none
                    _curTab = CuesTab.none
                    SelTab(tabLFX, False)
                    SelTab(tabSFX, False)
                    SelTab(tabPJX, False)
                    tabLFX.Tag = Nothing
                    tabSFX.Tag = Nothing
                    tabPJX.Tag = Nothing
                    pnlLFX.Hide()
                    pnlSFX.Hide()
                    pnlPJX.Hide()
            End Select
            My.Settings.Save()
        End Sub

        Private Sub UpdateActiveRects()
            For Each rx As RectangleX In LightRects
                rx.IsActive = False
            Next
            For Each s As Submaster In Subs
                If s.Name = lv.SelectedItems(0).Text Then
                    For Each chnl As KeyValuePair(Of Channel, Integer) In s.LightList
                        If Not String.IsNullOrEmpty(chnl.Key.ParentLight) Then
                            For Each rx As RectangleX In LightRects
                                If rx.Tag.ToString = chnl.Key.ParentLight Then
                                    rx.IsActive = True
                                End If
                            Next
                        End If
                    Next
                    Exit For
                End If
            Next
            visual.Refresh()
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
            If MsgBox("Delete the cue" & s & "''" & resNames & "''?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation _
                                                                      Or MsgBoxStyle.MsgBoxSetForeground, "Delete Cue" & s) =
               MsgBoxResult.Yes Then
                For Each i As ListViewItem In lv.SelectedItems
                    i.Selected = False
                    CurProject.Settings.DeleteSetting("Submasters", i.Text)
                    CurProject.Settings.DeleteSetting("Cues", i.Text)
                    CurProject.Settings.DeleteSetting("Sfx", i.Text)
                    CurProject.Settings.DeleteSetting("Projection", i.Text)
                    Subs.Remove(GetSubmasterByName(i.Text))
                    Cues.Remove(GetCueByName(i.Text))
                    SfxCues.Remove(GetSfxCueByName(i.Text))
                    PjxCues.Remove(GetPjxCueByName(i.Text))
                Next
                loadLv()
                For Each i As ListViewItem In lv.SelectedItems
                    i.Selected = False
                Next
                editor.Hide()
                If lv.Items.Count > 0 Then lv.Items(0).Selected = True
                visual.Refresh()
                CheckCueNum()
                SaveCues()
            End If
        End Sub

        Private Sub channelsView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles asngLV.SelectedIndexChanged
            FaderBar.Hide()
            btnFader.BackColor = Color.WhiteSmoke
            btnFader.ForeColor = Color.FromArgb(64, 64, 64)
            If asngLV.SelectedItems.Count <> 1 Then
                pnlCh.Hide()
                pnlLightSelector.Hide()
                cbType.Hide()
                btnFader.Hide()
                If asngLV.SelectedItems.Count < 1 Then
                    btnRemCh.Enabled = False
                Else
                    btnRemCh.Enabled = True
                End If
            Else
                Dim s As Submaster
                For Each sm As Submaster In Subs
                    If sm.Name = lv.SelectedItems(0).Text Then
                        s = sm
                        Exit For
                    End If
                Next
                If asngLV.SelectedItems(0).Text.StartsWith("C:") Then
                    cbType.SelectedIndex = 1
                    Dim key As Integer = CInt(unpadZeros(asngLV.SelectedItems(0).Text _
                                                            .Remove(0, asngLV.SelectedItems(0).Text.IndexOf(":") + 1).Trim))
                    numChID.Value = key
                    pnlLightSelector.Hide()
                    pnlCh.Show()

                    If s.ChannelList.ContainsKey(key) Then
                        btnFader.Text = CStr(Math.Round(s.ChannelList(key) / 25.5, 1))
                    Else
                        btnFader.Text = "10"
                    End If
                Else
                    cbType.SelectedIndex = 0
                    cbLLight.Items.Clear()
                    cbLChTag.Items.Clear()
                    cbLChTag.Items.Add("All")
                    For Each l As Light In Lights
                        cbLLight.Items.Add(l.Name)
                        If _
                            l.Name =
                            asngLV.SelectedItems(0).Text.Remove(0, asngLV.SelectedItems(0).Text.IndexOf(":") + 1).Trim Then
                            For Each c As Channel In l.Channels
                                cbLChTag.Items.Add(c.Name)
                            Next
                        End If
                    Next
                    For i As Integer = 0 To cbLLight.Items.Count - 1
                        If _
                            cbLLight.Items(i).ToString =
                            asngLV.SelectedItems(0).Text.Remove(0, asngLV.SelectedItems(0).Text.IndexOf(":") + 1).Trim Then
                            cbLLight.SelectedIndex = i
                            Exit For
                        End If
                    Next
                    For i As Integer = 0 To cbLChTag.Items.Count - 1
                        If _
                            cbLChTag.Items(i).ToString =
                            asngLV.SelectedItems(0).SubItems(1).Text.Remove(
                                asngLV.SelectedItems(0).SubItems(1).Text.IndexOf("@")).Trim Then
                            cbLChTag.SelectedIndex = i
                            Exit For
                        End If
                    Next
                    pnlCh.Hide()
                    pnlLightSelector.Show()
                    btnFader.Text = "10" 'set to 10 in case none found
                    For Each l As KeyValuePair(Of Channel, Integer) In s.LightList
                        If _
                            l.Key.Name =
                            asngLV.SelectedItems(0).SubItems(1).Text.Remove(
                                asngLV.SelectedItems(0).SubItems(1).Text.IndexOf("@")).Trim And
                            l.Key.ParentLight =
                            asngLV.SelectedItems(0).Text.Remove(0, asngLV.SelectedItems(0).Text.IndexOf(":") + 1).Trim Then
                            btnFader.Text = CStr(Math.Round(l.Value / 25.5, 1))
                            Exit For
                        End If
                    Next
                End If
                btnFader.Show()
                cbType.Show()
                btnRemCh.Enabled = True
            End If
        End Sub

        Private Sub numChID_ValueChanged(sender As Object, e As EventArgs) Handles numChID.ValueChanged
            If asngLV.SelectedIndices.Count = 1 Then
                asngLV.SelectedItems(0).Text = "C: " & padZeros(CInt(numChID.Value))
                saveChannels()
                asngLV.Sort()
                updateLights()
            End If
        End Sub

        Private Sub cmbChTag_TextChanged(sender As Object, e As EventArgs) Handles cbLChTag.SelectedIndexChanged
            If cbLChTag.Text <> "" And asngLV.SelectedIndices.Count = 1 Then
                Dim temp As String =
                        asngLV.SelectedItems(0).SubItems(1).Text.Remove(0,
                                                                        asngLV.SelectedItems(0).SubItems(1).Text.IndexOf("@")) _
                        .Trim
                asngLV.SelectedItems(0).SubItems(1).Text = cbLChTag.Text & " " & temp
                saveChannels()
                UpdateLights()
            End If
        End Sub

        Private Sub cbLLight_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLLight.SelectedIndexChanged
            If cbLLight.Text <> "" And asngLV.SelectedIndices.Count = 1 Then
                asngLV.SelectedItems(0).Text = "L: " & cbLLight.Text
                saveChannels()
                asngLV.Sort()
                updateActiveRects()
                updateLights()
            End If
        End Sub

        Private Sub SaveChannels()
            If lv.SelectedItems.Count = 1 Then
                For Each s As Submaster In Subs
                    If s.Name = lv.SelectedItems(0).Text Then
                        Dim bkupChnlLst As New Dictionary(Of Integer, Integer)
                        For Each c As KeyValuePair(Of Integer, Integer) In s.ChannelList
                            bkupChnlLst.Add(c.Key, c.Value)
                        Next
                        Dim bkupLightLst As New Dictionary(Of Channel, Integer)
                        For Each l As KeyValuePair(Of Channel, Integer) In s.LightList
                            bkupLightLst.Add(l.Key, l.Value)
                        Next
                        s.ChannelList.Clear()
                        s.LightList.Clear()
                        For Each li As ListViewItem In asngLV.Items
                            If li.Text.StartsWith("C") Then
                                Dim key As Integer = CInt(unpadZeros(li.Text.Remove(0, li.Text.IndexOf(":") + 1).Trim))
                                If bkupChnlLst.ContainsKey(key) Then
                                    s.ChannelList.Add(key, bkupChnlLst(key))
                                Else
                                    s.ChannelList.Add(key, 255)
                                End If
                            Else
                                Dim chnlName As String = li.SubItems(1).Text.Remove(li.SubItems(1).Text.IndexOf("@")).Trim
                                Dim chnlID As Integer = 1
                                Dim parentLight As String = li.Text.Remove(0, li.Text.IndexOf(":") + 1).Trim
                                For Each l As Light In Lights
                                    If l.Name = parentLight Then
                                        For Each c As Channel In l.Channels
                                            If c.Name = chnlName Then
                                                chnlID = c.Channel
                                                Exit For
                                            End If
                                        Next
                                        Exit For
                                    End If
                                Next
                                Dim containsKey As Boolean = False
                                Dim origKey As Channel
                                For Each c As Channel In bkupLightLst.Keys
                                    If c.Name = chnlName And c.Channel = chnlID And c.ParentLight = parentLight Then
                                        containsKey = True
                                        origKey = c
                                        Exit For
                                    End If
                                Next
                                If containsKey = True Then
                                    s.LightList.Add(New Channel(chnlName, chnlID, parentLight), bkupLightLst(origKey))
                                    'MsgBox(key.ParentLight & ":" & key.Name & vbCrLf & CStr(bkupLightLst(key)))
                                Else
                                    s.LightList.Add(New Channel(chnlName, chnlID, parentLight), 255)
                                End If
                            End If
                        Next
                        CurProject.Settings.SetSetting("Submasters", lv.SelectedItems(0).Text, s.ToString)
                        Exit For
                    End If
                Next
            End If
        End Sub

        Private Sub btnRemCh_Click(sender As Object, e As EventArgs) Handles btnRemCh.Click
            If asngLV.SelectedItems.Count > 0 Then
                For Each i As ListViewItem In asngLV.SelectedItems
                    asngLV.Items.Remove(i)
                    For Each r As RectangleX In LightRects
                        If i.Text.Remove(0, i.Text.IndexOf(":") + 1).Trim = r.Tag.ToString Then
                            r.IsActive = False
                        End If
                    Next
                Next
                saveChannels()
                visual.Refresh()
                updateLights()
            End If
        End Sub

        Private Sub btnAddCh_Click(sender As Object, e As EventArgs) Handles btnAddCh.Click
            Dim it As New ListViewItem()
            Dim i As Integer = 1
            While asngLV.Items.ContainsKey("C: " & padZeros(i))
                i += 1
            End While
            If i > 255 Then
                Exit Sub
            End If
            it.Text = "C: " & padZeros(i)
            it.Name = it.Text
            it.ImageIndex = 1
            it.SubItems.Add("@ 10")
            For Each j As ListViewItem In asngLV.SelectedItems
                j.Selected = False
            Next
            asngLV.Items.Add(it)
            it.Selected = True
            saveChannels()
            updateLights()
        End Sub
        'Private Sub btnLightingBD_Click(sender As Object, e As EventArgs) Handles btnLightingBD.Click
        '    For Each i As ListViewItem In asngLV.CheckedItems
        '        i.Checked = False
        '    Next
        '    With frmLightingBd
        '        '.Width = Screen.PrimaryScreen.WorkingArea.Width
        '        '.Height = Screen.PrimaryScreen.WorkingArea.Height / 7 * 5
        '        .MaximumSize = Screen.PrimaryScreen.WorkingArea.Size
        '        .Left = CInt(Screen.PrimaryScreen.WorkingArea.Width / 2 - .Width / 2)
        '        .Top = CInt(Screen.PrimaryScreen.WorkingArea.Height / 2 - .Height / 2)
        '        .Opacity = 1
        '        frmLightBox.Show()
        '        frmLightBox.BringToFront()
        '        .Show()
        '        .BringToFront()
        '    End With
        'End Sub

        Private Sub channelsView_ItemActivate(sender As Object, e As EventArgs) Handles asngLV.ItemActivate
            If asngLV.SelectedItems.Count > 0 Then
                For Each i As ListViewItem In asngLV.SelectedItems
                    i.Checked = Not i.Checked
                Next
            End If
        End Sub

        Private Sub channelsView_KeyUp(sender As Object, e As KeyEventArgs) Handles asngLV.KeyUp
            If e.Control Then
                Select Case e.KeyCode
                    Case Keys.A
                        For Each i As ListViewItem In asngLV.Items
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
                    cbLChTag.Focus()
            End Select
        End Sub

        Private Sub paintLight(ByVal g As Graphics, ByVal clipRec As Rectangle, ByVal cRec As RectangleX,
                               ByVal name As String)
            Using blackPen As New Pen(Color.fromArgb(100, 100, 100))
                Using blackBr As New SolidBrush(Color.fromArgb(100, 100, 100))
                    Using lightBr As New SolidBrush(Color.FromArgb(70, Color.GhostWhite))
                        Using segoeUI As New Font("Segoe UI SemiLight", 10)
                            g.SmoothingMode = SmoothingMode.HighQuality
                            g.CompositingQuality = CompositingQuality.HighQuality
                            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                            g.DrawEllipse(blackPen, cRec.ToRectangle)
                            g.FillEllipse(lightBr, cRec.ToRectangle)

                            Dim sz As SizeF = g.MeasureString(name, segoeUI)
                            g.DrawString(name, segoeUI, blackBr, CInt(cRec.Left + cRec.Width / 2 - sz.Width / 2),
                                         CInt(cRec.Top + cRec.Height / 2 - sz.Height / 2))
                        End Using
                    End Using
                End Using
            End Using
        End Sub

        Private Sub paintSelectedLight(ByVal g As Graphics, ByVal clipRec As Rectangle, ByVal cRec As RectangleX,
                                       ByVal name As String)
            If cRec IsNot Nothing Then
                Using whitePen As New Pen(Color.White, 2)
                    Using blackPen As New Pen(Color.fromArgb(80, 80, 80))
                        Using transBr As New SolidBrush(Color.FromArgb(100, Color.White))
                            Using lightBr As New SolidBrush(Color.FromArgb(100, Color.FromArgb(255, 191, 0))) 'amber
                                Using opaqueBr As New SolidBrush(Color.FromArgb(170, Color.fromArgb(100, 100, 100)))
                                    Using veryTransBr As New SolidBrush(Color.FromArgb(50, Color.AliceBlue))
                                        g.SmoothingMode = SmoothingMode.HighQuality
                                        g.CompositingQuality = CompositingQuality.HighQuality
                                        g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                                        g.DrawEllipse(blackPen, cRec.ToRectangle)
                                        g.FillEllipse(lightBr, cRec.ToRectangle)
                                        Using blackBr As New SolidBrush(Color.fromArgb(80, 80, 80))
                                            Using segoeUI As New Font("Segoe UI SemiLight", 10)
                                                Dim sz As SizeF = g.MeasureString(name, segoeUI)
                                                g.DrawString(name, segoeUI, blackBr,
                                                             CInt(cRec.Left + cRec.Width / 2 - sz.Width / 2),
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
                    Using segoeUI As New Font("Segoe UI SemiLight", 8)
                        e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
                        Dim sz As SizeF = e.Graphics.MeasureString("Audience (Click To Flip)", segoeUI)
                        If My.Settings.lightVisualReverse Then
                            e.Graphics.FillRectangle(bgBr, 0, visual.Height - CInt(visual.Height / 10), visual.Width,
                                                     CInt(visual.Height / 10))
                            e.Graphics.DrawString("Audience (Click To Flip)", segoeUI, br, CInt(visual.Width / 2 - sz.Width / 2),
                                                  CInt(visual.Height / 20 * 19 - sz.Height / 2))
                        Else
                            e.Graphics.FillRectangle(bgBr, 0, 0, visual.Width, CInt(visual.Height / 10))
                            e.Graphics.DrawString("Audience (Click To Flip)", segoeUI, br, CInt(visual.Width / 2 - sz.Width / 2),
                                                  CInt(visual.Height / 20 - sz.Height / 2))
                        End If
                    End Using
                End Using
            End Using
            Dim selRect As New List(Of RectangleX)
            For i As Integer = LightRects.Count - 1 To 0 Step -1
                Dim r As RectangleX = LightRects(i)
                If My.Settings.lightVisualReverse Then
                    Dim inverseR As New RectangleX(r.Left, visual.Height - r.Bottom, r.Width, r.Height)
                    inverseR.Tag = r.Tag
                    If r.IsActive Then
                        selRect.Add(inverseR)
                    Else
                        paintLight(e.Graphics, e.ClipRectangle, inverseR, r.Tag.ToString)
                    End If
                Else
                    If r.IsActive Then
                        selRect.Add(r)
                    Else
                        paintLight(e.Graphics, e.ClipRectangle, r, r.Tag.ToString)
                    End If
                End If
            Next
            If selRect.Count > 0 Then
                For i As Integer = 0 To selRect.Count - 1
                    paintSelectedLight(e.Graphics, e.ClipRectangle, selRect(i), selRect(i).Tag.ToString)
                Next
            End If
        End Sub

        Private Sub visual_MouseDown(sender As Object, e As MouseEventArgs) Handles visual.MouseDown
            Dim cRec As RectangleX
            For Each r As RectangleX In LightRects
                If r.IsActive Then
                    If My.Settings.lightVisualReverse Then
                        cRec = New RectangleX(r.Left, visual.Height - r.Bottom, r.Width, r.Height)
                    Else
                        cRec = r
                    End If
                    Exit For
                End If
            Next
            Dim foundNewRect As Boolean = False
            Dim mousePos As Point = e.Location
            If My.Settings.lightVisualReverse Then
                mousePos = New Point(mousePos.X, visual.Height - mousePos.Y)
            End If

            For Each r As RectangleX In LightRects
                If isInEllipse(mousePos, r.ToRectangle) Then
                    foundNewRect = True
                    If r.IsActive Then
                        r.IsActive = False
                        Dim toRemove As New List(Of Integer)
                        For Each i As ListViewItem In asngLV.Items
                            If i.Text.StartsWith("L") Then
                                If i.Text.Remove(0, i.Text.IndexOf(":") + 1).Trim = r.Tag.ToString Then
                                    toRemove.Add(i.Index)
                                End If
                            End If
                        Next
                        'remove after to prevent "collection modified, enumeration may not execute" error
                        For i As Integer = 0 To toRemove.Count - 1
                            Dim rInt As Integer = toRemove(i) - i
                            asngLV.Items.RemoveAt(rInt)
                        Next
                        saveChannels()
                        updateLights()
                    Else
                        r.IsActive = True
                        For Each l As Light In Lights
                            If l.Name = r.Tag.ToString Then
                                Dim c As Channel = l.GetMainChannel
                                Dim i As New ListViewItem("L: " & l.Name)
                                i.ImageIndex = 2
                                i.SubItems.Add(c.Name & " @ 10")
                                For Each li As ListViewItem In asngLV.SelectedItems
                                    li.Selected = False 'deselect all other items
                                Next
                                asngLV.Items.Add(i)
                                asngLV.Sort()
                                i.Selected = True
                                Exit For
                            End If
                        Next
                    End If
                    saveChannels()
                    Exit For
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
            editor.ScrollControlIntoView(btnEdit)
            visual.Refresh()
        End Sub

        Private Function isInRect(pt As Point, rect As Rectangle) As Boolean
            If pt.X > rect.X And pt.Y > rect.Y And pt.X < rect.Right And pt.Y < rect.Bottom Then Return True Else _
                Return False
        End Function

        Private Function isInEllipse(ByVal pt As Point, ByVal rect As Rectangle) As Boolean
            Dim gp As New GraphicsPath()
            gp.AddEllipse(rect)
            Return gp.IsVisible(pt)
        End Function

        Private Sub visual_MouseUp(sender As Object, e As MouseEventArgs) Handles visual.MouseUp
            visual.Refresh()
            lv.Focus()
        End Sub

        Private Sub cbType_TextChanged(sender As Object, e As EventArgs) Handles cbType.TextChanged
            If asngLV.SelectedItems.Count = 1 Then
                If cbType.SelectedIndex = 1 Then
                    'chnl
                    If Not asngLV.SelectedItems(0).Text.StartsWith("C") Then
                        Dim i As Integer = 1
                        While asngLV.Items.ContainsKey("C: " & padZeros(i))
                            i += 1
                        End While
                        If i > 255 Then
                            Exit Sub
                        End If
                        pnlCh.Show()
                        pnlLightSelector.Hide()
                        asngLV.SelectedItems(0).Text = "C: " & padZeros(i)
                        numChID.Value = 1
                        asngLV.SelectedItems(0).ImageIndex = 1
                        Dim temp As String =
                                asngLV.SelectedItems(0).SubItems(1).Text.Remove(0,
                                                                                asngLV.SelectedItems(0).SubItems(1).Text.
                                                                                   IndexOf("@")).Trim
                        asngLV.SelectedItems(0).SubItems(1).Text = temp
                        saveChannels()
                        updateActiveRects()
                    End If
                Else
                    'light
                    If Not asngLV.SelectedItems(0).Text.StartsWith("L") Then
                        pnlCh.Hide()
                        pnlLightSelector.Show()
                        asngLV.SelectedItems(0).ImageIndex = 2
                        cbType.SelectedIndex = 0
                        cbLLight.Items.Clear()
                        cbLChTag.Items.Clear()
                        If Lights.Count <> 0 Then
                            For Each l As Light In Lights
                                cbLLight.Items.Add(l.Name)
                                If l.Name = Lights(0).Name Then
                                    asngLV.SelectedItems(0).Text = "L: " & l.Name
                                    For Each c As Channel In l.Channels
                                        cbLChTag.Items.Add(c.Name)
                                    Next
                                End If
                            Next
                            Dim temp As String =
                                    asngLV.SelectedItems(0).SubItems(1).Text.Remove(0,
                                                                                    asngLV.SelectedItems(0).SubItems(1).Text _
                                                                                       .IndexOf("@")).Trim
                            asngLV.SelectedItems(0).SubItems(1).Text = cbLChTag.Items(0).ToString & " " & temp
                            cbLLight.SelectedIndex = 0
                            cbLChTag.SelectedIndex = 0
                        Else
                            MsgBox("No lights are available for programming!", MsgBoxStyle.Information,
                                   "No Lights Available")
                            cbType.SelectedIndex = 1
                        End If
                    End If
                End If
                updateLights()
            End If
        End Sub

        Private Sub vw1Light_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            For Each it As ListViewItem In asngLV.SelectedItems
                it.Selected = False
            Next
        End Sub

        Private Sub btnMvUp_Click(sender As Object, e As EventArgs) Handles btnMvUp.Click
            MoveItemsInListView(lv, True)
            UpdateCueOrder()
            SaveCues()
        End Sub

        Private Sub btnMvDn_Click(sender As Object, e As EventArgs) Handles btnMvDn.Click
            MoveItemsInListView(lv, False)
            UpdateCueOrder()
            SaveCues()
        End Sub

        Private Sub btnFader_Click(sender As Object, e As EventArgs) Handles btnFader.Click
            FaderBar.Top = btnFader.Top - FaderBar.Height
            If asngLV.SelectedItems.Count > 0 Then
                If FaderBar.Visible Then
                    FaderBar.Hide()
                    btnFader.BackColor = Color.WhiteSmoke
                    btnFader.ForeColor = Color.FromArgb(64, 64, 64)
                Else
                    btnFader.BackColor = Color.IndianRed
                    btnFader.ForeColor = Color.White
                    Dim s As Submaster = GetSubmasterByName(lv.SelectedItems(0).Text)
                    If asngLV.SelectedItems(0).Text.StartsWith("C") Then
                        For Each c As KeyValuePair(Of Integer, Integer) In s.ChannelList
                            If _
                                c.Key =
                                CInt(
                                    unpadZeros(
                                        asngLV.SelectedItems(0).Text.Remove(0, asngLV.SelectedItems(0).Text.IndexOf(":") + 1) _
                                                  .Trim)) Then
                                FaderBar.Value = s.ChannelList(c.Key)
                                Exit For
                            End If
                        Next
                    Else
                        For Each l As KeyValuePair(Of Channel, Integer) In s.LightList
                            Dim temp As String =
                                    asngLV.SelectedItems(0).SubItems(1).Text.Remove(
                                        asngLV.SelectedItems(0).SubItems(1).Text.IndexOf("@")).Trim
                            If l.Key.Name = temp And
                               l.Key.ParentLight =
                               asngLV.SelectedItems(0).Text.Remove(0, asngLV.SelectedItems(0).Text.IndexOf(":") + 1).Trim _
                                Then
                                FaderBar.Value = s.LightList(l.Key)
                                Exit For
                            End If
                        Next
                    End If
                    Cursor.Position = New Point(CInt(editor.Left + pnlLFX.Left + FaderBar.Left + FaderBar.Width / 2),
                                                CInt(Cursor.Position.Y - FaderBar.Height * (FaderBar.Value / 255) _
                                                     - 30 + (30 * (FaderBar.Value / 255))))
                    FaderBar.Show()
                End If
            End If
        End Sub

        Private Sub FaderBar_Scroll(sender As Object, e As EventArgs) Handles FaderBar.Scroll
            If asngLV.SelectedItems.Count > 0 Then
                btnFader.Text = CStr(Math.Round(FaderBar.Value / 25.5, 1))
                Dim s As Submaster = GetSubmasterByName(lv.SelectedItems(0).Text)
                Dim temp As String =
                        asngLV.SelectedItems(0).SubItems(1).Text.Remove(asngLV.SelectedItems(0).SubItems(1).Text.IndexOf("@")) _
                        .Trim
                If asngLV.SelectedItems(0).Text.StartsWith("C") Then
                    For Each c As KeyValuePair(Of Integer, Integer) In s.ChannelList
                        If _
                            c.Key =
                            CInt(
                                unpadZeros(
                                    asngLV.SelectedItems(0).Text.Remove(0, asngLV.SelectedItems(0).Text.IndexOf(":") + 1).
                                              Trim)) Then
                            s.ChannelList(c.Key) = FaderBar.Value
                            asngLV.SelectedItems(0).SubItems(1).Text = "@ " & CStr(Math.Round(FaderBar.Value / 25.5, 1))
                            Exit For
                        End If
                    Next
                Else
                    For Each l As KeyValuePair(Of Channel, Integer) In s.LightList
                        If l.Key.Name = temp And
                           l.Key.ParentLight =
                           asngLV.SelectedItems(0).Text.Remove(0, asngLV.SelectedItems(0).Text.IndexOf(":") + 1).Trim Then
                            s.LightList(l.Key) = FaderBar.Value
                            asngLV.SelectedItems(0).SubItems(1).Text = temp & " @ " &
                                                                       CStr(Math.Round(FaderBar.Value / 25.5, 1))
                            Exit For
                        End If
                    Next
                End If
                saveChannels()
            End If
        End Sub


        Private Sub tb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbFadeTime.KeyPress, tbFadeDelay.KeyPress,
                                                                                  tbSDelay.KeyPress, tbPDelay.KeyPress,
                                                                                  tbPJXDelay.KeyPress, tbPJXDur.KeyPress,
                                                                                  tbAllDelay.KeyPress, tbAllFade.KeyPress
            Select Case e.KeyChar
                Case "0"c To "9"c
                    'allow the char
                Case "."c
                    If DirectCast(sender, TextBox).Text.Contains(".") Then e.Handled = True _
                    'suppress the keypress if there is already a decimal point
                Case Convert.ToChar(Keys.Back)
                    'allow
                Case Else
                    e.Handled = True
            End Select
        End Sub

        Private Sub tbFadeTime_TextChanged(sender As Object, e As EventArgs) Handles tbFadeTime.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbFadeTime.Text.Trim) Then
                    tbFadeTime.Text = tbFadeTime.Text.Trim
                    Dim fadeTime As Double = CDbl(tbFadeTime.Text) 'see if converting works
                    If fadeTime > 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        'save the fade time
                        Dim curSubName As String = lv.SelectedItems(0).Text
                        For Each s As Submaster In Subs
                            If s.Name = curSubName Then
                                s.Duration = fadeTime
                                CurProject.Settings.SetSetting("Submasters", curSubName, s.ToString)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                tbFadeTime.Text = "1.0"
                Exit Sub 'if something fails resets text and exits sub
            End Try
        End Sub

        Private Sub tbDuration_Leave(sender As Object, e As EventArgs) Handles tbFadeTime.Leave, tbPJXDur.Leave
            Dim tb As TextBox = DirectCast(sender, TextBox)
            If tb.Text.EndsWith(".") Then tb.Text = tb.Text.Remove(tb.Text.Length - 1)
            Dim fadeTime As Double = CDbl(tb.Text) 'see if converting works
            If fadeTime > 15 Then 'unreasonably long fade time
                tb.Text = "15.0"
                Exit Sub 'set the fadetime back to 15
            End If
            If String.IsNullOrEmpty(tb.Text.Trim) OrElse CDbl(tb.Text.Trim) <= 0 Then
                tb.Text = "1.0"
                tb.SelectionLength = 0
                tb.SelectionStart = tb.Text.Length
            End If
        End Sub

        Private Sub tbDelay_Leave(sender As Object, e As EventArgs) _
            Handles tbPDelay.Leave, tbSDelay.Leave, tbPJXDelay.Leave, tbFadeDelay.Leave,
                    tbAllDelay.Leave, tbAllFade.Leave, tbSFade.Leave
            Dim tb As TextBox = DirectCast(sender, TextBox)
            If tb.Text.EndsWith(".") Then tb.Text = tb.Text.Remove(tb.Text.Length - 1)
            Dim fadeTime As Double = CDbl(tb.Text) 'see if converting works
            If fadeTime > 15 Then 'unreasonably long fade time
                tb.Text = "15.0"
                Exit Sub 'set the fadetime back to 15
            End If
            If String.IsNullOrEmpty(tb.Text.Trim) OrElse CDbl(tb.Text.Trim) < 0 Then
                tb.Text = "0.0"
                tb.SelectionLength = 0
                tb.SelectionStart = tb.Text.Length
            End If
        End Sub


        Private Sub vw4Cues_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
            If e.KeyCode = Keys.Shift Then _forceAddLast = True
        End Sub

        Private Sub tabLFX_Click(sender As Object, e As EventArgs) Handles tabLFX.Click
            visual.Focus()
            _curTab = CuesTab.Lfx
            tabLFX.Tag = 1
            SelTab(tabLFX)
            tabSFX.Tag = Nothing
            SelTab(tabSFX, False)
            tabPJX.Tag = Nothing
            SelTab(tabPJX, False)
            Dim curcue As Cue = GetCurCue()
            My.Settings.favCueTab = 1
            My.Settings.Save()
            pnlLFX.Show()
            pnlSFX.Hide()
            pnlPJX.Hide()
            CurProject.Settings.SetSetting("Cues", lv.SelectedItems(0).Text, curcue.ToString)
        End Sub

        Private Sub tabSFX_Click(sender As Object, e As EventArgs) Handles tabSFX.Click
            visual.Focus()
            _curTab = CuesTab.Sfx
            tabLFX.Tag = Nothing
            SelTab(tabLFX, False)
            tabSFX.Tag = 1
            SelTab(tabSFX)
            tabPJX.Tag = Nothing
            SelTab(tabPJX, False)
            Dim curcue As Cue = GetCurCue()
            My.Settings.favCueTab = 2
            My.Settings.Save()
            pnlLFX.Hide()
            pnlSFX.Show()
            pnlPJX.Hide()
            CurProject.Settings.SetSetting("Cues", lv.SelectedItems(0).Text, curcue.ToString)
            editor.ScrollControlIntoView(btnEdit)
        End Sub

        Private Sub tabPJX_Click(sender As Object, e As EventArgs) Handles tabPJX.Click
            visual.Focus()
            _curTab = CuesTab.Pjx
            tabLFX.Tag = Nothing
            SelTab(tabLFX, False)
            tabSFX.Tag = Nothing
            SelTab(tabSFX, False)
            tabPJX.Tag = 1
            SelTab(tabPJX)
            Dim curcue As Cue = GetCurCue()
            My.Settings.favCueTab = 3
            My.Settings.Save()
            pnlLFX.Hide()
            pnlSFX.Hide()
            pnlPJX.Show()
            CurProject.Settings.SetSetting("Cues", lv.SelectedItems(0).Text, curcue.ToString)
            editor.ScrollControlIntoView(btnEdit)
        End Sub

        Private Sub tab_EnabledChanged(sender As Object, e As EventArgs) _
            Handles tabSFX.EnabledChanged, tabPJX.EnabledChanged, tabLFX.EnabledChanged
            If DirectCast(sender, Button).Enabled = False Then
                DirectCast(sender, Button).BackColor = Color.fromArgb(100, 100, 100)
            Else
                'If DirectCast(sender, Button).Tag Is Nothing Then
                DirectCast(sender, Button).BackColor = Color.FromArgb(170, 170, 170)
                DirectCast(sender, Button).ForeColor = Color.White
                'Else
                'DirectCast(sender, Button).BackColor = Color.Gainsboro
                'DirectCast(sender, Button).ForeColor = Color.White
                'End If
            End If
        End Sub

        Private Sub SelTab(ByRef btn As Button, Optional ByVal sel As Boolean = True)
            If sel Then
                btn.BackColor = Color.Gainsboro
                btn.ForeColor = Color.FromArgb(64, 64, 64)
                btn.FlatAppearance.MouseDownBackColor = Color.Gainsboro
                btn.FlatAppearance.MouseOverBackColor = Color.Gainsboro
            Else
                If Not btn.Enabled = False Then
                    btn.BackColor = Color.FromArgb(170, 170, 170)
                    btn.ForeColor = Color.White
                    btn.FlatAppearance.MouseDownBackColor = Nothing
                    btn.FlatAppearance.MouseOverBackColor = Nothing
                End If
            End If
        End Sub

        Private Sub cbLFX_CheckedChanged(sender As Object, e As EventArgs) Handles cbLFX.CheckedChanged
            Dim curcue As Cue = GetCueByName(lv.SelectedItems(0).Text)
            curcue.IsLfxOn = cbLFX.Checked
            If cbLFX.Checked Then
                tabLFX.Tag = Nothing
                tabLFX.Enabled = True
                If _curTab = CuesTab.none Then
                    _curTab = CuesTab.lfx
                    tabLFX.Tag = 1
                    SelTab(tabLFX)
                    tabSFX.Tag = Nothing
                    SelTab(tabSFX, False)
                    tabPJX.Tag = Nothing
                    SelTab(tabPJX, False)
                    My.Settings.favCueTab = 1
                    My.Settings.Save()
                    pnlLFX.Show()
                    pnlSFX.Hide()
                    pnlPJX.Hide()
                End If
            Else
                tabLFX.Tag = Nothing
                If _curTab = CuesTab.lfx Then
                    pnlLFX.Hide()
                    _curTab = CuesTab.none
                End If
                tabLFX.Enabled = False
            End If
            CurProject.Settings.SetSetting("Cues", lv.SelectedItems(0).Text, curcue.ToString)
        End Sub

        Private Sub cbSFX_CheckedChanged(sender As Object, e As EventArgs) Handles cbSFX.CheckedChanged
            Dim curcue As Cue = GetCueByName(lv.SelectedItems(0).Text)
            curcue.IsSfxOn = cbSFX.Checked
            If cbSFX.Checked Then
                tabSFX.Tag = Nothing
                tabSFX.Enabled = True
                If _curTab = CuesTab.none Then
                    _curTab = CuesTab.sfx
                    tabLFX.Tag = Nothing
                    SelTab(tabLFX, False)
                    tabSFX.Tag = 1
                    SelTab(tabSFX)
                    tabPJX.Tag = Nothing
                    SelTab(tabPJX, False)
                    My.Settings.favCueTab = 2
                    My.Settings.Save()
                    pnlLFX.Hide()
                    pnlSFX.Show()
                    pnlPJX.Hide()
                End If
            Else
                tabSFX.Tag = Nothing
                If _curTab = CuesTab.sfx Then
                    pnlSFX.Hide()
                    _curTab = CuesTab.none
                End If
                tabSFX.Enabled = False
            End If
            CurProject.Settings.SetSetting("Cues", lv.SelectedItems(0).Text, curcue.ToString)
        End Sub

        Private Sub cbPJX_CheckedChanged(sender As Object, e As EventArgs) Handles cbPJX.CheckedChanged
            Dim curcue As Cue = GetCueByName(lv.SelectedItems(0).Text)
            curcue.IsPjxOn = cbPJX.Checked
            If cbPJX.Checked Then
                If _curTab = CuesTab.pjx Then tabPJX.Tag = 1 Else tabPJX.Tag = Nothing
                tabPJX.Enabled = True
                If _curTab = CuesTab.none Then
                    _curTab = CuesTab.pjx
                    tabLFX.Tag = Nothing
                    SelTab(tabLFX, False)
                    tabSFX.Tag = Nothing
                    SelTab(tabSFX, False)
                    tabPJX.Tag = 1
                    SelTab(tabPJX)
                    My.Settings.favCueTab = 3
                    My.Settings.Save()
                    pnlLFX.Hide()
                    pnlSFX.Hide()
                    pnlPJX.Show()
                End If
            Else
                tabPJX.Tag = Nothing
                If _curTab = CuesTab.pjx Then
                    pnlPJX.Hide()
                    _curTab = CuesTab.none
                End If
                tabPJX.Enabled = False
            End If
            CurProject.Settings.SetSetting("Cues", lv.SelectedItems(0).Text, curcue.ToString)
        End Sub

        Private Sub lbWarning_VisibleChanged(sender As Object, e As EventArgs) Handles lbWarning.VisibleChanged
            lbWarning.Top = tbName.Top - lbWarning.Height + 2
            If lbWarning.Visible Then editor.ScrollControlIntoView(lbWarning)
        End Sub

        Private Sub cbStopAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbStopAll.CheckedChanged
            If lv.SelectedItems.Count > 0 Then
                GetCurSfxCue.StopAll = cbStopAll.Checked
                editor.ScrollControlIntoView(tbAllFade)
                SaveCues()
            End If
        End Sub

        Private Sub btnPAdd_Click(sender As Object, e As EventArgs) Handles btnPAdd.Click
            lvToPlay.Focus()
            Using diag As New DiagSelectAudio
                With diag
                    .title.Text = "Add Sound Effect"
                    If .ShowDialog = DialogResult.OK Then
                        For Each it As ListViewItem In lvToPlay.Items
                            If it.Text = .Selected Then
                                MsgBox(
                                    "Warning: This resource is already set to be played at this cue. The same resource cannot be played " &
                                    "twice in one cue.", MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.Exclamation,
                                    "Warning")
                                Exit Sub
                            End If
                        Next
                        GetCurSfxCue.PlayEvents.Add(New SfxEvent(.Selected, SfxEvent.EventType.PlaySfx, .Delay))
                        Dim i As New ListViewItem(.Selected)
                        i.ImageIndex = 0
                        i.SubItems.Add(.Delay.ToString & "s")
                        lvToPlay.Items.Add(i)
                        lvToPlay.Sort()
                        lvToPlay.SelectedItems.Clear()
                        i.Selected = True
                        SaveCues()
                    End If
                End With
            End Using
        End Sub

        Private Sub btnSAdd_Click(sender As Object, e As EventArgs) Handles btnSAdd.Click
            lvToStop.Focus()
            Using diag As New DiagSelectAudio
                With diag
                    .title.Text = "Add Sound Effect (To Stop)"
                    .ShowDur = True
                    If .ShowDialog = DialogResult.OK Then
                        For Each it As ListViewItem In lvToPlay.Items
                            If it.Text = .Selected Then
                                MsgBox(
                                    "Warning: This resource is already set to be stopped at this cue. You cannot stop a stopped resource.",
                                    MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.Exclamation, "Warning")
                                Exit Sub
                            End If
                        Next
                        GetCurSfxCue.StopEvents.Add(New SfxEvent(.Selected, SfxEvent.EventType.StopSfx, .Duration, .Delay))
                        Dim i As New ListViewItem(.Selected)
                        i.ImageIndex = 0
                        i.SubItems.Add(.Duration.ToString & "s")
                        i.SubItems.Add(.Delay.ToString & "s")
                        lvToStop.Items.Add(i)
                        lvToStop.Sort()
                        lvToStop.SelectedItems.Clear()
                        i.Selected = True
                        SaveCues()
                    End If
                End With
            End Using
        End Sub

        Private Sub btn_EnableChanged(sender As Object, e As EventArgs) _
            Handles btnSRem.EnabledChanged, btnPRem.EnabledChanged,
                    btnPChange.EnabledChanged, btnSChange.EnabledChanged
            If DirectCast(sender, Button).Enabled = False Then
                DirectCast(sender, Button).BackColor = Color.fromArgb(100, 100, 100)
            Else
                DirectCast(sender, Button).BackColor = Color.FromArgb(170, 170, 170)
            End If
        End Sub

        Private Sub lvToPlay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvToPlay.SelectedIndexChanged
            If lv.SelectedItems.Count > 0 Then
                editor.ScrollControlIntoView(tbAllDelay)
                If lvToPlay.SelectedItems.Count < 1 Then
                    btnPRem.Enabled = False
                    btnPChange.Enabled = False
                    tbPDelay.Hide()
                    lbPDelay.Hide()
                ElseIf lvToPlay.SelectedItems.Count > 1 Then
                    btnPRem.Enabled = True
                    btnPChange.Enabled = True
                    tbPDelay.Hide()
                    lbPDelay.Hide()
                Else
                    btnPRem.Enabled = True
                    btnPChange.Enabled = True
                    tbPDelay.Show()
                    lbPDelay.Show()
                    Try
                        tbPDelay.Text = GetCurSfxCue.GetPlayEventByResName(lvToPlay.SelectedItems(0).Text).Delay.ToString
                    Catch ex As Exception
                    End Try
                End If
            End If
        End Sub

        Private Sub lvToStop_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvToStop.SelectedIndexChanged
            If lv.SelectedItems.Count > 0 Then
                editor.ScrollControlIntoView(tbAllDelay)
                If lvToStop.SelectedItems.Count < 1 Then
                    btnSRem.Enabled = False
                    btnSChange.Enabled = False
                    tbSDelay.Hide()
                    lbSDelay.Hide()
                    tbSFade.Hide()
                    lbSFade.Hide()
                ElseIf lvToStop.SelectedItems.Count > 1 Then
                    btnSRem.Enabled = True
                    btnSChange.Enabled = True
                    tbSDelay.Hide()
                    lbSDelay.Hide()
                    tbSFade.Hide()
                    lbSFade.Hide()
                Else
                    btnSRem.Enabled = True
                    btnSChange.Enabled = True
                    tbSDelay.Show()
                    lbSDelay.Show()
                    tbSFade.Show()
                    lbSFade.Show()
                    Try
                        Dim curEv As SfxEvent = GetCurSfxCue.GetStopEventByResName(lvToStop.SelectedItems(0).Text)
                        tbSDelay.Text = curEv.Delay.ToString
                        tbSFade.Text = curEv.FadeDuration.ToString
                    Catch ex As Exception
                    End Try
                End If
            End If
        End Sub

        Private Sub tbPDelay_TextChanged(sender As Object, e As EventArgs) Handles tbPDelay.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbPDelay.Text.Trim) Then
                    tbPDelay.Text = tbPDelay.Text.Trim
                    Dim fadeTime As Double = CDbl(tbPDelay.Text) 'see if converting works
                    If fadeTime >= 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        GetCurSfxCue.GetPlayEventByResName(lvToPlay.SelectedItems(0).Text).Delay = CDbl(tbPDelay.Text)
                        lvToPlay.SelectedItems(0).SubItems(1).Text = fadeTime.ToString & "s"
                        SaveCues()
                    End If
                End If
            Catch ex As Exception
                tbPDelay.Text = "0.0"
                'if something fails resets text
            End Try
        End Sub

        Private Sub tbSDelay_TextChanged(sender As Object, e As EventArgs) Handles tbSDelay.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbSDelay.Text.Trim) Then
                    tbSDelay.Text = tbSDelay.Text.Trim
                    Dim fadeTime As Double = CDbl(tbSDelay.Text) 'see if converting works
                    If fadeTime >= 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        GetCurSfxCue.GetStopEventByResName(lvToStop.SelectedItems(0).Text).Delay = CDbl(tbSDelay.Text)
                        lvToStop.SelectedItems(0).SubItems(2).Text = fadeTime.ToString & "s"
                        SaveCues()
                    End If
                End If
            Catch ex As Exception
                tbSDelay.Text = "0.0"
                Exit Sub 'if something fails resets text
            End Try
        End Sub

        Private Sub tbSFade_TextChanged(sender As Object, e As EventArgs) Handles tbSFade.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbSFade.Text.Trim) Then
                    tbSFade.Text = tbSFade.Text.Trim
                    Dim fadeTime As Double = CDbl(tbSFade.Text) 'see if converting works
                    If fadeTime >= 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        GetCurSfxCue.GetStopEventByResName(lvToStop.SelectedItems(0).Text).FadeDuration = CDbl(tbSFade.Text)
                        lvToStop.SelectedItems(0).SubItems(1).Text = fadeTime.ToString & "s"
                        SaveCues()
                    End If
                End If
            Catch ex As Exception
                tbSFade.Text = "0.0"
                Exit Sub 'if something fails resets text
            End Try
        End Sub

        Private Sub btnPRem_Click(sender As Object, e As EventArgs) Handles btnPRem.Click
            lvToPlay.Focus()
            If lvToPlay.SelectedItems.Count > 0 Then
                Dim toRemove As New List(Of ListViewItem)
                For Int As Integer = 0 To lvToPlay.SelectedItems.Count - 1
                    Dim curSfx As SfxCue = GetCurSfxCue()
                    For Each ev As SfxEvent In curSfx.PlayEvents
                        If ev.NameOfRes = lvToPlay.SelectedItems(Int).Text Then
                            curSfx.PlayEvents.Remove(ev)
                            Exit For
                        End If
                    Next
                    toRemove.Add(lvToPlay.SelectedItems(Int))
                Next
                lvToPlay.SelectedItems.Clear()
                For Each it As ListViewItem In toRemove
                    lvToPlay.Items.Remove(it)
                Next
                lvToPlay.Sort()
                SaveCues()
                If lvToPlay.Items.Count > 0 Then
                    lvToPlay.Items(lvToPlay.Items.Count - 1).Selected = True
                End If
            End If
        End Sub

        Private Sub btnSRem_Click(sender As Object, e As EventArgs) Handles btnSRem.Click
            lvToStop.Focus()
            If lvToStop.SelectedItems.Count > 0 Then
                Dim toRemove As New List(Of ListViewItem)
                For Int As Integer = 0 To lvToStop.SelectedItems.Count - 1
                    Dim curSfx As SfxCue = GetCurSfxCue()
                    For Each ev As SfxEvent In curSfx.StopEvents
                        If ev.NameOfRes = lvToStop.SelectedItems(Int).Text Then
                            curSfx.StopEvents.Remove(ev)
                            Exit For
                        End If
                    Next
                    toRemove.Add(lvToStop.SelectedItems(Int))
                Next
                lvToPlay.SelectedItems.Clear()
                For Each it As ListViewItem In toRemove
                    lvToStop.Items.Remove(it)
                Next
                lvToStop.Sort()
                SaveCues()
                If lvToStop.Items.Count > 0 Then
                    lvToStop.Items(lvToStop.Items.Count - 1).Selected = True
                End If
            End If
        End Sub

        Private Sub lvToPlay_KeyUp(sender As Object, e As KeyEventArgs) Handles lvToPlay.KeyUp
            If e.Control Then
                If e.KeyCode = Keys.A Then
                    For Each i As ListViewItem In lvToPlay.Items
                        i.Selected = True
                    Next
                ElseIf e.KeyCode = Keys.D Then
                    btnPAdd.PerformClick()
                End If
            ElseIf e.KeyCode = Keys.Delete Then
                btnPRem.PerformClick()
            End If
        End Sub

        Private Sub lvToStop_KeyUp(sender As Object, e As KeyEventArgs) Handles lvToStop.KeyUp
            If e.Control Then
                If e.KeyCode = Keys.A Then
                    For Each i As ListViewItem In lvToStop.Items
                        i.Selected = True
                    Next
                ElseIf e.KeyCode = Keys.D Then
                    btnSAdd.PerformClick()
                End If
            ElseIf e.KeyCode = Keys.Delete Then
                btnSRem.PerformClick()
            End If
        End Sub

        Private Sub btnPChange_Click(sender As Object, e As EventArgs) Handles btnPChange.Click
            lvToPlay.Focus()
            If lvToPlay.SelectedItems.Count > 0 Then
                Using diag As New DiagSelectAudio
                    With diag
                        .title.Text = "Change Sound Effect"
                        Dim origText As String = lvToPlay.SelectedItems(0).Text
                        .Selected = origText
                        If .ShowDialog = DialogResult.OK Then
                            If .Selected <> origText Then
                                For Each it As ListViewItem In lvToPlay.Items
                                    If it.Text = .Selected Then
                                        MsgBox(
                                            "Warning: This resource is already set to be played at this cue. The same resource cannot be played " &
                                            "twice in one cue.", MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.Exclamation,
                                            "Warning")
                                        Exit Sub
                                    End If
                                Next
                            End If
                            Dim ev As SfxEvent = GetCurSfxCue.GetPlayEventByResName(origText)
                            ev.NameOfRes = .Selected
                            ev.Delay = .Delay
                            Dim i As ListViewItem = lvToPlay.SelectedItems(0)
                            i.Text = .Selected
                            i.ImageIndex = 0
                            i.SubItems(1).Text = .Delay.ToString & "s"
                            lvToPlay.Sort()
                            lvToPlay.SelectedItems.Clear()
                            i.Selected = True
                            SaveCues()
                        End If
                    End With
                End Using
            End If
        End Sub

        Private Sub btnSChange_Click(sender As Object, e As EventArgs) Handles btnSChange.Click
            lvToStop.Focus()
            If lvToStop.SelectedItems.Count > 0 Then
                Using diag As New DiagSelectAudio
                    With diag
                        .title.Text = "Change Sound Effect (To Stop)"
                        .ShowDur = True
                        Dim origText As String = lvToStop.SelectedItems(0).Text
                        .Selected = origText
                        If .ShowDialog = DialogResult.OK Then
                            If .Selected <> origText Then
                                For Each it As ListViewItem In lvToStop.Items
                                    If it.Text = .Selected Then
                                        MsgBox(
                                            "Warning: This resource is already set to be played at this cue. The same resource cannot be played " &
                                            "twice in one cue.", MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.Exclamation,
                                            "Warning")
                                        Exit Sub
                                    End If
                                Next
                            End If
                            Dim ev As SfxEvent = GetCurSfxCue.GetStopEventByResName(origText)
                            ev.NameOfRes = .Selected
                            ev.Delay = .Delay
                            ev.FadeDuration = .Duration
                            Dim i As ListViewItem = lvToStop.SelectedItems(0)
                            i.Text = .Selected
                            i.ImageIndex = 0
                            i.SubItems(1).Text = .Duration.ToString & "s"
                            i.SubItems(2).Text = .Delay.ToString & "s"
                            lvToStop.Sort()
                            lvToStop.SelectedItems.Clear()
                            i.Selected = True
                            SaveCues()
                        End If
                    End With
                End Using
            End If
        End Sub

        Private Sub lvSFX_ItemActivate(sender As Object, e As EventArgs) _
            Handles lvToPlay.ItemActivate, lvToStop.ItemActivate
            Dim sendLV As ListView = DirectCast(sender, ListView)
            If sendLV.SelectedItems.Count = 1 Then
                Dim realPath As String
                If File.Exists(AFs(CurProject.ResPath) & sendLV.SelectedItems(0).Text & ".mp3") Then
                    realPath = AFs(CurProject.ResPath) & sendLV.SelectedItems(0).Text & ".mp3"
                ElseIf File.Exists(AFs(CurProject.ResPath) & sendLV.SelectedItems(0).Text.ToString & ".wav") Then
                    realPath = AFs(CurProject.ResPath) & sendLV.SelectedItems(0).Text & ".wav"
                Else
                    Exit Sub
                End If
                Using diag As New DiagMPlayer(realPath)
                    diag.StartPosition = FormStartPosition.Manual
                    diag.Top = sendLV.Bottom
                    diag.Left = CInt(editor.Left + pnlSFX.Left + sendLV.Left + sendLV.Width / 2 - diag.Width / 2)
                    diag.ShowDialog()
                End Using
            End If
        End Sub


        Private Sub tbPJXDur_TextChanged(sender As Object, e As EventArgs) Handles tbPJXDur.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbPJXDur.Text.Trim) Then
                    tbPJXDur.Text = tbPJXDur.Text.Trim
                    Dim fadeTime As Double = CDbl(tbPJXDur.Text) 'see if converting works
                    If fadeTime > 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        Dim curPjx As PjxCue = GetCurPjxCue()
                        curPjx.Duration = CDbl(tbPJXDur.Text)
                        CurProject.Settings.SetSetting("Projection", lv.SelectedItems(0).Text, curPjx.ToString)
                    End If
                End If
            Catch ex As Exception
                tbPJXDur.Text = "1.0"
                Exit Sub 'if something fails resets text and exits sub
            End Try
        End Sub

        Private Sub tbPJXDelay_TextChanged(sender As Object, e As EventArgs) Handles tbPJXDelay.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbPJXDelay.Text.Trim) Then
                    tbPJXDelay.Text = tbPJXDelay.Text.Trim
                    Dim fadeTime As Double = CDbl(tbPJXDelay.Text) 'see if converting works
                    If fadeTime > 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        Dim curPjx As PjxCue = GetCurPjxCue()
                        curPjx.Delay = CDbl(tbPJXDelay.Text)
                        CurProject.Settings.SetSetting("Projection", lv.SelectedItems(0).Text, curPjx.ToString)
                    End If
                End If
            Catch ex As Exception
                tbPJXDelay.Text = "1.0"
                Exit Sub 'if something fails resets text and exits sub
            End Try
        End Sub

        Private Sub btnPjxPlay_Click(sender As Object, e As EventArgs) Handles btnPjxPlay.Click
            Try
                If lv.SelectedItems.Count = 1 Then
                    Dim curPjx As PjxCue = GetCurPjxCue()
                    If HasSecondMonitor Then
                        curPjx.ExecuteCue()
                        curPjx.ExecuteCue(pbPjx)
                    Else
                        curPjx.ExecuteCue(pbPjx)
                    End If
                End If
            Catch ex As Exception
                MsgBox(
                    "Error occurred while attempting to play an image transition effect (Cue -> PJX). Details displayed below." _
                    & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Error")
            End Try
        End Sub

        Private Sub btnPjxChoose_Click(sender As Object, e As EventArgs) Handles btnPjxChoose.Click
            Using diag As New DiagSelectImage
                Dim curcue As PjxCue = GetCurPjxCue()
                diag.Transition = curcue.Effect
                diag.Delay = curcue.Delay
                diag.Duration = curcue.Duration
                If diag.ShowDialog = DialogResult.OK Then
                    Dim curPjx As PjxCue = GetCurPjxCue()
                    curPjx.NameOfRes = diag.Selected
                    CurProject.Settings.SetSetting("Projection", lv.SelectedItems(0).Text, curPjx.ToString)
                    pbPjx.Image.Dispose()
                    If diag.Selected = "_blackout" Then
                        Dim blackout As New Bitmap(My.Settings.secondaryScrRez.Width, My.Settings.secondaryScrRez.Height)
                        Using g As Graphics = Graphics.FromImage(blackout)
                            g.Clear(Color.Black)
                        End Using
                        pbPjx.Image = GetThumbnail(blackout, pbPjx.Width, pbPjx.Height, pbPjx.BackColor)
                    Else
                        pbPjx.Image = GetThumbnail(diag.SelectedPath, pbPjx.Width, pbPjx.Height, pbPjx.BackColor)
                    End If
                    lbPjx.Text = diag.Selected
                    cbPjxEffect.SelectedIndex = diag.Transition
                    tbPJXDur.Text = CStr(diag.Duration)
                    tbPJXDelay.Text = CStr(diag.Delay)
                End If
            End Using
        End Sub

        Private Sub cbPjxEffect_SelectedIndexChanged(sender As Object, e As EventArgs) _
            Handles cbPjxEffect.SelectedIndexChanged
            Dim curPjx As PjxCue = GetCurPjxCue()
            curPjx.Effect = CType(cbPjxEffect.SelectedIndex, PjxEngine.Effect)
            CurProject.Settings.SetSetting("Projection", lv.SelectedItems(0).Text, curPjx.ToString)
        End Sub

        Private Sub tbFadeDelay_TextChanged(sender As Object, e As EventArgs) Handles tbFadeDelay.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbFadeDelay.Text.Trim) Then
                    tbFadeDelay.Text = tbFadeDelay.Text.Trim
                    Dim delay As Double = CDbl(tbFadeDelay.Text) 'see if converting works
                    If delay > 0 And delay <= 15 And lv.SelectedItems.Count > 0 Then
                        'save the fade time
                        Dim curSubName As String = lv.SelectedItems(0).Text
                        For Each s As Submaster In Subs
                            If s.Name = curSubName Then
                                s.Delay = delay
                                CurProject.Settings.SetSetting("Submasters", curSubName, s.ToString)
                                Exit For
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                tbFadeDelay.Text = "1.0"
                Exit Sub 'if something fails resets text and exits sub
            End Try
        End Sub


        Private Sub tbAllDelay_TextChanged(sender As Object, e As EventArgs) Handles tbAllDelay.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbAllDelay.Text.Trim) Then
                    tbAllDelay.Text = tbAllDelay.Text.Trim
                    Dim fadeTime As Double = CDbl(tbAllDelay.Text) 'see if converting works
                    If fadeTime >= 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        Dim curSfx As SfxCue = GetCurSfxCue()
                        curSfx.StopAllDelay = CDbl(tbAllDelay.Text)
                        CurProject.Settings.SetSetting("Sfx", curSfx.CueName, curSfx.ToString)
                    End If
                End If
            Catch ex As Exception
                tbAllDelay.Text = "0.0"
                Exit Sub 'if something fails resets text
            End Try
        End Sub

        Private Sub tbAllFade_TextChanged(sender As Object, e As EventArgs) Handles tbAllFade.TextChanged
            Try
                If Not String.IsNullOrEmpty(tbAllFade.Text.Trim) Then
                    tbAllFade.Text = tbAllFade.Text.Trim
                    Dim fadeTime As Double = CDbl(tbAllFade.Text) 'see if converting works
                    If fadeTime >= 0 And fadeTime <= 15 And lv.SelectedItems.Count > 0 Then
                        Dim curSfx As SfxCue = GetCurSfxCue()
                        curSfx.StopAllDuration = CDbl(tbAllFade.Text)
                        CurProject.Settings.SetSetting("Sfx", curSfx.CueName, curSfx.ToString)
                    End If
                End If
            Catch ex As Exception
                tbAllFade.Text = "0.5"
                Exit Sub 'if something fails resets text
            End Try
        End Sub

        Private Sub CheckCueNum()
            If Cues.Count > 0 Then Frm3Viewer.tabStart.Enabled = True Else Frm3Viewer.tabStart.Enabled = False
        End Sub
        Private Sub UpdateCueOrder()
            General.UpdateCueOrder(lv)
        End Sub
        'Private Sub timerUpdateLights_Tick(sender As Object, e As EventArgs) Handles timerUpdateLights.Tick
        '    'keep connection alive
        '    If Frm3Viewer.viewer.Controls.Contains(Me) AndAlso DmxEngine.status = FT_STATUS.FT_OK Then
        '        UpdateLights()
        '    End If
        'End Sub
    End Class
End Namespace