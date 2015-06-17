<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false"
    CodeFile="invite-givers.aspx.vb" Inherits="invite_givers" Title="GiftLinkUp.com - Announce Your Wish List" %>

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
                        <asp:Table runat="server" CellSpacing="4" CellPadding="0" Width="95%" ID="Table1">
                            <asp:TableRow ID="TableRow1" runat="server">
                                <asp:TableCell ID="TableCell1" runat="server">
														<span class="forestgreen x-big">
															<u>Announce your wish list</u></span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" ID="TableRow2">
                                <asp:TableCell>
                                    <asp:Panel runat="server" ID="pnlIsPrivate">
                                        Your wish list is currently marked <b>Private</b>. This means that only the people
                                        <b>you</b> specify can search for and view your wish list.
                                        <br />
                                        <br />
                                        Enter the email addresses of the people you wish to announce to your GiftLinkUp.com
                                        wish list to. Separate email addresses with a comma or a line break.
                                        <br />
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnlIsPublic">
                                        Your wish list is currently marked <b>Public</b>. This means that anyone who knows
                                        your email address (<asp:Label runat="server" ID="lblEmail"></asp:Label>) can view
                                        your wish list.
                                        <br />
                                        <br />
                                        Enter the email addresses of the people you wish to announce to your GiftLinkUp.com
                                        wish list to. Separate email addresses with a comma or a line break.
                                        <br />
                                    </asp:Panel>
                                    <asp:TextBox runat="server" ID="txtInvitations" Text='' CssClass="stdinput-forestgreen"
                                        TextMode="multiline" Rows="8" Columns="60"></asp:TextBox><br />
                                    <br />
                                    <asp:Button ID="btnInviteUsers" runat="server" CssClass="targetwishlistbutton comments"
                                        Width="120" Text="Send Invitations" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow ID="TableRow3" runat="server">
                                <asp:TableCell ID="TableCell2" runat="server">
	    
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                    <div class="roundedcornr_bottom_512359">
                        <div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
