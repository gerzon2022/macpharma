Imports System.Data.OleDb

Public Class frm_main

   

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

        If TabControl1.SelectedIndex = 3 Then 'price update
            loadPriceUpdate()
        ElseIf TabControl1.SelectedIndex = 2 Then
            loadStockTransf()
        ElseIf TabControl1.SelectedIndex = 0 Then
            'loadStockTransf()
        ElseIf TabControl1.SelectedIndex = 1 Then
            'loadStockTransf()
            loadData()
            LoadComboBox_MtgcComboBoxItem()
        ElseIf TabControl1.SelectedIndex = 4 Then

            loadAdjust()
        ElseIf TabControl1.SelectedIndex = 5 Then
            ''loadStockTransf()
            'loadAdjust()
            'miciliesaniuseos
            loadYr()
            loadCustomerRpt()
        ElseIf TabControl1.SelectedIndex = 6 Then
            loadProdExp()
            loadTermExp()

        End If
     
        'cbproduct.Enabled = val
        'txtcusname.Enabled = val
        txtcusname.Select()
    End Sub
    Sub loadProdExp()
        Try
            sqlcode = "select lotno,prod_description, [EXPIRY], INVQTY from ProductFile where (DateDiff('d',  #" & Date.Now.ToShortDateString & "#,[EXPIRY]) <= 30)"
            displayData(sqlcode)
            Dim dt As New DataTable
            dt = displayData(sqlcode)
            DataProductExp.DataSource = dt
            DataProductExp.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            DataProductExp.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Sub loadTermExp()
        sqlcode = "SELECT INVDETAILS.invno,INVHEAD.[DATE], Contacts.Name, Contacts.Address, INVHEAD.TERM , sum(INVDETAILS.amount) as Amount FROM ((INVDETAILS INNER JOIN INVHEAD ON INVDETAILS.invno = INVHEAD.INVNO) INNER JOIN Contacts ON INVHEAD.CCODE = Contacts.ID) where ((DateDiff('d',  #" & Date.Now.ToShortDateString & "#,INVHEAD.[DATE]) <= " & alarmTerm & ") and INVHEAD.TERM >0) group by INVDETAILS.invno, INVHEAD.[DATE], INVHEAD.TERM , Contacts.Name, Contacts.Address "

        Try
            'sqlcode = "SELECT        INVDETAILS.invno, INVDETAILS.qty, INVDETAILS.description, INVDETAILS.unitp, INVDETAILS.amount, INVDETAILS.disc, INVDETAILS.lotno,INVDETAILS.expiry,  INVDETAILS.unit, INVHEAD.[DATE], INVHEAD.TERM AS Expr1, Contacts.Name, Contacts.Address FROM ((INVDETAILS INNER JOIN INVHEAD ON INVDETAILS.invno = INVHEAD.INVNO) INNER JOIN Contacts ON INVHEAD.CCODE = Contacts.ID) where (DateDiff('d',  #" & Date.Now.ToShortDateString & "#,[EXPIRY]) <= 30) "
            displayData(sqlcode)
            Dim dt As New DataTable
            dt = displayData(sqlcode)
            DataTermExp.DataSource = dt
            DataTermExp.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Sub loadCustomerRpt()
        Try
            If Not txtRptCustomer.Text = Nothing Then
                sqlcode = "SELECT distinct Contacts.Name,INVDETAILS.invno, INVHEAD.[DATE], Sum(INVDETAILS.amount) as Total  FROM ((INVDETAILS INNER JOIN INVHEAD ON INVDETAILS.invno = INVHEAD.INVNO) INNER JOIN Contacts ON INVHEAD.CCODE = Contacts.ID) where Contacts.Name like '%" & txtRptCustomer.Text & "%' GROUP BY INVDETAILS.invno,Contacts.Name,INVHEAD.[DATE]"

            Else
                sqlcode = "SELECT distinct Contacts.Name,INVDETAILS.invno, INVHEAD.[DATE], Sum(INVDETAILS.amount) as Total FROM ((INVDETAILS INNER JOIN INVHEAD ON INVDETAILS.invno = INVHEAD.INVNO) INNER JOIN Contacts ON INVHEAD.CCODE = Contacts.ID) GROUP BY INVDETAILS.invno,Contacts.Name,INVHEAD.[DATE]"

            End If
            
            'sqlcode = "select lotno,prod_description, [EXPIRY], INVQTY from ProductFile where (DateDiff('d',  #" & Date.Now.ToShortDateString & "#,[EXPIRY]) <= 30)"
            displayData(sqlcode)
            Dim dt As New DataTable
            dt = displayData(sqlcode)
            dataGvRpt.DataSource = dt
            dataGvRpt.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Sub refreshdata()
        loadData()
        LoadComboBox_MtgcComboBoxItem()
        newItem()
    End Sub
    Function dateDiff(ByVal date1 As Date, ByVal date2 As Date)

    
        Dim numday As New Day
        ' This will show the number of days between
        ' 28/07/2015 and 28/09/2015
        'MessageBox.Show(dateDiff(DateInterval.Day, date1, date2))
        Return numday
    End Function
    Dim thisqty As Integer
    Function hasDupCart()
        Try
            Dim fromCart As String
            If DGV_main.RowCount() > 0 Then
                For i = 0 To DGV_main.RowCount()
                    fromCart = DGV_main.Rows(i).Cells(3).Value
                    If txtlotno.Text = fromCart Then
                        sqlcode = "update INVDETAILS set qty=qty+" & CInt(txtqty.Text) * getQtyPerUnit(txtlotno.Text, cbunit.Text) & " where invno='0000" & txtinvoice.Text & "'"
                        insertQ(sqlcode)
                        loaddgv()
                        thisqty = currentQty - (CInt(txtqty.Text) * getQtyPerUnit(txtlotno.Text, cbunit.Text))
                        sqlcode = "update ProductFile set INVQTY=" & thisqty & " where lotno='" & txtlotno.Text & "'"
                        insertQ(sqlcode)
                        refreshdata()

                        Return True
                    End If
                Next
            End If
        Catch ex As Exception
        Finally
            reader.Close()
            closeDb()
        End Try

        Return False
    End Function

    Private Sub frm_main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmMenu.Close()
    End Sub


    Private Sub frm_main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then

            'sqlcode = "ALTER TABLE INVDETAILS ALTER COLUMN invno int"
            'insertQ(sqlcode)
            If hasDupCart() = True Then
                MessageBox.Show("Cart Updated")
            Else
                If CInt(txtqty.Text) > 0 Then

                    sqlcode = "insert into INVDETAILS(invno, qty,description, Unit,Unitp, Amount, lotno, expiry) values" &
                              "('0000" & txtinvoice.Text & "','" & txtqty.Text & "', '" & cbproduct.Text.Replace("'", "") & "', '" & cbunit.Text & "','" & txtprice.Text & "','" & txtamount.Text & "','" & txtlotno.Text & "','" & txtexp.Text & "' )"
                    insertQ(sqlcode)
                    If DGV_main.RowCount <= 0 Then
                        insertToINVHEAD()
                    End If
                    loaddgv()
                    thisqty = currentQty - (CInt(txtqty.Text) * getQtyPerUnit(txtlotno.Text, cbunit.Text)) ' get qtyperunit
                    sqlcode = "update ProductFile set INVQTY=" & thisqty & " where lotno='" & txtlotno.Text & "'"
                    insertQ(sqlcode)
                    refreshdata()
                    'increaseINV() 'should be done after clicking new
                    'getNextInv()
                ElseIf CInt(txtqty.Text) <= 0 And Not txtlotno.Text = Nothing Then
                MessageBox.Show("Enter Quantity")
                txtqty.Select()

            End If

            End If

            If TabControl1.SelectedIndex = 2 Then
                'ledger table naa pajud ang adjustment
                Dim InOut = CInt(txtFromToqty.Text)
                If cbtransferT.Text = "Outgoing" Then
                    sqlcode = "update ProductFile set INVQTY=INVQTY-" & InOut * getQtyPerUnit(txtpcode.Text, cbUnitTrans.Text) & " WHERE prodcode=" & txtpcode.Text & ""
                Else
                    sqlcode = "update ProductFile set INVQTY=INVQTY+" & InOut * getQtyPerUnit(txtpcode.Text, cbUnitTrans.Text) & " WHERE prodcode=" & txtpcode.Text & ""
                End If
                insertQ(sqlcode)


                sqlcode = "insert into incoming_details(FROM,DATERECEIVED,  TRANS_TYPE)values('" & txtFromTo.Text & "','" & DTPInvD.Value.ToString & "', '" & cbtransferT.Text & "')"
                insertQ(sqlcode)
            End If

        End If


    End Sub
    Sub loadOutIn()
        If CInt(txtFromToqty.Text) > 0 And Not cbtransferT.Text = Nothing Then
            Try
                sqlcode = ""
                insertQ(sqlcode)
                loadStockTransftoCb()
                txtFromTo.Clear()
                txtfromToAddr.Clear()
                txtFromToqty.Text = 0
                cbtransferT.Text = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        Else
            loadStockTransftoCb()
        End If
    End Sub
  
    Sub newItem()
        cbproduct.Text = Nothing
        txtprice.Text = "0.00"
        txtdiscount.Text = "0"
        cbunit.Text = Nothing
        txtlotno.Clear()
        txtqty.Text = "0"
        txtamount.Text = "0.00"
        txtexp.Clear()

    End Sub

    Private Sub frm_main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializedThePropertyName()
        cbprice.SelectedIndex = 0
        TabControl1.SelectedIndex = 6
        txtsearch_TextChanged(sender, e)
        autoname()
        loadData()
        LoadComboBox_MtgcComboBoxItem()
        getNextInv()

        'LoadComboBox_MtgcComboBoxItem()

        Me.KeyPreview = True

    End Sub
    Sub loadStockTransf()
        Try
            openDb()
            sqlcode = "select prodcode, prod_description, INVQTY from ProductFile"
            Dim newcommand As OleDb.OleDbCommand = conn.CreateCommand
            newcommand.CommandText = sqlcode
            Dim Newreader As OleDb.OleDbDataReader
            Newreader = newcommand.ExecuteReader
            Dim replce As String = Nothing
            Dim replce1 As String = Nothing
            Dim replce2 As String = Nothing
            Dim counter As Integer = 0
            lvStockTransf.Items.Clear()
            If Newreader.HasRows Then
       
                While Newreader.Read

                    If Newreader(1).ToString = Nothing Then
                        replce = "-"
                    Else
                        replce = Newreader(1).ToString
                    End If
                    If Newreader(0).ToString = Nothing Then
                        replce1 = "-"
                    Else
                        replce1 = Newreader(0).ToString
                    End If
                    If Newreader(2).ToString = Nothing Then
                        replce2 = "-"
                    Else
                        replce2 = Newreader(2).ToString
                    End If
                    With lvStockTransf.Items.Add(replce)
                        .SubItems.Add(replce1)
                        .SubItems.Add(replce2)
                    End With

                    counter += 1
                End While
                Newreader.Close()
            End If

            CbStockTransf.ColumnWidth = "340;50;50;0"

            Dim USstates(counter - 1) As MTGCComboBoxItem

            Dim i As Integer = 0
            For Each li As ListViewItem In lvStockTransf.Items

                USstates(i) = New MTGCComboBoxItem(li.Text.ToString, li.SubItems(1).Text.ToString, li.SubItems(2).Text.ToString)
                i += 1
            Next
            CbStockTransf.Items.Clear()

            With CbStockTransf
                .SelectedIndex = -1
                .Items.Clear()
                .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
                .MaxDropDownItems = 10
                .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDownList
                .Items.AddRange(USstates)
            End With
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Information)
        Finally

            closeDb()
        End Try

    End Sub
    Sub loadStockTransftoCb()
        

    End Sub
    Private Sub LoadComboBox_DataTable()
        'Dim dtLoading As New DataTable("UsStates")'reference lang ni

        'dtLoading.Columns.Add("Name", System.Type.GetType("System.String"))
        'dtLoading.Columns.Add("Abbreviation", System.Type.GetType("System.String"))
        'dtLoading.Columns.Add("Population", System.Type.GetType("System.String"))
        'dtLoading.Columns.Add("Size", System.Type.GetType("System.String"))

        'For Each li As ListViewItem In lsvData.Items
        '    Dim dr As DataRow
        '    dr = dtLoading.NewRow

        '    dr("Name") = li.Text
        '    dr("Abbreviation") = li.SubItems(1).Text
        '    dr("Population") = li.SubItems(2).Text
        '    dr("Size") = li.SubItems(3).Text

        '    dtLoading.Rows.Add(dr)
        'Next

        'cbproduct.SelectedIndex = -1
        'cbproduct.Items.Clear()
        'cbproduct.LoadingType = MTGCComboBox.CaricamentoCombo.DataTable
        'cbproduct.SourceDataString = New String(3) {"Name", "Abbreviation", "Population", "Size"}
        'cbproduct.SourceDataTable = dtLoading
        'MsgBox("Loading completed!", MsgBoxStyle.Information)
    End Sub

    Sub loadData()
        openDb()
        sqlcode = "select [Prod_description],LOTNO,[EXPIRY],INVQTY from ProductFile"
        command.CommandText = sqlcode
        reader = command.ExecuteReader
        Dim replce As String = Nothing
        Dim replce1 As String = Nothing
        Dim datehere As String = Nothing
        Dim replce3 As String = Nothing
        lsvData.Items.Clear()
        Dim counter = 0
        While reader.Read
            If reader(0).ToString = Nothing Then
                replce = "-"
            Else
                replce = reader(0).ToString
            End If
            If reader(1).ToString = Nothing Then
                replce1 = "-"
            Else
                replce1 = reader(1).ToString
            End If
            If reader(2).ToString = Nothing Then
                datehere = "-"
            Else

                Dim datestr As Date = reader(2).ToString
                datehere = datestr.ToShortDateString
            End If
            If reader(3).ToString = Nothing Then
                replce3 = "-"
            Else
                replce3 = reader(3).ToString
            End If

            'With lsvData.Items.Add("home")
            '    .SubItems.Add("teset")
            '    .SubItems.Add("testse")
            '    .SubItems.Add("test")
            'End With

            With lsvData.Items.Add(replce)
                .SubItems.Add(replce1)
                .SubItems.Add(datehere)
                .SubItems.Add(replce3)
            End With
            counter += 1
        End While
        reader.Close()
        closeDb()

        cbproduct.ColumnWidth = 340 & ";" & 80 & ";" & 120 & ";" & 50


        cbproduct.MaxDropDownItems = 10


        Dim USstates(counter - 1) As MTGCComboBoxItem

        Dim i As Integer = 0



        For Each li As ListViewItem In lsvData.Items
            USstates(i) = New MTGCComboBoxItem(li.Text, li.SubItems(1).Text, li.SubItems(2).Text, li.SubItems(3).Text)
            If li.Text = Nothing Or li.SubItems(1).Text = Nothing Or li.SubItems(2).Text = Nothing Or li.SubItems(3).Text = Nothing Then
                MessageBox.Show(li.SubItems(2).Text)
            End If

            i += 1
        Next
        cbproduct.Items.Clear()
        With cbproduct
            .SelectedIndex = -1
            .Items.Clear()
            .LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem
            .MaxDropDownItems = 10
            .DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDownList
            .Items.AddRange(USstates)
        End With
      
    End Sub

    Private Sub LoadComboBox_MtgcComboBoxItem()
        'Try
        'Dim w As String = 240
        'If Len(Trim(w)) = 0 Then w = "0"

        '' MsgBox(cbproduct.MaxDropDownItems)
        'If Not IsNumeric(w) OrElse (CLng(w) < 0) Then
        '    MsgBox("You must enter a positive integer!", MsgBoxStyle.Critical)
        '    'txtWCol1.Focus()
        '    Exit Sub
        'End If



    End Sub
    Sub autoNewProd()
        Try
            openDb()
            sqlcode = "select distinct prod_description from ProductFile"
            command.CommandText = sqlcode
            reader = command.ExecuteReader
            'txtcusname.AutoCompleteCustomSource.Clear()
            Dim autocomp As New AutoCompleteStringCollection
            While reader.Read
                If (reader(0).ToString = Nothing) Then
                Else
                    autocomp.Add(CType(reader(0), String))
                End If
                ' MessageBox.Show(CType(reader(0), String))
            End While
            reader.Close()
            closeDb()


            With txtNewDesc
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = autocomp
                .Clear()
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            reader.Close()
            closeDb()
        End Try

    End Sub


    Public Sub autoname()

        Try
            If conn.State = ConnectionState.Closed Then
                openDb()
            End If

            sqlcode = "select Name from contacts"
            command.CommandText = sqlcode
            reader = command.ExecuteReader
            'txtcusname.AutoCompleteCustomSource.Clear()
            Dim autocomp As New AutoCompleteStringCollection
            While reader.Read
                If (reader(0).ToString = Nothing) Then
                Else
                    autocomp.Add(CType(reader(0), String))
                End If
                ' MessageBox.Show(CType(reader(0), String))
            End While
            reader.Close()
            closeDb()


            With txtcusname
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = autocomp
                .Clear()
            End With

        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        Finally
            reader.Close()
            closeDb()
        End Try



    End Sub

    Public Sub autoItemDesc()
        Try
            If conn.State = ConnectionState.Closed Then
                openDb()
            End If
            sqlcode = "select Prod_description from ProductFile"
            command.CommandText = sqlcode
            reader = command.ExecuteReader
            cbproduct.AutoCompleteCustomSource.Clear()
            Dim autocomp As New AutoCompleteStringCollection

            Dim itemd As String = Nothing
            Dim lot As String = Nothing
            Dim exp As String = Nothing
            Dim stock As String = Nothing
            While reader.Read

                If reader(0).ToString = Nothing Then
                    itemd = " - "
                Else
                    itemd = reader(0)
                    autocomp.Add(CType(itemd, String) + " " + CType(lot, String) + " " + CType(exp, String) + " " + CType(stock, String))
                End If



                '
                'MessageBox.Show(reader(1))
                'MessageBox.Show(r.Item(0).ToString + r.Item(1).ToString)
            End While
            MessageBox.Show("success")

            With cbproduct
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = autocomp

            End With


        Catch ex As Exception

            MessageBox.Show(ex.ToString)
        Finally
            reader.Close()
            closeDb()
        End Try
    End Sub

    Private Sub DGV_main_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_main.CellClick
        If DGV_main.RowCount > 0 Then
            If DGV_main.SelectedRows.Count > 0 Then
                Dim rPos As Integer = DGV_main.CurrentCell.ColumnIndex
                Dim i As Integer = DGV_main.CurrentRow.Index

                addThis = DGV_main.Rows(i).Cells(0).Value
                thisItemDesc = DGV_main.Rows(i).Cells(1).Value
                thisUnit = DGV_main.Rows(i).Cells(2).Value
                delThis = DGV_main.Rows(i).Cells(3).Value
                thisLotno = delThis
                'thisExpiry = DGV_main.Rows(i).Cells(4).Value
                thisprice = DGV_main.Rows(i).Cells(5).Value
                thisamount = DGV_main.Rows(i).Cells(6).Value
                If e.ColumnIndex = 1 Then ' getting the desc for next column





                    '    sqlcode = "select Unit from ProductFile where Prod_description ='" &  & "'"
                    '    openDb()
                    '    'MessageBox.Show(sqlcode)
                    '    Dim dt As New DataTable
                    '    Dim ds As New DataSet
                    '    ds.Tables.Add(dt)
                    '    Dim cmd As New OleDbCommand(sqlcode)

                    '    Dim da As New OleDbDataAdapter(sqlcode, conn)
                    '    da.Fill(dt)
                    '    Dim r As DataRow
                    '    'frm_main.txtcusname.AutoCompleteCustomSource.Clear
                    '    'Dim cboCol1 As DataGridViewComboBoxColumn
                    '    'cboCol1 = DGV_main.Columns.Item(0)
                    '    If dt.Rows.Count > 0 Then
                    '        Dim cbCell As New DataGridViewComboBoxCell
                    '        cbCell = DGV_main.Rows(i).Cells("item_description")
                    '        cbCell.Items.Clear()
                    '        For Each r In dt.Rows
                    '            '
                    '            cbCell.Items.Add(r.Item(0).ToString)

                    '            'CType(Me.DGV_main.Columns(3), DataGridViewComboBoxColumn).Items.Add(r.Item(3).ToString())
                    '        Next
                    '    End If
                    '    closeDb()
                    'Catch ex As DataException
                    '    'MessageBox.Show(ex.ToString)
                    'End Try
                End If
            End If
        End If
    End Sub






    'Private Sub DGV_main_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_main.CellDoubleClick

    '    If DGV_main.RowCount > 0 Then
    '        editEnable = True
    '        txtlotno.Text = thisLotno
    '        cbproduct.Text = thisItemDesc
    '        cbunit.Text = thisUnit
    '        txtqty.Text = addThis
    '        txtamount.Text = thisamount
    '        txtprice.Text = thisprice
    '        cbunit.Text = thisUnit

    '        'txtexp.Text = thisExpiry
    '    End If


    'End Sub


    Private Sub DGV_main_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DGV_main.EditingControlShowing

        Try
            Dim TX As TextBox = CType(e.Control, TextBox)
            If DGV_main.CurrentCell.ColumnIndex = 1 Then
                If Not IsNothing(TX) Then
                    'TX.AutoCompleteCustomSource = gacInventoryItemsLookUp
                    TX.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    TX.AutoCompleteSource = AutoCompleteSource.CustomSource
                    Dim data As AutoCompleteStringCollection = New AutoCompleteStringCollection()
                    addData(data)
                    TX.AutoCompleteCustomSource = data
                End If
            Else
                TX = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub addData(ByVal data As AutoCompleteStringCollection)
        Try
            sqlcode = "select * from ProductFile"
            openDb()
            'MessageBox.Show("success")
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            Dim da As New OleDbDataAdapter(sqlcode, conn)
            da.Fill(dt)
            Dim r As DataRow
            'frm_main.txtcusname.AutoCompleteCustomSource.Clear()
            For Each r In dt.Rows
                data.Add(r.Item(2).ToString)
            Next
            closeDb()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub getData(ByVal sql As String)
        Try
            openDb()
            'MessageBox.Show("success")
            Dim dt As New DataTable
            Dim ds As New DataSet
            ds.Tables.Add(dt)
            Dim da As New OleDbDataAdapter(sqlcode, conn)
            da.Fill(dt)


            closeDb()
        Catch ex As Exception

        End Try
    End Sub




    Dim delThis As String
    Dim addThis As String
    Dim thisLotno As String
    Dim thisUnit As String
    Dim thisExpiry As String
    Private Sub DGV_main_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_main.CellContentClick

    End Sub


    Private Sub DGV_main_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGV_main.DataError


    End Sub

    Sub test()
        '' Set datagrid column styles
        'With TableStyle.GridColumnStyles
        '    ' Set datagrid ColumnStyle for Car field
        '    .Add(New DataGridTextBoxColumn(tblCrrncMngr.GetItemProperties.Item("Car")))
        '    With .Item(0)
        '        .MappingName = "Car"
        '        .HeaderText = "Car Name"
        '        .Width = 130
        '        .NullText = String.Empty
        '        .ReadOnly = True
        '    End With

        '    ' Set datagrid ComboBox ColumnStyle for PubID field
        '    .Add(New DataGridComboBoxColumn(ds.Tables.Item("Companies"), 1, 0))
        '    ' Datagrid ComboBox DisplayMember field has order number 1. Name of this column is "Name"
        '    ' Datagrid ComboBox ValueMember field has order number 0. Name of this column is "PubID"
        '    With .Item(1)
        '        .MappingName = "PubID"
        '        .HeaderText = "Company ID"
        '        .Width = 200
        '        .NullText = String.Empty
        '    End With

        '    ' Set datagrid combobox ColumnStyle for State field
        '    .Add(New DataGridComboBoxColumn(ds.Tables.Item("States"), 0, 0, , , False))
        '    ' Datagrid ComboBox DisplayMember field has order number 0. Name of this column is "State"
        '    ' Datagrid ComboBox ValueMember field has order number 0. It is the same column like for DisplayMember
        '    With .Item(2)
        '        .MappingName = "State"
        '        .HeaderText = "State"
        '        .Width = 45
        '        .NullText = String.Empty
        '    End With

        '    ' Set datagrid XP Style Button ColumnStyle for City field
        '    .Add(New DataGridXPButtonColumn())
        '    ' Also you may set datagrid Button ColumnStyle for City
        '    ' field without XP Button Style as the following:
        '    ' .Add(New DataGridButtonColumn())
        '    With .Item(3)
        '        .MappingName = "City"
        '        .HeaderText = "City"
        '        .Width = 60
        '        .NullText = String.Empty
        '    End With

        '    ' Set datagrid Memo ColumnStyle for Comments field
        '    .Add(New DataGridMemoColumn("Car description"))
        '    With .Item(4)
        '        .MappingName = "Comments"
        '        .HeaderText = "Comments"
        '        .Width = 60
        '        .NullText = String.Empty
        '    End With
        'End With
    End Sub

    Private Sub cbproduct_DropDownClosed(sender As Object, e As EventArgs) Handles cbproduct.DropDownClosed
        ch = 1
    End Sub

    Private Sub cbproduct_GotFocus(sender As Object, e As EventArgs) Handles cbproduct.GotFocus

    End Sub

    Private Sub cbproduct_KeyDown(sender As Object, e As KeyEventArgs) Handles cbproduct.KeyDown
        If e.KeyCode = Keys.Back Then
            cbproduct.Text = Nothing
            txtlotno.Clear()
            txtqty.Text = 0
            txtamount.Text = "0.00"
            txtprice.Text = "0.00"
            cbunit.Text = Nothing

        End If
    End Sub
    Dim ch As Integer = 0
    Private Sub cbproduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbproduct.SelectedIndexChanged
        If TabControl1.SelectedIndex = 1 Then
            Try
                If chcTerm.Checked = True Then
                    If cbterm.Text = Nothing Then
                        MessageBox.Show("Term is active but No term selected!")
                        Exit Sub
                        cbterm.Select()
                    End If
                End If
                If Not cbprice.Text = Nothing And Not cbproduct.Text = Nothing And Not txtcusname.Text = Nothing Then
                    If ch = 1 Then

                        txtlotno.Text = cbproduct.SelectedItem.Col2
                        txtexp.Text = cbproduct.SelectedItem.Col3
                        'txtCol3.Text = cbproduct.SelectedItem.Col3
                        'txtCol4.Text = cbproduct.SelectedItem.Col4
                        currentQty = cbproduct.SelectedItem.Col4

                        ch = 0
                    Else
                        txtlotno.Text = ""
                        txtexp.Text = ""
                        'txtCol3.Text = ""
                        'txtCol4.Text = ""
                    End If
                Else
                    MessageBox.Show("Fill Name and price on details")
                    cbproduct.Text = Nothing
                    txtcusname.Select()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub txtlotno_TextChanged(sender As Object, e As EventArgs) Handles txtlotno.TextChanged

        sqlcode = "select unit  from ProductFile where LOTNO='" & txtlotno.Text & "'"
        'MessageBox.Show(sqlcode)
        openDb()
        command.CommandText = sqlcode
        reader = command.ExecuteReader
        cbunit.Items.Clear()
        cbunit.Text = Nothing
        While reader.Read

            cbunit.Items.Add(reader(0).ToString)

        End While
        closeDb()
    End Sub
    Sub txtqtyChange()

    End Sub
    Private Sub txtqty_TextChanged(s As Object, e As EventArgs) Handles txtqty.TextChanged
        If txtqty.Text = Nothing Then
            txtqty.Text = 1
        Else
            TextboxOnlyNumbers(s)
            If Not txtlotno.Text = Nothing And Not cbunit.Text = Nothing Then
                If (CInt(txtqty.Text) * getQtyPerUnit(txtlotno.Text, cbunit.Text)) > currentQty And currentQty >= 0 Then
                    MessageBox.Show("Insuficient Stocks, Stock on hand is : " & currentQty)
                    txtqty.Text = "0"
                End If
            End If

        End If

    End Sub
    Public Sub TextboxOnlyNumbers(ByRef objTxtBox As TextBox)
        If IsNumeric(txtprice.Text) And IsNumeric(txtqty.Text) Then
            Dim amount As Double = CDbl(txtqty.Text) * CDbl(txtprice.Text)
            'Dim myqty As Double = 
            'Dim price As Double =

            txtamount.Text = amount.ToString("N2")


        End If




        ' ONLY allow numbers
        If Not IsNumeric(objTxtBox.Text) Then

            ' Don't process things like too many backspaces
            If objTxtBox.Text.Length > 0 Then

                MsgBox("Numerical Values only!")

                Try
                    ' If something bad was entered delete the last character
                    objTxtBox.Text = objTxtBox.Text.Substring(0, objTxtBox.Text.Length - 1)

                    ' Put the cursor and the END of the corrected number
                    objTxtBox.Select(objTxtBox.Text.Length + 1, 1)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub cbprice_GotFocus(sender As Object, e As EventArgs)

        cusCode = getCuscode()


    End Sub
    Private Sub txtprice_TextChanged(sender As Object, e As EventArgs) Handles txtprice.TextChanged
        txtqty_TextChanged(sender, e)
    End Sub
    Dim thisItemDesc As String
    Dim thisprice As String
    Dim thisamount As String



    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        Dim total As Double = txtTotal.Text


        If chcTerm.Checked = True And cbterm.Text = Nothing Then
            MessageBox.Show("No term seleceted! or uncheck term checkbox")
        Else
            If Not cusCode = Nothing And txtinvoice.ReadOnly = True Then
                increaseINV()
                getNextInv()
                cbproduct.Text = Nothing
                txtdiscount.Text = "0"
                txtcusname.Clear()
                txtcusadd.Clear()
                cbunit.Text = Nothing
                txtlotno.Clear()
                txtqty.Text = "0"
                txtprice.Clear()
                txtamount.Text = "0.00"
                chcTerm.Checked = False
                loaddgv()
                'DGV_main.DataSource = Nothing
                'DGV_main.Refresh()
                txtcusname.Select()

            End If
        End If

        If txtinvoice.ReadOnly = False Then
            txtinvoice.ReadOnly = True
            getNextInv()
        End If
        If txtinvoice.Text = Nothing And txtinvoice.ReadOnly = True Then
            getNextInv()
        End If
    End Sub
    Dim cusCode As Integer
    Private Function getCuscode()
        Dim getcode As Integer = 0

        Try
            sqlcode = "select ID, Pricing from contacts where name='" & txtcusname.Text & "'"
            openDb()
            Dim newcommand As New OleDb.OleDbCommand(sqlcode, conn)
            Dim Newreader As OleDb.OleDbDataReader
            Newreader = newcommand.ExecuteReader()
            If Newreader.HasRows Then
                If Newreader.Read Then
                    getcode = CInt(Newreader(0))
                    cbprice.Text = Newreader(1).ToString
                End If
            Else
                MessageBox.Show("Not Registered Please select again")
                txtcusname.Select()
            End If
            
            Newreader.Close()
            closeDb()
            'MessageBox.Show(getcode)
            Return getcode
        Catch ex As Exception
            MessageBox.Show(" getCuscode " + ex.ToString)
        End Try
        Return getcode
    End Function
    Sub insertToINVHEAD()
        If chcTerm.Checked = True Then
            sqlcode = "insert into INVHEAD(CCODE, INVNO, [DATE],  Term)values(" & cusCode & ", '0000" & txtinvoice.Text & "','" & DTPInvD.Value.ToString & "', '" & cbterm.Text & "')"

        Else
            sqlcode = "insert into INVHEAD(CCODE, INVNO, [DATE])values(" & cusCode & ", '0000" & txtinvoice.Text & "','" & DTPInvD.Value.ToString & "')"

        End If
       insertQ(sqlcode)
    End Sub


    Sub loaddgv()
        Dim total As Double
        openDb()
        '        sqlcode = "SELECT        INVDETAILS.invno, INVDETAILS.qty, INVDETAILS.description, INVDETAILS.unitp, INVDETAILS.amount, INVDETAILS.lotno, INVDETAILS.expiry, " +
        '            "INVDETAILS.unit, INVHEAD.[DATE], INVHEAD.TERM, Contacts.Name, Contacts.Address " +
        '            " FROM            ((INVDETAILS INNER JOIN" + " INVHEAD ON INVDETAILS.invno = INVHEAD.INVNO) INNER JOIN " +
        '" Contacts ON INVHEAD.CCODE = Contacts.ID) " + "WHERE (INVDETAILS.invno = '0000" & txtinvoice.Text & "')"
        sqlcode = "Select qty,description, Unit,LOTNO, EXPIRY,unitp,amount FROM INVDETAILS WHERE invno='0000" & txtinvoice.Text & "'"
        Try

            Dim da As New OleDb.OleDbDataAdapter(sqlcode, conn)
            Dim dt As New DataTable
            da.Fill(dt)

            DGV_main.DataSource = dt

            'if you have the other column to get the result you  could add a new one like these above 
            For index As Integer = 0 To DGV_main.RowCount - 1
                total += CDbl(DGV_main.Rows(index).Cells(6).Value)

                'if you have the other column to get the result you  could add a new one like these above (just change Cells(2) to the one you added)
            Next
            txtTotal.Text = total.ToString("N2")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        closeDb()
    End Sub


    Private Sub btnsearchinv_Click(sender As Object, e As EventArgs) Handles btnsearchinv.Click
        If txtinvoice.ReadOnly = True Then
            txtinvoice.Clear()
            txtcusname.Clear()
            txtcusadd.Clear()
            txtinvoice.ReadOnly = False
            txtinvoice.Select()
        End If


    End Sub

    Private Sub btndel_Click(sender As Object, e As EventArgs) Handles btndel.Click


        If addThis > 0 Then
            If MessageBox.Show("Are you want to delete this item?", "Deleting...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                sqlcode = "delete from INVDETAILS WHERE lotno='" & delThis & "' and invno='0000" & txtinvoice.Text & "'"
                insertQ(sqlcode)
                sqlcode = "update ProductFile set INVQTY=INVQTY + " & addThis * getQtyPerUnit(thisLotno, thisUnit) & " where lotno='" & thisLotno & "'"

                insertQ(sqlcode)
                refreshdata()
                loaddgv()
            End If


        Else
            MessageBox.Show("No item selected/Select again")

        End If


    End Sub

    Private Sub txtcusname_LostFocus(sender As Object, e As EventArgs) Handles txtcusname.LostFocus
        If TabControl1.SelectedIndex = 1 And Not txtcusname.Text = Nothing Then
            cusCode = getCuscode()

        End If

    End Sub



    Private Sub btnprintinv_Click(sender As Object, e As EventArgs) Handles btnprintinv.Click
        If Not txtinvoice.Text = Nothing Then
            previewInvoice = "0000" & txtinvoice.Text
            Form2.Show()
        End If

    End Sub

    Private Sub txtinvoice_TextChanged(sender As Object, e As EventArgs) Handles txtinvoice.TextChanged
        If Not txtinvoice.Text = Nothing Then
            loaddgv()
            loadcusName(txtinvoice.Text)
        End If
    End Sub
    Sub loadcusName(ByRef invno As String)

        Try
            Dim sqlcode2 = "SELECT Contacts.Name, Contacts.Address, INVHEAD.CCODE FROM(Contacts INNER JOIN INVHEAD ON Contacts.ID = INVHEAD.CCODE) WHERE(INVHEAD.INVNO = '0000" & invno & "')"

            openDb()
            Dim newcommand As New OleDb.OleDbCommand(sqlcode2, conn)
            newcommand.CommandText = sqlcode2
            Dim Newreader As OleDb.OleDbDataReader
            Newreader = newcommand.ExecuteReader()
            While Newreader.Read


                If Newreader(0).ToString = Nothing Then
                    txtcusname.Clear()
                Else
                    txtcusname.Text = Newreader(0).ToString
                End If

                If Newreader.GetString(1) = vbNullString Then
                    txtcusadd.Clear()
                Else
                    txtcusadd.Text = Newreader(1).ToString
                End If


            End While
            Newreader.Close()
            closeDb()
        Catch ex As Exception
            ' MessageBox.Show(ex.ToString)
        End Try

    End Sub


    Private Sub TabControl_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem

        '  Identify which TabPage is currently selected
        Dim SelectedTab As TabPage = TabControl1.TabPages(e.Index)

        '  Get the area of the header of this TabPage
        Dim HeaderRect As Rectangle = TabControl1.GetTabRect(e.Index)

        '  Create a Brush to paint the Text
        Dim TextBrush As New SolidBrush(Color.Black)

        '  Set the Alignment of the Text
        Dim sf As New StringFormat()
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        '  Paint the Text using the appropriate Bold setting 
        If Convert.ToBoolean(e.State And DrawItemState.Selected) Then
            Dim BoldFont As New Font(TabControl1.Font.Name, TabControl1.Font.Size, FontStyle.Bold)
            e.Graphics.DrawString(SelectedTab.Text, BoldFont, TextBrush, HeaderRect, sf)
        Else
            e.Graphics.DrawString(SelectedTab.Text, e.Font, TextBrush, HeaderRect, sf)
        End If

        '  Job done - dispose of the Brushes
        TextBrush.Dispose()

    End Sub

    Dim priceUpdate As New DataSet


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        'Dim cmdbuilder As New OleDb.OleDbCommandBuilder(dataAdp)
        'Dim i As Integer
        'Try
        '    i = dataAdp.Update(priceUpdate, "trial")
        '    MsgBox("Records Updated= " & i)
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        Try
            If Not txtpu_retail.Text = Nothing And CInt(txtpu_retail.Text) >= 0 Then

                sqlcode = "update ProductFile set " & accountType & "=" & txtpu_retail.Text & ", active=" & txtpu_wholesale.Checked & " WHERE LOTNO='" & txtpu_lotno.Text & "' and unit = '" & txtpu_unit.Text & "'"
                MessageBox.Show(sqlcode)
                insertQ(sqlcode)
                loadPriceUpdate()
                txtpu_desc.Clear()
                txtpu_lotno.Clear()
                txtpu_retail.Clear()
                txtpu_search.Clear()
                txtpu_unit.Text = Nothing

            End If
        Catch ex As Exception

            MessageBox.Show("Select and item")
            txtactual.Text = 0
            txtactual.Select()
        End Try

    End Sub

    Private Sub txtsearch_GotFocus(sender As Object, e As EventArgs) Handles txtsearch.GotFocus

    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        Dim sqlcode1 As String
        If Not txtsearch.Text = Nothing Then
            sqlcode1 = "SELECT  Prod_description, Unit, " & accountType & ", INVQTY FROM  ProductFile where  Prod_description like '%" & txtsearch.Text & "%'"
            loadSearchProd(sqlcode1)
        Else
            sqlcode1 = "SELECT  Prod_description, Unit, " & accountType & ", INVQTY FROM  ProductFile"
            loadSearchProd(sqlcode1)
        End If
    End Sub
    Sub loadSearchProd(ByRef sql As String)

        Try
            openDb()
            command = New OleDb.OleDbCommand(sql, conn)
            Dim da = New OleDbDataAdapter(command)
            Dim pldt As New DataTable
            Dim ds As New DataSet
            da.Fill(pldt)
            ''priceUpdate.Tables.Add(pldt)

            DataGVprodsearch.DataSource = pldt
            DataGVprodsearch.Refresh()
            closeDb()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub loadAdjust()

        Try
            openDb()

            Dim sql As String
            If TextBox10.Text = Nothing Then
                sql = "SELECT  lotno, Prod_description, Unit, " & accountType & ", INVQTY FROM  ProductFile"
            Else
                sql = "SELECT  lotno, Prod_description, Unit, " & accountType & ", INVQTY FROM  ProductFile where Prod_description like '%" & TextBox10.Text & "%'"


            End If
            Dim pldt As New DataTable
            pldt = displayData(sql)
            ''priceUpdate.Tables.Add(pldt)

            dataGVinvAdjust.DataSource = pldt
            dataGVinvAdjust.Refresh()
            closeDb()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub loadPriceUpdate()

        Try
            openDb()
            Dim sql As String = "SELECT  lotno, Prod_description, Unit, " & accountType & ", active FROM  ProductFile"
            command = New OleDb.OleDbCommand(sql, conn)
            Dim da = New OleDbDataAdapter(command)
            Dim pldt As New DataTable
            da.Fill(pldt)
            ''priceUpdate.Tables.Add(pldt)
            datagvPriceUpdate.DataSource = pldt
            datagvPriceUpdate.Refresh()
            closeDb()
        Catch ex As Exception
            ' MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dataGVinvAdjust_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGVinvAdjust.CellClick
        selectAdjust()
    End Sub
    Sub selectAdjust()
        If dataGVinvAdjust.RowCount > 0 Then
            If dataGVinvAdjust.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = dataGVinvAdjust.CurrentRow.Index

                txtcode.Text = dataGVinvAdjust.Rows(i).Cells(0).Value
                txtprodesc.Text = dataGVinvAdjust.Rows(i).Cells(1).Value
                txtunit.Text = dataGVinvAdjust.Rows(i).Cells(2).Value
                txtactual.Text = dataGVinvAdjust.Rows(i).Cells(4).Value
                txtunitp.Text = dataGVinvAdjust.Rows(i).Cells(3).Value
            End If
        End If
    End Sub
    Private Sub dataGVinvAdjust_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGVinvAdjust.CellContentClick

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If Not txtcode.Text = Nothing And CInt(txtactual.Text) > 0 Then

                sqlcode = "update ProductFile set INVQTY=" & (CInt(txtactual.Text)) * getQtyPerUnit(txtcode.Text, txtunit.Text) & " WHERE LOTNO='" & txtcode.Text & "'"
                insertQ(sqlcode)
                loadAdjust()
                TextBox10.Clear()
                txtcode.Clear()
                txtprodesc.Clear()
                txtunit.Text = ""
                txtactual.Clear()
                txtunitp.Clear()
            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)
            txtactual.Text = 0
            txtactual.Select()
        End Try


    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged
        Try
            Dim sql As String

            openDb()
            If TextBox10.Text = Nothing Then
                sql = "SELECT  lotno, Prod_description, Unit, " & accountType & ", INVQTY FROM  ProductFile"
            Else
                sql = "SELECT  lotno, Prod_description, Unit, " & accountType & ", INVQTY FROM  ProductFile where Prod_description like '%" & TextBox10.Text & "%'"

                
            End If
            Dim pldt As New DataTable
            pldt = displayData(sql)
            dataGVinvAdjust.DataSource = pldt
            dataGVinvAdjust.Refresh()
            closeDb()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub dataGVinvAdjust_SelectionChanged(sender As Object, e As EventArgs) Handles dataGVinvAdjust.SelectionChanged

        If dataGVinvAdjust.RowCount > 0 Then
            If dataGVinvAdjust.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = dataGVinvAdjust.CurrentRow.Index

                txtcode.Text = dataGVinvAdjust.Rows(i).Cells(0).Value.ToString
                txtprodesc.Text = dataGVinvAdjust.Rows(i).Cells(1).Value.ToString
                txtunit.Text = dataGVinvAdjust.Rows(i).Cells(2).Value.ToString
                txtactual.Text = dataGVinvAdjust.Rows(i).Cells(4).Value.ToString
                txtunitp.Text = dataGVinvAdjust.Rows(i).Cells(3).Value.ToString
            End If
        End If

    End Sub

    Private Sub datagvPriceUpdate_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagvPriceUpdate.CellClick
        If datagvPriceUpdate.RowCount > 0 Then
            If datagvPriceUpdate.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = datagvPriceUpdate.CurrentRow.Index

                txtpu_lotno.Text = datagvPriceUpdate.Rows(i).Cells(0).Value.ToString
                txtpu_desc.Text = datagvPriceUpdate.Rows(i).Cells(1).Value.ToString
                txtpu_unit.Text = datagvPriceUpdate.Rows(i).Cells(2).Value.ToString
                txtpu_retail.Text = datagvPriceUpdate.Rows(i).Cells(3).Value.ToString
                txtpu_wholesale.Checked = datagvPriceUpdate.Rows(i).Cells(4).Value.ToString
            End If
        End If
    End Sub
    Private Sub datagvPriceUpdate_SelectionChanged(sender As Object, e As EventArgs) Handles datagvPriceUpdate.SelectionChanged

        If datagvPriceUpdate.RowCount > 0 Then
            If datagvPriceUpdate.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = datagvPriceUpdate.CurrentRow.Index

                txtpu_lotno.Text = datagvPriceUpdate.Rows(i).Cells(0).Value.ToString
                txtpu_desc.Text = datagvPriceUpdate.Rows(i).Cells(1).Value.ToString
                txtpu_unit.Text = datagvPriceUpdate.Rows(i).Cells(2).Value.ToString
                txtpu_retail.Text = datagvPriceUpdate.Rows(i).Cells(3).Value.ToString
                txtpu_wholesale.Checked = datagvPriceUpdate.Rows(i).Cells(4).Value.ToString
            End If
        End If

    End Sub
    Sub InitializedThePropertyName()
        datagvPriceUpdate.Columns(3).DataPropertyName = accountType
        DataGVprodsearch.Columns(2).DataPropertyName = accountType
        'DGV_main.Columns(5).DataPropertyName = accountType
        datagvPriceUpdate.Columns(3).DataPropertyName = accountType
        dataGVinvAdjust.Columns(3).DataPropertyName = accountType
        dgProduct.Columns(3).DataPropertyName = accountType
    End Sub
    Private Sub datagvPriceUpdate_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles datagvPriceUpdate.CellContentClick

    End Sub

    Private Sub txtpu_search_TextChanged(sender As Object, e As EventArgs) Handles txtpu_search.TextChanged
        If Not txtpu_search.Text = Nothing Then
            '"SELECT  lotno, Prod_description, Unit, retail, wholesale, active FROM  ProductFile"
            'sqlcode = "SELECT  lotno, Prod_description, Unit, retail, wholesale, active FROM  ProductFile where Prod_description "
            Dim sql As String = "SELECT  lotno, Prod_description, Unit, " & accountType & ", wholesale, active FROM  ProductFile where prod_description like '%" & txtpu_search.Text & "%'"
            command = New OleDb.OleDbCommand(sql, conn)
            Dim da = New OleDbDataAdapter(command)
            Dim pldt As New DataTable
            da.Fill(pldt)
            ''priceUpdate.Tables.Add(pldt)

            datagvPriceUpdate.DataSource = pldt
            datagvPriceUpdate.Refresh()
            closeDb()


        End If
    End Sub


    Private Sub txtcusname_TextChanged(sender As Object, e As EventArgs) Handles txtcusname.TextChanged

    End Sub
    Dim chh = 0
    Private Sub CbStockTransf_DropDownClosed(sender As Object, e As EventArgs) Handles CbStockTransf.DropDownClosed
        chh = 1
    End Sub

    Private Sub CbStockTransf_GotFocus(sender As Object, e As EventArgs) Handles CbStockTransf.GotFocus
        If txtFromTo.Text = Nothing Or cbtransferT.Text = Nothing Then
            MessageBox.Show("Fill the details first")
            txtFromTo.Select()

        End If
    End Sub

    Private Sub CbStockTransf_KeyDown(sender As Object, e As KeyEventArgs) Handles CbStockTransf.KeyDown
        If e.KeyCode = Keys.Back Then
            CbStockTransf.Text = Nothing
        End If
    End Sub


    Private Sub CbStockTransf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbStockTransf.SelectedIndexChanged


        If cbproduct.Text = Nothing Then
            If chh = 1 Then
                txtpcode.Text = CbStockTransf.SelectedItem.Col2
                txtonhand.Text = CbStockTransf.SelectedItem.Col3
                'txtCol3.Text = cbproduct.SelectedItem.Col3
                'txtCol4.Text = cbproduct.SelectedItem.Col4
                'currentQty = cbproduct.SelectedItem.Col4


                'txtpcode.Text = ""
                'txtexp.Text = ""
                'txtCol3.Text = ""
                'txtCol4.Text = ""

                chh = 0
            Else
                txtpcode.Clear()
                txtonhand.Clear()
                'txtCol3.Text =
            End If
        End If



    End Sub

    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedIndex = 1 Then
            loadTodgProduct()
            autoNewProd()
        ElseIf TabControl2.SelectedIndex = 0 Then
            loadYr()
        ElseIf TabControl2.SelectedIndex = 2 Then
            'customer'
            loadCustomer()

        ElseIf TabControl2.SelectedIndex = 3 Then
            'supplier'
            loadSupplier()

        End If
    End Sub
    Sub loadCustomer()
        Try
            sqlcode = "select  name, address, ID, pricing from contacts"
            Dim dt As DataTable
            dt = displayData(sqlcode)
            DataGvCust.DataSource = dt
            DataGvCust.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.ToString & " contact developer")
        Finally

        End Try
    End Sub
    Sub loadSupplier()
        Try
            sqlcode = "select  ID, supname, address from supplier"
            Dim dt As DataTable
            dt = displayData(sqlcode)
            DataSupList.DataSource = dt
            DataSupList.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.ToString & " contact developer")
        Finally

        End Try
    End Sub
    Sub loadYr()
        Try
            sqlcode = "select DISTINCT year([DATE]) from INVHEAD"
            openDb()
            Dim newcommand As OleDb.OleDbCommand = conn.CreateCommand
            newcommand.CommandText = sqlcode
            Dim Newreader As OleDb.OleDbDataReader
            Newreader = newcommand.ExecuteReader
            If Newreader.HasRows Then
                cbmontYr.Items.Clear()
                While Newreader.Read
                    cbmontYr.Items.Add(Newreader(0).ToString)
                End While
            End If
            Newreader.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString & " contact developer")
        Finally

            closeDb()
        End Try
    End Sub
    Sub loadTodgProduct()
        Try
            sqlcode = "select lotno, Prod_description,Unit, " & accountType & " from ProductFile"
            Dim da As New OleDb.OleDbDataAdapter(sqlcode, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            dgProduct.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.ToString + " contact developer")
        End Try

    End Sub

    Private Sub txtProdNew_TextChanged(sender As Object, e As EventArgs) Handles txtProdNew.TextChanged
        If Not txtProdNew.Text = Nothing Then
            Try
                sqlcode = "select lotno, Prod_description,Unit, " & accountType & " from ProductFile where Prod_description like '%" & txtProdNew.Text & "%'"
                Dim da As New OleDb.OleDbDataAdapter(sqlcode, conn)
                Dim dt As New DataTable
                da.Fill(dt)
                dgProduct.DataSource = dt
            Catch ex As Exception
                MessageBox.Show(ex.ToString + " contact developer")
            End Try
        Else
            loadTodgProduct()
        End If
    End Sub

    Private Sub btnAddProd_Click(sender As Object, e As EventArgs) Handles btnAddProd.Click
        If cbNewCat.Text = Nothing Or txtNewDesc.Text = Nothing Or txtNewLot.Text = Nothing Or txtNewExp.Text = Nothing Or cbNewUnit.Text = Nothing Or txtNewQty.Text = Nothing Then
            MessageBox.Show("Fill all the details")
            Exit Sub
        Else
            If dupProduct() = False Then


                sqlcode = "Insert into ProductFile(lotno, Prod_description,Unit,qtyperunit, expiry, prod_Category) values(" &
                "'" & txtNewLot.Text & "', '" & txtNewDesc.Text.Replace("'", "") & "', '" & cbNewUnit.Text & "', '" & txtNewQty.Text & "','" & txtNewExp.Text & "', " & cbNewCat.SelectedIndex & ")"
                insertQ(sqlcode)

                cbNewCat.Text = Nothing
                txtNewDesc.Clear()
                txtNewLot.Clear()
                txtNewExp.Clear()
                cbNewUnit.Text = Nothing
                txtNewQty.Clear()
                autoNewProd()
                loadTodgProduct()
            End If
        End If




    End Sub
    Function dupProduct()
        Dim hasdupProd As Boolean = False
        sqlcode = "select * from  ProductFile where lotno='" & txtNewLot.Text & "' and unit='" & cbNewUnit.Text & "'"
        Try
            openDb()
            Dim newcommand As OleDb.OleDbCommand = conn.CreateCommand
            newcommand.CommandText = sqlcode
            Dim Newreader As OleDb.OleDbDataReader
            Newreader = newcommand.ExecuteReader
            If Newreader.HasRows Then
                MessageBox.Show("Duplicate record not allowed!")
                hasdupProd = True
            End If
            Newreader.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString & " contact developer")
        Finally

            closeDb()
        End Try




        Return hasdupProd

    End Function
    Private Sub txtNewDesc_LostFocus(sender As Object, e As EventArgs) Handles txtNewDesc.LostFocus
        If Not txtNewDesc.Text = Nothing Then
            sqlcode = "select lotno,Unit,qtyperunit, expiry,Prod_Category from ProductFile where Prod_description='" & txtNewDesc.Text & "'"
            Try
                openDb()
                Dim newcommand As OleDb.OleDbCommand = conn.CreateCommand
                newcommand.CommandText = sqlcode
                Dim Newreader As OleDb.OleDbDataReader
                Newreader = newcommand.ExecuteReader
                Dim replce As String = Nothing
                Dim replce1 As String = Nothing
                Dim replce2 As String = Nothing
                Dim replce3 As String = Nothing
                If Newreader.HasRows Then
                    If Newreader.Read Then
                        If Newreader(0).ToString = Nothing Then
                            replce = "-"
                        Else
                            replce = Newreader(0).ToString
                        End If
                        If Newreader(1).ToString = Nothing Then
                            replce1 = "-"
                        Else
                            replce1 = Newreader(1).ToString
                        End If
                        If Newreader(2).ToString = Nothing Then
                            replce2 = "-"
                        Else
                            replce2 = Newreader(2).ToString
                        End If
                        If Newreader(3).ToString = Nothing Then
                            replce3 = "-"
                        Else
                            replce3 = Newreader(3).ToString
                        End If

                        txtNewLot.Text = replce
                        cbNewUnit.Text = replce1
                        txtNewQty.Text = replce2
                        txtNewExp.Text = replce3
                        cbNewCat.Text = cbNewCat.Items(CInt(Newreader(4))).ToString
                        oldLotno = txtNewLot.Text
                    End If
                End If
                Newreader.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString & " contact developer")
            Finally

                closeDb()
            End Try
        End If



    End Sub

    Private Sub txtNewDesc_TextChanged(sender As Object, e As EventArgs) Handles txtNewDesc.TextChanged
        If Not txtNewDesc.Text = Nothing Then
            sqlcode = "select lotno,Unit,qtyperunit, expiry, Prod_Category from ProductFile where Prod_description='" & txtNewDesc.Text & "'"
            Try
                openDb()
                Dim newcommand As OleDb.OleDbCommand = conn.CreateCommand
                newcommand.CommandText = sqlcode
                Dim Newreader As OleDb.OleDbDataReader
                Newreader = newcommand.ExecuteReader
                Dim replce As String = Nothing
                Dim replce1 As String = Nothing
                Dim replce2 As String = Nothing
                Dim replce3 As String = Nothing
                Dim shit As Integer = 0
                If Newreader.HasRows Then

                    If Newreader.Read = True Then
                        If Newreader(0).ToString = Nothing Then
                            replce = "-"
                        Else
                            replce = Newreader(0).ToString
                        End If
                        If Newreader(1).ToString = Nothing Then
                            replce1 = "-"
                        Else
                            replce1 = Newreader(1).ToString
                        End If
                        If Newreader(2).ToString = Nothing Then
                            replce2 = "-"
                        Else
                            replce2 = Newreader(2).ToString
                        End If
                        If Newreader(3).ToString = Nothing Then
                            replce3 = "-"
                        Else
                            replce3 = Newreader(3).ToString
                        End If
                        If Newreader(4).ToString = Nothing Then
                            MessageBox.Show("No Category")
                        Else
                            shit = CInt(Newreader(4))
                        End If

                        txtNewLot.Text = replce
                        cbNewUnit.Text = replce1
                        txtNewQty.Text = replce2
                        txtNewExp.Text = replce3
                        cbNewCat.SelectedIndex = shit
                        oldLotno = txtNewLot.Text
                    End If
                End If
                Newreader.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString & " contact developer")
            Finally

                closeDb()
            End Try
        End If

    End Sub

    Private Sub btnNewProd_Click(sender As Object, e As EventArgs) Handles btnNewProd.Click
        cbNewCat.Text = Nothing
        txtNewDesc.Clear()
        txtNewLot.Clear()
        txtNewExp.Clear()
        cbNewUnit.Text = Nothing
        txtNewQty.Clear()
        oldLotno = Nothing
    End Sub
    Dim oldLotno As String

    Private Sub btnEditProd_Click(sender As Object, e As EventArgs) Handles btnEditProd.Click
        If cbNewCat.Text = Nothing Or txtNewDesc.Text = Nothing Or txtNewLot.Text = Nothing Or txtNewExp.Text = Nothing Or cbNewUnit.Text = Nothing Or txtNewQty.Text = Nothing Then
            MessageBox.Show("Fill all the details")
            Exit Sub
        Else
            sqlcode = "update ProductFile set lotno='" & txtNewLot.Text & "', Prod_description='" & txtNewDesc.Text.Replace("'", "") & "', expiry='" & txtNewExp.Text & "' where lotno='" & oldLotno & "'"
            insertQ(sqlcode)
            sqlcode = "update ProductFile set qtyperunit= '" & txtNewQty.Text & "'  where lotno='" & txtNewLot.Text & "' and Unit='" & cbNewUnit.Text & "'"
            insertQ(sqlcode)
            loadTodgProduct()
            cbNewCat.Text = Nothing
            txtNewDesc.Clear()
            txtNewLot.Clear()
            txtNewExp.Clear()
            cbNewUnit.Text = Nothing
            txtNewQty.Clear()
            autoNewProd()
        End If
    End Sub

    Private Sub dgProduct_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProduct.CellClick
        If dgProduct.RowCount > 0 Then
            If dgProduct.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = dgProduct.CurrentRow.Index

                txtNewDesc.Text = dgProduct.Rows(i).Cells(1).Value.ToString
                cbNewUnit.Text = dgProduct.Rows(i).Cells(2).Value.ToString
            End If
        End If

    End Sub

 
    Private Sub dgProduct_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgProduct.CellContentClick

    End Sub
    Dim d As Integer

    Private Sub dgProduct_SelectionChanged(sender As Object, e As EventArgs) Handles dgProduct.SelectionChanged
        If dgProduct.RowCount > 0 Then
            If dgProduct.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = dgProduct.CurrentRow.Index
                txtNewDesc.Text = dgProduct.Rows(i).Cells(1).Value.ToString
                cbNewUnit.Text = dgProduct.Rows(i).Cells(2).Value.ToString
              
            End If
        End If
    End Sub

    Private Sub cbunit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbunit.SelectedIndexChanged
        Try

            sqlcode = "select " & accountType & "  from ProductFile where LOTNO='" & txtlotno.Text & "' and unit ='" & cbunit.Text & "'"

            openDb()
            Dim newcommand As OleDb.OleDbCommand = conn.CreateCommand
            newcommand.CommandText = sqlcode
            Dim Newreader As OleDb.OleDbDataReader
            Newreader = newcommand.ExecuteReader()
            If Newreader.HasRows Then
                If Newreader.Read Then
                    txtprice.Text = Newreader(0).ToString
                End If
            End If
            If cbprice.Text = "Price 3" Then
                txtprice.Text = "0.00"
            End If
            closeDb()

        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub txtpu_lotno_TextChanged(sender As Object, e As EventArgs) Handles txtpu_lotno.TextChanged
        sqlcode = "select unit  from ProductFile where LOTNO='" & txtpu_lotno.Text & "'"
        'MessageBox.Show(sqlcode)
        openDb()
        command.CommandText = sqlcode
        reader = command.ExecuteReader
        txtpu_unit.Items.Clear()
        While reader.Read

            txtpu_unit.Items.Add(reader(0).ToString)

        End While
        closeDb()
    End Sub

    Private Sub txtpu_unit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtpu_unit.SelectedIndexChanged
        Try
            sqlcode = "select " & accountType & "  from ProductFile where LOTNO='" & txtpu_lotno.Text & "' and unit ='" & txtpu_unit.Text & "'"
            openDb()
            Dim newcommand As OleDb.OleDbCommand = conn.CreateCommand
            newcommand.CommandText = sqlcode
            Dim Newreader As OleDb.OleDbDataReader
            Newreader = newcommand.ExecuteReader()
            If Newreader.HasRows Then
                If Newreader.Read Then
                    txtpu_retail.Text = Newreader(0).ToString
                End If
            End If

            closeDb()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub cbNewUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNewUnit.SelectedIndexChanged
        Try
      
            txtNewQty.Text = getQtyPerUnit(txtNewLot.Text, cbNewUnit.Text)

        
        Catch ex As Exception
            MessageBox.Show(ex.ToString)

        End Try
    End Sub

    Private Sub txtNewLot_TextChanged(sender As Object, e As EventArgs) Handles txtNewLot.TextChanged
        'If Not txtNewDesc.Text = Nothing Then
        '    sqlcode = "select Prod_Category from ProductFile where lotno='" & txtNewLot.Text & "'"
        '    Try
        '        openDb()
        '        Dim newcommand As OleDb.OleDbCommand = conn.CreateCommand
        '        newcommand.CommandText = sqlcode
        '        Dim Newreader As OleDb.OleDbDataReader
        '        Newreader = newcommand.ExecuteReader
        '        If Newreader.HasRows Then
        '            If Newreader.Read Then
        '                cbNewCat.SelectedIndex = Newreader.GetValue(0)
        '            End If
        '        End If
        '        Newreader.Close()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString & " contact developer")
        '    Finally

        '        closeDb()
        '    End Try
        'End If
    End Sub

    Private Sub txtcode_TextChanged(sender As Object, e As EventArgs) Handles txtcode.TextChanged
        sqlcode = "select unit  from ProductFile where LOTNO='" & txtcode.Text & "'"
        'MessageBox.Show(sqlcode)
        openDb()
        command.CommandText = sqlcode
        reader = command.ExecuteReader
        txtunit.Items.Clear()
        While reader.Read

            txtunit.Items.Add(reader(0).ToString)

        End While
        closeDb()
    End Sub

    Private Sub txtFromToqty_TextChanged(sender As Object, e As EventArgs) Handles txtFromToqty.TextChanged

    End Sub
    Dim onhand As Integer

    Private Sub txtonhand_TextChanged(sender As Object, e As EventArgs) Handles txtonhand.TextChanged

    End Sub
    Sub getNextInv()
        Try
            sqlcode = "SELECT MAX(INV) from INVHEAD"
            openDb()
            command.CommandText = sqlcode
            Dim Newreader As OleDb.OleDbDataReader
            Newreader = command.ExecuteReader()
            If Newreader.Read Then
                txtinvoice.Text = CInt(Newreader(0)) + 1
            End If
            closeDb()
        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        End Try



    End Sub
    Private Sub txtpcode_TextChanged(sender As Object, e As EventArgs) Handles txtpcode.TextChanged
        sqlcode = "select unit  from ProductFile where LOTNO='" & txtpcode.Text & "'"
        'MessageBox.Show(sqlcode)
        openDb()
        Dim newcommand As New OleDb.OleDbCommand(sqlcode, conn)
        Dim Newreader As OleDb.OleDbDataReader
        Newreader = newcommand.ExecuteReader()
        If Newreader.HasRows Then
            cbUnitTrans.Items.Clear()
            While Newreader.Read

                cbUnitTrans.Items.Add(Newreader(0).ToString)

            End While
        End If



       
        Newreader.Close()
        closeDb()


    End Sub

 
    Private Sub btnDailyByDate_Click(sender As Object, e As EventArgs) Handles btnDailyByDate.Click
        thisDate = DTPthisDate.Value.ToShortDateString
        frmByDate.Show()

    End Sub


    Private Sub btnMontlyRpt_Click(sender As Object, e As EventArgs) Handles btnMontlyRpt.Click
        thisMonth = cbmonthrpt.SelectedIndex
        thisYr = cbmontYr.Text
        frmByMonth.Show()
    End Sub
    Private Sub txtRptCustomer_TextChanged(sender As Object, e As EventArgs) Handles txtRptCustomer.TextChanged
        loadCustomerRpt()
    End Sub


    Private Sub dataGvRpt_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGvRpt.CellClick
        If dataGvRpt.RowCount > 0 Then
            If dataGvRpt.SelectedRows.Count > 0 Then
                Dim rPos As Integer = dataGvRpt.CurrentCell.ColumnIndex
                Dim i As Integer = dataGvRpt.CurrentRow.Index

                'addThis = dataGvRpt.Rows(i).Cells(0).Value
                previewInvoice = dataGvRpt.Rows(i).Cells(1).Value
                'thisUnit = dataGvRpt.Rows(i).Cells(2).Value
                'delThis = dataGvRpt.Rows(i).Cells(3).Value
                'thisLotno = delThis
                ''thisExpiry = DGV_main.Rows(i).Cells(4).Value
                'thisprice = dataGvRpt.Rows(i).Cells(5).Value
                'thisamount = dataGvRpt.Rows(i).Cells(6).Value
                'If e.ColumnIndex = 1 Then ' getting the desc for next column




            End If
        End If

    End Sub

    Private Sub dataGvRpt_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGvRpt.CellContentClick

    End Sub

    Private Sub dataGvRpt_SelectionChanged(sender As Object, e As EventArgs) Handles dataGvRpt.SelectionChanged
        If dataGvRpt.RowCount > 0 Then
            If dataGvRpt.SelectedRows.Count > 0 Then
                Dim rPos As Integer = dataGvRpt.CurrentCell.ColumnIndex
                Dim i As Integer = dataGvRpt.CurrentRow.Index

                'addThis = dataGvRpt.Rows(i).Cells(0).Value
                previewInvoice = dataGvRpt.Rows(i).Cells(1).Value
                'thisUnit = dataGvRpt.Rows(i).Cells(2).Value
                'delThis = dataGvRpt.Rows(i).Cells(3).Value
                'thisLotno = delThis
                ''thisExpiry = DGV_main.Rows(i).Cells(4).Value
                'thisprice = dataGvRpt.Rows(i).Cells(5).Value
                'thisamount = dataGvRpt.Rows(i).Cells(6).Value
                'If e.ColumnIndex = 1 Then ' getting the desc for next column
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If dataGvRpt.SelectedRows.Count > 0 Then
            Form2.Show()
        End If
    End Sub

    Private Sub btnAddCust_Click(sender As Object, e As EventArgs) Handles btnAddCust.Click
        If Not txtnewCust.Text = Nothing And Not txtnewCustAdd.Text = Nothing And Not cbNewCustPr.Text = Nothing Then
            Try
                sqlcode = "insert into contacts (name, address,pricing)values('" & txtnewCust.Text & "', '" & txtnewCustAdd.Text & "','" & cbNewCustPr.Text & "')"
                insertQ(sqlcode)
                newCust()
                loadCustomer()
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
         
        End If
    End Sub
    Sub newCust()
        txtnewCust.Text = Nothing
        txtnewCustAdd.Text = Nothing
        cbNewCustPr.Text = Nothing
    End Sub

    Private Sub DataGvCust_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGvCust.CellClick
        If DataGvCust.RowCount > 0 Then
            If DataGvCust.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = DataGvCust.CurrentRow.Index
                cusNewId = DataGvCust.Rows(i).Cells(2).Value.ToString
                MessageBox.Show(cusNewId)
                txtnewCust.Text = DataGvCust.Rows(i).Cells(0).Value.ToString
                txtnewCustAdd.Text = DataGvCust.Rows(i).Cells(1).Value.ToString
                cbNewCustPr.Text = DataGvCust.Rows(i).Cells(3).Value.ToString
            End If
        End If
    End Sub

    Private Sub DataGvCust_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGvCust.CellContentClick

    End Sub
    Dim cusNewId As String = Nothing
    Private Sub DataGvCust_SelectionChanged(sender As Object, e As EventArgs) Handles DataGvCust.SelectionChanged
        If DataGvCust.RowCount > 0 Then
            If DataGvCust.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = DataGvCust.CurrentRow.Index
                cusNewId = DataGvCust.Rows(i).Cells(2).Value.ToString
                txtnewCust.Text = DataGvCust.Rows(i).Cells(0).Value.ToString
                txtnewCustAdd.Text = DataGvCust.Rows(i).Cells(1).Value.ToString
                cbNewCustPr.Text = DataGvCust.Rows(i).Cells(3).Value.ToString
            End If
        End If
    End Sub

    Private Sub BtnUpdateCust_Click(sender As Object, e As EventArgs) Handles BtnUpdateCust.Click
        Try
            sqlcode = "update contacts set name='" & txtnewCust.Text & "', address='" & txtnewCustAdd.Text & "', pricing='" & cbNewCustPr.Text & "' where ID=" & cusNewId & ""
            insertQ(sqlcode)
            newCust()
            loadCustomer()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Dim supid As Integer
    Private Sub DataSupList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataSupList.CellContentClick
        If DataSupList.RowCount > 0 Then
            If DataSupList.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = DataSupList.CurrentRow.Index
                supid = CInt(DataSupList.Rows(i).Cells(0).Value.ToString)
                txtNewSup.Text = DataSupList.Rows(i).Cells(1).Value.ToString
                txtNewSupAdd.Text = DataSupList.Rows(i).Cells(2).Value.ToString
            End If
        End If
    End Sub

    Private Sub DataSupList_SelectionChanged(sender As Object, e As EventArgs) Handles DataSupList.SelectionChanged
        If DataSupList.RowCount > 0 Then
            If DataSupList.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = DataSupList.CurrentRow.Index
                supid = CInt(DataSupList.Rows(i).Cells(0).Value.ToString)
                txtNewSup.Text = DataSupList.Rows(i).Cells(1).Value.ToString
                txtNewSupAdd.Text = DataSupList.Rows(i).Cells(2).Value.ToString
            End If
        End If
    End Sub

    Private Sub btnSupAdd_Click(sender As Object, e As EventArgs) Handles btnSupAdd.Click
        If Not txtNewSup.Text = Nothing And Not txtNewSupAdd.Text = Nothing Then
            sqlcode = "insert into supplier(supname,address)values('" & txtNewSup.Text & "','" & txtNewSupAdd.Text & "')"
            insertQ(sqlcode)
            clearSup()
            loadSupplier()

        End If
    End Sub
    Sub clearSup()
        txtNewSup.Text = Nothing
        txtNewSupAdd.Text = Nothing
    End Sub

    Private Sub btnNewSup_Click(sender As Object, e As EventArgs) Handles btnNewSup.Click
        clearSup()
    End Sub

    Private Sub btnSupUpdate_Click(sender As Object, e As EventArgs) Handles btnSupUpdate.Click
        If Not txtNewSup.Text = Nothing And Not txtNewSupAdd.Text = Nothing Then
            sqlcode = "update supplier set supname='" & txtNewSup.Text & "',address='" & txtNewSupAdd.Text & "' where id=" & supid & ""
            insertQ(sqlcode)
            clearSup()
            loadSupplier()
        End If
    End Sub

    Private Sub DataGVprodsearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGVprodsearch.CellContentClick

    End Sub

    Private Sub btnexit_Click(sender As Object, e As EventArgs) Handles btnexit.Click

        Me.Hide()
        frmMenu.Show()

    End Sub
    Dim thisinvo As String

    Private Sub DataTermExp_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataTermExp.CellClick
        If DataTermExp.RowCount > 0 Then
            If DataTermExp.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = DataTermExp.CurrentRow.Index
                thisinvo = DataTermExp.Rows(i).Cells(0).Value.ToString

                'txtnewCust.Text = DataTermExp.Rows(i).Cells(0).Value.ToString
                'txtnewCustAdd.Text = DataTermExp.Rows(i).Cells(1).Value.ToString
                'cbNewCustPr.Text = DataTermExp.Rows(i).Cells(3).Value.ToString
            End If
        End If
    End Sub
    Private Sub DataTermExp_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataTermExp.CellContentClick
        
    End Sub

    Private Sub DataTermExp_SelectionChanged(sender As Object, e As EventArgs) Handles DataTermExp.SelectionChanged
        If DataTermExp.RowCount > 0 Then
            If DataTermExp.SelectedRows.Count > 0 Then
                'Dim rPos As Integer = dataGVinvAdjust.CurrentCell.ColumnIndex
                Dim i As Integer = DataTermExp.CurrentRow.Index
                thisinvo = DataTermExp.Rows(i).Cells(0).Value.ToString

                'txtnewCust.Text = DataTermExp.Rows(i).Cells(0).Value.ToString
                'txtnewCustAdd.Text = DataTermExp.Rows(i).Cells(1).Value.ToString
                'cbNewCustPr.Text = DataTermExp.Rows(i).Cells(3).Value.ToString
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            sqlcode = "update INVHEAD set TERM=0 WHERE invno='" & thisinvo & "'"
            insertQ(sqlcode)
            loadTermExp()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class
