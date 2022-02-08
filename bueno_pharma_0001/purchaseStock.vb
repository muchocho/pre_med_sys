Imports MySql.Data.MySqlClient
Public Class purchaseStock
    Dim indexa As Integer = 0
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Panel2.Show()
        indexa = 1

        If TextBox1.Text = "" Then
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM supplierinfo", conbin)
            Dim cmdtable As New DataTable
            cmd.Fill(cmdtable)
            DataGridView1.DataSource = cmdtable
            DataGridView1.Columns(0).Width = 40
            DataGridView1.Columns(1).Width = 330
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.ColumnHeadersVisible = False
        Else
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM supplierinfo WHERE Supplier_Name LIKE '%" & TextBox1.Text & "%'", conbin)
            Dim table As New DataTable
            cmd1.Fill(table)
            DataGridView1.DataSource = table
            DataGridView1.Columns(0).Width = 40
            DataGridView1.Columns(1).Width = 330
            DataGridView1.Columns(2).Visible = False
            DataGridView1.Columns(3).Visible = False
            DataGridView1.Columns(4).Visible = False
            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False
            DataGridView1.ColumnHeadersVisible = False
        End If
    End Sub

    Private Sub purchaseStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel2.Hide()
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM supplierinfo", conbin)
        Dim cmdtable As New DataTable
        cmd.Fill(cmdtable)
        DataGridView1.DataSource = cmdtable
        DataGridView1.Columns(0).Width = 40
        DataGridView1.Columns(1).Width = 330
        DataGridView1.Columns(2).Visible = False
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(6).Visible = False
        DataGridView1.ColumnHeadersVisible = False
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        TextBox1.Text = selectedRow.Cells(1).Value.ToString
        Panel2.Hide()

        indexa = 0

    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        If indexa = 0 Then
            Panel2.Show()
            indexa = 1
        Else
            Panel2.Hide()
            indexa = 0
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As Object, e As EventArgs) Handles TextBox1.Leave
        Panel2.Hide()
        indexa = 0
    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        regsupplier.Show()
        Me.Close()
    End Sub

    Private Sub Panel5_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel5.MouseClick
        If TextBox1.Text = "" Then
            MessageBox.Show("Error:Empty Field!")
        Else
            restockform.Label3.Text = TextBox1.Text
            restockform.Show()
            Me.Close()
        End If

    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        regsupplier.Show()
        Me.Hide()
    End Sub

    Private Sub Panel7_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel7.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub

    Private Sub Panel8_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel8.MouseClick
        salesform.Show()
        Me.Close()
    End Sub

    Private Sub Panel9_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel9.MouseClick
        registerClient.Show()
        Me.Close()
    End Sub

    Private Sub Panel10_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel10.MouseClick
        updateClient.Show()
        Me.Close()
    End Sub

    Private Sub Panel11_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel11.MouseClick
        stocksinfor.Show()
        Me.Close()
    End Sub

    Private Sub Panel12_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel12.MouseClick
        payables.Show()
        Me.Close()
    End Sub

    Private Sub Panel13_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel13.MouseClick
        updateSupplier.Show()
        Me.Close()
    End Sub
End Class