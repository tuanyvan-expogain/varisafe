Public Class CDataGridToExcel

    Inherits System.ComponentModel.Component

    Public Shared Sub DataGridToExcel(ByVal dgExport As DataGrid, ByVal response As HttpResponse)
        'clean up the response.object
        response.Buffer = True
        response.Clear()
        response.Charset = ""

        ' response.ContentEncoding = Encoding.UTF8


        'try to open new window
        response.AddHeader("Content-Disposition", "attachment; filename=CharityCan_Report.xls")

        'set the response mime type for excel
        ' response.Cache.SetCacheability(HttpCacheability.NoCache)

        response.ContentType = "application/vnd.ms-excel"


        'create a string writer
        Dim stringWrite As New System.IO.StringWriter()

        'create an htmltextwriter which uses the stringwriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)


        'instantiate a datagrid
        Dim dg As New DataGrid()
        ' just set the input datagrid = to the new dg grid
        dg = dgExport

        ' I want to make sure there are no annoying gridlines
        dg.GridLines = GridLines.Both

        ' Make the header text bold
        dg.HeaderStyle.Font.Bold = True

        ' If needed, here's how to change colors/formatting at the component level
        'dg.HeaderStyle.ForeColor = System.Drawing.Color.Black
        'dg.ItemStyle.ForeColor = System.Drawing.Color.Black

        'bind the modified datagrid
        dg.AllowPaging = False
        dg.ShowFooter = False
        dg.DataBind()

        'Remove any button columns
        Dim i As Integer
        Dim strHeader As String

        For i = 0 To dg.Columns.Count - 1
            strHeader = LCase(dg.Columns(i).HeaderText)
            If strHeader = "edit" Or strHeader = "view" Or _
                strHeader = "view/edit" Or strHeader = "delete" Or _
                strHeader = "select" Or strHeader = "update" Or _
                strHeader = "details" Or strHeader = "remove" Or _
                strHeader = "save" Or strHeader = "charity trustee search" Or _
                strHeader = "view donor record source" Or strHeader = "noza donor search" Or _
                strHeader = "political donor search" Or strHeader = "corporate director search" Or _
                strHeader = "bio" Or strHeader = "who's who search" Or strHeader = "zoominfo search" Then
                dg.Columns(i).Visible = False
            End If

        Next

        'tell the datagrid to render itself to our htmltextwriter
        stringWrite.Write("<html><head><meta http-equiv=""content-type"" content=""text/html; charset=utf-8""></head><body>")

        dg.RenderControl(htmlWrite)
        stringWrite.Write("</body></html>")

        'output the html
        response.Write(stringWrite.ToString)
        response.End()

    End Sub


    Public Shared Sub GridViewToExcel(ByVal dgExport As GridView, ByVal response As HttpResponse)
        'clean up the response.object
        response.Buffer = True
        response.Clear()
        response.Charset = ""

        ' response.ContentEncoding = Encoding.UTF8


        'try to open new window
        response.AddHeader("Content-Disposition", "attachment; filename=VariSAFE_Report.xls")

        'set the response mime type for excel
        ' response.Cache.SetCacheability(HttpCacheability.NoCache)

        response.ContentType = "application/vnd.ms-excel"


        'create a string writer
        Dim stringWrite As New System.IO.StringWriter()

        'create an htmltextwriter which uses the stringwriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)


        'instantiate a datagrid
        Dim dg As New GridView
        ' just set the input datagrid = to the new dg grid
        dg = dgExport

        ' I want to make sure there are no annoying gridlines
        dg.GridLines = GridLines.Both

        ' Make the header text bold
        dg.HeaderStyle.Font.Bold = True

        ' If needed, here's how to change colors/formatting at the component level
        'dg.HeaderStyle.ForeColor = System.Drawing.Color.Black
        'dg.ItemStyle.ForeColor = System.Drawing.Color.Black

        'bind the modified datagrid
        dg.AllowPaging = False
        dg.ShowFooter = False
        dg.DataBind()

        'Remove any button columns
        Dim i As Integer
        Dim strHeader As String

        For i = 0 To dg.Columns.Count - 1
            strHeader = LCase(dg.Columns(i).HeaderText)
            If strHeader = "edit" Or strHeader = "view" Or _
                strHeader = "view/edit" Or strHeader = "delete" Or _
                strHeader = "select" Or strHeader = "update" Or _
                strHeader = "details" Or strHeader = "remove" Or _
                strHeader = "save" Or strHeader = "charity trustee search" Or _
                strHeader = "view donor record source" Or strHeader = "noza donor search" Or _
                strHeader = "political donor search" Or strHeader = "corporate director search" Or _
                strHeader = "bio" Or strHeader = "who's who search" Or strHeader = "zoominfo search" Then
                dg.Columns(i).Visible = False
            End If

        Next

        'tell the datagrid to render itself to our htmltextwriter
        stringWrite.Write("<html><head><meta http-equiv=""content-type"" content=""text/html; charset=utf-8""></head><body>")

        dg.RenderControl(htmlWrite)
        stringWrite.Write("</body></html>")

        'output the html
        response.Write(stringWrite.ToString)
        response.End()

    End Sub

    Public Shared Sub DataGridToTxt(ByVal dgExport As DataGrid, ByVal response As HttpResponse)
        'clean up the response.object
        response.Buffer = True
        response.Clear()

        'response.Write(response.ContentEncoding.ToString)





        response.Charset = ""

        'try to open new window

        response.AddHeader("Content-Disposition", "attachment; filename=CharityCan_Report.xls")

        'set the response mime type for excel
        response.ContentType = "application/vnd.ms-excel" '"text/plain" 
        'response.ContentType = "application/text/plain"
        'response.Cache.SetCacheability(HttpCacheability.NoCache)

        'create a string writer
        Dim stringWrite As New System.IO.StringWriter()

        'create an htmltextwriter which uses the stringwriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)

        'instantiate a datagrid
        Dim dg As New DataGrid()
        ' just set the input datagrid = to the new dg grid
        dg = dgExport

        ' I want to make sure there are no annoying gridlines
        dg.GridLines = GridLines.Both

        ' Make the header text bold
        'dg.HeaderStyle.Font.Bold = True

        ' If needed, here's how to change colors/formatting at the component level
        'dg.HeaderStyle.ForeColor = System.Drawing.Color.Black
        'dg.ItemStyle.ForeColor = System.Drawing.Color.Black

        'bind the modified datagrid
        dg.AllowPaging = False
        dg.ShowFooter = False
        dg.DataBind()

        'Remove any button columns
        Dim i As Integer
        Dim strHeader As String

        For i = 0 To dg.Columns.Count - 1
            strHeader = LCase(dg.Columns(i).HeaderText)
            If strHeader = "edit" Or strHeader = "view" Or _
                strHeader = "view/edit" Or strHeader = "delete" Or _
                strHeader = "select" Or strHeader = "update" Or _
                strHeader = "details" Or strHeader = "remove" Then
                dg.Columns(i).Visible = False
            End If

        Next

        For i = 0 To dg.Items.Count - 1
            If dg.Items(i).Cells(0).Text = "" Then
                dg.Items(i).Visible = False
            End If
        Next
        'tell the datagrid to render itself to our htmltextwriter
        dg.RenderControl(htmlWrite)

        Dim strFinal As String
        strFinal = stringWrite.ToString.Substring(131)
        strFinal = strFinal.Replace("<tr>", "")
        'Dim x As String = "<table cellspacing=""0"" rules=""all"" border=""1"" id=""ctl00_MainContentPlaceHolder_dgrdOffordExport"" style=""border-collapse:collapse;"">"
        strFinal = strFinal.Replace("<td>", "")
        strFinal = strFinal.Replace("</td>", vbTab)
        strFinal = strFinal.Replace("</tr>", "")
        strFinal = strFinal.Replace("&nbsp;", "")
        strFinal = strFinal.Replace("</table>", "")

        'output the html
        'response.Write(stringWrite.ToString)
        response.Write(strFinal)
        response.End()

    End Sub

    Public Shared Sub DataGridToTab(ByVal dgExport As DataGrid, ByVal response As HttpResponse)
        'clean up the response.object
        response.Buffer = True
        response.Clear()
        response.Charset = ""

        'try to open new window
        response.AddHeader("Content-Disposition", "attachment; filename=Chantler_Report.txt")

        'set the response mime type for excel
        response.ContentType = "application/vnd.ms-excel" '"text/plain" 
        'response.Cache.SetCacheability(HttpCacheability.NoCache)

        'create a string writer
        Dim stringWrite As New System.IO.StringWriter()

        'create an htmltextwriter which uses the stringwriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)

        'instantiate a datagrid
        Dim dg As New DataGrid()
        ' just set the input datagrid = to the new dg grid
        dg = dgExport

        ' I want to make sure there are no annoying gridlines
        dg.GridLines = GridLines.Both

        ' Make the header text bold
        'dg.HeaderStyle.Font.Bold = True

        ' If needed, here's how to change colors/formatting at the component level
        'dg.HeaderStyle.ForeColor = System.Drawing.Color.Black
        'dg.ItemStyle.ForeColor = System.Drawing.Color.Black

        'bind the modified datagrid
        dg.AllowPaging = False
        dg.ShowFooter = False
        dg.DataBind()

        'Remove any button columns
        Dim i As Integer
        Dim strHeader As String

        For i = 0 To dg.Columns.Count - 1
            strHeader = LCase(dg.Columns(i).HeaderText)
            If strHeader = "edit" Or strHeader = "view" Or _
                strHeader = "view/edit" Or strHeader = "delete" Or _
                strHeader = "select" Or strHeader = "update" Or _
                strHeader = "details" Or strHeader = "remove" Then
                dg.Columns(i).Visible = False
            End If

        Next

        'tell the datagrid to render itself to our htmltextwriter
        'dg.RenderControl(htmlWrite)
        Dim j As Integer
        Dim strVal As String

        stringWrite.Write("First Name" & vbTab & "Last Name" & vbTab & "Company" & _
            vbTab & "Job Title" & vbTab & "Business Street" & vbTab & "Business City" & _
            vbTab & "Business State" & vbTab & "Business Postal Code" & _
            vbTab & "Business Phone" & vbTab & "E-mail Address")
        stringWrite.WriteLine()

        For i = 0 To dg.Items.Count - 1
            For j = 1 To dg.Columns.Count - 1
                If j = 3 Then
                    strVal = Replace(CType(dg.Items(i).Cells(j).FindControl("lblOrg"), Label).Text, vbCrLf, "")
                ElseIf j = 4 Then
                    strVal = Replace(CType(dg.Items(i).Cells(j).FindControl("lblPositions"), Label).Text, vbCrLf, "")
                ElseIf j = 7 Then
                    strVal = Replace(CType(dg.Items(i).Cells(j).FindControl("lblProvince"), Label).Text, vbCrLf, "")
                ElseIf j = 9 Then
                    strVal = Replace(CType(dg.Items(i).Cells(j).FindControl("lblPhone"), Label).Text, vbCrLf, "")
                Else
                    strVal = Replace(dg.Items(i).Cells(j).Text, vbCrLf, "")
                End If
                strVal = Replace(strVal, "<br>", "")
                strVal = Chr(34) & Trim(strVal) & Chr(34)
                strVal = Replace(strVal, "&nbsp;", "")
                stringWrite.Write(strVal & vbTab)
            Next
            stringWrite.WriteLine()
        Next
        'output the html
        response.Write(stringWrite.ToString)
        response.End()

    End Sub

    Public Shared Sub DataGridToCSV(ByVal dgExport As DataGrid, ByVal response As HttpResponse)
        'clean up the response.object
        response.Buffer = True
        response.Clear()
        response.Charset = ""

        'try to open new window
        response.AddHeader("Content-Disposition", "attachment; filename=CharityCan_Report.CSV")

        'set the response mime type for excel
        response.ContentType = "application/vnd.ms-excel" '"text/plain" 
        'response.Cache.SetCacheability(HttpCacheability.NoCache)

        'create a string writer
        Dim stringWrite As New System.IO.StringWriter()

        'create an htmltextwriter which uses the stringwriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)

        'instantiate a datagrid
        Dim dg As New DataGrid()
        ' just set the input datagrid = to the new dg grid
        dg = dgExport

        ' I want to make sure there are no annoying gridlines
        dg.GridLines = GridLines.Both

        ' Make the header text bold
        'dg.HeaderStyle.Font.Bold = True

        ' If needed, here's how to change colors/formatting at the component level
        'dg.HeaderStyle.ForeColor = System.Drawing.Color.Black
        'dg.ItemStyle.ForeColor = System.Drawing.Color.Black

        'bind the modified datagrid
        dg.AllowPaging = False
        dg.ShowFooter = False
        dg.Visible = True
        dg.DataBind()

        'Remove any button columns
        Dim i As Integer
        Dim strHeader As String

        For i = 0 To dgExport.Columns.Count - 1
            strHeader = LCase(dgExport.Columns(i).HeaderText)
            If strHeader = "edit" Or strHeader = "view" Or _
                strHeader = "view/edit" Or strHeader = "delete" Or _
                strHeader = "select" Or strHeader = "update" Or _
                strHeader = "details" Or strHeader = "remove" Then
                dgExport.Columns(i).Visible = False
            End If

        Next

        'tell the datagrid to render itself to our htmltextwriter
        'dg.RenderControl(htmlWrite)
        Dim j As Integer
        Dim strVal As String

        'stringWrite.Write("First Name,Last Name,Company," & _
        '    "Job Title,Business Street,Business City," & _
        '    "Business State,Business Postal Code," & _
        '    "Business Phone,E-mail Address")
        'stringWrite.WriteLine()

        For i = 0 To dgExport.Items.Count - 1
            For j = 1 To dgExport.Columns.Count - 1
                strVal = Replace(dgExport.Items(i).Cells(j).Text, vbCrLf, "")

                strVal = Replace(strVal, "<br>", "")
                strVal = Chr(34) & Trim(strVal) & Chr(34)
                strVal = Replace(strVal, "&nbsp;", "")
                stringWrite.Write(strVal & ",")
            Next
            stringWrite.WriteLine()
        Next
        'output the html
        response.Write(stringWrite.ToString)
        response.End()

    End Sub

    Public Shared Sub ExportFinancials(ByVal dgExport As DataGrid, ByVal response As HttpResponse, ByVal strFileName As String)
        'clean up the response.object
        response.Buffer = True
        response.Clear()
        response.Charset = ""

        'try to open new window
        response.AddHeader("Content-Disposition", "attachment; filename=" & strFileName)

        'set the response mime type for excel
        response.ContentType = "application/vnd.ms-excel"
        'response.Cache.SetCacheability(HttpCacheability.NoCache)

        'create a string writer
        Dim stringWrite As New System.IO.StringWriter()

        'create an htmltextwriter which uses the stringwriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)

        'instantiate a datagrid
        Dim dg As New DataGrid()
        ' just set the input datagrid = to the new dg grid
        dg = dgExport

        ' I want to make sure there are no annoying gridlines
        dg.GridLines = GridLines.Both

        ' Make the header text bold
        dg.HeaderStyle.Font.Bold = True

        ' If needed, here's how to change colors/formatting at the component level
        dg.HeaderStyle.ForeColor = System.Drawing.Color.Black
        dg.ItemStyle.ForeColor = System.Drawing.Color.Black

        'bind the modified datagrid
        dg.AllowPaging = False
        dg.ShowFooter = False
        dg.DataBind()

        'Remove any button columns
        Dim i As Integer
        'Dim strHeader As String

        'For i = 0 To dg.Columns.Count - 1
        '    strHeader = LCase(dg.Columns(i).HeaderText)
        '    If strHeader = "edit" Or strHeader = "view" Or _
        '        strHeader = "view/edit" Or strHeader = "delete" Or _
        '        strHeader = "select" Or strHeader = "update" Or _
        '        strHeader = "details" Or strHeader = "remove" Then
        '        dg.Columns(i).Visible = False
        '    End If

        'Next

        'tell the datagrid to render itself to our htmltextwriter
        'dg.RenderControl(htmlWrite)

        'stringWrite.Write("First Name" & vbTab & "Last Name" & vbTab & "Company" & _
        '    vbTab & "Job Title" & vbTab & "Business Street" & vbTab & "Business City" & _
        '    vbTab & "Business State" & vbTab & "Business Postal Code" & _
        '    vbTab & "Business Phone" & vbTab & "E-mail Address")
        'stringWrite.WriteLine()
        Dim j As Integer

        response.Write("<table>")

        For i = 0 To dg.Items.Count - 1
            response.Write("<tr>")
            For j = 1 To dg.Columns.Count - 1

                response.Write("<td>" & dg.Items(i).Cells(j).Text & "</td>")
            Next
            response.Write("</tr>")
            'stringWrite.WriteLine()
        Next
        response.Write("</table>")

        'output the html
        'response.Write(stringWrite.ToString)
        response.End()

    End Sub

    Public Shared Sub DataGridToExcel25(ByVal dgExport As DataGrid, ByVal response As HttpResponse)
        'clean up the response.object
        response.Buffer = True
        response.Clear()
        response.Charset = ""

        ' response.ContentEncoding = Encoding.UTF8


        'try to open new window
        response.AddHeader("Content-Disposition", "attachment; filename=CharityCan_Report.xls")

        'set the response mime type for excel
        ' response.Cache.SetCacheability(HttpCacheability.NoCache)

        response.ContentType = "application/vnd.ms-excel"


        'create a string writer
        Dim stringWrite As New System.IO.StringWriter()

        'create an htmltextwriter which uses the stringwriter
        Dim htmlWrite As New System.Web.UI.HtmlTextWriter(stringWrite)


        'instantiate a datagrid
        Dim dg As New DataGrid()
        ' just set the input datagrid = to the new dg grid
        dg = dgExport

        ' I want to make sure there are no annoying gridlines
        dg.GridLines = GridLines.Both

        ' Make the header text bold
        dg.HeaderStyle.Font.Bold = True

        ' If needed, here's how to change colors/formatting at the component level
        'dg.HeaderStyle.ForeColor = System.Drawing.Color.Black
        'dg.ItemStyle.ForeColor = System.Drawing.Color.Black

        'bind the modified datagrid
        dg.AllowPaging = True
        dg.PageSize = 25
        dg.ShowFooter = False
        dg.DataBind()

        'Remove any button columns
        Dim i As Integer
        Dim strHeader As String

        For i = 0 To dg.Columns.Count - 1
            strHeader = LCase(dg.Columns(i).HeaderText)
            If strHeader = "edit" Or strHeader = "view" Or _
                strHeader = "view/edit" Or strHeader = "delete" Or _
                strHeader = "select" Or strHeader = "update" Or _
                strHeader = "details" Or strHeader = "remove" Then
                dg.Columns(i).Visible = False
            End If

        Next

        'tell the datagrid to render itself to our htmltextwriter
        stringWrite.Write("<html><head><meta http-equiv=""content-type"" content=""text/html; charset=utf-8""></head><body>")

        dg.RenderControl(htmlWrite)
        stringWrite.Write("</body></html>")

        'output the html
        response.Write(stringWrite.ToString)
        response.End()

    End Sub

End Class