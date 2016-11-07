Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Timers

Namespace _4Classes.Types

    Public Class AutoPjxEngine : Inherits PjxEngine : Implements IDisposable
        Public Shadows Event EffectEnded As EventHandler

        'Event EffectEnded: triggers when effect ends
        Public Property IsBusy As Boolean = False
        Public Overloads Property EffectName() As Effect
            Get
                Return _effect
            End Get
            Set(ByVal Value As Effect)
                _effect = Value
            End Set
        End Property

#Region "Private Variables"

        'Speed to draw effect
        Private _velocity As Integer = 20
        'The current effect
        Private _effect As Effect = Effect.Fan_Right
        'The control to show the Effect
        Private _dispControl As Control
        'Property of _DispControl where the image is placed in the Effect
        Private _property As PropertyInfo
        'Background filling color
        Private _fillColor As Color = Color.Transparent
        'Control timer for Effect
        Private _timer As New Windows.Forms.Timer
        'Count the times to run the Tick event for each effect
        Private _counter As Integer = 0
        'Contains a copy of the image passed to one of the constructors for the Effect
        Private _bmpTexture As Image
        'Contains an empty copy of _bmpTexture where the effect is drawn
        Private _bmpDraw As Image
        'Graphics used to draw _bmpDraw
        Private _graphics As Graphics
        'TextureBrush using the texture of image _bmpTexture
        Private _brush As TextureBrush
        'Contain the Width and Height of _bmpTexture
        Private _imageWidth, _imageHeight As Single
        'Indicates whether an effect is currently playing
        Private _isEffectRunning As Boolean = False
        Private _disposed As Boolean = False

#Region " Variables especificas de algunos Effect "

        '羘gulo de giro 
        Private _AngleChg As Single
        'Cantidad en que se aumentan las transformaciones de _Axles.
        Private _xAumentaPos, _yAumentaPos As Single
        '_Aumento progresivo de los dibujos
        Private _Aumento As Single

#End Region

#End Region

#Region "Public Methods"
        Public Sub New(ByVal ImagePath As String, ByVal Control As Control, ByVal strProperty As String,
                       Optional ByVal intVelocity As Integer = 20)
            'MyBase.New(ImagePath, Control, strProperty, intVelocity)
            Try
                Using fs As New FileStream(ImagePath, FileMode.Open)
                    _bmpTexture = New Bitmap(fs)
                End Using
                Initialize(Control, intVelocity, strProperty) 'code rewritten to call child initialize method
            Catch ex As Exception When Not Directory.Exists(ImagePath)
                MessageBox.Show("The image path is invalid")
            Catch ex As Exception When _bmpTexture Is Nothing
                MessageBox.Show("The image cannot be null")
            End Try
        End Sub

        Public Sub New(ByVal Image As Image, ByVal Control As Control, ByVal strProperty As String,
                       Optional ByVal intVelocity As Integer = 20)
            Try
                _bmpTexture = Image
                Initialize(Control, intVelocity, strProperty)
            Catch ex As Exception When _bmpTexture Is Nothing
                MessageBox.Show("The image cannot be null")
            End Try
        End Sub
        'Ejecuta el effect en la Property "EffectTrans.effectActual"
        Public Overloads Sub Start()
            If Not _disposed Then
                Me.IsBusy = True
                SetObjects()
            Else
                Throw _
                    New ObjectDisposedException("",
                                                "This instance of the class has been previously discarded and therefore no longer accessible.")
            End If
        End Sub

        'Ejecuta el effect pasado en eeffect
        Public Overloads Sub Start(ByVal effect As Effect)
            If Not _disposed Then
                Me.IsBusy = True
                _effect = effect
                'Iniciamos los objetos de dibujo y el Timer
                SetObjects()
            Else
                Throw _
                    New ObjectDisposedException("",
                                                "Esta instancia de la clase EffectTrans ha sido desechada previamente y por lo tanto, ya no es accesible.")
            End If
        End Sub

#End Region

#Region "Private Methods"

        'Establecemos las variables de nivel de modulo
        Private Sub Initialize(ByVal Control As Control, ByVal intVelocity As Integer, ByVal strProperty As String)

            _dispControl = Control
            _velocity = ValidateVelocity(intVelocity)
            _imageWidth = _bmpTexture.Width
            _imageHeight = _bmpTexture.Height

            _bmpDraw = New Bitmap(CInt(_imageWidth), CInt(_imageHeight), PixelFormat.Format32bppArgb)

            GetProperty(strProperty)
            _timer.Interval = 50
            'Set up controller timer tick event
            AddHandler _timer.Tick, AddressOf TimerTick
        End Sub

        'The following code was provided by Eduardo A. Morcillo
        Private Sub GetProperty(ByVal strProperty As String)
            'Get control type
            Dim t As Type = _dispControl.GetType
            'Get property
            _property = t.GetProperty(strProperty)
            'Verify that the property is returned
            If _property Is Nothing Then
                Throw New ArgumentException("This control does not contain the property")
            End If
            'Verify that the property returned
            'is the image type or a subclass of image
            If Not GetType(Image).IsAssignableFrom(_property.PropertyType) Then
                Throw New ArgumentException("The property is not of the image type")
            End If
        End Sub

        '(Re)Sets objects and global variables to their original state before executing an effect
        Private Sub SetObjects()
            'Try
            'If the above effect is not yet finished running then exit
            If _isEffectRunning Then Exit Sub
            'Start graphics object
            _graphics = Graphics.FromImage(_bmpDraw)
            Select Case _effect
                Case Effect.Fade_In, Effect.Stretch_Centre To Effect.Spin_Spiral_Up, Effect.Hinge_Right_CW,
                    Effect.Hinge_Right_CCW
                    'For these _Brush Effect the object is not needed (DrawImage used)
                    'In the case of Effect 'Hinge_Right_CCW' and 'Hinge_Right_CW'
                    'the code of these Effect will initialize the object 
                Case Else
                    'Start TextureBrush Object
                    IniTextureBrush()
            End Select

            '******* Image control is modified *******
            'Assign Property _bmpDraw to Control Image
            _property.SetValue(_dispControl, _bmpDraw, Nothing)
            '******* Image control is modified *******

            'Clear _bmpDraw
            _graphics.Clear(_fillColor)
            'Reset Variables
            _counter = 0
            _Aumento = 0
            _AngleChg = 0
            _xAumentaPos = 0
            _yAumentaPos = 0
            If EffectName = Effect.Appear Then
                _graphics.DrawImage(_bmpTexture, 0, 0, _imageWidth, _imageHeight)
                RefreshDispCtrl()
                Me.UnloadObjs()
            Else
                'True to indicate that the effect is to Initiate
                _isEffectRunning = True
                'Start the control timer
                _timer.Start()
            End If
            'Catch ex As Exception When _bmpDraw Is Nothing
            '    Throw New NullReferenceException("The image where the effect is to draw is null")
            'End Try
        End Sub

        'Inicializa el objeto TextureBrush
        Private Sub IniTextureBrush()
            _brush = New TextureBrush(_bmpTexture)
        End Sub

        'Controlador del evento Tick del control _Timer
        Private Sub TimerTick(ByVal sender As Object, ByVal e As EventArgs)
            Try
                'Ejecutamos cada 80 milesimas de segundo, el effect selecionado
                Select Case _effect
                    Case Effect.Fan_Right, Effect.Fan_Left
                        Fan(_effect)
                    Case Effect.Fade_In
                        Fade_In()
                    Case Effect.Bars_Horizontal, Effect.Bars_Vertical
                        Bars(_effect)
                    Case Effect.Sweep_Horizontal, Effect.Sweep_Vertical
                        Sweep(_effect)
                    Case Effect.Circle_Out
                        Circle_Out()
                    Case Effect.Circle_In
                        Circle_In()
                    Case Effect.Expand_Centre To Effect.Expand_Top_Left, Effect.Stretch_Centre To Effect.Stretch_Top_Left
                        Expand_Stretch(_effect)
                    Case Effect.Diagonal
                        Diagonal()
                    Case Effect.Division_Horizontal_In, Effect.Division_Horizontal_Out
                        DivisionH(_effect)
                    Case Effect.Division_Vertical_In, Effect.Division_Vertical_Out
                        DivisionV(_effect)
                    Case Effect.Push_Down To Effect.Push_Diagonal_Top_Left
                        Push(_effect)
                    Case Effect.Spin_Centre To Effect.Spin_Spiral_Up
                        Spin(_effect)
                    Case Effect.Blinds_Horizontal_Down, Effect.Blinds_Horizontal_Up
                        Blinds_Horizontal(_effect)
                    Case Effect.Blinds_Vertical_Left, Effect.Blinds_Vertical_Right
                        Blinds_Vertical(_effect)
                    Case Effect.Clock, Effect.Clock_CCW
                        Clock(_effect)
                    Case Effect.Symmetric_Down To Effect.Symmetric_Right
                        Symmetric(_effect)
                    Case Effect.Wheel_2_Axles To Effect.Wheel_8_Axles
                        WheelMultiple(_effect)
                    Case Effect.Division_Push_In_Horizontal, Effect.Division_Push_In_Vertical
                        PushDivision(_effect)
                    Case Effect.Hinge_Right_CW To Effect.Hinge_Left_CW
                        Hinge(_effect)
                End Select
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Sub

        'Descarga objetos y detiene el Timer
        Private Sub UnloadObjs()
            _graphics.Dispose()
            If Not (_brush Is Nothing) Then
                _brush.Dispose()
            End If
            _timer.Stop()
            'False para indicar que el effect acaba de terminar
            _isEffectRunning = False
            _AngleChg = 0
            'El effect termin? disparamos un evento para indicarlo
            Me.IsBusy = False
            RaiseEvent EffectEnded(Me, New EventArgs)
        End Sub

        'Validate the Property EffectVelocity
        Private Function ValidateVelocity(ByVal intValor As Integer) As Integer
            If intValor <= 0 Then
                Return _velocity ' Valor por deffect (20)
                'ElseIf intValor > 100 Then
                '    Return 100
            Else : Return intValor
            End If
        End Function

#Region "Effect Transitions"

        Private Sub RefreshDispCtrl()
            SyncLock _dispControl
                _dispControl.Invalidate()
            End SyncLock
            'If _DispControl.InvokeRequired Then
            '    _DispControl.BeginInvoke(New MethodInvoker(Sub()

            '                                               End Sub))
            'Else
            '    _DispControl.Invalidate()
            'End If
        End Sub

        'Generate fade in effect
        Private Sub Fade_In()
            Try
                SyncLock (_dispControl)
                    Static Opacity As Single = 0.0F
                    Dim FadeVelocity As Single = 0.0F
                    FadeVelocity = CSng(1 / (_velocity / 50))
                    _graphics.Clear(_fillColor)
                    Dim Cm As ColorMatrix = New ColorMatrix
                    Dim Ia As ImageAttributes = New ImageAttributes
                    Opacity += FadeVelocity
                    If Opacity > 1.0F Then
                        Opacity = 1.0F
                    ElseIf Opacity < 0.01F Then
                        Opacity = 0.01F
                        FadeVelocity = 0.01F
                    End If
                    Cm.Matrix33 = Opacity
                    Ia.SetColorMatrix(Cm)
                    _graphics.DrawImage(_bmpTexture, New Rectangle(0, 0, CInt(_imageWidth), CInt(_imageHeight)), 0, 0,
                                        _imageWidth, _imageHeight, GraphicsUnit.Pixel, Ia)

                    RefreshDispCtrl()

                    If Opacity >= 1.0F Then
                        Opacity = 0
                        Ia.Dispose()
                        UnloadObjs()
                    End If
                End SyncLock
            Catch
            End Try
        End Sub


        'Fan effects
        Private Sub Fan(ByVal effect As Effect)
            'Calculamos por Pitagoras el radio de la circunferencia con Centre en (_ImageWidth / 2, _ImageHeight) 
            'que Draw?la Image.
            Dim Radio As Single = CSng(Math.Pow(((_imageWidth / 2) ^ 2) + (_imageHeight ^ 2), 1 / 2))
            'isNegative: direcci髇 del effect
            Dim AngInitial, isNegative As Integer

            'iniciamos variables seg鷑 el effect
            If effect = effect.Fan_Right Then
                AngInitial = 180
                isNegative = 1
            ElseIf effect = effect.Fan_Left Then
                AngInitial = 0
                isNegative = -1
            End If
            'Llenamos media torta con Centre en (_ImageWidth / 2, _ImageHeight),
            'con la Texture de la im醙en original,
            'agregandole trozos de _AngleChg
            Dim _
                Rec As _
                    New Rectangle(CInt(-(Radio - (_imageWidth / 2))), CInt(-(Radio - _imageHeight)), CInt(Radio * 2),
                                  CInt(Radio * 2))
            'Mostramos el trozo actual de la Image
            _graphics.FillPie(_brush, Rec, AngInitial, isNegative * _AngleChg)
            'Aumentamos el angulo de giro
            _AngleChg += CSng(180 / (_velocity / 50))
            'Mostramos los trozos actuales
            RefreshDispCtrl()
            _counter += 1
            'end effect
            If _counter = _velocity / 50 + 1 Then
                UnloadObjs()
            End If
        End Sub

        'Bar effects
        Private Sub Bars(ByVal effect As Effect)
            Dim i, j, MedidaImage, X, Y, Ancho, Alto As Integer
            Dim Iterations As Integer
            Dim _BarVelocity As Integer

            'Init variables based on effect
            If effect = effect.Bars_Horizontal Then
                Ancho = CInt(_imageWidth)
                Alto = 2
                MedidaImage = CInt(_imageHeight)
            ElseIf effect = effect.Bars_Vertical Then
                Ancho = 2
                Alto = CInt(_imageHeight)
                MedidaImage = CInt(_imageWidth)
            End If
            'Iterations = the number of bars to be Drawn
            'the extent of each bar is 2 and 
            'and make sure all follows _Velocity.
            'We approximate to the largest integer in the event that the 
            'Measurement of the Image is not divisible _Velocity * 2
            Iterations = CInt(Math.Ceiling(MedidaImage / ((_velocity / 50) * 2)))
            _BarVelocity = CInt(Math.Ceiling(MedidaImage / (Iterations * 2)))

            _timer.Stop()
            'Cada vez que se ejecuta este m閠odo dibujamos Iterations Bars
            For i = 0 To Iterations - 1
                'Hallamos las coordenadas de cada barra que se necesita Draw (sin repetir)
                'llamando a DameParUnico.
                j = DameParUnico(CInt(MedidaImage - 2), CInt(MedidaImage / 2) - 1)
                'Cuando j = -1 ya se Drawon todas las Bars (toda la Image)
                If j = -1 Then Exit For
                If effect = effect.Bars_Horizontal Then
                    X = 0
                    Y = j
                ElseIf effect = effect.Bars_Vertical Then
                    X = j
                    Y = 0
                End If
                'Dibujamos la barra actual
                _graphics.FillRectangle(_brush, New Rectangle(X, Y, Ancho, Alto))
            Next
            _timer.Start()
            'Refrescamos el Control de la Image
            RefreshDispCtrl()
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _FadeVelocity veses terminamos el effect
            If _counter = _BarVelocity Then
                UnloadObjs()
            End If
        End Sub

        'Sweep effects
        Private Sub Sweep(ByVal effect As Effect)

            'Creamos un segundo objeto Graphics para Draw en _bmpDraw
            Static Gr2 As Graphics

            Dim Persiana As Single
            Dim xEsquinaPersiana, yEsquinaPersiana As Single
            Dim AnchoPersiana, AltoPersiana As Single

            If effect = effect.Sweep_Horizontal Then
                _xAumentaPos = _imageWidth
                _yAumentaPos = 0
                xEsquinaPersiana = 0
                yEsquinaPersiana = _imageHeight / 20
                AnchoPersiana = _imageWidth
                AltoPersiana = _imageHeight / 20
            ElseIf effect = effect.Sweep_Vertical Then
                _xAumentaPos = 0
                _yAumentaPos = _imageHeight
                xEsquinaPersiana = _imageWidth / 20
                yEsquinaPersiana = 0
                AnchoPersiana = _imageWidth / 20
                AltoPersiana = _imageHeight
            End If

            If _counter = 0 Then
                Gr2 = Graphics.FromImage(_bmpDraw)
                'Movemos el Centre del eje de coordenadas la primera vez
                'que se ejecuta el evento, para que la Image se dibuje pero no se vea
                _graphics.TranslateTransform(_xAumentaPos, _yAumentaPos)
                Gr2.TranslateTransform(-_xAumentaPos, -_yAumentaPos)
            End If
            '***** Esto solo es necesario para Imagees con fondo transparente *****
            '_Graphics.Clear(_FillColor)
            '***********************************************************************
            For Persiana = 0 To 20 'N?de Persianas (20)
                'Las persianas pares las dibujamos con _Graphics,
                'y las impares con Gr2
                Dim SupLeft As New PointF(Persiana * xEsquinaPersiana, Persiana * yEsquinaPersiana)
                Dim Tama駉Persiana As New SizeF(AnchoPersiana, AltoPersiana)

                If Persiana Mod 2 = 0 Then
                    Dim RecSweepPar As New RectangleF(SupLeft, Tama駉Persiana)
                    _graphics.FillRectangle(_brush, RecSweepPar)
                Else
                    Dim RecSweepImpar As New RectangleF(SupLeft, Tama駉Persiana)
                    Gr2.FillRectangle(_brush, RecSweepImpar)
                End If
            Next
            'Transladamos los _Axles progresivamente
            _graphics.TranslateTransform(CSng(-_xAumentaPos / (_velocity / 50)), CSng(-_yAumentaPos / (_velocity / 50))) 'Velocity
            Gr2.TranslateTransform(CSng(_xAumentaPos / (_velocity / 50)), CSng(_yAumentaPos / (_velocity / 50)))
            'Contamos las veces que movimos la im醙en
            _counter += 1
            'Refrescamos el Control
            RefreshDispCtrl()
            'Cuando el evento se halla ejecutado _Velocity + 1
            'veses terminamos el effect
            If _counter = (_velocity / 50) + 1 Then
                Gr2.Dispose()
                xEsquinaPersiana = 0
                yEsquinaPersiana = 0
                AnchoPersiana = 0
                AltoPersiana = 0
                UnloadObjs()
            End If
        End Sub

        'Circle in effect
        Private Sub Circle_In()
            Dim Diametro As Single
            Static RecAnterior As RectangleF
            Dim Diagonal As Single = CSng(Math.Pow((_imageHeight ^ 2) + (_imageWidth ^ 2), 1 / 2))
            Diametro = CSng(Diagonal - (_counter * Diagonal / (_velocity / 50)))
            Dim xEsquina As Single = (_imageWidth / 2) - (Diametro / 2)
            Dim yEsquina As Single = (_imageHeight / 2) - (Diametro / 2)
            Dim MiPunto As New PointF(xEsquina, yEsquina)
            Dim Tama駉 As SizeF = New SizeF(Diametro, Diametro)
            Dim Rect醤gulo As New RectangleF(MiPunto, Tama駉)

            If _counter > 0 Then
                Dim Trayecto1 As New GraphicsPath
                Trayecto1.AddEllipse(RecAnterior)
                Dim Trayecto2 As New GraphicsPath
                Trayecto2.AddEllipse(Rect醤gulo)
                'Creamos un objeto region
                'compuesto por la elipse encapsuladas en Trayecto1
                'Al a馻dir el GraphicsPth Trayecto2
                'indicamos que vamos a combinar el contenido
                'del nuevo GraphicsPath Trayecto2 con Trayecto1 usando el m閠odo Xor
                Dim Regi As New Region(Trayecto2)
                Regi.Xor(Trayecto1)
                'Dibujamos la regi髇
                If _counter > 0 Then _graphics.FillRegion(_brush, Regi)
                'Mostramos el circulo actual
                RefreshDispCtrl()
            End If
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Recordamos el 鷏timo rectangulo que se uso para Draw el 鷏timo circulo
            RecAnterior = Rect醤gulo
            'Cuando el evento se halla ejecutado _Velocity + 1
            'veses terminamos el effect
            If _counter = (_velocity / 50) + 1 Then
                RecAnterior = Nothing
                UnloadObjs()
            End If
        End Sub

        'Genera el effect con Circle hacia Up
        Private Sub Circle_Out()
            'El diametro de los Circle
            Static Diametro As Single
            'La diagonal de la im醙en va a ser el diametro m醲imo. 
            'La calculamos por Pitagoras.
            Dim Diagonal As Single = CSng(Math.Pow((_imageHeight ^ 2) + (_imageWidth ^ 2), 1 / 2))
            'Definimos las coordenadas del punto superior
            'izquierdo del rect醤gulo a partir del cual
            'se Draw?un circulo circunscripto en 閘, de modo que 
            'el Centre de el circulo coincida con el Centre del Control
            Dim xEsquina As Single = (_imageWidth / 2) - (Diametro / 2)
            Dim yEsquina As Single = (_imageHeight / 2) - (Diametro / 2)
            Dim MiPunto As New PointF(xEsquina, yEsquina)
            'Tama駉 del rect醤gulo donde se Draw?el circulo
            Dim Tama駉 As SizeF = New SizeF(Diametro, Diametro)
            Dim Rect醤gulo As New RectangleF(MiPunto, Tama駉)
            _graphics.FillEllipse(_brush, Rect醤gulo)
            'Mostramos el circulo actual
            RefreshDispCtrl()
            'Aumentamos el diametro
            Diametro += CSng(Diagonal / (_velocity / 50))
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity + 1
            'veses terminamos el effect
            If _counter = _velocity / 50 + 1 Then
                Diametro = 0
                UnloadObjs()
            End If
        End Sub

        'Genera los Effect de despliegue y estiramiento
        Private Sub Expand_Stretch(ByVal effect As Effect)
            Dim X, Y, Ancho, Alto As Single

            _Aumento += CSng(1 / (_velocity / 50))
            'Iniciamos variables seg鷑 el effect.
            'Notar que el c骴igo para los Effect "Expand" y "Stretch" son identicos 
            'excepto por el m閠odo usado para Draw la Image (FillRectangle o DrawImage)
            Select Case effect
                Case effect.Expand_Centre, effect.Stretch_Centre
                    X = (_imageWidth / 2) - ((_imageWidth / 2) * _Aumento)
                    Y = (_imageHeight / 2) - ((_imageHeight / 2) * _Aumento)
                Case effect.Expand_Bottom_Right, effect.Stretch_Bottom_Right
                    X = _imageWidth - (_imageWidth * _Aumento)
                    Y = _imageHeight - (_imageHeight * _Aumento)
                Case effect.Expand_Bottom_Left, effect.Stretch_Bottom_Left
                    X = 0
                    Y = _imageHeight - (_imageHeight * _Aumento)
                Case effect.Expand_Top_Right, effect.Stretch_Top_Right
                    X = _imageWidth - (_imageWidth * _Aumento)
                    Y = 0
                Case effect.Expand_Top_Left, effect.Stretch_Top_Left
                    X = 0
                    Y = 0
            End Select

            Ancho = _imageWidth * _Aumento
            Alto = _imageHeight * _Aumento

            Dim Rec As New RectangleF(X, Y, Ancho, Alto)
            _graphics.Clear(_fillColor)

            Select Case effect
                Case effect.Expand_Centre To effect.Expand_Top_Left
                    _graphics.FillRectangle(_brush, Rec)
                Case effect.Stretch_Centre To effect.Stretch_Top_Left
                    _graphics.DrawImage(_bmpTexture, Rec)
            End Select
            'Refrescamos el Control de la Image
            RefreshDispCtrl()
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity veses terminamos el effect
            If _counter = _velocity / 50 Then
                UnloadObjs()
            End If
        End Sub

        'Generates the effect on Diagonal from the top left corner
        Private Sub Diagonal()
            'Aumentamos los Horizontal del tri醤gulo
            _xAumentaPos += CSng(_imageWidth / (_velocity / 50))
            _yAumentaPos += CSng(_imageHeight / (_velocity / 50))
            'Dibujanos el tri醤gulo actual
            _graphics.FillPolygon(_brush,
                                  New PointF() {New PointF(0, 0), New PointF(_xAumentaPos, 0), New PointF(0, _yAumentaPos)})
            'Actualizamos el dibujo
            RefreshDispCtrl()
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity * 2
            'veses terminamos el effect
            If _counter = _velocity / 25 Then
                UnloadObjs()
            End If
        End Sub

        'Genera los Effect de Divici髇 Horizontal
        Private Sub DivisionH(ByVal effect As Effect)

            Dim Velocity As Single = CSng(_imageWidth / (_velocity / 50))
            'Si es la primera vez que se llega aqu? establecemos algunas variables
            If _counter = 0 Then

                If effect = effect.Division_Horizontal_In Then
                    _Aumento = 0
                ElseIf effect = effect.Division_Horizontal_Out Then
                    _Aumento = _imageWidth / 2
                End If
            End If

            Dim RecDivision As New RectangleF(_Aumento, 0, Velocity, _imageHeight)
            Dim RecDivision2 As New RectangleF(_imageWidth - _Aumento, 0, Velocity, _imageHeight)
            'Dibujamos los rectangulos de divisi髇
            _graphics.FillRectangle(_brush, RecDivision)
            _graphics.FillRectangle(_brush, RecDivision2)

            RefreshDispCtrl()
            'Aumentamos el tama駉 de los rectangulos
            _Aumento += Velocity
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado la mitad de la cantidad de
            'diviciones del Ancho + 1 veses terminamos el effect
            If _counter = CInt((_velocity / 50 + 1) / 2) + 1 Then
                UnloadObjs()
            End If
        End Sub

        'Genera los Effect de Divici髇 Vertical
        Private Sub DivisionV(ByVal effect As Effect)

            Dim Velocity As Single = CSng(_imageHeight / (_velocity / 50))
            'Si es la primera vez que se llega aqu? establecemos algunas variables
            If _counter = 0 Then
                If effect = effect.Division_Vertical_In Then
                    _Aumento = 0
                ElseIf effect = effect.Division_Vertical_Out Then
                    _Aumento = _imageHeight / 2
                End If
            End If

            Dim RecDivision As New RectangleF(0, _Aumento, _imageWidth, Velocity)
            Dim RecDivision2 As New RectangleF(0, _imageHeight - _Aumento, _imageWidth, Velocity)
            'Dibujamos los rectangulos de divisi髇
            _graphics.FillRectangle(_brush, RecDivision)
            _graphics.FillRectangle(_brush, RecDivision2)

            RefreshDispCtrl()
            'Aumentamos el tama駉 de los rectangulos
            _Aumento += Velocity
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado la mitad de la cantidad de
            'diviciones del Alto + 1 veses terminamos el effect
            If _counter = CInt((_velocity / 50 + 1) / 2) + 1 Then
                UnloadObjs()
            End If
        End Sub

        'Genera los Effect de Empuje
        Private Sub Push(ByVal eeffect As Effect)
            'Si es la primera vez que se llega aqu? 
            'Establecemos las transformaci髇es iniciales
            'seg鷑 la variante de effect de Empuje
            If _counter = 0 Then
                'note: the ':' char is the inline operator 
                If eeffect = Effect.Push_Down Then
                    _graphics.TranslateTransform(0, -_imageHeight)
                    _xAumentaPos = 0
                    _yAumentaPos = CSng(_imageHeight / (_velocity / 50))
                ElseIf eeffect = Effect.Push_Up Then
                    _graphics.TranslateTransform(0, _imageHeight)
                    _xAumentaPos = 0
                    _yAumentaPos = CSng(-_imageHeight / (_velocity / 50))
                ElseIf eeffect = Effect.Push_Right Then
                    _graphics.TranslateTransform(-_imageWidth, 0)
                    _xAumentaPos = CSng(_imageWidth / (_velocity / 50))
                    _yAumentaPos = 0
                ElseIf eeffect = Effect.Push_Left Then
                    _graphics.TranslateTransform(_imageWidth, 0)
                    _xAumentaPos = CSng(-_imageWidth / (_velocity / 50))
                    _yAumentaPos = 0
                ElseIf eeffect = Effect.Push_Diagonal_Top_Left Then
                    _graphics.TranslateTransform(-_imageWidth, -_imageHeight)
                    _xAumentaPos = CSng(_imageWidth / (_velocity / 50))
                    _yAumentaPos = CSng(_imageHeight / (_velocity / 50))
                ElseIf eeffect = Effect.Push_Diagonal_Top_Right Then
                    _graphics.TranslateTransform(_imageWidth, -_imageHeight)
                    _xAumentaPos = CSng(-_imageWidth / (_velocity / 50))
                    _yAumentaPos = CSng(_imageHeight / (_velocity / 50))
                ElseIf eeffect = Effect.Push_Diagonal_Bottom_Left Then
                    _graphics.TranslateTransform(-_imageWidth, _imageHeight)
                    _xAumentaPos = CSng(_imageWidth / (_velocity / 50))
                    _yAumentaPos = CSng(-_imageHeight / (_velocity / 50))
                ElseIf eeffect = Effect.Push_Diagonal_Bottom_Right Then
                    _graphics.TranslateTransform(_imageWidth, _imageHeight)
                    _xAumentaPos = CSng(-_imageWidth / (_velocity / 50))
                    _yAumentaPos = CSng(-_imageHeight / (_velocity / 50))
                End If
            End If
            '***** Esto solo es necesario para Imagees con fondo transparente *****
            '_Graphics.Clear(_FillColor)
            '***********************************************************************
            'Dibujamos la Image con las transformaci髇es de _Axles. 
            Dim RecEmpuja As New RectangleF(0, 0, _imageWidth, _imageHeight)
            _graphics.FillRectangle(_brush, RecEmpuja)
            _graphics.TranslateTransform(_xAumentaPos, _yAumentaPos)
            RefreshDispCtrl()
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity + 1 veses terminamos el effect
            If _counter = (_velocity / 50) + 1 Then
                UnloadObjs()
            End If
        End Sub

        'Genera los Effect de Empuje con Divisi髇
        Private Sub PushDivision(ByVal effect As Effect)
            'Creamos el segundo objeto Graphics para Draw en _bmpDraw
            Static Gr2 As Graphics
            Dim Ancho, Alto, xEsquina, yEsquina As Single

            If effect = effect.Division_Push_In_Horizontal Then
                _xAumentaPos = CSng(_imageWidth / (2 * (_velocity / 50)))
                _yAumentaPos = 0
                Ancho = _imageWidth / 2
                Alto = _imageHeight
                xEsquina = Ancho
                yEsquina = 0
            ElseIf effect = effect.Division_Push_In_Vertical Then
                _xAumentaPos = 0
                _yAumentaPos = CSng(_imageHeight / (2 * (_velocity / 50)))
                Ancho = _imageWidth
                Alto = _imageHeight / 2
                xEsquina = 0
                yEsquina = Alto
            End If
            'Si es la primera vez que se llega aqu?
            'Establecemos las transformaci髇es iniciales
            'seg鷑 la variante de effect de Empuje y Divisi髇
            If _counter = 0 Then
                Gr2 = Graphics.FromImage(_bmpDraw)
                If effect = effect.Division_Push_In_Horizontal Then
                    _graphics.TranslateTransform(-Ancho, 0)
                    Gr2.TranslateTransform(Ancho, 0)
                ElseIf effect = effect.Division_Push_In_Vertical Then
                    _graphics.TranslateTransform(0, -Alto)
                    Gr2.TranslateTransform(0, Alto)
                End If
            End If

            Dim RecEmpujaLado As New RectangleF(0, 0, Ancho, Alto)
            Dim RecEmpujaOpuesto As New RectangleF(xEsquina, yEsquina, Ancho, Alto)
            '***** Esto solo es necesario para Imagees con fondo transparente *****
            '_Graphics.Clear(_FillColor)
            '***********************************************************************
            'Dibujamos los rectangulos y los lenamos con la Image   
            _graphics.FillRectangle(_brush, RecEmpujaLado)
            Gr2.FillRectangle(_brush, RecEmpujaOpuesto)
            'Movemos los _Axles de coordenadas
            _graphics.TranslateTransform(_xAumentaPos, _yAumentaPos)
            Gr2.TranslateTransform(-_xAumentaPos, -_yAumentaPos)
            RefreshDispCtrl()
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity + 1 veses terminamos el effect
            If _counter = _velocity / 50 + 1 Then
                Gr2.Dispose()
                UnloadObjs()
            End If
        End Sub

        'm: Matriz que vamos a usar para establecer tranformaciones en algunos Effect
        Private m As Matrix
        'Genera los Effect de giro de la Image con movimiento en Spiral
        Private Sub Spin(ByVal effect As Effect)
            Dim X, Y, Ancho, Alto As Single

            If _counter = 0 Then
                'La primera vez que se ejecuta el procedimiento, iniciamos la martix
                'y establecemos el 醤gulo de giro
                m = New Matrix
                _AngleChg = CInt(360 / (_velocity / 50))
            End If

            _Aumento += CSng(1 / (_velocity / 50))

            Ancho = _imageWidth * _Aumento
            Alto = _imageHeight * _Aumento
            If effect = effect.Spin_Centre Then
                X = (_imageWidth / 2) - ((_imageWidth / 2) * _Aumento)
                Y = (_imageHeight / 2) - ((_imageHeight / 2) * _Aumento)
            ElseIf effect = effect.Spin_Spiral_Down Then
                X = 0
                Y = _imageHeight - _imageHeight * _Aumento
            ElseIf effect = effect.Spin_Spiral_Up Then
                X = _imageWidth - _imageWidth * _Aumento
                Y = 0
            End If
            'Rectangulo donde se Draw?la Image
            Dim Rec As New RectangleF(X, Y, Ancho, Alto)
            _graphics.Clear(_fillColor)
            'Dibujamos la Image completa
            _graphics.DrawImage(_bmpTexture, Rec)

            '"Preparamos" una rotaci髇 con Centre en el Centre de la Image en la matriz m
            'por medio del metodo RotateAt y estableciendo la transformaci髇 en nuestro objeto Graphics _Graphics
            'para ser usada en la proxima ejecuci髇 del procedimiento
            m.RotateAt(_AngleChg, New PointF(_imageWidth / 2, _imageHeight / 2))
            _graphics.Transform = m

            RefreshDispCtrl()
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Para asegurarnos de que la Image de 1 vuelta entera terminamos el effect cuando _Counter = 360,
            'o sea ...
            If _counter = CInt(360 / _AngleChg) Then
                '***** Esto solo es necesario para Imagees con fondo transparente *****
                '_Graphics.Clear(_FillColor)
                '***********************************************************************
                'Rotamos la Image a su posici髇 original y la dibujamos antes de descargar todo
                m.RotateAt(-CSng(_AngleChg * _counter), New PointF(_imageWidth / 2, _imageHeight / 2))
                _graphics.Transform = m

                _graphics.DrawImage(_bmpTexture, 0, 0, _imageWidth, _imageHeight)
                RefreshDispCtrl()
                m.Dispose()
                UnloadObjs()
            End If
        End Sub

        'Genera los Effect con Persianas Horizontal
        Private Sub Blinds_Horizontal(ByVal effect As Effect)

            Dim Persiana As Integer
            'Total de Persianas
            Dim TotalPersianas As Integer = 15
            Dim Velocity As Integer = CInt(TotalPersianas * (_velocity / 50))
            'Si es la primera vez que se llega aqu? establecemos algunas variables
            If _counter = 0 Then
                If effect = effect.Blinds_Horizontal_Down Then
                    _Aumento = 0
                ElseIf effect = effect.Blinds_Horizontal_Up Then
                    _Aumento = _imageHeight / TotalPersianas
                End If
            End If

            For Persiana = 0 To TotalPersianas - 1
                'Dibuja un trozo de cada una de las persianas por cada ejecuci髇 del evento
                Dim SupLeft As New PointF(0, _Aumento + (Persiana * (_imageHeight / TotalPersianas)))
                Dim Tama駉Persiana As New SizeF(_imageWidth, _imageHeight / Velocity)
                Dim RecPersiana As New RectangleF(SupLeft, Tama駉Persiana)
                _graphics.FillRectangle(_brush, RecPersiana)
            Next
            RefreshDispCtrl()

            'Aumentamos el tama駉 de cada persiana para la pr髕ima vez que se dibujen
            If effect = effect.Blinds_Horizontal_Down Then
                _Aumento += CSng(_imageHeight / Velocity)
            ElseIf effect = effect.Blinds_Horizontal_Up Then
                _Aumento -= CSng(_imageHeight / Velocity)
            End If
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity + 1 veses terminamos el effect
            If _counter = _velocity / 50 + 1 Then
                UnloadObjs()
            End If
        End Sub

        'Genera los Effect con Persianas Vertical
        Private Sub Blinds_Vertical(ByVal effect As Effect)

            Dim Persiana As Integer
            Dim TotalPersianas As Integer = 15
            Dim Velocity As Integer = CInt(TotalPersianas * (_velocity / 50))
            'Si es la primera vez que se llega aqu? establecemos algunas variables
            If _counter = 0 Then
                If effect = effect.Blinds_Vertical_Right Then
                    _Aumento = 0
                ElseIf effect = effect.Blinds_Vertical_Left Then
                    _Aumento = _imageWidth / TotalPersianas
                End If
            End If

            For Persiana = 0 To TotalPersianas - 1
                'Dibuja un trozo de cada una de las persianas por cada ejecuci髇 del evento
                Dim SupLeft As New PointF(_Aumento + (Persiana * (_imageWidth / TotalPersianas)), 0)
                Dim Tama駉Persiana As New SizeF(_imageWidth / Velocity, _imageHeight)
                Dim RecPersiana As New RectangleF(SupLeft, Tama駉Persiana)
                _graphics.FillRectangle(_brush, RecPersiana)
            Next
            RefreshDispCtrl()
            'Aumentamos el tama駉 de cada persiana para la pr髕ima vez que se dibujen
            If effect = effect.Blinds_Vertical_Right Then
                _Aumento += _imageWidth / Velocity
            ElseIf effect = effect.Blinds_Vertical_Left Then
                _Aumento -= _imageWidth / Velocity
            End If
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity + 1 veses terminamos el effect
            If _counter = _velocity / 50 + 1 Then
                UnloadObjs()
            End If
        End Sub

        'Genera el effect de Clock
        Private Sub Clock(ByVal effect As Effect)
            'La diagonal de la im醙en va a ser el diametro. 
            'La calculamos por Pitagoras.
            Dim Diagonal As Single = CSng(Math.Pow((_imageHeight ^ 2) + (_imageWidth ^ 2), 1 / 2))
            'isNegative: indica la direcci髇 del giro
            Dim isNegative As Integer

            If effect = effect.Clock Then
                isNegative = 1
            ElseIf effect = effect.Clock_CCW Then
                isNegative = -1
            End If
            'Llenamos una torta con Centre en el Centre del Control,
            'con la Texture de la im醙en original,
            'agregandole trozos de _AngleChg
            _graphics.FillPie(_brush, CSng(-(Diagonal - _imageWidth) / 2), CSng(-(Diagonal - _imageHeight) / 2), Diagonal,
                              Diagonal, -90, isNegative * _AngleChg)
            'Mostramos el trozo actual
            RefreshDispCtrl()
            _AngleChg += CSng(360 / (_velocity / 50))
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity + 1
            'veses terminamos el effect
            If _counter = _velocity / 50 + 1 Then
                UnloadObjs()
            End If
        End Sub

        'Genera los Effect de Hinge
        Private Sub Hinge(ByVal effect As Effect)
            'intAngulo: angulo de giro progresivo
            Dim intAngulo As Single = CSng(90 / (_velocity / 50))

            If _counter = 0 Then
                'Si es la primera vez que se llega aqu?iniciamos variables dependiendo
                'de el tipo de effect
                If effect = effect.Hinge_Left_CCW Then
                    _AngleChg = 90.0F
                    _Aumento = -1
                    _xAumentaPos = 0
                    _yAumentaPos = 0
                ElseIf effect = effect.Hinge_Left_CW Then
                    _AngleChg = -90.0F
                    _Aumento = 1
                    _xAumentaPos = 0
                    _yAumentaPos = 0
                ElseIf effect = effect.Hinge_Right_CCW Then
                    _bmpTexture.RotateFlip(RotateFlipType.RotateNoneFlipXY)
                    IniTextureBrush()
                    _AngleChg = 270
                    _Aumento = -1
                    _xAumentaPos = _imageWidth - 1
                    _yAumentaPos = _imageHeight - 1
                ElseIf effect = effect.Hinge_Right_CW Then
                    _bmpTexture.RotateFlip(RotateFlipType.RotateNoneFlipXY)
                    IniTextureBrush()
                    _AngleChg = -270.0F
                    _Aumento = 1
                    _xAumentaPos = _imageWidth - 1
                    _yAumentaPos = _imageHeight - 1
                End If
                'Movemos el Centre del eje de coordenadas la primera vez
                'que se ejecuta el evento, para que la Image se dibuje pero no se vea
                _graphics.TranslateTransform(_xAumentaPos, _yAumentaPos)
                'Tambien aplicamos la rotaci髇 adecuada al objeto _Graphics
                _graphics.RotateTransform(_AngleChg)
            End If
            'Dibujamos la Image con las transformaci髇es de _Axles. 
            Dim RecEmpuja As New RectangleF(0, 0, _imageWidth, _imageHeight)
            _graphics.Clear(_fillColor)
            _graphics.FillRectangle(_brush, RecEmpuja)
            'Refrescamos el Control de la Image
            RefreshDispCtrl()
            'Rotamos la Image progresivamente
            _graphics.RotateTransform(_Aumento * intAngulo)
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Para asegurarnos de que la Image de 1/2 vuelta, terminamos el effect cuando _Counter = 90
            'o sea ...
            If _counter = CInt(90 / intAngulo) + 1 Then
                'Restablecemos la Image a su estado original antes de  descargar objetos
                If (effect = effect.Hinge_Right_CW) OrElse (effect = effect.Hinge_Right_CCW) _
                    Then _bmpTexture.RotateFlip(RotateFlipType.RotateNoneFlipXY)
                UnloadObjs()
            End If
        End Sub

        'Genera los effect con m鷏tiples _Axles
        Private Sub WheelMultiple(ByVal effect As Effect)

            Dim AngInitial, Paso, _Axles As Integer
            'Establecemos variables seg鷑 la variante del effect seleccionados
            Select Case effect
                Case effect.Wheel_2_Axles
                    AngInitial = -90
                    Paso = 180
                    _Axles = 2
                Case effect.Wheel_3_Axles
                    AngInitial = -90
                    Paso = 120
                    _Axles = 3
                Case effect.Wheel_4_Axles
                    AngInitial = 0
                    Paso = 90
                    _Axles = 4
                Case effect.Wheel_8_Axles
                    AngInitial = 0
                    Paso = 45
                    _Axles = 8
            End Select

            'La diagonal de la im醙en va a ser el diametro. 
            'La calculamos por Pitagoras.
            Dim Diagonal As Single = CSng(Math.Pow((_imageHeight ^ 2) + (_imageWidth ^ 2), 1 / 2))
            Dim i As Integer
            'Llenamos una torta con Centre en el Centre del Control,
            'con la Texture de la im醙en original,
            'agregandole trozos de _AngleChg
            Dim _
                Rec As _
                    New Rectangle(CInt(-(Diagonal - _imageWidth) / 2), CInt(-(Diagonal - _imageHeight) / 2), CInt(Diagonal),
                                  CInt(Diagonal))

            For i = 1 To _Axles
                _graphics.FillPie(_brush, Rec, AngInitial, _AngleChg)
                AngInitial += Paso
            Next
            _AngleChg += CSng(Paso / (_velocity / 50))
            'Mostramos los trozos actuales
            RefreshDispCtrl()
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity + 1
            'veses terminamos el effect
            If _counter = _velocity / 50 + 1 Then
                UnloadObjs()
            End If
        End Sub

        'Genera los Effect de Simetr韆
        Private Sub Symmetric(ByVal effect As Effect)
            'La diagonal de la im醙en va a ser el diametro. 
            'La calculamos por Pitagoras.
            Dim Diagonal As Single = CSng(Math.Pow((_imageHeight ^ 2) + (_imageWidth ^ 2), 1 / 2))
            Dim AngInitial As Integer
            'Iniciamos variables seg鷑 el effect seleccionado
            If effect = effect.Symmetric_Down Then
                AngInitial = -90
            ElseIf effect = effect.Symmetric_Up Then
                AngInitial = 90
            ElseIf effect = effect.Symmetric_Right Then
                AngInitial = 180
            ElseIf effect = effect.Symmetric_Left Then
                AngInitial = 0
            End If
            'Llenamos una torta con Centre en el Centre de _bmpDraw,
            'con la Texture de la im醙en original,
            'agregandole trozos de _AngleChg
            Dim _
                rec As _
                    New Rectangle(CInt(-(Diagonal - _imageWidth) / 2), CInt(-(Diagonal - _imageHeight) / 2), CInt(Diagonal),
                                  CInt(Diagonal))

            _graphics.FillPie(_brush, rec, AngInitial, _AngleChg)
            _graphics.FillPie(_brush, rec, AngInitial, -_AngleChg)

            _AngleChg += CSng(180 / (_velocity / 50))
            'Mostramos los trozos actuales
            RefreshDispCtrl()
            'Contamos las veces que se ejecut?este evento
            _counter += 1
            'Cuando el evento se halla ejecutado _Velocity + 1
            'veses terminamos el effect
            If _counter = _velocity / 50 + 1 Then
                UnloadObjs()
            End If
        End Sub

        'Arreglo que se va a usar para contar los enteros pares generados por DameParUnico
        Private Rango() As Integer = {}
        'Genera y devuelve 'TotalCoordBars' enteros positivos pares (de a uno) 
        'entre 0 y intMaximo (incluido el cero) de forma aleatoria y sin repetir 
        Private Function DameParUnico(ByVal intMaximo As Integer, ByVal TotalCoordBars As Integer) As Integer
            'r: para generar los n鷐eros de forma aleatoria
            Dim r As New Random
            'i: contiene cada n鷐ero que se genera
            Dim i As Integer
            Static j As Integer = 0
            'Para saber si ya salio el cero 
            Static CeroYaSalio As Boolean = False

            If j = 0 Then
                'La primera vez redimensionamos el arreglo 'Rango' que contendr?los enteros
                ReDim Rango(TotalCoordBars)
            ElseIf j = TotalCoordBars Then
                'Cuando se llene el arreglo, reiniciamos variables y lo indicamos devolviendo -1
                j = 0
                CeroYaSalio = False
                Return -1
            End If

            Do
                i = r.Next(intMaximo)
                If i > 0 Then
                    'Si i es par...
                    If i Mod 2 = 0 Then
                        '... y no esta en el arreglo... 
                        If Array.IndexOf(Rango, i) = -1 Then
                            '... lo agregamos en Rango y lo devolvemos
                            j += 1
                            Rango.SetValue(i, j - 1)
                            Return Rango(j - 1)
                        End If
                    End If
                ElseIf Not CeroYaSalio Then
                    'Agregamos el cero en el arreglo y lo devolvemos
                    j += 1
                    Rango.SetValue(i, j - 1)
                    CeroYaSalio = True
                    Return Rango(j - 1)
                End If
            Loop Until j = TotalCoordBars
            Return Nothing
        End Function

#End Region

#End Region
#Region "Destroyers"

        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If Not Me._disposed Then
                If Not _bmpTexture Is Nothing Then
                    _bmpTexture.Dispose()
                End If
                If Not _bmpDraw Is Nothing Then _bmpDraw.Dispose()
                _timer.Dispose()
                Me._disposed = True
            End If
        End Sub


#End Region
    End Class
End Namespace