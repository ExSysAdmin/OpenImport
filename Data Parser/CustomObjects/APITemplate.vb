Public Class APITemplate

    Sub New()
        Id = Guid.NewGuid().ToString("N")
        Columns = New List(Of APITemplateColumn)
    End Sub

    Public Property Id As String
    Public Property Name As String
    Public Property Description As String
    Public Property Columns As List(Of APITemplateColumn)

End Class

Public Class APITemplateColumn

    Public PresentationProperties As APITemplateColumnPresntationProperties

    Public DataProperties As APITemplateColumnDataProperties

End Class

Public Class APITemplateColumnPresntationProperties

    Public Property HeaderText As String
    Public Property CellStyleFormat As String

End Class

Public Class APITemplateColumnDataProperties
    Public Property Name As String
    Public Property AllowNull As String
    Public Property DataType As String
    Public Property DataFormat As String
End Class
