Imports MySql.Data.MySqlClient
Module actions
    Public conbin As New MySqlConnection("server=localhost;database=buena_pharma;uid=root;pwd=root;")
    Public accountIdent As Integer
    Public username As String
    Public rsp As String
    Public staff As String
    Public finalID As String
    Public total As Decimal
    Public _tcost As Decimal
    Public sumtotal As Decimal
    Public total_cost As Decimal

    Public form_reference As Integer
    Public selected As String

    Public user_ID As String


    Public Sub connect()
        If conbin.State = ConnectionState.Open Then
            conbin.Close()
            conbin.Open()
        Else
            conbin.Open()
        End If
    End Sub

    Public Function login(_id As Integer, _password As String)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM account_privilage WHERE account_ID = @1 AND account_pass = @2", conbin)
        cmd.Parameters.AddWithValue("@1", _id)
        cmd.Parameters.AddWithValue("@2", _password)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function accountreg(_id As Integer, _type As String, _name As String, _pass As String, _ddate As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO account_privilage(account_ID, account_type, account_name, account_pass,reg_date)VALUES(@1,@2,@3,@4,@5)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", _id)
            .Parameters.AddWithValue("@2", _type)
            .Parameters.AddWithValue("@3", _name)
            .Parameters.AddWithValue("@4", _pass)
            .Parameters.AddWithValue("@5", _ddate)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function accountreg1(_id As Integer, _address As String, _contact As String, _email As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO staff_info(Account_Id, Address, Contact_No, Email)VALUES(@1,@2,@3,@4)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", _id)
            .Parameters.AddWithValue("@2", _address)
            .Parameters.AddWithValue("@3", _contact)
            .Parameters.AddWithValue("@4", _email)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function valID(_id As Integer)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM account_privilage WHERE account_ID = @1", conbin)
        cmd.Parameters.AddWithValue("@1", _id)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function valtransid(_id As Integer)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM trans_sales_data WHERE Transaction_No = @1", conbin)
        cmd.Parameters.AddWithValue("@1", _id)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function valname(_name As String)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM account_privilage WHERE account_name = @1", conbin)
        cmd.Parameters.AddWithValue("@1", _name)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function valclientname(_name As String)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM client_info WHERE Name='" & _name & "'", conbin)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function suppliereg(_name As String, _add As String, _conNo As String, _email As String, _terms As String, _ddate As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO supplierinfo(Supplier_Name,Address,Contact_No,Email,Terms,Date)VALUES(@2,@3,@4,@5,@6,@7)", conbin)
        With cmd

            .Parameters.AddWithValue("@2", _name)
            .Parameters.AddWithValue("@3", _add)
            .Parameters.AddWithValue("@4", _conNo)
            .Parameters.AddWithValue("@5", _email)
            .Parameters.AddWithValue("@6", _terms)
            .Parameters.AddWithValue("@7", _ddate)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function valsup(_name As String)
        connect()
        Dim cmd As New MySqlCommand("SELECT * FROM supplierinfo WHERE Supplier_Name = @1", conbin)
        cmd.Parameters.AddWithValue("@1", _name)
        Dim dt As New DataTable
        Dim dr As MySqlDataReader = cmd.ExecuteReader
        dt.Load(dr)
        Return dt
    End Function

    Public Function stockinfo(_id As String, _meds As String, _qnty As String, _rsp As String, _price As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO stocks_info(Bar_ID,Medicine_Name,Quantity,RSP,Price)VALUES(@1,@2,@3,@4,@5)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", _id)
            .Parameters.AddWithValue("@2", _meds)
            .Parameters.AddWithValue("@3", _qnty)
            .Parameters.AddWithValue("@4", _rsp)
            .Parameters.AddWithValue("@5", _price)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function stockTransInfo(_id As String, _pname As String, _supplier As String, _staff As String, _lot_no As String, _exp As Date, _cert As String, _date As String, _time As String, _qnt As String, _rsp As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO stock_trans_info(Bar_ID,Product_Name,Supplier,Staff_Incharge,Lot_Number,Exp_Date,Certified,Date,Time,Quantity,RSP)VALUES(@1,@11,@2,@3,@4,@5,@6,@7,@8,@9,@10)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", _id)
            .Parameters.AddWithValue("@2", _supplier)
            .Parameters.AddWithValue("@3", _staff)
            .Parameters.AddWithValue("@4", _lot_no)
            .Parameters.AddWithValue("@5", _exp)
            .Parameters.AddWithValue("@6", _cert)
            .Parameters.AddWithValue("@7", _date)
            .Parameters.AddWithValue("@8", _time)
            .Parameters.AddWithValue("@9", _qnt)
            .Parameters.AddWithValue("@10", _rsp)
            .Parameters.AddWithValue("@11", _pname)
            .ExecuteNonQuery()
        End With
        Return True
    End Function
    Public Function addmedsbrand(_name As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO meds_list(meds_name)VALUES('" & _name & "')", conbin)
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Function addmedsgen(_name As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO meds_gen(meds_name)VALUES('" & _name & "')", conbin)
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Function addclient(_name As String, _add As String, _conno As String, _email As String, _term As String, _ddate As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO client_info(Name,Address,Contact_No,Email,Terms,Date)VALUES(@1,@2,@3,@4,@5,@6)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", _name)
            .Parameters.AddWithValue("@2", _add)
            .Parameters.AddWithValue("@3", _conno)
            .Parameters.AddWithValue("@4", _email)
            .Parameters.AddWithValue("@5", _term)
            .Parameters.AddWithValue("@6", _ddate)
            .ExecuteNonQuery()
        End With
        Return True
    End Function

    Public Function addpurchaseproduct(_transid As String, _or As String, _medsname As String, _unit As String, _quantity As String, _price As String, _total As String, _ddate As Date, _ttime As String, _rsp As String, _bar As String, _tot_cost As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO sales_data(Transaction_ID,OR_Number,Product_Name,Unit,Quantity,Price,Total,Date,Time,RSP,Bar_ID,Total_Cost)VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", _transid)
            .Parameters.AddWithValue("@2", _or)
            .Parameters.AddWithValue("@3", _medsname)
            .Parameters.AddWithValue("@4", _unit)
            .Parameters.AddWithValue("@5", _quantity)
            .Parameters.AddWithValue("@6", _price)
            .Parameters.AddWithValue("@7", _total)
            .Parameters.AddWithValue("@8", _ddate)
            .Parameters.AddWithValue("@9", _ttime)
            .Parameters.AddWithValue("@10", _rsp)
            .Parameters.AddWithValue("@11", _bar)
            .Parameters.AddWithValue("@12", _tot_cost)
            .ExecuteNonQuery()
        End With
        Return True
    End Function


    Public Function addcolINFO(_transid As String, _client As String, _payment As String, _ddate As Date, _personel As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO collect_info(Transaction_ID,Client,Payment,Date,Incharge)VALUES(@1,@3,@4,@5,@6)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", _transid)
            .Parameters.AddWithValue("@3", _client)
            .Parameters.AddWithValue("@4", _payment)
            .Parameters.AddWithValue("@5", _ddate)
            .Parameters.AddWithValue("@6", _personel)
            .ExecuteNonQuery()
        End With
        Return True
    End Function


    Public Function addpayINFO(_client As String, _payment As String, _ddate As Date, _personel As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO payable_info(Client_Supplier,Payment,Date,Incharge)VALUES(@3,@4,@5,@6)", conbin)
        With cmd
            .Parameters.AddWithValue("@3", _client)
            .Parameters.AddWithValue("@4", _payment)
            .Parameters.AddWithValue("@5", _ddate)
            .Parameters.AddWithValue("@6", _personel)
            .ExecuteNonQuery()
        End With
        Return True
    End Function


    Public Function addsalestrans(_id As String, _staff As String, _client As String, _date As Date, _time As String, _price As String, _payment As String, _balance As String, _terms As String, _dis_per As String, _dis_amount As String, _total_cost As String)
        connect()
        Dim cmd As New MySqlCommand("INSERT INTO trans_sales_data(Transaction_No,Staff_Incharge,Client,Date,Time,Total_Price,Payment,Balance,Terms,Discount_Percentage,Discount_Amount,Total_Cost)VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12)", conbin)
        With cmd
            .Parameters.AddWithValue("@1", _id)
            .Parameters.AddWithValue("@2", _staff)
            .Parameters.AddWithValue("@3", _client)
            .Parameters.AddWithValue("@4", _date)
            .Parameters.AddWithValue("@5", _time)
            .Parameters.AddWithValue("@6", _price)
            .Parameters.AddWithValue("@7", _payment)
            .Parameters.AddWithValue("@8", _balance)
            .Parameters.AddWithValue("@9", _terms)
            .Parameters.AddWithValue("@10", _dis_per)
            .Parameters.AddWithValue("@11", _dis_amount)
            .Parameters.AddWithValue("@12", _total_cost)
            .ExecuteNonQuery()
        End With
        Return True
    End Function
    Public Function deleteproduct(_id As String)
        connect()
        Dim cmd As New MySqlCommand("DELETE FROM stocks_info WHERE Bar_ID='" & _id & "'", conbin)
        cmd.ExecuteNonQuery()
        Return True
    End Function

    Public Function updateqnt(_id As String, _qnt As String)
        connect()
        Dim cmd As New MySqlCommand("UPDATE stocks_info SET Quantity='" & _qnt & "' WHERE Bar_ID='" & _id & "'", conbin)
        cmd.ExecuteNonQuery()
        Return True
    End Function
End Module
