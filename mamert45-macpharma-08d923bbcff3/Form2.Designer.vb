<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.IndiInvoBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.mydataset1 = New MacPharma.mydataset1()
        Me.indiInvoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.indiInvoTableAdapter = New MacPharma.mydataset1TableAdapters.indiInvoTableAdapter()
        CType(Me.IndiInvoBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mydataset1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.indiInvoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'IndiInvoBindingSource1
        '
        Me.IndiInvoBindingSource1.DataMember = "indiInvo"
        Me.IndiInvoBindingSource1.DataSource = Me.mydataset1
        '
        'mydataset1
        '
        Me.mydataset1.DataSetName = "mydataset1"
        Me.mydataset1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'indiInvoBindingSource
        '
        Me.indiInvoBindingSource.DataMember = "indiInvo"
        Me.indiInvoBindingSource.DataSource = Me.mydataset1
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.IndiInvoBindingSource1
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "MacPharma.rpt_this_invo.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(888, 538)
        Me.ReportViewer1.TabIndex = 0
        '
        'indiInvoTableAdapter
        '
        Me.indiInvoTableAdapter.ClearBeforeFill = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 538)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.IndiInvoBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mydataset1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.indiInvoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents indiInvoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents mydataset1 As MacPharma.mydataset1
    Friend WithEvents indiInvoTableAdapter As MacPharma.mydataset1TableAdapters.indiInvoTableAdapter
    Friend WithEvents IndiInvoBindingSource1 As System.Windows.Forms.BindingSource
End Class
