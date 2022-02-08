Imports MySql.Data.MySqlClient
Public Class restockform
    Dim indexa As Integer = 0
    Dim indexa1 As Integer = 0
    Private WithEvents _liststock As New UserControl1

    Private Sub restockform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Panel7.Hide()
        Panel8.Hide()

        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM meds_list", conbin)
        Dim restable As New DataTable
        cmd.Fill(restable)
        DataGridView1.DataSource = restable
        DataGridView1.ColumnHeadersVisible = False
        DataGridView1.Columns(0).Width = 350

        connect()
        Dim cmd1 As New MySqlDataAdapter("SELECT * FROM meds_gen", conbin)
        Dim restable1 As New DataTable
        cmd1.Fill(restable1)
        DataGridView2.DataSource = restable1
        DataGridView2.ColumnHeadersVisible = False
        DataGridView2.Columns(0).Width = 350
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = Date.Now.ToString("MM/dd/yyyy")
        Label2.Text = Date.Now.ToString("hh:mm")
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Then
            MessageBox.Show("Please fillout the information needed!")
        Else
            Try
                stockinfo(TextBox1.Text, TextBox2.Text + "(" + TextBox4.Text + ")", TextBox3.Text, TextBox8.Text, TextBox9.Text)
                stockTransInfo(TextBox1.Text, TextBox2.Text + "(" + TextBox4.Text + ")", Label3.Text, username, TextBox5.Text, DateTimePicker1.Value, TextBox7.Text, Label1.Text, Label2.Text, TextBox3.Text, TextBox8.Text)
                _liststock = New UserControl1
                FlowLayoutPanel1.Controls.Add(_liststock)
                _liststock._medsname = TextBox2.Text + "(" + TextBox4.Text + ")"
                _liststock._qnty = TextBox3.Text

                TextBox1.Clear()
                TextBox2.Clear()
                TextBox3.Clear()
                TextBox4.Clear()
                TextBox5.Clear()
                TextBox7.Clear()
                TextBox8.Clear()
                TextBox9.Clear()
                Panel7.Hide()
                Panel8.Hide()
                TextBox1.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try


        End If
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        If TextBox2.Text = "" Then
            MessageBox.Show("Error:Empty Field!")
        Else
            Try
                addmedsbrand(TextBox2.Text)
                MessageBox.Show(TextBox2.Text + " successfully added to the list")
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If

    End Sub

    Private Sub Panel5_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel5.MouseClick
        If TextBox4.Text = "" Then
            MessageBox.Show("Error:Empty Field!")
        Else
            Try
                addmedsgen(TextBox4.Text)
                MessageBox.Show(TextBox4.Text + " successfully added to the list")
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try

        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Panel7.Show()
        indexa = 1
        If TextBox2.Text = "" Then
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM meds_list", conbin)
            Dim restable As New DataTable
            cmd.Fill(restable)
            DataGridView1.DataSource = restable
            DataGridView1.ColumnHeadersVisible = False
            DataGridView1.Columns(0).Width = 350
        Else
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM meds_list WHERE meds_name LIKE '%" & TextBox2.Text & "%'", conbin)
            Dim tableval As New DataTable
            cmd1.Fill(tableval)
            DataGridView1.DataSource = tableval
            DataGridView1.ColumnHeadersVisible = False
            DataGridView1.Columns(0).Width = 350
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        TextBox2.Text = selectedRow.Cells(0).Value.ToString
        Panel7.Hide()
        indexa = 0
        TextBox3.Focus()
    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        If indexa = 0 Then
            Panel7.Show()
            indexa = 1
        Else
            Panel7.Hide()
            indexa = 0
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        Panel8.Show()
        indexa1 = 1
        If TextBox4.Text = "" Then
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM meds_gen", conbin)
            Dim restable As New DataTable
            cmd.Fill(restable)
            DataGridView2.DataSource = restable
            DataGridView2.ColumnHeadersVisible = False
            DataGridView2.Columns(0).Width = 350
        Else
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM meds_gen WHERE meds_name LIKE '%" & TextBox4.Text & "%'", conbin)
            Dim tableval As New DataTable
            cmd1.Fill(tableval)
            DataGridView2.DataSource = tableval
            DataGridView2.ColumnHeadersVisible = False
            DataGridView2.Columns(0).Width = 350
        End If
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        If indexa1 = 0 Then
            Panel8.Show()
            indexa1 = 1
        Else
            Panel8.Hide()
            indexa1 = 0
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView2.Rows(index)
        TextBox4.Text = selectedRow.Cells(0).Value.ToString
        Panel8.Hide()
        indexa1 = 0
        TextBox5.Focus()

    End Sub

    Private Sub Panel9_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel9.MouseClick
        regsupplier.Show()
        Me.Hide()
    End Sub

    Private Sub Panel10_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel10.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub

    Private Sub Panel11_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel11.MouseClick
        salesform.Show()
        Me.Close()
    End Sub

    Private Sub Panel12_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel12.MouseClick
        registerClient.Show()
        Me.Close()
    End Sub

    Private Sub Panel13_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel13.MouseClick
        updateClient.Show()
        Me.Close()
    End Sub

    Private Sub Panel14_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel14.MouseClick
        stocksinfor.Show()
        Me.Close()
    End Sub

    Private Sub Panel15_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel15.MouseClick
        payables.Show()
        Me.Close()
    End Sub

    Private Sub Panel16_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel16.MouseClick
        updateSupplier.Show()
        Me.Close()
    End Sub


End Class