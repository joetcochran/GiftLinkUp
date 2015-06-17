Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web
Imports System.Xml
Imports Microsoft.ApplicationBlocks.Data



Partial Class GenRSS
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim WebConfig As New AppSettingsReader
        Dim SqlConn As String = WebConfig.GetValue("dbConn", GetType(String))


        If Request.QueryString("Type") = "O" Then


            Dim oCommandParameter As New SqlParameter("@guid", SqlDbType.UniqueIdentifier)
            oCommandParameter.Value = New System.Guid(Request.QueryString("recip"))

            Dim dsResult As DataSet = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
              "sel_gifts_for_others_rss", _
              oCommandParameter)

            Response.Clear()
            Response.ContentType = "application/rss+xml"
            Dim objX As New XmlTextWriter(Response.OutputStream, Encoding.UTF8)
            objX.WriteStartDocument()
            objX.WriteStartElement("rss")
            objX.WriteAttributeString("version", "2.0")
            objX.WriteStartElement("channel")
            objX.WriteElementString("title", "GiftLinkUp.com - Lists I'm Watching")
            objX.WriteElementString("link", "http://www.giftlinkup.com")
            objX.WriteElementString("description", "gift-giving made easier.")
            objX.WriteElementString("ttl", "5")
            For Each oRow As datarow In dsresult.tables(0).rows


                objX.WriteStartElement("item")
                If orow("type") = "G" Then
                    objX.WriteElementString("title", "Gift for " & oRow("name") & " posted")
                ElseIf orow("type") = "N" Then
                    objX.WriteElementString("title", "Notification for " & oRow("name") & " posted")
                End If

                objX.WriteElementString("description", CStr(orow("description")).replace("()", ""))
                If IsDBNull(oRow("url")) Then
                    objX.WriteElementString("link", "http://www.giftlinkup.com")
                Else
                    objX.WriteElementString("link", oRow("url"))
                End If

                objX.WriteElementString("pubDate", orow("updated_dt"))
                objX.WriteEndElement()
            Next


            objX.WriteEndElement()
            objX.WriteEndElement()
            objX.WriteEndDocument()
            objX.Flush()
            objX.Close()
            Response.End()

        ElseIf Request.QueryString("Type") = "M" Then
            Dim oCommandParameter As New SqlParameter("@guid", SqlDbType.UniqueIdentifier)
            oCommandParameter.Value = New System.Guid(Request.QueryString("recip"))

            Dim dsMyWishList As DataSet
            dsMyWishList = SqlHelper.ExecuteDataset(SqlConn, CommandType.StoredProcedure, _
             "sel_gifts_for_recipient_rss", _
             oCommandParameter)

            Response.Clear()
            Response.ContentType = "application/rss+xml"
            Dim objX As New XmlTextWriter(Response.OutputStream, Encoding.UTF8)
            objX.WriteStartDocument()
            objX.WriteStartElement("rss")
            objX.WriteAttributeString("version", "2.0")
            objX.WriteStartElement("channel")
            objX.WriteElementString("title", "GiftLinkUp.com - Lists I'm Watching")
            objX.WriteElementString("link", "http://www.giftlinkup.com")
            objX.WriteElementString("description", "gift-giving made easier.")
            objX.WriteElementString("ttl", "5")
            For Each oRow As DataRow In dsMyWishList.Tables(0).Rows
                objX.WriteStartElement("item")
                objX.WriteElementString("title", oRow("description"))
                
                objX.WriteElementString("description", CStr(oRow("description")).Replace("()", ""))
                If IsDBNull(oRow("url")) Then
                    objX.WriteElementString("link", "http://www.giftlinkup.com")
                Else
                    objX.WriteElementString("link", oRow("url"))
                End If

                objX.WriteElementString("pubDate", oRow("updated_dt"))
                objX.WriteEndElement()
            Next


            objX.WriteEndElement()
            objX.WriteEndElement()
            objX.WriteEndDocument()
            objX.Flush()
            objX.Close()
            Response.End()
        ElseIf Request.QueryString("Type") = "ADMINR" Then

            Dim dsRecentRecipients As DataSet
            dsRecentRecipients = SqlHelper.ExecuteDataset(SqlConn, CommandType.Text, _
             "select top 20 * from recipient order by recipient_id desc")

            Response.Clear()
            Response.ContentType = "application/rss+xml"
            Dim objX As New XmlTextWriter(Response.OutputStream, Encoding.UTF8)
            objX.WriteStartDocument()
            objX.WriteStartElement("rss")
            objX.WriteAttributeString("version", "2.0")
            objX.WriteStartElement("channel")
            objX.WriteElementString("title", "GiftLinkUp.com - Recent Users")
            objX.WriteElementString("link", "http://www.giftlinkup.com")
            objX.WriteElementString("description", "gift-giving made easier.")
            objX.WriteElementString("ttl", "5")
            For Each oRow As DataRow In dsRecentRecipients.Tables(0).Rows
                objX.WriteStartElement("item")
                objX.WriteElementString("title", oRow("name"))

                objX.WriteElementString("name", CStr(oRow("name")).Replace("()", ""))
                If IsDBNull(oRow("email")) Then
                    objX.WriteElementString("description", "Proxy")
                Else
                    objX.WriteElementString("description", oRow("email"))
                End If


                objX.WriteElementString("link", "http://www.giftlinkup.com")
                
                objX.WriteElementString("pubDate", Now)
                objX.WriteEndElement()
            Next


            objX.WriteEndElement()
            objX.WriteEndElement()
            objX.WriteEndDocument()
            objX.Flush()
            objX.Close()
            Response.End()
        ElseIf Request.QueryString("Type") = "ADMINA" Then

            Dim dsActivityLog As DataSet
            dsActivityLog = SqlHelper.ExecuteDataset(SqlConn, CommandType.Text, _
             "select top 20 * from recipient r, activity_log a where a.user_id = r.recipient_id order by activity_dt desc")

            Response.Clear()
            Response.ContentType = "application/rss+xml"
            Dim objX As New XmlTextWriter(Response.OutputStream, Encoding.UTF8)
            objX.WriteStartDocument()
            objX.WriteStartElement("rss")
            objX.WriteAttributeString("version", "2.0")
            objX.WriteStartElement("channel")
            objX.WriteElementString("title", "GiftLinkUp.com - Recent Activity")
            objX.WriteElementString("link", "http://www.giftlinkup.com")
            objX.WriteElementString("description", "gift-giving made easier.")
            objX.WriteElementString("ttl", "5")
            For Each oRow As DataRow In dsActivityLog.Tables(0).Rows
                objX.WriteStartElement("item")
                objX.WriteElementString("title", oRow("name") & " " & oRow("description"))

                objX.WriteElementString("name", oRow("name") & " " & oRow("description"))

                objX.WriteElementString("link", "http://www.giftlinkup.com")

                objX.WriteElementString("pubDate", oRow("activity_dt"))
                objX.WriteEndElement()
            Next


            objX.WriteEndElement()
            objX.WriteEndElement()
            objX.WriteEndDocument()
            objX.Flush()
            objX.Close()
            Response.End()

        End If
    End Sub
End Class
