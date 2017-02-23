Public Class editcontent
    Inherits System.Web.UI.Page
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblPageName As System.Web.UI.WebControls.Label
    Protected WithEvents lblContainer As System.Web.UI.WebControls.Label
    Protected WithEvents lblLanguage As System.Web.UI.WebControls.Label
    Protected WithEvents XHTMLEditor1 As XStandard.XHTMLEditor
    Protected WithEvents txtElementContentID As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents txtContent As FreeTextBoxControls.FreeTextBox
    Protected WithEvents txtContentPlain As System.Web.UI.WebControls.TextBox

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
            getcontent()
        End If

    End Sub

    Private Sub GetContent()

        'Try
        lblPageName.Text = Request.QueryString("pn").ToString
        lblContainer.Text = Request.QueryString("cn").ToString
        lblLanguage.Text = Request.QueryString("ln").ToString

        If IsNumeric(Request.QueryString("ecid")) Then
            txtElementContentID.Text = CInt(Request.QueryString("ecid"))

            Dim objPE As New BusinessRules.CPageElement()

            With objPE
                .PageElementID = CInt(txtElementContentID.Text)
                .EditHTMLContent()

                If Not IsNothing(.Contents) Then
                    txtContentplain.Text = .Contents.ToString
                End If
                ' XHTMLEditor1.Value = .Contents.ToString

            End With
        End If
        'Catch objError As Exception

        '    lblError.Text = objError.Message
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Dim objPE As New BusinessRules.CPageElement()


            With objPE
                .Contents = txtContentPlain.Text 'XHTMLEditor1.Value

                If Request.QueryString("ecid") <> "" Then
                    .PageElementID = CInt(txtElementContentID.Text)
                    .UpdateHTMLContent()
                Else
                    .ElementID = Request.QueryString("eID")
                    .LanguageID = Request.QueryString("plID")
                    .InsertHTMLContent()
                End If
            End With

            Response.Redirect("content.aspx", False)
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub

End Class
