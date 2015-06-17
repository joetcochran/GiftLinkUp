Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Partial Class light_fuse
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))



            Dim oCommandParameter As New SqlParameter("@fuse_key", SqlDbType.UniqueIdentifier)
            oCommandParameter.Value = New Guid(Request.QueryString("fuse_key"))

            Dim dsResults As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, "sel_fuse_action", oCommandParameter)
            If dsResults.Tables(0).Rows.Count = 0 Then
                Throw New Exception
            End If

            Select Case dsResults.Tables(0).Rows(0)("action_cd")
                Case "INVIT", "NEWSH"
                    If Request.QueryString("v") = "1" Then
                        Dim oInsertBlock As New SqlParameter("@vcemail", SqlDbType.VarChar, 100)
                        oInsertBlock.Value = dsResults.Tables(0).Rows(0)("target_email")
                        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_email_block", oInsertBlock)

                        Dim oDeleteFuseAction As New SqlParameter("@ifuse_action_id", SqlDbType.Int)
                        oDeleteFuseAction.Value = dsResults.Tables(0).Rows(0)("fuse_action_id")
                        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "del_fuse_action", oDeleteFuseAction)


                        Me.lblBlock.Visible = True

                    Else
                        Me.pnlINVIT.Visible = True
                        Me.tbEmail.Text = dsResults.Tables(0).Rows(0)("target_email")
                        Me.hdnInviter.Value = dsResults.Tables(0).Rows(0)("requester_id")
                        Me.hdnFuseActionID.Value = dsResults.Tables(0).Rows(0)("fuse_action_id")
                        If Not IsDBNull(dsResults.Tables(0).Rows(0)("tag")) Then
                            Me.hdnFuseTag.Value = dsResults.Tables(0).Rows(0)("tag")
                        End If
                    End If
                Case "SHARE"
                    If Request.QueryString("v") = "1" Then
                        Dim oInsertBlock As New SqlParameter("@vcemail", SqlDbType.VarChar, 100)
                        oInsertBlock.Value = dsResults.Tables(0).Rows(0)("target_email")
                        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_email_block", oInsertBlock)

                        Dim oDeleteFuseAction As New SqlParameter("@ifuse_action_id", SqlDbType.Int)
                        oDeleteFuseAction.Value = dsResults.Tables(0).Rows(0)("fuse_action_id")
                        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "del_fuse_action", oDeleteFuseAction)
                        Me.lblBlock.Visible = True

                    Else

                        Dim oCommandParameter2 As SqlParameter
                        oCommandParameter2 = New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
                        oCommandParameter2.Value = dsResults.Tables(0).Rows(0)("target_email")
                        Dim dsFindRecip As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, "sel_recipient_by_email", _
                                        oCommandParameter2)

                        'add management control
                        Dim oLinkProxy(1) As SqlParameter
                        oLinkProxy(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
                        oLinkProxy(0).Value = dsResults.Tables(0).Rows(0)("tag")
                        oLinkProxy(1) = New SqlParameter("@iproxy_for_id", SqlDbType.Int)
                        oLinkProxy(1).Value = dsFindRecip.Tables(0).Rows(0)("recipient_id")
                        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_xref_recipient_proxy", oLinkProxy)

                        Me.pnlSHARE.Visible = True

                        'Delete the fuse action
                        Dim oDeleteFuseAction As New SqlParameter("@ifuse_action_id", SqlDbType.Int)
                        oDeleteFuseAction.Value = dsResults.Tables(0).Rows(0)("fuse_action_id")
                        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "del_fuse_action", oDeleteFuseAction)

                        LogActivity(dsFindRecip.Tables(0).Rows(0)("recipient_id"), "Executed Fuse Action (SHARE)")

                    End If

            End Select



        End If


    End Sub

    Private Sub cvEmail_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvEmail.ServerValidate
        'Check for existence, validity
        Dim Result As String = ""


        Me.cvEmail.ErrorMessage = ""
        If Not helper.ValidateEmail(Me.tbEmail.Text, Result) Then
            args.IsValid = False
            Me.cvEmail.ErrorMessage = Result
        End If


        'Check database see if username already exists
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
        oCommandParameter.Value = Me.tbEmail.Text

        Dim ScalarResult As Object = SqlHelper.ExecuteScalar(SqlConn, CommandType.StoredProcedure, _
          "sel_recipient_by_email", _
         oCommandParameter)
        If Not ScalarResult Is Nothing Then
            cvEmail.ErrorMessage = "This email address already exists in the system."
            args.IsValid = False
        End If

    End Sub
    Private Sub cvName_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvName.ServerValidate
        Me.cvName.ErrorMessage = ""
        If Trim(Me.tbName.Text).Length = 0 Then
            Me.cvName.ErrorMessage = "Please enter a name."
            args.IsValid = False
        End If
    End Sub

    Private Sub cvPassword_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvPassword.ServerValidate
        Me.cvPassword.ErrorMessage = ""
        If Trim(Me.tbPassword.Text).Length < 4 Then
            Me.cvPassword.ErrorMessage = "Please enter a password, at least 4 characters long."
            args.IsValid = False
        End If
    End Sub

    Private Sub cvPasswordConfirm_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvPasswordConfirm.ServerValidate
        Me.cvPasswordConfirm.ErrorMessage = ""
        If Trim(Me.tbPassword.Text) <> Trim(Me.tbPasswordConfirm.Text) Then
            Me.cvPasswordConfirm.ErrorMessage = "Passwords do not match. Please try again."
            args.IsValid = False
        End If

    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Page.IsValid Then


            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

            'create the recipient
            Dim oInsertRecip(3) As SqlParameter
            oInsertRecip(0) = New SqlParameter("@vcname", SqlDbType.VarChar, 50)
            oInsertRecip(0).Value = Me.tbName.Text
            oInsertRecip(1) = New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
            oInsertRecip(1).Value = Me.tbEmail.Text
            oInsertRecip(2) = New SqlParameter("@vcpassword", SqlDbType.VarChar, 20)
            oInsertRecip(2).Value = Me.tbPassword.Text
            oInsertRecip(3) = New SqlParameter("@irecipient_id", SqlDbType.Int)
            oInsertRecip(3).Direction = ParameterDirection.Output
            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_recipient", oInsertRecip)


            'link their account up the the inviter
            Dim oLinkNewToInviter(1) As SqlParameter
            oLinkNewToInviter(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
            oLinkNewToInviter(0).Value = oInsertRecip(3).Value
            oLinkNewToInviter(1) = New SqlParameter("@inotify_recipient_id", SqlDbType.Int)
            oLinkNewToInviter(1).Value = Me.hdnInviter.Value
            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_xref_recipient_notify", oLinkNewToInviter)

            'link the inviters account (and the managed lists) up to the new one
            Dim oLinkInviter(1) As SqlParameter
            oLinkInviter(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
            oLinkInviter(0).Value = Me.hdnInviter.Value
            oLinkInviter(1) = New SqlParameter("@inotify_recipient_id", SqlDbType.Int)
            oLinkInviter(1).Value = oInsertRecip(3).Value
            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_xref_recipient_notify", oLinkInviter)

            Dim sAction As String = "INVIT"

            If Me.hdnFuseTag.Value <> "" Then
                'add management control
                sAction = "NEWSH"
                Dim oLinkProxy(1) As SqlParameter
                oLinkProxy(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
                oLinkProxy(0).Value = Me.hdnFuseTag.Value
                oLinkProxy(1) = New SqlParameter("@iproxy_for_id", SqlDbType.Int)
                oLinkProxy(1).Value = oInsertRecip(3).Value
                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_xref_recipient_proxy", oLinkProxy)
            End If

            'Delete the fuse action
            Dim oDeleteFuseAction As New SqlParameter("@ifuse_action_id", SqlDbType.Int)
            oDeleteFuseAction.Value = Me.hdnFuseActionID.Value
            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "del_fuse_action", oDeleteFuseAction)

            'Load the session up
            Dim oGetRecipient As New SqlParameter("@irecipient_id", SqlDbType.Int)
            oGetRecipient.Value = oInsertRecip(3).Value
            Dim dsRecipient As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, "sel_recipient_by_id", oGetRecipient)

            Session("RecipientID") = dsRecipient.Tables(0).Rows(0)("recipient_id")
            Session("RecipientGUID") = dsRecipient.Tables(0).Rows(0)("rss_guid")
            Session("RecipientName") = dsRecipient.Tables(0).Rows(0)("name")
            Session("RecipientEmail") = dsRecipient.Tables(0).Rows(0)("email")
            Session("DisplayListNotifications") = "Y"

            LogActivity(dsRecipient.Tables(0).Rows(0)("recipient_id"), "Executed Fuse Action (" & sAction & ")")

            Response.Redirect("main.aspx")
        End If

    End Sub

    Private Sub LogActivity(ByVal UserID As Integer, ByVal Description As String)
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        'Need to dynamically create the proxy user controls
        Dim dsProxyFor As DataSet
        Dim oCommandParameter(1) As SqlParameter
        oCommandParameter(0) = New SqlParameter("@user_id", SqlDbType.Int)
        oCommandParameter(0).Value = UserID
        oCommandParameter(1) = New SqlParameter("@vcdescription", SqlDbType.VarChar, 50)
        oCommandParameter(1).Value = Description

        dsProxyFor = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
         "ins_activity_log", _
         oCommandParameter)

    End Sub

    Protected Sub btnSHARE_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSHARE_Next.Click
        Session.Abandon()
        Response.Redirect("main.aspx")
    End Sub
End Class
