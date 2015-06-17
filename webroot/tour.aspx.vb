
Partial Class tour
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            Select Case Request.QueryString("t")
                Case ""
                    Me.imgTour.ImageUrl = "~/images/tour-1.jpg"
                    Me.hlTour.NavigateUrl = "tour.aspx?t=2"
                Case "2"
                    Me.imgTour.ImageUrl = "~/images/tour-2.jpg"
                    Me.hlTour.NavigateUrl = "tour.aspx?t=3"
                Case "3"
                    Me.imgTour.ImageUrl = "~/images/tour-3.jpg"
                    Me.hlTour.NavigateUrl = "tour.aspx?t=4"
                Case "4"
                    Me.imgTour.ImageUrl = "~/images/tour-4.jpg"
                    Me.hlTour.NavigateUrl = "tour.aspx?t=5"
                Case "5"
                    Me.imgTour.ImageUrl = "~/images/tour-5.jpg"
                    Me.hlTour.NavigateUrl = "tour.aspx?t=6"
                Case "6"
                    Me.imgTour.ImageUrl = "~/images/tour-6.jpg"
                    Me.hlTour.Text = "Create your account"
                    Me.hlTour.NavigateUrl = "create-single-step1.aspx"
            End Select
        End If
    End Sub
End Class
