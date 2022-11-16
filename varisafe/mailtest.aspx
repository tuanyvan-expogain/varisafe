<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mailtest.aspx.vb" Inherits="varisafe.mailtest" %>


<%@ Import Namespace="System.Net.Mail" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%
        dim Message = New System.Net.Mail.MailMessage()

        Message.From = New MailAddress("contact@varisafe.ca")
        Message.To.Add(New MailAddress("rich@infrontofthenet.com"))
        Message.Subject = "This is my subject - local"
        Message.Body = "This is the body"

        Dim client = New SmtpClient()

        client.Send(Message)
        %>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
