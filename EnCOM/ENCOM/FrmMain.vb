Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports System.Net
Imports System.Text
Public Class frmMain

    Delegate Sub AppendText(ByVal text As String, ByVal userColor As Color)
    Delegate Sub ShowAlertSafe(ByVal title As String, ByVal content As String)
    Public safeAppendText As AppendText
    Public alerter As ShowAlertSafe
    Public userName As String
    Public userColor As Color

    Private encryptor As New Crypto3DS("876a6770f25e473bbaaaEcb3f7cd99f7")
    Private shift As Boolean = False
    Private Receiver As New UdpClient
    Private Client As New UdpClient
    Private ListenerThread As Thread
    Private port As Integer = 9653
    Private EndPoint As New IPEndPoint(IPAddress.Broadcast, 9653)

    Private codeList As New List(Of String)
    Private codeExpiration As New List(Of DateTime)

    'Private MsgBroadcastName As String = "<bc>"
    Private Running As Boolean = True
    Private Sub toSend_KeyDown(sender As Object, e As KeyEventArgs) Handles toSend.KeyDown
        If e.Shift Then
            shift = True
        End If
        If e.Control Then
            If e.KeyCode = Keys.A Then
                toSend.SelectAll()
            End If
        End If
    End Sub
    Private Sub toSend_KeyPress(sender As Object, e As KeyPressEventArgs) Handles toSend.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            If shift Then
                shift = False
            Else
                btnSend.PerformClick()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub toSend_KeyUp(sender As Object, e As KeyEventArgs) Handles toSend.KeyUp
        shift = False
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sendText(userName & " (" & My.Computer.Name & ") left the EnCOM chat", True)
        Running = False
        Alert.CheckExit()
        Try
            Receiver.Close()
            Client.Close()
            ListenerThread.Abort()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeSender()
        InitializeReceiver()
        Me.Icon = My.Resources.People2
        sendText(userName & " (" & My.Computer.Name & ") joined the EnCOM chat", True)
    End Sub
    Private Sub Listening()
        While Running
            Dim data() As Byte
            data = Receiver.Receive(EndPoint)
            Dim incomingMessage As String = Encoding.UTF8.GetString(data)
            incomingMessage = encryptor.DecryptData(incomingMessage)
            If incomingMessage.Contains("<") And incomingMessage.Contains(">") Then
                Dim code As String = incomingMessage.Remove(incomingMessage.IndexOf("|")).Remove(0, 1)
                Dim argb As Integer = CInt(incomingMessage.Remove(incomingMessage.IndexOf(">")).Remove(0, incomingMessage.IndexOf("|") + 1))
                Dim content As String = incomingMessage.Remove(0, incomingMessage.IndexOf(">") + 1)
                If Not codeList.Contains(code) Then
                    If Not content = "keep_alive" Then
                        codeList.Add(code)
                        codeExpiration.Add(Now.AddSeconds(10)) 'expiration so the ids dont repeat
                        rtb.Invoke(Me.safeAppendText, New Object() {content, Color.FromArgb(argb)})
                        If content.Contains(":") And content.Trim.StartsWith(userName) = False Then
                            Me.Invoke(alerter, New Object() {content.Remove(content.IndexOf("(")).Trim & " Said:", _
                                                             content.Remove(0, content.IndexOf(":") + 1)})
                        End If
                    End If
                End If
            Else
                If incomingMessage <> "" And incomingMessage <> "keep_alive" Then rtb.Invoke(Me.safeAppendText, New Object() {incomingMessage, userColor})
            End If
        End While
    End Sub
    Private Sub showAlert(title As String, content As String)
        Alert.Title = title
        Alert.Content = content
        Alert.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Alert.Width - 50, 50)
        Alert.Show()
        Alert.Refresh()
        Alert.ResetDisappearTime()
        toSend.Focus()
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
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If Not String.IsNullOrEmpty(toSend.Text) Then
            sendText(toSend.Text)
        End If
    End Sub
    Private Sub sendText(ByVal textToSend As String, Optional ByVal systemMsg As Boolean = False)
        Dim code As String = Guid.NewGuid().ToString().GetHashCode().ToString("x")
        Dim argb As Integer = userColor.ToArgb
        Dim sendText As String
        If systemMsg Then
            sendText = "<" & code & "|" & argb & ">" & textToSend.Trim
        Else
            sendText = "<" & code & "|" & argb & ">" & userName & " (" & My.Computer.Name & "): " & textToSend.Trim
        End If
        sendText = encryptor.EncryptData(sendText)
        Dim data() As Byte = Encoding.UTF8.GetBytes(sendText.ToCharArray)
        toSend.Text = ""
        toSend.Focus()
        Try
            'send many times to prevent packet loss
            For i As Integer = 0 To 20
                Client.Send(data, data.Length)
            Next
        Catch ex As Exception
            MsgBox("Error, unable to send command." & vbNewLine & vbNewLine & ex.ToString)
            End
        End Try
    End Sub
    Private Sub InitializeSender()
        Try
            safeAppendText = New AppendText(AddressOf AppendRtbText)
            alerter = New ShowAlertSafe(AddressOf showAlert)
            Client = New UdpClient("255.255.255.255", port)
            Client.EnableBroadcast = True
        Catch ex As Exception
            MsgBox("Error, unable to setup sender client on port " & port & "." & vbNewLine & vbNewLine & ex.ToString)
        End Try
    End Sub

    Private Sub InitializeReceiver()
        Try
            Receiver = New UdpClient(port)
            ListenerThread = New Thread(New ThreadStart(AddressOf Listening))
            ListenerThread.Start()
            Running = True
        Catch ex As Exception
            MsgBox("Error, unable to setup receiver on port " & port & "." & vbNewLine & vbNewLine & _
                   "Quit any running instances of Entity or EnCOM before opening another." & vbCrLf & _
                   "Tip: Check your task manager to find any hidden Entity/EnCOM processes")
            End
        End Try
    End Sub

    Private Sub toSend_TextChanged(sender As Object, e As EventArgs) Handles toSend.TextChanged
        If String.IsNullOrEmpty(toSend.Text.Trim) Then
            btnSend.Enabled = False
        Else
            btnSend.Enabled = True
        End If

    End Sub
    Private Sub keepAlive()
        Dim data() As Byte = Encoding.UTF8.GetBytes("keep_alive".ToCharArray)
        Try
            Client.Send(data, data.Length)
            Client.Send(data, data.Length)
        Catch
        End Try
    End Sub
    Private Sub timerCodeExpire_Tick(sender As Object, e As EventArgs) Handles timerCodeExpire.Tick
        keepAlive()
        For i As Integer = 0 To codeExpiration.Count - 1
            If i > codeExpiration.Count - 1 Then Exit For
            If codeExpiration(i) < Now Then
                If i > codeExpiration.Count - 1 Then Exit For
                codeExpiration.Remove(codeExpiration(i))
                codeList.Remove(codeList(i))
            End If
        Next
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        frmUser.Show()
        Me.Close()
    End Sub

    Private Sub timerKeepAlive_Tick(sender As Object, e As EventArgs)

    End Sub
End Class
