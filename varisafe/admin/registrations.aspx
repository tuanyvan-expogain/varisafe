<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registrations.aspx.vb" Inherits="varisafe.registrations" enableeventvalidation="false" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<link href="control.css" rel="stylesheet" />
<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Manage Registrations</h2>
<a href="registration.aspx">Add New Registration</a>

<hr />
    <form id="form1" runat="server">
    <asp:textbox id="txtEmailList" textmode="multiline" visible="false" runat="server" width="750" height="250" />

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
        <%--<div class="row">
            <span class="label">Phone:</span>--%>
            <asp:textbox id="txtPhone" runat="server" visible="false"></asp:textbox>
        <%--</div>--%>
        <%--<div class="row">
            <span class="label">Registration #:</span>--%>
            <asp:textbox id="txtRegistrationID" runat="server" visible="false"></asp:textbox>
        <%--</div>--%>
        <div class="row">
            <span class="label">Wait Status:</span>
            <asp:dropdownlist id="ddlWaitList" runat="server">
                <asp:listitem value="NULL" selected="true">Any</asp:listitem>
                <asp:listitem value="0">Registered</asp:listitem>
                <asp:listitem value="1">Wait Listed</asp:listitem>
            </asp:dropdownlist>
        </div>
        <asp:button id="btnSearch" runat="server" text="Search" />
        <asp:button id="btnReset" runat="server" text="Reset" />
        <asp:button id="btnDuplicates" runat="server" text="Duplicates" />
        <asp:button id="btnMailList" runat="server" text="Mail List" visible="false" />
    </div>
    
    <div id="dvResults" runat="server" visible="false">
        <asp:label id="lblNumResults" runat="server"></asp:label>
        <asp:button id="btnExport" runat="server" text="Export to Excel" />
        <asp:gridview id="gvReg" runat="server" autogeneratecolumns="False" allowsorting="True" datakeynames="RegistrationID">
            <columns>
                <asp:BoundField DataField="RegistrationID" HeaderText="Registration #" SortExpression="RegistrationID"></asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName"></asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName"></asp:BoundField>
                <asp:BoundField DataField="CourseType" HeaderText="Course" SortExpression="CourseType"></asp:BoundField>
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City"></asp:BoundField>
                <asp:BoundField DataField="CourseDate" HeaderText="Course Date" SortExpression="CourseDate"></asp:BoundField>
                <asp:BoundField DataField="RegDate" HeaderText="Reg Date" SortExpression="RegDate"></asp:BoundField>
                 <asp:templatefield headertext="Email" sortexpression="Email">
                    <itemtemplate>
                        <asp:literal id="ltlEmail" runat="server" text='<%# Bind("Email") %>' />
                    </itemtemplate>
                </asp:templatefield>
                <asp:templatefield visible="true" headertext="Wait List">
                    <itemtemplate>
                        <asp:literal id="ltlWaitList" runat="server" text='<%# Bind("WaitList") %>'></asp:literal>
                    </itemtemplate>
                </asp:templatefield>
                <asp:HyperLinkField DataNavigateUrlFields="RegistrationID" DataNavigateUrlFormatString="registration.aspx?rid={0}" NavigateUrl="registration.aspx" Text="Details" HeaderText="Details"></asp:HyperLinkField>
                <asp:CommandField ShowDeleteButton="True" HeaderText="Delete"></asp:CommandField>
                <asp:templatefield  headertext="Activate">
                    <itemtemplate>
                        <asp:linkbutton runat="server" id="btnActivate" commandname="Activate" text="Activate" CommandArgument="<%# Container.DataItemIndex %>"></asp:linkbutton>
                    </itemtemplate>
                </asp:templatefield>
               
            </columns>
        </asp:gridview>
        <asp:gridview id="gvExport" runat="server" autogeneratecolumns="false" visible="false">
            <columns>
                <asp:TemplateField headertext="R"></asp:TemplateField>
                <asp:BoundField DataField="LastName" HeaderText="Last Name"></asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="First Name"></asp:BoundField>
                <asp:BoundField DataField="EmergPhone" HeaderText="Emerg Phone"></asp:BoundField>
                <asp:BoundField DataField="Allergies" HeaderText="Allergies"></asp:BoundField>
                <asp:BoundField DataField="Health" HeaderText="Health Concerns"></asp:BoundField>
                <asp:BoundField DataField="PromoCode" headertext="Sign Out"></asp:BoundField>
                <asp:templatefield visible="false" headertext="Wait List">
                    <itemtemplate>
                        <asp:literal id="ltlWaitList" runat="server" text='<%# Bind("WaitList") %>'></asp:literal>
                    </itemtemplate>
                </asp:templatefield>
            </columns>
        </asp:gridview>
        <asp:literal id="ltlDir" runat="server" visible="false"></asp:literal>
        <asp:literal id="ltlcid" runat="server" visible="false"></asp:literal>
    </div>
    
    </form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
