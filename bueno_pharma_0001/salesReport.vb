Imports MySql.Data.MySqlClient
Public Class salesReport

    Private Sub salesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Hide()

        Try
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2", conbin)
            cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim cmdtable As New MySqlDataAdapter
            cmdtable.SelectCommand = cmd
            Dim cmdres As New DataTable
            cmdtable.Fill(cmdres)


            If cmdres.Rows.Count >= 1 Then
                DataGridView1.DataSource = cmdres
                DataGridView1.Columns(0).Width = 130
                DataGridView1.Columns(1).Width = 400
                DataGridView1.Columns(2).Width = 400
                ''Me.DataGridView1.CurrentCell = Me.DataGridView1(0, 1)
                Dim _gross_pro As Decimal = 0
                For Each row As DataGridViewRow In DataGridView1.Rows
                    _gross_pro += row.Cells(10).Value
                Next
                Label2.Text = "₱ " + _gross_pro.ToString


                Dim _fortotal_vost As Decimal = 0
                For Each row As DataGridViewRow In DataGridView1.Rows
                    _fortotal_vost += row.Cells(11).Value
                Next
                Label1.Text = "₱ " + (_gross_pro - _fortotal_vost).ToString
            ElseIf cmdres.Rows.Count = 0
                Label1.Text = "-"
                Label2.Text = "-"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

        Try
                connect()
                Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2", conbin)
                cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
                cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
                Dim cmdtable As New MySqlDataAdapter
                cmdtable.SelectCommand = cmd
                Dim cmdres As New DataTable
                cmdtable.Fill(cmdres)
            DataGridView1.DataSource = cmdres
            DataGridView1.Columns(0).Width = 130
            DataGridView1.Columns(1).Width = 400
            DataGridView1.Columns(2).Width = 400
            If cmdres.Rows.Count >= 1 Then
                    Dim _gross_pro As Decimal = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        _gross_pro += row.Cells(10).Value
                    Next
                    Label2.Text = "₱ " + _gross_pro.ToString

                    Dim _fortotal_vost As Decimal = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        _fortotal_vost += row.Cells(11).Value
                    Next
                    Label1.Text = "₱ " + (_gross_pro - _fortotal_vost).ToString

                ElseIf cmdres.Rows.Count = 0
                    Label1.Text = "-"
                    Label2.Text = "-"
                End If

            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try



    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged

        Try
                connect()
                Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2", conbin)
                cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
                cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
                Dim cmdtable As New MySqlDataAdapter
                cmdtable.SelectCommand = cmd
                Dim cmdres As New DataTable
                cmdtable.Fill(cmdres)
                DataGridView1.DataSource = cmdres
            DataGridView1.Columns(0).Width = 130
            DataGridView1.Columns(1).Width = 400
            DataGridView1.Columns(2).Width = 400

            If cmdres.Rows.Count >= 1 Then
                    Dim _gross_pro As Decimal = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        _gross_pro += row.Cells(10).Value
                    Next
                    Label2.Text = "₱ " + _gross_pro.ToString


                    Dim _fortotal_vost As Decimal = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        _fortotal_vost += row.Cells(11).Value
                    Next
                    Label1.Text = "₱ " + (_gross_pro - _fortotal_vost).ToString

                ElseIf cmdres.Rows.Count = 0
                    Label1.Text = "-"
                    Label2.Text = "-"
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try


    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            Try
                connect()
                Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2", conbin)
                cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
                cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
                Dim cmdtable As New MySqlDataAdapter
                cmdtable.SelectCommand = cmd
                Dim cmdres As New DataTable
                cmdtable.Fill(cmdres)
                DataGridView1.DataSource = cmdres
                If cmdres.Rows.Count >= 1 Then
                    Dim _gross_pro As Decimal = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        _gross_pro += row.Cells(10).Value
                    Next
                    Label2.Text = "₱ " + _gross_pro.ToString

                    Dim _fortotal_vost As Decimal = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        _fortotal_vost += row.Cells(11).Value
                    Next
                    Label1.Text = "₱ " + (_gross_pro - _fortotal_vost).ToString

                ElseIf cmdres.Rows.Count = 0
                    Label1.Text = "-"
                    Label2.Text = "-"
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            Try
                connect()
                Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2 AND Client LIKE '%" & TextBox1.Text & "%'", conbin)
                cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
                cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
                Dim cmdtable As New MySqlDataAdapter
                cmdtable.SelectCommand = cmd
                Dim cmdres As New DataTable
                cmdtable.Fill(cmdres)
                DataGridView1.DataSource = cmdres
                If cmdres.Rows.Count >= 1 Then
                    Dim _gross_pro As Decimal = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        _gross_pro += row.Cells(10).Value
                    Next
                    Label2.Text = "₱ " + _gross_pro.ToString

                    Dim _fortotal_vost As Decimal = 0
                    For Each row As DataGridViewRow In DataGridView1.Rows
                        _fortotal_vost += row.Cells(11).Value
                    Next
                    Label1.Text = "₱ " + (_gross_pro - _fortotal_vost).ToString

                ElseIf cmdres.Rows.Count = 0
                    Label1.Text = "-"
                    Label2.Text = "-"
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Panel2.Show()
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        selected = selectedRow.Cells(0).Value.ToString

        Dim _net_pro As Decimal

        _net_pro = selectedRow.Cells(10).Value - selectedRow.Cells(11).Value
        Label1.Text = _net_pro.ToString
        Label2.Text = selectedRow.Cells(10).Value.ToString

        Label3.Text = selectedRow.Cells(0).Value.ToString
        Label5.Text = selectedRow.Cells(2).Value.ToString
        Label6.Text = selectedRow.Cells(5).Value.ToString
        Label7.Text = selectedRow.Cells(11).Value.ToString
        Label8.Text = selectedRow.Cells(10).Value.ToString
        Label9.Text = selectedRow.Cells(9).Value.ToString
        Label10.Text = selectedRow.Cells(6).Value.ToString
        Label11.Text = selectedRow.Cells(7).Value.ToString
        Label12.Text = selectedRow.Cells(8).Value.ToString
        Label13.Text = selectedRow.Cells(1).Value.ToString
        Label14.Text = selectedRow.Cells(3).Value.ToString
        Label15.Text = selectedRow.Cells(4).Value.ToString
        Panel5.Hide()

        Try
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM sales_data WHERE Date between @date1 AND @date2 AND Transaction_ID='" & selected & "'", conbin)
            cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim cmdtable As New MySqlDataAdapter
            cmdtable.SelectCommand = cmd
            Dim cmdres As New DataTable
            cmdtable.Fill(cmdres)
            DataGridView2.DataSource = cmdres
            Label4.Text = cmdres.Rows(0).Item(1).ToString
            DataGridView2.Columns(2).Width = 400
            DataGridView2.Columns(3).Width = 50
            DataGridView2.Columns(4).Width = 45
            DataGridView2.Columns(5).Width = 67
            DataGridView2.Columns(6).Width = 67
            DataGridView2.Columns(9).Width = 67
            DataGridView2.Columns(11).Width = 67
            DataGridView2.Columns(10).Width = 135
            DataGridView2.Columns(0).Visible = False
            DataGridView2.Columns(1).Visible = False
            DataGridView2.Columns(7).Visible = False
            DataGridView2.Columns(8).Visible = False
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        Panel2.Hide()
        Panel5.Show()

        Try
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date between @date1 AND @date2 AND Client LIKE '%" & TextBox1.Text & "%'", conbin)
            cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim cmdtable As New MySqlDataAdapter
            cmdtable.SelectCommand = cmd
            Dim cmdres As New DataTable
            cmdtable.Fill(cmdres)

            If cmdres.Rows.Count >= 1 Then
                DataGridView1.DataSource = cmdres
                Dim _gross_pro As Decimal = 0
                For Each row As DataGridViewRow In DataGridView1.Rows
                    _gross_pro += row.Cells(10).Value
                Next
                Label2.Text = "₱ " + _gross_pro.ToString

                Dim _fortotal_vost As Decimal = 0
                For Each row As DataGridViewRow In DataGridView1.Rows
                    _fortotal_vost += row.Cells(11).Value
                Next
                Label1.Text = "₱ " + (_gross_pro - _fortotal_vost).ToString

            ElseIf cmdres.Rows.Count = 0
                Label1.Text = "-"
                Label2.Text = "-"
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        printPrev.Show()
        Me.Hide()
    End Sub

    Private Sub Panel7_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel7.MouseClick
        Panel2.Show()


        Try
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM sales_data WHERE Date between @date1 AND @date2", conbin)
            cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
            Dim cmdtable As New MySqlDataAdapter
            cmdtable.SelectCommand = cmd
            Dim cmdres As New DataTable
            cmdtable.Fill(cmdres)


            DataGridView2.DataSource = cmdres
                DataGridView2.Columns(2).Width = 325
                DataGridView2.Columns(3).Width = 35
                DataGridView2.Columns(4).Width = 45
                DataGridView2.Columns(5).Width = 67
                DataGridView2.Columns(6).Width = 67
                DataGridView2.Columns(9).Width = 67
                DataGridView2.Columns(11).Width = 67
                DataGridView2.Columns(10).Width = 135
                DataGridView2.Columns(0).Visible = False
                DataGridView2.Columns(1).Width = 75
                DataGridView2.Columns(7).Visible = False
                DataGridView2.Columns(8).Visible = False


        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try





    End Sub

    Private Sub Panel8_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel8.MouseClick
        inputPass.Show()


    End Sub

    Private Sub Panel9_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel9.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            Try
                connect()
                Dim cmd As New MySqlCommand("SELECT * FROM sales_data WHERE Date between @date1 AND @date2", conbin)
                cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
                cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
                Dim cmdtable As New MySqlDataAdapter
                cmdtable.SelectCommand = cmd
                Dim cmdres As New DataTable
                cmdtable.Fill(cmdres)


                DataGridView2.DataSource = cmdres
                    DataGridView2.Columns(2).Width = 400
                    DataGridView2.Columns(3).Width = 35
                    DataGridView2.Columns(4).Width = 45
                    DataGridView2.Columns(5).Width = 67
                    DataGridView2.Columns(6).Width = 67
                    DataGridView2.Columns(9).Width = 67
                    DataGridView2.Columns(11).Width = 67
                    DataGridView2.Columns(10).Width = 135
                    DataGridView2.Columns(0).Visible = False
                    DataGridView2.Columns(1).Width = 75
                    DataGridView2.Columns(7).Visible = False
                    DataGridView2.Columns(8).Visible = False


            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            Try
                connect()
                Dim cmd As New MySqlCommand("SELECT * FROM sales_data WHERE Date between @date1 AND @date2 AND Product_Name LIKE '%" & TextBox2.Text & "%'", conbin)
                cmd.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
                cmd.Parameters.Add("@date2", MySqlDbType.Date).Value = DateTimePicker2.Value
                Dim cmdtable As New MySqlDataAdapter
                cmdtable.SelectCommand = cmd
                Dim cmdres As New DataTable
                cmdtable.Fill(cmdres)


                DataGridView2.DataSource = cmdres
                    DataGridView2.Columns(2).Width = 400
                    DataGridView2.Columns(3).Width = 35
                    DataGridView2.Columns(4).Width = 45
                    DataGridView2.Columns(5).Width = 67
                    DataGridView2.Columns(6).Width = 67
                    DataGridView2.Columns(9).Width = 67
                    DataGridView2.Columns(11).Width = 67
                    DataGridView2.Columns(10).Width = 135
                    DataGridView2.Columns(0).Visible = False
                    DataGridView2.Columns(1).Width = 75
                    DataGridView2.Columns(7).Visible = False
                    DataGridView2.Columns(8).Visible = False

            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub
End Class