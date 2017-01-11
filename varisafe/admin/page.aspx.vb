Public Class page
    Inherits System.Web.UI.Page
    Protected WithEvents txtPageName As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkInSitemap As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents txtPageID As System.Web.UI.WebControls.TextBox
    Protected WithEvents cboTemplateID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtPageTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtURL As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkLanguage As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents chkInMainNav As System.Web.UI.WebControls.CheckBox
    Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
    Protected WithEvents cboParentID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSaveLanguages As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Dim dtPageLanguages As DataTable
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents txtNavOrder As System.Web.UI.WebControls.TextBox

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

        '   Try
        'Put user code to initialize the page here
        If IsNumeric(Request.QueryString("pid")) Then
            If IsPostBack = False Then
                txtPageID.Text = Request.QueryString("pid")
                btnSave.Text = "Save"
            End If
        Else
            btnSaveLanguages.Visible = False
            btnSave.Text = "Create Page"
            '    If IsPostBack = False Then
            '        LoadPage()
            '    End If
        End If
        If IsPostBack = False Then
            LoadPage()
            btnDelete.Attributes.Add("onclick", "return window.confirm('Deleting this page will DELETE ALL CONTENT. Are you sure you want to delete this page?');")
            'GetPage()
        End If
        'Catch objError As Exception

        '    lblError.Text = objError.Message
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try

    End Sub

    Private Sub LoadPage()

        'Try
        Dim objPage As New BusinessRules.CPage()
        Dim i, j As Integer

        With objPage
            .PageID = CheckNullNum(txtPageID.Text)
            .LoadPage()
            'Response.Write(.PageName)
            'Exit Sub

            FillCombo(cboParentID, .ComboList.Tables(0), "PageID", "PageName")
            FillCombo(cboTemplateID, .ComboList.Tables(1), "TemplateID", "TemplateName")
            FillCheckBoxList(chkLanguage, .ComboList.Tables(2), "LanguageID", "Language", False)

            If .PageID > 0 Then
                txtPageName.Text = .PageName
                SetComboIndex(cboParentID, .ParentID)
                SetComboIndex(cboTemplateID, .TemplateID)
                chkInSitemap.Checked = .InSitemap
                chkInMainNav.Checked = .inMainNav

                If .NavOrder <> 999 Then
                    txtNavOrder.Text = .NavOrder
                End If

                'Check off languages
                For i = 0 To chkLanguage.Items.Count - 1
                    For j = 0 To .ComboList.Tables(4).Rows.Count - 1
                        If chkLanguage.Items(i).Value = .ComboList.Tables(4).Rows(j).Item(0) Then
                            chkLanguage.Items(i).Selected = True
                            Exit For
                        End If
                    Next
                Next

                'Show page names
                DataList1.DataSource = .ComboList.Tables(4)
                DataList1.DataBind()
            Else
                FillCheckBoxList(chkLanguage, .ComboList.Tables(2), "LanguageID", "Language", True)
            End If
        End With
        'Catch objError As Exception

        '    lblError.Text = objError.Message
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try

    End Sub

    Private Sub GetPage()

        Dim objPage As New BusinessRules.CPage()

        With objPage
            .PageID = txtPageID.Text
            '.GetPageItem()
            'txtTitle.Text = .Title
            'txtBody.Value = .body
            'txtDateEntered.Text = .dateentered
            'txtshortdescription.Text = .shortdescription
            'chkInSitemap.Checked = .
        End With

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        '   Try
        Dim objPage As New BusinessRules.CPage()
        Dim i As Integer

        With objPage

            If txtPageID.Text = "" Then
                .PageID = 0
            Else
                .PageID = CLng(txtPageID.Text)
            End If

            '.Title = txtPageName.Text
            '.body = txtBody.Value
            '.dateentered = txtDateEntered.Text
            '.shortdescription = txtshortdescription.Text
            '.active = chkInSitemap.Checked

            '.PageTitle = txtPageTitle.Text
            .PageName = txtPageName.Text
            .ParentID = cboParentID.SelectedItem.Value
            .TemplateID = cboTemplateID.SelectedItem.Value
            '.URL = txtURL.Text
            .InSitemap = chkInSitemap.Checked
            .inMainNav = chkInMainNav.Checked

            If txtNavOrder.Text <> "" Then
                .NavOrder = txtNavOrder.Text
            End If

            'Fill languages
            With .PageLanguages
                Dim dcLanguageID As New DataColumn("LanguageID", GetType(String))
                Dim dcChecked As New DataColumn("Checked", GetType(Boolean))

                'Add the columns to the DataTable's Columns collection
                .Columns.Add(dcLanguageID)
                .Columns.Add(dcChecked)

                'Add some rows
                Dim dr As DataRow


                For i = 0 To chkLanguage.Items.Count - 1
                    '.Add(chkLanguage.Items(i).Value, chkLanguage.Items(i).Selected)
                    dr = .NewRow()
                    dr("LanguageID") = chkLanguage.Items(i).Value
                    dr("Checked") = chkLanguage.Items(i).Selected
                    .Rows.Add(dr)

                Next
            End With
            .SavePage()
            txtPageID.Text = .PageID
        End With


        Response.Redirect("page.aspx?pid=" & txtPageID.Text, False)
        'Catch objError As Exception

        '    lblError.Text = objError.Message
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try

    End Sub



    Private Sub btnSaveLanguages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLanguages.Click

        '   Try
        Dim i As Integer
        Dim objPage As New BusinessRules.CPage()

        objPage.PageID = CInt(txtPageID.Text)
        With objPage.PageLanguages
            Dim dcLanguageID As New DataColumn("LanguageID", GetType(String))
            Dim dcLinkText As New DataColumn("LinkText", GetType(String))
            Dim dcPageTitle As New DataColumn("PageTitle", GetType(String))
            Dim dcDescription As New DataColumn("Description", GetType(String))
            Dim dcKeywords As New DataColumn("Keywords", GetType(String))

            'Add the columns to the DataTable's Columns collection
            .Columns.Add(dcLanguageID)
            .Columns.Add(dcLinkText)
            .Columns.Add(dcPageTitle)
            .Columns.Add(dcDescription)
            .Columns.Add(dcKeywords)

            'Add some rows
            Dim dr As DataRow

            For i = 0 To DataList1.Items.Count - 1

                dr = .NewRow()
                dr("LanguageID") = CType(DataList1.Items(i).FindControl("lblLanguageID"), Label).Text
                dr("LinkText") = CType(DataList1.Items(i).FindControl("txtLinkName"), TextBox).Text
                dr("PageTitle") = CType(DataList1.Items(i).FindControl("txtPageTitle"), TextBox).Text
                dr("Description") = CType(DataList1.Items(i).FindControl("txtDescription"), TextBox).Text
                dr("Keywords") = CType(DataList1.Items(i).FindControl("txtKeywords"), TextBox).Text
                .Rows.Add(dr)

            Next

        End With
        objPage.SavePageLanguagesText()
        Response.Redirect("pages.aspx", False)
        'Response.Write(objPage.URL)
        'Catch objError As Exception

        '    lblError.Text = objError.Message
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try

    End Sub


    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        'Try
        Dim objPage As New BusinessRules.CPage()

        With objPage
            .PageID = CInt(txtPageID.Text)
            .DeletePage()
        End With

        Response.Redirect("pages.aspx", False)
        'Catch objError As Exception

        '    lblError.Text = objError.Message
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try

    End Sub

End Class
