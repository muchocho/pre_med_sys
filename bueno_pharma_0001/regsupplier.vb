Imports MySql.Data.MySqlClient
Public Class regsupplier
    Private Sub regsupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
            MessageBox.Show("Please fillout the information needed!")
        Else
            Try
                Dim dt As DataTable = valsup(TextBox1.Text)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("Supplier name already exist!")
                Else
                    Try
                        suppliereg(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, Label1.Text)
                        TextBox1.Clear()
                        TextBox2.Clear()
                        TextBox3.Clear()
                        TextBox4.Clear()
                        TextBox5.Clear()
                        TextBox1.Focus()
                        MessageBox.Show("Information saved!")
                    Catch ex As Exception
                        MsgBox(ex.Message, vbInformation)
                    End Try
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Date.Now.ToString("MM/dd/yyyy")
    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        purchaseStock.Show()
        Me.Close()
    End Sub

    Private Sub Panel5_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel5.MouseClick
        salesform.Show()
        Me.Close()
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        registerClient.Show()
        Me.Close()
    End Sub

    Private Sub Panel7_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel7.MouseClick
        updateClient.Show()
        Me.Close()
    End Sub

    Private Sub Panel8_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel8.MouseClick
        stocksinfor.Show()
        Me.Close()
    End Sub

    Private Sub Panel9_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel9.MouseClick
        payables.Show()
        Me.Close()
    End Sub

    Private Sub Panel10_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel10.MouseClick
        updateSupplier.Show()
        Me.Close()
    End Sub
End Class