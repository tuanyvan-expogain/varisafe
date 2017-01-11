Public Class newsitem
    Inherits System.Web.UI.Page
    Protected WithEvents txtNewsID As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkActive As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtDateEntered As System.Web.UI.WebControls.TextBox
    Protected WithEvents cbonewstypeid As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents chkHomepage As System.Web.UI.WebControls.CheckBox
    Protected WithEvents dlContent As System.Web.UI.WebControls.DataList
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtshortdescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblLanguageID As System.Web.UI.WebControls.Label
    Protected WithEvents lblNewsLanguageID As System.Web.UI.WebControls.Label
    Protected WithEvents RequiredFieldValidator1 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator2 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents RequiredFieldValidator4 As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents XHTMLEditor1 As XStandard.XHTMLEditor
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected dTable As DataTable
    Protected WithEvents lblError As System.Web.UI.WebControls.Label

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
            GetNewsItem()
        End If
    End Sub

    Private Sub GetNewsItem()

        Try
            Dim objNews As New BusinessRules.CNews()

            With objNews
                If IsNumeric(Request.QueryString("nid")) Then
                    .newsID = CInt(Request.QueryString("nid"))
                    txtNewsID.Text = .newsID.ToString
                End If

                .EditNewsItem()
                FillCombo(cbonewstypeid, .News.Tables(0), "newsTypeID", "newsType")
                dlContent.DataSource = .News.Tables(1)
                dlContent.DataBind()
                'Response.Write(.newsID)

                If .newsID > 0 Then
                    txtDateEntered.Text = .dateentered
                    SetComboIndex(cbonewstypeid, .newstypeID)
                    chkActive.Checked = .active
                    chkHomepage.Checked = .homepage
                    dTable = .News.Tables(2)

                    'Populate datalist with boxes for each language
                    Dim objLi As DataListItem
                    Dim lid As Integer
                    Dim dView As DataView

                    For Each objLi In dlContent.Items
                        lid = CInt(CType(objLi.FindControl("lblLanguageID"), Label).Text)
                        dView = New DataView(.News.Tables(2), "LanguageID = " & lid, "", DataViewRowState.OriginalRows)

                        If dView.Count > 0 Then
                            CType(objLi.FindControl("lblNewsLanguageID"), Label).Text = dView.Item(0).Item("NewsLanguageID")
                            CType(objLi.FindControl("txtTitle"), TextBox).Text = dView.Item(0).Item("title")
                            CType(objLi.FindControl("txtshortdescription"), TextBox).Text = dView.Item(0).Item("shortdesciption")
                            CType(objLi.FindControl("XHTMLEditor1"), XStandard.XHTMLEditor).Value = dView.Item(0).Item("body").ToString

                        End If
                    Next


                    'dlContent.DataSource = .News.Tables(1)
                    'dlContent.DataBind()
                End If

                .News.Dispose()
            End With
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Dim objNews As New BusinessRules.CNews()
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

                    'row = .News.Tables(0).NewRow
                    '.News.Tables(0).Rows.Add(row)
                    .SaveNewsItem()
                    'Response.Write(.title)
                Next
            End With

            Response.Redirect("news.aspx", False)
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub


End Class
