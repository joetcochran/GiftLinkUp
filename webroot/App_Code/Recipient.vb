Imports Microsoft.VisualBasic
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data

Public Class Recipient
    Private m_ConnectionString As String

    Private m_Username As String
    Private m_Name As String
    Private m_Email As String
    Private m_Password As String
    Private m_RecipientID As Integer
    Private m_TransactionCode As String
    Private m_GroupID As Integer
    Private m_Proxies As ArrayList
    Private m_NotifyEmails As ArrayList
    Public ReadOnly Property TransactionCode() As String
        Get
            Return m_TransactionCode
        End Get
    End Property

    Public Property ConnectionString() As String
        Get
            Return m_ConnectionString
        End Get
        Set(ByVal Value As String)
            m_ConnectionString = Value
        End Set
    End Property
    Public ReadOnly Property NotifyEmails() As ArrayList
        Get
            Return m_NotifyEmails
        End Get
    End Property

    Public ReadOnly Property Proxies() As ArrayList
        Get
            Return m_Proxies
        End Get
    End Property
    Public Function AddProxy(ByVal RecipientID As Integer) As Boolean
        For Each i As Integer In Me.m_Proxies
            If i = RecipientID Then
                Return False
            End If
        Next
        m_Proxies.Add(RecipientID)
        Me.SetTransactionCd("U")
        Return True
    End Function

    Public Function AddNotifyEmail(ByVal Email As String) As Boolean
        For Each s As String In Me.m_NotifyEmails
            If s = Email Then
                Return False
            End If
        Next
        m_NotifyEmails.Add(Email)
        Me.SetTransactionCd("U")
        Return True
    End Function

    Public Function RemoveProxy(ByVal RecipientID As Integer) As Boolean
        For Each i As Integer In Me.m_Proxies
            If i = RecipientID Then
                Me.m_Proxies.Remove(RecipientID)
                Me.SetTransactionCd("U")
                Return True
            End If
        Next
        Return False
    End Function

    Public Function RemoveNotifyEmail(ByVal Email As String) As Boolean
        For Each s As String In Me.m_NotifyEmails
            If s = Email Then
                Me.m_NotifyEmails.Remove(Email)
                Me.SetTransactionCd("U")
                Return True
            End If
        Next
        Return False
    End Function

    Public Property GroupID() As Integer
        Get
            Return Me.m_GroupID
        End Get
        Set(ByVal Value As Integer)
            Me.m_GroupID = Value
        End Set
    End Property
    Public ReadOnly Property GroupMember() As Boolean
        Get
            Return m_GroupID <> 0
        End Get
    End Property
    Public Property RecipientID() As Integer
        Get
            Return m_RecipientID
        End Get
        Set(ByVal Value As Integer)
            m_RecipientID = Value
        End Set
    End Property
    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set(ByVal Value As String)
            m_Password = Value
            SetTransactionCd("U")
        End Set
    End Property
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(ByVal Value As String)
            m_Email = Value
            SetTransactionCd("U")
        End Set
    End Property
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal Value As String)
            m_Name = Value
            SetTransactionCd("U")
        End Set
    End Property

    Public Property Username() As String
        Get
            Return m_Username
        End Get
        Set(ByVal Value As String)
            m_Username = Value
            SetTransactionCd("U")
        End Set
    End Property

    Public Sub New(ByVal TransactionCode As String)
        Me.m_TransactionCode = TransactionCode
        Me.m_NotifyEmails = New ArrayList
        Me.m_Proxies = New ArrayList
    End Sub

    Private Sub SetTransactionCd(ByVal Value As String)
        If Value = "U" And Me.m_TransactionCode <> "I" Then
            Me.m_TransactionCode = Value
        End If
    End Sub

    Public Sub New(ByVal Name As String, ByVal Email As String, ByVal TransactionCode As String)
        Me.m_Name = Name
        Me.m_Email = Email
        Me.m_TransactionCode = TransactionCode
        Me.m_NotifyEmails = New ArrayList
        Me.m_Proxies = New ArrayList
    End Sub

    Public Sub Retrieve(ByVal RecipientID As Integer)
        SqlHelper.ExecuteDataset(Me.m_ConnectionString, CommandType.StoredProcedure, "sel_recipient")
    End Sub

    Public Sub InsertNotifyEmails()
        Dim NotifyEmailID As Integer
        For Each NotifyEmailIterate As String In Me.m_NotifyEmails
            'Try to see if this email already exists as a recipient in the system somewhere
            Dim oEmailParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
            oEmailParameter.Value = NotifyEmailIterate
            Dim ScalarResult As Object = SqlHelper.ExecuteScalar(Me.m_ConnectionString, CommandType.StoredProcedure, _
              "sel_recipient_by_email", _
             oEmailParameter)

            'If the email doesn't exist in the system, need to add it
            If ScalarResult Is Nothing Then

                Dim o2CommandParameters(3) As SqlParameter
                o2CommandParameters(0) = New SqlParameter("@vcname", SqlDbType.VarChar, 50)
                o2CommandParameters(0).Value = Me.m_Name
                o2CommandParameters(1) = New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
                o2CommandParameters(1).Value = Me.m_Email
                o2CommandParameters(2) = New SqlParameter("@vcpassword", SqlDbType.VarChar, 20)
                o2CommandParameters(2).Value = Me.Password
                o2CommandParameters(3) = New SqlParameter("@irecipient_id", SqlDbType.Int)
                o2CommandParameters(3).Direction = ParameterDirection.Output
                SqlHelper.ExecuteNonQuery(Me.m_ConnectionString, CommandType.StoredProcedure, "ins_recipient", _
                  o2CommandParameters)
                NotifyEmailID = o2CommandParameters(3).Value
            Else
                NotifyEmailID = ScalarResult
            End If

            Dim o3CommandParameters(2) As SqlParameter
            o3CommandParameters(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
            o3CommandParameters(0).Value = Me.RecipientID
            o3CommandParameters(1) = New SqlParameter("@inotify_recipient_id", SqlDbType.Int)
            o3CommandParameters(1).Value = NotifyEmailID

            SqlHelper.ExecuteNonQuery(Me.m_ConnectionString, CommandType.StoredProcedure, "ins_xref_recipient_notify", _
              o3CommandParameters)
        Next
    End Sub

    Public Sub InsertProxies()
        Dim oCommandParameters(3) As SqlParameter
        For Each i As Integer In Me.Proxies
            oCommandParameters(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
            oCommandParameters(0).Value = Me.m_RecipientID
            oCommandParameters(1) = New SqlParameter("@iproxy_for_id", SqlDbType.Int)
            oCommandParameters(1).Value = i
            SqlHelper.ExecuteNonQuery(Me.m_ConnectionString, CommandType.StoredProcedure, "ins_xref_recipient_proxy", _
              oCommandParameters)
        Next

    End Sub

    Public Sub Insert()
        Dim oCommandParameters(3) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@vcname", SqlDbType.VarChar, 50)
        oCommandParameters(0).Value = Me.m_Name
        oCommandParameters(1) = New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
        oCommandParameters(1).Value = Me.m_Email
        oCommandParameters(2) = New SqlParameter("@vcpassword", SqlDbType.VarChar, 20)
        oCommandParameters(2).Value = Me.Password
        oCommandParameters(3) = New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameters(3).Direction = ParameterDirection.Output

        SqlHelper.ExecuteNonQuery(Me.m_ConnectionString, CommandType.StoredProcedure, "ins_recipient", _
          oCommandParameters)

        Me.RecipientID = oCommandParameters(3).Value

    End Sub
    Public Sub Commit()
        If Me.m_TransactionCode = "I" Then


        
          
        End If


    End Sub

    Private Overloads Function Nullable(ByVal i As Integer) As Object
        If i = 0 Then
            Return System.DBNull.Value
        Else
            Return i
        End If
    End Function
End Class



Public Class Group
    Public Recipients As ArrayList
    Private m_GroupID As Integer
    Private m_ConnectionString As String

    Public Sub MaintainRecipientIntegrity(ByVal OldRecipientID As Integer, ByVal NewRecipientID As Integer)
        For Each oRecipient As Recipient In Me.Recipients
            For i As Integer = 0 To oRecipient.Proxies.Count - 1
                If CInt(oRecipient.Proxies(i)) = OldRecipientID Then
                    oRecipient.Proxies(i) = NewRecipientID
                End If
            Next
        Next
    End Sub

    Public Sub AssignArbitraryRecipientIDs()
        Dim i As Integer = 0
        For Each oRecipient As Recipient In Me.Recipients
            oRecipient.RecipientID = i
            i = i + 1
        Next
    End Sub
    Public Property ConnectionString() As String
        Get
            Return m_ConnectionString
        End Get
        Set(ByVal Value As String)
            m_ConnectionString = Value
        End Set
    End Property

    Public Sub New()
        Me.Recipients = New ArrayList
    End Sub

    Public Property GroupID() As Integer
        Get
            Return Me.m_GroupID
        End Get
        Set(ByVal Value As Integer)
            m_GroupID = Value
            For Each oRecipient As Recipient In Me.Recipients
                If oRecipient.GroupID <> Value Then
                    oRecipient.GroupID = Value
                End If
            Next
        End Set
    End Property

    Public Function AllRecipientsNeedingProxies() As ArrayList
        Dim oRC As New ArrayList
        For Each oRecipient As Recipient In Me.Recipients
            If oRecipient.Email = "" Then
                oRC.Add(oRecipient)
            End If
        Next
        Return oRC
    End Function

    Public Function AllRecipientsEligibleAsProxies() As ArrayList
        Dim oRC As New ArrayList
        For Each oRecipient As Recipient In Me.Recipients
            If oRecipient.Email <> "" Then
                oRC.Add(oRecipient)
            End If
        Next
        Return oRC
    End Function

    Public Function FindRecipientByID(ByVal RecipientID As Integer) As Recipient
        For Each oRecipient As Recipient In Me.Recipients
            If oRecipient.RecipientID = RecipientID Then
                Return oRecipient
            End If
        Next
        Return Nothing

    End Function


    Public Sub Commit(ByVal TransactionCd As String)

        If TransactionCd = "I" Then


        End If

    End Sub


End Class
