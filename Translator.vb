'
' Binary Hex Translator -> Class TRANSLATOR
' Author: Bobby Georgiou
' Date: 2014
'
Public Class Translator
    Dim Mode As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Mode = "Encode" Then
            If TextBox1.Text <> "" Then
                Dim Result As New System.Text.StringBuilder
                Dim val As String = Nothing
                For Each Character As Byte In System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox1.Text)
                    Result.Append(Convert.ToString(Character, 2).PadLeft(8, "0"))
                    Result.Append(" ")
                Next
                val = Result.ToString.Substring(0, Result.ToString.Length - 1)
                TextBox2.Text = val
            Else
                MsgBox("Please enter the text string you would like to convert to binary.", MsgBoxStyle.Exclamation, "Field is blank")
            End If
        Else
            Dim Val As String = Nothing
            Dim Characters As String = System.Text.RegularExpressions.Regex.Replace(TextBox1.Text, "[^01]", "")
            Dim ByteArray((Characters.Length / 8) - 1) As Byte
            For Index As Integer = 0 To ByteArray.Length - 1
                ByteArray(Index) = Convert.ToByte(Characters.Substring(Index * 8, 8), 2)
            Next
            Val = System.Text.ASCIIEncoding.ASCII.GetString(ByteArray)
            TextBox2.Text = Val
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Timer1.Start()
        Else
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Mode = "Encode" Then
            If TextBox1.Text <> "" Then
                Dim Result As New System.Text.StringBuilder
                Dim val As String = Nothing
                For Each Character As Byte In System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox1.Text)
                    Result.Append(Convert.ToString(Character, 2).PadLeft(8, "0"))
                    Result.Append(" ")

                Next
                val = Result.ToString.Substring(0, Result.ToString.Length - 1)
                TextBox2.Text = val
            Else
                '
            End If
        Else
            Dim Val As String = Nothing
            Dim Characters As String = System.Text.RegularExpressions.Regex.Replace(TextBox1.Text, "[^01]", "")
            Dim ByteArray((Characters.Length / 8) - 1) As Byte
            For Index As Integer = 0 To ByteArray.Length - 1
                ByteArray(Index) = Convert.ToByte(Characters.Substring(Index * 8, 8), 2)
            Next
            Val = System.Text.ASCIIEncoding.ASCII.GetString(ByteArray)
            TextBox2.Text = Val
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If TextBox1.Text = "" Then TextBox2.Text = ""

        If TextBox1.Text = "" Then
            Button1.Enabled = False
        Else
            Button1.Enabled = True
        End If

        If TextBox2.Text = "" Then
            Button2.Enabled = False
        Else
            Button2.Enabled = True
        End If

        If TextBox1.Text = "" And TextBox2.Text = "" Then
            LinkLabel1.Enabled = False
        Else
            LinkLabel1.Enabled = True
        End If

        '

        If TextBox4.Text = "" Then TextBox3.Text = ""

        If TextBox4.Text = "" Then
            Button4.Enabled = False
        Else
            Button4.Enabled = True
        End If

        If TextBox3.Text = "" Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If

        If TextBox4.Text = "" And TextBox3.Text = "" Then
            LinkLabel2.Enabled = False
        Else
            LinkLabel2.Enabled = True
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        TextBox1.Text = ""
        TextBox1.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.Clipboard.SetText(TextBox2.Text)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Mode = "Encode" Then
            If TextBox4.Text <> "" Then
                Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(TextBox4.Text)
                Dim hex As String = BitConverter.ToString(bytes).Replace("-", String.Empty)
                Dim s As String = hex
                For i As Integer = s.Length - 2 To 1 Step -2
                    s = s.Insert(i, " ")
                Next
                TextBox3.Text = s
            Else
                MsgBox("Please enter the text string you would like to convert to hex.", MsgBoxStyle.Exclamation, "Field is blank")
            End If
        Else
            TextBox3.Text = DecodeHex(TextBox4.Text.Replace(" ", ""))
        End If
    End Sub

    Private Function DecodeHex(ByVal HexString As String) As String
        Dim thisChar As String
        Dim ascii As Integer
        Dim ret As String
        Do While Len(HexString) > 0
            'Get the next two-digit hex number
            thisChar = HexString.Substring(0, 2)
            'Remove this hex number from the source string
            HexString = HexString.Substring(2)
            'Get the value in decimal of this hex number
            ascii = CInt(Val("&H" & thisChar))
            'Convert it to a character
            ret &= Chr(ascii)
        Loop
        Return ret
    End Function

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        TextBox4.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If Mode = "Encode" Then
            If TextBox4.Text <> "" Then
                Dim bytes As Byte() = System.Text.Encoding.ASCII.GetBytes(TextBox4.Text)
                Dim hex As String = BitConverter.ToString(bytes).Replace("-", String.Empty)
                Dim s As String = hex
                For i As Integer = s.Length - 2 To 1 Step -2
                    s = s.Insert(i, " ")
                Next
                TextBox3.Text = s
            Else
                '
            End If
        Else
            TextBox3.Text = DecodeHex(TextBox4.Text.Replace(" ", ""))
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Timer3.Start()
        Else
            Timer3.Stop()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.Clipboard.SetText(TextBox3.Text)
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then Mode = "Encode"
        Label7.Text = "Encode Mode"
        Label7.ForeColor = Color.Blue
        GroupBox1.Text = "Binary Encoder"
        GroupBox2.Text = "Hex Encoder"
        Label1.Text = "Text to encode"
        Label6.Text = "Text to encode"
        Button1.Text = "ENCODE"
        Button4.Text = "ENCODE"
        Label2.Text = "Binary code"
        Label4.Text = "Hex code"
        Button2.Text = "COPY CODE"
        Button3.Text = "COPY CODE"
        Label5.Visible = True
        Label3.Visible = True
        CheckBox1.Checked = False
        CheckBox1.Visible = True
        CheckBox2.Checked = False
        CheckBox2.Visible = True
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then Mode = "Decode"
        Label7.Text = "Decode Mode"
        Label7.ForeColor = Color.Green
        GroupBox1.Text = "Binary Decoder"
        GroupBox2.Text = "Hex Decoder"
        Label1.Text = "Binary code"
        Label6.Text = "Hex code"
        Button1.Text = "DECODE"
        Button4.Text = "DECODE"
        Label2.Text = "Decoded text"
        Label4.Text = "Decoded text"
        Button2.Text = "COPY TEXT"
        Button3.Text = "COPY TEXT"
        Label5.Visible = False
        Label3.Visible = False
        CheckBox1.Checked = False
        CheckBox1.Visible = False
        CheckBox2.Checked = False
        CheckBox2.Visible = False
        TextBox1.Text = ""
        TextBox4.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        GroupBox1.Height = GroupBox1.Height - 5
        GroupBox2.Height = GroupBox2.Height - 5
        Me.Height = Me.Height - 5
        If GroupBox1.Height = 405 Then Timer4.Stop()
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        GroupBox1.Height = GroupBox1.Height + 5
        GroupBox2.Height = GroupBox2.Height + 5
        Me.Height = Me.Height + 5
        If Me.Height = 525 Then Timer5.Stop()
    End Sub
End Class
