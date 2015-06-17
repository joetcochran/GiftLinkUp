<%@ Page Language="VB" MasterPageFile="~/NoLogin.master" AutoEventWireup="false"
    CodeFile="light-fuse.aspx.vb" Inherits="light_fuse" Title="GiftLinkUp.com" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
    <asp:Label runat="server" ID="lblBlock" Height="250" Visible="false"><b>
        <br /><br />Your email address has been added to our block-list. Thank you!
        </b>
    </asp:Label>
    <asp:Panel runat="server" ID="pnlSHARE" Visible="false">
        <asp:Label runat="server" ID="Label1" Font-Bold="true" Font-Size="Larger">Welcome to GiftLinkUp.com!
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" align="center">
                        <span class="big deepred">The new wish list has been added to your set of managed wish lists.</span></td>
                </tr>
                <tr><td><br /><br />        <asp:Button runat="server" ID="btnSHARE_Next" CssClass="stdinput  longish" Text="Continue" /><br /><br />
                </td></tr>
                </table>
        </asp:Label>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlINVIT" Visible="false">
        <asp:Label runat="server" ID="lblWelcome" Font-Bold="true" Font-Size="Larger">Welcome
            to GiftLinkUp.com!
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" align="center">
                        <span class="big deepred">Please enter some of your information below.</span></td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                    </td>
                </tr>
                <tr>
                    <td width="38%" align="right" class="forestgreen">
                        Your Name: <span class="brightred">*</span><br>
                        <span class="forestgreen small">(This is the name that will appear at the top of your
                            wish list.)</span></td>
                    <td width="4%">
                        &nbsp;</td>
                    <td valign="top" width="58%" align="left">
                        <asp:TextBox ID="tbName" runat="server" CssClass="stdinput longish"></asp:TextBox>
                        <asp:CustomValidator ID="cvName" runat="server" Display="dynamic"></asp:CustomValidator></td>
                </tr>
                <tr>
                    <td align="right" class="forestgreen" valign="top">
                        Your Email: <span class="brightred">*</span></td>
                    <td>
                        &nbsp;</td>
                    <td valign="top" align="left">
                        <asp:TextBox ID="tbEmail" runat="server" CssClass="stdinput longish"></asp:TextBox>
                        <asp:CustomValidator ID="cvEmail" runat="server" Display="dynamic"></asp:CustomValidator></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="forestgreen">
                        Please enter a password: <span class="brightred">*</span></td>
                    <td>
                        &nbsp;</td>
                    <td align="left">
                        <asp:TextBox ID="tbPassword" runat="server" CssClass="stdinput longish" TextMode="Password"></asp:TextBox>
                        <asp:CustomValidator ID="cvPassword" runat="server" Display="dynamic"></asp:CustomValidator></td>
                </tr>
                <tr>
                    <td align="right" class="forestgreen">
                        Please re-enter the password: <span class="brightred">*</span></td>
                    <td>
                        &nbsp;</td>
                    <td align="left">
                        <asp:TextBox ID="tbPasswordConfirm" runat="server" CssClass="stdinput longish" TextMode="Password"></asp:TextBox>
                        <asp:CustomValidator ID="cvPasswordConfirm" Display="dynamic" runat="server"></asp:CustomValidator></td>
                </tr>
                <tr>
                    <td align="right">
                        <p>
                            <span class="brightred small">* = Required<br>
                            </span>
                        </p>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">
                    </td>
                    <td>
                        <asp:HiddenField runat="server" ID="hdnInviter" />
                        <asp:HiddenField runat="server" ID="hdnFuseActionID" />
                        <asp:HiddenField runat="server" ID="hdnFuseTag" />
                        &nbsp;</td>
                    <td align="left">
                        <asp:Button runat="server" ID="btnNext" CssClass="stdinput  longish" Text="Continue" />
                </tr>
            </table>
        </asp:Label>
    </asp:Panel>
</asp:Content>
