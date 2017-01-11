<%@ Page Language="vb" AutoEventWireup="false" validateRequest="false" Codebehind="newsitem.aspx.vb" Inherits="varisafe.newsitem" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="xs" Namespace="XStandard.WebForms" Assembly="XStandard.WebForms"%>
<uc1:header id="Header1" runat="server"></uc1:header>
<h2>News Item</h2>
<form id="Form1" method="post" runat="server">
    <asp:label id="lblError" runat="server" cssclass="error"></asp:label>

	<div class="row">
		<span class="label">Date (mm/dd/yyyy):</span>
		<asp:textbox id="txtDateEntered" runat="server"></asp:textbox>
		<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" errormessage="Date is required" controltovalidate="txtDateEntered"></asp:requiredfieldvalidator><asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="Enter a valid date" Type="Date" ControlToValidate="txtDateEntered" Operator="DataTypeCheck"></asp:CompareValidator>
	</div>
	<div class="row">
		<span class="label">News Type</span>
		<asp:dropdownlist id="cbonewstypeid" runat="server"></asp:dropdownlist>
	</div>
	<div class="row">
		<span class="label">Active</span>
		<asp:checkbox id="chkActive" runat="server" checked="True"></asp:checkbox>
	</div>
	<div class="row">
		<span class="label">Show on Homepage</span>
		<asp:checkbox id="chkHomepage" runat="server" checked="True"></asp:checkbox>
	</div>
	<hr />
	
	<asp:datalist id="dlContent" runat="server" repeatlayout="Flow">
		<itemtemplate>
			<h3>
				<asp:label visible="false" id="lblLanguage" runat="server" text='<%#databinder.eval(container.dataitem,"Language")%>'></asp:label>
			</h3>
			
			<asp:label id="Label2" runat="server" visible="false">0</asp:label>
			<asp:label id="lblLanguageID" runat="server" visible="false" text='<%#databinder.eval(container.dataitem,"LanguageID")%>'></asp:label>
			<asp:label id="lblNewsLanguageID" runat="server" visible="false">0</asp:label>
	
			<div class="row">
				<span class="label">Title</span><br />
				<asp:textbox id="txtTitle" runat="server" maxlength="255" width="421px"></asp:textbox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="Title is required" controltovalidate="txtTitle"></asp:requiredfieldvalidator>
			</div>
			<div class="row">
				<span class="label">Short Description (max 100 chars)</span><br />
				<asp:textbox id="txtshortdescription" height="50px" width="600px" textmode="multiline" runat="server" maxlength="100"></asp:textbox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" errormessage="Short Description required" controltovalidate="txtshortdescription"></asp:requiredfieldvalidator>
			</div>
			<div class="row">
				<span class="label">Content</span> <br />
            	<xs:XHTMLEditor License="http://www.knowleswoolsey.com/license.txt" CSS="http://www.knowleswoolsey.com/control/control.css" Base="http://www.knowleswoolsey.com" Codebase="http://www.knowleswoolsey.com/XStandard.cab#Version=2,0,0,0" id="XHTMLEditor1" runat="server" Width="600" Height="400" EscapeUnicode="False" ImageLibraryURL="http://www.knowleswoolsey.com/services/imagelibrary.aspx" AttachmentLibraryURL="http://www.knowleswoolsey.com/services/attachmentlibrary.aspx" SpellCheckerURL="http://www.knowleswoolsey.com/services/spellchecker.aspx" Styles="http://www.knowleswoolsey.com/styles.xml" SpellCheckerLang="en-ca" EditorCSS="http://www.knowleswoolsey.com/control/control.css"></xs:XHTMLEditor>
			</div>
		</itemtemplate>
	</asp:datalist>
	<div class="row">
		<asp:button id="btnSave" runat="server" text="Save"></asp:button>
		<asp:textbox id="txtNewsID" runat="server" visible="False" width="40px" text="0"></asp:textbox>
	</div>
</form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
