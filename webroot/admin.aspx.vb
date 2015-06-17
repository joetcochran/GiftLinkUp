Imports System.Data
Imports Microsoft.applicationblocks.Data
Imports System.Data.SqlClient


Partial Class admin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("RecipientID") <> (your admin user id) Then
            Response.Redirect("default.aspx")
        End If


    End Sub

    Protected Sub btnExecute_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Me.GridView1.DataSource = Nothing

        If Me.tbQuery.Text <> "" Then
            Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.Text, _
               Me.tbQuery.Text)

            Me.GridView1.DataSource = dsResult
            Me.GridView1.DataBind()
        Else
            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.Text, Me.tbNonQuery.Text)
        End If


    End Sub

    Protected Sub ddlCommonQueries_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCommonQueries.SelectedIndexChanged
        If Me.ddlCommonQueries.SelectedItem.Value = 1 Then
            Me.tbNonQuery.Text = ""
            Me.tbQuery.Text = "select top 100 r.name, a.* from activity_log a, recipient r where a.user_id = r.recipient_id order by activity_id desc "
        ElseIf Me.ddlCommonQueries.SelectedItem.Value = 2 Then
            Me.tbNonQuery.Text = ""
            Me.tbQuery.Text = "select top 10 * from recipient order by recipient_id desc"
        ElseIf Me.ddlCommonQueries.SelectedItem.Value = 3 Then
            Me.tbNonQuery.Text = ""
            Me.tbQuery.Text = "select top 10 * from gift order by gift_id desc"
        End If
    End Sub
End Class
