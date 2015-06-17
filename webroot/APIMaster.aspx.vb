Imports System.Data
Imports Microsoft.applicationblocks.Data
Imports System.Data.SqlClient

Partial Class APIMaster
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Clear()

        If Request.QueryString("op") = "login" Then
            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

            Dim oCommandParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
            oCommandParameter.Value = Request.QueryString("email")
            Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
              "sel_recipient_by_email", _
              oCommandParameter)

            If dsResult.Tables(0).Rows.Count <> 0 Then
                If dsResult.Tables(0).Rows(0)("password") = Request.QueryString("password") Then
                    Response.Write(CreateUserSession(dsResult.Tables(0).Rows(0)("recipient_id")))
                End If
            End If
        End If

        If Request.QueryString("op") = "listmyitems" Then
            Dim userid As String = LookupUserSession(New Guid(Request.QueryString("token")))
            If userid = "" Then Response.End()

            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
            Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
            oCommandParameter.Value = userid

            Dim dsMyWishList As DataSet
            dsMyWishList = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
             "sel_gifts_for_recipient", _
             oCommandParameter)
            Dim output As String = ""
            For Each row As DataRow In dsMyWishList.Tables(0).Rows
                output = output & row("gift_id") & "-#@#-"
                output = output & row("description") & ","
            Next
            If output <> "" Then output = Left(output, Len(output) - 1) 'trim last comma
            Response.Write(output)
        End If

        If Request.QueryString("op") = "getmygift" Then
            Dim userid As String = LookupUserSession(New Guid(Request.QueryString("token")))
            If userid = "" Then Response.End()

            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

            Dim oCommandParameters(1) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
            oCommandParameters(0).Value = userid
            oCommandParameters(1) = New SqlParameter("@igift_id", SqlDbType.Int)
            oCommandParameters(1).Value = Request.QueryString("gift_id")

            Dim dsMyWishList As DataSet
            dsMyWishList = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
             "sel_gift_owned_by_recipient", _
             oCommandParameters)

            Dim output As String = ""
            For Each row As DataRow In dsMyWishList.Tables(0).Rows
                output = output & row("gift_id") & "-#@#-"
                output = output & row("description") & "-#@#-"
                If IsDBNull(row("url")) Then
                    output = output & " " & "-#@#-"
                Else
                    output = output & row("url") & "-#@#-"
                End If

                If IsDBNull(row("desire_lvl")) Then
                    output = output & " " & "-#@#-"
                Else
                    output = output & row("desire_lvl") & "-#@#-"
                End If

                output = output & row("comment") & " "
            Next

            Response.Write(output)
        End If

        If Request.QueryString("op") = "insertmygift" Then
            Dim userid As String = LookupUserSession(New Guid(Request.QueryString("token")))
            If userid = "" Then Response.End()
            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

            Dim sURL As String = ""

            If Request.QueryString("url") <> "" Then
                If Left(Trim(Request.QueryString("url")), 4) = "http" Then
                    sURL = Trim(Request.QueryString("url"))
                Else
                    sURL = "http://" & Trim(Request.QueryString("url"))
                End If
            End If


            Dim oCommandParameters(4) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@nrecipient_id", SqlDbType.Int)
            oCommandParameters(0).Value = userid
            oCommandParameters(1) = New SqlParameter("@vcdescription", SqlDbType.VarChar, 255)
            oCommandParameters(1).Value = Request.QueryString("description")
            oCommandParameters(2) = New SqlParameter("@vcurl", SqlDbType.VarChar, 8000)
            If sURL = "" Then
                oCommandParameters(2).Value = DBNull.Value
            Else
                oCommandParameters(2).Value = sURL
            End If

            oCommandParameters(3) = New SqlParameter("@tidesire_lvl", SqlDbType.TinyInt)
            If IsNumeric(Request.QueryString("desire_lvl")) Then
                oCommandParameters(3).Value = Request.QueryString("desire_lvl")
            Else
                oCommandParameters(3).Value = DBNull.Value
            End If

            oCommandParameters(4) = New SqlParameter("@vccomment", SqlDbType.VarChar, 5000)
            If Request.QueryString("comment") = "" Then
                oCommandParameters(4).Value = DBNull.Value
            Else
                oCommandParameters(4).Value = Request.QueryString("comment")
            End If

            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_gift", _
                        oCommandParameters)


        End If


    End Sub

    Private Function LookupUserSession(ByVal id As Guid) As String
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim parm As New SqlParameter("@id", SqlDbType.UniqueIdentifier)
        parm.Value = id
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
                  "sel_user_session", _
                  parm)

        If dsResult.Tables(0).Rows.Count = 0 Then
            Return ""
        Else
            Return dsResult.Tables(0).Rows(0)("user_id")
        End If

    End Function

    Private Sub UpdateUserSession(ByVal id As Guid)
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim parm As New SqlParameter("@id", SqlDbType.UniqueIdentifier)
        parm.Value = id
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
                  "upd_user_session", _
                  parm)

    End Sub

    Private Function CreateUserSession(ByVal UserID As Integer) As Guid
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim parms(1) As SqlParameter
        parms(0) = New SqlParameter("@id", SqlDbType.UniqueIdentifier)
        parms(0).Direction = ParameterDirection.Output
        parms(1) = New SqlParameter("@user_id", SqlDbType.Int)
        parms(1).Value = UserID
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
                  "ins_user_session", _
                  parms)
        Return parms(0).Value

    End Function
End Class
