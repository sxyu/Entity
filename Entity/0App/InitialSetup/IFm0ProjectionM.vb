Imports Entity._3Modules
Namespace _0App.InitialSetup
    Public Class IFm0ProjectionM
        Inherits IFmBase
        'Private WithEvents WScreenChangedEvent As ScreenChangedEvent = ScreenChangedEvent.Instance
        Private _identifyForms As New List(Of Form)
        Private _idFormsShown As Boolean = False

        Private Sub IFm0ProjectionM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            content.Visible = True
            btnMan.Text = "&Auto Setup"
            numRezHoriz.Value = 800
            numRezVert.Value = 600
            content.Left = CInt(Me.Width / 2 - content.Width / 2)
            content.Top = CInt(Me.Height / 2 - content.Height / 2)
            Me.Icon = My.Resources.en 'set icon
            Me.ForceClose = False
            Me.Fade()
        End Sub
        'Private Sub IFm0ProjectionM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        Private Sub btnMan_Click(sender As Object, e As EventArgs) Handles btnMan.Click
            FrmCinematic.BackColor = Color.FromArgb(100, 100, 100)
            If Screen.AllScreens.Length > 1 Then
                IFm0ProjectionA.Show()
            Else
                IFm0ProjectionC.Show()
            End If
            Me.Close()
        End Sub

        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If numRezHoriz.Value > 0 And numRezVert.Value > 0 Then
                My.Settings.secondaryScr = "MANUAL"
                If numRezHoriz.Value <> My.Settings.secondaryScrRez.Width Or numRezVert.Value <> My.Settings.secondaryScrRez.Height Then
                    My.Settings.secondaryScrRez = New Size(CInt(numRezHoriz.Value), CInt(numRezVert.Value))
                    My.Settings.secondaryScrWH = numRezHoriz.Value / numRezVert.Value
                End If
                FrmCinematic.BlankOut = False
                FrmCinematic.StartScene = 8
                FrmCinematic.ReInit()

                Me.Close()
            End If
        End Sub
        Private Sub IFm0ProjectionM_Resize(sender As Object, e As EventArgs) Handles Me.Resize
            CheckSecondaryScreen()
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            If Me.Opacity = 1 Then Me.Close()
        End Sub
    End Class
End Namespace