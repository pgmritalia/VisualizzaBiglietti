Imports System.Globalization

Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub flagUk_Click(sender As Object, e As ImageClickEventArgs) Handles flagUk.Click
        'Session("Lang") = "en-EN"
        If HttpContext.Current.Session("Lang") IsNot Nothing Then
            HttpContext.Current.Session.Remove("Lang")
        End If
        HttpContext.Current.Session.Add("Lang", "en-EN")
        Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(Session("Lang").ToString())
        Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo(Session("Lang").ToString())
        Response.Redirect(Request.UrlReferrer.AbsoluteUri)
    End Sub

    Protected Sub flagIt_Click(sender As Object, e As ImageClickEventArgs) Handles flagIt.Click
        'Session("Lang") = "it-IT"
        If HttpContext.Current.Session("Lang") IsNot Nothing Then
            HttpContext.Current.Session.Remove("Lang")
        End If
        HttpContext.Current.Session.Add("Lang", "it-IT")
        Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(Session("Lang").ToString())
        Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo(Session("Lang").ToString())
        Response.Redirect(Request.UrlReferrer.AbsoluteUri)
    End Sub
End Class