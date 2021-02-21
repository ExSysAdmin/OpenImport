Public Class InitialStartup

    Public Function GetInitialPatternList() As List(Of PatternCls)
        Dim Patterns As List(Of PatternCls) = New List(Of PatternCls)

        Dim Pattern01 As New PatternCls With {
            .Name = "Phone Number",
            .DataType = "String",
            .Enabled = True,
            .Pattern = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"
        }
        Patterns.Add(Pattern01)

        Dim Pattern02 As New PatternCls With {
            .Name = "Email Address",
            .DataType = "String",
            .Enabled = True,
            .Pattern = "^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$"
        }
        Patterns.Add(Pattern02)

        Dim Pattern03 As New PatternCls With {
            .Name = "DateTime",
            .DataType = "String",
            .Enabled = True,
            .Pattern = "(?n:^(?=\d)((?<month>(0?[13578])|1[02]|(0?[469]|11)(?!.31)|0?2(?(.29)(?=.29.((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(16|[2468][048]|[3579][26])00))|(?!.3[01])))(?<sep>[-./])(?<day>0?[1-9]|[12]\d|3[01])\k<sep>(?<year>(1[6-9]|[2-9]\d)\d{2})(?(?=\x20\d)\x20|$))?(?<time>((0?[1-9]|1[012])(:[0-5]\d){0,2}(?i:\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$)"
        }
        Patterns.Add(Pattern03)

        Dim PatternLast As New PatternCls With {
            .Name = "Numeric Value",
            .DataType = "String",
            .Enabled = True,
            .Pattern = "^([0-9])*$|^([1-9][0-9]{0,2}([,][0-9]{3})*([.][0-9]*))$"
        }
        Patterns.Add(PatternLast)

        Return Patterns
    End Function


    Public Function GetInitialDelimiterList() As List(Of DelimiterCls)
        Dim Delimiters As New List(Of DelimiterCls)

        Dim Delimiter01 As New DelimiterCls With {
            .Delimiter = ","
        }
        Delimiters.Add(Delimiter01)

        Dim Delimiter02 As New DelimiterCls With {
            .Delimiter = vbTab
        }
        Delimiters.Add(Delimiter02)

        Return Delimiters
    End Function

End Class
