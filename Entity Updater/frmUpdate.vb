Imports System.Net

Public Class FrmUpdate
    Delegate Sub ChangeTextsSafe(ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)
    Delegate Sub DownloadCompleteSafe(ByVal cancelled As Boolean)
    Dim _whereToSave As String = Application.StartupPath
    Dim _toDownload As String = ""
    Dim _newVersion As String = ""
    Dim _manifestFile() As String
    Dim _downloadCount As Integer = 0
    Dim _reRun As Boolean = False
    Public Sub DownloadComplete(ByVal cancelled As Boolean)
        Me.btnCancel.Enabled = False
        If cancelled Then
            MsgBox("You have canceled the update. The patcher will now exit.", MsgBoxStyle.Information, "Update Cancelled")
            Me.Close()
        End If
        Me.pb.Value = 0
        Me.lbTSize.Text = "Total size: "
        Me.lbSpeed.Text = "Download speed: "
        Me.lbDlSize.Text = ""

        _downloadCount += 1
        If _downloadCount = _manifestFile.Length Then
            lbStep.Text = "Deleting Temporary Files..."
            lbFile.Text = ""
            For Each file As String In _manifestFile
                Dim fn As String = IO.Path.GetFileName(file.Trim).Replace("%20", " ")
                Dim tempFile As String = FileIO.SpecialDirectories.Temp & "\" & fn
                Dim actualFile As String = Application.StartupPath & "\" & fn
                FileIO.FileSystem.CopyFile(tempFile, actualFile, True)
                FileIO.FileSystem.DeleteFile(tempFile)
            Next
            If MsgBox("We have successfully updated the Entity System to version " & _newVersion & "!" & vbCrLf & _
                   "Launch Entity now?", _
                   MsgBoxStyle.Information Or MsgBoxStyle.MsgBoxSetForeground Or MsgBoxStyle.YesNo, "Update Successful") = _
               MsgBoxResult.Yes Then
                Process.Start(Application.StartupPath & "\Entity.exe")
            End If
            _reRun = False
            Me.Close()
        Else
            _toDownload = _manifestFile(_downloadCount).Trim.Replace("%20", " ")
            Dim filename As String = IO.Path.GetFileName(_toDownload)
            lbFile.Text = filename
            lbStep.Text = _downloadCount + 1 & " of " & _manifestFile.Length
            _whereToSave = FileIO.SpecialDirectories.Temp & "\" & filename
            _reRun = True
        End If
    End Sub

    Public Sub ChangeTexts(ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)

        Me.lbTSize.Text = "File Size: " & Math.Round((length / 1024), 2) & " KB"

        Me.lbDlSize.Text = "Downloaded " & Math.Round((position / 1024), 2) & " KB (" & Me.pb.Value & "%)"

        If speed = -1 Then
            Me.lbSpeed.Text = "Speed: calculating..."
        Else
            If speed < 750 Then
                Me.lbSpeed.Text = "Speed: " & speed & " B/s"
            ElseIf speed < 750000 Then
                Me.lbSpeed.Text = "Speed: " & Math.Round((speed / 1024), 1) & " KB/s"
            Else
                Me.lbSpeed.Text = "Speed: " & Math.Round((speed / 1048576), 1) & " MB/s"
            End If
        End If
        Me.pb.Value = percent
    End Sub
    Private Sub frmUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.Update

        Try
            If My.Application.CommandLineArgs.Count > 0 Then 'check if cmd args is not empty, so calling ...(0) will not cause an error
                If My.Application.CommandLineArgs(0).Trim = "-forceupdate" Then 'check if cmd args correct
                    If Not My.Computer.Network.IsAvailable Then
                        MsgBox("Your internet just broke! We cannot update Entity without an internet connection. Please try again later.", _
                       MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Aw Snap")
                        Application.Exit()
                    Else
                        Using wc As New System.Net.WebClient()
                            _newVersion = wc.DownloadString("http://update.uhillsec.com/ensys/version")
                            lbVer.Text = "Installing Patch " & _newVersion
                            _manifestFile = _
                                wc.DownloadString("http://update.uhillsec.com/ensys/manifest").Split(CChar(vbLf))
                        End Using
                        If _manifestFile.Length > 0 Then
                            _toDownload = _manifestFile(0).Trim.Replace("%20", " ")
                            Dim filename As String = IO.Path.GetFileName(_toDownload)
                            lbFile.Text = filename
                            lbStep.Text = "1 of " & _manifestFile.Length
                            _whereToSave = FileIO.SpecialDirectories.Temp & "\" & filename
                            bw.RunWorkerAsync()
                        Else
                            MsgBox("Patcher Error 1: the update manifest is corrupted or failed to download. If this persists, please contact the Entity Team.", _
                                    MsgBoxStyle.Exclamation, "Error")
                            Application.Exit()
                        End If
                    End If
                Else
                    Application.Exit() 'otherwise don't run
                End If
            Else
                Application.Exit() 'otherwise don't run
            End If
        Catch ex As Exception
            MsgBox("Patcher Error: An unknown error has occurred. Please send the following information to the Entity Team: " _
                   & vbCrLf & ex.Message, _
                            MsgBoxStyle.Exclamation, "Unknown Error")
            Application.Exit() ' on error quit
        End Try
    End Sub

    Private Sub logo_Paint(sender As Object, e As PaintEventArgs) Handles logo.Paint
        Using whiteBr As New SolidBrush(Color.White)
            Using clrBr As New SolidBrush(Color.FromArgb(129, 137, 153))
                Using sUI As New Font("Segoe UI SemiLight", CInt(e.ClipRectangle.Width / 5 * 2))
                    Using sF As New StringFormat
                        sF.Alignment = StringAlignment.Center
                        sF.LineAlignment = StringAlignment.Center
                        e.Graphics.FillRectangle(clrBr, 0, 0, e.ClipRectangle.Width, e.ClipRectangle.Height)
                        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
                        e.Graphics.DrawString("En", sUI, whiteBr, e.ClipRectangle, sF)
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub bw_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bw.DoWork
        'Creating the request and getting the response
        Dim theResponse As WebResponse
        Dim theRequest As WebRequest
        Try 'Checks if the file exist

            theRequest = WebRequest.Create(Me._toDownload)
            theResponse = theRequest.GetResponse
        Catch ex As Exception

            MessageBox.Show("An error occurred while downloading file. Possible causes:" & ControlChars.CrLf & _
                            "1) File doesn't exist" & ControlChars.CrLf & _
                            "2) Remote server error", "Error", _
            MessageBoxButtons.OK, MessageBoxIcon.Error)

            Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
            Me.Invoke(cancelDelegate, True)
            Exit Sub
        End Try
        Dim length As Long = theResponse.ContentLength 'Size of the response (in bytes)

        Dim safedelegate As New ChangeTextsSafe(AddressOf ChangeTexts)
        Me.Invoke(safedelegate, length, 0, 0, 0) 'Invoke the TreadsafeDelegate
        Dim writeStream As New IO.FileStream(Me._whereToSave, IO.FileMode.Create, IO.FileAccess.Write)
        'Replacement for Stream.Position (webResponse stream doesn't support seek)
        Dim nRead As Integer

        'To calculate the download speed
        Dim speedtimer As New Stopwatch
        Dim currentspeed As Double = -1
        Dim readings As Integer = 0

        Do
            If bw.CancellationPending Then 'If user aborts download
                Exit Do
            End If

            speedtimer.Start()

            Dim readBytes(4095) As Byte
            Dim bytesread As Integer = theResponse.GetResponseStream.Read(readBytes, 0, 4096)

            nRead += bytesread
            Dim percent As Short = CShort((nRead * 100) / length)

            Me.Invoke(safedelegate, length, nRead, percent, currentspeed)

            If bytesread = 0 Then Exit Do

            writeStream.Write(readBytes, 0, bytesread)

            speedtimer.Stop()

            readings += 1
            If readings >= 5 Then 'For increase precision, _
                ' the speed is calculated only every five cycles
                currentspeed = 20480 / (speedtimer.ElapsedMilliseconds / 1000)
                speedtimer.Reset()
                readings = 0
            End If
        Loop

        'Close the streams
        theResponse.GetResponseStream.Close()
        writeStream.Close()

        If Me.bw.CancellationPending Then

            IO.File.Delete(Me._whereToSave)

            Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)

            Me.Invoke(cancelDelegate, True)

            Exit Sub

        End If

        Dim completeDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)

        Me.Invoke(completeDelegate, False)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBox("Are you sure you want to cancel the update?", MsgBoxStyle.Exclamation Or MsgBoxStyle.YesNo, "Cancel Update") _
            = MsgBoxResult.Yes Then
            bw.CancelAsync()
        End If
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        If _reRun Then
            bw.RunWorkerAsync()
        End If
    End Sub
    Dim moving As Boolean = False
    Dim prevPt As New Point
    Private Sub lbTSize_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown, pb.MouseDown, logo.MouseDown, _
        lbVer.MouseDown, lbTSize.MouseDown, lbTitle.MouseDown, lbStep.MouseDown, lbSpeed.MouseDown, lbFile.MouseDown, lbDlSize.MouseDown
        moving = True
        prevPt = e.Location
    End Sub

    Private Sub lbTSize_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove, pb.MouseMove, logo.MouseMove, _
        lbVer.MouseMove, lbTSize.MouseMove, lbTitle.MouseMove, lbStep.MouseMove, lbSpeed.MouseMove, lbFile.MouseMove, lbDlSize.MouseMove
        If moving Then
            Me.Location = New Point(Me.Left + e.X - prevPt.X, Me.Top + e.Y - prevPt.Y)
        End If
    End Sub

    Private Sub lbTSize_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp, pb.MouseUp, logo.MouseUp, _
        lbVer.MouseUp, lbTSize.MouseUp, lbTitle.MouseUp, lbStep.MouseUp, lbSpeed.MouseUp, lbFile.MouseUp, lbDlSize.MouseUp
        moving = False
    End Sub

    Private Sub frmUpdate_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Using pn As New Pen(Color.Gainsboro, 2)
            e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
        End Using
    End Sub
End Class
