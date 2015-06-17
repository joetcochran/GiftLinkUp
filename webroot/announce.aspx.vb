Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Partial Class Announce
    Inherits System.Web.UI.Page


    Public TargetRecipientName As String
    Public TargetRecipientID As String



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
            Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
            oCommandParameter.Value = Session("RecipientID")

            Dim dsTargets As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
            "sel_viewable_lists_by_recipient", _
            oCommandParameter)

            Dim bFoundTarget As Boolean
            For Each oRow As DataRow In dsTargets.Tables(0).Rows
                If oRow("recipient_id") = Request.QueryString("r") Then
                    bFoundTarget = True
                    Me.TargetRecipientName = oRow("name")
                    Me.TargetRecipientID = oRow("recipient_id")
                    Exit For
                End If
            Next
            If Not bFoundTarget Then
                Response.Redirect("main.aspx")
            End If

            oCommandParameter = New SqlParameter("@irecipient_id", SqlDbType.Int)
            oCommandParameter.Value = Me.TargetRecipientID
            Dim oCommandParameter2 As New SqlParameter("@bunpurchased_only", SqlDbType.Bit)
            oCommandParameter2.Value = 1

            Dim dsWishList As DataSet
            dsWishList = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
             "sel_gifts_for_recipient", _
             oCommandParameter, oCommandParameter2)
            Me.cboGifts.Items.Clear()
            For Each oRow As DataRow In dsWishList.Tables(0).Rows
                Me.cboGifts.Items.Add(New ListItem(oRow("description"), oRow("gift_id")))
            Next

            Me.cboGifts.Items.Insert(0, New ListItem("(Optional) - Select an item from the list -", ""))

            If Me.cboGifts.Items.Count = 0 Then
                Me.cboGifts.Visible = False
            End If

            For Each item As ListItem In Me.cboGifts.Items
                If item.Value = Request.QueryString("g") Then
                    item.Selected = True
                    Exit For
                End If
            Next
        End If

    End Sub

    Protected Sub btnAnnounce_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAnnounce.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Session("RecipientID")
        Dim dsTargets As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
        "sel_viewable_lists_by_recipient", _
        oCommandParameter)

        Dim bFoundTarget As Boolean
        For Each oRow As DataRow In dsTargets.Tables(0).Rows
            If oRow("recipient_id") = Request.Form("target_recipient_id") Then
                bFoundTarget = True
                Exit For
            End If
        Next

        If Not bFoundTarget Then
            Response.Redirect("main.aspx")
        End If

        oCommandParameter = New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Request.Form("target_recipient_id") 
        dsTargets = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
        "sel_targets_for_recipient", _
        oCommandParameter)

        Dim GiftDescription As String = ""
        If Left(Me.cboGifts.SelectedItem.ToString, 10) <> "(Optional)" Then
            GiftDescription = Me.cboGifts.SelectedItem.ToString
        End If
        GiftDescription = GiftDescription & vbCrLf & Request.Form("description")

        For Each oRow As DataRow In dsTargets.Tables(0).Rows
            If Not IsDBNull(oRow("email")) Then

                Me.SendMail(oRow("email"), "Someone got a gift for " & oRow("recipient_name") & "!", "Someone got a gift for " & oRow("recipient_name") & ". Please see below for details." & vbCrLf & GiftDescription)

            End If
        Next


        Dim oCommandParameters(4) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@nrecipient_id", SqlDbType.Int)
        oCommandParameters(0).Value = Request.Form("target_recipient_id")


        oCommandParameters(1) = New SqlParameter("@nentered_by_id", SqlDbType.Int)
        oCommandParameters(1).Value = Session("RecipientID")


        oCommandParameters(2) = New SqlParameter("@vcdescription", SqlDbType.VarChar, 5000)
        oCommandParameters(2).Value = Request.Form("description")


        oCommandParameters(3) = New SqlParameter("@nnotification_id", SqlDbType.Int)
        oCommandParameters(3).Direction = ParameterDirection.Output



        oCommandParameters(4) = New SqlParameter("@ngift_id", SqlDbType.Int)
        If Me.cboGifts.SelectedValue = "" Then
            oCommandParameters(4).Value = System.DBNull.Value

        Else
            oCommandParameters(4).Value = Me.cboGifts.SelectedValue

        End If


        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_notification", _
        oCommandParameters)


        Response.Redirect("announce-history.aspx?r=" & Request.Form("target_recipient_id"))


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
End Class
