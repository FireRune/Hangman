Public Class ReadFile

    Private _file As String

    Sub New(file As String)
        _file = file
    End Sub

    Public Sub SetFile(file As String)
        _file = file
    End Sub

    Public Function GetFile() As String
        Return _file
    End Function

    Public Function SelectWord() As String
        Dim word As String
        Do
            Using WordReader As New FileIO.TextFieldParser(_file)
                Dim rng As Integer = New Random().Next(1, GetLines() + 1)
                Dim line As String
                While Not WordReader.EndOfData
                    If WordReader.LineNumber = rng Then
                        line = WordReader.ReadLine()
                        If line <> "" AndAlso ValidateChars(line) = True Then
                            word = line
                            Exit Do
                        End If
                    Else
                        WordReader.ReadLine()
                    End If
                End While
            End Using
        Loop
        Return word
    End Function

    Public Function GetLines() As Integer
        Dim lines As Integer
        Using LineReader As New FileIO.TextFieldParser(_file)
            While Not LineReader.EndOfData
                lines = LineReader.LineNumber
                LineReader.ReadLine()
            End While
        End Using
        Return lines
    End Function

    'Public Function SelectWord() As String
    '    Dim text As String() = IO.File.ReadAllLines(_file)
    '    Dim word As String
    '    Do
    '        Dim rng As Integer = New Random().Next(0, text.Length)
    '        word = text(rng)
    '        If word <> "" AndAlso ValidateChars(word) = True Then
    '            Exit Do
    '        End If
    '    Loop
    '    Return word
    'End Function

    Public Function IsValidFile() As Boolean
        Dim valid As Boolean = False
        Using fileReader As New FileIO.TextFieldParser(_file)
            While Not fileReader.EndOfData
                Dim temp As String = fileReader.ReadLine().ToLower()
                If temp <> "" AndAlso ValidateChars(temp) = True Then
                    valid = True
                    Exit While
                End If
            End While
        End Using
        Return valid
    End Function

    Public Function ValidateChars(word As String) As Boolean
        Dim valid As Boolean = True
        Dim validChars As String() = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ä", "ö", "ü", "ß"}
        Dim wordValid(word.Length() - 1) As Boolean
        For i = 0 To word.Length() - 1
            For j = 0 To validChars.Length() - 1
                If word.ToLower().Chars(i) = validChars(j) Then
                    wordValid(i) = True
                    Exit For
                Else
                    wordValid(i) = False
                End If
            Next
        Next
        For Each t As Boolean In wordValid
            If t = False Then
                valid = False
                Exit For
            End If
        Next
        Return valid
    End Function

End Class
