<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim HouseNoLabel As System.Windows.Forms.Label
        Dim HouseAddressLabel As System.Windows.Forms.Label
        Dim PersonNoLabel As System.Windows.Forms.Label
        Me.TestDataSet = New TestMultiColumnComboBox.testDataSet
        Me.HousesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HousesTableAdapter = New TestMultiColumnComboBox.testDataSetTableAdapters.HousesTableAdapter
        Me.TableAdapterManager = New TestMultiColumnComboBox.testDataSetTableAdapters.TableAdapterManager
        Me.HousesBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.HousesBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.HouseNoTextBox = New System.Windows.Forms.TextBox
        Me.HouseAddressTextBox = New System.Windows.Forms.TextBox
        Me.PersonNoTextBox = New System.Windows.Forms.TextBox
        Me.PersonBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PersonTableAdapter = New TestMultiColumnComboBox.testDataSetTableAdapters.PersonTableAdapter
        Me.MultiColumnComboBox1 = New MultiColumnComboBox.MultiColumnComboBox
        HouseNoLabel = New System.Windows.Forms.Label
        HouseAddressLabel = New System.Windows.Forms.Label
        PersonNoLabel = New System.Windows.Forms.Label
        CType(Me.TestDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HousesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HousesBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HousesBindingNavigator.SuspendLayout()
        CType(Me.PersonBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TestDataSet
        '
        Me.TestDataSet.DataSetName = "testDataSet"
        Me.TestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'HousesBindingSource
        '
        Me.HousesBindingSource.DataMember = "Houses"
        Me.HousesBindingSource.DataSource = Me.TestDataSet
        '
        'HousesTableAdapter
        '
        Me.HousesTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.HousesTableAdapter = Me.HousesTableAdapter
        Me.TableAdapterManager.PersonTableAdapter = Me.PersonTableAdapter
        Me.TableAdapterManager.UpdateOrder = TestMultiColumnComboBox.testDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'HousesBindingNavigator
        '
        Me.HousesBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.HousesBindingNavigator.BindingSource = Me.HousesBindingSource
        Me.HousesBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.HousesBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.HousesBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.HousesBindingNavigatorSaveItem})
        Me.HousesBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.HousesBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.HousesBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.HousesBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.HousesBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.HousesBindingNavigator.Name = "HousesBindingNavigator"
        Me.HousesBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.HousesBindingNavigator.Size = New System.Drawing.Size(617, 25)
        Me.HousesBindingNavigator.TabIndex = 0
        Me.HousesBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 15)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 6)
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 20)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'HousesBindingNavigatorSaveItem
        '
        Me.HousesBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.HousesBindingNavigatorSaveItem.Image = CType(resources.GetObject("HousesBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.HousesBindingNavigatorSaveItem.Name = "HousesBindingNavigatorSaveItem"
        Me.HousesBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 23)
        Me.HousesBindingNavigatorSaveItem.Text = "Save Data"
        '
        'HouseNoLabel
        '
        HouseNoLabel.AutoSize = True
        HouseNoLabel.Location = New System.Drawing.Point(59, 39)
        HouseNoLabel.Name = "HouseNoLabel"
        HouseNoLabel.Size = New System.Drawing.Size(57, 13)
        HouseNoLabel.TabIndex = 1
        HouseNoLabel.Text = "House No:"
        '
        'HouseNoTextBox
        '
        Me.HouseNoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.HousesBindingSource, "HouseNo", True))
        Me.HouseNoTextBox.Location = New System.Drawing.Point(148, 36)
        Me.HouseNoTextBox.Name = "HouseNoTextBox"
        Me.HouseNoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.HouseNoTextBox.TabIndex = 2
        '
        'HouseAddressLabel
        '
        HouseAddressLabel.AutoSize = True
        HouseAddressLabel.Location = New System.Drawing.Point(59, 65)
        HouseAddressLabel.Name = "HouseAddressLabel"
        HouseAddressLabel.Size = New System.Drawing.Size(83, 13)
        HouseAddressLabel.TabIndex = 3
        HouseAddressLabel.Text = "House Address:"
        '
        'HouseAddressTextBox
        '
        Me.HouseAddressTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.HousesBindingSource, "HouseAddress", True))
        Me.HouseAddressTextBox.Location = New System.Drawing.Point(148, 62)
        Me.HouseAddressTextBox.Name = "HouseAddressTextBox"
        Me.HouseAddressTextBox.Size = New System.Drawing.Size(100, 20)
        Me.HouseAddressTextBox.TabIndex = 4
        '
        'PersonNoLabel
        '
        PersonNoLabel.AutoSize = True
        PersonNoLabel.Location = New System.Drawing.Point(59, 91)
        PersonNoLabel.Name = "PersonNoLabel"
        PersonNoLabel.Size = New System.Drawing.Size(60, 13)
        PersonNoLabel.TabIndex = 5
        PersonNoLabel.Text = "Person No:"
        '
        'PersonNoTextBox
        '
        Me.PersonNoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.HousesBindingSource, "PersonNo", True))
        Me.PersonNoTextBox.Location = New System.Drawing.Point(148, 88)
        Me.PersonNoTextBox.Name = "PersonNoTextBox"
        Me.PersonNoTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PersonNoTextBox.TabIndex = 6
        '
        'PersonBindingSource
        '
        Me.PersonBindingSource.DataMember = "Person"
        Me.PersonBindingSource.DataSource = Me.TestDataSet
        '
        'PersonTableAdapter
        '
        Me.PersonTableAdapter.ClearBeforeFill = True
        '
        'MultiColumnComboBox1
        '
        Me.MultiColumnComboBox1.DisplayDataMember = "PersonName"
        Me.MultiColumnComboBox1.DisplayDataSource = Me.PersonBindingSource
        Me.MultiColumnComboBox1.Location = New System.Drawing.Point(148, 114)
        Me.MultiColumnComboBox1.Name = "MultiColumnComboBox1"
        Me.MultiColumnComboBox1.SaveDataMember = "PersonNo"
        Me.MultiColumnComboBox1.SaveDataSource = Me.HousesBindingSource
        Me.MultiColumnComboBox1.Size = New System.Drawing.Size(396, 20)
        Me.MultiColumnComboBox1.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 438)
        Me.Controls.Add(Me.MultiColumnComboBox1)
        Me.Controls.Add(HouseNoLabel)
        Me.Controls.Add(Me.HouseNoTextBox)
        Me.Controls.Add(HouseAddressLabel)
        Me.Controls.Add(Me.HouseAddressTextBox)
        Me.Controls.Add(PersonNoLabel)
        Me.Controls.Add(Me.PersonNoTextBox)
        Me.Controls.Add(Me.HousesBindingNavigator)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TestDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HousesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HousesBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HousesBindingNavigator.ResumeLayout(False)
        Me.HousesBindingNavigator.PerformLayout()
        CType(Me.PersonBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TestDataSet As TestMultiColumnComboBox.testDataSet
    Friend WithEvents HousesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HousesTableAdapter As TestMultiColumnComboBox.testDataSetTableAdapters.HousesTableAdapter
    Friend WithEvents TableAdapterManager As TestMultiColumnComboBox.testDataSetTableAdapters.TableAdapterManager
    Friend WithEvents HousesBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HousesBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents PersonTableAdapter As TestMultiColumnComboBox.testDataSetTableAdapters.PersonTableAdapter
    Friend WithEvents HouseNoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents HouseAddressTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PersonNoTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PersonBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents MultiColumnComboBox1 As MultiColumnComboBox.MultiColumnComboBox

End Class
