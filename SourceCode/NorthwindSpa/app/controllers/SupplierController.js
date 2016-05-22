(function (app) {
    "use strict";

    app.controller("SupplierController", SupplierController);
    app.controller("CreateSupplierController", CreateSupplierController);
    app.controller("EditSupplierController", EditSupplierController);

    SupplierController.$inject = ["$log", "$location", "$routeParams", "$filter", "toaster", "ngTableParams", "UnitOfWork"];
    CreateSupplierController.$inject = ["$log", "$location", "UnitOfWork"];
    EditSupplierController.$inject = ["$log", "$location", "$routeParams", "UnitOfWork"];

    function SupplierController($log, $location, $routeParams, $filter, toaster, ngTableParams, uow) {
        var vm = this;

        vm.result = {};

        toaster.pop("wait", "Notification", "Loading suppliers...");

        uow.supplierRepository.get().then(function (result) {
            vm.result = result.data;

            if (!vm.result.didError) {
                toaster.pop("success", "Message", "Suppliers data was loaded successfully!");

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

        vm.create = function () {
            $location.path("/supplier-create");
        };

        vm.details = function (obj) {
            $location.path("/supplier-details/" + obj.supplierID);
        };

        vm.edit = function (id) {
            $location.path("/supplier-edit/" + id);
        };

        vm.delete = function (id) {
            $location.path("/supplier-delete/" + id);
        };
    };

    function CreateSupplierController($log, $location, uow) {
        var vm = this;

        vm.model = {};

        vm.create = function () {
            uow.supplierRepository.post(vm.result.model).then(function (result) {
                if (result.data.didError) {

                } else {
                    $location.path("/suppliers");
                }
            });
        };

        vm.cancel = function () {
            $location.path("/suppliers");
        };
    };

    function EditSupplierController($log, $location, $routeParams, uow) {
        var vm = this;

        vm.result = {};

        uow.supplierRepository.get($routeParams.id).then(function (result) {
            vm.result = result.data;
        });

        vm.edit = function (id) {
            $location.path("/supplier-edit/" + id);
        };

        vm.update = function () {
            uow.supplierRepository.put(vm.result.model.supplierID, vm.result.model);

            $location.path("/suppliers");
        };

        vm.delete = function () {
            uow.supplierRepository.delete(vm.result.model.supplierID, vm.result.model);

            $location.path("/suppliers");
        };

        vm.cancel = function () {
            $location.path("/suppliers");
        };
    };
})(angular.module("northwindApp"));
