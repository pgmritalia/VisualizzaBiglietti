Imports System.Globalization

Public Class Site_Mobile
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs)

    End Sub

    Protected Sub flagMobileEn_Click(sender As Object, e As ImageClickEventArgs) Handles flagMobileEn.Click
        Session("Lang") = "en-EN"
        Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(Session("Lang").ToString())
        Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo(Session("Lang").ToString())
        Response.Redirect(Request.UrlReferrer.AbsoluteUri)
    End Sub

    Protected Sub flagMobileIt_Click(sender As Object, e As ImageClickEventArgs) Handles flagMobileIt.Click
        Session("Lang") = "it-IT"
        Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(Session("Lang").ToString())
        Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo(Session("Lang").ToString())
        Response.Redirect(Request.UrlReferrer.AbsoluteUri)
    End Sub
End Class