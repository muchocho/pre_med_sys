Imports MySql.Data.MySqlClient

Public Class collectibles
    Dim _trans_idd As String
    Dim indexa As Integer = 0
    Dim _client_nameee As String
    Dim _cleintt_balance As Decimal

    Private Sub collectibles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Hide()
        Panel5.Hide()
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2", conbin)
        cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
        cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
        Dim cmdtable As New MySqlDataAdapter
        cmdtable.SelectCommand = cmd
        Dim cmdres As New DataTable
        Try
            cmdtable.Fill(cmdres)
            DataGridView1.DataSource = cmdres
            DataGridView1.Columns(0).Width = 130
            DataGridView1.Columns(1).Width = 400
            DataGridView1.Columns(2).Width = 400
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2", conbin)
            cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim cmdtable As New MySqlDataAdapter
            cmdtable.SelectCommand = cmd
            Dim cmdres As New DataTable
            Try
                cmdtable.Fill(cmdres)
                DataGridView1.DataSource = cmdres
                DataGridView1.Columns(0).Width = 130
                DataGridView1.Columns(1).Width = 400
                DataGridView1.Columns(2).Width = 400
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2 AND Client LIKE '%" & TextBox2.Text & "%'", conbin)
            cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim cmdtable As New MySqlDataAdapter
            cmdtable.SelectCommand = cmd
            Dim cmdres As New DataTable
            Try
                cmdtable.Fill(cmdres)
                DataGridView1.DataSource = cmdres
                DataGridView1.Columns(0).Width = 130
                DataGridView1.Columns(1).Width = 400
                DataGridView1.Columns(2).Width = 400
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        Label1.Text = selectedRow.Cells(7).Value.ToString
        _trans_idd = selectedRow.Cells(0).Value.ToString
        _client_nameee = selectedRow.Cells(2).Value.ToString
        TextBox1.Focus()
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        If TextBox1.Text = "" Then
            MessageBox.Show("ERROR: Empty field!")
        Else
            _cleintt_balance = Label1.Text - TextBox1.Text

            Try
                connect()
                Dim cmd As New MySqlCommand("UPDATE trans_sales_data SET Balance = '" & _cleintt_balance & "' WHERE Transaction_No = '" & _trans_idd & "'", conbin)
                cmd.ExecuteNonQuery()
                Try
                    addcolINFO(_trans_idd, _client_nameee, TextBox1.Text, Label3.Text, username)
                    MessageBox.Show("Transaction Successful.")


                    connect()
                    Dim cmd1 As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2", conbin)
                    cmd1.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
                    cmd1.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
                    Dim cmdtable1 As New MySqlDataAdapter
                    cmdtable1.SelectCommand = cmd1
                    Dim cmdres1 As New DataTable
                    Try
                        cmdtable1.Fill(cmdres1)
                        DataGridView1.DataSource = cmdres1
                        DataGridView1.Columns(0).Width = 130
                        DataGridView1.Columns(1).Width = 400
                        DataGridView1.Columns(2).Width = 400
                    Catch ex As Exception
                        MsgBox(ex.Message, vbInformation)
                    End Try

                    TextBox1.Clear()
                    Label1.Text = "-"
                    TextBox1.Focus()
                Catch ex As Exception
                    MsgBox(ex.Message, vbInformation)
                End Try
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If



    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Date.Now.ToString("MM/dd/yyyy")
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        If indexa = 0 Then
            Panel4.Show()
            Panel5.Show()
            indexa = 1

            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM collect_info WHERE Date between @date1 AND @date2", conbin)
            cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim cmdtable As New MySqlDataAdapter
            cmdtable.SelectCommand = cmd
            Dim cmdres As New DataTable
            Try
                cmdtable.Fill(cmdres)
                DataGridView2.DataSource = cmdres
                DataGridView2.Columns(0).Width = 130
                DataGridView2.Columns(1).Width = 400
                DataGridView2.Columns(2).Width = 150
                DataGridView2.Columns(3).Width = 200
                DataGridView2.Columns(4).Width = 400
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try


        Else
            Panel4.Hide()
            Panel5.Hide()
            indexa = 0
        End If
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2", conbin)
        cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
        cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
        Dim cmdtable As New MySqlDataAdapter
        cmdtable.SelectCommand = cmd
        Dim cmdres As New DataTable
        Try
            cmdtable.Fill(cmdres)
            DataGridView1.DataSource = cmdres
            DataGridView1.Columns(0).Width = 130
            DataGridView1.Columns(1).Width = 400
            DataGridView1.Columns(2).Width = 400
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try




        connect()
        Dim cmd1 As New MySqlCommand("SELECT * FROM collect_info WHERE Date between @date1 AND @date2", conbin)
        cmd1.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
        cmd1.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
        Dim cmdtable1 As New MySqlDataAdapter
        cmdtable1.SelectCommand = cmd1
        Dim cmdres1 As New DataTable
        Try
            cmdtable1.Fill(cmdres1)
            DataGridView2.DataSource = cmdres1
            DataGridView2.Columns(0).Width = 130
            DataGridView2.Columns(1).Width = 400
            DataGridView2.Columns(2).Width = 150
            DataGridView2.Columns(3).Width = 200
            DataGridView2.Columns(4).Width = 400
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "" Then
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM collect_info WHERE Date between @date1 AND @date2", conbin)
            cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim cmdtable As New MySqlDataAdapter
            cmdtable.SelectCommand = cmd
            Dim cmdres As New DataTable
            Try
                cmdtable.Fill(cmdres)
                DataGridView2.DataSource = cmdres
                DataGridView2.Columns(0).Width = 130
                DataGridView2.Columns(1).Width = 400
                DataGridView2.Columns(2).Width = 150
                DataGridView2.Columns(3).Width = 200
                DataGridView2.Columns(4).Width = 400
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM collect_info WHERE  Date between @date1 AND @date2 AND Client LIKE '%" & TextBox3.Text & "%'", conbin)
            cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim cmdtable As New MySqlDataAdapter
            cmdtable.SelectCommand = cmd
            Dim cmdres As New DataTable
            Try
                cmdtable.Fill(cmdres)
                DataGridView2.DataSource = cmdres
                DataGridView2.Columns(0).Width = 130
                DataGridView2.Columns(1).Width = 400
                DataGridView2.Columns(2).Width = 150
                DataGridView2.Columns(3).Width = 200
                DataGridView2.Columns(4).Width = 400
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2", conbin)
        cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
        cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
        Dim cmdtable As New MySqlDataAdapter
        cmdtable.SelectCommand = cmd
        Dim cmdres As New DataTable
        Try
            cmdtable.Fill(cmdres)
            DataGridView1.DataSource = cmdres
            DataGridView1.Columns(0).Width = 130
            DataGridView1.Columns(1).Width = 400
            DataGridView1.Columns(2).Width = 400
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try




        connect()
        Dim cmd1 As New MySqlCommand("SELECT * FROM collect_info WHERE Date between @date1 AND @date2", conbin)
        cmd1.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
        cmd1.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
        Dim cmdtable1 As New MySqlDataAdapter
        cmdtable1.SelectCommand = cmd1
        Dim cmdres1 As New DataTable
        Try
            cmdtable1.Fill(cmdres1)
            DataGridView2.DataSource = cmdres1
            DataGridView2.Columns(0).Width = 130
            DataGridView2.Columns(1).Width = 400
            DataGridView2.Columns(2).Width = 150
            DataGridView2.Columns(3).Width = 200
            DataGridView2.Columns(4).Width = 400
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub
End Class