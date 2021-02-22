<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegExPatternsDetailForm
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
        Me.NameTextBox = New System.Windows.Forms.TextBox()
        Me.PatternTextBox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DataTypeComboBox = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EnabledCheckBox = New System.Windows.Forms.CheckBox()
        Me.OKBtn = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'NameTextBox
        '
        Me.NameTextBox.Location = New System.Drawing.Point(76, 22)
        Me.NameTextBox.Name = "NameTextBox"
        Me.NameTextBox.Size = New System.Drawing.Size(263, 20)
        Me.NameTextBox.TabIndex = 2
        '
        'PatternTextBox
        '
        Me.PatternTextBox.Location = New System.Drawing.Point(6, 19)
        Me.PatternTextBox.Multiline = True
        Me.PatternTextBox.Name = "PatternTextBox"
        Me.PatternTextBox.Size = New System.Drawing.Size(418, 179)
        Me.PatternTextBox.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Name:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PatternTextBox)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 204)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pattern"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DataTypeComboBox)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.EnabledCheckBox)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.NameTextBox)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(430, 97)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details"
        '
        'DataTypeComboBox
        '
        Me.DataTypeComboBox.FormattingEnabled = True
        Me.DataTypeComboBox.Location = New System.Drawing.Point(76, 54)
        Me.DataTypeComboBox.Name = "DataTypeComboBox"
        Me.DataTypeComboBox.Size = New System.Drawing.Size(263, 21)
        Me.DataTypeComboBox.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "DataType:"
        '
        'EnabledCheckBox
        '
        Me.EnabledCheckBox.AutoSize = True
        Me.EnabledCheckBox.Location = New System.Drawing.Point(359, 58)
        Me.EnabledCheckBox.Name = "EnabledCheckBox"
        Me.EnabledCheckBox.Size = New System.Drawing.Size(65, 17)
        Me.EnabledCheckBox.TabIndex = 4
        Me.EnabledCheckBox.Text = "Enabled"
        Me.EnabledCheckBox.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKBtn.Location = New System.Drawing.Point(356, 330)
        Me.OKBtn.Name = "OKButton"
        Me.OKBtn.Size = New System.Drawing.Size(75, 23)
        Me.OKBtn.TabIndex = 8
        Me.OKBtn.Text = "Ok"
        Me.OKBtn.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelBtn.Location = New System.Drawing.Point(270, 330)
        Me.CancelBtn.Name = "CancelButton"
        Me.CancelBtn.Size = New System.Drawing.Size(75, 23)
        Me.CancelBtn.TabIndex = 7
        Me.CancelBtn.Text = "Cancel"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'RegExPatternsDetailForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 365)
        Me.Controls.Add(Me.CancelBtn)
        Me.Controls.Add(Me.OKBtn)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "RegExPatternsDetailForm"
        Me.Text = "Pattern Details"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NameTextBox As TextBox
    Friend WithEvents PatternTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents DataTypeComboBox As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents EnabledCheckBox As CheckBox
    Friend WithEvents OKBtn As Button
    Friend WithEvents CancelBtn As Button
End Class
