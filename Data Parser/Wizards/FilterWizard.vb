Public Class FilterWizard
    Public TabGuid As String = ""
    Public DataGridViewColumns As List(Of String) = New List(Of String)



    Private Sub FilterWizard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDataGridStructure()
    End Sub


    Private Sub GetDataGridStructure()
        Dim ColumnNameColumn As DataGridViewComboBoxColumn = DataGridView1.Columns(1)
        For Each ColumnName As String In DataGridViewColumns
            ColumnNameColumn.Items.Add(ColumnName)
        Next
    End Sub

End Class