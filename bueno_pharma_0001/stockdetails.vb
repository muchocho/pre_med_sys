Public Class stockdetails
    Private prname As String
    Private pbarr As String
    Private pcost As String
    Private pstockq As String
    Private tcost As String
    Public Property _prname As String
        Get
            Return prname
        End Get
        Set(value As String)
            prname = value
            Label1.Text = value
        End Set
    End Property

    Public Property _pbarr As String
        Get
            Return pbarr
        End Get
        Set(value As String)
            pbarr = value
            Label2.Text = value
        End Set
    End Property

    Public Property _pcost As String
        Get
            Return pcost
        End Get
        Set(value As String)
            pcost = value
            Label3.Text = value
        End Set
    End Property

    Public Property _pstockq As String
        Get
            Return pstockq
        End Get
        Set(value As String)
            pstockq = value
            Label4.Text = value
        End Set
    End Property

    Public Property _tcost As String
        Get
            Return tcost
        End Get
        Set(value As String)
            tcost = value
            Label5.Text = value
        End Set
    End Property
End Class
