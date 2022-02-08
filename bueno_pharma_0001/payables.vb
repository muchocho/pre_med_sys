Imports MySql.Data.MySqlClient

Public Class payables
    Dim indexta As Integer = 0
    Dim indesta As Integer = 0
    Private Sub payables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel4.Hide()
        Panel5.Hide()
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM client_info", conbin)
        Dim cmdres As New DataTable
        Try
            cmd.Fill(cmdres)
            DataGridView1.DataSource = cmdres
            DataGridView1.Columns(1).Width = 690
            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        If indexta = 0 Then
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM supplierinfo", conbin)
            Dim cmdres As New DataTable
            Try
                cmd.Fill(cmdres)
                DataGridView1.DataSource = cmdres
                DataGridView1.Columns(1).Width = 690
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).Visible = False
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(6).Visible = False
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
            indexta = 1
        Else
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM client_info", conbin)
            Dim cmdres As New DataTable
            Try
                cmd.Fill(cmdres)
                DataGridView1.DataSource = cmdres
                DataGridView1.Columns(1).Width = 690
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(2).Visible = False
                DataGridView1.Columns(3).Visible = False
                DataGridView1.Columns(4).Visible = False
                DataGridView1.Columns(5).Visible = False
                DataGridView1.Columns(6).Visible = False

            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
            indexta = 0
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        Label1.Text = selectedRow.Cells(1).Value.ToString
        TextBox1.Focus()
    End Sub

    Private Sub FlowLayoutPanel1_MouseClick(sender As Object, e As MouseEventArgs) Handles FlowLayoutPanel1.MouseClick
        Try
            addpayINFO(Label1.Text, TextBox1.Text, Label3.Text, username)
            MessageBox.Show("Transaction Successful.")
            Label1.Text = "-"
            TextBox1.Clear()
            TextBox1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Date.Now.ToString("MM/dd/yyyy")
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If indexta = 0 Then
            If TextBox2.Text = "" Then
                connect()
                Dim cmd As New MySqlDataAdapter("SELECT * FROM client_info", conbin)

                Dim cmdres As New DataTable
                Try
                    cmd.Fill(cmdres)
                    DataGridView1.DataSource = cmdres
                    DataGridView1.Columns(1).Width = 690
                    DataGridView1.Columns(0).Visible = False
                    DataGridView1.Columns(2).Visible = False
                    DataGridView1.Columns(3).Visible = False
                    DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(5).Visible = False
                    DataGridView1.Columns(6).Visible = False
                Catch ex As Exception
                    MsgBox(ex.Message, vbInformation)
                End Try
            Else
                connect()
                Dim cmd As New MySqlDataAdapter("SELECT * FROM client_info WHERE Name LIKE '%" & TextBox2.Text & "%'", conbin)
                Dim cmdres As New DataTable
                Try
                    cmd.Fill(cmdres)
                    DataGridView1.DataSource = cmdres
                    DataGridView1.Columns(1).Width = 690
                    DataGridView1.Columns(0).Visible = False
                    DataGridView1.Columns(2).Visible = False
                    DataGridView1.Columns(3).Visible = False
                    DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(5).Visible = False
                    DataGridView1.Columns(6).Visible = False
                Catch ex As Exception
                    MsgBox(ex.Message, vbInformation)
                End Try


            End If
        Else
            If TextBox2.Text = "" Then
                connect()
                Dim cmd As New MySqlDataAdapter("SELECT * FROM supplierinfo", conbin)
                Dim cmdres As New DataTable
                Try
                    cmd.Fill(cmdres)
                    DataGridView1.DataSource = cmdres
                    DataGridView1.Columns(1).Width = 690
                    DataGridView1.Columns(0).Visible = False
                    DataGridView1.Columns(2).Visible = False
                    DataGridView1.Columns(3).Visible = False
                    DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(5).Visible = False
                    DataGridView1.Columns(6).Visible = False

                Catch ex As Exception
                    MsgBox(ex.Message, vbInformation)
                End Try
            Else
                connect()

                Dim cmd As New MySqlDataAdapter("SELECT * FROM supplierinfo WHERE Supplier_Name LIKE '%" & TextBox2.Text & "%'", conbin)
                Dim cmdres As New DataTable
                Try
                    cmd.Fill(cmdres)
                    DataGridView1.DataSource = cmdres
                    DataGridView1.Columns(1).Width = 690
                    DataGridView1.Columns(0).Visible = False
                    DataGridView1.Columns(2).Visible = False
                    DataGridView1.Columns(3).Visible = False
                    DataGridView1.Columns(4).Visible = False
                    DataGridView1.Columns(5).Visible = False
                    DataGridView1.Columns(6).Visible = False

                Catch ex As Exception
                    MsgBox(ex.Message, vbInformation)
                End Try
            End If
        End If
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        If indesta = 0 Then
            Panel4.Show()
            Panel5.Show()

            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM payable_info WHERE Date between @date1 AND @date2", conbin)
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
                DataGridView2.Columns(4).Width = 400
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try


            indesta = 1
        Else
            Panel4.Hide()
            Panel5.Hide()
            indesta = 0
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        indesta = 1
        Panel4.Show()
        Panel5.Show()

        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM payable_info WHERE Date between @date1 AND @date2", conbin)
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
            DataGridView2.Columns(4).Width = 400
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox3.Text = "" Then
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM payable_info WHERE Date between @date1 AND @date2", conbin)
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
                DataGridView2.Columns(4).Width = 400
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            connect()
            Dim cmd As New MySqlCommand("SELECT * FROM payable_info WHERE Date between @date1 AND @date2 AND Client_Supplier LIKE '%" & TextBox3.Text & "%'", conbin)
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
                DataGridView2.Columns(4).Width = 400
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        indesta = 1
        Panel4.Show()
        Panel5.Show()

        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM payable_info WHERE Date between @date1 AND @date2", conbin)
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
            DataGridView2.Columns(4).Width = 400
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub
End Class