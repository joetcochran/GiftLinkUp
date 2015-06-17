<%@ Page Language="VB" MasterPageFile="~/Standard.master" AutoEventWireup="false" CodeFile="create-group-step2.aspx.vb" Inherits="create_group_step2" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Main" Runat="Server">
	<script language="javascript">
		function init()
		{
			showHideContent('name2a', false);
			showHideContent('name2b', false);
			showHideContent('name3a', false);
			showHideContent('name3b', false);
			showHideContent('name4a', false);
			showHideContent('name4b', false);
			showHideContent('name5a', false);
			showHideContent('name5b', false);
			showHideContent('name6a', false);
			showHideContent('name6b', false);
			showHideContent('name7a', false);
			showHideContent('name7b', false);
			showHideContent('name8a', false);
			showHideContent('name8b', false);
			showHideContent('name9a', false);
			showHideContent('name9b', false);
			showHideContent('name10a', false);
			showHideContent('name10b', false);
			showHideContent('name11a', false);
			showHideContent('name11b', false);
			showHideContent('name12a', false);
			showHideContent('name12b', false);
			showHideContent('name13a', false);
			showHideContent('name13b', false);
			showHideContent('name14a', false);
			showHideContent('name14b', false);
			showHideContent('name15a', false);
			showHideContent('name15b', false);
			showHideContent('name16a', false);
			showHideContent('name16b', false);
			showHideContent('name17a', false);
			showHideContent('name17b', false);
			showHideContent('name18a', false);
			showHideContent('name18b', false);
			showHideContent('name19a', false);
			showHideContent('name19b', false);
			showHideContent('name20a', false);
			showHideContent('name20b', false);
			showHideContent('name21a', false);
			showHideContent('name21b', false);
			showHideContent('name22a', false);
			showHideContent('name22b', false);
			showHideContent('name23a', false);
			showHideContent('name23b', false);
			showHideContent('name24a', false);
			showHideContent('name24b', false);
			showHideContent('name25a', false);
			showHideContent('name25b', false);
		}	
		

		function showHideContent(id, show)
		{
			
			var elem = document.getElementById(id);
			if (elem) 
			{
				if (show) 
				{
					elem.style.display = 'block';
					elem.style.visibility = 'visible';
				} 
				else
				{
					elem.style.display = 'none';
					elem.style.visibility = 'hidden';
				}
			}
		}   
	function bluractivity(divnbr, nameelement)
	{
		//nameelement = document.getElementById('tbName' + divnbr);
		nameelement = document.getElementById(nameelement);
		namevalue = nameelement.value;
		divplus1 = (divnbr * 1) + 1
		targetdiv1 = 'name' + divplus1 + 'a';
		targetdiv2 = 'name' + divplus1 + 'b';
		if ( namevalue == '')
		{			
			cmd1 = 'showHideContent(\'' + targetdiv1 + '\', false)';
			cmd2 = 'showHideContent(\'' + targetdiv2 + '\', false)';
		}
		else
		{
			cmd1 = 'showHideContent(\'' + targetdiv1 + '\', true)';
			cmd2 = 'showHideContent(\'' + targetdiv2 + '\', true)';
		}
		eval(cmd1)
		eval(cmd2)
		
	}
		
		
		
	</script>
	
	
	<table width="100%" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td colspan="4" align="center"><span class="big deepred"> Please confirm the information you provided below.</span></td>
							</tr>
							<tr>
								<td width="48%" align="right" class="forestgreen">Your Name:
								</td>
								<td>&nbsp;</td>
								<td width="202"> 
								<asp:Label id="lblName" runat="server" CssClass="text3"></asp:Label></td>
								<td></td>
							</tr>
							<tr>
								<td width="48%" align="right" class="forestgreen">Your Email:
								</td>
								<td>&nbsp;</td>
								<td width="202"><asp:Label id="lblEmail" runat="server" CssClass="text3"></asp:Label></td>
								<td></td>
							</tr>
							<tr>
								<td colspan="4"><br>
								</td>
							</tr>
							<tr>
								<td colspan="4" align="center">
									<P><span class="big deepred"><u>Not including yourself,</u> please enter the names and email addresses <br>of the people who 
            should have their own wish lists (up to 25).
						</span><br>
										<br>
										<SPAN class="big deepred"></SPAN>
										<SPAN class="big deepred">
											<asp:CustomValidator id="cvDuplicateNames" runat="server"></asp:CustomValidator>
											<br>
											<asp:CustomValidator id="cvAtLeastOneOtherMember" runat="server"></asp:CustomValidator>
									    </SPAN>
						    </td>
							</tr>							
							<tr>
								<td width="48%" align="right" class="forestgreen" valign="top"><b><u>Name</u></b><br>
									<span class="small">(This is the name that will appear <br>at the top of their wish list.)</span></td>
								<td>&nbsp;</td>
								<td width="202" align="left"><span class="forestgreen"><b><u>Email</u></b>
										<br>
										<span class="small">(For children, pets, or those without <br>email addresses, leave email blank)</span>
									</span></td>
								<td></td>
							</tr>
							<div id="name1">
							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
									<asp:TextBox id="tbName1" runat="server" CssClass="stdinput rightalign"></asp:TextBox></td>
								<td>&nbsp;</td>
								<td valign="top" width="202" align="left">
									<asp:TextBox id="tbEmail1" runat="server" CssClass="stdinput"></asp:TextBox></td>
								<td valign="top" >
									<asp:CustomValidator id="cv1" runat="server"></asp:CustomValidator></td>
							</tr>
							</div>
							
							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name2a">
									<asp:TextBox id="tbName2" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name2b">
									<asp:TextBox id="tbEmail2" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv2" runat="server"></asp:CustomValidator>&nbsp;</td>
							</tr>
							
							
							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name3a">
									<asp:TextBox id="tbName3" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td valign="top"> </td>
								<td width="202" align="left">
								<div id="name3b">
									<asp:TextBox id="tbEmail3" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv3" runat="server"></asp:CustomValidator></td>
							</tr>							
							
							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name4a">							
									<asp:TextBox id="tbName4" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td></td>
								<td valign="top" width="202" align="left">
								<div id="name4b">			
									<asp:TextBox id="tbEmail4" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv4" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name5a">															
									<asp:TextBox id="tbName5" runat="server" CssClass="stdinput rightalign"></asp:TextBox>									
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name5b">															
									<asp:TextBox id="tbEmail5" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv5" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name6a">
									<asp:TextBox id="tbName6" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name6b">
									<asp:TextBox id="tbEmail6" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv6" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name7a">
									<asp:TextBox id="tbName7" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name7b">
									<asp:TextBox id="tbEmail7" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv7" runat="server"></asp:CustomValidator></td>
							</tr>
							
							
							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name8a">
									<asp:TextBox id="tbName8" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name8b">
									<asp:TextBox id="tbEmail8" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv8" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name9a">
									<asp:TextBox id="tbName9" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name9b">
									<asp:TextBox id="tbEmail9" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv9" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen" height="20">
								<div id="name10a">
									<asp:TextBox id="tbName10" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" height="20" width="202" align="left">
								<div id="name10b">
									<asp:TextBox id="tbEmail10" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv10" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name11a">
									<asp:TextBox id="tbName11" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name11b">
									<asp:TextBox id="tbEmail11" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv11" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name12a">
									<asp:TextBox id="tbName12" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name12b">
									<asp:TextBox id="tbEmail12" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv12" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name13a">
									<asp:TextBox id="tbName13" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>									
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name13b">
									<asp:TextBox id="tbEmail13" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv13" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name14a">
									<asp:TextBox id="tbName14" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name14b">
									<asp:TextBox id="tbEmail14" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv14" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name15a">
									<asp:TextBox id="tbName15" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name15b">
									<asp:TextBox id="tbEmail15" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv15" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name16a">
									<asp:TextBox id="tbName16" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name16b">
									<asp:TextBox id="tbEmail16" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv16" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name17a">
									<asp:TextBox id="tbName17" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name17b">
									<asp:TextBox id="tbEmail17" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv17" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name18a">
									<asp:TextBox id="tbName18" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name18b">
									<asp:TextBox id="tbEmail18" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv18" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name19a">
									<asp:TextBox id="tbName19" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name19b">
									<asp:TextBox id="tbEmail19" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv19" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name20a">
									<asp:TextBox id="tbName20" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name20b">
									<asp:TextBox id="tbEmail20" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv20" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name21a">
									<asp:TextBox id="tbName21" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name21b">
									<asp:TextBox id="tbEmail21" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv21" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name22a">
									<asp:TextBox id="tbName22" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name22b">
									<asp:TextBox id="tbEmail22" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv22" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen" height="20">
								<div id="name23a">
									<asp:TextBox id="tbName23" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" height="20" width="202" align="left">
								<div id="name23b">
									<asp:TextBox id="tbEmail23" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv23" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name24a">
									<asp:TextBox id="tbName24" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name24b">
									<asp:TextBox id="tbEmail24" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv24" runat="server"></asp:CustomValidator></td>
							</tr>

							<tr>
								<td valign="top" width="48%" align="right" class="forestgreen">
								<div id="name25a">
									<asp:TextBox id="tbName25" runat="server" CssClass="stdinput rightalign"></asp:TextBox>
								</div>
								</td>
								<td> </td>
								<td valign="top" width="202" align="left">
								<div id="name25b">
									<asp:TextBox id="tbEmail25" runat="server" CssClass="stdinput"></asp:TextBox>
								</div>
								</td>
								<td valign="top">
									<asp:CustomValidator id="cv25" runat="server"></asp:CustomValidator></td>
							</tr>
							
							<TR>
								<td align="right">
									<asp:ImageButton id="btnPrev" runat="server" ImageUrl="images/previous.jpg"></asp:ImageButton></td>
								<td></td>
								<td align="left" width="202">
									<asp:ImageButton id="btnNext" runat="server" ImageUrl="images/next.jpg"></asp:ImageButton></td>
								<td></td>
							</TR>
						</table>
					



</asp:Content>

