Public Class courses
    Inherits System.Web.UI.Page
    Protected WithEvents rptCourses As System.Web.UI.WebControls.Repeater
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents dgCourses As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ddlDisplay As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox

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
        txtEmail.visible = False
        GetCourses("dte")
    End Sub

    Private Sub GetCourses(ByVal strSort As String)

        ' Try
        Dim objList As New BusinessRules.CCourse()

        With objList
            .GetCourses()

            Dim strFilter As String = ""

            If ddlDisplay.SelectedValue = "Upcoming" Then
                strFilter = "dte >= '" + System.DateTime.Today + "'"
            ElseIf ddlDisplay.SelectedValue = "Completed" Then
                strFilter = "dte < '" + System.DateTime.Today + "'"
            End If

            Dim dView As New DataView(.CourseDS.Tables(0), strFilter, strSort, DataViewRowState.OriginalRows)
            dgCourses.DataSource = dView '.Courses
            dgCourses.DataBind()

            dView.Dispose()
            .CourseDS.Dispose()
            '.Courses.Close()
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
            GetCourses("dte")

        End If

    End Sub

    Private Sub rptCourses_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptCourses.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim deleteButton As LinkButton = e.Item.FindControl("btnDelete")

            'We can now add the onclick event handler
            deleteButton.Attributes("onclick") = "javascript:return " &
                       "confirm('Are you sure you want to delete this course?')"


        End If
    End Sub

    Protected Sub dgCourses_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCourses.DeleteCommand

        If e.CommandName = "Delete" Then
            Dim objList As New BusinessRules.CCourse

            With objList
                .CourseID = dgCourses.DataKeys(CInt(e.Item.ItemIndex)) 'e.Item.DataItem.Int32.Parse(e.CommandArgument.ToString())
                .DeleteCourse()
            End With

            objList = Nothing
            GetCourses("dte")
        End If

    End Sub

    Private Sub dgCourses_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgCourses.ItemCommand

        If e.CommandName = "Remind" Then
            Dim objReg As New BusinessRules.CRegistration

            With objReg
                .CourseID = dgCourses.DataKeys(CInt(e.Item.ItemIndex))
                .SendReminders()
            End With

            objReg = Nothing
            Response.Write("<script language=""javascript"">alert('Reminders Sent');</script>")
        ElseIf e.CommandName = "MailList" Then
            Dim objReg As New BusinessRules.CRegistration
            Dim strList As String = ""

            With objReg
                .CourseID = dgCourses.DataKeys(CInt(e.Item.ItemIndex))
                strList = .GetEmailList()
            End With
            txtEmail.Text = strList
            txtEmail.Visible = True

            objReg = Nothing
        End If

    End Sub

    Private Sub dgCourses_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgCourses.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim deleteButton As LinkButton = CType(e.Item.Cells(dgCourses.Columns.Count - 1).Controls(0), LinkButton) 'e.Item.FindControl("btnDelete")

            'We can now add the onclick event handler
            deleteButton.Attributes("onclick") = "javascript:return " & _
                       "confirm('***Are you sure you want to delete this course and ALL registrations?***')"

            'Reminder confirmation
            Dim remindButton As LinkButton = CType(e.Item.Cells(dgCourses.Columns.Count - 3).Controls(0), LinkButton)

            'We can now add the onclick event handler
            remindButton.Attributes("onclick") = "javascript:return " &
                       "confirm('Are you sure you want to send reminders for this course?')"

            If e.Item.Cells(6).Text = "0" Then
                e.Item.BackColor = Drawing.Color.LightGray
            End If
        End If
    End Sub

    Private Sub ddlDisplay_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDisplay.SelectedIndexChanged

        GetCourses("dte")

    End Sub

    Protected Sub dgCourses_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgCourses.SortCommand

        GetCourses(e.SortExpression)

    End Sub

End Class
