Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.IO
Imports Entity._3Modules

Namespace _0App.InitialSetup

    Public Class FrmCinematic
        Public StartScene As Integer = 1
        Public DontInit As Boolean = False
        Public BlankOut As Boolean = False
        Private Shared _first As Boolean = True
        Private _curScene As Integer = 0
        Private _curOpc As Double = 0
        Private _switch As Integer = 0
        Private _ct As Integer = 0
        Private _isHeld As Boolean = True
        Private _tmrAnim As New Timers.Timer(50)
        Private _strSize As SizeF
        Private _strSize2 As SizeF
        Private _ltrSize As SizeF
        'Private fwCheck As Boolean = False
        'Private fwCheckIssue As Boolean = False
        Private Sub frmCinematic_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality
            Using whiteBr As New SolidBrush(Color.FromArgb(CInt(_curOpc * 255), Color.White))
                Using whiteSmBr As New SolidBrush(Color.FromArgb(CInt(_curOpc * 255), Color.WhiteSmoke))
                    Using backBr As New SolidBrush(Color.FromArgb(CInt(_curOpc * 255), 129, 137, 153))
                        Select Case _curScene
                            Case 1
                                DrawCentreText(e, "Hi")
                            Case 2
                                'e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias
                                e.Graphics.DrawString("Welcome to the", New Font("Segoe UI SemiLight", 20), whiteBr _
                                                      , CSng(e.ClipRectangle.Width / 2 - _strSize.Width / 2),
                                                      CSng(e.ClipRectangle.Height / 2 - _strSize.Height - 48))

                                e.Graphics.FillRectangle(backBr, e.ClipRectangle.Width \ 2 - 32,
                                                    CInt(e.ClipRectangle.Height / 2 - 32), 64, 64)
                                e.Graphics.DrawString("En", New Font("Segoe UI SemiLight", 30), whiteBr,
                                                    e.ClipRectangle.Width \ 2 - 29,
                                                    CInt(e.ClipRectangle.Height / 2 - 28))

                                e.Graphics.DrawString("Entity System", New Font("Segoe UI SemiLight", 26), whiteSmBr _
                                                      , CSng(e.ClipRectangle.Width / 2 - _strSize2.Width / 2 + _ltrSize.Width / 2),
                                                      CSng(e.ClipRectangle.Height / 2 + 42))
                            'Case 3
                            '    drawTopText(e, "To get started," & vbCrLf & "please let us through the firewall.", 20)
                            Case 6
                                'If fwCheckIssue Then
                                '    drawCentreText(e, "Good work." & vbCrLf & "let's set up the projector settings.", 20)
                                'Else
                                DrawCentreText(e, "To get started," & vbCrLf & "let's set up your projector.", 20)
                            'End If
                            Case 8
                                DrawCentreText(e, "Well done!" & vbCrLf & "Let's move on to lights.", 20)
                            Case 10
                                DrawCentreText(e,
                                               "Don't panic if you made mistakes." & vbCrLf & "You can correct them later.",
                                               20)
                            Case 11
                                DrawCentreText(e, "We're almost done." & vbCrLf & "Just one more step...", 20)
                            Case 13
                                DrawCentreText(e, "You have set a password." & vbCrLf &
                                                  "You will now be asked for it every time you start Entity.", 20)
                            Case 14
                                DrawCentreText(e, "... And we're done!", 20)
                        End Select
                    End Using
                End Using
            End Using
        End Sub

        Public Sub ReInit()
            _tmrAnim.Stop()
            Me.BackColor = Color.FromArgb(100, 100, 100)
            _curScene = StartScene
            Cursor.Hide()
            _tmrAnim.Start()
        End Sub

        Private Sub TmrAnim_Tick(sender As Object, e As EventArgs)
            Select Case _curScene
                Case 0
                    BlankOut = False
                    FadeFrm(False, New Action(Sub() _curScene = StartScene))
                Case 1
                    BlankOut = False
                    FadeInOut(0.5, 1.5, 0.5, 0.2)
                Case 2
                    BlankOut = False
                    FadeInOut(0.5, 2, 0.5, 0.6)
                Case 3
                    'If My.Computer.Network.IsAvailable = False Then
                    _curScene = 6
                    Exit Sub
                'End If
                'If Not fwCheck Then
                '    fwCheck = True
                '    DiagCOM.Show()
                '    DiagCOM.Hide()
                'End If
                'If fwCheck Then
                '    If switch = 0 Then
                '        switch = 1
                '        'Dim str As String = "-----------" & vbCrLf
                '        Dim pcs As New List(Of String)
                '        For Each p As Process In Process.GetProcesses()
                '            pcs.Add(p.ProcessName.ToLower)
                '            'str &= p.ProcessName.ToLower & vbCrLf
                '        Next
                '        'WriteLog(str)
                '        If pcs.Contains("rundll32") Then
                '            fwCheckIssue = True
                '        Else
                '            switch = 0
                '            curScene = 6
                '            Exit Sub
                '        End If
                '    End If
                '    fadeInOut(0.5, 1.5, 0.5, 0.2)
                'End If
                Case 4
                    'If Me.Opacity > 0.25 Then
                    '    Me.Opacity -= 0.2
                    'Else
                    '    switch = 0
                    '    Me.Opacity = 0.1
                    '    If Me.Visible Then
                    '        Me.Hide()
                    '    End If
                    '    If Not tmrCheckFW.Enabled Then tmrCheckFW.Start()
                    'End If
                Case 5
                    BlankOut = False
                    If Me.Opacity < 0.9 Then
                        Me.Opacity += 0.1
                    Else
                        Me.Opacity = 1
                        _curScene = 6
                    End If
                Case 6
                    BlankOut = False
                    FadeInOut(0.5, 1.5, 0.5, 0.2)
                Case 7
                    If Not BlankOut Then
                        BlankOut = True
                        My.Settings.secondaryScrRez = New Size(0, 0)
                        My.Settings.secondaryScrWH = 0
                        My.Settings.secondaryScr = ""
                        My.Settings.Save()
                        invokeAction(Sub()
                                         DecideProjFrm()
                                         Cursor.Show()
                                     End Sub)
                    End If
                'fadeFrm(True, New Action(Sub() Me.Close()))
                Case 8
                    BlankOut = False
                    FadeInOut(1, 1, 0.5, 0.2)
                Case 9
                    If Not BlankOut Then
                        BlankOut = True
                        invokeAction(Sub()
                                         _4Classes.Types.DmxEngine.initialize()
                                         IFm1LightQ.Show()
                                         Cursor.Show()
                                     End Sub)
                    End If
                'fadeFrm(True, New Action(Sub() Me.Close()))
                Case 10
                    BlankOut = False
                    FadeInOut(1, 1, 0.5, 0.2)
                Case 11
                    BlankOut = False
                    FadeInOut(1, 1, 0.5, 0.2)
                Case 12
                    If Not BlankOut Then
                        BlankOut = True
                        invokeAction(Sub()
                                         IFm2Security.Show()
                                         Cursor.Show()
                                     End Sub)
                    End If
                Case 13
                    BlankOut = False
                    FadeInOut(1, 1, 0.5, 0.2)
                Case 14
                    BlankOut = False
                    FadeInOut(1, 1, 0.5, 0.2)
                Case 15
                    If Not BlankOut Then
                        BlankOut = True
                        invokeAction(Sub()
                                         IFm3Tips.Show()
                                         Cursor.Show()
                                     End Sub)
                    End If
                Case 16
                    If Not BlankOut Then
                        My.Settings.initialSetup = False
                        My.Settings.Save()
                        Me.TopMost = True
                        BlankOut = True
                        invokeAction(Sub()
                                         Frm0Loading.Show()
                                         Cursor.Show()
                                     End Sub)
                    End If
                    FadeFrm(True, New Action(Sub()
                                                 BlankOut = False
                                                 Me.TopMost = False
                                                 Me.Close()
                                             End Sub))
            End Select
        End Sub

        Private Sub DecideProjFrm()
            If Screen.AllScreens.Length <= 1 Then
                IFm0ProjectionC.Show()
            Else
                IFm0ProjectionA.Show()
            End If
        End Sub

        Private Sub FadeInOut(fInSec As Double, holdSec As Double, fOutSec As Double, afterSec As Double)
            Dim inSpeed As Double = 1 / (fInSec * 20)
            Dim outSpeed As Double = 1 / (fOutSec * 20)
            If _switch = 0 Then
                If _curOpc < 0.95 Then
                    _curOpc += inSpeed
                    If _curOpc > 1 Then _curOpc = 1
                Else
                    _curOpc = 1
                    _switch = 1
                End If
            ElseIf _switch = 1 Then
                If _ct < holdSec * 10 Then
                    _ct += 1
                    Exit Sub
                Else
                    _ct = 0
                    _switch = 2
                End If
            ElseIf _switch = 2 Then
                If _curOpc > 0.05 Then
                    _curOpc -= outSpeed
                    If _curOpc < 0 Then _curOpc = 0
                Else
                    _curOpc = 0
                    _switch = 3
                End If
            Else
                If _ct < afterSec * 10 Then
                    _ct += 1
                    Exit Sub
                Else
                    _ct = 0
                    _switch = 0
                    _curScene += 1
                End If
            End If
            invokeAction(Sub() Me.Invalidate())
        End Sub

        Private Sub FadeFrm(Optional fadeOut As Boolean = False,
                            Optional ByVal execAfter As Action = Nothing)
            If fadeOut Then
                If Me.Opacity > 0.25 Then
                    invokeAction(Sub() Me.Opacity -= 0.1)
                Else
                    _switch = 0
                    invokeAction(Sub() Me.Opacity = 0.1)
                    If Me.Visible Then
                        Me.Hide()
                        If execAfter IsNot Nothing Then
                            invokeAction(Sub() execAfter())
                        End If
                    End If
                End If
            Else
                If Me.Opacity < 0.9 Then
                    invokeAction(Sub() Me.Opacity += 0.05)
                Else
                    invokeAction(Sub() Me.Opacity = 1)
                    If execAfter IsNot Nothing Then
                        invokeAction(Sub() execAfter())
                    End If
                End If
            End If
        End Sub
        Private Sub DrawCentreText(e As PaintEventArgs, str As String, Optional ByVal fontSize As Single = 30)
            Using whiteBr As New SolidBrush(Color.FromArgb(CInt(_curOpc * 255), Color.White))
                Dim strSize As SizeF = e.Graphics.MeasureString(str, New Font("Segoe UI SemiLight", fontSize))
                e.Graphics.DrawString(str, New Font("Segoe UI SemiLight", fontSize), whiteBr _
                                      , CSng(e.ClipRectangle.Width / 2 - strSize.Width / 2),
                                      CSng(e.ClipRectangle.Height / 2 - strSize.Height / 2))
            End Using
        End Sub
        'Private Sub tmrCheckFW_Tick(sender As Object, e As EventArgs) Handles tmrCheckFW.Tick
        '    Dim pcs As New List(Of String)
        '    For Each p As Process In Process.GetProcesses()
        '        pcs.Add(p.ProcessName.ToLower)
        '    Next
        '    If Not pcs.Contains("rundll32") Then
        '        tmrCheckFW.Stop()
        '        switch = 0
        '        Me.Show()
        '        curScene = 5
        '        Exit Sub
        '    End If
        'End Sub
        Private Sub frmCinematic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If String.IsNullOrEmpty(My.Settings.workDir) Then
                My.Settings.workDir = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Entity Shows"
                My.Settings.Save()
            End If
            If Not Directory.Exists(My.Settings.workDir) Then
                Directory.CreateDirectory(My.Settings.workDir)
            End If
            CurWorkDir = New _4Classes.Project.WorkingDirectory(My.Settings.workDir)
            'upgrade settings if required
            'this keeps the settings the same when a new version of the Entity System is installed

            If My.Settings.reqUpgrade Then 'Upgrade application settings from previous version
                My.Settings.Upgrade()

                My.Settings.reqUpgrade = False 'Always set this to avoid potential upgrade loop
                My.Settings.Save()
            End If
            If Not My.Settings.initialSetup Then
                Frm0Loading.Show()
                Me.Close()
                Exit Sub
            End If
            AddHandler _tmrAnim.Elapsed, AddressOf TmrAnim_Tick
            _curScene = 0
            Me.Icon = My.Resources.en
            Using b As New Bitmap(1, 1)
                Using g As Graphics = Graphics.FromImage(b)
                    _strSize = g.MeasureString("Welcome to the", New Font("Segoe UI SemiLight", 20))
                    _strSize2 = g.MeasureString("Entity System", New Font("Segoe UI SemiLight", 26))
                    _ltrSize = g.MeasureString("i", New Font("Segoe UI SemiLight", 10))
                End Using
            End Using
            Cursor.Hide()
            _tmrAnim.Start()
        End Sub

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
        End Sub

        Private Sub frmCine_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            Cursor.Show()
            _tmrAnim.Stop()
            _6Misc.SecondMonitor.CheckExit()
            _1Dialogs.Popups.DiagCOM.Close()
        End Sub

        Private Sub FrmCinematic_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
            If e.KeyCode = Keys.Space Then
                Me.Opacity = 1
                Select Case _curScene
                    Case Is < 7
                        _curScene = 7
                    Case Is < 9
                        _curScene = 9
                    Case Is < 12
                        _curScene = 12
                End Select
            End If
        End Sub

        Private Sub FrmCinematic_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
            CheckSecondaryScreen()
        End Sub
        Private Sub invokeAction(a As Action, Optional c As Control = Nothing)
            If c Is Nothing Then c = Me
            Try
                If c.InvokeRequired Then
                    c.BeginInvoke(a)
                Else
                    a()
                End If
            Catch
            End Try
        End Sub
    End Class
End Namespace