Imports System.IO

Public Class course
    Inherits System.Web.UI.Page
    Protected WithEvents txtCourseID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtlocation As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtBuilding As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtPrice As System.Web.UI.WebControls.TextBox

    Protected WithEvents txtMapLink As System.Web.UI.WebControls.TextBox

    Protected WithEvents txtCapacity As System.Web.UI.WebControls.TextBox
    Protected WithEvents XHTMLEditor1 As XStandard.XHTMLEditor
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents txtCourseDate As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStartTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEndTime As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCourseName As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCourse As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlCity As System.Web.UI.WebControls.DropDownList
    Protected dTable As DataTable
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents chkActive As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtAdditionalInfo As System.Web.UI.WebControls.TextBox

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        lblError.Text = ""

        If IsPostBack = False Then
            FillCombos()

            If Not IsNothing(Request.QueryString("cid")) Then
                GetCourse()
            End If
        End If
    End Sub

    Private Sub FillCombos()

        Dim objCourse As New BusinessRules.CCourse

        With objCourse
            .GetCoursesAndCities()
            'ddlCourse.DataSource = .CourseDS.Tables(0)
            'ddlCourse.DataBind()
            'ddlCourse.Items.Insert(0, "-Any-")

            ddlCity.DataSource = .CourseDS.Tables(1)
            ddlCity.DataBind()
            ddlCity.Items.Insert(0, "-Select-")

            .CourseDS.Dispose()
        End With

    End Sub

    Private Sub GetCourse()

        Try
            Dim objList As New BusinessRules.CCourse()

            With objList
                If IsNumeric(Request.QueryString("cid")) Then
                    .CourseID = CInt(Request.QueryString("cid"))
                    txtCourseID.Text = .CourseID.ToString
                ElseIf txtCourseID.Text <> "" And txtCourseID.Text <> "0" Then
                    .CourseID = CInt(txtCourseID.Text)
                End If

                .GetCourse()

                If .CourseID > 0 Then
                    ddlCity.SelectedValue = .City
                    ddlCourse.SelectedValue = .CourseTypeID
                    txtlocation.Text = .Location
                    txtBuilding.Text = .Building
                    txtCourseDate.Text = .CourseDate
                    txtStartTime.Text = .StartTime
                    txtEndTime.Text = .EndTime
                    txtCapacity.Text = .Capacity
                    txtMapLink.Text = .MapLink
                    txtCourseName.Text = .CourseName
                    If (.Active) Then
                        chkactive.checked = True
                    Else
                        chkActive.checked = False
                    End If
                    txtAdditionalInfo.Text = .AdditionalInfo
                    .Courses.Close()
                End If

            End With
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'Try
        Dim objList As New BusinessRules.CCourse()

        With objList
            If txtCourseID.Text <> "" Then
                .CourseID = CInt(txtCourseID.Text)
            Else
                .CourseID = 0
            End If

            .City = ddlCity.SelectedValue
            .CourseTypeID = ddlCourse.SelectedValue
            .Location = txtlocation.Text
            .Building = txtBuilding.Text
            .CourseDate = txtCourseDate.Text
            .StartTime = txtStartTime.Text
            .EndTime = txtEndTime.Text
            .Capacity = txtCapacity.Text
            .MapLink = txtMapLink.Text
            .CourseName = txtCourseName.Text
            .Active = chkActive.Checked
            .AdditionalInfo = txtAdditionalInfo.Text
            .SaveCourse()
        End With

        Response.Redirect("courses.aspx", False)
        'Catch objError As Exception

        '    lblError.Text = objError.Message
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try

    End Sub

End Class
