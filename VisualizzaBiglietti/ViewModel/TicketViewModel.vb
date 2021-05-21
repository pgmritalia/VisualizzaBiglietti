Public Class TicketViewModel
    Public Property items As List(Of ItemTicketViewModel)
    Public Property exception As Boolean
    Public ReadOnly Property showGrid As Boolean
        Get
            Dim result = (From p In items Where p.Modificato = False).Count
            If result > 0 Then
                Return False
            Else
                Return True
            End If
        End Get
    End Property
    Public ReadOnly Property showRegistry As Boolean
        Get
            Dim result = (From p In items Where p.Modificato = False).Count
            If result > 0 Then
                Return True
            Else
                Return False
            End If
        End Get
    End Property


End Class
