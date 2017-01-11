Public Partial Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        BusinessRules.CEmail.SendMailPersits("register@varisafe.ca", "varisafe test", "vs test", "rich@infrontofthenet.com", "test", "")

    End Sub

End Class