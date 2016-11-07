Imports Entity._3Modules
Imports Entity._4Classes.Types

Namespace _0App.InitialSetup
    Public Class IFmBase
        Inherits Windows.Forms.Form
        'Implements System.Windows.Forms.Design.IWindowsFormsEditorService
        Public ForceClose As Boolean = False
        Public RetToCine As Boolean = False
        Private components As System.ComponentModel.IContainer

        Friend fadeReverse As Boolean = False
        Protected tmrAnim As New Timers.Timer(50)
        Protected Friend Sub Fade(Optional ByVal fadeOut As Boolean = False)
            AddHandler tmrAnim.Elapsed, AddressOf tmrAnim_Tick
            fadeReverse = fadeOut
            tmrAnim.Interval = 50
            tmrAnim.Start()
        End Sub
        Friend Overridable Sub tmrAnim_Tick(sender As Object, e As EventArgs)
            If fadeReverse Then
                If Me.Opacity > 0.25 Then
                    invokeAction(Sub() Me.Opacity -= 0.1)
                Else
                    DirectCast(sender, Timers.Timer).Stop()
                    Me.ForceClose = True
                    invokeAction(Sub() Me.Close())
                End If
            Else
                If Me.Opacity < 0.9 Then
                    invokeAction(Sub() Me.Opacity += 0.05)
                Else
                    DirectCast(sender, Timers.Timer).Stop()
                    invokeAction(Sub() Me.Opacity = 1)
                End If
            End If
        End Sub
        Protected Friend Overridable Sub Base_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            If ForceClose Then
                _6Misc.SecondMonitor.CheckExit()
                _1Dialogs.Popups.DiagCOM.Close()
                If OpenFormsCount <= 1 Then
                    DmxEngine.abortThread()
                End If
            Else
                e.Cancel = True
                Me.Fade(True)
                If FrmCinematic.BlankOut And OpenFormsCountNo2M < 3 Then
                    FrmCinematic.Close()
                End If
            End If
        End Sub
        Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'IFmBase
            '
            Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
            Me.ClientSize = New System.Drawing.Size(284, 261)
            Me.Font = New System.Drawing.Font("Segoe UI Semilight", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Name = "IFmBase"
            Me.Opacity = 0.1R
            Me.TopMost = True
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.ResumeLayout(False)

        End Sub
        Protected Overrides ReadOnly Property CreateParams() As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                If Not Me.DesignMode Then cp.ExStyle = cp.ExStyle Or &H80
                Return cp
            End Get
        End Property
        Friend Overridable Sub invokeAction(a As Action, Optional c As Control = Nothing)
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