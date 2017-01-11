Imports System.Data.SqlClient
Imports System.data

Public Class CPageElement

#Region "Members"

    Private mPageElementID As Integer
    Private mPageID As Integer
    Private mElementID As Integer
    Private mContainerID As Integer
    Private mContents As String
    Private mElementOrder As Integer
    Private mElement As String
    Private mPageTitle As String
    Private mContainer As String
    Private mLanguageID As Integer
    Private mCurrLanguage As String
    Private mPageStructure As DataSet
    Private mContent As SqlDataReader
    Private mDescription As String
    Private mKeywords As String

#End Region

#Region "Constructor"

    Public Sub New()

        MyBase.new()

    End Sub

#End Region

#Region "Methods"

    Public Sub GetPageStructure()

        'Dim objRdr As SqlDataReader

        Dim strSQL As String

        If IsDBNull(PageID) Or PageID = 1 Then
            PageID = 33
        End If
        strSQL = "EXEC spKWGetPageStructure " & PageID & ";EXEC spKWGetPageElements " & PageID & ";" & _
            "EXEC spKWGetPageTitle " & LanguageID & "," & PageID & ";"

        PageStructure = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSQL)

        'PageTitle = strSQL
        PageTitle = PageStructure.Tables(2).Rows(0).Item("PageTitle").ToString
        Description = PageStructure.Tables(2).Rows(0).Item("Description").ToString
        Keywords = PageStructure.Tables(2).Rows(0).Item("Keywords").ToString

    End Sub

    Public Sub GetHTMLElements()

        PageStructure = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, _
            "spKWGetHTMLContentElements")

    End Sub

    Public Sub EditHTMLContent()

        Contents = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spKWEditHTMLContent", New SqlParameter("@ElementContentID", PageElementID))

    End Sub

    Public Sub UpdateHTMLContent()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spKWSaveHTMLContent", New SqlParameter("@ElementContentID", PageElementID), _
            New SqlParameter("@content", Contents))

    End Sub

    Public Sub InsertHTMLContent()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spKWSaveHTMLContent", New SqlParameter("@ElementID", ElementID), _
            New SqlParameter("@PageLanguageID", LanguageID), _
            New SqlParameter("@content", Contents))

    End Sub

    Public Sub GetHTMLContent()

        'Contents = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
        '  "spGetHTMLContent", New SqlParameter("@ElementContentID", PageElementID))

        Content = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, _
            "spKWGetHTMLContent", New SqlParameter("@PageID", PageID), New SqlParameter("@ContainerID", ContainerID), New SqlParameter("@CurrLanguage", CurrLanguage))

    End Sub

#End Region

#Region "Properties"

    Public Property PageElementID() As Integer
        Get
            Return mPageElementID
        End Get
        Set(ByVal Value As Integer)
            mPageElementID = Value
        End Set
    End Property
    Public Property PageID() As Integer
        Get
            Return mPageID
        End Get
        Set(ByVal Value As Integer)
            mPageID = Value
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
    Public Property ContainerID() As Integer
        Get
            Return mContainerID
        End Get
        Set(ByVal Value As Integer)
            mContainerID = Value
        End Set
    End Property
    Public Property Contents() As String
        Get
            Return mContents
        End Get
        Set(ByVal Value As String)
            mContents = Value
        End Set
    End Property
     Public Property PageTitle() As String
        Get
            Return mPageTitle
        End Get
        Set(ByVal Value As String)
            mPageTitle = Value
        End Set
    End Property
    Public Property Content() As SqlDataReader
        Get
            Return mContent
        End Get
        Set(ByVal Value As SqlDataReader)
            mContent = Value
        End Set
    End Property
    Public Property Element() As String
        Get
            Return mElement
        End Get
        Set(ByVal Value As String)
            mElement = Value
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
    Public Property Container() As String
        Get
            Return mContainer
        End Get
        Set(ByVal Value As String)
            mContainer = Value
        End Set
    End Property
    Public Property CurrLanguage() As String
        Get
            Return mCurrLanguage
        End Get
        Set(ByVal Value As String)
            mCurrLanguage = Value
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
    Public Property PageStructure() As DataSet
        Get
            Return mPageStructure
        End Get
        Set(ByVal Value As DataSet)
            mPageStructure = Value
        End Set
    End Property
    Public Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal Value As String)
            mDescription = Value
        End Set
    End Property
    Public Property Keywords() As String
        Get
            Return mKeywords
        End Get
        Set(ByVal Value As String)
            mKeywords = Value
        End Set
    End Property
#End Region

End Class
