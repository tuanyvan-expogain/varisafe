Public Partial Class register
    Inherits ControlTemplate

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            If Not IsNothing(Request.QueryString("step")) Then
                SetStep(CInt(Request.QueryString("step")))
            Else
                SetStep(1)
            End If

        End If

    End Sub

    Private Sub SetStep(ByVal intStep As Integer)

        'If IsPostBack = False Then


        '    Dim intStep As Integer = CInt(Request.QueryString("step"))

        Select Case intStep
            Case 2
                dvStep1.Visible = False
                dvStep2.Visible = True
                dvStep3.Visible = False
                dvStep4.Visible = False
                dvStep5.Visible = False
                Dim objCourse As New BusinessRules.CCourse

                With objCourse
                    .GetRegions()
                    'ddlCourse.DataSource = .CourseDS.Tables(0)
                    'ddlCourse.DataBind()
                    'ddlCourse.Items.Insert(0, "-Any-")

                    ddlRegion.DataSource = .Courses
                    ddlRegion.DataBind()
                    ddlRegion.Items.Insert(0, "-Select-")

                    .Courses.Close()
                End With
            Case 3
                dvStep1.Visible = False
                dvStep2.Visible = False
                dvStep3.Visible = True
                dvStep4.Visible = False
                dvStep5.Visible = False
                Dim objCourse As New BusinessRules.CCourse

                With objCourse
                    .GetCoursesAndCities()
                    'ddlCourse.DataSource = .CourseDS.Tables(0)
                    'ddlCourse.DataBind()
                    'ddlCourse.Items.Insert(0, "-Any-")


                    Dim dView As New DataView(.CourseDS.Tables(1), "RegionID = " & ddlRegion.SelectedValue, "", DataViewRowState.OriginalRows)

                    ddlCity.DataSource = dView '.CourseDS.Tables(1)
                    ddlCity.DataBind()
                    ddlCity.Items.Insert(0, "-Select-")

                    dView.Dispose()
                    .CourseDS.Dispose()
                End With
            Case 4
                dvStep1.Visible = False
                dvStep2.Visible = False
                dvStep3.Visible = False
                dvStep4.Visible = True
                dvStep5.Visible = False


                Dim objCourse As New BusinessRules.CCourse


                With objCourse
                    .City = ddlCity.SelectedValue
                    .CourseTypeID = Request.QueryString("cid")
                    .SearchUpcomingByCity()

                    dgCourses.DataSource = .Courses
                    dgCourses.DataBind()
                    .Courses.Close()

                    If dgCourses.Rows.Count = 0 Then
                        lblNumCourses.Text = "No Upcoming Courses Found"
                    Else
                        lblNumCourses.Text = dgCourses.Rows.Count.ToString + " Upcoming Courses"
                    End If

                End With
            Case 5
                dvStep1.Visible = False
                dvStep2.Visible = False
                dvStep3.Visible = False
                dvStep4.Visible = False
                dvStep5.Visible = True

                If Not IsNothing(Request.QueryString("w")) Then
                    If Request.QueryString("w") = 1 Then
                        dvWait.Visible = True
                    End If
                End If

                ltlCourseType.Text = Request.QueryString("coursetype")
                ltlCity.Text = Request.QueryString("city")
                ltlCourseDate.Text = FormatDateTime(Request.QueryString("coursedate"), DateFormat.LongDate)
                Session("CourseID") = CInt(Request.QueryString("courseid"))
        End Select
        'End If
        ' End If

    End Sub

    Private Sub ddlCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCity.SelectedIndexChanged

        SetStep(4)

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Not Page.IsValid Then
            lblResult.Text = "Incorrect"
            lblResult.ForeColor = Drawing.Color.Red
            Exit Sub
        End If

        Dim objR As New BusinessRules.CRegistration

        With objR
            .RegistrationID = "0"
            .CourseID = Session("CourseID")
            .FirstName = txtFirstName.Text
            .LastName = txtLastName.Text

            If ddlSchool.SelectedValue <> "-Select-" Then
                .School = ddlSchool.Text
            End If

            .Age = txtAge.Text
            .Allergies = txtAllergies.Text
            .Health = txtHealth.Text
            .Comments = txtComments.Text
            .ParentFirst = txtParentFirst.Text
            .ParentLast = txtParentLast.Text
            .EmergPhone = txtEmergPhone.Text
            .Email = txtEmail.Text
            .Phone = txtPhone.Text
            .City = txtCity.Text
            .Address = txtAddress.Text
            .Address2 = txtAddress2.Text
            .Province = ddlProvince.Text
            .PostalCode = txtPostalCode.Text
            .PromoCode = txtPromoCode.Text

            If dvWait.Visible = True Then
                .WaitList = True
            Else
                .WaitList = False
            End If
            .SaveRegistration()
            Session("rid") = .RegistrationID

            'Response.Write(.Address2)
        End With


        Response.Redirect("thankyou.aspx", False)

    End Sub

    Private Sub ddlRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRegion.SelectedIndexChanged

        SetStep(3)

    End Sub

    Private Sub dgCourses_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgCourses.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim intSpaces As Integer = 45

            If CType(e.Row.FindControl("ltlCapacity"), Literal).Text = "0" Then
                CType(e.Row.Cells(8).Controls(0), System.Web.UI.WebControls.HyperLink).Text = "Cancelled"
                CType(e.Row.Cells(8).Controls(0), System.Web.UI.WebControls.HyperLink).Enabled = False
                Exit Sub
            End If

            intSpaces = CInt(CType(e.Row.FindControl("ltlCapacity"), Literal).Text) - CInt(CType(e.Row.FindControl("ltlRegistrations"), Literal).Text)

            If intSpaces <= 0 Then
                If intSpaces < -5 Then
                    e.Row.Visible = False
                Else
                    CType(e.Row.Cells(8).Controls(0), System.Web.UI.WebControls.HyperLink).Text = "Waiting List"
                    CType(e.Row.Cells(8).Controls(0), System.Web.UI.WebControls.HyperLink).NavigateUrl += "&w=1"
                End If
            End If
        End If

    End Sub
    Protected Sub CheckBoxRequired_ServerValidate(ByVal sender As Object, ByVal e As ServerValidateEventArgs)
        e.IsValid = chkTOC.Checked
    End Sub

End Class