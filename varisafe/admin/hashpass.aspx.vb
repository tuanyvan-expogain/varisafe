Imports System.Security.Cryptography

Public Class hashpass
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGo_Click(sender As Object, e As EventArgs)

        Dim pw As String = txtpw.Text
        Dim hpw As Byte()
        Dim final As String

        Dim Data As Byte() = Encoding.UTF8.GetBytes(pw)
        Dim shaM As SHA512 = New SHA512Managed()

        hpw = shaM.ComputeHash(Data)

        Dim hashedInputStringBuilder As New System.Text.StringBuilder(128)
        Dim b As Object
        Dim i As Integer

        For i = 0 To hpw.Length - 1
            hashedInputStringBuilder.Append(hpw(i).ToString("x"))
        Next

        'For Each b In hpw
        '    hashedInputStringBuilder.Append(b.ToString("x"))
        'Next
        final = hashedInputStringBuilder.ToString()
        'final = final.ToString()

        lblHash.Text = final 'SHA512(hpw)
    End Sub

    Public Shared Function SHA512(input As String) As String
        Dim bytes = System.Text.Encoding.UTF8.GetBytes(input)
        Using hash = System.Security.Cryptography.SHA512.Create()
            Dim hashedInputBytes = hash.ComputeHash(bytes)

            ' Convert to text
            ' StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            Dim hashedInputStringBuilder = New System.Text.StringBuilder(128)
            Dim b As Object

            For Each b In hashedInputBytes
                hashedInputStringBuilder.Append(b.ToString("X2"))
            Next
            Return hashedInputStringBuilder.ToString()
        End Using
    End Function

End Class