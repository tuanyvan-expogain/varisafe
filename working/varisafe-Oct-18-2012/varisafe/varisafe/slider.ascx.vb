Imports System.Globalization
Imports System.Threading

Public MustInherit Class slider
    'Inherits System.Web.UI.UserControl
    Inherits ControlTemplate
    Protected WithEvents lblForm As System.Web.UI.WebControls.Label
    Protected WithEvents rptFeaturedNews As System.Web.UI.WebControls.Repeater

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
        'ShowFeaturedNews()
    End Sub

    Private Sub ShowFeaturedNews()

        Try
            Dim objNews As New BusinessRules.CNews()

            With objNews
                .Culture = System.Threading.Thread.CurrentThread.CurrentCulture.Name
                .ShowFeaturedNews()
                rptFeaturedNews.DataSource = .NewsItems
                rptFeaturedNews.DataBind()
                .NewsItems.Close()
            End With
        Catch objError As Exception
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Form.ToString(), Request.QueryString.ToString())
            Response.Redirect("/error.aspx", False)

        End Try
    End Sub



End Class
