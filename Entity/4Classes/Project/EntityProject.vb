Imports Entity._3Modules.Tabs
Namespace _4Classes.Project
    Public Class EntityProject
        Private _name As String
        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                If Not _name = value Then
                    Dim view As Integer = CurView
                    'dispose all views to make sure the dir is not being used
                    For i As Integer = 0 To ViewCache.Length - 1
                        Try
                            ViewCache(i).Dispose()
                        Catch ex As Exception
                        End Try
                    Next
                    'do the renaming
                    My.Computer.FileSystem.RenameDirectory(_path, value)
                    _path = IO.Path.GetDirectoryName(_path.Trim({"\"c, "/"c})) & "\" & value
                    My.Computer.FileSystem.RenameFile(_path & "\" & _name & ".enproj", value & ".enproj")
                    _name = value
                    Me._settings = New SettingsReader(_path & "\" & _name & ".enproj")
                    're-init views
                    CurView = EntityView.Null
                    InitViews()
                    ChangeView(CType(view, EntityView))
                End If
            End Set
        End Property

        Private _path As String
        Public ReadOnly Property Path As String
            Get
                Return _path
            End Get
        End Property
        Public ReadOnly Property ResPath As String
            Get
                Return _path & "\resources"
            End Get
        End Property
        Public ReadOnly Property ResCachePath As String
            Get
                Return _path & "\resources\0cache"
            End Get
        End Property
        Public ReadOnly Property ResBackPath As String
            Get
                Return _path & "\resources\0backup"
            End Get
        End Property
        Private _settings As SettingsReader
        Public ReadOnly Property Settings As SettingsReader
            Get
                Return _settings
            End Get
        End Property
        Public Sub New(ByVal filepath As String)
            Me._name = IO.Path.GetFileNameWithoutExtension(filepath)
            Me._path = IO.Path.GetDirectoryName(filepath)
            Me._settings = New SettingsReader(filepath)
        End Sub
        Public Sub New(ByVal name As String, ByVal path As String)
            Me._name = name
            Me._path = path
            Me._settings = New SettingsReader(path & "\" & name & ".enproj")
        End Sub
    End Class
End Namespace