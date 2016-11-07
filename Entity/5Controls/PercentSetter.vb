Imports System.ComponentModel

Namespace _5Controls

    Public Class PercentSetter
        Inherits UserControl
        Implements INotifyPropertyChanged
        Public Event MouseUpX()
        Private _mValue As Double
        Private _mVert As Boolean
        Private _mProgresscolor As Color
        Private _mProgresstext As String

        Public Property Value As Double
            Get
                Return _mValue
            End Get
            Set(value As Double)
                If Not (value = _mValue) Then
                    Me._mValue = value
                    NotifyValueChanged("value")
                End If
            End Set
        End Property

        Public Property Vertical As Boolean
            Get
                Return _mVert
            End Get
            Set(value As Boolean)
                If Not (value = _mVert) Then
                    Me._mVert = value
                    NotifyValueChanged("vertical")
                End If
            End Set
        End Property

        Public Property ProgressColor As Color
            Get
                Return _mProgresscolor
            End Get
            Set(value As Color)
                If Not (value = _mProgresscolor) Then
                    Me._mProgresscolor = value
                    NotifyValueChanged("progresscolor")
                End If
            End Set
        End Property

        Public Property ProgressText As String
            Get
                Return _mProgresstext
            End Get
            Set(value As String)
                If Not (value = _mProgresstext) Then
                    Me._mProgresstext = value
                    NotifyValueChanged("progresstext")
                End If
            End Set
        End Property

        Public Property RightClickEnabled As Boolean

        'number of digits to round text
        Public Property AccuracyDigits As Integer

        Public Event ValueChanged As PropertyChangedEventHandler _
            Implements INotifyPropertyChanged.PropertyChanged

        Private Sub NotifyValueChanged(ByVal info As String)
            RaiseEvent ValueChanged(Me, New PropertyChangedEventArgs(info))
        End Sub

        Private Sub percentSetter_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.tbEdit.Left = 0
            Me.tbEdit.Top = 0
            Me.tbEdit.Height = Me.Height
            Me.tbEdit.Width = Me.Width
            Me.pb.BackColor = Me.BackColor
            Me.pb.ForeColor = Me.ForeColor
        End Sub

        Public Sub me_valueChanged(sender As Object, e As PropertyChangedEventArgs) Handles Me.ValueChanged
            If e.PropertyName = "value" Then
                If Me.Value > 100 Then Me.Value = 100
                If Me.Value < 0 Then Me.Value = 0
                Me.pb.ProgressText = Math.Round(Me.Value, AccuracyDigits) & "%"
                Me.pb.Value = CInt(Me.Value)
            ElseIf e.PropertyName = "vertical" Then
                If Me.Vertical Then
                    pb.Vertical = True
                Else
                    pb.Vertical = False
                End If
            ElseIf e.PropertyName = "progresscolor" Then
                Me.pb.ProgressColor = Me.ProgressColor
            ElseIf e.PropertyName = "progresstext" Then
                Me.pb.ProgressText = Me.ProgressText
            End If
        End Sub

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Me.Value = 0
            Me.ProgressColor = Color.WhiteSmoke
            Me.ProgressText = ""
            Me.Vertical = False
            Me.RightClickEnabled = True
            Me.AccuracyDigits = 2
        End Sub

        Dim _dragging As Boolean = False

        Private Sub pb_MouseDown(sender As Object, e As MouseEventArgs) Handles pb.MouseDown
            If tbEdit.Visible Then
                If Not tbEdit.Text = "" Then
                    Me.Value = CDbl(tbEdit.Text)
                End If
                tbEdit.Hide()
            Else
                If e.Button = MouseButtons.Left Then
                    If Vertical Then
                        Dim buf As Double = e.Location.Y / Me.Height * 100
                        If buf < 0 Then buf = 0
                        If buf > 100 Then buf = 100
                        Me.Value = 100 - buf
                    Else
                        Dim buf As Double = e.Location.X / Me.Width * 100
                        If buf < 0 Then buf = 0
                        If buf > 100 Then buf = 100
                        Me.Value = buf
                    End If
                    _dragging = True
                ElseIf e.Button = MouseButtons.Right Then
                    If RightClickEnabled Then
                        If Vertical Then
                            tbEdit.Font = New Font("Segoe UI SemiLight", CSng(Me.Width / 5 * 2))
                            tbEdit.ScrollBars = ScrollBars.Both
                        Else
                            tbEdit.Font = New Font("Segoe UI SemiLight", CSng(Me.Height / 5 * 2))
                        End If
                        tbEdit.Text = CStr(Math.Round(CDec(Me.Value), CInt(AccuracyDigits)))
                        tbEdit.Show()
                    End If
                End If
            End If
        End Sub

        Private Sub tbEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles tbEdit.KeyDown
            If e.KeyCode = Keys.Enter Then
                If Not tbEdit.Text = "" Then
                    Me.Value = CDbl(tbEdit.Text)
                End If
                tbEdit.Hide()
            End If
        End Sub

        Private Sub tbEdit_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles tbEdit.KeyPress
            e.Handled = NumbersOnly(e.KeyChar, tbEdit)
        End Sub

        Private Function NumbersOnly(ByVal pstrChar As Char, ByVal oTextBox As TextBox) As Boolean
            'validate the entry for a textbox limiting it to only numeric values and the decimal point
            If CBool((CInt(Convert.ToString(pstrChar) = ".") And InStr(oTextBox.Text, "."))) Then Return True _
            'accept only one instance of the decimal point
            If Convert.ToString(pstrChar) <> "." And pstrChar <> vbBack Then
                Return CBool(IIf(IsNumeric(pstrChar), False, True)) 'check if numeric is returned
            End If
            Return False 'for backspace
        End Function

        Private Sub pb_MouseMove(sender As Object, e As MouseEventArgs) Handles pb.MouseMove
            If _dragging Then
                If Vertical Then
                    Dim buf As Single = CSng(e.Location.Y / Me.Height * 100)
                    If buf < 0 Then buf = 0
                    If buf > 100 Then buf = 100
                    Me.Value = 100 - buf
                Else
                    Dim buf As Single = CSng(e.Location.X / Me.Width * 100)
                    If buf < 0 Then buf = 0
                    If buf > 100 Then buf = 100
                    Me.Value = buf
                End If
            End If
        End Sub

        Private Sub pb_MouseUp(sender As Object, e As MouseEventArgs) Handles pb.MouseUp
            RaiseEvent MouseUpX()
            If e.Button = MouseButtons.Left Then
                _dragging = False
            End If
        End Sub


        Private Sub tbEdit_TextChanged(sender As Object, e As EventArgs) Handles tbEdit.TextChanged
            If tbEdit.Text <> "" Then
                If CDbl(tbEdit.Text) > 100 Then
                    tbEdit.Text = "100"
                    tbEdit.SelectionStart = tbEdit.Text.Length
                End If
            End If
        End Sub

        Private Sub tbEdit_MouseDown(sender As Object, e As MouseEventArgs) Handles tbEdit.MouseDown
            If e.Button = MouseButtons.Right Then
                If Not tbEdit.Text = "" Then
                    Me.Value = CDbl(tbEdit.Text)
                End If
                tbEdit.Hide()
            End If
        End Sub


        Private _keyDownDir As ArrowDirection

        Private Sub percentSetter_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        End Sub

        Protected Overrides Function ProcessDialogKey(ByVal keyData As  _
                                                         Keys) As Boolean
            If keyData = Keys.Up Then
                If Me.Value < 100 Then
                    Me.Value += 1
                End If
            ElseIf keyData = Keys.Down Then
                If Me.Value > 0 Then
                    Me.Value -= 1
                End If
            End If
            Select Case keyData
                Case Keys.Up
                    _keyDownDir = ArrowDirection.Up
                Case Keys.Down
                    _keyDownDir = ArrowDirection.Down
                Case Else
                    Return False
                    Exit Function
            End Select
            timerKeyDown.Start()
            Return True
        End Function

        Private Sub percentSetter_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
            timerKeyDown.Stop()
        End Sub

        Private Sub timerKeyDown_Tick(sender As Object, e As EventArgs) Handles timerKeyDown.Tick
            If _keyDownDir = ArrowDirection.Right Or _keyDownDir = ArrowDirection.Up Then
                If Me.Value < 100 Then
                    Me.Value += 1
                End If
            ElseIf _keyDownDir = ArrowDirection.Left Or _keyDownDir = ArrowDirection.Down Then
                If Me.Value > 0 Then
                    Me.Value -= 1
                End If
            End If
        End Sub

        Private Sub percentSetter_Scroll(sender As Object, e As MouseEventArgs) Handles MyBase.MouseWheel, pb.MouseWheel
            Me.Value += e.Delta / 76
        End Sub

    End Class
End Namespace