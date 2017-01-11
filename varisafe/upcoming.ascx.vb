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

    Private Sub rptUpcoming_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptUpcoming.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim objLnk As System.Web.UI.WebControls.HyperLink

            objLnk = CType(e.Item.FindControl("lnkRegister"), System.Web.UI.WebControls.HyperLink)

            If CType(e.Item.FindControl("ltlCapacity"), Literal).Text = "0" Then
                objLnk.Text = "Cancelled"
                objLnk.Enabled = False
                Exit Sub
            End If

            objLnk.NavigateUrl = "registration.aspx?courseid=" + CType(e.Item.FindControl("ltlCourseID"), Literal).Text + _
                "&city=" + CType(e.Item.FindControl("ltlCity"), Literal).Text + _
                "&coursedate=" + CType(e.Item.FindControl("ltlDte"), Literal).Text + _
                "&coursetype=" + CType(e.Item.FindControl("ltlCourseType"), Literal).Text + _
                "&step=5"

            Dim intSpaces As Integer = 45
            intSpaces = CInt(CType(e.Item.FindControl("ltlCapacity"), Literal).Text) - CInt(CType(e.Item.FindControl("ltlRegistrations"), Literal).Text)

            If intSpaces <= 0 Then
                If intSpaces < -5 Then
                    e.Item.Visible = False
                Else
                    objLnk.Text = "Waiting List"
                    objLnk.NavigateUrl += "&w=1"
                End If
            End If
        End If

    End Sub
End Class