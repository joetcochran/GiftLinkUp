<%@ Page Language="VB" EnableEventValidation="false" MasterPageFile="~/Standard.master"
    AutoEventWireup="false" CodeFile="Main.aspx.vb" Inherits="NewMain" Title="GiftLinkUp.com" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/MyWishList.ascx" TagName="MyWishList" TagPrefix="uc1" %>
<%@ Register Src="~/ProxyWishList.ascx" TagName="ProxyWishList" TagPrefix="uc1" %>
<%@ Register Src="~/OtherWishList.ascx" TagName="OtherWishList" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:Table ID="tblMyWishList" Width="100%" runat="server" CellPadding="0" CellSpacing="0">
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell1" runat="server" ColumnSpan="3">
                <asp:UpdatePanel runat="server" ID="upMaster">
                    <ContentTemplate>
                        <uc1:MyWishList runat="server" ID="ucMyWishList" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <hr />
    <br />
    <table width="100%">
        <tr>
            <td align="left" valign="top" width="315">
                <u>
                    <asp:Label runat="server" ID="lblProxiesHeader" Text="Other lists I'm managing" CssClass="brightred big"></asp:Label>
                </u>
                <asp:ImageButton runat="server" ImageUrl="~/images/hide-purchased.jpg" ID="imgbutToggleManagedNotifications"
                    AlternateText="Show/Hide Managed List Notifications" />
            </td>
            <td align="right" valign="top">
                <asp:UpdatePanel runat="server" ID="upAddManagedList">
                    <ContentTemplate>
                        <asp:LinkButton runat="server" ID="btnAddManagedList">Add A Managed Wish List</asp:LinkButton>
                        <asp:Label runat="server" ID="lblManagedListSuccess" Visible="false"><br /><b>You have successfully added this list.</b></asp:Label>
                        <br />
                        <asp:Panel Visible="false" runat="server" ID="pnlAddManaged">
                            <table border="0" width="100%">
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Label runat="server" ID="lblAddManaged">Enter the name of the person that the wish list is for.</asp:Label>
                                        <asp:Label Visible="false" runat="server" ID="lblNameErr"><br /><b>Please enter a name.</b></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="100%">
                                        <b>Name:</b>
                                    </td>
                                    <td align="right">
                                        <asp:TextBox runat="server" ID="txtAddManaged" CssClass="stdinput-brightred long"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCreateProxy" runat="server" CssClass="proxywishlistbutton" Text="Create" />&nbsp;
                                        <asp:Button ID="btnCancelCreateProxy" runat="server" CssClass="proxywishlistbutton"
                                            Text="Cancel" />&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:Repeater runat="server" ID="rptProxies">
        <ItemTemplate>
            <uc1:ProxyWishList ID="ProxyList1" runat="server" RecipientID='<%# DataBinder.Eval(Container.DataItem,"recipient_id")%>'
                RecipientName='<%# DataBinder.Eval(Container.DataItem,"name")%>' />
            <br />
            <br />
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <hr />
    <br />
    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td valign="top" width="270" align="left">
                        <u>
                            <asp:Label runat="server" ID="Label1" Text="Linked Up Lists" CssClass="forestgreen big"></asp:Label>
                        </u>
                        <asp:ImageButton runat="server" ImageUrl="~/images/hide-purchased.jpg" ID="imgbutToggleListNotifications"
                            AlternateText="Show/Hide List Notifications" />
                    </td>
                    <td valign="top" align="right">
                        <asp:HiddenField runat="server" ID="hdnPrivateListRecipientID" Value="" />
                        <asp:LinkButton runat="server" ID="lbLinkUp" Text="Link Up To A New List"></asp:LinkButton>
                        <br />
                        <asp:Panel runat="server" ID="pnlLinkUp" Visible="false">
                            <asp:Table ID="tblLinkUp" runat="server" Width="100%">
                                <asp:TableRow ID="tblRow1" runat="server">
                                    <asp:TableCell ID="tblCell1" runat="server" ColumnSpan="2">
                                        <asp:Label runat="server" ID="lblLinkUpSuccess" Visible="false"><b>You have successfully linked up.</b><br /></asp:Label>
                                        <asp:Label runat="server" ID="lblLinkUpDirectionStep1">Enter the email address of the person that you'd like to link to.<br />
                                        </asp:Label>
                                        <asp:Label runat="server" ID="lblLinkUpDirectionStep2" Visible="false">This persons wish list is marked <b><font color="red">Private</font></b><br />
                                                    Please enter their Private List Password in order to Link Up to their list.<br />
                                        </asp:Label>
                                        <asp:Label runat="server" ID="lblLinkUpPrivateFail" Visible="false"><b>That is not the correct password. Please try again.</b><br /></asp:Label>
                                        <asp:Label runat="server" ID="lblLinkUpNotFound" Visible="false"><b>That user is not found. Please try again.</b><br /> or </asp:Label>
                                        <asp:LinkButton runat="server" ID="hlInvite" Visible="false"><b> Click Here </b></asp:LinkButton>
                                        <asp:Label runat="server" ID="lblLinkUpNotFound2" Visible="false"><b>to send this person an invitation.</b></asp:Label>                                        
                                    </asp:TableCell></asp:TableRow>
                                <asp:TableRow runat="server" ID="tblRowEmail">
                                    <asp:TableCell ID="TableCell2" runat="server" Width="100%" HorizontalAlign="right">
                                                    <b>Email Address:</b>
                                    </asp:TableCell>
                                    <asp:TableCell ID="TableCell3" runat="server">
                                        <asp:TextBox runat="server" ID="txtLinkUpEmail" CssClass="stdinput long"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" ID="tblRowPrivateListPassword" Visible="false">
                                    <asp:TableCell ID="TableCell4" runat="server" Width="100%" HorizontalAlign="right">
                                                    <b>Private List Password:</b>
                                    </asp:TableCell>
                                    <asp:TableCell ID="TableCell5" runat="server">
                                        <asp:TextBox runat="server" ID="txtLinkUpPrivateListPassword" TextMode="Password"
                                            CssClass="stdinput long"></asp:TextBox>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" ID="tblRowSearchStep1">
                                    <asp:TableCell ID="TableCell6" runat="server">
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ID="tblCell2">
                                        <asp:Button ID="btnSearchRecipients" runat="server" CssClass="targetwishlistbutton"
                                            Text="Search"></asp:Button>&nbsp;
                                        <asp:Button ID="btnCancelSearch" runat="server" CssClass="targetwishlistbutton" Text="Cancel">
                                        </asp:Button>&nbsp;
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow runat="server" ID="tblRowSearchStep2" Visible="false">
                                    <asp:TableCell ID="TableCell7" runat="server">
                                    </asp:TableCell>
                                    <asp:TableCell runat="server" ID="TableCell8">
                                        <asp:Button ID="btnSubmitPrivateListPassword" runat="server" CssClass="targetwishlistbutton"
                                            Text="Submit"></asp:Button>&nbsp;
                                        <asp:Button ID="btnCancelPrivateList" runat="server" CssClass="targetwishlistbutton"
                                            Text="Cancel"></asp:Button>&nbsp;
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Repeater runat="server" ID="rptOthers">
        <ItemTemplate>
            <uc1:OtherWishList ID="OtherList1" runat="server" RecipientID='<%# DataBinder.Eval(Container.DataItem,"recipient_id")%>'
                RecipientName='<%# DataBinder.Eval(Container.DataItem,"name")%>' />
            <br />
            <br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>