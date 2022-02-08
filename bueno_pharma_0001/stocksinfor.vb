Imports MySql.Data.MySqlClient

Public Class stocksinfor
    Private WithEvents _stockdetails As New stockdetails
    Private Sub stocksinfor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlowLayoutPanel1.Controls.Clear()
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM stocks_info", conbin)
        Dim cmdres As New DataTable
        Try
            cmd.Fill(cmdres)
            Dim _ftotalcost As Decimal = 0
            For i = 0 To cmdres.Rows.Count - 1
                Dim _totalcost As Decimal
                _stockdetails = New stockdetails
                FlowLayoutPanel1.Controls.Add(_stockdetails)
                _stockdetails._prname = cmdres.Rows(i).Item(1).ToString
                _stockdetails._pbarr = cmdres.Rows(i).Item(0).ToString
                _stockdetails._pcost = cmdres.Rows(i).Item(3).ToString
                _stockdetails._pstockq = cmdres.Rows(i).Item(2).ToString
                _totalcost = cmdres.Rows(i).Item(3) * cmdres.Rows(i).Item(2)
                _stockdetails._tcost = _totalcost
                _ftotalcost += _totalcost

            Next
            Label1.Text = "₱ " + _ftotalcost.ToString + ".00"

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        If TextBox2.Text = "" Then
            FlowLayoutPanel1.Controls.Clear()
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM stocks_info", conbin)
            Dim cmdres As New DataTable
            Try
                cmd.Fill(cmdres)
                Dim _ftotalcost As Decimal = 0
                For i = 0 To cmdres.Rows.Count - 1
                    Dim _totalcost As Decimal
                    _stockdetails = New stockdetails
                    FlowLayoutPanel1.Controls.Add(_stockdetails)
                    _stockdetails._prname = cmdres.Rows(i).Item(1).ToString
                    _stockdetails._pbarr = cmdres.Rows(i).Item(0).ToString
                    _stockdetails._pcost = cmdres.Rows(i).Item(3).ToString
                    _stockdetails._pstockq = cmdres.Rows(i).Item(2).ToString
                    _totalcost = cmdres.Rows(i).Item(3) * cmdres.Rows(i).Item(2)
                    _stockdetails._tcost = _totalcost
                    _ftotalcost += _totalcost

                Next
                Label1.Text = "₱ " + _ftotalcost.ToString + ".00"

            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        Else
            FlowLayoutPanel1.Controls.Clear()
            connect()
            Dim cmd As New MySqlDataAdapter("SELECT * FROM stocks_info WHERE Medicine_Name LIKE '%" & TextBox2.Text & "%'", conbin)
            Dim cmdres As New DataTable
            Try
                cmd.Fill(cmdres)
                Dim _ftotalcost As Decimal = 0
                For i = 0 To cmdres.Rows.Count - 1
                    Dim _totalcost As Decimal
                    _stockdetails = New stockdetails
                    FlowLayoutPanel1.Controls.Add(_stockdetails)
                    _stockdetails._prname = cmdres.Rows(i).Item(1).ToString
                    _stockdetails._pbarr = cmdres.Rows(i).Item(0).ToString
                    _stockdetails._pcost = cmdres.Rows(i).Item(3).ToString
                    _stockdetails._pstockq = cmdres.Rows(i).Item(2).ToString
                    _totalcost = cmdres.Rows(i).Item(3) * cmdres.Rows(i).Item(2)
                    _stockdetails._tcost = _totalcost
                    _ftotalcost += _totalcost

                Next
                Label1.Text = "₱ " + _ftotalcost.ToString + ".00"

            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        admindashboard.Show()
        Me.Close()
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        purchaseStock.Show()
        Me.Close()
    End Sub
End Class