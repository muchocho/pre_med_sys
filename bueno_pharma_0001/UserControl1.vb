Public Class UserControl1
    Private medsname As String
    Private qnty As String

    Public Property _medsname As String
        Get
            Return medsname
        End Get
        Set(value As String)
            medsname = value
            Label3.Text = value
        End Set
    End Property

    Public Property _qnty As String
        Get
            Return qnty
        End Get
        Set(value As String)
            qnty = value
            Label1.Text = value
        End Set
    End Property

End Class
