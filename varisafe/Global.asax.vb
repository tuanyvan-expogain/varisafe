Imports System.Web.SessionState
Imports System.Web
Imports System.Threading
Imports System.Globalization
Imports System.Security.Principal
Imports System.Xml
Imports System.Configuration
Imports System.Collections.Specialized

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

        If IsNothing(CType(sender, HttpApplication).Request) Then
            Exit Sub
        End If

        If IsNothing(CType(sender, HttpApplication).Context) Then
            Exit Sub
        End If

        ' Fires at the beginning of each request
        Dim request As HttpRequest = CType(sender, HttpApplication).Request
        Dim context As HttpContext = CType(sender, HttpApplication).Context

        Dim applicationPath As String = request.ApplicationPath
        If applicationPath = "/" Then
            applicationPath = String.Empty
        End If
        Dim requestPath As String = request.Url.AbsolutePath.Substring(applicationPath.Length)



        'LoadCulture(requestPath)


        If (request.Path.IndexOf(Chr(92)) >= 0 Or System.IO.Path.GetFullPath(request.PhysicalPath) <> request.PhysicalPath) Then
            Throw New HttpException(404, "Not Found")
        End If

        'Dim siteMapFile As String = ConfigurationSettings.AppSettings("strURLFile1")
        Dim siteMapFile As String = System.Configuration.ConfigurationManager.AppSettings("SiteMap")
        Dim siteMap As New XmlDocument()
        siteMap.Load(HttpContext.Current.Server.MapPath(siteMapFile))

        'Dim rewriteFrom As String = HttpContext.Current.Request.RawUrl
        ' Dim rewriteFrom As String = Mid(requestPath, 2, Len(requestPath) - 6)


        Dim strQS As String = ""
        Dim rewriteFrom As String

        'If InStr(requestPath, "/shop/") > 0 Then
        '    Exit Sub
        'End If

        'Strip off any slashes or file extensions
        rewriteFrom = Replace(requestPath, "/", "")
        rewriteFrom = Replace(rewriteFrom, ".aspx", "")

        'Check if there is a querystring
        Dim intQS As Integer

        'intQS = InStr(rewriteFrom, "?")
        intQS = InStr(CType(sender, HttpApplication).Request.Url.ToString, "?")
        If intQS > 0 Then
            If Not IsNothing(CType(sender, HttpApplication).Request.QueryString) Then
                If CType(sender, HttpApplication).Request.QueryString.Count > 0 Then
                    strQS = "&" & CType(sender, HttpApplication).Request.QueryString.ToString
                End If
            End If
            'strQS = Mid(rewriteFrom, intQS + 1)
        End If


        'Dim rewriteRule As XmlNode = siteMap.SelectSingleNode("descendant::siteMapNode[@url='" + rewriteFrom + "']")
        'Dim rewriteRule As XmlNode = siteMap.SelectSingleNode("pages[pageName = '" & rewriteFrom & "']")
        If IsNothing(rewriteFrom) Then
            rewriteFrom = ""
        End If

        Dim rewriteRule As XmlNode = siteMap.SelectSingleNode("descendant::pages[pageName='" & rewriteFrom.ToLower & "']")

        'Dim rewriteToNode As XmlNode

        Dim rewriteTo As String = String.Empty
        If (Not (rewriteRule) Is Nothing) Then
            Dim rewriteToRule As XmlNode = rewriteRule.SelectSingleNode("pageID")
            If (Not (rewriteToRule) Is Nothing) Then

                If InStr(strQS, "pid=") > 0 Then
                    rewriteTo = "/default.aspx?pid=" & rewriteToRule.InnerText
                Else
                    rewriteTo = "/default.aspx?pid=" & rewriteToRule.InnerText & strQS
                End If
            End If
        End If

        'context.RewritePath(applicationPath + rewriteTo) ' + rewriteTo)

        If (rewriteTo.Length > 0) Then
            'HttpContext.Current.RewritePath(rewriteTo)
            context.RewritePath(applicationPath + rewriteTo)
        Else
            'if the page cannot be found - display 404.aspx???
            'context.RewritePath(applicationPath + "/default.aspx")
        End If
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use

        If Context.Request.IsAuthenticated Then


            'If Len(User.Identity.Name) = 0 Then

            If IsNumeric(User.Identity.Name) Then

                Dim objuser As New BusinessRules.CUser()
                Dim roleList As New ArrayList()

                With objuser
                    '.Username = User.Identity.Name
                    .UserID = CInt(User.Identity.Name)
                    .GetUserRoles()

                    'Get Role List
                    While .Roles.Read
                        Dim x As String
                        x = .Roles("role").ToString
                        roleList.Add(x) '.Rdr("Role").ToString)

                    End While

                    .Roles.Close()
                End With

                'Add the roles to the User Principal
                ' do I need to make it an array? I got errors when It was just a string

                Dim arrRoles As String() = roleList.ToArray(GetType(String)) ' {objuser.role}
                'HttpContext.Current.User = New GenericPrincipal(User.Identity, arrRoles)

                Context.User = New GenericPrincipal(User.Identity, arrRoles)

                '    'Response.Write(arrRoles(0))
                '    'Response.Write(User.IsInRole("LicenseeAdmin"))
                '    'Response.Write(User.Identity.IsAuthenticated)


            End If
        End If


    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

        ' Fires when an error occurs - do not enable
        'Dim objErr As Exception = Server.GetLastError().GetBaseException()
        'Dim err As String = objErr.Message.ToString()
        'Dim errUrl As String = Request.Url.ToString() & "<p>" & objErr.StackTrace.ToString() & "</p>"

        ''BusinessRules.CEmail.SendErrorMessage(objErr, Request.Form.ToString(), Request.QueryString.ToString())
        'Server.ClearError()

        'If err <> "External component has thrown an exception." Then

        '    Response.Redirect("~/error.aspx", False)

        'End If

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Session_OnEnd()
        'Server.Transfer("default.aspx")
        FormsAuthentication.SignOut()
        'Session.Abandon()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class