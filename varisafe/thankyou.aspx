<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="thankyou.aspx.vb" Inherits="varisafe.thankyou1" masterpagefile="~/public.Master" %>
<%@ Register TagPrefix="uc1" TagName="thankyou" Src="thankyou.ascx" %>
<%@ Register TagPrefix="uc1" TagName="page" Src="page.ascx" %>
<%@ register tagprefix="uc2" tagname="upcoming" src="~/upcoming.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <div class="main"><!-- maincolumn -->
        <uc1:thankyou id="ThankYou1" runat="server"></uc1:thankyou>
    </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SidebarContentPlaceHolder" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="SidebarContentPlaceHolder2" runat="server">
        <uc2:upcoming id="upcoming1" runat="server" />
    <a href="https://www.facebook.com/VariSAFE">
        <img src="images/facebook-like-us.png" alt="Like us on Facebook" />
    </a>
</asp:Content>
        

