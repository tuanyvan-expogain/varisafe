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

                If CInt(Request.QueryString("cid")) = 1 Then
                    ltlCName.Text = "Babysitter Training "
                Else
                    ltlCName.Text = "Home Alone & Stranger Safety "
                End If
            Case 3
                dvStep1.Visible = False
                dvStep2.Visible = False
                dvStep3.Visible = True
                dvStep4.Visible = False
                dvStep5.Visible = False
                Dim objCourse As New BusinessRules.CCourse

                With objCourse
                    .GetCoursesAndCities()
                    ddlCity.DataSource = .CourseDS.Tables(1)
                    ddlCity.DataBind()
                    ddlCity.Items.Insert(0, "-Select-")


                    'Dim dView As New DataView(.CourseDS.Tables(1), "RegionID = " & ddlRegion.SelectedValue, "", DataViewRowState.OriginalRows)

                    'ddlCity.DataSource = dView '.CourseDS.Tables(1)
                    'ddlCity.DataBind()
                    'ddlCity.Items.Insert(0, "-Select-")

                    'dView.Dispose()
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
                    .City = ddlCity.SelectedValue 'ddlRegion.SelectedValue 'change to search by region not city ddlCity.SelectedValue
                    .CourseTypeID = Request.QueryString("cid")
                    .Active = True
                    .SearchUpcomingByCity()

                    dgCourses.DataSource = .Courses
                    dgCourses.DataBind()
                    .Courses.Close()

                    If dgCourses.Rows.Count = 0 Then
                        lblNumCourses.Text = "<p>No Upcoming Courses Found.</p><p><a href=""registration.aspx?cid=" & .CourseTypeID.ToString & "&step=3"">CLICK HERE</a> to choose another location.</p>"
                        dvRequest.Visible = True
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

                Dim cid As String = Request.QueryString("courseid")
                ltlCourseID.Text = cid

                If ltlCourseID.Text = 4073 Then
                    Response.Write("<script language=""javascript"">alert('Oops...we had trouble processing your request.  Please reselect your course to ensure we have the correct information.');history.go(-1);</script>")
                End If
                cid = cid
        End Select
        'End If
        ' End If

    End Sub

    Private Sub ddlCity_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCity.SelectedIndexChanged

        SetStep(4)

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "whatever1", "Recaptcha.reload();", True)

        If Not Page.IsValid Then
            '    lblResult.Text = "Incorrect"
            '    lblResult.ForeColor = Drawing.Color.Red
            '    lblResult.Visible = True
            '    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "CaptchaReload", "Recaptcha.reload();", True)
            Exit Sub
        End If

        Dim objR As New BusinessRules.CRegistration

        With objR
            .RegistrationID = "0"
            .CourseID = ltlCourseID.Text 'Session("CourseID")
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
            Session("Message") = .Address2

            'Response.Write(.Address2)
        End With


        Response.Redirect("thankyou.aspx", False)

    End Sub

    Private Sub ddlRegion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRegion.SelectedIndexChanged

        SetStep(4) '3)

    End Sub

    Private Sub dgCourses_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgCourses.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim intSpaces As Integer = 45

            If CType(e.Row.FindControl("ltlCapacity"), Literal).Text = "0" Then
                CType(e.Row.Cells(9).Controls(0), System.Web.UI.WebControls.HyperLink).Text = "Not Available"
                CType(e.Row.Cells(9).Controls(0), System.Web.UI.WebControls.HyperLink).Enabled = False
                Exit Sub
            End If

            intSpaces = CInt(CType(e.Row.FindControl("ltlCapacity"), Literal).Text) - CInt(CType(e.Row.FindControl("ltlRegistrations"), Literal).Text)

            If intSpaces <= 0 Then
                If intSpaces < -10 Then
                    'e.Row.Visible = False
                    CType(e.Row.Cells(9).Controls(0), System.Web.UI.WebControls.HyperLink).Text = "Not Available/Wait List Full"
                    CType(e.Row.Cells(9).Controls(0), System.Web.UI.WebControls.HyperLink).Enabled = False
                Else
                    CType(e.Row.Cells(9).Controls(0), System.Web.UI.WebControls.HyperLink).Text = "Waiting List"
                    CType(e.Row.Cells(9).Controls(0), System.Web.UI.WebControls.HyperLink).NavigateUrl += "&w=1"
                End If
            End If
        End If

    End Sub

    Protected Sub CheckBoxRequired_ServerValidate(ByVal sender As Object, ByVal e As ServerValidateEventArgs)
        e.IsValid = chkTOC.Checked
    End Sub

    Private Sub btnRequest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRequest.Click

        Dim strMess As String = "<p>A new " & ltlCName.Text + " course has been requested:</p>" + _
            "Parent Name: " + txtRFirst.Text + " " + txtRLast.Text + "<br />" + _
            "City Requested: " + txtRCity.Text + "<br />" + _
            "Phone: " + txtRPhone.Text + "<br />" + _
            "Email: " + txtREmail.Text

        'BusinessRules.CEmail.SendMail("register@varisafe.ca", "Vari SAFE Education", "Vari SAFE Course Request", "rich@infrontofthenet.com", strMess, "")
        BusinessRules.CEmail.SendMail("register@varisafe.ca", "Vari SAFE Education", "Vari SAFE Course Request", "admin@varisafe.ca", strMess, "")

        lblNumCourses.Text = "Thank you for your request.  We will notify you if we are able to organize a course in your city."
        dvRequest.Visible = False

    End Sub

    Private Sub btnCity_Click(sender As Object, e As System.EventArgs) Handles btnCity.Click

        SetStep(4)

    End Sub

End Class