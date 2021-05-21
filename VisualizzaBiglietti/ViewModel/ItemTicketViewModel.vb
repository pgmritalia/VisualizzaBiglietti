Public Class ItemTicketViewModel
    Public Property NumBiglietto As String
    Public Property QRCode As String
    Public Property NomeEvento As String
    Public Property DataEvento As String
    Public Property filaeposto As String
    Public Property Prezzo As String
    Public Property Prevendita As String
    Public Property Totale As String
    Public Property SCN As String
    Public Property SCP As String
    Public Property SCMAC As String
    Public Property Titolare As String
    Public Property Organizzatore As String
    Public Property DataEmissione As String
    Public Property Sistema As String
    Public Property TipoTitolo As String
    Public Property DescTitolo As String
    Public Property Modificato As Boolean

    Public ReadOnly Property sezionePrezzo As String
        Get

            Return String.Format("{3}: {0} - {4}: {1} - {5}: {2}", Prezzo, Prevendita, Totale, Resources.ticket.prezzo, Resources.ticket.prevendita, Resources.ticket.totale)
        End Get
    End Property
    Public ReadOnly Property sezioneInfo As String
        Get

            Return String.Format("SCN: {0} - SCP: {1} - SCMAC: {2}", SCN, SCP, SCMAC)
        End Get
    End Property

End Class
