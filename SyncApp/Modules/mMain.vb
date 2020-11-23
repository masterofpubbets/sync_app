Module mMain
    Public Const hSSl = "https"
    Public DB As New EAMS.DataBaseTools.SQLServerTools
    Public interDB As New EAMS.DataBaseTools.SQLServerTools
    Const serverURL = "swea.database.windows.net"
    Const user = "sewaadmin"
    Const pass = "sqlserverESLAM_2020"
    Public log As String = ""
    Public Const SheetName = "Template"

    Public Function azureConnect() As Boolean
        DB.DataBaseLocation = serverURL
        DB.DataBaseName = "top"
        DB.UserName = user
        DB.Pass = pass

        interDB.DataBaseLocation = "."
        interDB.DataBaseName = "IntermidiateDB"
        Try
            log = ""
            DB.Connect()
            interDB.Connect()

            If DB.DBStatus = ConnectionState.Open Then
                If interDB.DBStatus = ConnectionState.Open Then
                    Return True
                End If
            End If

        Catch ex As Exception
            log = ex.Message
            Return False
        End Try
        Return False
    End Function
End Module
