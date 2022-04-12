<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiColumnComboBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.BTM = New System.Windows.Forms.Button
        Me.TX = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'BTM
        '
        Me.BTM.Location = New System.Drawing.Point(261, 33)
        Me.BTM.Name = "BTM"
        Me.BTM.Size = New System.Drawing.Size(29, 19)
        Me.BTM.TabIndex = 1
        Me.BTM.Text = "..."
        Me.BTM.UseVisualStyleBackColor = True
        '
        'TX
        '
        Me.TX.BackColor = System.Drawing.Color.White
        Me.TX.Location = New System.Drawing.Point(82, 29)
        Me.TX.Name = "TX"
        Me.TX.ReadOnly = True
        Me.TX.Size = New System.Drawing.Size(119, 20)
        Me.TX.TabIndex = 2
        '
        'MultiColumnComboBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TX)
        Me.Controls.Add(Me.BTM)
        Me.Name = "MultiColumnComboBox"
        Me.Size = New System.Drawing.Size(396, 100)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTM As System.Windows.Forms.Button
    Friend WithEvents TX As System.Windows.Forms.TextBox

End Class
