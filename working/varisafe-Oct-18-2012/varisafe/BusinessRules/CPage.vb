Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Text
Imports System.data

Public Class CPage

#Region "Members"

    Private mPageID As Integer
    Private mPageName As String
    Private mPageTitle As String
    Private mPageElements As New ArrayList()
    Private mParentID As Integer
    Private mInSitemap As Boolean
    Private mURL As String
    Private mTemplateID As String
    Private mPages As SqlDataReader
    Private mComboList As DataSet
    Private mPageLanguages As New DataTable()
    Private mImageFile As String
    Private mInMainNav As Boolean
    Private mNavorder As Integer = 999
#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()
    End Sub

#End Region

#Region "Methods"

    Public Sub GetSiteStructure()

        Dim strSQL As String
        Dim aPages(1) As String
        ComboList = New DataSet()
        aPages(0) = "pages"
        aPages(1) = "LinkNames"

        strSQL = "EXEC spKWGetPages NULL;EXEC spKWGetLinkNames;"

        SqlHelper.FillDataset(strConn, CommandType.Text, strSQL, combolist, aPages)

    End Sub

    Public Sub GetPage(ByVal intContainerID As Integer)

        'Go to database and get page info and all related elements and their content
        Dim strConn As String = CDataAccess.GetConnString
        Dim strSQL As String
        Dim objRdr As SqlDataReader
        Dim objPE As CPageElement

        'Retrieve page data from db
        strSQL = "EXEC spKWGetPage3 " & PageID & ";" & _
            "EXEC spGetKWPageElements1 " & PageID & ";" '& "," & intContainerID & ";"
        objRdr = SqlHelper.ExecuteReader(strConn, CommandType.Text, strSQL)

        With objRdr
            'Set Page Title property
            While .Read
                PageTitle = CheckNullString(objRdr.GetSqlString(0))
            End While

            'Populate page element array
            .NextResult()
            While .Read
                'Create new page element object and fill its properties
                objPE = New CPageElement()
                objPE.PageElementID = CheckNullNum(.GetSqlInt32(0))
                objPE.ElementID = CheckNullNum(.GetSqlInt32(1))
                objPE.Element = CheckNullString(.GetSqlString(2))
                objPE.ContainerID = CheckNullNum(.GetSqlInt32(3))
                objPE.Container = CheckNullString(.GetSqlString(4))
                objPE.Contents = CheckNullString(.GetSqlString(5))
                objPE.LanguageID = CheckNullNum(.GetSqlInt32(6))

                'Add current element to array of page elements
                mPageElements.Add(objPE)
            End While

            objPE = Nothing
        End With

    End Sub

    Public Sub GetPageContent()

        Pages = SqlHelper.ExecuteReader("spKWGetPageContent", CommandType.StoredProcedure, _
            New SqlParameter("@PageID", PageID))

        With Pages
            While .Read
                PageTitle = CheckNullString(.GetSqlString(0))
                ParentID = CheckNullNum(.GetSqlInt32(1))

            End While
        End With
    End Sub

    Public Sub GetPageList()

        Pages = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spKWGetPages", _
            New SqlParameter("@siteID", siteID))

    End Sub

    Public Sub LoadPage()

        'Fills Parent & Template Combos
        'Also gets current page properties if any
        'Dim strSQL As String = "EXEC spGetPages NULL," & siteID & ";EXEC spGetTemplates " & siteID & ";EXEC spGetLanguages;"
        Dim strSQL As String = "EXEC spKWGetPages NULL;EXEC spKWGetTemplates;EXEC spKWGetLanguages;"

        If PageID > 0 Then
            strSQL += "EXEC spKWGetPage " & PageID & ";EXEC spKWGetPageLanguages " & PageID
        End If

        PageName = strSQL.ToString
        ComboList = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSQL)

        'Populate class properties if retrieving an existing page
        If PageID > 0 Then
            With ComboList.Tables(3).Rows(0)
                PageName = .Item(0).ToString
                ParentID = CheckNullNum(.Item(1))
                InSitemap = .Item(2)
                TemplateID = CheckNullNum(.Item(3))
                inMainNav = .Item(4)

                If Not IsDBNull(.Item(5)) Then
                    NavOrder = CInt(.Item(5))
                End If
            End With
        End If

    End Sub

    Public Sub SavePage()

        PageID = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, "spKWSavePage", _
            New SqlParameter("@pageID", PageID), _
            New SqlParameter("@pageName", PageName), _
            New SqlParameter("@parentID", ParentID), _
            New SqlParameter("@inSitemap", InSitemap), _
            New SqlParameter("@TemplateID", TemplateID), _
            New SqlParameter("@inMainNav", inMainNav), _
            New SqlParameter("@NavOrder", NavOrder))

        SavePageLanguages()

    End Sub

    Public Sub SavePageLanguages()

        Dim strSQL As New StringBuilder()
        'Dim myEnumerator As IDictionaryEnumerator = PageLanguages.GetEnumerator()
        Dim i As Integer

        For i = 0 To PageLanguages.Rows.Count - 1
            strSQL.Append("EXEC spKWSavePageLanguage " & PageID & "," & _
               PageLanguages.Rows(i).Item(0) & "," & PageLanguages.Rows(i).Item(1) & ";")
        Next

        SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSQL.ToString)

    End Sub

    Public Sub SavePageLanguagesText()

        Dim strSQL As New StringBuilder()
        Dim i As Integer

        For i = 0 To PageLanguages.Rows.Count - 1
            strSQL.Append("EXEC spKWSavePageLanguageText " & PageID & "," & _
               PageLanguages.Rows(i).Item(0) & ",'" & _
               Replace(PageLanguages.Rows(i).Item(1), "'", "''") & "','" & _
               Replace(PageLanguages.Rows(i).Item(2), "'", "''") & "','" & _
               Replace(PageLanguages.Rows(i).Item(3), "'", "''") & "','" & _
               Replace(PageLanguages.Rows(i).Item(4), "'", "''") & "';")
        Next

        URL = strSQL.ToString
        SqlHelper.ExecuteNonQuery(strConn, CommandType.Text, strSQL.ToString)

    End Sub

    Public Sub GetSitemap()

        Dim strSQL As String
        Dim aPages(1) As String
        ComboList = New DataSet()
        aPages(0) = "pages"
        aPages(1) = "LinkNames"

        strSQL = "EXEC spKWGetPages 1; EXEC spKWGetLinkNames;"

        SqlHelper.FillDataset(strConn, CommandType.Text, strSQL, combolist, aPages)

    End Sub

    Public Sub GetMainNav()

        Dim strSQL As String
        Dim aPages(1) As String
        ComboList = New DataSet()
        aPages(0) = "pages"
        aPages(1) = "LinkNames"

        strSQL = "EXEC spKWGetMainNav;EXEC spKWGetLinkNames;"

        SqlHelper.FillDataset(strConn, CommandType.Text, strSQL, ComboList, aPages)

    End Sub

    Public Sub DeletePage()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, _
            "spKWDeletePage", New SqlParameter("@pageID", PageID))

    End Sub

    Public Sub GetImage()

        imageFile = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spKWGetPageImage", New SqlParameter("@pageID", PageID)).ToString

    End Sub

#End Region

#Region "Properties"

    Public Property PageID() As Integer
        Get
            Return mPageID
        End Get
        Set(ByVal Value As Integer)
            mPageID = Value
        End Set
    End Property
    Public Property PageName() As String
        Get
            Return mPageName
        End Get
        Set(ByVal Value As String)
            mPageName = Value
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
    Public Property PageElements() As ArrayList
        Get
            Return mPageElements
        End Get
        Set(ByVal Value As ArrayList)
            mPageElements = Value
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
    Public Property InSitemap() As Boolean
        Get
            Return mInSitemap
        End Get
        Set(ByVal Value As Boolean)
            mInSitemap = Value
        End Set
    End Property
    Public Property URL() As String
        Get
            Return mURL
        End Get
        Set(ByVal Value As String)
            mURL = Value
        End Set
    End Property
    Public Property TemplateID() As Integer
        Get
            Return mTemplateID
        End Get
        Set(ByVal Value As Integer)
            mTemplateID = Value
        End Set
    End Property
    Public Property Pages() As SqlDataReader
        Get
            Return mPages
        End Get
        Set(ByVal Value As SqlDataReader)
            mPages = Value
        End Set
    End Property
    Public Property ComboList() As DataSet
        Get
            Return mComboList
        End Get
        Set(ByVal Value As DataSet)
            mComboList = Value
        End Set
    End Property
    Public Property PageLanguages() As DataTable
        Get
            Return mPageLanguages
        End Get
        Set(ByVal Value As DataTable)
            mPageLanguages = Value
        End Set
    End Property
    Public Property imageFile() As String
        Get
            Return mImageFile
        End Get
        Set(ByVal Value As String)
            mImageFile = Value
        End Set
    End Property
    Public Property inMainNav() As Boolean
        Get
            Return mInMainNav
        End Get
        Set(ByVal Value As Boolean)
            mInMainNav = Value
        End Set
    End Property
    Public Property NavOrder() As Integer
        Get
            Return mNavorder
        End Get
        Set(ByVal value As Integer)
            mNavorder = value
        End Set
    End Property

#End Region

End Class
