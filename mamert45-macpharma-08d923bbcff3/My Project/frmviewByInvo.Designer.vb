<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmviewByInvo
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
        Me.indiInvoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.mydataset = New MacPharma.mydataset()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.indiInvoTableAdapter = New MacPharma.mydatasetTableAdapters.indiInvoTableAdapter()
        CType(Me.indiInvoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mydataset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'indiInvoBindingSource
        '
        Me.indiInvoBindingSource.DataMember = "indiInvo"
        Me.indiInvoBindingSource.DataSource = Me.mydataset
        '
        'mydataset
        '
        Me.mydataset.DataSetName = "mydataset"
        Me.mydataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.indiInvoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "MacPharma.rpt_invoiceno.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(946, 578)
        Me.ReportViewer1.TabIndex = 0
        '
        'indiInvoTableAdapter
        '
        Me.indiInvoTableAdapter.ClearBeforeFill = True
        '
        'frmviewByInvo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 578)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmviewByInvo"
        Me.Text = "frmviewByInvo"
        CType(Me.indiInvoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mydataset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents indiInvoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents mydataset As MacPharma.mydataset
    Friend WithEvents indiInvoTableAdapter As MacPharma.mydatasetTableAdapters.indiInvoTableAdapter
End Class
