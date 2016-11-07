Namespace _1Dialogs.Loading
    Public Class FrmProcessing
        Public Audio As Boolean = False
        Private Sub frmProcessing_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 3, Me.Height - 3)
            End Using
            If Audio Then
                e.Graphics.DrawString("Audio Processing Subsystem - Entity System", New Font("Segoe UI SemiLight", 11, FontStyle.Bold), Brushes.White _
                                      , 10, 10)
                e.Graphics.DrawString("Processing your audio. Please wait..." & vbCrLf & _
                                      "This may take a while for larger files. DO NOT close the app.", New Font("Segoe UI SemiLight", 11), Brushes.White _
                                      , 10, 35)
                Me.BackColor = Color.FromArgb(170,170,170)
            Else
                e.Graphics.DrawString("Image Processing Subsystem - Entity System", New Font("Segoe UI SemiLight", 11, FontStyle.Bold), Brushes.White _
                                      , 10, 10)
                e.Graphics.DrawString("Processing your image. Please wait..." & vbCrLf & _
                                      "This may take a while for larger pictures. DO NOT close the app.", New Font("Segoe UI SemiLight", 11), Brushes.White _
                                      , 10, 35)
                Me.BackColor = Color.fromArgb(120, 120, 120)
            End If
        End Sub

        Public fc As Boolean = False
        Private Sub frmProc_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
            If Not fc Then
                e.Cancel = True
                fc = False
            End If
        End Sub

        Private Sub FrmProcessing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Icon = My.Resources.en 'set icon
        End Sub
    End Class
End Namespace