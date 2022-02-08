Public Class adminadmin
    Private Sub adminadmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel2_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel2.MouseClick
        regadmin.Show()
        Me.Hide()
    End Sub

    Private Sub Panel3_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel3.MouseClick
        regstaff.Show()
        Me.Hide()
    End Sub

    Private Sub Panel4_MouseClick(sender As Object, e As MouseEventArgs) Handles Panel4.MouseClick
        Form1.Show()
        Me.Close()
    End Sub
End Class