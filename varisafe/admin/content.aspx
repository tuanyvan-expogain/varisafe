<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="content.aspx.vb" Inherits="varisafe.content" validaterequest="false"%>
<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Edit Page Content</h2>
<hr>
<form id="Form1" name="Form1" method="post" runat="server">
    <asp:label id="lblError" runat="server" cssclass="error"></asp:label>
	<asp:datagrid id="dgContent" runat="server" autogeneratecolumns="False">
		<columns>
			<asp:templatecolumn visible="False">
				<itemtemplate>
					<asp:Label id="lblElementContentID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.elementContentID") %>'>
					</asp:label>
				</itemtemplate>
			</asp:templatecolumn>
			<asp:templatecolumn headertext="Page">
				<itemtemplate>
					<asp:Label id="lblPageName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.pageName") %>'>
					</asp:label>
				</itemtemplate>
			</asp:templatecolumn>
			<asp:templatecolumn headertext="Container">
				<itemtemplate>
					<asp:Label id="lblContainer" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.container") %>'>
					</asp:label>
				</itemtemplate>
			</asp:templatecolumn>
			<asp:templatecolumn headertext="Language">
				<itemtemplate>
					<asp:Label id="lblLanguage" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Language") %>'>
					</asp:label>
				</itemtemplate>
			</asp:templatecolumn>
			<asp:templatecolumn headertext="Edit">
				<itemtemplate>
					<asp:HyperLink id="lnkEdit" runat="server" Text="Edit" NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.elementContentID", "editcontent.aspx?ecid={0}") %>'>
					</asp:hyperlink>
				</itemtemplate>
			</asp:templatecolumn>
			<asp:templatecolumn visible="False" headertext="PageLanguageID">
				<itemtemplate>
					<asp:Label id="lblPageLanguageID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PageLanguageID") %>'>
					</asp:label>
				</itemtemplate>
			</asp:templatecolumn>
			<asp:templatecolumn visible="False" headertext="ElementID">
				<itemtemplate>
					<asp:Label id="lblElementID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ElementID") %>'>
					</asp:label>
				</itemtemplate>
			</asp:templatecolumn>
		</columns>
	</asp:datagrid></form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
