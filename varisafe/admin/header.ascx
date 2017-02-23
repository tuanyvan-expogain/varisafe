<%@ Control Language="vb" AutoEventWireup="false" Codebehind="header.ascx.vb" Inherits="varisafe.header1" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" "http://www.w3.org/tr/xhtml1/dtd/xhtml1-transitional.dtd">
<%Dim strServer As String = Request.ServerVariables("SERVER_NAME").ToLower

    If InStr(strServer, "www.varisafe.ca") <= 0 Then
        Dim strURL As String
        Dim qs As String = ""

        If Len(Request.QueryString.ToString) > 0 Then
            qs = "?" + Request.QueryString.ToString
        End If

        strURL = "https://www.varisafe.ca" + Request.ServerVariables("SCRIPT_NAME") + qs
        'The next line is active in the live site but doesn't work on localhost
        'Response.Redirect(strURL)
    End If

    If InStr(strServer, "www.varisafe.ca") > 0 Then
        If Request.ServerVariables("HTTPS") = "off" Then
            Dim strURL As String
            Dim qs As String = ""

            If Len(Request.QueryString.ToString) > 0 Then
                qs = "?" + Request.QueryString.ToString
            End If

            strURL = "https://www.varisafe.ca" + Request.ServerVariables("SCRIPT_NAME") + qs
            'The next line is active in the live site but doesn't work on localhost
            'Response.Redirect(strURL)
        End If
    End If%>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
	<head>
		<title>Vari SAFE Control Panel</title>
	    <link rel="stylesheet" href="control.css" />
	</head>
	<script language="javascript" src="/scripts.js" type="text/javascript"></script>
	<body>
			<div id="container">
			<div id="header">
			
				<img src="../images/logo.jpg" alt="Vari SAFE Site Control Panel" />
			
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
					<a href="courses.aspx">Courses</a>
				</li>
				
					<li>
					<a href="registrations.aspx">Registrations</a>
				</li>
				
				<li id="liPages" runat="server">
					<asp:hyperlink id="lnkPages" navigateurl="pages.aspx" runat="server" visible="true">Pages</asp:hyperlink>
				</li>
				<li id="liContent" runat="server">
					<asp:hyperlink id="lnkContent" navigateurl="content.aspx" runat="server" visible="true">Content</asp:hyperlink>
				</li>
				<li id="liTemplates" runat="server">
					<asp:hyperlink id="lnkTemplates" navigateurl="templates.aspx" runat="server" visible="true">Templates</asp:hyperlink>
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
			

