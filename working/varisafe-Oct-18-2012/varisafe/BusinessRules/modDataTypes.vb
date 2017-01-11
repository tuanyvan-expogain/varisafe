Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Module modDataTypes

    Public strConn As String = CDataAccess.GetConnString()
    Public siteID As Integer = CDataAccess.GetSiteID

    Function CheckNullString(ByVal str As SqlString) As String

        'Check string value for null and replace null w/""
        'Params: 1. Numeric value to check
        If str.IsNull Then
            Return ""
        Else
            Return str.Value
        End If
    End Function

    Function CheckNullNum(ByVal Num As Object) As Double

        'Check numeric value for null and replace null w/0
        'Params: 1. Numeric value to check
        If IsDBNull(Num) Then
            Return 0
        Else
            Return Num
        End If
    End Function

    Function CheckNullNum(ByVal Num As SqlDecimal) As Double

        'Check numeric value for null and replace null w/0
        'Params: 1. Numeric value to check
        If Num.IsNull Then
            Return 0
        Else
            Return Num.Value
        End If
    End Function

    Function CheckNullNum(ByVal Num As SqlInt32) As Int32

        'Check numeric value for null and replace null w/0
        'Params: 1. Numeric value to check
        If Num.IsNull Then
            Return 0
        Else
            Return Num.Value
        End If

    End Function

    Function CheckNullDate(ByVal dat As SqlDateTime) As DateTime

        'Check date value for null and replace null w/min value i.e. "12:00:00 AM"
        'Params: 1. Date value to check
        If dat.IsNull Then
            Return DateTime.MinValue
        Else
            Return dat.Value
        End If
    End Function

    Function CheckNullDate(ByVal dat As Object) As DateTime

        'Check date value for null and replace null w/min value i.e. "12:00:00 AM"
        'Params: 1. Date value to check
        If IsDBNull(dat) Then
            Return DateTime.MinValue
        Else
            Return dat
        End If

    End Function

    Function CheckParamDateNull(ByVal dat As DateTime) As SqlDateTime

        If dat = #1/1/1900# Or dat = "" Then
            Return SqlDateTime.Null
        Else
            Return SqlDateTime.Parse(CStr(dat))
        End If

    End Function

    

End Module
