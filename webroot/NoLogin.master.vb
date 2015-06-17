
Partial Class NoLogin
    Inherits System.Web.UI.MasterPage


    Private Function ImageChooser() As String
        Dim imgChooser As Integer = CInt(Now.ToOADate) Mod 300
        Select Case imgChooser
            Case 0 To 30
                Return "a"
            Case 31 To 60
                Return "b"
            Case 61 To 90
                Return "c"
            Case 91 To 120
                Return "d"
            Case 121 To 150
                Return "e"
            Case 151 To 180
                Return "f"
            Case 181 To 210
                Return "g"
            Case 211 To 240
                Return "h"
            Case 241 To 270
                Return "i"
            Case Else
                Return "j"
        End Select
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.imgHeader.ImageUrl = "images/dn2_05" & ImageChooser() & ".jpg"
    End Sub
End Class

