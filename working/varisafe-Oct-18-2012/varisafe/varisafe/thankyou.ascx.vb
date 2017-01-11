Public Partial Class thankyou
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            GetRegistration()
        End If

    End Sub

    Private Sub GetRegistration()

        Dim objR As New BusinessRules.CRegistration

        With objR
            .RegistrationID = CInt(Session("rid"))
            lblRegistrationID.Text = .RegistrationID
            .GetRegistration()
            'ddlCourse.SelectedValue = .CourseID
            txtFirstName.Text = .FirstName
            txtLastName.Text = .LastName
            ddlSchool.Text = .School
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
            lblProvince.Text = .Province
            txtPostalCode.Text = .PostalCode
            lblPromoCode.Text = .PromoCode
        End With

    End Sub
End Class