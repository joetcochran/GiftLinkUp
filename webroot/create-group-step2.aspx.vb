
Partial Class create_group_step2
    Inherits System.Web.UI.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not Page.IsPostBack Then

            CType(Me.Master, Standard).SetOnLoadJS("init();")

            If Not Session("GroupData") Is Nothing Then
                Dim i As Integer = 0
                For Each oRecipient As Recipient In CType(Session("GroupData"), Group).Recipients
                    If i = 0 Then
                        Me.lblName.Text = oRecipient.Name
                        Me.lblEmail.Text = oRecipient.Email
                    Else
                        If Me.tbName1.Text = "" Then : Me.tbName1.Text = oRecipient.Name : Me.tbEmail1.Text = oRecipient.Email
                        ElseIf Me.tbName2.Text = "" Then : Me.tbName2.Text = oRecipient.Name : Me.tbEmail2.Text = oRecipient.Email
                        ElseIf Me.tbName3.Text = "" Then : Me.tbName3.Text = oRecipient.Name : Me.tbEmail3.Text = oRecipient.Email
                        ElseIf Me.tbName4.Text = "" Then : Me.tbName4.Text = oRecipient.Name : Me.tbEmail4.Text = oRecipient.Email
                        ElseIf Me.tbName5.Text = "" Then : Me.tbName5.Text = oRecipient.Name : Me.tbEmail5.Text = oRecipient.Email
                        ElseIf Me.tbName6.Text = "" Then : Me.tbName6.Text = oRecipient.Name : Me.tbEmail6.Text = oRecipient.Email
                        ElseIf Me.tbName7.Text = "" Then : Me.tbName7.Text = oRecipient.Name : Me.tbEmail7.Text = oRecipient.Email
                        ElseIf Me.tbName8.Text = "" Then : Me.tbName8.Text = oRecipient.Name : Me.tbEmail8.Text = oRecipient.Email
                        ElseIf Me.tbName9.Text = "" Then : Me.tbName9.Text = oRecipient.Name : Me.tbEmail9.Text = oRecipient.Email
                        ElseIf Me.tbName10.Text = "" Then : Me.tbName10.Text = oRecipient.Name : Me.tbEmail10.Text = oRecipient.Email
                        ElseIf Me.tbName11.Text = "" Then : Me.tbName11.Text = oRecipient.Name : Me.tbEmail11.Text = oRecipient.Email
                        ElseIf Me.tbName12.Text = "" Then : Me.tbName12.Text = oRecipient.Name : Me.tbEmail12.Text = oRecipient.Email
                        ElseIf Me.tbName13.Text = "" Then : Me.tbName13.Text = oRecipient.Name : Me.tbEmail13.Text = oRecipient.Email
                        ElseIf Me.tbName14.Text = "" Then : Me.tbName14.Text = oRecipient.Name : Me.tbEmail14.Text = oRecipient.Email
                        ElseIf Me.tbName15.Text = "" Then : Me.tbName15.Text = oRecipient.Name : Me.tbEmail15.Text = oRecipient.Email
                        ElseIf Me.tbName16.Text = "" Then : Me.tbName16.Text = oRecipient.Name : Me.tbEmail16.Text = oRecipient.Email
                        ElseIf Me.tbName17.Text = "" Then : Me.tbName17.Text = oRecipient.Name : Me.tbEmail17.Text = oRecipient.Email
                        ElseIf Me.tbName18.Text = "" Then : Me.tbName18.Text = oRecipient.Name : Me.tbEmail18.Text = oRecipient.Email
                        ElseIf Me.tbName19.Text = "" Then : Me.tbName19.Text = oRecipient.Name : Me.tbEmail19.Text = oRecipient.Email
                        ElseIf Me.tbName20.Text = "" Then : Me.tbName20.Text = oRecipient.Name : Me.tbEmail20.Text = oRecipient.Email
                        ElseIf Me.tbName21.Text = "" Then : Me.tbName21.Text = oRecipient.Name : Me.tbEmail21.Text = oRecipient.Email
                        ElseIf Me.tbName22.Text = "" Then : Me.tbName22.Text = oRecipient.Name : Me.tbEmail22.Text = oRecipient.Email
                        ElseIf Me.tbName23.Text = "" Then : Me.tbName23.Text = oRecipient.Name : Me.tbEmail23.Text = oRecipient.Email
                        ElseIf Me.tbName24.Text = "" Then : Me.tbName24.Text = oRecipient.Name : Me.tbEmail24.Text = oRecipient.Email
                        ElseIf Me.tbName25.Text = "" Then : Me.tbName25.Text = oRecipient.Name : Me.tbEmail25.Text = oRecipient.Email : End If
                    End If
                    i = i + 1
                Next
            End If
        End If

        Me.tbName1.Attributes.Add("onblur", "bluractivity('1', '" & Me.tbName1.ClientID & "')")
        Me.tbName2.Attributes.Add("onblur", "bluractivity('2', '" & Me.tbName2.ClientID & "')")
        Me.tbName3.Attributes.Add("onblur", "bluractivity('3', '" & Me.tbName3.ClientID & "')")
        Me.tbName4.Attributes.Add("onblur", "bluractivity('4', '" & Me.tbName4.ClientID & "')")
        Me.tbName5.Attributes.Add("onblur", "bluractivity('5', '" & Me.tbName5.ClientID & "')")
        Me.tbName6.Attributes.Add("onblur", "bluractivity('6', '" & Me.tbName6.ClientID & "')")
        Me.tbName7.Attributes.Add("onblur", "bluractivity('7', '" & Me.tbName7.ClientID & "')")
        Me.tbName8.Attributes.Add("onblur", "bluractivity('8', '" & Me.tbName8.ClientID & "')")
        Me.tbName9.Attributes.Add("onblur", "bluractivity('9', '" & Me.tbName9.ClientID & "')")
        Me.tbName10.Attributes.Add("onblur", "bluractivity('10', '" & Me.tbName10.ClientID & "')")
        Me.tbName11.Attributes.Add("onblur", "bluractivity('11', '" & Me.tbName11.ClientID & "')")
        Me.tbName12.Attributes.Add("onblur", "bluractivity('12', '" & Me.tbName12.ClientID & "')")
        Me.tbName13.Attributes.Add("onblur", "bluractivity('13', '" & Me.tbName13.ClientID & "')")
        Me.tbName14.Attributes.Add("onblur", "bluractivity('14', '" & Me.tbName14.ClientID & "')")
        Me.tbName15.Attributes.Add("onblur", "bluractivity('15', '" & Me.tbName15.ClientID & "')")
        Me.tbName16.Attributes.Add("onblur", "bluractivity('16', '" & Me.tbName16.ClientID & "')")
        Me.tbName17.Attributes.Add("onblur", "bluractivity('17', '" & Me.tbName17.ClientID & "')")
        Me.tbName18.Attributes.Add("onblur", "bluractivity('18', '" & Me.tbName18.ClientID & "')")
        Me.tbName19.Attributes.Add("onblur", "bluractivity('19', '" & Me.tbName19.ClientID & "')")
        Me.tbName20.Attributes.Add("onblur", "bluractivity('20', '" & Me.tbName20.ClientID & "')")
        Me.tbName21.Attributes.Add("onblur", "bluractivity('21', '" & Me.tbName21.ClientID & "')")
        Me.tbName22.Attributes.Add("onblur", "bluractivity('22', '" & Me.tbName22.ClientID & "')")
        Me.tbName23.Attributes.Add("onblur", "bluractivity('23', '" & Me.tbName23.ClientID & "')")
        Me.tbName24.Attributes.Add("onblur", "bluractivity('24', '" & Me.tbName24.ClientID & "')")
        Me.tbName25.Attributes.Add("onblur", "bluractivity('25', '" & Me.tbName25.ClientID & "')")
    End Sub

    Private Sub TextBox21_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbName21.TextChanged

    End Sub

    Private Sub TextBox48_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEmail3.TextChanged

    End Sub

    Private Sub TextBox31_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbEmail20.TextChanged

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNext.Click

        If Page.IsValid Then

            Dim oGroup As Group = Session("GroupData")
            If Me.tbName1.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName1.Text, Me.tbEmail1.Text, "I"))
            If Me.tbName2.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName2.Text, Me.tbEmail2.Text, "I"))
            If Me.tbName3.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName3.Text, Me.tbEmail3.Text, "I"))
            If Me.tbName4.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName4.Text, Me.tbEmail4.Text, "I"))
            If Me.tbName5.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName5.Text, Me.tbEmail5.Text, "I"))
            If Me.tbName6.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName6.Text, Me.tbEmail6.Text, "I"))
            If Me.tbName7.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName7.Text, Me.tbEmail7.Text, "I"))
            If Me.tbName8.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName8.Text, Me.tbEmail8.Text, "I"))
            If Me.tbName9.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName9.Text, Me.tbEmail9.Text, "I"))
            If Me.tbName10.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName10.Text, Me.tbEmail10.Text, "I"))
            If Me.tbName11.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName11.Text, Me.tbEmail11.Text, "I"))
            If Me.tbName12.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName12.Text, Me.tbEmail12.Text, "I"))
            If Me.tbName13.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName13.Text, Me.tbEmail13.Text, "I"))
            If Me.tbName14.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName14.Text, Me.tbEmail14.Text, "I"))
            If Me.tbName15.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName15.Text, Me.tbEmail15.Text, "I"))
            If Me.tbName16.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName16.Text, Me.tbEmail16.Text, "I"))
            If Me.tbName17.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName17.Text, Me.tbEmail17.Text, "I"))
            If Me.tbName18.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName18.Text, Me.tbEmail18.Text, "I"))
            If Me.tbName19.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName19.Text, Me.tbEmail19.Text, "I"))
            If Me.tbName20.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName20.Text, Me.tbEmail20.Text, "I"))
            If Me.tbName21.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName21.Text, Me.tbEmail21.Text, "I"))
            If Me.tbName22.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName22.Text, Me.tbEmail22.Text, "I"))
            If Me.tbName23.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName23.Text, Me.tbEmail23.Text, "I"))
            If Me.tbName24.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName24.Text, Me.tbEmail24.Text, "I"))
            If Me.tbName25.Text <> "" Then oGroup.Recipients.Add(New Recipient(Me.tbName25.Text, Me.tbEmail25.Text, "I"))

            oGroup.AssignArbitraryRecipientIDs()

            Session("GroupData") = oGroup

            Response.Redirect("create-group-step3.aspx")
        End If

    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPrev.Click
        Response.Redirect("create-group-step1.aspx")
    End Sub

    Private Sub cvDuplicateNames_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvDuplicateNames.ServerValidate
        Dim DuplicateNames As String
        DuplicateNames = FoundDuplicateNames()
        If DuplicateNames <> "" Then
            cvDuplicateNames.ErrorMessage = "Duplicate names found: " & DuplicateNames & "<br>Please change these names to something unique (by adding a last name for example)."
            args.IsValid = False
        End If
    End Sub

    Private Function FoundDuplicateNames() As String
        Dim sAdminUser As String = Trim(UCase(CType(Session("GroupData"), Group).Recipients(0).Name))
        Dim sCheckingName As String
        Dim sRC As String = ""

        If sAdminUser = Me.tbName1.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName2.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName3.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName4.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName5.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName6.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName7.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName8.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName9.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName10.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName11.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName12.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName13.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName14.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName15.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName16.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName17.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName18.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName19.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName20.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName21.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName22.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName23.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName24.Text.Trim.ToUpper() Or _
        sAdminUser = Me.tbName25.Text.Trim.ToUpper() Then
            sRC = sAdminUser & ", "
        End If

        If Me.tbName1.Text <> "" Then
            sCheckingName = Me.tbName1.Text.Trim.ToUpper
            If sCheckingName = Me.tbName2.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName3.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName4.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName5.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName6.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName7.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName8.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName9.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName10.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName2.Text <> "" Then
            sCheckingName = Me.tbName2.Text.Trim.ToUpper
            If sCheckingName = Me.tbName3.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName4.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName5.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName6.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName7.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName8.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName9.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName10.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName3.Text <> "" Then
            sCheckingName = Me.tbName3.Text.Trim.ToUpper
            If sCheckingName = Me.tbName4.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName5.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName6.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName7.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName8.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName9.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName10.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName4.Text <> "" Then
            sCheckingName = Me.tbName4.Text.Trim.ToUpper
            If sCheckingName = Me.tbName5.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName6.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName7.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName8.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName9.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName10.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName5.Text <> "" Then
            sCheckingName = Me.tbName5.Text.Trim.ToUpper
            If sCheckingName = Me.tbName6.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName7.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName8.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName9.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName10.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName6.Text <> "" Then
            sCheckingName = Me.tbName6.Text.Trim.ToUpper
            If sCheckingName = Me.tbName7.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName8.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName9.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName10.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName7.Text <> "" Then
            sCheckingName = Me.tbName7.Text.Trim.ToUpper
            If sCheckingName = Me.tbName8.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName9.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName10.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName8.Text <> "" Then
            sCheckingName = Me.tbName8.Text.Trim.ToUpper
            If sCheckingName = Me.tbName9.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName10.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName9.Text <> "" Then
            sCheckingName = Me.tbName9.Text.Trim.ToUpper
            If sCheckingName = Me.tbName10.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName10.Text <> "" Then
            sCheckingName = Me.tbName10.Text.Trim.ToUpper
            If sCheckingName = Me.tbName11.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName11.Text <> "" Then
            sCheckingName = Me.tbName11.Text.Trim.ToUpper
            If sCheckingName = Me.tbName12.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName12.Text <> "" Then
            sCheckingName = Me.tbName12.Text.Trim.ToUpper
            If sCheckingName = Me.tbName13.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName13.Text <> "" Then
            sCheckingName = Me.tbName13.Text.Trim.ToUpper
            If sCheckingName = Me.tbName14.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName14.Text <> "" Then
            sCheckingName = Me.tbName14.Text.Trim.ToUpper
            If sCheckingName = Me.tbName15.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName15.Text <> "" Then
            sCheckingName = Me.tbName15.Text.Trim.ToUpper
            If sCheckingName = Me.tbName16.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName16.Text <> "" Then
            sCheckingName = Me.tbName16.Text.Trim.ToUpper
            If sCheckingName = Me.tbName17.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName17.Text <> "" Then
            sCheckingName = Me.tbName17.Text.Trim.ToUpper
            If sCheckingName = Me.tbName18.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName18.Text <> "" Then
            sCheckingName = Me.tbName18.Text.Trim.ToUpper
            If sCheckingName = Me.tbName19.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName19.Text <> "" Then
            sCheckingName = Me.tbName19.Text.Trim.ToUpper
            If sCheckingName = Me.tbName20.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName20.Text <> "" Then
            sCheckingName = Me.tbName20.Text.Trim.ToUpper
            If sCheckingName = Me.tbName21.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName21.Text <> "" Then
            sCheckingName = Me.tbName21.Text.Trim.ToUpper
            If sCheckingName = Me.tbName22.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName22.Text <> "" Then
            sCheckingName = Me.tbName22.Text.Trim.ToUpper
            If sCheckingName = Me.tbName23.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName23.Text <> "" Then
            sCheckingName = Me.tbName23.Text.Trim.ToUpper
            If sCheckingName = Me.tbName24.Text.Trim.ToUpper() Or _
            sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If Me.tbName24.Text <> "" Then
            sCheckingName = Me.tbName24.Text.Trim.ToUpper
            If sCheckingName = Me.tbName25.Text.Trim.ToUpper() Then
                sRC = sRC & sCheckingName & ", "
            End If
        End If

        If sRC <> "" Then
            sRC = Left(sRC, sRC.Length - 2)
        End If

        Return sRC
    End Function

    Private Sub cv1_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv1.ServerValidate
        If Me.tbName1.Text.Trim = "" And Me.tbEmail1.Text <> "" Then
            args.IsValid = False
            cv1.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail1.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail1.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv1.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv2_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv2.ServerValidate
        If Me.tbName2.Text.Trim = "" And Me.tbEmail2.Text <> "" Then
            args.IsValid = False
            cv2.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail2.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail2.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv2.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv3_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv3.ServerValidate
        If Me.tbName3.Text.Trim = "" And Me.tbEmail3.Text <> "" Then
            args.IsValid = False
            cv3.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail3.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail3.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv3.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv4_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv4.ServerValidate
        If Me.tbName4.Text.Trim = "" And Me.tbEmail4.Text <> "" Then
            args.IsValid = False
            cv4.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail4.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail4.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv4.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv5_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv5.ServerValidate
        If Me.tbName5.Text.Trim = "" And Me.tbEmail5.Text <> "" Then
            args.IsValid = False
            cv5.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail5.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail5.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv5.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv6_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv6.ServerValidate
        If Me.tbName6.Text.Trim = "" And Me.tbEmail6.Text <> "" Then
            args.IsValid = False
            cv6.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail6.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail6.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv6.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv7_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv7.ServerValidate
        If Me.tbName7.Text.Trim = "" And Me.tbEmail7.Text <> "" Then
            args.IsValid = False
            cv7.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail7.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail7.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv7.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv8_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv8.ServerValidate
        If Me.tbName8.Text.Trim = "" And Me.tbEmail8.Text <> "" Then
            args.IsValid = False
            cv8.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail8.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail8.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv8.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv9_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv9.ServerValidate
        If Me.tbName9.Text.Trim = "" And Me.tbEmail9.Text <> "" Then
            args.IsValid = False
            cv9.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail9.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail9.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv9.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv10_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv10.ServerValidate
        If Me.tbName10.Text.Trim = "" And Me.tbEmail10.Text <> "" Then
            args.IsValid = False
            cv10.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail10.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail10.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv10.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv11_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv11.ServerValidate
        If Me.tbName11.Text.Trim = "" And Me.tbEmail11.Text <> "" Then
            args.IsValid = False
            cv11.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail11.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail11.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv11.ErrorMessage = sRC
            End If
        End If
    End Sub
    Private Sub cv12_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv12.ServerValidate
        If Me.tbName12.Text.Trim = "" And Me.tbEmail12.Text <> "" Then
            args.IsValid = False
            cv12.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail12.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail12.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv12.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv13_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv13.ServerValidate
        If Me.tbName13.Text.Trim = "" And Me.tbEmail13.Text <> "" Then
            args.IsValid = False
            cv13.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail13.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail13.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv13.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv14_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv14.ServerValidate
        If Me.tbName14.Text.Trim = "" And Me.tbEmail14.Text <> "" Then
            args.IsValid = False
            cv14.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail14.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail14.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv14.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv15_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv15.ServerValidate
        If Me.tbName15.Text.Trim = "" And Me.tbEmail15.Text <> "" Then
            args.IsValid = False
            cv15.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail15.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail15.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv15.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv16_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv16.ServerValidate
        If Me.tbName16.Text.Trim = "" And Me.tbEmail16.Text <> "" Then
            args.IsValid = False
            cv16.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail16.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail16.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv16.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv17_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv17.ServerValidate
        If Me.tbName17.Text.Trim = "" And Me.tbEmail17.Text <> "" Then
            args.IsValid = False
            cv17.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail17.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail17.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv17.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv18_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv18.ServerValidate
        If Me.tbName18.Text.Trim = "" And Me.tbEmail18.Text <> "" Then
            args.IsValid = False
            cv18.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail18.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail18.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv18.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv19_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv19.ServerValidate
        If Me.tbName19.Text.Trim = "" And Me.tbEmail19.Text <> "" Then
            args.IsValid = False
            cv19.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail19.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail19.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv19.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv20_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv20.ServerValidate
        If Me.tbName20.Text.Trim = "" And Me.tbEmail20.Text <> "" Then
            args.IsValid = False
            cv20.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail20.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail20.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv20.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv21_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv21.ServerValidate
        If Me.tbName21.Text.Trim = "" And Me.tbEmail21.Text <> "" Then
            args.IsValid = False
            cv21.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail21.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail21.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv21.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv22_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv22.ServerValidate
        If Me.tbName22.Text.Trim = "" And Me.tbEmail22.Text <> "" Then
            args.IsValid = False
            cv22.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail22.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail22.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv22.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv23_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv23.ServerValidate
        If Me.tbName23.Text.Trim = "" And Me.tbEmail23.Text <> "" Then
            args.IsValid = False
            cv23.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail23.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail23.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv23.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv24_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv24.ServerValidate
        If Me.tbName24.Text.Trim = "" And Me.tbEmail24.Text <> "" Then
            args.IsValid = False
            cv24.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail24.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail24.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv24.ErrorMessage = sRC
            End If
        End If
    End Sub

    Private Sub cv25_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cv25.ServerValidate
        If Me.tbName25.Text.Trim = "" And Me.tbEmail25.Text <> "" Then
            args.IsValid = False
            cv25.ErrorMessage = "Please enter a name."
        ElseIf Me.tbEmail25.Text.Trim <> "" Then
            Dim sRC As String = ""
            Helper.ValidateEmail(Me.tbEmail25.Text, sRC)
            If sRC <> "" Then
                args.IsValid = False
                cv25.ErrorMessage = sRC
            End If
        End If
    End Sub


    Private Sub cvAtLeastOneOtherMember_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvAtLeastOneOtherMember.ServerValidate
        If Me.tbName1.Text.Trim = "" Then
            args.IsValid = False
            Me.cvAtLeastOneOtherMember.ErrorMessage = "Please enter at least one group member."
        End If
    End Sub


End Class
