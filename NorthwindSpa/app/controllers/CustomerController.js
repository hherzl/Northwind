(function () {
    "use strict";

    angular.module("northwindApp").controller("CustomerController", CustomerController);
    angular.module("northwindApp").controller("CreateCustomerController", CreateCustomerController);
    angular.module("northwindApp").controller("EditCustomerController", EditCustomerController);

    CustomerController.$inject = ["$log", "$scope", "$location", "$routeParams", "ngTableParams", "$filter", "UnitOfWork"];
    CreateCustomerController.$inject = ["$scope", "$location", "UnitOfWork"];
    EditCustomerController.$inject = ["$scope", "$location", "$routeParams", "UnitOfWork"];

    function CustomerController($log, $scope, $location, $routeParams, ngTableParams, $filter, uow) {
        $scope.result = {};

        uow.customerRepository.get().then(function (result) {
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

        $scope.create = function () {
            $location.path("/customer-create");
        };

        $scope.details = function (id) {
            $location.path("/customer-details/" + id);
        };

        $scope.edit = function (id) {
            $location.path("/customer-edit/" + id);
        };

        $scope.delete = function (id) {
            $location.path("/customer-delete/" + id);
        };
    };

    function CreateCustomerController($scope, $location, uow) {
        $scope.result = {};

        $scope.create = function () {
            uow.customerRepository.create($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                } else {
                    $location.path("/customer");
                }
            });
        };

        $scope.cancel = function () {
            $location.path("/customer");
        };
    };

    function EditCustomerController($scope, $location, $routeParams, uow) {
        $scope.result = {};

        uow.customerRepository.get($routeParams.id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.edit = function (id) {
            $location.path("/customer-edit/" + id);
        };

        $scope.update = function () {
            uow.customerRepository.update($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                } else {
                    $location.path("/customer");
                }
            });
        };

        $scope.delete = function () {
            uow.customerRepository.delete($scope.model);

            $location.path("/customer");
        };

        $scope.cancel = function () {
            $location.path("/customer");
        };
    };
})();
