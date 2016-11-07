Namespace _1Dialogs.Loading
    Public Class FrmPrepShow : Inherits _0App.InitialSetup.IFmBase
        Public Property Title As String = "Preparing Your Show..."
        Public Property Description As String = "Locating Resources"
        Private Sub frmLoading_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            Dim strSize As SizeF = e.Graphics.MeasureString(Me.Title, New Font("Segoe UI SemiLight", 30))
            Dim ltrSize As SizeF = e.Graphics.MeasureString("i", New Font("Segoe UI SemiLight", 10))
            Using br As New SolidBrush(Color.White)
                e.Graphics.DrawString(Me.Title, New Font("Segoe UI SemiLight", 30), br _
                                      , CSng(e.ClipRectangle.Width / 2 - strSize.Width / 2), CSng(e.ClipRectangle.Height / 2 - strSize.Height / 2))
                Using brWS As New SolidBrush(Color.WhiteSmoke)
                    e.Graphics.DrawString(Description, New Font("Segoe UI SemiLight", 20), brWS _
                                          , CSng(e.ClipRectangle.Width / 2 - strSize.Width / 2 + ltrSize.Width / 2), _
                                          CSng(e.ClipRectangle.Height / 2 + strSize.Height / 2))
                End Using
                Using backBr As New SolidBrush(Color.FromArgb(129, 137, 153))
                    e.Graphics.FillRectangle(backBr, e.ClipRectangle.Width \ 2 - CLng(strSize.Width) \ 2 - 70, _
                                             e.ClipRectangle.Height \ 2 - 32, 64, 64)
                End Using
                e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                e.Graphics.DrawString("En", New Font("Segoe UI SemiLight", 30), br, e.ClipRectangle.Width \ 2 - CLng(strSize.Width) \ 2 - 67, _
                                      e.ClipRectangle.Height \ 2 - 28)
            End Using
        End Sub


        Private Sub FrmPrepShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.Icon = My.Resources.en 'set icon
        End Sub
    End Class
End Namespace