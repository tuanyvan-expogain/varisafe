Imports System.Data.SqlClient
Imports System.Text
Imports System.data

Public Class CNewsletter

#Region "Members"

    Private mnewsletterID As Integer
    Private mtitle As String
    Private mfilename As String
    Private mactive As Boolean
    Private mmessage as String
    Private mdateentered As Date
    Private mNewsletters As New Dataset
    Private mNewsletter As SqlDataReader
    Private mautosend As Boolean
    Private mCulture As String

#End Region

#Region "Properties"

    Public Property Newsletters() as DataSet
        get
            Return mNewsletters
        End Get
        Set(ByVal value as DataSet)
            mNewsletters = value
        End Set
    End Property    
     Public Property Newsletter() as SqlDataReader
        get
            Return mNewsletter
        End Get
        Set(ByVal value as SqlDataReader)
            mNewsletter = value
        End Set
    End Property    
    Public Property newsletterID() As Integer
        Get
            Return mnewsletterID
        End Get
        Set(ByVal Value As Integer)
            mnewsletterID = Value
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
    Public Property filename() As String
        Get
            Return mfilename
        End Get
        Set(ByVal Value As String)
            mfilename = Value
        End Set
    End Property
     Public Property message() As String
        Get
            Return mmessage
        End Get
        Set(ByVal Value As String)
            mmessage = Value
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
   
    Public Property autosend() As Boolean
        Get
            Return mautosend
        End Get
        Set(ByVal Value As Boolean)
            mautosend = Value
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
#End Region

#Region "Constructor"

    Public Sub New()

        MyBase.New()

    End Sub

    Public Sub New(ByVal intnewsletterID As Integer)

        MyBase.New()
        newsletterID = intnewsletterID

    End Sub

#End Region

#Region "Methods"
    
    Public Sub ShowNews()

        Newsletters = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, _
            "spGetNewsLetters", New SqlParameter("@culture", Culture))

    End Sub
 
    Public Sub GetEnglishNewsletters()

        Newsletter = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spGetNewsletters")

    End Sub

  Public Sub GetNewsletters()

        Newsletter = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spGetNewsletter")

    End Sub

    Public Sub GetNewsletter()

        Newsletters = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, _
            "spGetNewsletter", New SqlParameter("@newsletterID", newsletterID))

    End Sub

    'Public Sub SaveNewsletter()

    '    SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
    '        "spSaveNewsletter", New SqlParameter("@title", title), _
    '        New SqlParameter("@filename", filename), _
    '        New SqlParameter("@active", active), _
    '        New SqlParameter("@dateentered", dateentered), _
    '        New SqlParameter("@newsletterID", newsletterID), _
    '        New SqlParameter("@autosend", autosend))

    'End Sub

      Public Sub SaveNewsletter()

        dim strSQL as new Stringbuilder()
        dim row as DataRow

        NewsletterID = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spSaveNewsletters", New SqlParameter("@newsletterid", newsletterID), _
            New SqlParameter("@active", active), _
            New SqlParameter("@dateentered", dateentered), _
            New SqlParameter("@autosend", autosend))

        for each row in Newsletters.Tables(0).Rows
            strSQL.Append("EXEC spSaveNewsletterLanguage " & row.Item("NewsletterLanguageID") & _
                "," & newsletterID & "," & _
                row.Item("languageID") & ",'" & row.Item("title") & "','" & _
                row.Item("message") & "';") ','" & Row.Item("filename") & "';")
        Next

        SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSQL.ToString)
        Newsletters.Dispose()

    End Sub


    Public Sub DeleteNewsletter()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spDeleteNewsletter", New SqlParameter("@newsletterID", newsletterID))

    End Sub

#End Region

End Class
