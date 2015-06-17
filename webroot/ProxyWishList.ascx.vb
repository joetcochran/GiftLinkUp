Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Net.mail

Partial Class ProxyWishList
    Inherits System.Web.UI.UserControl

    Public ReadOnly Property ShowNotifications() As Boolean
        Get
            Return (Session("DisplayListNotifications") = "Y")
        End Get
    End Property

    Protected Function GiftLabelVisible(ByVal URL As String) As Boolean
        Return (URL = "")
    End Function
    Protected Function GiftHyperlinkVisible(ByVal URL As String) As Boolean
        Return (URL <> "")
    End Function
    Protected Function AddCommentImageVisible(ByVal Comment As Object) As Boolean
        If IsDBNull(Comment) Then Return True

        Return (Trim(CStr(Comment)) = "")
    End Function
    Protected Function EditCommentImageVisible(ByVal Comment As Object) As Boolean
        If IsDBNull(Comment) Then Return False
        Return (Trim(CStr(Comment)) <> "")
    End Function

    Protected Function Purchaser(ByVal s As Object) As String
        If IsDBNull(s) Then Return False
        Return "Purchased by " & s
    End Function

    Protected Function PurchasedImageVisible(ByVal s As Object) As Boolean

        If Me.ShowNotifications = False Then
            Return False
        End If

        If IsDBNull(s) Then
            Return False
        Else
            Return True
        End If
    End Function
    Protected Function NotifyImageVisible(ByVal s As Object) As Boolean
        If Me.ShowNotifications = False Then
            Return True
        End If

        If IsDBNull(s) Then
            Return True
        Else
            Return False
        End If
    End Function
    'Private m_RecipientID As Integer
    'Private m_RecipientName As String

    Private Function Possessive(ByVal s As String) As String
        If Right(s, 1) = "s" Then
            Return s & "'"
        Else
            Return s & "'s"
        End If
    End Function
    Public Property RecipientName() As String
        Get
            Return ViewState("RecipientName")
            'Return m_RecipientName
        End Get
        Set(ByVal value As String)
            'm_RecipientName = value
            ViewState("RecipientName") = value
        End Set
    End Property
    Public Property RecipientID() As Integer
        Get
            'Return m_RecipientID
            Return ViewState("RecipientID")
        End Get
        Set(ByVal value As Integer)
            'm_RecipientID = value
            ViewState("RecipientID") = value
        End Set
    End Property

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub

    Protected Sub NotifyGift(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oGiftID As HiddenField = CType(sender.parent.parent, System.Web.UI.WebControls.GridViewRow).FindControl("hdnGiftID")
        Response.Redirect("announce.aspx?r=" & Me.RecipientID & "&g=" & oGiftID.Value)
    End Sub
    Protected Sub lbOpenComments_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        For Each oRow As GridViewRow In Me.grdProxyGifts.Rows
            oRow.FindControl("pnlProxyGiftComments").Visible = False
            oRow.FindControl("pnlCommands").Visible = False
        Next

        Dim oPanel As Panel = CType(sender.parent.parent, System.Web.UI.WebControls.DataControlFieldCell).FindControl("pnlProxyGiftComments")
        oPanel.Visible = True
        sender.visible = False


    End Sub
    Protected Sub btnProxyGiftCommentsCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oPanel As Panel = CType(sender.parent, Panel)
        oPanel.Visible = False
        Dim oCell As DataControlFieldCell = sender.parent.parent
        CType(oCell.FindControl("pnlCommands"), Panel).Visible = True
        For Each oRow As GridViewRow In Me.grdProxyGifts.Rows
            oRow.FindControl("pnlCommands").Visible = True
        Next
        BindGrid()

    End Sub
    Protected Sub btnProxyGiftCommentsAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oPanel As Panel = CType(sender.parent, Panel)
        oPanel.Visible = False
        Dim oCell As DataControlFieldCell = sender.parent.parent
        Dim oActionRow As GridViewRow = oCell.Parent

        Dim iGiftID As Integer = CType(oActionRow.FindControl("hdnGiftID"), HiddenField).Value
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameters(1) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@igift_id", SqlDbType.Int)
        oCommandParameters(0).Value = iGiftID
        oCommandParameters(1) = New SqlParameter("@vccomment", SqlDbType.VarChar, 8000)
        oCommandParameters(1).Value = CType(oCell.FindControl("txtProxyGiftComments"), TextBox).Text

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "upd_gift_comment", oCommandParameters)


        CType(oCell.FindControl("pnlCommands"), Panel).Visible = True
        For Each oRow As GridViewRow In Me.grdProxyGifts.Rows
            oRow.FindControl("pnlCommands").Visible = True
        Next
        BindGrid()
    End Sub
    Protected Sub ProxyGiftRating_Changed(ByVal sender As Object, ByVal e As AjaxControlToolkit.RatingEventArgs)

        Dim RatingSender As AjaxControlToolkit.Rating = sender


        Dim iDesireLvl As Integer = CInt(e.Value)
        Dim iGiftID As Integer = CInt(RatingSender.Tag)

        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameters(2) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@ngift_id", SqlDbType.Int)
        oCommandParameters(0).Value = iGiftID
        oCommandParameters(1) = New SqlParameter("@tidesire_lvl", SqlDbType.TinyInt)
        oCommandParameters(1).Value = iDesireLvl
        oCommandParameters(2) = New SqlParameter("@nupdating_recipient_id", SqlDbType.Int)
        oCommandParameters(2).Value = Me.RecipientID

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "upd_gift_desire_lvl", _
        oCommandParameters)

        RatingSender.CurrentRating = iDesireLvl


    End Sub

    Private Sub BindGrid()
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
        Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Me.RecipientID

        Dim dsWishList As DataSet
        dsWishList = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
         "sel_gifts_for_recipient", _
         oCommandParameter)


        Me.grdProxyGifts.DataSource = dsWishList
        Me.grdProxyGifts.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.lblProxyWishList.Text = Possessive(RecipientName) & " Wish List"
        Me.btnProxyAnnounce.AlternateText = "Announce a gift purchase for " & RecipientName
        Me.btnProxyShowHistory.AlternateText = "View the announcement history for " & RecipientName
        Me.lblProxyAddNew.Text = "Add an item to " & Possessive(RecipientName) & " wish list"


        If Not Page.IsPostBack Then
            Me.btnProxyDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the item(s) checked?');")
            BindGrid()
        End If

        If Me.grdProxyGifts.Rows.Count = 0 Then
            Me.lblNoItems.Visible = True
            Me.btnProxyDelete.Visible = False
        Else
            Me.lblNoItems.Visible = False
            Me.btnProxyDelete.Visible = True
        End If

        Me.btnDelete.Attributes.Add("onclick", "return ConfirmProxyDelete()")

    End Sub



    Protected Sub btnDelete_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDelete.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim RecipientToRemove As Integer
        RecipientToRemove = Me.RecipientID

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
    Protected Sub btnProxyAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProxyAdd.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        If Trim(Me.tbProxyNewURL.Text).Length <= 7 Then
            Dim oCommandParameters(1) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@nrecipient_id", SqlDbType.Int)
            oCommandParameters(0).Value = Me.RecipientID
            oCommandParameters(1) = New SqlParameter("@vcdescription", SqlDbType.VarChar, 255)
            oCommandParameters(1).Value = Me.tbProxyNewDescription.Text
            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_gift", _
                    oCommandParameters)
        Else
            Dim sURL As String

            If Left(Trim(Me.tbProxyNewURL.Text), 4) = "http" Then
                sURL = Trim(Me.tbProxyNewURL.Text)
            Else
                sURL = "http://" & Trim(Me.tbProxyNewURL.Text)
            End If

            sURL = Helper.InjectAffiliateInfo(sURL)

            Dim oCommandParameters(2) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@nrecipient_id", SqlDbType.Int)
            oCommandParameters(0).Value = Me.RecipientID
            oCommandParameters(1) = New SqlParameter("@vcdescription", SqlDbType.VarChar, 255)
            oCommandParameters(1).Value = Me.tbProxyNewDescription.Text
            oCommandParameters(2) = New SqlParameter("@vcurl", SqlDbType.VarChar, 8000)
            oCommandParameters(2).Value = sURL

            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_gift", _
                        oCommandParameters)

        End If
        BindGrid()

        If Me.grdProxyGifts.Rows.Count = 0 Then
            Me.lblNoItems.Visible = True
            Me.btnProxyDelete.Visible = False
        Else
            Me.lblNoItems.Visible = False
            Me.btnProxyDelete.Visible = True
        End If


    End Sub

    Protected Sub btnProxyDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProxyDelete.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        For Each oRow As GridViewRow In Me.grdProxyGifts.Rows
            If CType(oRow.FindControl("chkDelete"), CheckBox).Checked Then
                Dim iGiftID As Integer = CType(oRow.FindControl("hdnGiftID"), HiddenField).Value
                Dim oCommandParameter As New SqlParameter("@ngift_id", SqlDbType.Int)
                oCommandParameter.Value = iGiftID
                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "del_gift", oCommandParameter)
            End If
        Next
        BindGrid()

        If Me.grdProxyGifts.Rows.Count = 0 Then
            Me.lblNoItems.Visible = True
            Me.btnProxyDelete.Visible = False
        Else
            Me.lblNoItems.Visible = False
            Me.btnProxyDelete.Visible = True
        End If

    End Sub

    Protected Sub btnProxyShowHistory_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnProxyShowHistory.Click
        Response.Redirect("announce-history.aspx?r=" & Me.RecipientID)
    End Sub

    Protected Sub btnProxyAnnounce_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnProxyAnnounce.Click
        Response.Redirect("announce.aspx?r=" & Me.RecipientID)
    End Sub

    Protected Sub grdProxyGifts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdProxyGifts.RowCommand
        If e.CommandName = "CancelEdits" Then
            grdProxyGifts.EditIndex = -1
            BindGrid()
        ElseIf e.CommandName = "SaveEdits" Then
            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

            Dim gvrow As GridViewRow = CType(sender, GridView).Rows(CType(sender, GridView).EditIndex)


            Dim oCommandParameters(3) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@ngift_id", SqlDbType.Int)
            oCommandParameters(0).Value = CType(gvrow.FindControl("hdnGiftID"), HiddenField).Value
            oCommandParameters(1) = New SqlParameter("@nrecipient_id", SqlDbType.Int)
            oCommandParameters(1).Value = Me.RecipientID
            oCommandParameters(2) = New SqlParameter("@vcdescription", SqlDbType.VarChar, 255)
            oCommandParameters(2).Value = CType(gvrow.FindControl("txtDescription"), TextBox).Text
            oCommandParameters(3) = New SqlParameter("@vcurl", SqlDbType.VarChar, 8000)
            Dim sURL As String = CType(gvrow.FindControl("txtUrl"), TextBox).Text
            If sURL = "" Then
                oCommandParameters(3).Value = System.DBNull.Value
            Else
                If Left(Trim(sURL), 4) = "http" Then
                    sURL = Trim(sURL)
                Else
                    sURL = "http://" & Trim(sURL)
                End If

                sURL = Helper.InjectAffiliateInfo(sURL)

                oCommandParameters(3).Value = sURL
            End If


            If CType(gvrow.FindControl("txtDescription"), TextBox).Text.Trim <> "" Then
                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "upd_gift", _
                        oCommandParameters)
                grdProxyGifts.EditIndex = -1
            End If

            BindGrid()
        End If
    End Sub

    Protected Sub grdProxyGifts_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdProxyGifts.RowEditing
        Me.grdProxyGifts.EditIndex = e.NewEditIndex
        BindGrid()
    End Sub

    Protected Sub btnSharemanagement_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSharemanagement.Click
        Me.pnlSharemanagement.Visible = True


    End Sub

    Protected Sub btnShareManagementCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShareManagementCancel.Click
        Me.pnlSharemanagement.Visible = False

    End Sub

    Protected Sub btnShareManagementSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShareManagementSearch.Click
        'Search for the email address. A few results to catch

        '1) check email block table
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
        Dim oCommandParameters(1) As SqlParameter
        Dim cancelSharing As Boolean = False
        Dim isAlreadyAUser As Boolean = False

        oCommandParameters(0) = New SqlParameter("@email", SqlDbType.VarChar, 100)
        oCommandParameters(0).Value = Me.txtEmail.Text
        oCommandParameters(1) = New SqlParameter("@result", SqlDbType.Char, 1)
        oCommandParameters(1).Direction = ParameterDirection.Output
        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "sel_email_block", _
                oCommandParameters)
        If oCommandParameters(1).Value = "Y" Then
            'On email block list. inform user

            trSharemanagementFeedback.Visible = True
            Me.lblShareManagementFeedback.Text = "This user has chosen to block emails from GiftLinkUp."
            cancelSharing = True
        Else
            'continue with other checks.
            'check fuse action already outstanding


            If CheckFuseAction("SHARE") Or CheckFuseAction("NEWSH") Then
                'Already outstanding

                trSharemanagementFeedback.Visible = True
                Me.lblShareManagementFeedback.Text = "This user has already received a request to share management."
                cancelSharing = True
            Else
                'check already a proxy
                Dim oCommandParameter As SqlParameter
                oCommandParameter = New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
                oCommandParameter.Value = Me.txtEmail.Text
                Dim dsFindRecip As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, "sel_recipient_by_email", _
                                oCommandParameter)
                If dsFindRecip.Tables(0).Rows.Count <> 0 Then
                    'check to see if this is already a proxy
                    isAlreadyAUser = True
                    Dim oCommandParameter2 As SqlParameter
                    oCommandParameter2 = New SqlParameter("@irecipient_id", SqlDbType.Int)
                    oCommandParameter2.Value = dsFindRecip.Tables(0).Rows(0)("recipient_id")
                    Dim dsProxies As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, "sel_proxies_for_recipient", _
                                                    oCommandParameter2)
                    Dim foundProxy As Boolean = False
                    For Each oRow As DataRow In dsProxies.Tables(0).Rows
                        If oRow("recipient_id") = Me.RecipientID Then
                            foundProxy = True
                        End If
                    Next

                    If foundProxy = True Then
                        'Already a manager
                        trSharemanagementFeedback.Visible = True
                        Me.lblShareManagementFeedback.Text = "This user already has management control of this wish list."
                        cancelSharing = True
                    End If
                End If

            End If

        End If


        If Not cancelSharing Then

            Dim oCommandParameters3(4) As SqlParameter
            oCommandParameters3(0) = New SqlParameter("@caction_cd", SqlDbType.Char, 5)
            If isAlreadyAUser Then
                oCommandParameters3(0).Value = "SHARE"
            Else
                oCommandParameters3(0).Value = "NEWSH"
            End If
            oCommandParameters3(1) = New SqlParameter("@vctarget_email", SqlDbType.VarChar, 100)
            oCommandParameters3(1).Value = Me.txtEmail.Text
            oCommandParameters3(2) = New SqlParameter("@nrequester_id", SqlDbType.Int)
            oCommandParameters3(2).Value = Session("RecipientID")
            oCommandParameters3(3) = New SqlParameter("@fuse_key", SqlDbType.UniqueIdentifier)
            oCommandParameters3(3).Direction = ParameterDirection.Output
            oCommandParameters3(4) = New SqlParameter("@tag", SqlDbType.VarChar, 50)
            oCommandParameters3(4).Value = Me.RecipientID.ToString



            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
              "ins_fuse_action", _
              oCommandParameters3)

            If Not IsDBNull(oCommandParameters3(3).Value) Then
                If isAlreadyAUser Then

                    SendMail(Me.txtEmail.Text, "Request to share management of a wish list (" & Me.RecipientName & ")", GenerateShareManagement(oCommandParameters3(3).Value.ToString))

                Else

                    SendMail(Me.txtEmail.Text, Session("RecipientName") & " wants you to join!", GenerateInvitation(oCommandParameters3(3).Value.ToString))

                End If

            End If

            trSharemanagementFeedback.Visible = True
            Me.lblShareManagementFeedback.Text = "An email invitation has been sent."
            Me.trShareManagementSubmitStep1.Visible = True

            

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

    Private Function CheckFuseAction(ByVal ActionCode As String) As Boolean
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameters(3) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@email", SqlDbType.VarChar, 100)
        oCommandParameters(0).Value = Me.txtEmail.Text
        oCommandParameters(1) = New SqlParameter("@action_cd", SqlDbType.Char, 5)
        oCommandParameters(1).Value = ActionCode
        oCommandParameters(2) = New SqlParameter("@tag", SqlDbType.VarChar, 50)
        oCommandParameters(2).Value = Me.RecipientID
        oCommandParameters(3) = New SqlParameter("@result", SqlDbType.Char, 1)
        oCommandParameters(3).Direction = ParameterDirection.Output
        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "sel_fuse_action_oustanding", _
                        oCommandParameters)
        Return (oCommandParameters(3).Value = "Y")

    End Function

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


    Private Function GenerateShareManagement(ByVal fuseKey As String) As String

        Dim invitation As String = Session("RecipientName") & " wants to share management of " & Me.RecipientName & "'s wish list with you!" & vbCrLf & vbCrLf


        invitation = invitation & "What does this mean?" & vbCrLf
        invitation = invitation & Session("RecipientName") & " believes that you should share control over the items on " & Me.RecipientName & "'s wish list. Sharing management control over a wish list allows you to add, remove, and delete items from the list." & vbCrLf & vbCrLf

        invitation = invitation & "Simply click the link below, or copy it to the address bar of your browser and " & Me.RecipientName & "'s list will appear on your GiftLinkUp.com page. " & vbCrLf
        invitation = invitation & "http://www.giftlinkup.com/light-fuse.aspx?fuse_key=" & fuseKey & vbCrLf & vbCrLf

        invitation = invitation & "Happy Gift-Giving!" & vbCrLf
        invitation = invitation & "The GiftLinkUp.com team" & vbCrLf & vbCrLf & vbCrLf

        invitation = invitation & "To OPT OUT of future GiftLinkUp.com invitations, follow the link below." & vbCrLf
        invitation = invitation & "Opt Out: " & "http://www.giftlinkup.com/light-fuse.aspx?fuse_key=" & fuseKey & "&v=1"
        Return invitation

    End Function

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
