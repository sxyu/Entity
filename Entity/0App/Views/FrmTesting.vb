Public Class FrmTesting

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dmxEngine.Set_Channel(0, CInt(n1.Value), CByte(CShort(n2.Value)))
        MsgBox("0 " & dmxEngine.ErrorString(0) & vbCrLf & "1 " & dmxEngine.ErrorString(1) & vbCrLf & "2 " & dmxEngine.ErrorString(2) & vbCrLf & "3 " & dmxEngine.ErrorString(3))
    End Sub
End Class