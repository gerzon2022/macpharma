Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms
Public Class frmReport

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pass("hey")
        '    'TODO: This line of code loads data into the 'Mydataset.SALES_TABLE' table. You can move, or remove it, as needed.
        ' Me.SALES_TABLETableAdapter.Fill(Me.Mydataset.SALES_TABLE)
        '    'TODO: This line of code loads data into the 'macpharmaDataSet.SALESFORTHEDAY_QRY' table. You can move, or remove it, as needed.

        '    Me.ReportViewer1.RefreshReport()
    End Sub
    Private Sub pass(ByVal fromPage As String)
        Try
            'Me.ReportViewer1.LocalReport.DataSources.Clear()

            Dim adp As New mydatasetTableAdapters.SALES_TABLETableAdapter
            Dim table As New mydataset.SALES_TABLEDataTable
            adp.Connection.ConnectionString = My.Settings.macpharmaConnectionString
            Me.SALES_TABLETableAdapter.Fill(Me.Mydataset.SALES_TABLE)

            Dim table2 As New DataTable
            table2 = table.Copy
            ReportViewer1.LocalReport.ReportPath = My.Settings.location_rpt + "daily.rdlc"

            Dim newDatasource As New ReportDataSource("a", table2)

            ' Me.ReportViewer1.LocalReport.DataSources.Add(New ReportDataSource("mydataset)
            Dim myparam As New ReportParameter("myparam", fromPage)
            ReportViewer1.LocalReport.SetParameters(myparam)
            ReportViewer1.RefreshReport()

        Catch ex As Exception


            frmSetting.Show()
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub


End Class