<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtw = New System.Windows.Forms.RadioButton()
        Me.rbtp = New System.Windows.Forms.RadioButton()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.MacPharma.My.Resources.Resources.mcpharma
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Location = New System.Drawing.Point(12, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(166, 181)
        Me.Panel1.TabIndex = 0
        '
        'rbtw
        '
        Me.rbtw.AutoSize = True
        Me.rbtw.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtw.Location = New System.Drawing.Point(223, 73)
        Me.rbtw.Name = "rbtw"
        Me.rbtw.Size = New System.Drawing.Size(88, 24)
        Me.rbtw.TabIndex = 1
        Me.rbtw.TabStop = True
        Me.rbtw.Text = "Peddler"
        Me.rbtw.UseVisualStyleBackColor = True
        '
        'rbtp
        '
        Me.rbtp.AutoSize = True
        Me.rbtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtp.Location = New System.Drawing.Point(223, 117)
        Me.rbtp.Name = "rbtp"
        Me.rbtp.Size = New System.Drawing.Size(73, 24)
        Me.rbtp.TabIndex = 2
        Me.rbtp.TabStop = True
        Me.rbtp.Text = "Client"
        Me.rbtp.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(214, 147)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(160, 28)
        Me.Button3.TabIndex = 39
        Me.Button3.Text = "Enter"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(12, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(25, 22)
        Me.Button1.TabIndex = 40
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 265)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.rbtp)
        Me.Controls.Add(Me.rbtw)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMenu"
        Me.Text = "Setting"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rbtw As System.Windows.Forms.RadioButton
    Friend WithEvents rbtp As System.Windows.Forms.RadioButton
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
