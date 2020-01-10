Public Class Form1

    Private file As ReadFile

    Private _word As String
    Private _maskedWord As String()

    Private _life As Integer = 12
    Private _damage As Integer = 0

    Private _running As Boolean = False

    Private Sub StartGame()
        If file.IsValidFile() = True Then
            TheHangedMan()
            Label2.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            Button1.Visible = False
            Button2.Enabled = False
            Button33.Visible = True
            Button34.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            RadioButton3.Enabled = False
            TextBox1.Text = ""
            _word = file.SelectWord()
            ReDim _maskedWord(_word.Length() - 1)
            For i = 0 To _word.Length() - 1
                _maskedWord(i) = "*"
            Next
            Display()
            Label1.Visible = True
            Timer1.Enabled = True
            If RadioButton3.Checked = True Then
                Timer2.Enabled = True
            End If
            _running = True
        Else
            MessageBox.Show("Die ausgewählte Datei ist leer oder enthält nur Wörter mit ungültigen Zeichen. Bitte wählen Sie eine andere Datei aus.")
        End If
    End Sub

    Private Sub CheckLetter(letter As String, modifier As Integer)
        Dim letterInWord As Boolean = False
        For i = 0 To _word.Length() - 1
            If _word.ToLower().Chars(i) = letter Then
                _maskedWord(i) = _word.Chars(i)
                letterInWord = True
            End If
        Next
        If letterInWord = False Then
            Hurt(modifier)
            If _damage = 0 Then
                Exit Sub
            End If
        End If
        Display()
        If TextBox1.Text.Contains("*") = False Then
            Label3.Visible = True
            If _damage = 0 Then
                Label4.Visible = True
            End If
            StopRightThere()
        End If
    End Sub

    Private Sub TheHangedMan()
        Select Case _damage
            Case 0
                TextBox3.Text = ""
            Case 1
                TextBox3.Text = "        " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | "
            Case 2
                TextBox3.Text = "        " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "     /|\"
            Case 3
                TextBox3.Text = "--------" & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "     /|\"
            Case 4
                TextBox3.Text = "--------" & vbCrLf &
                                "     \|/" & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "     /|\"
            Case 5
                TextBox3.Text = "--------" & vbCrLf &
                                " |   \|/" & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "___   | " & vbCrLf &
                                "| |  /|\"
            Case 6
                TextBox3.Text = "--------" & vbCrLf &
                                " |   \|/" & vbCrLf &
                                " O    | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "      | " & vbCrLf &
                                "___   | " & vbCrLf &
                                "| |  /|\"
            Case 7
                TextBox3.Text = "--------" & vbCrLf &
                                " |   \|/" & vbCrLf &
                                " O    | " & vbCrLf &
                                " |    | " & vbCrLf &
                                " |    | " & vbCrLf &
                                "      | " & vbCrLf &
                                "___   | " & vbCrLf &
                                "| |  /|\"
            Case 8
                TextBox3.Text = "--------" & vbCrLf &
                                " |   \|/" & vbCrLf &
                                " O    | " & vbCrLf &
                                "/|    | " & vbCrLf &
                                " |    | " & vbCrLf &
                                "      | " & vbCrLf &
                                "___   | " & vbCrLf &
                                "| |  /|\"
            Case 9
                TextBox3.Text = "--------" & vbCrLf &
                                " |   \|/" & vbCrLf &
                                " O    | " & vbCrLf &
                                "/|\   | " & vbCrLf &
                                " |    | " & vbCrLf &
                                "      | " & vbCrLf &
                                "___   | " & vbCrLf &
                                "| |  /|\"
            Case 10
                TextBox3.Text = "--------" & vbCrLf &
                                " |   \|/" & vbCrLf &
                                " O    | " & vbCrLf &
                                "/|\   | " & vbCrLf &
                                " |    | " & vbCrLf &
                                "/     | " & vbCrLf &
                                "___   | " & vbCrLf &
                                "| |  /|\"
            Case 11
                TextBox3.Text = "--------" & vbCrLf &
                                " |   \|/" & vbCrLf &
                                " O    | " & vbCrLf &
                                "/|\   | " & vbCrLf &
                                " |    | " & vbCrLf &
                                "/ \   | " & vbCrLf &
                                "___   | " & vbCrLf &
                                "| |  /|\"
            Case 12
                TextBox3.Text = "--------" & vbCrLf &
                                " |   \|/" & vbCrLf &
                                " O    | " & vbCrLf &
                                "/|\   | " & vbCrLf &
                                " |    | " & vbCrLf &
                                "/ \   | " & vbCrLf &
                                "      | " & vbCrLf &
                                "     /|\"
        End Select
    End Sub

    Private Sub Display()
        Dim temp As String = ""
        For i = 0 To _maskedWord.Length() - 1
            temp = temp & _maskedWord(i)
        Next
        TextBox1.Text = temp
    End Sub

    Private Sub StopRightThere()
        _running = False
        _damage = 0
        ResetButtons()
        Label1.Visible = False
        Timer1.Enabled = False
        Timer2.Enabled = False
        ProgressBar1.Value = 0
        Button1.Visible = True
        Button2.Enabled = True
        Button33.Visible = False
        Button34.Enabled = True
        RadioButton1.Enabled = True
        RadioButton2.Enabled = True
        RadioButton3.Enabled = True
    End Sub

    Private Sub ResetButtons()
        For Each letter As Button In GroupBox1.Controls
            letter.Enabled = True
        Next
    End Sub

    Private Sub ShowFile()
        Dim preText As String = "Ausgewählte Datei: "
        If file.GetFile().StartsWith(My.Computer.FileSystem.CurrentDirectory) = True Then
            Dim temp As String() = My.Computer.FileSystem.CurrentDirectory.Split("\")
            Dim shortpath As String = temp(temp.Length() - 1) & file.GetFile().Remove(0, My.Computer.FileSystem.CurrentDirectory.Length())
            TextBox2.Text = preText & shortpath
        Else
            TextBox2.Text = preText & file.GetFile()
        End If
    End Sub

    Private Sub Hurt(modifier As Integer)
        _damage += modifier
        TheHangedMan()
        If _damage >= _life Then
            StopRightThere()
            Label2.Visible = True
            TextBox1.Text = _word
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists(My.Computer.FileSystem.CurrentDirectory & "\Wortlisten") = False Then
            My.Computer.FileSystem.CreateDirectory(My.Computer.FileSystem.CurrentDirectory & "\Wortlisten")
        End If
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.CurrentDirectory & "\Wortlisten\Default.txt") = False Then
            IO.File.WriteAllText(My.Computer.FileSystem.CurrentDirectory & "\Wortlisten\Default.txt", "Dateisystem" & vbCrLf & "Telefon" & vbCrLf & "Computer" & vbCrLf & "Server" & vbCrLf & "Monitor" & vbCrLf & "Allgemein" & vbCrLf & "Programmierung" & vbCrLf & "unerwartet" & vbCrLf & "Projekt" & vbCrLf & "Hangman")
        End If
        file = New ReadFile(My.Computer.FileSystem.CurrentDirectory & "\Wortlisten\Default.txt")
        ShowFile()
        OpenFileDialog1.InitialDirectory = My.Computer.FileSystem.CurrentDirectory & "\Wortlisten"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        StartGame()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            file.SetFile(OpenFileDialog1.FileName)
        End If
        ShowFile()
    End Sub

    Private Sub Button3to32_Click(sender As Object, e As EventArgs) Handles Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click, Button12.Click, Button13.Click, Button14.Click, Button15.Click, Button16.Click, Button17.Click, Button18.Click, Button19.Click, Button20.Click, Button21.Click, Button22.Click, Button23.Click, Button24.Click, Button25.Click, Button26.Click, Button27.Click, Button28.Click, Button29.Click, Button30.Click, Button31.Click, Button32.Click
        If _running = True Then
            CType(sender, Button).Enabled = False
            If RadioButton1.Checked = True Then
                CheckLetter(CType(sender, Button).Text, 1)
            ElseIf RadioButton2.Checked = True Then
                CheckLetter(CType(sender, Button).Text, 2)
            ElseIf RadioButton3.Checked = True Then
                CheckLetter(CType(sender, Button).Text, 3)
                ProgressBar1.Value = 0
            End If
        End If
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        StopRightThere()
        TextBox1.Text = ""
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        MessageBox.Show("Es können auch benutzerdefinierte Wortlisten in Form von .txt-Dateien verwendet werden." & vbCrLf & vbCrLf &
                        "Jedes Wort muss in einer eigenen Zeile stehen." & vbCrLf &
                        "Nur Buchstaben von A bis Z, sowie Ä, Ö, Ü und ß, sind erlaubt." & vbCrLf &
                        "Groß- & Kleinschreibung wird nicht beachtet.")
    End Sub

    Private Sub TextBox2_MouseHover(sender As Object, e As EventArgs) Handles TextBox2.MouseHover
        ToolTip1.Show(file.GetFile(), sender)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Label1.Visible = True Then
            Select Case Label1.Text
                Case "Running"
                    Label1.Text = "Running."
                Case "Running."
                    Label1.Text = "Running.."
                Case "Running.."
                    Label1.Text = "Running..."
                Case "Running..."
                    Label1.Text = "Running"
            End Select
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If ProgressBar1.Value = 30 Then
            ProgressBar1.Value = 0
            Hurt(3)
        End If
        ProgressBar1.PerformStep()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            ProgressBar1.Visible = True
        Else
            ProgressBar1.Visible = False
        End If
    End Sub

End Class
