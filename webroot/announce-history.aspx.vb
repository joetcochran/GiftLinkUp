
Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Partial Class announce_history
    Inherits System.Web.UI.Page

    Public TargetRecipientName As String
    Public TargetRecipientID As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Put user code to initialize the page here
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

            Dim o2CommandParameter As New SqlParameter("@nrecipient_id", SqlDbType.Int)
            o2CommandParameter.Value = Me.TargetRecipientID

            Dim dsNotifications As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
            "sel_notifications_by_recipient", _
            o2CommandParameter)

            Me.dgNotificationHistory.DataSource = dsNotifications.Tables(0)
            Me.dgNotificationHistory.DataBind()

            If Me.dgNotificationHistory.Rows.Count = 0 Then
                Me.lblNoNotifications.Visible = True
            End If

        End If


    End Sub
End Class
