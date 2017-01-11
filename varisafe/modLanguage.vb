Imports System.Threading

Module modLanguage

    Public Function GetLanguageID() As Integer

        If Thread.CurrentThread.CurrentCulture.Name.ToLower = "fr-ca" Then
            Return 2
        Else
            Return 1
        End If

    End Function

    Public Function GetLanguage() As String

        If Thread.CurrentThread.CurrentCulture.Name.ToLower = "fr-ca" Then
            Return "Fr"
        Else
            Return "En"
        End If

    End Function

End Module
