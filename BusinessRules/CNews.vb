Imports System.Data.SqlClient
Imports System.Text
Imports System.data

Public Class CNews

#Region "Members"

    Private mnewsID As Integer
    Private mtitle As String
    Private mbody As String
    Private mactive As Boolean
    Private mdateentered As Date
    Private mshortdescription As String
    Private mnewstype As String
    Private mnewstypeID As Integer
    Private mNewsItems As SqlDataReader
    Private mhomepage As Boolean
    Private mCulture As String
    Private mNews As New DataSet
    Private mDateString As String

#End Region

#Region "Properties"

    Public Property News() as DataSet
        get
            Return mNews
        End Get
        Set(ByVal value as DataSet)
            mNews = value
        End Set
    End Property
    Public Property newsID() As Integer
        Get
            Return mnewsID
        End Get
        Set(ByVal Value As Integer)
            mnewsID = Value
        End Set
    End Property
    Public Property title() As String
        Get
            Return mtitle
        End Get
        Set(ByVal Value As String)
            mtitle = Value
        End Set
    End Property
    Public Property body() As String
        Get
            Return mbody
        End Get
        Set(ByVal Value As String)
            mbody = Value
        End Set
    End Property
    Public Property active() As Boolean
        Get
            Return mactive
        End Get
        Set(ByVal Value As Boolean)
            mactive = Value
        End Set
    End Property
    Public Property dateentered() As Date

        Get
            Return mdateentered
        End Get
        Set(ByVal Value As Date)
            mdateentered = Value
        End Set
    End Property
    Public Property shortdescription() As String
        Get
            Return mshortdescription
        End Get
        Set(ByVal Value As String)
            mshortdescription = Value
        End Set
    End Property
    Public Property NewsItems() As SqlDataReader
        Get
            Return mNewsItems
        End Get
        Set(ByVal Value As SqlDataReader)
            mNewsItems = Value
        End Set
    End Property
    Public Property newstypeID() As Integer
        Get
            Return mnewstypeID
        End Get
        Set(ByVal Value As Integer)
            mnewstypeID = Value
        End Set
    End Property
    Public Property homepage() As Boolean
        Get
            Return mhomepage
        End Get
        Set(ByVal Value As Boolean)
            mhomepage = Value
        End Set
    End Property
    Public Property Culture() As String
        Get
            Return mCulture
        End Get
        Set(ByVal Value As String)
            mCulture = Value
        End Set
    End Property
    Public Property DateString() As String
        Get
            Return mDateString
        End Get
        Set(ByVal Value As String)
            mDateString = Value
        End Set
    End Property
#End Region

#Region "Constructor"

    Public Sub New()

        MyBase.New()

    End Sub

    Public Sub New(ByVal intnewsID As Integer)

        MyBase.New()
        newsID = intnewsID

    End Sub

#End Region

#Region "Methods"

    Public Sub ShowNews()

        News = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, _
            "spKWGetNews", New SqlParameter("@culture", Culture))

    End Sub

    Public Sub ShowFeaturedNews()

        NewsItems = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, _
            "spKWGetFeaturedNews", New SqlParameter("@culture", Culture))

    End Sub

    Public Sub GetNews()

        NewsItems = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spKWGetNews")

    End Sub

    Public Sub GetEnglishNews()

        NewsItems = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spKWGetAllNews", _
            New SqlParameter("@culture", "en-CA"))

    End Sub

    Public Sub EditNewsItem()

        Dim strSQL As New StringBuilder()

        strSQL.Append("EXEC spKWGetNewsTypes;EXEC spKWGetLanguages;")

        If newsID > 0 Then
            strSQL.Append("EXEC spKWGetNews " & newsID & ";")
        End If

        News = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSQL.ToString)

        With News
            If newsID > 0 Then
                With .Tables(2).Rows(0)
                    dateentered = .Item("dateentered").ToString
                    active = .Item("active")
                    newstypeID = CheckNullNum(.Item("newstypeID"))
                    homepage = .Item("homepage")
                End With
            End If
        End With

    End Sub

    Public Sub GetNewsItem()

        NewsItems = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spKWGetNews", _
            New SqlParameter("@newsID", newsID), New SqlParameter("@culture", Culture))

        With NewsItems
            While .Read
                title = CheckNullString(.GetSqlString(1))
                shortdescription = CheckNullString(.GetSqlString(2))
                body = CheckNullString(.GetSqlString(3))
                dateentered = CheckNullDate(.GetSqlDateTime(4))
                active = .GetBoolean(5)
                DateString = CheckNullString(.GetSqlString(11))
            End While
        End With

        NewsItems.Close()

    End Sub

    Public Sub SaveNewsItem()

        Dim strSQL As New Stringbuilder()
        Dim row As DataRow


        newsID = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spKWSaveNews", New SqlParameter("@newsid", newsID), _
            New SqlParameter("@active", active), _
            New SqlParameter("@dateentered", dateentered), _
            New SqlParameter("@newstypeID", 1), _
            New SqlParameter("@homepage", homepage))

        For Each row In News.Tables(0).Rows
            strSQL.Append("EXEC spKWSaveNewsLanguage " & row.Item("NewsLanguageID") & _
                "," & newsID & "," & _
                row.Item("languageID") & ",'" & row.Item("title") & "','" & _
                row.Item("body") & "','" & row.Item("shortdesciption") & "';")
        Next
        ' title = strSQL.ToString

        SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSQL.ToString)
        News.Dispose()

    End Sub

    Public Sub SaveNewsLanguages()

        Dim strSQL As New StringBuilder()
        Dim row As DataRow

        For Each row In News.Tables(0).Rows
            strSQL.Append("EXEC spKWSaveNewsLanguage " & row.Item("NewsLanguageID") & _
                "," & newsID & "," & _
                row.Item("languageID") & ",'" & row.Item("title") & "','" & _
                row.Item("body") & "','" & row.Item("shortdesciption") & "';")
        Next
        title = strSQL.ToString

        SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSQL.ToString)
        News.Dispose()

    End Sub

    Public Sub DeleteNewsItem()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spKWDeleteNews", New SqlParameter("@newsID", newsID))

    End Sub

#End Region

End Class
