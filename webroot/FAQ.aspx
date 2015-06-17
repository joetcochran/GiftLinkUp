<%@ Page Language="VB" MasterPageFile="~/NoLogin.master" AutoEventWireup="false"
    CodeFile="FAQ.aspx.vb" Inherits="block_givers" Title="GiftLinkUp.com - FAQ" %>

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
															<u>Frequently Asked Questions</u></span>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow runat="server" ID="TableRow2">
                                <asp:TableCell HorizontalAlign="Left">
                                <asp:Label runat="server" ID="FullContent" cssclass="textinusercontrol">
                                <b>What does this site do?</b><br />
                                Creating a GiftLinkUp.com account is a great way to let people know what you would 
                                like while still preserving the surprise! When you link your account to your friends and family
                                members with GiftLinkUp.com accounts, you can make sure you get what you want and they do too.
                                <br />
                                        <br />
                                                                
                                <b>Seems like that would take the surprise out of gift-giving.</b><br />
                                The notifications that GiftLinkUp.com sends when someone purchases a gift from your list
                                are sent only to the people who have linked to your wish list. Not you. 
                                <br />
                                <br />
                                
                                <b>How is this different from a gift registry?</b><br />
                                <li>You can list items from any online or offline vendor.
                                <li>You can also create "managed" wish lists for your children, and the same notification process applies. 
                                <li>Once you're linked up to other people's GiftLinkUp.com accounts, all of their wish lists
                                show up on your GiftLinkUp.com homepage. (<asp:hyperlink runat="server" NavigateUrl="~/images/screenshots/aggregateview.jpg" Target="_new">Screenshot</asp:hyperlink>)
                                <li>You can also use a star-rating system to indicate how much you want the gift.
                                <li>You can use comments on each wish list item to describe why you want the item.
                                <li>RSS Syndication allows you to track when items are purchased for others.
                                <br /><br />
                                
                                <b>How do I add items to my kids' wish lists?</b><br />
                                You can use the "Create Managed Wish List" link in the Account Options section of the site. Enter
                                your childrens' names and they will be added to your GiftLinkUp.com homepage. From there, 
                                you can add items to their lists just as you would your own. (<asp:hyperlink ID="Hyperlink1" runat="server" NavigateUrl="~/images/screenshots/proxyview.jpg" Target="_new">Screenshot</asp:hyperlink>)<br />
                                <br />

                                <b>Does it cost anything?</b><br />
                                No. GiftLinkUp.com is absolutely free.<br />
                                <br />
                                
                                <b>Can I set up my kids' wish lists so that both my spouse can manage it as well?</b><br />
                                Yes. Enter your spouse's email address under the "Share Management" section of the Account Options.<br />
                                <br />
                                
                                <b>How can I link up to other users' wish lists?</b><br />
                                You can use the "Manage Recipients" section in the Account Options to search by email address. If the
                                person's wish list is marked "Public" you will see it on your homepage immediately. If they've marked
                                their wish list "Private", then you will need to enter a password before getting access to their list.<br />
                                <br />
                                
                                <b>How can I make sure other people can see my wish list?</b><br />
                                You can use the "Invite Gift-Givers" section in the Account Options to search by email address.
                                If they're not a GiftLinkUp.com user, they will be sent an email invitation to create an account, 
                                and your wish list will automatically be linked to their new account.<br />
                                <br />
                                
                                <b>What if I want to restrict access to my wish list?</b><br />
                                Under the "Edit Personal Information" section of the Account Options, mark your "Wish List Type" as
                                <b>Private</b>. Then, you must specify a "Private Wish List Password". Before linking up to your 
                                wish list, users must provide this password.<br />
                                <br />

                                <b>What do I need to do when I purchase a gift?</b><br />
                                Clicking on the notification icon (<img src="images/email.gif"  style="vertical-align:bottom;" />) 
                                will take you to a new page so that you can enter additional information and send the notification. (<asp:hyperlink ID="Hyperlink2" runat="server" NavigateUrl="~/images/screenshots/announce.jpg" Target="_new">Screenshot</asp:hyperlink>)<br />
                                <br />
                                                                
                                <b>How do I know when a gift has been purchased for someone else?</b><br />
                                You will receive an email once the gift has been purchased. Also, the envelope icon will change
                                to a present icon (<img src="images/purchased.gif"  style="vertical-align:bottom;" />). If you hover your mouse cursor over the
                                present, it will tell you who purchased the gift. You can also click on the notification history
                                icon (<img src="images/history.gif"  style="vertical-align:bottom;" />) to see the history of all email notifications that were
                                sent out.<br />
                                <br />
                                                                
                                <b>Do I <b>have to</b> login to GiftLinkUp.com in order to see what gifts have been purchased?</b><br />
                                No. You can use RSS Feeds to embed this kind of information into any RSS Reader such as My Yahoo, Google Reader, or FeedDemon. <br />
                                <br />
</asp:Label>                                
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                        
                        <asp:LinkButton runat="server" Font-Bold="true" ID="lbHome" Font-Size="Small">Home</asp:LinkButton>
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
