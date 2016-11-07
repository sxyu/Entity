Imports System.Drawing.Imaging
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports Entity._3Modules.General
Namespace _3Modules
    Module Images
        ''' <summary>
        '''     Crops and resizes the image to best fit the specified size
        ''' </summary>
        ''' <param name="srcPath">path to get the image from</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetBestFitImage(ByVal srcPath As String,
                                        Optional ByVal width As Integer = 158, Optional ByVal height As Integer = 100) _
            As Bitmap
            Try
                Dim previewImg As Bitmap = New Bitmap(width, height)
                Using fs As New FileStream(srcPath, FileMode.Open)
                    Using newImg As Bitmap = New Bitmap(fs)
                        Using g As Graphics = Graphics.FromImage(previewImg)
                            g.Clear(Color.WhiteSmoke)
                            g.SmoothingMode = SmoothingMode.HighSpeed
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic
                            If newImg.Width / newImg.Height < width / height Then
                                Dim h As Double = newImg.Height * (width / newImg.Width)
                                Dim hdist As Double = (height - h) / 2
                                g.DrawImage(newImg, 0, CInt(hdist), width, CInt(h))
                            Else
                                Dim w As Double = newImg.Width * (height / newImg.Height)
                                Dim wdist As Double = (width - w) / 2
                                g.DrawImage(newImg, CInt(wdist), 0, CInt(w), height)
                            End If
                        End Using
                    End Using
                End Using
                Return previewImg
            Catch ex As Exception
                MsgBox(
                    "Misc Error 4: Error occurred when retrieving a best fit image from ''" & srcPath &
                    "''. Detailed info displayed below:" _
                    & vbCrLf & ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function


        ''' <summary>
        '''     Generates a thumbnail from an image
        ''' </summary>
        ''' <param name="srcPath">path to get the image from</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetThumbnail(ByVal srcPath As String,
                                     Optional ByVal width As Integer = 158, Optional ByVal height As Integer = 100,
                                     Optional ByVal bgC As Color = Nothing) As Bitmap
            Try
                If bgC = Nothing Then bgC = Color.WhiteSmoke
                Dim previewImg As Bitmap = New Bitmap(width, height)
                Using fs As New FileStream(srcPath, FileMode.Open, FileAccess.Read)
                    Using newImg As Bitmap = New Bitmap(fs)
                        Using g As Graphics = Graphics.FromImage(previewImg)
                            g.Clear(bgC)
                            g.SmoothingMode = SmoothingMode.HighSpeed
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic
                            If newImg.Width / newImg.Height > width / height Then
                                Dim h As Double = newImg.Height * (width / newImg.Width)
                                Dim hdist As Double = (height - h) / 2
                                g.DrawImage(newImg, 0, CInt(hdist), width, CInt(h))
                            Else
                                Dim w As Double = newImg.Width * (height / newImg.Height)
                                Dim wdist As Double = (width - w) / 2
                                g.DrawImage(newImg, CInt(wdist), 0, CInt(w), height)
                            End If
                        End Using
                    End Using
                End Using
                Return previewImg
            Catch ex As Exception
                MsgBox(
                    "Misc Error 5: Error occurred when generating a thumbnail of ''" & srcPath &
                    "''. Detailed info displayed below:" _
                    & vbCrLf & ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function


        ''' <summary>
        '''     Generates a thumbnail from an image
        ''' </summary>
        ''' <param name="bmp">bitmap image to use</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetThumbnail(ByVal bmp As Bitmap,
                                     Optional ByVal width As Integer = 158, Optional ByVal height As Integer = 100,
                                     Optional ByVal bgC As Color = Nothing) As Bitmap
            Try
                If bgC = Nothing Then bgC = Color.WhiteSmoke
                Dim previewImg As Bitmap = New Bitmap(width, height)
                Using g As Graphics = Graphics.FromImage(previewImg)
                    g.Clear(bgC)
                    g.SmoothingMode = SmoothingMode.HighSpeed
                    If bmp.Width / bmp.Height > width / height Then
                        Dim h As Double = bmp.Height * (width / bmp.Width)
                        Dim hdist As Double = (height - h) / 2
                        g.DrawImage(bmp, 0, CInt(hdist), width, CInt(h))
                    Else
                        Dim w As Double = bmp.Width * (height / bmp.Height)
                        Dim wdist As Double = (width - w) / 2
                        g.DrawImage(bmp, CInt(wdist), 0, CInt(w), height)
                    End If
                End Using
                Return previewImg
            Catch ex As Exception
                MsgBox(
                    "Misc Error 6: Error occurred when generating a thumbnail of a memory bitmap. Detailed info displayed below:" _
                    & vbCrLf & ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function


        ''' <summary>
        '''     Saves a encoded jpeg file with quality settings
        ''' </summary>
        ''' <param name="path">where to save to</param>
        ''' <param name="img">the image</param>
        ''' <param name="quality">the quality settings (0-100, the higher the better quality. 85 recommended.)</param>
        ''' <remarks></remarks>
        Public Sub SaveJpeg(path As String, img As Bitmap, quality As Long)
            Try
                ' Encoder parameter for image quality
                Dim qualityParam As New EncoderParameter(Imaging.Encoder.Quality, quality)

                ' Jpeg image codec
                Dim jpegCodec As ImageCodecInfo = getEncoderInfo("image/jpeg")


                If jpegCodec Is Nothing Then
                    Return
                End If

                Dim encoderParams As New EncoderParameters(1)
                encoderParams.Param(0) = qualityParam
                Using fs As New FileStream(path, FileMode.Create)
                    img.Save(fs, jpegCodec, encoderParams)
                End Using
            Catch ex As Exception
                MsgBox(
                    "IPS Error 2: Error occurred while saving a JPEG image to ''" & path &
                    "''. Detailed info displayed below:" _
                    & vbCrLf & ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub


        ''' <summary>
        '''     saves a png image
        ''' </summary>
        ''' <param name="path">the path to save to</param>
        ''' <param name="img">the image</param>
        ''' <remarks></remarks>
        Public Sub SavePng(path As String, img As Bitmap)
            Try
                Using fs As New FileStream(path, FileMode.Create)
                    img.Save(fs, ImageFormat.Png)
                End Using
            Catch ex As Exception
                MsgBox(
                    "IPS Error 3: Error occurred while saving a PNG image to ''" & path &
                    "''. Detailed info displayed below:" _
                    & vbCrLf & ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub

        Private Function getEncoderInfo(mimeType As String) As ImageCodecInfo
            ' Get image codecs for all image formats
            Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()

            ' Find the correct image codec
            For i As Integer = 0 To codecs.Length - 1
                If codecs(i).MimeType = mimeType Then
                    Return codecs(i)
                End If
            Next
            Return Nothing
        End Function
        ''' <summary>
        '''     Recolors a bitmap image.
        ''' </summary>
        ''' <param name="image">bitmap to recolor</param>
        ''' <param name="mode">color mode</param>
        ''' <remarks></remarks>
        Public Function RecolorImage(ByVal image As Bitmap, ByVal mode As ImageColorMode) As Image
            Try
                If mode = ImageColorMode.Normal Then Return image 'skip the rest if mode is normal
                'puts image into a memory array, to increase read speed
                Dim retimg As New Bitmap(image)
                Dim data As BitmapData = retimg.LockBits(New Rectangle(0, 0, retimg.Width, retimg.Height),
                                                         ImageLockMode.ReadWrite, retimg.PixelFormat)
                Dim ptr As IntPtr = data.Scan0
                Dim bytes As Integer = Math.Abs(data.Stride) * image.Height
                Dim rgbValues(bytes - 1) As Byte
                Dim aveg As Integer = 0
                Marshal.Copy(ptr, rgbValues, 0, bytes)
                Select Case mode
                    Case ImageColorMode.Normal
                    Case ImageColorMode.Blackwhite
                        'make image b&w
                        For counter As Integer = 0 To rgbValues.Length - 1 Step 4
                            If counter + 2 > rgbValues.Length - 1 Then Continue For
                            aveg = (CInt(rgbValues(counter)) + CInt(rgbValues(counter + 1)) + CInt(rgbValues(counter + 2))) \
                                   3
                            If aveg > 128 Then
                                rgbValues(counter) = 255
                                rgbValues(counter + 1) = 255
                                rgbValues(counter + 2) = 255
                            Else
                                rgbValues(counter) = 0
                                rgbValues(counter + 1) = 0
                                rgbValues(counter + 2) = 0
                            End If
                        Next
                    Case ImageColorMode.Greyscale
                        'convert image to Color.fromArgb(100, 100, 100)scale
                        For counter As Integer = 0 To rgbValues.Length - 1 Step 4
                            If counter + 2 > rgbValues.Length - 1 Then Continue For
                            aveg = (CInt(rgbValues(counter)) + CInt(rgbValues(counter + 1)) + CInt(rgbValues(counter + 2))) \
                                   3
                            rgbValues(counter) = CByte(aveg)
                            rgbValues(counter + 1) = CByte(aveg)
                            rgbValues(counter + 2) = CByte(aveg)
                        Next
                    Case ImageColorMode.Sepia
                        'convert image to a sepia (old) tone
                        For counter As Integer = 0 To rgbValues.Length - 1 Step 4
                            If counter + 2 > rgbValues.Length - 1 Then Continue For
                            Dim inR As Int32 = CInt(rgbValues(counter))
                            Dim inG As Int32 = CInt(rgbValues(counter + 1))
                            Dim inB As Int32 = CInt(rgbValues(counter + 2))
                            Dim outR As Int32 = CInt(inR * 0.393 + inG * 0.769 + inB * 0.189)
                            Dim outG As Int32 = CInt(inR * 0.349 + inG * 0.686 + inB * 0.168)
                            Dim outB As Int32 = CInt(inR * 0.272 + inG * 0.534 + inB * 0.131)
                            If outR > 255 Then outR = 255
                            If outG > 255 Then outG = 255
                            If outB > 255 Then outB = 255
                            If outR < 0 Then outR = 0
                            If outG < 0 Then outG = 0
                            If outB < 0 Then outB = 0
                            'MsgBox(inR & vbCrLf & inG & vbCrLf & inB)
                            rgbValues(counter) = CByte(outB)
                            rgbValues(counter + 1) = CByte(outG)
                            rgbValues(counter + 2) = CByte(outR)
                        Next
                    Case ImageColorMode.Inverse
                        'invert image
                        For counter As Integer = 0 To rgbValues.Length - 1 Step 4
                            If counter + 2 > rgbValues.Length - 1 Then Continue For
                            Dim inR As Int32 = CInt(rgbValues(counter))
                            Dim inG As Int32 = CInt(rgbValues(counter + 1))
                            Dim inB As Int32 = CInt(rgbValues(counter + 2))
                            rgbValues(counter) = CByte(255 - inR)
                            rgbValues(counter + 1) = CByte(255 - inG)
                            rgbValues(counter + 2) = CByte(255 - inB)
                        Next
                    Case ImageColorMode.Bright
                        'make image bright
                        For counter As Integer = 0 To rgbValues.Length - 1 Step 4
                            If counter + 2 > rgbValues.Length - 1 Then Continue For
                            Dim inR As Int32 = CInt(rgbValues(counter))
                            Dim inG As Int32 = CInt(rgbValues(counter + 1))
                            Dim inB As Int32 = CInt(rgbValues(counter + 2))
                            Dim max As Int32 = Math.Max(inR, inG)
                            max = Math.Max(max, inB)
                            Dim diff As Int32 = CInt((255 - max) / 2)
                            rgbValues(counter) = CByte(inR + diff)
                            rgbValues(counter + 1) = CByte(inG + diff)
                            rgbValues(counter + 2) = CByte(inB + diff)
                        Next
                    Case ImageColorMode.Dark
                        'make image dark
                        For counter As Integer = 0 To rgbValues.Length - 1 Step 4
                            If counter + 2 > rgbValues.Length - 1 Then Continue For
                            Dim inR As Int32 = CInt(rgbValues(counter))
                            Dim inG As Int32 = CInt(rgbValues(counter + 1))
                            Dim inB As Int32 = CInt(rgbValues(counter + 2))
                            Dim min As Int32 = Math.Min(inR, inG)
                            min = Math.Min(min, inB)
                            Dim diff As Int32 = min \ 2
                            rgbValues(counter) = CByte(inR - diff)
                            rgbValues(counter + 1) = CByte(inG - diff)
                            rgbValues(counter + 2) = CByte(inB - diff)
                        Next
                    Case ImageColorMode.Highcontrast
                        'make image high contrast
                        For counter As Integer = 0 To rgbValues.Length - 1 Step 4
                            If counter + 2 > rgbValues.Length - 1 Then Continue For
                            Dim inR As Int32 = CInt(rgbValues(counter))
                            Dim inG As Int32 = CInt(rgbValues(counter + 1))
                            Dim inB As Int32 = CInt(rgbValues(counter + 2))
                            Dim outR As Int32 = CInt((inR - 127) * 1.4 + 127)
                            Dim outG As Int32 = CInt((inG - 127) * 1.4 + 127)
                            Dim outB As Int32 = CInt((inB - 127) * 1.4 + 127)
                            'in case something exceeds 255 or goes below 0
                            If outR > 255 Then outR = 255
                            If outG > 255 Then outG = 255
                            If outB > 255 Then outB = 255
                            If outR < 0 Then outR = 0
                            If outG < 0 Then outG = 0
                            If outB < 0 Then outB = 0
                            rgbValues(counter) = CByte(outR)
                            rgbValues(counter + 1) = CByte(outG)
                            rgbValues(counter + 2) = CByte(outB)
                        Next
                    Case Else
                        MsgBox("Error: mode invalid.", MsgBoxStyle.Critical)
                End Select
                're-forms the image from the array
                Marshal.Copy(rgbValues, 0, ptr, bytes)
                retimg.UnlockBits(data)
                Return retimg
            Catch ex As Exception
                MsgBox("IPS Error 1: Image re-color operation failed. Detailed info displayed below:" _
                       & vbCrLf & ex.ToString & vbCrLf & "Contact the Entity Team if this persists.",
                       MsgBoxStyle.Critical Or
                       MsgBoxStyle.MsgBoxSetForeground, "Error")
                Application.Restart()
            End Try
        End Function

    End Module
End Namespace