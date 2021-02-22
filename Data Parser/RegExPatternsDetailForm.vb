Public Class RegExPatternsDetailForm

    Public ObjPattern As PatternCls = New PatternCls

    Private Sub OKBtn_Click(sender As Object, e As EventArgs) Handles OKBtn.Click
        If Not IsNothing(ObjPattern.Name) And Not IsNothing(ObjPattern.Pattern) Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub RegExPatternsDetailForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            PatternTextBox.Text = ObjPattern.Pattern
            EnabledCheckBox.Checked = ObjPattern.Enabled
            DataTypeComboBox.Text = ObjPattern.DataType
            NameTextBox.Text = ObjPattern.Name
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NameTextBox_TextChanged(sender As Object, e As EventArgs) Handles NameTextBox.TextChanged
        Try
            ObjPattern.Name = NameTextBox.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EnabledCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EnabledCheckBox.CheckedChanged
        Try
            ObjPattern.Enabled = EnabledCheckBox.Checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DataTypeComboBox.SelectedIndexChanged
        Try
            ObjPattern.DataType = DataTypeComboBox.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PatternTextBox_TextChanged(sender As Object, e As EventArgs) Handles PatternTextBox.TextChanged
        Try
            ObjPattern.Pattern = PatternTextBox.Text
        Catch ex As Exception

        End Try
    End Sub
End Class