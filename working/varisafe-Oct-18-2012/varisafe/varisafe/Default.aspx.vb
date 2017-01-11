Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If IsNumeric(Request.QueryString("pid")) And Request.QueryString("pid") <> "" Then
        '    Me.Page1.PID = Request.QueryString("pid")
        'Else
        '    Me.Page1.PID = System.Configuration.ConfigurationManager.AppSettings("defaultPageID")
        'End If

    End Sub

End Class