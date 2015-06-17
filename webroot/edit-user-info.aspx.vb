Imports System.Data
Imports Microsoft.ApplicationBlocks.Data
Imports System.Data.SqlClient
Partial Class edit_user_info
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
            Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
            oCommandParameter.Value = Session("RecipientID")

            Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, "sel_recipient_by_id", oCommandParameter)
            Dim dsChallengeQuestions As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, "sel_challenge_questions")
            Me.cboChallengeQuestion.DataSource = dsChallengeQuestions
            Me.cboChallengeQuestion.DataBind()

            For Each oRow As DataRow In dsResult.Tables(0).Rows
                Me.tbName.Text = oRow("name")
                Me.tbEmail.Text = oRow("email")
                If oRow("searchable_ind") = "N" Then
                    Me.optPrivate.Checked = True
                    Me.optPublic.Checked = False
                    Me.txtPrivateListPassword.Text = oRow("private_list_password")
                    Me.pnlPrivateListPassword.Visible = True
                Else
                    Me.optPrivate.Checked = False
                    Me.optPublic.Checked = True
                    Me.txtPrivateListPassword.Text = ""
                End If


                If Not IsDBNull(oRow("challenge_question_id")) Then
                    Me.cboChallengeQuestion.SelectedValue = oRow("challenge_question_id")
                    Me.txtChallengeAnswer.Text = oRow("challenge_answer")
                End If
            Next

            


        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Validate (custom validators)
        If Page.IsValid Then
            Dim WebConfig As New AppSettingsReader
            Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

            Dim sPasswordToUse As String = Me.tbCurrentPassword.Text
            If Me.tbPassword.text <> "" Then
                sPasswordToUse = Me.tbPassword.Text
            End If
            Dim oCommandParameters(7) As SqlParameter
            oCommandParameters(0) = New SqlParameter("@nrecipient_id", SqlDbType.Int)
            oCommandParameters(0).Value = Session("RecipientID")
            oCommandParameters(1) = New SqlParameter("@vcname", SqlDbType.VarChar, 50)
            oCommandParameters(1).Value = Me.tbName.Text
            oCommandParameters(2) = New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
            oCommandParameters(2).Value = Me.tbEmail.Text
            oCommandParameters(3) = New SqlParameter("@csearchable_ind", SqlDbType.Char, 1)
            oCommandParameters(3).Value = IIf(Me.optPublic.Checked, "Y", "N")
            oCommandParameters(4) = New SqlParameter("@vcpassword", SqlDbType.VarChar, 20)
            oCommandParameters(4).Value = sPasswordToUse
            oCommandParameters(5) = New SqlParameter("@nchallenge_question_id", SqlDbType.Int)
            oCommandParameters(5).Value = Me.cboChallengeQuestion.SelectedValue
            oCommandParameters(6) = New SqlParameter("@vcchallenge_answer", SqlDbType.VarChar, 50)
            oCommandParameters(6).Value = Me.txtChallengeAnswer.Text
            oCommandParameters(7) = New SqlParameter("@vcprivate_list_password", SqlDbType.VarChar, 50)
            If Me.optPrivate.Checked Then
                oCommandParameters(7).Value = Me.txtPrivateListPassword.Text
            Else
                oCommandParameters(7).Value = System.DBNull.Value
            End If


            SqlHelper.ExecuteNonQuery(SqlConn, CommandType.StoredProcedure, _
                                         "upd_recipient", _
                                          oCommandParameters)


            Me.lblSuccess.Visible = True




        End If
    End Sub

    Private Sub cvName_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvName.ServerValidate
        Me.cvName.ErrorMessage = ""
        If Trim(Me.tbName.Text).Length = 0 Then
            Me.cvName.ErrorMessage = "<br>Please enter a name."
            args.IsValid = False
        End If
    End Sub

    Private Sub cvEmail_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvEmail.ServerValidate
        'Validate
        Dim Result As String = ""
        Me.cvEmail.ErrorMessage = ""
        If Not Helper.ValidateEmail(Me.tbEmail.Text, Result) Then
            args.IsValid = False
            Me.cvEmail.ErrorMessage = "<br>" & Result
        End If

        'Check database see if username already exists
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@vcemail", SqlDbType.VarChar, 250)
        oCommandParameter.Value = Me.tbEmail.Text
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
          "sel_recipient_by_email", _
         oCommandParameter)
        If dsResult.Tables(0).Rows.Count <> 0 Then
            If dsResult.Tables(0).Rows(0)("recipient_id") <> Session("RecipientID") Then
                cvEmail.ErrorMessage = "<br>This email address already exists in the system."
                args.IsValid = False
            End If
        End If

    End Sub

    Private Sub cvPassword_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvPassword.ServerValidate

        Me.cvPassword.ErrorMessage = ""
        If Me.tbPassword.Text <> "" And Me.tbPasswordConfirm.Text <> "" Then
            If Trim(Me.tbPassword.Text).Length < 4 Then
                Me.cvPassword.ErrorMessage = "<br>Please enter a password, at least 4 characters long."
                args.IsValid = False
            End If
        End If

    End Sub

    Private Sub cvConfirmPassword_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs)
        Me.cvPasswordConfirm.ErrorMessage = ""
        If Me.tbPassword.Text <> "" And Me.tbPasswordConfirm.Text <> "" Then
            If Trim(Me.tbPassword.Text) <> Trim(Me.tbPasswordConfirm.Text) Then
                Me.cvPasswordConfirm.ErrorMessage = "<br>Passwords do not match. Please try again."
                args.IsValid = False
            End If
        End If
    End Sub

    Private Sub cvCurrentPassword_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvCurrentPassword.ServerValidate
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))

        Dim oCommandParameter As New SqlParameter("@irecipient_id", SqlDbType.Int)
        oCommandParameter.Value = Session("RecipientID")

        Me.cvCurrentPassword.ErrorMessage = ""
        Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, "sel_recipient_by_id", oCommandParameter)
        If dsResult.Tables(0).Rows(0)("password") <> Me.tbCurrentPassword.Text Then
            Me.cvCurrentPassword.ErrorMessage = "<br>Current Password is incorrect. Please try again."
            args.IsValid = False

        End If

    End Sub

    Protected Sub cvAnswer_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvAnswer.ServerValidate
        If Me.txtChallengeAnswer.Text.Trim = "" Then
            Me.cvAnswer.ErrorMessage = "Please enter an answer."
            args.IsValid = False
        End If
    End Sub

    Protected Sub optPrivate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optPrivate.CheckedChanged
        If Me.optPrivate.Checked Then
            Me.pnlPrivateListPassword.Visible = True
        Else
            Me.pnlPrivateListPassword.Visible = False
        End If
    End Sub

    Protected Sub optPublic_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles optPublic.CheckedChanged
        If Me.optPrivate.Checked Then
            Me.pnlPrivateListPassword.Visible = True
        Else
            Me.pnlPrivateListPassword.Visible = False
        End If
    End Sub

    Protected Sub cvPrivateListPassword_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvPrivateListPassword.ServerValidate
        If Me.optPrivate.Checked Then
            If Me.txtPrivateListPassword.Text.Trim = "" Then
                Me.cvPrivateListPassword.ErrorMessage = "Please enter a Private List Password."
                args.IsValid = False
            End If
        End If
    End Sub
End Class
