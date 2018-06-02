var CashController = function ($scope, $http, $filter, ajaxService, $timeout, $location, $translate) {

  
    $scope.names = [{ "Name": "Alfreds Futterkiste", "City": "Berlin", "Country": "Germany" }, { "Name": "Ana Trujillo Emparedados y helados", "City": "México D.F.", "Country": "Mexico" }, { "Name": "Antonio Moreno Taquería", "City": "México D.F.", "Country": "Mexico" }, { "Name": "Around the Horn", "City": "London", "Country": "UK" }, { "Name": "B's Beverages", "City": "London", "Country": "UK" }, { "Name": "Berglunds snabbköp", "City": "Luleå", "Country": "Sweden" }, { "Name": "Blauer See Delikatessen", "City": "Mannheim", "Country": "Germany" }, { "Name": "Blondel père et fils", "City": "Strasbourg", "Country": "France" }, { "Name": "Bólido Comidas preparadas", "City": "Madrid", "Country": "Spain" }, { "Name": "Bon app'", "City": "Marseille", "Country": "France" }, { "Name": "Bottom-Dollar Marketse", "City": "Tsawassen", "Country": "Canada" }, { "Name": "Cactus Comidas para llevar", "City": "Buenos Aires", "Country": "Argentina" }, { "Name": "Centro comercial Moctezuma", "City": "México D.F.", "Country": "Mexico" }, { "Name": "Chop-suey Chinese", "City": "Bern", "Country": "Switzerland" }, { "Name": "Comércio Mineiro", "City": "São Paulo", "Country": "Brazil" }];

    $scope.testingClick = function (name) {
        console.log(name);
    };



    $scope.agents;
    $scope.bringAgents = function () {
        var promise = ajaxService.getData("POST", "/CashCut/BringAgents");

        promise.then(function (result) {
            $scope.agents = result;
            console.log(result);
        });
    }

    $scope.isValid = true;
    $scope.validateButton = function () {
        if (!!$scope.date && !!$scope.usuario) {
            $scope.isValid = false;

        }
    }

    $scope.conceptos;
    $scope.sumResult;
    $scope.sumResult1;
    $scope.sumResult2;
    $scope.sumResult3;
    $scope.sumResult4;

    $scope.reports = function (date, usuario) {
        var promise = ajaxService.getData("POST", "/CashCut/BringCatalog", { date: date, usuario: usuario });
        promise.then(function (result) {
            $scope.objects = result;
            $scope.concepts = result[0].CONCEPT;
          
            console.log($scope.concepts);
            $scope.sumResult = result[1].SUM;
            $scope.sumResult1 = result[2].SUM2;
            $scope.sumResult2 = result[3].SUM3;
            $scope.sumResult3 = result[4].SUM4;
            $scope.sumResult4 = result[5].SUM5;
            for (var i = 0; $scope.concepts.length > 0; i++) {
                $scope.concepts[i].DOC.CFECHA = $scope.formatDate($scope.concepts[i].DOC.CFECHA);
            }



        });

    }

    $scope.formatDate = function (date) {
        //dale formate a la fecha
      
            var fechaCorrecta = new Date(parseInt(date.substr(6)));
            return fechaCorrecta;
        }
    


    $scope.sumMil = 0;
    $scope.sumQuinientos = 0;
    $scope.sumDocientos = 0;
    $scope.sumCien = 0;
    $scope.sumCincuenta = 0;
    $scope.sumVeinte = 0;
    $scope.sumDiez = 0;
    $scope.sumCinco = 0;
    $scope.sumDos = 0;
    $scope.sumUno = 0;
    $scope.sumCincuentaCentavos = 0;
    $scope.sumVales = 0;
    $scope.totalValue = 0;
    $scope.sumaVales = function (vales) {
        $scope.sumVales = vales * 1;
    }
   
    $scope.sumFunction = function (value, type) {

        if (type === 1000) {
            $scope.sumMil = value * type;
        }
        else if (type === 500) {
            $scope.sumQuinientos = value * type;
        }
        else if (type === 200) {
            $scope.sumDocientos = value * type;
        }
        else if (type === 100) {
            $scope.sumCien = value * type;
        }
        else if (type === 50) {
            $scope.sumCincuenta = value * type;
        }
        else if (type === 20) {
            $scope.sumVeinte = value * type;
        } else if (type === 10) {
            $scope.sumDiez = value * type;
        } else if (type === 5) {
            $scope.sumCinco = value * type;
        } else if (type === 2) {
            $scope.sumDos = value * type;
        } else if (type === 1) {
            $scope.sumUno = value * type;
        } else if (type === .50) {
            $scope.sumCincuentaCentavos = value * type;
        }

    }


    $scope.sumAllValues = function () {

        $scope.totalValue = $scope.sumMil + $scope.sumDocientos + $scope.sumQuinientos + $scope.sumCien + $scope.sumCincuenta + $scope.sumVeinte + $scope.sumDiez + $scope.sumCinco + $scope.sumDos + $scope.sumUno + $scope.sumCincuentaCentavos + $scope.sumVales;
    }
   
    $scope.isDisabledupdate = true;
    $scope.exportData = function () {
        var blob = new Blob([document.getElementById('export').innerHTML], {
            type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
        });
        saveAs(blob, "Employeereport.xls");
    };
  
}
   



CashController.$inject = ['$scope', '$http', '$filter', 'ajaxService', '$timeout', '$location', '$sce'];
Cash.controller("CashController", CashController);
