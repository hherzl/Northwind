(function () {
    "use strict";

    northwindApp.controller("ShipperController", ["$scope", "$location", "$routeParams", "$cookies", "ngTableParams", "$filter", "ShipperService", "TranslationService", function ($scope, $location, $routeParams, $cookies, ngTableParams, $filter, shipperService, translationService) {
        $scope.result = [];

        shipperService.getAll().then(function (result) {
            $scope.result = result.data;

            $scope.tableParams = new ngTableParams({
                page: 1,
                count: 10,
                sorting: {
                    name: "asc"
                }
            }, {
                total: $scope.result.model.length,
                getData: function ($defer, params) {
                    var orderedData = params.sorting() ? $filter("orderBy")($scope.result.model, params.orderBy()) : $scope.result.model;

                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                }
            });
        });

        translationService.getTranslation($scope, $cookies.lang);

        $scope.create = function () {
            $location.path("/shipper-create");
        };

        $scope.details = function (id) {
            $location.path("/shipper-details/" + id);
        };

        $scope.edit = function (id) {
            $location.path("/shipper-edit/" + id);
        };

        $scope.delete = function (id) {
            $location.path("/shipper-delete/" + id);
        };
    }]);

    northwindApp.controller("CreateShipperController", ["$scope", "$location", "$cookies", "ShipperService", "TranslationService", function ($scope, $location, $cookies, shipperService, translationService) {
        $scope.model = {};

        translationService.getTranslation($scope, $cookies.lang);

        $scope.create = function () {
            shipperService.create($scope.model);

            $location.path("/shipper");
        };

        $scope.cancel = function () {
            $location.path("/shipper");
        };
    }]);

    northwindApp.controller("EditShipperController", ["$scope", "$location", "$routeParams", "$cookies", "ShipperService", "TranslationService", function ($scope, $location, $routeParams, shipperService, translationService) {
        $scope.model = {};

        shipperService.get($routeParams.id).then(function (result) {
            $scope.model = result.data;
        });

        translationService.getTranslation($scope, $cookies.lang);

        $scope.edit = function (id) {
            $location.path("/shipper-edit/" + id);
        };

        $scope.update = function () {
            shipperService.update($scope.model);

            $location.path("/shipper");
        };

        $scope.delete = function () {
            shipperService.delete($scope.model);

            $location.path("/shipper");
        };

        $scope.cancel = function () {
            $location.path("/shipper");
        };
    }]);
})();
