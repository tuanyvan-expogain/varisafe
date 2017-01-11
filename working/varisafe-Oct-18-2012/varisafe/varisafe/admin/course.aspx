<%@ Page Language="vb" AutoEventWireup="false" validateRequest="false" Codebehind="course.aspx.vb" Inherits="varisafe.course" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>

<uc1:header id="Header1" runat="server"></uc1:header>

<form id="Form1" method="post" runat="server" enctype="multipart/form-data">
	
	
	<fieldset>
	<legend>Course Details</legend>
	
	
    <asp:label id="lblError" runat="server" cssclass="error"></asp:label>
	<div class="row">
           <span class="label">Course: *</span>
            <asp:dropdownlist runat="server" id="ddlCourse">
                <asp:listitem value="-1">-Select-</asp:listitem>
                <asp:listitem value="1">Babysitters</asp:listitem>
                <asp:listitem value="2">Home Alone</asp:listitem>
            </asp:dropdownlist>
            <asp:rangevalidator id="RangeValidator2" runat="server" controltovalidate="ddlCourse"
                display="Dynamic" errormessage="*" maximumvalue="9999999" minimumvalue="1"></asp:rangevalidator>
    </div>
	<div class="row">
	    <span class="label">City: *</span>
	    <asp:dropdownlist runat="server" id="ddlCity" datatextfield="City" datavaluefield="City"></asp:dropdownlist>
	</div>
	
	<div class="row">
		<span class="label">Location: *</span>
		<asp:textbox id="txtLocation" cssclass="txtlrg" runat="server"></asp:textbox>
	</div>
	<div class="row">
		<span class="label">Map Link:</span>
		<asp:textbox id="txtMapLink" cssclass="txtlrg" runat="server"></asp:textbox>
	</div>
	<div class="row">
		<span class="label">Date: *</span>
		<asp:textbox id="txtCourseDate" cssclass="txt" runat="server"></asp:textbox>
	</div>
	<div class="row">
		<span class="label">Time: *</span>
		<asp:textbox id="txtCourseTime" cssclass="txt" runat="server"></asp:textbox>
	</div>
	<div class="row">
		<span class="label">Capacity: *</span>
		<asp:textbox id="txtCapacity" cssclass="txt" runat="server"></asp:textbox>
	</div>
	
	<div class="btn">
		<asp:button id="btnSave" runat="server" text="Save" cssclass="btnMedium"></asp:button>
		<asp:textbox id="txtCourseID" runat="server" visible="False" width="40px"></asp:textbox>
	</div>
	</div>
	
	
	</fieldset>
	
	
</form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
