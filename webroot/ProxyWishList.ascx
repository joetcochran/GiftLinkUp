<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ProxyWishList.ascx.vb"
    Inherits="ProxyWishList" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="aspajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<script language="javascript">
function ConfirmProxyDelete()
{
    return confirm('Are you sure you want to remove this list from your view?');
}
</script>

<aspajax:UpdatePanel runat="server" ID="up1" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="roundedcornr_box_250279">
            <div class="roundedcornr_top_250279">
                <div>
                </div>
            </div>
            <div class="roundedcornr_content_250279">
                <table width="100%">
                    <tr>
                        <td align="left">
                            <asp:Panel runat="server" ID="mainContent">
                                <table width="100%">
                                    <tr>
                                        <td valign="top" align="left" width="50%">
                                            <asp:Label runat="server" ID="lblProxyWishList" CssClass="brightred big" Style="text-decoration: underline;"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td width="100" align="center" valign="top" style="background-color:White;" class="raised-cell">
                                            <asp:ImageButton runat="server" ID="btnProxyAnnounce" ImageUrl="images/email.gif" />&nbsp;
                                            <asp:ImageButton runat="server" ID="btnProxyShowHistory" ImageUrl="images/history.gif" />&nbsp;
                                            <asp:ImageButton runat="server" ID="btnSharemanagement" ImageUrl="~/images/share-mgmt.gif"
                                                AlternateText="Share Management of this list" />&nbsp;
                                            <asp:ImageButton runat="server" ID="btnDelete" AlternateText="Remove this list from your page"
                                                ImageUrl="~/images/delete.gif" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="pnlSharemanagement" runat="server"  HorizontalAlign="Right" Visible="false">
                                    <asp:Table runat="server" ID="tblShareManagement" Width="100%">
                                        <asp:TableRow runat="server" ID="trShareManagementStep1">
                                            <asp:TableCell ColumnSpan="2" runat="server" ID="tcShareManagementStep1" Width="100%"
                                                HorizontalAlign="Right">
                                                <asp:Label runat="server" ID="lblShareManagement">Please enter the email address of the person that you <br />would like to share management with.</asp:Label><br />
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow runat="server" ID="trSharemanagementFeedback" Visible="false">
                                            <asp:TableCell ColumnSpan="2" runat="server" ID="TableCell1" Width="100%"
                                                HorizontalAlign="Right">
                                                <asp:Label runat="server" ID="lblShareManagementFeedback" Font-Bold="true"></asp:Label><br />
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow runat="server" ID="trShareManagementEmail">
                                            <asp:TableCell Width="100%" HorizontalAlign="Right" runat="server" ID="tcShareManagementEmail1">
                                                <asp:Label runat="server" ID="lblEmail" Text="Email Address:" Font-Bold="true"></asp:Label>
                                            </asp:TableCell>
                                            <asp:TableCell runat="server" ID="tcShareManagementEmail2">
                                                <asp:TextBox runat="server" ID="txtEmail" CssClass="proxywishlistinput longish"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                        <asp:TableRow runat="server" ID="trShareManagementSubmitStep1">
                                            <asp:TableCell runat="server" ID="tcShareManagementSubmitCancel1">                                                
                                            </asp:TableCell>
                                            <asp:TableCell runat="server" ID="tcShareManagementSubmitCancel2">
                                                <asp:Button runat="server" ID="btnShareManagementSearch" CssClass="proxywishlistbutton" Text="Search" />&nbsp;
                                                <asp:Button runat="server" ID="btnShareManagementCancel" cssclass="proxywishlistbutton" Text="Cancel" />
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                </asp:Panel>
                                <asp:GridView runat="server" Border="0" Width="100%" ID="grdProxyGifts" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="20" ItemStyle-VerticalAlign="top">
                                            <ItemTemplate>
                                                <asp:ImageButton runat="server" ID="imgbutNotify" OnClick="NotifyGift" ImageUrl="~/images/email.gif"
                                                    Visible='<%# NotifyImageVisible(DataBinder.Eval(Container.DataItem,"Purchaser")) %>' />
                                                <asp:Image runat="server" ID="imgbutPurchased" ImageUrl="~/images/purchased.gif"
                                                    AlternateText='<%# Purchaser(DataBinder.Eval(Container.DataItem,"Purchaser")) %>'
                                                    Visible='<%# PurchasedImageVisible(DataBinder.Eval(Container.DataItem,"Purchaser")) %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="50" ItemStyle-VerticalAlign="top">
                                            <ItemTemplate>
                                                <asp:CheckBox runat="server" ID="chkDelete" />
                                                <asp:ImageButton CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"gift_id") %>'
                                                    runat="server" ID="btnEdit" ImageUrl="~/images/editIcon.gif" />
                                                <asp:HiddenField runat="server" ID="hdnGiftID" Value='<%# DataBinder.Eval(Container.DataItem,"gift_id") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Wrap="false" ItemStyle-Width="200" ItemStyle-VerticalAlign="top">
                                            <ItemTemplate>
                                                <asp:Label CssClass="textinusercontrol" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'
                                                    ID="lblNoURLGift" Visible='<%# GiftLabelVisible(DataBinder.Eval(Container.DataItem,"URL")) %>'></asp:Label>
                                                <asp:HyperLink CssClass="textinusercontrol" runat="server" ID="hlURLGift" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'
                                                    NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"URL") %>' Visible='<%# GiftHyperlinkVisible(DataBinder.Eval(Container.DataItem,"URL")) %>'></asp:HyperLink>
                                                <asp:Panel runat="server" ID="pnlProxyGiftComments" Visible="false">
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="15">
                                                                &nbsp;</td>
                                                            <td valign="top">
                                                                Comments:</td>
                                                            <td valign="top">
                                                                <asp:TextBox runat="server" ID="txtProxyGiftComments" Text='<%# Eval("Comment") %>'
                                                                    CssClass="proxywishlistinput long" TextMode="multiline" Rows="4" Columns="60"></asp:TextBox><br />
                                                                <asp:Button OnClick="btnProxyGiftCommentsAdd_Click" ID="btnProxyGiftCommentsAdd"
                                                                    runat="server" CssClass="proxywishlistbutton comments" Text="Add Comment" />
                                                                <asp:Button OnClick="btnProxyGiftCommentsCancel_Click" ID="btnProxyGiftCommentsCancel"
                                                                    runat="server" CssClass="proxywishlistbutton comments" Text="Cancel" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Label CssClass="textinusercontrol" runat="server" ID="lblDescriptionEdit">Description:</asp:Label></td>
                                                        <td>
                                                            <asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'
                                                                ID="txtDescription" CssClass="proxywishlistinput long"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap>
                                                            <asp:Label CssClass="textinusercontrol" runat="server" ID="lblUrlEdit">Url (Optional):</asp:Label></td>
                                                        <td>
                                                            <asp:TextBox CssClass="proxywishlistinput long" runat="server" ID="txtURL" Text='<%# DataBinder.Eval(Container.DataItem,"URL") %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Button CommandName="SaveEdits" runat="server" CssClass="proxywishlistbutton login"
                                                                ID="btnEditSave" Text=" Save " />
                                                            <asp:Button CommandName="CancelEdits" runat="server" CssClass="proxywishlistbutton login"
                                                                ID="btnEditCancel" Text="Cancel" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="85" ItemStyle-Wrap="false" ItemStyle-VerticalAlign="top">
                                            <ItemTemplate>
                                                <ajaxToolkit:Rating ID="ProxyGiftRating" runat="server" CurrentRating='<%# DataBinder.Eval(Container.DataItem,"desire_lvl") %>'
                                                    MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                                    FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" OnChanged="ProxyGiftRating_Changed"
                                                    AutoPostBack="true" Tag='<%# DataBinder.Eval(Container.DataItem,"gift_id") %>'>
                                                </ajaxToolkit:Rating>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-VerticalAlign="Top">
                                            <ItemTemplate>
                                                <asp:Panel runat="server" ID="pnlCommands" Visible="true">
                                                    <asp:ImageButton Visible='<%# AddCommentImageVisible(DataBinder.Eval(Container.DataItem,"Comment")) %>'
                                                        runat="server" OnClick="lbOpenComments_Click" ID="imgbutAddComments" ImageUrl="~/images/talk-bubble-add.GIF"
                                                        AlternateText="Add Comments"></asp:ImageButton>
                                                    <asp:ImageButton Visible='<%# EditCommentImageVisible(DataBinder.Eval(Container.DataItem,"Comment")) %>'
                                                        runat="server" OnClick="lbOpenComments_Click" ID="imgbutEditComments" ImageUrl="~/images/talk-bubble.GIF"
                                                        AlternateText="Edit Comments"></asp:ImageButton>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <table width="100%">
                                    <tr>
                                        <td width="20">
                                        </td>
                                        <td>
                                            <asp:Button ID="btnProxyDelete" runat="server" CssClass="proxywishlistbutton longish"
                                                Text="Remove the checked items" />
                                        </td>
                                    </tr>
                                </table>
                                <asp:Label runat="server" CssClass="textinusercontrol" ID="lblNoItems"><i>No items in this wish list.</i></asp:Label>
                                <br />
                                <hr noshade />
                                <table width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label runat="server" ID="lblProxyAddNew" CssClass="big"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="100">
                                            <asp:Label CssClass="textinusercontrol" runat="server" ID="Label2">Description:</asp:Label></td>
                                        <td align="left">
                                            <asp:TextBox runat="server" ID="tbProxyNewDescription" CssClass="proxywishlistinput longish"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label CssClass="textinusercontrol" runat="server" ID="Label3">URL (Optional):</asp:Label></td>
                                        <td align="left">
                                            <asp:TextBox runat="server" ID="tbProxyNewURL" CssClass="proxywishlistinput longish"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="btnProxyAdd" runat="server" CssClass="proxywishlistbutton longish"
                                                Text="Add this item" /></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="roundedcornr_bottom_250279">
                <div>
                </div>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
    </Triggers>
</aspajax:UpdatePanel>
