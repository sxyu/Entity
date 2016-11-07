Namespace _2Namespaces.ImageIndexer
    Public Class IndexedImage
        Private _mName As String
        Public Property Name As String
            Get
                Return _mName
            End Get
            Set(value As String)
                _mName = value
            End Set
        End Property
        Private m_image As Bitmap
        Public Property Image As Bitmap
            Get
                Return m_image
            End Get
            Set(value As Bitmap)
                m_image = value
            End Set
        End Property

        Public Sub New(ByVal imageName As String, ByVal contentImage As Bitmap)
            Me.Name = imageName
            Me.Image = contentImage
        End Sub
    End Class
    Public Class indexedImageList
        Private _list As New List(Of IndexedImage)
        Private _length As Integer
        Public ReadOnly Property Length As Integer
            Get
                Return _length
            End Get
        End Property
        Public Function toArray() As IndexedImage()
            Return _list.ToArray
        End Function
        Public Function Items() As List(Of IndexedImage)
            Return _list
        End Function
        Public Sub Add(ByVal name As String, ByVal image As Bitmap)
            _list.Add(New IndexedImage(name, image))
            _length = _list.Count
        End Sub
        Public Overloads Sub Clear()
            _list.Clear()
            _length = _list.Count
        End Sub
        Public Overloads Sub RemoveAt(ByVal index As Integer)
            _list.RemoveAt(index)
            _length = _list.Count
        End Sub
        Public Sub RemoveByName(ByVal name As String)
            For Each i As IndexedImage In _list
                If i.Name = name Then
                    _list.Remove(i)
                    Exit For
                End If
            Next
            _length = _list.Count
        End Sub
        Public Sub ChangeKey(ByVal name As String, ByVal newName As String)
            For Each i As IndexedImage In _list
                If i.Name = name Then
                    i.Name = newName
                    Exit For
                End If
            Next
            _length = _list.Count
        End Sub
        Public Function GetImageByName(ByVal name As String) As Bitmap
            Dim ret As New Bitmap(1, 1)
            For Each i As IndexedImage In _list
                If i.Name = name Then
                    ret = New Bitmap(i.Image)
                    Exit For
                End If
            Next
            _length = _list.Count
            Return ret
        End Function
        Public Function GetImageAt(ByVal index As Integer) As Bitmap
            _length = _list.Count
            Return New Bitmap(_list(index).Image)
        End Function
        Public Sub AddRange(ByVal items As IndexedImage())
            _list.AddRange(items)
            _length = _list.Count
        End Sub
        Public Sub Remove(ByVal item As IndexedImage)
            _list.Remove(item)
            _length = _list.Count
        End Sub

        Public Sub New()
            _list = New List(Of IndexedImage)
        End Sub

    End Class

End Namespace