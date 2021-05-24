Imports System.Globalization
Imports System.Resources
Imports MySql.Data.MySqlClient

Public Class _Default
    Inherits Page

    Private Const IpServerCassaNw As String = "10.10.0.7"
    Private Const UserNameDBCassaNw As String = "BigliettiSMS"
    Private Const PasswordDbCassaNw As String = "B!gliett!SmS2021*"
    Private Const DatabaseCassaNw As String = "cassanuova"

    Dim rm As ResourceManager
    Dim ci As CultureInfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        'da decommentare in fase di test
        paramTel.Value = Request.Item("NumTel")
        paramIdMan.Value = Request.Item("IdMan")

        'paramTel.Value = "3288283546"
        'paramIdMan.Value = "CJ30"


        If HttpContext.Current.Session("Lang") Is Nothing Then
            HttpContext.Current.Session.Add("Lang", Request.UserLanguages(0))
        End If

        Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(HttpContext.Current.Session("Lang").ToString())
        Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo(HttpContext.Current.Session("Lang").ToString())
        paramLoading.Value = GetGlobalResourceObject("ticket", MyResources._default.loading)


        litBiglietto.Text = GetGlobalResourceObject("ticket", MyResources._default.numBiglietto)
        litNome.Text = GetGlobalResourceObject("ticket", MyResources._default.nome)
        litCognome.Text = GetGlobalResourceObject("ticket", MyResources._default.cognome)
        litConferma.Text = GetGlobalResourceObject("ticket", MyResources._default.conferma)
        litDisplay.Text = GetGlobalResourceObject("ticket", MyResources._default.compilacampi)
    End Sub
End Class