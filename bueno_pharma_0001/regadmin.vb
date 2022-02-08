Public Class regadmin
    Public random As New Random
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Date.Now.ToString("MM/dd/yyyy")
    End Sub

    Private Sub regadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Please Fillout the information needed!")
        Else
            Dim accId As Integer = random.Next(0, 1000000)
            Dim tyype As String = "Admin"
            Try
                Dim dt As DataTable = valID(accId)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("ID already exist, please click 'OK' button, and then click 'Save' button again.")
                Else

                    Try
                        Dim dt1 As DataTable = valname(TextBox1.Text)
                        If dt1.Rows.Count > 0 Then
                            MessageBox.Show("Account name already exist")
                        Else
                            Try
                                accountreg(accId, tyype, TextBox1.Text, TextBox2.Text, Label1.Text)
                                MessageBox.Show("Information saved!" + "Account ID: " + accId.ToString)
                                TextBox1.Clear()
                                TextBox2.Clear()
                                TextBox1.Focus()
                            Catch ex As Exception
                                MsgBox(ex.Message, vbInformation)
                            End Try
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message, vbInformation)
                    End Try
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        adminadmin.Show()
        Me.Close()
    End Sub
End Class