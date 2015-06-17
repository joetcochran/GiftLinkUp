<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false"
    CodeFile="manage-recipients.aspx.vb" Inherits="manage_recipients" Title="GiftLinkUp.com - Manage Recipients" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
														<span class="x-big">
															<u>Add Recipients</u></span>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow ID="TableRow2" runat="server">
                                        <asp:TableCell ID="TableCell2" runat="server" HorizontalAlign="Center">
                                            Use this to <b>add someone</b> to your collection of wish lists.&nbsp;<br>
                                            <br>
                                            If they're currently not a GiftLinkUp.com user, you can send an email invitation
                                            to try GiftLinkUp.com.<br>
                                            <br>
                                            Enter the e-mail of the person to add! We'll send them a customized e-mail invitation.<br>
                                            <br>
                                            <table border="0">
                                                <tr>
                                                    <td align="right">
                                                        <span class="big">E-mail:</span>
                                                    </td>
                                                    <td align="left">
                                                        <asp:TextBox ID="tbEmail" runat="server" CssClass="stdinput"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" colspan="2">
                                                        <asp:Button ID="btnSearchRecipients" runat="server" CssClass="targetwishlistbutton"
                                                            Text="Search GiftLinkUp.com"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:Label ID="lblPickExistingUser" runat="server" Font-Bold="True"></asp:Label>
                                            <asp:Label ID="lblInviteNewUser" runat="server" Font-Bold="True"></asp:Label>
                                            <asp:Panel ID="pnlEnterPrivateListPassword" Visible="false" runat="server">
                                                <br />
                                                <asp:Label ID="Label1" runat="server" Font-Bold="True">In order to view this wish list, please enter this person's private list password:
                                                </asp:Label>
                                                <asp:TextBox runat="server" ID="txtPrivateListPassword" TextMode="Password" CssClass="stdinput">
                                                </asp:TextBox>
                                                &nbsp;
                                                <asp:HiddenField runat="server" ID="hdnPrivateListRecipientID" />
                                                <asp:Button runat="server" ID="btnPrivateListPassword" Text="Submit" CssClass="targetwishlistbutton" />
                                                <br />                                                
                                            </asp:Panel>
                                            <asp:Label runat="server" ID="lblPrivateListPasswordResult" Font-Bold ="true"></asp:Label>
                                            <asp:Panel ID="pnlInvite" runat="server" Visible="true">
                                                <asp:Label ID="lblInviteNewUser2a" runat="server" Font-Bold="True"></asp:Label><br />
                                                <asp:LinkButton ID="hlInvite" Visible="false" runat="server" Font-Bold="true" Text="Click here"></asp:LinkButton>
                                                <asp:Label ID="lblInviteNewUser2b" runat="server" Font-Bold="True"></asp:Label>
                                            </asp:Panel>
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
                        <div class="roundedcornr_box_512359">
                            <div class="roundedcornr_top_512359">
                                <div>
                                </div>
                            </div>
                            <div class="roundedcornr_content_512359">
                                <asp:Table runat="server" CellSpacing="4" CellPadding="0" Width="95%" ID="tblRemoveRecipients">
                                    <asp:TableRow ID="TableRow3" runat="server">
                                        <asp:TableCell ID="TableCell3" runat="server" HorizontalAlign="Center">

														<span class="x-big">
															<u>Remove Recipients</u></span>

                                        </asp:TableCell></asp:TableRow>
                                    <asp:TableRow ID="trRemoveRecipients2" runat="server">
                                        <asp:TableCell ID="TableCell4" runat="server" HorizontalAlign="Center">
                                            <asp:Label runat="server" ID="lblRemove">Use this to <b>remove someone</b> from your collection of 
															wish lists. &nbsp;
															<br>
                                            </asp:Label>
                                            <br>
                                            <br>
                                            <table align="center">
                                                <tr>
                                                    <td align="left">
                                                        <asp:CheckBoxList RepeatColumns="3" CellPadding="5" CellSpacing="5" ID="clbRemoveRecipients"
                                                            runat="server" RepeatLayout="Table" RepeatDirection="Horizontal">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnRemoveRecipients" runat="server" CssClass="targetwishlistbutton"
                                                            Text="   Remove These Recipients   "></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                                <asp:Table ID="Table2" runat="server">
                                </asp:Table>
                            </div>
                            <div class="roundedcornr_bottom_512359">
                                <div>
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
