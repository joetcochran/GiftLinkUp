Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Net.Mail
Partial Class NewMain
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            BindRepeaters()

        End If
        SetShowHideImages()
    End Sub

    Private Sub BindRepeaters()
        'Need to dynamically create the proxy user controls
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        'Need to dynamically create the proxy user controls
        Dim dsProxyFor As DataSet
        Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Session("RecipientID")

        dsProxyFor = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
         "sel_proxies_for_recipient", _
         oCommandParameter)

        Me.rptProxies.DataSource = dsProxyFor
        Me.rptProxies.DataBind()

        Dim dsOther As DataSet
        Dim o2CommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        o2CommandParameter.Value = Session("RecipientID")

        dsOther = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
         "sel_viewable_lists_by_recipient", _
         o2CommandParameter)

        'Remove any "other" wish list that has already been displayed as a proxy
        For Each oProxyRow As DataRow In dsProxyFor.Tables(0).Rows
            RemoveRow(oProxyRow("recipient_id"), dsOther)
        Next

        Me.rptOthers.DataSource = dsOther
        Me.rptOthers.DataBind()

    End Sub
    Private Sub SetShowHideImages()
        If Session("DisplayListNotifications") = "Y" Then
            Me.imgbutToggleListNotifications.ImageUrl = "~/images/hide-purchased-cmd.jpg"
            Me.imgbutToggleManagedNotifications.ImageUrl = "~/images/hide-purchased-cmd.jpg"
        Else
            Me.imgbutToggleListNotifications.ImageUrl = "~/images/show-purchased-cmd.jpg"
            Me.imgbutToggleManagedNotifications.ImageUrl = "~/images/show-purchased-cmd.jpg"
        End If
    End Sub

    Private Sub RemoveRow(ByVal RecipientID As Integer, ByRef ds As DataSet)
        For Each oRow As DataRow In ds.Tables(0).Rows
            If oRow("recipient_id") = RecipientID Then
                oRow.Delete()
            End If
        Next
        ds.AcceptChanges()
    End Sub

    Protected Sub imgbutToggleListNotifications_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbutToggleListNotifications.Click
        If Session("DisplayListNotifications") = "Y" Then
            Session("DisplayListNotifications") = "N"
        Else
            Session("DisplayListNotifications") = "Y"
        End If
        SetShowHideImages()
        Response.Redirect("main.aspx")
    End Sub

    Protected Sub imgbutToggleManagedNotifications_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbutToggleManagedNotifications.Click
        If Session("DisplayListNotifications") = "Y" Then
            Session("DisplayListNotifications") = "N"
        Else
            Session("DisplayListNotifications") = "Y"
        End If
        SetShowHideImages()
        Response.Redirect("main.aspx")
    End Sub
    Protected Sub lbLinkUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLinkUp.Click
        Me.pnlLinkUp.Visible = True
        Me.lbLinkUp.Visible = False
    End Sub

    Protected Sub btnSearchRecipients_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearchRecipients.Click

        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
        oCommandParameter.Value = Me.txtLinkUpEmail.Text
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
          "sel_recipient_by_email", _
         oCommandParameter)

        lblLinkUpDirectionStep1.Visible = False
        lblLinkUpDirectionStep2.Visible = False
        lblLinkUpSuccess.Visible = False
        lblLinkUpPrivateFail.Visible = False
        lblLinkUpNotFound.Visible = False
        lblLinkUpNotFound2.Visible = False
        hlInvite.Visible = False
        tblRowPrivateListPassword.Visible = False
        tblRowEmail.Visible = False
        tblRowSearchStep2.Visible = False
        tblRowSearchStep1.Visible = False

        If dsResult.Tables(0).Rows.Count = 0 Then
            Me.lblLinkUpNotFound.Visible = True
            Me.lblLinkUpNotFound2.Visible = True
            hlInvite.Visible = True
            Me.tblRowSearchStep1.Visible = True
            lblLinkUpDirectionStep1.Visible = True
            tblRowEmail.Visible = True

        Else
            If dsResult.Tables(0).Rows(0)("searchable_ind") = "N" Then
                lblLinkUpDirectionStep2.Visible = True
                lblLinkUpDirectionStep1.Visible = False
                Me.hdnPrivateListRecipientID.Value = dsResult.Tables(0).Rows(0)("recipient_id")
                tblRowPrivateListPassword.Visible = True
                tblRowEmail.Visible = False
                tblRowSearchStep2.Visible = True
                tblRowSearchStep1.Visible = False


            Else

                Dim oCommandParameters(1) As SqlParameter
                oCommandParameters(0) = New SqlParameter("@irecipient_id", Data.SqlDbType.Int)
                oCommandParameters(0).Value = dsResult.Tables(0).Rows(0)("recipient_id")
                oCommandParameters(1) = New SqlParameter("@inotify_recipient_id", Data.SqlDbType.Int)
                oCommandParameters(1).Value = Session("RecipientID")


                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_xref_recipient_notify", _
                oCommandParameters)

                Me.lblLinkUpSuccess.Visible = True
                Me.tblRowEmail.Visible = True
                Me.tblRowPrivateListPassword.Visible = False
                tblRowSearchStep1.Visible = True


                Response.Redirect("main.aspx")
            End If
        End If
    End Sub

    Protected Sub btnSubmitPrivateListPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitPrivateListPassword.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Me.hdnPrivateListRecipientID.Value
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
          "sel_recipient_by_id", _
         oCommandParameter)

        lblLinkUpDirectionStep1.Visible = False
        lblLinkUpDirectionStep2.Visible = False
        lblLinkUpSuccess.Visible = False
        lblLinkUpPrivateFail.Visible = False
        lblLinkUpNotFound.Visible = False
        lblLinkUpNotFound2.Visible = False
        hlInvite.Visible = False
        tblRowPrivateListPassword.Visible = False
        tblRowEmail.Visible = False
        tblRowSearchStep2.Visible = False
        tblRowSearchStep1.Visible = False

        If IsDBNull(dsResult.Tables(0).Rows(0)("private_list_password")) Then
            Me.lblLinkUpPrivateFail.Visible = True
            Me.lblLinkUpDirectionStep2.Visible = True
            Me.lblLinkUpPrivateFail.Visible = True
            Me.tblRowSearchStep2.Visible = True
            Me.tblRowPrivateListPassword.Visible = True

        Else
            Dim CorrectPrivateListPassword As String = dsResult.Tables(0).Rows(0)("private_list_password")
            If Me.txtLinkUpPrivateListPassword.Text <> CorrectPrivateListPassword Then
                Me.lblLinkUpPrivateFail.Visible = True
                Me.lblLinkUpDirectionStep2.Visible = True
                Me.tblRowSearchStep2.Visible = True
                Me.tblRowPrivateListPassword.Visible = True

            Else

                Dim oCommandParameters(1) As SqlParameter
                oCommandParameters(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
                oCommandParameters(0).Value = dsResult.Tables(0).Rows(0)("recipient_id")
                oCommandParameters(1) = New SqlParameter("@inotify_recipient_id", SqlDbType.Int)
                oCommandParameters(1).Value = Session("RecipientID")
                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_xref_recipient_notify", oCommandParameters)
                hdnPrivateListRecipientID.Value = ""

                Me.tblRowSearchStep1.Visible = True
                Me.tblRowEmail.Visible = True
                Me.lblLinkUpDirectionStep1.Visible = True
                Me.lblLinkUpSuccess.Visible = True
                Me.txtLinkUpEmail.Text = ""
                Me.txtLinkUpPrivateListPassword.Text = ""

                Response.Redirect("main.aspx")

            End If
        End If
    End Sub

    Protected Sub btnCancelPrivateList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelPrivateList.Click

        lblLinkUpDirectionStep1.Visible = True
        lblLinkUpDirectionStep2.Visible = False
        lblLinkUpSuccess.Visible = False
        lblLinkUpPrivateFail.Visible = False
        lblLinkUpNotFound.Visible = False
        lblLinkUpNotFound2.Visible = False
        hlInvite.Visible = False
        tblRowPrivateListPassword.Visible = False
        tblRowEmail.Visible = True
        tblRowSearchStep2.Visible = False
        tblRowSearchStep1.Visible = True
        tblRowSearchStep1.Visible = True
    End Sub

    Protected Sub btnCancelSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelSearch.Click

        Me.pnlLinkUp.Visible = False
        Me.lbLinkUp.Visible = True
    End Sub

    Protected Sub btnAddManagedList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddManagedList.Click
        Me.pnlAddManaged.Visible = True
        Me.btnAddManagedList.Visible = False
    End Sub

    Protected Sub btnCancelCreateProxy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelCreateProxy.Click
        Me.pnlAddManaged.Visible = False
        Me.btnAddManagedList.Visible = True
    End Sub

    Protected Sub btnCreateProxy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateProxy.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        lblNameErr.Visible = False

        If Trim(txtAddManaged.Text) = "" Then
            lblNameErr.Visible = True
            Exit Sub
        End If


        Dim oCommandParameters(3) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@vcname", SqlDbType.VarChar, 50)
        oCommandParameters(0).Value = Me.txtAddManaged.Text
        oCommandParameters(1) = New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
        oCommandParameters(1).Value = System.DBNull.Value
        oCommandParameters(2) = New SqlParameter("@vcpassword", SqlDbType.VarChar, 20)
        oCommandParameters(2).Value = System.DBNull.Value
        oCommandParameters(3) = New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameters(3).Direction = ParameterDirection.Output

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
          "ins_recipient", _
          oCommandParameters)

        Dim NewRecipientID As Integer = oCommandParameters(3).Value

        Dim oCommandParameters2(1) As SqlParameter
        oCommandParameters2(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameters2(0).Value = NewRecipientID
        oCommandParameters2(1) = New SqlParameter("@iproxy_for_id", SqlDbType.Int)
        oCommandParameters2(1).Value = Session("RecipientID")

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
          "ins_xref_recipient_proxy", _
          oCommandParameters2)


        Dim oCommandParameters3(1) As SqlParameter
        oCommandParameters3(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameters3(0).Value = NewRecipientID
        oCommandParameters3(1) = New SqlParameter("@inotify_recipient_id", SqlDbType.Int)
        oCommandParameters3(1).Value = Session("RecipientID")

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
          "ins_xref_recipient_notify", _
          oCommandParameters3)


        Me.btnAddManagedList.Visible = True
        Me.pnlAddManaged.Visible = False
        Me.lblManagedListSuccess.Visible = True
        Response.Redirect("main.aspx")


    End Sub

    Protected Sub hlInvite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles hlInvite.Click

        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameters(3) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@caction_cd", SqlDbType.Char, 5)
        oCommandParameters(0).Value = "INVIT"
        oCommandParameters(1) = New SqlParameter("@vctarget_email", SqlDbType.VarChar, 100)
        oCommandParameters(1).Value = Me.txtLinkUpEmail.Text.ToUpper.Trim
        oCommandParameters(2) = New SqlParameter("@nrequester_id", SqlDbType.Int)
        oCommandParameters(2).Value = Session("RecipientID")
        oCommandParameters(3) = New SqlParameter("@fuse_key", SqlDbType.UniqueIdentifier)
        oCommandParameters(3).Direction = ParameterDirection.Output


        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
          "ins_fuse_action", _
          oCommandParameters)

        If Not IsDBNull(oCommandParameters(3).Value) Then
            SendMail(Me.txtLinkUpEmail.Text, Session("RecipientName") & " wants you to join!", GenerateInvitation(oCommandParameters(3).Value.ToString))
        End If

    End Sub

    Private Sub SendMail(ByVal EmailTo As String, ByVal Subject As String, ByVal Content As String)
        Dim mailServerName As String = "relay-hosting.secureserver.net"

        Dim message As MailMessage = New MailMessage("admin@giftlinkup.com", EmailTo, Subject, Content)
        Dim mailClient As SmtpClient = New SmtpClient
        mailClient.Host = mailServerName
        mailClient.Port = 25
        mailClient.Send(message)
        message.Dispose()

    End Sub


    Private Function GenerateInvitation(ByVal fuseKey As String) As String

        Dim invitation As String = Session("RecipientName") & " wants you to join GiftLinkUp.com!" & vbCrLf & vbCrLf


        invitation = invitation & "What is GiftLinkUp.com?" & vbCrLf
        invitation = invitation & "Creating a GiftLinkUp.com account is a great way to let people know what you would like while still preserving the surprise! When you link your account to your friends and family members with GiftLinkUp.com accounts, you can make sure you get what you want and they do too." & vbCrLf & vbCrLf

        invitation = invitation & "Simply click the link below, or copy it to the address bar of your browser and you'll be automatically linked up to " & Session("RecipientName") & "'s wish list." & vbCrLf
        invitation = invitation & "http://www.giftlinkup.com/light-fuse.aspx?fuse_key=" & fuseKey & vbCrLf & vbCrLf

        invitation = invitation & "Happy Gift-Giving!" & vbCrLf
        invitation = invitation & "The GiftLinkUp.com team" & vbCrLf & vbCrLf & vbCrLf



        invitation = invitation & "To OPT OUT of future GiftLinkUp.com invitations, follow the link below." & vbCrLf
        invitation = invitation & "Opt Out: " & "http://www.giftlinkup.com/light-fuse.aspx?fuse_key=" & fuseKey & "&v=1"
        Return invitation
    End Function
End Class
