Imports System.Data.OleDb
Imports Microsoft.Reporting.WinForms
Public Class frmByDate

    Private Sub frmByDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'mydataset1.indiInvo' table. You can move, or remove it, as needed.
        'Me.indiInvoTableAdapter.Fill(Me.mydataset1.indiInvo)

        'Me.ReportViewer1.RefreshReport()Date.Parse("09/26/2018", "MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)
        pass(thisDate)
    End Sub
    Private Sub pass(ByVal fromPage As Date)
        Try
            'xs2 = Date.Parse(date2.Text).ToString("MM'/'dd'/'yyyy")
          
            Dim sq = "SELECT INVDETAILS.invno, INVDETAILS.qty, INVDETAILS.description, INVDETAILS.unitp, INVDETAILS.amount, INVDETAILS.disc, INVDETAILS.lotno, INVDETAILS.expiry, INVDETAILS.unit, INVHEAD.[DATE], INVHEAD.TERM AS Expr1, Contacts.Name, Contacts.Address FROM  ((INVDETAILS INNER JOIN INVHEAD ON INVDETAILS.invno = INVHEAD.INVNO) INNER JOIN Contacts ON INVHEAD.CCODE = Contacts.ID)WHERE (INVHEAD.[DATE] between #" & fromPage & "# and #" & fromPage & "#+1)"

            openDb()
            Dim ds As New mydataset1
            Dim DA = New OleDb.OleDbDataAdapter(sq, conn)

            DA.Fill(ds, ds.Tables(0).TableName)
            Dim rpds As New ReportDataSource("daily_date", ds.Tables(0)) 'tanawa sa ang name sa dataset1
            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(rpds)
            ReportViewer1.Refresh()
            ReportViewer1.RefreshReport()
            closeDb()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
End Class