Namespace _1Dialogs.Loading
    Public Class FrmWait
        Public Property Caption As String = "Please Wait..."
        Dim strForm As New StringFormat()
        Dim strFormCent As New StringFormat()
        Dim sui As New Font("Segoe UI SemiLight", 14)
        Dim suiL As New Font("Segoe UI SemiLight", 60)
        Dim whiteBr As New SolidBrush(Color.White)
        Dim ang As Integer = 0
        Public Sub New(ByVal caption As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.Caption = caption
        End Sub
        Private Sub frmWait_Load(sender As Object, e As EventArgs) Handles Me.Load
            Me.Icon = My.Resources.en 'set icon
            strForm.Alignment = StringAlignment.Center
            strForm.LineAlignment = StringAlignment.Far
            strFormCent.Alignment = StringAlignment.Center
            strFormCent.LineAlignment = StringAlignment.Center
        End Sub

        Private Sub frmWait_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
            Dim paintRect As New Rectangle(CInt(e.ClipRectangle.Width / 2 - 100), CInt(e.ClipRectangle.Height / 2 - 100), 200, 200)
            Using br As New Drawing2D.LinearGradientBrush(paintRect, Color.fromArgb(80, 80, 80), Color.fromArgb(100, 100, 100), 90)
                e.Graphics.FillEllipse(br, paintRect)
            End Using
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
            e.Graphics.DrawString("En", suiL, whiteBr _
                                  , e.ClipRectangle, strFormCent)
            e.Graphics.DrawString(Caption, sui, whiteBr _
                                  , e.ClipRectangle, strForm)
        End Sub

        Public fc As Boolean = False
        Private Sub frmProc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If Not fc Then
                e.Cancel = True
                fc = False
            End If
        End Sub

    End Class
End Namespace