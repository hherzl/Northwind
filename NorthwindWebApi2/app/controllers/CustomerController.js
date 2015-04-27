(function () {
    "use strict";

    northwindApp.controller("CustomerController", CustomerController);
    northwindApp.controller("CreateCustomerController", CreateCustomerController);
    northwindApp.controller("EditCustomerController", EditCustomerController);

    CustomerController.$inject = ["$log", "$scope", "$location", "$routeParams", "ngTableParams", "$filter", "CustomerService"];
    CreateCustomerController.$inject = ["$scope", "$location", "CustomerService"];
    EditCustomerController.$inject = ["$scope", "$location", "$routeParams", "CustomerService"];

    function CustomerController($log, $scope, $location, $routeParams, ngTableParams, $filter, customerService) {
        $scope.result = {};

        customerService.getAll().then(function (result) {
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

    function CreateCustomerController($scope, $location, customerService) {
        $scope.result = {};

        $scope.create = function () {
            customerService.create($scope.result.model).then(function (result) {
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

    function EditCustomerController($scope, $location, $routeParams, customerService) {
        $scope.result = {};

        customerService.get($routeParams.id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.edit = function (id) {
            $location.path("/customer-edit/" + id);
        };

        $scope.update = function () {
            customerService.update($scope.result.model).then(function (result) {
                if (result.data.didError) {
                    $scope.result = result.data;
                } else {
                    $location.path("/customer");
                }
            });
        };

        $scope.delete = function () {
            customerService.delete($scope.model);

            $location.path("/customer");
        };

        $scope.cancel = function () {
            $location.path("/customer");
        };
    };
})();
