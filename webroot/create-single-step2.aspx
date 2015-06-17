<%@ Page Language="VB" MasterPageFile="~/NotLoggedIn.master" AutoEventWireup="false" CodeFile="create-single-step2.aspx.vb" Inherits="create_single_step2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript">
		
		
		function showHideContent(id, show)
		{
			
			//var elem = document.forms[0].getElementById(id);
				if (show) 
				{
					document.forms[0][id].style.display = 'block';
					document.forms[0][id].style.visibility = 'visible';
				} 
				else
				{
					document.forms[0][id].style.display = 'none';
					document.forms[0][id].style.visibility = 'hidden';
				}
			
		}   
		
	function bluractivity(divnbr)
	{
		nameelement = document.getElementById('tbEmail' + divnbr);
		namevalue = nameelement.value;
		divplus1 = (divnbr * 1) + 1
		targetdiv1 = 'email' + divplus1 ;
		
		if ( namevalue == '')
		{			
			cmd1 = 'showHideContent(\'' + targetdiv1 + '\', false)';	
		}
		else
		{
			cmd1 = 'showHideContent(\'' + targetdiv1 + '\', true)';			
		}
		eval(cmd1)		
		
	}		

			</script>

<table  cellSpacing="0" cellPadding="0" width="775" border="0">
							<tr>
								<td align="center" colSpan="3"><span class="big deepred">Please confirm the 
            information below.</span></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><br>
									<br>
								</td>
							</tr>
							<tr>
								<td class="forestgreen" align="right" width="48%">Your Email:
								</td>
								<td>&nbsp;
								</td>
								<td width="48%" align="left"><asp:label id="lblEmail" runat="server" CssClass="text3"></asp:label></td>
							</tr>
							<tr>
								<td class="forestgreen" align="right" width="48%">Your Name:
								</td>
								<td>&nbsp;
								</td>
								<td align="left" width="48%"><asp:label id="lblName" runat="server" CssClass="text3"></asp:label></td>
							</tr>
							<tr>
								<td colSpan="3"><br>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><span class="big deepred"><u>Please enter the email 
											addresses (up to 25) you wish to notify about your wish list.<br>
											They will be sent an invitation to set up a GiftLinkUp.com account.											
										</u>
									</span></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><span class="forestgreen"><b><u>Email</u></b></span></td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><asp:textbox id="tbEmail1" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
									&nbsp;
									<asp:customvalidator id="cv1" runat="server"></asp:customvalidator></td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email2"><asp:textbox id="tbEmail2" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv2" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email3"><asp:textbox id="tbEmail3" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv3" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email4"><asp:textbox id="tbEmail4" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv4" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email5"><asp:textbox id="tbEmail5" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv5" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email6"><asp:textbox id="tbEmail6" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv6" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email7"><asp:textbox id="tbEmail7" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv7" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email8"><asp:textbox id="tbEmail8" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv8" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email9"><asp:textbox id="tbEmail9" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv9" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email10"><asp:textbox id="tbEmail10" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv10" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email11"><asp:textbox id="tbEmail11" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv11" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email12"><asp:textbox id="tbEmail12" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv12" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email13"><asp:textbox id="tbEmail13" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv13" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email14"><asp:textbox id="tbEmail14" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv14" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email15"><asp:textbox id="tbEmail15" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv15" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email16"><asp:textbox id="tbEmail16" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv16" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email17"><asp:textbox id="tbEmail17" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv17" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email18"><asp:textbox id="tbEmail18" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv18" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email19"><asp:textbox id="tbEmail19" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv19" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email20"><asp:textbox id="tbEmail20" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv20" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email21"><asp:textbox id="tbEmail21" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv21" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email22"><asp:textbox id="tbEmail22" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv22" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3">
									<div id="email23"><asp:textbox id="tbEmail23" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv23" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><div id="email24"><asp:textbox id="tbEmail24" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv24" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="3"><div id="email25"><asp:textbox id="tbEmail25" runat="server" CssClass="stdinput" Width="196px"></asp:textbox>&nbsp; 
										&nbsp;
										<asp:customvalidator id="cv25" runat="server"></asp:customvalidator></div>
								</td>
							</tr>
							<TR>
								
								<td colspan="3" align="center"><asp:Button runat="server" ID="btnNext" CssClass="stdinput  longish" Text="Continue" /></td>
							</TR>
						</table>
						
<script type="text/javascript">
    var Email1 = '<%= tbEmail1.ClientID %>';
    var Email2 = '<%= tbEmail2.ClientID %>';
</script>


</asp:Content>

