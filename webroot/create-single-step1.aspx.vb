Imports Microsoft.ApplicationBlocks.Data
Imports System.Data
Imports System.Data.SqlClient
Partial Class create_single_step1
    Inherits System.Web.UI.Page


    Private Sub cvEmail_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvEmail.ServerValidate
        'Check for existence, validity
        Dim Result As String = ""


        Me.cvEmail.ErrorMessage = ""
        If Not helper.ValidateEmail(Me.tbEmail.Text, Result) Then
            args.IsValid = False
            Me.cvEmail.ErrorMessage = Result
        End If


        'Check database see if username already exists
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
        oCommandParameter.Value = Me.tbEmail.Text

        Dim ScalarResult As Object = SqlHelper.ExecuteScalar(SqlConn, CommandType.StoredProcedure, _
          "sel_recipient_by_email", _
         oCommandParameter)
        If Not ScalarResult Is Nothing Then
            cvEmail.ErrorMessage = "This email address already exists in the system."
            args.IsValid = False
        End If

    End Sub
    Private Sub cvName_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvName.ServerValidate
        Me.cvName.ErrorMessage = ""
        If Trim(Me.tbName.Text).Length = 0 Then
            Me.cvName.ErrorMessage = "Please enter a name."
            args.IsValid = False
        End If
    End Sub

    Private Sub cvPassword_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvPassword.ServerValidate
        Me.cvPassword.ErrorMessage = ""
        If Trim(Me.tbPassword.Text).Length < 4 Then
            Me.cvPassword.ErrorMessage = "Please enter a password, at least 4 characters long."
            args.IsValid = False
        End If
    End Sub

    Private Sub cvPasswordConfirm_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvPasswordConfirm.ServerValidate
        Me.cvPasswordConfirm.ErrorMessage = ""
        If Trim(Me.tbPassword.Text) <> Trim(Me.tbPasswordConfirm.Text) Then
            Me.cvPasswordConfirm.ErrorMessage = "Passwords do not match. Please try again."
            args.IsValid = False
        End If

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            Dim oRecipient As Recipient
            If Not Session("UserData") Is Nothing Then
                oRecipient = Session("UserData")
                Me.tbEmail.Text = oRecipient.Email
                Me.tbName.Text = oRecipient.Name
                Me.tbPassword.Text = oRecipient.Password
                Me.tbPasswordConfirm.Text = oRecipient.Password
            End If
        End If
    End Sub


    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim oRecipient As Recipient
        If Me.IsValid Then
            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

            If IsNothing(Session("UserData")) Then
                oRecipient = New Recipient("I")
            Else
                oRecipient = Session("UserData")
            End If

            oRecipient.ConnectionString = SqlConn
            oRecipient.Email = Me.tbEmail.Text
            oRecipient.Name = Me.tbName.Text
            oRecipient.Password = Me.tbPassword.Text


            Session("UserData") = oRecipient
            Response.Redirect("new-recipient.aspx")
        End If




    End Sub
End Class
