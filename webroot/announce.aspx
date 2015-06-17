<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false" CodeFile="announce.aspx.vb" Inherits="Announce" title="GiftLinkUp.com" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
<table width="100%">
<tr>

<td valign="top" width="100%">


<div class="roundedcornr_box_512359">
   <div class="roundedcornr_top_512359"><div></div></div>
   
    <div class="roundedcornr_content_512359">


		<table cellSpacing="4" cellPadding="0" width="95%">
			<tr>
				<td><span class="forestgreen big">If you purchased a gift for
						<%=TargetRecipientName%> , please use the form below:</span></td>
			</tr>
			<tr>
				<td><br>
					<br>
					<table cellSpacing="0" cellPadding="8" width="100%">
						<tr>
							<td align="center"><span class="forestgreen"><b>What item did you purchase for
										<%=TargetRecipientName%>
										?</b></span><br>
                                <asp:DropDownList width="250" ID="cboGifts" runat="server">
                                </asp:DropDownList>
                                <br /><br />
                                Additional Information:<br />
								<textarea class="stdinput-forestgreen" name="description" rows="4" cols="60"></textarea></td>
						</tr>
						<tr>
							<td align="center">
							<span class="forestgreen">By clicking the button below, an email will be sent to <b>everyone</b> who intends to get <%=TargetRecipientName%> a gift this year.</span><br>
								<br>
								<input type="hidden" name="target_recipient_id" value="<%=TargetRecipientID%>">
								<asp:Button id="btnAnnounce" runat="server" Text="Announce This Gift" CssClass="targetwishlistbutton"></asp:Button></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
    
        </div>
   
    <div class="roundedcornr_bottom_512359"><div></div></div>
</div>



</td></tr></table>
</asp:Content>

