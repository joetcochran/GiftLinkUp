<%@ Page Language="VB" AutoEventWireup="false" CodeFile="create-single-step1.aspx.vb"
    Inherits="create_single_step1" Title="GiftLinkUp.com" MasterPageFile="~/NoLogin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">
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
            <td width="48%" align="right" class="forestgreen">
                Your Name: <span class="brightred">*</span><br>
                <span class="forestgreen small">(This is the name that will appear at the top of your
                    wish list.)</span></td>
            <td width="4%">
                &nbsp;</td>
            <td valign="top" width="48%" align="left">
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
                &nbsp;</td>
            <td align="left">
                <asp:Button runat="server" ID="btnNext" CssClass="stdinput  longish" Text="Continue" />
        </tr>
    </table>
</asp:Content>
