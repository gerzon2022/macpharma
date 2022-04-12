
Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms
Public Class Form2

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'mydataset1.indiInvo' table. You can move, or remove it, as needed.

        'Me.indiInvoTableAdapter.FillBy(Me.mydataset1.indiInvo, previewInvoice)
        'TODO: This line of code loads data into the 'mydataset.indiInvo' table. You can move, or remove it, as needed.
        'Me.indiInvoTableAdapter.Fill(Me.mydataset.indiInvo)
        ''TODO: This line of code loads data into the 'mydataset.indiInvo' table. You can move, or remove it, as needed.
        ''Me.indiInvoTableAdapter.Fill(Me.mydataset.indiInvo)

        'Me.ReportViewer1.RefreshReport()
        pass(previewInvoice)
    End Sub
    Private Sub pass(ByVal fromPage As String)
        Try
            Me.ReportViewer1.SetDisplayMode(DisplayMode.Normal)
            
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        Dim sq = "SELECT INVDETAILS.invno, INVDETAILS.qty, INVDETAILS.description, INVDETAILS.unitp, INVDETAILS.amount, INVDETAILS.disc, INVDETAILS.lotno, INVDETAILS.expiry, INVDETAILS.unit, INVHEAD.[DATE], INVHEAD.TERM AS Expr1, Contacts.Name, Contacts.Address FROM  ((INVDETAILS INNER JOIN INVHEAD ON INVDETAILS.invno = INVHEAD.INVNO) INNER JOIN Contacts ON INVHEAD.CCODE = Contacts.ID)WHERE (INVDETAILS.invno = '" & fromPage & "')"
        openDb()
        Dim ds As New mydataset1
        Dim DA = New OleDb.OleDbDataAdapter(sq, conn)
        DA.Fill(ds, ds.Tables(0).TableName)
        Dim rpds As New ReportDataSource("DataSet1", ds.Tables(0)) 'tanawa sa ang name sa dataset1
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rpds)
        ReportViewer1.Refresh()
        ReportViewer1.RefreshReport()
        closeDb()
    End Sub
End Class