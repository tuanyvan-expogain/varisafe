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

        ltlDir.Text = "ASC"
    End Sub

    Sub SearchByCourseID()

        Dim objReg As New BusinessRules.CRegistration

        With objReg
            .CourseID = CInt(Request.QueryString("cid"))
            ltlcid.Text = .CourseID.ToString
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

        ltlcid.Text = ""
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

        If ddlCourse.SelectedItem.Text <> "-Any-" Then
            If Left(ddlCourse.SelectedItem.Text.ToLower, 4) = "home" Then
                CourseTypeID = 2
            Else
                CourseTypeID = 1
            End If
        End If

        If ddlCity.SelectedItem.Text <> "-Any-" Then
            cy = ddlCity.SelectedItem.Text
        End If

        Dim rid As Integer

        If txtRegistrationID.Text <> "" Then
            rid = CInt(txtRegistrationID.Text)
        End If

        Dim WaitStatus As Integer = -1

        If ddlWaitList.SelectedIndex > 0 Then
            WaitStatus = CInt(ddlWaitList.SelectedValue)
        End If

        With objReg
            .SearchRegistrations(CourseTypeID, cy, sDate, eDate, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text, rid, WaitStatus)
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
        ddlCourse.Items(0).Text = "-Any-"
        ddlCity.Items(0).Text = "-Any-"
        txtFirstName.Text = ""
        txtLastName.Text = ""
        'gvReg.Visible = False
        dvResults.Visible = False
        ddlCity.ClearSelection()
        ddlCourse.ClearSelection()

    End Sub

    Private Sub btnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.Click

        If ltlcid.Text <> "" Then
            SearchByCourseID()
        Else
            SearchRegistrations()
        End If

        gvExport.Visible = True
        'CDataGridToExcel.GridViewToExcel(gvExport, Response)
        GridViewToExcel(gvExport, Response)
        gvExport.Visible = False

    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As System.Web.UI.Control)

    End Sub

    ' Override the Render method to ensure that this control
    ' is nested in an HtmlForm server control, between a <form runat=server>
    ' opening tag and a </form> closing tag.
    Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

        ' Ensure that the control is nested in a server form.
        If Not (Page Is Nothing) Then
            Page.VerifyRenderingInServerForm(Me)
        End If

        MyBase.Render(writer)

    End Sub

    Public Shared Sub GridViewToExcel(ByVal dgExport As GridView, ByVal response As HttpResponse)
        'clean up the response.object
        response.Buffer = True
        response.Clear()
        response.Charset = ""

        ' response.ContentEncoding = Encoding.UTF8


        'try to open new window
        response.AddHeader("Content-Disposition", "attachment; filename=VariSAFE_Report.xls")

        'set the response mime type for excel
        ' response.Cache.SetCacheability(HttpCacheability.NoCache)

        response.ContentType = "application/vnd.ms-excel"


        'create a string writer
        Dim stringWrite As New System.IO.StringWriter()

        'create an htmltextwriter which uses the stringwriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)


        'instantiate a datagrid
        Dim dg As New GridView
        ' just set the input datagrid = to the new dg grid
        dg = dgExport

        ' I want to make sure there are no annoying gridlines
        dg.GridLines = GridLines.Both

        ' Make the header text bold
        dg.HeaderStyle.Font.Bold = True

        ' If needed, here's how to change colors/formatting at the component level
        'dg.HeaderStyle.ForeColor = System.Drawing.Color.Black
        'dg.ItemStyle.ForeColor = System.Drawing.Color.Black

        'bind the modified datagrid
        dg.AllowPaging = False
        dg.ShowFooter = False
        dg.DataBind()

        'Remove any button columns
        Dim i As Integer
        Dim strHeader As String

        For i = 0 To dg.Columns.Count - 1
            strHeader = LCase(dg.Columns(i).HeaderText)
            If strHeader = "edit" Or strHeader = "view" Or _
                strHeader = "view/edit" Or strHeader = "delete" Or _
                strHeader = "select" Or strHeader = "update" Or _
                strHeader = "details" Or strHeader = "remove" Or _
                strHeader = "save" Or strHeader = "charity trustee search" Or _
                strHeader = "view donor record source" Or strHeader = "noza donor search" Or _
                strHeader = "political donor search" Or strHeader = "corporate director search" Or _
                strHeader = "bio" Or strHeader = "who's who search" Or strHeader = "zoominfo search" Then
                dg.Columns(i).Visible = False
            End If

        Next

        'tell the datagrid to render itself to our htmltextwriter
        stringWrite.Write("<html><head><meta http-equiv=""content-type"" content=""text/html; charset=utf-8""></head><body>")

        dg.RenderControl(htmlWrite)
        stringWrite.Write("</body></html>")

        'output the html
        response.Write(stringWrite.ToString)
        response.End()

    End Sub

    Private Sub gvReg_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvReg.RowCommand

        If e.CommandName = "Activate" Then
            Dim objR As New BusinessRules.CRegistration

            With objR
                .RegistrationID = Convert.ToInt32(Me.gvReg.DataKeys(Int32.Parse(e.CommandArgument.ToString())).Value)
                .Activate()
            End With
            SearchRegistrations()

        End If

    End Sub

    Private Sub gvReg_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvReg.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            If CType(e.Row.FindControl("ltlWaitList"), Literal).Text = "True" Then
                e.Row.BackColor = Drawing.Color.LightGray
            End If

            Dim objLnk As LinkButton

            objLnk = CType(e.Row.Cells(9).Controls(0), LinkButton)
            objLnk.Attributes.Add("onclick", "return confirm('Are you sure you want to Delete this item?')")

        End If

    End Sub

    Private Sub gvReg_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvReg.RowDeleting

        Dim objR As New BusinessRules.CRegistration

        With objR
            .RegistrationID = Convert.ToInt32(gvReg.DataKeys(e.RowIndex).Value) ' Convert.ToInt32(Me.gvReg.DataKeys(e.RowIndex))
            .DeleteRegistration()
        End With
        SearchRegistrations()

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

        If ddlCourse.SelectedItem.Text <> "-Any-" Then
            If Left(ddlCourse.SelectedItem.Text.ToLower, 4) = "home" Then
                CourseTypeID = 2
            Else
                CourseTypeID = 1
            End If
        End If

        If ddlCity.SelectedItem.Text <> "-Any-" Then
            cy = ddlCity.SelectedItem.Text
        End If

        Dim rid As Integer
        If txtRegistrationID.Text <> "" Then
            rid = CInt(txtRegistrationID.Text)
        End If

        Dim WaitStatus As Integer = -1

        If ddlWaitList.SelectedIndex > 0 Then
            WaitStatus = CInt(ddlWaitList.SelectedValue)
        End If

        With objReg
            .SearchRegistrations(CourseTypeID, cy, sDate, eDate, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text, rid, WaitStatus)
            Dim dView As New DataView(.CourseDS.Tables(0), "", e.SortExpression & " " & ltlDir.Text, DataViewRowState.OriginalRows)
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

    Private Sub gvExport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvExport.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then
            If CType(e.Row.FindControl("ltlWaitList"), Literal).Text = "True" Then
                e.Row.Visible = False
            End If
        End If

    End Sub

End Class