<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false" CodeFile="create-group-step3.aspx.vb" Inherits="setup_group_step3" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">

<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td align="center" colSpan="3"><br>
			<asp:table id="tblNoEmail" runat="server" Width="80%" CellSpacing="0" CellPadding="0">
				<asp:TableRow>
					<asp:TableCell  VerticalAlign="top" Width="50%">
						<table width="100%"><tr><td class="infocell">
						<span class="forestgreen"><b><u>Why is this needed?</u></b><br><br>Since no email 
						address is entered, this person will not be able to log-in to 
						GiftLinkUp.com.<br><br>Therefore, you need to&nbsp;tell 
						us&nbsp;which people will be allowed to enter gifts for 
						them.<br><br>For 
						children or pets, this is usually the <br><b><u>parent(s) or guardian(s)</u></b>.</span>
						</td></tr></table>
					</asp:TableCell>
					<asp:TableCell Width="50%"  HorizontalAlign="center" VerticalAlign ="top">
						
							<asp:label id="lblNoEmail" Height="32px"  CssClass="big deepred" runat="server">
								(!person_name!) does not have an email.<br>Please select the person or people that will be acting upon their behalf.
							</asp:label>
						<br /><br /><br />
						<asp:checkboxlist id="cblProxySelection" runat="server" CssClass="forestgreen" Width="216px"></asp:checkboxlist>
					</asp:TableCell>
				</asp:TableRow>
			</asp:table>
			<P>&nbsp;</P>
			<P>&nbsp;</P>
		</td>
	</tr>
	<tr>
		<td align="center" colSpan="3">
			<table cellSpacing="0" cellPadding="0" width="80%" border="0">
				<tr>
					<td vAlign="top" width="50%">
					<table width="100%"><tr><td class="infocell" valign="top"><span class="forestgreen"><b><u>Why is this 
									needed?</u></b><br /><br />When someone 
uses GiftLinkUp.com to get a gift off of the wish list, we 
need to know who to send the email notifications to. </span></td></tr></table>
</td>
					<td vAlign="top" width="50%">
						<center><asp:label id="lblNotifyLabel" Height="0px" runat="server" CssClass="big deepred">
					Who should we notify when a gift is purchased for (!person_name!)?
				</asp:label></center><br /><br /><br />
						<asp:checkboxlist id="cblNotifySelection" runat="server" CssClass="forestgreen" Width="216px"></asp:checkboxlist></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td align="center" colSpan="3"><span class="big deepred">
				<asp:CustomValidator id="cvGeneric" runat="server"></asp:CustomValidator>
				<br>
			</span></td>
	</tr>
	<tr>
	</tr>
	<TR>
		<td align="right" width="48%"><asp:imagebutton id="imgPrevious" runat="server" Width="100px" ImageUrl="images/previous.jpg"></asp:imagebutton></td>
		<td></td>
		<td align="left" width="48%"><asp:imagebutton id="imgNext"  runat="server" Width="100px" ImageUrl="images/next.jpg"></asp:imagebutton></td>
	</TR>

</table>

</asp:Content>

