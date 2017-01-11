Imports System.Data.SqlClient

Public Class CCourse

#Region "Members"

    Private mCourseID As Integer
    Private mCourseTypeID As Integer
    Private mCity As String
    Private mCourseDate As DateTime
    Private mCourseTime As String
    Private mCapacity As Integer
    Private mCourseName As String
    Private mLocation As String
    Private mMapLink As String
    Private mCourses As SqlDataReader
    Private mCourseDS As DataSet
    Private mStartTime As String
    Private mEndTime As String

#End Region

#Region "Constructor"

    Public Sub New()
        MyBase.New()
    End Sub

#End Region

#Region "Properties"

    Public Property CourseID() As Integer
        Get
            Return mCourseID
        End Get
        Set(ByVal value As Integer)
            mCourseID = value
        End Set
    End Property
    Public Property CourseTypeID() As Integer
        Get
            Return mCourseTypeID
        End Get
        Set(ByVal value As Integer)
            mCourseTypeID = value
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
    Public Property CourseDate() As DateTime
        Get
            Return mCourseDate
        End Get
        Set(ByVal value As DateTime)
            mCourseDate = value
        End Set
    End Property
    Public Property CourseTime() As String
        Get
            Return mCourseTime
        End Get
        Set(ByVal value As String)
            mCourseTime = value
        End Set
    End Property
    Public Property Capacity() As Integer
        Get
            Return mCapacity
        End Get
        Set(ByVal value As Integer)
            mCapacity = value
        End Set
    End Property
    Public Property CourseName() As String
        Get
            Return mCourseName
        End Get
        Set(ByVal value As String)
            mCourseName = value
        End Set
    End Property
    Public Property Location() As String
        Get
            Return mLocation
        End Get
        Set(ByVal value As String)
            mLocation = value
        End Set
    End Property
    Public Property MapLink() As String
        Get
            Return mMapLink
        End Get
        Set(ByVal value As String)
            mMapLink = value
        End Set
    End Property
    Public Property Courses() As SqlDataReader
        Get
            Return mCourses
        End Get
        Set(ByVal value As SqlDataReader)
            mCourses = value
        End Set
    End Property
    Public Property CourseDS() As DataSet
        Get
            Return mCourseDS
        End Get
        Set(ByVal value As DataSet)
            mCourseDS = value
        End Set
    End Property
    Public Property StartTime() As String
        Get
            Return mStartTime
        End Get
        Set(ByVal value As String)
            mStartTime = value
        End Set
    End Property
    Public Property EndTime() As String
        Get
            Return mEndTime
        End Get
        Set(ByVal value As String)
            mEndTime = value
        End Set
    End Property
#End Region

#Region "Methods"

    Sub GetCourses()

        Courses = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spGetAllCourses")

    End Sub

    Sub SaveCourse()

    End Sub

    Sub DeleteCourse()

    End Sub

    Sub GetCourse()

        Courses = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spGetCourse", _
            New SqlParameter("@CourseID", CourseID))

        With Courses
            While .Read
                coursedate = .Item("CourseDate")
                CourseTypeID = CheckNullNum(.Item("CourseTypeID"))
                City = .Item("City").ToString
                StartTime = .Item("StartTime").ToString
                EndTime = .Item("EndTime").ToString
                CourseName = .Item("CourseName").ToString
                MapLink = .Item("MapLink").ToString
                Capacity = CheckNullNum(.Item("Capacity"))
                Location = .Item("Location").ToString
            End While
            .Close()
        End With

    End Sub

    Sub GetCoursesAndCities()

        CourseDS = SqlHelper.ExecuteDataset(strConn, CommandType.StoredProcedure, "spGetCoursesAndCities")

    End Sub

    Sub GetUpcoming()

        Courses = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spGetUpcoming")

    End Sub

    Sub SearchUpcomingByCity()

        Courses = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spSearchCourses", _
            New SqlParameter("@CourseTypeID", CourseTypeID), _
            New SqlParameter("@City", City))

    End Sub

    Sub GetRegions()

        Courses = SqlHelper.ExecuteReader(strConn, CommandType.StoredProcedure, "spGetRegions")

    End Sub

#End Region

End Class
