<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="upcoming.ascx.vb" Inherits="varisafe.upcoming" %>

    <h4>Frequently Asked Questions</h4>
    <ul>
        <li><a href="GeneralQuestions.aspx">General Questions</a></li>
        <li><a href="HomeAloneQuestions.aspx">Home Alone Questions</a></li>
        <li><a href="BabysittersQuestions.aspx">Babysitters Questions</a></li>
    </ul>

<asp:repeater id="rptUpcoming" runat="server" visible="false">
    <headertemplate>
        <h4><a href="registration.aspx">Upcoming Courses</a></h4>
    </headertemplate>
    
    <itemtemplate>
    <div class="sidebar-course">
        <h5><asp:literal id="ltlCourse" runat="server" text='<%# Bind("Course") %>'></asp:literal></h5>
        <asp:literal id="ltlDate" runat="server" text='<%# Bind("dte") %>'></asp:literal>
        <asp:literal id="ltlCourseID" runat="server" text='<%# Bind("CourseID") %>' visible="false"></asp:literal>
        <asp:literal id="ltlCity" runat="server" text='<%# Bind("City") %>' visible="false"></asp:literal>
        <asp:literal id="ltlDte" runat="server" text='<%# Bind("dte") %>' visible="false"></asp:literal>
        <asp:literal id="ltlCourseType" runat="server" text='<%# Bind("CourseType") %>' visible="false"></asp:literal>
        <asp:literal id="ltlCapacity" runat="server" text='<%# Bind("Capacity") %>' visible="false"></asp:literal>
        <asp:literal id="ltlRegistrations" runat="server" text='<%# Bind("Registrations") %>' visible="false"></asp:literal>
        <asp:hyperlink id="lnkRegister" runat="server" text="Register" navigateurl="registration.aspx"></asp:hyperlink>
    </div>
    </itemtemplate>
    
</asp:repeater>
