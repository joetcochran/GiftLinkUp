<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false"
    CodeFile="announce-history.aspx.vb" Inherits="announce_history" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <table width="100%">
        <tr>
            <td valign="top" width="100%">
                <div class="roundedcornr_box_512359">
                    <div class="roundedcornr_top_512359">
                        <div>
                        </div>
                    </div>
                    <div class="roundedcornr_content_512359">
                        <table cellspacing="4" cellpadding="0" width="95%">
                            <tr>
                                <td>
                                    <span class="forestgreen big">Gift Notification History for
                                        <%=TargetRecipientName%>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <br>
                                    <br>
                                    <asp:Label runat="server" ID="lblNoNotifications"  Visible="false"><i>No Notifications to display.</i></asp:Label>
                                    <asp:gridview Width="95%" ID="dgNotificationHistory" runat="server" BorderColor="#336666"
                                        BorderStyle="Double" BorderWidth="3px" CellPadding="4" AutoGenerateColumns="False"
                                        DataMember="Table" BackColor="White" GridLines="Horizontal">
                                        <HeaderStyle Font-Bold="True" BackColor="#127507" ForeColor="White" />
                                        <Columns>
                                      
                                            <asp:BoundField DataField="updated_dt" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                HeaderText="Date" DataFormatString="{0:d}" HtmlEncode="false"></asp:BoundField>
                                            <asp:BoundField DataField="notification_desc" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                                HeaderText="Description"></asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="White" ForeColor="#333333" />                                      
                                        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center"  />
                                       
                                    </asp:gridview><br>
                                    <br>
                                    <br>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="roundedcornr_bottom_512359">
                        <div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
