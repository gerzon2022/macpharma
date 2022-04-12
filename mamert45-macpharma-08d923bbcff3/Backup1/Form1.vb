Public Class Form1

    Private Sub HousesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HousesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.HousesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.TestDataSet)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TestDataSet.Person' table. You can move, or remove it, as needed.
        Me.PersonTableAdapter.Fill(Me.TestDataSet.Person)
        'TODO: This line of code loads data into the 'TestDataSet.Houses' table. You can move, or remove it, as needed.
        Me.HousesTableAdapter.Fill(Me.TestDataSet.Houses)

    End Sub
End Class
