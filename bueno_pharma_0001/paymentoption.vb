Imports MySql.Data.MySqlClient
Public Class paymentoption
    Dim options As Integer
    Dim _dis_val As Decimal
    Dim paymentf As Decimal
    Dim _upbalace As Decimal
    Private Sub paymentoption_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        Label5.Text = sumtotal

        Timer1.Enabled = True


        If form_reference = 0 Then

            Panel7.Hide()
            ComboBox1.SelectedItem = "None"
            options = 0
        ElseIf form_reference = 1

            Panel7.Show()
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM trans_sales_data WHERE Transaction_No='" & selected & "'", conbin)
            Dim cmdres As New DataTable
            Try
                cmd.Fill(cmdres)
                ComboBox1.SelectedItem = cmdres.Rows(0).Item(9).ToString
                paymentf = cmdres.Rows(0).Item(6).ToString
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Date.Now.ToString("MM/dd/yyyy")
        Label4.Text = Date.Now.ToString("hh:mm")
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        If options = 0 Then
            If TextBox1.Text = "" Then
                MessageBox.Show("ERROR: empty field!")
            Else
                Dim change As Decimal = TextBox1.Text - Label5.Text
                Try
                    Dim bal As String = "Paid"
                    Dim terms As String = ""
                    addsalestrans(finalID, staff, salesformnext.Label1.Text, Label3.Text, Label4.Text, sumtotal, TextBox1.Text, bal, terms, ComboBox1.Text, Label5.Text, total_cost)
                    MessageBox.Show("Total Change: " + change.ToString + ", Transaction Successful.")
                    salesform.Show()
                    salesformnext.Close()
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, vbInformation)
                End Try
            End If
        ElseIf options = 1
            If TextBox2.Text = "" Or TextBox3.Text = "" Then
                MessageBox.Show("ERROR: empty field!")
            Else
                Dim bal As Decimal = Label5.Text - TextBox2.Text

                Try
                    addsalestrans(finalID, staff, salesformnext.Label1.Text, Label3.Text, Label4.Text, sumtotal, TextBox2.Text, bal.ToString, TextBox3.Text, ComboBox1.Text, Label5.Text, total_cost)
                    MessageBox.Show("Transaction Successful.")
                    salesform.Show()
                    salesformnext.Close()
                    Me.Close()
                Catch ex As Exception
                    MsgBox(ex.Message, vbInformation)
                End Try
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            TextBox2.Show()
            TextBox3.Show()
        Else
            TextBox2.Hide()
            TextBox3.Hide()
            options = 0
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            TextBox1.Show()
        Else
            TextBox1.Hide()
            options = 1
        End If
    End Sub



    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged

        If ComboBox1.Text = "None" Then
            Label5.Text = sumtotal
        Else
            _dis_val = (salesformnext.Label5.Text * ComboBox1.SelectedItem) / 100
            Label5.Text = sumtotal - _dis_val
        End If
    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        salesformnext.Show()
        Me.Hide()
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        salesformnext.Show()
        Me.Close()

    End Sub

    Private Sub Panel8_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel8.MouseClick
        _upbalace = Label5.Text - paymentf
        Try
            connect()
            Dim cmd As New MySqlCommand("UPDATE trans_sales_data SET Total_Price='" & sumtotal & "', Balance='" & _upbalace & "', Discount_Percentage='" & ComboBox1.Text & "', Discount_Amount='" & Label5.Text & "', Total_Cost='" & total_cost & "' WHERE Transaction_No='" & selected & "'", conbin)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Update successful.")
            salesReport.Show()
            Me.Close()
            salesformnext.Close()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub
End Class