(function (app) {
    "use strict";

    app.controller("CustomerController", CustomerController);
    app.controller("CreateCustomerController", CreateCustomerController);
    app.controller("EditCustomerController", EditCustomerController);

    CustomerController.$inject = ["$log", "$location", "$routeParams", "ngTableParams", "$filter", "UnitOfWork"];
    CreateCustomerController.$inject = ["$log", "$location", "UnitOfWork"];
    EditCustomerController.$inject = ["$log", "$location", "$routeParams", "UnitOfWork"];

    function CustomerController($log, $location, $routeParams, ngTableParams, $filter, uow) {
        var vm = this;

        vm.result = {};

        uow.customerRepository.get().then(function (result) {
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

        vm.create = function () {
            $location.path("/customer-create");
        };

        vm.details = function (id) {
            $location.path("/customer-details/" + id);
        };

        vm.edit = function (id) {
            $location.path("/customer-edit/" + id);
        };

        vm.delete = function (id) {
            $location.path("/customer-delete/" + id);
        };
    };

    function CreateCustomerController($log, $location, uow) {
        var vm = this;

        vm.result = {};

        vm.create = function () {
            uow.customerRepository.create(vm.result.model).then(function (result) {
                if (result.data.didError) {
                    vm.result = result.data;
                } else {
                    $location.path("/customer");
                }
            });
        };

        vm.cancel = function () {
            $location.path("/customer");
        };
    };

    function EditCustomerController($log, $location, $routeParams, uow) {
        var vm = this;

        vm.result = {};

        uow.customerRepository.get($routeParams.id).then(function (result) {
            vm.result = result.data;
        });

        vm.edit = function (id) {
            $location.path("/customer-edit/" + id);
        };

        vm.update = function () {
            uow.customerRepository.update(vm.result.model).then(function (result) {
                if (result.data.didError) {
                    vm.result = result.data;
                } else {
                    $location.path("/customer");
                }
            });
        };

        vm.delete = function () {
            uow.customerRepository.delete(vm.model);

            $location.path("/customer");
        };

        vm.cancel = function () {
            $location.path("/customer");
        };
    };
})(angular.module("northwindApp"));
