Imports System.ComponentModel
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Form1

    Public Patterns As List(Of PatternCls) = New List(Of PatternCls)
    Public Delimiters As List(Of DelimiterCls) = New List(Of DelimiterCls)

    Public GridViewList As List(Of DataGridView) = New List(Of DataGridView)
    Public TextboxList As List(Of TextBox) = New List(Of TextBox)

    Public DefaultDataGridViewSettings As Dictionary(Of String, String) = New Dictionary(Of String, String)




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Startup()
    End Sub

    Sub Startup()

        Dim objInitialStartup As New InitialStartup
        Patterns = objInitialStartup.GetInitialPatterns().ToList
        Delimiters = objInitialStartup.GetInitialDelimiters().ToList

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
        Dim RegExDialog As New RegExPatterns With {
            .PatternList = Patterns
        }
        If RegExDialog.ShowDialog() = DialogResult.OK Then

        End If
    End Sub




    Function CleanParse(FilePath As String) As DataTable
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
                    Dim UniqueValueCount As Integer = CurrentDelimArray.ToArray().Distinct().Count()
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

            End If

        End If



        Return ResultTable

    End Function

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Dim FileArr As ArrayList = New ArrayList
            Dim FileBrowser As OpenFileDialog = New OpenFileDialog With {
                .Multiselect = True
            }
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


    Sub ResizeColumns(strTabGUID As String, FillMode As Integer)
        Try
            For Each DataGridView As DataGridView In GridViewList
                If (DataGridView.Name) = (strTabGUID) Then
                    For Each Column As DataGridViewColumn In DataGridView.Columns
                        Select Case FillMode
                            Case 2
                                Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                            Case 6
                                Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            Case 16
                                Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                            Case Else
                                Column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                        End Select
                    Next
                    DataGridView.Refresh()
                    DataGridView.Update()
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub


    Function GetColumnAutoSizeMode(strTabGUID As String) As DataGridViewAutoSizeColumnMode
        Try
            For Each DataGridView As DataGridView In GridViewList
                If (DataGridView.Name) = (strTabGUID) Then
                    Dim AutoSizeModeTheSame As Boolean = True
                    Dim AutoSizeMode As DataGridViewAutoSizeColumnMode = Nothing
                    For Each Column As DataGridViewColumn In DataGridView.Columns
                        If AutoSizeMode = Nothing Then
                            AutoSizeMode = Column.AutoSizeMode
                        Else
                            If AutoSizeMode <> Column.AutoSizeMode Then
                                AutoSizeModeTheSame = False
                            End If
                        End If
                    Next
                    If AutoSizeModeTheSame Then
                        Return AutoSizeMode
                    Else
                        Return Nothing
                    End If

                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
        Return Nothing
    End Function












    Function BuildNewTab(StrFileName As String, DataTable As DataTable) As String
        Dim strTabGUID As String = Guid.NewGuid().ToString().Replace("-", "")

        Dim TabPage As TabPage = New TabPage With {
            .Name = strTabGUID & "_TabPage",
            .Text = StrFileName,
            .BackColor = SystemColors.Window
        }

        Dim TLP As TableLayoutPanel = New TableLayoutPanel With {
            .Name = strTabGUID & "_TLP",
            .Dock = DockStyle.Fill
        }
        TLP.ColumnStyles.Clear()
        TLP.ColumnStyles.Add(New ColumnStyle)
        TLP.ColumnStyles.Item(0).SizeType = SizeType.Absolute
        TLP.ColumnStyles.Item(0).Width = 200
        TLP.ColumnStyles.Add(New ColumnStyle)
        TLP.ColumnStyles.Item(1).SizeType = SizeType.Percent
        TLP.ColumnStyles.Item(1).Width = 100
        TLP.RowStyles.Clear()
        TLP.RowStyles.Add(New RowStyle)
        TLP.RowStyles.Add(New RowStyle)
        TLP.RowStyles.Item(0).SizeType = SizeType.Absolute
        TLP.RowStyles.Item(0).Height = 50
        TLP.RowStyles.Item(1).SizeType = SizeType.Percent
        TLP.RowStyles.Item(1).Height = 100

        Dim groupBox1 As GroupBox = New GroupBox With {
            .Name = strTabGUID & "_DetailsGroupbox",
            .Text = "Details",
            .Height = 44,
            .Width = 414
        }

        Dim DetailsLabel As Label = New Label With {
            .Name = strTabGUID & "_DetailsLabel",
            .Dock = DockStyle.Fill
        }
        Dim CurrentLabelFont As Font = DetailsLabel.Font
        Dim NewLabelFont As Font = New Font(CurrentLabelFont.FontFamily, CurrentLabelFont.Size, FontStyle.Bold)
        DetailsLabel.Font = NewLabelFont
        DetailsLabel.TextAlign = ContentAlignment.MiddleCenter


        groupBox1.Controls.Add(DetailsLabel)


        Dim groupBox As GroupBox = New GroupBox With {
            .Name = strTabGUID & "_SearchGroupbox",
            .Text = "Search",
            .Height = 44,
            .Width = 414
        }

        Dim textBox As TextBox = New TextBox With {
            .Name = strTabGUID & "_Textbox",
            .Height = 20,
            .Width = 224,
            .Location = New Point(6, 19)
        }

        TextboxList.Add(textBox)

        Dim button As Button = New Button With {
            .Name = strTabGUID & "_Btn",
            .Text = "Search",
            .Height = 23,
            .Width = 75,
            .Location = New Point(236, 17)
        }

        AddHandler button.Click, AddressOf Me.Button_Click

        Dim buttonClose As Button = New Button With {
            .Name = strTabGUID & "_BtnClose",
            .Text = "Close",
            .Height = 23,
            .Width = 75,
            .Location = New Point(321, 17)
        }

        AddHandler buttonClose.Click, AddressOf Me.ButtonClose_Click

        groupBox.Controls.Add(textBox)
        groupBox.Controls.Add(button)
        groupBox.Controls.Add(buttonClose)

        'DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing
        Dim DGV As DataGridView = New DataGridView With {
            .Name = strTabGUID,
            .Dock = DockStyle.Fill,
            .BackgroundColor = SystemColors.Window,
            .GridColor = SystemColors.Window,
            .AllowUserToResizeRows = False,
            .ContextMenuStrip = DGVContextMenuStrip,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader,
            .AllowUserToOrderColumns = True,
            .AllowUserToAddRows = False,
            .DataSource = DataTable.DefaultView
        }
        DGV.Update()

        AddHandler DGV.CellPainting, AddressOf Me.dataGridViewForSearching_CellPainting

        GridViewList.Add(DGV)

        DetailsLabel.Text = "Displaying " & DataTable.Rows.Count & "/" & DataTable.Rows.Count & " Rows"

        TLP.Controls.Add(groupBox1, 0, 0)
        TLP.Controls.Add(groupBox, 1, 0)
        TLP.Controls.Add(DGV, 0, 1)
        TLP.SetColumnSpan(DGV, 2)

        TabPage.Controls.Add(TLP)

        TabControl1.TabPages.Add(TabPage)

        For Each Tab As TabPage In TabControl1.TabPages
            If (Tab.Name) = (strTabGUID & "_TabPage") Then
                TabControl1.SelectedTab = Tab
                TabControl1.Update()
                Exit For
            End If
        Next

        Return strTabGUID
    End Function

    Private Sub Button_Click(sender As Object, e As System.EventArgs)
        ' Handle your Button clicks here

        Dim TheButton As Button = DirectCast(sender, Button)
        Dim strTabGUID As String = TheButton.Name.ToString().Replace("_Btn", "")
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
                            If Column.ColumnName <> "RowIndex" Then
                                If strFilter = "" Then
                                    strFilter = "[" & Column.ColumnName & "] Like '" & StrSearchText & "'"
                                Else
                                    strFilter = strFilter & " OR [" & Column.ColumnName & "] like '" & StrSearchText & "'"
                                End If
                            End If
                        Next
                        dv.RowFilter = strFilter
                    Else
                        dv.RowFilter = String.Empty
                    End If
                    DataGridView.DataSource = dv
                    DataGridView.Update()

                    For Each Tab As TabPage In TabControl1.TabPages
                        If Tab.Name = (strTabGUID & "_TabPage") Then
                            Try
                                Dim ControlName As String = ""
                                ControlName = strTabGUID & "_DetailsLabel"
                                Dim DetailsControl As Control() = Tab.Controls.Find(ControlName, True)
                                Dim DetailsLabel As Label = DirectCast(DetailsControl(0), Label)
                                DetailsLabel.Text = "Displaying " & dv.Count & "/" & dv.Table.Rows.Count & " Rows"
                            Catch ex As Exception

                            End Try
                        End If
                    Next

                Catch ex As Exception
                    'MsgBox(ex.Message & vbCrLf & vbCrLf & ex.StackTrace & vbCrLf & vbCrLf & ex.Data.ToString())
                End Try
                Exit For
            End If
        Next



    End Sub









    Private Sub ButtonClose_Click(sender As Object, e As System.EventArgs)
        ' Handle your Button clicks here

        Dim TheButton As Button = DirectCast(sender, Button)
        Dim strTabGUID As String = TheButton.Name.ToString().Replace("_BtnClose", "")





        'FilterDGV(strTabGUID)

        'Exit Sub


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

        Dim PreviousTabIndex As Integer = 0
        Dim TabRemoved As Boolean = False
        Dim TabCount As Integer = TabControl1.TabPages.Count
        For Each TabPage As TabPage In TabControl1.TabPages

            If TabPage.Name = (strTabGUID & "_TabPage") Then

                If PreviousTabIndex > 0 AndAlso TabCount > 2 Then
                    TabControl1.TabPages.Remove(TabPage)
                    TabControl1.SelectedTab = TabControl1.TabPages().Item(PreviousTabIndex)
                    TabControl1.Update()
                    Exit For
                ElseIf TabCount = 2 Then
                    TabControl1.TabPages.Remove(TabPage)
                    TabControl1.SelectedTab = TabControl1.TabPages().Item(0)
                    TabControl1.Update()
                    Exit For
                Else
                    TabControl1.TabPages.Remove(TabPage)
                    TabRemoved = True
                    TabControl1.Update()
                End If

            Else
                If TabRemoved = False Then
                    PreviousTabIndex = TabPage.TabIndex
                Else
                    TabControl1.SelectedTab = TabPage
                    TabControl1.Update()
                    Exit For
                End If
            End If
        Next

    End Sub



    Sub FilterDGV(strTabGUID As String)
        Try
            Dim FilterWizard As New FilterWizard With {
                .TabGuid = strTabGUID
            }
            For Each DataGridView As DataGridView In GridViewList
                If DataGridView.Name = (strTabGUID) Then
                    For Each Column As DataGridViewColumn In DataGridView.Columns
                        Dim StrColumnName As String = ""
                        StrColumnName = "[" & Column.Name & "]"
                        FilterWizard.DataGridViewColumns.Add(StrColumnName)
                    Next
                    Exit For
                End If
            Next
            If FilterWizard.ShowDialog() Then

            End If
        Catch ex As Exception

        End Try
    End Sub





    Function GetSearchTerm(strTabGUID As String) As String
        Dim SearchTerm As String = ""
        For Each textbox As TextBox In TextboxList
            If textbox.Name = (strTabGUID & "_Textbox") Then
                SearchTerm = textbox.Text.Trim()
                Exit For
            End If
        Next
        Return SearchTerm
    End Function



    Private Sub dataGridViewForSearching_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        Dim SearchText As String = ""

        Try
            Dim DVG As DataGridView = DirectCast(sender, DataGridView)
            SearchText = GetSearchTerm(DVG.Name)
        Catch ex As Exception

        End Try

        If e.RowIndex > -1 AndAlso e.ColumnIndex > 0 Then
            If Not String.IsNullOrWhiteSpace(SearchText.Trim()) Then
                Dim gridCellValue As String = e.FormattedValue.ToString()
                Dim startIndexInCellValue As Integer = gridCellValue.ToLower().IndexOf(SearchText.Trim().ToLower())

                If startIndexInCellValue >= 0 Then
                    e.Handled = True
                    e.PaintBackground(e.CellBounds, True)
                    Dim hl_rect As Rectangle = New Rectangle With {
                        .Y = e.CellBounds.Y + 2,
                        .Height = e.CellBounds.Height - 5
                    }
                    Dim sBeforeSearchword As String = gridCellValue.Substring(0, startIndexInCellValue)
                    Dim sSearchWord As String = gridCellValue.Substring(startIndexInCellValue, SearchText.Trim().Length)
                    Dim s1 As Size = TextRenderer.MeasureText(e.Graphics, sBeforeSearchword, e.CellStyle.Font, e.CellBounds.Size)
                    Dim s2 As Size = TextRenderer.MeasureText(e.Graphics, sSearchWord, e.CellStyle.Font, e.CellBounds.Size)

                    If s1.Width > 5 Then
                        hl_rect.X = e.CellBounds.X + s1.Width - 5
                        hl_rect.Width = s2.Width - 6
                    Else
                        hl_rect.X = e.CellBounds.X + 2
                        hl_rect.Width = s2.Width - 6
                    End If

                    Dim hl_brush As SolidBrush
                    hl_brush = New SolidBrush(Color.Yellow)
                    e.Graphics.FillRectangle(hl_brush, hl_rect)
                    hl_brush.Dispose()
                    e.PaintContent(e.CellBounds)
                End If
            End If
        End If
    End Sub














    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim SettingsPage As New Settings With {
            .PatternList = Patterns
        }
        If SettingsPage.ShowDialog() = DialogResult.OK Then

        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If Not BackgroundWorker1.CancellationPending Then
            Dim FileArr As ArrayList = e.Argument
            For Each Item In FileArr.ToArray()
                Dim dt As New DataTable
                Dim FilePath As String = Item

                Dim iUserState As List(Of Object) = New List(Of Object) From {
                    FilePath,
                    0
                }

                BackgroundWorker1.ReportProgress(1, iUserState)
                'dt = CleanParse(FilePath)

#Region "CleanParse"

                Dim ResultTable As DataTable = New DataTable()

                If File.Exists(FilePath) Then
                    For Each Delim In Delimiters
                        ResultTable.Rows.Clear()
                        ResultTable.Columns.Clear()
                        Dim RowNumber As Integer = 0
                        Dim CurrentDelimArray As ArrayList = New ArrayList
                        Dim LineCount As Integer = File.ReadAllLines(FilePath).Length
                        Dim ReportArray As String() = {Convert.ToInt32(LineCount * 0.1), Convert.ToInt32(LineCount * 0.2), Convert.ToInt32(LineCount * 0.3), Convert.ToInt32(LineCount * 0.4), Convert.ToInt32(LineCount * 0.5), Convert.ToInt32(LineCount * 0.6), Convert.ToInt32(LineCount * 0.7), Convert.ToInt32(LineCount * 0.8), Convert.ToInt32(LineCount * 0.9), Convert.ToInt32(LineCount)}
                        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(FilePath)
                            MyReader.TextFieldType = FileIO.FieldType.Delimited
                            MyReader.SetDelimiters(Delim.Delimiter)
                            Dim currentRow As String()

                            While Not MyReader.EndOfData
                                RowNumber += 1
                                If (RowNumber = ReportArray(0)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        10
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                ElseIf (RowNumber = ReportArray(1)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        20
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                ElseIf (RowNumber = ReportArray(2)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        30
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                ElseIf (RowNumber = ReportArray(3)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        40
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                ElseIf (RowNumber = ReportArray(4)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        50
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                ElseIf (RowNumber = ReportArray(5)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        60
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                ElseIf (RowNumber = ReportArray(6)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        70
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                ElseIf (RowNumber = ReportArray(7)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        80
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                ElseIf (RowNumber = ReportArray(8)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        90
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                ElseIf (RowNumber = ReportArray(8)) Then
                                    Dim oUserState As List(Of Object) = New List(Of Object) From {
                                        FilePath,
                                        100
                                    }
                                    BackgroundWorker1.ReportProgress(1, oUserState)
                                End If
                                Try
                                    currentRow = MyReader.ReadFields()
                                    CurrentDelimArray.Add(currentRow.Count)
                                    Try
                                        If ResultTable.Columns.Count = 0 Then
                                            Dim RowIndex As DataColumn = ResultTable.Columns.Add("RowIndex", GetType(Integer))
                                            RowIndex.AutoIncrement = True
                                            RowIndex.AutoIncrementSeed = 1
                                            RowIndex.AutoIncrementStep = 1
                                            RowIndex.ReadOnly = True
                                            For Each abItem As String In currentRow
                                                ResultTable.Columns.Add(abItem)
                                            Next
                                        Else
                                            If ResultTable.Columns.Count = (currentRow.Count + 1) Then
                                                Dim oDataRow As DataRow = ResultTable.NewRow()
                                                For i = 0 To (currentRow.Count - 1)
                                                    oDataRow.Item(i + 1) = currentRow(i)
                                                Next
                                                ResultTable.Rows.Add(oDataRow)
                                            End If
                                        End If
                                    Catch ex As Exception

                                    End Try

                                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                                    'MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                                End Try
                            End While
                            Dim UniqueValueCount As Integer = CurrentDelimArray.ToArray().Distinct().Count()
                            If UniqueValueCount = 1 Then
                                Dim UniqueValues As Array = CurrentDelimArray.ToArray().Distinct().ToArray()
                                If Convert.ToInt32(UniqueValues.GetValue(0)) > 1 Then
                                    Dim CorrectDelimiter As String = Delim.Delimiter
                                    dt = ResultTable
                                    Exit For
                                End If
                            End If
                        End Using
                    Next

                End If

#End Region





                Dim eUserState As List(Of Object) = New List(Of Object) From {
                    FilePath,
                    dt
                }
                BackgroundWorker1.ReportProgress(2, eUserState)
            Next
        End If
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        If e.ProgressPercentage = 1 Then
            Dim UserState As List(Of Object) = DirectCast(e.UserState, List(Of Object))
            Dim FilePath As String = UserState.Item(0)
            Dim Percentage As Integer = UserState.Item(1)
            ToolStripStatusLabel2.Text = "Processing: " & FilePath
            ToolStripProgressBar1.Maximum = 100
            ToolStripProgressBar1.Value = Percentage
            'Me.Refresh()
        ElseIf e.ProgressPercentage = 2 Then
            Try
                Dim UserState As List(Of Object) = New List(Of Object)
                UserState = DirectCast(e.UserState, List(Of Object))
                Dim FilePath As String = ""
                FilePath = UserState.Item(0)
                Dim dt As New DataTable
                dt = UserState.Item(1)
                BuildNewTab(FilePath, dt)
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ToolStripStatusLabel2.Text = "Ready"
        ToolStripProgressBar1.Value = 0
    End Sub

    Private Sub AllCellsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllCellsToolStripMenuItem.Click
        Try
            Dim SelectedTab As String = ""
            Dim strTabGUID As String = ""
            SelectedTab = TabControl1.SelectedTab().Name
            If InStr(SelectedTab, "_TabPage") > 0 Then
                strTabGUID = SelectedTab.Replace("_TabPage", "")
            End If
            ResizeColumns(strTabGUID, 6)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HeaderColumnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HeaderColumnToolStripMenuItem.Click
        Try
            Dim SelectedTab As String = ""
            Dim strTabGUID As String = ""
            SelectedTab = TabControl1.SelectedTab().Name
            If InStr(SelectedTab, "_TabPage") > 0 Then
                strTabGUID = SelectedTab.Replace("_TabPage", "")
            End If
            ResizeColumns(strTabGUID, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FillToolStripMenuItem.Click
        Try
            Dim SelectedTab As String = ""
            Dim strTabGUID As String = ""
            SelectedTab = TabControl1.SelectedTab().Name
            If InStr(SelectedTab, "_TabPage") > 0 Then
                strTabGUID = SelectedTab.Replace("_TabPage", "")
            End If
            ResizeColumns(strTabGUID, 16)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NoneToolStripMenuItem.Click
        Try
            Dim SelectedTab As String = ""
            Dim strTabGUID As String = ""
            SelectedTab = TabControl1.SelectedTab().Name
            If InStr(SelectedTab, "_TabPage") > 0 Then
                strTabGUID = SelectedTab.Replace("_TabPage", "")
            End If
            ResizeColumns(strTabGUID, 1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            Dim SelectedTab As String = ""
            Dim strTabGUID As String = ""
            SelectedTab = TabControl1.SelectedTab().Name
            If InStr(SelectedTab, "_TabPage") > 0 Then
                strTabGUID = SelectedTab.Replace("_TabPage", "")
                Dim AutoSizeMode As DataGridViewAutoSizeColumnMode = GetColumnAutoSizeMode(strTabGUID)
                GridViewDisplayToolStripMenuItem.Visible = True
                AllCellsToolStripMenuItem.Checked = False
                HeaderColumnToolStripMenuItem.Checked = False
                FillToolStripMenuItem.Checked = False
                NoneToolStripMenuItem.Checked = False

                If AutoSizeMode <> Nothing Then
                    Select Case AutoSizeMode
                        Case DataGridViewAutoSizeColumnMode.AllCells
                            AllCellsToolStripMenuItem.Checked = True
                        Case DataGridViewAutoSizeColumnMode.Fill
                            FillToolStripMenuItem.Checked = True
                        Case DataGridViewAutoSizeColumnMode.ColumnHeader
                            HeaderColumnToolStripMenuItem.Checked = True
                        Case DataGridViewAutoSizeColumnMode.None
                            NoneToolStripMenuItem.Checked = True
                        Case Else

                    End Select
                End If

            Else
                GridViewDisplayToolStripMenuItem.Visible = False
                GridViewDisplayToolStripMenuItem.Visible = True
                AllCellsToolStripMenuItem.Checked = False
                HeaderColumnToolStripMenuItem.Checked = False
                FillToolStripMenuItem.Checked = False
                NoneToolStripMenuItem.Checked = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AllCellsToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles AllCellsToolStripMenuItem.CheckStateChanged
        If AllCellsToolStripMenuItem.Checked Then
            HeaderColumnToolStripMenuItem.Checked = False
            FillToolStripMenuItem.Checked = False
            NoneToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub HeaderColumnToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles HeaderColumnToolStripMenuItem.CheckStateChanged
        If HeaderColumnToolStripMenuItem.Checked Then
            AllCellsToolStripMenuItem.Checked = False
            FillToolStripMenuItem.Checked = False
            NoneToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub FillToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles FillToolStripMenuItem.CheckStateChanged
        If FillToolStripMenuItem.Checked Then
            AllCellsToolStripMenuItem.Checked = False
            HeaderColumnToolStripMenuItem.Checked = False
            NoneToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub NoneToolStripMenuItem_CheckStateChanged(sender As Object, e As EventArgs) Handles NoneToolStripMenuItem.CheckStateChanged
        If NoneToolStripMenuItem.Checked Then
            AllCellsToolStripMenuItem.Checked = False
            FillToolStripMenuItem.Checked = False
            HeaderColumnToolStripMenuItem.Checked = False
        End If
    End Sub
End Class
