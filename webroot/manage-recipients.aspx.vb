Imports Microsoft.ApplicationBlocks.Data
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail



Partial Class manage_recipients
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            RefreshCheckboxList()
        End If
    End Sub

    Private Sub RefreshCheckboxList()
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter1 As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter1.Value = Session("RecipientID")
        Dim oCommandParameter2 As New SqlParameter("@omit_proxies", SqlDbType.Bit)
        oCommandParameter2.Value = True

        Dim dsTargets As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
        "sel_viewable_lists_by_recipient", _
        oCommandParameter1, oCommandParameter2)

        Me.clbRemoveRecipients.Items.Clear()
        For Each oRow As DataRow In dsTargets.Tables(0).Rows
            Me.clbRemoveRecipients.Items.Add(New System.Web.UI.WebControls.ListItem(oRow("name"), oRow("recipient_id")))
        Next

        If Me.clbRemoveRecipients.Items.Count = 0 Then
            Me.tblRemoveRecipients.Visible = False

        Else
            Me.tblRemoveRecipients.Visible = True

        End If

    End Sub
    Private Sub btnRemoveRecipients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveRecipients.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))





        For Each o As ListItem In Me.clbRemoveRecipients.Items
            If o.Selected Then
                Dim oCommandParameters(1) As SqlParameter
                oCommandParameters(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
                oCommandParameters(0).Value = o.Value
                oCommandParameters(1) = New SqlParameter("@inotify_recipient_id", SqlDbType.Int)
                oCommandParameters(1).Value = Session("RecipientID")

                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "del_xref_notify", _
                oCommandParameters)
            End If
        Next

        Response.Redirect("Main.aspx")
    End Sub

    Private Sub btnSearchRecipients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchRecipients.Click
        Me.lblPickExistingUser.Text = ""
        Me.lblInviteNewUser.Text = ""
        pnlEnterPrivateListPassword.Visible = False
        Me.hdnPrivateListRecipientID.Value = ""

        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
        oCommandParameter.Value = Me.tbEmail.Text
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
          "sel_recipient_by_email", _
         oCommandParameter)
        Me.pnlInvite.Visible = False

        If dsResult.Tables(0).Rows.Count = 0 Then
            Me.pnlInvite.Visible = True
            Me.hlInvite.Visible = True
            Me.lblInviteNewUser2a.Text = "Sorry, we could not find that email address in our system."
            Me.lblInviteNewUser2a.Visible = True
            Me.lblInviteNewUser2b.Text = " to send this person an email to invite them to join GiftLinkUp.com."
            Me.lblInviteNewUser2b.Visible = True

        Else
            If dsResult.Tables(0).Rows(0)("searchable_ind") = "N" Then
                Me.lblInviteNewUser.Text = "Sorry, we found that email address in our system, but the person has marked their list <font color=""red"">Private</font>."
                Me.pnlEnterPrivateListPassword.Visible = True
                Me.hdnPrivateListRecipientID.Value = dsResult.Tables(0).Rows(0)("recipient_id")
            Else
                Session("AddRecipientID") = dsResult.Tables(0).Rows(0)("recipient_id")
                Me.lblPickExistingUser.Text = "This person has a GiftLinkUp.com account.<br><a href=""add-recipient.aspx"">Click here</a> to add this person to your view."
            End If
        End If




    End Sub

    Protected Sub hlInvite_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles hlInvite.Click


        Dim mailServerName As String = "relay-hosting.secureserver.net"

        Dim sBody As String = Session("RecipientName") & " (" & Session("RecipientEmail") & ") would like to invite you to join GiftLinkUp.com." & vbCrLf & vbCrLf
        sBody = sBody & "GiftLinkUp.com is a site that makes holiday gift-giving easier. To learn more, please visit www.giftlinkup.com." & vbCrLf & vbCrLf
        sBody = sBody & "Thank you," & vbCrLf & "The GiftLinkUp.com Team"

        Dim message As MailMessage = New MailMessage("admin@giftlinkup.com", Me.tbEmail.Text, "Invitation from " & Session("RecipientName") & " to join GiftLinkUp.com", sBody)

        Dim mailClient As SmtpClient = New Smtpclient

        mailClient.Host = mailServerName

        mailClient.Port = 25

        mailClient.Send(message)

        message.Dispose()

        Me.pnlInvite.Visible = True
        Me.lblInviteNewUser2a.Text = "Thank you. We have sent an invitation to " & Me.tbEmail.Text & " to join GiftLinkUp.com."
        Me.lblInviteNewUser2b.Visible = False
        Me.hlInvite.Visible = False

    End Sub

    Protected Sub btnPrivateListPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrivateListPassword.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Me.hdnPrivateListRecipientID.Value
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
          "sel_recipient_by_id", _
         oCommandParameter)

        Dim CorrectPrivateListPassword As String = dsResult.Tables(0).Rows(0)("private_list_password")
        If Me.txtPrivateListPassword.Text <> CorrectPrivateListPassword Then
            Me.lblPrivateListPasswordResult.Text = "Sorry, that is not the correct password. Please try again."
        Else
            Me.pnlEnterPrivateListPassword.Visible = False


            Dim oCommandParameters(1) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
            oCommandParameters(0).Value = dsResult.Tables(0).Rows(0)("recipient_id")
            oCommandParameters(1) = New SqlParameter("@inotify_recipient_id", SqlDbType.Int)
            oCommandParameters(1).Value = Session("RecipientID")
            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_xref_recipient_notify", oCommandParameters)

            RefreshCheckboxList()
            Me.lblInviteNewUser.Text = "Thank you. " & dsResult.Tables(0).Rows(0)("name") & " has been added to your set of wish lists."
        End If
    End Sub
End Class
