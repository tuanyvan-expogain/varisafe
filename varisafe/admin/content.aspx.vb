Public Class content
    Inherits System.Web.UI.Page
    Protected WithEvents dgContent As System.Web.UI.WebControls.DataGrid
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
        lblerror.text = ""
        GetContent()
    End Sub

    Private Sub GetContent()

        Try
            Dim objPE As New BusinessRules.CPageElement()

            With objPE
                .GetHTMLElements()

                Dim dView As New DataView(.PageStructure.Tables(0), "elementContentID IS NOT NULL", "", DataViewRowState.OriginalRows)
                dgContent.DataSource = dView '.PageStructure
                dgContent.DataBind()
                dView.Dispose()
            End With
        Catch objError As Exception

            lblerror.text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try
    End Sub

    Private Sub dgContent_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgContent.ItemDataBound

        Try
            Dim strQS As String

            If e.Item.ItemType = ListItemType.Item Or _
                        e.Item.ItemType = ListItemType.AlternatingItem Then
                strQS = "editcontent.aspx?ecid=" & CType(e.Item.FindControl("lblElementContentID"), Label).Text & _
                    "&pn=" & CType(e.Item.FindControl("lblPageName"), Label).Text & _
                    "&cn=" & CType(e.Item.FindControl("lblContainer"), Label).Text & _
                     "&plID=" & CType(e.Item.FindControl("lblPageLanguageID"), Label).Text & _
                      "&eID=" & CType(e.Item.FindControl("lblElementID"), Label).Text & _
                    "&ln=" & CType(e.Item.FindControl("lblLanguage"), Label).Text
                CType(e.Item.FindControl("lnkEdit"), HyperLink).NavigateUrl = strQS
            End If
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub

End Class
