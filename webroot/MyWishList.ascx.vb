Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Partial Class MyWishList
    Inherits System.Web.UI.UserControl
    Protected Function GiftLabelVisible(ByVal URL As String) As Boolean
        Return (URL = "")
    End Function
    Protected Function GiftHyperlinkVisible(ByVal URL As String) As Boolean
        Return (URL <> "")
    End Function
    Protected Function EditCommentImageVisible(ByVal Comment As Object) As Boolean
        If IsDBNull(Comment) Then Return False

        Return (Trim(CStr(Comment)) <> "")
    End Function
    Protected Function AddCommentImageVisible(ByVal Comment As Object) As Boolean
        If IsDBNull(Comment) Then Return True

        Return (Trim(CStr(Comment)) = "")
    End Function
    Private _showFacebookControls As Boolean

    Public Property ShowFacebookControls() As Boolean
        Get
            Return _showFacebookControls
        End Get
        Set(ByVal value As Boolean)
            _showFacebookControls = value
        End Set
    End Property
    Public Sub SetProfilePic(ByVal imageURL As String)
        Me.imgFacebookProfilePic.ImageUrl = imageURL
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Connect to DB, retrieve wish list items found for Session("RecipientID")
        'Bind data to the repeater control

        If Not Page.IsPostBack Then
            Me.btnDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete the item(s) checked?');")
            BindGrid()
        End If

        Me.imgFacebookProfilePic.Visible = Me.ShowFacebookControls
        
    End Sub

    Private Sub BindGrid()
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
        Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Session("RecipientID")

        Dim dsMyWishList As DataSet
        dsMyWishList = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
         "sel_gifts_for_recipient", _
         oCommandParameter)
        Me.grdMyGifts.DataSource = dsMyWishList
        Me.grdMyGifts.DataBind()

        If Me.grdMyGifts.Rows.Count = 0 Then
            Me.lblNoItems.Visible = True
            Me.btnDelete.Visible = False
        Else
            Me.lblNoItems.Visible = False
            Me.btnDelete.Visible = True
        End If

    End Sub
    Protected Sub btnMyAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMyAdd.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        If Trim(Me.tbMyNewURL.Text).Length <= 7 Then
            Dim oCommandParameters(1) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@nrecipient_id", SqlDbType.Int)
            oCommandParameters(0).Value = Session("RecipientID")
            oCommandParameters(1) = New SqlParameter("@vcdescription", SqlDbType.VarChar, 255)
            oCommandParameters(1).Value = Me.tbMyNewDescription.Text
            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_gift", _
                    oCommandParameters)
        Else
            Dim sURL As String

            If Left(Trim(Me.tbMyNewURL.Text), 4) = "http" Then
                sURL = Trim(Me.tbMyNewURL.Text)
            Else
                sURL = "http://" & Trim(Me.tbMyNewURL.Text)
            End If


            If sURL.ToLower.Contains("amazon.com/") Then
                sURL = Helper.ConvertAmazonLink(sURL)
            ElseIf sURL.ToLower.Contains("walmart.com/") Then
                sURL = Helper.ConvertWalmartLink(sURL)
            ElseIf sURL.ToLower.Contains("lillianvernon.com/") Then
                sURL = Helper.ConvertLillianVernonLink(sURL)
            End If

            Dim oCommandParameters(2) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@nrecipient_id", SqlDbType.Int)
            oCommandParameters(0).Value = Session("RecipientID")
            oCommandParameters(1) = New SqlParameter("@vcdescription", SqlDbType.VarChar, 255)
            oCommandParameters(1).Value = Me.tbMyNewDescription.Text
            oCommandParameters(2) = New SqlParameter("@vcurl", SqlDbType.VarChar, 8000)
            oCommandParameters(2).Value = sURL

            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_gift", _
                        oCommandParameters)

        End If
        BindGrid()
    End Sub

    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        For Each oRow As GridViewRow In Me.grdMyGifts.Rows
            If CType(oRow.FindControl("chkDelete"), CheckBox).Checked Then
                Dim iGiftID As Integer = CType(oRow.FindControl("hdnGiftID"), HiddenField).Value
                Dim oCommandParameter As New SqlParameter("@ngift_id", SqlDbType.Int)
                oCommandParameter.Value = iGiftID
                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "del_gift", oCommandParameter)
            End If
        Next
        BindGrid()
    End Sub

    Protected Sub lbOpenComments_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        For Each oRow As GridViewRow In Me.grdMyGifts.Rows
            oRow.FindControl("pnlMyGiftComments").Visible = False
            oRow.FindControl("pnlCommands").Visible = False
        Next

        Dim oPanel As Panel = CType(sender.parent.parent, System.Web.UI.WebControls.DataControlFieldCell).FindControl("pnlMyGiftComments")
        oPanel.Visible = True
        sender.visible = False


    End Sub
    Protected Sub btnMyGiftCommentsCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim oPanel As Panel = CType(sender.parent, Panel)
        oPanel.Visible = False
        Dim oCell As DataControlFieldCell = sender.parent.parent
        CType(oCell.FindControl("pnlCommands"), Panel).Visible = True

        BindGrid()

    End Sub
    Protected Sub btnMyGiftCommentsAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs)
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
        oCommandParameters(1).Value = CType(oCell.FindControl("txtMyGiftComments"), TextBox).Text

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "upd_gift_comment", oCommandParameters)


        BindGrid()
    End Sub
    Protected Sub MyGiftRating_Changed(ByVal sender As Object, ByVal e As AjaxControlToolkit.RatingEventArgs)

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
        oCommandParameters(2).Value = Session("RecipientID")

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "upd_gift_desire_lvl", _
        oCommandParameters)

        RatingSender.CurrentRating = iDesireLvl


    End Sub

    Protected Sub grdMyGifts_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdMyGifts.RowCommand
        If e.CommandName = "CancelEdits" Then
            grdMyGifts.EditIndex = -1
            BindGrid()
        ElseIf e.CommandName = "SaveEdits" Then
            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

            Dim gvrow As GridViewRow = CType(sender, GridView).Rows(CType(sender, GridView).EditIndex)


            Dim oCommandParameters(3) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@ngift_id", SqlDbType.Int)
            oCommandParameters(0).Value = CType(gvrow.FindControl("hdnGiftID"), HiddenField).Value
            oCommandParameters(1) = New SqlParameter("@nrecipient_id", SqlDbType.Int)
            oCommandParameters(1).Value = Session("RecipientID")
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


                If sURL.ToLower.Contains("amazon.com/") Then
                    sURL = Helper.ConvertAmazonLink(sURL)
                ElseIf sURL.ToLower.Contains("walmart.com/") Then
                    sURL = Helper.ConvertWalmartLink(sURL)
                ElseIf sURL.ToLower.Contains("lillianvernon.com/") Then
                    sURL = Helper.ConvertLillianVernonLink(sURL)
                End If

                oCommandParameters(3).Value = sURL
            End If


            If CType(gvrow.FindControl("txtDescription"), TextBox).Text.Trim <> "" Then
                SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "upd_gift", _
                        oCommandParameters)
                grdMyGifts.EditIndex = -1
            End If

            BindGrid()
        End If
    End Sub

    Protected Sub grdMyGifts_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles grdMyGifts.RowEditing
        Me.grdMyGifts.EditIndex = e.NewEditIndex
        BindGrid()
    End Sub
End Class
