Public MustInherit Class ContactForm
    Inherits ControlTemplate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            If Not IsNothing(Request.QueryString("name")) Then
                Divcontact.Visible = False
                divThankyou.Visible = True
            End If
        End If
    End Sub

    Private Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        ' Try


        '  If IsValid Then
        Dim objemail As New BusinessRules.CEmail()
        Dim StrM As New StringBuilder()

        StrM.Append("<p>Website Contact Form Submission</p>")
        StrM.Append("<p>From: " & txtname.Text & "</p>")
        StrM.Append("<p>Email: " & txtemail.Text & "</p>")
        StrM.Append("<p>Phone: " & txtphone.Text & "</p>")
        StrM.Append("<p>Message: " & txtmessage.Text & "</p>")

        With objemail
            ' This all likely needs to change
            .FromName = "Vari SAFE Online"
            .Sender = "scott@knowleswoolsey.com"
            .Subject = "Website Inquiry"
            .Recipient = "scott@knowleswoolsey.com"
            ' end need to change

            .Message = StrM.ToString
            '.SendMail()

            .Recipient = "rich@infrontofthenet.com"
            '.SendMail()

        End With

        'Response.Write("<script language='javascript'>alert('Thank you for your email.  We will contact you shortly.');location.href='default.aspx';</script>")

        Divcontact.Visible = False
        divThankyou.Visible = True

        'Dim Script As New StringBuilder()
        'Script.Append("var hashValue='#thankYou';")
        'Script.Append("if(location.hash!=hashValue)")
        'Script.Append("location.hash=hashValue;")

        'Dim objPage As kw._default = HttpContext.Current.Handler

        'If (Not objPage.ClientScript.IsClientScriptBlockRegistered("BookMarkScript")) Then
        '    objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "BookMarkScript", Script.ToString(), True)
        'End If

        'Response.Write("<script language='javascript'>alert('Thank you for your message.  We will contact you shortly');</script>")
        ' End If

        Response.Redirect("default.aspx?name=#thankYou", False)
        'Catch objError As Exception
        '    'Dim lble As Label = CType(Master.FindControl("lblError"), Label)
        '    'lble.Text = "An error has occurred in the application: " & objError.Message
        '    'lble.Visible = True
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try
    End Sub
End Class