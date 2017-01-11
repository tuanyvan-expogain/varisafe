<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="varisafe._default1" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
        "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html>
	<head>
		<title>Vari SAFE Control Panel</title>
		<link rel="stylesheet" href="control.css">
	</head>
		<body>
		<form id="Form1" method="post" runat="server">
			<div id="container">
			<div id="header">
			
				<img src="/images/logo.jpg" alt="Vari SAFE Site Control Panel" />
				
				<h6>
					Site Control Panel
				</h6>
				<hr />
			</div>
				<div id="main">
					
					<h4>Instructions: Enter your username and password to enter secure web site.  </h4>
					<div>
						<span class="label">Username:</span>
						<asp:textbox id="txtUsername" runat="server"></asp:textbox>
					</div>
					<div>
						<span class="label">Password:</span>&nbsp;
						<asp:textbox id="txtPassword" runat="server" textmode="Password"></asp:textbox>
					</div>
					<div>
						<asp:button id="btnLogin" CssClass="btn" runat="server" text="Login"></asp:button>
					</div>
					<asp:label id="lblError" runat="server"></asp:label>
				</div>
			</div>
		</form>
			<uc1:footer id="Footer1" runat="server"></uc1:footer>
	</body>
</html>
