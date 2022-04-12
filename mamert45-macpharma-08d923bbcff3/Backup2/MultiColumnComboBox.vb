' MultiColumnComboBox, written by mkaatr 2011
' this code is free for anyone to use. It is provided as it is without any warranty. 



<System.ComponentModel.ComplexBindingProperties("SaveDataSource", "SaveDataMember")> _
Public Class MultiColumnComboBox

    Private vDataSource As BindingSource
    Private vDataMember As String
    Private WithEvents vSaveDataSource As BindingSource
    Private vSaveMember As String

    Private vWin As New DataGridView


    Public Property DisplayDataSource() As BindingSource
        Get
            Return vDataSource
        End Get
        Set(ByVal value As BindingSource)
            Try
                vDataSource = value
                vWin.DataSource = vDataSource
                TX.DataBindings.Clear()
                If vDataMember <> "" Then
                    Dim BindingX1 = New Binding("Text", vDataSource, vDataMember)
                    TX.DataBindings.Clear()
                    TX.DataBindings.Add(BindingX1)
                End If
            Catch ex As Exception

            End Try
        End Set
    End Property

    Public Property SaveDataSource() As BindingSource
        Get
            Return vSaveDataSource
        End Get
        Set(ByVal value As BindingSource)
            vSaveDataSource = value
        End Set
    End Property

    Public Property DisplayDataMember() As String
        Get
            Return vDataMember
        End Get
        Set(ByVal value As String)
            vDataMember = value
            If vDataSource IsNot Nothing Then
                Dim BindingX1 = New Binding("Text", vDataSource, vDataMember)
                TX.DataBindings.Clear()
                TX.DataBindings.Add(BindingX1)
            End If
        End Set
    End Property

    Public Property SaveDataMember() As String
        Get
            Return vSaveMember
        End Get
        Set(ByVal value As String)
            vSaveMember = value
        End Set
    End Property




    Private Sub MultiColumnComboBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TX.Width = Me.Width - BTM.Width
        TX.Left = 0
        TX.Top = 0
        Me.Height = TX.Height
        BTM.Height = TX.Height
        BTM.Left = TX.Width
        BTM.Top = 0

        AddHandler vWin.LostFocus, AddressOf DGVLostFocus
        AddHandler vWin.MouseLeave, AddressOf DGVLostFocus
        AddHandler vWin.Click, AddressOf DGVClicked

        vWin.ReadOnly = True
        vWin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        vWin.AllowUserToAddRows = False
        vWin.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        vWin.MultiSelect = False
        vWin.RowHeadersVisible = False
    End Sub

    Private Sub DGVLostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        vWin.Visible = False
    End Sub

    Private Sub DGVClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        If vWin.SelectedRows.Count = 0 Then
            Exit Sub
        End If
        Try
            vSaveDataSource.Current.item(vSaveMember) = vWin.SelectedRows(0).Cells(vSaveMember).Value
        Catch ex As Exception

        End Try
        vWin.Visible = False
    End Sub

    Private Sub MultiColumnComboBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        TX.Width = Me.Width - BTM.Width
        TX.Left = 0
        TX.Top = 0
        Me.Height = TX.Height
        BTM.Height = TX.Height
        BTM.Left = TX.Width
        BTM.Top = 0
    End Sub

    Private Sub BTM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTM.Click
        vWin.Width = Me.Width
        vWin.Left = Me.Left
        vWin.Parent = Me.Parent
        vWin.Height = 200
        vWin.Visible = True
        vWin.Top = Me.Top + Me.Height
        vWin.BringToFront()
        vWin.Focus()
    End Sub





    Private Sub vSaveDataSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vSaveDataSource.CurrentChanged
        Try
            Dim BS As BindingSource
            BS = vDataSource
            Dim Index = BS.Find(vSaveMember, vSaveDataSource.Current.item(vSaveMember))
            BS.Position = Index
        Catch ex As Exception

        End Try
    End Sub
End Class
