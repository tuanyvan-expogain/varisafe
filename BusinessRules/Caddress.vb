Imports System.Data.SqlClient
Imports System.data

Public Class Caddress

#Region "Members"
    Private mAddress As String
    Private mAddress2 As String
    Private mCity As String
    Private mProvince As String
    Private mCountry As String
    Private mProvinceID As String
    Private mCountryID As String

    Private mPostalCode As String
    Private mPhone As String
    Private mProvinces As SqlDataReader
    Private mCountries As SqlDataReader
#End Region

#Region "Properties"
    Public Property Address() As String
        Get
            Return mAddress
        End Get
        Set(ByVal Value As String)
            mAddress = Value
        End Set
    End Property
    Public Property Address2() As String
        Get
            Return mAddress2
        End Get
        Set(ByVal Value As String)
            mAddress2 = Value
        End Set
    End Property
    Public Property City() As String
        Get
            Return mCity
        End Get
        Set(ByVal Value As String)
            mCity = Value
        End Set
    End Property
    Public Property Province() As String
        Get
            Return mProvince
        End Get
        Set(ByVal Value As String)
            mProvince = Value
        End Set
    End Property
    Public Property ProvinceID() As String
        Get
            Return mProvinceID
        End Get
        Set(ByVal Value As String)
            mProvinceID = Value
        End Set
    End Property
    Public Property Country() As String
        Get
            Return mCountry
        End Get
        Set(ByVal Value As String)
            mCountry = Value
        End Set
    End Property
    Public Property CountryID() As String
        Get
            Return mCountryID
        End Get
        Set(ByVal Value As String)
            mCountryID = Value
        End Set
    End Property
    Public Property PostalCode() As String
        Get
            Return mPostalCode
        End Get
        Set(ByVal Value As String)
            mPostalCode = Value
        End Set
    End Property
    Public Property Phone() As String
        Get
            Return mPhone
        End Get
        Set(ByVal Value As String)
            mPhone = Value
        End Set
    End Property

    Public Property Provinces() As SqlDataReader
        Get
            Return mProvinces
        End Get
        Set(ByVal Value As SqlDataReader)
            mProvinces = Value
        End Set
    End Property
    Public Property Countries() As SqlDataReader
        Get
            Return mCountries
        End Get
        Set(ByVal Value As SqlDataReader)
            mCountries = Value
        End Set
    End Property

#End Region

#Region "Methods"

    Public Sub listProvinces(ByVal ParentID As Integer)
        Provinces = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spListCountryProv", _
            New SqlParameter("@CID", ParentID))
    End Sub

    Public Sub listCountries()
        Countries = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "splistCountries")
    End Sub

    Function GetCountryCode(ByVal CountryID As String)
        Dim countryCode As String = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, "spGetcountryCode", _
                New SqlParameter("@CountryID", CountryID))
        Return countryCode
    End Function

#End Region

End Class
