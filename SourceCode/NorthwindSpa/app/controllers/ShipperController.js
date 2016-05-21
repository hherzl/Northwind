(function (app) {
    "use strict";

    app.controller("ShipperController", ShipperController);
    app.controller("CreateShipperController", CreateShipperController);
    app.controller("EditShipperController", EditShipperController);
    app.controller("DeleteShipperController", DeleteShipperController);

    ShipperController.$inject = ["$log", "$location", "$routeParams", "$filter", "toaster", "ngTableParams", "UnitOfWork", "TranslationService"];
    CreateShipperController.$inject = ["$log", "$location", "UnitOfWork", "TranslationService"];
    EditShipperController.$inject = ["$log", "$location", "$routeParams", "UnitOfWork", "TranslationService"];
    DeleteShipperController.$inject = ["$log", "$location", "$routeParams", "UnitOfWork", "TranslationService"];

    function ShipperController($log, $location, $routeParams, $filter, toaster, ngTableParams, uow, translationService) {
        var vm = this;

        vm.result = {};

        toaster.pop("wait", "Notification", "Loading shippers...");

        uow.shipperRepository.get().then(function (result) {
            vm.result = result.data;

            if (!vm.result.didError) {
                toaster.pop("success", "Message", "Shippers data was loaded successfully!");

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
            }
        });

        translationService.setResource(vm);

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

        translationService.setResource(vm);

        vm.create = function () {
            uow.shipperRepository.post(vm.result.model).then(function (result) {
                $location.path("/shipper");
            });
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

        translationService.setResource(vm);

        vm.edit = function (id) {
            $location.path("/shipper-edit/" + id);
        };

        vm.save = function () {
            uow.shipperRepository.put(vm.result.model.shipperID, vm.result.model).then(function (result) {
                $location.path("/shipper");
            });
        };

        vm.cancel = function () {
            $location.path("/shipper");
        };
    };

    function DeleteShipperController($log, $location, $routeParams, uow, translationService) {
        var vm = this;

        translationService.setResource(vm);

        vm.result = {};
        vm.requestResult = {};

        var id = $routeParams.id;

        uow.shipperRepository.get(id).then(function (result) {
            vm.result = result.data;
        });

        vm.delete = function () {
            uow.shipperRepository.delete(id).then(function (result) {
                if (result.data.didError) {
                    vm.requestResult = result.data;
                } else {
                    $location.path("/shipper");
                }
            });
        };

        vm.cancel = function () {
            $location.path("/shipper/details/" + id);
        };
    };
})(angular.module("northwindApp"));
