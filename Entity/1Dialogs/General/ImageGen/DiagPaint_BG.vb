Imports Entity._3Modules
Namespace _1Dialogs.General.ImageGen

    Public Class DiagPaintBg
        Private _parent As DiagPaint
        Dim _moving As Boolean = False
        Dim _ppt As New Point
        Private Sub diag_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, lbTitle.MouseDown
            _moving = True
            _ppt = e.Location
        End Sub

        Private Sub diag_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, lbTitle.MouseMove
            If _moving Then
                Me.Location = New Point(Me.Left + e.X - _ppt.X, Me.Top + e.Y - _ppt.Y)
            End If
        End Sub

        Private Sub diag_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, lbTitle.MouseUp
            _moving = False
        End Sub
        Public Sub New(parent As DiagPaint)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me._parent = parent
        End Sub
        Private Sub diagPaint_BG_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Select Case _parent.BgpMode
                Case DiagPaint.BackMode.Color
                    rbSolid.Checked = True
                Case DiagPaint.BackMode.Gradient
                    rbGrad.Checked = True
                Case DiagPaint.BackMode.Image
                    rbImage.Checked = True
            End Select
            cbGradType.SelectedIndex = _parent.BgpGradMode
            btnSolidColor.BackColor = _parent.BgpColor1
            btnSolidColor.ForeColor = GetInverseColor(_parent.BgpColor1)
            btnGradStart.BackColor = _parent.BgpColor1
            btnGradStart.ForeColor = GetInverseColor(_parent.BgpColor1)
            btnGradEnd.BackColor = _parent.BgpColor2
            btnGradEnd.ForeColor = GetInverseColor(_parent.BgpColor2)
        End Sub
        Private Function GetInverseColor(ByVal color As Color) As Color
            Return color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B)
        End Function
        Private Sub rbSolid_CheckedChanged(sender As Object, e As EventArgs) Handles rbSolid.CheckedChanged
            My.Settings.favBGMode = 0
            My.Settings.Save()
            If _parent IsNot Nothing Then
                _parent.BgpMode = DiagPaint.BackMode.Color
                _parent.pb.Invalidate()
            End If
            btnSolidColor.Enabled = True
            pnlGrad.Enabled = False
            btnCustomBack.Enabled = False
        End Sub

        Private Sub rbGrad_CheckedChanged(sender As Object, e As EventArgs) Handles rbGrad.CheckedChanged
            My.Settings.favBGMode = 1
            My.Settings.Save()
            If _parent IsNot Nothing Then
                _parent.BgpMode = DiagPaint.BackMode.Gradient
                _parent.pb.Invalidate()
            End If
            btnSolidColor.Enabled = False
            pnlGrad.Enabled = True
            btnCustomBack.Enabled = False
        End Sub

        Private Sub rbImage_CheckedChanged(sender As Object, e As EventArgs) Handles rbImage.CheckedChanged
            My.Settings.favBGMode = 0
            My.Settings.Save()
            If _parent IsNot Nothing Then
                If String.IsNullOrEmpty(_parent.BgpImage) = False Then
                    _parent.BgpMode = DiagPaint.BackMode.Image
                    _parent.pb.Invalidate()
                End If
            End If
            btnSolidColor.Enabled = False
            pnlGrad.Enabled = False
            btnCustomBack.Enabled = True
        End Sub

        Private Sub btnGradSw_Click(sender As Object, e As EventArgs) Handles btnGradSw.Click
            Dim temp As Color = _parent.BgpColor1
            _parent.BgpColor1 = _parent.BgpColor2
            _parent.BgpColor2 = temp
            btnGradStart.BackColor = _parent.BgpColor1
            btnGradStart.ForeColor = GetInverseColor(_parent.BgpColor1)
            btnGradEnd.BackColor = _parent.BgpColor2
            btnGradEnd.ForeColor = GetInverseColor(_parent.BgpColor2)
            _parent.pb.Invalidate()
            My.Settings.favBGColor1 = _parent.BgpColor1
            My.Settings.favBGColor2 = _parent.BgpColor2
            My.Settings.Save()
        End Sub

        Private Sub btnSolidColor_Click(sender As Object, e As EventArgs) Handles btnSolidColor.Click
            Using diag As New ColorDialog
                diag.Color = _parent.BgpColor1
                If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                    _parent.BgpColor1 = diag.Color
                    btnSolidColor.BackColor = _parent.BgpColor1
                    btnSolidColor.FlatAppearance.MouseDownBackColor = _parent.BgpColor1
                    btnSolidColor.FlatAppearance.MouseOverBackColor = _parent.BgpColor1

                    btnGradStart.BackColor = _parent.BgpColor1
                    btnGradStart.FlatAppearance.MouseDownBackColor = _parent.BgpColor1
                    btnGradStart.FlatAppearance.MouseOverBackColor = _parent.BgpColor1

                    btnSolidColor.ForeColor = GetInverseColor(_parent.BgpColor1)
                    _parent.pb.Invalidate()
                    My.Settings.favBGColor1 = _parent.BgpColor1
                    My.Settings.Save()
                End If
            End Using
        End Sub

        Private Sub btnGradStart_Click(sender As Object, e As EventArgs) Handles btnGradStart.Click
            Using diag As New ColorDialog
                diag.Color = _parent.BgpColor1
                If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                    _parent.BgpColor1 = diag.Color
                    btnGradStart.BackColor = _parent.BgpColor1
                    btnGradStart.FlatAppearance.MouseDownBackColor = _parent.BgpColor1
                    btnGradStart.FlatAppearance.MouseOverBackColor = _parent.BgpColor1

                    btnSolidColor.BackColor = _parent.BgpColor1
                    btnSolidColor.FlatAppearance.MouseDownBackColor = _parent.BgpColor1
                    btnSolidColor.FlatAppearance.MouseOverBackColor = _parent.BgpColor1
                    btnGradStart.ForeColor = GetInverseColor(_parent.BgpColor1)
                    _parent.pb.Invalidate()
                    My.Settings.favBGColor1 = _parent.BgpColor1
                    My.Settings.Save()
                End If
            End Using
        End Sub

        Private Sub btnGradEnd_Click(sender As Object, e As EventArgs) Handles btnGradEnd.Click
            Using diag As New ColorDialog
                diag.Color = _parent.BgpColor2
                If diag.ShowDialog = Windows.Forms.DialogResult.OK Then
                    _parent.BgpColor2 = diag.Color
                    btnGradEnd.BackColor = _parent.BgpColor2
                    btnGradEnd.FlatAppearance.MouseDownBackColor = _parent.BgpColor2
                    btnGradEnd.FlatAppearance.MouseOverBackColor = _parent.BgpColor2
                    btnGradEnd.ForeColor = GetInverseColor(_parent.BgpColor2)
                    _parent.pb.Invalidate()
                    My.Settings.favBGColor2 = _parent.BgpColor2
                    My.Settings.Save()
                End If
            End Using
        End Sub

        Private Sub cbGradType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGradType.SelectedIndexChanged
            If cbGradType.SelectedItem IsNot Nothing Then
                My.Settings.favBGGradMode = cbGradType.SelectedIndex
                My.Settings.Save()
                _parent.BgpGradMode = CType(cbGradType.SelectedIndex, DiagPaint.GradientType)
                _parent.pb.Invalidate()
            End If
        End Sub

        Private Sub btnCustomBack_Click(sender As Object, e As EventArgs) Handles btnCustomBack.Click
            Using diag As New OpenFileDialog
                With diag
                    .Title = "Choose Image File"
                    .Filter = ImageFilter
                    .Multiselect = False
                    If .ShowDialog = Windows.Forms.DialogResult.OK Then
                        _parent.BgpImage = .FileName
                        _parent.BgpMode = DiagPaint.BackMode.Image
                        _parent.pb.Invalidate()
                    End If
                End With
            End Using
        End Sub

        Private Sub diagPaint_BG_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
            Using pn As New Pen(Color.Gainsboro, 2)
                e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
            End Using
        End Sub

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub
    End Class
End Namespace