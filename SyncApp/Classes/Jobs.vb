Public Class Jobs


    Public Function Add(ByVal targetDBId As Integer, ByVal jobName As String, ByVal jobDescription As String, ByVal startTime As Date, ByVal active As Int16) As String
        Try
            If interDB.ExcutResult(String.Format("SELECT jobName from tblJobs WHERE jobName ='{0}'", jobName)) <> "" Then
                Return "This Job is exists"
            End If
            If targetDBId = 0 Then
                interDB.ExcuteNoneResult(String.Format("EXEC sp_addJob '{0}', '{1}','{2}',{3},null", jobName, jobDescription, Format(startTime, "HH:mm"), active))
            Else
                interDB.ExcuteNoneResult(String.Format("EXEC sp_addJob '{0}', '{1}','{2}',{3},{4}", jobName, jobDescription, Format(startTime, "HH:mm"), active, targetDBId))
            End If
            Return "Job has been added."
        Catch ex As Exception
            Return ex.Message
        End Try
        Return ""
    End Function

End Class
