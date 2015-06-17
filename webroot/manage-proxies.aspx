<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false"
    CodeFile="manage-proxies.aspx.vb" Inherits="manage_proxies" Title="GiftLinkUp.com - Manage Wish Lists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">

    <script language="javascript">
	function showsharingmanagement()
	{
		document.getElementById('sharingmanagement').style.display = 'block';
		document.getElementById('whatissharingmanagement').style.display = 'none';
	}
	
		function showmanagedlists()
	{
		document.getElementById('managedlists').style.display = 'block';
		document.getElementById('whataremanagedlists').style.display = 'none';
	}

		function showremovemanagedlist()
	{
		document.getElementById('removemanagedlist').style.display = 'block';
		document.getElementById('whatisremovemanagedlist').style.display = 'none';
	}

    </script>

    <table width="100%">
        <tr>
            <td valign="top" width="100%">
                <div class="roundedcornr_box_655973">
                    <div class="roundedcornr_top_655973">
                        <div>
                        </div>
                    </div>
                    <div class="roundedcornr_content_655973">
                        <table cellspacing="4" cellpadding="0" width="95%">
                            <tr>
                                <td>
                                    <span class="brightred big">Add a Managed Wish List</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td valign="top" align="right" width="30%">
                                                <span class="brightred"><b>Name:</b></span>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td valign="top" align="left" width="58%">
                                                <asp:TextBox ID="tbNewProxy" runat="server" CssClass="stdinput"></asp:TextBox>
                                                <asp:Label runat="server" ID="lblNameErr" CssClass="brightred" Visible="false"><br />Please enter a name.</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:Button ID="btnCreateProxy" runat="server" CssClass="proxywishlistbutton" Text="Create Managed Wish List">
                                                </asp:Button><br />
                                                <span class="brightred">
                                                    <div id="whataremanagedlists">
                                                        <a href="javascript:showmanagedlists();"><span class="brightred small">What is this?</span></a></div>
                                                    <div id="managedlists" style="display: none">
                                                        <span class="brightred small">If you'd like to manage a wish list for your child, enter
                                                            their name here and click the button. A new wish list, which you can fully control,
                                                            will be created on the main page.</span></div>
                                            </td>
                                        </tr>
                                    </table>
                                    <hr noshade size="5">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="brightred big">Share a Managed Wish List</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblNoProxies" runat="server">
															<i>[No Managed Wish Lists Found.]</i></asp:Label>
                                    <asp:RadioButtonList ID="rblProxies" runat="server">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <br>
                                    <table cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td valign="top" align="right" width="30%">
                                                <span class="brightred"><b>Search By Email:</b></span>
                                            </td>
                                            <td width="2%">
                                                &nbsp;
                                            </td>
                                            <td valign="top" align="left" width="58%">
                                                <asp:TextBox ID="tbAssociateProxyEmail" runat="server" CssClass="stdinput long"></asp:TextBox>
                                            </td>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td align="left">
                                                    <asp:Button ID="btnAssociateProxy" runat="server" ToolTip="Allows you to grant management permissions over the selected wish list to another user of GiftLinkUp.com"
                                                        CssClass="proxywishlistbutton" Text="Share Management Permission"></asp:Button><br />
                                                    <asp:Label runat="server" Visible="false" ID="lblNoSuchUser" Text="Sorry, but the email address you entered does not appear to belong to a current GiftLinkUp.com user. The person you wish to share management with must be a GiftLinkUp.com user.">
                                                    </asp:Label>
                                                    <asp:Label runat="server" Visible="false" ID="lblEmailSent" Text="Thank you! We have sent an email to the address you requested asking them to share management control.">
                                                    </asp:Label>
                                                    <span class="brightred">
                                                        <div id="whatissharingmanagement">
                                                            <a href="javascript:showsharingmanagement();"><span class="brightred small">What is
                                                                this?</span></a></div>
                                                        <div id="sharingmanagement" style="display: none">
                                                            <span class="brightred small">If you are currently managing your child's wish list,
                                                                and want to share this management responsibility with another person, such as a
                                                                spouse, you can enter their email address here and they will be sent an email asking
                                                                them if they with to accept the shared management of the child's wish list.</span></div>
                                                </td>
                                            </tr>
                                    </table>
                                    <hr noshade size="5">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span class="brightred big">Remove a Managed Wish List</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="center">
                                    <table cellspacing="0" cellpadding="0" width="100%">
                                        <tr>
                                            <td colspan="3" valign="top" align="center">
                                                <asp:Label ID="lblNoProxiesRemove" runat="server">
															    <i>[No Managed Wish Lists Found.]</i></asp:Label>
                                                <asp:RadioButtonList ID="rblProxiesRemove" runat="server">
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%">
                                            </td>
                                            <td width="2%">
                                            </td>
                                            <td width="58%" align="left">
                                                <asp:Button ID="btnRemoveList" runat="server" CssClass="proxywishlistbutton" Text="Remove Managed Wish List">
                                                </asp:Button><br />
                                                <span class="brightred">
                                                    <div id="whatisremovemanagedlist">
                                                        <a href="javascript:showremovemanagedlist();"><span class="brightred small">What is
                                                            this?</span></a></div>
                                                    <div id="removemanagedlist" style="display: none">
                                                        <span class="brightred small">If you are currently managing your child's wish list,
                                                            but you now wish to remove that list, please select the name below and click the
                                                            button to remove it. <b>Note:</b> If you're the only person managing the list, all
                                                            items on that wish list will be deleted permanently.</span></div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="roundedcornr_bottom_655973">
                        <div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
