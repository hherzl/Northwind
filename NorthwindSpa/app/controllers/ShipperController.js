(function () {
    "use strict";

    angular.module("northwindApp").controller("ShipperController", ShipperController);
    angular.module("northwindApp").controller("CreateShipperController", CreateShipperController);
    angular.module("northwindApp").controller("EditShipperController", EditShipperController);

    ShipperController.$inject = ["$log", "$location", "$routeParams", "ngTableParams", "$filter", "UnitOfWork", "TranslationService"];
    CreateShipperController.$inject = ["$log", "$location", "UnitOfWork", "TranslationService"];
    EditShipperController.$inject = ["$log", "$location", "$routeParams", "UnitOfWork", "TranslationService"];

    function ShipperController($log, $location, $routeParams, ngTableParams, $filter, uow, translationService) {
        var vm = this;

        vm.result = [];

        uow.shipperRepository.get().then(function (result) {
            vm.result = result.data;

            vm.tableParams = new ngTableParams({
                page: 1,
                count: 10,
                sorting: {
                    name: "asc"
                }
            }, {
                total: vm.result.model.length,
                getData: function ($defer, params) {
                    var orderedData = params.sorting() ? $filter("orderBy")(vm.result.model, params.orderBy()) : vm.result.model;

                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                }
            });
        });

        translationService.setResource($scope);

        vm.create = function () {
            $location.path("/shipper-create");
        };

        vm.details = function (id) {
            $location.path("/shipper-details/" + id);
        };

        vm.edit = function (id) {
            $location.path("/shipper-edit/" + id);
        };

        vm.delete = function (id) {
            $location.path("/shipper-delete/" + id);
        };
    };

    function CreateShipperController($log, $location, uow, translationService) {
        var vm = this;

        vm.result = {};

        translationService.setResource($scope);

        vm.create = function () {
            uow.shipperRepository.create(vm.result.model);

            $location.path("/shipper");
        };

        vm.cancel = function () {
            $location.path("/shipper");
        };
    };

    function EditShipperController($log, $location, $routeParams, uow, translationService) {
        var vm = this;

        vm.result = {};

        uow.shipperRepository.get($routeParams.id).then(function (result) {
            vm.result = result.data;
        });

        translationService.setResource($scope);

        vm.edit = function (id) {
            $location.path("/shipper-edit/" + id);
        };

        vm.update = function () {
            uow.shipperRepository.put(vm.result.model.shipperID, vm.result.model);

            $location.path("/shipper");
        };

        vm.delete = function () {
            uow.shipperRepository.delete(vm.result.model.shipperID, vm.result.model);

            $location.path("/shipper");
        };

        vm.cancel = function () {
            $location.path("/shipper");
        };
    };
})();
