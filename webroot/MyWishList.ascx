<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MyWishList.ascx.vb" Inherits="MyWishList" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="aspajax" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<aspajax:updatepanel runat="server" id="up1" updatemode="Conditional">
    
    <contenttemplate>
        <div class="roundedcornr_box_655973">
            <div class="roundedcornr_top_655973">
                <div>
                </div>
            </div>
            <div class="roundedcornr_content_655973">
                <table width="100%">
                    <tr>
                        <td align="left">
                        <aspajax:UpdateProgress associatedupdatepanelid="up1" ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                              <img src="images/loading-ani.gif" />
                            </ProgressTemplate>
                            </aspajax:UpdateProgress>                            
                            <asp:Image   ID="imgFacebookProfilePic" runat="server" />&nbsp;<asp:Label runat="server" ID="lblMyWishList" CssClass="deepred x-big"><u>My Wish List</u></asp:Label>
                            <br />
                            <asp:GridView Border="0" CellSpacing="5" runat="server" ID="grdMyGifts" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField  ItemStyle-Wrap="false" ItemStyle-VerticalAlign="top">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkDelete" />
                                            <asp:ImageButton  CommandName="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"gift_id") %>' runat="server" ID="btnEdit" ImageUrl="~/images/editIcon.gif" />
                                            <asp:HiddenField runat="server" ID="hdnGiftID" Value='<%# DataBinder.Eval(Container.DataItem,"gift_id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField  ItemStyle-Width="400" ItemStyle-VerticalAlign="top">
                                        <ItemTemplate>
                                            <asp:Label CssClass="textinusercontrol" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'
                                                ID="lblNoURLGift" Visible='<%# GiftLabelVisible(DataBinder.Eval(Container.DataItem,"URL")) %>'></asp:Label>
                                            <asp:HyperLink CssClass="textinusercontrol" runat="server" ID="hlURLGift" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'
                                                NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"URL") %>' Visible='<%# GiftHyperlinkVisible(DataBinder.Eval(Container.DataItem,"URL")) %>'></asp:HyperLink>
                                                <asp:Panel runat="server" ID="pnlMyGiftComments" Visible="false">
                                                <table width="100%"><tr><td width="15">&nbsp;</td><td valign="top">Comments:</td><td valign="top">
                                                <asp:TextBox runat="server" ID="txtMyGiftComments" Text='<%# Eval("Comment") %>'
                                                    CssClass="stdinput-deepred" TextMode="multiline" Rows="4" Columns="60"></asp:TextBox><br />
                                                <asp:Button OnClick="btnMyGiftCommentsAdd_Click" ID="btnMyGiftCommentsAdd" runat="server"
                                                    CssClass="mywishlistbutton comments" Text="Add Comment" />
                                                <asp:Button OnClick="btnMyGiftCommentsCancel_Click" ID="btnMyGiftCommentsCancel"
                                                    runat="server" CssClass="mywishlistbutton comments" Text="Cancel" />
                                                </td></tr></table>
                                            </asp:Panel>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                        <table><tr><td>
                                        <asp:label CssClass="textinusercontrol" runat="server" ID="lblDescriptionEdit">Description:</asp:label></td>
                                        <td><asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Description") %>'
                                                ID="txtDescription" CssClass="stdinput-deepred long"></asp:TextBox></td></tr><tr><td>
                                            
                                            <asp:label CssClass="textinusercontrol" runat="server" ID="lblUrlEdit">Url (Optional):</asp:label></td>
                                            <td><asp:TextBox CssClass="stdinput-deepred long" runat="server" ID="txtURL" Text='<%# DataBinder.Eval(Container.DataItem,"URL") %>'></asp:TextBox>
                                            </td></tr>
                                            <tr><td></td>
                                            <td align="left">
                                            <asp:Button  CommandName="SaveEdits" runat="server" CssClass="mywishlistbutton login" ID="btnEditSave" Text=" Save " />
                                            <asp:Button  CommandName="CancelEdits" runat="server" CssClass="mywishlistbutton login" ID="btnEditCancel" Text="Cancel" />
                                            </td>
                                            </tr></table>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Wrap="false" ItemStyle-VerticalAlign="top">
                                        <ItemTemplate>
                                            <ajaxToolkit:Rating ID="MyGiftRating" runat="server" CurrentRating='<%# DataBinder.Eval(Container.DataItem,"desire_lvl") %>'
                                                MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                                FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" OnChanged="MyGiftRating_Changed"
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
                                        <asp:Button runat="server" CssClass="mywishlistbutton long" ID="btnDelete" Text="Remove the checked items" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Label runat="server" CssClass="textinusercontrol"  ID="lblNoItems"><i>No items in this wish list.</i></asp:Label>
                            <br />
                            <hr noshade />
                            <table width="100%">
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label  runat="server" ID="lblAddNew" CssClass="textinusercontrol big">Add an item to your wish list</asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="right" width="100">
                                        <asp:Label CssClass="textinusercontrol" runat="server" ID="lblNewDesc">Description:</asp:Label></td>
                                    <td align="left">
                                        <asp:TextBox runat="server" ID="tbMyNewDescription" CssClass="stdinput-deepred long"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label CssClass="textinusercontrol" runat="server" ID="lblNewURL">URL (Optional):</asp:Label></td>
                                    <td align="left">
                                        <asp:TextBox runat="server" ID="tbMyNewURL" CssClass="stdinput-deepred long"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td align="right">
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnMyAdd" runat="server" CssClass="mywishlistbutton long" Text="Add this item to my wish list" /></td>
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
    </contenttemplate>
    <triggers>
    </triggers>
</aspajax:updatepanel>
