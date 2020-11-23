Public Class TargetDBs

    Public Function getDBs() As DataTable
        Try
            Return (interDB.ReturnDataTable("SELECT * FROM tbldbs"))
        Catch ex As Exception
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Function Add(ByVal dbName As String, ByVal dbDescription As String, ByVal server As String, ByVal tag As String) As String
        Try
            If interDB.ExcutResult(String.Format("SELECT tagName from tblDBs WHERE tagName ='{0}'", tag)) <> "" Then
                Return "This Tag is exists"
            End If
            interDB.ExcuteNoneResult(String.Format("EXEC sp_addDb '{0}', '{1}','{2}','{3}'", dbName, dbDescription, server, tag))
            Return ""
        Catch ex As Exception
            Return ex.Message
        End Try
        Return ""
    End Function

    Public Function getDbId(ByVal tag As String) As Integer
        Return Val(interDB.ExcutResult(String.Format("SELECT dbID from tblDBs WHERE tagName ='{0}'", tag)))
    End Function
End Class
