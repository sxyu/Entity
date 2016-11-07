Imports System.Xml
Namespace _4Classes.Project
    Public Class SettingsReader
        Private _xml As New XmlDocument
        Private _path As String
        Public ReadOnly Property Path As String
            Get
                Return Path
            End Get
        End Property
        Public Sub New(path As String)
            _path = path
            _xml.Load(path)
        End Sub
        Public Function GetSettingsInSection(sect As String) As List(Of String)
            Dim s As XmlElement = getChild("Section", sect.ToLower())
            Dim l As New List(Of String)
            If s Is Nothing Then
                s = _xml.CreateElement("Section")
                Dim n As XmlElement = _xml.CreateElement("Name")
                n.InnerText = sect
                _xml.DocumentElement.AppendChild(s)
                s.AppendChild(n)
                Save()
            ElseIf s.ChildNodes.Count > 0 Then
                For i As Integer = 1 To s.ChildNodes.Count - 1
                    Dim item As XmlElement = s.ChildNodes(i)
                    If item.ChildNodes.Count > 0 Then
                        l.Add(item.FirstChild.InnerText)
                    End If
                Next
            End If
            Return l
        End Function
        Public Sub ClearSection(sect As String, Optional saveAfter As Boolean = True)
            Dim s As XmlElement = getChild("Section", sect.ToLower())
            If s Is Nothing Then
                s = _xml.CreateElement("Section")
            Else
                s.RemoveAll()
            End If
            Dim n As XmlElement = _xml.CreateElement("Name")
            n.InnerText = sect
            _xml.DocumentElement.AppendChild(s)
            s.AppendChild(n)
            If saveAfter Then Save()
        End Sub
        'Public Function GetSettingsInSectionXML(sect As String) As List(Of XmlElement)
        '    Dim s As XmlElement = getChild("Section", sect.ToLower())
        '    If s Is Nothing Then
        '        s = _xml.CreateElement("Section")
        '        Dim n As XmlElement = _xml.CreateElement("Name")
        '        n.InnerText = sect
        '        _xml.DocumentElement.AppendChild(s)
        '        s.AppendChild(n)
        '        Save()
        '    ElseIf s.ChildNodes.Count > 0 Then
        '        Return New List(Of XmlElement)(s.ChildNodes)
        '    End If
        'End Function
        Public Function GetSetting(sect As String, name As String) As String
            Dim s As XmlElement = getChild("Section", sect.ToLower())
            If s Is Nothing Then
                SetSetting(sect, name, "")
                Save()
            Else
                Dim item As XmlElement = getChild("Setting", name.ToLower, s)
                If item IsNot Nothing Then
                    Dim field As XmlElement = getChild("Content", "", item)
                    If field IsNot Nothing Then Return field.InnerText
                End If
            End If
            Return ""
        End Function
        Public Sub SetSetting(sect As String, name As String, content As String, Optional saveAfter As Boolean = True)
            Dim s As XmlElement = getChild("Section", sect.ToLower())
            If s Is Nothing Then
                s = _xml.CreateElement("Section")
                Dim n As XmlElement = _xml.CreateElement("Name")
                n.InnerText = sect
                _xml.DocumentElement.AppendChild(s)
                s.AppendChild(n)
            End If

            Dim item As XmlElement = getChild("Setting", name.ToLower, s)
            If item Is Nothing Then
                item = _xml.CreateElement("Setting")
                Dim n As XmlElement = _xml.CreateElement("Name")
                n.InnerText = name
                Dim c As XmlElement = _xml.CreateElement("Content")
                c.InnerText = content
                s.AppendChild(item)
                item.AppendChild(n)
                item.AppendChild(c)
            Else
                Dim field As XmlElement = getChild("Content", "", item)
                If field IsNot Nothing Then field.InnerText = content
            End If
            If saveAfter Then
                Save()
            End If
        End Sub
        Public Sub RenameSetting(sect As String, name As String, newname As String)
            Dim s As XmlElement = getChild("Section", sect.ToLower())
            If s IsNot Nothing Then
                Dim item As XmlElement = getChild("Setting", name.ToLower, s)
                If item IsNot Nothing Then
                    Dim field As XmlElement = getChild("Name", "", item)
                    If field IsNot Nothing Then field.InnerText = newname
                    Save()
                End If
            End If
        End Sub
        Public Function DeleteSetting(sect As String, name As String) As Boolean
            Dim s As XmlElement = getChild("Section", sect.ToLower())
            If s IsNot Nothing Then
                Dim item As XmlElement = getChild("Setting", name.ToLower, s)
                If item IsNot Nothing Then
                    s.RemoveChild(item)
                    Save()
                    Return True
                End If
            End If
            Return False
        End Function
        Public Sub Save()
            _xml.Save(_path)
        End Sub
        Private Function getChild(tagname As String, Optional name As String = "", Optional document As XmlNode = Nothing) As XmlElement
            If document Is Nothing Then document = _xml.DocumentElement
            For Each c As XmlElement In document.ChildNodes
                If c.Name.ToLower = tagname.ToLower Then
                    If String.IsNullOrEmpty(name) Then
                        Return c
                    Else
                        If c.ChildNodes.Count > 0 AndAlso c.FirstChild.InnerText.ToLower = name.ToLower Then
                            Return c
                        End If
                    End If
                End If
            Next
            Return Nothing
        End Function
    End Class
End Namespace
