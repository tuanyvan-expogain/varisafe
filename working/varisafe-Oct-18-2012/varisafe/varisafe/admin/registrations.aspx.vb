Public Partial Class registrations
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            FillCombos()

            If Not IsNothing(Request.QueryString("cid")) Then
                If IsNumeric(Request.QueryString("cid")) Then
                    SearchByCourseID()
                End If
            End If
        End If
    End Sub

    Sub FillCombos()

        Dim objCourse As New BusinessRules.CCourse

        With objCourse
            .GetCoursesAndCities()
            'ddlCourse.DataSource = .CourseDS.Tables(0)
            'ddlCourse.DataBind()
            'ddlCourse.Items.Insert(0, "-Any-")

            ddlCity.DataSource = .CourseDS.Tables(1)
            ddlCity.DataBind()
            ddlCity.Items.Insert(0, "-Any-")

            .CourseDS.Dispose()
        End With
    End Sub

    Sub SearchByCourseID()

        Dim objReg As New BusinessRules.CRegistration

        With objReg
            .CourseID = CInt(Request.QueryString("cid"))
            .SearchRegistrationsByCourseID()

            dvResults.Visible = True
            If .CourseDS.Tables(0).Rows.Count > 0 Then
                gvReg.DataSource = .CourseDS.Tables(0)
                gvReg.DataBind()
                gvReg.Visible = True

                With .CourseDS.Tables(0)
                    If Not IsNothing(.Rows(0)) Then
                        lblNumResults.Text = .Rows.Count.ToString + " Registrations"
                        btnExport.Visible = True
                        ddlCourse.SelectedItem.Text = .Rows(0).Item("CourseType").ToString
                        ddlCity.SelectedItem.Text = .Rows(0).Item("City").ToString
                        txtStartDate.Text = .Rows(0).Item("CourseDate").ToString
                        txtEndDate.Text = .Rows(0).Item("CourseDate").ToString
                    End If
                End With

                gvExport.DataSource = .CourseDS.Tables(1)
                gvExport.DataBind()
            Else
                lblNumResults.Text = "0 Registrations"
                btnExport.Visible = False
            End If

            .CourseDS.Dispose()
        End With
    End Sub

    Sub SearchRegistrations()

        Dim objReg As New BusinessRules.CRegistration
        Dim sDate, eDate As String
        Dim CourseTypeID As Integer = -1
        Dim cy As String = "*"

        If txtStartDate.Text <> "" Then
            sDate = txtStartDate.Text + " 00:00:00 AM"
        Else
            sDate = "2012-01-01"
        End If

        If txtEndDate.Text <> "" Then
            eDate = txtEndDate.Text + " 23:59:59 PM"
        Else
            eDate = "2050-12-31"
        End If

        If ddlCourse.SelectedIndex > 0 Then
            CourseTypeID = ddlCourse.SelectedValue
        End If

        If ddlCity.SelectedIndex > 0 Then
            cy = ddlCity.SelectedValue
        End If

        With objReg
            .SearchRegistrations(CourseTypeID, cy, sDate, eDate, txtFirstName.Text, txtLastName.Text, txtEmail.Text)
            gvReg.DataSource = .CourseDS.Tables(0)
            gvReg.DataBind()
            lblNumResults.Text = .CourseDS.Tables(0).Rows.Count.ToString + " Registrations"

            gvExport.DataSource = .CourseDS.Tables(1)
            gvExport.DataBind()
            .CourseDS.Dispose()
            dvResults.Visible = True
        End With

    End Sub

    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        SearchRegistrations()


    End Sub

    Protected Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        txtStartDate.Text = ""
        txtEndDate.Text = ""
        ddlCourse.SelectedIndex = -1
        ddlCity.SelectedIndex = -1
        txtFirstName.Text = ""
        txtLastName.Text = ""
        'gvReg.Visible = False
        dvResults.Visible = False

    End Sub

    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click

        SearchRegistrations()
        gvExport.Visible = True
        CDataGridToExcel.GridViewToExcel(gvExport, Response)
        gvExport.Visible = False

    End Sub


    Public Overrides Sub VerifyRenderingInServerForm(ByVal Control As Control)

    End Sub

    Private Sub gvReg_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvReg.Sorting

        Dim objReg As New BusinessRules.CRegistration
        Dim sDate, eDate As String
        Dim CourseTypeID As Integer = -1
        Dim cy As String = "*"

        If txtStartDate.Text <> "" Then
            sDate = txtStartDate.Text + " 00:00:00 AM"
        Else
            sDate = "2012-01-01"
        End If

        If txtEndDate.Text <> "" Then
            eDate = txtEndDate.Text + " 23:59:59 PM"
        Else
            eDate = "2050-12-31"
        End If

        If ddlCourse.SelectedIndex > 0 Then
            CourseTypeID = ddlCourse.SelectedValue
        End If

        If ddlCity.SelectedIndex > 0 Then
            cy = ddlCity.SelectedValue
        End If

        With objReg
            .SearchRegistrations(CourseTypeID, cy, sDate, eDate, txtFirstName.Text, txtLastName.Text, txtEmail.Text)
            Dim dView As New DataView(.CourseDS.Tables(0), "", e.SortExpression & " " & ltlDir.text, DataViewRowState.OriginalRows)
            gvReg.DataSource = dView
            gvReg.DataBind()
            lblNumResults.Text = .CourseDS.Tables(0).Rows.Count.ToString + " Registrations"

            gvExport.DataSource = .CourseDS.Tables(1)
            gvExport.DataBind()
            .CourseDS.Dispose()
            dvResults.Visible = True
        End With

        If ltlDir.Text = "ASC" Then
            ltlDir.Text = "DESC"
        Else
            ltlDir.Text = "ASC"
        End If

    End Sub

End Class