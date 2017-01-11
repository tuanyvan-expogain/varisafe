Public Partial Class upcoming
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            GetUpcoming()
        End If

    End Sub

    Private Sub GetUpcoming()

        Dim objC As New BusinessRules.CCourse

        With objC
            .GetUpcoming()
            rptUpcoming.DataSource = .Courses
            rptUpcoming.DataBind()
            .Courses.Close()
        End With

        For i As Integer = 0 To rptUpcoming.Items.Count - 1
            If i > 3 Then
                rptUpcoming.Items(i).Visible = False
            End If
        Next

    End Sub

End Class