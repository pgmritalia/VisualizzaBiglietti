<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="VisualizzaBiglietti._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/qrcode.min.js"></script>
 
    <div class="row">
        <div class="col-md-4">
            <h6 style="text-align:center">Ecco i tuoi biglietti</h6>
            <hr />
            <%--<div>
            <p style="text-align:center">
              @@NUMBIGLIETTO@@
            </p>
            <div style="align-items:center" id="@@QRID@@"></div>
                <script type="text/javascript">
                new QRCode(document.getElementById("@@QRID@@"), "@@QRCODE@@");
                </script>
            <br />
            <p> 
              
                <table style="width: 100%;">
                   <tr>
                        <td>Tit        :</td>
                        <td><b>@@TITOLARE@@</b></td>
                        
                    </tr>
                    <tr>
                        <td>Org        :</td>
                        <td><b>@@ORGANIZZATORE@@</b></td>
                        
                    </tr>
                    <tr>
                        <td>Evento        :</td>
                        <td><b>@@EVENTO@@</b></td>
                        
                    </tr>
                    <tr>
                        <td>Data        :</td>
                        <td><b>@@DATA@@</b></td>
                        
                    </tr>
                    <tr>
                        <td>Dove        :</td>
                        <td><b>@@DOVE@@</b></td>
                        
                    </tr>
                    <tr>
                        <td> Prezzo      : </td>
                        <td><b>@@PREZZO@@</b></td>
                        
                    </tr>
                    <tr>
                        <td>Prevendita  :</td>
                        <td><b>@@PREVENDITA@@</b></td>
                       
                    </tr>
                     <tr>
                        <td>Totale      :</td>
                        <td><b>@@TOTALE@@</b></td>
                        
                    </tr>
                    <tr>
                        <td>SCN         :</td>
                        <td><b>@@SCN@@</b></td>
                        
                    </tr>
                    <tr>
                        <td>SCP         :</td>
                        <td><b>@@SCP@@</b></td>
                       
                    </tr>
                     <tr>
                        <td>SCMAC       :</td>
                        <td><b>@@SCMAC@@</b></td>
                       
                    </tr>
                </table>
            </p>
                
            </div>--%>
            
            <asp:Literal ID="ElencoBiglietti" runat="server"></asp:Literal>
            </div>
       
    </div>

</asp:Content>
