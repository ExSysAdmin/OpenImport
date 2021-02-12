Public Class PatternCls

    Sub New()
        Id = Guid.NewGuid().ToString().Replace("-", "")
    End Sub

    Public Property Id As String
    Public Property Name As String
    Public Property Pattern As String
    Public Property Enabled As Boolean
    Public Property DataType As String
End Class
