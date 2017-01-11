<%@ Page Language="vb" AutoEventWireup="false" Codebehind="templates.aspx.vb" Inherits="varisafe.templates" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Manage Page Templates</h2>
		<form id="Form1" method="post" runat="server">
		    <asp:label id="lblError" runat="server" cssclass="error"></asp:label>

			<asp:datagrid id="dgTemplates" runat="server" autogeneratecolumns="False" showfooter="True" oneditcommand="dgTemplates_EditCommand" onupdatecommand="dgTemplates_UpdateCommand" oncancelcommand="dgTemplates_CancelCommand" onitemcommand="dgTemplates_ItemCommand" datakeyfield="TemplateID">
				<columns>
					<asp:templatecolumn visible="False">
						<itemtemplate>
							<asp:Label runat="server" id="lblTemplateID" text='<%# DataBinder.Eval(Container, "DataItem.TemplateID") %>'>
							</asp:label>
						</itemtemplate>
					</asp:templatecolumn>
					<asp:templatecolumn headertext="Template Name">
						<itemtemplate>
							<asp:Label runat="server" id="lblTemplateName" text='<%# DataBinder.Eval(Container, "DataItem.TemplateName") %>'>
							</asp:label>
						</itemtemplate>
						<footertemplate>
							<asp:textbox runat="server" id="txtAddTemplate"></asp:textbox>
						</footertemplate>
						<edititemtemplate>
							<asp:TextBox runat="server" id="txtEditTemplate" text='<%# DataBinder.Eval(Container, "DataItem.TemplateName") %>'>
							</asp:textbox>
						</edititemtemplate>
					</asp:templatecolumn>
					<asp:templatecolumn headertext="Edit" footertext="Add">
						<itemtemplate>
							<asp:linkbutton runat="server" text="Edit" commandname="Edit" causesvalidation="false"></asp:linkbutton>
						</itemtemplate>
						<footertemplate>
							<asp:linkbutton runat="server" text="Add" commandname="Add"></asp:linkbutton>
						</footertemplate>
						<edititemtemplate>
							<asp:linkbutton runat="server" text="Update" commandname="Update"></asp:linkbutton>&nbsp;
							<asp:linkbutton runat="server" text="Cancel" commandname="Cancel" causesvalidation="false"></asp:linkbutton>
						</edititemtemplate>
					</asp:templatecolumn>
					<asp:templatecolumn headertext="Design">
						<itemtemplate>
							<asp:hyperlink runat="server" id="lnkEdit">Design</asp:hyperlink>
						</itemtemplate>
					</asp:templatecolumn>
				</columns>
			</asp:datagrid>
		</form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
