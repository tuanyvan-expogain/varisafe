Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.data

Public Class CUser

#Region "Members"
    Private mUserID As Integer
    Private mUsername As String
    Private mPassword As Object
    Private mRoles As SqlDataReader
    Private mFirstname As String
    Private mLastname As String
    Private mAddress As String
    Private mAddress2 As String
    Private mCity As String
    Private mProvince As String
    Private mProvinceID As String

    Private mCountry As String
    Private mCountryID As String

    Private mPostalCode As String
    Private mPhone As String
    Private mphoneX As String
    Private mEmail As String
    Private mNotify As Boolean
    Private mCombos As DataSet
    Private mCompany As String
    Private mlicenseeID As Integer
    Private mexpiryDate As Date
    Private mStartDate As Date
    Private mActive As Boolean

    Private mlastmodifiedby As Integer
    Private mSavedSearches As DataSet
    Private mSavedCharities As DataSet

#End Region

#Region "Properties"

    Public Property Roles() As SqlDataReader
        Get
            Return mRoles
        End Get
        Set(ByVal Value As SqlDataReader)
            mRoles = Value
        End Set
    End Property
    Public Property Combos() As DataSet
        Get
            Return mCombos
        End Get
        Set(ByVal Value As DataSet)
            mCombos = Value
        End Set
    End Property
    Public Property Username() As String
        Get
            Return mUsername
        End Get
        Set(ByVal Value As String)
            mUsername = Value
        End Set
    End Property
    Public Property Password() As Object
        Get
            Return mPassword
        End Get
        Set(ByVal Value As Object)
            mPassword = Value
        End Set
    End Property
    Public Property UserID() As Integer
        Get
            Return mUserID
        End Get
        Set(ByVal Value As Integer)
            mUserID = Value
        End Set
    End Property
    Public Property Firstname() As String
        Get
            Return mFirstname
        End Get
        Set(ByVal Value As String)
            mFirstname = Value
        End Set
    End Property
    Public Property Lastname() As String
        Get
            Return mLastname
        End Get
        Set(ByVal Value As String)
            mLastname = Value
        End Set
    End Property

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
    Public Property PhoneX() As String
        Get
            Return mphoneX
        End Get
        Set(ByVal Value As String)
            mphoneX = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return mEmail
        End Get
        Set(ByVal Value As String)
            mEmail = Value
        End Set
    End Property
    Public Property Notify() As Boolean
        Get
            Return mNotify
        End Get
        Set(ByVal Value As Boolean)
            mNotify = Value
        End Set
    End Property
    Public Property Company() As String
        Get
            Return mCompany
        End Get
        Set(ByVal Value As String)
            mCompany = Value
        End Set
    End Property

    Public Property LicenseeID() As Integer
        Get
            Return mlicenseeID
        End Get
        Set(ByVal value As Integer)
            mlicenseeID = value
        End Set
    End Property


    Public Property LastModifiedby() As Integer
        Get
            Return mlastmodifiedby
        End Get
        Set(ByVal value As Integer)
            mlastmodifiedby = value
        End Set
    End Property

    Public Property ExpiryDate() As Date
        Get
            Return mexpiryDate
        End Get
        Set(ByVal value As Date)
            mexpiryDate = value
        End Set
    End Property
    Public Property StartDate() As Date
        Get
            Return mStartDate
        End Get
        Set(ByVal value As Date)
            mStartDate = value
        End Set
    End Property

    Public Property Active() As Boolean
        Get
            Return mActive
        End Get
        Set(ByVal value As Boolean)
            mActive = value
        End Set
    End Property
   
    Public Property savedSearches() As DataSet
        Get
            Return mSavedSearches
        End Get
        Set(ByVal value As DataSet)
            mSavedSearches = value
        End Set
    End Property

    Public Property SavedCharities() As DataSet
        Get
            Return mSavedCharities
        End Get
        Set(ByVal value As DataSet)
            mSavedCharities = value
        End Set
    End Property


#End Region

#Region "Constructor"

    Public Sub New()

        MyBase.new()

    End Sub

#End Region

#Region "Methods"

    Public Sub ValidateUser()

        UserID = CheckNullNum(SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spKWValidateAdmin", New SqlParameter("@Username", Username), _
            New SqlParameter("@Password", Password)))

    End Sub


  

    Public Sub ValidateCustomer()

        'UserID = CheckNullNum(SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
        '    "spValidateUser", New SqlParameter("@Username", Username), _
        '    New SqlParameter("@Password", Password)))

        Roles = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, _
            "spK2ValidateUser", New SqlParameter("@Username", Username)) ', _
        'New SqlParameter("@Password", Password))

        With Roles
            While .Read
                UserID = CheckNullNum(.GetSqlInt32(0))
                Firstname = CheckNullString(.GetSqlString(1))
                Lastname = CheckNullString(.GetSqlString(2))
                Password = .Item("user_password")
            End While

            .Close()
        End With

    End Sub

    Public Sub RegisterUser()
        ' are we actually saving the address for users or just for licensees accounts and contacts?
        ' we don't have addresses / contact info in the specs for the user account so I have
        ' passed a modifed version of this below called "addUser" with everything not in the specs removed

        UserID = CheckNullNum(SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spSaveCustomer", New SqlParameter("@Firstname", Firstname), _
            New SqlParameter("@Lastname", Lastname), _
            New SqlParameter("@Address", Address), _
            New SqlParameter("@Address2", Address2), _
            New SqlParameter("@City", City), _
            New SqlParameter("@Province", Province), _
            New SqlParameter("@PostalCode", PostalCode), _
            New SqlParameter("@Country", Country), _
            New SqlParameter("@Phone", Phone), _
            New SqlParameter("@Email", Email), _
            New SqlParameter("@Notify", Notify), _
            New SqlParameter("@Username", Username), _
            New SqlParameter("@Password", Password)))

    End Sub

    Public Function UpdateUser()
        ' see comments under register user, have also made a different version of this "updateuser_New"
        Dim strMsg As String = ""
        UserID = CheckNullNum(SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spUpdateUser", New SqlParameter("@UserID", UserID), _
            New SqlParameter("@Firstname", Firstname), _
            New SqlParameter("@Lastname", Lastname), _
            New SqlParameter("@Address", Address), _
            New SqlParameter("@Address2", Address2), _
            New SqlParameter("@City", City), _
            New SqlParameter("@Province", Province), _
            New SqlParameter("@PostalCode", PostalCode), _
            New SqlParameter("@Country", Country), _
            New SqlParameter("@Phone", Phone), _
            New SqlParameter("@Email", Email), _
            New SqlParameter("@Notify", Notify), _
            New SqlParameter("@Username", Username), _
            New SqlParameter("@Password", Password)))

        If UserID > 0 Then
            strMsg = "Your Account has been updated"
        Else
            strMsg = "An Error occoured in updating your account, please try again"
        End If

        Return strMsg
    End Function

    Public Sub FillProvCountries()

        Dim strSQL As String

        strSQL = "EXEC spKWGetProvinces;EXEC spKWGetCountries;"
        Combos = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSQL)

    End Sub

    Public Sub GetUserRoles()

        Roles = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, _
             "spKWGetUserRoles", New SqlParameter("@UserID", UserID))

    End Sub

    Public Sub GetUser()

        ' not sure about the combos thing, have changed the Spgetuser,
        ' since we are not storing users addresses do we need the combo thing?, that would 
        ' only be for licensee Admin Users

        'Dim strSQL As String

        'strSQL = "EXEC spGetProvinces;EXEC spGetCountries;EXEC spGetUser " & UserID & ";"

        'Combos = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSQL)

        Dim objrdr As SqlDataReader
        objrdr = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spKWgetuser", _
        New SqlParameter("@userID", UserID))

        With objrdr
            While .Read
                Username = .Item("Username").ToString()
                'Password = .Item(2).ToString()
                Firstname = .Item("Firstname").ToString()
                Lastname = .Item("Lastname").ToString()
                'Address = .Item(5).ToString()
                'Address2 = .Item(6).ToString()
                'City = .Item(7).ToString()
                'Province = .Item(8).ToString()
                'PostalCode = .Item(9).ToString()
                'Country = .Item(10).ToString()
                'Phone = .Item(11).ToString()
                Email = .Item("email").ToString()
                ExpiryDate = CheckNullDate(.Item("enddate"))

                'Notify = .Item(13)
            End While
            
        End With

    End Sub

    Public Sub GetSubscribers()
        Roles = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, _
            "spGetSubscribers")
    End Sub
    'CDG specific 
    'need to make sp    

    Public Sub GetSavedSearches()
        savedSearches = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, "spGetSavedSearches", _
           New SqlParameter("@userID", UserID))
    End Sub

    Public Sub GetSavedCharities()
        SavedCharities = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, _
            "spGetSavedCharities", _
            New SqlParameter("@uid", UserID))
    End Sub

    Public Sub GetCustomerReports()
        SavedCharities = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, _
            "spGetCustomerReports", _
            New SqlParameter("@uid", UserID))
    End Sub

    Public Sub ResetPassword(ByVal Stremail)

        ' random password

        Dim password As String = System.Guid.NewGuid().ToString()

        'Remove the hyphens
        password = password.Replace("-", String.Empty)

        password = password.Substring(0, 8)

        ' are we encrypting passwords?  

        'Dim hashedPassword As Byte()
        'Dim encoder As New UTF8Encoding()
        'Dim md5Hasher As New MD5CryptoServiceProvider()
        Dim strReturn As String = ""

        'hashedPassword = md5Hasher.ComputeHash(encoder.GetBytes(Password))


        strReturn = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spResetPassword", New SqlParameter("@Password", password), _
            New SqlParameter("@userID", UserID))


        If Len(strReturn) > 0 Then
            ' need to create message
            Dim emailmessage As New BusinessRules.CEmail()
            With emailmessage
                .Sender = "admin@charitycan.ca"
                .FromName = "CharityCan Support"
                .Recipient = Stremail
                .Subject = "Your Password Has Been Reset"

                .Message = "<p>Your charitycan.ca password has been reset.</p><p><b>Your new password is:</b>" & password & "</b></p><p>Your username is:" & strReturn & "<p/><p>For more information please click on the Help button on the CharityCan Home Page, <a href='http://www.charitycan.ca'>www.charitycan.ca</a>, or telephone or e-mail the CharityCan Help Desk at (705) 325-5552 or admin@charitycan.ca </p>"
                .SendMail()

                .Recipient = "alicia@infrontofthenet.com"
                .SendMail()
            End With
        End If


    End Sub

    Public Function UpdateAdminUser(ByVal modifiedby As Integer) As String
        Dim strReturn As String = ""
        strReturn = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spupdateAdminUser", New SqlParameter("@userID", UserID), _
            New SqlParameter("@password", Password), _
            New SqlParameter("@Email", Email), _
            New SqlParameter("@Fname", Firstname), _
            New SqlParameter("@Lname", Lastname), _
            New SqlParameter("@modifiedBY", modifiedby))

        Return strReturn
    End Function

    Public Function UpdateLicenseeUser(ByVal modifiedby As Integer, ByVal sid As Integer, _
ByVal sendWelcome As Boolean, ByVal companyname As String) As String
        Dim strReturn As String = ""
        strReturn = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spUpdateSubUser", New SqlParameter("@userID", UserID), _
            New SqlParameter("@password", Password), _
            New SqlParameter("@Email", Email), _
            New SqlParameter("@Fname", Firstname), _
            New SqlParameter("@Lname", Lastname), _
            New SqlParameter("@startdate", StartDate), _
            New SqlParameter("@enddate", ExpiryDate), _
               New SqlParameter("@sid", sid), _
                New SqlParameter("@active", Active), _
            New SqlParameter("@modifiedBY", modifiedby), _
            New SqlParameter("@Username", Username)) 'Username param added by Rich June 5 at Anderson's request



        If sendWelcome Then
            Dim emailmessage As New BusinessRules.CEmail()
            With emailmessage
                .Sender = "admin@charitycan.ca"
                .FromName = "CharityCan.ca"
                .Recipient = Email
                .Subject = "Your CharityCan Account Has Been Created"

                Dim straccountinfo As New StringBuilder
                With straccountinfo

                    .Append("Thank you for the payment of your invoice for access to CharityCan. Your account has now been made active. The term of your licensee agreement begins now.  <br/> ")

                    .Append("<h3>Account Details<h3> <br/>")
                    .Append("<strong>Account Name: </strong> ")
                    .Append(CompanyName)
                    .Append("<br/>")

                    .Append("<strong>User Name: </strong> ")
                    .Append(Username)
                    .Append("<br/>")

                    .Append("<strong>Subscription Starts: </strong> ")
                    .Append(StartDate)
                    .Append("<br/>")

                    .Append("<strong>Subscription Expires: </strong> ")
                    .Append(ExpiryDate)
                    .Append("<br/>")

                    .Append("For more information please click on the Help button on the CharityCan Home Page, <a href='https://www.charitycan.ca/default.aspx'>www.charitycan.ca/default.aspx</a>, or telephone or e-mail the CharityCan Help Desk at (705) 325-5552 or admin@charitycan.ca ")

                End With
                .Message = straccountinfo.ToString
                .SendMail()

                .Recipient = "alicia@infrontofthenet.com"
                .SendMail()

                .Recipient = "info@charitycan.ca"
                .SendMail()


            End With
        End If





        Return strReturn
    End Function

    Public Sub saveToFavorites(ByVal bnroot)
        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "SpSaveFav", _
            New SqlParameter("@uid", UserID), New SqlParameter("@bnroot", bnroot))
    End Sub

    Public Sub RemoveFromFavorites(ByVal bnRoot As String)
        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "SpDeleteFav", _
                   New SqlParameter("@uid", UserID), New SqlParameter("@bnroot", bnRoot))


    End Sub

    Public Function Isfavorite(ByVal bnroot As String) As Boolean
        Dim count As Integer
        count = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spCheckUserFav", New SqlParameter("@bnroot", bnroot), _
            New SqlParameter("@userID", UserID))

        If count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GoodUsername(ByVal username As String) As Boolean
        Dim count As Integer
        count = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spCheckUsername", New SqlParameter("@username", username))

        If count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function GoodEmail(ByVal email As String) As Boolean
        Dim count As Integer
        count = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spCheckemail", New SqlParameter("@email", email))

        If count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub GetAdminUsers()
        Roles = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, _
           "spGetAdminUsers")

    End Sub

    Public Function CreateAdminAccount(ByVal createdby As Integer) As String

        Dim strReturn As String = ""

        strReturn = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
            "spCreateAdminUser", New SqlParameter("@Username", Username), _
            New SqlParameter("@Email", Email), _
            New SqlParameter("@Password", Password), _
            New SqlParameter("@ContactFname", Firstname), _
            New SqlParameter("@ContactLname", Lastname), _
            New SqlParameter("@CreatedBY", createdby))

        ' if the record inserts correctly strReturn will be the new licenseeID, if not it will be an error msg

        If IsNumeric(strReturn) Then
            ' need to create message
            Dim emailmessage As New BusinessRules.CEmail()
            With emailmessage
                .Sender = "admin@charitycan.ca"
                .FromName = "CharityCan Admin"
                .Recipient = Email
                .Subject = "Your CharityCan Account Has Been Created"

                .Message = "Your new CharityCan account has been created <br /> Username: " & Username & "<br /> Password: " & Password
                .SendMail()

              
            End With
        End If

        Return strReturn

    End Function

    Public Sub deleteAdminUser()
        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "SpDeleteUser", _
                    New SqlParameter("@uid", UserID))
    End Sub

    Public Sub renewSubscription(ByVal sid As Integer)
        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "sprenewSubscription", _
                   New SqlParameter("@sid", sid))
    End Sub

    Public Function EmailPassword() As String

        Dim strMessage As String

        Dim rdr As SqlDataReader

        Rdr = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, _
            "spForgetPassword", New SqlParameter("@Username", Username))

        With Rdr
            While .Read
                Password = .Item("Password").ToString
                Email = .Item("Email").ToString
            End While

            .Close()
        End With

        If Email = "" Then
            Return "No email address was found that matches the username you provided.  If you have lost your username and password please contact the CharityCan Help Desk at (705) 325-5552 or admin@charitycan.ca"
        Else
            strMessage = "Your charitycan.ca password: <b>" & Password & "</b>."
            CEmail.SendMail("admin@charitycan.ca", "CharityCan Support", "CharityCan: Help Desk", Email, strMessage, "")

            Return "Your password has been sent to the email address associated with your account. </br> If you have any further problems please contact the CharityCan Help Desk at (705) 325-5552 or admin@charitycan.ca"
        End If
    End Function

    Public Function SaveReportUser() As String

        Return SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, _
             "spSaveReportUser", New SqlParameter("@Firstname", Firstname), _
             New SqlParameter("@Lastname", Lastname), _
             New SqlParameter("@Username", Username), _
             New SqlParameter("@Password", Password), _
             New SqlParameter("@Email", Email), _
             New SqlParameter("@Address", Address), _
             New SqlParameter("@City", City), _
             New SqlParameter("@ProvinceID", ProvinceID), _
             New SqlParameter("@CountryID", CountryID), _
             New SqlParameter("@PostalCode", PostalCode), _
             New SqlParameter("@Phone", Phone), _
             New SqlParameter("@uid", UserID))

    End Function

    Public Sub GetCustomer()

        ' not sure about the combos thing, have changed the Spgetuser,
        ' since we are not storing users addresses do we need the combo thing?, that would 
        ' only be for licensee Admin Users

        'Dim strSQL As String

        'strSQL = "EXEC spGetProvinces;EXEC spGetCountries;EXEC spGetUser " & UserID & ";"

        'Combos = SqlHelper.ExecuteDataset(strConn, CommandType.Text, strSQL)

        Dim objrdr As SqlDataReader
        objrdr = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spGetCustomer", _
        New SqlParameter("@userID", UserID))

        With objrdr
            While .Read
                Username = .Item("Username").ToString()
                Password = .Item("Password").ToString()
                Firstname = .Item("Firstname").ToString()
                Lastname = .Item("Lastname").ToString()
                Address = .Item("BillingAddress1").ToString()
                'Address2 = .Item(6).ToString()
                City = .Item("BillingCity").ToString()
                ProvinceID = .Item("BillingProvinceID").ToString()
                PostalCode = .Item("BillingPostal").ToString()
                CountryID = .Item("BillingCountryID").ToString()
                Phone = .Item("BillingPhone").ToString()
                Email = .Item("email").ToString()

                'Notify = .Item(13)
            End While

        End With

    End Sub

    Public Sub saveToDonors(ByVal ID As Integer)
        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "SpSaveDonor", _
            New SqlParameter("@UserID", UserID), New SqlParameter("@DonationID", ID))
    End Sub

    Public Sub RemoveDonor(ByVal ID As Integer)
        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "SpRemoveDonor", _
            New SqlParameter("@UserID", UserID), New SqlParameter("@DonationID", ID))


    End Sub

    Public Sub GetSavedDonors()
        SavedCharities = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, _
            "spGetUserDonors", New SqlParameter("@UserID", UserID))
    End Sub

    Public Sub GetSavedDonorSearches()
        savedSearches = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, "spGetSavedDonorSearches", _
           New SqlParameter("@userID", UserID))
    End Sub

#End Region

End Class
