Imports MySql.Data.MySqlClient
Public Class updatePrice
    Dim _bar_code As String
    Private Sub updatePrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM stocks_info", conbin)
        Dim cmdres As New DataTable
        Try
            cmd.Fill(cmdres)
            DataGridView1.DataSource = cmdres
            DataGridView1.Columns(0).Width = 200
            DataGridView1.Columns(1).Width = 685
            DataGridView1.Columns(2).Width = 50
            DataGridView1.Columns(3).Width = 150
            DataGridView1.Columns(4).Width = 150
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM stocks_info", conbin)
            Dim cmdres As New DataTable
            Try
                cmd.Fill(cmdres)
                DataGridView1.DataSource = cmdres
                DataGridView1.ColumnHeadersVisible = False
                DataGridView1.Columns(1).Width = 685
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).Visible = False
                DataGridView1.Columns(4).Visible = False
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM stocks_info WHERE Medicine_Name LIKE '%" & TextBox2.Text & "%'", conbin)
            Dim cmdres1 As New DataTable
            Try
                cmd1.Fill(cmdres1)
                DataGridView1.DataSource = cmdres1
                DataGridView1.ColumnHeadersVisible = False
                DataGridView1.Columns(1).Width = 685
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).Visible = False
                DataGridView1.Columns(4).Visible = False
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        Label1.Text = selectedRow.Cells(4).Value.ToString
        _bar_code = selectedRow.Cells(0).Value.ToString
        TextBox1.Focus()
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        Try
            connect()
            Dim cmd As New MySqlCommand("UPDATE stocks_info SET Price='" & TextBox1.Text & "' WHERE Bar_ID = '" & _bar_code & "'", conbin)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Update successful")
            TextBox1.Clear()
            TextBox2.Clear()
            Label1.Text = "-"
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM stocks_info", conbin)
            Dim cmdres1 As New DataTable
            Try
                cmd1.Fill(cmdres1)
                DataGridView1.DataSource = cmdres1
                DataGridView1.Columns(0).Width = 200
                DataGridView1.Columns(1).Width = 685
                DataGridView1.Columns(2).Width = 50
                DataGridView1.Columns(3).Width = 150
                DataGridView1.Columns(4).Width = 150
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub
End Class