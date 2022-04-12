Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms
Public Class frmviewByInvo

    Private Sub frmviewByInvo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'mydataset.indiInvo' table. You can move, or remove it, as needed.
        Me.indiInvoTableAdapter.Fill(Me.mydataset.indiInvo)

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub pass(ByVal fromPage As String)
        Try
            'Me.ReportViewer1.LocalReport.DataSources.Clear()

            Dim adp As New mydatasetTableAdapters.indiInvoTableAdapter
            Dim table As New mydataset.arpopupDataTable
            Me.indiInvoTableAdapter.Fill(Me.mydataset.indiInvo)
            Dim table2 As New DataTable
            table2 = table.Copy
            Dim newDatasource As New ReportDataSource("a", table2)
            Me.ReportViewer1.LocalReport.DataSources.Add(newDatasource)
            Dim myparam As New ReportParameter("invno", fromPage)
            ReportViewer1.LocalReport.SetParameters(myparam)
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
End Class