Imports Microsoft.ApplicationBlocks.Data

Partial Class GenericAPI
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case Request.QueryString("Type")
            Case "1"
                Dim WebConfig As New AppSettingsReader
                Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
                Response.Write(SqlHelper.ExecuteScalar(SqlConn, Data.CommandType.Text, "select max(activity_id) from activity_log"))
        End Select
    End Sub
End Class
