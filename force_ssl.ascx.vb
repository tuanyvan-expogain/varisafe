
Partial Class force_ssl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim strServer As String = Request.ServerVariables("SERVER_NAME").ToLower

        If InStr(strServer, "shop.cellcycle.ca") > 0 Then
            If Request.ServerVariables("HTTPS") = "off" Then
                Dim strURL As String
                Dim qs As String = ""

                If Len(Request.QueryString.ToString) > 0 Then
                    qs = "?" + Request.QueryString.ToString
                End If

                strURL = "https://shop.cellcycle.ca" + Request.ServerVariables("SCRIPT_NAME") + qs
                'The next line is active in the live site but doesn't work on localhost
                Response.Redirect(strURL)
            End If
        End If
    End Sub

End Class
