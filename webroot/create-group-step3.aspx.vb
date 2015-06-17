
Partial Class setup_group_step3
    Inherits System.Web.UI.Page

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Find the first unprocessed recipient in the group

        If Not Page.IsPostBack Then


            Dim oRecipient As Recipient
            Dim oSubRecipient As Recipient
            Dim bProcessedOne As Boolean

            Me.tblNoEmail.Visible = False
            Me.cblNotifySelection.Items.Clear()
            Me.cblProxySelection.Items.Clear()
            Session("ThisRecipient") = Nothing

            With CType(Session("GroupData"), Group)
                For Each oRecipient In .Recipients
                    If oRecipient.NotifyEmails.Count = 0 Then                  'unprocessed
                        Session("ThisRecipient") = oRecipient
                        bProcessedOne = True

                        If oRecipient.Email = "" And oRecipient.Proxies.Count = 0 Then                       'unprocessed, in need of proxy
                            Me.tblNoEmail.Visible = True
                            Me.lblNoEmail.Text = Me.lblNoEmail.Text.Replace("(!person_name!)", oRecipient.Name)
                            Me.lblNotifyLabel.Text = Me.lblNotifyLabel.Text.Replace("(!person_name!)", oRecipient.Name)

                            For Each oRecipientNotify As Recipient In .AllRecipientsEligibleAsProxies
                                Me.cblNotifySelection.Items.Add(New System.Web.UI.WebControls.ListItem(oRecipientNotify.Name, oRecipientNotify.RecipientID))
                            Next

                            For Each oSubRecipient In .AllRecipientsEligibleAsProxies
                                Me.cblProxySelection.Items.Add(New System.Web.UI.WebControls.ListItem(oSubRecipient.Name, oSubRecipient.RecipientID))
                            Next
                            Exit For

                        Else                         'unprocessed, no need for proxy
                            Me.lblNotifyLabel.Text = Me.lblNotifyLabel.Text.Replace("(!person_name!)", oRecipient.Name)
                            For Each oRecipientNotify As Recipient In .AllRecipientsEligibleAsProxies
                                If orecipientnotify.RecipientID <> CType(Session("ThisRecipient"), Recipient).RecipientID Then
                                    Me.cblNotifySelection.Items.Add(New System.Web.UI.WebControls.ListItem(oRecipientNotify.Name, oRecipientNotify.RecipientID))
                                End If
                            Next
                            Exit For
                        End If

                    End If
                Next

                If Not bProcessedOne Then
                    'All done
                    Response.Redirect("create-group-step4.aspx")
                End If

            End With
        End If
    End Sub

    Private Sub imgNext_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNext.Click
        If Page.IsValid Then
            Dim oGroup As Group = Session("GroupData")
            For Each oRecipient As Recipient In oGroup.Recipients
                If oRecipient.RecipientID = CType(Session("ThisRecipient"), Recipient).RecipientID Then

                    For Each o As ListItem In Me.cblNotifySelection.Items
                        If o.Selected Then
                            oRecipient.AddNotifyEmail(oGroup.FindRecipientByID(o.Value).Email)
                        End If
                    Next

                    If Me.cblProxySelection.Visible Then
                        For Each o As ListItem In Me.cblProxySelection.Items
                            If o.Selected Then
                                oRecipient.AddProxy(oGroup.FindRecipientByID(o.Value).RecipientID)
                            End If
                        Next
                    End If
                    Exit For
                End If
            Next

            Session("GroupData") = oGroup
            Response.Redirect("create-group-step3.aspx")
        End If
    End Sub

    Private Sub cvGeneric_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvGeneric.ServerValidate
        Dim bFoundAtLeastOneGiver As Boolean = False
        Dim bFoundAtLeastOneProxy As Boolean = False

        cvGeneric.ErrorMessage = ""

        For Each o As ListItem In Me.cblNotifySelection.Items
            If o.Selected = True Then
                bFoundAtLeastOneGiver = True
                Exit For
            End If
        Next

        If Not bFoundAtLeastOneGiver Then
            cvGeneric.ErrorMessage = "Please select at least one person from the list who might give " & CType(Session("ThisRecipient"), Recipient).Name & " a gift."
        End If

        If Me.cblProxySelection.Visible = True Then
            For Each o As ListItem In Me.cblNotifySelection.Items
                If o.Selected = True Then
                    bFoundAtLeastOneProxy = True
                    Exit For
                End If
            Next

            If Not bFoundAtLeastOneProxy Then
                If cvGeneric.ErrorMessage = "" Then
                    cvGeneric.ErrorMessage = "Please select at least one person from the list who can act on behalf of " & CType(Session("ThisRecipient"), Recipient).Name & "."
                Else
                    cvGeneric.ErrorMessage = "Please select at least one person from the list who can act on behalf of " & CType(Session("ThisRecipient"), Recipient).Name & ".<br>" & cvGeneric.ErrorMessage
                End If

            End If

        End If

        If cvGeneric.ErrorMessage <> "" Then
            args.IsValid = False
        End If

    End Sub


End Class
