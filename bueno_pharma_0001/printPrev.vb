Imports MySql.Data.MySqlClient

Public Class printPrev
    Dim total_row As Integer
    Dim indexa As Integer = 0

    Private Sub printPrev_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel5.Hide()
        Label2.Text = "Page 1"
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM sales_data WHERE Transaction_ID='" & selected & "'", conbin)
        Dim cmdres As New DataTable

        Try
            cmd.Fill(cmdres)
            total_row = cmdres.Rows.Count
            If cmdres.Rows.Count >= 1 Then
                DataGridView1.DataSource = cmdres

                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(1).Visible = False
                DataGridView1.Columns(2).Width = 480
                DataGridView1.Columns(3).Width = 35
                DataGridView1.Columns(4).Width = 45
                DataGridView1.Columns(5).Width = 67
                DataGridView1.Columns(6).Width = 67
                DataGridView1.Columns(7).Visible = False
                DataGridView1.Columns(8).Visible = False
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False
                DataGridView1.Columns(11).Visible = False


            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

        Try
            For i = 0 To total_row - 1
                If i <= 15 Then
                    DataGridView1.Rows(i).Visible = True
                Else
                    DataGridView1.Rows(i).Visible = False
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

        If total_row <= 15 Then
            Panel6.Hide()
        End If
    End Sub





    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        PrintDocument1.PrinterSettings.PrinterName = My.Settings.printer
        ''PrintPreviewDialog1.ShowDialog()
        PrintDocument1.Print()
    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If
        My.Settings.printer = PrintDialog1.PrinterSettings.PrinterName

        MessageBox.Show(PrintDialog1.PrinterSettings.PrinterName.ToString)

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim dm As New Bitmap(Me.Panel2.Width, Me.Panel2.Height)
        Panel2.DrawToBitmap(dm, New Rectangle(0, 0, Me.Panel2.Width, Me.Panel2.Height))
        e.Graphics.DrawImage(dm, 0, 0)
        Dim aps As New PageSetupDialog

        aps.Document = PrintDocument1
    End Sub

    Private Sub Panel6_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel6.MouseClick
        Panel5.Show()
        indexa = indexa + 1
        Label2.Text = "Page " + (indexa + 1).ToString
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM sales_data WHERE Transaction_ID='" & selected & "'", conbin)
        Dim cmdres As New DataTable

        Try
            cmd.Fill(cmdres)
            total_row = cmdres.Rows.Count
            If cmdres.Rows.Count >= 1 Then
                DataGridView1.DataSource = cmdres


                DataGridView1.Columns(1).Visible = False
                DataGridView1.Columns(7).Visible = False
                DataGridView1.Columns(8).Visible = False
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False
                DataGridView1.Columns(11).Visible = False
                DataGridView1.Columns(0).Visible = False

            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try



        If indexa = 1 Then

            Me.DataGridView1.CurrentCell = Me.DataGridView1(2, 15)
            Try
                For i = 0 To total_row - 1
                    If (i > 14) AndAlso (i < 30) Then
                        DataGridView1.Rows(i).Visible = True

                    Else
                        DataGridView1.Rows(i).Visible = False
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try

            If total_row <= 30 Then
                Panel6.Hide()
            End If
        ElseIf indexa = 2
            Me.DataGridView1.CurrentCell = Me.DataGridView1(2, 30)
            Try
                For i = 0 To total_row - 1
                    If (i > 29) AndAlso (i < 45) Then
                        DataGridView1.Rows(i).Visible = True

                    Else
                        DataGridView1.Rows(i).Visible = False
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try

            If total_row <= 45 Then
                Panel6.Hide()
            End If
        End If

    End Sub

    Private Sub Panel5_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel5.MouseClick
        indexa = indexa - 1
        Label2.Text = "Page " + (indexa + 1).ToString
        connect()
        Dim cmd As New MySqlDataAdapter("SELECT * FROM sales_data WHERE Transaction_ID='" & selected & "'", conbin)
        Dim cmdres As New DataTable

        Try
            cmd.Fill(cmdres)
            total_row = cmdres.Rows.Count
            If cmdres.Rows.Count >= 1 Then
                DataGridView1.DataSource = cmdres

                DataGridView1.Columns(0).Visible = False
                DataGridView1.Columns(1).Visible = False

                DataGridView1.Columns(7).Visible = False
                DataGridView1.Columns(8).Visible = False
                DataGridView1.Columns(9).Visible = False
                DataGridView1.Columns(10).Visible = False
                DataGridView1.Columns(11).Visible = False


            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try


        If indexa = 0 Then
            Me.DataGridView1.CurrentCell = Me.DataGridView1(2, 0)
            Panel5.Hide()
            Panel6.Show()
            Try
                For i = 0 To total_row - 1
                    If i < 15 Then
                        DataGridView1.Rows(i).Visible = True
                    Else
                        DataGridView1.Rows(i).Visible = False
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        ElseIf indexa = 1
            Me.DataGridView1.CurrentCell = Me.DataGridView1(2, 15)
            Panel5.Show()
            Panel6.Show()
            Try
                For i = 0 To total_row - 1
                    If (i > 14) AndAlso (i < 30) Then
                        DataGridView1.Rows(i).Visible = True

                    Else
                        DataGridView1.Rows(i).Visible = False
                    End If
                Next
            Catch ex As Exception
                MsgBox(ex.Message, vbInformation)
            End Try
        End If
    End Sub

    Private Sub Panel7_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel7.MouseClick
        salesReport.Show()
        Me.Close()
    End Sub
End Class