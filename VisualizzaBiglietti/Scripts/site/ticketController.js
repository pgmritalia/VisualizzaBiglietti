var app = angular.module("MyApp", ['ja.qr']);

app.controller("ticketController", function ($scope) {

    $scope.showRegistry = false;
    $scope.showGrid = false;
    $scope.list = null;

    function block() {
        var msg = $("input[name*='paramLoading']").val();
        $.blockUI({ message: msg });
    }

    $scope.init = function () {
        block();
        // $.blockUI({ message: "Ui is blocked" });
        $scope.showRegistry = false;
        $scope.showGrid = false;
        $scope.list = null;


        var nTel = $("input[name*='paramTel']").val();
        var nIdMan = $("input[name*='paramIdMan']").val();

        var url = "../service.asmx/GetTickets";
        var obj = {
            NumTel: nTel,
            IdMan: nIdMan
        };
        var json = JSON.stringify(obj);
        $.ajax({
            type: "POST",
            url: url,
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (r) {

                $scope.showRegistry = r.d.showRegistry;
                $scope.showGrid = r.d.showGrid;
                $scope.list = r.d.items;
                $scope.$apply();

                $.unblockUI();
            },
            error: function (r) {
                console.log(r);
                $.unblockUI();
            },
            failure: function (r) {
                console.log(r);
                $.unblockUI();
            }
        });



    }

    $scope.send = function (numBiglietto, index) {
        block();
        var name = $("#name_" + index).val();
        var surname = $("#surname_" + index).val();
        var obj = {
            Nome: name,
            Cognome: surname,
            NumBiglietto: numBiglietto
        };
        var url = "../service.asmx/AddRegistry";
        var json = JSON.stringify(obj);
        $.ajax({
            type: "POST",
            url: url,
            data: json,
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (r) {
                $.unblockUI();
                if (r.d.Exception) {
                    toastr.error(r.d.ExceptionMessage);
                }
                else {
                    $scope.init();
                }
            },
            error: function (r) {
                $.unblockUI();
                toastr.error(r);
            }
        });
    }


    $scope.setCode = function (code) {
        $scope.qrcodeString = code;
    }

});