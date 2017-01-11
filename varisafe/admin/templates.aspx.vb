Public Class templates
    Inherits System.Web.UI.Page
    Protected WithEvents dgTemplates As System.Web.UI.WebControls.DataGrid

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
        If IsPostBack = False Then
            GetTemplates()
        End If
    End Sub

    Private Sub GetTemplates()

        Dim objTemplate As New BusinessRules.CTemplate()

        With objTemplate
            .GetTemplates()
            dgTemplates.DataSource = .Templates
            dgTemplates.DataBind()
        End With

    End Sub

    
    Protected Sub dgTemplates_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTemplates.EditCommand

        dgTemplates.EditItemIndex = CInt(e.Item.ItemIndex)
        GetTemplates()

    End Sub

    Protected Sub dgTemplates_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTemplates.UpdateCommand

        Dim objTemplate As New BusinessRules.CTemplate()

        With objTemplate
            .TemplateID = dgTemplates.DataKeys(CInt(e.Item.ItemIndex))
            .TemplateName = CType(e.Item.FindControl("txtEditTemplate"), TextBox).Text
            .SaveTemplate()
        End With

        dgTemplates.EditItemIndex = -1
        GetTemplates()

    End Sub

    Protected Sub dgTemplates_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTemplates.CancelCommand

        dgTemplates.EditItemIndex = -1
        GetTemplates()

    End Sub

    Protected Sub dgTemplates_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgTemplates.ItemCommand

        If e.CommandName = "Add" Then
            Dim objTemplate As New BusinessRules.CTemplate()

            With objTemplate
                .TemplateID = 0
                .TemplateName = CType(e.Item.FindControl("txtAddTemplate"), TextBox).Text
                .SaveTemplate()
            End With

            GetTemplates()
        End If

    End Sub

    Private Sub dgTemplates_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgTemplates.ItemDataBound

        Dim strQS As String

        If e.Item.ItemType = ListItemType.Item Or _
                    e.Item.ItemType = ListItemType.AlternatingItem Then
            strQS = "template.aspx?tid=" & CType(e.Item.FindControl("lblTemplateID"), Label).Text & _
                "&tn=" & CType(e.Item.FindControl("lblTemplateName"), Label).Text
            CType(e.Item.FindControl("lnkEdit"), HyperLink).NavigateUrl = strQS
        End If

    End Sub
End Class
