Imports MySql.Data.MySqlClient
Public Class salesform
    Dim indexa As Integer = 0
    Private Sub salesform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel3.Hide()
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM client_info", conbin)
        Dim cmdres As New DataTable
        cmd.Fill(cmdres)

        DataGridView1.DataSource = cmdres
        DataGridView1.Columns(0).Width = 20
        DataGridView1.Columns(1).Width = 350
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.ColumnHeadersVisible = False
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        registerClient.Show()
        Me.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Panel3.Show()
        indexa = 1
        If TextBox1.Text = "" Then
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM client_info", conbin)
            Dim cmdres As New DataTable
            cmd.Fill(cmdres)

            DataGridView1.DataSource = cmdres
            DataGridView1.Columns(0).Width = 20
            DataGridView1.Columns(1).Width = 350
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.ColumnHeadersVisible = False

        Else
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM client_info WHERE Name LIKE '%" & TextBox1.Text & "%'", conbin)
            Dim cmdresult As New DataTable
            cmd1.Fill(cmdresult)
            DataGridView1.DataSource = cmdresult
            DataGridView1.Columns(0).Width = 20
            DataGridView1.Columns(1).Width = 350
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.ColumnHeadersVisible = False

        End If
    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        If indexa = 0 Then
            Panel3.Show()
            indexa = 1
        Else
            Panel3.Hide()
            indexa = 0
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        TextBox1.Text = selectedRow.Cells(1).Value.ToString
        Panel3.Hide()
        indexa = 0
    End Sub

    Private Sub Panel5_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel5.MouseClick
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MessageBox.Show("Error:Empty Field!")
        Else
            form_reference = 0
            salesformnext.Show()
            salesformnext.Label1.Text = TextBox1.Text
            salesformnext.Label2.Text = TextBox2.Text

            Me.Close()

        End If

    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub

    Private Sub Panel11_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel11.MouseClick
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
        restockform.Show()
        Me.Close()
    End Sub

    Private Sub Panel12_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel12.MouseClick
        regsupplier.Show()
        Me.Close()
    End Sub

    Private Sub Panel13_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel13.MouseClick
        updateSupplier.Show()
        Me.Close()
    End Sub
End Class