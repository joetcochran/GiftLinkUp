
Partial Class create_single_step2
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim oRecipient As Recipient
        oRecipient = Session("UserData")

        Me.lblEmail.Text = oRecipient.Email
        Me.lblName.Text = oRecipient.Name

        RenderJavascript()
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "InitCall", "<script language=""javascript"">init();</script>")


        If Not Page.IsPostBack Then
            'stupid mans approach to reflection...
            With CType(Session("UserData"), Recipient)
                For Each sEmail As String In .NotifyEmails
                    If Me.tbEmail1.Text = "" Then : Me.tbEmail1.Text = sEmail
                    ElseIf Me.tbEmail2.Text = "" Then : Me.tbEmail2.Text = sEmail
                    ElseIf Me.tbEmail3.Text = "" Then : Me.tbEmail3.Text = sEmail
                    ElseIf Me.tbEmail4.Text = "" Then : Me.tbEmail4.Text = sEmail
                    ElseIf Me.tbEmail5.Text = "" Then : Me.tbEmail5.Text = sEmail
                    ElseIf Me.tbEmail6.Text = "" Then : Me.tbEmail6.Text = sEmail
                    ElseIf Me.tbEmail7.Text = "" Then : Me.tbEmail7.Text = sEmail
                    ElseIf Me.tbEmail8.Text = "" Then : Me.tbEmail8.Text = sEmail
                    ElseIf Me.tbEmail9.Text = "" Then : Me.tbEmail9.Text = sEmail
                    ElseIf Me.tbEmail10.Text = "" Then : Me.tbEmail10.Text = sEmail
                    ElseIf Me.tbEmail11.Text = "" Then : Me.tbEmail11.Text = sEmail
                    ElseIf Me.tbEmail12.Text = "" Then : Me.tbEmail12.Text = sEmail
                    ElseIf Me.tbEmail13.Text = "" Then : Me.tbEmail13.Text = sEmail
                    ElseIf Me.tbEmail14.Text = "" Then : Me.tbEmail14.Text = sEmail
                    ElseIf Me.tbEmail15.Text = "" Then : Me.tbEmail15.Text = sEmail
                    ElseIf Me.tbEmail16.Text = "" Then : Me.tbEmail16.Text = sEmail
                    ElseIf Me.tbEmail17.Text = "" Then : Me.tbEmail17.Text = sEmail
                    ElseIf Me.tbEmail18.Text = "" Then : Me.tbEmail18.Text = sEmail
                    ElseIf Me.tbEmail19.Text = "" Then : Me.tbEmail19.Text = sEmail
                    ElseIf Me.tbEmail20.Text = "" Then : Me.tbEmail20.Text = sEmail
                    ElseIf Me.tbEmail21.Text = "" Then : Me.tbEmail21.Text = sEmail
                    ElseIf Me.tbEmail22.Text = "" Then : Me.tbEmail22.Text = sEmail
                    ElseIf Me.tbEmail23.Text = "" Then : Me.tbEmail23.Text = sEmail
                    ElseIf Me.tbEmail24.Text = "" Then : Me.tbEmail24.Text = sEmail
                    ElseIf Me.tbEmail25.Text = "" Then : Me.tbEmail25.Text = sEmail
                    End If
                Next
            End With
        End If

        'Need to populate the objects because the user might be using the previous/next buttons.
        Me.tbEmail1.Attributes.Add("onkeydown", "bluractivity('1')")
        Me.tbEmail2.Attributes.Add("onkeydown", "bluractivity('2')")
        Me.tbEmail3.Attributes.Add("onkeydown", "bluractivity('3')")
        Me.tbEmail4.Attributes.Add("onkeydown", "bluractivity('4')")
        Me.tbEmail5.Attributes.Add("onkeydown", "bluractivity('5')")
        Me.tbEmail6.Attributes.Add("onkeydown", "bluractivity('6')")
        Me.tbEmail7.Attributes.Add("onkeydown", "bluractivity('7')")
        Me.tbEmail8.Attributes.Add("onkeydown", "bluractivity('8')")
        Me.tbEmail9.Attributes.Add("onkeydown", "bluractivity('9')")
        Me.tbEmail10.Attributes.Add("onkeydown", "bluractivity('10')")
        Me.tbEmail11.Attributes.Add("onkeydown", "bluractivity('11')")
        Me.tbEmail12.Attributes.Add("onkeydown", "bluractivity('12')")
        Me.tbEmail13.Attributes.Add("onkeydown", "bluractivity('13')")
        Me.tbEmail14.Attributes.Add("onkeydown", "bluractivity('14')")
        Me.tbEmail15.Attributes.Add("onkeydown", "bluractivity('15')")
        Me.tbEmail16.Attributes.Add("onkeydown", "bluractivity('16')")
        Me.tbEmail17.Attributes.Add("onkeydown", "bluractivity('17')")
        Me.tbEmail18.Attributes.Add("onkeydown", "bluractivity('18')")
        Me.tbEmail19.Attributes.Add("onkeydown", "bluractivity('19')")
        Me.tbEmail20.Attributes.Add("onkeydown", "bluractivity('20')")
        Me.tbEmail21.Attributes.Add("onkeydown", "bluractivity('21')")
        Me.tbEmail22.Attributes.Add("onkeydown", "bluractivity('22')")
        Me.tbEmail23.Attributes.Add("onkeydown", "bluractivity('23')")
        Me.tbEmail24.Attributes.Add("onkeydown", "bluractivity('24')")
        Me.tbEmail25.Attributes.Add("onkeydown", "bluractivity('25')")


    End Sub

    Private Sub RenderJavascript()
        Dim JS As String = ""
        JS = JS + "function init() "
        JS = JS + "{" & vbCrLf
        JS = JS + "$(Email1).value = 'hi there';" & vbCrLf
        JS = JS + "	}" & vbCrLf
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "Init", "<script type=""text/javascript"">" & JS & "</script>")
    End Sub



    Private Sub SaveEmails()
        With CType(Session("UserData"), Recipient)
            .NotifyEmails.Clear()
            If Me.tbEmail1.Text <> "" Then .AddNotifyEmail(Me.tbEmail1.Text)
            If Me.tbEmail2.Text <> "" Then .AddNotifyEmail(Me.tbEmail2.Text)
            If Me.tbEmail3.Text <> "" Then .AddNotifyEmail(Me.tbEmail3.Text)
            If Me.tbEmail4.Text <> "" Then .AddNotifyEmail(Me.tbEmail4.Text)
            If Me.tbEmail5.Text <> "" Then .AddNotifyEmail(Me.tbEmail5.Text)
            If Me.tbEmail6.Text <> "" Then .AddNotifyEmail(Me.tbEmail6.Text)
            If Me.tbEmail7.Text <> "" Then .AddNotifyEmail(Me.tbEmail7.Text)
            If Me.tbEmail8.Text <> "" Then .AddNotifyEmail(Me.tbEmail8.Text)
            If Me.tbEmail9.Text <> "" Then .AddNotifyEmail(Me.tbEmail9.Text)
            If Me.tbEmail10.Text <> "" Then .AddNotifyEmail(Me.tbEmail10.Text)
            If Me.tbEmail11.Text <> "" Then .AddNotifyEmail(Me.tbEmail11.Text)
            If Me.tbEmail12.Text <> "" Then .AddNotifyEmail(Me.tbEmail12.Text)
            If Me.tbEmail13.Text <> "" Then .AddNotifyEmail(Me.tbEmail13.Text)
            If Me.tbEmail14.Text <> "" Then .AddNotifyEmail(Me.tbEmail14.Text)
            If Me.tbEmail15.Text <> "" Then .AddNotifyEmail(Me.tbEmail15.Text)
            If Me.tbEmail16.Text <> "" Then .AddNotifyEmail(Me.tbEmail16.Text)
            If Me.tbEmail17.Text <> "" Then .AddNotifyEmail(Me.tbEmail17.Text)
            If Me.tbEmail18.Text <> "" Then .AddNotifyEmail(Me.tbEmail18.Text)
            If Me.tbEmail19.Text <> "" Then .AddNotifyEmail(Me.tbEmail19.Text)
            If Me.tbEmail20.Text <> "" Then .AddNotifyEmail(Me.tbEmail20.Text)
            If Me.tbEmail21.Text <> "" Then .AddNotifyEmail(Me.tbEmail21.Text)
            If Me.tbEmail22.Text <> "" Then .AddNotifyEmail(Me.tbEmail22.Text)
            If Me.tbEmail23.Text <> "" Then .AddNotifyEmail(Me.tbEmail23.Text)
            If Me.tbEmail24.Text <> "" Then .AddNotifyEmail(Me.tbEmail24.Text)
            If Me.tbEmail25.Text <> "" Then .AddNotifyEmail(Me.tbEmail25.Text)
        End With


    End Sub


    Private Sub cv1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv1.ServerValidate
        If GenericEmailValidator(Me.tbEmail1, Me.cv1) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv2.ServerValidate
        If GenericEmailValidator(Me.tbEmail2, Me.cv2) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv3_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv3.ServerValidate
        If GenericEmailValidator(Me.tbEmail3, Me.cv3) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv4_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv4.ServerValidate
        If GenericEmailValidator(Me.tbEmail4, Me.cv4) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv5_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv5.ServerValidate
        If GenericEmailValidator(Me.tbEmail5, Me.cv5) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv6_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv6.ServerValidate
        If GenericEmailValidator(Me.tbEmail6, Me.cv6) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv7_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv7.ServerValidate
        If GenericEmailValidator(Me.tbEmail7, Me.cv7) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv8_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv8.ServerValidate
        If GenericEmailValidator(Me.tbEmail8, Me.cv8) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv9_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv9.ServerValidate
        If GenericEmailValidator(Me.tbEmail9, Me.cv9) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv10_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv10.ServerValidate
        If GenericEmailValidator(Me.tbEmail10, Me.cv10) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv11_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv11.ServerValidate
        If GenericEmailValidator(Me.tbEmail11, Me.cv11) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv12_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv12.ServerValidate
        If GenericEmailValidator(Me.tbEmail12, Me.cv12) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv13_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv13.ServerValidate
        If GenericEmailValidator(Me.tbEmail13, Me.cv13) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv14_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv14.ServerValidate
        If GenericEmailValidator(Me.tbEmail14, Me.cv14) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv15_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv15.ServerValidate
        If GenericEmailValidator(Me.tbEmail15, Me.cv15) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv16_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv16.ServerValidate
        If GenericEmailValidator(Me.tbEmail16, Me.cv16) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv17_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv17.ServerValidate
        If GenericEmailValidator(Me.tbEmail17, Me.cv17) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv18_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv18.ServerValidate
        If GenericEmailValidator(Me.tbEmail18, Me.cv18) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv19_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv19.ServerValidate
        If GenericEmailValidator(Me.tbEmail19, Me.cv19) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv20_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv20.ServerValidate
        If GenericEmailValidator(Me.tbEmail20, Me.cv20) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv21_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv21.ServerValidate
        If GenericEmailValidator(Me.tbEmail21, Me.cv21) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv22_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv22.ServerValidate
        If GenericEmailValidator(Me.tbEmail22, Me.cv22) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv23_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv23.ServerValidate
        If GenericEmailValidator(Me.tbEmail23, Me.cv23) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv24_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv24.ServerValidate
        If GenericEmailValidator(Me.tbEmail24, Me.cv24) <> "" Then args.IsValid = False
    End Sub
    Private Sub cv25_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv25.ServerValidate
        If GenericEmailValidator(Me.tbEmail25, Me.cv25) <> "" Then args.IsValid = False
    End Sub



    Private Function GenericEmailValidator(ByVal tb As System.Web.UI.WebControls.TextBox, ByVal cv As System.Web.UI.WebControls.CustomValidator) As String
        If tb.Text = "" Then
            Return ""
        Else
            Dim sResult As String = ""
            Helper.ValidateEmail(tb.Text, sResult)
            If sResult <> "" Then
                cv.ErrorMessage = sResult
            End If
            Return sResult
        End If
    End Function


    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Page.IsValid Then
            SaveEmails()
            Response.Redirect("new-recipient.aspx")
        End If
    End Sub
End Class
