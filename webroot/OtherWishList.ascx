<%@ Control Language="VB" AutoEventWireup="false" CodeFile="OtherWishList.ascx.vb"
    Inherits="OtherWishList" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="aspajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<script language="javascript">
function ConfirmOtherDelete()
{
    return confirm('Are you sure you want to remove this list from your view?');
}
</script>
<aspajax:UpdatePanel runat="server" id="up1" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="roundedcornr_box_512359">
            <div class="roundedcornr_top_512359">
                <div>
                </div>
            </div>
            <div class="roundedcornr_content_512359">
            
                <table width="100%">
                
                    <tr>
                        <td align="left" valign="top">
                            <table width="100%">
                                <tr>
                                    <td valign="top" align="left" width="50%">
                                        <asp:Label runat="server" ID="lblOtherWishList" CssClass="forestgreen big" Style="text-decoration: underline;"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td width="100" align="right" style="background-color:White;" class="raised-cell" valign="top">
                                        <asp:ImageButton runat="server" ID="btnAnnounce" ImageUrl="images/email.gif" AlternateText="Announce a gift purchase for (!person_name!)" />
                                        &nbsp;
                                        <asp:ImageButton runat="server" ID="btnShowHistory" ImageUrl="images/history.gif"
                                            AlternateText="View the announcement history for (!person_name!)" />
                                        &nbsp;
                                        <asp:ImageButton runat="server" ID="btnDelete" AlternateText="Remove this list from your page"
                                            ImageUrl="~/images/delete.gif" />&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td align="left">
                            <asp:Label CssClass="textinusercontrol" runat="server" ID="lblNoItems"><i>No items in this wish list.</i></asp:Label>
<asp:GridView  GridLines="None" ID="grdOtherWishList" runat="server" AutoGenerateColumns="false" Border="0">
                                <Columns>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:HiddenField runat="server" ID="hdnGiftID" Value='<%# DataBinder.Eval(Container.DataItem,"gift_id") %>' />
                                            <asp:ImageButton runat="server" ID="imgbutNotify" OnClick="NotifyGift" ImageUrl="~/images/email.gif"
                                                Visible='<%# NotifyImageVisible(DataBinder.Eval(Container.DataItem,"Purchaser")) %>' />
                                            <asp:Image runat="server" ID="imgbutPurchased" ImageUrl="~/images/purchased.gif"
                                                AlternateText='<%# Purchaser(DataBinder.Eval(Container.DataItem,"Purchaser")) %>'
                                                Visible='<%# PurchasedImageVisible(DataBinder.Eval(Container.DataItem,"Purchaser")) %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Image runat="server" ID="star1" Visible='<%# StarVisible(1, DataBinder.Eval(Container.DataItem,"Desire_lvl")) %>'
                                                ImageUrl="~/images/star-on.gif" /><asp:Image runat="server" ID="star2" Visible='<%# StarVisible(2, DataBinder.Eval(Container.DataItem,"Desire_lvl")) %>'
                                                    ImageUrl="~/images/star-on.gif" /><asp:Image runat="server" ID="star3" Visible='<%# StarVisible(3, DataBinder.Eval(Container.DataItem,"Desire_lvl")) %>'
                                                        ImageUrl="~/images/star-on.gif" /><asp:Image runat="server" ID="star4" Visible='<%# StarVisible(4, DataBinder.Eval(Container.DataItem,"Desire_lvl")) %>'
                                                            ImageUrl="~/images/star-on.gif" /><asp:Image runat="server" ID="star5" Visible='<%# StarVisible(5, DataBinder.Eval(Container.DataItem,"Desire_lvl")) %>'
                                                                ImageUrl="~/images/star-on.gif" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Wrap="true" ItemStyle-Width="70%" ItemStyle-VerticalAlign="top">
                                        <ItemTemplate><b>
                                            <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'
                                                ID="lblNoURLGift"  CssClass="textinusercontrol" Visible='<%# GiftLabelVisible(DataBinder.Eval(Container.DataItem,"URL")) %>'></asp:Label>
                                            <asp:HyperLink runat="server" ID="hlURLGift"  CssClass="textinusercontrol" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'
                                                NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"URL") %>' Visible='<%# GiftHyperlinkVisible(DataBinder.Eval(Container.DataItem,"URL")) %>'></asp:HyperLink></b>
                                            <asp:Label runat="server"  CssClass="textinusercontrol" Text='<%# CommentWrapper(DataBinder.Eval(Container.DataItem,"Comment")) %>'
                                                ID="lblComment"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="5%">
                                        <ItemTemplate>
                                            &nbsp;</ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </td>
                    </tr>
                </table>
            </div>
            <div class="roundedcornr_bottom_512359">
                <div>
                </div>
            </div>
        </div>
    </ContentTemplate>
    <Triggers>
    </Triggers>
</aspajax:UpdatePanel>
