Imports Entity._3Modules
Imports Entity._4Classes.Events
Imports Entity._4Classes.Types

Namespace _0App.InitialSetup
    Public Class IFm0ProjectionC
        Inherits IFmBase
        Private WScreenChangedEvent As ScreenChangedEvent = ScreenChangedEvent.Instance
        Private _identifyForms As New List(Of Form)
        Private _idFormsShown As Boolean = False

        Public Sub CheckScreens()
            If Me.Visible Then
                If Screen.AllScreens.Length > 1 Then
                    FrmCinematic.BackColor = Color.fromArgb(100, 100, 100)
                    IFm0ProjectionA.Show()
                    Me.Close()
                End If
            End If
        End Sub

        Protected Friend Overrides Sub Base_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If ForceClose Then
                _6Misc.SecondMonitor.CheckExit()
                _1Dialogs.Popups.DiagCOM.Close()
                If OpenFormsCount <= 1 Then
                    dmxEngine.abortThread()
                End If
                RemoveHandler WScreenChangedEvent.SecondaryScreenChanged, AddressOf scrChanged
            Else
                e.Cancel = True
                Me.Fade(True)
                If FrmCinematic.BlankOut And OpenFormsCountNo2M < 3 Then
                    FrmCinematic.Close()
                End If
            End If
        End Sub
        Private Sub IFm0ProjectionC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            pnlContent.Left = CInt(Me.Width / 2 - pnlContent.Width / 2)
            pnlContent.Top = CInt(Me.Height / 2 - pnlContent.Height / 2)
            AddHandler WScreenChangedEvent.SecondaryScreenChanged, AddressOf scrChanged
            Me.Icon = My.Resources.en 'set icon
            Me.ForceClose = False
            Me.Fade()
        End Sub

        'Private Sub IFm0ProjectionC_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '    If Not ForceClose Then
        '        e.Cancel = True
        '        Me.Fade(True)
        '    End If
        'End Sub

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
        Sub scrChanged()
            CheckScreens()
        End Sub

        Private Sub btnMan_Click(sender As Object, e As EventArgs) Handles btnMan.Click
            FrmCinematic.BackColor = Color.fromArgb(100, 100, 100)
            IFm0ProjectionM.Show()
            Me.Close()
        End Sub

        Private Sub IFm0ProjectionC_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            CheckSecondaryScreen()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            If Me.Opacity = 1 Then Me.Close()
        End Sub
    End Class
End Namespace