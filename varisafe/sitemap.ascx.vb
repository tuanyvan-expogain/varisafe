imports System.text

Public MustInherit Class sitemap
    Inherits ControlTemplate
    Protected WithEvents ltlContent As System.Web.UI.WebControls.Literal
    dim strMap as New StringBuilder()

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
        GetSitemap()
    End Sub

    Private Sub GetSitemap()

        Try
            Dim objPage As New BusinessRules.CPage
            Dim row As DataRow
            Dim childRow As DataRow

            With objPage
                .GetSitemap()

                'Build page relations
                .ComboList.Relations.Add("PageTree", _
                    .ComboList.Tables("pages").Columns("pageID"), _
                    .ComboList.Tables("pages").Columns("parentID"), False)
                .ComboList.Relations.Add("PageLinks", _
                    .ComboList.Tables("pages").Columns("pageID"), _
                    .ComboList.Tables("linkNames").Columns("pageID"), False)
                .ComboList.Relations("PageLinks").Nested = True

                'Open list
                strMap.Append("<ul>" & vbCrLf)

                For Each row In .ComboList.Tables(0).Rows
                    If CInt(row.Item(2)) = 0 And row.Item(5) = True Then
                        'Write link
                        writeAnchor(row)

                        'check for link name relations
                        'If row.GetChildRows("PageLinks").GetUpperBound(0) > 0 Then
                        If Not IsNothing(row.GetChildRows("PageLinks")) Then
                            For Each childRow In row.GetChildRows("PageLinks")
                                writeLinkName(childRow)
                            Next
                        End If

                        'Check for child nodes
                        AddChildNode(row)
                    End If
                Next

                'Begin Mod May 30
                'Add hard-coded links for the pages that are actual .aspx files
                'strMap.Append(vbCrLf & vbTab & "<li><a href=""basic_search.aspx"">Basic Search</a></li>")
                'strMap.Append(vbCrLf & vbTab & "<li><a href=""register1.aspx"">Register</a></li>")
                'strMap.Append(vbCrLf & vbTab & "<li><a href=""tutorial.aspx"">Tutorial</a></li>")
                'End Mod

                'Close list
                strMap.Append("</ul>")
                .ComboList.Dispose()
            End With

            ltlContent.Text = strMap.ToString
        Catch objError As Exception
            BusinessRules.CEmail.SendErrorMessage(objError, Request.Form.ToString(), Request.QueryString.ToString())
            Response.Redirect("/error.aspx", False)

        End Try
    End Sub

    Sub writeAnchor(ByVal row As DataRow)

        strMap.Append(vbCrLf & vbTab & "<li><a href=""" & row.Item("pagename") & ".aspx"">")

    End Sub

    Sub writeLinkName(ByVal row As DataRow)

        if cint(row.Item(1)) = GetLanguageID() then
            strMap.Append(row.Item(2).ToString & "</a>")
        end if

    End Sub

    Sub AddChildNode(ByVal row As DataRow)

        Dim childRow As DataRow
        Dim childRow1 As DataRow

        ' If row.GetChildRows("PageTree").GetUpperBound(0) > 0 Then

        If Not IsNothing(row.GetChildRows("PageTree")) Then

            If row.GetChildRows("PageTree").Length > 0 Then
                'Record has children, so open a new unordered list
                strMap.Append(vbCrLf & vbTab & vbTab & "<ul class=""level2"">" & vbCrLf & vbTab & vbTab & vbTab)


                For Each childRow In row.GetChildRows("PageTree")

                    'check for link name relations
                    'If childRow.GetChildRows("PageLinks").GetUpperBound(0) > 0 Then
                    If Not IsNothing(childRow.GetChildRows("PageLinks")) Then
                        writeAnchor(childRow)

                        For Each childRow1 In childRow.GetChildRows("PageLinks")
                            writeLinkName(childRow1)
                        Next

                    End If
                    'AddChildNode(childRow, Level + 1)
                    strMap.Append(vbCrLf & vbTab & "</li>")
                Next

                'Close sub-list
                strMap.Append(vbCrLf & vbTab & vbTab & "</ul>")

            End If

        End If


    End Sub

End Class
