﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmByMonth
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
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.mydataset1 = New MacPharma.mydataset1()
        Me.indiInvoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.indiInvoTableAdapter = New MacPharma.mydataset1TableAdapters.indiInvoTableAdapter()
        CType(Me.mydataset1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.indiInvoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "rpt_month"
        ReportDataSource1.Value = Me.indiInvoBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "MacPharma.rpt_montly.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1057, 579)
        Me.ReportViewer1.TabIndex = 0
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
        'indiInvoTableAdapter
        '
        Me.indiInvoTableAdapter.ClearBeforeFill = True
        '
        'frmByMonth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 579)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmByMonth"
        Me.Text = "Monthly Report"
        CType(Me.mydataset1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.indiInvoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents indiInvoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents mydataset1 As MacPharma.mydataset1
    Friend WithEvents indiInvoTableAdapter As MacPharma.mydataset1TableAdapters.indiInvoTableAdapter
End Class
