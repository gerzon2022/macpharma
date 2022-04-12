<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReport
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.SALES_TABLEBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Mydataset = New MacPharma.mydataset()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SALES_TABLETableAdapter = New MacPharma.mydatasetTableAdapters.SALES_TABLETableAdapter()
        CType(Me.SALES_TABLEBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Mydataset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SALES_TABLEBindingSource
        '
        Me.SALES_TABLEBindingSource.DataMember = "SALES_TABLE"
        Me.SALES_TABLEBindingSource.DataSource = Me.Mydataset
        '
        'Mydataset
        '
        Me.Mydataset.DataSetName = "mydataset"
        Me.Mydataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet2"
        ReportDataSource1.Value = Me.SALES_TABLEBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "MacPharma.daily.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1028, 473)
        Me.ReportViewer1.TabIndex = 0
        '
        'SALES_TABLETableAdapter
        '
        Me.SALES_TABLETableAdapter.ClearBeforeFill = True
        '
        'frmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 473)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmReport"
        Me.Text = "frmReport"
        CType(Me.SALES_TABLEBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Mydataset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Mydataset As MacPharma.mydataset
    Friend WithEvents SALES_TABLEBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SALES_TABLETableAdapter As MacPharma.mydatasetTableAdapters.SALES_TABLETableAdapter


End Class
