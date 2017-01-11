Imports System.Data.SqlClient
Imports System.Data

Public Class CContainer

#Region "Members"

    Private mContainerID As Integer
    Private mContainer As String
    Private mContainers As DataSet
    Private mParentID As Integer

#End Region

#Region "Properties"

    Public Property ContainerID() As Integer
        Get
            Return mContainerID
        End Get
        Set(ByVal Value As Integer)
            mContainerID = Value
        End Set
    End Property

    Public Property Container() As String
        Get
            Return mContainer
        End Get
        Set(ByVal Value As String)
            mContainer = Value
        End Set
    End Property
    Public Property Containers() As DataSet
        Get
            Return mContainers
        End Get
        Set(ByVal Value As DataSet)
            mContainers = Value
        End Set
    End Property
    Public Property ParentID() As Integer
        Get
            Return mParentID
        End Get
        Set(ByVal Value As Integer)
            mParentID = Value
        End Set
    End Property

#End Region

#Region "Constructor"

    Public Sub New()

        MyBase.New()

    End Sub

#End Region

#Region "Methods"

    Public Sub GetContainer()

        Dim objRdr As SqlDataReader

        objRdr = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spKWGetContainer")

        With objRdr
            While .Read
                ContainerID = CheckNullNum(.GetSqlInt32(0))
                Container = CheckNullString(.GetSqlString(1))
            End While
        End With

    End Sub

    Private Function FillParams() As SqlParameter()

        Dim objParams() As SqlParameter = {New SqlParameter("@ContainerID", ContainerID), _
            New SqlParameter("@Container", Container)}

        Return objParams

    End Function

    Public Sub SaveContainer()

        If ContainerID > 0 Then
            SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
                "spKWSaveContainer", FillParams())
        Else
            ContainerID = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
                "spKWSaveContainer", FillParams())
        End If

    End Sub

    Public Sub DeleteContainer()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spKWDeleteContainer", New SqlParameter("@ContainerID", ContainerID))

    End Sub

    Public Sub GetContainers(ByVal intTemplateID As Integer)

        Containers = SqlHelper.ExecuteDataset(strConn, CommandType.Text, _
            "EXEC spKWGetContainers;EXEC spKWGetElements;" & _
            "EXEC spKWGetTemplateContainers " & intTemplateID & ";")

    End Sub

#End Region

End Class

Public Class CContainerElement

#Region "Members"

    Private mContainerElementID As Integer
    Private mTemplateContainerID As Integer
    Private mElementID As Integer
    Private mElementOrder As Integer

#End Region

#Region "Constructor"

    Public Sub New()

        MyBase.new()

    End Sub

#End Region

#Region "Properties"

    Public Property ContainerElementID() As Integer
        Get
            Return mContainerElementID
        End Get
        Set(ByVal Value As Integer)
            mContainerElementID = Value
        End Set
    End Property
    Public Property TemplateContainerID() As Integer
        Get
            Return mTemplateContainerID
        End Get
        Set(ByVal Value As Integer)
            mTemplateContainerID = Value
        End Set
    End Property
    Public Property ElementID() As Integer
        Get
            Return mElementID
        End Get
        Set(ByVal Value As Integer)
            mElementID = Value
        End Set
    End Property
    Public Property ElementOrder() As Integer
        Get
            Return mElementOrder
        End Get
        Set(ByVal Value As Integer)
            mElementOrder = Value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub InsertContainerElement()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spKWSaveContainerElement", New SqlParameter("@TemplateContainerID", TemplateContainerID), _
            New SqlParameter("@ElementID", ElementID), _
            New SqlParameter("@ElementOrder", ElementOrder))

    End Sub

    Public Sub DeleteContainerElement()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spKWDeleteContainerElement", New SqlParameter("@ContainerElementID", ContainerElementID))

    End Sub

#End Region

End Class

Public Class CContainerContent

#Region "Members"

    Private mElementID As Integer
    Private mContent As String
    Private mPages As DataSet
    Private mLanguageID As Integer

#End Region

#Region "Constructor"

    Public Sub New()

        MyBase.new()

    End Sub

#End Region

#Region "Properties"
    Public Property ElementID() As Integer
        Get
            Return mElementID
        End Get
        Set(ByVal Value As Integer)
            mElementID = Value
        End Set
    End Property

    Public Property Content() As String
        Get
            Return mContent
        End Get
        Set(ByVal Value As String)
            mContent = Value
        End Set
    End Property

    Public Property Pages() As DataSet
        Get
            Return mPages
        End Get
        Set(ByVal Value As DataSet)
            mPages = Value
        End Set
    End Property

    Public Property LanguageID() As Integer
        Get
            Return mLanguageID
        End Get
        Set(ByVal Value As Integer)
            mLanguageID = Value
        End Set
    End Property
#End Region

#Region "Methods"

    Public Sub GetContent()

        Dim objRdr As SqlDataReader

        objRdr = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spKWGetContainer")

        With objRdr
            While .Read
                Content = CheckNullString(.GetSqlString(1))
            End While
        End With

    End Sub

    Private Function FillParams() As SqlParameter()

        Dim objParams() As SqlParameter = {New SqlParameter("@ElementID", ElementID), _
            New SqlParameter("@Content", Content)}

        Return objParams

    End Function

    Public Sub SaveContent()

        If ElementID > 0 Then
            SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
                "spKWSaveContainerContent", FillParams())
        Else
            ElementID = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
                "spKWSaveContainerContent", FillParams())
        End If

    End Sub

    Public Sub DeleteContent()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spKWDeleteContent", New SqlParameter("@ElementID", ElementID))

    End Sub

    Public Sub GetPages()

        Pages = SqlHelper.ExecuteDataset(strConn, CommandType.Text, _
             "EXEC spKWListPages;EXEC spKWGetElements;")

    End Sub
#End Region

End Class
