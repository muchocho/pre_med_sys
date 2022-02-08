Public Class Form1

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick


        Dim countd As Integer = Len(TextBox1.Text)
        Dim convert As Integer = TextBox1.Text
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please fillout the information needed!")
            TextBox1.Clear()
            TextBox2.Clear()
            TextBox1.Focus()
        Else
            Try
                Dim dt As DataTable = login(TextBox1.Text, TextBox2.Text)
                If dt.Rows.Count > 0 Then
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox1.Focus()
                    accountIdent = convert
                    If countd = 7 Then
                        admindashboard.Show()
                        Me.Hide()
                    Else
                        adminadmin.Show()
                        Me.Hide()
                    End If
                Else
                    MessageBox.Show("Invalid User ID or Password!")
                    TextBox1.Clear()
                    TextBox2.Clear()
                    TextBox1.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        Me.Close()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
