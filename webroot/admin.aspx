<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false" CodeFile="admin.aspx.vb" Inherits="admin" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Non-Query"></asp:Label>
    <br />
    <asp:TextBox ID="tbNonQuery" runat="server" Rows="5" TextMode="MultiLine" Width="508px"></asp:TextBox><br />
    <br />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Query"></asp:Label><br />
    <asp:TextBox ID="tbQuery" runat="server" Rows="5" TextMode="MultiLine" Width="508px"></asp:TextBox><br />
    <asp:DropDownList ID="ddlCommonQueries" runat="server" AutoPostBack="True">
        <asp:ListItem Value="0">- Common Queries -</asp:ListItem>
        <asp:ListItem Value="1">- Activity Log (last 100) -</asp:ListItem>
        <asp:ListItem Value="2">- Recipients (last 10) -</asp:ListItem>
        <asp:ListItem Value="3">- Gifts (last 10) -</asp:ListItem>
    </asp:DropDownList><br />
    <br />
    <asp:Button ID="btnExecute" runat="server" Text="Execute" /><br />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <EditRowStyle BackColor="#999999" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>


</asp:Content>

