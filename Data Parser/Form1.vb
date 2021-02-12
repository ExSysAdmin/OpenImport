Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1

    Public Patterns As List(Of PatternCls) = New List(Of PatternCls)
    Public Delimiters As List(Of DelimiterCls) = New List(Of DelimiterCls)

    Public GridViewList As List(Of DataGridView) = New List(Of DataGridView)
    Public TextboxList As List(Of TextBox) = New List(Of TextBox)




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Startup()
    End Sub

    Sub Startup()

        Dim objInitialStartup As New InitialStartup
        Patterns = objInitialStartup.GetInitialPatternList()
        Delimiters = objInitialStartup.GetInitialDelimiterList()

    End Sub





















    Private Sub BrowseBtn_Click(sender As Object, e As EventArgs) Handles BrowseBtn.Click
        Dim FileBrowser As OpenFileDialog = New OpenFileDialog
        If FileBrowser.ShowDialog() = DialogResult.OK Then
            OpenFileTextBox.Text = FileBrowser.FileName
        End If
    End Sub


    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click
        'Dim OptionsDialog As New Options
        'If OptionsDialog.ShowDialog() = DialogResult.OK Then

        'End If
    End Sub

    Private Sub RegexPatternsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim RegExDialog As New RegExPatterns
        RegExDialog.PatternList = Patterns
        If RegExDialog.ShowDialog() = DialogResult.OK Then

        End If
    End Sub




    Function CleanParse(ByVal FilePath As String) As DataTable
        Dim ResultTable As DataTable = New DataTable()

        If File.Exists(FilePath) Then
            Dim CorrectDelimiter As String = ""

            For Each Delim In Delimiters
                Dim CurrentDelimArray As ArrayList = New ArrayList
                Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(FilePath)
                    MyReader.TextFieldType = FileIO.FieldType.Delimited
                    MyReader.SetDelimiters(Delim.Delimiter)
                    Dim currentRow As String()
                    While Not MyReader.EndOfData
                        Try
                            currentRow = MyReader.ReadFields()
                            CurrentDelimArray.Add(currentRow.Count)
                        Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                            'MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                        End Try
                    End While
                    Dim UniqueValueCount As Int32 = CurrentDelimArray.ToArray().Distinct().Count()
                    If UniqueValueCount = 1 Then
                        Dim UniqueValues As Array = CurrentDelimArray.ToArray().Distinct().ToArray()
                        If Convert.ToInt32(UniqueValues.GetValue(0)) > 1 Then
                            CorrectDelimiter = Delim.Delimiter
                            Exit For
                        End If
                    End If
                End Using
            Next

            If CorrectDelimiter <> "" Then

                Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(FilePath)
                    MyReader.TextFieldType = FileIO.FieldType.Delimited
                    MyReader.SetDelimiters(CorrectDelimiter)
                    Dim currentRow As String()
                    While Not MyReader.EndOfData
                        Try
                            currentRow = MyReader.ReadFields()
                            If ResultTable.Columns.Count = 0 Then
                                For Each Item As String In currentRow
                                    ResultTable.Columns.Add(Item)
                                Next
                            Else
                                If ResultTable.Columns.Count = currentRow.Count Then
                                    ResultTable.Rows.Add(currentRow)
                                End If
                            End If
                        Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                            'MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                        End Try
                    End While
                End Using

            Else

                'Dim IW As New ImportWizard
                'IW.StrFilePath = FilePath
                'If IW.ShowDialog = DialogResult.OK Then
                'End If

            End If

        End If



        Return ResultTable

    End Function

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Dim FileArr As ArrayList = New ArrayList
            Dim FileBrowser As OpenFileDialog = New OpenFileDialog
            FileBrowser.Multiselect = True
            If FileBrowser.ShowDialog() = DialogResult.OK Then
                For Each FilePath In FileBrowser.FileNames
                    If FilePath <> "" And File.Exists(FilePath) Then
                        FileArr.Add(FilePath)
                    End If
                Next
                BackgroundWorker1.RunWorkerAsync(FileArr)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Try
            OpenFileTextBox.Text = ""
            'DataGridView1.DataSource = Nothing
            'DataGridView1.Update()
        Catch ex As Exception

        End Try
    End Sub










    Function BuildNewTab(ByVal StrFileName As String, ByVal DataTable As DataTable) As String
        Dim strTabGUID As String = Guid.NewGuid().ToString().Replace("-", "")

        Dim TabPage As TabPage = New TabPage
        TabPage.Name = strTabGUID & "_TabPage"
        TabPage.Text = StrFileName
        TabPage.BackColor = SystemColors.Window

        Dim TLP As TableLayoutPanel = New TableLayoutPanel
        TLP.Name = strTabGUID & "_TLP"
        TLP.Dock = DockStyle.Fill
        TLP.ColumnStyles.Clear()
        TLP.ColumnStyles.Add(New ColumnStyle)
        TLP.ColumnStyles.Item(0).SizeType = SizeType.Percent
        TLP.ColumnStyles.Item(0).Width = 100
        TLP.RowStyles.Clear()
        TLP.RowStyles.Add(New RowStyle)
        TLP.RowStyles.Add(New RowStyle)
        TLP.RowStyles.Item(0).SizeType = SizeType.Absolute
        TLP.RowStyles.Item(0).Height = 50
        TLP.RowStyles.Item(1).SizeType = SizeType.Percent
        TLP.RowStyles.Item(1).Height = 100

        Dim groupBox As GroupBox = New GroupBox
        groupBox.Name = strTabGUID & "_Groupbox"
        groupBox.Text = "Search"
        groupBox.Height = 44
        groupBox.Width = 414

        Dim textBox As TextBox = New TextBox
        textBox.Name = strTabGUID & "_Textbox"
        textBox.Height = 20
        textBox.Width = 224
        textBox.Location = New Point(6, 19)

        TextboxList.Add(textBox)

        Dim button As Button = New Button
        button.Name = strTabGUID & "_Btn"
        button.Text = "Search"
        button.Height = 23
        button.Width = 75
        button.Location = New Point(236, 17)

        AddHandler button.Click, AddressOf Me.Button_Click

        Dim buttonClose As Button = New Button
        buttonClose.Name = strTabGUID & "_BtnClose"
        buttonClose.Text = "Close"
        buttonClose.Height = 23
        buttonClose.Width = 75
        buttonClose.Location = New Point(321, 17)

        AddHandler buttonClose.Click, AddressOf Me.ButtonClose_Click

        groupBox.Controls.Add(textBox)
        groupBox.Controls.Add(button)
        groupBox.Controls.Add(buttonClose)

        Dim DGV As DataGridView = New DataGridView
        DGV.Name = strTabGUID
        DGV.Dock = DockStyle.Fill
        DGV.BackgroundColor = SystemColors.Window
        DGV.GridColor = SystemColors.Window

        DGV.DataSource = DataTable.DefaultView
        DGV.Update()

        GridViewList.Add(DGV)

        TLP.Controls.Add(groupBox, 0, 0)
        TLP.Controls.Add(DGV, 0, 1)
        TabPage.Controls.Add(TLP)

        TabControl1.TabPages.Add(TabPage)

        Return strTabGUID
    End Function

    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Handle your Button clicks here

        Dim TheButton As Button = DirectCast(sender, Button)
        Dim strTabGUID As String = ""
        strTabGUID = TheButton.Name.ToString().Replace("_Btn", "")
        Dim StrSearchText As String = ""


        For Each textbox As TextBox In TextboxList
            If textbox.Name = (strTabGUID & "_Textbox") Then
                StrSearchText = textbox.Text
                Exit For
            End If
        Next

        For Each DataGridView As DataGridView In GridViewList
            If DataGridView.Name = (strTabGUID) Then
                Try
                    Dim dv As DataView = DataGridView.DataSource
                    If StrSearchText.Trim() <> "" Then
                        Dim strFilter As String = ""
                        For Each Column As DataColumn In dv.Table.Columns
                            If strFilter = "" Then
                                strFilter = "[" & Column.ColumnName & "] Like '" & StrSearchText & "'"
                            Else
                                strFilter = strFilter & " OR [" & Column.ColumnName & "] like '" & StrSearchText & "'"
                            End If
                        Next
                        dv.RowFilter = strFilter
                    Else
                        dv.RowFilter = String.Empty
                    End If
                    DataGridView.DataSource = dv
                    DataGridView.Update()
                Catch ex As Exception
                    'MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.Data.ToString())
                End Try
                Exit For
            End If
        Next

    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Handle your Button clicks here

        Dim TheButton As Button = DirectCast(sender, Button)
        Dim strTabGUID As String = ""
        strTabGUID = TheButton.Name.ToString().Replace("_BtnClose", "")


        For Each textbox As TextBox In TextboxList
            If textbox.Name = (strTabGUID & "_Textbox") Then
                TextboxList.Remove(textbox)
                Exit For
            End If
        Next

        For Each DataGridView As DataGridView In GridViewList
            If DataGridView.Name = (strTabGUID) Then
                Try
                    GridViewList.Remove(DataGridView)
                Catch ex As Exception
                End Try
                Exit For
            End If
        Next

        For Each TabPage As TabPage In TabControl1.TabPages
            If TabPage.Name = (strTabGUID & "_TabPage") Then
                TabControl1.TabPages.Remove(TabPage)
            End If
        Next

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim SettingsPage As New Settings
        SettingsPage.PatternList = Patterns
        If SettingsPage.ShowDialog() = DialogResult.OK Then

        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If Not BackgroundWorker1.CancellationPending Then
            Dim FileArr As ArrayList = e.Argument
            For Each Item In FileArr.ToArray()
                Dim dt As New DataTable
                Dim FilePath As String = ""
                FilePath = Item
                BackgroundWorker1.ReportProgress(1, "Processing: " & FilePath)
                dt = CleanParse(FilePath)
                Dim eUserState As List(Of Object) = New List(Of Object)
                eUserState.Add(FilePath)
                eUserState.Add(dt)
                BackgroundWorker1.ReportProgress(2, eUserState)
            Next
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If e.ProgressPercentage = 1 Then
            ToolStripStatusLabel2.Text = e.UserState.ToString()
        ElseIf e.ProgressPercentage = 2 Then
            Try
                Dim UserState As List(Of Object) = New List(Of Object)
                UserState = DirectCast(e.UserState, List(Of Object))
                Dim FilePath As String = ""
                FilePath = UserState.Item(0)
                Dim dt As New DataTable
                dt = UserState.Item(1) 'DirectCast(e.Result, DataTable)
                BuildNewTab(FilePath, dt)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ToolStripStatusLabel2.Text = "Ready"
    End Sub
End Class
