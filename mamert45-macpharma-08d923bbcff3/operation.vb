Imports System.Data.OleDb
Module operation
    Public currentQty As Integer = -1
    Public previewInvoice As String
    Public thisDate As Date
    Public alarmTerm As Integer = 10
    Public thisMonth As Integer
    Public thisYr As Integer
    Public accountType As String



    
    Public Sub openDb()
        Try
            conn.ConnectionString = connstring
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            ElseIf conn.State = ConnectionState.Open Then

            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub closeDb()
        
        conn.Close()


    End Sub
    Public Sub insertQ(ByVal sql As String)
        Try
            openDb()
            command.CommandText = sql
            command.ExecuteNonQuery()
            'load cart
            closeDb()


        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    
    Public Sub increaseINV()
        Dim term As String = "CASH"
        If frm_main.chcTerm.Checked = True Then
            term = "CHARGE"
        End If
        sqlcode = "insert into SALES_TABLE([DATE]," & term & ")values('" & frm_main.DTPInvD.Value.ToString & "', " & frm_main.txtTotal.Text.Trim & ")"

        Try
            openDb()
            command.CommandText = sqlcode
            command.ExecuteNonQuery()


            'load cart
            closeDb()
            'getNextInv()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try

    End Sub
    Function getQtyPerUnit(ByVal lotno As String, ByVal unit As String)
        Dim qtypunit As Integer = 0
        Try
            sqlcode = "select qtyperunit from ProductFile WHERE lotno='" & lotno & "' and unit='" & unit & "'"
            openDb()
            Dim newcommand As OleDb.OleDbCommand = conn.CreateCommand
            newcommand.CommandText = sqlcode
            Dim Newreader As OleDb.OleDbDataReader
            Newreader = newcommand.ExecuteReader
            If Newreader.HasRows Then
                If Newreader.Read Then
                    qtypunit = CInt(Newreader(0).ToString)
                End If
            End If
            Newreader.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString & " contact developer")
        Finally
            closeDb()
        End Try

        Return qtypunit


    End Function

    Function displayData(ByVal sql As String)
        Dim dt As New DataTable
        Try
            openDb()
            command = New OleDb.OleDbCommand(sql, conn)
            Dim da = New OleDbDataAdapter(command)
            da.Fill(dt)
            closeDb()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function
    Sub ddiff()

        Dim x As Integer
        Dim dt1 As Date
        Dim dt2 As Date

        'dt1 = DateTimePicker1.Text
        'dt2 = DateTimePicker2.Text
        dt1 = dt1.AddYears(x)
        x = DateDiff(DateInterval.Year, dt1, dt2)
        dt1 = dt1.AddYears(x)

        If dt1 <= dt2 Then
            x = x
            '   TextBox1.Text = x
        Else
            x = x - 1
            ' TextBox1.Text = x
        End If
    End Sub
End Module
