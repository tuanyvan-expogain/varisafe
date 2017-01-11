<%@ Page Language="vb" AutoEventWireup="false" Codebehind="news.aspx.vb" Inherits="varisafe.news" %>
<%@ Register TagPrefix="uc1" TagName="header" Src="header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="footer" Src="footer.ascx" %>
<uc1:header id="Header1" runat="server"></uc1:header>

<script language="javascript" type="text/javascript">

    function confirmDelete(id) {
    
        if (confirm('Are you sure you want to delete this item?') == true) {
            var strUrl = 'deletenewsitem.aspx?nid=' + id;
            location.href = strUrl;
            //return true;
        }
        else {
            //return false;
        }
    }

</script>


<h2>Manage News Items</h2>
<a href="newsitem.aspx">Add New News Item</a>
<hr />
<form id="Form1" method="post" runat="server">
    <asp:label id="lblError" runat="server" cssclass="error"></asp:label>

	<table cellspacing="0" border="1">
		<asp:repeater id="rptNews" runat="server">
			<headertemplate>
				<tr>
					<td>Title</td>
					<td>Language</td>
					<td>Date</td>
					<td>Active</td>
					<td>Details</td>
					<td>Delete</td>
				</tr>
			</headertemplate>
			<itemtemplate>
				<tr>
					<td><%# DataBinder.Eval(Container.DataItem, "title")%></td>
					<td><%# DataBinder.Eval(Container.DataItem, "language")%></td>
					<td width="170"><%# DataBinder.Eval(Container.DataItem, "dte")%></td>
					<td><%# DataBinder.Eval(Container.DataItem, "active")%></td>
					<td><a href='newsitem.aspx?nid=<%# DataBinder.Eval(Container.DataItem, "newsid")%>'>Details</a></td>
					<td><a href="javascript:confirmDelete(<%# DataBinder.Eval(Container.DataItem, "newsid")%>);">Delete</a></td>
				</tr>
			</itemtemplate>
		</asp:repeater>
	</table>
</form>
<uc1:footer id="Footer1" runat="server"></uc1:footer>
