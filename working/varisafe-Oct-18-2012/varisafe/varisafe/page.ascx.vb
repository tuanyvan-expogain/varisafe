Imports System.Threading
Public MustInherit Class page1
    'Inherits System.Web.UI.UserControl
    Inherits ControlTemplate
    Dim objPage As New BusinessRules.CPageElement()
    Dim myDRV As DataRowView
    Public mPageTitle As String
    Public mDescription As String
    Public mKeywords As String
    Public mPID As String
    Public mImageFile As String = "roadahead.jpg"


#Region "Properties"

    Public Property PageTitle() As String
        Get
            Return mPageTitle
        End Get
        Set(ByVal Value As String)
            mPageTitle = Value
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
    Public Property imageFile() As String
        Get
            Return mImageFile
        End Get
        Set(ByVal Value As String)
            mImageFile = Value
        End Set
    End Property
    Public Property PID() As Integer
        Get
            Return mPID
        End Get
        Set(ByVal Value As Integer)
            mPID = Value
        End Set
    End Property

#End Region

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    

#End Region

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If IsNumeric(Request.QueryString("pid")) And Request.QueryString("pid") <> "" Then
            PID = Request.QueryString("pid")
        Else
            PID = System.Configuration.ConfigurationManager.AppSettings("defaultPageID")
        End If

        GetPageStructure()
    End Sub



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'If Not IsPostBack Then
        '    GetPageStructure()
        'End If


    End Sub

    Private Function GetContainer(ByVal intTCID As Integer, ByVal ContainerID As Integer, ByVal intRow As Integer) As System.Web.UI.HtmlControls.HtmlGenericControl

        Dim dvSub As DataView
        Dim i As Integer
        Dim RowIndex As Integer

        'Create new div for container
        Controls.Add(New LiteralControl(Chr(13)))

        Dim objdiv As New System.Web.UI.HtmlControls.HtmlGenericControl()
        objdiv.TagName = "div"

        objdiv.ID = objPage.PageStructure.Tables(0).Rows(intRow).Item(1).ToString
        'MOD by alicia for styles
        objdiv.Attributes("class") = objPage.PageStructure.Tables(0).Rows(intRow).Item(1).ToString

        'Get SubContainers
        dvSub = New DataView(objPage.PageStructure.Tables(0), "ParentID=" & ContainerID, "", DataViewRowState.OriginalRows)

        For Each myDRV In dvSub
            'For each sub-container, check if it also has sub-containers
            For i = 0 To objPage.PageStructure.Tables(0).Rows.Count - 1
                If objPage.PageStructure.Tables(0).Rows(i).Item("TemplateContainerID") = myDRV("TemplateContainerID") Then
                    RowIndex = i
                    objdiv.Controls.Add(GetContainer(CInt(myDRV("TemplateContainerID")), CInt(myDRV("ContainerID")), RowIndex))
                    Exit For
                End If
            Next
        Next

        dvSub.Dispose()

        LoadContainerControls(objdiv, intTCID, intRow)

        Return objdiv

    End Function

    Private Sub LoadContainerControls(ByRef objDiv As System.Web.UI.HtmlControls.HtmlGenericControl, ByVal intTCID As Integer, ByVal intRow As Integer)

        Dim dv As New DataView(objPage.PageStructure.Tables(1), "TemplateContainerID=" & objPage.PageStructure.Tables(0).Rows(intRow).Item(2).ToString, "ElementOrder", DataViewRowState.OriginalRows)

        For Each myDRV In dv

            Dim objCtlDiv As New System.Web.UI.HtmlControls.HtmlGenericControl()
            objCtlDiv.TagName = "div"
            objCtlDiv.ID = objPage.PageStructure.Tables(0).Rows(intRow).Item(1).ToString & "_" & myDRV("element")

            'mod by Alicia: Added for styling
            objCtlDiv.Attributes("class") = myDRV("element")

            'MOD by Alicia -- attempting to make the contact form work
            Dim controlName As String = myDRV("element")

            'If controlName = "contactform44" Then
            '    Dim objcontactForm As kw.ContactForm

            '    objcontactForm = CType(LoadControl("/" & myDRV("element") & ".ascx"), kw.ContactForm)
            '    objcontactForm.PageID = objPage.PageID

            '    objcontactForm.ContainerID = CInt(objPage.PageStructure.Tables(0).Rows(intRow).Item(3))
            '    objCtlDiv.Controls.Add(objcontactForm)
            '    objDiv.Controls.Add(objCtlDiv)

            'Else
            Dim objCtl = Page.LoadControl("~/" & myDRV("element") & ".ascx")


            objCtl.PageID = objPage.PageID

            objCtl.ContainerID = CInt(objPage.PageStructure.Tables(0).Rows(intRow).Item(3))
            objCtlDiv.Controls.Add(objCtl)

            objDiv.Controls.Add(objCtlDiv)
            'End If




        Next

    End Sub

    Private Sub GetPageStructure()

        Dim i As Integer


        With objPage


            ' had to change this to set the value to the pid public property of this 
            ' control as I was having issues accessing the querystring values once this
            ' was moved to the init event

            ''If IsNumeric(Request.QueryString("pid")) And Request.QueryString("pid") <> "" Then
            ''    .PageID = Request.QueryString("pid")
            ''    ' PID = Request.QueryString("pID")


            ''Else
            ''    If IsNothing(.PageID) Or .PageID = 0 Then
            ''        .PageID = System.Configuration.ConfigurationManager.AppSettings("defaultPageID")
            ''        '.PageID = 33


            ''    End If
            ''End If

            .PageID = PID

            If IsNothing(.PageID) Or .PageID = 0 Then
                .PageID = System.Configuration.ConfigurationManager.AppSettings("defaultPageID")
            End If

            .LanguageID = GetLanguageID()

            .GetPageStructure()

            'Response.Write(.PageTitle)
            For i = 0 To .PageStructure.Tables(0).Rows.Count - 1

                Dim objdiv As New System.Web.UI.HtmlControls.HtmlGenericControl()

                '***new*** check for sub-containers here
                If .PageStructure.Tables(0).Rows(i).Item("ParentID") = 0 Then
                    objdiv = GetContainer(CInt(.PageStructure.Tables(0).Rows(i).Item(2)), CInt(.PageStructure.Tables(0).Rows(i).Item(3)), i)
                    Controls.Add(objdiv)
                End If
                '***

                PageTitle = .PageTitle
                Description = .Description
                Keywords = .Keywords



            Next

            .PageStructure.Dispose()

        End With

    End Sub

End Class
