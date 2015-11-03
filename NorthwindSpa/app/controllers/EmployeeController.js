(function () {
    "use strict";

    angular.module("northwindApp").controller("EmployeeController", EmployeeController);

    EmployeeController.$inject = ["$log", "$scope", "$location", "$routeParams", "toaster", "ngTableParams", "$filter", "UnitOfWork"];

    function EmployeeController($log, $scope, $location, $routeParams, toaster, ngTableParams, $filter, uow) {
        toaster.pop("wait", "Message", "Loading Regions...");

        $scope.result = {};

        uow.employeeRepository.get().then(function (result) {
            $scope.result = result.data;

            if (!$scope.result.didError) {
                toaster.pop("success", "Message", "Employees data was loaded successfully!");
            }

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
            $location.path("/employee-create");
        };

        $scope.details = function (id) {
            $location.path("/employee-details/" + id);
        };

        $scope.edit = function (id) {
            $location.path("employee-edit/" + id);
        };

        $scope.delete = function (id) {
            $location.path("/employee-delete/" + id);
        };
    };
})();
