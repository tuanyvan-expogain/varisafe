<%@ Page Language="VB" Debug="true" validateRequest="false" %>

<%@ Import Namespace="System.Web" %>


<html>

<body>

<%

        'Sends Persits Email
        'Params: 1. Sending Address
        '2. Friendly Sender Name
        '3. Message Subject
        '4. Recipient Address
        '5. Message text
        '6. Attachment, if any

        Dim Mailer As Object

        Mailer = CreateObject("Persits.MailSender")
        Mailer.Host = "mail.varisafe.ca"

        Mailer.From = "support@varisafe.ca"
        Mailer.FromName = "varsisafe testing"
        Mailer.Subject = "vs test"

        Mailer.AddAddress("rich@infrontofthenet.com")
        Mailer.IsHTML = True

    


        Mailer.Body = "test"

        Mailer.username = "support@varisafe.ca"
        Mailer.password = "varisafe1150"
        
            Mailer.Send()
      


        Mailer = Nothing


	

	
	%>

</body>
</html>