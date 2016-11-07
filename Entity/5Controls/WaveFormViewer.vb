Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports NAudio.Wave

Namespace AlexYu
    ''' <summary>
    ''' Control for viewing waveforms
    ''' </summary>
    Public Class WaveFormViewer
        Inherits System.Windows.Forms.UserControl
        Public Property penColor() As Color
            Get
                Return m_penColor
            End Get
            Set(value As Color)
                m_penColor = Value
            End Set
        End Property
        Private m_penColor As Color
        Public Property penWidth() As Single
            Get
                Return m_penWidth
            End Get
            Set(value As Single)
                m_penWidth = Value
            End Set
        End Property
        Private m_penWidth As Single
        Private m_curLineLocation As Single
        Public Property curLineLocation() As Single
            Get
                Return m_curLineLocation
            End Get
            Set(value As Single)
                m_curLineLocation = value
            End Set
        End Property
        Public Property lineColor() As Color
            Get
                Return m_lineColor
            End Get
            Set(value As Color)
                m_lineColor = value
            End Set
        End Property
        Private m_lineColor As Color
        Public Property lineWidth() As Single
            Get
                Return m_lineWidth
            End Get
            Set(value As Single)
                m_lineWidth = value
            End Set
        End Property
        Private m_lineWidth As Single
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing
        Private m_waveStream As WaveStream
        Private m_samplesPerPixel As Integer = 128
        Private m_startPosition As Long
        Private bytesPerSample As Integer
        ''' <summary>
        ''' Creates a new WaveViewer control
        ''' </summary>
        Public Sub New()
            ' This call is required by the Windows.Forms Form Designer.
            InitializeComponent()
            Me.DoubleBuffered = True

            Me.penColor = Color.WhiteSmoke
            Me.penWidth = 1
            Me.lineColor = Color.SlateGray
            Me.lineWidth = 2
            Me.curLineLocation = 0
        End Sub

        ''' <summary>
        ''' sets the associated wavestream
        ''' </summary>
        Public Property WaveStream() As WaveStream
            Get
                Return m_waveStream
            End Get
            Set(value As WaveStream)
                m_waveStream = value
                If m_waveStream IsNot Nothing Then
                    bytesPerSample = (m_waveStream.WaveFormat.BitsPerSample / 8) * m_waveStream.WaveFormat.Channels
                End If
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' The zoom level, in samples per pixel
        ''' </summary>
        Public Property SamplesPerPixel() As Integer
            Get
                Return m_samplesPerPixel
            End Get
            Set(value As Integer)
                m_samplesPerPixel = value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' Start position (currently in bytes)
        ''' </summary>
        Public Property StartPosition() As Long
            Get
                Return m_startPosition
            End Get
            Set(value As Long)
                m_startPosition = value
            End Set
        End Property

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overrides Sub Dispose(disposing As Boolean)
            If disposing Then
                If components IsNot Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
        Public Sub FitToScreen()
            If IsNothing(WaveStream) Then Return
            Dim samples As Integer = CInt(WaveStream.Length / bytesPerSample)
            StartPosition = 0
            SamplesPerPixel = samples / Me.Width
        End Sub
        ''' <summary>
        ''' <see cref="Control.OnPaint"/>
        ''' </summary>
        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            If m_waveStream IsNot Nothing Then
                m_waveStream.Position = 0
                Dim bytesRead As Integer
                Dim waveData As Byte() = New Byte(m_samplesPerPixel * bytesPerSample - 1) {}
                m_waveStream.Position = m_startPosition + (e.ClipRectangle.Left * bytesPerSample * m_samplesPerPixel)
                Using graphPen = New Pen(penColor, penWidth)
                    Using linePen = New Pen(lineColor, lineWidth)
                        For x As Single = e.ClipRectangle.X To e.ClipRectangle.Right - 1
                            Dim low As Short = 0
                            Dim high As Short = 0
                            bytesRead = m_waveStream.Read(waveData, 0, m_samplesPerPixel * bytesPerSample)
                            If bytesRead = 0 Then
                                Exit For
                            End If
                            For n As Integer = 0 To bytesRead - 1 Step 2
                                Dim sample As Short = BitConverter.ToInt16(waveData, n)
                                If sample < low Then
                                    low = sample
                                End If
                                If sample > high Then
                                    high = sample
                                End If
                            Next
                            Dim lowPercent As Single = ((CSng(low) - Short.MinValue) / UShort.MaxValue)
                            Dim highPercent As Single = ((CSng(high) - Short.MinValue) / UShort.MaxValue)

                            e.Graphics.DrawLine(graphPen, x, Me.Height * lowPercent, x, Me.Height * highPercent)
                        Next
                        Dim actualLineLoc As Integer = CInt(Me.Width * (curLineLocation / 100))

                    End Using
                End Using
            End If

            MyBase.OnPaint(e)
        End Sub


#Region "Component Designer generated code"
        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.SuspendLayout()
            '
            'WaveFormViewer
            '
            Me.Name = "WaveFormViewer"
            Me.ResumeLayout(False)

        End Sub
#End Region


    End Class
End Namespace
