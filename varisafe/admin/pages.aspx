<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="pages.aspx.vb" Inherits="varisafe.pages" %>
<% Response.CacheControl = "no-cache" %>
<% Response.AddHeader ("Pragma", "no-cache") %> 
<% Response.Expires = -1 %>

<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Manage Web Pages</h2>
    <asp:label id="lblError" runat="server" cssclass="error"></asp:label>

<a href="page.aspx">Add New Web Page</a>
<hr>
<form id="Form1" method="post" runat="server">
	<asp:xml id="xmlSitemap" runat="server"></asp:xml></form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
