<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registration.aspx.vb" Inherits="varisafe.registration" %>

<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<link href="control.css" rel="stylesheet" />
<link href="control.css" rel="stylesheet" />
<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Add Registration</h2>

<hr />
    <form id="form1" runat="server">
    <div>
        <div class="row">
            <span class="labelwide">Course *</span>
            <asp:dropdownlist runat="server" id="ddlCourse" datatextfield="CourseName" datavaluefield="CourseID"></asp:dropdownlist>
            <asp:rangevalidator id="RangeValidator2" runat="server" controltovalidate="ddlCourse"
                display="Dynamic" errormessage="*" maximumvalue="9999999" minimumvalue="1"></asp:rangevalidator>
        </div>
        <div class="row">
            <span class="labelwide">Child First * / Last *</span>
            <asp:textbox id="txtFirstName" runat="server"></asp:textbox>
            <asp:textbox id="txtLastName" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator1" controltovalidate="txtFirstName" runat="server" errormessage="*"></asp:requiredfieldvalidator>
            <asp:requiredfieldvalidator id="RequiredFieldValidator2" controltovalidate="txtLastName" runat="server" errormessage="*"></asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">School</span>
            <asp:dropdownlist runat="server" id="ddlSchool">
                <asp:listitem value="-Select">-Select-</asp:listitem>
                <asp:listitem value="Public School">Public School</asp:listitem>
                <asp:listitem value="Private School">Private School</asp:listitem>
            </asp:dropdownlist>
        </div>
        <div class="row">
            <span class="labelwide">Age *</span>
            <asp:textbox id="txtAge" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" errormessage="*" controltovalidate="txtAge" display="Dynamic"></asp:requiredfieldvalidator>
            <asp:rangevalidator id="RangeValidator1" runat="server" errormessage="Invalid Age" controltovalidate="txtAge" display="Dynamic" maximumvalue="99" minimumvalue="8" type="Integer"></asp:rangevalidator>
        </div>
        <div class="row">
            <span class="labelwide">Parent First * / Last *</span>
            <asp:textbox id="txtParentFirst" runat="server"></asp:textbox>
            <asp:textbox id="txtParentLast" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator4" controltovalidate="txtParentFirst" runat="server" errormessage="*"></asp:requiredfieldvalidator>
            <asp:requiredfieldvalidator id="RequiredFieldValidator5" controltovalidate="txtParentLast" runat="server" errormessage="*"></asp:requiredfieldvalidator>
        </div>
         <div class="row">
            <span class="labelwide">Email *</span>
            <asp:textbox id="txtEmail" runat="server" cssclass="txtlrg"></asp:textbox>
             <asp:requiredfieldvalidator id="RequiredFieldValidator6" runat="server" errormessage="*" controltovalidate="txtEmail" display="Dynamic"></asp:requiredfieldvalidator>
             <asp:regularexpressionvalidator id="RegularExpressionValidator1" runat="server" errormessage="Invalid Email Format" controltovalidate="txtEmail" validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:regularexpressionvalidator>
         </div>
        <div class="row">
            <span class="labelwide">Emergency Phone *</span>
            <asp:textbox id="txtEmergPhone" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator7" runat="server" errormessage="*" controltovalidate="txtEmergPhone" display="Dynamic"></asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">Allergies</span>
            <asp:textbox id="txtAllergies" textmode="multiline" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="labelwide">Health Concerns</span>
            <asp:textbox id="txtHealth" textmode="multiline" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="labelwide">Comments</span>
            <asp:textbox id="txtComments" textmode="multiline" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="labelwide">Phone *</span>
            <asp:textbox id="txtPhone" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" errormessage="*" controltovalidate="txtPhone" display="Dynamic"></asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">Address *</span>
            <asp:textbox id="txtAddress" runat="server" cssclass="txtlrg"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" errormessage="*" controltovalidate="txtAddress"></asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">Address Line 2</span>
            <asp:textbox id="txtAddress2" runat="server" cssclass="txtlrg"></asp:textbox>
            &nbsp;
        </div>
        <div class="row">
            <span class="labelwide">City * / Province *</span>
            <asp:textbox id="txtCity" runat="server"></asp:textbox>
            <asp:dropdownlist id="ddlProvince" runat="server">
                <asp:listitem>AB</asp:listitem>
                <asp:listitem>BC</asp:listitem>
                <asp:listitem>MB</asp:listitem>
                <asp:listitem>NB</asp:listitem>
                <asp:listitem>NL</asp:listitem>
                <asp:listitem>NS</asp:listitem>
                <asp:listitem>NT</asp:listitem> 
                <asp:listitem>NU</asp:listitem> 
                <asp:listitem selected="true">ON</asp:listitem>
                <asp:listitem>PE</asp:listitem>
                <asp:listitem>QC</asp:listitem> 
                <asp:listitem>SK</asp:listitem>
                <asp:listitem>YT</asp:listitem>
              </asp:dropdownlist>
            <asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" errormessage="*" controltovalidate="txtCity" display="Dynamic"></asp:requiredfieldvalidator></div>
        <div class="row">
            <span class="labelwide">Postal Code *</span>
            <asp:textbox id="txtPostalCode" runat="server"></asp:textbox>
            <asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" controltovalidate="txtPostalCode"
                display="Dynamic" errormessage="*">*</asp:requiredfieldvalidator>
        </div>
        <div class="row">
            <span class="labelwide">Internal Notes</span>
            <asp:textbox id="txtInternalNotes" runat="server" textmode="multiline"></asp:textbox>
        </div>
        <div class="row">
            <span class="labelwide">Adjusted Rate</span>
            <asp:textbox id="txtAdjustedRate" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="labelwide">Registered</span>
            <asp:textbox id="txtRegDate" runat="server" enabled="false"></asp:textbox>
        </div>
        <asp:literal id="ltlRegistrationID" runat="server" visible="false"></asp:literal>
        <asp:button id="btnSave" runat="server" text="Save" />
        <asp:button id="btnEmail" runat="server" text="Email" />
        <hr />
        <div class="row">
            <span class="labelwide">Copy To</span>
            <asp:dropdownlist id="ddlCopy" runat="server" datatextfield="CourseName" datavaluefield="CourseID">
            </asp:dropdownlist>
            <asp:button id="btnCopy" runat="server" text="Copy" />
        </div>
        
    </div>

    </form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>

