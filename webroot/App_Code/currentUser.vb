Imports Facebook
Imports System.Collections.Generic

Public Class currentUser
    Private _id As Integer
    Private _firstname As String
    Private _profilepic As String
    Private _lastname As String
    Private _fullname As String
    Private _dateadded As Date
    Private _user As Facebook.Entity.User

#Region "Properties"
    Public Property User() As Facebook.Entity.User
        Get
            Return _user
        End Get
        Set(ByVal value As Facebook.Entity.User)
            _user = value
        End Set
    End Property
    Public Property ProfilePic() As String
        Get
            Return _profilepic
        End Get
        Set(ByVal value As String)
            _profilepic = value
        End Set
    End Property
    Public Property FullName() As String
        Get
            Return _fullname
        End Get
        Set(ByVal value As String)
            _fullname = value
        End Set
    End Property
    Public Property Firstname() As String
        Get
            Return _firstname
        End Get
        Set(ByVal value As String)
            _firstname = value
        End Set
    End Property

    Public Property Lastname() As String
        Get
            Return _lastname
        End Get
        Set(ByVal value As String)
            _lastname = value
        End Set
    End Property


    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property DateAdded() As Date
        Get
            Return _dateadded
        End Get
        Set(ByVal value As Date)
            _dateadded = value
        End Set
    End Property

#End Region

    Public Sub New(ByVal pUser As Entity.User)
        'this is used when a user logs in because we may need to create a new user
        User = pUser
        ID = pUser.UserId
        Firstname = pUser.FirstName
        Lastname = pUser.LastName
        FullName = pUser.Name
        ProfilePic = pUser.PictureSmallUrl.ToString
    End Sub



End Class

