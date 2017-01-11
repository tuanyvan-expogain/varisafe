Public Class template
    Inherits System.Web.UI.Page
    Protected WithEvents cboContainerID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents lblTemplateID As System.Web.UI.WebControls.Label
    Protected WithEvents dgContainers As System.Web.UI.WebControls.DataGrid
    Protected WithEvents cboParentID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboContainerID2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cboElementID As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtElementOrder As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSaveElement As System.Web.UI.WebControls.Button

    Protected dTable As DataTable
    Protected dtElements As DataTable
    Protected WithEvents lblTemplateName As System.Web.UI.WebControls.Label
    Protected WithEvents cboElementID2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtElementOrder2 As System.Web.UI.WebControls.TextBox
    Protected intContainerID As Integer

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
            lblTemplateID.Text = Request.QueryString("tid")
            lblTemplateName.Text = Request.QueryString("tn")
            FillCombos()
            GetTemplate()
        End If


    End Sub

    Private Sub FillCombos()

        Dim objContainer As New BusinessRules.CContainer()

        With objContainer
            .GetContainers(CInt(Request.QueryString("tid")))
            FillCombo(cboContainerID, .Containers.Tables(0), "ContainerID", "Container")
            FillCombo(cboParentID, .Containers.Tables(0), "ContainerID", "Container")
            FillCombo(cboContainerID2, .Containers.Tables(2), "TemplateContainerID", "Container")
            FillCombo(cboElementID2, .Containers.Tables(1), "elementID", "element")
        End With
    End Sub

    Private Sub GetTemplate()

        Dim objTemplate As New BusinessRules.CTemplate()

        With objTemplate
            .TemplateID = lblTemplateID.Text
            .GetAdminTemplate()
            '.Container.Containers.WriteXml(Server.MapPath("\") & "norwood\control\xml\template.xml")
            dgContainers.DataSource = .Container.Containers.Tables(0)
            dTable = .Container.Containers.Tables(1)
            dtElements = .Container.Containers.Tables(2)
            dgContainers.DataBind()
            AddDelConfirmHandler(dgContainers, 4)

        End With

    End Sub

    Protected Sub AddControl(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        'If e.CommandName = "Insert" Then
        '    Dim objTemplate As New BusinessRules.CContainerElement()

        '    'With objTemplate
        '    '    .ContainerID = 0
        '    '    .ElementID = CType(e.Item.FindControl("cboElementID"), DropDownList).SelectedItem.Value
        '    '    .ElementOrder = CType(e.Item.FindControl("txtElementOrder"), TextBox).Text
        '    '    .InsertContainerElement()
        '    'End With

        'End If

    End Sub

    Protected Sub DeleteControl(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        Dim objContainer As New BusinessRules.CContainerElement()

        With objContainer
            .ContainerElementID = CInt(CType(e.Item.FindControl("lblContainerElementID"), Label).Text)
            .DeleteContainerElement()
        End With

        GetTemplate()

    End Sub

    Protected Sub GetControls(ByVal sender As System.Object, ByVal e As DataGridItemEventArgs)

        If e.Item.ItemType = ListItemType.Item Or _
            e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim dView As New DataView()
            Dim objDG As New DataGrid()

            If Not IsNothing(dTable) Then
                dView = dTable.DefaultView
                dView.RowFilter = "ContainerID=" & e.Item.DataItem("ContainerID")

                objDG = CType(e.Item.FindControl("dgControls"), DataGrid)
                objDG.DataSource = dView
                objDG.DataBind()

                intContainerID = e.Item.DataItem("ContainerID")
            End If
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim objTemplate As New BusinessRules.CTemplate()

        With objTemplate
            .TemplateID = lblTemplateID.Text
            .Container.ContainerID = cboContainerID.SelectedItem.Value
            .Container.ParentID = cboParentID.SelectedItem.Value
            .SaveTemplateContainer()
        End With

        cboContainerID.SelectedIndex = 0
        cboParentID.SelectedIndex = 0

        GetTemplate()

    End Sub

    Protected Sub dgContainers_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgContainers.DeleteCommand

        Dim objTemplate As New BusinessRules.CTemplate()

        With objTemplate
            .Container.ContainerID = dgContainers.DataKeys(CInt(e.Item.ItemIndex))
            .DeleteTemplateContainer()
        End With

        GetTemplate()

    End Sub


    Private Sub btnSaveElement_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveElement.Click

        Dim objTemplate As New BusinessRules.CContainerElement()

        With objTemplate
            .TemplateContainerID = cboContainerID2.SelectedItem.Value
            .ElementID = cboElementID2.SelectedItem.Value
            .ElementOrder = txtElementOrder2.Text
            .InsertContainerElement()
        End With

        cboContainerID2.SelectedIndex = -1
        cboElementID2.SelectedIndex = -1
        txtElementOrder2.Text = ""
        GetTemplate()

    End Sub

End Class
