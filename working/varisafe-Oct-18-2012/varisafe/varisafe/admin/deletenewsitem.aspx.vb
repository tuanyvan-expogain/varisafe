Public Partial Class deletenewsitem
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsNumeric(Request.QueryString("nid")) Then
            Dim objN As New BusinessRules.CNews

            With objN
                .newsID = CInt(Request.QueryString("nid"))
                .DeleteNewsItem()
            End With

            Response.Redirect("news.aspx", False)
        End If

    End Sub

End Class