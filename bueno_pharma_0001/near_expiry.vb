Imports MySql.Data.MySqlClient
Public Class near_expiry

    Dim res_date As Date
    Dim notife As Date
    Dim dateNow As Date
    Private Sub near_expiry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel3.Hide()

        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(1).Width = 485
        DataGridView1.Columns(2).Width = 85
        For x = 0 To DataGridView1.RowCount - 1
            For Each row As DataGridViewRow In DataGridView1.Rows
                DataGridView1.Rows.Remove(row)
            Next
        Next
        dateNow = DateTimePicker1.Value
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM stock_trans_info", conbin)
        Dim cmdres As New DataTable
        Try
            cmd.Fill(cmdres)
            If cmdres.Rows.Count > 0 Then
                For i = 0 To cmdres.Rows.Count - 1

                    Dim barid As String = cmdres.Rows(i).Item(0).ToString
                    Dim product_name As String = cmdres.Rows(i).Item(1).ToString
                    Dim exp_date As String = cmdres.Rows(i).Item(5).ToString
                    res_date = cmdres.Rows(i).Item(5)
                    notife = DateAdd(DateInterval.Month, -6, res_date)
                    If dateNow = notife Then
                        DataGridView1.Rows.Add(barid, product_name, exp_date)
                    ElseIf dateNow > notife
                        DataGridView1.Rows.Add(barid, product_name, exp_date)
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try


        connect()
        Dim cmd1 As New MySqlDataAdapter("SELECT * FROM stock_trans_info", conbin)
        Dim cmdres1 As New DataTable
        Try
            cmd1.Fill(cmdres1)

            DataGridView2.DataSource = cmdres1
            DataGridView2.Columns(0).Width = 120
            DataGridView2.Columns(1).Width = 300
            DataGridView2.Columns(2).Width = 200
            DataGridView2.Columns(3).Width = 200
            DataGridView2.Columns(6).Width = 50
            DataGridView2.Columns(8).Width = 50

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick

        Panel3.Show()


    End Sub

    Private Sub Panel5_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel5.MouseClick
        Panel3.Hide()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "" Then
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM stock_trans_info", conbin)
            Dim cmdres1 As New DataTable
            Try
                cmd1.Fill(cmdres1)

                DataGridView2.DataSource = cmdres1
                DataGridView2.Columns(0).Width = 120
                DataGridView2.Columns(1).Width = 300
                DataGridView2.Columns(2).Width = 200
                DataGridView2.Columns(3).Width = 200
                DataGridView2.Columns(6).Width = 50
                DataGridView2.Columns(8).Width = 50

            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM stock_trans_info WHERE Product_Name LIKE '%" & TextBox3.Text & "%'", conbin)
            Dim cmdres1 As New DataTable
            Try
                cmd1.Fill(cmdres1)

                DataGridView2.DataSource = cmdres1
                DataGridView2.Columns(0).Width = 120
                DataGridView2.Columns(1).Width = 300
                DataGridView2.Columns(2).Width = 200
                DataGridView2.Columns(3).Width = 200
                DataGridView2.Columns(6).Width = 50
                DataGridView2.Columns(8).Width = 50

            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub
End Class