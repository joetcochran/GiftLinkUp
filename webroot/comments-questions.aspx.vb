
Partial Class comments_questions
    Inherits System.Web.UI.Page

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Helper.SendMail("your email", "GiftLinkUp.com Feedback", Me.txtFeedback.Text & vbCrLf & vbCrLf & "Email: " & Me.txtEmail.Text)

        lblUserInfo.Text = "Thank you for your feedback. "
        If Session("RecipientID") Is Nothing Then
            lblUserInfo.Text = lblUserInfo.Text & "<a href=""default.aspx"">Click here</a> to return to the login page."
        Else
            lblUserInfo.Text = lblUserInfo.Text & "<a href=""main.aspx"">Click here</a> to return to the site."
        End If
        Me.btnSubmit.Visible = False
    End Sub
End Class
