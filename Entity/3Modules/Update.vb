Imports Entity._6Misc
Imports Entity._1Dialogs.Loading
Imports System.Net
Imports System.IO

Namespace _3Modules
    Public Module Update

        ''' <summary>
        '''     Connects to the network and checks if an update is required.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CheckUpdate(Optional ByVal hideSplash As Boolean = False) As Integer
            Try
                If My.Computer.Network.IsAvailable Then
                    Using waitInd As New FrmWait("Checking For Update... ")
                        If Not hideSplash Then
                            waitInd.Show()
                            waitInd.Refresh()
                        End If
                        Dim ver As Integer = CInt(My.Application.Info.Version.ToString.Replace(".", ""))
                        Dim newVerStr As String
                        Dim newVerNum As String
                        If My.Computer.Network.IsAvailable Then
                            Try
                                Dim wr As HttpWebRequest = CType(WebRequest.Create("http://update.uhillsec.com/ensys/version"), HttpWebRequest)
                                wr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)"
                                wr.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate")
                                wr.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
                                Using response As WebResponse = wr.GetResponse()
                                    Using responseStream As Stream = response.GetResponseStream()
                                        Using sr As New IO.StreamReader(responseStream)
                                            newVerStr = sr.ReadToEnd()
                                        End Using
                                    End Using
                                End Using
                                Dim verChars() As Char = newVerStr.Replace(".", "").ToCharArray()
                                For Each ch As Char In verChars
                                    If Char.IsDigit(ch) Then
                                        newVerNum &= ch
                                    End If
                                Next


                            Catch ex As Exception
                                Return -2
                            End Try
                        Else
                            Return -1
                        End If
                        If CInt(newVerNum) > ver Then
                            ShowUpdator(, hideSplash, newVerStr)
                            Return 1
                        Else
                            Return 0
                        End If
                    End Using
                Else
                    Return -1
                End If
            Catch ex As Exception
                MsgBox("Update Checker Error 1: Failed to check for update. Detailed info displayed below:" _
                       & vbCrLf & ex.ToString & vbCrLf &
                       "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                       "Error")
                Return -1
            End Try
        End Function


        ''' <summary>
        '''     Shows and populates the updator window. If the user decides to update, the app is closed and the updator
        '''     application is ran.
        ''' </summary>
        ''' <param name="parent">the from that the updator window should be a child of.</param>
        ''' <param name="autocheck">
        '''     specifies if this function is ran by the auto updator. If so, an option to stop auto-updating
        '''     is shown.
        ''' </param>
        ''' <remarks></remarks>
        Public Sub ShowUpdator(Optional ByVal parent As Form = Nothing, Optional ByVal autocheck As Boolean = False, _
                               Optional ByVal ver As String = "")
            Try
                Using upd As New FrmUpdate
                    With upd
                        Using waitInd As New FrmWait("Retrieving Update Info...")
                            .IsAutoCheck = autocheck
                            If Not autocheck Then
                                waitInd.Show()
                                waitInd.Refresh()
                                waitInd.BringToFront()
                            End If

                            Try
                                Dim newver As String
                                If String.IsNullOrEmpty(ver) Then
                                    Dim nwr As HttpWebRequest = CType(WebRequest.Create("http://update.uhillsec.com/ensys/notes"), HttpWebRequest)
                                    nwr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)"
                                    nwr.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate")
                                    nwr.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
                                    Using response As WebResponse = nwr.GetResponse()
                                        Using responseStream As Stream = response.GetResponseStream()
                                            Using sr As New IO.StreamReader(responseStream)
                                                newver = sr.ReadToEnd()
                                            End Using
                                        End Using
                                    End Using

                                Else
                                    newver = ver
                                End If
                                .lbVer.Text = "Version " & newver
                                Dim wr As HttpWebRequest = CType(WebRequest.Create("http://update.uhillsec.com/ensys/notes"), HttpWebRequest)
                                wr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.0.3705;)"
                                wr.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate")
                                wr.AutomaticDecompression = DecompressionMethods.GZip Or DecompressionMethods.Deflate
                                Dim description As String
                                Using response As WebResponse = wr.GetResponse()
                                    Using responseStream As Stream = response.GetResponseStream()
                                        Using sr As New IO.StreamReader(responseStream)
                                            description = sr.ReadToEnd
                                        End Using
                                    End Using
                                End Using
                                .tbNotes.Text = description.Replace(vbLf, vbCrLf)
                                'Else
                                'MsgBox("Update Checker Error 2b: Update server is unavailable.")
                                'Exit Sub
                                'End If
                            Catch

                                MsgBox("Update Checker Error 2b: Failed to show update window." & _
                                       "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                                       "Error")
                            End Try
                        End Using
                        If parent Is Nothing Then
                            .ShowDialog()
                            If .IsOk = False Then Exit Sub
                        Else
                            .ShowDialog(parent)
                            If .IsOk = False Then Exit Sub
                        End If
                        Process.Start(Application.StartupPath() & "\Updater.exe", "-forceupdate")
                        Application.Exit()
                    End With
                End Using
            Catch ex As Exception
                MsgBox("Update Checker Error 2: Failed to show update window. Detailed info displayed below:" _
                       & vbCrLf & ex.ToString & vbCrLf &
                       "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                       "Error")
            End Try
        End Sub

    End Module
End Namespace
