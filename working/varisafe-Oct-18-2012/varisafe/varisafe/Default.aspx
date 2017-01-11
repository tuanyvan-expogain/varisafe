<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="varisafe._Default" masterpagefile="~/public.Master" %>
<%@ Register TagPrefix="uc1" TagName="register" Src="register.ascx" %>
<%@ Register TagPrefix="uc1" TagName="page" Src="page.ascx" %>
<%@ register tagprefix="uc2" tagname="upcoming" src="~/upcoming.ascx" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <uc1:page id="Page1" runat="server"></uc1:page>
</asp:Content>    
    
<asp:Content ID="Content1" ContentPlaceHolderID="SidebarContentPlaceHolder" runat="server">
   <%-- <uc1:register id="register1" runat="server"></uc1:register>--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="SidebarContentPlaceHolder2" runat="server">
    <uc2:upcoming id="upcoming1" runat="server" />
    <img src="images/facebook-like-us.png" />
</asp:Content>