Public Class frmSelectTargetDb
    Public Tag = ""
    Public dbID As Integer = 0
    Private dbs As New TargetDBs

    Private Sub getData()
        grd.DataSource = dbs.getDBs
    End Sub
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        dbID = 0
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Dim row_handle As Integer = gv.GetSelectedRows(0)
        If row_handle < 0 Then
            MsgBox("Please Select Database", MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End If
        Tag = gv.GetDataRow(row_handle).Item("tagName")
        dbID = gv.GetDataRow(row_handle).Item("dbID")
        Me.Close()
    End Sub

    Private Sub frmSelectTargetDb_Load(sender As Object, e As EventArgs) Handles Me.Load
        getData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim frm As New frmAddTargetDB
        frm.ShowDialog(Me)
        If frm.dbId <> 0 Then
            getData()
        End If
        frm = Nothing
    End Sub
End Class