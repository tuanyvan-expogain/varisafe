Imports System.Xml
Imports System.Xml.XPath
Imports System.Xml.Xsl
Imports System.Text
Imports System.IO
Imports System.Threading
Imports System.Globalization

Public MustInherit Class mainnav
    Inherits ControlTemplate
    Protected WithEvents ltlNav As System.Web.UI.WebControls.Literal
    Dim strNav As New StringBuilder()
    Dim noLineFlag As Boolean = False
    Dim j As Integer
    Dim objPage As New BusinessRules.CPage()


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
        GetMainNav()
    End Sub


    Private Sub GetMainNav()

        Dim row As DataRow
        Dim childRow As DataRow

        With objPage
            .GetMainNav()

            'Build page relations
            .ComboList.Relations.Add("PageTree", _
                .ComboList.Tables("pages").Columns("pageID"), _
                .ComboList.Tables("pages").Columns("parentID"), False)
            .ComboList.Relations.Add("PageLinks", _
                .ComboList.Tables("pages").Columns("pageID"), _
                .ComboList.Tables("linkNames").Columns("pageID"), False)
            .ComboList.Relations("PageLinks").Nested = True

            'Open list
            strNav.Append(vbCrLf & "<ul id=""nav1"">" & vbCrLf)


            For Each row In .ComboList.Tables(0).Rows
                If CInt(row.Item("parentID")) = 0 Then
                    'Write link
                    writeTopAnchor(row)

                    'check for link name relations

                    ' If row.GetChildRows("PageLinks").GetUpperBound(0) > 0 Then
                    For Each childRow In row.GetChildRows("PageLinks")
                        writeLinkName(childRow)
                    Next
                    'End If

                    'Check for child nodes
                    Dim parentID As Integer

                    'This is only adding child nodes on the current page, we want child nodes every time

                    'Dim dview As New DataView(objPage.ComboList.Tables(0), "pageID=" & PageID, "", DataViewRowState.OriginalRows)

                    'If dview.Count > 0 Then
                    '    parentID = dview.Item(0).Item("parentID")
                    'End If
                    ''Top level link

                    'If row.Item("pageid") = PageID Or row.Item("pageID") = parentID Then
                    '    AddChildNode(row, 1)
                    'End If

                    'END MOD
                    Dim pid As Integer = CInt(row.Item("pageID"))



                    Dim dview As New DataView(objPage.ComboList.Tables(0), "pageID=" & pid, "", DataViewRowState.OriginalRows)

                    If dview.Count > 0 Then
                        parentID = dview.Item(0).Item("parentID")
                    End If
                    'Top level link

                    If row.Item("pageid") = pid Or row.Item("pageID") = parentID Then
                        AddChildNode(row, 1)
                    End If




                    strNav.Append("</li>")
                End If
            Next

            'Close list
            strNav.Append(vbCrLf & "</ul>" & vbCrLf)
            .ComboList.Dispose()
        End With

        ltlNav.Text = strNav.ToString

    End Sub

    Sub writeTopAnchor(ByVal row As DataRow)

        Dim parentID As Integer
        Dim dview As New DataView(objPage.ComboList.Tables(0), "pageID=" & PageID, "", DataViewRowState.OriginalRows)
        If dview.Count > 0 Then
            parentID = dview.Item(0).Item("parentID")
        End If
        'Top level link
        If row.Item("pageid") = PageID Or row.Item("pageID") = parentID Then
            strNav.Append(vbCrLf & vbTab & "<li class=""active""><a href=""" & row.Item("pagename") & ".aspx"">")
            noLineFlag = True
        Else
            If noLineFlag = True Then
                strNav.Append(vbCrLf & vbTab & "<li class=""noline""><a href=""" & row.Item("pagename") & ".aspx"">")
                noLineFlag = False
            Else

                strNav.Append(vbCrLf & vbTab & "<li class=""inactive""><a href=""" & row.Item("pagename") & ".aspx"">")
            End If
        End If

    End Sub

    Sub writeAnchor(ByVal row As DataRow, ByVal Level As Integer)


        'Child link
        Dim x As String = row.Item("pagename").ToString
        strNav.Append("<li><a href=""" & row.Item("pagename") & ".aspx"">")


    End Sub

    Sub writeLinkName(ByVal row As DataRow)

        If CInt(row.Item("languageID")) = GetLanguageID() Then
            strNav.Append(row.Item("linkName").ToString & "</a>")
        End If

    End Sub

    Sub AddChildNode(ByVal row As DataRow, ByVal Level As Integer)

        Dim childRow As DataRow
        Dim childRow1 As DataRow

        ' If row.GetChildRows("PageTree").GetUpperBound(0) > 0 Then

        If Not IsNothing(row.GetChildRows("PageTree")) Then


            If row.GetChildRows("PageTree").Length > 0 Then


                'Record has children, so open a new unordered list
                strNav.Append(vbCrLf & vbTab & vbTab & "<ul id=""nav2"">" & vbCrLf & vbTab & vbTab & vbTab)


                For Each childRow In row.GetChildRows("PageTree")

                    'check for link name relations
                    'If childRow.GetChildRows("PageLinks").GetUpperBound(0) > 0 Then
                    If Not IsNothing(childRow.GetChildRows("PageLinks")) Then
                        writeAnchor(childRow, Level)

                        For Each childRow1 In childRow.GetChildRows("PageLinks")
                            writeLinkName(childRow1)
                        Next

                    End If
                    'AddChildNode(childRow, Level + 1)
                    strNav.Append(vbCrLf & vbTab & "</li>")
                Next

                'Close sub-list
                strNav.Append(vbCrLf & vbTab & vbTab & "</ul>")

            End If

        End If
        'Close this item now that it the link and any-sub links have been written
        'strNav.Append("</li>")

    End Sub


End Class
