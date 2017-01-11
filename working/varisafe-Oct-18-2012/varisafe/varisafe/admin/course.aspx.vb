Imports System.IO

Public Class course
    Inherits System.Web.UI.Page
    Protected WithEvents txtCourseID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtMLS As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkActive As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents chkFeatured As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtPrice As System.Web.UI.WebControls.TextBox

    Protected WithEvents txtMapLink As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtVideo As System.Web.UI.WebControls.TextBox

    Protected WithEvents txtshortdescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents XHTMLEditor1 As XStandard.XHTMLEditor
    Protected WithEvents CompareValidator1 As System.Web.UI.WebControls.CompareValidator
    Protected WithEvents dlImages As DataList
    Protected WithEvents divPhotos As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents DivnoPhotos As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents txtFileName As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents btnUpload As System.Web.UI.WebControls.Button
    Protected WithEvents txtCaption As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkMainImage As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ddlCity As System.Web.UI.WebControls.DropDownList
    Protected dTable As DataTable
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents chkSold As System.Web.UI.WebControls.CheckBox

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

        If IsPostBack = False Then
            FillCombos()

            If Not IsNothing(Request.QueryString("cid")) Then
                GetCourse()
            End If
        End If
    End Sub

    Private Sub FillCombos()

        Dim objCourse As New BusinessRules.CCourse

        With objCourse
            .GetCoursesAndCities()
            'ddlCourse.DataSource = .CourseDS.Tables(0)
            'ddlCourse.DataBind()
            'ddlCourse.Items.Insert(0, "-Any-")

            ddlCity.DataSource = .CourseDS.Tables(1)
            ddlCity.DataBind()
            ddlCity.Items.Insert(0, "-Select-")

            .CourseDS.Dispose()
        End With

    End Sub

    Private Sub GetCourse()

        Try
            Dim objList As New BusinessRules.CCourse()

            With objList
                If IsNumeric(Request.QueryString("cid")) Then
                    .CourseID = CInt(Request.QueryString("cid"))
                    txtCourseID.Text = .CourseID.ToString
                ElseIf txtCourseID.Text <> "" And txtCourseID.Text <> "0" Then
                    .CourseID = CInt(txtCourseID.Text)
                Else
                    divPhotos.Visible = False
                    DivnoPhotos.Visible = False
                End If

                .GetCourse()

                If .CourseID > 0 Then
                    '    txtAddress.Text = .Address
                    '    txtPrice.Text = FormatCurrency(.Price, 0)
                    '    txtMLS.Text = .MLS


                    '    chkActive.Checked = .Active
                    '    chkFeatured.Checked = .Featured
                    '    chkSold.Checked = .Sold
                    '    txtMapLink.Text = .MapLink
                    '    txtVideo.Text = .VideoLink
                    '    XHTMLEditor1.Value = .Description
                    '    'dTable = .Course.Tables(2)

                    '    dlImages.DataSource = .Courses
                    '    dlImages.DataBind()
                    '    .Courses.Close()
                End If

            End With
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Dim objList As New BusinessRules.CCourse()

            With objList
                If txtCourseID.Text <> "" Then
                    .CourseID = CInt(txtCourseID.Text)
                Else
                    .CourseID = 0
                End If

                '.Address = txtAddress.Text
                '.Price = Replace(Replace(txtPrice.Text, "$", ""), ".00", "")
                '.MLS = txtMLS.Text
                '.Active = chkActive.Checked
                '.Featured = chkFeatured.Checked

                '.Description = stripXML(XHTMLEditor1.Value)
                '.Rental = False
                '.Sold = chkSold.Checked
                '.MapLink = txtMapLink.Text
                '.VideoLink = txtVideo.Text

                'txtCourseID.Text = .SaveCourse().ToString
            End With

            'Response.Redirect("Course.aspx", False)
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub

    Protected Sub dlImages_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlImages.CancelCommand

        Try
            dlImages.EditItemIndex = -1
            GetCourse()
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub


    Protected Sub dlImages_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlImages.DeleteCommand

        Try
            '1. delete image from server
            Dim strFN As String = CType(e.Item.FindControl("lblfilename"), Label).Text
            ' Response.Write("StrFN " & strFN)

            File.Delete(Server.MapPath("\") & "\" & strFN)


            ''2. delete thumbnail from server
            'Dim strTFN As String = Replace(strFN, ".jp", "_tb.jp")
            'strTFN = Replace(strTFN, ".JP", "_tb.JP")

            '' Response.Write("<br> StrTFN: " & strTFN)


            'File.Delete(Server.MapPath("\images\bioimages") & "\" & strTFN)

            '3. delete database record
            ' BusinessRules.CCourse.DeleteCourseImage(CInt(dlImages.DataKeys.Item(e.Item.ItemIndex)))

            'refresh page
            GetCourse()
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub

    Protected Sub dlImages_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlImages.EditCommand

        dlImages.EditItemIndex = e.Item.ItemIndex

        'If CType(e.Item.FindControl("lblMain"), Label).Text = "True" Then
        '    CType(e.Item.FindControl("chkMain"), CheckBox).Checked = True
        'End If
        GetCourse()

    End Sub

    Private Sub dlImages_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlImages.ItemDataBound

        Try
            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

                Dim deleteButton As LinkButton = CType(e.Item.FindControl("btnDelete"), LinkButton)
                deleteButton.Attributes("onclick") = "javascript:return " & _
                     "confirm('Are you sure you want to delete this image?')"

            End If
        Catch objError As Exception

            lblError.Text = objError.Message
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        End Try

    End Sub

    Protected Sub dlImages_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlImages.UpdateCommand

        Dim iid As Integer = CInt(dlImages.DataKeys.Item(e.Item.ItemIndex))
        Dim ImageOrder As Integer = CheckNullNum(CType(e.Item.FindControl("txtImageOrder"), TextBox).Text)
        Dim bolMain As Boolean = CType(e.Item.FindControl("chkMain"), System.Web.UI.WebControls.CheckBox).Checked
        Dim Caption As String = CType(e.Item.FindControl("txtCaption"), TextBox).Text

        ' BusinessRules.CCourse.UpdateImage(iid, ImageOrder, bolMain, Caption)

        'refresh page
        dlImages.EditItemIndex = -1
        GetCourse()

    End Sub

    Private Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click

        'Try
        '    If Not txtFileName.PostedFile Is Nothing And txtFileName.PostedFile.ContentLength > 0 Then
        '        Dim fn As String = Replace(Replace(Replace(System.IO.Path.GetFileName(txtFileName.PostedFile.FileName), "'", ""), "_", ""), " ", "-")
        '        Dim SaveLocation As String = Server.MapPath("\images\Courses") & "\" & fn


        '        If (UCase(Right(fn, 4)) = ".JPG" Or UCase(Right(fn, 5)) = ".JPEG") And (txtFileName.PostedFile.ContentType = "image/pjpeg" Or txtFileName.PostedFile.ContentType = "image/jpeg") Then

        '            'Try
        '            'Response.Write(SaveLocation)

        '            'If File.Exists(SaveLocation) Then
        '            '    SaveLocation = Server.MapPath("\images\Courses") & "\" & Session.SessionID & "_" & ltlBiometricsID.Text & "_" & fn
        '            'End If

        '            txtFileName.PostedFile.SaveAs(SaveLocation)

        '            Dim objJpeg = New ASPJPEGLib.ASPJpeg()

        '            With objJpeg
        '                .Open(SaveLocation)
        '                If (.Width > .Height) And (.width > 512) Then
        '                    .width = 512
        '                    .Height = objJpeg.OriginalHeight * objJpeg.Width / objJpeg.OriginalWidth
        '                Else
        '                    If .height > 400 Then
        '                        .height = 400
        '                        .width = objJpeg.originalWidth * objJpeg.Height / objJpeg.OriginalHeight
        '                    End If

        '                End If
        '                .Save(SaveLocation)
        '                .Close()
        '            End With

        '            BusinessRules.CCourse.SaveImage(CInt(txtCourseID.Text), fn, txtCaption.Text, chkMainImage.Checked)

        '            GetCourse()

        '            txtCaption.Text = ""
        '            chkMainImage.Checked = False
        '            'Catch objError As Exception
        '            'lblError.Text = "The following error occurred: " & objError.Message & _
        '            '    ".  Please try re-loading the page, or contact technical support with a description of this problem."

        '            ''Notify tech support
        '            'Dim objErr As New CEmail()
        '            'objErr.SendErrorMessage(objError, Request.Form.ToString(), Request.QueryString.ToString(), Session("CompanyID"), Session("StoreID"))
        '            'objErr = Nothing
        '            'End Try
        '        Else
        '            'lblError.Text = "Please select a image file to upload."
        '        End If
        '    Else
        '        'lblError.Text = "Please select an image file to upload."
        '    End If
        'Catch objError As Exception

        '    lblError.Text = objError.Message
        '    BusinessRules.CEmail.SendErrorMessage(objError, Request.Url.ToString(), Request.QueryString.ToString())

        'End Try

    End Sub
End Class
