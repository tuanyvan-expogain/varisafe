<%@ Page Language="vb" AutoEventWireup="false" Codebehind="template.aspx.vb" Inherits="varisafe.template" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Page Template</h2>
<form id="Form1" method="post" runat="server">
    <asp:label id="lblError" runat="server" cssclass="error"></asp:label>

	<div>
		<h3>Add Container to
			<asp:label id="lblTemplateName" runat="server" font-underline="true"></asp:label>&nbsp;Template
			<asp:label id="lblTemplateID" runat="server" visible="False"></asp:label></h3>
		<div><span>Choose Container:</span><asp:dropdownlist id="cboContainerID" runat="server"></asp:dropdownlist>
		</div>
		<div><span>Choose Parent (optional):</span>
			<asp:dropdownlist id="cboParentID" runat="server"></asp:dropdownlist></div>
		<div><asp:button id="btnSave" runat="server" text="Add"></asp:button></div>
		<hr>
	</div>
	<div>
		<h4>Add Control to Container</h4>
		<div><span>Choose Container:</span>
			<asp:dropdownlist id="cboContainerID2" runat="server"></asp:dropdownlist></div>
		<div><span>Choose Control:</span>
			<asp:dropdownlist id="cboElementID2" runat="server"></asp:dropdownlist></div>
		<div><span>Enter Control Order:</span>
			<asp:textbox id="txtElementOrder2" runat="server" width="72px"></asp:textbox></div>
		<div>&nbsp;
			<asp:button id="btnSaveElement" runat="server" text="Add"></asp:button></div>
		<hr>
	</div>
	<div><asp:datagrid id="dgContainers" runat="server" onitemcreated="GetControls" ondeletecommand="dgContainers_DeleteCommand" datakeyfield="TemplateContainerID" autogeneratecolumns="False" useaccessibleheader="true">
			<columns>
				<asp:boundcolumn visible="true" datafield="TemplateContainerID"></asp:boundcolumn>
				<asp:boundcolumn datafield="Container" headertext="Container"></asp:boundcolumn>
				<asp:boundcolumn datafield="Parent" headertext="Parent"></asp:boundcolumn>
				<asp:templatecolumn headertext="Controls">
					<itemtemplate>
						<asp:datagrid id="dgControls" runat="server" ondeletecommand="DeleteControl" autogeneratecolumns="False" backcolor="#E0E0E0" onitemcommand="AddControl" bordercolor="Blue" width="250px">
							<columns>
								<asp:templatecolumn visible="true">
									<itemtemplate>
										<asp:Label runat="server" id="lblContainerElementID" Text='<%# DataBinder.Eval(Container, "DataItem.ContainerElementID") %>'>
										</asp:label>
									</itemtemplate>
								</asp:templatecolumn>
								<asp:templatecolumn headertext="Control">
									<headerstyle width="120px"></headerstyle>
									<itemtemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.element") %>'>
										</asp:label>
									</itemtemplate>
									<footertemplate>
										<asp:dropdownlist runat="server" id="cboElementID" datatextfield="element" datavaluefield="elementID" datasource="<%#dtElements%>">
										</asp:dropdownlist>
									</footertemplate>
								</asp:templatecolumn>
								<asp:templatecolumn headertext="Order #">
									<itemtemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ElementOrder") %>'>
										</asp:label>
									</itemtemplate>
									<footertemplate>
										<asp:textbox runat="server" id="txtElementOrder"></asp:textbox>
									</footertemplate>
								</asp:templatecolumn>
								<asp:templatecolumn headertext="Remove">
									<itemtemplate>
										<asp:linkbutton runat="server" text="Remove" commandname="Delete" causesvalidation="false"></asp:linkbutton>
									</itemtemplate>
									<footertemplate>
										<asp:linkbutton runat="server" text="Add" commandname="Insert"></asp:linkbutton>
									</footertemplate>
								</asp:templatecolumn>
								<asp:templatecolumn visible="False">
									<itemtemplate>
										<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ContainerID") %>'>
										</asp:label>
									</itemtemplate>
									<footertemplate>
										<asp:label runat="server" text='<%# intContainerID %>' id="lblContainerID">
										</asp:label>
									</footertemplate>
								</asp:templatecolumn>
							</columns>
						</asp:datagrid>
					</itemtemplate>
				</asp:templatecolumn>
				<asp:buttoncolumn text="Delete" headertext="Delete" commandname="Delete"></asp:buttoncolumn>
			</columns>
		</asp:datagrid></div>
</form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
