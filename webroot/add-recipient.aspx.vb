Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Imports System.Data

Partial Class add_recipient
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
        Dim oCommandParameters(1) As SqlParameter
        oCommandParameters(0) = New SqlParameter("@irecipient_id", Data.SqlDbType.Int)
        oCommandParameters(0).Value = Session("AddRecipientID")
        oCommandParameters(1) = New SqlParameter("@inotify_recipient_id", Data.SqlDbType.Int)
        oCommandParameters(1).Value = Session("RecipientID")


        SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, "ins_xref_recipient_notify", _
        oCommandParameters)

        Session("AddRecipientID") = ""
        Response.Redirect("main.aspx")

    End Sub
End Class
