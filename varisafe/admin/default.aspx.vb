Imports System.Data.SqlClient
Imports System.Web.Security

Public Class _default1
    Inherits System.Web.UI.Page
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnLogin As System.Web.UI.WebControls.Button
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents txtUsername As System.Web.UI.WebControls.TextBox

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
        If HttpContext.Current.User.IsInRole("Admin") Then
            Response.Redirect("menu.aspx", False)
        End If

    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Dim bolAuthenticated As Boolean = False
        Dim objUser As New BusinessRules.CUser()

        'Try
            With objUser
                .Username = txtUsername.Text
            .Password = txtPassword.Text
                .ValidateUser()

            If .UserID > 0 Then
                bolAuthenticated = True
                FormsAuthentication.RedirectFromLoginPage(.UserID.ToString, False)
            End If

        End With

        If bolAuthenticated Then
            Response.Redirect("menu.aspx", False)
        Else
            lblError.Text = "Invalid Login"
        End If

        'Catch objError As Exception
        '    lblError.Text = "An error has occurred in your application" & _
        '        ".  Please try re-loading the page, or contact technical support with a description of this problem."

        '    ''Notify tech support
        '    'Dim objErr As New CEmail()
        '    'objErr.SendErrorMessage(objError, Request.Form.ToString(), Request.QueryString.ToString(), Session("CompanyID"), Session("StoreID"))
        '    'objErr = Nothing
        'End Try

    End Sub
End Class
