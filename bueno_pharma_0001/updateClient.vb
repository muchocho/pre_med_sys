Imports MySql.Data.MySqlClient
Public Class updateClient
    Dim _acc_ID As Integer
    Private Sub updateClient_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM client_info", conbin)
        Dim cmdres As New DataTable
        Try
            cmd.Fill(cmdres)
            DataGridView1.DataSource = cmdres
            DataGridView1.Columns(0).Width = 65
            DataGridView1.Columns(1).Width = 250
            DataGridView1.Columns(2).Width = 250
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).Width = 250
            DataGridView1.Columns(5).Width = 75
            DataGridView1.Columns(6).Width = 85
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        _acc_ID = selectedRow.Cells(0).Value.ToString
        TextBox1.Text = selectedRow.Cells(1).Value.ToString
        TextBox2.Text = selectedRow.Cells(2).Value.ToString
        TextBox3.Text = selectedRow.Cells(3).Value.ToString
        TextBox4.Text = selectedRow.Cells(4).Value.ToString
        TextBox5.Text = selectedRow.Cells(5).Value.ToString
        Panel2.Hide()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If TextBox6.Text = "" Then
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM client_info", conbin)
            Dim cmdres As New DataTable
            Try
                cmd.Fill(cmdres)
                DataGridView1.DataSource = cmdres
                DataGridView1.Columns(0).Width = 65
                DataGridView1.Columns(1).Width = 250
                DataGridView1.Columns(2).Width = 250
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Width = 250
                DataGridView1.Columns(5).Width = 75
                DataGridView1.Columns(6).Width = 85
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM client_info WHERE Name LIKE '%" & TextBox6.Text & "%'", conbin)
            Dim cmdres1 As New DataTable
            Try
                cmd1.Fill(cmdres1)
                DataGridView1.DataSource = cmdres1
                DataGridView1.Columns(0).Width = 65
                DataGridView1.Columns(1).Width = 250
                DataGridView1.Columns(2).Width = 250
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Width = 250
                DataGridView1.Columns(5).Width = 75
                DataGridView1.Columns(6).Width = 85
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        Try
            connect()
            Dim cmd As New MySqlCommand("UPDATE client_info SET Name='" & TextBox1.Text & "',Address='" & TextBox2.Text & "',Contact_No='" & TextBox3.Text & "',Email='" & TextBox4.Text & "',Terms='" & TextBox5.Text & "' WHERE Client_ID='" & _acc_ID & "'", conbin)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Update successful.")
            Panel2.Show()
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM client_info", conbin)
            Dim cmdres1 As New DataTable
            Try
                cmd1.Fill(cmdres1)
                DataGridView1.DataSource = cmdres1
                DataGridView1.Columns(0).Width = 65
                DataGridView1.Columns(1).Width = 250
                DataGridView1.Columns(2).Width = 250
                DataGridView1.Columns(3).Width = 100
                DataGridView1.Columns(4).Width = 250
                DataGridView1.Columns(5).Width = 75
                DataGridView1.Columns(6).Width = 85
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        Panel2.Show()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub
End Class