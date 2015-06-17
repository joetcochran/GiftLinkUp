
Partial Class block_givers
    Inherits System.Web.UI.Page

    Protected Sub lbHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbHome.Click
        Response.Redirect("main.aspx")
    End Sub
End Class
