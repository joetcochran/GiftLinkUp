<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false" CodeFile="create-group-step1.aspx.vb" Inherits="create_group_step1" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td colspan="3" align="center"><span class="big deepred">Please enter some of your information below.</span></td>
							</tr>
							<tr>
								<td colspan="3" align="center">
								</td>
							</tr>
							<tr>
								<td width="48%" align="right" class="forestgreen">Your Name:
									<span class="brightred">*</span><BR>
									<SPAN class="forestgreen small">(This is the name that will appear at 
the top of your wish list.)</SPAN></td>
								<td width="4%">&nbsp;</td>
								<td valign="top" width="48%" align="left">
									<asp:TextBox id="tbName" runat="server" CssClass="stdinput longish"></asp:TextBox>
								
									<asp:CustomValidator id="cvName" runat="server" Display="dynamic"></asp:CustomValidator></td>
							</tr>
							<tr>
								<td align="right" class="forestgreen" valign="top">Your Email:
									<span class="brightred">*</span></td>
								<td>&nbsp;</td>
								<td valign="top" align="left">
									<asp:TextBox id="tbEmail" runat="server" CssClass="stdinput longish"></asp:TextBox>
									<asp:CustomValidator id="cvEmail" runat="server" Display="dynamic"></asp:CustomValidator></td>
							</tr>
							<tr>
								<td colspan="3"><br>
								</td>
							</tr>
							<tr>
								<td align="right" class="forestgreen">Please enter a password:
									<span class="brightred">*</span></td>
								<td>&nbsp;</td>
								<td align="left">
									<asp:TextBox id="tbPassword" runat="server" CssClass="stdinput longish" TextMode="Password"></asp:TextBox>
									<asp:CustomValidator id="cvPassword" runat="server" Display="dynamic" ></asp:CustomValidator></td>
							</tr>
							<tr>
								<td align="right" class="forestgreen">Please re-enter the password:
									<span class="brightred">*</span></td>
								<td>&nbsp;</td>
								<td align="left">
									<asp:TextBox id="tbPasswordConfirm" runat="server" CssClass="stdinput longish" TextMode="Password"></asp:TextBox>
																		<asp:CustomValidator id="cvPasswordConfirm"  Display="dynamic" runat="server"></asp:CustomValidator></td>
							</tr>
							<tr>
								<td align="right">
									<P><span class="brightred small">* = Required<br></span></P>
								</td>
								<td colspan="2"></td>
							</tr>
							<tr>
								<td align="right" valign="top"></td>
								<td>&nbsp;</td>
								<td align="left">
									<asp:Button runat="server" ID="btnNext" CssClass="stdinput  longish" Text="Continue" />
								
							</tr>
						</table>
</asp:Content>

