(function () {
    "use strict";

    angular.module("northwindApp").controller("ShipperController", ShipperController);
    angular.module("northwindApp").controller("CreateShipperController", CreateShipperController);
    angular.module("northwindApp").controller("EditShipperController", EditShipperController);

    ShipperController.$inject = ["$scope", "$location", "$routeParams", "ngTableParams", "$filter", "UnitOfWork", "TranslationService"];
    CreateShipperController.$inject = ["$scope", "$location", "UnitOfWork", "TranslationService"];
    EditShipperController.$inject = ["$scope", "$location", "$routeParams", "UnitOfWork", "TranslationService"];

    function ShipperController($scope, $location, $routeParams, ngTableParams, $filter, uow, translationService) {
        $scope.result = [];

        uow.shipperRepository.get().then(function (result) {
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

    function CreateShipperController($scope, $location, uow, translationService) {
        $scope.result = {};

        translationService.setResource($scope);

        $scope.create = function () {
            uow.shipperRepository.create($scope.result.model);

            $location.path("/shipper");
        };

        $scope.cancel = function () {
            $location.path("/shipper");
        };
    };

    function EditShipperController($scope, $location, $routeParams, uow, translationService) {
        $scope.result = {};

        uow.shipperRepository.get($routeParams.id).then(function (result) {
            $scope.result = result.data;
        });

        translationService.setResource($scope);

        $scope.edit = function (id) {
            $location.path("/shipper-edit/" + id);
        };

        $scope.update = function () {
            uow.shipperRepository.put($scope.result.model.shipperID, $scope.result.model);

            $location.path("/shipper");
        };

        $scope.delete = function () {
            uow.shipperRepository.delete($scope.result.model.shipperID, $scope.result.model);

            $location.path("/shipper");
        };

        $scope.cancel = function () {
            $location.path("/shipper");
        };
    };
})();
