<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="upcoming.ascx.vb" Inherits="varisafe.upcoming" %>

<asp:repeater id="rptUpcoming" runat="server">
    <headertemplate>
        <h4>Upcoming Courses</h4>
    </headertemplate>
    
    <itemtemplate>
    <div class="sidebar-course">
        <h5><asp:literal id="ltlCourse" runat="server" text='<%# Bind("Course") %>'></asp:literal></h5>
        <asp:literal id="ltlDate" runat="server" text='<%# Bind("dte") %>'></asp:literal>
    </div>
    </itemtemplate>
    
</asp:repeater>
