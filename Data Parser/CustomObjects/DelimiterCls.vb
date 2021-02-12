Public Class DelimiterCls

    Sub New()
        Id = Guid.NewGuid().ToString().Replace("-", "")
    End Sub
    Public Property Id As String
    Public Property DelimiterClass As String
    Public Property DelimiterRank As Int32
    Public Property Delimiter As String
End Class
