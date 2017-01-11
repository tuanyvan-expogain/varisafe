Imports System.Web.Security
Imports System.Security.Principal

Public MustInherit Class header1
    Inherits System.Web.UI.UserControl
    Protected WithEvents lnkPages As System.Web.UI.WebControls.HyperLink
    Protected WithEvents liContent As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents liPages As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents lnkTemplates As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkContent As System.Web.UI.WebControls.HyperLink
    Protected WithEvents liTemplates As System.Web.UI.HtmlControls.HtmlGenericControl

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
        SetTabs()
    End Sub

    Private Sub SetTabs()

        'If HttpContext.Current.User.IsInRole("Admin") Then
        '    liTemplates.Visible = True
        '    lnkTemplates.Visible = True
        '    lnkContent.Visible = True
        '    liContent.Visible = True
        '    lnkPages.Visible = True
        '    liPages.Visible = True
        'Else
        '    If HttpContext.Current.User.IsInRole("Design") Then
        '        lnkPages.Visible = True
        '        liPages.Visible = True
        '        lnkContent.Visible = True
        '        liContent.Visible = True
        '    Else
        '        lnkPages.Visible = False
        '        liPages.Visible = False
        '        lnkContent.Visible = False
        '        liContent.Visible = False
        '    End If
        '    liTemplates.Visible = False
        'End If

    End Sub

End Class
