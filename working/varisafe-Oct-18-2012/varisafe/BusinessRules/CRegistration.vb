Imports System.Data.SqlClient

Public Class CRegistration

#Region "Members"

    Private mRegistrationID As Integer
    Private mCourseID As Integer
    Private mFirstName As String
    Private mLastName As String
    Private mAge As Integer
    Private mSchool As String
    Private mAllergies As String
    Private mHealth As String
    Private mComments As String
    Private mParentFirst As String
    Private mParentLast As String
    Private mEmergPhone As String
    Private mEmail As String
    Private mPhone As String
    Private mCity As String
    Private mAddress As String
    Private mAddress2 As String
    Private mProvince As String
    Private mPostalCode As String
    Private mRegs As SqlDataReader
    Private mRegDS As DataSet
    Private mRegDate As DateTime
    Private mPromoCode As String

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()
    End Sub

#End Region

#Region "Properties"

    Public Property RegistrationID() As Integer
        Get
            Return mRegistrationID
        End Get
        Set(ByVal value As Integer)
            mRegistrationID = value
        End Set
    End Property
    Public Property CourseID() As Integer
        Get
            Return mCourseID
        End Get
        Set(ByVal value As Integer)
            mCourseID = value
        End Set
    End Property
    Public Property FirstName() As String
        Get
            Return mFirstName
        End Get
        Set(ByVal value As String)
            mFirstName = value
        End Set
    End Property
    Public Property LastName() As String
        Get
            Return mLastName
        End Get
        Set(ByVal value As String)
            mLastName = value
        End Set
    End Property
    Public Property Age() As Integer
        Get
            Return mAge
        End Get
        Set(ByVal value As Integer)
            mAge = value
        End Set
    End Property
    Public Property School() As String
        Get
            Return mSchool
        End Get
        Set(ByVal value As String)
            mSchool = value
        End Set
    End Property
    Public Property Allergies() As String
        Get
            Return mAllergies
        End Get
        Set(ByVal value As String)
            mAllergies = value
        End Set
    End Property
    Public Property Health() As String
        Get
            Return mHealth
        End Get
        Set(ByVal value As String)
            mHealth = value
        End Set
    End Property
    Public Property Comments() As String
        Get
            Return mComments
        End Get
        Set(ByVal value As String)
            mComments = value
        End Set
    End Property
    Public Property ParentFirst() As String
        Get
            Return mParentFirst
        End Get
        Set(ByVal value As String)
            mParentFirst = value
        End Set
    End Property
    Public Property ParentLast() As String
        Get
            Return mParentLast
        End Get
        Set(ByVal value As String)
            mParentLast = value
        End Set
    End Property
    Public Property EmergPhone() As String
        Get
            Return mEmergPhone
        End Get
        Set(ByVal value As String)
            mEmergPhone = value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return mEmail
        End Get
        Set(ByVal value As String)
            mEmail = value
        End Set
    End Property
    Public Property Phone() As String
        Get
            Return mPhone
        End Get
        Set(ByVal value As String)
            mPhone = value
        End Set
    End Property
    Public Property City() As String
        Get
            Return mCity
        End Get
        Set(ByVal value As String)
            mCity = value
        End Set
    End Property

    Public Property Address() As String
        Get
            Return mAddress
        End Get
        Set(ByVal value As String)
            mAddress = value
        End Set
    End Property
    Public Property Address2() As String
        Get
            Return mAddress2
        End Get
        Set(ByVal value As String)
            mAddress2 = value
        End Set
    End Property
    Public Property Province() As String
        Get
            Return mProvince
        End Get
        Set(ByVal value As String)
            mProvince = value
        End Set
    End Property
    Public Property PostalCode() As String
        Get
            Return mPostalCode
        End Get
        Set(ByVal value As String)
            mPostalCode = value
        End Set
    End Property
    Public Property Regs() As SqlDataReader
        Get
            Return mRegs
        End Get
        Set(ByVal value As SqlDataReader)
            mRegs = value
        End Set
    End Property
    Public Property CourseDS() As DataSet
        Get
            Return mRegDS
        End Get
        Set(ByVal value As DataSet)
            mRegDS = value
        End Set
    End Property
    Public Property RegDate() As DateTime
        Get
            Return mRegDate
        End Get
        Set(ByVal value As DateTime)
            mRegDate = value
        End Set
    End Property
    Public Property PromoCode() As DateTime
        Get
            Return mPromoCode
        End Get
        Set(ByVal value As DateTime)
            mPromoCode = value
        End Set
    End Property

#End Region

#Region "Methods"

    Sub SearchRegistrations(ByVal CourseTypeID As Integer, ByVal cy As String, ByVal StartDate As String, ByVal EndDate As String, ByVal fname As String, ByVal lname As String, ByVal em As String)

        CourseDS = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, "spSearchRegistrations", _
            New SqlParameter("@CourseTypeID", CourseTypeID), _
            New SqlParameter("@City", cy), _
            New SqlParameter("@StartDate", StartDate), _
            New SqlParameter("@EndDate", EndDate), _
            New SqlParameter("@FirstName", fname), _
            New SqlParameter("@LastName", lname), _
            New SqlParameter("@Email", em))

    End Sub

    Sub SearchRegistrationsByCourseID()

        CourseDS = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, "spSearchRegistrationsByCourseID", _
            New SqlParameter("@CourseID", CourseID))

    End Sub

    Sub SaveRegistration()

        Dim rid As Integer = RegistrationID

        RegistrationID = CheckNullNum(SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, "spSaveRegistration", _
            New SqlParameter("@RegistrationID", RegistrationID), _
            New SqlParameter("@CourseID", CourseID), _
            New SqlParameter("@FirstName", FirstName), _
            New SqlParameter("@LastName", LastName), _
            New SqlParameter("@School", School), _
            New SqlParameter("@Age", Age), _
            New SqlParameter("@Allergies", Allergies), _
            New SqlParameter("@Health", Health), _
            New SqlParameter("@Comments", Comments), _
            New SqlParameter("@ParentFirst", ParentFirst), _
            New SqlParameter("@ParentLast", ParentLast), _
            New SqlParameter("@EmergPhone", EmergPhone), _
            New SqlParameter("@Email", Email), _
            New SqlParameter("@Phone", Phone), _
            New SqlParameter("@City", City), _
            New SqlParameter("@Address", Address), _
            New SqlParameter("@Address2", Address2), _
            New SqlParameter("@Province", Province), _
            New SqlParameter("@PostalCode", PostalCode), _
            New SqlParameter("@PromoCode", PromoCode)))

        If rid = 0 And RegistrationID > 0 Then
            'New reg, so send emails
            SendRegEmail()
        End If

    End Sub

    Sub SendRegEmail()

        ' XXXXXXXX XXXXXX XXXXX
        'Meeting room XXXXXX~ look for our signs!

        Dim objC As New CCourse

        objC.CourseID = 2 'CourseID
        objC.GetCourse()

        Dim strDoll As String = ""
        Dim strTeam As String = "Home Alone and Stranger Safety Team"
        Dim strCheckin As String = ""
        Dim strTime As DateTime
        Dim strMap As String = ""

        strTime = DateTime.Parse(objC.StartTime) ', DateFormat.ShortTime, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal)
        strTime = strTime.AddMinutes(-30)
        strCheckin = strTime.ToString

        strCheckin = Mid(strCheckin, InStr(strCheckin, " ") + 1)
        strCheckin = strCheckin.Replace(":00 ", " ").ToLower

        If objC.CourseTypeID = 1 Then
            strDoll = "<li>Doll or an infant sized toy (teddy bear) to use as your baby for demonstrations.</li>"
            strTeam = "The Kid Sitters Canada Team"
        End If

        If objC.MapLink <> "" Then
            strMap = "<br />Google Map Link: <a href=""" & objC.MapLink & """>" & objC.MapLink & "</a>"
        End If

        Dim strBody As String = "<p>Hi there,</p>" & _
            "Your registration has been accepted and you are now confirmed to attend the Vari SAFE Education " & _
            "XXXXXXXXXXXX Training Course in " & objC.City & " on " & FormatDateTime(objC.CourseDate, DateFormat.LongDate) & ".</p>" & _
            "<p>This confirmation email will include an outline of the course details, how to pay and what to bring. " & _
            "Please write down this information or print off a copy for your records.</p>" & _
            "<p><strong>Course Details</strong></p>" & _
            "<p>" & FormatDateTime(objC.CourseDate, DateFormat.LongDate) & "<br />" & _
            objC.City & ", ON<br />" & _
            objC.CourseTime & "</p>" & _
            "<p><strong>Location</strong></p>" & _
            "<p>" & objC.Location & strMap & "</p>" & _
            "<p><strong>Times</strong></p>" & _
            "<p>Check in: Please arrive anytime between " & strCheckin & " and " & objC.StartTime & ".<br />" & _
            "Course begins right at " & objC.StartTime & " and finishes at " & objC.EndTime & " sharp.</p>" & _
            "<p>Please note: We currently do not offer an early drop off/ late pick up service. Please arrange transportation for your child to and from the course.</p>" & _
            "<p><strong>Payment</strong></p>" & _
            "<p>The course fee is $53.10 plus HST (total cost is $60.00, per student). Please pay with cash the morning of the course. Please request a tax receipt upon payment should you require one.</p>" & _
            "<p>Please note: We apologize but we are unable to accept cheques or credit cards at this time. Due to the large number of declined cards and NSF cheques we can only accept cash payments.</p>" & _
            "<p><strong>What to bring</strong></p>" & _
            "<ul><li>Writing and note taking supplies (pen or pencil).</li>" & _
            "<li>Markers and/or pencil crayons (optional).</li>" & strDoll & _
            "<li>Lunch, including snacks and drinks. Please pack a nut free lunch due to the risk of nut allergies.</li></ul>" & _
            "<p>Congratulations on taking the first step in XXXXXXXXXXXXXXXX! We are excited to have you in our class and look forward to meeting you soon. Please contact us if you have any questions.</p>" & _
            "<p>Kindest regards,</p>" & _
            "<p>" & strTeam & "<br />" & _
            "<p>Vari SAFE Education</p>" & _
            "<p><a href=""mailto:admin@varisafe.ca"">admin@varisafe.ca</a><br />" & _
            "<a href=""www.varisafe.ca"">www.varisafe.ca</a></p>"

        Address2 = strBody

    End Sub

    Sub DeleteCourse()

    End Sub

    Sub GetRegistration()

        Regs = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spGetRegistration", _
            New SqlParameter("@RegistrationID", RegistrationID))

        With Regs
            While .Read
                CourseID = CheckNullNum(.Item("CourseID"))
                FirstName = .Item("FirstName").ToString
                LastName = .Item("LastName").ToString
                School = .Item("SchoolType").ToString
                Age = CheckNullNum(.Item("Age"))
                Allergies = .Item("Allergies").ToString
                Health = .Item("Health").ToString
                Comments = .Item("Comments").ToString
                ParentFirst = .Item("ParentFirst").ToString
                ParentLast = .Item("ParentLast").ToString
                EmergPhone = .Item("EmergPhone").ToString
                Email = .Item("Email").ToString
                Phone = .Item("Phone").ToString
                City = .Item("City").ToString
                Address = .Item("Address").ToString
                Address2 = .Item("Address2").ToString
                Province = .Item("Province").ToString
                PostalCode = .Item("PostalCode").ToString
                RegDate = CheckNullDate(.Item("RegDate").ToString)
                PromoCode = .Item("PromoCode").ToString
            End While
        End With
    End Sub

#End Region

End Class
