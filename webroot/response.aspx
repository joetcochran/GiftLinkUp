<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false" CodeFile="response.aspx.vb" Inherits="response" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">

<div class="roundedcornr_box_655973">
   <div class="roundedcornr_top_655973"><div></div></div>
   
    <div class="roundedcornr_content_655973">
    
    <br /><br />
    <asp:Label runat="server" visible= "false" ID="lblSuccess" CssClass="deepred x-big">Thank you. [##MESSAGE##]</asp:Label>
    
    <asp:Label visible="false" runat="server" ID="lblFailure" CssClass="deepred x-big">Sorry, there was a problem with the request you made. Please check the URL from your email and try again.</asp:Label>
    <br /><br />
    
    
        </div>
    
    <div class="roundedcornr_bottom_655973"><div></div></div>
</div>
</asp:Content>


