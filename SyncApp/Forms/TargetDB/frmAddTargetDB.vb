Public Class frmAddTargetDB
    Public dbId As Integer = 0
    Private dbs As New TargetDBs

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        dbId = 0
        Me.Close()
    End Sub

    Private Function Isvalidate() As Boolean
        If Trim(txtTag.Text) = "" Then
            MsgBox("Empty Tag", MsgBoxStyle.Exclamation, Me.Text)
            txtTag.Focus()
            Return False
        End If
        If Trim(txtDb.Text) = "" Then
            MsgBox("Empty Database Name", MsgBoxStyle.Exclamation, Me.Text)
            txtDb.Focus()
            Return False
        End If
        If Trim(txtServer.Text) = "" Then
            MsgBox("Empty Server", MsgBoxStyle.Exclamation, Me.Text)
            txtServer.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If Isvalidate() Then
            Dim result = dbs.Add(txtDb.Text, txtDescription.Text, txtServer.Text, txtTag.Text)
            If result <> "" Then
                MsgBox(result, MsgBoxStyle.Exclamation, Me.Text)
            Else
                dbId = dbs.getDbId(txtTag.Text)
                Me.Close()
            End If
        End If
    End Sub
End Class