Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web
Imports System.Xml
Imports Microsoft.ApplicationBlocks.Data
Imports System.Net.Mail


Partial Class response
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim RequestGUID As String = Request.QueryString("r")

        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@request_guid", SqlDbType.UniqueIdentifier)
        oCommandParameter.Value = New System.Guid(Request.QueryString("r"))

        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
        "sel_recipient_request", _
        oCommandParameter)

        If dsResult.Tables(0).Rows.Count = 0 Then
            Me.lblFailure.Visible = True
            Exit Sub
        End If

        With dsResult.Tables(0).Rows(0)
            If .Item("request_typ") = "S" Then
                Dim sChildsName As String
                Dim sRequestersEmail As String
                Dim sRequesteesEmail As String

                Dim oRecipCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
                oRecipCommandParameter.Value = CInt(.Item("additional_info"))

                Dim dsRecipientInfo As DataSet
                dsRecipientInfo = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
                         "sel_recipient_by_id", _
                         oRecipCommandParameter)

                Dim oRecipCommandParameter2 As New SqlParameter("@irecipient_id", SqlDbType.Int)
                oRecipCommandParameter.Value = CInt(.Item("from_recipient_id"))

                Dim dsRecipientInfo2 As DataSet
                dsRecipientInfo2 = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
                         "sel_recipient_by_id", _
                         oRecipCommandParameter)

                sRequestersEmail = dsRecipientInfo2.Tables(0).Rows(0)("email")

                Dim oRecipCommandParameter3 As New SqlParameter("@irecipient_id", SqlDbType.Int)
                oRecipCommandParameter.Value = CInt(.Item("to_recipient_id"))

                Dim dsRecipientInfo3 As DataSet
                dsRecipientInfo3 = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
                         "sel_recipient_by_id", _
                         oRecipCommandParameter)
                sRequesteesEmail = dsRecipientInfo2.Tables(0).Rows(0)("email")


                sChildsName = dsRecipientInfo.Tables(0).Rows(0)("name")

                Dim oCommandParameters2(1) As SqlParameter
                oCommandParameters2(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
                oCommandParameters2(0).Value = .Item("additional_info")
                oCommandParameters2(1) = New SqlParameter("@iproxy_for_id", SqlDbType.Int)
                oCommandParameters2(1).Value = .Item("to_recipient_id")

                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
                  "ins_xref_recipient_proxy", _
                  oCommandParameters2)


                Dim oCommandParameters3(1) As SqlParameter
                oCommandParameters3(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
                oCommandParameters3(0).Value = .Item("additional_info")
                oCommandParameters3(1) = New SqlParameter("@inotify_recipient_id", SqlDbType.Int)
                oCommandParameters3(1).Value = .Item("to_recipient_id")

                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
                  "ins_xref_recipient_notify", _
                  oCommandParameters3)


                Me.lblSuccess.Text.Replace("[**MESSAGE**]", sChildsName & " has been added to your wish lists that you can manage. Please <a href=""http://www.giftlinkup.com/default.aspx"">log in</a> to the site to list some items!")
                Me.lblSuccess.Visible = True


                Dim mailServerName As String = "relay-hosting.secureserver.net"
                Dim message As MailMessage = New MailMessage("admin@giftlinkup.com", sRequestersEmail, "Your Request to Share Management for " & sChildsName & " was accepted", _
                "A fellow user of GiftLinkUp.com (" & sRequesteesEmail & ") accepted your request to share management control " & _
                "over the wish list belonging to " & sChildsName & ". He/She will be able to add and remove items from this wish list." & _
                vbCrLf & vbCrLf & "Thank you for using GiftLinkUp.com!" & vbCrLf & vbCrLf & "The GiftLinkUp.com Team")
                Dim mailClient As SmtpClient = New Smtpclient
                mailClient.Host = mailServerName
                mailClient.Port = 25
                mailClient.Send(message)
                message.Dispose()

            End If

        End With

    End Sub
End Class
