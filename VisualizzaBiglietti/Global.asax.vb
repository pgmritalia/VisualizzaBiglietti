Imports System.Globalization
Imports System.Threading
Imports System.Web.Optimization

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Generato all'avvio dell'applicazione
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub

    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        Dim cultureName As String = "it-IT"
        If HttpContext.Current.Session IsNot Nothing AndAlso TypeOf HttpContext.Current.Session("Lang") Is String Then cultureName = HttpContext.Current.Session("Lang")
        If Thread.CurrentThread.CurrentUICulture.Name = cultureName Then Return
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(cultureName)
        Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture
    End Sub
End Class