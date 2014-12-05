(function () {
    "use strict";

    var app = angular.module("app", []);

    app.controller("ProductController", ["$http", "$scope", function ($http, $scope) {
        $scope.products = [];

        $http.get("http://localhost:58532/api/Product").success(function (data) {
            $scope.products = data;
        });
    }]);
})();
