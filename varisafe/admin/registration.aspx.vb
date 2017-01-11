Public Partial Class registration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            GetCourses()

            If Not IsNothing(Request.QueryString("rid")) Then
                If IsNumeric(Request.QueryString("rid")) Then
                    ltlRegistrationID.Text = Request.QueryString("rid")
                    GetRegistration()
                End If
            Else
                ltlRegistrationID.Text = "0"
            End If
        End If
    End Sub

    Sub GetCourses()

        Dim objC As New BusinessRules.CCourse

        With objC
            .GetUpcoming()
            ddlCourse.DataSource = .Courses
            ddlCourse.DataBind()

            Dim itm As New ListItem("-Select-", 0)
            ddlCourse.Items.Insert(0, itm)
            .Courses.Close()
        End With

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim objR As New BusinessRules.CRegistration

        With objR
            .RegistrationID = ltlRegistrationID.Text
            .CourseID = ddlCourse.SelectedValue
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
            .SaveRegistration()
        End With

        Response.Redirect("registrations.aspx", False)

    End Sub

    Private Sub GetRegistration()

        Dim objR As New BusinessRules.CRegistration

        With objR
            .RegistrationID = ltlRegistrationID.Text
            .GetRegistration()
            ddlCourse.SelectedValue = .CourseID
            txtFirstName.Text = .FirstName
            txtLastName.Text = .LastName

            If .School <> "" Then
                ddlSchool.SelectedValue = .School
            End If

            txtAge.Text = .Age
            txtAllergies.Text = .Allergies
            txtHealth.Text = .Health
            txtComments.Text = .Comments
            txtParentFirst.Text = .ParentFirst
            txtParentLast.Text = .ParentLast
            txtEmergPhone.Text = .EmergPhone
            txtEmail.Text = .Email
            txtPhone.Text = .Phone
            txtCity.Text = .City
            txtAddress.Text = .Address
            txtAddress2.Text = .Address2
            ddlProvince.SelectedValue = .Province
            txtPostalCode.Text = .PostalCode
            txtRegDate.Text = .RegDate.ToString
        End With
    End Sub

    Private Sub btnEmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEmail.Click

        Dim objReg As New BusinessRules.CRegistration

        With objReg
            .RegistrationID = ltlRegistrationID.Text
            .GetRegistration()
            .SendRegEmail(False)
        End With

        objReg = Nothing

    End Sub

End Class