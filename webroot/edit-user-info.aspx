<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false"
    CodeFile="edit-user-info.aspx.vb" Inherits="edit_user_info" Title="GiftLinkUp.com - Edit Personal Information" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" runat="Server">

    <script language="javascript">
	function showpublicprivate()
	{
		document.getElementById('publicprivate').style.display = 'block';
		document.getElementById('whatispublicprivate').style.display = 'none';
	}
	function showpublicprivate2()
	{
		document.getElementById('publicprivate2').style.display = 'block';
		document.getElementById('whatispublicprivate2').style.display = 'none';
	}


    </script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td valign="top" width="100%">
                        <div class="roundedcornr_box_655973">
                            <div class="roundedcornr_top_655973">
                                <div>
                                </div>
                            </div>
                            <div class="roundedcornr_content_655973">
                                <asp:Label  ID="lblSuccess" runat="server"  style="font-size:12pt;   font-weight:bold;" Visible="False">
			<br>
			Your profile has been successfully updated. Thank you.
			<br>
			<br>
                                </asp:Label>
                                <table cellspacing="4" cellpadding="0" width="95%">
                                    <tr>
                                        <td width="48%" valign="top" align="right">
                                            <span class="deepred"><b>&nbsp;&nbsp;&nbsp; Name:</b></span>
                                        </td>
                                        <td width="2%">
                                            &nbsp;
                                        </td>
                                        <td width="48%" valign="top" align="left">
                                            <asp:TextBox ID="tbName" runat="server" CssClass="stdinput-deepred"></asp:TextBox><span
                                                class="deepred"><b>
                                                    <asp:CustomValidator ID="cvName" runat="server" CssClass="small"></asp:CustomValidator></b></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="48%" valign="top" align="right">
                                            <span class="deepred"><b>&nbsp;&nbsp;&nbsp; Email:</b></span>
                                        </td>
                                        <td width="2%">
                                            &nbsp;
                                        </td>
                                        <td width="48%" valign="top" align="left">
                                            <asp:TextBox ID="tbEmail" runat="server" CssClass="stdinput-deepred long"></asp:TextBox><span
                                                class="deepred"><b>
                                                    <asp:CustomValidator ID="cvEmail" runat="server" CssClass="small"></asp:CustomValidator></b></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="48%" valign="top" align="right">
                                            <span class="deepred"><b>Current Password:</b></span>
                                        </td>
                                        <td width="2%">
                                            &nbsp;
                                        </td>
                                        <td width="48%" valign="top" align="left">
                                            <asp:TextBox ID="tbCurrentPassword" runat="server" CssClass="stdinput-deepred" TextMode="Password"></asp:TextBox>
                                            <asp:CustomValidator ID="cvCurrentPassword" runat="server" CssClass="small"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="48%" valign="top" align="right">
                                            <span class="deepred"><b>New Password:</b></span>
                                        </td>
                                        <td width="2%">
                                            &nbsp;
                                        </td>
                                        <td width="48%" valign="top" align="left">
                                            <asp:TextBox ID="tbPassword" runat="server" CssClass="stdinput-deepred" TextMode="Password"></asp:TextBox>
                                            <asp:CustomValidator ID="cvPassword" runat="server" CssClass="small"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="48%" valign="top" align="right">
                                            <span class="deepred"><b>Confirm New Password:</b></span>
                                        </td>
                                        <td width="2%">
                                            &nbsp;
                                        </td>
                                        <td width="48%" valign="top" align="left">
                                            <asp:TextBox ID="tbPasswordConfirm" runat="server" CssClass="stdinput-deepred" TextMode="Password"></asp:TextBox>
                                            <asp:CustomValidator ID="cvPasswordConfirm" runat="server" CssClass="small"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="48%" valign="top" align="right">
                                            <span class="deepred"><b>Wish List Type:</b></span><br>
                                            <div id="whatispublicprivate">
                                                <a href="javascript:showpublicprivate();"><span class="deepred small">What is this?</span></a></div>
                                            <div id="publicprivate" style="display: none">
                                                <span class="deepred small">If your wish list is <b>Public</b>, it can be viewed by
                                                    other GiftLinkUp.com users when they search for your email address.<br>
                                                    <br>
                                                    Access to a <b>Private</b> Wish List is limited to the people you specify.</span></div>
                                        </td>
                                        <td width="2%">
                                            &nbsp;
                                        </td>
                                        <td width="48%" valign="top" align="left">
                                            <asp:RadioButton CausesValidation="false" AutoPostBack="true"  ID="optPublic" runat="server" CssClass="deepred" Text="Public" GroupName="SearchableInd">
                                            </asp:RadioButton>&nbsp;&nbsp;&nbsp;
                                            <asp:RadioButton  CausesValidation="false" AutoPostBack="true" ID="optPrivate" runat="server" CssClass="deepred" Text="Private"
                                                GroupName="SearchableInd"></asp:RadioButton><br>
                                        </td>
                                    </tr>
                                    <asp:Panel runat="server" ID="pnlPrivateListPassword" Visible="false">
                                    <tr>
                                        <td width="48%" valign="top" align="right">
                                            <span class="deepred"><b>
                                                <asp:Label runat="server" ID="lblPrivateWishListPassword" Text="Private Wish List Password"></asp:Label></b></span><br>
                                            <div id="whatispublicprivate2">
                                                <a href="javascript:showpublicprivate2();"><span class="deepred small">What is this?</span></a></div>
                                            <div id="publicprivate2" style="display: none">
                                                <span class="deepred small">If your wish list is <b>Private</b>, this is the password
                                                    that other GiftLinkUp.com users must enter before it can be viewed by them.<br>
                                                    <br>
                                        </td>
                                        <td width="2%">
                                            &nbsp;
                                        </td>
                                        <td width="48%" valign="top" align="left">
                                            <asp:TextBox runat="server" ID="txtPrivateListPassword" CssClass="stdinput-deepred"></asp:TextBox>
                                            <asp:CustomValidator ID="cvPrivateListPassword" runat="server" CssClass="small"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    </asp:Panel>
                                    <tr>
                                        <td align="right">
                                            <span class="deepred"><b>Forgotten Password Challenge Question:</b></span>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboChallengeQuestion" runat="server" CssClass="stdinput-deepred"
                                                DataTextField="question" DataValueField="challenge_question_id">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <span class="deepred"><b>Forgotten Password Challenge Answer:</b></span>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtChallengeAnswer" runat="server" CssClass="stdinput-deepred long"></asp:TextBox>
                                            <asp:CustomValidator ID="cvAnswer" runat="server" CssClass="small"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <br />
                                            <p>
                                                <asp:Button ID="btnSave" runat="server" CssClass="stdinput-deepred" Text="   Save Changes   ">
                                                </asp:Button></p>
                                            <p>
                                                &nbsp;</p>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
