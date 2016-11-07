Imports System.Runtime.InteropServices

Namespace _5Controls

    Public Class ListViewX
        Inherits ListView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ' Enable internal ListView double-buffering
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

            If DesignMode Then
                Me.HideSelection = False
                Me.FullRowSelect = True
                Me.Activation = ItemActivation.TwoClick
                Me.Sorting = SortOrder.Ascending
                Me.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top
                Me.BorderStyle = BorderStyle.None
                Me.HeaderStyle = ColumnHeaderStyle.None
                If Me.Parent IsNot Nothing Then
                    Me.BackColor = Me.Parent.BackColor
                Else
                    Me.BackColor = Color.fromArgb(100, 100, 100)
                End If
                Me.ForeColor = Color.FromArgb(64, 64, 64)

                Me.Font = New Font("Segoe UI SemiLight", 11)
            End If

            ' Disable default CommCtrl painting on non-XP systems
            If (Not NativeInterop.IsWinXP) Then
                SetStyle(ControlStyles.UserPaint, True)
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            If GetStyle(ControlStyles.UserPaint) Then
                Dim m As New Message()
                m.HWnd = Handle
                m.Msg = NativeInterop.WM_PRINTCLIENT
                m.WParam = e.Graphics.GetHdc()
                m.LParam = CType(NativeInterop.PRF_CLIENT, IntPtr)
                DefWndProc(m)
                e.Graphics.ReleaseHdc(m.WParam)
            End If
            MyBase.OnPaint(e)
        End Sub
    End Class

    Friend Class NativeInterop
        Public Const WM_PRINTCLIENT As Integer = &H318
        Public Const PRF_CLIENT As Integer = &H4

        <DllImport("user32.dll")>
        Public Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As IntPtr) As IntPtr
        End Function

        Public Shared ReadOnly Property IsWinXP() As Boolean
            Get
                Dim OS As OperatingSystem = Environment.OSVersion
                Return _
                    (OS.Platform = PlatformID.Win32NT) AndAlso
                    ((OS.Version.Major > 5) OrElse ((OS.Version.Major = 5) AndAlso (OS.Version.Minor = 1)))
            End Get
        End Property

        Public Shared ReadOnly Property IsWinVista() As Boolean
            Get
                Dim OS As OperatingSystem = Environment.OSVersion
                Return (OS.Platform = PlatformID.Win32NT) AndAlso (OS.Version.Major >= 6)
            End Get
        End Property
    End Class
End Namespace