
Partial Class Standard
    Inherits System.Web.UI.MasterPage

    Protected Sub lbMainWishListPage_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbMainWishListPage.Click
        Response.Redirect("main.aspx")
    End Sub

    Protected Sub lbManageRecipients_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbFAQ.Click
        Response.Redirect("FAQ.aspx")
    End Sub

    Protected Sub lbAccountOptions_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAccountOptions.Click
        Response.Redirect("account-options.aspx")
    End Sub
    Public Sub SetOnLoadJS(ByVal script As String)
        Me.serverBody.Attributes.Add("onload", script)
    End Sub

    Protected Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLogout.Click
        Response.Redirect("logout.aspx")
    End Sub

    Protected Sub lbGenRSS_M_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbGenRSS_M.Click
        Response.Redirect("GenRSS.aspx?Type=M&recip=" & Session("RecipientGUID").ToString)
    End Sub

    Protected Sub lbGenRSS_O_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbGenRSS_O.Click
        Response.Redirect("GenRSS.aspx?Type=O&recip=" & Session("RecipientGUID").ToString)
    End Sub

    Protected Sub lbBlog_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbBlog.Click
        Response.Redirect("http://giftlinkup.wordpress.com")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.imgHeader.ImageUrl = "images/dn2_05" & ImageChooser() & ".jpg"
        If Session("RecipientID") Is Nothing Then
            Response.Redirect("default.aspx")
        End If

        If Session("RecipientID") = 82 Then
            Me.lbAdmin.Visible = True
        End If
    End Sub

    Private Function ImageChooser() As String
        Dim imgChooser As Integer = CInt(Now.ToOADate) Mod 300
        Select Case imgChooser
            Case 0 To 30
                Return "a"
            Case 31 To 60
                Return "b"
            Case 61 To 90
                Return "c"
            Case 91 To 120
                Return "d"
            Case 121 To 150
                Return "e"
            Case 151 To 180
                Return "f"
            Case 181 To 210
                Return "g"
            Case 211 To 240
                Return "h"
            Case 241 To 270
                Return "i"
            Case Else
                Return "j"
        End Select
    End Function

    Protected Sub lbComments_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbComments.Click
        Response.Redirect("comments-questions.aspx")
    End Sub

    Protected Sub lbAdmin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAdmin.Click
        Response.Redirect("admin.aspx")
    End Sub
End Class

