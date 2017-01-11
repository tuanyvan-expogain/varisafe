<%@ Page Language="vb" AutoEventWireup="false" Codebehind="courses.aspx.vb" Inherits="varisafe.courses" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<uc1:header id="Header1" runat="server"></uc1:header>
<h2>Manage Courses</h2>
<a href="course.aspx">Add New Course</a>

<hr />
<form id="Form1" method="post" runat="server">
        <asp:label id="lblError" runat="server" cssclass="error"></asp:label>

    <div class="row">
        <span class="label">Display:</span>
        <asp:dropdownlist id="ddlDisplay" runat="server">
            <asp:listitem>-All-</asp:listitem>
            <asp:listitem selected="true">Upcoming</asp:listitem>
            <asp:listitem>Completed</asp:listitem>
        </asp:dropdownlist>
    </div>

	    <asp:datagrid id="dgCourses" runat="server" datakeyfield="CourseID" autogeneratecolumns="False"
	        allowsorting="True" ondeletecommand="dgCourses_DeleteCommand"><Columns>
<asp:BoundColumn DataField="CourseID" HeaderText="Course" Visible="False"></asp:BoundColumn>
<asp:BoundColumn DataField="CourseName" HeaderText="Course" SortExpression="CourseName"></asp:BoundColumn>
<asp:BoundColumn DataField="City" HeaderText="City" SortExpression="City"></asp:BoundColumn>
<asp:BoundColumn DataField="CourseDate" HeaderText="Date" SortExpression="CourseDate"></asp:BoundColumn>
<asp:BoundColumn DataField="CourseTime" HeaderText="Time" SortExpression="CourseTime"></asp:BoundColumn>
<asp:BoundColumn DataField="Location" HeaderText="Location" SortExpression="Location"></asp:BoundColumn>
<asp:BoundColumn DataField="Capacity" HeaderText="Capacity" SortExpression="Capacity"></asp:BoundColumn>
<asp:BoundColumn DataField="Registrations" HeaderText="Reg Count" SortExpression="Registrations"></asp:BoundColumn>
<asp:HyperLinkColumn NavigateUrl="course.aspx" Text="Details" HeaderText="Details"></asp:HyperLinkColumn>
<asp:HyperLinkColumn DataNavigateUrlField="CourseID" DataNavigateUrlFormatString="registrations.aspx?cid={0}" NavigateUrl="registrations.aspx" Text="Registrations" HeaderText="Registrations"></asp:HyperLinkColumn>
<asp:ButtonColumn CommandName="Delete" Text="Delete" HeaderText="Delete"></asp:ButtonColumn>
</Columns>
</asp:datagrid>
</form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
