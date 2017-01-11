Imports System.Configuration
Imports System.Reflection
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class CEmail

#Region "Members"

    Private mSender As String
    Private mFromName As String
    Private mSubject As String
    Private mRecipient As String
    Private mMessage As String

    'Public Const Prefix As String = "<p>Thank you for your online credit application.  In order " & _
    '    "to confirm your identity and proceed with your application, please click the link below. " & _
    '    "</p><p><a href=""https://www.jimwilsonchevrolet.com/response.aspx?aid="
    'Public Const Suffix As String = """>Click here to verify your application</a></p><p>" & _
    '    "The Jim Wilson Chevrolet Sales Team</p>"
    'Private Const sKey As String = "3?45a$#!"

#End Region

#Region "Methods"

    Public Shared Sub SendMail(ByVal strFrom As String, ByVal strFromName As String, ByVal strSubject As String, _
        ByVal strTo As String, ByVal strMessage As String, ByVal strAttachment As String)

        'Sends Persits Email
        'Params: 1. Sending Address
        '2. Friendly Sender Name
        '3. Message Subject
        '4. Recipient Address
        '5. Message text
        '6. Attachment, if any

        Dim Mailer As Object

        Mailer = CreateObject("Persits.MailSender")
        Mailer.Host = System.Configuration.ConfigurationManager.AppSettings("strHost")

        Mailer.From = strFrom
        Mailer.FromName = strFromName
        Mailer.Subject = strSubject

        Mailer.AddAddress(strTo)
        ' Mailer.AddBcc("alicia@infrontofthenet.com")
        Mailer.IsHTML = True

        If InStr(strConn, "localhost") = 0 Then
            Mailer.ContentTransferEncoding = "Quoted-Printable"
        End If

        If strAttachment <> "" Then
            Mailer.AddAttachment(strAttachment)
        End If

        Mailer.Body = strMessage

        Mailer.username = "scott@knowleswoolsey.com"
        Mailer.password = "joedog"
        If InStr(Mailer.host.ToString, "localhost") = 0 Then
            Mailer.Send()
        End If


        Mailer = Nothing

    End Sub

    Public Sub SendMail()

        SendMail(Sender, FromName, Subject, Recipient, Message, "")

    End Sub

    Public Shared Sub SendErrorMessage(ByVal objError As Exception, ByVal strForm As String, ByVal strQs As String)

        'Dim strFormValues As String
        'Dim intStart As Integer

        If Not objError.Message.ToString.Contains("Thread was being aborted") Then

            Dim strMessage, strFrom, strFromName, strSubject, strTo As String

            'Parse form values to remove view state
            'intStart = InStr(strForm, "&")
            'strFormValues = Mid(strForm, intStart + 1)

            strMessage = "MESSAGE: " & objError.Message.ToString() & _
                "<p>SOURCE: " & objError.Source.ToString() & _
                "<p>FORM: " & strForm & _
                "<p>QUERYSTRING: " & strQs & _
                "<p>TARGETSITE: " & objError.TargetSite.ToString() & _
                "<p>STACKTRACE: " & objError.StackTrace
            strFrom = "errors@infrontofthenet.com"
            strFromName = "KW Error"
            strSubject = "KW Error"
            strTo = "rfreeman@infrontofthenet.com"
            SendMail(strFrom, strFromName, strSubject, strTo, strMessage, "")
            'strTo = "alicia@infrontofthenet.com"
            'SendMail(strFrom, strFromName, strSubject, strTo, strMessage, "")


        End If

    End Sub

    'Public Shared Function Encrypt(ByVal ApplicationID As String) As String

    '    Dim objSecurity As New CSecurity()

    '    Return objSecurity.Encrypt(ApplicationID, sKey)

    'End Function

    'Public Shared Function Decrypt(ByVal ApplicationID As String) As String

    '    Dim objSecurity As New CSecurity()

    '    Return objSecurity.Decrypt(ApplicationID, sKey)

    'End Function

    'Public Shared Function GenerateMessage(ByVal aid As String) As String

    '    Dim strFinal As String

    '    strFinal = Prefix & Encrypt(aid) & Suffix
    '    Return strFinal

    'End Function

#End Region

#Region "Properties"

    Public Property Sender() As String
        Get
            Return mSender
        End Get
        Set(ByVal Value As String)
            mSender = Value
        End Set
    End Property
    Public Property FromName() As String
        Get
            Return mFromName
        End Get
        Set(ByVal Value As String)
            mFromName = Value
        End Set
    End Property
    Public Property Subject() As String
        Get
            Return mSubject
        End Get
        Set(ByVal Value As String)
            mSubject = Value
        End Set
    End Property
    Public Property Message() As String
        Get
            Return mMessage
        End Get
        Set(ByVal Value As String)
            mMessage = Value
        End Set
    End Property
    Public Property Recipient() As String
        Get
            Return mRecipient
        End Get
        Set(ByVal Value As String)
            mRecipient = Value
        End Set
    End Property

#End Region

End Class
