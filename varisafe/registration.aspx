<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="registration.aspx.vb" Inherits="varisafe._registration" masterpagefile="~/public.Master" %>
<%@ Register TagPrefix="uc1" TagName="register" Src="register.ascx" %>
<%@ Register TagPrefix="uc1" TagName="page" Src="page.ascx" %>
<%@ register tagprefix="uc2" tagname="upcoming" src="~/upcoming.ascx" %>



<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <%Dim strURL As String
        Dim QS As String = Request.ServerVariables("QUERY_STRING")
        
        If QS <> "" Then
            QS = "?" + QS
        End If
        
        If InStr(Request.ServerVariables("SERVER_NAME").ToLower, "www.") < 1 and InStr(Request.ServerVariables("SERVER_NAME").ToLower, "varisafe.ca") > 0 Then
                strURL = "https://www." & LCase(Request.ServerVariables("SERVER_NAME")) & Request.ServerVariables("SCRIPT_NAME") & QS
                'The next line is active in the live site but doesn't work on localhost
            'Response.Redirect(strURL)
        End If
        
        If InStr(Request.ServerVariables("SERVER_NAME").ToLower, "varisafe.ca") > 0 Then
            If Request.ServerVariables("HTTPS") = "off" Then
                strURL = "https://" & LCase(Request.ServerVariables("SERVER_NAME")) & Request.ServerVariables("SCRIPT_NAME") & QS
                'The next line is active in the live site but doesn't work on localhost
                'Response.Redirect(strURL)
            End If
        End If%>    
    
    <%--<uc1:page id="Page1" runat="server"></uc1:page>--%>
    <div class="main"><!-- maincolumn -->
        <uc1:register id="register1" runat="server"></uc1:register>
    </div><!-- end maincolumn -->
</asp:Content>    
    
<asp:Content ID="Content1" ContentPlaceHolderID="SidebarContentPlaceHolder" runat="server">
   <%-- <uc1:register id="register1" runat="server"></uc1:register>--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SidebarContentPlaceHolder2" runat="server">
    <uc2:upcoming id="upcoming1" runat="server" />
    <a href="https://www.facebook.com/VariSAFE">
        <img src="images/facebook-like-us.png" alt="Like us on Facebook" />
    </a>
</asp:Content>