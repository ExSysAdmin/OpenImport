<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegExPatterns
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
        Me.RegexPatternsLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.PatternGridView = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ArrowUpBtn = New System.Windows.Forms.Button()
        Me.xDeleteBtn = New System.Windows.Forms.Button()
        Me.ArrowDownBtn = New System.Windows.Forms.Button()
        Me.NewBtn = New System.Windows.Forms.Button()
        Me.EditBtn = New System.Windows.Forms.Button()
        Me.DeleteBtn = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.RegexPatternsLayoutPanel.SuspendLayout()
        CType(Me.PatternGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RegexPatternsLayoutPanel
        '
        Me.RegexPatternsLayoutPanel.ColumnCount = 7
        Me.RegexPatternsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.RegexPatternsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.RegexPatternsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.RegexPatternsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RegexPatternsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.RegexPatternsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.RegexPatternsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.RegexPatternsLayoutPanel.Controls.Add(Me.PatternGridView, 1, 1)
        Me.RegexPatternsLayoutPanel.Controls.Add(Me.ArrowUpBtn, 0, 2)
        Me.RegexPatternsLayoutPanel.Controls.Add(Me.xDeleteBtn, 0, 3)
        Me.RegexPatternsLayoutPanel.Controls.Add(Me.ArrowDownBtn, 0, 4)
        Me.RegexPatternsLayoutPanel.Controls.Add(Me.NewBtn, 1, 0)
        Me.RegexPatternsLayoutPanel.Controls.Add(Me.EditBtn, 2, 0)
        Me.RegexPatternsLayoutPanel.Controls.Add(Me.DeleteBtn, 3, 0)
        Me.RegexPatternsLayoutPanel.Controls.Add(Me.Button7, 5, 6)
        Me.RegexPatternsLayoutPanel.Controls.Add(Me.Button8, 4, 6)
        Me.RegexPatternsLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RegexPatternsLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.RegexPatternsLayoutPanel.Name = "RegexPatternsLayoutPanel"
        Me.RegexPatternsLayoutPanel.RowCount = 7
        Me.RegexPatternsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.RegexPatternsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.RegexPatternsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.RegexPatternsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.RegexPatternsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.RegexPatternsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RegexPatternsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.RegexPatternsLayoutPanel.Size = New System.Drawing.Size(714, 461)
        Me.RegexPatternsLayoutPanel.TabIndex = 0
        '
        'PatternGridView
        '
        Me.PatternGridView.AllowUserToAddRows = False
        Me.PatternGridView.AllowUserToDeleteRows = False
        Me.PatternGridView.AllowUserToResizeColumns = False
        Me.PatternGridView.AllowUserToResizeRows = False
        Me.PatternGridView.BackgroundColor = System.Drawing.SystemColors.Window
        Me.PatternGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PatternGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3, Me.Column1, Me.Column2})
        Me.RegexPatternsLayoutPanel.SetColumnSpan(Me.PatternGridView, 5)
        Me.PatternGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PatternGridView.Location = New System.Drawing.Point(33, 33)
        Me.PatternGridView.MultiSelect = False
        Me.PatternGridView.Name = "PatternGridView"
        Me.PatternGridView.ReadOnly = True
        Me.PatternGridView.RowHeadersVisible = False
        Me.RegexPatternsLayoutPanel.SetRowSpan(Me.PatternGridView, 5)
        Me.PatternGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.PatternGridView.Size = New System.Drawing.Size(658, 395)
        Me.PatternGridView.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.HeaderText = "Id"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'Column1
        '
        Me.Column1.FillWeight = 150.0!
        Me.Column1.HeaderText = "Name"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 150
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Pattern"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'ArrowUpBtn
        '
        Me.ArrowUpBtn.Enabled = False
        Me.ArrowUpBtn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArrowUpBtn.Location = New System.Drawing.Point(3, 148)
        Me.ArrowUpBtn.Name = "ArrowUpBtn"
        Me.ArrowUpBtn.Size = New System.Drawing.Size(24, 23)
        Me.ArrowUpBtn.TabIndex = 2
        Me.ArrowUpBtn.Text = "U"
        Me.ArrowUpBtn.UseVisualStyleBackColor = True
        '
        'xDeleteBtn
        '
        Me.xDeleteBtn.Enabled = False
        Me.xDeleteBtn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xDeleteBtn.Location = New System.Drawing.Point(3, 183)
        Me.xDeleteBtn.Name = "xDeleteBtn"
        Me.xDeleteBtn.Size = New System.Drawing.Size(24, 25)
        Me.xDeleteBtn.TabIndex = 3
        Me.xDeleteBtn.Text = "X"
        Me.xDeleteBtn.UseVisualStyleBackColor = True
        '
        'ArrowDownBtn
        '
        Me.ArrowDownBtn.Enabled = False
        Me.ArrowDownBtn.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ArrowDownBtn.Location = New System.Drawing.Point(3, 218)
        Me.ArrowDownBtn.Name = "ArrowDownBtn"
        Me.ArrowDownBtn.Size = New System.Drawing.Size(24, 25)
        Me.ArrowDownBtn.TabIndex = 4
        Me.ArrowDownBtn.Text = "D"
        Me.ArrowDownBtn.UseVisualStyleBackColor = True
        '
        'NewBtn
        '
        Me.NewBtn.Location = New System.Drawing.Point(33, 3)
        Me.NewBtn.Name = "NewBtn"
        Me.NewBtn.Size = New System.Drawing.Size(69, 23)
        Me.NewBtn.TabIndex = 5
        Me.NewBtn.Text = "New"
        Me.NewBtn.UseVisualStyleBackColor = True
        '
        'EditBtn
        '
        Me.EditBtn.Enabled = False
        Me.EditBtn.Location = New System.Drawing.Point(108, 3)
        Me.EditBtn.Name = "EditBtn"
        Me.EditBtn.Size = New System.Drawing.Size(69, 24)
        Me.EditBtn.TabIndex = 6
        Me.EditBtn.Text = "Edit"
        Me.EditBtn.UseVisualStyleBackColor = True
        '
        'DeleteBtn
        '
        Me.DeleteBtn.Enabled = False
        Me.DeleteBtn.Location = New System.Drawing.Point(183, 3)
        Me.DeleteBtn.Name = "DeleteBtn"
        Me.DeleteBtn.Size = New System.Drawing.Size(69, 24)
        Me.DeleteBtn.TabIndex = 7
        Me.DeleteBtn.Text = "Delete"
        Me.DeleteBtn.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(622, 434)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(69, 24)
        Me.Button7.TabIndex = 8
        Me.Button7.Text = "OK"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(547, 434)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(69, 24)
        Me.Button8.TabIndex = 9
        Me.Button8.Text = "Cancel"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'RegExPatterns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 461)
        Me.Controls.Add(Me.RegexPatternsLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RegExPatterns"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "RegEx Patterns"
        Me.RegexPatternsLayoutPanel.ResumeLayout(False)
        CType(Me.PatternGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RegexPatternsLayoutPanel As TableLayoutPanel
    Friend WithEvents PatternGridView As DataGridView
    Friend WithEvents ArrowUpBtn As Button
    Friend WithEvents xDeleteBtn As Button
    Friend WithEvents ArrowDownBtn As Button
    Friend WithEvents NewBtn As Button
    Friend WithEvents EditBtn As Button
    Friend WithEvents DeleteBtn As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
End Class
