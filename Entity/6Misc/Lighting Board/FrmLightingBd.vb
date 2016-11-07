Imports Entity._0App
Imports Entity._4Classes.Types
Imports Entity._5Controls

Namespace _6Misc

    Public Class FrmLightingBd
        Dim _dmxarrEmpty(511) As Byte

        Dim _dmxarr(511) As Byte
        Dim dmxarrA(511) As Byte
        Dim dmxarrB(511) As Byte
        Dim _dmxarrBarsA(511) As Byte
        Dim _dmxarrBarsB(511) As Byte

        Dim devicesBarsA(3)() As Byte
        Dim devicesBarsB(3)() As Byte
        Dim devicesMaster(3) As Double
        Dim devicesFader(3) As Double
        Dim devicesBlackOut(3) As Double

        Dim devicesChInterval(3) As Integer
        Dim devicesStartCh(3) As Integer
        Dim devicesPg(3) As Integer
        'don't show form on alt tab
        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not Me.DesignMode Then cp.ExStyle = cp.ExStyle Or &H80 'pretend to be a fixed tool window
                Return cp
            End Get
        End Property
        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
        'Dim moving As Boolean = False
        'Dim ppt As New Point
        Dim _device As Integer = 0
        Dim _interval As Integer = 2
        Dim _page As Integer = 1
        Dim _lastPageChnls As Integer = 12
        Dim _startIdx As Integer = 1
        Dim _master As Double = 1
        Dim _blackOut As Double = 1
        Dim _fader As Double = 1
#Region " Methods"
        Private Sub renameChannelLabels(page As Integer)
            Dim base As Integer = 12 * (page - 1)
            'show everything
            barA1.Show()
            barA2.Show()
            barA3.Show()
            barA4.Show()
            barA5.Show()
            barA6.Show()
            barA7.Show()
            barA8.Show()
            barA9.Show()
            barA10.Show()
            barA11.Show()
            barA12.Show()
            barB1.Show()
            barB2.Show()
            barB3.Show()
            barB4.Show()
            barB5.Show()
            barB6.Show()
            barB7.Show()
            barB8.Show()
            barB9.Show()
            barB10.Show()
            barB11.Show()
            barB12.Show()
            lbA1.Show()
            lbA2.Show()
            lbA3.Show()
            lbA4.Show()
            lbA5.Show()
            lbA6.Show()
            lbA7.Show()
            lbA8.Show()
            lbA9.Show()
            lbA10.Show()
            lbA11.Show()
            lbA12.Show()

            lbB1.Show()
            lbB2.Show()
            lbB3.Show()
            lbB4.Show()
            lbB5.Show()
            lbB6.Show()
            lbB7.Show()
            lbB8.Show()
            lbB9.Show()
            lbB10.Show()
            lbB11.Show()
            lbB12.Show()
            'hide unnecessary channels
            If page = numPG.Maximum Then
                If _lastPageChnls < 2 Then
                    barA2.Hide()
                    barB2.Hide()
                    lbA2.Hide()
                    lbB2.Hide()
                End If
                If _lastPageChnls < 3 Then
                    barA3.Hide()
                    barB3.Hide()
                    lbA3.Hide()
                    lbB3.Hide()
                End If
                If _lastPageChnls < 4 Then
                    barA4.Hide()
                    barB4.Hide()
                    lbA4.Hide()
                    lbB4.Hide()
                End If
                If _lastPageChnls < 5 Then
                    barA5.Hide()
                    barB5.Hide()
                    lbA5.Hide()
                    lbB5.Hide()
                End If
                If _lastPageChnls < 6 Then
                    barA6.Hide()
                    barB6.Hide()
                    lbA6.Hide()
                    lbB6.Hide()
                End If
                If _lastPageChnls < 7 Then
                    barA7.Hide()
                    barB7.Hide()
                    lbA7.Hide()
                    lbB7.Hide()
                End If
                If _lastPageChnls < 8 Then
                    barA8.Hide()
                    barB8.Hide()
                    lbA8.Hide()
                    lbB8.Hide()
                End If
                If _lastPageChnls < 9 Then
                    barA9.Hide()
                    barB9.Hide()
                    lbA9.Hide()
                    lbB9.Hide()
                End If
                If _lastPageChnls < 10 Then
                    barA10.Hide()
                    barB10.Hide()
                    lbA10.Hide()
                    lbB10.Hide()
                End If
                If _lastPageChnls < 11 Then
                    barA11.Hide()
                    barB11.Hide()
                    lbA11.Hide()
                    lbB11.Hide()
                End If
                If _lastPageChnls < 12 Then
                    barA12.Hide()
                    barB12.Hide()
                    lbA12.Hide()
                    lbB12.Hide()
                End If
            End If
            'rename labels
            lbA1.Text = CStr(base + 1)
            lbB1.Text = CStr(base + 1)
            lbA2.Text = CStr(base + 2)
            lbB2.Text = CStr(base + 2)
            lbA3.Text = CStr(base + 3)
            lbB3.Text = CStr(base + 3)
            lbA4.Text = CStr(base + 4)
            lbB4.Text = CStr(base + 4)
            lbA5.Text = CStr(base + 5)
            lbB5.Text = CStr(base + 5)
            lbA6.Text = CStr(base + 6)
            lbB6.Text = CStr(base + 6)
            lbA7.Text = CStr(base + 7)
            lbB7.Text = CStr(base + 7)
            lbA8.Text = CStr(base + 8)
            lbB8.Text = CStr(base + 8)
            lbA9.Text = CStr(base + 9)
            lbB9.Text = CStr(base + 9)
            lbA10.Text = CStr(base + 10)
            lbB10.Text = CStr(base + 10)
            lbA11.Text = CStr(base + 11)
            lbB11.Text = CStr(base + 11)
            lbA12.Text = CStr(base + 12)
            lbB12.Text = CStr(base + 12)
            'set bar tags
            barA1.Tag = barIDtoChannelID(1)
            barB1.Tag = barIDtoChannelID(1)
            barA2.Tag = barIDtoChannelID(2)
            barB2.Tag = barIDtoChannelID(2)
            barA3.Tag = barIDtoChannelID(3)
            barB3.Tag = barIDtoChannelID(3)
            barA4.Tag = barIDtoChannelID(4)
            barB4.Tag = barIDtoChannelID(4)
            barA5.Tag = barIDtoChannelID(5)
            barB5.Tag = barIDtoChannelID(5)
            barA6.Tag = barIDtoChannelID(6)
            barB6.Tag = barIDtoChannelID(6)
            barA7.Tag = barIDtoChannelID(7)
            barB7.Tag = barIDtoChannelID(7)
            barA8.Tag = barIDtoChannelID(8)
            barB8.Tag = barIDtoChannelID(8)
            barA9.Tag = barIDtoChannelID(9)
            barB9.Tag = barIDtoChannelID(9)
            barA10.Tag = barIDtoChannelID(10)
            barB10.Tag = barIDtoChannelID(10)
            barA11.Tag = barIDtoChannelID(11)
            barB11.Tag = barIDtoChannelID(11)
            barA12.Tag = barIDtoChannelID(12)
            barB12.Tag = barIDtoChannelID(12)

            reloadBarValues()
        End Sub
        Private Sub reloadBarValues()
            Try
                barA1.Value = _dmxarrBarsA(CInt(barA1.Tag) - 1)
                barA2.Value = _dmxarrBarsA(CInt(barA2.Tag) - 1)
                barA3.Value = _dmxarrBarsA(CInt(barA3.Tag) - 1)
                barA4.Value = _dmxarrBarsA(CInt(barA4.Tag) - 1)
                barA5.Value = _dmxarrBarsA(CInt(barA5.Tag) - 1)
                barA6.Value = _dmxarrBarsA(CInt(barA6.Tag) - 1)
                barA7.Value = _dmxarrBarsA(CInt(barA7.Tag) - 1)
                barA8.Value = _dmxarrBarsA(CInt(barA8.Tag) - 1)
                barA9.Value = _dmxarrBarsA(CInt(barA9.Tag) - 1)
                barA10.Value = _dmxarrBarsA(CInt(barA10.Tag) - 1)
                barA11.Value = _dmxarrBarsA(CInt(barA11.Tag) - 1)
                barA12.Value = _dmxarrBarsA(CInt(barA12.Tag) - 1)

                barB1.Value = _dmxarrBarsB(CInt(barB1.Tag) - 1)
                barB2.Value = _dmxarrBarsB(CInt(barB2.Tag) - 1)
                barB3.Value = _dmxarrBarsB(CInt(barB3.Tag) - 1)
                barB4.Value = _dmxarrBarsB(CInt(barB4.Tag) - 1)
                barB5.Value = _dmxarrBarsB(CInt(barB5.Tag) - 1)
                barB6.Value = _dmxarrBarsB(CInt(barB6.Tag) - 1)
                barB7.Value = _dmxarrBarsB(CInt(barB7.Tag) - 1)
                barB8.Value = _dmxarrBarsB(CInt(barB8.Tag) - 1)
                barB9.Value = _dmxarrBarsB(CInt(barB9.Tag) - 1)
                barB10.Value = _dmxarrBarsB(CInt(barB10.Tag) - 1)
                barB11.Value = _dmxarrBarsB(CInt(barB11.Tag) - 1)
                barB12.Value = _dmxarrBarsB(CInt(barB12.Tag) - 1)
            Catch ex As Exception

            End Try
            If _blackOut = 1 Then
                btnBlackOut.BackColor = Color.fromArgb(120, 120, 120)
            Else
                btnBlackOut.BackColor = Color.Orange
            End If
            barGM.Value = CInt(_master * 100)
            barXFader.Value = CInt(_fader * 100)
            numCI.Value = _interval
            numPG.Value = _page
            numStart.Value = _startIdx
        End Sub
        Private Sub changeDevice(newDevice As Integer)
            If _device <> newDevice Then
                'save the settings of the current device
                devicesBarsA(_device) = CType(_dmxarrBarsA.Clone, Byte())
                devicesBarsB(_device) = CType(_dmxarrBarsB.Clone, Byte())
                devicesBlackOut(_device) = _blackOut
                devicesFader(_device) = _fader
                devicesMaster(_device) = _master
                devicesChInterval(_device) = _interval
                devicesPg(_device) = _page
                devicesStartCh(_device) = _startIdx
                'load new device settings from memory (if null load defaults)
                If devicesBarsA(newDevice) IsNot Nothing Then
                    _dmxarrBarsA = CType(devicesBarsA(newDevice).Clone, Byte())
                Else
                    _dmxarrBarsA = CType(_dmxarrEmpty.Clone, Byte())
                End If
                If devicesBarsB(newDevice) IsNot Nothing Then
                    _dmxarrBarsB = CType(devicesBarsB(newDevice).Clone, Byte())
                Else
                    _dmxarrBarsB = CType(_dmxarrEmpty.Clone, Byte())
                End If
                If devicesMaster(newDevice) <> Nothing Then
                    _master = devicesMaster(newDevice)
                Else
                    _master = 1
                End If
                If devicesBlackOut(newDevice) <> Nothing Then
                    _blackOut = devicesBlackOut(newDevice)
                Else
                    _blackOut = 1
                End If
                If devicesFader(newDevice) <> Nothing Then
                    _fader = devicesFader(newDevice)
                Else
                    _fader = 1
                End If
                If devicesStartCh(newDevice) <> Nothing Then
                    _startIdx = devicesStartCh(newDevice)
                Else
                    _startIdx = My.Settings.lbdStartIdx
                End If
                If devicesChInterval(newDevice) <> Nothing Then
                    _interval = devicesChInterval(newDevice)
                Else
                    _interval = My.Settings.lbdChannelInterval
                End If
                If devicesPg(newDevice) <> Nothing Then
                    _page = devicesPg(newDevice)
                Else
                    _page = 1
                End If
                renameChannelLabels(_page)
                _device = newDevice
                reloadBarValues()
            End If
        End Sub
#End Region
        Private Sub diagImageView_Load(sender As Object, e As EventArgs) Handles Me.Load
            Try
                dmxEngine.initialize() ' auto find and init
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.MsgBoxSetForeground)
            End Try
            _interval = My.Settings.lbdChannelInterval
            _startIdx = My.Settings.lbdStartIdx
            numCI.Value = _interval
            numStart.Maximum = _interval
            numStart.Value = _startIdx
            ' how to set the dmx: dmxEngine.SetDmx(byteArray)
            ' each member of byteArray represents 1 channel. byteArray(0) means channel 1.
            ' (values possible: 0-255) 0000 0000 to 1111 1111\
            ' then call dmxEngine.SetDmx() with the device number, the byte to use
        End Sub
        'Private Sub diagImageView_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, Label1.MouseDown
        '   moving = True
        '    ppt = e.Location
        'End Sub

        'Private Sub diagImageView_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, Label1.MouseMove
        '    If moving Then
        '        Me.Location = New Point(Me.Left + e.X - ppt.X, Me.Top + e.Y - ppt.Y)
        '    End If
        'End Sub

        'Private Sub diagImageView_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, Label1.MouseUp
        '    moving = False
        'End Sub

        Private Sub frmLightingBd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            timerNewDevice.Stop()
            For i As Integer = 0 To 3
                DmxEngine.setDmx(_dmxarrEmpty) 'set all lights to 0
            Next
            DmxEngine.abortThread() 'end all threads
            Frm3Viewer.WindowState = FormWindowState.Maximized
            Frm3Viewer.BringToFront()
            frmLightBox.Close()
        End Sub

        Private Function barIDtoChannelID(barID As Integer) As Integer
            'Debug.WriteLine(barID)
            'Debug.WriteLine((_startIdx + ((barID - 1) * _interval)) + ((_page - 1) * 12 * _interval))
            'Debug.WriteLine("---------------------")
            Return (_startIdx + ((barID - 1) * _interval)) + ((_page - 1) * 12 * _interval)
        End Function
        Private Sub timerNewDevice_Tick(sender As Object, e As EventArgs) Handles timerNewDevice.Tick
            Call dmxEngine.initialize() ' find new devices and start thread for them
            If DmxEngine.status = FT_STATUS.FT_OK Then
                btnD0.Enabled = True
            Else
                btnD0.Enabled = False
            End If
        End Sub




        Private Sub btnBlackOut_Click(sender As Object, e As EventArgs) Handles btnBlackOut.Click
            If _blackOut = 1 Then
                btnBlackOut.BackColor = Color.Orange
                _blackOut = 0
            Else
                btnBlackOut.BackColor = Color.fromArgb(120, 120, 120)
                _blackOut = 1
            End If
            For i As Integer = 0 To 511
                dmxarrA(i) = CByte(_dmxarrBarsA(i) * _master * _blackOut)
                dmxarrB(i) = CByte(_dmxarrBarsB(i) * _master * _blackOut)
                _dmxarr(i) = CByte((dmxarrA(i) * (barXFader.Value / 100)) + (dmxarrB(i) * (1 - (barXFader.Value / 100))))
            Next
            dmxEngine.SetDmx(_dmxarr)
        End Sub

        Private Sub barGM_Scroll(sender As Object, e As EventArgs) Handles barGM.Scroll
            _master = barGM.Value / 100
            For i As Integer = 0 To 511
                dmxarrA(i) = CByte(_dmxarrBarsA(i) * _master * _blackOut)
                dmxarrB(i) = CByte(_dmxarrBarsB(i) * _master * _blackOut)
                _dmxarr(i) = CByte((dmxarrA(i) * (barXFader.Value / 100)) + (dmxarrB(i) * (1 - (barXFader.Value / 100))))
            Next
            dmxEngine.SetDmx(_dmxarr)
        End Sub

        Private Sub barA_Scroll(sender As Object, e As EventArgs) Handles barA9.Scroll, barA8.Scroll, barA7.Scroll, barA6.Scroll, _
                                                                          barA5.Scroll, barA4.Scroll, barA3.Scroll, barA2.Scroll, barA12.Scroll, barA11.Scroll, barA10.Scroll, barA1.Scroll
            Dim bar As CoolTrackBar = DirectCast(sender, CoolTrackBar)
            For i As Integer = CInt(bar.Tag) - 1 To CInt(bar.Tag) - 2 + Me._interval
                _dmxarrBarsA(i) = CByte(bar.Value)
                dmxarrA(i) = CByte(bar.Value * _master * _blackOut)
                _dmxarr(i) = CByte((dmxarrA(i) * (barXFader.Value / 100)) + (dmxarrB(i) _
                                                                             * (1 - (barXFader.Value / 100))))
                dmxEngine.SetDmx(_dmxarr)
            Next
        End Sub

        Private Sub barB_Scroll(sender As Object, e As EventArgs) Handles barB9.Scroll, barB8.Scroll, barB7.Scroll, barB6.Scroll, _
                                                                          barB5.Scroll, barB4.Scroll, barB3.Scroll, barB2.Scroll, barB12.Scroll, barB11.Scroll, barB10.Scroll, barB1.Scroll
            Dim bar As CoolTrackBar = DirectCast(sender, CoolTrackBar)
            For i As Integer = CInt(bar.Tag) - 1 To CInt(bar.Tag) - 2 + Me._interval
                _dmxarrBarsB(i) = CByte(bar.Value)
                dmxarrB(i) = CByte(bar.Value * _master * _blackOut)
                _dmxarr(i) = CByte(dmxarrA(i) * (barXFader.Value / 100) + (dmxarrB(i)) * (1 - (barXFader.Value / 100)))
                DmxEngine.SetDmx(_dmxarr)
            Next
        End Sub

        Private Sub barXFader_Scroll(sender As Object, e As EventArgs) Handles barXFader.Scroll
            For i As Integer = 0 To 511
                _dmxarr(i) = CByte((dmxarrA(i) * (barXFader.Value / 100)) + (dmxarrB(i) * (1 - (barXFader.Value / 100))))
            Next
            _fader = barXFader.Value / 100
            dmxEngine.SetDmx(_dmxarr)
        End Sub


        Private Sub btnD_EnabledChanged(sender As Object, e As EventArgs) Handles btnD0.EnabledChanged
            Dim btn As Button = DirectCast(sender, Button)
            If btn.Enabled Then
                btn.Show()
                If _device = CInt(btn.Tag) Then
                    btn.BackColor = Color.DarkSeaGreen
                Else
                    btn.BackColor = Color.MediumSeaGreen
                End If
            Else
                btn.Hide()
            End If
        End Sub

        Private Sub numPG_ValueChanged(sender As Object, e As EventArgs) Handles numPG.ValueChanged
            _page = CInt(numPG.Value)
            renameChannelLabels(_page)
        End Sub
        Private firstCIChg As Boolean = True
        Private Sub numCI_ValueChanged(sender As Object, e As EventArgs) Handles numCI.ValueChanged
            _interval = CInt(numCI.Value)
            Dim totalChnls As Integer = CInt(Math.Floor(512 / _interval))
            numPG.Maximum = CDec(Math.Ceiling(totalChnls / 12))
            numStart.Maximum = _interval
            _lastPageChnls = CInt(((totalChnls / 12) - Math.Floor(totalChnls / 12)) * 12)
            'Debug.WriteLine("Total Chnls: " & totalChnls)
            'Debug.WriteLine("Last Page: " & _lastPageChnls)
            If firstCIChg Then
                firstCIChg = False
            Else
                My.Settings.lbdChannelInterval = _interval
                My.Settings.Save()
            End If
            renameChannelLabels(_page)
        End Sub
        Private firstStartChg As Boolean = True
        Private Sub numStart_ValueChanged(sender As Object, e As EventArgs) Handles numStart.ValueChanged
            _startIdx = CInt(numStart.Value)
            If firstStartChg Then
                firstStartChg = False
            Else
                My.Settings.lbdStartIdx = _startIdx
                My.Settings.Save()
            End If
            renameChannelLabels(_page)
        End Sub

        Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD0.Click
            btnD0.BackColor = Color.MediumSeaGreen
            DirectCast(sender, Button).BackColor = Color.DarkSeaGreen
            changeDevice(CInt(DirectCast(sender, Button).Tag))
        End Sub

        Private Sub frmLightingBd_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
            Me.Close()
        End Sub


        Private Sub frmLightingBd_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub

        Private Sub lbGM_Click(sender As Object, e As EventArgs) Handles lbGM.Click

        End Sub
    End Class
End Namespace