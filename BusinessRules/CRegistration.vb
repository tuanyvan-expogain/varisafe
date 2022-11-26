Imports System.Data.SqlClient
Imports System.Text

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
    Private mWaitList As Boolean = False
    Private mInternalNotes As String
    Private mAdjustedRate As Decimal = -1

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
    Public Property PromoCode() As String
        Get
            Return mPromoCode
        End Get
        Set(ByVal value As String)
            mPromoCode = value
        End Set
    End Property
    Public Property WaitList() As Boolean
        Get
            Return mWaitList
        End Get
        Set(ByVal value As Boolean)
            mWaitList = value
        End Set
    End Property
    Public Property InternalNotes() As String
        Get
            Return mInternalNotes
        End Get
        Set(value As String)
            mInternalNotes = value
        End Set
    End Property
    Public Property AdjustedRate As Decimal
        Get
            Return mAdjustedRate
        End Get
        Set(value As Decimal)
            mAdjustedRate = value
        End Set
    End Property

#End Region

#Region "Methods"

    Sub SearchRegistrations(ByVal CourseTypeID As Integer, ByVal cy As String, ByVal StartDate As String, ByVal EndDate As String, ByVal fname As String, ByVal lname As String, ByVal em As String, ByVal ph As String, ByVal rid As Integer, ByVal WaitStatus As Integer)

        CourseDS = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, "spSearchRegistrations",
            New SqlParameter("@CourseTypeID", CourseTypeID),
            New SqlParameter("@City", cy),
            New SqlParameter("@StartDate", StartDate),
            New SqlParameter("@EndDate", EndDate),
            New SqlParameter("@FirstName", fname),
            New SqlParameter("@LastName", lname),
            New SqlParameter("@Email", em),
            New SqlParameter("@Phone", ph),
            New SqlParameter("@RegistrationID", rid),
            New SqlParameter("@WaitList", WaitStatus))

    End Sub

    Sub GetDuplicates()

        CourseDS = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, "spGetDuplicates")

    End Sub

    Sub SearchRegistrationsByCourseID()

        CourseDS = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, "spSearchRegistrationsByCourseID", _
            New SqlParameter("@CourseID", CourseID))

    End Sub

    Sub SaveRegistration()

        Dim rid As Integer = RegistrationID

        RegistrationID = CheckNullNum(SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, "spSaveRegistration",
            New SqlParameter("@RegistrationID", RegistrationID),
            New SqlParameter("@CourseID", CourseID),
            New SqlParameter("@FirstName", FirstName),
            New SqlParameter("@LastName", LastName),
            New SqlParameter("@School", School),
            New SqlParameter("@Age", Age),
            New SqlParameter("@Allergies", Allergies),
            New SqlParameter("@Health", Health),
            New SqlParameter("@Comments", Comments),
            New SqlParameter("@ParentFirst", ParentFirst),
            New SqlParameter("@ParentLast", ParentLast),
            New SqlParameter("@EmergPhone", EmergPhone),
            New SqlParameter("@Email", Email),
            New SqlParameter("@Phone", Phone),
            New SqlParameter("@City", City),
            New SqlParameter("@Address", Address),
            New SqlParameter("@Address2", Address2),
            New SqlParameter("@Province", Province),
            New SqlParameter("@PostalCode", PostalCode),
            New SqlParameter("@PromoCode", PromoCode),
            New SqlParameter("@WaitList", WaitList),
            New SqlParameter("@InternalNotes", InternalNotes),
            New SqlParameter("@AdjustedRate", AdjustedRate)))

        If rid = 0 And RegistrationID > 0 Then
            'New reg, so send emails
            If WaitList Then
                SendWaitEmail()
            Else
                SendRegEmail(False)
            End If
        End If

    End Sub

    Sub SendRegEmail(ByVal Remind As Boolean)

        ' XXXXXXXX XXXXXX XXXXX
        'Meeting room XXXXXX~ look for our signs!

        Dim objC As New CCourse

        objC.CourseID = CourseID
        objC.GetCourse()

        Dim strDoll As String = ""
        Dim strTeam As String = "Home Alone and Stranger Safety Team"
        Dim strCheckin As String = ""
        Dim strTime As DateTime
        Dim strMap As String = ""
        Dim strCourse As String = "Home Alone and Stranger Safety"
        Dim strCourse1 As String = "preparing yourself to stay home alone"
        Dim strIntro As String = "Your registration has been accepted and you are "
        Dim strBuilding As String = ""
        Dim strAdditional As String = ""

        If Remind Then
            strIntro = "This is a friendly reminder that you are "
        End If

        strTime = DateTime.Parse(objC.StartTime) ', DateFormat.ShortTime, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal)
        strTime = strTime.AddMinutes(-30)
        strCheckin = strTime.ToString

        strCheckin = Mid(strCheckin, InStr(strCheckin, " ") + 1)
        strCheckin = strCheckin.Replace(":00 ", " ").ToLower

        If objC.CourseTypeID = 1 Then
            strDoll = "<li>Doll or an infant sized toy (teddy bear) to use as your baby for demonstrations.</li>"
            strTeam = "The Kid Sitters Canada Team"
            strCourse = "Babysitters"
            strCourse1 = "Babysitting"
        End If

        If objC.MapLink <> "" Then
            strMap = "<br />Google Map Link: <a href=""" & objC.MapLink & """>" & objC.MapLink & "</a>"
        End If

        If objC.Building <> "" Then
            strBuilding = "<br />" + objC.Building
        End If

        If objC.AdditionalInfo <> "" Then
            strAdditional = "<p>Additional Information: " & objC.AdditionalInfo & "</p>"
        End If

        Dim strBody As String = "<p>Hi there,</p><p>&nbsp;</p>" &
            "<p>" & strIntro & "confirmed to attend the <u>Vari SAFE Education</u> " &
           strCourse + " Training Course in <u><strong>" & objC.City & "</strong></u> on <strong>" & FormatDateTime(objC.CourseDate, DateFormat.LongDate) & "</strong>.</p><p>&nbsp;</p>" &
            "<p>This confirmation email will include an outline of the course details, how to pay and what to bring. " &
            "Please write down this information or print off a copy for your records.</p>" & strAdditional & "<p>&nbsp;</p>" &
            "<p><u><strong>Course Details</strong></u></p><p>&nbsp;</p>" &
            "<p>" & FormatDateTime(objC.CourseDate, DateFormat.LongDate) & "<br />" &
            objC.City & ", ON<br />" &
            objC.CourseTime & "</p><p>&nbsp;</p>" &
            "<p><u><strong>Location</strong></u></p><p>&nbsp;</p>" &
            "<p><u>" & objC.Location & "</u>" & strMap & strBuilding & strAdditional & "</p><p>&nbsp;</p>" &
            "<p><u><strong>Times</strong></u></p><p>&nbsp;</p>" &
            "<p><u>Check in:</u> Please arrive anytime between " & strCheckin & " and " & objC.StartTime & ".<br />" &
            "Course begins right at " & objC.StartTime & " and finishes at " & objC.EndTime & " sharp.</p><p>&nbsp;</p>" &
            "<p><em>Please note: We currently do not offer an early drop off/ late pick up service. Please arrange transportation for your child to and from the course.</em></p>" &
            "<p><p>&nbsp;</p><u><strong>Payment</strong></u></p><p>&nbsp;</p>" &
            "<p>The course fee is $61.95 plus HST (total cost is $70.00, per student). Please pay with cash the morning of the course. Please request a tax receipt upon payment should you require one.</p><p>&nbsp;</p>" &
            "<p><em>Please note: We apologize but we are unable to accept cheques or credit cards at this time. Due to the large number of declined cards and NSF cheques we can only accept cash payments.</em></p><p>&nbsp;</p>" &
            "<p><u><strong>What to bring</strong></u></p><p>&nbsp;</p>" &
            "<ul><li>Writing and note taking supplies (pen or pencil).</li>" &
            "<li>Markers and/or pencil crayons (optional).</li>" & strDoll &
            "<li>Lunch, including snacks and drinks. Please pack a nut free lunch due to the risk of nut allergies.</li></ul>" &
            "<p>Congratulations on taking the first step in " + strCourse1 + "! We are excited to have you in our class and look forward to meeting you soon. Please contact us if you have any questions.</p><p>&nbsp;</p>" &
            "<p><a href=""http://www.facebook.com/VariSAFE"">Like us on Facebook</a> or " &
            "<a href=""hhttps://www.instagram.com/vari_safe_education_/"">follow us on Instagram</a> for your chance to win a free course with Vari SAFE Education!</p>" &
            "<p>Kindest regards,</p><p>&nbsp;</p>" &
            "<p><em>" & strTeam & "</em><br />" &
            "<p><strong>Vari SAFE Education</strong></p>" &
            "<p><a href=""mailto:register@varisafe.ca"">register@varisafe.ca</a><br />" &
            "<a href=""www.varisafe.ca"">www.varisafe.ca</a></p>"

        Address2 = strBody
        CEmail.SendMail("register@varisafe.ca", "Vari SAFE Education", "Vari SAFE Registration Confirmation", Email, strBody, "")

    End Sub

    Sub SendWaitEmail()

        ' XXXXXXXX XXXXXX XXXXX
        'Meeting room XXXXXX~ look for our signs!

        Dim objC As New CCourse

        objC.CourseID = CourseID
        objC.GetCourse()

        Dim strDoll As String = ""
        Dim strTeam As String = "Home Alone and Stranger Safety Team"
        Dim strCheckin As String = ""
        Dim strTime As DateTime
        Dim strMap As String = ""
        Dim strCourse As String = "Home Alone and Stranger Safety"
        Dim strCourse1 As String = strCourse

        strTime = DateTime.Parse(objC.StartTime) ', DateFormat.ShortTime, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal)
        strTime = strTime.AddMinutes(-30)
        strCheckin = strTime.ToString

        strCheckin = Mid(strCheckin, InStr(strCheckin, " ") + 1)
        strCheckin = strCheckin.Replace(":00 ", " ").ToLower

        If objC.CourseTypeID = 1 Then
            strDoll = "<li>Doll or an infant sized toy (teddy bear) to use as your baby for demonstrations.</li>"
            strTeam = "The Kid Sitters Canada Team"
            strCourse = "Babysitters"
            strCourse1 = "Babysitting"
        End If

        If objC.MapLink <> "" Then
            strMap = "<br />Google Map Link: <a href=""" & objC.MapLink & """>" & objC.MapLink & "</a>"
        End If

        Dim strBody As String = "<p>Hi there,</p><p>&nbsp;</p>" &
            "<p>Your registration has been added to our Waiting List for the the <u>Vari SAFE Education</u> " &
           strCourse + " Training Course in <strong><u>" & objC.City & "</u></strong> on <strong>" & FormatDateTime(objC.CourseDate, DateFormat.LongDate) & "</strong>.</p><p>&nbsp;</p>" &
            "<p>We do limit our class sizes to maintain a safe, and effective learning environment with increased " +
            "student to instructor interaction.</p><p>&nbsp;</p>" +
            "<p>We will hold your registration request in queue, and in the event of a cancellation – we will provide you " +
            "with a confirmation email if a space should become available for your student.  Cancellations may occur, " +
            "however they are generally during the week leading up to the course date.</p><p>&nbsp;</p>" &
            "<p><u><strong>Course Details</strong></u></p><p>&nbsp;</p>" &
            "<p>" & FormatDateTime(objC.CourseDate, DateFormat.LongDate) & "<br />" &
            objC.City & ", ON<br />" &
            objC.CourseTime & "</p><p>&nbsp;</p>" &
            "<p><strong><u>Location</strong></u></p><p>&nbsp;</p>" &
            "<p><u>" & objC.Location & "</u>" & strMap & "</p><p>&nbsp;</p>" &
            "<p><a href=""http://www.facebook.com/VariSAFE"">Like us on Facebook</a> or " &
            "<a href=""https://www.instagram.com/vari_safe_education_/"">follow us on Instagram</a> for your chance to win a free course with Vari SAFE Education!</p>" &
            "<p>Kindest regards,</p><p>&nbsp;</p>" &
            "<p><em>" & strTeam & "</em><br />" &
            "<p><strong>Vari SAFE Education</strong></p>" &
            "<p><a href=""mailto:register@varisafe.ca"">register@varisafe.ca</a><br />" &
            "<a href=""www.varisafe.ca"">www.varisafe.ca</a></p>"

        Address2 = strBody
        CEmail.SendMail("register@varisafe.ca", "Vari SAFE Education", "Vari SAFE Waiting List Confirmation", Email, strBody, "")

    End Sub

    Sub DeleteRegistration()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "spDeleteRegistration", _
            New SqlParameter("@RegistrationID", RegistrationID))

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

                If Not IsDBNull(.Item("WaitList")) Then
                    WaitList = .Item("WaitList")
                End If

                InternalNotes = .Item("InternalNotes").ToString

                If Not IsDBNull(.Item("AdjustedRate")) Then
                    AdjustedRate = CheckNullNum(.Item("AdjustedRate"))
                End If
            End While
        End With
    End Sub

    Sub Activate()

        SqlHelper.ExecuteNonQuery(strConn, CommandType.StoredProcedure, "spActivateRegistration", _
            New SqlParameter("@RegistrationID", RegistrationID))

        'Fill email & course property
        GetRegistration()

        SendRegEmail(False)
        Regs.Close()

    End Sub

    Sub SendReminders()

        SearchRegistrationsByCourseID()

        With CourseDS.Tables(0)
            Dim i As Integer

            For i = 0 To .Rows.Count - 1
                Email = .Rows(i).Item("Email").ToString

                If .Rows(i).Item("WaitList").ToString <> "True" Then
                    'Dim x As String = "x"
                    SendRegEmail(True)
                End If

            Next
        End With

        CourseDS.Dispose()

    End Sub

    Function GetEmailList() As String

        Dim strEmailList As New StringBuilder()

        CourseDS = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, "spSearchRegistrationsByCourseID",
            New SqlParameter("@CourseID", CourseID))

        With CourseDS.Tables(0)
            Dim i As Integer

            For i = 0 To .Rows.Count - 1
                strEmailList.Append(.Rows(i).Item("Email").ToString() & "; ")
            Next
        End With

        Return strEmailList.ToString()

    End Function

    Function CopyRegistration() As Integer

        Dim NewRegID As Integer

        NewRegID = SqlHelper.ExecuteScalar(strConn, CommandType.StoredProcedure, "spCopyRegistration",
            New SqlParameter("@RegistrationID", RegistrationID),
            New SqlParameter("@CourseID", CourseID))

        'If new course is active, send confirmation email
        If CourseID <> 4364 Then
            GetRegistration()
            SendRegEmail(False)
        End If

        Return NewRegID

    End Function
#End Region

End Class
