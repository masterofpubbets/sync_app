Public Class Users
    Public Shared userType As en_userType

    Public Enum en_userType
        Admin = 1
        User = 2
    End Enum

    Public Sub getUserType()
        Dim enc As New EAMS.Coding.EncodeString
        Dim encryptedUserName As String = enc.Encode(My.User.Name.ToLower)
        Dim userTypeName As String = DB.ExcutResult(String.Format("SELECT username from tblUsers where username ='{0}'", encryptedUserName))
        If userTypeName = "" Then
            userType = en_userType.User
        Else
            userType = en_userType.Admin
        End If
    End Sub

    Public Function addUser(ByVal username As String, ByVal type As en_userType) As Boolean
        Try
            Dim enc As New EAMS.Coding.EncodeString
            Dim encryptedUserName As String = enc.Encode(username)
            If type = en_userType.Admin Then
                DB.ExcuteNoneResult(String.Format("DELETE FROM tblUsers WHERE username = '{0}'", encryptedUserName))
                DB.ExcuteNoneResult(String.Format("insert into tblUsers (username) values ('{0}')", encryptedUserName))
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Public Function deleteUser(ByVal username As String) As Boolean
        Try
            Dim enc As New EAMS.Coding.EncodeString
            Dim encryptedUserName As String = enc.Encode(username)
            DB.ExcuteNoneResult(String.Format("DELETE FROM tblUsers WHERE username = '{0}'", encryptedUserName))
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

End Class
