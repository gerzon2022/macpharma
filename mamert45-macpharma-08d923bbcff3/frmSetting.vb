Public Class frmSetting

    Private Sub frmSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.myconnectionString
        TextBox2.Text = My.Settings.location_rpt
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "Database|*.accdb"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = OpenFileDialog1.FileName
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        My.Settings.myconnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + TextBox1.Text
        My.Settings.Save()
        MessageBox.Show("saved")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.location_rpt = TextBox2.Text + "\"
        My.Settings.Save()
        MessageBox.Show("saved")
    End Sub
End Class