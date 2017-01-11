<%@ Page Language="vb" AutoEventWireup="false" Codebehind="newsitem_1.aspx.vb" Inherits="varisafe.newsitem_1"  validaterequest="false"%>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="xs" Namespace="XStandard.WebForms" Assembly="XStandard.WebForms"%>


<uc1:header id="Header1" runat="server"></uc1:header>
<h2>News Item</h2>* indicates Required Fields 
<form id="Form1" method="post" runat="server">
<div>
	<asp:label class="error" id="lblError" runat="server"></asp:label>
</div>
<div class="row">
	<span class="label">Date: *</span> 
	<asp:textbox id="txtDateEntered" runat="server"></asp:textbox>(dd/mm/yyyy) 
	<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" controltovalidate="txtDateEntered" errormessage="Date is required"></asp:requiredfieldvalidator><asp:comparevalidator id="CompareValidator1" runat="server" Operator="DataTypeCheck" ControlToValidate="txtDateEntered" Type="Date" ErrorMessage="Enter a valid date"></asp:comparevalidator>
</div>
	<!--<div class="row">
		<span class="label">News Type</span>-->
		<asp:dropdownlist id="cbonewstypeid" runat="server" visible="false" ></asp:dropdownlist>
	<!--</div>-->
<div class="row">
	<span class="label">Active:</span> 
	<asp:checkbox id=chkActive runat="server" checked="True"></asp:checkbox>
</div>
<div class="row">
	<span class="label">Show on Homepage:</span> 
	<asp:checkbox id="chkHomepage" runat="server" checked="True"></asp:checkbox>
</div>
<div class="row" id="dvLang" runat="server">
	<span class="label">Choose Languages: *</span> 
	<asp:checkboxlist id="chkLanguage" runat="server" repeatlayout="Flow"></asp:checkboxlist>
</div>
<div>
	<asp:button id="btnSaveNews" runat="server" text="Save"></asp:button>
	<asp:button id="btnDelete" runat="server" Text="Delete"></asp:button>
	<asp:textbox id="txtPageID" runat="server" Visible="False"></asp:textbox>
</div>
<h2>Add News Item for each Language Selected</h2>
<asp:datalist id="dlContent" runat="server" repeatlayout="Flow">
		<itemtemplate>
			<hr />
			<h3>
				<asp:label id="lblLanguage" runat="server" text='<%#databinder.eval(container.dataitem,"Language")%>'></asp:label>
			</h3>
		
			<asp:label id="lblLanguageID" runat="server" visible="false" text='<%#databinder.eval(container.dataitem,"LanguageID")%>'></asp:label>
		
			<asp:label id="lblNewsLanguageID" runat="server" visible="false" text='<%#databinder.eval(container.dataitem,"newslanguageID")%>'></asp:label>

			<div class="row">
				<span class="label">Title: *</span>
				<asp:textbox id="txtTitle" runat="server" maxlength="255" class="txtlrg" text='<%#databinder.eval(container.dataitem,"Title")%>'></asp:textbox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" errormessage="Title is required" controltovalidate="txtTitle"></asp:requiredfieldvalidator>
			</div>
			<div class="row">
				<span class="label">Short Description (max 100 chars): *</span>
				<asp:textbox id="txtshortdescription" height="50px" class="txtlrg" textmode="multiline" runat="server" maxlength="100" text='<%#databinder.eval(container.dataitem,"shortdesciption")%>'></asp:textbox>
				<asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" errormessage="Short Description required" controltovalidate="txtshortdescription"></asp:requiredfieldvalidator>
			</div>
			<div>
				
			<xs:XHTMLEditor CSS="http://rainbows.infrontofthenet.com/content.css" Base="http://rainbows.infrontofthenet.com" Codebase="http://rainbows.infrontofthenet.com/XStandard.cab#Version=1,7,2,2" id="Xhtmleditor1" runat="server" Width="650" Height="500" EscapeUnicode="False" License="http://rainbows.infrontofthenet.com/license.txt" ImageLibraryURL="http://rainbows.infrontofthenet.com/services/imagelibrary.aspx" AttachmentLibraryURL="http://rainbows.infrontofthenet.com/services/attachmentlibrary.aspx" SpellCheckerURL="http://rainbows.infrontofthenet.com/services/spellchecker.aspx" SpellCheckerLang="en-ca" value='<%#databinder.eval(container.dataitem,"body")%>'></xs:XHTMLEditor>
			</div>
		</itemtemplate>
	</asp:datalist>
<div class="row">
	<asp:button class="btn" id="btnSave" runat="server" text="Save"></asp:button>
	<asp:textbox id="txtNewsID" runat="server" visible="False" text="0" width="40px"></asp:textbox>
</div>
</form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
