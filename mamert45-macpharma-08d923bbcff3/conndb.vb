Imports System.Data.OleDb.OleDbConnection
Module conndb
    Dim Provider As String = "Microsoft.Jet.OLEDB.4.0;Data source="
    Public connstring As String = My.Settings.myconnectionString
    Public sqlcode = Nothing
    Public conn As New OleDb.OleDbConnection
    Public command As OleDb.OleDbCommand = conn.CreateCommand
    'Public command As New OleDb.OleDbCommand=conn.OleDbCommand
    Public reader As OleDb.OleDbDataReader
    Public dataAdp As New OleDb.OleDbDataAdapter



End Module
