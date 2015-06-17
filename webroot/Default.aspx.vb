Imports System.Data
Imports Microsoft.applicationblocks.Data
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page
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
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
        oCommandParameter.Value = Me.tbEmail.Text
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
          "sel_recipient_by_email", _
          oCommandParameter)

        If dsResult.Tables(0).Rows.Count <> 0 Then
            If dsResult.Tables(0).Rows(0)("password") = Me.tbPassword.Text Then
                Session("RecipientID") = dsResult.Tables(0).Rows(0)("recipient_id")
                Session("RecipientGUID") = dsResult.Tables(0).Rows(0)("rss_guid")
                Session("RecipientName") = dsResult.Tables(0).Rows(0)("name")
                Session("RecipientEmail") = dsResult.Tables(0).Rows(0)("email")
                Session("DisplayListNotifications") = "Y"

                LogActivity(dsResult.Tables(0).Rows(0)("recipient_id"), "Logged In")

                Response.Redirect("main.aspx")
                Exit Sub
            End If
        End If

        Me.lblLoginErr.Text = "Invalid Login. Please try again."
        Me.lblLoginErr.Visible = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.tbEmail.Focus()
    End Sub

    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCreate.Click
        Response.Redirect("create-single-step1.aspx")
    End Sub

    Protected Sub btnFaq_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFaq.Click
        Response.Redirect("faq.aspx")
    End Sub

    Protected Sub btnTour_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnTour.Click
        Response.Redirect("tour.aspx")
    End Sub
End Class
