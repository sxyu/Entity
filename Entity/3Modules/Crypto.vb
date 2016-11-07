Imports System.Security.Cryptography
Imports System.Text

Namespace _3Modules

    Public Module Cryptography
        Public Function GenerateHash(ByVal sourceText As String) As String()
            'Create an encoding object to ensure the encoding standard for the source text
            Dim Ue As New UnicodeEncoding()
            'Retrieve a byte array based on the source text
            Dim salt1 As String = randStr(5)
            Dim salt2 As String = randStr(6)
            Dim byteSalt1() As Byte = Ue.GetBytes(salt1)
            Dim byteSalt2() As Byte = Ue.GetBytes(salt2)
            Dim byteSourceText() As Byte = Ue.GetBytes(salt1 & sourceText & salt2)
            'Instantiate an SHA512 Provider object
            Dim sha512 As New SHA512CryptoServiceProvider()
            'Compute the hash value from the source
            Dim byteHash() As Byte = sha512.ComputeHash(byteSourceText)
            'And convert it to String format for return
            Dim str(3) As String
            str(0) = Convert.ToBase64String(byteHash)
            str(1) = salt1
            str(2) = salt2
            Return str
        End Function

        Public Function GenerateHashUnsalted(ByVal sourceText As String) As String
            Dim ue As New UnicodeEncoding()
            Dim byteSourceText() As Byte = ue.GetBytes(sourceText)
            Dim sha512 As New SHA512CryptoServiceProvider()
            Dim byteHash() As Byte = sha512.ComputeHash(byteSourceText)
            Return Convert.ToBase64String(byteHash)
        End Function

        Public Function RandStr(ByVal len As Integer) As String
            Dim vals As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            vals &= vals.ToLower
            vals &= "1234567890"

            Dim toReturn As String = ""
            For i As Integer = 0 To len - 1
                toReturn &= vals(CInt(Math.Ceiling(Rnd() * (vals.Length - 1))))
            Next
            Return toReturn
        End Function
        'Public Function AES_Encrypt(ByVal input As String, ByVal pass As String) As String
        '    Dim AES As New System.Security.Cryptography.RijndaelManaged
        '    Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        '    Dim encrypted As String = ""
        '    Try
        '        Dim hash(31) As Byte
        '        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
        '        Array.Copy(temp, 0, hash, 0, 16)
        '        Array.Copy(temp, 0, hash, 15, 16)
        '        AES.Key = hash
        '        AES.Mode = Security.Cryptography.CipherMode.ECB
        '        Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
        '        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(input)
        '        encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        '        Return encrypted
        '    Catch ex As Exception
        '    End Try
        'End Function

        'Public Function AES_Decrypt(ByVal input As String, ByVal pass As String) As String
        '    Dim AES As New System.Security.Cryptography.RijndaelManaged
        '    Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        '    Dim decrypted As String = ""
        '    Try
        '        Dim hash(31) As Byte
        '        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(pass))
        '        Array.Copy(temp, 0, hash, 0, 16)
        '        Array.Copy(temp, 0, hash, 15, 16)
        '        AES.Key = hash
        '        AES.Mode = Security.Cryptography.CipherMode.ECB
        '        Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
        '        Dim Buffer As Byte() = Convert.FromBase64String(input)
        '        decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        '        Return decrypted
        '    Catch ex As Exception
        '    End Try
        'End Function
    End Module
End Namespace