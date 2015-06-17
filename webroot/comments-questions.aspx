<%@ Page Language="VB" MasterPageFile="~/NotLoggedIn.master" AutoEventWireup="false"
    CodeFile="comments-questions.aspx.vb" Inherits="comments_questions" Title="GiftLinkUp.com - Comments and Questions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="775">
        <tr>
            <td valign="top">
                <div class="roundedcornr_box_512359">
                    <div class="roundedcornr_top_512359">
                        <div>
                        </div>
                    </div>
                    <div class="roundedcornr_content_512359">
                        <table cellspacing="4" cellpadding="0" width="95%">
                            <tr>
                                <td>
                                    <span class="forestgreen big">We are interested in your feedback!</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br>
                                    <br>
                                    <table cellspacing="0" cellpadding="8" width="100%">
                                        <tr>
                                            <td align="center">
                                                <span class="forestgreen"><asp:Label runat="server" ID="lblUserInfo">Please use the form below to provide feedback to the GiftLinkUp.com
                                                    team. We're always open to new ideas and features that can be added to the site!<br />
                                                    </asp:Label>
                                                    
                                                    
                                                    <asp:TextBox runat="server" CssClass="stdinput-forestgreen" ID="txtFeedback" Rows="4" Columns="60"
                                                        TextMode="MultiLine" />
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <span class="forestgreen">Your Email Address (optional):
                                                    <asp:TextBox class="stdinput-forestgreen" runat="server" ID="txtEmail"></asp:TextBox>
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="targetwishlistbutton">
                                                    </asp:Button>
                                                </span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="roundedcornr_bottom_512359">
                        <div>
                        </div>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
