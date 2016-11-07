Namespace _2Namespaces
    Public Class KeyFrame
        Private _mTime As Decimal
        Public Property Time As Decimal
            Get
                Return _mTime
            End Get
            Set(value As Decimal)
                _mTime = value
            End Set
        End Property
        Private m_volume As Double
        Public Property Volume As Double
            Get
                Return m_volume
            End Get
            Set(value As Double)
                m_volume = value
            End Set
        End Property

        Public Sub New(ByVal time As Decimal, ByVal volume As Double)
            Me.Time = time
            Me.Volume = volume
        End Sub
    End Class
    Public Class KeyFrameList
        Private m_list As New List(Of KeyFrame)
        Private m_length As Integer
        Public ReadOnly Property Length As Integer
            Get
                Return m_length
            End Get
        End Property
        Public Function toArray() As KeyFrame()
            Return m_list.ToArray
        End Function
        Public Function Items() As List(Of KeyFrame)
            Return m_list
        End Function
        Public Sub Add(ByVal time As Decimal, ByVal volume As Double)
            m_list.Add(New KeyFrame(time, volume))
            m_length = m_list.Count
            Me.Sort()
        End Sub
        Public Overloads Sub Clear()
            m_list.Clear()
            m_length = m_list.Count
        End Sub
        Public Overloads Sub RemoveAt(ByVal index As Integer)
            m_list.RemoveAt(index)
            m_length = m_list.Count
            Me.Sort()
        End Sub

        Public Sub ChangeVolume(ByVal index As Integer, ByVal volume As Double)
            m_list(index).Volume = volume
            m_length = m_list.Count
        End Sub

        Public Sub ChangeVolumeByTime(ByVal time As Decimal, ByVal volume As Double)
            Dim ret As Double = -1
            For Each i As KeyFrame In m_list
                If time = i.Time Then
                    i.Volume = volume
                    Exit For
                End If
            Next
            m_length = m_list.Count
        End Sub
        ''' <summary>
        ''' Gets the volume at a key frame
        ''' </summary>
        ''' <param name="time"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetVolumeByTime(ByVal time As Decimal) As Double
            Dim ret As Double = -1
            For Each i As KeyFrame In m_list
                If time = i.Time Then
                    ret = i.Volume
                    Exit For
                End If
            Next
            m_length = m_list.Count
            Return ret
        End Function
        ''' <summary>
        ''' Calculates the volume at any point
        ''' </summary>
        ''' <param name="time">the time to get the volume at</param>
        ''' <returns>the volume level at a specific time (dbl)</returns>
        ''' <remarks></remarks>
        Public Function CalcVolumeByTime(ByVal time As Decimal) As Double
            On Error Resume Next
            'keyframe before
            Dim lClosestKF As New KeyFrame(m_list(0).Time, m_list(0).Volume)
            'keyframe after
            Dim rClosestKF As New KeyFrame(m_list(m_list.Count - 1).Time, m_list(m_list.Count - 1).Volume)
            For int As Integer = 0 To m_list.Count
                Dim i As KeyFrame = m_list(int)
                If time = i.Time Then
                    'if a keyframe is at the specified time, return immediately
                    Dim ret As Double = i.Volume
                    Return ret
                ElseIf (time - i.Time) > 0 Then
                    'get keyframe before
                    If (time - i.Time) < (time - rClosestKF.Time) Then
                        rClosestKF = New KeyFrame(i.Time, i.Volume)
                    End If
                Else
                    'get keyframe before
                    If (i.Time - time) < (lClosestKF.Time - time) Then
                        lClosestKF = New KeyFrame(i.Time, i.Volume)
                    End If
                End If
            Next
            Dim timeDiff As Decimal = rClosestKF.Time - lClosestKF.Time 'time between the closest frames
            Dim volDiff As Decimal = CDec(rClosestKF.Volume - lClosestKF.Volume) 'volume difference
            If timeDiff = 0 Then
                Return 0
            End If
            Dim volDiffPerUnit As Double = volDiff / timeDiff 'unit volume increment/decrement

            Dim curTimeInterval As Decimal = time - lClosestKF.Time 'difference between current time and previous keyframe
            Return (lClosestKF.Volume + curTimeInterval * volDiffPerUnit) 'return the calculated volume level
        End Function
        Public Function GetClosestKF(ByVal time As Decimal) As KeyFrame
            Dim leastdiff As Decimal = 100
            Dim ret As KeyFrame = Nothing
            For int As Integer = 0 To m_list.Count - 1
                Dim i As KeyFrame = m_list(int)
                Dim diff As Decimal = Math.Abs(time - i.Time)
                If diff <= 0.1 Then
                    Return New KeyFrame(i.Time, i.Volume)
                    Exit For
                ElseIf diff < leastdiff Then
                    leastdiff = diff
                    ret = New KeyFrame(i.Time, i.Volume)
                End If
            Next
            Return ret
        End Function
        Public Function GetProximityStatus(ByVal time As Decimal) As Integer '-1 is far, 0 is near a keyframe, 1 is a keyframe
            Dim ret As Integer = -1
            For int As Integer = 0 To m_list.Count - 1
                Dim i As KeyFrame = m_list(int)
                Dim diff As Decimal = Math.Abs(time - i.Time)
                If diff = 0 Then
                    ret = 1
                    Exit For
                ElseIf diff < 0.1 Then
                    If ret < 0 Then ret = 0
                End If
            Next
            Return ret
        End Function
        Public Function GetProximityStatusCustom(ByVal time As Decimal, ByVal range As Decimal) As Integer '0 is far, 1 is in range
            Dim ret As Integer = 0
            For Each i As KeyFrame In m_list
                Dim diff As Decimal = Math.Abs(time - i.Time)
                If diff < range Then
                    ret = 1
                End If
            Next
            Return ret
        End Function
        Public Sub RemoveByTime(ByVal time As Decimal)
            Dim ret As Double = -1
            For Each i As KeyFrame In m_list
                If time = i.Time Then
                    m_list.Remove(i)
                    Exit For
                End If
            Next
            m_length = m_list.Count
        End Sub
        Public Sub AddRange(ByVal items As KeyFrame())
            m_list.AddRange(items)
            m_length = m_list.Count
            Me.Sort()
        End Sub
        Public Sub Remove(ByVal item As KeyFrame)
            m_list.Remove(item)
            m_length = m_list.Count
            Me.Sort()
        End Sub
        Public Sub Sort()
            Dim temp As New List(Of KeyFrame)
            While m_list.Count > 0
                Dim earliestTime As KeyFrame = Nothing
                For int As Integer = 0 To m_list.Count - 1
                    Dim k As KeyFrame = m_list(int)
                    If earliestTime Is Nothing Then
                        earliestTime = k
                    Else
                        If Decimal.Compare(k.Time, earliestTime.Time) = 1 Then
                            earliestTime = k
                        End If
                    End If
                Next
                temp.Add(earliestTime)
                m_list.Remove(earliestTime)
            End While
            m_list.AddRange(temp.ToArray)
            temp.Clear()
        End Sub
        Public Sub New()
            m_list = New List(Of KeyFrame)
        End Sub
        Public Overrides Function ToString() As String
            Dim ret As String = ""
            For i As Integer = 0 To Me.Length - 1
                ret &= Me.Items(i).Time & "," & Me.Items(i).Volume & vbCrLf
            Next
            Return ret.Trim
        End Function
    End Class

End Namespace