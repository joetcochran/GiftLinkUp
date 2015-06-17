
Partial Class create_group_step4
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Need to insert this user data
        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))
        Dim iOldArbitraryRecipientID As Integer

        For Each oRecipient As Recipient In CType(Session("GroupData"), Group).Recipients
            oRecipient.ConnectionString = SqlConn
            iOldArbitraryRecipientID = oRecipient.RecipientID

            'TODO: Before just running the insert, we should check to see if this email is already 
            'in the system.


            oRecipient.Insert()
            CType(Session("GroupData"), Group).MaintainRecipientIntegrity(iOldArbitraryRecipientID, oRecipient.RecipientID)

        Next

        For Each oRecipient As Recipient In CType(Session("GroupData"), Group).Recipients
            oRecipient.InsertProxies()
            oRecipient.InsertNotifyEmails()
        Next

    End Sub

End Class
