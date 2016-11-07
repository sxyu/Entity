Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Imports Entity._3Modules
Imports Entity._0App
Imports Entity._4Classes.Types

Namespace _1Dialogs.Popups
    Public Class DiagCOM
        Delegate Sub AppendText(ByVal text As String, ByVal userColor As Color)
        Delegate Sub ShowAlertSafe(ByVal title As String, ByVal content As String)
        Public SafeAppendText As AppendText
        Public Alerter As ShowAlertSafe
        Public UserName As String
        Public UserColor As Color

        Public ForceClose As Boolean = False

        Private _encryptor As New Crypto3DS("876a6770f25e473bbaaaEcb3f7cd99f7")
        Private _shift As Boolean = False
        Private _receiver As New UdpClient
        Private _client As New UdpClient
        Private _listenerThread As Thread
        Private Const Port As Integer = 9653
        Private _endPoint As New IPEndPoint(IPAddress.Broadcast, 9653)

        Private codeList As New List(Of String)
        Private codeExpiration As New List(Of DateTime)

        'Private msgBroadcastName As String = "<bc>"
        Private _running As Boolean = True

        Private maxF As New Font("Segoe UI SemiLight", 10)
        Private minF As New Font("Segoe UI SemiLight", 14)

        Private _r As New Random
        Private _moving As Boolean = False
        Private _ppt As New Point
        Public Sub MaxUI()
            Me.Height = 352
            Me.Top = CInt(Screen.PrimaryScreen.WorkingArea.Height / 2 - Me.Height / 2)
            ToSend.Font = maxF
            ToSend.Multiline = True
            ToSend.Location = pnlBG.Location
            ToSend.Size = pnlBG.Size
            ToSend.Focus()
            Me.Invalidate()
        End Sub
        Public Sub MinUI()
            Me.Height = btnExpand.Bottom + 2
            Me.Top = CInt(Screen.PrimaryScreen.WorkingArea.Height / 2 - Me.Height / 2)
            ToSend.Font = minF
            ToSend.Multiline = False
            ToSend.Top = CInt(pnlBG.Bottom - pnlBG.Height / 2 - ToSend.Height / 2)
            ToSend.Left = pnlBG.Left + 10
            ToSend.Width = pnlBG.Width - 20

            ToSend.Focus()

            Me.Invalidate()
        End Sub

        Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click
            rtb.ScrollBars = RichTextBoxScrollBars.None
            If btnExpand.Text = "+" Then
                btnExpand.Text = "-"
                MaxUI()
            Else
                btnExpand.Text = "+"
                MinUI()
            End If
        End Sub
        Private Sub diagCOM_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.Icon = My.Resources.en 'set icon
            If My.Computer.Network.IsAvailable Then
                ForceClose = False
                Me.UserName = "Show Control"
                Me.UserColor = RandomRGBColor()
                MinUI()
                rtb.Rtf = EnComMsg
                rtb.SelectionLength = 0
                rtb.SelectionStart = rtb.Text.Length
                rtb.ScrollToCaret()
                InitializeSender()
                InitializeReceiver()
                SendText(UserName & " (" & My.Computer.Name & ") launched the Entity System", True)
            Else
                'MsgBox("We are sorry, but we are currently unable to open EnCOM due to network issues.", , "EnCOM Unreachable")
                Me.ForceClose = True
                Me.Close()
            End If
        End Sub
        Private Sub DiagCOM_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
            Me.Hide()
        End Sub
        Private Sub DiagCOM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If IsPresMode = False Or OpenFormsCount < 3 OrElse ForceClose Then
                SendText(UserName & " (" & My.Computer.Name & ") closed the Entity System", True)
                _running = False
                Alert.CheckExit()
                Try
                    _receiver.Close()
                    _client.Close()
                    _listenerThread.Abort()
                Catch ex As Exception
                End Try
            Else
                e.Cancel = True
                Me.Hide()
            End If

        End Sub
        Private Sub DiagCOM_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
            If e.KeyCode = Keys.Escape Then
                If Frm2Launcher.Visible Then
                    Frm2Launcher.TopBar.Panel1.Focus()
                ElseIf Frm5ShowUI.Visible Then
                    Frm5ShowUI.TopBar1.Panel1.Focus()
                Else
                    Frm3Viewer.TopBar1.Panel1.Focus()
                End If
                Me.Close()
            End If
        End Sub

        Private Sub DiagCOM_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub


        Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
            If Not String.IsNullOrEmpty(ToSend.Text) Then
                SendText(ToSend.Text)
            End If
            If btnExpand.Text = "+" And IsPresMode Then
                Me.Hide()
            End If
        End Sub
        Private Sub SendText(ByVal textToSend As String, Optional ByVal systemMsg As Boolean = False)
            If My.Computer.Network.IsAvailable Then
                Dim code As String = Guid.NewGuid().ToString().GetHashCode().ToString("x")
                Dim argb As Integer = UserColor.ToArgb
                Dim sendText As String
                If systemMsg Then
                    sendText = "<" & code & "|" & argb & ">" & textToSend.Trim
                Else
                    sendText = "<" & code & "|" & argb & ">" & UserName & " (" & My.Computer.Name & "): " & textToSend.Trim
                End If
                sendText = _encryptor.EncryptData(sendText)
                Dim data() As Byte = Encoding.UTF8.GetBytes(sendText.ToCharArray)
                ToSend.Text = ""
                ToSend.Focus()
                Try
                    'send many times to prevent packet loss
                    For i As Integer = 0 To 20
                        _client.Send(data, data.Length)
                    Next
                Catch ex As Exception
                    'MsgBox("Error, unable to send command." & vbNewLine & vbNewLine & ex.ToString)
                End Try
            End If
        End Sub
        Private Sub InitializeSender()
            Try
                SafeAppendText = New AppendText(AddressOf AppendRtbText)
                Alerter = New ShowAlertSafe(AddressOf showAlert)
                _client = New UdpClient("255.255.255.255", Port)
                _client.EnableBroadcast = True
            Catch ex As Exception
                MsgBox("Error, unable to setup sender client on port " & Port & "." & vbNewLine & vbNewLine & ex.ToString)
            End Try
        End Sub

        Private Sub InitializeReceiver()
            Try
                _receiver = New UdpClient(Port)
                _listenerThread = New Thread(New ThreadStart(AddressOf Listening))
                _listenerThread.Start()
                _running = True
            Catch ex As Exception
                End
            End Try
        End Sub
        Public Function TestSend() As Boolean
            Try
                InitializeReceiver()
                InitializeSender()
                Dim data() As Byte = Encoding.UTF8.GetBytes("TESTING".ToCharArray)
                'send many times to prevent packet loss
                For i As Integer = 0 To 5
                    _client.Send(data, data.Length)
                Next
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Private Sub Listening()
            While _running
                If My.Computer.Network.IsAvailable Then
                    Dim data() As Byte
                    data = _receiver.Receive(_endPoint)
                    Dim incomingMessage As String = Encoding.UTF8.GetString(data)
                    incomingMessage = _encryptor.DecryptData(incomingMessage)
                    If incomingMessage.Contains("<") And incomingMessage.Contains(">") Then
                        Dim code As String = incomingMessage.Remove(incomingMessage.IndexOf("|")).Remove(0, 1)
                        Dim argb As Integer = CInt(incomingMessage.Remove(incomingMessage.IndexOf(">")).Remove(0, incomingMessage.IndexOf("|") + 1))
                        Dim content As String = incomingMessage.Remove(0, incomingMessage.IndexOf(">") + 1)
                        If Not codeList.Contains(code) Then
                            If Not content = "keep_alive" Then
                                codeList.Add(code)
                                codeExpiration.Add(Now.AddSeconds(10)) 'expiration so the ids dont repeat
                                rtb.Invoke(Me.SafeAppendText, New Object() {content, Color.FromArgb(argb)})
                                If content.Contains(":") And content.Trim.StartsWith(UserName) = False Then
                                    Me.Invoke(Alerter, New Object() {content.Remove(content.IndexOf("(")).Trim & " Said:", _
                                                                     content.Remove(0, content.IndexOf(":") + 1)})
                                End If
                            End If
                        End If
                    Else
                        If incomingMessage <> "" And incomingMessage <> "keep_alive" Then rtb.Invoke(Me.SafeAppendText, New Object() {incomingMessage, UserColor})
                    End If
                Else
                    Me.ForceClose = True
                    'MsgBox("We are sorry, but we are currently unable to open EnCOM due to network issues." & vbCrLf & _
                    '       "when the network issue is resolved, we kindly ask you to click the" & vbCrLf & _
                    '       "EnCOM button on the top right of the screen again to retry.", , "EnCOM Unreachable")
                    Me.Close()
                End If
            End While
        End Sub
        Private Sub AppendRtbText(ByVal text As String, Optional ByVal userColor As Color = Nothing)
            If userColor = Nothing Then userColor = Color.WhiteSmoke
            If text.Contains(":") Then
                rtb.SelectionStart = rtb.Text.Length
                rtb.SelectionColor = userColor
                rtb.AppendText(text.Remove(text.IndexOf(":")))
                rtb.SelectionColor = Color.White
                rtb.AppendText(text.Remove(0, text.IndexOf(":")) & vbCrLf)
            Else
                rtb.SelectionStart = rtb.Text.Length
                rtb.AppendText(text & vbCrLf)
            End If
            rtb.SelectionStart = rtb.Text.Length
            rtb.ScrollToCaret()
            EnComMsg = rtb.Rtf
        End Sub
        Private Sub showAlert(title As String, content As String)
            Alert.Title = title
            Alert.Content = content
            Alert.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Alert.Width - 52, 52)
            Alert.Show()
            Alert.Refresh()
            Alert.ResetDisappearTime()
            ToSend.Focus()
        End Sub

        Private Sub ToSend_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ToSend.KeyPress
            If _shift = False Then
                If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                    btnSend.PerformClick()
                    e.Handled = True
                End If
            End If
        End Sub

        Private Sub ToSend_KeyDown(sender As Object, e As KeyEventArgs) Handles ToSend.KeyDown
            If e.Control Then
                If e.KeyCode = Keys.A Then
                    ToSend.SelectAll()
                End If
            ElseIf e.Shift Then
                _shift = True
            End If
        End Sub
        Private Sub ToSend_KeyUp(sender As Object, e As KeyEventArgs) Handles ToSend.KeyUp
            _shift = False
        End Sub
        Public Function RandomRGBColor() As Color
            Dim n As Integer = 79
            Return Color.FromArgb(255, _
                                  175 + _r.Next(0, n), _
                                  175 + CInt(Math.Ceiling(Rnd() * n)), _
                                  175 + CInt(Math.Ceiling(Rnd() * n)))
        End Function

        Private Sub pnlBG_Click(sender As Object, e As EventArgs) Handles pnlBG.Click
            ToSend.Focus()
        End Sub
    End Class
End Namespace