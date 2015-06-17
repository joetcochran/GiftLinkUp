Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient

Partial Class OtherWishList
    Inherits System.Web.UI.UserControl


    Public ReadOnly Property ShowNotifications() As Boolean
        Get
            Return (Session("DisplayListNotifications") = "Y")
        End Get
    End Property
    Public Property RecipientName() As String
        Get
            Return ViewState("RecipientName")
        End Get
        Set(ByVal value As String)
            ViewState("RecipientName") = value
        End Set
    End Property

    Public Property RecipientID() As Integer
        Get
            Return ViewState("RecipientID")
        End Get
        Set(ByVal value As Integer)
            ViewState("RecipientID") = value
        End Set
    End Property
    Private Function Possessive(ByVal s As String) As String
        If Right(s, 1) = "s" Then
            Return s & "'"
        Else
            Return s & "'s"
        End If
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
    Protected Function GiftLabelVisible(ByVal URL As String) As Boolean
        Return (URL = "")
    End Function
    Protected Function GiftHyperlinkVisible(ByVal URL As String) As Boolean
        Return (URL <> "")
    End Function

    Protected Function CommentWrapper(ByVal s As Object) As String
        If IsDBNull(s) Then Return ""

        Return IIf(Trim(s) = "", s, "<br>(" & s & ")<br><br>")
    End Function
    Protected Sub NotifyGift(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Dim oGiftID As HiddenField = CType(sender.parent.parent, System.Web.UI.WebControls.GridViewRow).FindControl("hdnGiftID")
        Response.Redirect("announce.aspx?r=" & Me.RecipientID & "&g=" & oGiftID.Value)
    End Sub
    Protected Function StarVisible(ByVal StarNbr As Integer, ByVal Desire_lvl As Object) As Boolean
        If IsDBNull(Desire_lvl) Then
            Return False
        Else
            If Desire_lvl >= StarNbr Then Return True Else Return False
        End If
    End Function


    Protected Function Purchaser(ByVal s As Object) As String
        If IsDBNull(s) Then Return False
        Return "Purchased by " & s
    End Function
    Private Sub BindGrid()
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
        Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Me.RecipientID

        Dim dsWishList As DataSet
        dsWishList = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
         "sel_gifts_for_recipient", _
         oCommandParameter)

        Me.grdOtherWishList.DataSource = dsWishList
        Me.grdOtherWishList.DataBind()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Connect to DB, retrieve wish list items found for Session("RecipientID")
        'Bind data to the repeater control

        Me.lblOtherWishList.Text = Possessive(RecipientName) & " Wish List"
        Me.btnAnnounce.AlternateText = "Announce a gift purchase for " & RecipientName
        Me.btnShowHistory.AlternateText = "View the announcement history for " & RecipientName

        BindGrid()
        If Me.grdOtherWishList.Rows.Count = 0 Then
            Me.lblNoItems.Visible = True
        Else
            Me.lblNoItems.Visible = False
        End If

        Me.btnDelete.Attributes.Add("onclick", "return ConfirmOtherDelete()")
    End Sub

    Protected Sub btnShowHistory_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnShowHistory.Click
        Response.Redirect("announce-history.aspx?r=" & Me.RecipientID)
    End Sub

    Protected Sub btnAnnounce_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAnnounce.Click
        Response.Redirect("announce.aspx?r=" & Me.RecipientID)
    End Sub
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDelete.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))


        Dim oCommandParameters(1) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameters(0).Value = Me.RecipientID
        oCommandParameters(1) = New SqlParameter("@inotify_recipient_id", SqlDbType.Int)
        oCommandParameters(1).Value = Session("RecipientID")

        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "del_xref_notify", _
        oCommandParameters)
        Response.Redirect("main.aspx")
    End Sub
End Class
