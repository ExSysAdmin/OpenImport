<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportWizard
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
        Me.ImportWizardLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ImportWizardDataGridView = New System.Windows.Forms.DataGridView()
        Me.ImportWizardLayoutPanel.SuspendLayout()
        CType(Me.ImportWizardDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImportWizardLayoutPanel
        '
        Me.ImportWizardLayoutPanel.ColumnCount = 2
        Me.ImportWizardLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.625!))
        Me.ImportWizardLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.375!))
        Me.ImportWizardLayoutPanel.Controls.Add(Me.ImportWizardDataGridView, 0, 1)
        Me.ImportWizardLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImportWizardLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.ImportWizardLayoutPanel.Name = "ImportWizardLayoutPanel"
        Me.ImportWizardLayoutPanel.RowCount = 2
        Me.ImportWizardLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.444445!))
        Me.ImportWizardLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.55556!))
        Me.ImportWizardLayoutPanel.Size = New System.Drawing.Size(800, 450)
        Me.ImportWizardLayoutPanel.TabIndex = 0
        '
        'ImportWizardDataGridView
        '
        Me.ImportWizardDataGridView.AllowUserToAddRows = False
        Me.ImportWizardDataGridView.AllowUserToDeleteRows = False
        Me.ImportWizardDataGridView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.ImportWizardDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ImportWizardDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImportWizardDataGridView.GridColor = System.Drawing.SystemColors.Window
        Me.ImportWizardDataGridView.Location = New System.Drawing.Point(3, 32)
        Me.ImportWizardDataGridView.Name = "ImportWizardDataGridView"
        Me.ImportWizardDataGridView.ReadOnly = True
        Me.ImportWizardDataGridView.Size = New System.Drawing.Size(703, 415)
        Me.ImportWizardDataGridView.TabIndex = 0
        '
        'ImportWizard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ImportWizardLayoutPanel)
        Me.Name = "ImportWizard"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Import Wizard"
        Me.ImportWizardLayoutPanel.ResumeLayout(False)
        CType(Me.ImportWizardDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ImportWizardLayoutPanel As TableLayoutPanel
    Friend WithEvents ImportWizardDataGridView As DataGridView
End Class
