Imports MySql.Data.MySqlClient
Public Class inputPass

    Private Sub inputPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick


        If TextBox2.Text = "" Then
            MessageBox.Show("Error: Empty field!")
        Else
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM account_privilage WHERE account_ID = '" & accountIdent.ToString & "' AND account_pass='" & TextBox2.Text & "'", conbin)
            Dim cmdres As New DataTable

            Try
                cmd.Fill(cmdres)
                If cmdres.Rows.Count = 1 Then
                    form_reference = 1
                    salesformnext.Show()
                    Me.Close()
                Else
                    MessageBox.Show("Wrong passowrd.")
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.BringToFront()
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        Me.Close()
    End Sub
End Class