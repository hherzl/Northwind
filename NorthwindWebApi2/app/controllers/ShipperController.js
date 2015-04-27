(function () {
    "use strict";

    angular.module("northwindApp").controller("ShipperController", ShipperController);
    angular.module("northwindApp").controller("CreateShipperController", CreateShipperController);
    angular.module("northwindApp").controller("EditShipperController", EditShipperController);

    ShipperController.$inject = ["$scope", "$location", "$routeParams", "ngTableParams", "$filter", "ShipperService", "TranslationService"];
    CreateShipperController.$inject = ["$scope", "$location", "ShipperService", "TranslationService"];
    EditShipperController.$inject = ["$scope", "$location", "$routeParams", "ShipperService", "TranslationService"];

    function ShipperController($scope, $location, $routeParams, ngTableParams, $filter, shipperService, translationService) {
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

        translationService.setResource($scope);

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
    };

    function CreateShipperController($scope, $location, shipperService, translationService) {
        $scope.model = {};

        translationService.setResource($scope);

        $scope.create = function () {
            shipperService.create($scope.model);

            $location.path("/shipper");
        };

        $scope.cancel = function () {
            $location.path("/shipper");
        };
    };

    function EditShipperController($scope, $location, $routeParams, shipperService, translationService) {
        $scope.model = {};

        shipperService.get($routeParams.id).then(function (result) {
            $scope.model = result.data;
        });

        translationService.setResource($scope);

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
    };
})();
