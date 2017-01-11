
Public Class newsitem_1
    Inherits System.Web.UI.Page
    Protected WithEvents txtNewsID As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkActive As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtDateEntered As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkHomepage As System.Web.UI.WebControls.CheckBox
    Protected WithEvents dlContent As System.Web.UI.WebControls.DataList
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtshortdescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLanguageID As System.Web.UI.WebControls.Label
    Protected WithEvents lblNewsLanguageID As System.Web.UI.WebControls.Label
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents XHTMLEditor1 As XStandard.XHTMLEditor
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents cbonewstypeid As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSaveNews As System.Web.UI.WebControls.Button
    Protected WithEvents chkLanguage As System.Web.UI.WebControls.CheckBoxList
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents txtPageID As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents dvLang As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected dTable As DataTable
    Dim objNews As New BusinessRules.CNews()

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
        If Not IsPostBack Then
            GetNewsItem()
        End If
    End Sub

    Private Sub GetNewsItem()

        With objNews
            If IsNumeric(Request.QueryString("nid")) Then
                .newsID = CInt(Request.QueryString("nid"))
                txtNewsID.Text = .newsID.ToString
            Else
                btnSave.Visible = False
                btnSaveNews.Text = "Create News Item"
                btnDelete.Visible = False
            End If

            .EditNewsItem()

            FillCombo(cbonewstypeid, .News.Tables(0), "newsTypeID", "newsType")
            FillCheckBoxList(chkLanguage, .News.Tables(1), "LanguageID", "Language", False)

            If chkLanguage.Items.Count = 1 Then
                chkLanguage.Items(0).Selected = True
                'dvLang.Visible = False
            End If

            'dlContent.DataSource = .News.Tables(1)
            'dlContent.DataBind()

            If .newsID > 0 Then
                txtDateEntered.Text = .dateentered
                SetComboIndex(cbonewstypeid, .newstypeID)
                chkActive.Checked = .active
                chkHomepage.Checked = .homepage

                dTable = .News.Tables(2)
                dlContent.DataSource = dTable
                dlContent.DataBind()

                'Populate datalist with boxes for each language
                'Dim objLi As DataListItem
                'Dim lid As Integer
                'Dim dView As DataView

                'For Each objLi In dlContent.Items
                '    lid = CInt(CType(objLi.FindControl("lblLanguageID"), Label).Text)
                '    dView = New DataView(.News.Tables(2), "LanguageID = " & lid, "", DataViewRowState.OriginalRows)

                '    If dView.Count > 0 Then
                '        CType(objLi.FindControl("lblNewsLanguageID"), Label).Text = dView.Item(0).Item("NewsLanguageID")
                '        CType(objLi.FindControl("txtTitle"), TextBox).Text = dView.Item(0).Item("title")
                '        CType(objLi.FindControl("txtshortdescription"), TextBox).Text = dView.Item(0).Item("shortdesciption")
                '        CType(objLi.FindControl("XHTMLEditor1"), XStandard.WebForms.XHTMLEditor).Value = dView.Item(0).Item("body").ToString

                '    End If
                'Next


                'dlContent.DataSource = .News.Tables(1)
                'dlContent.DataBind()
            End If

            .News.Dispose()
        End With

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim objLi As DataListItem
        Dim row As DataRow

        With objNews
            If txtNewsID.Text <> "" Then
                .newsID = CInt(txtNewsID.Text)
            Else
                .newsID = 0
            End If

            .News = New DataSet()
            .News.Tables.Add()
            .News.Tables(0).Columns.Add("NewsLanguageID")
            .News.Tables(0).Columns.Add("languageID")
            .News.Tables(0).Columns.Add("title")
            .News.Tables(0).Columns.Add("body")
            .News.Tables(0).Columns.Add("shortdesciption")

            .newstypeID = cbonewstypeid.SelectedItem.Value
            .dateentered = Replace(txtDateEntered.Text, "'", "''")
            .active = chkActive.Checked
            .homepage = chkHomepage.Checked

            For Each objLi In dlContent.Items

                row = .News.Tables(0).NewRow
                row("NewsLanguageID") = CType(objLi.FindControl("lblNewsLanguageID"), Label).Text
                row("languageID") = CType(objLi.FindControl("lblLanguageID"), Label).Text
                row("title") = Replace(CType(objLi.FindControl("txtTitle"), TextBox).Text, "'", "''")
                row("shortdesciption") = Replace(CType(objLi.FindControl("txtshortdescription"), TextBox).Text, "'", "''")
                row("body") = Replace(stripXML(CType(objLi.FindControl("XHTMLEditor1"), XStandard.XHTMLEditor).Value), "'", "''")
                .News.Tables(0).Rows.Add(row)

                '        'row = .News.Tables(0).NewRow
                '        '.News.Tables(0).Rows.Add(row)
            Next
            '    '.SaveNewsItem()
            .SaveNewsLanguages()
            'Response.Write(.title)
        End With

        Response.Redirect("news.aspx", False)

    End Sub

    Private Sub SaveNewsLanguages()

        Dim objLi As DataListItem
        Dim row As DataRow
        Dim i As Integer

        With objNews
            'Create the columns to populate
            .News = New DataSet()
            .News.Tables.Add()
            .News.Tables(0).Columns.Add("NewsLanguageID")
            .News.Tables(0).Columns.Add("languageID")
            .News.Tables(0).Columns.Add("title")
            .News.Tables(0).Columns.Add("body")
            .News.Tables(0).Columns.Add("shortdesciption")

            If dlContent.Items.Count = 0 Then
                'New news item - no details yet so fill w/default values
                For i = 0 To chkLanguage.Items.Count - 1
                    If chkLanguage.Items(i).Selected Then
                        row = .News.Tables(0).NewRow
                        row("NewsLanguageID") = 0
                        row("languageID") = chkLanguage.Items(i).Value
                        row("title") = ""
                        row("shortdesciption") = ""
                        row("body") = ""
                        .News.Tables(0).Rows.Add(row)
                    End If
                Next
            Else
                'Editing existing news language records
                For Each objLi In dlContent.Items

                    row = .News.Tables(0).NewRow
                    row("NewsLanguageID") = CType(objLi.FindControl("lblNewsLanguageID"), Label).Text
                    row("languageID") = CType(objLi.FindControl("lblLanguageID"), Label).Text
                    row("title") = Replace(CType(objLi.FindControl("txtTitle"), TextBox).Text, "'", "''")
                    row("shortdesciption") = Replace(CType(objLi.FindControl("txtshortdescription"), TextBox).Text, "'", "''")
                    row("body") = Replace(stripXML(CType(objLi.FindControl("XHTMLEditor1"), XStandard.XHTMLEditor).Value), "'", "''")
                    .News.Tables(0).Rows.Add(row)

                    'row = .News.Tables(0).NewRow
                    '.News.Tables(0).Rows.Add(row)
                Next
            End If
            .SaveNewsLanguages()
            Response.Write(.title)
        End With

    End Sub

    Private Sub btnSaveNews_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveNews.Click

        Dim nid As Integer = 0
        Dim i As Integer
        Dim bolLangChecked As Boolean = False

        'Ensure at least 1 language is selected
        With chkLanguage
            For i = 0 To .Items.Count - 1
                If .Items(i).Selected Then
                    bolLangChecked = True
                    Exit For
                End If
            Next
        End With

        'Throw error if no languages picked and exit
        If bolLangChecked = False Then
            lblError.Text = "Please select at least 1 Language for this news item."
            Exit Sub
        End If

        'Validation OK; proceed to save
        With objNews
            If txtNewsID.Text = "" Then
                .newsID = 0 'Insert
            Else
                .newsID = CLng(txtNewsID.Text) 'Update
            End If

            .dateentered = DateTime.Parse(txtDateEntered.Text)
            .newstypeID = cbonewstypeid.SelectedItem.Value
            .active = chkActive.Checked
            .homepage = chkHomepage.Checked
            .SaveNewsItem()
            SaveNewsLanguages()
            nid = .newsID
        End With

        Response.Redirect("newsitem.aspx?nid=" & nid)

    End Sub

    Private Sub dlContent_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlContent.ItemDataBound

        Dim lid As Integer
        Dim i As Integer

        'Check off selected languages
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Then
            lid = CInt(CType(e.Item.FindControl("lblLanguageID"), Label).Text)

            With chkLanguage
                For i = 0 To .Items.Count - 1
                    If .Items(i).Value = lid Then
                        .Items(i).Selected = True
                    End If
                Next
            End With
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim objNews As New BusinessRules.CNews()

        With objNews
            .newsID = CInt(txtNewsID.Text)
            .DeleteNewsItem()
        End With

        Response.Redirect("news.aspx", False)
    End Sub
End Class
