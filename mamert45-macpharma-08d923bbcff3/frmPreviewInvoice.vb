Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms
Public Class frmPreviewInvoice

    Private Sub frmPreviewInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
        pass("hey")

    End Sub
    Private Sub pass(ByVal fromPage As String)
        Try
            'Me.ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.ReportPath = My.Settings.location_rpt + "invoicenoReport.rdlc"
            Dim adp As New mydatasetTableAdapters.arpopupTableAdapter
            Dim table As New mydataset.arpopupDataTable
            Me.arpopupTableAdapter.Fill(Me.Mydataset.arpopup)
            Dim table2 As New DataTable
            table2 = table.Copy
            Dim newDatasource As New ReportDataSource("a", table2)
            Me.ReportViewer1.LocalReport.DataSources.Add(newDatasource)
            'Dim myparam As New ReportParameter("myparam", fromPage)
            'ReportViewer1.LocalReport.SetParameters(myparam)
            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
End Class