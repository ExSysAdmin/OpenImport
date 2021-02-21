Public Class Settings
    Private Sub Options_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeView1.ExpandAll()

#Region "RegExSettings Startup"
        ArrowUpBtn.Text = ChrW(9650)
        xDeleteBtn.Text = ChrW(10060)
        ArrowDownBtn.Text = ChrW(9660)
        LoadPatterns()
#End Region

    End Sub


#Region "RegExSettings"

    Public PatternList As List(Of PatternCls) = New List(Of PatternCls)

    Private Sub PatternGridView_SelectionChanged(sender As Object, e As EventArgs) Handles PatternGridView.SelectionChanged
        ToggleButtons()
    End Sub

    Private Sub PatternGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles PatternGridView.CellDoubleClick
        Dim RegexDetails As New RegExPatternsDetailForm
        For Each Pattern In PatternList
            If Pattern.Id = PatternGridView.SelectedRows(0).Cells(0).Value Then
                RegexDetails.ObjPattern = Pattern
                Exit For
            End If
        Next
        If RegexDetails.ShowDialog = DialogResult.OK Then
            If RegexDetails.ObjPattern.Name.Trim() <> "" And RegexDetails.ObjPattern.Pattern.Trim() <> "" Then
                For Each Pattern In PatternList
                    If Pattern.Id = RegexDetails.ObjPattern.Id Then
                        Pattern.Name = RegexDetails.ObjPattern.Name
                        Pattern.DataType = RegexDetails.ObjPattern.DataType
                        Pattern.Enabled = RegexDetails.ObjPattern.Enabled
                        Pattern.Pattern = RegexDetails.ObjPattern.Pattern
                        Exit For
                    End If
                Next
            End If
            LoadPatterns()
        End If
    End Sub

    Private Sub NewBtn_Click(sender As Object, e As EventArgs) Handles NewBtn.Click
        Try
            Dim RegexDetails As New RegExPatternsDetailForm
            If RegexDetails.ShowDialog = DialogResult.OK Then
                If RegexDetails.ObjPattern.Name.Trim() <> "" And RegexDetails.ObjPattern.Pattern.Trim() <> "" Then
                    PatternList.Add(RegexDetails.ObjPattern)
                End If
            End If
            LoadPatterns()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditBtn_Click(sender As Object, e As EventArgs) Handles EditBtn.Click
        Dim RegexDetails As New RegExPatternsDetailForm
        For Each Pattern In PatternList
            If Pattern.Id = PatternGridView.SelectedRows(0).Cells(0).Value Then
                RegexDetails.ObjPattern = Pattern
                Exit For
            End If
        Next
        If RegexDetails.ShowDialog = DialogResult.OK Then
            If RegexDetails.ObjPattern.Name.Trim() <> "" And RegexDetails.ObjPattern.Pattern.Trim() <> "" Then
                For Each Pattern In PatternList
                    If Pattern.Id = RegexDetails.ObjPattern.Id Then
                        Pattern.Name = RegexDetails.ObjPattern.Name
                        Pattern.DataType = RegexDetails.ObjPattern.DataType
                        Pattern.Enabled = RegexDetails.ObjPattern.Enabled
                        Pattern.Pattern = RegexDetails.ObjPattern.Pattern
                        Exit For
                    End If
                Next
            End If
            LoadPatterns()
        End If
    End Sub

    Private Sub DeleteBtn_Click(sender As Object, e As EventArgs) Handles DeleteBtn.Click
        Try
            For Each Pattern In PatternList
                If Pattern.Id = PatternGridView.SelectedRows(0).Cells(0).Value Then
                    PatternList.Remove(Pattern)
                    Exit For
                End If
            Next
            LoadPatterns()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ArrowUpBtn_Click(sender As Object, e As EventArgs) Handles ArrowUpBtn.Click
        Try
            Dim i As Integer = 0
            For i = 0 To (PatternList.Count - 1)
                Dim CurrentItem As PatternCls = PatternList.Item(i)
                If CurrentItem.Id = PatternGridView.SelectedRows(0).Cells(0).Value Then
                    PatternList.RemoveAt(i)
                    PatternList.Insert(i - 1, CurrentItem)
                    Exit For
                End If
            Next
            LoadPatterns(i - 1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub xDeleteBtn_Click(sender As Object, e As EventArgs) Handles xDeleteBtn.Click
        Try
            For Each Pattern In PatternList
                If Pattern.Id = PatternGridView.SelectedRows(0).Cells(0).Value Then
                    PatternList.Remove(Pattern)
                    Exit For
                End If
            Next
            LoadPatterns()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ArrowDownBtn_Click(sender As Object, e As EventArgs) Handles ArrowDownBtn.Click
        Try
            Dim i As Integer = 0
            For i = 0 To (PatternList.Count - 1)
                Dim CurrentItem As PatternCls = PatternList.Item(i)
                If CurrentItem.Id = PatternGridView.SelectedRows(0).Cells(0).Value Then
                    PatternList.RemoveAt(i)
                    PatternList.Insert(i + 1, CurrentItem)
                    Exit For
                End If
            Next
            LoadPatterns(i + 1)
        Catch ex As Exception

        End Try
    End Sub

    Sub LoadPatterns(Optional ByVal SelectedIndex As Integer = -1)
        PatternGridView.Rows.Clear()
        For Each Pattern As PatternCls In PatternList
            PatternGridView.Rows.Add(Pattern.Id, Pattern.Name, Pattern.Pattern)
        Next
        For Each Row As DataGridViewRow In PatternGridView.Rows
            If Row.Index = SelectedIndex Then
                Row.Selected = True
                Exit For
            End If
        Next
        ToggleButtons()
    End Sub

    Sub ToggleButtons()
        If PatternGridView.SelectedRows.Count > 0 Then

            EditBtn.Enabled = True
            DeleteBtn.Enabled = True
            xDeleteBtn.Enabled = True

            If PatternGridView.SelectedRows(0).Index < (PatternGridView.Rows.Count - 1) Then
                ArrowDownBtn.Enabled = True
            Else
                ArrowDownBtn.Enabled = False
            End If

            If PatternGridView.SelectedRows(0).Index > 0 Then
                ArrowUpBtn.Enabled = True
            Else
                ArrowUpBtn.Enabled = False
            End If

        Else
            EditBtn.Enabled = False
            DeleteBtn.Enabled = False
            xDeleteBtn.Enabled = False
            ArrowDownBtn.Enabled = False
            ArrowUpBtn.Enabled = False
        End If
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Select Case TreeView1.SelectedNode.Text
            Case "Regex Patterns"
                RegexPatternsLayoutPanel.Visible = True
            Case Else

        End Select
    End Sub

#End Region

End Class