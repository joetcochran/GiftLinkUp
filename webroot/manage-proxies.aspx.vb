Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web
Imports System.Xml
Imports Microsoft.ApplicationBlocks.Data
Imports System.Net.Mail


Partial Class manage_proxies
    Inherits System.Web.UI.Page

    Protected Sub btnCreateProxy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateProxy.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        lblNameErr.visible = False
        If Trim(tbNewProxy.Text) = "" Then
            lblNameErr.visible = True
            Exit Sub
        End If


        Dim oCommandParameters(3) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@vcname", SqlDbType.VarChar, 50)
        oCommandParameters(0).Value = Me.tbNewProxy.Text
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


        Response.Redirect("main.aspx")

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then


            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

            Me.lblEmailSent.Visible = False

            Me.btnRemoveList.Attributes.Add("onclick", "return confirm('Are you sure you want to remove this wish list?')")
            Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
            oCommandParameter.Value = Session("RecipientID")
            Dim dsResults As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
                      "sel_proxies_for_recipient", _
                      oCommandParameter)

            Dim bAnyFound As Boolean = False
            For Each oRow As DataRow In dsResults.Tables(0).Rows
                Me.rblProxies.Items.Add(New ListItem(oRow("name"), oRow("recipient_id")))
                Me.rblProxiesRemove.Items.Add(New ListItem(oRow("name"), oRow("recipient_id")))
                bAnyFound = True
            Next

            If bAnyFound Then
                Me.rblProxies.Visible = True
                Me.rblProxiesRemove.Visible = True
                Me.lblNoProxies.Visible = False
                Me.lblNoProxiesRemove.Visible = False
                Me.rblProxies.Items(0).Selected = True
                Me.rblProxiesRemove.Items(0).Selected = True
            Else
                Me.rblProxies.Visible = False
                Me.lblNoProxies.Visible = True
                Me.rblProxiesRemove.Visible = False
                Me.lblNoProxiesRemove.Visible = True
            End If
        End If
    End Sub

    Protected Sub btnRemoveList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveList.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim RecipientToRemove As Integer
        RecipientToRemove = Me.rblProxiesRemove.SelectedItem.Value

        Dim oCommandParameters(1) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameters(0).Value = RecipientToRemove
        oCommandParameters(1) = New SqlParameter("@iaction_performed_by_id", SqlDbType.Int)
        oCommandParameters(1).Value = Session("RecipientID")

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
                  "del_proxy", _
                  oCommandParameters)

        Response.Redirect("main.aspx")

    End Sub

    Protected Sub btnAssociateProxy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAssociateProxy.Click
        'First check to see if the email belongs to a current GiftLinkUp.com user
        'if not, notify the user, and don't send.
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
        oCommandParameter.Value = Me.tbAssociateProxyEmail.Text
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
          "sel_recipient_by_email", _
          oCommandParameter)

        Dim bUserExists As Boolean
        Dim iToRecipientID As Integer
        If dsResult.Tables(0).Rows.Count <> 0 Then
            bUserExists = True
            iToRecipientID = dsResult.Tables(0).Rows(0)("recipient_id")
        End If

        If Not bUserExists Then
            Me.lblNoSuchUser.Visible = True
            Exit Sub
        Else
            Me.lblNoSuchUser.Visible = False
        End If

        Dim sAcceptURL As String

        Dim oCommandParameters(4) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@crequest_typ", SqlDbType.Char, 1)
        oCommandParameters(0).Value = "S"
        oCommandParameters(1) = New SqlParameter("@ifrom_recipient_id", SqlDbType.Int)
        oCommandParameters(1).Value = Session("RecipientID")
        oCommandParameters(2) = New SqlParameter("@ito_recipient_id", SqlDbType.Int)
        oCommandParameters(2).Value = iToRecipientID
        oCommandParameters(3) = New SqlParameter("@request_guid", SqlDbType.UniqueIdentifier)
        oCommandParameters(3).Direction = ParameterDirection.Output
        oCommandParameters(4) = New SqlParameter("@vcadditional_info", SqlDbType.VarChar, 50)
        oCommandParameters(4).Value = Me.rblProxies.SelectedItem.Value

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
                  "ins_recipient_request", _
                  oCommandParameters)

        sAcceptURL = "http://www.giftlinkup.com/response.aspx?r=" & oCommandParameters(3).Value.ToString()



        Dim mailServerName As String = "relay-hosting.secureserver.net"
        Dim message As MailMessage = New MailMessage("admin@giftlinkup.com", Me.tbAssociateProxyEmail.Text, "Request from GiftLinkUp.com", _
        "A fellow user of GiftLinkUp.com (" & Session("RecipientName") & "/" & Session("RecipientEmail") & ") would " & _
        "like you to share management of a wish list belonging to " & Me.rblProxies.SelectedItem.Text & "." & _
        vbCrLf & vbCrLf & "If you wish to accept this request, please click the link below. If you wish to decline this request, there is no need to " & _
        "take any action. " & vbCrLf & vbCrLf & vbCrLf & "To accept the request, please click the link below." & vbCrLf & _
        sAcceptURL & vbCrLf & vbCrLf & _
        "Thank you for using GiftLinkUp.com!" & vbCrLf & vbCrLf & "The GiftLinkUp.com Team")
        Dim mailClient As SmtpClient = New Smtpclient
        mailClient.Host = mailServerName
        mailClient.Port = 25
        mailClient.Send(message)
        message.Dispose()

        Me.lblEmailSent.visible = True



    End Sub
End Class
