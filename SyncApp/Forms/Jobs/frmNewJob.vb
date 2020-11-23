Public Class frmNewJob
    Private dbID As Integer = 0
    Private job As New Jobs

    Private Function Isvalidate() As Boolean
        If Trim(txtJobName.Text) = "" Then
            MsgBox("Empty Job Name", MsgBoxStyle.Exclamation, Me.Text)
            txtJobName.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Dim frm As New frmSelectTargetDb
        frm.ShowDialog(Me)
        If frm.dbID <> 0 Then
            lblTargetDB.Text = frm.Tag
            dbID = frm.dbID
        End If
        frm = Nothing
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Me.Close()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        If Isvalidate() Then
            Dim result As String = ""
            If ckActive.Checked Then
                result = job.Add(dbID, txtJobName.Text, txtJobDescription.Text, pTime.EditValue, 1)
            Else
                result = job.Add(dbID, txtJobName.Text, txtJobDescription.Text, pTime.EditValue, 0)
            End If
            MsgBox(result, MsgBoxStyle.Information, Me.Text)
            Dim msgR As MsgBoxResult = MsgBox("Do You Want To Add Another Job?", MsgBoxStyle.YesNo, Me.Text)
            If msgR = MsgBoxResult.No Then
                Me.Close()
            Else
                txtJobDescription.Text = ""
                txtJobName.Text = ""
                txtJobName.Focus()
            End If
        End If
    End Sub
End Class