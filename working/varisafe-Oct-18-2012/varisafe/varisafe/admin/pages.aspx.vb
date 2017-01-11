Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient

Public Class pages
    Inherits System.Web.UI.Page
    Protected WithEvents xmlSitemap As System.Web.UI.WebControls.Xml
    Dim objDs As New DataSet()
    Dim relPage As DataRelation
    Dim strXML As New StringBuilder()
    Dim writer As XmlTextWriter

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
        GetSitemap1()
    End Sub

    Private Sub GetSitemap()


        Dim aPages(0) As String
        Dim strConn As String = System.Configuration.ConfigurationManager.AppSettings("strConn")
        Dim siteID As Integer = System.Configuration.ConfigurationManager.AppSettings("siteID")
        aPages(0) = "pages"

        '.net 1
        'BusinessRules.SqlHelper.FillDataset(ConfigurationSettings.AppSettings("strConn"), _
        '    CommandType.StoredProcedure, "spGetPages", objDs, aPages, _
        '    New SqlParameter("@siteID", ConfigurationSettings.AppSettings("siteID")))

        'new .net 2
        BusinessRules.SqlHelper.FillDataset(strConn, _
            CommandType.StoredProcedure, "spGetPages", objDs, aPages, _
            New SqlParameter("@siteID", siteID))

        objDs.Relations.Add("PageTree", _
            objDs.Tables("pages").Columns("pageID"), _
            objDs.Tables("pages").Columns("parentID"), False)


        'Dim custRow As DataRow
        'Dim orderRow As DataRow

        writer.WriteStartDocument()
        writer.Formatting = System.Xml.Formatting.Indented

        writer.WriteStartElement("sitemap")

        Dim row As DataRow
        Dim x As Integer
        For Each row In objDs.Tables(0).Rows
            x = CInt(row.Item(2))
            If CInt(row.Item(2)) = 0 Then
                writeXml(row)
                addtodropdownrecursively(row)
            End If
        Next

        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Close()

    End Sub

    Sub AddXML(ByVal row As DataRow)

        strXML.Append("<pages><pageID>" & row.Item(0).ToString & "</pageID>")
        strXML.Append("<pageName>" & row.Item(1).ToString & "</pageName>")
        strXML.Append("<parentID>" & row.Item(2).ToString & "</parentID>")
        strXML.Append("<inMainNav>" & row.Item(4).ToString & "</inMainNav>")
        strXML.Append("<inSiteMap>" & row.Item(5).ToString & "</inSiteMap>")

    End Sub

    Sub writeXml(ByVal row As DataRow)

        writer.WriteStartElement("pages")
        writer.WriteElementString("pageID", row.Item(0).ToString)
        writer.WriteElementString("pageName", row.Item(1).ToString)
        writer.WriteElementString("parentID", row.Item(2).ToString)
        writer.WriteElementString("inMainNav", row.Item(4).ToString)
        writer.WriteElementString("inSitemap", row.Item(5).ToString)

    End Sub

    Sub addtodropdownrecursively(ByVal row As DataRow)

        Dim childRow As DataRow
        For Each childRow In row.GetChildRows("PageTree")

            writeXml(childRow)
            Dim x As String
            x = childRow.Item(0).ToString
            addtodropdownrecursively(childRow)

        Next

        writer.WriteEndElement()

    End Sub

    Private Sub GetSitemap1()

        Dim row As DataRow
        Dim childRow As DataRow

        Dim objPage As New BusinessRules.CPage()

        Try
            With objPage
                .GetSiteStructure()
                objDs = .ComboList
            End With

            '   Dim aPages(0) As String

            '   aPages(0) = "pages"

            '   BusinessRules.SqlHelper.FillDataset(ConfigurationSettings.AppSettings("strConn"), _
            'CommandType.StoredProcedure, "spGetPages", objDs, aPages)

            With objDs
                .Relations.Add("PageTree", _
                    .Tables("pages").Columns("pageID"), _
                    .Tables("pages").Columns("parentID"), False)
                .Relations.Add("PageLinks", _
                    .Tables("pages").Columns("pageID"), _
                    .Tables("linkNames").Columns("pageID"), False)
                .Relations("PageLinks").Nested = True

                writer = New XmlTextWriter(Server.MapPath("xml\pages.xml"), Encoding.UTF8)
                writer.WriteStartDocument()
                writer.Formatting = System.Xml.Formatting.Indented

                writer.WriteStartElement("sitemap")

                For Each row In .Tables(0).Rows
                    If CInt(row.Item(2)) = 0 Then
                        writeXml1(row)

                        'check for link name relations
                        For Each childRow In row.GetChildRows("PageLinks")
                            writeLinkName(childRow)
                        Next

                        AddChildNode(row)
                    End If
                Next

                writer.WriteEndElement()
                writer.WriteEndDocument()
                writer.Close()
            End With

            File.Copy(Server.MapPath("xml\pages.xml"), Server.MapPath("xml\backup\pages.xml"), True)

            xmlSitemap.DocumentSource = "xml/pages.xml"
            xmlSitemap.TransformSource = "xml/pages.xslt"
            xmlSitemap.DataBind()
        Catch objError As Exception
            Response.Write("An error occurred - retrieving backup file")
            File.Delete(Server.MapPath("xml\pages.xml"))
            File.Copy(Server.MapPath("xml\backup\pages.xml"), Server.MapPath("xml\pages.xml"), True)
            'GetSitemap1()
        End Try

    End Sub

    Sub writeXml1(ByVal row As DataRow)

        writer.WriteStartElement("pages")
        writer.WriteElementString("pageID", row.Item(0).ToString)
        writer.WriteElementString("pageName", row.Item(1).ToString.ToLower)
        writer.WriteElementString("parentID", row.Item(2).ToString)
        writer.WriteElementString("inMainNav", row.Item(4).ToString)
        writer.WriteElementString("inSitemap", row.Item(5).ToString)

    End Sub

    Sub writeLinkName(ByVal row As DataRow)

        writer.WriteStartElement("LinkNames")
        writer.WriteElementString("pageID", row.Item(0).ToString)
        writer.WriteElementString("linkName", row.Item(2).ToString)
        writer.WriteElementString("languageID", row.Item(1).ToString)
        writer.WriteEndElement()


    End Sub

    Sub AddChildNode(ByVal row As DataRow)

        Dim childRow As DataRow
        Dim childRow1 As DataRow

        For Each childRow In row.GetChildRows("PageTree")

            writeXml1(childRow)

            'check for link name relations
            For Each childRow1 In childRow.GetChildRows("PageLinks")
                writeLinkName(childRow1)
            Next

            AddChildNode(childRow)

        Next

        writer.WriteEndElement()

    End Sub
End Class
