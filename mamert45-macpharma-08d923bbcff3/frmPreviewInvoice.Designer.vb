<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreviewInvoice
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()

        Me.arpopup1BindingSource = New System.Windows.Forms.BindingSource(Me.components)

        Me.mydataset = New MacPharma.mydataset()
        Me.arpopupBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.arpopupTableAdapter = New MacPharma.mydatasetTableAdapters.arpopupTableAdapter()

        CType(Me.arpopup1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.mydataset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.arpopupBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "mydataset"
        ReportDataSource1.Value = Me.arpopup1BindingSource
        ReportDataSource2.Name = "previewInvo"
        ReportDataSource2.Value = Me.arpopupBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "MacPharma.invoicenoReport.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(772, 429)
        Me.ReportViewer1.TabIndex = 0
        '
        'previewInvo
        '
       
        '
        'arpopup1BindingSource
        '
        Me.arpopup1BindingSource.DataMember = "arpopup1"

        '
        'arpopup1TableAdapter
        '

        '
        'mydataset
        '
        Me.mydataset.DataSetName = "mydataset"
        Me.mydataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'arpopupBindingSource
        '
        Me.arpopupBindingSource.DataMember = "arpopup"
        Me.arpopupBindingSource.DataSource = Me.mydataset
        '
        'arpopupTableAdapter
        '
        Me.arpopupTableAdapter.ClearBeforeFill = True
        '
        'frmPreviewInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 429)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmPreviewInvoice"
        Me.Text = "Invoice Preview"

        CType(Me.arpopup1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.mydataset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.arpopupBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents arpopup1BindingSource As System.Windows.Forms.BindingSource

    Friend WithEvents arpopupBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents mydataset As MacPharma.mydataset

    Friend WithEvents arpopupTableAdapter As MacPharma.mydatasetTableAdapters.arpopupTableAdapter
End Class
