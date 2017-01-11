<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/public.Master" CodeBehind="sitemap.aspx.vb" Inherits="kw.sitemap1" 
    title="CharityCan: Site Map" %>
<%@ Register TagPrefix="uc1" TagName="SiteMap" Src="sitemap.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="SidebarContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
<div class="sitemap">
<uc1:SiteMap runat="server" />
</div>
</asp:Content>
