<%@ Page Language="vb" AutoEventWireup="false" Codebehind="menu.aspx.vb" Inherits="varisafe.menu" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>

		<uc1:header id="Header1" runat="server"></uc1:header>
		<h2>Welcome to Your Web Site Control Panel</h2>
		<h4>Instructions:</h4>
		<ul id="menu">
			<li>
				To Create or Edit Web site pages click the <a href="pages.aspx">Pages</a> link.
			</li>
			<li>
				To add content or edit content click the <a href="content.aspx">Content</a> link.
			</li>
			<li>
				To add or Edit news items click the <a href="news.aspx">News Items</a> link.
			</li>
		</ul>
	<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</body>
</html>
