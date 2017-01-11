Public Class courses
    Inherits System.Web.UI.Page
    Protected WithEvents rptCourses As System.Web.UI.WebControls.Repeater
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents dgCourses As System.Web.UI.WebControls.DataGrid

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
        GetCourses()
    End Sub

    Private Sub GetCourses()

        ' Try
        Dim objList As New BusinessRules.CCourse()

        With objList
            .GetCourses()
            dgCourses.DataSource = .Courses
            dgCourses.DataBind()
            .Courses.Close()
        End With
        'Catch objError As Exception

        '    lblError.Text = objError.Message
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try

    End Sub

    Private Sub rptCourses_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptCourses.ItemCommand

        If e.CommandName = "Delete" Then
            Dim objList As New BusinessRules.CCourse

            With objList
                .CourseID = Int32.Parse(e.CommandArgument.ToString())
                .DeleteCourse()
            End With

            objList = Nothing
            GetCourses()
        End If

    End Sub

    Private Sub rptCourses_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptCourses.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim deleteButton As LinkButton = e.Item.FindControl("btnDelete")

            'We can now add the onclick event handler
            deleteButton.Attributes("onclick") = "javascript:return " & _
                       "confirm('Are you sure you want to delete this course?')"
        End If
    End Sub

    Protected Sub dgCourses_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCourses.DeleteCommand

        If e.CommandName = "Delete" Then
            Dim objList As New BusinessRules.CCourse

            With objList
                .CourseID = Int32.Parse(e.CommandArgument.ToString())
                .DeleteCourse()
            End With

            objList = Nothing
            GetCourses()
        End If

    End Sub

    Private Sub dgCourses_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCourses.ItemDataBound


        'If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
        '    Dim deleteButton As LinkButton = e.Item.FindControl("btnDelete")

        '    'We can now add the onclick event handler
        '    deleteButton.Attributes("onclick") = "javascript:return " & _
        '               "confirm('Are you sure you want to delete this course?')"
        'End If
    End Sub
End Class
