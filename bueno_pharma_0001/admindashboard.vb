Imports MySql.Data.MySqlClient
Public Class admindashboard
    Dim rows_val As Decimal
    Dim rows_add As Decimal

    Dim rows_val1 As Decimal
    Dim rows_add1 As Decimal

    Dim rows_val2 As Decimal
    Dim rows_add2 As Decimal
    Private Sub admindashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM account_privilage WHERE account_ID = '" & accountIdent & "'", conbin)
        Dim tableval As New DataTable
        cmd.Fill(tableval)

        Label1.Text = tableval.Rows(0).Item(2).ToString
        username = tableval.Rows(0).Item(2).ToString

        Try
            connect()
            Dim cmd1 As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date=@date1", conbin)
            cmd1.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            Dim cmdtable1 As New MySqlDataAdapter
            cmdtable1.SelectCommand = cmd1
            Dim cmdres1 As New DataTable
            cmdtable1.Fill(cmdres1)
            If cmdres1.Rows.Count = 0 Then
                Label2.Text = "-"
            Else


                For i = 0 To cmdres1.Rows.Count - 1
                    rows_val = cmdres1.Rows(i).Item(6)
                    rows_add = rows_add + rows_val
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

        Try
            connect()
            Dim cmd11 As New MySqlCommand("SELECT * FROM collect_info WHERE Date=@date1", conbin)
            cmd11.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            Dim cmdtable11 As New MySqlDataAdapter
            cmdtable11.SelectCommand = cmd11
            Dim cmdres11 As New DataTable
            cmdtable11.Fill(cmdres11)
            If cmdres11.Rows.Count = 0 Then
                Label2.Text = "-"
            Else


                For i = 0 To cmdres11.Rows.Count - 1
                    rows_val1 = cmdres11.Rows(i).Item(2)
                    rows_add1 = rows_add1 + rows_val1
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

        Try
            connect()
            Dim cmd112 As New MySqlCommand("SELECT * FROM payable_info WHERE Date=@date1", conbin)
            cmd112.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            Dim cmdtable112 As New MySqlDataAdapter
            cmdtable112.SelectCommand = cmd112
            Dim cmdres112 As New DataTable
            cmdtable112.Fill(cmdres112)
            If cmdres112.Rows.Count = 0 Then
                Label2.Text = "-"
            Else


                For i = 0 To cmdres112.Rows.Count - 1
                    rows_val2 = cmdres112.Rows(i).Item(2)
                    rows_add2 = rows_add2 + rows_val2
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try



        Label2.Text = rows_add + rows_add1 - rows_add2
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        regsupplier.Show()
        Me.Close()
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        purchaseStock.Show()
        Me.Close()

    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        salesform.Show()
        Me.Close()
    End Sub

    Private Sub Panel5_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel5.MouseClick
        registerClient.Show()
        Me.Close()
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Panel7_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel7.MouseClick
        updatePrice.Show()
        Me.Close()
    End Sub

    Private Sub Panel8_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel8.MouseClick
        salesReport.Show()
        Me.Close()
    End Sub

    Private Sub Panel9_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel9.MouseClick
        stocksinfor.Show()
        Me.Close()
    End Sub

    Private Sub Panel10_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel10.MouseClick
        updateSupplier.Show()
        Me.Close()
    End Sub



    Private Sub Panel11_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel11.MouseClick
        updateClient.Show()
        Me.Close()
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        rows_val = 0
        rows_add = 0

        rows_val1 = 0
        rows_add1 = 0

        rows_val2 = 0
        rows_add2 = 0

        Try
            connect()
            Dim cmd1 As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Date=@date1", conbin)
            cmd1.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            Dim cmdtable1 As New MySqlDataAdapter
            cmdtable1.SelectCommand = cmd1
            Dim cmdres1 As New DataTable
            cmdtable1.Fill(cmdres1)
            If cmdres1.Rows.Count = 0 Then
                Label2.Text = "-"
            Else


                For i = 0 To cmdres1.Rows.Count - 1
                    rows_val = cmdres1.Rows(i).Item(6)
                    rows_add = rows_add + rows_val
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

        Try
            connect()
            Dim cmd11 As New MySqlCommand("SELECT * FROM collect_info WHERE Date=@date1", conbin)
            cmd11.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            Dim cmdtable11 As New MySqlDataAdapter
            cmdtable11.SelectCommand = cmd11
            Dim cmdres11 As New DataTable
            cmdtable11.Fill(cmdres11)
            If cmdres11.Rows.Count = 0 Then
                Label2.Text = "-"
            Else


                For i = 0 To cmdres11.Rows.Count - 1
                    rows_val1 = cmdres11.Rows(i).Item(2)
                    rows_add1 = rows_add1 + rows_val1
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

        Try
            connect()
            Dim cmd112 As New MySqlCommand("SELECT * FROM payable_info WHERE Date=@date1", conbin)
            cmd112.Parameters.Add("@date1", MySqlDbType.Date).Value = DateTimePicker1.Value
            Dim cmdtable112 As New MySqlDataAdapter
            cmdtable112.SelectCommand = cmd112
            Dim cmdres112 As New DataTable
            cmdtable112.Fill(cmdres112)
            If cmdres112.Rows.Count = 0 Then
                Label2.Text = "-"
            Else


                For i = 0 To cmdres112.Rows.Count - 1
                    rows_val2 = cmdres112.Rows(i).Item(2)
                    rows_add2 = rows_add2 + rows_val2
                Next

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try




        Label2.Text = rows_add + rows_add1 - rows_add2
    End Sub

    Private Sub Label2_MouseClick(sender As Object, e As MouseEventArgs) Handles Label2.MouseClick
        salesReport.Show()
        Me.Close()
    End Sub

    Private Sub Panel12_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel12.MouseClick
        collectibles.Show()
        Me.Close()
    End Sub

    Private Sub Panel13_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel13.MouseClick
        payables.Show()
        Me.Close()
    End Sub

    Private Sub Panel14_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel14.MouseClick
        near_expiry.Show()
        Me.Close()
    End Sub

    Private Sub Panel15_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel15.MouseClick
        payables.Show()
        Me.Close()
    End Sub
End Class