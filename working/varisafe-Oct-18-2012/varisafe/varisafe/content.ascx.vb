Imports System.Threading

Public MustInherit Class content1
    'Inherits System.Web.UI.UserControl
    Inherits ControlTemplate
    Protected WithEvents ltlContent As System.Web.UI.WebControls.Literal
    Protected WithEvents ltlPageTitle As System.Web.UI.WebControls.Literal

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
        GetContent()
    End Sub

    Private Sub GetContent()

        'Try
        Dim objpage As New BusinessRules.CPageElement()

        With objpage
            .PageID = PageID
            .ContainerID = ContainerID
            '.LanguageID = 1 'will need to make dynamic
            .CurrLanguage = Thread.CurrentThread.CurrentCulture.ToString
            .GetHTMLContent()
            While .Content.Read

                ltlContent.Text = .Content.Item(0).ToString
                ltlPageTitle.Text = .Content.Item(1).ToString
            End While


        End With

        'Catch objError As Exception
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Form.ToString(), Request.QueryString.ToString())
        '    Response.Redirect("/error.aspx", False)

        'End Try

    End Sub



End Class
