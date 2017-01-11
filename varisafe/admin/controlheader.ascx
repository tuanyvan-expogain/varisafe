<%@ Control Language="vb" AutoEventWireup="false" Codebehind="controlheader.ascx.vb" Inherits="varisafe.controlheader" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/dtd/xhtml1-transitional.dtd">


		<div id="container">
			<div id="header">
			
			<img src="~/images/logo.jpg" alt="Knowles/Woolsey Site Control Panel" />
			
			<h6>
				 Site Control Panel
			</h6>
		    </div>
		    <div id="links">
			    <ul id="nav">
				    <li>
					    <a href="menu.aspx">Home</a>
				    </li>
				    <li>
					    <a href="news.aspx">News Items</a> 
					    <!--<li>
					    <a href="events.aspx">Events</a></li>-->
				    </li>
				    <li>
				        <a href="subscriptions.aspx">Subscriptions</a>
				    </li>
				    <!--
				    <li>
					    <a href="newsletters.aspx">Send Email</a>
				    </li>-->
				    <li id="liPages" runat="server">
					    <asp:hyperlink id="lnkPages" navigateurl="pages.aspx" runat="server" visible="False">Pages</asp:hyperlink>
				    </li>
				    <li id="liContent" runat="server">
					    <asp:hyperlink id="lnkContent" navigateurl="content.aspx" runat="server" visible="False">Content</asp:hyperlink>
				    </li>
				    <li id="liTemplates" runat="server">
					    <asp:hyperlink id="lnkTemplates" navigateurl="templates.aspx" runat="server" visible="False">Templates</asp:hyperlink>
				    </li>
				    <li>
					    <a href="../default.aspx">View Site</a>
				    </li>
				    <li>
					    <a href="signout.aspx">Sign Out</a>
				    </li>
			    </ul>
		    </div>
		    <div id="main">
			

