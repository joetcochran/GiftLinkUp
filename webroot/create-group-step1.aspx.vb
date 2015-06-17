Imports Microsoft.ApplicationBlocks.Data
Imports System.Data
Imports System.Data.SqlClient

Partial Class create_group_step1
    Inherits System.Web.UI.Page


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then
            Dim oGroup As Group
            If Not Session("GroupData") Is Nothing Then
                oGroup = Session("GroupData")
                With CType(oGroup.Recipients(0), Recipient)
                    Me.tbEmail.Text = .Email
                    Me.tbName.Text = .Name
                    Me.tbPassword.Text = .Password
                    Me.tbPasswordConfirm.Text = .Password
                End With
            End If
        End If
    End Sub

    Private Sub cvEmail_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvEmail.ServerValidate
        'Check for existence, validity
        Dim Result As String = ""
        Me.cvEmail.ErrorMessage = ""
        If Not Helper.ValidateEmail(Me.tbEmail.Text, Result) Then
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



    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Me.IsValid Then
            Dim oGroup As New Group

            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
            oGroup.ConnectionString = SqlConn

            Dim oRecipient As New Recipient("I")
            oRecipient.ConnectionString = SqlConn
            oRecipient.Email = Me.tbEmail.Text
            oRecipient.Name = Me.tbName.Text
            oRecipient.Password = Me.tbPassword.Text
            oRecipient.GroupID = 0
            oGroup.Recipients.Add(oRecipient)

            Session("GroupData") = oGroup

            Response.Redirect("create-group-step2.aspx")
        End If

    End Sub
End Class
