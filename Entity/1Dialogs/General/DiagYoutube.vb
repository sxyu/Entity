Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.FileIO

Namespace _1Dialogs.General

    Public Class DiagYoutube
        ''some unmanaged code to prevent the webbrowser from leaking memory
        ''(such a horrible control otherwise, goes up to 1.5gb memory usage, which is never freed!!!)
        <
            DllImport _
                ("KERNEL32.DLL", EntryPoint:="SetProcessWorkingSetSize", SetLastError:=True,
                 CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function SetProcessWorkingSetSize(pProcess As IntPtr, dwMinimumWorkingSetSize As Integer,
                                                        dwMaximumWorkingSetSize As Integer) As Boolean
        End Function

        <
            DllImport _
                ("KERNEL32.DLL", EntryPoint:="GetCurrentProcess", SetLastError:=True,
                 CallingConvention:=CallingConvention.StdCall)>
        Friend Shared Function GetCurrentProcess() As IntPtr
        End Function
        'to free up memory:
        'Dim pHandle As IntPtr = GetCurrentProcess()
        'SetProcessWorkingSetSize(pHandle, -1, -1)

        Public Result As String = ""
        Dim ok As Boolean = False

        Dim cur_doc As String
        Dim orig_doc As String
        Dim isProcessing As Boolean = False
        Private blockAds As Boolean = True

        Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
            wb.Navigate("about:blank")
            Me.DialogResult = DialogResult.Cancel
        End Sub

        Delegate Sub DownloadCompleteSafe(ByVal cancelled As Boolean)

        Delegate Sub ChangeTextsSafe _
            (ByVal length As Long, ByVal position As Integer, ByVal percent As Integer, ByVal speed As Double)

        Dim _moving As Boolean = False
        Dim _ppt As New Point

        Public Sub DownloadComplete(ByVal cancelled As Boolean)
            If Not cancelled Then
                Dim pHandle As IntPtr = GetCurrentProcess()
                SetProcessWorkingSetSize(pHandle, -1, -1)
                Me.Result = fileName
                Me.DialogResult = DialogResult.OK
                ok = True
                wb.Navigate("about:blank")
            Else
                Dim pHandle As IntPtr = GetCurrentProcess()
                SetProcessWorkingSetSize(pHandle, -1, -1)
                MsgBox("You have cancelled the conversion.", MsgBoxStyle.Exclamation, "Conversion Cancelled")
                Me.DialogResult = DialogResult.Cancel
                wb.Navigate("about:blank")
            End If
        End Sub

        Private Sub diagImageView_MouseDown(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseDown, lbTitle.MouseDown,
                    backPnl.MouseDown, progress.MouseDown, lbWarning.MouseDown, pnl.MouseDown
            _moving = True
            _ppt = e.Location
        End Sub

        Private Sub diagImageView_MouseMove(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseMove, lbTitle.MouseMove,
                    backPnl.MouseMove, progress.MouseMove, lbWarning.MouseDown, pnl.MouseDown
            If _moving Then
                Me.Location = New Point(Me.Left + e.X - _ppt.X, Me.Top + e.Y - _ppt.Y)
            End If
        End Sub

        Private Sub diagImageView_MouseUp(sender As Object, e As MouseEventArgs) _
            Handles MyBase.MouseUp, lbTitle.MouseUp, backPnl.MouseUp,
                    progress.MouseUp, lbWarning.MouseDown, pnl.MouseDown
            _moving = False
        End Sub

        Private Sub wb_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles wb.Navigated
            Dim pHandle As IntPtr = GetCurrentProcess()
            SetProcessWorkingSetSize(pHandle, -1, -1)
            If wb.Url.ToString.Contains("http://www.youtube-mp3.org") Then
                Try
                    If Not isProcessing Then
                        progress.Value = 15
                        wb.Document.GetElementById("youtube-url").SetAttribute("value", tbURL.Text)
                        wb.Document.GetElementById("submit").InvokeMember("click")
                        cur_doc = wb.DocumentText
                        isProcessing = True
                        msgCheck.Start()
                        progress.Value = 30
                    End If
                Catch ex As Exception
                    Debug.WriteLine(ex.Message)
                End Try
            Else
                If blockAds Then
                    Dim lst As HtmlElementCollection = wb.Document.GetElementsByTagName("iframe")
                    For i As Integer = 0 To lst.Count - 1
                        lst(i).Style = "display:none"
                    Next
                    lst = wb.Document.GetElementsByTagName("div")
                    For i As Integer = 0 To lst.Count - 1
                        Dim id As String = lst(i).Id
                        If String.IsNullOrEmpty(id) Then Continue For
                        If id = "header" Or id.StartsWith("ad") Or id.StartsWith("goog_") Then
                            lst(i).Style = "display:none"
                        ElseIf id = "results" Then
                            lst(i).Children(0).Style += "display:none"
                        ElseIf id = "movie_player" Then
                            Dim playerFrame As HtmlElement = lst(i).Children(0)
                            playerFrame.Children(0).SetAttribute("src", "")
                            playerFrame.Children(playerFrame.Children.Count - 1).Style = "display:none"
                        End If
                    Next
                End If
                tbURL.Text = wb.Url.ToString
            End If
            If tbURL.Text = "about:blank" Then
                If ok Then
                    Me.DialogResult = DialogResult.OK
                Else
                    Me.DialogResult = DialogResult.Cancel
                End If
                Me.Close()
                Exit Sub
            End If

        End Sub

        Private Sub tbURL_KeyDown(sender As Object, e As KeyEventArgs) Handles tbURL.KeyDown
            If e.KeyCode = Keys.Enter Then
                Try
                    If tbURL.Text.Contains("youtube.com") Then
                        wb.Navigate(tbURL.Text)
                    End If
                Catch ex As Exception
                End Try
            End If
        End Sub

        Private Sub tbURL_TextChanged(sender As Object, e As EventArgs) Handles tbURL.TextChanged
            If tbURL.Text.Replace("https://", "http://").StartsWith("http://www.youtube.com/watch?v=") Then
                btnDownload.Enabled = True
                lbWarning.Hide()
            Else
                btnDownload.Enabled = False
                If tbURL.Text.Replace("https://", "http://") <> "http://www.youtube.com/" Then
                    lbWarning.Show()
                End If
            End If
        End Sub

        Private Sub btnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
            If btnDownload.Text = "Cancel" Then
                Try
                    bw.CancelAsync()
                    If File.Exists(SpecialDirectories.Temp & vbCrLf & fileName & ".mp3") Then
                        File.Delete(SpecialDirectories.Temp & vbCrLf & fileName & ".mp3")
                    End If
                Catch ex As Exception
                End Try
                DownloadComplete(True)
            Else
                Dim url As String = "http://youtube-mp3.org"
                ytbUrl = tbURL.Text
                progress.Show()
                orig_doc = wb.DocumentText
                btnDownload.Text = "Preparing"
                btnDownload.Enabled = False
                pnl.Show()
                wb.Navigate(url)
                progress.Value = 10
            End If
        End Sub

        Private Sub processVid(sender As Object, e As WebBrowserNavigatedEventArgs)
            'FileIO.FileSystem.WriteAllText(FileIO.SpecialDirectories.Desktop & "\1.htm", bgWb.DocumentText, False)
        End Sub

        Dim fileToDl As String = ""
        Dim fileName As String = "myFile"

        Private Sub bw_dowork(ByVal sender As Object,
                              ByVal e As DoWorkEventArgs) Handles bw.DoWork
            Try
                'Creating the request and getting the response
                Dim theResponse As HttpWebResponse
                Dim theRequest As HttpWebRequest
                Try 'Checks if the file exist

                    theRequest = CType(HttpWebRequest.Create(fileToDl), HttpWebRequest)
                    theResponse = CType(theRequest.GetResponse, HttpWebResponse)
                Catch ex As Exception

                    MessageBox.Show("An error occurred while downloading file. Possible causes:" & ControlChars.CrLf &
                                    "1) File doesn't exist" & ControlChars.CrLf & "2) Remote server error", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)

                    Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)

                    Me.Invoke(cancelDelegate, True)

                    Exit Sub
                End Try
                Dim length As Long = theResponse.ContentLength 'Size of the response (in bytes)

                Dim writeStream As New FileStream(SpecialDirectories.Temp & "\" & fileName & ".mp3", FileMode.Create)

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

                    bw.ReportProgress(percent)

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

                    File.Delete(SpecialDirectories.Temp & vbCrLf & fileName & ".mp3")

                    Dim cancelDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)

                    Me.Invoke(cancelDelegate, True)

                    Exit Sub

                End If
                Dim completeDelegate As New DownloadCompleteSafe(AddressOf DownloadComplete)
                Me.Invoke(completeDelegate, False)
            Catch ex As Exception
                If File.Exists(SpecialDirectories.Temp & vbCrLf & fileName & ".mp3") Then
                    File.Delete(SpecialDirectories.Temp & vbCrLf & fileName & ".mp3")
                End If
                MsgBox("Oops... an error occurred while attempting to download this file:" & vbCrLf & ex.ToString,
                                  MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground, "Download Failed")
            End Try
        End Sub


        Private Sub Wb_NewWindow(sender As Object, e As CancelEventArgs) Handles wb.NewWindow
            e.Cancel = True
        End Sub

        Private Sub bw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bw.ProgressChanged
            progress.Value = e.ProgressPercentage
        End Sub


        Private Sub diagYoutube_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            wb.ScriptErrorsSuppressed = True
            btnClose.DialogResult = DialogResult.None
        End Sub

        Public ytbUrl As String = ""


        Private Sub msgCheck_Tick(sender As Object, e As EventArgs) Handles msgCheck.Tick
            If cur_doc <> "" Then
                Dim errEle As HtmlElement = wb.Document.GetElementById("error_text")
                If errEle IsNot Nothing Then
                    If Not errEle.InnerHtml Is Nothing Then
                        msgCheck.Stop()
                        If orig_doc.ToLower.Contains("nyan") And orig_doc.ToLower.Contains("cat") Then
                            MsgBox(
                                "''System.NyanReferenceException'' occured in youtubeconverter.dll" & vbCrLf & vbCrLf &
                                "This error is usually caused by downloading videos" & vbCrLf &
                                "containing the words 'nyan' and 'cat'." &
                                vbCrLf & "Contact cat control immediately to correct the problem.", MsgBoxStyle.Critical _
                                                                      Or MsgBoxStyle.ApplicationModal Or
                                                                      MsgBoxStyle.MsgBoxSetForeground, "Catastrophic Error")
                        Else
                            MsgBox(
                                "Sorry, but this video cannot be converted." & vbCrLf &
                                "Usually this problem is caused by the video being too long (>20min)" _
                                , MsgBoxStyle.Exclamation Or MsgBoxStyle.ApplicationModal Or
                                  MsgBoxStyle.MsgBoxSetForeground, "Cannot Convert")
                        End If
                        Me.DialogResult = DialogResult.Cancel
                        wb.Navigate("about:blank")
                    End If
                End If

                For Each ele As HtmlElement In wb.Document.GetElementById("dl_link").Document.Links
                    If ele.GetAttribute("href").Contains("video_id=") And ele.Style = "" Then
                        Try
                            ' Download it
                            fileName = wb.Document.GetElementById("title").InnerHtml
                            fileName = fileName.Remove(0, fileName.ToLower.IndexOf("</b>") + 4).Trim
                            fileName = _3Modules.General.CPath(fileName)
                            fileToDl = ele.GetAttribute("href")
                            If Not bw.IsBusy Then
                                msgCheck.Stop()
                                progress.Value = 70
                                btnDownload.Text = "Cancel"
                                btnDownload.Enabled = True
                                progress.Value = 100
                                bw.RunWorkerAsync()
                                progress.ProgressText = "Downloading"
                                progress.Value = 0
                            End If
                            Exit For
                        Catch ex As Exception
                            Continue For
                        End Try
                    End If
                Next

            End If
        End Sub

        Private Sub diagYoutube_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
            'we have to make sure that the webbrowser has loaded about:blank before the window is closed
            'because i find that if it is otherwise it will start opening IE after being disposed for some reason
            If Not wb.Url.ToString = "about:blank" Then
                e.Cancel = True
                wb.Navigate("about:blank")
            End If
        End Sub


        'Private Sub diagYoutube_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        '    Using pn As New Pen(Color.Gainsboro, 2)
        '        e.Graphics.DrawRectangle(pn, 1, 1, Me.Width - 2, Me.Height - 2)
        '    End Using
        'End Sub
        Private Sub btnAd_Click(sender As Object, e As EventArgs) Handles btnAd.Click
            blockAds = Not blockAds
            If blockAds Then
                btnAd.BackColor = Color.DimGray
            Else
                btnAd.BackColor = Color.FromArgb(230, 80, 40)
            End If
        End Sub

        Private Sub lbTitle_Click(sender As Object, e As EventArgs) Handles lbTitle.Click
            If Not wb.Url.ToString().Contains("youtube-mp3.org") Then
                wb.GoBack()
            End If
        End Sub
    End Class
End Namespace