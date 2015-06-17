Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.ApplicationBlocks.Data

Partial Class invite_givers
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
        Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Session("RecipientID")

        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, "sel_recipient_by_id", oCommandParameter)

        If dsResult.Tables(0).Rows(0)("searchable_ind") = "Y" Then
            Me.pnlIsPublic.Visible = True
            Me.pnlIsPrivate.Visible = False
            Me.lblEmail.Text = Session("RecipientEmail")
        Else
            Me.pnlIsPublic.Visible = False
            Me.pnlIsPrivate.Visible = True
        End If


    End Sub
End Class
