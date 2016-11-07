Imports System.Text
Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Namespace _3Modules
    Module Settings
        ''' <summary>
        '''     gets all fields in a entity settings file.
        ''' </summary>
        ''' <param name="file">file to get settings from</param>
        ''' <returns>String</returns>
        ''' <remarks></remarks>
        Public Function GetAllSettingFields(ByVal file As String) As String()
            Try
                'createProjFolders(cur_pjpath)
                Dim dat As String = FileSystem.ReadAllText(file, Encoding.UTF8)
                Dim rows() As String = dat.Split(CChar(vbCrLf))
                Dim ret As New List(Of String)
                For Each row As String In rows
                    If row.Contains("=") Then
                        ret.Add(row.Remove(row.IndexOf("=")).Trim)
                    End If
                Next
                Return ret.ToArray
            Catch ex As Exception
                MsgBox(
                    "INI Error 4: Failed to list all settings fields. Detailed info displayed below:" & vbCrLf & ex.ToString &
                    vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function


        ''' <summary>
        '''     gets a field in a entity settings file CASE SENSITIVE. returns zero if no such field.
        ''' </summary>
        ''' <param name="file">file to get settings from</param>
        ''' <param name="name">field name to read from</param>
        ''' <returns>String</returns>
        ''' <remarks></remarks>
        Public Function GetSettingData(ByVal file As String, ByVal name As String) As String
            Try
                'createProjFolders(cur_pjpath)
                Dim dat As String = FileSystem.ReadAllText(file, Encoding.UTF8)
                Dim rows() As String = dat.Split(CChar(vbCrLf))
                Dim ret As String = Nothing
                For Each row As String In rows
                    If row.Trim.StartsWith(name & "=") Then
                        ret = row.Replace(name & "=", "")
                        ret = ret.Trim
                        Exit For
                    End If
                Next
                If ret = Nothing Then
                    SetSettingData(file, name, "")
                End If
                Return ret
            Catch ex As Exception
                MsgBox(
                    "INI Error 3: Failed to read INI data (CaseS Mode). Detailed info displayed below:" & vbCrLf &
                    ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function


        ''' <summary>
        '''     gets a field in a entity settings file CASE INSENSITIVE. returns zero if no such field.
        ''' </summary>
        ''' <param name="file">file to get settings from</param>
        ''' <param name="name">field name to read from</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetSettingDataCaseI(ByVal file As String, ByVal name As String) As String
            Try
                'createProjFolders(cur_pjpath)
                Dim dat As String = FileSystem.ReadAllText(file, Encoding.UTF8)
                Dim rows() As String = dat.Split(CChar(vbCrLf))
                Dim ret As String = "0"
                For Each row As String In rows
                    If row.ToLower.Trim.StartsWith(name.ToLower & "=") Then
                        ret = row.Remove(0, row.IndexOf("=") + 1).Trim
                        ret = ret.Trim
                        Exit For
                    End If
                Next
                If ret = "0" Then
                    SetSettingData(file, name, "")
                End If
                Return ret
            Catch ex As Exception
                MsgBox(
                    "INI Error 2: Failed to read INI data (CaseI Mode). Detailed info displayed below:" & vbCrLf &
                    ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Function


        ''' <summary>
        '''     sets a field in a entity settings file
        ''' </summary>
        ''' <param name="file">file to set settings in</param>
        ''' <param name="name">field to set</param>
        ''' <param name="data">date to write in field</param>
        ''' <remarks></remarks>
        Public Sub SetSettingData(ByVal file As String, ByVal name As String, ByVal data As String)
            Try
                Dim dat As String = FileSystem.ReadAllText(file, Encoding.UTF8)
                Dim rows() As String = dat.Split(CChar(vbCrLf))
                Dim ret As Boolean = False
                Dim strToWrite As String = ""
                For i As Integer = 0 To rows.Length - 1
                    Dim row As String = rows(i)
                    If row.Trim.StartsWith(name & "=") Then
                        ret = True
                        rows(i) = name.Trim & "=" & data.Trim
                        strToWrite &= rows(i) & vbCrLf
                    ElseIf row.Contains("=") Then
                        strToWrite &= rows(i) & vbCrLf
                    ElseIf row.Trim.StartsWith("[") And row.Trim.EndsWith("]") Then
                        strToWrite &= rows(i) & vbCrLf
                    End If
                Next
                If ret = False Then
                    strToWrite &= vbCrLf & name & "=" & data
                End If
                While strToWrite.Contains(vbCrLf & vbCrLf)
                    strToWrite = strToWrite.Replace(vbCrLf & vbCrLf, vbCrLf)
                End While
                FileSystem.WriteAllText(file, strToWrite.Trim, False, Encoding.UTF8)
            Catch ex As Exception
                MsgBox(
                    "INI Error 1: Failed to write INI data. Detailed info displayed below:" & vbCrLf & ex.ToString & vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub


        ''' <summary>
        '''     renames a field in an Entity settings file
        ''' </summary>
        ''' <param name="file">file to rename settings in</param>
        ''' <param name="name">field to rename</param>
        ''' <param name="newName">new name of field</param>
        ''' <remarks></remarks>
        Public Sub RenameSettingData(ByVal file As String, ByVal name As String, ByVal newName As String)
            Try
                Dim dat As String = FileSystem.ReadAllText(file, Encoding.UTF8)
                Dim rows() As String = dat.Split(CChar(vbCrLf))
                Dim ret As Boolean = False
                Dim strToWrite As String = ""
                For i As Integer = 0 To rows.Length - 1
                    Dim row As String = rows(i)
                    If row.Trim.StartsWith(name & "=") Then
                        ret = True
                        rows(i) = newName & row.Remove(0, row.IndexOf("="))
                    End If
                    strToWrite &= rows(i)
                    If Not i = rows.Length - 1 Then strToWrite &= vbCrLf
                Next
                'If ret = False Then
                'End If
                FileSystem.WriteAllText(file, strToWrite.Trim, False, Encoding.UTF8)
            Catch ex As Exception
                MsgBox(
                    "INI Error 4: Failed to rename INI field. Detailed info displayed below:" & vbCrLf & ex.ToString &
                    vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
            End Try
        End Sub


        ''' <summary>
        '''     deletes a field in a entity settings file
        ''' </summary>
        ''' <param name="file">file to set settings in</param>
        ''' <param name="name">field to delete</param>
        ''' <remarks></remarks>
        Public Function DeleteSettingData(ByVal file As String, ByVal name As String) As Boolean
            Try
                Dim dat As String = FileSystem.ReadAllText(file, Encoding.UTF8)
                Dim rows() As String = dat.Split(CChar(vbCrLf))
                Dim ret As Boolean = False
                Dim strToWrite As String = ""
                For i As Integer = 0 To rows.Length - 1
                    Dim row As String = rows(i)
                    If row.Trim.StartsWith(name & "=") Then
                        ret = True
                        rows(i) = ""
                    End If
                    If Not rows(i) = "" Then
                        strToWrite &= rows(i)
                        If Not i = rows.Length - 1 Then strToWrite &= vbCrLf
                    End If
                Next
                If ret Then
                    FileSystem.WriteAllText(file, strToWrite.Trim, False, Encoding.UTF8)
                End If
                Return ret
            Catch ex As Exception
                MsgBox(
                    "INI Error 5: Failed to delete INI field. Detailed info displayed below:" & vbCrLf & ex.ToString &
                    vbCrLf &
                    "Contact the Entity Team if this persists.", MsgBoxStyle.Critical Or MsgBoxStyle.MsgBoxSetForeground,
                    "Error")
                Application.Restart()
                Return False
            End Try
        End Function
    End Module
End Namespace