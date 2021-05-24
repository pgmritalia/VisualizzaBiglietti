<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="VisualizzaBiglietti._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        element.style {
            display: inline !important;
        }

        /*        img {
            margin-top: 17px !important;
            margin-left: 10px !important;
        }*/

        h3 {
            font-size: 1rem !important;
        }

        .titolare {
            font-size: 9pt !important;
        }

        .info {
            font-size: 10pt !important;
        }

        .eventoposto {
            font-size: 24pt !important;
        }

        img {
            vertical-align: middle;
            border-style: none;
            margin-top: 17px !important;
            margin-left: 15px !important;
            margin-right: 15px !important;
            width: 90%;
        }
    </style>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <div data-ng-controller="ticketController" data-ng-init="init()">
        <script src="Scripts/query.blockUI.js"></script>
        <script src="Scripts/angular.js"></script>
        <script src="Scripts/qrcode/qrcode.js"></script>
        <script src="Scripts/qrcode/angular-qr.js"></script>
        <script src="Scripts/site/ticketController.js"></script>
        <script src="Scripts/toastr.min.js"></script>

        <input type="hidden" id="paramTel" name="paramTel" runat="server" />
        <input type="hidden" id="paramIdMan" name="paramIdMan" runat="server" />

        <input type="hidden" id="paramLoading" name="paramLoading" runat="server" />
        <section class="content">
            <div class="container-fluid">

                <section class="container" data-ng-show="showGrid">
                    <br />
                    <div class="row" data-ng-repeat="item in list">
                        <div class="col-md-12">
                            <article class="cardTK">
                                <div class="row">
                                    <div class="col-md-3">
                                        <div data-ng-init="setCode(item.QRCode)" style="text-align: center">
                                            <qr text="qrcodeString" size="250" image="true"></qr>
                                        </div>
                                    </div>
                                    <div class="col-md-9 card-cont">
                                        <small>{{item.CodBiglietto}}</small><br />
                                        <span class="titolare">{{item.Titolare}}</span><br />
                                        <span class="titolare">{{item.Organizzatore}}</span>
                                        <div class="even-info">
                                            <i class="fa fa-map-marker"></i>
                                            <p class="eventoposto">
                                                {{item.NomeEvento}}
                                            </p>
                                        </div>
                                        <div class="even-date">
                                            <i class="fa fa-calendar"></i>
                                            <p class="titolare">
                                                <span>{{item.DataEvento}}</span>
                                            </p>
                                        </div>
                                        <div class="even-info">
                                            <i class="fa fa-map-pin"></i>
                                            <p class="eventoposto">
                                                {{item.filaeposto}}
                                            </p>
                                        </div>
                                        <div class="even-info">
                                            <i class="fa fa-eur"></i>
                                            <p class="info">
                                                {{item.sezionePrezzo}}
                                            </p>
                                        </div>
                                        <div class="even-info">
                                            <i class="fa fa-info"></i>
                                            <p class="info">
                                                {{item.sezioneInfo}}
                                            </p>
                                        </div>
                                    </div>
                                </div>


                            </article>
                        </div>
                    </div>
                </section>

                <section class="container-fluid" data-ng-show="showRegistry">
                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-header">
                                    <small>
                                        <asp:Literal ID="litDisplay" runat="server"></asp:Literal>
                                    </small>
                                </div>
                            </div>

                        </div>
                    </div>
                    <div class="row" data-ng-repeat="item in list " data-ng-hide="item.Modificato">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-header">
                                    <asp:Literal ID="litBiglietto" runat="server"></asp:Literal>
                                    {{item.CodBiglietto}}
                                </div>
                                <div class="card-body">
                                    <div class="form-row">
                                        <div class="col-6">
                                            <asp:Literal ID="litNome" runat="server"></asp:Literal>
                                            <input type="text" id="name_{{$index}}" class="form-control">
                                        </div>
                                        <div class="col-6">
                                            <asp:Literal ID="litCognome" runat="server"></asp:Literal>
                                            <input type="text" id="surname_{{$index}}" class="form-control">
                                        </div>
                                    </div>

                                </div>
                                <div class="card-footer">
                                    <a href="#" class="btn btn-success" data-ng-click="send(item.NumBiglietto,$index)">
                                        <asp:Literal ID="litConferma" runat="server"></asp:Literal>

                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </div>
        </section>

    </div>




    <%--            <asp:Literal ID="ElencoBiglietti" runat="server"></asp:Literal>
            </div>--%>
</asp:Content>
