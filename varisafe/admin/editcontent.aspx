<%@ Page Language="vb" AutoEventWireup="false" Codebehind="editcontent.aspx.vb" Inherits="varisafe.editcontent"  validaterequest="false"%>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="xs" Namespace="XStandard.WebForms" Assembly="XStandard.WebForms"%>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Edit Page Content</h2>
<form id="Form1" method="post" runat="server">
    <asp:label id="lblError" runat="server" cssclass="error"></asp:label>

	<div class="row">
		<span class="label">Page Name:</span>
		<asp:label id="lblPageName" runat="server">Label</asp:label>
	</div>
	<div class="row">
		<span class="label">Container:</span>
		<asp:label id="lblContainer" runat="server">Label</asp:label>
	</div>
	<div class="row">
		<span class="label">Language:</span>
		<asp:label id="lblLanguage" runat="server">Label</asp:label>
	</div>
	<div>
		<asp:textbox runat="server" id="txtElementContentID" visible="false"></asp:textbox>
	</div>
	<div>
        <asp:textbox runat="server" id="txtContentPlain" textmode="multiline"></asp:textbox>
	    <FTB:FreeTextBox id="txtContent1" Visible="false" toolbarstyleconfiguration="OfficeXP" runat="Server" EnableHtmlMode="false" StripAllScripting="true" height="130">
            <TOOLBARS>
                <FTB:TOOLBAR runat="server">
                    <FTB:NetSpell runat="server" />
                </FTB:TOOLBAR>
            </TOOLBARS>
        </FTB:FreeTextBox>
	</div>
	<div>
	<!--
	<xs:xhtmleditor id="Xhtmleditor2" runat="server" SpellCheckerLang="en-ca" SpellCheckerURL="http://localhost/services/spellchecker.aspx" AttachmentLibraryURL="http://localhost/services/attachmentlibrary.aspx" ImageLibraryURL="http://localhost/services/imagelibrary.aspx" License="../bin/license.txt" EscapeUnicode="False" Height="500" Width="650" Codebase="http://varisafe.infrontofthenet.com/XStandard.cab#Version=1,7,2,2" Base="http://localhost/" CSS="http://localhost/content.css" EnablePasteMarkup="True" EnableTimestamp="False"></xs:xhtmleditor>
	
	<xs:XHTMLEditor License="http://www.knowleswoolsey.com/license.txt" CSS="http://www.knowleswoolsey.com/control/control.css" Base="http://www.knowleswoolsey.com" Codebase="http://www.knowleswoolsey.com/XStandard.cab#Version=2,0,0,0" id="XHTMLEditor1" runat="server" Width="600" Height="400" EscapeUnicode="False" ImageLibraryURL="http://www.knowleswoolsey.com/services/imagelibrary.aspx" AttachmentLibraryURL="http://www.knowleswoolsey.com/services/attachmentlibrary.aspx" SpellCheckerURL="http://www.knowleswoolsey.com/services/spellchecker.aspx" Styles="http://www.knowleswoolsey.com/styles.xml" SpellCheckerLang="en-ca" EditorCSS="http://www.knowleswoolsey.com/control/control.css"></xs:XHTMLEditor>
	-->
	</div>	

		<asp:button id="btnSave" text="Save" cssclass="btn" runat="server"></asp:button></form>

<!-- tinymce -->
<script src="/js/tinymce/tinymce.min.js"></script>
<script>tinymce.init({
    selector: 'textarea',
    height: 500,
    plugins: [
    'advlist autolink lists link image charmap print preview anchor',
    'searchreplace visualblocks code fullscreen',
    'insertdatetime media table contextmenu paste code'
    ],
    toolbar: 'undo redo | insert | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image'
});</script>

<uc1:footer id="Footer1" runat="server"></uc1:footer>
