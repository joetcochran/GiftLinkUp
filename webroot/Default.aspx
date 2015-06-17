<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default"
    MasterPageFile="~/NoLogin.master" %>

<asp:Content runat="Server" ContentPlaceHolderID="Main" ID="cphMain">
    <center>
        <table width="100%">
            <tr>
                <td valign="top">
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <asp:ImageButton runat="server" ID="btnCreate" ImageUrl="~/images/createbutton.jpg" />
                            </td>
                            <td align="center">
                                <asp:ImageButton runat="server" ID="btnFaq" ImageUrl="~/images/faq.jpg" />
                            </td>
                            <td align="center">
                                <asp:ImageButton runat="server" ID="btnTour" ImageUrl="~/images/tour.jpg" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Panel runat="server" ID="pnllogin" DefaultButton="Button1">
                        <table width="100%">
                            <tr>
                                <td width="40%" align="right">
                                    <b>Email:</b></td>
                                <td width="60%" align="left">
                                    <asp:TextBox ID="tbEmail" runat="server" CssClass="stdinput login" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <b>Password:</b></td>
                                <td align="left">
                                    <asp:TextBox ID="tbPassword" runat="server" CssClass="stdinput login" TextMode="Password"
                                        Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td align="left">
                                    <asp:Button ID="Button1" runat="server" CssClass="stdinput login" Text="Login" /></td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2" width="100%">
                                    <asp:Label ID="lblLoginErr" runat="server" CssClass="brightred small"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <br />
                    <img src ="images/screenshots.jpg" /><br />
                    <a href="images/screenshots/mmyitems2.jpg" class="highslide" onclick="return hs.expand(this)">
                        <img src="images/screenshots/mmyitems-thumb.jpg" alt="Manage your own wish list"
                            title="Click to enlarge" width="100" /></a>
                    <div class="highslide-caption">
                        Manage your own wish list.
                    </div>
                    <a href="images/screenshots/mmanagedlists2.jpg" class="highslide" onclick="return hs.expand(this)">
                        <img src="images/screenshots/mmanagedlists-thumb.jpg" alt="Manage your childrens' wish lists"
                            title="Click to enlarge" width="100" /></a>
                    <div class="highslide-caption">
                        Manage your childrens' wish lists.
                    </div>
                    <a href="images/screenshots/mlinkeduplists2.jpg" class="highslide" onclick="return hs.expand(this)">
                        <img src="images/screenshots/mlinkeduplists-thumb.jpg" alt="Manage your childrens' wish lists"
                            title="Click to enlarge" width="100" /></a>
                    <div class="highslide-caption">
                        Link-Up to other users' wish lists.
                    </div>
                    <a href="images/screenshots/mannounce3.jpg" class="highslide" onclick="return hs.expand(this)">
                        <img src="images/screenshots/mannounce-thumb.jpg" alt="Announce when you've purchased an item"
                            title="Click to enlarge" width="100" /></a>
                    <div class="highslide-caption">
                        Announce when you've purchased an item from someone's wish list.
                    </div>
                </td>
            </tr>
        </table>
        <!-- End ImageReady Slices -->
    </center>
</asp:Content>
