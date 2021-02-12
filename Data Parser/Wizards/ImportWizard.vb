Imports System.IO

Public Class ImportWizard

    Public StrFilePath As String = ""

    Private Sub ImportWizard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If StrFilePath <> "" Then
            InitialGridViewLoad(StrFilePath)
        End If

    End Sub

    Sub InitialGridViewLoad(ByVal FilePath As String)
        If File.Exists(FilePath) Then
            ImportWizardDataGridView.Columns.Add("ImportFile", FilePath)
            ImportWizardDataGridView.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            Dim FileContentsArray As String() = File.ReadAllLines(FilePath)
            For Each LineItem In FileContentsArray
                Try
                    ImportWizardDataGridView.Rows.Add(LineItem)
                Catch ex As Exception
                End Try
            Next
        End If
    End Sub

End Class