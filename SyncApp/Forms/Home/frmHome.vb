Public Class frmHome
    Private user As New Users

    Private Sub dbConHandler()
        lblDBCon.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        lblDBDis.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        user.getUserType()
    End Sub
    Private Sub dbDisconHandler()
        lblDBCon.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing
        lblDBDis.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblUser.Caption = My.User.Name
        dbDisconHandler()
        If azureConnect() Then
            dbConHandler()
        Else
            dbDisconHandler()
            MsgBox(log, MsgBoxStyle.Critical, Me.Text)
        End If
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim frm As New frmNewJob() With {.MdiParent = Me}
        frm.Show()
    End Sub
End Class
