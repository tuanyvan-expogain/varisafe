<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="hashpass.aspx.vb" Inherits="varisafe.hashpass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        PW: <asp:TextBox ID="txtpw" runat="server" />
        <asp:Button ID="btnGo" runat="server" Text="Hash" OnClick="btnGo_Click" />
        <asp:Label ID="lblHash" runat="server" />
    </div>
    </form>
</body>
</html>
