Public Class CDataAccess

#Region "Members"

    Private mstrConn As String = GetConnString()
    Private msiteID As Integer = GetSiteID()

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.new()
    End Sub

#End Region

#Region "Methods"

    Public Shared Function GetConnString() As String

        Dim connString As String = _
       System.Configuration.ConfigurationManager.ConnectionStrings("strConn").ConnectionString

        Return connString

        'Return System.Configuration.ConfigurationManager.AppSettings("strConn")
        'Dim rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/kw/")
        'Dim connString As System.Configuration.ConnectionStringSettings

        'connString = rootWebConfig.ConnectionStrings.ConnectionStrings(0) '("strConn")

        'If Not IsNothing(connString) Then
        '    Dim x As String = connString.Name
        'Else
        '    Dim y As String = "nothing"
        'End If
        'Return connString.ConnectionString
        'Dim objAr As New AppSettingsReader()

        ''Gets DB Connection string by reading value from config file
        'Return objAr.GetValue("strConn", GetType(System.String))

    End Function

    Public Shared Function GetSiteID() As Integer

        Return 1
        'Dim objAr As New AppSettingsReader()

        'Gets DB Connection string by reading value from config file
        'Return objAr.GetValue("siteID", GetType(System.String))

    End Function

#End Region

#Region "Properties"

    Public Property strConn() As String
        Get
            Return mstrConn
        End Get
        Set(ByVal Value As String)
            mstrConn = Value
        End Set
    End Property

    Public Property siteID() As Integer
        Get
            Return msiteID
        End Get
        Set(ByVal Value As Integer)
            msiteID = Value
        End Set
    End Property

#End Region

End Class
