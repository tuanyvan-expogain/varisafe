<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="page.aspx.vb" Inherits="varisafe.page" %>


<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Manage Web Page</h2>
<form id="Form1" method="post" runat="server">
    <asp:label id="lblError" runat="server" cssclass="error"></asp:label>

<div class="row">
	<span class="label">Page Name:</span> 
	<asp:textbox id="txtPageName" runat="server"></asp:textbox>
	<span class="tip">Name that appears in the URL (i.e. about.aspx).  Enter 1 word only.</span>
</div>
<div class="row">
	<span class="label">Parent:</span> 
	<asp:dropdownlist id="cboParentID" runat="server"></asp:dropdownlist>
		<span class="tip">Select parent if the page is a "sub page" of another page.</span>

</div>
<div class="row">
	<span class="label">Template:</span> 
	<asp:dropdownlist id="cboTemplateID" runat="server"></asp:dropdownlist>
		<span class="tip">Choose MAIN for internal pages.</span>

</div>
<div class="row">
	<span class="label">Show In Site Map:</span> 
	<asp:checkbox id="chkInSitemap" runat="server" checked="True"></asp:checkbox>
		<span class="tip">Uncheck this box if you don't want the page to be part of the site map.</span>

</div>
<div class="row">
	<span class="label">Show In Main Navigation:</span> 
	<asp:checkbox id="chkInMainNav" runat="server" checked="True"></asp:checkbox>
		<span class="tip">Uncheck if this page should not have a link in the main navigation.</span>

</div>
<div class="clear">&nbsp;</div>
<div class="row">
    <span class="label">Navigation Order</span>
    <asp:textbox id="txtNavOrder" runat="server" maxlength="3" cssclass="txtsml"></asp:textbox>
    <span class="tip">If page in main nav, enter the order in which this link should appear (starts at left with 1).</span>
</div>

<div class="row">
	<span class="label">Choose Languages:</span>
	<asp:checkboxlist id="chkLanguage" runat="server" repeatlayout="Flow"></asp:checkboxlist>
</div>
<div>
	<asp:button id="btnSave" runat="server"></asp:button>
	<asp:button id="btnDelete" runat="server" Text="Delete"></asp:button>
	<asp:textbox id="txtPageID" runat="server" Visible="False"></asp:textbox>
</div>
<h2>Add Language Page Titles and Link Text</h2>
<asp:datalist id="DataList1" runat="server">

<itemtemplate>


	<h3>
<asp:Label id="lblLanguage" runat="server" text='<%#databinder.eval(container.dataitem,"Language")%>'></asp:Label></h3>
<hr />
<asp:Label id="lblLanguageID" runat="server" visible="false" text='<%#databinder.eval(container.dataitem,"LanguageID")%>'></asp:Label>

<div class="row">
	<span class="label">Link Name: </span>
<asp:TextBox id="txtLinkName" runat="server" text='<%#databinder.eval(container.dataitem,"linkName")%>'></asp:TextBox>
	<span class="tip">Name of Link in the navigation.</span>

</div>	
<div class="row">
	<span class="label">Page Title: </span>
<asp:TextBox id="txtPageTitle" runat="server" text='<%#databinder.eval(container.dataitem,"pageTitle")%>'></asp:TextBox>
	<span class="tip">Appears at the top of the browser window (read by search engines)</span>

</div>	
<div class="row">
	<span class="label">Meta Description: </span>
	<asp:textbox id="txtDescription" runat="server" text='<%#databinder.eval(container.dataitem,"Description")%>' textmode="multiline"></asp:textbox>
	<span class="tip">Enter description if different from rest of site.</span>

</div>	
<div class="row">
	<span class="label">Meta Keywords: </span>
<asp:textbox id="txtKeywords" runat="server" text='<%#databinder.eval(container.dataitem,"Keywords")%>' textmode="multiline"></asp:textbox>
	<span class="tip">Enter keywords if different from the rest of the site.</span>

</div>	
</ItemTemplate>

</asp:datalist>
<asp:button id="btnSaveLanguages" runat="server" Text="Save"></asp:button>
</form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
