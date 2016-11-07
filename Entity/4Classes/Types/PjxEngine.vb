Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Timers

'I didn't create this class myself -- I got this class from a spanish programmer
'although I heavily modified it.
'Many of the var names and comments have not been translated from Spanish. Sorry for the mess.
Namespace _4Classes.Types

    Public Class PjxEngine
        Implements IDisposable

        'Event EffectEnded: triggers when effect ends
        Public Event EffectEnded As EventHandler

#Region "Enumerations"

        'Enumeration of Effects
        Public Enum Effect
            Appear
            Fade_In
            Fan_Right
            Fan_Left
            Bars_Horizontal
            Bars_Vertical
            Sweep_Horizontal
            Sweep_Vertical
            Circle_In
            Circle_Out
            Expand_Centre
            Expand_Bottom_Right
            Expand_Bottom_Left
            Expand_Top_Right
            Expand_Top_Left
            Diagonal
            Division_Horizontal_In
            Division_Horizontal_Out
            Division_Vertical_In
            Division_Vertical_Out
            Division_Push_In_Horizontal
            Division_Push_In_Vertical
            Push_Down
            Push_Up
            Push_Left
            Push_Right
            Push_Diagonal_Bottom_Right
            Push_Diagonal_Bottom_Left
            Push_Diagonal_Top_Right
            Push_Diagonal_Top_Left
            Stretch_Centre
            Stretch_Bottom_Right
            Stretch_Bottom_Left
            Stretch_Top_Right
            Stretch_Top_Left
            Spin_Centre
            Spin_Spiral_Down
            Spin_Spiral_Up
            Blinds_Horizontal_Down
            Blinds_Horizontal_Up
            Blinds_Vertical_Left
            Blinds_Vertical_Right
            Clock
            Clock_CCW
            Hinge_Right_CW
            Hinge_Right_CCW
            Hinge_Left_CCW
            Hinge_Left_CW
            Wheel_2_Axles
            Wheel_3_Axles
            Wheel_4_Axles
            Wheel_8_Axles
            Symmetric_Down
            Symmetric_Up
            Symmetric_Left
            Symmetric_Right
        End Enum

#End Region

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
        Private _disposed As Boolean = False
        'Last progress value
        Private _prevProg As Double

#Region " Variables especificas de algunos Effect "

        Private _AngleChg As Single
        Private _xAumentaPos, _yAumentaPos As Single
        Private _Aumento As Single
        Private _AppearDone As Boolean

#End Region

#End Region

#Region "Public Methods"
        Protected Sub New()
            'default constructor left empty
        End Sub
        Public Sub New(ByVal ImagePath As String, ByVal Control As Control, ByVal strProperty As String,
                       Optional ByVal intVelocity As Integer = 20)
            Try
                _bmpTexture = _3Modules.Images.GetThumbnail(ImagePath, Control.Width, Control.Height, Color.Transparent)
                Initialize(Control, intVelocity, strProperty)
            Catch ex As Exception When Not Directory.Exists(ImagePath)
                MessageBox.Show("The image path is invalid")
            Catch ex As Exception When _bmpTexture Is Nothing
                MessageBox.Show("The image cannot be null")
            End Try
        End Sub

        Public Sub New(ByVal Image As Image, ByVal Control As Control, ByVal strProperty As String,
                       Optional ByVal intVelocity As Integer = 20)
            Try
                _bmpTexture = _3Modules.Images.GetThumbnail(Image, Control.Width, Control.Height, Color.Transparent)
                Initialize(Control, intVelocity, strProperty)
            Catch ex As Exception When _bmpTexture Is Nothing
                MessageBox.Show("The image cannot be null")
            End Try
        End Sub
        Public Sub Reset()
            If Not _disposed Then
                _prevProg = 0
                'Reset Variables
                _AppearDone = False
                _Aumento = 0
                _AngleChg = 0
                _xAumentaPos = 0
                _yAumentaPos = 0
            End If
        End Sub
        'Set the effect
        Public Overloads Sub SetEffect(ByVal effect As Effect)
            If Not _disposed Then
                _effect = effect
                SetObjects()
            Else
                Throw _
                    New ObjectDisposedException("",
                                                "Cannot access a disposed PjxEngine object.")
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
            'Set up controller timer tick event
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
            'Start graphics object
            _graphics = Graphics.FromImage(_bmpDraw)
            Select Case _effect
                Case Effect.Fade_In, Effect.Stretch_Centre To Effect.Spin_Spiral_Up, Effect.Hinge_Right_CW,
                    Effect.Hinge_Right_CCW, Effect.Appear
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
            '_graphics.Clear(_fillColor)
            'Reset Variables
            _AppearDone = False
            _Aumento = 0
            _AngleChg = 0
            _xAumentaPos = 0
            _yAumentaPos = 0
            'Catch ex As Exception When _bmpDraw Is Nothing
            '    Throw New NullReferenceException("The image to draw the transition onto is null")
            'End Try
        End Sub

        'Inicializa el objeto TextureBrush
        Private Sub IniTextureBrush()
            _brush = New TextureBrush(_bmpTexture)
        End Sub

        'Set to position at the specified time
        Public Sub SetTime(ByVal time As Integer)
            Try
                'percent progress
                Dim prog As Double = time / _velocity
                If prog = _prevProg Then Exit Sub

                If _effect = Effect.Appear Then
                    Appear()
                    Exit Sub
                End If
                'If _effect <> Effect.Fade_In AndAlso _effect <> Effect.Stretch_Centre AndAlso _effect <> Effect.Spin_Spiral_Up _
                '    AndAlso _effect <> Effect.Hinge_Right_CW AndAlso _effect <> Effect.Hinge_Right_CCW Then
                '    If _brush Is Nothing Then Exit Sub
                'End If
                Select Case _effect
                    Case Effect.Fade_In
                        Fade_In(prog)
                    Case Effect.Fan_Right, Effect.Fan_Left
                        Fan(_effect, prog)
                    Case Effect.Bars_Horizontal, Effect.Bars_Vertical
                        Bars(_effect, prog)
                    Case Effect.Sweep_Horizontal, Effect.Sweep_Vertical
                        Sweep(_effect, prog)
                    Case Effect.Circle_Out
                        Circle_Out(prog)
                    Case Effect.Circle_In
                        Circle_In(prog)
                    Case Effect.Expand_Centre To Effect.Expand_Top_Left, Effect.Stretch_Centre To Effect.Stretch_Top_Left
                        Expand_Stretch(_effect, prog)
                    Case Effect.Diagonal
                        Diagonal(prog)
                    Case Effect.Division_Horizontal_In, Effect.Division_Horizontal_Out
                        DivisionH(_effect, prog)
                    Case Effect.Division_Vertical_In, Effect.Division_Vertical_Out
                        DivisionV(_effect, prog)
                    Case Effect.Push_Down To Effect.Push_Diagonal_Top_Left
                        Push(_effect, prog)
                    Case Effect.Spin_Centre To Effect.Spin_Spiral_Up
                        Spin(_effect, prog)
                    Case Effect.Blinds_Horizontal_Down, Effect.Blinds_Horizontal_Up
                        Blinds_Horizontal(_effect, prog)
                    Case Effect.Blinds_Vertical_Left, Effect.Blinds_Vertical_Right
                        Blinds_Vertical(_effect, prog)
                    Case Effect.Clock, Effect.Clock_CCW
                        Clock(_effect, prog)
                    Case Effect.Symmetric_Down To Effect.Symmetric_Right
                        Symmetric(_effect, prog)
                    Case Effect.Wheel_2_Axles To Effect.Wheel_8_Axles
                        WheelMultiple(_effect, prog)
                    Case Effect.Division_Push_In_Horizontal, Effect.Division_Push_In_Vertical
                        PushDivision(_effect, prog)
                    Case Effect.Hinge_Right_CW To Effect.Hinge_Left_CW
                        Hinge(_effect, prog)
                End Select
                _prevProg = prog
                If prog > 1 Then UnloadObjs()
            Catch ex As Exception
                MsgBox(ex.ToString, , "Projection Engine Error")
                Throw New Exception(ex.ToString)
            End Try
        End Sub

        'Descarga objetos y detiene el Timer
        Private Sub UnloadObjs()
            If _graphics IsNot Nothing Then _graphics.Dispose()
            If _brush IsNot Nothing Then _brush.Dispose()
            'False para indicar que el effect acaba de terminar
            _AngleChg = 0
            _prevProg = 0

            'El effect termin? disparamos un evento para indicarlo
            RaiseEvent EffectEnded(Me, New EventArgs)
        End Sub

        'Ensure that the velocity value is valid
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
            If _dispControl IsNot Nothing Then
                SyncLock _dispControl

                    _dispControl.Invalidate()
                End SyncLock
            End If
            'If _DispControl.InvokeRequired Then
            '    _DispControl.BeginInvoke(New MethodInvoker(Sub()

            '                                               End Sub))
            'Else
            '    _DispControl.Invalidate()
            'End If
        End Sub
        Private Sub Appear()
            If Not _AppearDone Then
                _graphics.DrawImage(_bmpTexture, 0, 0, _imageWidth, _imageHeight)
                RefreshDispCtrl()
                _AppearDone = True
            End If
        End Sub
        'Generate fade in effect
        Private Sub Fade_In(ByVal prog As Double)
            Try
                SyncLock (_dispControl)
                    Static Opacity As Single = 0.0F
                    Dim FadeVelocity As Single = 0.0F
                    FadeVelocity = CSng(1 * _velocity)
                    _graphics.Clear(_fillColor)
                    Dim Cm As ColorMatrix = New ColorMatrix
                    Dim Ia As ImageAttributes = New ImageAttributes
                    Opacity = prog
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
                    End If
                End SyncLock
            Catch
            End Try
        End Sub


        'Fan effects
        Private Sub Fan(ByVal effect As Effect, ByVal prog As Double)
            Dim Radio As Single = CSng(Math.Pow(((_imageWidth / 2) ^ 2) + (_imageHeight ^ 2), 1 / 2))
            Dim AngInitial, isNegative As Integer

            If effect = effect.Fan_Right Then
                AngInitial = 180
                isNegative = 1
            ElseIf effect = effect.Fan_Left Then
                AngInitial = 0
                isNegative = -1
            End If
            Dim _
                Rec As _
                    New Rectangle(CInt(-(Radio - (_imageWidth / 2))), CInt(-(Radio - _imageHeight)), CInt(Radio * 2),
                                  CInt(Radio * 2))
            _AngleChg = CSng(180 * prog)
            _graphics.FillPie(_brush, Rec, AngInitial, isNegative * _AngleChg)

            RefreshDispCtrl()
        End Sub

        'Bar effects
        Private Sub Bars(ByVal effect As Effect, ByVal prog As Double)
            Dim i, j, SzImage, X, Y, Width, Height As Integer
            Dim Iterations As Integer
            Dim Max As Integer

            'Init variables based on effect
            If effect = effect.Bars_Horizontal Then
                Width = CInt(_imageWidth)
                Height = 2
                SzImage = CInt(_imageHeight)
            ElseIf effect = effect.Bars_Vertical Then
                Width = 2
                Height = CInt(_imageHeight)
                SzImage = CInt(_imageWidth)
            End If
            'the number of times to paint random bars
            'SzImage/2 is the total number of bars and
            'prog - _prevProg is the fractional change in progress
            Iterations = CInt(Math.Ceiling(SzImage / 2 * (prog - _prevProg)))

            For i = 0 To Iterations - 1
                j = DameParUnico(CInt(SzImage - 2), CInt(SzImage / 2) - 1)
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
                _graphics.FillRectangle(_brush, New Rectangle(X, Y, Width, Height))
            Next
            'Refrescamos el Control de la Image
            RefreshDispCtrl()
        End Sub

        'Sweep effects
        Private Sub Sweep(ByVal effect As Effect, ByVal prog As Double)

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

            If _prevProg = 0 Then
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
                Dim TamaPersiana As New SizeF(AnchoPersiana, AltoPersiana)

                If Persiana Mod 2 = 0 Then
                    Dim RecSweepPar As New RectangleF(SupLeft, TamaPersiana)
                    _graphics.FillRectangle(_brush, RecSweepPar)
                Else
                    Dim RecSweepImpar As New RectangleF(SupLeft, TamaPersiana)
                    Gr2.FillRectangle(_brush, RecSweepImpar)
                End If
            Next
            'Transladamos los _Axles progresivamente
            Dim delta As Double = prog - _prevProg
            _graphics.TranslateTransform(CSng(-_xAumentaPos * delta), CSng(-_yAumentaPos * delta)) 'Velocity
            Gr2.TranslateTransform(CSng(_xAumentaPos * delta), CSng(_yAumentaPos * delta))
            'Refrescamos el Control
            RefreshDispCtrl()
            'Cuando el evento se halla ejecutado _Velocity + 1
            'veses terminamos el effect
            If prog > 1 Then
                Gr2.Dispose()
                xEsquinaPersiana = 0
                yEsquinaPersiana = 0
                AnchoPersiana = 0
                AltoPersiana = 0
            End If
        End Sub
        'Circle in effect
        Private Sub Circle_In(ByVal prog As Double)
            Dim Diameter As Single
            Static RecAnterior As RectangleF
            Dim Diagonal As Single = CSng(Math.Pow((_imageHeight ^ 2) + (_imageWidth ^ 2), 1 / 2))
            Diameter = CSng(Diagonal * (1 - prog))
            Dim xEsquina As Single = (_imageWidth / 2) - (Diameter / 2)
            Dim yEsquina As Single = (_imageHeight / 2) - (Diameter / 2)
            Dim Rect As New RectangleF(New PointF(xEsquina, yEsquina), New SizeF(Diameter, Diameter))

            If _prevProg > 0 Then
                Dim Trayecto1 As New GraphicsPath
                Trayecto1.AddEllipse(RecAnterior)
                Dim Trayecto2 As New GraphicsPath
                Trayecto2.AddEllipse(Rect)
                Dim Reg As New Region(Trayecto2)
                Reg.Xor(Trayecto1)
                _graphics.FillRegion(_brush, Reg)
                RefreshDispCtrl()
            End If
            'Recordamos el 鷏timo rectangulo que se uso para Draw el 鷏timo circulo
            RecAnterior = Rect
            'terminamos el effect
            If prog > 1 Then
                RecAnterior = Nothing
            End If
        End Sub

        'Genera el effect con Circle hacia Up
        Private Sub Circle_Out(ByVal prog As Double)
            'El diametro de los Circle
            Static Diametro As Single
            'La calculamos por Pitagoras.
            Dim Diagonal As Single = CSng(Math.Pow((_imageHeight ^ 2) + (_imageWidth ^ 2), 1 / 2))
            Dim xEsquina As Single = (_imageWidth / 2) - (Diametro / 2)
            Dim yEsquina As Single = (_imageHeight / 2) - (Diametro / 2)
            Dim MiPunto As New PointF(xEsquina, yEsquina)
            Dim Rect As New RectangleF(MiPunto, New SizeF(Diametro, Diametro))
            _graphics.FillEllipse(_brush, Rect)
            RefreshDispCtrl()
            Diametro += CSng(Diagonal * (prog - _prevProg))
            If prog > 1 Then
                Diametro = 0
            End If
        End Sub

        'Genera los Effect de despliegue y estiramiento
        Private Sub Expand_Stretch(ByVal effect As Effect, ByVal prog As Double)
            Dim X, Y, Ancho, Alto As Single

            _Aumento += CSng(prog - _prevProg)
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
        End Sub

        'Generates the effect on Diagonal from the top left corner
        Private Sub Diagonal(ByVal prog As Double)
            'Aumentamos los Horizontal del tri醤gulo
            Dim delta As Double = prog - _prevProg
            _xAumentaPos += CSng(_imageWidth * delta) * 2
            _yAumentaPos += CSng(_imageHeight * delta) * 2
            'Dibujanos el tri醤gulo actual
            _graphics.FillPolygon(_brush,
                                  New PointF() {New PointF(0, 0), New PointF(_xAumentaPos, 0), New PointF(0, _yAumentaPos)})
            'Actualizamos el dibujo
            RefreshDispCtrl()
        End Sub

        'Horizontal division effect
        Private Sub DivisionH(ByVal effect As Effect, ByVal prog As Double)

            Dim Velocity As Single = CSng(_imageWidth * (prog - _prevProg))
            'Si es la primera vez que se llega aqu? establecemos algunas variables
            If _prevProg = 0 Then
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
        End Sub

        'Vertical division effect
        Private Sub DivisionV(ByVal effect As Effect, ByVal prog As Double)

            Dim Velocity As Single = CSng(_imageHeight * (prog - _prevProg))
            'Si es la primera vez que se llega aqu? establecemos algunas variables
            If _prevProg = 0 Then
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
        End Sub

        'Push effect
        Private Sub Push(ByVal effect As Effect, ByVal prog As Double)
            'Si es la primera vez que se llega aqu? 
            'Establecemos las transformaci髇es iniciales
            'seg鷑 la variante de effect de Empuje
            If _prevProg = 0 Then
                'note: the ':' char is the inline operator 
                If effect = effect.Push_Down Then
                    _graphics.TranslateTransform(0, -_imageHeight)
                ElseIf effect = effect.Push_Up Then
                    _graphics.TranslateTransform(0, _imageHeight)
                ElseIf effect = effect.Push_Right Then
                    _graphics.TranslateTransform(-_imageWidth, 0)
                ElseIf effect = effect.Push_Left Then
                    _graphics.TranslateTransform(_imageWidth, 0)
                ElseIf effect = effect.Push_Diagonal_Top_Left Then
                    _graphics.TranslateTransform(-_imageWidth, -_imageHeight)
                ElseIf effect = effect.Push_Diagonal_Top_Right Then
                    _graphics.TranslateTransform(_imageWidth, -_imageHeight)
                ElseIf effect = effect.Push_Diagonal_Bottom_Left Then
                    _graphics.TranslateTransform(-_imageWidth, _imageHeight)
                ElseIf effect = effect.Push_Diagonal_Bottom_Right Then
                    _graphics.TranslateTransform(_imageWidth, _imageHeight)
                End If
            End If
            '***** Esto solo es necesario para Imagees con fondo transparente *****
            '_Graphics.Clear(_FillColor)
            '***********************************************************************
            'Dibujamos la Image con las transformaci髇es de _Axles. 
            If effect = effect.Push_Down Then
                _xAumentaPos = 0
                _yAumentaPos = CSng(_imageHeight * (prog - _prevProg))
            ElseIf effect = effect.Push_Up Then
                _xAumentaPos = 0
                _yAumentaPos = CSng(-_imageHeight * (prog - _prevProg))
            ElseIf effect = effect.Push_Right Then
                _xAumentaPos = CSng(_imageWidth * (prog - _prevProg))
                _yAumentaPos = 0
            ElseIf effect = effect.Push_Left Then
                _xAumentaPos = CSng(-(_imageWidth * (prog - _prevProg)))
                _yAumentaPos = 0
            ElseIf effect = effect.Push_Diagonal_Top_Left Then
                _xAumentaPos = CSng(_imageWidth * (prog - _prevProg))
                _yAumentaPos = CSng(_imageHeight * (prog - _prevProg))
            ElseIf effect = effect.Push_Diagonal_Top_Right Then
                _xAumentaPos = CSng(-_imageWidth * (prog - _prevProg))
                _yAumentaPos = CSng(_imageHeight * (prog - _prevProg))
            ElseIf effect = effect.Push_Diagonal_Bottom_Left Then
                _xAumentaPos = CSng(_imageWidth * (prog - _prevProg))
                _yAumentaPos = CSng(-_imageHeight * (prog - _prevProg))
            ElseIf effect = effect.Push_Diagonal_Bottom_Right Then
                _xAumentaPos = CSng(-(_imageWidth * (prog - _prevProg)))
                _yAumentaPos = CSng(-(_imageHeight * (prog - _prevProg)))
            End If
            Dim RecEmpuja As New RectangleF(0, 0, _imageWidth, _imageHeight)
            _graphics.FillRectangle(_brush, RecEmpuja)
            _graphics.TranslateTransform(_xAumentaPos, _yAumentaPos)
            RefreshDispCtrl()
        End Sub

        'Genera los Effect de Empuje con Divisi髇
        Private Sub PushDivision(ByVal effect As Effect, ByVal prog As Double)
            'Creamos el segundo objeto Graphics para Draw en _bmpDraw
            Static Gr2 As Graphics
            Dim Ancho, Alto, xEsquina, yEsquina As Single

            If effect = effect.Division_Push_In_Horizontal Then
                _xAumentaPos = CSng(_imageWidth * (prog - _prevProg) / 2)
                _yAumentaPos = 0
                Ancho = _imageWidth / 2
                Alto = _imageHeight
                xEsquina = Ancho
                yEsquina = 0
            ElseIf effect = effect.Division_Push_In_Vertical Then
                _xAumentaPos = 0
                _yAumentaPos = CSng(_imageHeight * (prog - _prevProg) / 2)
                Ancho = _imageWidth
                Alto = _imageHeight / 2
                xEsquina = 0
                yEsquina = Alto
            End If
            'Si es la primera vez que se llega aqu?
            'Establecemos las transformaci髇es iniciales
            'seg鷑 la variante de effect de Empuje y Divisi髇
            If _prevProg = 0 Then
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
            'Cuando el evento se halla ejecutado _Velocity + 1 veses terminamos el effect
            If prog > 1 Then
                Gr2.Dispose()
            End If
        End Sub

        'm: Matriz que vamos a usar para establecer tranformaciones en algunos Effect
        Private m As Matrix
        'Genera los Effect de giro de la Image con movimiento en Spiral
        Private Sub Spin(ByVal effect As Effect, ByVal prog As Double)
            Dim X, Y, Ancho, Alto As Single

            If _prevProg = 0 Then
                m = New Matrix
                _AngleChg = CInt(360 * (prog - _prevProg))
            End If

            _Aumento += CSng(1 * (prog - _prevProg))

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
            'Para asegurarnos de que la Image de 1 vuelta entera terminamos el effect cuando _Counter = 360,
            'o sea ...
            If prog > 1 Then
                '***** Esto solo es necesario para Imagees con fondo transparente *****
                '_Graphics.Clear(_FillColor)
                '***********************************************************************
                'Rotamos la Image a su posici髇 original y la dibujamos antes de descargar todo
                _graphics.DrawImage(_bmpTexture, 0, 0, _imageWidth, _imageHeight)
                RefreshDispCtrl()
                m.Dispose()
            End If
        End Sub

        'Horizontal blinds effect
        Private Sub Blinds_Horizontal(ByVal effect As Effect, ByVal prog As Double)

            Dim Persiana As Integer
            'Total de Persianas
            Dim TotalPersianas As Integer = 15
            Dim Velocity As Integer = CInt(TotalPersianas / (prog - _prevProg))
            'Si es la primera vez que se llega aqu? establecemos algunas variables
            If _prevProg = 0 Then
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
        End Sub

        'Genera los Effect con Persianas Vertical
        Private Sub Blinds_Vertical(ByVal effect As Effect, ByVal prog As Double)

            Dim Persiana As Integer
            Dim TotalPersianas As Integer = 15
            Dim Velocity As Integer = CInt(TotalPersianas / (prog - _prevProg))
            'Si es la primera vez que se llega aqu? establecemos algunas variables
            If _prevProg = 0 Then
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
        End Sub

        'Genera el effect de Clock
        Private Sub Clock(ByVal effect As Effect, ByVal prog As Double)
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
            SyncLock _graphics
                _graphics.FillPie(_brush, CSng(-(Diagonal - _imageWidth) / 2), CSng(-(Diagonal - _imageHeight) / 2), Diagonal,
                              Diagonal, -90, isNegative * _AngleChg)
            End SyncLock
            'Mostramos el trozo actual
            RefreshDispCtrl()
            _AngleChg += CSng(360 * (prog - _prevProg))
        End Sub

        'Genera los Effect de Hinge
        Private Sub Hinge(ByVal effect As Effect, ByVal prog As Double)
            'intAngulo: angulo de giro progresivo
            Dim intAngulo As Single = CSng(90 * (prog - _prevProg))

            If _prevProg = 0 Then
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
                    _AngleChg = 270.0F
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
            'Para asegurarnos de que la Image de 1/2 vuelta, terminamos el effect cuando _Counter = 90
            'o sea ...
            If prog > 1 Then
                'Restablecemos la Image a su estado original antes de  descargar objetos
                If (effect = effect.Hinge_Right_CW) OrElse (effect = effect.Hinge_Right_CCW) _
                    Then _bmpTexture.RotateFlip(RotateFlipType.RotateNoneFlipXY)
            End If
        End Sub

        'Genera los effect con m鷏tiples _Axles
        Private Sub WheelMultiple(ByVal effect As Effect, ByVal prog As Double)

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
            _AngleChg += CSng(Paso * (prog - _prevProg))
            'Mostramos los trozos actuales
            RefreshDispCtrl()
        End Sub

        'Genera los Effect de Simetr韆
        Private Sub Symmetric(ByVal effect As Effect, ByVal prog As Double)
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

            _AngleChg += CSng(180 * (prog - _prevProg))
            'Mostramos los trozos actuales
            RefreshDispCtrl()
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

#Region "Properties"
        'MISSING: To control a large Property to decide how you will Draw the Image.

        'Effect
        <DefaultValue(GetType(Effect), "Fan_Right"),
            Category("Behavior"),
            Description("Sets the current effect for this object.")>
        Public Property EffectName() As Effect
            Get
                Return _effect
            End Get
            Set(ByVal Value As Effect)
                SetEffect(Value)
            End Set
        End Property
        'EffectVelocity
        <DefaultValue(GetType(Integer), "20"),
            Category("Behavior"),
            Description("Set drawing speed")>
        Public Property EffectVelocity() As Integer
            Get
                Return _velocity
            End Get
            Set(ByVal Value As Integer)
                _velocity = ValidateVelocity(Value)
            End Set
        End Property
        'ColorTrans
        <DefaultValue(GetType(Color), "Transparent"),
            Category("Appearance"),
            Description("Sets the fill color for this object.")>
        Public Property ColorTrans() As Color
            Get
                Return _fillColor
            End Get
            Set(ByVal value As Color)
                _fillColor = value
            End Set
        End Property
        'Image
        <Category("Appearance"),
            Description("Sets the image to use For the selected effect.")>
        Public Property Image() As Image
            Get
                Return _bmpTexture
            End Get
            Set(ByVal value As Image)
                Try
                    _bmpTexture = value
                    _imageWidth = _bmpTexture.Width
                    _imageHeight = _bmpTexture.Height
                    'Hay Imagees que tienen un formato de pixel
                    'que no permite crear un objeto Graphics para Draw sobre
                    'ellas, por eso creamos una copia de la Image, del mismo tama駉
                    'y con un formato de pixel que no de problemas
                    _bmpDraw = New Bitmap(CInt(_imageWidth), CInt(_imageHeight), PixelFormat.Format32bppArgb)
                Catch ex As Exception When value Is Nothing
                    Throw New NullReferenceException("The image can not be null.")
                End Try
            End Set
        End Property

#End Region

#Region "Destroyers"

        Public Overridable Overloads Sub Dispose() Implements IDisposable.Dispose
            UnloadObjs()
            DirectCast(_dispControl, PictureBox).Image = Nothing
            DirectCast(_dispControl, PictureBox).BackgroundImage = Nothing
            Dispose(True)
            'GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Overloads Sub Dispose(ByVal disposing As Boolean)
            If Not Me._disposed Then
                'Ac? limpiamos recursos no administrados de esta clase
                If Not _bmpTexture Is Nothing Then
                    _bmpTexture.Dispose()
                End If
                If Not _bmpDraw Is Nothing Then _bmpDraw.Dispose()
                Me._disposed = True
            End If
        End Sub


#End Region
    End Class
End Namespace