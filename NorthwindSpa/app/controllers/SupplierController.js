(function () {
    "use strict";

    angular.module("northwindApp").controller("SupplierController", SupplierController);
    angular.module("northwindApp").controller("CreateSupplierController", CreateSupplierController);
    angular.module("northwindApp").controller("EditSupplierController", EditSupplierController);

    SupplierController.$inject = ["$log", "$scope", "$location", "$routeParams", "ngTableParams", "$filter", "UnitOfWork"];
    CreateSupplierController.$inject = ["$scope", "$location", "UnitOfWork"];
    EditSupplierController.$inject = ["$scope", "$location", "$routeParams", "UnitOfWork"];

    function SupplierController($log, $scope, $location, $routeParams, ngTableParams, $filter, uow) {
        $scope.result = {};

        uow.supplierRepository.get().then(function (result) {
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
            $location.path("/supplier-create");
        };

        $scope.details = function (obj) {
            $location.path("/supplier-details/" + obj.supplierID);
        };

        $scope.edit = function (id) {
            $location.path("/supplier-edit/" + id);
        };

        $scope.delete = function (id) {
            $location.path("/supplier-delete/" + id);
        };
    };

    function CreateSupplierController($scope, $location, uow) {
        $scope.model = {};

        $scope.create = function () {
            uow.supplierRepository.post($scope.result.model).then(function (result) {
                if (result.data.didError) {

                } else {
                    $location.path("/suppliers");
                }
            });
        };

        $scope.cancel = function () {
            $location.path("/suppliers");
        };
    };

    function EditSupplierController($scope, $location, $routeParams, uow) {
        $scope.result = {};

        uow.supplierRepository.get($routeParams.id).then(function (result) {
            $scope.result = result.data;
        });

        $scope.edit = function (id) {
            $location.path("/supplier-edit/" + id);
        };

        $scope.update = function () {
            uow.supplierRepository.put($scope.result.model.supplierID, $scope.result.model);

            $location.path("/suppliers");
        };

        $scope.delete = function () {
            uow.supplierRepository.delete($scope.result.model.supplierID, $scope.result.model);

            $location.path("/suppliers");
        };

        $scope.cancel = function () {
            $location.path("/suppliers");
        };
    };
})();
