<%@ Page Language="vb" AutoEventWireup="false" Codebehind="testing.aspx.vb" Inherits="WebAppDotNetCartVBNET.testing" validaterequest="false"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
    <title>testing</title>
    <meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
    <meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
    <meta name=vs_defaultClientScript content="JavaScript">
    <meta name=vs_targetSchema content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
  <body MS_POSITIONING="GridLayout">
	<p>
	P - pending<br >
	C - complete<br >
	H - on hold<br >
	L - complete but inactive until Launch
	</p>
	<div>
    <form id="Form1" method="post" runat="server">
		<asp:DataGrid id="DataGrid1" runat="server" Width="1000px" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True" OnCancelCommand="DataGrid1_CancelCommand" OnEditCommand="DataGrid1_EditCommand" OnUpdateCommand="DataGrid1_UpdateCommand" DataKeyField="TaskID" OnItemCommand="DataGrid1_ItemCommand" OnSortCommand="DataGrid1_SortCommand">
<Columns>
<asp:TemplateColumn HeaderText="TaskID" SortExpression="TaskID">
<ItemTemplate>
<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TaskID") %>'></asp:Label>
</ItemTemplate>

<EditItemTemplate>
<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TaskID") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Page" SortExpression="Page">
<ItemTemplate>
<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Page") %>'></asp:Label>
</ItemTemplate>

<FooterTemplate>
	<asp:TextBox Runat="server" ID="txtAddPage"></asp:TextBox>
</FooterTemplate>

<EditItemTemplate>
<asp:TextBox runat="server" ID="txtPage" Text='<%# DataBinder.Eval(Container, "DataItem.Page") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Description">
<ItemTemplate>
<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'></asp:Label>
</ItemTemplate>

<FooterTemplate>
	<asp:TextBox Runat="server" ID="txtAddDescription" TextMode="MultiLine" Rows="5" Columns="50"></asp:TextBox>
</FooterTemplate>

<EditItemTemplate>
<asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="5" Columns="50" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Assigned To" SortExpression="AssignedTo">
<ItemTemplate>
<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AssignedTo") %>'></asp:Label>
</ItemTemplate>

<FooterTemplate>
	<asp:TextBox Runat="server" ID="txtAddAssignedTo"></asp:TextBox>
</FooterTemplate>

<EditItemTemplate>
<asp:TextBox runat="server" ID="txtAssignedTo" Text='<%# DataBinder.Eval(Container, "DataItem.AssignedTo") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="Status" SortExpression="Status">
<ItemTemplate>
<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Status") %>'></asp:Label>
</ItemTemplate>

<FooterTemplate>
	<asp:TextBox Runat="server" ID="txtAddStatus"></asp:TextBox>
</FooterTemplate>

<EditItemTemplate>
<asp:TextBox runat="server" ID="txtStatus" Text='<%# DataBinder.Eval(Container, "DataItem.Status") %>'></asp:TextBox>
</EditItemTemplate>
</asp:TemplateColumn>
<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
<asp:TemplateColumn HeaderText="Add">
<ItemTemplate>

</ItemTemplate>
<FooterTemplate>
												<asp:LinkButton id="btnAdd" runat="server" CommandName="Insert">Add</asp:LinkButton>
											</FooterTemplate>
</asp:TemplateColumn>
</Columns>


</asp:DataGrid>
</div></FORM>

  </body>
</HTML>
