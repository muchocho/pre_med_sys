Imports MySql.Data.MySqlClient

Public Class salesformnext
    Public random As New Random
    Dim indexaaa As Integer = 0
    Dim barcodeID As String
    Dim pname As String
    Dim tquantity As Integer
    Dim inquant As Integer
    Dim price As String





    Private Sub salesformnext_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        staff = username
        Panel8.Hide()
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM stocks_info", conbin)
        Dim cmdres As New DataTable
        cmd.Fill(cmdres)

        DataGridView2.DataSource = cmdres
        DataGridView2.ColumnHeadersVisible = False
        DataGridView2.Columns(1).Width = 335
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(2).Visible = False
        DataGridView2.Columns(3).Visible = False
        DataGridView2.Columns(4).Visible = False


        If form_reference = 0 Then
            Panel6.Hide()

            Dim transID As Integer = random.Next(0, 1000000000)

            Try
                Dim dt As DataTable = valtransid(transID)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("ID already exist, please refresh the form!")
                    Me.Close()
                    salesform.Show()
                Else
                    finalID = transID
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try


        ElseIf form_reference = 1
            Panel6.Show()
            finalID = selected
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM sales_data WHERE Transaction_ID = '" & selected & "'", conbin)
            Dim cmdres1 As New DataTable
            Try
                cmd1.Fill(cmdres1)
                Label2.Text = cmdres1.Rows(0).Item(1)
                DataGridView1.DataSource = cmdres1

                DataGridView1.ColumnHeadersVisible = False
                DataGridView1.Columns(2).Width = 400
                DataGridView1.Columns(3).Width = 62
                DataGridView1.Columns(4).Width = 65
                DataGridView1.Columns(5).Width = 70
                DataGridView1.Columns(6).Width = 70
                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(1).Visible = False
                DataGridView1.Columns(7).Visible = False
                DataGridView1.Columns(8).Visible = False
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False

                DataGridView1.Columns(11).Visible = False

                Dim sum As Decimal = 0
                For Each row As DataGridViewRow In DataGridView1.Rows
                    sum += row.Cells(6).Value
                Next
                Label5.Text = "₱ " + sum.ToString
                sumtotal = sum

                Dim csum As Decimal = 0
                For Each row As DataGridViewRow In DataGridView1.Rows
                    csum += row.Cells(11).Value
                Next
                total_cost = csum


                connect()
                Dim cmd2 As New MySqlDataAdapter("SELECT * FROM trans_sales_data WHERE Transaction_No='" & selected & "'", conbin)
                Dim cmdres2 As New DataTable
                Try
                    cmd2.Fill(cmdres2)
                    Label1.Text = cmdres2.Rows(0).Item(2)
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
        Label4.Text = Date.Now.ToString("hh:mm")
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TextBox1.Text = "" Then
            Else
                Try
                    connect()
                    Dim cmd As New MySqlDataAdapter("SELECT * FROM stocks_info WHERE Bar_ID ='" & TextBox1.Text & "'", conbin)
                    Dim result As New DataTable
                    cmd.Fill(result)

                    If result.Rows.Count = 0 Then
                        MessageBox.Show("Bar ID not registered!")
                    Else
                        TextBox1.Text = result.Rows(0).Item(0).ToString
                        barcodeID = result.Rows(0).Item(0).ToString
                        TextBox3.Text = result.Rows(0).Item(1).ToString
                        pname = result.Rows(0).Item(1).ToString
                        TextBox5.Text = result.Rows(0).Item(4).ToString
                        price = result.Rows(0).Item(4).ToString
                        tquantity = result.Rows(0).Item(2)
                        rsp = result.Rows(0).Item(3).ToString
                        TextBox2.Focus()
                    End If


                Catch ex As Exception
                    MsgBox(ex.Message, vbInformation)
                End Try

            End If
        Else
            Exit Sub

        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub TextBox4_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox4.KeyDown

        If e.KeyCode = Keys.Enter Then
            connect()
            Dim cmdcheck As New MySqlDataAdapter("SELECT * FROM sales_data WHERE Transaction_ID = '" & finalID & "' AND Bar_ID='" & TextBox1.Text & "'", conbin)
            Dim cmdcheckres As New DataTable
            Try
                cmdcheck.Fill(cmdcheckres)
                If cmdcheckres.Rows.Count > 0 Then
                    MessageBox.Show("Error: Duplicate entry, Please merge the product quantity.")
                Else

                    If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Then
                        MessageBox.Show("Error: Empty Field!")
                    Else
                        inquant = TextBox4.Text

                        If tquantity < TextBox4.Text Then
                            MessageBox.Show("ERROR: Total stock: " + tquantity.ToString)

                        ElseIf tquantity = TextBox4.Text
                            Try
                                total = TextBox5.Text * TextBox4.Text
                                _tcost = TextBox4.Text * rsp
                                addpurchaseproduct(finalID, Label2.Text, TextBox3.Text, TextBox2.Text, TextBox4.Text, TextBox5.Text, total, Label3.Text, Label4.Text, rsp, TextBox1.Text, _tcost)
                                TextBox1.Clear()
                                TextBox2.Clear()
                                TextBox3.Clear()
                                TextBox4.Clear()
                                TextBox5.Clear()
                                TextBox1.Focus()
                                Try
                                    connect()
                                    Dim cmd As New MySqlDataAdapter("SELECT * FROM sales_data WHERE Transaction_ID='" & finalID & "'", conbin)
                                    Dim result1 As New DataTable
                                    cmd.Fill(result1)


                                    DataGridView1.DataSource = result1
                                    DataGridView1.ColumnHeadersVisible = False
                                    DataGridView1.Columns(2).Width = 400
                                    DataGridView1.Columns(3).Width = 62
                                    DataGridView1.Columns(4).Width = 65
                                    DataGridView1.Columns(5).Width = 70
                                    DataGridView1.Columns(6).Width = 70
                                    DataGridView1.Columns(0).Visible = False
                                    DataGridView1.Columns(1).Visible = False
                                    DataGridView1.Columns(7).Visible = False
                                    DataGridView1.Columns(8).Visible = False
                                    DataGridView1.Columns(9).Visible = False
                                    DataGridView1.Columns(10).Visible = False

                                    DataGridView1.Columns(11).Visible = False

                                    Dim sum As Decimal = 0
                                    For Each row As DataGridViewRow In DataGridView1.Rows
                                        sum += row.Cells(6).Value
                                    Next
                                    Label5.Text = "₱ " + sum.ToString
                                    sumtotal = sum

                                    Dim csum As Decimal = 0
                                    For Each row As DataGridViewRow In DataGridView1.Rows
                                        csum += row.Cells(11).Value
                                    Next
                                    total_cost = csum
                                    Try

                                        deleteproduct(barcodeID)
                                    Catch ex As Exception
                                        MsgBox(ex.Message, vbInformation)
                                    End Try
                                Catch ex As Exception
                                    MsgBox(ex.Message, vbInformation)
                                End Try



                            Catch ex As Exception
                                MsgBox(ex.Message, vbInformation)
                            End Try

                        ElseIf tquantity > TextBox4.Text


                            Try
                                total = TextBox5.Text * TextBox4.Text
                                _tcost = TextBox4.Text * rsp
                                addpurchaseproduct(finalID, Label2.Text, TextBox3.Text, TextBox2.Text, TextBox4.Text, TextBox5.Text, total, Label3.Text, Label4.Text, rsp, TextBox1.Text, _tcost)
                                TextBox1.Clear()
                                TextBox2.Clear()
                                TextBox3.Clear()
                                TextBox4.Clear()
                                TextBox5.Clear()
                                TextBox1.Focus()
                                Try
                                    connect()
                                    Dim cmd As New MySqlDataAdapter("SELECT * FROM sales_data WHERE Transaction_ID='" & finalID & "'", conbin)
                                    Dim result1 As New DataTable
                                    cmd.Fill(result1)


                                    DataGridView1.DataSource = result1
                                    DataGridView1.ColumnHeadersVisible = False
                                    DataGridView1.Columns(2).Width = 400
                                    DataGridView1.Columns(3).Width = 62
                                    DataGridView1.Columns(4).Width = 65
                                    DataGridView1.Columns(5).Width = 70
                                    DataGridView1.Columns(6).Width = 70
                                    DataGridView1.Columns(0).Visible = False
                                    DataGridView1.Columns(1).Visible = False
                                    DataGridView1.Columns(7).Visible = False
                                    DataGridView1.Columns(8).Visible = False
                                    DataGridView1.Columns(9).Visible = False
                                    DataGridView1.Columns(10).Visible = False
                                    DataGridView1.Columns(11).Visible = False
                                    Dim sum As Decimal = 0
                                    For Each row As DataGridViewRow In DataGridView1.Rows
                                        sum += row.Cells(6).Value
                                    Next
                                    Label5.Text = "₱ " + sum.ToString
                                    sumtotal = sum
                                    Dim csum As Decimal = 0
                                    For Each row As DataGridViewRow In DataGridView1.Rows
                                        csum += row.Cells(11).Value
                                    Next
                                    total_cost = csum
                                    tquantity = tquantity - inquant
                                    Try
                                        connect()
                                        Dim cmd2 As New MySqlCommand("UPDATE stocks_info SET Quantity = '" & tquantity & "' WHERE Bar_ID = '" & barcodeID & "'", conbin)
                                        cmd2.ExecuteNonQuery()

                                    Catch ex As Exception
                                        MsgBox(ex.Message, vbInformation)
                                    End Try

                                Catch ex As Exception
                                    MsgBox(ex.Message, vbInformation)
                                End Try





                            Catch ex As Exception
                                MsgBox(ex.Message, vbInformation)
                            End Try

                        End If







                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try




        Else
            Exit Sub

        End If
        e.SuppressKeyPress = True
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick

        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM sales_data WHERE Transaction_ID = '" & finalID & "'", conbin)
        Dim cmdres As New DataTable
        Try
            cmd.Fill(cmdres)
            If cmdres.Rows.Count = 0 Then
                salesform.Show()
                Me.Close()
            Else
                MessageBox.Show("Please delete all the entered product!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try



    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        If TextBox1.Text = "" Or TextBox3.Text = "" Or TextBox5.Text = "" Then
            If Label5.Text = "" Then
                MessageBox.Show("No list of items to checkout!")
            Else
                paymentoption.Show()
                Me.Hide()
            End If
        Else
            MessageBox.Show("You have on process transaction!")
        End If

    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox1.Focus()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        If TextBox1.Text = "" Then
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM stocks_info", conbin)
            Dim cmdres As New DataTable
            cmd.Fill(cmdres)

            DataGridView2.DataSource = cmdres
            DataGridView2.ColumnHeadersVisible = False
            DataGridView2.Columns(1).Width = 335
            DataGridView2.Columns(0).Visible = False
            DataGridView2.Columns(2).Visible = False
            DataGridView2.Columns(3).Visible = False
            DataGridView2.Columns(4).Visible = False
        Else
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM stocks_info WHERE Medicine_Name LIKE '%" & TextBox3.Text & "%'", conbin)
            Dim cmdres1 As New DataTable
            cmd1.Fill(cmdres1)

            DataGridView2.DataSource = cmdres1
            DataGridView2.ColumnHeadersVisible = False
            DataGridView2.Columns(1).Width = 335
            DataGridView2.Columns(0).Visible = False
            DataGridView2.Columns(2).Visible = False
            DataGridView2.Columns(3).Visible = False
            DataGridView2.Columns(4).Visible = False
        End If
    End Sub

    Private Sub Panel5_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel5.MouseClick
        If indexaaa = 0 Then
            Panel8.Show()
            indexaaa = 1
        ElseIf indexaaa = 1
            Panel8.Hide()
            indexaaa = 0
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView2.Rows(index)
        Dim selected As String = selectedRow.Cells(1).Value.ToString
        Try
            connect()
            Dim cmd1 As New MySqlDataAdapter("SELECT * FROM stocks_info WHERE Medicine_Name='" & selected & "'", conbin)
            Dim cmdres1 As New DataTable
            cmd1.Fill(cmdres1)

            TextBox1.Text = cmdres1.Rows(0).Item(0).ToString
            barcodeID = cmdres1.Rows(0).Item(0).ToString
            TextBox3.Text = cmdres1.Rows(0).Item(1).ToString
            TextBox5.Text = cmdres1.Rows(0).Item(4).ToString
            tquantity = cmdres1.Rows(0).Item(2)
            rsp = cmdres1.Rows(0).Item(3).ToString
            Panel8.Hide()
            indexaaa = 0
            TextBox2.Focus()
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try



    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim tquant As Integer
        Dim quant As Integer
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = DataGridView1.Rows(index)
        quant = selectedRow.Cells(4).Value


        Dim dialog As DialogResult
        dialog = MsgBox("Are you sure you want to delete the selected row?", MessageBoxButtons.OKCancel)
        If dialog = DialogResult.OK Then
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM stocks_info WHERE Bar_ID = '" & selectedRow.Cells(10).Value.ToString & "'", conbin)
            Dim cmdres As New DataTable
            Try
                cmd.Fill(cmdres)
                tquant = cmdres.Rows(0).Item(2)

                tquant = tquant + quant

                Try
                    connect()
                    Dim cmd1 As New MySqlCommand("UPDATE stocks_info SET Quantity='" & tquant & "' WHERE Bar_ID='" & selectedRow.Cells(10).Value.ToString & "'", conbin)
                    cmd1.ExecuteNonQuery()
                    Dim reader As MySqlDataReader
                    Try
                        connect()
                        Dim cmd2 As New MySqlCommand("DELETE FROM sales_data WHERE Transaction_ID='" & finalID & "' AND Bar_ID='" & selectedRow.Cells(10).Value.ToString & "'", conbin)
                        reader = cmd2.ExecuteReader

                        Try
                            connect()
                            Dim cmd3 As New MySqlDataAdapter("SELECT * FROM sales_data WHERE Transaction_ID='" & finalID & "'", conbin)
                            Dim result3 As New DataTable
                            cmd3.Fill(result3)


                            DataGridView1.DataSource = result3
                            DataGridView1.ColumnHeadersVisible = False
                            DataGridView1.Columns(2).Width = 400
                            DataGridView1.Columns(3).Width = 62
                            DataGridView1.Columns(4).Width = 65
                            DataGridView1.Columns(5).Width = 70
                            DataGridView1.Columns(6).Width = 70
                            DataGridView1.Columns(0).Visible = False
                            DataGridView1.Columns(1).Visible = False
                            DataGridView1.Columns(7).Visible = False
                            DataGridView1.Columns(8).Visible = False
                            DataGridView1.Columns(9).Visible = False
                            DataGridView1.Columns(10).Visible = False
                            DataGridView1.Columns(11).Visible = False
                            Dim sum As Decimal = 0
                            For Each row As DataGridViewRow In DataGridView1.Rows
                                sum += row.Cells(6).Value
                            Next
                            Label5.Text = "₱ " + sum.ToString
                            sumtotal = sum
                        Catch ex As Exception
                            MsgBox(ex.Message, vbInformation)
                        End Try
                    Catch ex As Exception
                        MsgBox(ex.Message, vbInformation)
                    End Try
                Catch ex As Exception
                    MsgBox(ex.Message, vbInformation)
                End Try


            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try

        End If





    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub
End Class