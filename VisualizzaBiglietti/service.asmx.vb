Imports System.ComponentModel
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class service
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function GetTickets(NumTel As String, IdMan As String) As TicketViewModel
        Dim model As New TicketViewModel With {
            .exception = False
        }
        Try

            Dim ws As New wsTicket.ServizioRemoto
            Dim list As wsTicket.Biglietto() = ws.RecuperaBiglietti(NumTel, IdMan)
            Dim items As New List(Of ItemTicketViewModel)
            For Each item In list
                Dim row As New ItemTicketViewModel
                row.NumBiglietto = item.CodiceBiglietto
                row.QRCode = item.QRCode
                row.NomeEvento = item.NomeEvento
                row.DataEvento = item.DataEvento
                row.filaeposto = item.filaeposto
                row.Prezzo = item.Prezzo
                row.Prevendita = item.Prevendita
                row.Totale = item.Totale
                row.SCN = item.SCN
                row.SCP = item.SCP
                row.SCMAC = item.SCMAC
                row.Titolare = item.Titolare
                row.Organizzatore = item.Organizzatore
                row.DataEmissione = item.DataEmissione
                row.Sistema = item.Sistema
                row.TipoTitolo = item.TipoTitolo
                row.DescTitolo = item.DescTitolo
                row.Modificato = item.Modificato
                items.Add(row)
            Next
            model.items = items
        Catch ex As Exception
            model.exception = True
        End Try
        Return model
    End Function

    <WebMethod()>
    Public Function AddRegistry(Nome As String, Cognome As String, NumBiglietto As String) As BaseViewModel
        Dim viewModel As New BaseViewModel With {
            .Exception = False
        }
        Try
            If String.IsNullOrEmpty(Nome) Then
                viewModel.Exception = True
                viewModel.ExceptionMessage = String.Format("{1} {0}: inserire il nome", NumBiglietto, Resources.ticket.numBiglietto)
                Return viewModel
            End If
            If String.IsNullOrEmpty(Cognome) Then
                viewModel.Exception = True
                viewModel.ExceptionMessage = String.Format("{1} {0}: inserire il cognome", NumBiglietto, Resources.ticket.numBiglietto)
                Return viewModel
            End If
            Dim ws As New wsTicket.ServizioRemoto
            If ws.InserisciAnagrafica(Nome, Cognome, NumBiglietto) = False Then
                viewModel.Exception = True
                viewModel.ExceptionMessage = String.Format("{1} {0}: {2}", NumBiglietto, Resources.ticket.numBiglietto, Resources.ticket.erroreAnagrafica)
            End If
        Catch ex As Exception
            viewModel.Exception = True
            viewModel.ExceptionMessage = ex.Message
        End Try
        Return viewModel
    End Function





End Class