Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data
Imports System.Net.Mail
Partial Class new_recipient
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim NotifyEmailID As Integer

        With CType(Session("UserData"), Recipient)

            Dim o2CommandParameters(3) As SqlParameter
            o2CommandParameters(0) = New SqlParameter("@vcname", SqlDbType.VarChar, 50)
            o2CommandParameters(0).Value = .Name
            o2CommandParameters(1) = New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
            o2CommandParameters(1).Value = .Email
            o2CommandParameters(2) = New SqlParameter("@vcpassword", SqlDbType.VarChar, 20)
            o2CommandParameters(2).Value = .Password
            o2CommandParameters(3) = New SqlParameter("@irecipient_id", SqlDbType.Int)
            o2CommandParameters(3).Direction = ParameterDirection.Output
            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_recipient", _
              o2CommandParameters)
            NotifyEmailID = o2CommandParameters(3).Value

            For Each Email As String In .NotifyEmails

                Dim oCommandParameter2 As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
                oCommandParameter2.Value = Email
                Dim dsResult2 As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
                  "sel_recipient_by_email", _
                  oCommandParameter2)

                If dsResult2.Tables(0).Rows.Count = 0 Then
                    Dim mailServerName As String = "relay-hosting.secureserver.net"
                    Dim message As MailMessage = New MailMessage("admin@giftlinkup.com", _
                    Email, _
                    "You have been invited by " & .Name & " to join GiftLinkUp.com!", _
                    .Name & " has provided your email address to us as someone who might want to sign up for " & _
                    "GiftLinkUp.com. GiftLinkUp.com is a site that lets you manage wish lists and automatically " & _
                    "sends out email notifications when gifts are purchased." & vbCrLf & vbCrLf & "Please feel free " & _
                    "to visit our site at www.giftlinkup.com to take a tour." & vbCrLf & vbCrLf & "Thank you," & vbCrLf & "The GiftLinkUp.com Team")
                    Dim mailClient As SmtpClient = New SmtpClient
                    mailClient.Host = mailServerName
                    mailClient.Port = 25
                    mailClient.Send(message)
                    message.Dispose()

                End If

            Next


            Dim oCommandParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
            oCommandParameter.Value = .Email
            Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
              "sel_recipient_by_email", _
              oCommandParameter)

            If dsResult.Tables(0).Rows.Count <> 0 Then

                Session("RecipientID") = dsResult.Tables(0).Rows(0)("recipient_id")
                Session("RecipientGUID") = dsResult.Tables(0).Rows(0)("rss_guid")
                Session("RecipientName") = dsResult.Tables(0).Rows(0)("name")
                Session("RecipientEmail") = dsResult.Tables(0).Rows(0)("email")
                Response.Redirect("main.aspx")
                Exit Sub

            End If

        End With

    End Sub
End Class
