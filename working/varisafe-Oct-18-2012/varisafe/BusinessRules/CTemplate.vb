Imports System.Data.SqlClient
Imports System.Data

Public Class CTemplate

#Region "Members"

    Private mTemplateID As Integer
    Private mTemplateName As String
    Private mContainer As CContainer
    Private mTemplates As SqlDataReader

#End Region

#Region "Properties"

    Public Property TemplateID() As Integer
        Get
            Return mTemplateID
        End Get
        Set(ByVal value As Integer)
            mTemplateID = value
        End Set
    End Property
    Public Property TemplateName() As String
        Get
            Return mTemplateName
        End Get
        Set(ByVal Value As String)
            mTemplateName = Value
        End Set
    End Property
    Public Property Container() As CContainer
        Get
            Return mContainer
        End Get
        Set(ByVal Value As CContainer)
            mContainer = Value
        End Set
    End Property
    Public Property Templates() As SqlDataReader
        Get
            Return mTemplates
        End Get
        Set(ByVal Value As SqlDataReader)
            mTemplates = Value
        End Set
    End Property

#End Region

#Region "Constructor"

    Public Sub New()

        MyBase.New()
        Container = New CContainer()

    End Sub

#End Region

#Region "Members"

    Public Sub SaveTemplate()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "spKWSaveTemplate", _
            New SqlParameter("@TemplateID", TemplateID), _
            New SqlParameter("@TemplateName", TemplateName))
        'New SqlParameter("@siteID", siteID))

    End Sub

    Public Sub GetTemplates()

        Templates = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, _
           "spKWGetTemplates")

        'Templates = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, _
        '     "spGetTemplates", New SqlParameter("@siteID", siteID))

    End Sub

    Public Sub SaveTemplateContainer()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "spKWSaveTemplateContainer", _
            New SqlParameter("@TemplateID", TemplateID), _
            New SqlParameter("@ContainerID", Container.ContainerID), _
            New SqlParameter("@ParentID", Container.ParentID))

    End Sub

    Public Sub GetAdminTemplate()

        Container.Containers = SqlHelper.ExecuteDataset(strConn, CommandType.Text, _
            "EXEC spKWGetAdminTemplate " & TemplateID & ";EXEC spKWGetContainerElements " & TemplateID & ";" & _
            "EXEC spKWGetElements;")
    End Sub

    Public Sub DeleteTemplateContainer()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spKWDeleteTemplateContainer", _
            New SqlParameter("@TemplateContainerID", Container.ContainerID))

    End Sub

#End Region

End Class
