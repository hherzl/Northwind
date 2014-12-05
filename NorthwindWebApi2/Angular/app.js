(function () {
    "use strict";

    var app = angular.module("app", []);

    app.controller("ProductCtrl", ["$http", "$scope", function ($http, $scope) {
        $scope.products = [];

        $http.get("/api/Product").success(function (data) {
            $scope.products = data;
        });
    }]);

    app.controller("CustomerCtrl", ["$http", "$scope", function ($http, $scope) {
        $scope.customers = [];

        $http.get("/api/Customer").success(function (data) {
            $scope.customers = data;
        });
    }]);
})();
