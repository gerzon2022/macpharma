Public Class frmMenu

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        frmSetting.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If rbtw.Checked = True Then
            accountType = "retail"
            Dim frm_main As New frm_main
            frm_main.Show()
            Me.Hide()
        Else
            accountType = "wholesale"
            Dim frm_main As New frm_main
            frm_main.Show()
            Me.Hide()

        End If

    End Sub


End Class