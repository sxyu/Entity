Imports System.IO
Imports Entity._3Modules

Namespace _4Classes.Project
    Public Class WorkingDirectory
        Private _path As String
        Public ReadOnly Property Path
            Get
                Return _path
            End Get
        End Property
        Public Sub New(path As String)
            Me._path = path
        End Sub
        Public Function GetProjects() As List(Of EntityProject)
            Dim toRet As New List(Of EntityProject)
            Dim di As New DirectoryInfo(CurWorkDir.Path)
            Dim dia As DirectoryInfo() = di.GetDirectories
            For Each d As DirectoryInfo In dia
                If (File.Exists(d.FullName & "\" & d.Name & ".enproj")) Then
                    toRet.Add(New EntityProject(d.FullName & "\" & d.Name & ".enproj"))
                End If
            Next
            Return toRet
        End Function
    End Class
End Namespace
