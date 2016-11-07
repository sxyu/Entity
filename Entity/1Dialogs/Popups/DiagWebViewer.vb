Imports System.Reflection

Namespace _1Dialogs.Popups

    Public Class DiagWebViewer
        Public Property TitleX As String = "Entity Web Viewer"
        Public Property Content As String = ""

        Private _navigated As Integer = 0
        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub
        Dim moving As Boolean = False
        Dim ppt As New Point
        Public Sub New(ByVal title As String, ByVal content As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.TitleX = title
            Me.Content = content
        End Sub

        Private Sub diagImageView_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.ResizeRedraw = True
            Me.Text = Me.TitleX
            title.Text = Me.TitleX
            Me.Icon = My.Resources.en 'set icon
            wbContent.Navigate("about:blank")
        End Sub
        Private Sub diagImageView_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, title.MouseDown
            moving = True
            ppt = e.Location
        End Sub

        Private Sub diagImageView_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, title.MouseMove
            If moving Then
                Me.Location = New Point(Me.Left + e.X - ppt.X, Me.Top + e.Y - ppt.Y)
            End If
        End Sub

        Private Sub diagImageView_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, title.MouseUp
            moving = False
        End Sub

        Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub wbContent_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles wbContent.DocumentCompleted
            If _navigated = 1 Then
                Dim doc As HtmlDocument = wbContent.Document.OpenNew(True)
                doc.Write(Me.Content)
            End If
        End Sub

        Private Sub wbContent_Navigating(sender As Object, e As WebBrowserNavigatingEventArgs) Handles wbContent.Navigating
            If _navigated >= 2 Then
                e.Cancel = True
            ElseIf _navigated = 1 Then
                _navigated = 2
            ElseIf _navigated = 0 Then
                _navigated = 1
            End If
        End Sub

        Private Sub diagWebViewer_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub
    End Class
End Namespace