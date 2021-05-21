Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports MySql.Data.MySqlClient

' Per consentire la chiamata di questo servizio Web dallo script utilizzando ASP.NET AJAX, rimuovere il commento dalla riga seguente.
<System.Web.Script.Services.ScriptService()>
<System.Web.Services.WebService(Namespace:="https://biglietti.mailticket.it/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class ServizioRemoto
    Inherits System.Web.Services.WebService

    Private Const IpServerCassaNw As String = "10.10.0.7"
    Private Const UserNameDBCassaNw As String = "BigliettiSMS"
    Private Const PasswordDbCassaNw As String = "B!gliett!SmS2021*"
    Private Const DatabaseCassaNw As String = "cassanuova"

    <WebMethod()>
    Public Function RecuperaBiglietti(NumTel As String, IdMan As String) As List(Of Biglietto)
        Dim Mysql As MySqlConnection
        Mysql =
           New MySqlConnection(
                "server=" + IpServerCassaNw + ";user id=" + UserNameDBCassaNw + ";Password=" + PasswordDbCassaNw +
                ";database=" + DatabaseCassaNw + ";persist security info=False")

        Try
            Mysql.Open()

            Using msqlCommand = New MySqlCommand() With {.Connection = Mysql}

                msqlCommand.CommandText = "select * from emissionidigitali where id_man=@IdMan and num_tel=@NumTel"
                msqlCommand.Prepare()
                msqlCommand.Parameters.AddWithValue("@IdMan", IdMan)
                msqlCommand.Parameters.AddWithValue("@NumTel", NumTel)

                Dim reader As MySqlDataReader = msqlCommand.ExecuteReader()

                Dim ElencoBiglietti As New List(Of Biglietto)

                While reader.Read()
                    Dim Bigl As New Biglietto
                    If Not reader.IsDBNull(reader.GetOrdinal("codice_biglietto")) Then
                        Bigl.CodiceBiglietto = reader.GetString("codice_biglietto")
                    Else
                        Bigl.CodiceBiglietto = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("codice_biglietto")) Then
                        Bigl.QRCode = reader.GetString("codice_biglietto")
                    Else
                        Bigl.QRCode = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("cognome")) Then
                        Bigl.Cognome = reader.GetString("cognome")
                    Else
                        Bigl.Cognome = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("data_evento")) Then
                        Bigl.DataEvento = reader.GetString("data_evento")
                    Else
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("filaeposto")) Then
                        Bigl.filaeposto = reader.GetString("filaeposto")
                    Else
                        Bigl.filaeposto = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("nome")) Then
                        Bigl.Nome = reader.GetString("nome")
                    Else
                        Bigl.Nome = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("nome_evento")) Then
                        Bigl.NomeEvento = reader.GetString("nome_evento")
                    Else
                        Bigl.NomeEvento = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("prevendita")) Then
                        Bigl.Prevendita = reader.GetString("prevendita")
                    Else
                        Bigl.Prevendita = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("prezzo")) Then
                        Bigl.Prezzo = reader.GetString("prezzo")
                    Else
                        Bigl.Prezzo = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("sc_mac")) Then
                        Bigl.SCMAC = reader.GetString("sc_mac")
                    Else
                        Bigl.SCMAC = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("sc_n")) Then
                        Bigl.SCN = reader.GetString("sc_n")
                    Else
                        Bigl.SCN = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("sc_prog")) Then
                        Bigl.SCP = reader.GetString("sc_prog")
                    Else
                        Bigl.SCP = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("totale")) Then
                        Bigl.Totale = reader.GetString("totale")
                    Else
                        Bigl.Totale = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("titolare")) Then
                        Bigl.Titolare = reader.GetString("titolare")
                    Else
                        Bigl.Titolare = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("organizzatore")) Then
                        Bigl.Organizzatore = reader.GetString("organizzatore")
                    Else
                        Bigl.Organizzatore = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("dataora_emissione")) Then
                        Bigl.DataEmissione = reader.GetString("dataora_emissione")
                    Else
                        Bigl.DataEmissione = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("codice_sistema")) Then
                        Bigl.Sistema = reader.GetString("codice_sistema")
                    Else
                        Bigl.Sistema = "ND"
                    End If


                    If Not reader.IsDBNull(reader.GetOrdinal("tipo_titolo")) Then
                        Bigl.TipoTitolo = reader.GetString("tipo_titolo")
                    Else
                        Bigl.TipoTitolo = "ND"
                    End If

                    If Not reader.IsDBNull(reader.GetOrdinal("desc_titolo")) Then
                        Bigl.DescTitolo = reader.GetString("desc_titolo")
                    Else
                        Bigl.DescTitolo = "ND"
                    End If

                    If reader.GetInt32("modificato") = 0 Then
                        Bigl.Modificato = False
                    Else
                        Bigl.Modificato = True
                    End If
                    ElencoBiglietti.Add(Bigl)
                End While

                Return ElencoBiglietti

            End Using

            Return Nothing

        Catch e As Exception
            Return Nothing
        Finally
            Mysql.Close()
        End Try
    End Function

    <WebMethod>
    Public Function InserisciAnagrafica(Nome As String, Cognome As String, CodiceBiglietto As String) As Boolean
        Dim Mysql As MySqlConnection
        Mysql =
           New MySqlConnection(
                "server=" + IpServerCassaNw + ";user id=" + UserNameDBCassaNw + ";Password=" + PasswordDbCassaNw +
                ";database=" + DatabaseCassaNw + ";persist security info=False")

        Try
            Mysql.Open()

            Using msqlCommand = New MySqlCommand() With {.Connection = Mysql}

                msqlCommand.CommandText =
                    "UPDATE emissionidigitali SET nome=@Nome, cognome=@Cognome, modificato=1  WHERE  codice_biglietto=@CodTit"
                msqlCommand.Prepare()

                msqlCommand.Parameters.AddWithValue("@CodTit", CodiceBiglietto)
                msqlCommand.Parameters.AddWithValue("@Nome", Nome)
                msqlCommand.Parameters.AddWithValue("@Cognome", Cognome)

                Dim Righe As Integer = msqlCommand.ExecuteNonQuery

                If Righe > 0 Then
                    Return True
                Else
                    Return False
                End If

            End Using

        Catch e As Exception
            Return False
        Finally
            Mysql.Close()
        End Try




    End Function

End Class