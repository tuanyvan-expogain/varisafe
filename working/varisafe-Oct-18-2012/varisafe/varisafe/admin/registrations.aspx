<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registrations.aspx.vb" Inherits="varisafe.registrations" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<link href="control.css" rel="stylesheet" />
<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Manage Registrations</h2>
<a href="registration.aspx">Add New Registration</a>

<hr />
    <form id="form1" runat="server">
    <div>
        <div class="row">
            <span class="label">Course:</span>
            <asp:dropdownlist runat="server" id="ddlCourse">
                <asp:listitem value="-1">-Any-</asp:listitem>
                <asp:listitem value="1">Babysitters</asp:listitem>
                <asp:listitem value="2">Home Alone</asp:listitem>
            </asp:dropdownlist>
        </div>
        <div class="row">
            <span class="label">City:</span>
            <asp:dropdownlist runat="server" id="ddlCity" datatextfield="City" datavaluefield="City"></asp:dropdownlist>
        </div>
        <div class="row">
            <span class="label">Start Date:</span>
            <asp:textbox id="txtStartDate" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="label">End Date:</span>
            <asp:textbox id="txtEndDate" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="label">First Name:</span>
            <asp:textbox id="txtFirstName" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="label">Last Name:</span>
            <asp:textbox id="txtLastName" runat="server"></asp:textbox>
        </div>
        <div class="row">
            <span class="label">Email:</span>
            <asp:textbox id="txtEmail" runat="server"></asp:textbox>
        </div>
        <asp:button id="btnSearch" runat="server" text="Search" />
        <asp:button id="btnReset" runat="server" text="Reset" />
    </div>
    
    <div id="dvResults" runat="server" visible="false">
        <asp:label id="lblNumResults" runat="server"></asp:label>
        <asp:button id="btnExport" runat="server" text="Export to Excel" />
        <asp:gridview id="gvReg" runat="server" autogeneratecolumns="False" allowsorting="True" datakeynames="RegistrationID">
            <Columns>
                <asp:BoundField DataField="RegistrationID" HeaderText="Registration #" SortExpression="RegistrationID"></asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName"></asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName"></asp:BoundField>
                <asp:BoundField DataField="CourseType" HeaderText="Course" SortExpression="CourseType"></asp:BoundField>
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
                <asp:BoundField DataField="CourseDate" HeaderText="Course Date" SortExpression="CourseDate"></asp:BoundField>
                <asp:BoundField DataField="RegDate" HeaderText="Reg Date" SortExpression="RegDate"></asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="RegistrationID" DataNavigateUrlFormatString="registration.aspx?rid={0}" NavigateUrl="registration.aspx" Text="Details" HeaderText="Details"></asp:HyperLinkField>
                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete"></asp:CommandField>
            </Columns>
        </asp:gridview>
        <asp:gridview id="gvExport" runat="server" autogeneratecolumns="true" visible="false">
        
        </asp:gridview>
        <asp:literal id="ltlDir" runat="server" visible="false"></asp:literal>
    </div>
    
    </form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
