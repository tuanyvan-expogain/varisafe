Imports System.Threading
Imports System.Globalization

Public Class ControlTemplate
    Inherits System.Web.UI.UserControl
    Public mPageID As Integer
    Public mContainerID As Integer

#Region "Properties"

    Public Property PageID() As Integer
        Get
            Return mPageID
        End Get
        Set(ByVal Value As Integer)
            mPageID = Value
        End Set
    End Property
    Public Property ContainerID() As Integer
        Get
            Return mContainerID
        End Get
        Set(ByVal Value As Integer)
            mContainerID = Value
        End Set
    End Property

#End Region

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
    End Sub

End Class
